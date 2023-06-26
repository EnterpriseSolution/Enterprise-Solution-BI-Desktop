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
    public partial class MasterTableGeneratorForm : FormBase
    {
        private string _dbname;
        private string _tableNameMaster;
        private string _tableNameMasterFilter;
        DataTable _table;

        public MasterTableGeneratorForm(string dbname,string tableNameMaster,string tableNameMasterFilter="")
        {
            InitializeComponent();
            this._dbname = dbname;
            this._tableNameMaster = tableNameMaster;
            _tableNameMasterFilter = tableNameMasterFilter;
            InitialCatalog = dbname;
            gridMaster.ColumnAdded += dataGrid_ColumnAdded;
        }

        public MasterTableGeneratorForm(DataTable table)
        {
            InitializeComponent();
            this._tableNameMaster = table.TableName;
            this._table = table;
            InitialCatalog= table.ExtendedProperties["InitialCatalog"].ToString();
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

           if(!string.IsNullOrWhiteSpace(_dbname))
               GetData();
           else
            {               
                DataSet data = new DataSet();
                //_table.TableName = _tableNameMaster;
                data.Locale = System.Globalization.CultureInfo.InvariantCulture;
                data.Tables.Add(_table.Copy());

                bindingSourceMaster.DataSource = data;
                bindingSourceMaster.DataMember = _tableNameMaster;
            }

            gridMaster.AutoResizeColumns();
            //ColumnStyle(gridMaster,_tableNameMaster);
            this.Description = string.Format("Master [{0}]",_tableNameMaster);
        }

        private void GetData()
        {
            SqlConnectionStringBuilder builer = new SqlConnectionStringBuilder(Program.ConnectionString);
            builer.InitialCatalog = _dbname;
            Database database = new SqlDatabase(builer.ConnectionString);
            DbCommand cmd = database.GetSqlStringCommand(Build(Command.ALL_ROWS, _tableNameMaster,_tableNameMasterFilter));
            DataSet dataSetParent = database.ExecuteDataSet(cmd);
            DataTable tableParent = dataSetParent.Tables[0];
            tableParent.TableName = _tableNameMaster;
           
            DataSet data = new DataSet();
            data.Locale = System.Globalization.CultureInfo.InvariantCulture;
            data.Tables.Add(tableParent.Copy());

            bindingSourceMaster.DataSource = data;
            bindingSourceMaster.DataMember = _tableNameMaster;
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            string insert= $@"SET IDENTITY_INSERT {_tableNameMaster} ON
DECLARE @recnum DECIMAL(8,0)
SET @recnum=1
IF NOT EXISTS(SELECT * FROM dbo.{_tableNameMaster} WHERE RECNUM = @recnum)
BEGIN
      INSERT INTO {_tableNameMaster}(RECNUM)
             VALUES(@recnum)
END

SET IDENTITY_INSERT {_tableNameMaster} OFF";

            DataSet data = bindingSourceMaster.DataSource as DataSet;
            var table = data.Tables[_tableNameMaster];
            List<string> sql=new List<string>(){ insert, Environment.NewLine };
            int index = 0;
            foreach (DataRow row in table.Rows)
            {
                string name = row.Field<string>("ColumnName");
                if (name.Equals("RECNUM", StringComparison.InvariantCultureIgnoreCase))
                    continue;

                string type = row.Field<string>("DataType");
                string value = row.Field<string>("Value");
                string ret = "";
                switch (type)
                {
                    case "nvarchar":
                    case "datetime":
                        ret = $" N'{value}'";
                        break;
                    case "decimal":
                    case "int":
                    case "numeric":
                        ret = string.IsNullOrWhiteSpace(value)? "NULL": value;
                        break;
                    case "bit":
                        ret = string.IsNullOrWhiteSpace(value) ? "NULL" : (Convert.ToBoolean(value) ? "1" : "0");
                        break;
                }

                sql.Add($"UPDATE   {_tableNameMaster}  SET  [{name}]={ret}  WHERE RECNUM=@recnum ");
                index++;
                if (index % 10 == 0)
                {
                    sql.Add(Environment.NewLine);
                }
            }

            txtSql.Text = string.Join(Environment.NewLine, sql);
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtSql.Text);
        }
    }
}
