using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

namespace EnterpriseSolutionBIDesktop
{
    public partial class WorkflowForm : FormBase
    {
        public const string QUERY_DATABASE_SIZE = @" SELECT * FROM dbo.GBWRKF   ";

        private string _database;

        public WorkflowForm(string database)
        {
            InitializeComponent();
            _database = database;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            SqlConnectionStringBuilder builer = new SqlConnectionStringBuilder(Program.ConnectionString);
            builer.InitialCatalog = _database;
            this.Text = string.Format(" {0} Workflow", builer.InitialCatalog);

            Database database = new SqlDatabase(builer.ConnectionString);
            using (DbCommand dbCommand = database.GetSqlStringCommand(QUERY_DATABASE_SIZE))
            {
                DataSet overview = database.ExecuteDataSet(dbCommand);
                grid.AutoGenerateColumns = true;
                bsDatabase.DataSource = overview.Tables[0];
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            string file = string.Empty;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);      
            saveFileDialog.Title = "Save workflow Files";
            saveFileDialog.DefaultExt = "xml";
            saveFileDialog.Filter = "Workflow files (*.xml)|*.xml|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                file = saveFileDialog.FileName;
            }

            if (string.IsNullOrWhiteSpace(file))
                return;

            DataTable dataSource = (DataTable)this.bsDatabase.DataSource;
            if (dataSource != null)
            {
                if (!chkSeparateFilePerWorkflow.Checked)
                    dataSource.WriteXml(file, XmlWriteMode.WriteSchema);
                else
                    ExportWorkflow(dataSource, file);
            }
        }

        private void ExportWorkflow(DataTable table, string file)
        {
            foreach (DataRow row in table.Rows)
            {
                DataTable tableWorkflow = table.Clone();
                tableWorkflow.ImportRow(row);
                string path = System.IO.Path.GetDirectoryName(file);
                //string wfType = StringEnum<WorkflowType>.GetDisplayText((WorkflowType)Convert.ToInt32(row["WorkflowType"]));
                //string wf = $"{wfType}.{Convert.ToString(row["WorkflowName"])}.{Convert.ToString(row["Description"])}.xml";
                //wf = RemoveInvalidFilePathCharacters(wf, string.Empty);
                //wf = Path.Combine(path, wf);
                //tableWorkflow.WriteXml(wf, XmlWriteMode.WriteSchema);
            }
        }

        public static string RemoveInvalidFilePathCharacters(string filename, string replaceChar)
        {
            string regexSearch = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());
            Regex r = new Regex(string.Format("[{0}]", Regex.Escape(regexSearch)));
            return r.Replace(filename, replaceChar);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure to delete all workflow item ?", "Confirm Deletion", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                string query = string.Format(" DELETE dbo.GBWRKF ");
                SqlConnectionStringBuilder builer = new SqlConnectionStringBuilder(Program.ConnectionString);
                builer.InitialCatalog = _database;
                using (SqlConnection connection = new SqlConnection(builer.ConnectionString))
                {
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = query;
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                }
            }
        }
    }
}
