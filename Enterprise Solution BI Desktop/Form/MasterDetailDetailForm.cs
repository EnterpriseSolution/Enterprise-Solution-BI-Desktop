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
    public partial class MasterDetailDetailForm : FormBase
    {
        //private string _dbname;
        private string _tableNameMaster;
        private string _tableNameDetail;
        private List<string> _relationMasterColumns;
        private List<string> _relationDetailColumns;
        private string _tableNameDetailDetail;

        private List<string> _relationChildMasterColumns;
        private List<string> _relationChildDetailColumns;

        public MasterDetailDetailForm(string dbname,string tableNameMaster,string tableNameDetail,string tableNameDetailDetail, List<string> relationMasterColumns, List<string> relationDetailColumns, List<string> _relationChildMasterColumns, List<string> _relationChildDetailColumns)
        {
            InitializeComponent();
            this.InitialCatalog = dbname;
            this._tableNameMaster = tableNameMaster;
            this._tableNameDetail = tableNameDetail;
            this._tableNameDetailDetail = tableNameDetailDetail;

            this._relationMasterColumns = relationMasterColumns;
            this._relationDetailColumns = relationDetailColumns;

            this._relationChildMasterColumns = _relationChildMasterColumns;
            this._relationChildDetailColumns = _relationChildDetailColumns;

            gridMaster.ColumnAdded += dataGrid_ColumnAdded;
            gridDetail.ColumnAdded += dataGrid_ColumnAdded;
            gridDetailDetail.ColumnAdded += dataGrid_ColumnAdded;
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
            this.Description = string.Format("Master/Detail/Detail [{0} / {1} / {2}]", _tableNameMaster, _tableNameDetail,_tableNameDetailDetail);

            gridMaster.DataSource = bindingSourceMaster;
            gridMaster.AutoGenerateColumns = true;
            gridDetail.DataSource = bindingSourceDetail;
            gridDetail.AutoGenerateColumns = true;
            gridDetailDetail.DataSource = bindingSourceDetailDetail;
            gridDetailDetail.AutoGenerateColumns = true;

            GetData();

            gridMaster.AutoResizeColumns();

            //ColumnStyle(gridMaster,_tableNameMaster);
            //ColumnStyle(gridDetail, _tableNameDetail);
            //ColumnStyle(gridDetailDetail, _tableNameDetailDetail);

            gridDetail.AutoSizeColumnsMode =DataGridViewAutoSizeColumnsMode.AllCells;
            gridDetailDetail.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
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

            cmd = database.GetSqlStringCommand(string.Format(Command.ALL_ROWS, _tableNameDetailDetail));
            DataSet dataSetChildChild = database.ExecuteDataSet(cmd);
            DataTable tableChildChild = dataSetChildChild.Tables[0];
            tableChildChild.TableName = _tableNameDetailDetail;

            DataSet data = new DataSet();
            data.Locale = System.Globalization.CultureInfo.InvariantCulture;
            data.Tables.Add(tableParent.Copy());
            data.Tables.Add(tableChild.Copy());
            data.Tables.Add(tableChildChild.Copy());

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
            
            string relationDetailName = _tableNameMaster + _tableNameDetail +_tableNameDetailDetail;
            List<DataColumn> childMasterColumns = new List<DataColumn>();
            foreach (string relationColumn in _relationChildMasterColumns)
            {
                childMasterColumns.Add(data.Tables[_tableNameDetail].Columns[relationColumn]);
            }
            List<DataColumn> childDetailColumns = new List<DataColumn>();
            foreach (string relationColumn in _relationChildDetailColumns)
            {
                childDetailColumns.Add(data.Tables[_tableNameDetailDetail].Columns[relationColumn]);
            }
            DataRelation relationDetail = new DataRelation(relationDetailName, childMasterColumns.ToArray(), childDetailColumns.ToArray());
            data.Relations.Add(relationDetail);

            bindingSourceMaster.DataSource = data;
            bindingSourceMaster.DataMember = _tableNameMaster;

            bindingSourceDetail.DataSource = bindingSourceMaster;
            bindingSourceDetail.DataMember = relationName;

            bindingSourceDetailDetail.DataSource = bindingSourceDetail;
            bindingSourceDetailDetail.DataMember = relationDetailName;
        }
    }
}
