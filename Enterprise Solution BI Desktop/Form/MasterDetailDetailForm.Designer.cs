namespace EnterpriseSolutionBIDesktop
{
    partial class MasterDetailDetailForm
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
            this.gridMaster = new System.Windows.Forms.DataGridView();
            this.gridDetail = new System.Windows.Forms.DataGridView();
            this.bindingSourceMaster = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSourceDetail = new System.Windows.Forms.BindingSource(this.components);
            this.splitContainerBottom = new System.Windows.Forms.SplitContainer();
            this.gridDetailDetail = new System.Windows.Forms.DataGridView();
            this.bindingSourceDetailDetail = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerBottom)).BeginInit();
            this.splitContainerBottom.Panel1.SuspendLayout();
            this.splitContainerBottom.Panel2.SuspendLayout();
            this.splitContainerBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDetailDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDetailDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(12, 12);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.gridMaster);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.splitContainerBottom);
            this.splitContainer.Size = new System.Drawing.Size(981, 608);
            this.splitContainer.SplitterDistance = 177;
            this.splitContainer.TabIndex = 0;
            // 
            // gridMaster
            // 
            this.gridMaster.AutoGenerateColumns = false;
            this.gridMaster.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridMaster.DataSource = this.bindingSourceMaster;
            this.gridMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridMaster.Location = new System.Drawing.Point(0, 0);
            this.gridMaster.Name = "gridMaster";
            this.gridMaster.RowTemplate.Height = 23;
            this.gridMaster.Size = new System.Drawing.Size(981, 177);
            this.gridMaster.TabIndex = 0;
            // 
            // gridDetail
            // 
            this.gridDetail.AutoGenerateColumns = false;
            this.gridDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridDetail.DataSource = this.bindingSourceDetail;
            this.gridDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridDetail.Location = new System.Drawing.Point(0, 0);
            this.gridDetail.Name = "gridDetail";
            this.gridDetail.RowTemplate.Height = 23;
            this.gridDetail.Size = new System.Drawing.Size(981, 213);
            this.gridDetail.TabIndex = 0;
            // 
            // splitContainerBottom
            // 
            this.splitContainerBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerBottom.Location = new System.Drawing.Point(0, 0);
            this.splitContainerBottom.Name = "splitContainerBottom";
            this.splitContainerBottom.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerBottom.Panel1
            // 
            this.splitContainerBottom.Panel1.Controls.Add(this.gridDetail);
            // 
            // splitContainerBottom.Panel2
            // 
            this.splitContainerBottom.Panel2.Controls.Add(this.gridDetailDetail);
            this.splitContainerBottom.Size = new System.Drawing.Size(981, 427);
            this.splitContainerBottom.SplitterDistance = 213;
            this.splitContainerBottom.TabIndex = 1;
            // 
            // gridDetailDetail
            // 
            this.gridDetailDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridDetailDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridDetailDetail.Location = new System.Drawing.Point(0, 0);
            this.gridDetailDetail.Name = "gridDetailDetail";
            this.gridDetailDetail.RowTemplate.Height = 23;
            this.gridDetailDetail.Size = new System.Drawing.Size(981, 210);
            this.gridDetailDetail.TabIndex = 0;
            // 
            // MasterDetailDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1005, 632);
            this.Controls.Add(this.splitContainer);
            this.Name = "MasterDetailDetailForm";
            this.Padding = new System.Windows.Forms.Padding(12);
            this.Text = "Master/Detail/Detail";
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDetail)).EndInit();
            this.splitContainerBottom.Panel1.ResumeLayout(false);
            this.splitContainerBottom.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerBottom)).EndInit();
            this.splitContainerBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridDetailDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDetailDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.DataGridView gridMaster;
        private System.Windows.Forms.DataGridView gridDetail;
        private System.Windows.Forms.BindingSource bindingSourceMaster;
        private System.Windows.Forms.BindingSource bindingSourceDetail;
        private System.Windows.Forms.SplitContainer splitContainerBottom;
        private System.Windows.Forms.DataGridView gridDetailDetail;
        private System.Windows.Forms.BindingSource bindingSourceDetailDetail;
    }
}