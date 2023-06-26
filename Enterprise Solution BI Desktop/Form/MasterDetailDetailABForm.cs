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
    public partial class MasterDetailDetailABForm : FormBase
    {
        //private string _dbname;
        private string _tableNameMaster;
        private string _tableNameDetail;
        private string _tableNameDetailDetailA;
        private string _tableNameDetailDetailB;

        private List<string> _relationMasterColumns;
        private List<string> _relationDetailColumns;

        private List<string> _relationChildMasterColumns;
        private List<string> _relationChildDetailColumns;
        private List<string> _relationChildDetailColumnsB;

        public MasterDetailDetailABForm(string dbname,string tableNameMaster,string tableNameDetail,string tableNameDetailDetailA, string tableNameDetailDetailB, List<string> relationMasterColumns, List<string> relationDetailColumns, List<string> _relationChildMasterColumns, List<string> _relationChildDetailColumns, List<string> relationChildDetailColumnsB)
        {
            InitializeComponent();
            this.InitialCatalog = dbname;
            this._tableNameMaster = tableNameMaster;
            this._tableNameDetail = tableNameDetail;
            this._tableNameDetailDetailA = tableNameDetailDetailA;
            this._tableNameDetailDetailB = tableNameDetailDetailB;

            this._relationMasterColumns = relationMasterColumns;
            this._relationDetailColumns = relationDetailColumns;

            this._relationChildMasterColumns = _relationChildMasterColumns;
            this._relationChildDetailColumns = _relationChildDetailColumns;
            this._relationChildDetailColumnsB = relationChildDetailColumnsB;

            gridMaster.ColumnAdded += dataGrid_ColumnAdded;
            gridDetail.ColumnAdded += dataGrid_ColumnAdded;
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
            this.Description = string.Format("Master/Detail/Detail [{0} / {1} / {2} / {3}]", _tableNameMaster, _tableNameDetail,_tableNameDetailDetailA,_tableNameDetailDetailB);

            gridMaster.DataSource = bindingSourceMaster;
            gridMaster.AutoGenerateColumns = true;
            gridDetail.DataSource = bindingSourceDetail;
            gridDetail.AutoGenerateColumns = true;
            gridDetailDetailA.DataSource = bindingSourceDetailDetail;
            gridDetailDetailA.AutoGenerateColumns = true;
            gridDetailDetailB.DataSource = bindingSourceDetailDetailB;
            gridDetailDetailB.AutoGenerateColumns = true;

            GetData();

            //ColumnStyle(gridMaster, _tableNameMaster);
            //ColumnStyle(gridDetail, _tableNameDetail);
            //ColumnStyle(gridDetailDetailA, _tableNameDetailDetailA);
            //ColumnStyle(gridDetailDetailB, _tableNameDetailDetailB);

            gridMaster.AutoResizeColumns();
            gridDetail.AutoSizeColumnsMode =DataGridViewAutoSizeColumnsMode.AllCells;
            gridDetailDetailA.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            gridDetailDetailB.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
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

            cmd = database.GetSqlStringCommand(string.Format(Command.ALL_ROWS, _tableNameDetail));
            DataSet dataSetChild = database.ExecuteDataSet(cmd);
            DataTable tableChild = dataSetChild.Tables[0];
            tableChild.TableName = _tableNameDetail;

            cmd = database.GetSqlStringCommand(string.Format(Command.ALL_ROWS, _tableNameDetailDetailA));
            DataSet dataSetChildChild = database.ExecuteDataSet(cmd);
            DataTable tableChildChild = dataSetChildChild.Tables[0];
            tableChildChild.TableName = _tableNameDetailDetailA;

            cmd = database.GetSqlStringCommand(string.Format(Command.ALL_ROWS, _tableNameDetailDetailB));
            DataSet dataSetChildChild2 = database.ExecuteDataSet(cmd);
            DataTable tableChildChild2 = dataSetChildChild2.Tables[0];
            tableChildChild2.TableName = _tableNameDetailDetailB;

            DataSet data = new DataSet();
            data.Locale = System.Globalization.CultureInfo.InvariantCulture;
            data.Tables.Add(tableParent.Copy());
            data.Tables.Add(tableChild.Copy());
            data.Tables.Add(tableChildChild.Copy());
            data.Tables.Add(tableChildChild2.Copy());

            tabPageA.Text = _tableNameDetailDetailA;
            tabPageB.Text = _tableNameDetailDetailB;

            List<DataColumn> masterColumns = new List<DataColumn>();
            foreach (string relationColumn in _relationMasterColumns)
            {
                masterColumns.Add(data.Tables[_tableNameMaster].Columns[relationColumn]);
            }
            List<DataColumn> detailColumns = new List<DataColumn>();
            foreach (string relationColumn in _relationDetailColumns)
            {
                detailColumns.Add(data.Tables[_tableNameDetail].Columns[relationColumn]);
            }
            string relationName = _tableNameMaster + _tableNameDetail;
            DataRelation relation = new DataRelation(relationName, masterColumns.ToArray(), detailColumns.ToArray());
            data.Relations.Add(relation);
            
            string relationDetailName = _tableNameMaster + _tableNameDetail +_tableNameDetailDetailA;
            List<DataColumn> childMasterColumns = new List<DataColumn>();
            foreach (string relationColumn in _relationChildMasterColumns)
            {
                childMasterColumns.Add(data.Tables[_tableNameDetail].Columns[relationColumn]);
            }
            List<DataColumn> childDetailColumns = new List<DataColumn>();
            foreach (string relationColumn in _relationChildDetailColumns)
            {
                childDetailColumns.Add(data.Tables[_tableNameDetailDetailA].Columns[relationColumn]);
            }
            DataRelation relationDetail = new DataRelation(relationDetailName, childMasterColumns.ToArray(), childDetailColumns.ToArray());
            data.Relations.Add(relationDetail);
            
            string relationDetailNameB = _tableNameMaster + _tableNameDetail + _tableNameDetailDetailB;
            List<DataColumn> childDetailColumns2 = new List<DataColumn>();
            foreach (string relationColumn in _relationChildDetailColumnsB)
            {
                childDetailColumns2.Add(data.Tables[_tableNameDetailDetailB].Columns[relationColumn]);
            }
            DataRelation relationDetail2 = new DataRelation(relationDetailNameB, childMasterColumns.ToArray(), childDetailColumns2.ToArray());
            data.Relations.Add(relationDetail2);

            bindingSourceMaster.DataSource = data;
            bindingSourceMaster.DataMember = _tableNameMaster;

            bindingSourceDetail.DataSource = bindingSourceMaster;
            bindingSourceDetail.DataMember = relationName;

            bindingSourceDetailDetail.DataSource = bindingSourceDetail;
            bindingSourceDetailDetail.DataMember = relationDetailName;
            
            bindingSourceDetailDetailB.DataSource = bindingSourceDetail;
            bindingSourceDetailDetailB.DataMember = relationDetailNameB;           
        }
    }
}
