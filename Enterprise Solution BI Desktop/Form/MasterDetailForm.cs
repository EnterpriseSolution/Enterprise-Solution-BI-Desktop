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
using System.Windows.Markup;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

namespace EnterpriseSolutionBIDesktop
{
    public partial class MasterDetailForm : FormBase
    {
        private string _tableNameMaster;
        private string _tableNameDetail;
        private string _tableNameMasterFilter;
        private string _tableNameDetailFilter;
        private List<string> _relationMasterColumns;
        private List<string> _relationDetailColumns;
        private DataSet _dataSet;
        private bool _filterWithDefaultClient = true;
        public MasterDetailForm(string dbname,string tableNameMaster,string tableNameDetail, List<string> relationMasterColumns, List<string> relationDetailColumns,string tableNameMasterFilter="",string tableNameDetailFilter = "",  bool filterWithDefaultClient = true)
        {
            InitializeComponent();
            this.InitialCatalog = dbname;
            this._tableNameMaster =$"{tableNameMaster}" ;
            this._tableNameDetail = $"{tableNameDetail}"; 

            this._relationMasterColumns = relationMasterColumns;
            this._relationDetailColumns = relationDetailColumns;
            this._tableNameMasterFilter = tableNameMasterFilter;
            this._tableNameDetailFilter = tableNameDetailFilter;
            _filterWithDefaultClient = filterWithDefaultClient;

            txtMasterTable.Text = _tableNameMaster;
            txtDetailTable.Text = _tableNameDetail;

            gridMaster.ColumnAdded += dataGrid_ColumnAdded;
            gridDetail.ColumnAdded += dataGrid_ColumnAdded;
        }

        public MasterDetailForm(DataSet dataSet)
        {
            InitializeComponent();
            _dataSet = dataSet;
            gridMaster.ColumnAdded += dataGrid_ColumnAdded;
            gridDetail.ColumnAdded += dataGrid_ColumnAdded;
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
            gridDetail.DataSource = bindingSourceDetail;
            gridDetail.AutoGenerateColumns = true;
            gridMaster.RowPostPaint += DataGridViewRowPostPaint;
            gridDetail.RowPostPaint += DataGridViewRowPostPaint;

            if (_dataSet != null)
            {
                BindData();
                this.Description = "Master/Detail";
            }
            else
            {
                GetData();
                this.Description = string.Format("Master/Detail [{0} / {1}]", _tableNameMaster, _tableNameDetail);
            }
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


        //private BackgroundWorker backgroundWorker;

        private void GetData()
        {
            //backgroundWorker = new BackgroundWorker();
            //backgroundWorker.DoWork += backgroundWorker_DoWork;
            //backgroundWorker.RunWorkerCompleted += backgroundWorker_RunWorkerCompleted;
            Cursor = Cursors.WaitCursor;
            backgroundWorker.RunWorkerAsync();
        }

        private void BindData()
        {
            bindingSourceMaster.DataSource = _dataSet;
            bindingSourceMaster.DataMember = _dataSet.Tables[0].TableName;
            bindingSourceDetail.DataSource = bindingSourceMaster;
            bindingSourceDetail.DataMember = _dataSet.Relations[0].RelationName;
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            SqlConnectionStringBuilder builer = new SqlConnectionStringBuilder(Program.ConnectionString);
            builer.InitialCatalog = InitialCatalog;
            Database database = new SqlDatabase(builer.ConnectionString);
            DbCommand cmd = database.GetSqlStringCommand(Build(Command.ALL_ROWS, _tableNameMaster, _tableNameMasterFilter, _filterWithDefaultClient));
            DataSet dataSetParent = database.ExecuteDataSet(cmd);
            DataTable tableParent = dataSetParent.Tables[0];
            tableParent.TableName = _tableNameMaster;

            cmd = database.GetSqlStringCommand(Build(Command.ALL_ROWS, _tableNameDetail, _tableNameDetailFilter, _filterWithDefaultClient));
            DataSet dataSetChild = database.ExecuteDataSet(cmd);
            DataTable tableChild = dataSetChild.Tables[0];
            tableChild.TableName = _tableNameDetail;

            DataSet data = new DataSet();
            data.Locale = System.Globalization.CultureInfo.InvariantCulture;
            data.Tables.Add(tableParent.Copy());
            data.Tables.Add(tableChild.Copy());

            List<DataColumn> masterColumns = new List<DataColumn>();
            foreach (string relationColumn in _relationMasterColumns)
            {
                masterColumns.Add(data.Tables[_tableNameMaster].Columns[relationColumn]);
            }

            List<DataColumn> detailColumns = new List<DataColumn>();
            foreach (string relationColumn in _relationDetailColumns)
            {
                detailColumns.Add(data.Tables[_tableNameDetail].Columns[relationColumn]);
            }

            relationName = _tableNameMaster + _tableNameDetail;
            DataRelation relation = new DataRelation(relationName, masterColumns.ToArray(), detailColumns.ToArray(), false);
            data.Relations.Add(relation);
            e.Result = data;
        }

        private string relationName;
        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Cursor = Cursors.Default;
            if (e.Error != null)
            {
                Program.ShowError(e.Error);
            }

            if (e.Result != null)
            {
                DataSet data = e.Result as DataSet;
                bindingSourceMaster.DataSource = data;
                bindingSourceMaster.DataMember = _tableNameMaster;
                bindingSourceDetail.DataSource = bindingSourceMaster;
                bindingSourceDetail.DataMember = relationName;

                ColumnStyle(gridMaster, data.Tables[_tableNameMaster]);
                ColumnStyle(gridDetail, data.Tables[ _tableNameDetail]);
            }
        }
    }
}
