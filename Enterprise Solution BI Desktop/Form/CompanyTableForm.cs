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
    public partial class CompanyTableForm : FormBase
    {
        private string _tableNameMaster= "Company";

        public CompanyTableForm()
        {
            InitializeComponent();          
          
            gridMaster.ColumnAdded += dataGrid_ColumnAdded;
            gridOverview.ColumnAdded += dataGrid_ColumnAdded;
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
            gridMaster.DataSource = bindingSourceMaster;
            gridMaster.AutoGenerateColumns = true;
            gridOverview.DataSource = bindingSourceDetail;
            gridOverview.AutoGenerateColumns = true;

            gridMaster.CellContentDoubleClick += GridMaster_CellContentDoubleClick;
            gridMaster.CellDoubleClick += GridMaster_CellContentDoubleClick;

            gridMaster.AutoResizeColumns();
            gridOverview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
           
            GetData();

            gridOverview.Columns["DB_DATABASE"].Visible = false;

            gridMaster.AutoResizeColumns();
            this.Description = string.Format("Master [{0}]",_tableNameMaster);
        }

        private void GridMaster_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (bindingSourceMaster.Current == null || string.IsNullOrWhiteSpace(InitialCatalog))
                return;

            DialogResult = DialogResult.OK;
        }

        public string InitialCatalog
        {
            get
            {
                DataRowView row = bindingSourceMaster.Current as DataRowView;
                return row["DB_DATABASE"].ToString();
            }
        }

        private void GetData()
        {
            SqlConnectionStringBuilder builer = new SqlConnectionStringBuilder(Program.ConnectionString);            
            Database database = new SqlDatabase(builer.ConnectionString);
            DbCommand cmd = database.GetSqlStringCommand(string.Format(Command.ALL_ROWS, _tableNameMaster));
            DataSet dataSetParent = database.ExecuteDataSet(cmd);
            DataTable tableParent = dataSetParent.Tables[0];
            tableParent.TableName = _tableNameMaster;

            DataSet data = new DataSet();
            data.Locale = System.Globalization.CultureInfo.InvariantCulture;
            data.Tables.Add(tableParent.Copy());

            string _tableNameDetail = "Query";
            DataTable query = null;
            
            if (MainForm.CacheDatabaseStatistics == null)
            {
                foreach (DataRow row in tableParent.Rows)
                {
                    builer = new SqlConnectionStringBuilder(Program.ConnectionString);
                    builer.InitialCatalog = row.Field<string>("DB_DATABASE");
                    database = new SqlDatabase(builer.ConnectionString);
                    using (DbCommand dbCommand = database.GetSqlStringCommand(Command.QUERY_DATABASE_SIZE))
                    {
                        DataSet overview = database.ExecuteDataSet(dbCommand);
                        DataTable table = overview.Tables[0];
                        table.Columns.Add("DB_DATABASE", typeof(string));
                        foreach (DataRow dataRow in table.Rows)
                        {
                            dataRow["DB_DATABASE"] = builer.InitialCatalog;
                        }

                        if (query == null)
                            query = table.Copy();
                        else
                            query.Merge(table);
                    }
                }

                query.TableName = _tableNameDetail;
                MainForm.CacheDatabaseStatistics = query;
            }
            else
            {
                query = MainForm.CacheDatabaseStatistics.Copy();
                query.TableName = _tableNameDetail;
            }

            data.Tables.Add(query);

            List<string> _relationMasterColumns=new List<string>(){ "DB_DATABASE" };
            List<string> _relationDetailColumns = new List<string>() { "DB_DATABASE" };

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

            bindingSourceMaster.DataSource = data;
            bindingSourceMaster.DataMember = _tableNameMaster;

            bindingSourceDetail.DataSource = bindingSourceMaster;
            bindingSourceDetail.DataMember = relationName;
        }
    }
}
