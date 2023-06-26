
using System.Windows.Forms;
using System.Drawing;

namespace EnterpriseSolutionBIDesktop
{
    partial class ErrorDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ErrorDialog));
            this.btnShowDetails = new System.Windows.Forms.Button();
            this.btnCopytoClipboard = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.lblException = new System.Windows.Forms.TextBox();
            this.ErrorrichText = new System.Windows.Forms.TextBox();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // btnShowDetails
            // 
            this.btnShowDetails.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnShowDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowDetails.Location = new System.Drawing.Point(15, 108);
            this.btnShowDetails.Name = "btnShowDetails";
            this.btnShowDetails.Size = new System.Drawing.Size(100, 29);
            this.btnShowDetails.TabIndex = 1;
            this.btnShowDetails.Text = "Show Details";
            this.btnShowDetails.UseVisualStyleBackColor = false;
            this.btnShowDetails.Click += new System.EventHandler(this.btn显示详细资料_Click);
            // 
            // btnCopytoClipboard
            // 
            this.btnCopytoClipboard.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCopytoClipboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCopytoClipboard.Location = new System.Drawing.Point(121, 108);
            this.btnCopytoClipboard.Name = "btnCopytoClipboard";
            this.btnCopytoClipboard.Size = new System.Drawing.Size(124, 29);
            this.btnCopytoClipboard.TabIndex = 2;
            this.btnCopytoClipboard.Text = "Copy to Clipboard";
            this.btnCopytoClipboard.UseVisualStyleBackColor = false;
            this.btnCopytoClipboard.Visible = false;
            this.btnCopytoClipboard.Click += new System.EventHandler(this.btn复制到剪切板_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(403, 108);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 29);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btn确定_Click);
            // 
            // lblException
            // 
            this.lblException.AcceptsReturn = true;
            this.lblException.BackColor = System.Drawing.SystemColors.Control;
            this.lblException.Font = new System.Drawing.Font("SimSun", 9F);
            this.lblException.Location = new System.Drawing.Point(80, 12);
            this.lblException.Multiline = true;
            this.lblException.Name = "lblException";
            this.lblException.ReadOnly = true;
            this.lblException.Size = new System.Drawing.Size(427, 90);
            this.lblException.TabIndex = 4;
            // 
            // ErrorrichText
            // 
            this.ErrorrichText.AcceptsReturn = true;
            this.ErrorrichText.Font = new System.Drawing.Font("SimSun", 9F);
            this.ErrorrichText.Location = new System.Drawing.Point(14, 161);
            this.ErrorrichText.Multiline = true;
            this.ErrorrichText.Name = "ErrorrichText";
            this.ErrorrichText.ReadOnly = true;
            this.ErrorrichText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ErrorrichText.Size = new System.Drawing.Size(493, 224);
            this.ErrorrichText.TabIndex = 3;
            this.ErrorrichText.Text = "textEditor1";
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox.Image")));
            this.pictureBox.Location = new System.Drawing.Point(15, 14);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(59, 61);
            this.pictureBox.TabIndex = 5;
            this.pictureBox.TabStop = false;
            // 
            // ErrorDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 154);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.lblException);
            this.Controls.Add(this.ErrorrichText);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCopytoClipboard);
            this.Controls.Add(this.btnShowDetails);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(430, 182);
            this.Name = "ErrorDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Error";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnShowDetails;
        private Button btnCopytoClipboard;
        private Button btnOK;
        private TextBox lblException;
        private TextBox ErrorrichText;
        private PictureBox pictureBox;
    }
}