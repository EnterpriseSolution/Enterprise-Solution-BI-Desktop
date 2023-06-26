using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Windows.Forms;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Microsoft.Win32;

/*
EnumAvailableSqlServers and SqlDataSourceEnumerator will only find named instances if the SQL Server Browser services is running.

ManagedComputer will only find servers registered in SQL Server Management Studio.

If you're just looking for servers on the current computer, you can read the information from the registry. The key HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Microsoft SQL Server has a value called InstalledInstances which contains the name of the SQL Server instances installed on the local computer:

 */
namespace EnterpriseSolutionBIDesktop
{
    public partial class DatabaseForm : FormBase
    {
        bool fig;

        public DatabaseForm()
        {
            InitializeComponent();
            grid.ColumnAdded += dataGrid_ColumnAdded;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            lblStatus.Text = string.Empty;
            cbxSql.DataSource = SqlHelper.ListLocalSqlInstances().ToList();
            cbxSql.SelectedIndex = -1;
            fig = true;
        }

        void dataGrid_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            DataGridView grid = sender as DataGridView;
            if (e.Column.CellType == typeof(DataGridViewImageCell))
                grid.Columns.Remove(e.Column);
        }

        private void CbxSql_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!fig)
                return;

            string selectValue = this.cbxSql.SelectedValue == null ? string.Empty: this.cbxSql.SelectedValue.ToString();
            if (!string.IsNullOrWhiteSpace(selectValue))
            {
                 ServiceControllerStatus sc= GetServiceStatus(selectValue);
                 if (sc == ServiceControllerStatus.Running)
                 {
                     lblStatus.Text = sc.ToString();

                     SqlConnectionStringBuilder builer = new SqlConnectionStringBuilder();
                     builer.DataSource = selectValue;
                     builer.InitialCatalog = "master";
                     builer.IntegratedSecurity = true;
                     Database database = new SqlDatabase(builer.ConnectionString);
                     DbCommand cmd = database.GetSqlStringCommand(" SELECT *  FROM master.dbo.sysdatabases WHERE dbid > 4  ");
                     DataSet dataSetParent = database.ExecuteDataSet(cmd);
                     DataTable tableParent = dataSetParent.Tables[0];
                     bsDatabase.DataSource = tableParent;
                     grid.DataSource = bsDatabase;
                 }
            }
        }

        private void BtnBrowser_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtPath.Text = folderDlg.SelectedPath;
            }
        }

        /*
         * ExecuteNonQuery()方法：执行CommandText属性所制定的操作，返回受影响的记录条数。该方法一般用来执行SQL中的UPDATE、INSERT和DELETE等操作
对于UPDATE、INSERT和DELETE语句，执行成功返回值为该命令所影响的行数，如果影响行数为0时返回值为0，如果数据操作回滚则返回值为-1。但是对于其他的操作比如对数据库结构的操作，如果操作成功时返回的确是-1，例如给数据库添加一个数据表CREATE操作，当表创建成功返回-1，如果操作失败，则发生异常，最好是使用try-catch-finally语句来处理异常
         */
        private void BtnBackup_Click(object sender, EventArgs e)
        {
            string selectValue = this.cbxSql.SelectedValue == null ? string.Empty : this.cbxSql.SelectedValue.ToString();
            if (bsDatabase.Current == null||string.IsNullOrWhiteSpace(selectValue) || string.IsNullOrWhiteSpace(txtPath.Text.Trim()))
                return;

            DataRowView row = bsDatabase.Current as DataRowView;
            string name = row.Row.Field<string>("name");
            string bak =Path.Combine(txtPath.Text.Trim(), $"{name}_{DateTime.Now.ToString("yyyyMMddHHmmss")}.bak");
            string sql = string.Format(@"backup database [{0}]  to disk='{1}' ", name, bak);

            SqlConnectionStringBuilder builer = new SqlConnectionStringBuilder();
            builer.DataSource = selectValue;
            builer.InitialCatalog = "master";
            builer.IntegratedSecurity = true;
            Database database = new SqlDatabase(builer.ConnectionString);
            DbCommand cmd = database.GetSqlStringCommand(sql);
            int rowAffected=database.ExecuteNonQuery(cmd);
            if (rowAffected == -1)
            {
                MessageBox.Show($"Database({bak}) backup successfuly");
            }
        }

        private void BtnShrink_Click(object sender, EventArgs e)
        {
            /*
            DECLARE @strDatabaseName nvarchar(255)
            SET @strDatabaseName = 'YourDatabaseName'
            BACKUP LOG @strDatabaseName WITH TRUNCATE_ONLY
            DBCC SHRINKDATABASE(@strDatabaseName, 0)--Parameters are Database Name &Target %


            Find database and log file

Sometimes, database name and log file may vary so we need to confirm the database and database log file names first.

Expand the database and go to our database. Now, right click your database and go to Properties. Then, click “Files” in Database Properties window and confirm database name and log file name in "Logical Name” Column.

            ALTER DATABASE Sample SET RECOVERY SIMPLE WITH NO_WAIT  
DBCC SHRINKFILE([Sample_log], 0, TRUNCATEONLY)  
ALTER DATABASE Sample SET RECOVERY FULL WITH NO_WAIT 

            */

            string selectValue = this.cbxSql.SelectedValue == null ? string.Empty : this.cbxSql.SelectedValue.ToString();
            if (bsDatabase.Current == null || string.IsNullOrWhiteSpace(selectValue))
                return;

            DataRowView row = bsDatabase.Current as DataRowView;
            string name = row.Row.Field<string>("name");
            string sql = $"   DBCC SHRINKDATABASE([{name}], 0) ";

            SqlConnectionStringBuilder builer = new SqlConnectionStringBuilder();
            builer.DataSource = selectValue;
            builer.InitialCatalog = "master";
            builer.IntegratedSecurity = true;
            Database database = new SqlDatabase(builer.ConnectionString);
            DbCommand cmd = database.GetSqlStringCommand(sql);
            int rowAffected = database.ExecuteNonQuery(cmd);
            if (rowAffected == -1)
            {
                MessageBox.Show($"Shrink({name}) backup successfuly");
            }
        }

        private ServiceControllerStatus GetServiceStatus(string instance)
        {
            string serviceName = "";
            if(instance.Equals("."))
                serviceName = "MSSQLSERVER";
            else if (serviceName.StartsWith(".\\"))
            {
                serviceName = "MSSQL$" + serviceName.Replace(".\\", string.Empty);
            }

          
            ServiceController sc=new ServiceController();
            sc.ServiceName = serviceName;
            return sc.Status;
        }
    }

    public static class SqlHelper
    {
        public static IEnumerable<string> ListLocalSqlInstances()
        {
            if (Environment.Is64BitOperatingSystem)
            {
                using (var hive = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
                {
                    foreach (string item in ListLocalSqlInstances(hive))
                    {
                        yield return item;
                    }
                }

                using (var hive = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32))
                {
                    foreach (string item in ListLocalSqlInstances(hive))
                    {
                        yield return item;
                    }
                }
            }
            else
            {
                foreach (string item in ListLocalSqlInstances(Registry.LocalMachine))
                {
                    yield return item;
                }
            }
        }

        private static IEnumerable<string> ListLocalSqlInstances(RegistryKey hive)
        {
            const string keyName = @"Software\Microsoft\Microsoft SQL Server";
            const string valueName = "InstalledInstances";
            const string defaultName = "MSSQLSERVER";

            using (var key = hive.OpenSubKey(keyName, false))
            {
                if (key == null) return Enumerable.Empty<string>();

                var value = key.GetValue(valueName) as string[];
                if (value == null) return Enumerable.Empty<string>();

                for (int index = 0; index < value.Length; index++)
                {
                    if (string.Equals(value[index], defaultName, StringComparison.OrdinalIgnoreCase))
                    {
                        value[index] = ".";
                    }
                    else
                    {
                        value[index] = @".\" + value[index];
                    }
                }

                return value;
            }
        }
    }
}
