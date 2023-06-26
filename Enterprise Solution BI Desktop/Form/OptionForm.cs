using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using Infragistics.Documents.Excel;
using File = System.IO.File;

namespace EnterpriseSolutionBIDesktop
{
    public partial class OptionForm : FormBase
    {
        private string _dbname;
        //private RijndaelCryptionHelper _rijndaelCryption;
        private List<Tuple<string, string>> _list;
        private string password;

        public OptionForm(string dbname)
        {
            InitializeComponent();
            _dbname = dbname;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            //this._rijndaelCryption = Microsoft.Common.Shared.GetCryptionHelper();

            //txtEventLogRegister.Text = Microsoft.Common.Shared.LogName;
            //_list=new List<Tuple<string, string>>();
            //string conn = Program.ConnectionString;
            //using (SqlConnection sqlConnection = new SqlConnection(conn))
            //{
            //    SqlCommand sqlCmd = new SqlCommand("SELECT * FROM dbo.[User]", sqlConnection);
            //    sqlConnection.Open();
            //    SqlDataReader sqlReader = sqlCmd.ExecuteReader();

            //    while (sqlReader.Read())
            //    {
            //        cbxUserId1.Items.Add(sqlReader["USER_ID"].ToString());
            //        _list.Add(Tuple.Create(sqlReader["USER_ID"].ToString(), sqlReader["PASSWORD"].ToString()));
            //    }

            //    sqlReader.Close();
            //}

            //using (SqlConnection sqlConnection = new SqlConnection(conn))
            //{
            //    SqlCommand sqlCmd = new SqlCommand("SELECT * FROM dbo.Company ", sqlConnection);
            //    sqlConnection.Open();
            //    SqlDataReader sqlReader = sqlCmd.ExecuteReader();

            //    while (sqlReader.Read())
            //    {
            //        cbxCompanyCode1.Items.Add(sqlReader["COMPANY_CODE"].ToString());
            //    }

            //    sqlReader.Close();
            //}

        }

        private void btnTableCategoryGenerator_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Workbook (*.xls, *.xlsx)|*.xls;*.xlsx|CSV files (*.csv)|*.csv|All files (*.*)|*.*";

            string excel = string.Empty;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                excel = openFileDialog.FileName;
            }

            if (string.IsNullOrWhiteSpace(excel))
                return;

            string pattern = @"IF NOT EXISTS (SELECT NULL FROM SYS.EXTENDED_PROPERTIES WHERE [major_id] = OBJECT_ID('{0}') AND [name] = N'Category' AND [minor_id] = 0)
  EXEC sp_addextendedproperty @name = N'Category', @value = N'{1}', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'{0}';
ELSE
  EXEC sys.sp_updateextendedproperty @name = N'Category', @value = N'{1}' , @level0type = N'SCHEMA',@level0name = N'dbo', @level1type = N'TABLE',@level1name = N'{0}' ";

            var workbook = Workbook.Load(excel);
            List<string> sql=new List<string>();
            Worksheet sheet = workbook.Worksheets["Category"];
            if (sheet != null)
            {
                foreach (WorksheetRow workRow in sheet.Rows)
                {
                    if (workRow.Index == 0) 
                        continue;

                    string table= workRow.Cells[0].Value.ToString();
                    string category = workRow.Cells[1].Value.ToString();

                    if (!string.IsNullOrWhiteSpace(table) && !string.IsNullOrWhiteSpace(category))
                    {
                        sql.Add(string.Format(pattern, table, category)+ Environment.NewLine);
                    }
                }

                string file =Path.Combine(System.IO.Path.GetTempPath(),string.Format(@"{0}.sql", DateTime.Now.Ticks));
                File.AppendAllText(file, string.Join(Environment.NewLine, sql));
                Process.Start(file);
            }
        }

        private void btnReportExport_Click(object sender, EventArgs e)
        {
            string fileName = "Microsoft.EnterpriseSolution.Report";
            string reports = "Reports";
            System.IO.Directory.CreateDirectory(reports);

            System.IO.DirectoryInfo di = new DirectoryInfo(reports);

            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                dir.Delete(true);
            }

            Assembly executingAssembly = Assembly.Load(fileName);
            foreach (string resourceName in executingAssembly.GetManifestResourceNames())
            {

                if (resourceName.EndsWith(".rpt", StringComparison.InvariantCultureIgnoreCase))
                {
                    string rpt = resourceName.Replace(fileName, string.Empty).Substring(1);

                    Stream stream = executingAssembly.GetManifestResourceStream(resourceName);
                    FileStream fileStream = new FileStream(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, reports, rpt), FileMode.CreateNew);
                    for (int i = 0; i < stream.Length; i++)
                        fileStream.WriteByte((byte)stream.ReadByte());
                    fileStream.Close();
                }

                Console.WriteLine(resourceName);
            }
        }

        private string DataFolder
        {
            get
            {
                // %appdata%  C:\Users\Administrator\AppData\Roaming
                //C:\Users\Administrator\AppData\Roaming\Enterprise Solution Limited\Enterprise Solution\Data
                string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                //string companyFolder = Path.Combine(folder, Microsoft.Common.AssemblyVersion.Company);
                //Directory.CreateDirectory(companyFolder);

                //string specificFolder = Path.Combine(companyFolder, Microsoft.Common.AssemblyVersion.Product);
                //Directory.CreateDirectory(specificFolder);

                //string dataFolder = Path.Combine(specificFolder, "Data");
                //Directory.CreateDirectory(dataFolder);

                //return dataFolder;
                return string.Empty;
            }
        }

        
        
        
        private void btnEventLogDelete_Click(object sender, EventArgs e)
        {
            string log = "Enterprise Process Navigator";
            log = txtEventLog.Text.Trim();
            if (!string.IsNullOrWhiteSpace(log))
            {
                EventLog.Delete(log);
            }
        }
       
        private void btnSaveEventLogRegister_Click(object sender, EventArgs e)
        {
            //if (!string.IsNullOrWhiteSpace(txtEventLogRegister.Text))
            //    Microsoft.Common.Shared.SaveLogRegister(txtEventLogRegister.Text.Trim());
        }

        private void btnEmailSync_Click(object sender, EventArgs e)
        {
            //EmailSyncForm frm = new EmailSyncForm(_dbname);
            //frm.MdiParent = this.ParentForm;
            //frm.Show();
        }

        private void btnCreateShortcut_Click(object sender, EventArgs e)
        {
            string userId = cbxUserId1.SelectedItem.ToString();
            string companyCode = cbxCompanyCode1.SelectedItem.ToString();
            if (string.IsNullOrWhiteSpace(userId) || string.IsNullOrWhiteSpace(companyCode)||string.IsNullOrWhiteSpace(password))
            {
                return;
            }

            //password= _rijndaelCryption.DecryptString(password);
            string login = string.Join("  ", new string[] {userId, "Enterprise", companyCode, "0"});
            RegisterStartupMenu(login);
        }

        private static void RegisterStartupMenu(string login)
        {
            //string folder = AssemblyVersion.Package;
            //string[] desktopClient = { "EntMain.exe", AssemblyVersion.Product };
            //string[] systemMaintenance = { "EntSys.exe", "System Maintenance" };
            
            //AddShortcut(folder, desktopClient[0], desktopClient[1], login);
            //AddShortcut(folder, systemMaintenance[0], systemMaintenance[1],string.Empty);
        }

        private static void AddShortcut(string folder, string exe, string description,string login)
        {
            //string pathToExe = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, exe);
            //string commonStartMenuPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonStartMenu);
            //string appStartMenuPath = Path.Combine(commonStartMenuPath, "Programs", folder);

            //if (!Directory.Exists(appStartMenuPath))
            //    Directory.CreateDirectory(appStartMenuPath);

            //string shortcutLocation = Path.Combine(appStartMenuPath, description + ".lnk");
            //if (!System.IO.File.Exists(shortcutLocation))
            //{
            //    WshShell shell = new WshShell();
            //    IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutLocation);

            //    shortcut.Description = description;
            //    shortcut.TargetPath = pathToExe;
            //    shortcut.Save();
            //}

            //var desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            //shortcutLocation = Path.Combine(desktop, description + ".lnk");
            //if (!System.IO.File.Exists(shortcutLocation))
            //{
            //    WshShell shell = new WshShell();
            //    IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutLocation);

            //    shortcut.Description = description;
            //    shortcut.TargetPath = pathToExe;
            //    shortcut.Arguments = login;

            //    shortcut.Save();
            //}
        }
        
        private void cbxUserId1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            string userid = "";
            userid = (string)cmb.SelectedItem;
            var item = _list.FirstOrDefault(en => en.Item1 == userid);

            if (cmb == cbxUserId1)
            {
                if (item != null)
                    password = item.Item2;
            }
        }
    }
}
