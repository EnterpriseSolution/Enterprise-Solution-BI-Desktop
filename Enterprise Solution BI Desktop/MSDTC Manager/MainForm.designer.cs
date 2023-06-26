namespace Demo
{
    partial class MainForm
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
            this.ctrlTabControl = new System.Windows.Forms.TabControl();
            this.tabService = new System.Windows.Forms.TabPage();
            this.btnRegMtxoci = new System.Windows.Forms.Button();
            this.btnUnistallService = new System.Windows.Forms.Button();
            this.btnIstallService = new System.Windows.Forms.Button();
            this.gbFirewall = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbFirewallProfileTypes = new System.Windows.Forms.ComboBox();
            this.btnDisableWindowsFirewallException = new System.Windows.Forms.Button();
            this.btnIsMsdtcRuleGroupEnabled = new System.Windows.Forms.Button();
            this.btnEnableWindowsFirewallException = new System.Windows.Forms.Button();
            this.btnRestartService = new System.Windows.Forms.Button();
            this.btnStopService = new System.Windows.Forms.Button();
            this.btnStartService = new System.Windows.Forms.Button();
            this.btnGetServiceInfo = new System.Windows.Forms.Button();
            this.btnGetServiceStatus = new System.Windows.Forms.Button();
            this.chbIsServiceInstalledAndRunning = new System.Windows.Forms.CheckBox();
            this.chbIsServiceInstalled = new System.Windows.Forms.CheckBox();
            this.tabProperties = new System.Windows.Forms.TabPage();
            this.gbDtcLogon = new System.Windows.Forms.GroupBox();
            this.btnChangeLogonAccount = new System.Windows.Forms.Button();
            this.lblConfirmPassword = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblAccount = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtAccount = new System.Windows.Forms.TextBox();
            this.gbFooter = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnResetDefault = new System.Windows.Forms.Button();
            this.gpSecurity = new System.Windows.Forms.GroupBox();
            this.chbEnableSnaLuTransactions = new System.Windows.Forms.CheckBox();
            this.chbEnableXaTransactions = new System.Windows.Forms.CheckBox();
            this.chbClientandAdministration = new System.Windows.Forms.GroupBox();
            this.chbAllowRemoteAdministration = new System.Windows.Forms.CheckBox();
            this.chbAllowRemoteClient = new System.Windows.Forms.CheckBox();
            this.gbTransactionManagerCommunication = new System.Windows.Forms.GroupBox();
            this.rbtnIncomingCallerAuthenticationRequired = new System.Windows.Forms.RadioButton();
            this.rbtnNoAuthenticationRequired = new System.Windows.Forms.RadioButton();
            this.rbtnMutualAuthenticationRequired = new System.Windows.Forms.RadioButton();
            this.chbAllowOutbound = new System.Windows.Forms.CheckBox();
            this.chbAllowInbound = new System.Windows.Forms.CheckBox();
            this.chbNetworkDtcAccess = new System.Windows.Forms.CheckBox();
            this.tabAbout = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ctrlTabControl.SuspendLayout();
            this.tabService.SuspendLayout();
            this.gbFirewall.SuspendLayout();
            this.tabProperties.SuspendLayout();
            this.gbDtcLogon.SuspendLayout();
            this.gbFooter.SuspendLayout();
            this.gpSecurity.SuspendLayout();
            this.chbClientandAdministration.SuspendLayout();
            this.gbTransactionManagerCommunication.SuspendLayout();
            this.tabAbout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ctrlTabControl
            // 
            this.ctrlTabControl.Controls.Add(this.tabService);
            this.ctrlTabControl.Controls.Add(this.tabProperties);
            this.ctrlTabControl.Controls.Add(this.tabAbout);
            this.ctrlTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlTabControl.Location = new System.Drawing.Point(0, 0);
            this.ctrlTabControl.Name = "ctrlTabControl";
            this.ctrlTabControl.SelectedIndex = 0;
            this.ctrlTabControl.Size = new System.Drawing.Size(367, 448);
            this.ctrlTabControl.TabIndex = 0;
            // 
            // tabService
            // 
            this.tabService.Controls.Add(this.btnRegMtxoci);
            this.tabService.Controls.Add(this.btnUnistallService);
            this.tabService.Controls.Add(this.btnIstallService);
            this.tabService.Controls.Add(this.gbFirewall);
            this.tabService.Controls.Add(this.btnRestartService);
            this.tabService.Controls.Add(this.btnStopService);
            this.tabService.Controls.Add(this.btnStartService);
            this.tabService.Controls.Add(this.btnGetServiceInfo);
            this.tabService.Controls.Add(this.btnGetServiceStatus);
            this.tabService.Controls.Add(this.chbIsServiceInstalledAndRunning);
            this.tabService.Controls.Add(this.chbIsServiceInstalled);
            this.tabService.Location = new System.Drawing.Point(4, 22);
            this.tabService.Name = "tabService";
            this.tabService.Padding = new System.Windows.Forms.Padding(3);
            this.tabService.Size = new System.Drawing.Size(359, 422);
            this.tabService.TabIndex = 0;
            this.tabService.Text = "Service";
            this.tabService.UseVisualStyleBackColor = true;
            // 
            // btnRegMtxoci
            // 
            this.btnRegMtxoci.Image = global::ConfigurationManager.Properties.Resources.document_execute;
            this.btnRegMtxoci.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRegMtxoci.Location = new System.Drawing.Point(21, 205);
            this.btnRegMtxoci.Name = "btnRegMtxoci";
            this.btnRegMtxoci.Size = new System.Drawing.Size(129, 38);
            this.btnRegMtxoci.TabIndex = 16;
            this.btnRegMtxoci.Text = "RegMtxoci";
            this.btnRegMtxoci.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRegMtxoci.UseVisualStyleBackColor = true;
            this.btnRegMtxoci.Click += new System.EventHandler(this.btnRegMtxoci_Click);
            // 
            // btnUnistallService
            // 
            this.btnUnistallService.Image = global::ConfigurationManager.Properties.Resources.gear_remove;
            this.btnUnistallService.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUnistallService.Location = new System.Drawing.Point(21, 162);
            this.btnUnistallService.Name = "btnUnistallService";
            this.btnUnistallService.Size = new System.Drawing.Size(129, 38);
            this.btnUnistallService.TabIndex = 15;
            this.btnUnistallService.Text = "UnistallService";
            this.btnUnistallService.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUnistallService.UseVisualStyleBackColor = true;
            this.btnUnistallService.Click += new System.EventHandler(this.btnUnistallService_Click);
            // 
            // btnIstallService
            // 
            this.btnIstallService.Image = global::ConfigurationManager.Properties.Resources.gear_add;
            this.btnIstallService.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIstallService.Location = new System.Drawing.Point(21, 119);
            this.btnIstallService.Name = "btnIstallService";
            this.btnIstallService.Size = new System.Drawing.Size(129, 38);
            this.btnIstallService.TabIndex = 14;
            this.btnIstallService.Text = "IstallService";
            this.btnIstallService.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnIstallService.UseVisualStyleBackColor = true;
            this.btnIstallService.Click += new System.EventHandler(this.btnIstallService_Click);
            // 
            // gbFirewall
            // 
            this.gbFirewall.Controls.Add(this.label1);
            this.gbFirewall.Controls.Add(this.cbFirewallProfileTypes);
            this.gbFirewall.Controls.Add(this.btnDisableWindowsFirewallException);
            this.gbFirewall.Controls.Add(this.btnIsMsdtcRuleGroupEnabled);
            this.gbFirewall.Controls.Add(this.btnEnableWindowsFirewallException);
            this.gbFirewall.Location = new System.Drawing.Point(4, 248);
            this.gbFirewall.Name = "gbFirewall";
            this.gbFirewall.Size = new System.Drawing.Size(352, 172);
            this.gbFirewall.TabIndex = 13;
            this.gbFirewall.TabStop = false;
            this.gbFirewall.Text = "Firewall";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 12);
            this.label1.TabIndex = 13;
            this.label1.Text = "Type of profile:";
            // 
            // cbFirewallProfileTypes
            // 
            this.cbFirewallProfileTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFirewallProfileTypes.FormattingEnabled = true;
            this.cbFirewallProfileTypes.Items.AddRange(new object[] {
            "ALL",
            "DOMAIN",
            "PRIVATE",
            "PUBLIC"});
            this.cbFirewallProfileTypes.Location = new System.Drawing.Point(155, 17);
            this.cbFirewallProfileTypes.Name = "cbFirewallProfileTypes";
            this.cbFirewallProfileTypes.Size = new System.Drawing.Size(164, 20);
            this.cbFirewallProfileTypes.TabIndex = 12;
            // 
            // btnDisableWindowsFirewallException
            // 
            this.btnDisableWindowsFirewallException.Image = global::ConfigurationManager.Properties.Resources.firewall_delete2_32;
            this.btnDisableWindowsFirewallException.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDisableWindowsFirewallException.Location = new System.Drawing.Point(51, 127);
            this.btnDisableWindowsFirewallException.Name = "btnDisableWindowsFirewallException";
            this.btnDisableWindowsFirewallException.Size = new System.Drawing.Size(252, 37);
            this.btnDisableWindowsFirewallException.TabIndex = 10;
            this.btnDisableWindowsFirewallException.Text = "DisableWindowsFirewallException";
            this.btnDisableWindowsFirewallException.UseVisualStyleBackColor = true;
            this.btnDisableWindowsFirewallException.Click += new System.EventHandler(this.btnDisableWindowsFirewallException_Click);
            // 
            // btnIsMsdtcRuleGroupEnabled
            // 
            this.btnIsMsdtcRuleGroupEnabled.Image = global::ConfigurationManager.Properties.Resources.firewall_info_32;
            this.btnIsMsdtcRuleGroupEnabled.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIsMsdtcRuleGroupEnabled.Location = new System.Drawing.Point(51, 42);
            this.btnIsMsdtcRuleGroupEnabled.Name = "btnIsMsdtcRuleGroupEnabled";
            this.btnIsMsdtcRuleGroupEnabled.Size = new System.Drawing.Size(252, 37);
            this.btnIsMsdtcRuleGroupEnabled.TabIndex = 11;
            this.btnIsMsdtcRuleGroupEnabled.Text = "IsMsdtcRuleGroupEnabled";
            this.btnIsMsdtcRuleGroupEnabled.UseVisualStyleBackColor = true;
            this.btnIsMsdtcRuleGroupEnabled.Click += new System.EventHandler(this.btnIsMsdtcRuleGroupEnabled_Click);
            // 
            // btnEnableWindowsFirewallException
            // 
            this.btnEnableWindowsFirewallException.Image = global::ConfigurationManager.Properties.Resources.firewall_ok_32;
            this.btnEnableWindowsFirewallException.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEnableWindowsFirewallException.Location = new System.Drawing.Point(51, 85);
            this.btnEnableWindowsFirewallException.Name = "btnEnableWindowsFirewallException";
            this.btnEnableWindowsFirewallException.Size = new System.Drawing.Size(252, 37);
            this.btnEnableWindowsFirewallException.TabIndex = 9;
            this.btnEnableWindowsFirewallException.Text = "EnableWindowsFirewallException";
            this.btnEnableWindowsFirewallException.UseVisualStyleBackColor = true;
            this.btnEnableWindowsFirewallException.Click += new System.EventHandler(this.btnEnableWindowsFirewallException_Click);
            // 
            // btnRestartService
            // 
            this.btnRestartService.Image = global::ConfigurationManager.Properties.Resources.button_blue_repeat;
            this.btnRestartService.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRestartService.Location = new System.Drawing.Point(213, 119);
            this.btnRestartService.Name = "btnRestartService";
            this.btnRestartService.Size = new System.Drawing.Size(129, 38);
            this.btnRestartService.TabIndex = 8;
            this.btnRestartService.Text = "RestartService";
            this.btnRestartService.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRestartService.UseVisualStyleBackColor = true;
            this.btnRestartService.Click += new System.EventHandler(this.btnRestartService_Click);
            // 
            // btnStopService
            // 
            this.btnStopService.Image = global::ConfigurationManager.Properties.Resources.button_blue_stop;
            this.btnStopService.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStopService.Location = new System.Drawing.Point(213, 32);
            this.btnStopService.Name = "btnStopService";
            this.btnStopService.Size = new System.Drawing.Size(129, 38);
            this.btnStopService.TabIndex = 5;
            this.btnStopService.Text = "StopService";
            this.btnStopService.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnStopService.UseVisualStyleBackColor = true;
            this.btnStopService.Click += new System.EventHandler(this.btnStopService_Click);
            // 
            // btnStartService
            // 
            this.btnStartService.Image = global::ConfigurationManager.Properties.Resources.button_blue_play;
            this.btnStartService.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStartService.Location = new System.Drawing.Point(213, 76);
            this.btnStartService.Name = "btnStartService";
            this.btnStartService.Size = new System.Drawing.Size(129, 38);
            this.btnStartService.TabIndex = 4;
            this.btnStartService.Text = "StartService";
            this.btnStartService.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnStartService.UseVisualStyleBackColor = true;
            this.btnStartService.Click += new System.EventHandler(this.btnStartService_Click);
            // 
            // btnGetServiceInfo
            // 
            this.btnGetServiceInfo.Image = global::ConfigurationManager.Properties.Resources.info_32;
            this.btnGetServiceInfo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGetServiceInfo.Location = new System.Drawing.Point(21, 32);
            this.btnGetServiceInfo.Name = "btnGetServiceInfo";
            this.btnGetServiceInfo.Size = new System.Drawing.Size(129, 38);
            this.btnGetServiceInfo.TabIndex = 3;
            this.btnGetServiceInfo.Text = "GetServiceInfo";
            this.btnGetServiceInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGetServiceInfo.UseVisualStyleBackColor = true;
            this.btnGetServiceInfo.Click += new System.EventHandler(this.btnGetServiceInfo_Click);
            // 
            // btnGetServiceStatus
            // 
            this.btnGetServiceStatus.Image = global::ConfigurationManager.Properties.Resources.gear_info_32;
            this.btnGetServiceStatus.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGetServiceStatus.Location = new System.Drawing.Point(21, 76);
            this.btnGetServiceStatus.Name = "btnGetServiceStatus";
            this.btnGetServiceStatus.Size = new System.Drawing.Size(129, 38);
            this.btnGetServiceStatus.TabIndex = 2;
            this.btnGetServiceStatus.Text = "GetServiceStatus";
            this.btnGetServiceStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGetServiceStatus.UseVisualStyleBackColor = true;
            this.btnGetServiceStatus.Click += new System.EventHandler(this.btnGetServiceStatus_Click);
            // 
            // chbIsServiceInstalledAndRunning
            // 
            this.chbIsServiceInstalledAndRunning.AutoSize = true;
            this.chbIsServiceInstalledAndRunning.Enabled = false;
            this.chbIsServiceInstalledAndRunning.Location = new System.Drawing.Point(168, 10);
            this.chbIsServiceInstalledAndRunning.Name = "chbIsServiceInstalledAndRunning";
            this.chbIsServiceInstalledAndRunning.Size = new System.Drawing.Size(216, 16);
            this.chbIsServiceInstalledAndRunning.TabIndex = 1;
            this.chbIsServiceInstalledAndRunning.Text = "Is Service Installed And Running";
            this.chbIsServiceInstalledAndRunning.UseVisualStyleBackColor = true;
            // 
            // chbIsServiceInstalled
            // 
            this.chbIsServiceInstalled.AutoSize = true;
            this.chbIsServiceInstalled.Enabled = false;
            this.chbIsServiceInstalled.Location = new System.Drawing.Point(21, 10);
            this.chbIsServiceInstalled.Name = "chbIsServiceInstalled";
            this.chbIsServiceInstalled.Size = new System.Drawing.Size(144, 16);
            this.chbIsServiceInstalled.TabIndex = 0;
            this.chbIsServiceInstalled.Text = "Is Service Installed";
            this.chbIsServiceInstalled.UseVisualStyleBackColor = true;
            // 
            // tabProperties
            // 
            this.tabProperties.Controls.Add(this.gbDtcLogon);
            this.tabProperties.Controls.Add(this.gbFooter);
            this.tabProperties.Controls.Add(this.gpSecurity);
            this.tabProperties.Location = new System.Drawing.Point(4, 22);
            this.tabProperties.Name = "tabProperties";
            this.tabProperties.Padding = new System.Windows.Forms.Padding(3);
            this.tabProperties.Size = new System.Drawing.Size(359, 422);
            this.tabProperties.TabIndex = 1;
            this.tabProperties.Text = "Properties";
            this.tabProperties.UseVisualStyleBackColor = true;
            // 
            // gbDtcLogon
            // 
            this.gbDtcLogon.Controls.Add(this.btnChangeLogonAccount);
            this.gbDtcLogon.Controls.Add(this.lblConfirmPassword);
            this.gbDtcLogon.Controls.Add(this.lblPassword);
            this.gbDtcLogon.Controls.Add(this.lblAccount);
            this.gbDtcLogon.Controls.Add(this.textBox3);
            this.gbDtcLogon.Controls.Add(this.txtPassword);
            this.gbDtcLogon.Controls.Add(this.txtAccount);
            this.gbDtcLogon.Location = new System.Drawing.Point(7, 222);
            this.gbDtcLogon.Name = "gbDtcLogon";
            this.gbDtcLogon.Size = new System.Drawing.Size(346, 148);
            this.gbDtcLogon.TabIndex = 2;
            this.gbDtcLogon.TabStop = false;
            this.gbDtcLogon.Text = "DTC Logon Account";
            // 
            // btnChangeLogonAccount
            // 
            this.btnChangeLogonAccount.Location = new System.Drawing.Point(163, 91);
            this.btnChangeLogonAccount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnChangeLogonAccount.Name = "btnChangeLogonAccount";
            this.btnChangeLogonAccount.Size = new System.Drawing.Size(131, 26);
            this.btnChangeLogonAccount.TabIndex = 6;
            this.btnChangeLogonAccount.Text = "ChangeLogonAccount";
            this.btnChangeLogonAccount.UseVisualStyleBackColor = true;
            this.btnChangeLogonAccount.Click += new System.EventHandler(this.btnChangeLogonAccount_Click);
            // 
            // lblConfirmPassword
            // 
            this.lblConfirmPassword.AutoSize = true;
            this.lblConfirmPassword.Location = new System.Drawing.Point(12, 71);
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.Size = new System.Drawing.Size(107, 12);
            this.lblConfirmPassword.TabIndex = 5;
            this.lblConfirmPassword.Text = "Confirm Password:";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(12, 47);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(59, 12);
            this.lblPassword.TabIndex = 4;
            this.lblPassword.Text = "Password:";
            // 
            // lblAccount
            // 
            this.lblAccount.AutoSize = true;
            this.lblAccount.Location = new System.Drawing.Point(12, 23);
            this.lblAccount.Name = "lblAccount";
            this.lblAccount.Size = new System.Drawing.Size(53, 12);
            this.lblAccount.TabIndex = 3;
            this.lblAccount.Text = "Account:";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(124, 68);
            this.textBox3.Name = "textBox3";
            this.textBox3.PasswordChar = '*';
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(170, 21);
            this.textBox3.TabIndex = 2;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(124, 44);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(170, 21);
            this.txtPassword.TabIndex = 1;
            // 
            // txtAccount
            // 
            this.txtAccount.Location = new System.Drawing.Point(124, 20);
            this.txtAccount.Name = "txtAccount";
            this.txtAccount.Size = new System.Drawing.Size(170, 21);
            this.txtAccount.TabIndex = 0;
            // 
            // gbFooter
            // 
            this.gbFooter.Controls.Add(this.btnSave);
            this.gbFooter.Controls.Add(this.btnLoad);
            this.gbFooter.Controls.Add(this.btnResetDefault);
            this.gbFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbFooter.Location = new System.Drawing.Point(3, 372);
            this.gbFooter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbFooter.Name = "gbFooter";
            this.gbFooter.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbFooter.Size = new System.Drawing.Size(353, 47);
            this.gbFooter.TabIndex = 1;
            this.gbFooter.TabStop = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(121, 18);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(107, 26);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(4, 18);
            this.btnLoad.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(107, 26);
            this.btnLoad.TabIndex = 4;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnResetDefault
            // 
            this.btnResetDefault.Location = new System.Drawing.Point(238, 18);
            this.btnResetDefault.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnResetDefault.Name = "btnResetDefault";
            this.btnResetDefault.Size = new System.Drawing.Size(107, 26);
            this.btnResetDefault.TabIndex = 3;
            this.btnResetDefault.Text = "Reset To Default";
            this.btnResetDefault.UseVisualStyleBackColor = true;
            this.btnResetDefault.Click += new System.EventHandler(this.btnResetDefault_Click);
            // 
            // gpSecurity
            // 
            this.gpSecurity.Controls.Add(this.chbEnableSnaLuTransactions);
            this.gpSecurity.Controls.Add(this.chbEnableXaTransactions);
            this.gpSecurity.Controls.Add(this.chbClientandAdministration);
            this.gpSecurity.Controls.Add(this.gbTransactionManagerCommunication);
            this.gpSecurity.Controls.Add(this.chbNetworkDtcAccess);
            this.gpSecurity.Location = new System.Drawing.Point(7, 6);
            this.gpSecurity.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gpSecurity.Name = "gpSecurity";
            this.gpSecurity.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gpSecurity.Size = new System.Drawing.Size(346, 211);
            this.gpSecurity.TabIndex = 0;
            this.gpSecurity.TabStop = false;
            this.gpSecurity.Text = "Security Settings";
            // 
            // chbEnableSnaLuTransactions
            // 
            this.chbEnableSnaLuTransactions.AutoSize = true;
            this.chbEnableSnaLuTransactions.Location = new System.Drawing.Point(163, 192);
            this.chbEnableSnaLuTransactions.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chbEnableSnaLuTransactions.Name = "chbEnableSnaLuTransactions";
            this.chbEnableSnaLuTransactions.Size = new System.Drawing.Size(204, 16);
            this.chbEnableSnaLuTransactions.TabIndex = 9;
            this.chbEnableSnaLuTransactions.Text = "Enable SNA LU 6.2 Transactions";
            this.chbEnableSnaLuTransactions.UseVisualStyleBackColor = true;
            // 
            // chbEnableXaTransactions
            // 
            this.chbEnableXaTransactions.AutoSize = true;
            this.chbEnableXaTransactions.Location = new System.Drawing.Point(5, 192);
            this.chbEnableXaTransactions.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chbEnableXaTransactions.Name = "chbEnableXaTransactions";
            this.chbEnableXaTransactions.Size = new System.Drawing.Size(156, 16);
            this.chbEnableXaTransactions.TabIndex = 8;
            this.chbEnableXaTransactions.Text = "Enable XA Transactions";
            this.chbEnableXaTransactions.UseVisualStyleBackColor = true;
            // 
            // chbClientandAdministration
            // 
            this.chbClientandAdministration.Controls.Add(this.chbAllowRemoteAdministration);
            this.chbClientandAdministration.Controls.Add(this.chbAllowRemoteClient);
            this.chbClientandAdministration.Location = new System.Drawing.Point(5, 39);
            this.chbClientandAdministration.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chbClientandAdministration.Name = "chbClientandAdministration";
            this.chbClientandAdministration.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chbClientandAdministration.Size = new System.Drawing.Size(336, 38);
            this.chbClientandAdministration.TabIndex = 2;
            this.chbClientandAdministration.TabStop = false;
            this.chbClientandAdministration.Text = "Client and Administration";
            // 
            // chbAllowRemoteAdministration
            // 
            this.chbAllowRemoteAdministration.AutoSize = true;
            this.chbAllowRemoteAdministration.Location = new System.Drawing.Point(158, 18);
            this.chbAllowRemoteAdministration.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chbAllowRemoteAdministration.Name = "chbAllowRemoteAdministration";
            this.chbAllowRemoteAdministration.Size = new System.Drawing.Size(186, 16);
            this.chbAllowRemoteAdministration.TabIndex = 3;
            this.chbAllowRemoteAdministration.Text = "Allow Remote Administration";
            this.chbAllowRemoteAdministration.UseVisualStyleBackColor = true;
            // 
            // chbAllowRemoteClient
            // 
            this.chbAllowRemoteClient.AutoSize = true;
            this.chbAllowRemoteClient.Location = new System.Drawing.Point(10, 18);
            this.chbAllowRemoteClient.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chbAllowRemoteClient.Name = "chbAllowRemoteClient";
            this.chbAllowRemoteClient.Size = new System.Drawing.Size(138, 16);
            this.chbAllowRemoteClient.TabIndex = 4;
            this.chbAllowRemoteClient.Text = "Allow Remote Client";
            this.chbAllowRemoteClient.UseVisualStyleBackColor = true;
            // 
            // gbTransactionManagerCommunication
            // 
            this.gbTransactionManagerCommunication.Controls.Add(this.rbtnIncomingCallerAuthenticationRequired);
            this.gbTransactionManagerCommunication.Controls.Add(this.rbtnNoAuthenticationRequired);
            this.gbTransactionManagerCommunication.Controls.Add(this.rbtnMutualAuthenticationRequired);
            this.gbTransactionManagerCommunication.Controls.Add(this.chbAllowOutbound);
            this.gbTransactionManagerCommunication.Controls.Add(this.chbAllowInbound);
            this.gbTransactionManagerCommunication.Location = new System.Drawing.Point(5, 82);
            this.gbTransactionManagerCommunication.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbTransactionManagerCommunication.Name = "gbTransactionManagerCommunication";
            this.gbTransactionManagerCommunication.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbTransactionManagerCommunication.Size = new System.Drawing.Size(336, 106);
            this.gbTransactionManagerCommunication.TabIndex = 1;
            this.gbTransactionManagerCommunication.TabStop = false;
            this.gbTransactionManagerCommunication.Text = "Transaction Manager Communication";
            // 
            // rbtnIncomingCallerAuthenticationRequired
            // 
            this.rbtnIncomingCallerAuthenticationRequired.AutoSize = true;
            this.rbtnIncomingCallerAuthenticationRequired.Location = new System.Drawing.Point(31, 58);
            this.rbtnIncomingCallerAuthenticationRequired.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbtnIncomingCallerAuthenticationRequired.Name = "rbtnIncomingCallerAuthenticationRequired";
            this.rbtnIncomingCallerAuthenticationRequired.Size = new System.Drawing.Size(257, 16);
            this.rbtnIncomingCallerAuthenticationRequired.TabIndex = 7;
            this.rbtnIncomingCallerAuthenticationRequired.TabStop = true;
            this.rbtnIncomingCallerAuthenticationRequired.Text = "Incoming Caller Authentication Required";
            this.rbtnIncomingCallerAuthenticationRequired.UseVisualStyleBackColor = true;
            // 
            // rbtnNoAuthenticationRequired
            // 
            this.rbtnNoAuthenticationRequired.AutoSize = true;
            this.rbtnNoAuthenticationRequired.Location = new System.Drawing.Point(31, 78);
            this.rbtnNoAuthenticationRequired.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbtnNoAuthenticationRequired.Name = "rbtnNoAuthenticationRequired";
            this.rbtnNoAuthenticationRequired.Size = new System.Drawing.Size(179, 16);
            this.rbtnNoAuthenticationRequired.TabIndex = 6;
            this.rbtnNoAuthenticationRequired.TabStop = true;
            this.rbtnNoAuthenticationRequired.Text = "No Authentication Required";
            this.rbtnNoAuthenticationRequired.UseVisualStyleBackColor = true;
            // 
            // rbtnMutualAuthenticationRequired
            // 
            this.rbtnMutualAuthenticationRequired.AutoSize = true;
            this.rbtnMutualAuthenticationRequired.Location = new System.Drawing.Point(31, 38);
            this.rbtnMutualAuthenticationRequired.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbtnMutualAuthenticationRequired.Name = "rbtnMutualAuthenticationRequired";
            this.rbtnMutualAuthenticationRequired.Size = new System.Drawing.Size(203, 16);
            this.rbtnMutualAuthenticationRequired.TabIndex = 5;
            this.rbtnMutualAuthenticationRequired.TabStop = true;
            this.rbtnMutualAuthenticationRequired.Text = "Mutual Authentication Required";
            this.rbtnMutualAuthenticationRequired.UseVisualStyleBackColor = true;
            // 
            // chbAllowOutbound
            // 
            this.chbAllowOutbound.AutoSize = true;
            this.chbAllowOutbound.Location = new System.Drawing.Point(158, 18);
            this.chbAllowOutbound.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chbAllowOutbound.Name = "chbAllowOutbound";
            this.chbAllowOutbound.Size = new System.Drawing.Size(108, 16);
            this.chbAllowOutbound.TabIndex = 4;
            this.chbAllowOutbound.Text = "Allow Outbound";
            this.chbAllowOutbound.UseVisualStyleBackColor = true;
            // 
            // chbAllowInbound
            // 
            this.chbAllowInbound.AutoSize = true;
            this.chbAllowInbound.Location = new System.Drawing.Point(10, 18);
            this.chbAllowInbound.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chbAllowInbound.Name = "chbAllowInbound";
            this.chbAllowInbound.Size = new System.Drawing.Size(102, 16);
            this.chbAllowInbound.TabIndex = 3;
            this.chbAllowInbound.Text = "Allow Inbound";
            this.chbAllowInbound.UseVisualStyleBackColor = true;
            // 
            // chbNetworkDtcAccess
            // 
            this.chbNetworkDtcAccess.AutoSize = true;
            this.chbNetworkDtcAccess.Location = new System.Drawing.Point(5, 18);
            this.chbNetworkDtcAccess.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chbNetworkDtcAccess.Name = "chbNetworkDtcAccess";
            this.chbNetworkDtcAccess.Size = new System.Drawing.Size(132, 16);
            this.chbNetworkDtcAccess.TabIndex = 0;
            this.chbNetworkDtcAccess.Text = "Network DTC Access";
            this.chbNetworkDtcAccess.UseVisualStyleBackColor = true;
            // 
            // tabAbout
            // 
            this.tabAbout.Controls.Add(this.pictureBox1);
            this.tabAbout.Controls.Add(this.label5);
            this.tabAbout.Controls.Add(this.label4);
            this.tabAbout.Controls.Add(this.label3);
            this.tabAbout.Controls.Add(this.label2);
            this.tabAbout.Location = new System.Drawing.Point(4, 22);
            this.tabAbout.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabAbout.Name = "tabAbout";
            this.tabAbout.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabAbout.Size = new System.Drawing.Size(359, 422);
            this.tabAbout.TabIndex = 2;
            this.tabAbout.Text = "About";
            this.tabAbout.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ConfigurationManager.Properties.Resources.MsdtcManager;
            this.pictureBox1.Location = new System.Drawing.Point(258, 13);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(86, 71);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.DarkRed;
            this.label5.Location = new System.Drawing.Point(40, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(167, 12);
            this.label5.TabIndex = 3;
            this.label5.Text = "Developer   : Tammam Koujan";
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.Color.DarkRed;
            this.label4.Location = new System.Drawing.Point(40, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(313, 30);
            this.label4.TabIndex = 2;
            this.label4.Text = "Description : Class library to manage and configure Microsoft Distributed Transac" +
    "tion Coordinator service.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.DarkRed;
            this.label3.Location = new System.Drawing.Point(40, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "Version        : Beta";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.DarkRed;
            this.label2.Location = new System.Drawing.Point(99, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "MSDTC Manager";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 448);
            this.Controls.Add(this.ctrlTabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "MSDTC Manager";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ctrlTabControl.ResumeLayout(false);
            this.tabService.ResumeLayout(false);
            this.tabService.PerformLayout();
            this.gbFirewall.ResumeLayout(false);
            this.gbFirewall.PerformLayout();
            this.tabProperties.ResumeLayout(false);
            this.gbDtcLogon.ResumeLayout(false);
            this.gbDtcLogon.PerformLayout();
            this.gbFooter.ResumeLayout(false);
            this.gpSecurity.ResumeLayout(false);
            this.gpSecurity.PerformLayout();
            this.chbClientandAdministration.ResumeLayout(false);
            this.chbClientandAdministration.PerformLayout();
            this.gbTransactionManagerCommunication.ResumeLayout(false);
            this.gbTransactionManagerCommunication.PerformLayout();
            this.tabAbout.ResumeLayout(false);
            this.tabAbout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl ctrlTabControl;
        private System.Windows.Forms.TabPage tabService;
        private System.Windows.Forms.TabPage tabProperties;
        private System.Windows.Forms.CheckBox chbIsServiceInstalled;
        private System.Windows.Forms.CheckBox chbIsServiceInstalledAndRunning;
        private System.Windows.Forms.Button btnGetServiceStatus;
        private System.Windows.Forms.Button btnGetServiceInfo;
        private System.Windows.Forms.Button btnStartService;
        private System.Windows.Forms.Button btnStopService;
        private System.Windows.Forms.Button btnRestartService;
        private System.Windows.Forms.Button btnEnableWindowsFirewallException;
        private System.Windows.Forms.Button btnDisableWindowsFirewallException;
        private System.Windows.Forms.Button btnIsMsdtcRuleGroupEnabled;
        private System.Windows.Forms.ComboBox cbFirewallProfileTypes;
        private System.Windows.Forms.GroupBox gbFirewall;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbFooter;
        private System.Windows.Forms.Button btnResetDefault;
        private System.Windows.Forms.GroupBox gpSecurity;
        private System.Windows.Forms.GroupBox chbClientandAdministration;
        private System.Windows.Forms.CheckBox chbAllowRemoteAdministration;
        private System.Windows.Forms.CheckBox chbAllowRemoteClient;
        private System.Windows.Forms.GroupBox gbTransactionManagerCommunication;
        private System.Windows.Forms.RadioButton rbtnIncomingCallerAuthenticationRequired;
        private System.Windows.Forms.RadioButton rbtnNoAuthenticationRequired;
        private System.Windows.Forms.RadioButton rbtnMutualAuthenticationRequired;
        private System.Windows.Forms.CheckBox chbAllowOutbound;
        private System.Windows.Forms.CheckBox chbAllowInbound;
        private System.Windows.Forms.CheckBox chbNetworkDtcAccess;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.TabPage tabAbout;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnUnistallService;
        private System.Windows.Forms.Button btnIstallService;
        private System.Windows.Forms.Button btnRegMtxoci;
        private System.Windows.Forms.CheckBox chbEnableSnaLuTransactions;
        private System.Windows.Forms.CheckBox chbEnableXaTransactions;
        private System.Windows.Forms.GroupBox gbDtcLogon;
        private System.Windows.Forms.Label lblConfirmPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblAccount;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtAccount;
        private System.Windows.Forms.Button btnChangeLogonAccount;
    }
}

