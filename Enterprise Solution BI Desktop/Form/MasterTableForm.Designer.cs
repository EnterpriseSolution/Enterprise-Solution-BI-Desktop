namespace EnterpriseSolutionBIDesktop
{
    partial class MasterTableForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.gridMaster = new Zuby.ADGV.AdvancedDataGridView();
            this.bindingSourceMaster = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSourceDetail = new System.Windows.Forms.BindingSource(this.components);
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblVersion = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblMasterTable = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtMasterTable = new System.Windows.Forms.ToolStripTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDetail)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(12, 13);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.gridMaster);
            this.splitContainer.Panel2Collapsed = true;
            this.splitContainer.Size = new System.Drawing.Size(981, 659);
            this.splitContainer.SplitterDistance = 294;
            this.splitContainer.TabIndex = 0;
            // 
            // gridMaster
            // 
            this.gridMaster.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridMaster.FilterAndSortEnabled = true;
            this.gridMaster.FilterStringChangedInvokeBeforeDatasourceUpdate = true;
            this.gridMaster.Location = new System.Drawing.Point(0, 0);
            this.gridMaster.Name = "gridMaster";
            this.gridMaster.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gridMaster.Size = new System.Drawing.Size(981, 659);
            this.gridMaster.SortStringChangedInvokeBeforeDatasourceUpdate = true;
            this.gridMaster.TabIndex = 1;
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblVersion,
            this.lblMasterTable,
            this.txtMasterTable});
            this.statusStrip.Location = new System.Drawing.Point(12, 649);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(981, 23);
            this.statusStrip.TabIndex = 4;
            this.statusStrip.Text = "statusStrip1";
            // 
            // lblVersion
            // 
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblVersion.Size = new System.Drawing.Size(0, 18);
            // 
            // lblMasterTable
            // 
            this.lblMasterTable.Name = "lblMasterTable";
            this.lblMasterTable.Size = new System.Drawing.Size(76, 18);
            this.lblMasterTable.Text = "Master Table:";
            // 
            // txtMasterTable
            // 
            this.txtMasterTable.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtMasterTable.Name = "txtMasterTable";
            this.txtMasterTable.ReadOnly = true;
            this.txtMasterTable.Size = new System.Drawing.Size(200, 23);
            // 
            // MasterTableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1005, 685);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.splitContainer);
            this.DoubleBuffered = true;
            this.Name = "MasterTableForm";
            this.Padding = new System.Windows.Forms.Padding(12, 13, 12, 13);
            this.Text = "Master/Detail ";
            this.splitContainer.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDetail)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.BindingSource bindingSourceMaster;
        private System.Windows.Forms.BindingSource bindingSourceDetail;
        private Zuby.ADGV.AdvancedDataGridView gridMaster;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblVersion;
        private System.Windows.Forms.ToolStripStatusLabel lblMasterTable;
        private System.Windows.Forms.ToolStripTextBox txtMasterTable;
    }
}