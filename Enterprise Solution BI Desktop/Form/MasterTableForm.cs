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
    public partial class MasterTableForm : FormBase
    {
        private string _dbname;
        private string _tableNameMaster;
        private string _tableNameMasterFilter;
        DataTable _table;
        private bool _filterWithDefaultClient = false;

        public MasterTableForm(string tableNameMaster,string tableNameMasterFilter="", bool filterWithDefaultClient=false)
        {
            InitializeComponent();
           
            this._tableNameMaster = tableNameMaster;
            _tableNameMasterFilter = tableNameMasterFilter;
            _filterWithDefaultClient = filterWithDefaultClient;
            gridMaster.ColumnAdded += dataGrid_ColumnAdded;

            txtMasterTable.Text = tableNameMaster;
        }

        protected override void MergeToolStrip()
        {
            if ((base.IsMdiChild) && (base.MdiParent is IMDIContainer))
            {
                this.statusStrip.Visible = false;
                IMDIContainer mdiParent = (IMDIContainer)base.MdiParent;
                mdiParent.MergeStatusStrip(this.statusStrip);
            }
        }

        protected override void RevertMergeToolStrip()
        {
            if (base.IsMdiChild && (base.MdiParent is IMDIContainer))
            {
                IMDIContainer mdiParent = (IMDIContainer)base.MdiParent;
                mdiParent.RevertStatusStrip(this.statusStrip);
                this.statusStrip.Visible = base.MdiParent.ActiveMdiChild == this;
            }
        }

        public MasterTableForm(DataTable table)
        {
            InitializeComponent();
            this._tableNameMaster = table.TableName;
            this._table = table;
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
            gridMaster.RowPostPaint += DataGridViewRowPostPaint;
            GetData();

           
        }

        //protected override void OnShown(EventArgs e)
        //{
        //    base.OnShown(e);

        //    //gridMaster.DataSource = bindingSourceMaster;
        //    //gridMaster.AutoGenerateColumns = true;
        //    //gridMaster.RowPostPaint += DataGridViewRowPostPaint;
        //    //GetData();
        //}

        //async void LoadData()
        //{
        //    gridMaster.DataSource = bindingSourceMaster;
        //    gridMaster.AutoGenerateColumns = true;
        //    gridMaster.RowPostPaint += DataGridViewRowPostPaint;
        //    GetData();
        //}
        void DataGridViewRowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridView dg = (DataGridView)sender;
            // Current row record
            string rowNumber = (e.RowIndex + 1).ToString();

            // Format row based on number of records displayed by using leading zeros
            while (rowNumber.Length < dg.RowCount.ToString().Length) rowNumber = "0" + rowNumber;

            // Position text
            SizeF size = e.Graphics.MeasureString(rowNumber, this.Font);
            if (dg.RowHeadersWidth < (int)(size.Width + 20)) dg.RowHeadersWidth = (int)(size.Width + 20);

            // Use default system text brush
            Brush b = SystemBrushes.ControlText;

            // Draw row number
            e.Graphics.DrawString(rowNumber, dg.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));
        }

        private void GetData()
        {
           // backgroundWorker = new BackgroundWorker();
            //backgroundWorker.DoWork += backgroundWorker_DoWork;
            //backgroundWorker.RunWorkerCompleted += backgroundWorker_RunWorkerCompleted;
            Cursor = Cursors.WaitCursor;
            if (!backgroundWorker.IsBusy)
                backgroundWorker.RunWorkerAsync();
        }

       // private BackgroundWorker backgroundWorker;
      
        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            SqlConnectionStringBuilder builer = new SqlConnectionStringBuilder(Program.ConnectionString);
            Database database = new SqlDatabase(builer.ConnectionString);
            DbCommand cmd = database.GetSqlStringCommand(Build(Command.ALL_ROWS, _tableNameMaster, _tableNameMasterFilter, _filterWithDefaultClient));
            DataSet dataSetParent = database.ExecuteDataSet(cmd);
            e.Result = dataSetParent;
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Cursor = Cursors.Default;
           
            if (e.Error != null)
            {
                Program.ShowError(e.Error);

                //Type errorType = e.Error.GetType();

               

                //switch (errorType.Name)
                //{
                //    case "ArgumentNullException":
                //    case "MyException":
                        
                //        break;
                //    default:
                //        //do something.
                //        break;
                //}
            }
            
            if(e.Result!=null)
            {
                DataSet dataSetParent = e.Result as DataSet;
                DataTable tableParent = dataSetParent.Tables[0];
                tableParent.TableName = _tableNameMaster;

                DataSet data = new DataSet();
                data.Locale = System.Globalization.CultureInfo.InvariantCulture;
                data.Tables.Add(tableParent.Copy());

                bindingSourceMaster.DataSource = data;
                bindingSourceMaster.DataMember = _tableNameMaster;

                //gridMaster.AutoResizeColumns();
                ColumnStyle(gridMaster, tableParent);
            }
        }
    }

   
}
