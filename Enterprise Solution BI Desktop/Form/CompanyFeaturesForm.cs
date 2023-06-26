 using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using Infragistics.Documents.Excel;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

namespace EnterpriseSolutionBIDesktop
{
    public partial class CompanyFeaturesForm : FormBase
    {
        private string _tableNameMaster= "Company";

        private List<CompanyEntity> _companyEntities;
        private Dictionary<string, string> _nameQuery;
        private DataTable _cache;

        public string InitialCatalog
        {
            get
            {
                DataRowView row = bindingSourceMaster.Current as DataRowView;
                return row["DB_DATABASE"].ToString();
            }
        }

        public CompanyFeaturesForm()
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

            gridMaster.AutoResizeColumns();
            _nameQuery=new Dictionary<string, string>();
            _cache=new DataTable("Data");
            _cache.Columns.Add("CompanyCode", typeof(string));
            _cache.Columns.Add("Field", typeof(string));
            _cache.Columns.Add("FieldValue", typeof(bool));
            _cache.PrimaryKey = new DataColumn[] {_cache.Columns["CompanyCode"], _cache.Columns["Field"]};

            this.UseWaitCursor = true;
            bgwInit.RunWorkerAsync();
        }

        private void bgwInit_DoWork(object sender, DoWorkEventArgs e)
        {
            GetData();
        }
        
        private void GetData()
        {
            SqlConnectionStringBuilder builer = new SqlConnectionStringBuilder(Program.ConnectionString);            
            Database database = new SqlDatabase(builer.ConnectionString);
            DbCommand cmd = database.GetSqlStringCommand(string.Format(Command.ALL_ROWS, _tableNameMaster));
            DataSet dataSetParent = database.ExecuteDataSet(cmd);
            DataTable tableParent = dataSetParent.Tables[0];
            tableParent.TableName = _tableNameMaster;

            _companyEntities=new List<CompanyEntity>();
            _companyEntities = tableParent.ToList<CompanyEntity>();

            this.Invoke(new MethodInvoker(delegate ()
            {
                bindingSourceMaster.DataSource = _companyEntities;
                bindingSourceMaster.DataMember = "";
                gridMaster.DataSource = bindingSourceMaster;
            }));
            
            Init();
        }

        private void Init()
        {
            var fileName = "ConfigurationManager.Resources.FeaturesApply.xlsx";
            var assembly = Assembly.GetExecutingAssembly();
            var stream = assembly.GetManifestResourceStream(fileName);
            Workbook workbook = Workbook.Load(stream);
            Worksheet worksheetGeneral = workbook.Worksheets["General"];
            Worksheet worksheetProduction = workbook.Worksheets["Production"];
            Worksheet worksheetFinance = workbook.Worksheets["Finance"];
            
            ProcessWorksheet(worksheetGeneral, panelGeneral);
            ProcessWorksheet(worksheetProduction, panelProduction);
            ProcessWorksheet(worksheetFinance, panelFinance);
        }

        private void ProcessWorksheet(Worksheet sheet, Panel panel)
        {
            foreach (WorksheetRow row in sheet.Rows)
            {
                if (row.Index == 0)
                    continue;

                if (row.Cells[2].Value == null || string.IsNullOrEmpty(row.Cells[2].Value.ToString()))
                    continue;

                string description = row.Cells[0].Value.ToString().Trim();
                string query = row.Cells[1].Value.ToString().Trim();
                string name = row.Cells[2].Value.ToString().Trim();

                if (!string.IsNullOrWhiteSpace(name) && !string.IsNullOrWhiteSpace(query))
                {
                    if(!_nameQuery.ContainsKey(name))
                        _nameQuery.Add(name,query);

                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        CheckBox box = new CheckBox();
                        box.Name = name;
                        box.Text = description;
                        box.AutoSize = true;
                        box.TextAlign = ContentAlignment.MiddleCenter;
                        panel.Controls.Add(box);
                    }));
                }
            }
        }

        private void bgwItemChanged_DoWork(object sender, DoWorkEventArgs e)
        {
            CompanyEntity row = bindingSourceMaster.Current as CompanyEntity;
            if (row == null || _nameQuery.Count == 0)
                return;

            this.Invoke(new MethodInvoker(delegate ()
            {
                ResetUnchecked(panelGeneral);
                ResetUnchecked(panelProduction);
                ResetUnchecked(panelFinance);
            }));

            System.Data.SqlClient.SqlConnectionStringBuilder builer = new System.Data.SqlClient.SqlConnectionStringBuilder();
            builer.DataSource = row.DB_SERVER;
            builer.InitialCatalog = row.DB_DATABASE;
            //var cryptionHelper = Microsoft.Common.Shared.GetCryptionHelper();
            //if (!string.IsNullOrWhiteSpace(row.DB_USER))
            //    builer.UserID = cryptionHelper.DecryptString(row.DB_USER);
            //if (!string.IsNullOrWhiteSpace(row.DB_PASSWORD))
            //    builer.Password = cryptionHelper.DecryptString(row.DB_PASSWORD);

            if (!IsServerConnected(builer.ConnectionString))
                return;

            //this.Invoke(new MethodInvoker(delegate ()
            //{
            //    Entries control = new Entries(row);
            //    control.FormBorderStyle = FormBorderStyle.None;
            //    control.TopLevel = false;
            //    control.Parent = this;
            //    control.Visible = true;
            //    control.Dock = DockStyle.Fill;
            //    control.Show();
            //    tabEntries.Controls.Add(control);
            //}));

            foreach (KeyValuePair<string, string> pair in _nameQuery)
            {
                bool implementation = false;
                DataRow dataRow = _cache.Rows.Find(new object[] { row.COMPANY_CODE, pair.Key });
                if (dataRow == null)
                {
                    Database database = new SqlDatabase(builer.ConnectionString);
                    DbCommand cmd = database.GetSqlStringCommand(pair.Value);
                    object objScalar = database.ExecuteScalar(cmd);
                    implementation = objScalar != DBNull.Value && Convert.ToInt32(objScalar) > 0;

                    var newRow = _cache.NewRow();
                    newRow["CompanyCode"] = row.COMPANY_CODE;
                    newRow["Field"] = pair.Key;
                    newRow["FieldValue"] = implementation;
                    _cache.Rows.Add(newRow);
                }
                else
                {
                    implementation = Convert.ToBoolean(dataRow["FieldValue"]);
                }

                //ReflectionHelper.SetPropertyValue(row, pair.Key, implementation);
            }

            this.Invoke(new MethodInvoker(delegate ()
            {
                ProcessCheckbox(row, panelGeneral);
                ProcessCheckbox(row, panelProduction);
                ProcessCheckbox(row, panelFinance);
            }));
        }

        private void bindingSourceMaster_CurrentItemChanged(object sender, EventArgs e)
        {
            if (bindingSourceMaster.Current == null)
                return;

            this.UseWaitCursor = true;
            if (!bgwItemChanged.IsBusy)
                bgwItemChanged.RunWorkerAsync();
        }

        private void ProcessCheckbox(CompanyEntity row,Panel panel)
        {
            foreach (Control control in panel.Controls)
            {
                if (control is CheckBox)
                {
                    control.DataBindings.Clear();
                    try
                    {
                        control.DataBindings.Add(new System.Windows.Forms.Binding("Checked", row, control.Name, true));
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(control.Name + Environment.NewLine + exception.Message, "Configuration Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void ResetUnchecked(Panel panel)
        {
            foreach (Control control in panel.Controls)
            {
                if (control is CheckBox)
                {
                    (control as CheckBox).Checked = false;
                }
            }
        }

        private static bool IsServerConnected(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    return true;
                }
                catch (SqlException)
                {
                    return false;
                }
            }
        }

        private void bgwItemChanged_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.UseWaitCursor = false;
        }

        private void bgwInit_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.UseWaitCursor = false;
        }
    }
}
