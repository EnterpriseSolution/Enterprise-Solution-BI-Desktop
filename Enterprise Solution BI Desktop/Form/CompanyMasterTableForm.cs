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
    public partial class CompanyMasterTableForm : FormBase
    {
        private string _tableNameMaster= "Company";

        public CompanyMasterTableForm()
        {
            InitializeComponent();          
          
            gridMaster.ColumnAdded += dataGrid_ColumnAdded;
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

            gridMaster.CellContentDoubleClick += GridMaster_CellContentDoubleClick;
            gridMaster.CellDoubleClick += GridMaster_CellContentDoubleClick;

            gridMaster.AutoResizeColumns();
            
            GetData();

            gridMaster.AutoResizeColumns();
            this.Description =string.Format("Master [{0}]",_tableNameMaster);
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
            System.Data.SqlClient.SqlConnectionStringBuilder builer = new System.Data.SqlClient.SqlConnectionStringBuilder(Program.ConnectionString);            
            Database database = new SqlDatabase(builer.ConnectionString);
            DbCommand cmd = database.GetSqlStringCommand(string.Format(Command.ALL_ROWS, _tableNameMaster));
            DataSet dataSetParent = database.ExecuteDataSet(cmd);
            DataTable tableParent = dataSetParent.Tables[0];
            tableParent.TableName = _tableNameMaster;

            DataSet data = new DataSet();
            data.Locale = System.Globalization.CultureInfo.InvariantCulture;
            data.Tables.Add(tableParent.Copy());

            bindingSourceMaster.DataSource = data;
            bindingSourceMaster.DataMember = _tableNameMaster;
        }
    }
}
