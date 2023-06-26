using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

namespace EnterpriseSolutionBIDesktop
{
    public partial class DatabaseOverview : FormBase
    {
        private string _dbname;
        private List<string> _predefineContent;
        public DatabaseOverview(string dbname,bool isSystemDatabase,List<string> predefineContent)
        {
            InitializeComponent();
            this._dbname = dbname;
            this._predefineContent = predefineContent;

            gridOverview.ColumnAdded += dataGrid_ColumnAdded;
            gridOverview.CellDoubleClick += gridAllDatabase_CellContentClick;
        }

        void dataGrid_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            DataGridView grid = sender as DataGridView;
            if (e.Column.CellType == typeof(DataGridViewImageCell))
                grid.Columns.Remove(e.Column);
        }

        private void gridAllDatabase_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.gridOverview.Rows[e.RowIndex];
                string tableName = row.Cells["Table Name"].Value.ToString().Trim();
                if (!string.IsNullOrWhiteSpace(tableName))
                {
                    BuildTableView(tableName,"");
                }
            }
        }

        private void BuildTableView(string tableName,string description)
        {
            TabPage tabPage = new TabPage();
            tabPage.Name = tableName + (new Random()).Next(10, 1000);
            if (string.IsNullOrWhiteSpace(description))
                tabPage.Text = tableName;
            else
                tabPage.Text = description;

            DataGridView grid = new DataGridView();
            grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grid.Dock = System.Windows.Forms.DockStyle.Fill;
            grid.Location = new System.Drawing.Point(3, 3);
            grid.Name = tableName + (new Random()).Next(10, 1000);
            grid.RowTemplate.Height = 23;
            grid.Size = new System.Drawing.Size(913, 509);
            grid.ColumnAdded += dataGrid_ColumnAdded;

            SqlConnectionStringBuilder builer = new SqlConnectionStringBuilder(Program.ConnectionString);
            builer.InitialCatalog = _dbname;
            Database database = new SqlDatabase(builer.ConnectionString);
            DbCommand cmd = database.GetSqlStringCommand(string.Format(Command.ALL_ROWS, tableName));
            DataSet alldatabase = database.ExecuteDataSet(cmd);
            grid.DataSource = alldatabase.Tables[0];
            grid.AutoGenerateColumns = true;

            tabPage.Controls.Add(grid);
            tabControl.Controls.Add(tabPage);

            tabControl.SelectedIndex = tabControl.TabPages.Count - 1;
        }


        private void BuildMasterDetailTableView(string description, Form control )
        {
            TabPage tabPage = new TabPage();
            tabPage.Name = description + (new Random()).Next(10, 1000);
            tabPage.Text = description;

            control.FormBorderStyle = FormBorderStyle.None;
            control.TopLevel = false;
            control.Parent = tabPage;
            control.Visible = true;
            control.Dock = DockStyle.Fill;
            control.Show();
            tabPage.Controls.Add(control);
            tabControl.Controls.Add(tabPage);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.Text = this.Text + string.Format(" [{0}] ", _dbname);
            SqlConnectionStringBuilder builer = new SqlConnectionStringBuilder(Program.ConnectionString);
            builer.InitialCatalog = _dbname;
            Database database = new SqlDatabase(builer.ConnectionString);
            using (DbCommand dbCommand = database.GetSqlStringCommand(Command.QUERY_DATABASE_SIZE))
            {
                DataSet overview = database.ExecuteDataSet(dbCommand);
                gridOverview.DataSource = overview.Tables[0];
                gridOverview.AutoGenerateColumns = true;
            }
          
            if (_predefineContent.Count>0)
                ProcessPredefineTabPage(database,_predefineContent);
        }

        private void ProcessPredefineTabPage(Database database,List<string> predefineContent)
        {
            foreach (string line in predefineContent)
            {
                if (line.Trim().StartsWith("//") || string.IsNullOrWhiteSpace(line.Trim()))
                    continue;
                
                if (line.Trim().StartsWith("====="))
                {
                    ProcessMasterDetailDetailABC(line.Trim().Replace("===", ""));
                    continue;
                }

                if (line.Trim().StartsWith("===="))
                {
                    ProcessMasterDetailDetailAB(line.Trim().Replace("===", ""));
                    continue;
                }

                if (line.Trim().StartsWith("==="))
                {
                    ProcessMasterDetailDetail(line.Trim().Replace("===",""));
                    continue;
                }
                
                if (line.Trim().StartsWith("=="))
                {
                    ProcessMasterDetail(line.Trim().Replace("==",""));
                    continue;
                }
               
                string[] row = Regex.Split(line, "#");
                string description = row[0].Trim();
                string tableName = row[1].Trim();

                string query = "select case when exists((select * from information_schema.tables where table_name = '" + tableName + "')) then 1 else 0 end";
                DbCommand cmd = database.GetSqlStringCommand(query);
                bool exists = (int)database.ExecuteScalar(cmd) == 1;
                if (exists)
                    BuildTableView(tableName, description);
            }
        }

        private void ProcessMasterDetail(string line)
        {
            // == Authorization #  ADAUTH , USER_GROUP,MODULE_CODE  #   ADAUTD,USER_GROUP, MODULE_CODE
            string table = line.Trim().Replace("=", string.Empty).Trim();
            string[] row = Regex.Split(table, "#");
            string description = row[0].Trim();
            string master = row[1].Trim();
            string detail = row[2].Trim();

            string[] masterInfo = Regex.Split(master, ",",RegexOptions.IgnorePatternWhitespace);
            string[] detailInfo = Regex.Split(detail, ",", RegexOptions.IgnorePatternWhitespace);

            string tableNameMaster = masterInfo[0].Trim();
            string tableNameDetail = detailInfo[0].Trim();
            List<string> relationMasterColumns = new List<string>();
            List<string> relationDetailColumns = new List<string>();
            for (int i = 1; i < masterInfo.Length; i++)
            {
                relationMasterColumns.Add(masterInfo[i].Trim());
            }

            for (int i = 1; i < detailInfo.Length; i++)
            {
                relationDetailColumns.Add(detailInfo[i].Trim());
            }

            MasterDetailForm form = new MasterDetailForm(_dbname, tableNameMaster, tableNameDetail, relationMasterColumns, relationDetailColumns);
            BuildMasterDetailTableView(description, form);
        }

        private void ProcessMasterDetailDetail(string line)
        {
            string table = line.Trim().Replace("=", string.Empty).Trim();
            string[] row = Regex.Split(table, "#");

            string description = row[0].Trim();
            string master = row[1].Trim();
            string detail1 = row[2].Trim();
            string detail2 = row[3].Trim();
            string child = row[4].Trim();

            string[] masterInfo = Regex.Split(master, ",", RegexOptions.IgnorePatternWhitespace);
            string[] detail1Info = Regex.Split(detail1, ",", RegexOptions.IgnorePatternWhitespace);
            string[] detail2Info = Regex.Split(detail2, ",", RegexOptions.IgnorePatternWhitespace);
            string[] childInfo = Regex.Split(child, ",", RegexOptions.IgnorePatternWhitespace);
            
            string tableNameMaster = masterInfo[0].Trim();
            string tableNameDetail = detail1Info[0].Trim();
            string tableNameChild = childInfo[0].Trim();
            //Master-Detail
            List<string> relationMasterColumns = new List<string>();
            List<string> relationDetailColumns = new List<string>();
            for (int i = 1; i < masterInfo.Length; i++)
            {
                relationMasterColumns.Add(masterInfo[i].Trim());
            }
            for (int i = 1; i < detail1Info.Length; i++)
            {
                relationDetailColumns.Add(detail1Info[i].Trim());
            }

            //Detail-Detail
            List<string> relationChildMasterColumns = new List<string>();
            List<string> relationChildDetailColumns = new List<string>();
            for (int i = 1; i < detail2Info.Length; i++)
            {
                relationChildMasterColumns.Add(detail2Info[i].Trim());
            }
            for (int i = 1; i < childInfo.Length; i++)
            {
                relationChildDetailColumns.Add(childInfo[i].Trim());
            }

            MasterDetailDetailForm form = new MasterDetailDetailForm(_dbname, tableNameMaster, tableNameDetail, tableNameChild,relationMasterColumns, relationDetailColumns, relationChildMasterColumns, relationChildDetailColumns);
            BuildMasterDetailTableView(description, form);
        }

        private void ProcessMasterDetailDetailAB(string line)
        {
            string table = line.Trim().Replace("=", string.Empty).Trim();
            string[] row = Regex.Split(table, "#");

            string description = row[0].Trim();
            string master = row[1].Trim();
            string detail1 = row[2].Trim();
            string detail2 = row[3].Trim();
            string child1 = row[4].Trim();
            string child2 = row[5].Trim();

            string[] masterInfo = Regex.Split(master, ",", RegexOptions.IgnorePatternWhitespace);
            string[] detail1Info = Regex.Split(detail1, ",", RegexOptions.IgnorePatternWhitespace);
            string[] detail2Info = Regex.Split(detail2, ",", RegexOptions.IgnorePatternWhitespace);
            string[] childInfo1 = Regex.Split(child1, ",", RegexOptions.IgnorePatternWhitespace);
            string[] childInfo2 = Regex.Split(child2, ",", RegexOptions.IgnorePatternWhitespace);

            string tableNameMaster = masterInfo[0].Trim();
            string tableNameDetail = detail1Info[0].Trim();
            string tableNameChild1 = childInfo1[0].Trim();
            string tableNameChild2 = childInfo2[0].Trim();

            //Master-Detail
            List<string> relationMasterColumns = new List<string>();
            List<string> relationDetailColumns = new List<string>();
            for (int i = 1; i < masterInfo.Length; i++)
            {
                relationMasterColumns.Add(masterInfo[i].Trim());
            }
            for (int i = 1; i < detail1Info.Length; i++)
            {
                relationDetailColumns.Add(detail1Info[i].Trim());
            }

            //Detail-Detail
            List<string> relationChildMasterColumns = new List<string>();
            List<string> relationChildDetailColumns = new List<string>();
            List<string> relationChildDetailColumnsB = new List<string>();

            for (int i = 1; i < detail2Info.Length; i++)
            {
                relationChildMasterColumns.Add(detail2Info[i].Trim());
            }
            for (int i = 1; i < childInfo1.Length; i++)
            {
                relationChildDetailColumns.Add(childInfo1[i].Trim());
            }
            for (int i = 1; i < childInfo2.Length; i++)
            {
                relationChildDetailColumnsB.Add(childInfo2[i].Trim());
            }

            MasterDetailDetailABForm form = new MasterDetailDetailABForm(_dbname, tableNameMaster, tableNameDetail, tableNameChild1, tableNameChild2, relationMasterColumns, relationDetailColumns, relationChildMasterColumns, relationChildDetailColumns, relationChildDetailColumnsB);
            BuildMasterDetailTableView(description, form);
        }

        private void ProcessMasterDetailDetailABC(string line)
        {
            string table = line.Trim().Replace("=", string.Empty).Trim();
            string[] row = Regex.Split(table, "#");

            string description = row[0].Trim();
            string master = row[1].Trim();
            string detail1 = row[2].Trim();
            string detail2 = row[3].Trim();
            string child1 = row[4].Trim();
            string child2 = row[5].Trim();
            string child3 = row[6].Trim();

            string[] masterInfo = Regex.Split(master, ",", RegexOptions.IgnorePatternWhitespace);
            string[] detail1Info = Regex.Split(detail1, ",", RegexOptions.IgnorePatternWhitespace);
            string[] detail2Info = Regex.Split(detail2, ",", RegexOptions.IgnorePatternWhitespace);
            string[] childInfo1 = Regex.Split(child1, ",", RegexOptions.IgnorePatternWhitespace);
            string[] childInfo2 = Regex.Split(child2, ",", RegexOptions.IgnorePatternWhitespace);
            string[] childInfo3 = Regex.Split(child3, ",", RegexOptions.IgnorePatternWhitespace);

            string tableNameMaster = masterInfo[0].Trim();
            string tableNameDetail = detail1Info[0].Trim();
            string tableNameChild1 = childInfo1[0].Trim();
            string tableNameChild2 = childInfo2[0].Trim();
            string tableNameChild3 = childInfo3[0].Trim();

            //Master-Detail
            List<string> relationMasterColumns = new List<string>();
            List<string> relationDetailColumns = new List<string>();
            for (int i = 1; i < masterInfo.Length; i++)
            {
                relationMasterColumns.Add(masterInfo[i].Trim());
            }
            for (int i = 1; i < detail1Info.Length; i++)
            {
                relationDetailColumns.Add(detail1Info[i].Trim());
            }

            //Detail-Detail
            List<string> relationChildMasterColumns = new List<string>();
            List<string> relationChildDetailColumns = new List<string>();
            List<string> relationChildDetailColumnsB = new List<string>();
            List<string> relationChildDetailColumnsC = new List<string>();

            for (int i = 1; i < detail2Info.Length; i++)
            {
                relationChildMasterColumns.Add(detail2Info[i].Trim());
            }
            for (int i = 1; i < childInfo1.Length; i++)
            {
                relationChildDetailColumns.Add(childInfo1[i].Trim());
            }
            for (int i = 1; i < childInfo2.Length; i++)
            {
                relationChildDetailColumnsB.Add(childInfo2[i].Trim());
            }
            for (int i = 1; i < childInfo3.Length; i++)
            {
                relationChildDetailColumnsC.Add(childInfo3[i].Trim());
            }

            MasterDetailDetailABCForm form = new MasterDetailDetailABCForm(_dbname, tableNameMaster, tableNameDetail, tableNameChild1, tableNameChild2, tableNameChild3,relationMasterColumns, relationDetailColumns, relationChildMasterColumns, relationChildDetailColumns, relationChildDetailColumnsB, relationChildDetailColumnsC);
            BuildMasterDetailTableView(description, form);
        }

        private void dataDeletionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SqlConnectionStringBuilder builer = new SqlConnectionStringBuilder(Program.ConnectionString);
            builer.InitialCatalog = _dbname;
            DataRowView row = gridOverview.CurrentRow.DataBoundItem as DataRowView;
            if (row == null)
                return;
        }
    }
}
