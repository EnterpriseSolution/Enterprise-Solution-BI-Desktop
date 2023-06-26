namespace EnterpriseSolutionBIDesktop
{
    partial class CompanyTableForm
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
            this.bindingSourceMaster = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSourceDetail = new System.Windows.Forms.BindingSource(this.components);
            this.gridOverview = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridOverview)).BeginInit();
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
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.gridOverview);
            this.splitContainer.Size = new System.Drawing.Size(981, 659);
            this.splitContainer.SplitterDistance = 318;
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
            this.gridMaster.Size = new System.Drawing.Size(981, 318);
            this.gridMaster.TabIndex = 0;
            // 
            // gridOverview
            // 
            this.gridOverview.AutoGenerateColumns = false;
            this.gridOverview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridOverview.DataSource = this.bindingSourceMaster;
            this.gridOverview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridOverview.Location = new System.Drawing.Point(0, 0);
            this.gridOverview.Name = "gridOverview";
            this.gridOverview.RowTemplate.Height = 23;
            this.gridOverview.Size = new System.Drawing.Size(981, 337);
            this.gridOverview.TabIndex = 1;
            // 
            // CompanyMasterTableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1005, 685);
            this.Controls.Add(this.splitContainer);
            this.Name = "CompanyMasterTableForm";
            this.Padding = new System.Windows.Forms.Padding(12, 13, 12, 13);
            this.Text = "Master/Detail ";
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridOverview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.DataGridView gridMaster;
        private System.Windows.Forms.BindingSource bindingSourceMaster;
        private System.Windows.Forms.BindingSource bindingSourceDetail;
        private System.Windows.Forms.DataGridView gridOverview;
    }
}