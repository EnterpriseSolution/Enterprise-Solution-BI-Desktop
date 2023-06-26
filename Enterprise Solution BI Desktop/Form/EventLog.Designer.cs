namespace EnterpriseSolutionBIDesktop
{
    partial class EventLogDialog
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
            this.eventLogViewer = new EnterpriseSolutionBIDesktop.EventLogViewer();
            this.SuspendLayout();
            // 
            // eventLogViewer
            // 
            this.eventLogViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.eventLogViewer.IsCategoryVisible = true;
            this.eventLogViewer.IsEventIDVisible = true;
            this.eventLogViewer.IsSourceVisible = true;
            this.eventLogViewer.Location = new System.Drawing.Point(12, 12);
            this.eventLogViewer.Log = "Application";
            this.eventLogViewer.Name = "eventLogViewer";
            this.eventLogViewer.Size = new System.Drawing.Size(697, 407);
            this.eventLogViewer.TabIndex = 0;
            // 
            // EventLogDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 431);
            this.Controls.Add(this.eventLogViewer);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EventLogDialog";
            this.Text = "Event Log Viewer";
            this.ResumeLayout(false);

        }

        #endregion

        private EventLogViewer eventLogViewer;
    }
}