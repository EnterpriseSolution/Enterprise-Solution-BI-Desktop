using System;
using System.Windows.Forms;
using Madaa.Lib.Win.Services.Msdtc;
using NetFwTypeLib;


namespace Demo
{
    public partial class MainForm : Form
    {

        #region Variables

        private MsdtcManager msdtcManager;

        #endregion Variables

        public MainForm()
        {
            InitializeComponent();
            msdtcManager = new MsdtcManager(false, 1000);
        }

        #region Methods

        #region Private
         private NET_FW_PROFILE_TYPE2_ GetNetFwProfileType()
        {
            NET_FW_PROFILE_TYPE2_ netFwProfile = new NET_FW_PROFILE_TYPE2_();
            switch (cbFirewallProfileTypes.SelectedIndex)
            {
                // All
                case 0:
                    {
                        netFwProfile = NET_FW_PROFILE_TYPE2_.NET_FW_PROFILE2_ALL;
                        break;
                    }
                // Domain
                case 1:
                    {
                        netFwProfile = NET_FW_PROFILE_TYPE2_.NET_FW_PROFILE2_DOMAIN;
                        break;
                    }
                // Private
                case 2:
                    {
                        netFwProfile = NET_FW_PROFILE_TYPE2_.NET_FW_PROFILE2_PRIVATE;
                        break;
                    }
                // Public
                case 3:
                    {
                        netFwProfile = NET_FW_PROFILE_TYPE2_.NET_FW_PROFILE2_PUBLIC;
                        break;
                    }
            }
            return netFwProfile;
        }

        #endregion Private

        #endregion Methods

        private void MainForm_Load(object sender, EventArgs e)
        {
            cbFirewallProfileTypes.SelectedIndex = 0;
            chbIsServiceInstalled.Checked = msdtcManager.IsServiceInstalled();
            chbIsServiceInstalledAndRunning.Checked = msdtcManager.IsServiceInstalledAndRunning();
        }

        private void btnGetServiceStatus_Click(object sender, EventArgs e)
        {
            MessageBox.Show(msdtcManager.GetServiceStatus().ToString());
        }

        private void btnGetServiceInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show(msdtcManager.GetServiceInfo().ToString());
        }

        private void btnStartService_Click(object sender, EventArgs e)
        {
            msdtcManager.StartService();
        }

        private void btnStopService_Click(object sender, EventArgs e)
        {
            msdtcManager.StopService();
        }

        private void btnPauseService_Click(object sender, EventArgs e)
        {
            msdtcManager.PauseService();
        }

        private void btnContinueService_Click(object sender, EventArgs e)
        {
            msdtcManager.ContinueService();
        }

        private void btnRestartService_Click(object sender, EventArgs e)
        {
            msdtcManager.RestartService();
        }

        private void btnIsMsdtcRuleGroupEnabled_Click(object sender, EventArgs e)
        {
            MessageBox.Show(msdtcManager.IsMsdtcRuleGroupEnabled(GetNetFwProfileType()).ToString());
        }

        private void btnEnableWindowsFirewallException_Click(object sender, EventArgs e)
        {

            msdtcManager.EnableWindowsFirewallException(GetNetFwProfileType());
        }

        private void btnDisableWindowsFirewallException_Click(object sender, EventArgs e)
        {
            msdtcManager.DisableWindowsFirewallException(GetNetFwProfileType());
        }

        private void btnResetDefault_Click(object sender, EventArgs e)
        {
            msdtcManager.ResetToDefaultSettings();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            chbNetworkDtcAccess.Checked = msdtcManager.NetworkDtcAccess == NetworkDTCAccessStatus.On;
            chbAllowInbound.Checked = msdtcManager.AllowInbound;
            chbAllowOutbound.Checked = msdtcManager.AllowInbound;
            switch (msdtcManager.AuthenticationRequired)
            {
                    case AuthenticationRequiredType.MutualAuthenticationRequired:
                {
                    rbtnMutualAuthenticationRequired.Checked = true;
                    break;
                }
                    case AuthenticationRequiredType.IncomingCallerAuthenticationRequired:
                {
                    rbtnIncomingCallerAuthenticationRequired.Checked = true;
                    break;
                }
                    case AuthenticationRequiredType.NoAuthenticationRequired:
                {
                    rbtnNoAuthenticationRequired.Checked = true;
                    break;
                }
            }

            chbEnableXaTransactions.Checked = msdtcManager.EnableXaTransactions;
            chbEnableSnaLuTransactions.Checked = msdtcManager.EnableSnaLuTransactions;


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            msdtcManager.NetworkDtcAccess = chbNetworkDtcAccess.Checked ? NetworkDTCAccessStatus.On : NetworkDTCAccessStatus.Off;
            msdtcManager.AllowInbound = chbAllowInbound.Checked;
            msdtcManager.AllowOutbound = chbAllowOutbound.Checked;
            if (rbtnMutualAuthenticationRequired.Checked)
            {
                msdtcManager.AuthenticationRequired = AuthenticationRequiredType.MutualAuthenticationRequired;
            }
            if (rbtnIncomingCallerAuthenticationRequired.Checked)
            {
                msdtcManager.AuthenticationRequired = AuthenticationRequiredType.IncomingCallerAuthenticationRequired;
            }
            if (rbtnNoAuthenticationRequired.Checked)
            {
                msdtcManager.AuthenticationRequired = AuthenticationRequiredType.NoAuthenticationRequired;
            }

            // Because of we initiate msdtcManager with autoRestartService = false we should care about restarting the service if required
            if (msdtcManager.NeedRestart)
            {
                msdtcManager.RestartService();
            }

            msdtcManager.EnableXaTransactions = chbEnableXaTransactions.Checked;
            msdtcManager.EnableSnaLuTransactions = chbEnableSnaLuTransactions.Checked;


        }

        private void btnIstallService_Click(object sender, EventArgs e)
        {
            msdtcManager.InstallService();
        }

        private void btnUnistallService_Click(object sender, EventArgs e)
        {
            msdtcManager.UninstallService();
        }

        private void btnRegMtxoci_Click(object sender, EventArgs e)
        {
            //Mtxoci.dll is a dynamic-link library (DLL) 
            //that is used internally by the Microsoft ODBC Driver for Oracle and the Microsoft OLEDB Provider for Oracle 
            //in conjunction with Microsoft Distributed Transaction Coordinator (DTC) to provide transactional support to Oracle databases. 
            //Specifically, it translates the DTC transactions into the XA transactions that Oracle can understand. 
            //This component currently has no way of tracing the DTC and application messages received by it nor XA messages sent by it. 
            //This can make troubleshooting some problems extremely difficult.
            msdtcManager.RegMtxoci();
        }

        private void btnChangeLogonAccount_Click(object sender, EventArgs e)
        {
            msdtcManager.ChangeLogonAccount(txtAccount.Text, txtPassword.Text);
        }
    }
}
