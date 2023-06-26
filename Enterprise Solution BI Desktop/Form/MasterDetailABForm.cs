using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

namespace EnterpriseSolutionBIDesktop
{
    public partial class MasterDetailABForm : FormBase
    {
        //private string _dbname;
        private string _tableNameMaster;
        private string _tableNameDetailA;
        private string _tableNameDetailB;
        private string _tableNameDetailDetailB;

        private List<string> _relationMasterColumns;
        private List<string> _relationDetailColumnAs;

        private List<string> _relationDetailColumnBs;
        private List<string> _relationChildDetailColumns;
        private List<string> _relationChildDetailColumnsB;

        public MasterDetailABForm(string dbname,string tableNameMaster,string tableNameDetailA,string tableNameDetailB, List<string> relationMasterColumns, List<string> relationDetailColumnAs, List<string> _relationDetailColumnBs)
        {
            InitializeComponent();
            this.InitialCatalog = dbname;
            this._tableNameMaster = tableNameMaster;
            this._tableNameDetailA = tableNameDetailA;
            this._tableNameDetailB = tableNameDetailB;

            this._relationMasterColumns = relationMasterColumns;
            this._relationDetailColumnAs = relationDetailColumnAs;
            this._relationDetailColumnBs = _relationDetailColumnBs;
            
            gridMaster.ColumnAdded += dataGrid_ColumnAdded;
            gridDetailDetailA.ColumnAdded += dataGrid_ColumnAdded;
            gridDetailDetailB.ColumnAdded += dataGrid_ColumnAdded;
        }

        void dataGrid_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            DataGridView grid = sender as DataGridView;
            if (e.Column.CellType == typeof(DataGridViewImageCell))
                grid.Columns.Remove(e.Column);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.Description = string.Format("Master/Detail/Detail [{0} / {1} / {2}]", _tableNameMaster, _tableNameDetailA,_tableNameDetailB);

            gridMaster.DataSource = bindingSourceMaster;
            gridMaster.AutoGenerateColumns = true;
            
            gridDetailDetailA.DataSource = bindingSourceDetailA;
            gridDetailDetailA.AutoGenerateColumns = true;
            gridDetailDetailB.DataSource = bindingSourceDetailB;
            gridDetailDetailB.AutoGenerateColumns = true;

            GetData();

            gridMaster.AutoResizeColumns();
            gridDetailDetailA.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            gridDetailDetailB.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //ColumnStyle(gridMaster, _tableNameMaster);
            //ColumnStyle(gridDetailDetailA, _tableNameDetailA);
            //ColumnStyle(gridDetailDetailB, _tableNameDetailB);
        }

        private void GetData()
        {
            SqlConnectionStringBuilder builer = new SqlConnectionStringBuilder(Program.ConnectionString);
            builer.InitialCatalog = InitialCatalog;
            Database database = new SqlDatabase(builer.ConnectionString);
            DbCommand cmd = database.GetSqlStringCommand(string.Format(Command.ALL_ROWS, _tableNameMaster));
            DataSet dataSetParent = database.ExecuteDataSet(cmd);
            DataTable tableParent = dataSetParent.Tables[0];
            tableParent.TableName = _tableNameMaster;

            cmd = database.GetSqlStringCommand(string.Format(Command.ALL_ROWS, _tableNameDetailA));
            DataSet dataSetChild = database.ExecuteDataSet(cmd);
            DataTable tableChildA = dataSetChild.Tables[0];
            tableChildA.TableName = _tableNameDetailA;

            cmd = database.GetSqlStringCommand(string.Format(Command.ALL_ROWS, _tableNameDetailB));
            DataSet dataSetChildChild = database.ExecuteDataSet(cmd);
            DataTable tableChildB = dataSetChildChild.Tables[0];
            tableChildB.TableName = _tableNameDetailB;

            DataSet data = new DataSet();
            data.Locale = System.Globalization.CultureInfo.InvariantCulture;
            data.Tables.Add(tableParent.Copy());
            data.Tables.Add(tableChildA.Copy());
            data.Tables.Add(tableChildB.Copy());
            
            tabPageA.Text = _tableNameDetailA;
            tabPageB.Text = _tableNameDetailB;

            List<DataColumn> masterColumns = new List<DataColumn>();
            foreach (string relationColumn in _relationMasterColumns)
            {
                masterColumns.Add(data.Tables[_tableNameMaster].Columns[relationColumn]);
            }
            List<DataColumn> detailColumnAs = new List<DataColumn>();
            foreach (string relationColumn in _relationDetailColumnAs)
            {
                detailColumnAs.Add(data.Tables[_tableNameDetailA].Columns[relationColumn]);
            }
            string relationNameA = _tableNameMaster + _tableNameDetailA;
            DataRelation relationA = new DataRelation(relationNameA, masterColumns.ToArray(), detailColumnAs.ToArray(),false);
            data.Relations.Add(relationA);

            string relationNameB = _tableNameMaster + _tableNameDetailB;
            List<DataColumn> detailColumnBs = new List<DataColumn>();
            foreach (string relationColumn in _relationMasterColumns)
            {
                detailColumnBs.Add(data.Tables[_tableNameMaster].Columns[relationColumn]);
            }
            List<DataColumn> childDetailColumnBs = new List<DataColumn>();
            foreach (string relationColumn in _relationDetailColumnBs)
            {
                childDetailColumnBs.Add(data.Tables[_tableNameDetailB].Columns[relationColumn]);
            }
            DataRelation relationB = new DataRelation(relationNameB, detailColumnBs.ToArray(), childDetailColumnBs.ToArray(),false);
            data.Relations.Add(relationB);
            
            bindingSourceMaster.DataSource = data;
            bindingSourceMaster.DataMember = _tableNameMaster;
            
            bindingSourceDetailA.DataSource = bindingSourceMaster;
            bindingSourceDetailA.DataMember = relationNameA;
            
            bindingSourceDetailB.DataSource = bindingSourceMaster;
            bindingSourceDetailB.DataMember = relationNameB;           
        }
    }
}
