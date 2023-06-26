using System.Windows.Forms;

namespace EnterpriseSolutionBIDesktop
{
    public partial class TabbedMdiManager
    {
        #region Methods

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CloseForm = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.HorizontalGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.VerticalGroupGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.MoveToFirstGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.MoveToNextTabGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.MoveToPreviousGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.MoveToLastGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.CloseAllFormButThis = new System.Windows.Forms.ToolStripMenuItem();
            this.CloseAllForm = new System.Windows.Forms.ToolStripMenuItem();
            this.ReOpenForm = new System.Windows.Forms.ToolStripMenuItem();
            this.CloseTabOnTheRight = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // ContextMenuStrip
            // 
            this.ContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CloseForm,
            this.toolStripMenuItem1,
            this.HorizontalGroup,
            this.VerticalGroupGroup,
            this.toolStripMenuItem2,
            this.MoveToFirstGroup,
            this.MoveToNextTabGroup,
            this.MoveToPreviousGroup,
            this.MoveToLastGroup,
            this.toolStripMenuItem3,
            this.CloseAllFormButThis,
            this.CloseTabOnTheRight,
            this.CloseAllForm,
            this.ReOpenForm});
            this.ContextMenuStrip.Name = "contextMenuStrip";
            this.ContextMenuStrip.Size = new System.Drawing.Size(208, 264);
            this.ContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.ContextMenuStrip_Opening);
            // 
            // CloseForm
            // 
            this.CloseForm.Name = "CloseForm";
            this.CloseForm.Size = new System.Drawing.Size(207, 22);
            this.CloseForm.Text = "Close Focus Form";
            this.CloseForm.Click += new System.EventHandler(this.OnCloseTabForm);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(204, 6);
            // 
            // HorizontalGroup
            // 
            this.HorizontalGroup.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.HorizontalGroup.Name = "HorizontalGroup";
            this.HorizontalGroup.Size = new System.Drawing.Size(207, 22);
            this.HorizontalGroup.Text = "Horizontal Group";
            this.HorizontalGroup.Click += new System.EventHandler(this.HorizontalGroup_Click);
            // 
            // VerticalGroupGroup
            // 
            this.VerticalGroupGroup.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.VerticalGroupGroup.Name = "VerticalGroupGroup";
            this.VerticalGroupGroup.Size = new System.Drawing.Size(207, 22);
            this.VerticalGroupGroup.Text = "Vertical Group";
            this.VerticalGroupGroup.Click += new System.EventHandler(this.VerticalGroupGroup_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(204, 6);
            // 
            // MoveToFirstGroup
            // 
            this.MoveToFirstGroup.Name = "MoveToFirstGroup";
            this.MoveToFirstGroup.Size = new System.Drawing.Size(207, 22);
            this.MoveToFirstGroup.Text = "Move To First Group";
            this.MoveToFirstGroup.Click += new System.EventHandler(this.MoveToFirstGroup_Click);
            // 
            // MoveToNextTabGroup
            // 
            this.MoveToNextTabGroup.Name = "MoveToNextTabGroup";
            this.MoveToNextTabGroup.Size = new System.Drawing.Size(207, 22);
            this.MoveToNextTabGroup.Text = "Move To Next Tab Group";
            this.MoveToNextTabGroup.Click += new System.EventHandler(this.MoveToNextTabGroup_Click);
            // 
            // MoveToPreviousGroup
            // 
            this.MoveToPreviousGroup.Name = "MoveToPreviousGroup";
            this.MoveToPreviousGroup.Size = new System.Drawing.Size(207, 22);
            this.MoveToPreviousGroup.Text = "Move To Previous Group";
            this.MoveToPreviousGroup.Click += new System.EventHandler(this.MoveToPreviousGroup_Click);
            // 
            // MoveToLastGroup
            // 
            this.MoveToLastGroup.Name = "MoveToLastGroup";
            this.MoveToLastGroup.Size = new System.Drawing.Size(207, 22);
            this.MoveToLastGroup.Text = "Move To Last Group";
            this.MoveToLastGroup.Click += new System.EventHandler(this.MoveToLastGroup_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(204, 6);
            // 
            // CloseAllFormButThis
            // 
            this.CloseAllFormButThis.Name = "CloseAllFormButThis";
            this.CloseAllFormButThis.Size = new System.Drawing.Size(207, 22);
            this.CloseAllFormButThis.Text = "Close All Form But This";
            this.CloseAllFormButThis.Click += new System.EventHandler(this.CloseAllFormButThis_Click);
            // 
            // CloseAllForm
            // 
            this.CloseAllForm.Name = "CloseAllForm";
            this.CloseAllForm.Size = new System.Drawing.Size(207, 22);
            this.CloseAllForm.Text = "Close All Form";
            this.CloseAllForm.Click += new System.EventHandler(this.CloseAllForm_Click);
            // 
            // ReOpenForm
            // 
            this.ReOpenForm.Name = "ReOpenForm";
            this.ReOpenForm.Size = new System.Drawing.Size(207, 22);
            this.ReOpenForm.Text = "ReOpen Function";
            this.ReOpenForm.Click += new System.EventHandler(this.ReOpenForm_Click);
            // 
            // CloseTabOnTheRight
            // 
            this.CloseTabOnTheRight.Name = "CloseTabOnTheRight";
            this.CloseTabOnTheRight.Size = new System.Drawing.Size(207, 22);
            this.CloseTabOnTheRight.Text = "Close Tabs To The Right";
            this.CloseTabOnTheRight.Click += new System.EventHandler(this.CloseTabOnTheRight_Click);
            this.ContextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion Methods

        private System.ComponentModel.IContainer components;
        private ToolStripMenuItem CloseTabOnTheRight;
    }
}