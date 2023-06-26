namespace EnterpriseSolutionBIDesktop
{
    partial class MasterDetailABForm
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
            this.splitContainerBottom = new System.Windows.Forms.SplitContainer();
            this.bindingSourceDetail = new System.Windows.Forms.BindingSource(this.components);
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageA = new System.Windows.Forms.TabPage();
            this.gridDetailDetailA = new System.Windows.Forms.DataGridView();
            this.tabPageB = new System.Windows.Forms.TabPage();
            this.gridDetailDetailB = new System.Windows.Forms.DataGridView();
            this.bindingSourceDetailB = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSourceDetailA = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerBottom)).BeginInit();
            this.splitContainerBottom.Panel2.SuspendLayout();
            this.splitContainerBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDetail)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabPageA.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDetailDetailA)).BeginInit();
            this.tabPageB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDetailDetailB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDetailB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDetailA)).BeginInit();
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
            this.splitContainer.SplitterDistance = 285;
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
            this.gridMaster.Size = new System.Drawing.Size(981, 285);
            this.gridMaster.TabIndex = 0;
            // 
            // splitContainerBottom
            // 
            this.splitContainerBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerBottom.Location = new System.Drawing.Point(0, 0);
            this.splitContainerBottom.Name = "splitContainerBottom";
            this.splitContainerBottom.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.splitContainerBottom.Panel1Collapsed = true;
            // 
            // splitContainerBottom.Panel2
            // 
            this.splitContainerBottom.Panel2.Controls.Add(this.tabControl);
            this.splitContainerBottom.Size = new System.Drawing.Size(981, 319);
            this.splitContainerBottom.SplitterDistance = 213;
            this.splitContainerBottom.TabIndex = 1;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageA);
            this.tabControl.Controls.Add(this.tabPageB);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(981, 319);
            this.tabControl.TabIndex = 1;
            // 
            // tabPageA
            // 
            this.tabPageA.Controls.Add(this.gridDetailDetailA);
            this.tabPageA.Location = new System.Drawing.Point(4, 22);
            this.tabPageA.Name = "tabPageA";
            this.tabPageA.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageA.Size = new System.Drawing.Size(973, 401);
            this.tabPageA.TabIndex = 0;
            this.tabPageA.Text = "A";
            this.tabPageA.UseVisualStyleBackColor = true;
            // 
            // gridDetailDetailA
            // 
            this.gridDetailDetailA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridDetailDetailA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridDetailDetailA.Location = new System.Drawing.Point(3, 3);
            this.gridDetailDetailA.Name = "gridDetailDetailA";
            this.gridDetailDetailA.RowTemplate.Height = 23;
            this.gridDetailDetailA.Size = new System.Drawing.Size(967, 395);
            this.gridDetailDetailA.TabIndex = 0;
            // 
            // tabPageB
            // 
            this.tabPageB.Controls.Add(this.gridDetailDetailB);
            this.tabPageB.Location = new System.Drawing.Point(4, 22);
            this.tabPageB.Name = "tabPageB";
            this.tabPageB.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageB.Size = new System.Drawing.Size(973, 293);
            this.tabPageB.TabIndex = 1;
            this.tabPageB.Text = "B";
            this.tabPageB.UseVisualStyleBackColor = true;
            // 
            // gridDetailDetailB
            // 
            this.gridDetailDetailB.AutoGenerateColumns = false;
            this.gridDetailDetailB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridDetailDetailB.DataSource = this.bindingSourceDetailB;
            this.gridDetailDetailB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridDetailDetailB.Location = new System.Drawing.Point(3, 3);
            this.gridDetailDetailB.Name = "gridDetailDetailB";
            this.gridDetailDetailB.RowTemplate.Height = 23;
            this.gridDetailDetailB.Size = new System.Drawing.Size(967, 287);
            this.gridDetailDetailB.TabIndex = 1;
            // 
            // MasterDetailABForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1005, 632);
            this.Controls.Add(this.splitContainer);
            this.Name = "MasterDetailABForm";
            this.Padding = new System.Windows.Forms.Padding(12);
            this.Text = "Master/Detail/Detail";
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceMaster)).EndInit();
            this.splitContainerBottom.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerBottom)).EndInit();
            this.splitContainerBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDetail)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabPageA.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridDetailDetailA)).EndInit();
            this.tabPageB.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridDetailDetailB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDetailB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDetailA)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.DataGridView gridMaster;
        private System.Windows.Forms.BindingSource bindingSourceMaster;
        private System.Windows.Forms.BindingSource bindingSourceDetail;
        private System.Windows.Forms.SplitContainer splitContainerBottom;
        private System.Windows.Forms.DataGridView gridDetailDetailA;
        private System.Windows.Forms.BindingSource bindingSourceDetailA;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageA;
        private System.Windows.Forms.TabPage tabPageB;
        private System.Windows.Forms.DataGridView gridDetailDetailB;
        private System.Windows.Forms.BindingSource bindingSourceDetailB;
    }
}