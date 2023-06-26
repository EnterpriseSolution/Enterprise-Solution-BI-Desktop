using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace EnterpriseSolutionBIDesktop
{
    [DesignerGenerated]
    public class EventLogViewer : UserControl
    {
        private static ArrayList __ENCList = new ArrayList();
        private ToolStripButton _btnErrors;
        private ToolStripButton _btnMessages;
        private ToolStripButton _btnWarnings;
        private ToolStripSeparator _ButtonSeparator1;
        private ToolStripSeparator _ButtonSeparator2;
        private DataGridView grid;
        private DataGridViewImageColumn eventImage;
        private EventLog _evLog;
        private ToolStripLabel _FindLabel;
        private ToolStripSeparator _FindSeparator;
        private ToolStripTextBox _FindText;
        private ToolStripLabel _NotFoundLabel;
        private ToolStripComboBox sourceCombo;
        private ToolStripLabel _SourceLabel;
        private ToolStripSeparator _SourceSeparator;
        private ToolStrip _ToolStrip1;
        private bool categoryVisible;
        private IContainer components;
        private DataSet ds;
        private bool eventIDVisible;
        private string logName = "";// Microsoft.Common.Shared.LogName;
        private int numErrors;
        private int numMessages;
        private int numWarnings;
        private int oldRowIndex;
        private DataGridViewImageColumn EventImage;
        private SplitContainer splitContainer;
        private TextBox txtError;
        private BindingSource eventLogBindingSource;
        private ToolStripButton toolStripButtonExport;

        // private DataGridViewImageColumn EventImage;
        private bool sourceVisible;

        public EventLogViewer()
        {
            this.InitializeComponent();
            base.Load += new EventHandler(this.EventLogViewer_Load);
            __ENCList.Add(new WeakReference(this));
            //this.logName = Microsoft.Common.Shared.LogName; // "Application";
            this.sourceVisible = true;
            this.categoryVisible = true;
            this.eventIDVisible = true;
            this.oldRowIndex = 0;
            this.numErrors = 0;
            this.numWarnings = 0;
            this.numMessages = 0;
            this.ds = null;
            //this.bs = null;
            this._FindText.TextChanged += new EventHandler(this.txtFindText_TextChanged);
            this._FindText.KeyPress += new KeyPressEventHandler(this.txtFindText_KeyPress);
            this.sourceCombo.SelectedIndexChanged += new EventHandler(this.cmb_SourceCombo_SelectedIndexChanged);

            this._btnErrors.Click += new EventHandler(this.btnErrors_Click);
            this._btnMessages.Click += new EventHandler(this.btnMessages_Click);
            this._btnWarnings.Click += new EventHandler(this.btnWarnings_Click);
        }

        private void appendEntryToDataSet(string message, string source, EventLogEntryType type, long instanceID, string category)
        {
            DateTime now = DateAndTime.Now;
            object[] values = new object[] {type, now, message, source, category, instanceID};
            this.ds.Tables["Events"].Rows.Add(values);
            if (type == EventLogEntryType.Error)
            {
                this.numErrors++;
            }

            if (type == EventLogEntryType.Warning)
            {
                this.numWarnings++;
            }

            if (type == EventLogEntryType.Information)
            {
                this.numMessages++;
            }

            this._btnErrors.Text = this.numErrors.ToString() + " Errors";
            this._btnWarnings.Text = this.numWarnings.ToString() + " Warnings";
            this._btnMessages.Text = this.numMessages.ToString() + " Messages";
            this._btnErrors.ToolTipText = this.numErrors.ToString() + " Errors";
            this._btnWarnings.ToolTipText = this.numWarnings.ToString() + " Warnings";
            this._btnMessages.ToolTipText = this.numMessages.ToString() + " Messages";
        }

        private void btnErrors_Click(object sender, EventArgs e)
        {
            this.eventLogBindingSource.Filter = this.generateEventFiler();
            this.refreshFilterDisplay();
        }

        private void btnMessages_Click(object sender, EventArgs e)
        {
            this.eventLogBindingSource.Filter = this.generateEventFiler();
            this.refreshFilterDisplay();
        }

        private void btnWarnings_Click(object sender, EventArgs e)
        {
            this.eventLogBindingSource.Filter = this.generateEventFiler();
            this.refreshFilterDisplay();
        }

        private void cmb_SourceCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.eventLogBindingSource.Filter = this.generateEventFiler();
            this.refreshFilterDisplay();
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.grid.Columns[e.ColumnIndex].Name.Equals("EventImage") && this.grid.Columns.Contains("Type"))
            {
                string str = this.grid["Type", e.RowIndex].Value as string;
                if (str != null)
                {
                    DataGridViewCell cell = this.grid[e.ColumnIndex, e.RowIndex];
                    cell.ToolTipText = str;
                    switch (str)
                    {
                        case "Error":
                            e.Value = EnterpriseSolutionBIDesktop.Properties.Resources.Error;
                            break;

                        case "Warning":
                            e.Value = EnterpriseSolutionBIDesktop.Properties.Resources.Warning;
                            break;

                        case "Information":
                            e.Value = EnterpriseSolutionBIDesktop.Properties.Resources.Message;
                            break;
                    }
                }
            }
        }

        private void dataGridView1_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            this.grid.Invalidate();
        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            if (this.oldRowIndex != -1)
            {
                this.grid.InvalidateRow(this.oldRowIndex);
            }

            this.oldRowIndex = this.grid.CurrentCellAddress.Y;
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Rectangle bounds = new Rectangle(0, e.RowBounds.Top, (this.grid.Columns.GetColumnsWidth(DataGridViewElementStates.Visible) - this.grid.HorizontalScrollingOffset) + 1, e.RowBounds.Height);
            SolidBrush brush = null;
            {
                if ((e.State & DataGridViewElementStates.Selected) == DataGridViewElementStates.Selected)
                {
                    brush = new SolidBrush(e.InheritedRowStyle.SelectionForeColor);
                }
                else
                {
                    brush = new SolidBrush(e.InheritedRowStyle.ForeColor);
                }
            }
            if (this.grid.CurrentCellAddress.Y == e.RowIndex)
            {
                e.DrawFocus(bounds, true);
            }
        }

        private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            e.PaintParts &= ~DataGridViewPaintParts.Focus;
            if ((e.State & DataGridViewElementStates.Selected) == DataGridViewElementStates.Selected)
            {
                Rectangle rect = new Rectangle(0, e.RowBounds.Top, (this.grid.Columns.GetColumnsWidth(DataGridViewElementStates.Visible) - this.grid.HorizontalScrollingOffset) + 1, e.RowBounds.Height);
                using (LinearGradientBrush brush = new LinearGradientBrush(rect, this.grid.DefaultCellStyle.SelectionBackColor, e.InheritedRowStyle.ForeColor, LinearGradientMode.Horizontal))
                {
                    e.Graphics.FillRectangle(brush, rect);
                }
            }
        }

        [DebuggerNonUserCode]
        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }

            base.Dispose(disposing);
        }

        BindingSource gridSource;

        private void EventLogViewer_Load(object sender, EventArgs e)
        {
            this.grid.RowTemplate.DefaultCellStyle.SelectionBackColor = Color.Transparent;
            this.grid.RowTemplate.DefaultCellStyle.SelectionBackColor = Color.Transparent;
            this.grid.CellBorderStyle = DataGridViewCellBorderStyle.None;
            this.grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.grid.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders);
            if (!this.DesignMode)
            {
                IEnumerator enumerator;

                if (!EventLog.SourceExists(this.logName))
                    EventLog.CreateEventSource(this.logName, this.logName);
                this._evLog = new EventLog(this.logName);
                this._evLog.EnableRaisingEvents = true;
                this._evLog.EntryWritten += new EntryWrittenEventHandler(this.evLog_EntryWritten);
                this.ds = new DataSet("EventLog Entries");
                this.ds.Tables.Add("Events");
                DataTable table = this.ds.Tables["Events"];
                table.Columns.Add("Type");
                table.Columns.Add("Date/Time");
                table.Columns["Date/Time"].DataType = typeof(DateTime);
                table.Columns.Add("Message");
                table.Columns.Add("Source");
                table.Columns.Add("Category");
                table.Columns.Add("EventID");
                table = null;
                int num2 = this._evLog.Entries.Count - 1;
                for (int i = 0; i <= num2; i++)
                {
                    EventLogEntry entry = this._evLog.Entries[i];
                    object[] values = new object[] {entry.EntryType, entry.TimeGenerated, entry.Message, entry.Source, entry.Category, entry.InstanceId};
                    this.ds.Tables["Events"].Rows.Add(values);
                    if (!this.sourceCombo.Items.Contains(entry.Source))
                    {
                        this.sourceCombo.Items.Add(entry.Source);
                    }

                    if (entry.EntryType == EventLogEntryType.Error)
                    {
                        this.numErrors++;
                    }
                    else if (entry.EntryType == EventLogEntryType.Warning)
                    {
                        this.numWarnings++;
                    }
                    else if (entry.EntryType == EventLogEntryType.Information)
                    {
                        this.numMessages++;
                    }
                    else
                    {
                        entry = null;
                    }
                }

                this._btnErrors.Text = this.numErrors.ToString() + " Errors";
                this._btnErrors.ToolTipText = this.numErrors.ToString() + " Errors";
                this._btnWarnings.Text = this.numWarnings.ToString() + " Warnings";
                this._btnWarnings.ToolTipText = this.numWarnings.ToString() + " Warnings";
                this._btnMessages.Text = this.numMessages.ToString() + " Messages";
                this._btnMessages.ToolTipText = this.numMessages.ToString() + " Messages";
                //eventLogBindingSource = new BindingSource(this.ds, "Events");
                eventLogBindingSource.DataSource = ds;
                eventLogBindingSource.DataMember = "Events";
                this.grid.DataSource = this.eventLogBindingSource;
                try
                {
                    enumerator = this.grid.Columns.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        DataGridViewColumn current = (DataGridViewColumn) enumerator.Current;
                        if (current.Name != "Message")
                        {
                            current.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
                        }

                        if (current.Name == "Date/Time")
                        {
                            current.ValueType = typeof(DateTime);
                        }
                    }
                }
                finally
                {
                    //if (enumerator is IDisposable)
                    //{
                    //    (enumerator as IDisposable).Dispose();
                    //}
                }

                if (this.grid.Columns.Contains("Source"))
                {
                    this.grid.Columns["Source"].Visible = this.sourceVisible;
                }

                this.sourceCombo.Visible = this.sourceVisible;
                this._SourceSeparator.Visible = this.sourceVisible;
                this._SourceLabel.Visible = this.sourceVisible;
                if (this.grid.Columns.Contains("Category"))
                {
                    this.grid.Columns["Category"].Visible = this.categoryVisible;
                }

                if (this.grid.Columns.Contains("EventID"))
                {
                    this.grid.Columns["EventID"].Visible = this.eventIDVisible;
                }
            }
        }

        private void evLog_EntryWritten(object sender, EntryWrittenEventArgs e)
        {
            if (this.InvokeRequired)
            {
                d_appendEntryToDataSet method = new d_appendEntryToDataSet(this.appendEntryToDataSet);
                this.Invoke(method, new object[] {e.Entry.Message, e.Entry.Source, e.Entry.EntryType, e.Entry.InstanceId, e.Entry.Category});
            }
            else
            {
                this.appendEntryToDataSet(e.Entry.Message, e.Entry.Source, e.Entry.EntryType, e.Entry.InstanceId, e.Entry.Category);
            }
        }

        private string generateEventFiler()
        {
            bool flag = this._btnErrors.Checked;
            bool flag3 = this._btnWarnings.Checked;
            bool flag2 = this._btnMessages.Checked;
            string str = string.Empty;
            if (this._btnErrors.Checked)
            {
                str = "(Type='Error')";
            }

            if (this._btnWarnings.Checked)
            {
                if (string.IsNullOrEmpty(str))
                {
                    str = "(Type='Warning')";
                }
                else
                {
                    str = str.Trim(")".ToCharArray()) + " OR Type='Warning')";
                }
            }

            if (this._btnMessages.Checked)
            {
                if (string.IsNullOrEmpty(str))
                {
                    str = "(Type='Information')";
                }
                else
                {
                    str = str.Trim(")".ToCharArray()) + " OR Type='Information')";
                }
            }

            if (string.IsNullOrEmpty(str))
            {
                return "Type=''";
            }

            if (!string.IsNullOrEmpty(this.sourceCombo.Text.Trim()))
            {
                str = str + " AND Source='" + this.sourceCombo.Text + "'";
            }

            if (!string.IsNullOrEmpty(this._FindText.Text))
            {
                str = str + " AND Message LIKE '*" + this._FindText.Text + "*'";
            }

            return str;
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this._ToolStrip1 = new System.Windows.Forms.ToolStrip();
            this._btnErrors = new System.Windows.Forms.ToolStripButton();
            this._ButtonSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this._btnWarnings = new System.Windows.Forms.ToolStripButton();
            this._ButtonSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this._btnMessages = new System.Windows.Forms.ToolStripButton();
            this._SourceSeparator = new System.Windows.Forms.ToolStripSeparator();
            this._SourceLabel = new System.Windows.Forms.ToolStripLabel();
            this.sourceCombo = new System.Windows.Forms.ToolStripComboBox();
            this._FindSeparator = new System.Windows.Forms.ToolStripSeparator();
            this._FindLabel = new System.Windows.Forms.ToolStripLabel();
            this._FindText = new System.Windows.Forms.ToolStripTextBox();
            this._NotFoundLabel = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButtonExport = new System.Windows.Forms.ToolStripButton();
            this.grid = new System.Windows.Forms.DataGridView();
            this.EventImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.txtError = new System.Windows.Forms.TextBox();
            this.eventLogBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._ToolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.eventLogBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // _ToolStrip1
            // 
            this._ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this._ToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[]
            {
                this._btnErrors,
                this._ButtonSeparator1,
                this._btnWarnings,
                this._ButtonSeparator2,
                this._btnMessages,
                this._SourceSeparator,
                this._SourceLabel,
                this.sourceCombo,
                this._FindSeparator,
                this._FindLabel,
                this._FindText,
                this._NotFoundLabel,
                this.toolStripButtonExport
            });
            this._ToolStrip1.Location = new System.Drawing.Point(0, 0);
            this._ToolStrip1.Name = "_ToolStrip1";
            this._ToolStrip1.Padding = new System.Windows.Forms.Padding(4, 1, 1, 1);
            this._ToolStrip1.Size = new System.Drawing.Size(728, 25);
            this._ToolStrip1.TabIndex = 4;
            this._ToolStrip1.Text = "ToolStrip1";
            // 
            // _btnErrors
            // 
            this._btnErrors.Checked = true;
            this._btnErrors.CheckOnClick = true;
            this._btnErrors.CheckState = System.Windows.Forms.CheckState.Checked;
            this._btnErrors.Image = global::EnterpriseSolutionBIDesktop.Properties.Resources.Error;
            this._btnErrors.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this._btnErrors.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnErrors.Name = "_btnErrors";
            this._btnErrors.Size = new System.Drawing.Size(64, 20);
            this._btnErrors.Text = "0 Errors";
            this._btnErrors.ToolTipText = "0 Errors";
            // 
            // _ButtonSeparator1
            // 
            this._ButtonSeparator1.Margin = new System.Windows.Forms.Padding(-1, 0, 1, 0);
            this._ButtonSeparator1.Name = "_ButtonSeparator1";
            this._ButtonSeparator1.Size = new System.Drawing.Size(6, 23);
            // 
            // _btnWarnings
            // 
            this._btnWarnings.Checked = true;
            this._btnWarnings.CheckOnClick = true;
            this._btnWarnings.CheckState = System.Windows.Forms.CheckState.Checked;
            this._btnWarnings.Image = global::EnterpriseSolutionBIDesktop.Properties.Resources.Warning;
            this._btnWarnings.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this._btnWarnings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnWarnings.Name = "_btnWarnings";
            this._btnWarnings.Size = new System.Drawing.Size(86, 20);
            this._btnWarnings.Text = "0 Warnings";
            this._btnWarnings.ToolTipText = "0 Warnings";
            // 
            // _ButtonSeparator2
            // 
            this._ButtonSeparator2.Margin = new System.Windows.Forms.Padding(-1, 0, 1, 0);
            this._ButtonSeparator2.Name = "_ButtonSeparator2";
            this._ButtonSeparator2.Size = new System.Drawing.Size(6, 23);
            // 
            // _btnMessages
            // 
            this._btnMessages.Checked = true;
            this._btnMessages.CheckOnClick = true;
            this._btnMessages.CheckState = System.Windows.Forms.CheckState.Checked;
            this._btnMessages.Image = global::EnterpriseSolutionBIDesktop.Properties.Resources.Message;
            this._btnMessages.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this._btnMessages.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnMessages.Name = "_btnMessages";
            this._btnMessages.Size = new System.Drawing.Size(86, 20);
            this._btnMessages.Text = "0 Messages";
            this._btnMessages.ToolTipText = "0 Messages";
            // 
            // _SourceSeparator
            // 
            this._SourceSeparator.Margin = new System.Windows.Forms.Padding(-1, 0, 1, 0);
            this._SourceSeparator.Name = "_SourceSeparator";
            this._SourceSeparator.Size = new System.Drawing.Size(6, 23);
            // 
            // _SourceLabel
            // 
            this._SourceLabel.Name = "_SourceLabel";
            this._SourceLabel.Size = new System.Drawing.Size(46, 20);
            this._SourceLabel.Text = "Source:";
            // 
            // sourceCombo
            // 
            this.sourceCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sourceCombo.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.sourceCombo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.sourceCombo.Items.AddRange(new object[]
            {
                " "
            });
            this.sourceCombo.Margin = new System.Windows.Forms.Padding(1, 0, 2, 0);
            this.sourceCombo.Name = "sourceCombo";
            this.sourceCombo.Size = new System.Drawing.Size(140, 23);
            this.sourceCombo.Sorted = true;
            // 
            // _FindSeparator
            // 
            this._FindSeparator.Margin = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this._FindSeparator.Name = "_FindSeparator";
            this._FindSeparator.Size = new System.Drawing.Size(6, 23);
            // 
            // _FindLabel
            // 
            this._FindLabel.Name = "_FindLabel";
            this._FindLabel.Size = new System.Drawing.Size(33, 20);
            this._FindLabel.Text = "Find:";
            // 
            // _FindText
            // 
            this._FindText.ForeColor = System.Drawing.SystemColors.WindowText;
            this._FindText.Name = "_FindText";
            this._FindText.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this._FindText.Size = new System.Drawing.Size(76, 23);
            // 
            // _NotFoundLabel
            // 
            this._NotFoundLabel.Image = global::EnterpriseSolutionBIDesktop.Properties.Resources.NotFound;
            this._NotFoundLabel.Margin = new System.Windows.Forms.Padding(5, 1, 0, 2);
            this._NotFoundLabel.Name = "_NotFoundLabel";
            this._NotFoundLabel.Size = new System.Drawing.Size(111, 20);
            this._NotFoundLabel.Text = "No events found";
            this._NotFoundLabel.ToolTipText = "There are no events that match the defined filter.";
            this._NotFoundLabel.Visible = false;
            // 
            // toolStripButtonExport
            // 
            this.toolStripButtonExport.Image = global::EnterpriseSolutionBIDesktop.Properties.Resources.node_export_16;
            this.toolStripButtonExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonExport.Name = "toolStripButtonExport";
            this.toolStripButtonExport.Size = new System.Drawing.Size(60, 20);
            this.toolStripButtonExport.Text = "Export";
            this.toolStripButtonExport.Click += new System.EventHandler(this.toolStripButtonExport_Click);
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToDeleteRows = false;
            this.grid.AllowUserToResizeColumns = false;
            this.grid.AllowUserToResizeRows = false;
            this.grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[]
            {
                this.EventImage
            });
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.Location = new System.Drawing.Point(0, 0);
            this.grid.MultiSelect = false;
            this.grid.Name = "grid";
            this.grid.ReadOnly = true;
            this.grid.RowHeadersVisible = false;
            this.grid.Size = new System.Drawing.Size(728, 225);
            this.grid.TabIndex = 5;
            this.grid.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            this.grid.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dataGridView1_ColumnWidthChanged);
            this.grid.CurrentCellChanged += new System.EventHandler(this.dataGridView1_CurrentCellChanged);
            this.grid.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView1_RowPostPaint);
            this.grid.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dataGridView1_RowPrePaint);
            // 
            // EventImage
            // 
            this.EventImage.HeaderText = "";
            this.EventImage.Name = "EventImage";
            this.EventImage.ReadOnly = true;
            this.EventImage.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.EventImage.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 25);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.grid);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.txtError);
            this.splitContainer.Size = new System.Drawing.Size(728, 321);
            this.splitContainer.SplitterDistance = 225;
            this.splitContainer.TabIndex = 6;
            // 
            // txtError
            // 
            this.txtError.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtError.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtError.Location = new System.Drawing.Point(0, 0);
            this.txtError.Multiline = true;
            this.txtError.Name = "txtError";
            this.txtError.Size = new System.Drawing.Size(728, 92);
            this.txtError.TabIndex = 0;
            // 
            // eventLogBindingSource
            // 
            this.eventLogBindingSource.CurrentItemChanged += new System.EventHandler(this.eventLogBindingSource_CurrentItemChanged);
            // 
            // EventLogViewer
            // 
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this._ToolStrip1);
            this.Name = "EventLogViewer";
            this.Size = new System.Drawing.Size(728, 346);
            this._ToolStrip1.ResumeLayout(false);
            this._ToolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) (this.grid)).EndInit();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) (this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize) (this.eventLogBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void refreshFilterDisplay()
        {
            if (this.grid.Rows.Count == 0)
            {
                if (this._FindText.Text.Length > 0)
                {
                    this._FindText.BackColor = Color.Salmon;
                }
                else
                {
                    this._FindText.BackColor = Color.White;
                }

                this._NotFoundLabel.Visible = true;
            }
            else
            {
                this._FindText.BackColor = Color.White;
                this._NotFoundLabel.Visible = false;
            }
        }

        private void txtFindText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsPunctuation(e.KeyChar))
            {
                e.Handled = true;
                Interaction.Beep();
            }
        }

        private void txtFindText_TextChanged(object sender, EventArgs e)
        {
            this.eventLogBindingSource.Filter = this.generateEventFiler();
            if (this.grid.Rows.Count == 0)
            {
                this._FindText.BackColor = Color.Salmon;
                this._NotFoundLabel.Visible = true;
            }
            else
            {
                this._FindText.BackColor = Color.White;
                this._NotFoundLabel.Visible = false;
            }
        }

        //internal virtual ToolStripSeparator ButtonSeparator1
        //{
        //    [DebuggerNonUserCode]
        //    get
        //    {
        //        return this._ButtonSeparator1;
        //    }
        //    [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
        //    set
        //    {
        //        this._ButtonSeparator1 = value;
        //    }
        //}

        //internal virtual ToolStripSeparator ButtonSeparator2
        //{
        //    [DebuggerNonUserCode]
        //    get
        //    {
        //        return this._ButtonSeparator2;
        //    }
        //    [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
        //    set
        //    {
        //        this._ButtonSeparator2 = value;
        //    }
        //}

        public bool IsCategoryVisible
        {
            get { return this.categoryVisible; }
            set
            {
                this.categoryVisible = value;
                if (!this.DesignMode)
                {
                    IEnumerator enumerator;
                    if (this.grid.Columns.Contains("Category"))
                    {
                        this.grid.Columns["Category"].Visible = this.categoryVisible;
                    }

                    try
                    {
                        enumerator = this.grid.Columns.GetEnumerator();
                        while (enumerator.MoveNext())
                        {
                            DataGridViewColumn current = (DataGridViewColumn) enumerator.Current;
                            if (current.Name != "Message")
                            {
                                current.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                            }
                        }
                    }
                    finally
                    {
                        //if (enumerator is IDisposable)
                        //{
                        //    (enumerator as IDisposable).Dispose();
                        //}
                    }
                }
            }
        }

        public bool IsEventIDVisible
        {
            get { return this.eventIDVisible; }
            set
            {
                this.eventIDVisible = value;
                if (!this.DesignMode)
                {
                    IEnumerator enumerator;
                    if (this.grid.Columns.Contains("EventID"))
                    {
                        this.grid.Columns["EventID"].Visible = this.eventIDVisible;
                    }

                    try
                    {
                        enumerator = this.grid.Columns.GetEnumerator();
                        while (enumerator.MoveNext())
                        {
                            DataGridViewColumn current = (DataGridViewColumn) enumerator.Current;
                            if (current.Name != "Message")
                            {
                                current.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                            }
                        }
                    }
                    finally
                    {
                        //if (enumerator is IDisposable)
                        //{
                        //    (enumerator as IDisposable).Dispose();
                        //}
                    }
                }
            }
        }

        public bool IsSourceVisible
        {
            get { return this.sourceVisible; }
            set
            {
                this.sourceVisible = value;
                if (!this.DesignMode)
                {
                    IEnumerator enumerator;
                    if (this.grid.Columns.Contains("Source"))
                    {
                        this.grid.Columns["Source"].Visible = this.sourceVisible;
                    }

                    sourceCombo.Visible = this.sourceVisible;
                    this._SourceSeparator.Visible = this.sourceVisible;
                    this._SourceLabel.Visible = this.sourceVisible;
                    try
                    {
                        enumerator = this.grid.Columns.GetEnumerator();
                        while (enumerator.MoveNext())
                        {
                            DataGridViewColumn current = (DataGridViewColumn) enumerator.Current;
                            if (current.Name != "Message")
                            {
                                current.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                            }
                        }
                    }
                    finally
                    {
                        //if (enumerator is IDisposable)
                        //{
                        //    (enumerator as IDisposable).Dispose();
                        //}
                    }
                }
            }
        }

        public string Log
        {
            get { return this.logName; }
            set { this.logName = value; }
        }

        private delegate void d_appendEntryToDataSet(string message, string source, EventLogEntryType type, long instanceID, string category);

        private void eventLogBindingSource_CurrentItemChanged(object sender, EventArgs e)
        {
            if (eventLogBindingSource.Current == null)
                return;

            DataRowView row = eventLogBindingSource.Current as DataRowView;
            if (row != null)
                txtError.Text = Convert.ToString(row.Row["Message"]);
        }

        private void toolStripButtonExport_Click(object sender, EventArgs e)
        {
            String filter = sourceCombo.Text;
            string channelPath = "";
            if (string.IsNullOrWhiteSpace(filter))
            {
                //channelPath = Microsoft.Common.Shared.LogName;
                filter = "*";
            }
            else
                channelPath = this.logName;

             SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "Event files (*.evtx)|*.evtx|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex =1;
            saveFileDialog1.RestoreDirectory = true;
            string ft = filter.Length > 1 ? "_" + filter : string.Empty;
            string file = $"{Environment.MachineName}_{channelPath}{ft}_{DateTime.Now.ToShortDateString()}.evtx";
            string invalid = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());
            foreach (char c in invalid)
            {
                file = file.Replace(c.ToString(), "");
            }

            saveFileDialog1.FileName = file;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                file = saveFileDialog1.FileName;
            }

            if (string.IsNullOrWhiteSpace(file))
                return ;

            var success = EvtExportLog(IntPtr.Zero, channelPath, filter, file, 1);
            if (!success)
            {
                var error = GetLastError();
                Console.WriteLine(error);
            }
        }

        /*
         * Question: Is it possible to export an event log in a process not "run as administrator"?

Yes you can but only if you have the rights to access the event log you want to export.

However, your question seems to be more something like

Why can't I export my application's event log using EventLogSession? An EventLogException is thrown with the message "The directory name is invalid".

Looking into the source code for EventLogSession you can see that the call to ExportLogAndMessages will call the native function EvtExportLog. If this function fails the error code is retrieved by calling GetLastError. This native Windows error code is then mapped to one of several exceptions.

The exception that you experience is thrown if any of the following errors happen:

ERROR_FILE_NOT_FOUND (2): The system cannot find the file specified.
ERROR_PATH_NOT_FOUND (3): The system cannot find the path specified.
ERROR_EVT_CHANNEL_NOT_FOUND (15007): The specified channel could not be found. Check channel configuration.
ERROR_EVT_MESSAGE_NOT_FOUND (15027): The message resource is present but the message is not found in the string/message table.
ERROR_EVT_MESSAGE_ID_NOT_FOUND (15028): The message id for the desired message could not be found.
ERROR_EVT_PUBLISHER_METADATA_NOT_FOUND (15002): The publisher metadata cannot be found in the resource.
If you specify a wrong event log name then ERROR_EVT_CHANNEL_NOT_FOUND is the error you encounter. My guess is that this is your problem.

However, you can call EvtExportLog yourself and inspect the native error code to better understand why the call fails:
         */
        [DllImport("kernel32.dll")]
        static extern uint GetLastError();

        [DllImport("wevtapi.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool EvtExportLog(IntPtr session, string channelPath, string query, string targetFilePath, int flags);
    }
}

