using Microsoft.Practices.EnterpriseLibrary.Data;
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
using DevComponents.DotNetBar;
using System.Text.RegularExpressions;
using DevComponents.DotNetBar.Controls;

namespace EnterpriseSolutionBIDesktop
{
    public partial class FormBase : Office2007Form, IFormBase
    {
        public string InitialCatalog { get; set; }
        
        public DataTable Cache
        {
            get
            {
                if (MainForm.CachePrimaryKey == null)
                {
                    MainForm.CachePrimaryKey = new DataTable();

                    SqlConnectionStringBuilder builer = new SqlConnectionStringBuilder(Program.ConnectionString);
                    Database database = new Microsoft.Practices.EnterpriseLibrary.Data.Sql.SqlDatabase(builer.ConnectionString);
                    DbCommand cmd = database.GetSqlStringCommand(Command.ALL_PK_CACHE);
                    DataSet dataSetParent = database.ExecuteDataSet(cmd);
                    MainForm.CachePrimaryKey = dataSetParent.Tables[0];
                }

                return MainForm.CachePrimaryKey;
            }
        }
        public FormBase()
        {
            InitializeComponent();
        }

        protected virtual void ColumnStyle(DataGridView grid,  DataTable tableParent)
        {
            var rows=Cache.AsEnumerable().Where(en=>en.Field<string>("TABLE_NAME")== $"{tableParent.TableName}");
            foreach (DataRow row in rows)
            {
                if (grid.Columns[row.Field<string>("COLUMN_NAME")] != null)
                    grid.Columns[row.Field<string>("COLUMN_NAME")].HeaderCell.Style.Font = new Font("Tahoma", 9.75F, FontStyle.Bold);
            }

            foreach (DataGridViewColumn dataGridViewColumn in grid.Columns)
            {
                string colu = dataGridViewColumn.DataPropertyName;
                DataColumn dataColumn = tableParent.Columns[colu];
                dataGridViewColumn.HeaderText = colu + Environment.NewLine + GetDBType(dataColumn.DataType).ToString().ToLower();
            }
        }

        private SqlDbType GetDBType(System.Type theType)
        {
            System.Data.SqlClient.SqlParameter p1;
            System.ComponentModel.TypeConverter tc;
            p1 = new System.Data.SqlClient.SqlParameter();
            tc = System.ComponentModel.TypeDescriptor.GetConverter(p1.DbType);
            if (tc.CanConvertFrom(theType))
            {
                p1.DbType = (DbType)tc.ConvertFrom(theType.Name);
            }
            else
            {
                //Try brute force
                try
                {
                    p1.DbType = (DbType)tc.ConvertFrom(theType.Name);
                }
                catch (Exception)
                {
                    //Do Nothing; will return NVarChar as default
                }
            }
            return p1.SqlDbType;
        }

        protected virtual string Build(string query, string tableNameMaster,string filter,bool filterWithDefaultClient=false)
        {
            StringBuilder tableName = new StringBuilder();
            string prefix = $"{Command.TableOwner}.";
            tableName.Append(string.Format(Command.ALL_ROWS, prefix + tableNameMaster));
            tableName.Append("  WHERE  1=1 ");
            if (filterWithDefaultClient)
            {
                tableName.Append($"  AND MANDT = '{Command.Default_Client}' ");
            }

            if (!string.IsNullOrWhiteSpace(filter))
                tableName.Append($"  AND {filter} ");

            return tableName.ToString();
        }

        public string Description { get; set; }

        public void PerformMergeToolStrip()
        {
            this.MergeToolStrip();
        }

        public void PerformRevertMergeToolStrip()
        {
            this.RevertMergeToolStrip();
        }

        protected virtual void MergeToolStrip()
        {
        }


        protected virtual void RevertMergeToolStrip()
        {
        }

        protected override void OnClosed(EventArgs e)
        {
            if (!base.DesignMode)
            {
                this.RevertMergeToolStrip();
                this.Owner = null;
               
            }
            base.OnClosed(e);
        }
    }

    public interface IFormBase : IWin32Window, IDisposable
    {
        void PerformMergeToolStrip();
        void PerformRevertMergeToolStrip();
    }
}
