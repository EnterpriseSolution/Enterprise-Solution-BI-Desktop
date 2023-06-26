using Infragistics.Win.UltraWinTabs;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.ServiceModel;
using System.Text;
using System.Windows.Forms;
using System.Windows.Media;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using Infragistics.Win.UltraWinTabbedMdi;
using Color = System.Drawing.Color;

namespace EnterpriseSolutionBIDesktop
{
    public partial class MainForm : FormBase, IMDIContainer
    {
        public static DataTable CacheDatabaseStatistics = null;

        public static DataTable CachePrimaryKey = null;

        private string _frameworkDb;

        public string FrameworkDb
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_frameworkDb))
                {
                    SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(Program.ConnectionString);
                    _frameworkDb = builder.InitialCatalog;
                    return _frameworkDb;
                }

                return _frameworkDb;
            }
            //set
            //{
            //    Program.CONNECTION_STRING = value;
            //    _frameworkDb = value;
            //}
        }

        public MainForm()
        {
            InitializeComponent();

            //ToolStripStatusLabel labelserver = new ToolStripStatusLabel();
            //labelserver.Text = "Database Server:";
            //labelserver.Width = 120;

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(Program.ConnectionString);
            //ToolStripTextBox textServer = new ToolStripTextBox();
            //textServer.ReadOnly = true;
            //textServer.Width = 200;
            //textServer.Text = builder.DataSource;

            //ToolStripStatusLabel labelclient = new ToolStripStatusLabel();
            //labelclient.Text = "Default Client:";
            //labelclient.Width = 120;

            //ToolStripTextBox textclient = new ToolStripTextBox();
            //textclient.ReadOnly = true;
            //textclient.Width = 200;
            //textclient.Text = Command.Default_Client;

            //ToolStripStatusLabel labelMaster = new ToolStripStatusLabel();
            //labelMaster.Text = "Master Table:";
            //labelMaster.Width = 160;

            //ToolStripTextBox textMaster = new ToolStripTextBox("textMaster");
            //textMaster.Width = 260;
            //textMaster.ReadOnly = true;
            //textMaster.Text = "";

            //ToolStripStatusLabel labelDetail = new ToolStripStatusLabel();
            //labelDetail.Text = "Detail Table:";
            //labelDetail.Width = 160;

            //ToolStripTextBox textDetail = new ToolStripTextBox("textDetail");
            //textDetail.Width = 260;
            //textDetail.ReadOnly = true;
            //textDetail.Text = "";

            //statusStrip.Items.AddRange(new ToolStripItem[]
            //{
            //    labelserver, textServer, labelclient,textclient,labelMaster, textMaster, labelDetail, textDetail
            //});
            txtDatabaseServer.Text= builder.DataSource;
            txtDefaultClient.Text= builder.InitialCatalog;
        }

        public void MergeStatusStrip(System.Windows.Forms.ToolStrip statusStripToMerge)
        {
            this.statusStrip.SuspendLayout();
            ToolStripManager.Merge(statusStripToMerge, this.statusStrip);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
        }

        public void RevertStatusStrip(System.Windows.Forms.ToolStrip statusStripToUnmerge)
        {
            this.statusStrip.SuspendLayout();
            ToolStripManager.RevertMerge(this.statusStrip, statusStripToUnmerge);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
        }

        private IFormBase _lastActiveForm;

        private void Main_MdiChildActivate(object sender, EventArgs e)
        {
            if (this._lastActiveForm != null)
            {
                this._lastActiveForm.PerformRevertMergeToolStrip();
            }
            IFormBase activeMdiChild = base.ActiveMdiChild as IFormBase;
            if (activeMdiChild != null)
            {
                activeMdiChild.PerformMergeToolStrip();
                this._lastActiveForm = activeMdiChild;
            }
        }

        //private void ultraTabbedMdiManager_TabClosed(object sender, MdiTabEventArgs e)
        //{
        //    if (e.Tab.Form != null)
        //    {
        //        if (this._lastActiveForm == e.Tab.Form)
        //        {
        //            this._lastActiveForm = null;
        //        }
        //        if (!e.Tab.Form.IsDisposed)
        //        {
        //            e.Tab.Form.Dispose();
        //        }
        //    }
        //    if (!base.IsClosing)
        //    {
        //        this.ultraTabbedMdiManager.EndUpdate();
        //        this.LockWindowUpdate(false);
        //        this.Update();
        //        Shared.FlushMemory();
        //    }
        //}

        //private void ultraTabbedMdiManager_TabClosing(object sender, CancelableMdiTabEventArgs e)
        //{
        //    if (!(e.Cancel || base.IsClosing))
        //    {
        //        this.ultraTabbedMdiManager.BeginUpdate();
        //        this.LockWindowUpdate(true);
        //    }
        //}

        //private void ultraTabbedMdiManager_TabSelected(object sender, MdiTabEventArgs e)
        //{
        //    this.ultraTabbedMdiManager.EndUpdate();
        //    this.LockWindowUpdate(false);
        //    this.Update();
        //}

        //private void ultraTabbedMdiManager_TabSelecting(object sender, CancelableMdiTabEventArgs e)
        //{
        //    if (!(e.Cancel || base.IsClosing))
        //    {
        //        this.ultraTabbedMdiManager.BeginUpdate();
        //        this.LockWindowUpdate(true);
        //    }
        //}

        //public void LockWindowUpdate(bool lockUpdate)
        //{
        //    if (!(lockUpdate || !this.ultraTabbedMdiManager.IsUpdating))
        //    {
        //        this.ultraTabbedMdiManager.EndUpdate();
        //    }
        //    base.LockWindowUpdate(lockUpdate);
        //}

        public void SetMasterTableName(string name)
        {
            foreach (ToolStripItem statusStripItem in statusStrip.Items)
            {
                if (statusStripItem.Name.Equals("textMaster"))
                {
                    var textBox = statusStripItem as ToolStripTextBox;
                    textBox.Text = name;
                    break;
                }
            }
        }

        public void SetDetailTableName(string name)
        {
            foreach (ToolStripItem statusStripItem in statusStrip.Items)
            {
                if (statusStripItem.Name.Equals("textDetail"))
                {
                    var textBox = statusStripItem as ToolStripTextBox;
                    textBox.Text = name;
                    break;
                }
            }
        }

        private ToolStripLabel label;
        private ToolStripTextBox serverToolStripTextBox;
        private static Color _statusStripBorderDark = Color.FromArgb(86, 125, 176);
        private static Color _r9 = Color.FromArgb(160, 188, 228);

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            ToolStripManager.Renderer = new Office2007Renderer();
            statusStrip.Renderer = new Office2007Renderer();
            this.ultraTabbedMdiManager.TabGroupSettings.TextOrientation = TextOrientation.Horizontal;

            //txtDatabaseServer.BackColor = statusStrip.BackColor;
            //txtDefaultClient.BackColor = statusStrip.BackColor;

            ShowMainMenu();
        }

        private Dictionary<string, Type> _formBaseType = new Dictionary<string, Type>();
     
        private void BuildMasterDetailFormView(object sender, string tableNameMaster, string tableNameDetail, List<string> relationMasterColumns, List<string> relationDetailColumns, string tableNameMasterFilter = "", string tableNameDetailFilter = "")
        {
            BuildMasterDetailFormView(sender, FrameworkDb, tableNameMaster, tableNameDetail, relationMasterColumns, relationDetailColumns, tableNameMasterFilter, tableNameDetailFilter);
        }

        private void BuildMasterDetailFormView(object sender, string InitialCatalog, string tableNameMaster, string tableNameDetail, List<string> relationMasterColumns, List<string> relationDetailColumns, string tableNameMasterFilter = "", string tableNameDetailFilter = "")
        {
            MasterDetailForm frm = new MasterDetailForm(InitialCatalog, tableNameMaster, tableNameDetail, relationMasterColumns, relationDetailColumns, tableNameMasterFilter, tableNameDetailFilter);
            frm.Text = (sender as ToolStripMenuItem).Text.Replace("&", string.Empty);
            frm.MdiParent = this;
            frm.Show();
        }

        private void BuildMasterDetailFormView(object sender, DataSet dataSet)
        {
            MasterDetailForm frm = new MasterDetailForm(dataSet);
            frm.Text = (sender as ToolStripMenuItem).Text.Replace("&", string.Empty);
            frm.MdiParent = this;
            frm.Show();
        }

        public void BuildMasterDetailDetailFormView(object sender, string tableNameMaster, string tableNameDetail, string tableNameDetailDetail, List<string> relationMasterColumns, List<string> relationDetailColumns, List<string> _relationChildMasterColumns, List<string> _relationChildDetailColumns)
        {
            CompanyMasterTableForm dlg = new CompanyMasterTableForm();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                BuildMasterDetailDetailFormView(sender, dlg.InitialCatalog, tableNameMaster, tableNameDetail, tableNameDetailDetail, relationMasterColumns, relationDetailColumns, _relationChildMasterColumns, _relationChildDetailColumns);
            }
        }

        public void BuildMasterDetailDetailFormView(object sender, string InitialCatalog, string tableNameMaster, string tableNameDetail, string tableNameDetailDetail, List<string> relationMasterColumns, List<string> relationDetailColumns, List<string> _relationChildMasterColumns, List<string> _relationChildDetailColumns)
        {
            MasterDetailDetailForm frm = new MasterDetailDetailForm(InitialCatalog, tableNameMaster, tableNameDetail, tableNameDetailDetail, relationMasterColumns, relationDetailColumns, _relationChildMasterColumns, _relationChildDetailColumns);
            frm.Text = (sender as ToolStripMenuItem).Text.Replace("&", string.Empty);
            frm.MdiParent = this;
            frm.Show();
        }

        public void BuildMasterDetailFormView(object sender, string tableNameMaster, string tableNameDetailA, string tableNameDetailB, List<string> relationMasterColumns, List<string> relationDetailColumnAs, List<string> _relationDetailColumnBs)
        {
            CompanyMasterTableForm dlg = new CompanyMasterTableForm();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                BuildMasterDetailFormView(sender, dlg.InitialCatalog, tableNameMaster, tableNameDetailA, tableNameDetailB, relationMasterColumns, relationDetailColumnAs, _relationDetailColumnBs);
            }
        }

        public void BuildMasterDetailFormView(object sender, string InitialCatalog, string tableNameMaster, string tableNameDetailA, string tableNameDetailB, List<string> relationMasterColumns, List<string> relationDetailColumnAs, List<string> _relationDetailColumnBs)
        {
            MasterDetailABForm frm = new MasterDetailABForm(InitialCatalog, tableNameMaster, tableNameDetailA, tableNameDetailB, relationMasterColumns, relationDetailColumnAs, _relationDetailColumnBs);
            frm.Text = (sender as ToolStripMenuItem).Text.Replace("&", string.Empty);
            frm.MdiParent = this;
            frm.Show();
        }

        private void BuildMasterFormView(object sender, string table)
        {
            BuildMasterFormView(sender, $"{table}", string.Empty);
        }

        private DataTable Execute(object sender, string dbname, string query)
        {
            SqlConnectionStringBuilder builer = new SqlConnectionStringBuilder(Program.ConnectionString);
            builer.InitialCatalog = dbname;
            Database database = new SqlDatabase(builer.ConnectionString);
            DbCommand cmd = database.GetSqlStringCommand(query);
            DataSet dataSetParent = database.ExecuteDataSet(cmd);
            return dataSetParent.Tables[0];
        }

        public void BuildMasterFormView(object sender, DataTable tableNameMaster)
        {
            MasterTableForm frm = new MasterTableForm(tableNameMaster);
            frm.Text = (sender as ToolStripMenuItem).Text.Replace("&", string.Empty);
            frm.MdiParent = this;
            frm.Show();
        }

        public void BuildMasterFormViewEditor(object sender, DataTable tableNameMaster)
        {
            MasterTableGeneratorForm frm = new MasterTableGeneratorForm(tableNameMaster);
            frm.Text = (sender as ToolStripMenuItem).Text.Replace("&", string.Empty);
            frm.MdiParent = this;
            frm.Show();
        }
        
        public void BuildMasterFormView(object sender, string tableNameMaster, string tableNameMasterFilter = "",bool filterWithDefaultClient = false)
        {
            MasterTableForm frm = new MasterTableForm(tableNameMaster, tableNameMasterFilter, filterWithDefaultClient);
            frm.Text = (sender as ToolStripMenuItem).Text.Replace("&", string.Empty);
            frm.MdiParent = this;
            frm.Show();
        }

        private DataTable FetchItem(object sender, string dbname, string tableName)
        {
            string query = string.Format(@"SELECT db_name() as DATABASE_NAME, TABLE_SCHEMA, TABLE_NAME, COLUMN_NAME AS [ColumnName] , ORDINAL_POSITION,
                           COLUMN_DEFAULT, DATA_TYPE AS [DataType], CHARACTER_MAXIMUM_LENGTH,
                           NUMERIC_PRECISION, NUMERIC_PRECISION_RADIX, NUMERIC_SCALE,
                           DATETIME_PRECISION
                           FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{0}' ", tableName);
            string queryData = string.Format(" SELECT * FROM [{0}] ", tableName);
            DataTable table = Execute(sender, dbname, query);
            DataTable tableData = Execute(sender, dbname, queryData);
            DataRow valueRow = tableData.Rows[0];

            DataTable tableResult = new DataTable("Query");
            tableResult.TableName = tableName;
            tableResult.ExtendedProperties.Add("InitialCatalog", dbname);
            tableResult.Columns.Add("ColumnName", typeof(string));
            tableResult.Columns.Add("DataType", typeof(string));
            tableResult.Columns.Add("Value", typeof(string));
            foreach (DataRow dataRow in table.Rows)
            {
                DataRow newRow = tableResult.NewRow();
                newRow["ColumnName"] = dataRow.Field<string>("ColumnName");
                newRow["DataType"] = dataRow.Field<string>("DataType");

                object scale = valueRow[dataRow.Field<string>("ColumnName")];
                newRow["Value"] = scale == DBNull.Value ? string.Empty : Convert.ToString(scale);
                tableResult.Rows.Add(newRow);
            }

            return tableResult;
        }

        public void NewFunction(Type type)
        {
            Form frm = Activator.CreateInstance(type) as Form;
            frm.MdiParent = this;
            frm.Show();
        }
        
        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //	T880	Global company data (for KONS Ledger)
            BuildMasterFormView(sender, "T880");
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //T001W-工厂信息表
            BuildMasterFormView(sender, "T001W");

           // BuildMasterDetailFormView(sender, FrameworkDb, "SystemModule", "SystemFunction", new List<string> {"MODULE_CODE"}, new List<string> {"MODULE_CODE"});
        }

        private void mitUser_Click(object sender, EventArgs e)
        {
            //BuildMasterDetailFormView(sender, FrameworkDb, "UserGroup", "User", new List<string> {"USER_GROUP"}, new List<string> {"USER_GROUP"});
            //USR21：分配用户名称地址码
            BuildMasterFormView(sender, "USR02");
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BuildMasterDetailDetailFormView(sender, FrameworkDb, "UserLog", "UserLogDetail", "UserLogDetailAction", new List<string> {"LOG_NO"}, new List<string> {"LOG_NO"}, new List<string> {"LOG_NO", "ENTRY_NO"}, new List<string> {"LOG_NO", "ENTRY_NO"});
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BuildMasterDetailDetailFormView(sender, FrameworkDb, "AuditTrail", "AuditTrailTableDetail", "AuditTrailColumnDetail", new List<string> {"LOG_NO"}, new List<string> {"LOG_NO"}, new List<string> {"LOG_NO", "TABLE_NO"}, new List<string> {"LOG_NO", "TABLE_NO"});
        }
        
        private void ToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            BuildMasterFormView(sender, "Dim_Buyer");
        }

        private void ToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            //MARA	General Material Data
            BuildMasterFormView(sender, "Dim_Calendar");
        }

     
        private void ToolStripMenuItem12_Click(object sender, EventArgs e)
        {
            //KNA1	General Data in Customer Master
            BuildMasterFormView(sender, "Dim_JobCategory");
        }

        private void ToolStripMenuItem7_Click(object sender, EventArgs e)
        {
            //LFA1	Vendor Master (General Section)
            BuildMasterFormView(sender, "Dim_Item");
        }
        
        private void toolStripMaterialGroup_Click(object sender, EventArgs e)
        {
            //Material group - T023
            BuildMasterFormView(sender, "Dim_Account");
        }

        private void ToolStripMenuItem11_Click(object sender, EventArgs e)
        {
            BuildMasterFormView(sender, "Dim_AnalysisCode");
        }

        private void ToolStripMenuItem8_Click(object sender, EventArgs e)
        {
            //BuildMasterDetailFormView(sender,"GBCURR", "GBRATE", new List<string> {"CCY"}, new List<string> {"CCY"});
            //TCURC	currency Codes
            BuildMasterFormView(sender, "Dim_Operation");
        }

        private void ToolStripMenuItem13_Click(object sender, EventArgs e)
        {
            //Check <b>MARD</b> - Storage Location Table.
            //Use the FM <b>LOCATION_READ_T001L</b> and pass <b>WERKS</b>. It will return all the storage locs.
            BuildMasterFormView(sender, "Dim_Salesman");
        }

        private void ToolStripMenuItem9_Click(object sender, EventArgs e)
        {
            //CRHD CRHD	工作中心表头 
            BuildMasterFormView(sender, "Dim_Products");
            //BuildMasterDetailFormView(sender, "GBWCTR", "GBWCTO", new List<string> {"WORK_CENTRE"}, new List<string> {"WORK_CENTRE"});
        }

        private void ToolStripMenuItem14_Click(object sender, EventArgs e)
        {
            //BuildMasterDetailFormView(sender, "PRSBOM", "PRPART", "PRPROC", new List<string> {"BOM_NO"}, new List<string> {"BOM_NO"}, new List<string> {"BOM_NO"});
            //STPO	BOM item
            //STKO
            // RAINT[STKO~0] PRIMARY KEY CLUSTERED([MANDT], [STLTY], [STLNR], [STLAL], [STKOZ]) WITH(DATA_COMPRESSION = PAGE) ON[PRIMARY]
            //STKO BOM 表头          ([], [], [], [], [])
            //    STPO    BOM 项目   [MANDT], [STLTY], [STLNR], [STLKN], [STPOZ]
            //List<string> keyHeader = new List<string>() { "MANDT", "STLTY", "STLNR", "STLAL" , "STKOZ" };
            //List<string> keyDetail = new List<string>() { "MANDT", "STLTY", "STLNR", "STLKN", "STPOZ" };

            //BuildMasterDetailFormView(sender, "STKO", "STPO", keyHeader, keyDetail);
            BuildMasterFormView(sender, "Dim_Fiscal");
            
        }
        
        private void ToolStripMenuItem15_Click(object sender, EventArgs e)
        {
            BuildMasterFormView(sender, "Dim_PayTerms");
        }

        private void ToolStripMenuItem16_Click(object sender, EventArgs e)
        {
            //SKB1	G/L account master (company code)
            BuildMasterFormView(sender, "Dim_Planner");
        }

        private void workflowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // BNKA 银行主数据
            BuildMasterFormView(sender, "Dim_Vendor");
        }

        private void toolStripMenuItem18_Click(object sender, EventArgs e)
        {
            BuildMasterDetailFormView(sender, "PUORDH", "PUORDD", new List<string> {"ORDER_NO"}, new List<string> {"ORDER_NO"});
        }

        private void toolStripMenuItem19_Click(object sender, EventArgs e)
        {
            //VBAK抬头；  VBAP行项
            //销售订单抬头                       VBAK    ([], [])      
            //BuildMasterDetailFormView(sender, "SLORDH", "SLORDD", new List<string> {"ORDER_NO"}, new List<string> {"ORDER_NO"});
            //List<string> key = new List<string>() { "MANDT", "VBELN" };
            //BuildMasterDetailFormView(sender, "VBAK", "VBAP", key, key);
            BuildMasterFormView(sender, "Fact_DaysDebtors");
           // var key = new List<string> { "MANDT", "VBELN" };
           // BuildMasterDetailFormView(sender, "VBAK", "VBAP", key, key, " VBTYP = 'C'");
        }

        private void toolStripMenuItem20_Click(object sender, EventArgs e)
        {
            BuildMasterDetailFormView(sender, "PRJOBH", "PRJOBB", "PRJOBD", new List<string> {"JOB_NO"}, new List<string> {"JOB_NO"}, new List<string> {"JOB_NO"});
        }

        private void toolStripMenuItem21_Click(object sender, EventArgs e)
        {
            //BuildMasterDetailFormView(sender, "ARINVH", "ARINVD", new List<string> {"INVOICE_NO"}, new List<string> {"INVOICE_NO"});
            BuildMasterFormView(sender, "Fact_NetAccountsReceivable");
        }

        private void toolStripMenuItem22_Click(object sender, EventArgs e)
        {
            BuildMasterDetailFormView(sender, "APINVH", "APINVD", new List<string> {"CONTROL_NO"}, new List<string> {"CONTROL_NO"});
        }

        private void voucherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BuildMasterDetailFormView(sender, "GLVOUH", "GLVOUd", new List<string> {"VOUCHER_NO", "VOUCHER_TYPE"}, new List<string> {"VOUCHER_NO", "VOUCHER_TYPE"});

        }

        private void exceptionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BuildMasterFormView(sender,  "Exception", string.Empty);
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BuildMasterFormView(sender,  "Error", string.Empty);
        }

        private void schedulerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BuildMasterDetailFormView(sender, FrameworkDb, "Job", "JobLog", new List<string> {"JOB_NO"}, new List<string> {"JOB_NO"});
        }

        private void layoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BuildMasterDetailFormView(sender, FrameworkDb, "FormLayout", "FormLayoutDetail", new List<string> {"LAYOUT_NAME"}, new List<string> {"LAYOUT_NAME"});
        }

        private void lookupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BuildMasterDetailFormView(sender, FrameworkDb, "LookupDialog", "LookupDialogFilter", new List<string> {"LOOKUP_NAME"}, new List<string> {"LOOKUP_NAME"});
        }

        private void reportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Sales organization : TVKO.

            //    Distribution Channel: TVTW.
            BuildMasterFormView(sender, "TVKO");
        }

        private void authorizationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BuildMasterDetailDetailFormView(sender, FrameworkDb, "UserGroup", "UserGroupAuthorization", "UserGroupAuthorizationDetail", new List<string> {"USER_GROUP"}, new List<string> {"USER_GROUP"}, new List<string> {"USER_GROUP", "MODULE_CODE"}, new List<string> {"USER_GROUP", "MODULE_CODE"});
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BuildMasterFormView(sender, FetchItem(sender, FrameworkDb, "SystemParameter"));
        }
        
        private void toolStripMenuItem23_Click(object sender, EventArgs e)
        {
            BuildMasterFormView(sender,"GBDEPT");
        }

        private void toolStripMenuItem24_Click(object sender, EventArgs e)
        {
            //Master table is PA0003, where all pernrs will be
            //stored here.But to get employee name you can use

            //PA0001 - ENAME(Formatted name of employee)

            //PA0001 - SNAME(Employee's name)

            //For last name and first name you can check

            //PA0002 - VORNA and PA0002 - NACHN.

            BuildMasterFormView(sender, "PA0003");
        }

        private void toolStripMenuItem25_Click(object sender, EventArgs e)
        {
            BuildMasterDetailFormView(sender, "GBCALH", "GBCALD", new List<string> {"TRAN_MONTH"}, new List<string> {"TRAN_MONTH"});
        }

        private void purchaseRequisitionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BuildMasterDetailFormView(sender, "PUREQH", "PUREQD", new List<string> {"REQ_NO"}, new List<string> {"REQ_NO"});
        }

        private void purchaseReceiptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BuildMasterDetailFormView(sender, "PUGRNH", "PUGRND", new List<string> {"GRN_NO"}, new List<string> {"GRN_NO"});
        }

        private void purchaseReturnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BuildMasterDetailFormView(sender, "PURETH", "PURETD", new List<string> {"REF_NO"}, new List<string> {"REF_NO"});
        }

        private void toolStripMenuItem26_Click(object sender, EventArgs e)
        {
            //Header Table: VBAK

            //    Item table: VBAP

            //VBAK - VBTYP = 'B'

            //SD Quotations, check the tables VBAK (Header) & VBAP (Item Details). 
            //VBAK ([MANDT], [VBELN])
            //VBAP  ([MANDT], [VBELN], [POSNR]) 
            //var key = new List<string> { "MANDT", "VBELN" };
            //BuildMasterDetailFormView(sender, "VBAK", "VBAP", key, key, " VBTYP = 'B'");
            BuildMasterFormView(sender, "Fact_DaysCompletionEarlyAndLate");
        }

        private void toolStripMenuItem27_Click(object sender, EventArgs e)
        {
            //BuildMasterDetailFormView(sender, "SLSHPH", "SLSHPD", new List<string> {"REF_NO"}, new List<string> {"REF_NO"});
            //var key = new List<string> { "MANDT", "VBELN" };
            //BuildMasterDetailFormView(sender, "VBAK", "VBAP", key, key, " VBTYP = 'J'");
            BuildMasterFormView(sender, "Fact_InventoryTurns");
        }

        private void toolStripMenuItem28_Click(object sender, EventArgs e)
        {
            //var key = new List<string> { "MANDT", "VBELN" };
            //BuildMasterDetailFormView(sender, "VBAK", "VBAP", key, key, " VBTYP = 'H'");
            BuildMasterFormView(sender, "Fact_DeliveryInFull");
        }

        private void toolStripMenuItem30_Click(object sender, EventArgs e)
        {
            BuildMasterDetailFormView(sender, "GBLOCN", "ICBALN", "ICLEDG", new List<string>() {"LOC"}, new List<string>() {"LOC"}, new List<string>() {"LOC"});
        }

        private void ToolStripMenuItem36_Click(object sender, EventArgs e)
        {
            BuildMasterDetailFormView(sender, "PRCOMH", "PRCOMD", "PRCOMC", new List<string> {"REF_NO"}, new List<string> {"REF_NO"}, new List<string> {"REF_NO"});
        }

        private void ToolStripMenuItem35_Click(object sender, EventArgs e)
        {
            BuildMasterDetailFormView(sender, "ICMOVH", "ICMOVD", new List<string> {"REF_NO"}, new List<string> {"REF_NO"}, "MOVE_TYPE='Mat_Is'", string.Empty);
        }

        private void EnumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            #region Enum

            DataTable tableInterface;
            DataTable tableMethod;
            tableInterface = new DataTable("Interface");
            tableInterface.Columns.Add("Enum", typeof(string));
            tableInterface.Columns.Add("Length", typeof(int));
            tableInterface.PrimaryKey = new DataColumn[] {tableInterface.Columns["Enum"]};

            tableMethod = new DataTable("Method");
            tableMethod.Columns.Add("Enum", typeof(string));
            tableMethod.Columns.Add("Line", typeof(int));
            tableMethod.Columns.Add("ValueMember", typeof(string));
            tableMethod.Columns.Add("DisplayMember", typeof(string));
            tableMethod.PrimaryKey = new DataColumn[] {tableMethod.Columns["Enum"], tableMethod.Columns["Line"]};

            List<Type> intefaceList = new List<Type>();
            Assembly assembly = Assembly.Load("Microsoft.Common.Enum");
            foreach (Type ti in assembly.GetTypes().Where(x => x.IsSubclassOf(typeof(Enum))))
            {
                intefaceList.Add(ti);

                var fieldInfos = ti.GetFields(BindingFlags.Static | BindingFlags.Public);
                int i = 1;
                foreach (var fieldInfo in fieldInfos)
                {
                    DataRow columnRow = tableMethod.NewRow();
                    bool canAdd = false;
                    object[] attrs = fieldInfo.GetCustomAttributes(true);
                    foreach (object attr in attrs)
                    {
                        //StringValueAttribute attrValue = attr as StringValueAttribute;
                        //DisplayTextAttribute attrDisplay = attr as DisplayTextAttribute;

                        //if (attrValue != null)
                        //{
                        //    columnRow["ValueMember"] = attrValue.Value;
                        //    canAdd = true;
                        //}

                        //if (attrDisplay != null)
                        //{
                        //    columnRow["DisplayMember"] = attrDisplay.Value;
                        //    canAdd = true;

                        //}
                    }

                    if (attrs.Length == 0)
                    {
                        object obj = Activator.CreateInstance(ti);
                        int value = (int) fieldInfo.GetValue(obj);
                        columnRow["ValueMember"] = value;
                        columnRow["DisplayMember"] = fieldInfo.Name.ToString(CultureInfo.InvariantCulture);
                        canAdd = true;
                    }

                    if (canAdd)
                    {
                        columnRow["Enum"] = ti.Name;
                        columnRow["Line"] = i++;
                        tableMethod.Rows.Add(columnRow);
                    }
                }

                if (fieldInfos.Length > 0)
                {
                    DataRow row = tableInterface.NewRow();
                    row["Enum"] = ti.Name;
                    row["Length"] = fieldInfos.Length;
                    tableInterface.Rows.Add(row);
                }
            }

            DataSet dataSet = new DataSet("Data");
            dataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
            dataSet.Tables.Add(tableInterface);
            dataSet.Tables.Add(tableMethod);

            //bsEnum.DataSource = dataSet;
            //bsEnum.DataMember = "Interface";

            DataRelation relation = new DataRelation("InterfaceMethod", dataSet.Tables["Interface"].Columns["Enum"], dataSet.Tables["Method"].Columns["Enum"]);
            dataSet.Relations.Add(relation);

            //grdEnum.SetDataBinding(dataSet, "Interface", true, true);
            //gridEnumMember.SetDataBinding(dataSet, "Interface.InterfaceMethod", true, true);

            #endregion

            BuildMasterDetailFormView(sender,dataSet);
        }

        private void ToolStripMenuItem37_Click(object sender, EventArgs e)
        {
            BuildMasterDetailFormView(sender, "ADBRAN", "ADBRAD", new List<string> {"BRANCH_NO"}, new List<string> {"BRANCH_NO"});
        }

        private void ToolStripMenuItem38_Click(object sender, EventArgs e)
        {
            BuildMasterDetailFormView(sender, "ADSERS", "ADSERD", new List<string> {"SERIES_CODE"}, new List<string> {"SERIES_CODE"});
        }

        private void ToolStripMenuItem31_Click(object sender, EventArgs e)
        {
            //BuildMasterDetailFormView(sender, "GBVEND", "APLEDG", "APOPEN", new List<string> {"VENDOR_NO"}, new List<string> {"VENDOR_NO"}, new List<string> {"VENDOR_NO"});
            //PLAF: 计划订单
            BuildMasterFormView(sender, "Fact_ProductionEfficiency");
        }

        private void ToolStripMenuItem32_Click(object sender, EventArgs e)
        {
            //BuildMasterDetailFormView(sender, "GBCUST", "ARLEDG", "AROPEN", new List<string> {"CUSTOMER_NO"}, new List<string> {"CUSTOMER_NO"}, new List<string> {"CUSTOMER_NO"});
            //MKAL	生产版本
            BuildMasterFormView(sender, "Fact_ProductionReliability");
        }

        private void ToolStripMenuItem39_Click(object sender, EventArgs e)
        {
            BuildMasterDetailFormView(sender, "ARPAYH", "ARPAYD", new List<string> {"RECEIPT_NO"}, new List<string> {"RECEIPT_NO"});
        }

        private void ToolStripMenuItem40_Click(object sender, EventArgs e)
        {
            BuildMasterDetailFormView(sender, "APPAYH", "APPAYD", new List<string> {"REF_NO"}, new List<string> {"REF_NO"});
        }

        private void AnalysisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //CSKS-成本中心信息表
            BuildMasterFormView(sender, "Dim_WorkCentre");

            //BuildMasterDetailFormView(sender, "GBANTL", "GBANCO", new List<string> {"CATEGORY"}, new List<string> {"CATEGORY"});
        }

        private void OperationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BuildMasterFormView(sender, "MIGO_T156");
        }

        private void PeriodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BuildMasterDetailFormView(sender, "GBPERH", "GBPERD", new List<string> {"FISCAL_YEAR"}, new List<string> {"FISCAL_YEAR"});
        }

        private void ToolStripMenuItem41_Click(object sender, EventArgs e)
        {
            //BuildMasterDetailFormView(sender, "GBACCT", "GLCBAL", "GLCLDG", new List<string> {"ACCT_NO"}, new List<string> {"ACCT_NO"}, new List<string> {"ACCT_NO"});
            //AFKO 订单表头数据 PP 订单
            //AFPO 订单项
            BuildMasterFormView(sender, "Fact_ProductionYield");

            //List<string> key =new List<string> { "MANDT", "AUFNR" }; 
            //BuildMasterDetailFormView(sender, "AFKO", "AFPO", key, key);
        }

        private void mnuInventoryIssue_Click(object sender, EventArgs e)
        {
            BuildMasterDetailFormView(sender, "ICMOVH", "ICMOVD", new List<string> {"REF_NO"}, new List<string> {"REF_NO"}, "FLOW_TYPE='I'", string.Empty);
        }

        private void mnuInventoryReceipt_Click(object sender, EventArgs e)
        {
            BuildMasterDetailFormView(sender, "ICMOVH", "ICMOVD", new List<string> {"REF_NO"}, new List<string> {"REF_NO"}, "FLOW_TYPE='R'", string.Empty);
        }

        private void mnuInventoryTransfer_Click(object sender, EventArgs e)
        {
            BuildMasterDetailFormView(sender, "ICMOVH", "ICMOVD", new List<string> {"REF_NO"}, new List<string> {"REF_NO"}, "FLOW_TYPE='T'", string.Empty);
        }

        private void ToolStripMenuItem45_Click(object sender, EventArgs e)
        {
            BuildMasterDetailFormView(sender, "PRMBOM", "PRMFIN", "PRMMAT", new List<string> {"BOM_NO", "FORMULA_CODE"}, new List<string> {"BOM_NO", "FORMULA_CODE"}, new List<string> {"BOM_NO", "FORMULA_CODE"});
        }

        private void BuyerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BuildMasterDetailFormView(sender, "PUBUYR", "PUBUYL", new List<string> {"BUYER_CODE"}, new List<string> {"BUYER_CODE"});
        }

        private void SalesmanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BuildMasterDetailFormView(sender, "SLSMAN", "SLSCUS", new List<string> {"SALESMAN"}, new List<string> {"SALESMAN"});
        }

        private void PlannerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BuildMasterFormView(sender, "T024D");
        }

        private void ToolStripMenuItem46_Click(object sender, EventArgs e)
        {
            BuildMasterDetailFormView(sender, "PRMRPD", "PRMRPS", new List<string> {"ITEM_NO"}, new List<string> {"ITEM_NO"});
        }

        private void MessageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BuildMasterDetailFormView(sender, "MESSAGE", "MSGATM", new List<string> {"MESSAGE_ID"}, new List<string> {"MESSAGE_ID"});
        }

        private void MnuGarmentIndustry_Click(object sender, EventArgs e)
        {
            //EBAN: 采购申请
            //EBAN	Purchase Requisition
            BuildMasterFormView(sender, "EBAN");
            
            //BuildMasterDetailDetailFormView(sender, "GBCOLT", "GBSTYL", "GBSGRP", new List<string> {"COLLECTION_CODE"}, new List<string> {"COLLECTION_CODE"}, new List<string> {"STYLE_CODE"}, new List<string> {"STYLE_CODE"});
        }

        private void MnuFinalProduct_Click(object sender, EventArgs e)
        {
            BuildMasterFormView(sender, "GBITEM", " PRODUCT='Y' AND MAKE_BUY='Y' ");
        }

        private void MnuSemiProduct_Click(object sender, EventArgs e)
        {
            BuildMasterFormView(sender, "GBITEM", " PRODUCT='Y' AND MATERIAL='Y' AND MAKE_BUY='Y' ");
        }

        private void MnuRawMaterial_Click(object sender, EventArgs e)
        {
            BuildMasterFormView(sender, "GBITEM", " MATERIAL='Y' AND MAKE_BUY='N' ");
        }

        private void webServiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //EKKO: 采购订单抬头 采购订单抬头                        EKKO          
            var key = new List<string>() { "MANDT", "EBELN" };
            
            BuildMasterDetailFormView(sender, "EKKO", "EKPO", key, key);
        }
        
        private void mnuUserSettingMenuItem_Click(object sender, EventArgs e)
        {
            BuildMasterFormView(sender, FetchItem(sender, FrameworkDb, "User"));
        }

        private void mnuMD5Generator_Click(object sender, EventArgs e)
        {
            //FileHasher form = new FileHasher();
            //form.MdiParent = this;
            //form.Show();
        }

        private void databaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DatabaseForm form = new DatabaseForm();
            form.MdiParent = this;
            form.Show();
        }

        private void excelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MasterExcelForm form = new MasterExcelForm();
            form.MdiParent = this;
            form.Show();
        }

       
        private void mTOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //BuildMasterDetailFormView(sender, "PRMRPH", "PRJOBH", "PUORDH", new List<string> {"REF_NO"}, new List<string> {"SOURCE_MRP_NO"}, new List<string> {"SOURCE_REF_NO"});
            //EKKO 采购凭证抬头
            //EKPO 采购凭证项目  [], []) 
            List<string> key = new List<string>() { "MANDT", "EBELN" };
            BuildMasterDetailFormView(sender, "EKKO", "EKPO", key, key);
        }

        private void mitBOMRevision_Click(object sender, EventArgs e)
        {
            string query = @"   SELECT *  FROM dbo.PRSBOM
                WHERE ASSM_ITEM_NO IN(SELECT ASSM_ITEM_NO FROM dbo.PRSBOM   GROUP BY ASSM_ITEM_NO HAVING(COUNT(*) > 1))   ";

            CompanyMasterTableForm dlg = new CompanyMasterTableForm();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                DataTable table = Execute(sender, dlg.InitialCatalog, query);
                table.ExtendedProperties.Add("InitialCatalog", dlg.InitialCatalog);

                BuildMasterFormView(sender, table);
            }
        }

        private void toolStripMenuItem47_Click(object sender, EventArgs e)
        {
            string query = @"  SELECT  *FROM dbo.PUVITM WHERE VENDOR_ITEM_NO IS NOT NULL AND LEN(VENDOR_ITEM_NO)> 0   ";

            CompanyMasterTableForm dlg = new CompanyMasterTableForm();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                DataTable table = Execute(sender, dlg.InitialCatalog, query);
                table.ExtendedProperties.Add("InitialCatalog", dlg.InitialCatalog);

                BuildMasterFormView(sender, table);
            }
        }

        private void toolStripMenuItem48_Click(object sender, EventArgs e)
        {
            string query = @"  SELECT * FROM dbo.SLCITM WHERE CUST_ITEM_NO IS NOT NULL AND LEN(CUST_ITEM_NO)>0  ";

            CompanyMasterTableForm dlg = new CompanyMasterTableForm();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                DataTable table = Execute(sender, dlg.InitialCatalog, query);
                table.ExtendedProperties.Add("InitialCatalog", dlg.InitialCatalog);

                BuildMasterFormView(sender, table);
            }
        }

        private void toolStripMenuItem49_Click(object sender, EventArgs e)
        {
            EventLogDialog form = new EventLogDialog();
            form.MdiParent = this;
            form.Show();
        }

        private void toolStripMenuItem50_Click(object sender, EventArgs e)
        {
            //Translation form = new Translation();
            //form.MdiParent = this;
            //form.Show();
        }

        private void rohsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //string query = @"  SELECT *  FROM gbitem WHERE ROHS_COMPLIANCE=1   ";

            //CompanyMasterTableForm dlg = new CompanyMasterTableForm();
            //if (dlg.ShowDialog() == DialogResult.OK)
            //{
            //    DataTable table = Execute(sender, dlg.InitialCatalog, query);
            //    table.ExtendedProperties.Add("InitialCatalog", dlg.InitialCatalog);

            //    BuildMasterFormView(sender, table);
            //}
            //12、EINA: 采购信息记录（一般数据）
            //13、EINE: 采购信息记录（采购组织数据）   
            var key = new List<string> { "MANDT", "INFNR" };
            BuildMasterDetailFormView(sender, "EINA", "EINE", key, key);
        }

        private void implementationLotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //1、LTBK: 转储请求抬头
            //2、LTBP: 转储请求项目 
            var key = new List<string> { "MANDT", "LGNUM", "TBNUM" };
            BuildMasterDetailFormView(sender, "LTBK", "LTBP", key, key);


            //string query = @"  SELECT *  FROM gbitem WHERE ENABLE_LOT='Y'   ";

            //CompanyMasterTableForm dlg = new CompanyMasterTableForm();
            //if (dlg.ShowDialog() == DialogResult.OK)
            //{
            //    DataTable table = Execute(sender, dlg.InitialCatalog, query);
            //    table.ExtendedProperties.Add("InitialCatalog", dlg.InitialCatalog);

            //    BuildMasterFormView(sender, table);
            //}
        }

        private void implementationSerialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //3、LTAK: WM转储单抬头  [MANDT], [LGNUM], [TANUM]) 
            //4、LTAP: WM转储单项目   ([MANDT], [LGNUM], [TANUM], [TAPOS]
            var key = new List<string> { "MANDT", "LGNUM", "TBNUM" };
            var key2 = new List<string> { "MANDT", "LGNUM", "TANUM" };

            BuildMasterDetailFormView(sender, "LTAK", "LTAP", key, key2);


            //string query = @"  SELECT *  FROM gbitem WHERE ENABLE_SERIAL='Y'   ";

            //CompanyMasterTableForm dlg = new CompanyMasterTableForm();
            //if (dlg.ShowDialog() == DialogResult.OK)
            //{
            //    DataTable table = Execute(sender, dlg.InitialCatalog, query);
            //    table.ExtendedProperties.Add("InitialCatalog", dlg.InitialCatalog);

            //    BuildMasterFormView(sender, table);
            //}
        }

        private void toolStripMenuItem51_Click(object sender, EventArgs e)
        {
            BuildMasterFormView("PRSBOM", "PHANTOM=1");
        }

        private void toolStripMenuItem52_Click(object sender, EventArgs e)
        {
            //T001	Company Codes

            //CompanyTableForm form = new CompanyTableForm();
            //form.Text = (sender as ToolStripMenuItem).Text;
            //form.MdiParent = this;
            //form.Show();  
            BuildMasterFormView(sender, "T001");

        }

        private void toolStripMenuItem53_Click(object sender, EventArgs e)
        {
            BuildMasterFormView("GBITEM", "ITEM_TYPE='STA'");
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {
            BuildMasterFormView("GBITEM", "ITEM_TYPE='CFA'");
        }

        private void tableNameValidatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CompanyMasterTableForm dlg = new CompanyMasterTableForm();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string query = @"select schema_name(tab.schema_id) as schema_name,
            tab.name as table_name, 
            col.column_id,
            col.name as column_name, 
            t.name as data_type,    
            col.max_length,
            col.precision
                from sys.tables as tab
            inner join sys.columns as col
            on tab.object_id = col.object_id
            left join sys.types as t
            on col.user_type_id = t.user_type_id
            order by schema_name,
                table_name, 
                column_id; ";

                DataTable table = Execute(sender,dlg.InitialCatalog, query);
                table.ExtendedProperties.Add("InitialCatalog", dlg.InitialCatalog);

                DataTable tableFunction = new DataTable("Schema");
                tableFunction.Columns.Add("Table", typeof(string));
                tableFunction.Columns.Add("Column", typeof(string));
                tableFunction.ExtendedProperties.Add("InitialCatalog", dlg.InitialCatalog);

                foreach (DataRow row in table.Rows)
                {
                    string tableName = row.Field<string>("table_name");
                    string columnName = row.Field<string>("column_name");
                    if (IsAllUpper2(tableName) && IsAllUpper2(columnName))
                        continue;

                    var newRow = tableFunction.NewRow();
                    newRow["Table"] = tableName;
                    newRow["Column"] = columnName;
                    tableFunction.Rows.Add(newRow);
                }

                BuildMasterFormView(sender,tableFunction);
            }
        }

        // If you want to skip non-alphabetic characters (The OP's original implementation does not, but his/her comments indicate that they might want to
        static bool IsAllUpper2(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (Char.IsLetter(input[i]) && !Char.IsUpper(input[i]))
                    return false;
            }

            return true;
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OptionForm frm = new OptionForm(Program.ConnectionString);
            frm.Description = optionsToolStripMenuItem.Text;
            frm.MdiParent = this;
            frm.Show();
        }

        private void mitFirstInputFirstOutput_Click(object sender, EventArgs e)
        {
            BuildMasterFormView(sender, "GBITEM", "ALLOC_METHOD='F'");
        }

        private void mitActualCost_Click(object sender, EventArgs e)
        {
            BuildMasterFormView(sender, "GBITEM", "ALLOC_METHOD='A'");
        }

        private void mitLastInFirstOut_Click(object sender, EventArgs e)
        {
            BuildMasterFormView(sender, "GBITEM", "ALLOC_METHOD='L'");
        }

        private void mitMonthlyAverage_Click(object sender, EventArgs e)
        {
            BuildMasterFormView(sender, "GBITEM", "ALLOC_METHOD='N'");
        }

        private void toolStripMenuItem54_Click(object sender, EventArgs e)
        {
            //TSTC	SAP Transaction Codes
            //TSTC	SAP Transaction codes
            BuildMasterFormView(sender, "TSTC");
            //HardwareInfoForm frm = new HardwareInfoForm();
            //frm.Text = (sender as ToolStripMenuItem).Text;
            //frm.MdiParent = this;
            //frm.Show();
        }

       

        public static object InvokeMethod(object o, string methodName, object[] arguments)
        {
            Type[] types = arguments.Select(x => x.GetType()).ToArray();
            MethodInfo method = o.GetType().GetMethod(methodName, types);
            return method.Invoke(o, arguments);
        }

        public static object GetEnumValue(Type enumType, string enumItemName)
        {
            // Get the underlying type used for each enum item
            Type enumUnderlyingType = enumType.GetEnumUnderlyingType();

            // Get a list of all the names in the enums
            List<string> enumNames = enumType.GetEnumNames().ToList();
            // Get an array of all the corresponding values in the enum
            Array enumValues = enumType.GetEnumValues();

            // Get the value where the corresponding name matches our specified name
            object enumValue = enumValues.GetValue(enumNames.IndexOf(enumItemName));

            // Convert the value to the underlying enum type and return it
            return Convert.ChangeType(enumValue, enumUnderlyingType);
        }

        public object ExecuteAssembly(string assemblyName, string[] parameters)
        {
            // Get your assembly.
            Assembly asm = Assembly.LoadFile(assemblyName);

            // Get your point of entry.
            MethodInfo entryPoint = asm.EntryPoint;

            // Invoke point of entry with arguments.
            return entryPoint.Invoke(null, parameters);
        }

        private void toolStripMenuItemSecurity_Click(object sender, EventArgs e)
        {
            //SecurityForm frm = new SecurityForm();
            //frm.MdiParent = this;
            //frm.Show();
        }

        private void toolStripMenuItemRegistryFileType_Click(object sender, EventArgs e)
        {
            //var dic = Microsoft.Common.Shared.GetRegistryFileTypes().OrderBy(en => en.Key);
            //StringBuilder sb = new StringBuilder();
            //foreach (var pair in dic)
            //{
            //    sb.AppendLine($"{pair.Key}  {pair.Value}");
            //}

            //ConsoleInfoForm frm = new ConsoleInfoForm("Registry File Type");
            //frm.Text = (sender as ToolStripMenuItem).Text;
            //frm.MdiParent = this;
            //frm.Show();
        }

        private void toolStripMenuItem2DotNetVersions_Click(object sender, EventArgs e)
        {
            //T100	Messages
            BuildMasterFormView(sender, "T100",string.Empty,false);
        }

        public class TextBoxWriter : TextWriter
        {
            // The control where we will write text.
            private Control MyControl;
            public TextBoxWriter(Control control)
            {
                MyControl = control;
            }

            public override void Write(char value)
            {
                MyControl.Text += value;
            }

            public override void Write(string value)
            {
                MyControl.Text += value;
            }

            public override Encoding Encoding
            {
                get { return Encoding.Unicode; }
            }
        }

        private static void MainEntry(string[] args)
        {
            bool batchMode = false;

            if (args.Length > 0 && (args[0] == "/help" || args[0] == "-help" || args[0] == "--help" || args[0] == "/?" || args[0] == "-?" || args[0] == "--?"))
            {
                Console.Write("Writes all the currently installed versions of \"classic\" .NET platform in the system.\r\nUse --b, -b or /b to use in a batch, showing only the installed versions, without any extra informational lines.");
            }
            else
            {
                if (args.Length > 0 && (args[0] == "/b" || args[0] == "-b" || args[0] == "--b"))
                {
                    batchMode = true;
                }

                if (!batchMode)
                    Console.WriteLine("Currently installed \"classic\" .NET Versions in the system:");

                //Show all the installed versions
                //Get1To45VersionFromRegistry();
                //Get45PlusFromRegistry();
            }

            if (!batchMode)
                Console.ReadKey();
        }

        private void workflowToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CompanyMasterTableForm dlg = new CompanyMasterTableForm();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                WorkflowForm frm = new WorkflowForm(dlg.InitialCatalog);
                frm.Text = (sender as ToolStripMenuItem).Text;
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void toolStripMenuItemSDKClient_Click(object sender, EventArgs e)
        {
            //19、MKPF: 物料凭证抬头
            //20、MSEG: 物料凭证行项目
           
            List<string> list =new List<string>  { "MANDT","MBLNR","MJAHR" };
            BuildMasterDetailFormView(sender,FrameworkDb, "MKPF", "MSEG", list,list);

            //LoginClientForm frm = new LoginClientForm();
            //frm.Text = (sender as ToolStripMenuItem).Text;
            //frm.MdiParent = this;
            //frm.Show();
        }

        private void moldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //VBRK是抬头； VBRP是行项；
            List<string> key = new List<string>() { "MANDT", "VBELN" };
            BuildMasterDetailFormView(sender, "VBRK", "VBRP", key, key);
        }

        private void toolStripMenuItemCloseAll_Click(object sender, EventArgs e)
        {
            CloseAllMdiForms();
        }

        private void CloseAllMdiForms()
        {
            foreach (Form form in this.GetOpenedForms())
            {
                if (!(form is MainMenu))
                {
                    form.Close();
                }
            }

            this.ShowMainMenu();
        }

        private void ShowMainMenu()
        {
            Startup frm = new Startup(this);
            frm.MdiParent = this;
            frm.Show();
        }

        protected List<Form> GetOpenedForms()
        {
            List<Form> list = new List<Form>();
            foreach (Form form in base.MdiChildren)
            {
                if (!list.Contains(form))
                {
                    list.Add(form);
                }
            }
            foreach (Form form in Application.OpenForms)
            {
                if (!(list.Contains(form) || (form == this)))
                {
                    list.Add(form);
                }
            }
            return list;
        }

        private void toolStripMenuItemMenu_Click(object sender, EventArgs e)
        {
            ShowMainMenu();
        }

        private void voucherToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //BKPF 财务凭证抬头
            //BSEG 财务凭证行项目

            //    BSIK, BSAK 分别是供应商(K)的未清已清项存放的表
            //    BSIS, BSAS 分别是总账(S)的未清已清项存放的表
            //    BSID, BSAD 分别是客户(D)的未清已清项存放的表
            //    I 表示未清，A 表示已清。

            // BKPF 财务凭证抬头
            // BSEG 财务凭证行项目  
            List<string> key=new List<string>(){ "MANDT", "BUKRS", "BELNR", "GJAHR" };
            BuildMasterDetailFormView(sender, "BKPF", "BSEG",key,key);
        }

        private void vendorOpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string> key = new List<string>() { "MANDT", "BUKRS", "LIFNR", "UMSKS", "UMSKZ", "AUGDT", "AUGBL", "ZUONR", "GJAHR", "BELNR", "BUZEI" };
            BuildMasterDetailFormView(sender, "BSIK", "BSAK", key, key);
        }

        private void customerOpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string> key = new List<string>() { "MANDT", "BUKRS", "KUNNR", "UMSKS",  "UMSKZ", "AUGDT", "AUGBL", "ZUONR", "GJAHR", "BELNR", "BUZEI" };
            BuildMasterDetailFormView(sender, "BSID", "BSAD", key, key);

        }

        private void generalLedgerOpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string> key = new List<string>() { "MANDT", "BUKRS", "HKONT", "AUGDT", "AUGBL", "ZUONR", "GJAHR", "BELNR", "BUZEI" };
            BuildMasterDetailFormView(sender, "BSIS", "BSAS", key, key);
        }

        private void projectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //1、PROJ: 项目定义
            //2、PRPS: WBS(工作中断结构) 元素主数据

            List<string> key = new List<string>() { "MANDT", "PSPNR"};
            BuildMasterDetailFormView(sender, "PROJ", "PRPS", key, key);

        }

        private void toolStripMenuItem10_Click_1(object sender, EventArgs e)
        {
            //Division Table: TSPA...

            //Division Description table: TSPAT

            List<string> key = new List<string>() { "MANDT", "SPART" };
            BuildMasterDetailFormView(sender, "TSPA", "TSPAT", key, key);
        }

        private void toolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            //Sales organization : TVKO.

            //    Distribution Channel: TVTW.

            //Relation between VKORG and VTVEG is found in

            //table TVKOV.

            BuildMasterFormView(sender, "TVTW");
        }

        private void toolStripMenuItem20_Click_1(object sender, EventArgs e)
        {
            BuildMasterFormView(sender, "Dim_Parameter");

        }

        private void toolStripMenuItem18_Click_1(object sender, EventArgs e)
        {
            BuildMasterFormView(sender, "SWD_STEPS","",false);
        }

        //protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        //{
        //    switch (keyData)
        //    {
        //        case Keys.F4:
        //           // OpenPDFHelp();
        //            return true;

        //            //case Keys.D1 | Keys.Control:
        //            //    SwitchLanguage(0);
        //            //    return true;

        //            //case Keys.D2 | Keys.Control:
        //            //    SwitchLanguage(1);
        //            //    return true;

        //            //case Keys.D3 | Keys.Control:
        //            //    SwitchLanguage(2);
        //            //    return true;

        //            //case Keys.Alt & Keys.Shift & Keys.Enter:
        //            //if (_bFullScreenMode == false)
        //            //{
        //            //    formState.Maximize(this);
        //            //    _bFullScreenMode = true;
        //            //}
        //            //else
        //            //{
        //            //    formState.Restore(this);
        //            //    _bFullScreenMode = false;
        //            //}
        //            //    fullScreenToolStripMenuItem.PerformClick();

        //            break;
        //    }

        //    return base.ProcessCmdKey(ref msg, keyData);
        //}

        private void OpenPDFHelp()
        {
            MasterTableFormOption frm = new MasterTableFormOption();
            frm.ShowDialog();
        }

        private void purchasingOrganizationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //T024E    - Purchasing Organizations 
            BuildMasterFormView(sender, "T024E");
        }

        private void purchasingGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //T024      - Purchasing Groups 
            BuildMasterFormView(sender, "T024");
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            BuildMasterFormView(sender, "T001B");
        }

        private void businessAreaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BuildMasterFormView(sender, "TGSB");
        }

        private void toolStripMenuItem5_Click_1(object sender, EventArgs e)
        {
            BuildMasterFormView(sender, "TVBUR");
        }

        private void toolStripMenuItem11_Click_1(object sender, EventArgs e)
        {
            BuildMasterFormView(sender, "TVKGR");
        }

        private void toolStripMenuItem25_Click_1(object sender, EventArgs e)
        {
           // var key = new List<string> { "MANDT", "VBELN" };
           // BuildMasterDetailFormView(sender, "VBAK", "VBAP", key, key, " VBTYP = 'A'");
           BuildMasterFormView(sender, "Fact_AccountSummary");
        }

        private void toolStripMenuItem34_Click(object sender, EventArgs e)
        {
            //var key = new List<string> { "MANDT", "VBELN" };
            //BuildMasterDetailFormView(sender, "VBAK", "VBAP", key, key, " VBTYP = 'D'");
            BuildMasterFormView(sender, "Fact_DaysInInventory");
        }

        private void toolStripMenuItem35_Click_1(object sender, EventArgs e)
        {
            //var key = new List<string> { "MANDT", "VBELN" };
            //BuildMasterDetailFormView(sender, "VBAK", "VBAP", key, key, " VBTYP = 'E'");
            BuildMasterFormView(sender, "Fact_DaysReceiptEarlyAndLate");
        }

        private void toolStripMenuItem36_Click_1(object sender, EventArgs e)
        {
            //var key = new List<string> { "MANDT", "VBELN" };
            //BuildMasterDetailFormView(sender, "VBAK", "VBAP", key, key, " VBTYP = 'G'");
            BuildMasterFormView(sender, "Fact_DaysShipmentEarlyAndLate");
        }

        private void toolStripMenuItem37_Click_1(object sender, EventArgs e)
        {
            BuildMasterFormView(sender, "T000","",false);
        }

        private void materialValuationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BuildMasterFormView(sender, "MBEW");
        }

        private void physicalInventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var key = new List<string> { "MANDT", "IBLNR" , "GJAHR" }; 
            BuildMasterDetailFormView(sender, "IKPF", "ISEG", key, key);

        }

        private void quotaFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //var key = new List<string> { "MANDT", "IBLNR", "GJAHR" };
            //BuildMasterDetailFormView(sender, "EQUK", "EQUP", key, key);

        }

        private void purchasingDocumentTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //T161	Purchasing Document Types
            BuildMasterFormView(sender, "T161");
        }

        private void toolStripMenuItem23_Click_1(object sender, EventArgs e)
        {
            //TKA01	controlling areas	
            BuildMasterFormView(sender, "TKA01");
        }

        private void costElementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //the tables for cost element and cost center groups are SETHEADER and SETLEAF. For Cost element class is 0102 and for cost center class is 0101.
            //The group value should be entered in SETID field.

            var key = new List<string> { "MANDT", "SETCLASS", "SUBCLASS", "SETNAME" };
            BuildMasterDetailFormView(sender, "SETHEADER", "SETLEAF", key, key, " SETCLASS='0102' ", "SETCLASS='0102' ");

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            BuildMasterFormView(sender, "Dim_Customer");
        }

        private void orderAvailabilityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BuildMasterFormView(sender, "Fact_OrderAvailability");
        }

        private void orderChangeFrequencyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BuildMasterFormView(sender, "Fact_OrderChangeFrequency");
        }

        private void orderLeadTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BuildMasterFormView(sender, "Fact_OrderLeadTime");
        }

        private void factOrderReliabilityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BuildMasterFormView(sender, "Fact_OrderReliability");
        }

        private void profitabilityGPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BuildMasterFormView(sender, "Fact_ProfitabilityGP");
        }

        private void profitabilityPMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BuildMasterFormView(sender, "Fact_ProfitabilityPM");
        }

        private void factPurchasePartsReliabilityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BuildMasterFormView(sender, "Fact_PurchasePartsReliability");
        }

        private void purchasePriceVarianceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BuildMasterFormView(sender, "Fact_PurchasePriceVariance");
        }

        private void quotationHitRateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BuildMasterFormView(sender, "Fact_QuotationHitRate");
        }

        private void salesOrderOnHandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BuildMasterFormView(sender, "Fact_SalesOrderOnHand");
        }

        private void salesToNetWorkingCapitalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BuildMasterFormView(sender, "Fact_SalesToNetWorkingCapital");
        }

        private void shipmentValueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BuildMasterFormView(sender, "Fact_ShipmentValue");
        }
    }

    public interface IMDIContainer
    {
        void MergeStatusStrip(ToolStrip statusStripToMerge);
        void RevertStatusStrip(ToolStrip statusStripToUnmerge);
    }


}