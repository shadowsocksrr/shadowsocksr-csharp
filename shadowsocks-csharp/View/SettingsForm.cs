using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Shadowsocks.Controller;
using Shadowsocks.Model;
using Shadowsocks.Properties;

namespace Shadowsocks.View
{
    public partial class SettingsForm : Form
    {
        private ShadowsocksController controller;
        // this is a copy of configuration that we are working on
        private Configuration _modifiedConfiguration;
        private Dictionary<int, string> _balanceIndexMap = new Dictionary<int, string>();

        public SettingsForm(ShadowsocksController controller)
        {
            this.Font = System.Drawing.SystemFonts.MessageBoxFont;
            InitializeComponent();

            this.Icon = Icon.FromHandle(Resources.ssw128.GetHicon());
            this.controller = controller;

            UpdateTexts();
            controller.ConfigChanged += controller_ConfigChanged;

            int dpi_mul = Util.Utils.GetDpiMul();

            //comment
            ////int font_height = 9;
            ////Font new_font = new Font("Arial", (float)(9.0 * dpi_mul / 4));
            ////this.Font = new_font;

            ////comboProxyType.Height = comboProxyType.Height - font_height + font_height * dpi_mul / 4;
            //comboProxyType.Width = comboProxyType.Width * dpi_mul / 4;
            ////RandomComboBox.Height = RandomComboBox.Height - font_height + font_height * dpi_mul / 4;
            //RandomComboBox.Width = RandomComboBox.Width * dpi_mul / 4;

            //TextS5Server.Width = TextS5Server.Width * dpi_mul / 4;
            //NumS5Port.Width = NumS5Port.Width * dpi_mul / 4;
            //TextS5User.Width = TextS5User.Width * dpi_mul / 4;
            //TextS5Pass.Width = TextS5Pass.Width * dpi_mul / 4;
            //TextUserAgent.Width = TextUserAgent.Width * dpi_mul / 4;

            //NumProxyPort.Width = NumProxyPort.Width * dpi_mul / 4;
            //TextAuthUser.Width = TextAuthUser.Width * dpi_mul / 4;
            //TextAuthPass.Width = TextAuthPass.Width * dpi_mul / 4;

            //buttonDefault.Height = buttonDefault.Height * dpi_mul / 4;
            //buttonDefault.Width = buttonDefault.Width * dpi_mul / 4;
            //DNSText.Width = DNSText.Width * dpi_mul / 4;
            //LocalDNSText.Width = LocalDNSText.Width * dpi_mul / 4;
            //NumReconnect.Width = NumReconnect.Width * dpi_mul / 4;
            //NumTimeout.Width = NumTimeout.Width * dpi_mul / 4;
            //NumTTL.Width = NumTTL.Width * dpi_mul / 4;

            LoadCurrentConfiguration();
        }
        private void SettingsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            controller.ConfigChanged -= controller_ConfigChanged;
        }

        private void UpdateTexts()
        {
            this.Text = I18N.GetString("Global Settings") + "("
                + (controller.GetCurrentConfiguration().shareOverLan ? I18N.GetString("Any") : I18N.GetString("Local")) + ":" + controller.GetCurrentConfiguration().localPort.ToString()
                + " " + I18N.GetString("Version") + ":" + UpdateChecker.FullVersion
                + ")";

            gbxListen.Text = I18N.GetString(gbxListen.Text);
            checkShareOverLan.Text = I18N.GetString(checkShareOverLan.Text);
            lblProxyPort.Text = I18N.GetString("Proxy Port");
            btnDefault.Text = I18N.GetString("Set Default");
            lblLocalDns.Text = I18N.GetString("Local Dns");
            lblReconnect.Text = I18N.GetString("Reconnect Times");
            lblTtl.Text = I18N.GetString("TTL");
            lblTimeout.Text = I18N.GetString(lblTimeout.Text);

            chkAutoStartup.Text = I18N.GetString(chkAutoStartup.Text);
            chkSwitchAutoCloseAll.Text = I18N.GetString(chkSwitchAutoCloseAll.Text);
            chkBalance.Text = I18N.GetString(chkBalance.Text);
            chkAutoBan.Text = I18N.GetString("AutoBan");
            lblLogging.Text = I18N.GetString("Logging");
            chkLogEnable.Text = I18N.GetString("Enable Log");

            gbxSocks5Proxy.Text = I18N.GetString(gbxSocks5Proxy.Text);
            chkPacProxy.Text = I18N.GetString(chkPacProxy.Text);
            chkSockProxy.Text = I18N.GetString("Proxy On");
            lblS5Server.Text = I18N.GetString("Server IP");
            lblS5Port.Text = I18N.GetString("Server Port");
            lblS5Server.Text = I18N.GetString("Server IP");
            lblS5Port.Text = I18N.GetString("Server Port");
            lblS5Username.Text = I18N.GetString("Username");
            lblS5Password.Text = I18N.GetString("Password");
            lblUserAgent.Text = I18N.GetString("User Agent");
            lblAuthUser.Text = I18N.GetString("Username");
            lblAuthPass.Text = I18N.GetString("Password");

            lblBalance.Text = I18N.GetString("Balance");
            for (int i = 0; i < cmbProxyType.Items.Count; ++i)
            {
                cmbProxyType.Items[i] = I18N.GetString(cmbProxyType.Items[i].ToString());
            }
            chkBalanceInGroup.Text = I18N.GetString("Balance in group");
            for (int i = 0; i < cmbBalance.Items.Count; ++i)
            {
                _balanceIndexMap[i] = cmbBalance.Items[i].ToString();
                cmbBalance.Items[i] = I18N.GetString(cmbBalance.Items[i].ToString());
            }

            btnOK.Text = I18N.GetString("OK");
            btnCancel.Text = I18N.GetString("Cancel");
        }

        private void controller_ConfigChanged(object sender, EventArgs e)
        {
            LoadCurrentConfiguration();
        }

        private void ShowWindow()
        {
            this.Opacity = 1;
            this.Show();
        }

        private int SaveOldSelectedServer()
        {
            try
            {
                int localPort = int.Parse(nudProxyPort.Text);
                Configuration.CheckPort(localPort);
                int ret = 0;
                _modifiedConfiguration.shareOverLan = checkShareOverLan.Checked;
                _modifiedConfiguration.localPort = localPort;
                _modifiedConfiguration.reconnectTimes = nudReconnect.Text.Length == 0 ? 0 : int.Parse(nudReconnect.Text);

                if (chkAutoStartup.Checked != AutoStartup.Check() && !AutoStartup.Set(chkAutoStartup.Checked))
                {
                    MessageBox.Show(I18N.GetString("Failed to update registry"));
                }
                _modifiedConfiguration.random = chkBalance.Checked;
                _modifiedConfiguration.balanceAlgorithm = cmbBalance.SelectedIndex >= 0 && cmbBalance.SelectedIndex < _balanceIndexMap.Count ? _balanceIndexMap[cmbBalance.SelectedIndex] : "OneByOne";
                _modifiedConfiguration.randomInGroup = chkBalanceInGroup.Checked;
                _modifiedConfiguration.TTL = Convert.ToInt32(nudTTL.Value);
                _modifiedConfiguration.connectTimeout = Convert.ToInt32(nudTimeout.Value);
                _modifiedConfiguration.dnsServer = txtDNS.Text;
                _modifiedConfiguration.localDnsServer = txtLocalDNS.Text;
                _modifiedConfiguration.proxyEnable = chkSockProxy.Checked;
                _modifiedConfiguration.pacDirectGoProxy = chkPacProxy.Checked;
                _modifiedConfiguration.proxyType = cmbProxyType.SelectedIndex;
                _modifiedConfiguration.proxyHost = txtS5Server.Text;
                _modifiedConfiguration.proxyPort = Convert.ToInt32(nudS5Port.Value);
                _modifiedConfiguration.proxyAuthUser = txtS5User.Text;
                _modifiedConfiguration.proxyAuthPass = txtS5Pass.Text;
                _modifiedConfiguration.proxyUserAgent = txtUserAgent.Text;
                _modifiedConfiguration.authUser = txtAuthUser.Text;
                _modifiedConfiguration.authPass = txtAuthPass.Text;

                _modifiedConfiguration.autoBan = chkAutoBan.Checked;
                _modifiedConfiguration.checkSwitchAutoCloseAll = chkSwitchAutoCloseAll.Checked;
                _modifiedConfiguration.logEnable = chkLogEnable.Checked;

                return ret;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return -1; // ERROR
        }

        private void LoadSelectedServer()
        {
            checkShareOverLan.Checked = _modifiedConfiguration.shareOverLan;
            nudProxyPort.Value = _modifiedConfiguration.localPort;
            nudReconnect.Value = _modifiedConfiguration.reconnectTimes;

            chkAutoStartup.Checked = AutoStartup.Check();
            chkBalance.Checked = _modifiedConfiguration.random;
            int selectedIndex = 0;
            for (int i = 0; i < _balanceIndexMap.Count; ++i)
            {
                if (_modifiedConfiguration.balanceAlgorithm == _balanceIndexMap[i])
                {
                    selectedIndex = i;
                    break;
                }
            }
            cmbBalance.SelectedIndex = selectedIndex;
            chkBalanceInGroup.Checked = _modifiedConfiguration.randomInGroup;
            nudTTL.Value = _modifiedConfiguration.TTL;
            nudTimeout.Value = _modifiedConfiguration.connectTimeout;
            txtDNS.Text = _modifiedConfiguration.dnsServer;
            txtLocalDNS.Text = _modifiedConfiguration.localDnsServer;

            chkSockProxy.Checked = _modifiedConfiguration.proxyEnable;
            chkPacProxy.Checked = _modifiedConfiguration.pacDirectGoProxy;
            cmbProxyType.SelectedIndex = _modifiedConfiguration.proxyType;
            txtS5Server.Text = _modifiedConfiguration.proxyHost;
            nudS5Port.Value = _modifiedConfiguration.proxyPort;
            txtS5User.Text = _modifiedConfiguration.proxyAuthUser;
            txtS5Pass.Text = _modifiedConfiguration.proxyAuthPass;
            txtUserAgent.Text = _modifiedConfiguration.proxyUserAgent;
            txtAuthUser.Text = _modifiedConfiguration.authUser;
            txtAuthPass.Text = _modifiedConfiguration.authPass;

            chkAutoBan.Checked = _modifiedConfiguration.autoBan;
            chkSwitchAutoCloseAll.Checked = _modifiedConfiguration.checkSwitchAutoCloseAll;
            chkLogEnable.Checked = _modifiedConfiguration.logEnable;
        }

        private void LoadCurrentConfiguration()
        {
            _modifiedConfiguration = controller.GetConfiguration();
            LoadSelectedServer();
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            if (SaveOldSelectedServer() == -1)
            {
                return;
            }
            controller.SaveServersConfig(_modifiedConfiguration);
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonDefault_Click(object sender, EventArgs e)
        {
            if (chkSockProxy.Checked)
            {
                nudReconnect.Value = 4;
                nudTimeout.Value = 10;
                nudTTL.Value = 60;
            }
            else
            {
                nudReconnect.Value = 4;
                nudTimeout.Value = 5;
                nudTTL.Value = 60;
            }
        }
    }
}
