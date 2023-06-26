namespace EnterpriseSolutionBIDesktop
{
    partial class OptionForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnEventLogDelete = new System.Windows.Forms.Button();
            this.txtEventLog = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSaveEventLogRegister = new System.Windows.Forms.Button();
            this.txtEventLogRegister = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbxCompanyCode1 = new System.Windows.Forms.ComboBox();
            this.cbxUserId1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnCreateShortcut = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnEventLogDelete);
            this.groupBox1.Controls.Add(this.txtEventLog);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(194, 82);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Event Log Deletion";
            // 
            // btnEventLogDelete
            // 
            this.btnEventLogDelete.Location = new System.Drawing.Point(107, 47);
            this.btnEventLogDelete.Name = "btnEventLogDelete";
            this.btnEventLogDelete.Size = new System.Drawing.Size(75, 23);
            this.btnEventLogDelete.TabIndex = 2;
            this.btnEventLogDelete.Text = "Delete";
            this.btnEventLogDelete.UseVisualStyleBackColor = true;
            this.btnEventLogDelete.Click += new System.EventHandler(this.btnEventLogDelete_Click);
            // 
            // txtEventLog
            // 
            this.txtEventLog.Location = new System.Drawing.Point(82, 22);
            this.txtEventLog.Name = "txtEventLog";
            this.txtEventLog.Size = new System.Drawing.Size(100, 20);
            this.txtEventLog.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Event Log:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSaveEventLogRegister);
            this.groupBox2.Controls.Add(this.txtEventLogRegister);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(12, 118);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(194, 82);
            this.groupBox2.TabIndex = 27;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Event Log Register";
            // 
            // btnSaveEventLogRegister
            // 
            this.btnSaveEventLogRegister.Location = new System.Drawing.Point(107, 47);
            this.btnSaveEventLogRegister.Name = "btnSaveEventLogRegister";
            this.btnSaveEventLogRegister.Size = new System.Drawing.Size(75, 23);
            this.btnSaveEventLogRegister.TabIndex = 2;
            this.btnSaveEventLogRegister.Text = "Save";
            this.btnSaveEventLogRegister.UseVisualStyleBackColor = true;
            this.btnSaveEventLogRegister.Click += new System.EventHandler(this.btnSaveEventLogRegister_Click);
            // 
            // txtEventLogRegister
            // 
            this.txtEventLogRegister.Location = new System.Drawing.Point(82, 22);
            this.txtEventLogRegister.Name = "txtEventLogRegister";
            this.txtEventLogRegister.Size = new System.Drawing.Size(100, 20);
            this.txtEventLogRegister.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Event Log:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbxCompanyCode1);
            this.groupBox3.Controls.Add(this.cbxUserId1);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.btnCreateShortcut);
            this.groupBox3.Location = new System.Drawing.Point(12, 214);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(194, 106);
            this.groupBox3.TabIndex = 29;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Shortcut Creator";
            // 
            // cbxCompanyCode1
            // 
            this.cbxCompanyCode1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCompanyCode1.FormattingEnabled = true;
            this.cbxCompanyCode1.Location = new System.Drawing.Point(82, 46);
            this.cbxCompanyCode1.Name = "cbxCompanyCode1";
            this.cbxCompanyCode1.Size = new System.Drawing.Size(100, 21);
            this.cbxCompanyCode1.TabIndex = 21;
            // 
            // cbxUserId1
            // 
            this.cbxUserId1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxUserId1.FormattingEnabled = true;
            this.cbxUserId1.Location = new System.Drawing.Point(82, 19);
            this.cbxUserId1.Name = "cbxUserId1";
            this.cbxUserId1.Size = new System.Drawing.Size(100, 21);
            this.cbxUserId1.TabIndex = 20;
            this.cbxUserId1.SelectedIndexChanged += new System.EventHandler(this.cbxUserId1_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Company";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "User Id:";
            // 
            // btnCreateShortcut
            // 
            this.btnCreateShortcut.Location = new System.Drawing.Point(107, 73);
            this.btnCreateShortcut.Name = "btnCreateShortcut";
            this.btnCreateShortcut.Size = new System.Drawing.Size(75, 23);
            this.btnCreateShortcut.TabIndex = 2;
            this.btnCreateShortcut.Text = "Save";
            this.btnCreateShortcut.UseVisualStyleBackColor = true;
            this.btnCreateShortcut.Click += new System.EventHandler(this.btnCreateShortcut_Click);
            // 
            // OptionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 597);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.Name = "OptionForm";
            this.Text = "Options";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnEventLogDelete;
        private System.Windows.Forms.TextBox txtEventLog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSaveEventLogRegister;
        private System.Windows.Forms.TextBox txtEventLogRegister;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnCreateShortcut;
        private System.Windows.Forms.ComboBox cbxCompanyCode1;
        private System.Windows.Forms.ComboBox cbxUserId1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}