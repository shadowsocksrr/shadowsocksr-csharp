using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Net;
using Microsoft.Win32;
using Shadowsocks.Controller;
using Shadowsocks.Model;
using Shadowsocks.Properties;
using ZXing.QrCode.Internal;
using Shadowsocks.Encryption;

namespace Shadowsocks.View
{
    public partial class ConfigForm : Form
    {
        private ShadowsocksController controller;
        private UpdateChecker updateChecker;

        // this is a copy of configuration that we are working on
        private Configuration _modifiedConfiguration;
        private int _oldSelectedIndex = -1;
        private bool _allowSave = true;
        private bool _ignoreLoad = false;
        private string _oldSelectedID = null;

        private string _SelectedID = null;

        public ConfigForm(ShadowsocksController controller, UpdateChecker updateChecker, int focusIndex)
        {
            this.Font = System.Drawing.SystemFonts.MessageBoxFont;
            InitializeComponent();
            lstServers.Font = CreateFont();

            nudServerPort.Minimum = IPEndPoint.MinPort;
            nudServerPort.Maximum = IPEndPoint.MaxPort;
            nudUdpPort.Minimum = IPEndPoint.MinPort;
            nudUdpPort.Maximum = IPEndPoint.MaxPort;

            this.Icon = Icon.FromHandle(Resources.ssw128.GetHicon());
            this.controller = controller;
            this.updateChecker = updateChecker;
            if (updateChecker.LatestVersionURL == null)
                llbUpdate.Visible = false;

            foreach (string name in EncryptorFactory.GetEncryptor())
            {
                EncryptorInfo info = EncryptorFactory.GetEncryptorInfo(name);
                if (info.display)
                    cmbEncryption.Items.Add(name);
            }
            UpdateTexts();
            controller.ConfigChanged += controller_ConfigChanged;

            LoadCurrentConfiguration();
            if (_modifiedConfiguration.index >= 0 && _modifiedConfiguration.index < _modifiedConfiguration.configs.Count)
                _oldSelectedID = _modifiedConfiguration.configs[_modifiedConfiguration.index].id;
            if (focusIndex == -1)
            {
                int index = _modifiedConfiguration.index + 1;
                if (index < 0 || index > _modifiedConfiguration.configs.Count)
                    index = _modifiedConfiguration.configs.Count;

                focusIndex = index;
            }

            if (_modifiedConfiguration.isHideTips)
                picQRcode.Visible = false;

            int dpi_mul = Util.Utils.GetDpiMul();
            //comment
            ////ServersListBox.Height = ServersListBox.Height * 4 / dpi_mul;
            //lstServers.Width = lstServers.Width * dpi_mul / 4;
            ////ServersListBox.Height = ServersListBox.Height * dpi_mul / 4;
            //lstServers.Height = chkAdvSetting.Top + chkAdvSetting.Height;
            //btnAdd.Width = btnAdd.Width * dpi_mul / 4;
            //btnAdd.Height = btnAdd.Height * dpi_mul / 4;
            //btnDelete.Width = btnDelete.Width * dpi_mul / 4;
            //btnDelete.Height = btnDelete.Height * dpi_mul / 4;
            //btnUp.Width = btnUp.Width * dpi_mul / 4;
            //btnUp.Height = btnUp.Height * dpi_mul / 4;
            //btnDown.Width = btnDown.Width * dpi_mul / 4;
            //btnDown.Height = btnDown.Height * dpi_mul / 4;

            ////IPTextBox.Width = IPTextBox.Width * dpi_mul / 4;
            ////ServerPortNumericUpDown.Width = ServerPortNumericUpDown.Width * dpi_mul / 4;
            ////PasswordTextBox.Width = PasswordTextBox.Width * dpi_mul / 4;
            ////EncryptionSelect.Width = EncryptionSelect.Width * dpi_mul / 4;
            ////TCPProtocolComboBox.Width = TCPProtocolComboBox.Width * dpi_mul / 4;
            ////ObfsCombo.Width = ObfsCombo.Width * dpi_mul / 4;
            ////TextObfsParam.Width = TextObfsParam.Width * dpi_mul / 4;
            ////RemarksTextBox.Width = RemarksTextBox.Width * dpi_mul / 4;
            ////TextGroup.Width = TextGroup.Width * dpi_mul / 4;
            ////TextLink.Width = TextLink.Width * dpi_mul / 4;
            ////TextUDPPort.Width = TextUDPPort.Width * dpi_mul / 4;

            ////int font_height = 9;
            ////EncryptionSelect.Height = EncryptionSelect.Height - font_height + font_height * dpi_mul / 4;
            ////TCPProtocolComboBox.Height = TCPProtocolComboBox.Height - font_height + font_height * dpi_mul / 4;
            ////ObfsCombo.Height = ObfsCombo.Height - font_height + font_height * dpi_mul / 4;

            ////OKButton.Width = OKButton.Width * dpi_mul / 4;
            //btnOK.Height = btnOK.Height * dpi_mul / 4;
            ////MyCancelButton.Width = MyCancelButton.Width * dpi_mul / 4;
            //btnCancel.Height = btnCancel.Height * dpi_mul / 4;

            DrawLogo(350 * dpi_mul / 4);
            //DrawLogo(350);

            ShowWindow();

            if (focusIndex >= 0 && focusIndex < _modifiedConfiguration.configs.Count)
            {
                SetServerListSelectedIndex(focusIndex);
                LoadSelectedServer();
            }

            UpdateServersListBoxTopIndex();
        }

        private Font CreateFont()
        {
            try
            {
                return new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            }
            catch
            {
                try
                {
                    return new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
                catch
                {
                    return new System.Drawing.Font(System.Drawing.FontFamily.GenericMonospace, 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }

        private void UpdateTexts()
        {
             this.Text = I18N.GetString("Edit Servers") + "("
                + (controller.GetCurrentConfiguration().shareOverLan ? I18N.GetString("Any") : I18N.GetString("Local")) + ":" + controller.GetCurrentConfiguration().localPort.ToString()
                +" " +I18N.GetString("Version")+":" + UpdateChecker.FullVersion
                + ")";

            btnAdd.Text = I18N.GetString("&Add");
            btnDelete.Text = I18N.GetString("&Delete");
            btnUp.Text = I18N.GetString("Up");
            btnDown.Text = I18N.GetString("Down");

            const string mark_str = "*";
            chkIP.Text = mark_str + I18N.GetString("Server IP");
            lblServerPort.Text = mark_str + I18N.GetString("Server Port");
            lblUDPPort.Text = I18N.GetString("UDP Port");
            chkPassword.Text = mark_str + I18N.GetString("Password");
            lblEncryption.Text = mark_str + I18N.GetString("Encryption");
            lblTCPProtocol.Text = mark_str + I18N.GetString(lblTCPProtocol.Text);
            lblObfs.Text = mark_str + I18N.GetString(lblObfs.Text);
            lblRemarks.Text = I18N.GetString("Remarks");
            lblGroup.Text = I18N.GetString("Group");

            chkAdvSetting.Text = I18N.GetString(chkAdvSetting.Text);
            lblTcpOverUdp.Text = I18N.GetString(lblTcpOverUdp.Text);
            lblUdpOverTcp.Text = I18N.GetString(lblUdpOverTcp.Text);
            lblProtocolParam.Text = I18N.GetString(lblProtocolParam.Text);
            lblObfsParam.Text = I18N.GetString(lblObfsParam.Text);
            lblObfsUdp.Text = I18N.GetString(lblObfsUdp.Text);
            LabelNote.Text = I18N.GetString(LabelNote.Text);
            chkTcpOverUdp.Text = I18N.GetString(chkTcpOverUdp.Text);
            chkUdpOverTcp.Text = I18N.GetString(chkUdpOverTcp.Text);
            chkObfsUDP.Text = I18N.GetString(chkObfsUDP.Text);
            chkSSRLink.Text = I18N.GetString(chkSSRLink.Text);
            for (int i = 0; i < cmbTcpProtocol.Items.Count; ++i)
            {
                cmbTcpProtocol.Items[i] = I18N.GetString(cmbTcpProtocol.Items[i].ToString());
            }

            ServerGroupBox.Text = I18N.GetString("Server");

            btnOK.Text = I18N.GetString("OK");
            btnCancel.Text = I18N.GetString("Cancel");
            llbUpdate.MaximumSize = new Size(lstServers.Width, lstServers.Height);
            llbUpdate.Text = String.Format(I18N.GetString("New version {0} {1} available"), UpdateChecker.Name, updateChecker.LatestVersionNumber);
        }

        private void controller_ConfigChanged(object sender, EventArgs e)
        {
            LoadCurrentConfiguration();
        }

        private void ShowWindow()
        {
            this.Opacity = 1;
            this.Show();
            txtIP.Focus();
        }

        private int SaveOldSelectedServer()
        {
            try
            {
                if (_oldSelectedIndex == -1 || _oldSelectedIndex >= _modifiedConfiguration.configs.Count)
                {
                    return 0; // no changes
                }
                Server server = new Server
                {
                    server = txtIP.Text.Trim(),
                    server_port = Convert.ToUInt16(nudServerPort.Value),
                    server_udp_port = Convert.ToUInt16(nudUdpPort.Value),
                    password = txtPassword.Text,
                    method = cmbEncryption.Text,
                    protocol = cmbTcpProtocol.Text,
                    protocolparam = txtProtocolParam.Text,
                    obfs = cmbObfs.Text,
                    obfsparam = txtObfsParam.Text,
                    remarks = txtRemarks.Text,
                    group = txtGroup.Text.Trim(),
                    udp_over_tcp = chkUdpOverTcp.Checked,
                    //obfs_udp = CheckObfsUDP.Checked,
                    id = _SelectedID
                };
                Configuration.CheckServer(server);
                int ret = 0;
                if (_modifiedConfiguration.configs[_oldSelectedIndex].server != server.server
                    || _modifiedConfiguration.configs[_oldSelectedIndex].server_port != server.server_port
                    || _modifiedConfiguration.configs[_oldSelectedIndex].remarks_base64 != server.remarks_base64
                    || _modifiedConfiguration.configs[_oldSelectedIndex].group != server.group
                    )
                {
                    ret = 1; // display changed
                }
                Server oldServer = _modifiedConfiguration.configs[_oldSelectedIndex];
                if (oldServer.isMatchServer(server))
                {
                    server.setObfsData(oldServer.getObfsData());
                    server.setProtocolData(oldServer.getProtocolData());
                    server.enable = oldServer.enable;
                }
                _modifiedConfiguration.configs[_oldSelectedIndex] = server;

                return ret;
            }
            catch (FormatException)
            {
                MessageBox.Show(I18N.GetString("Illegal port number format"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return -1; // ERROR
        }

        private void DrawLogo(int width)
        {
            Bitmap drawArea = new Bitmap(width, width);
            using (Graphics g = Graphics.FromImage(drawArea))
            {
                g.Clear(Color.White);
                Bitmap ngnl = Resources.ngnl;
                g.DrawImage(ngnl, new Rectangle(0, 0, width, width));
                if (!_modifiedConfiguration.isHideTips)
                    g.DrawString(I18N.GetString("Click the 'Link' text box"), new Font("宋体", 12), new SolidBrush(Color.Black), new RectangleF(0, 0, 300, 300));
            }
            picQRcode.Image = drawArea;
        }

        private void GenQR(string ssconfig)
        {
            int dpi_mul = Util.Utils.GetDpiMul();
            int width = 350 * dpi_mul / 4;
            if (txtLink.Focused)
            {
                string qrText = ssconfig;
                QRCode code = ZXing.QrCode.Internal.Encoder.encode(qrText, ErrorCorrectionLevel.M);
                ByteMatrix m = code.Matrix;
                int blockSize = Math.Max(width / (m.Width + 2), 1);
                Bitmap drawArea = new Bitmap(((m.Width + 2) * blockSize), ((m.Height + 2) * blockSize));
                using (Graphics g = Graphics.FromImage(drawArea))
                {
                    g.Clear(Color.White);
                    using (Brush b = new SolidBrush(Color.Black))
                    {
                        for (int row = 0; row < m.Width; row++)
                        {
                            for (int col = 0; col < m.Height; col++)
                            {
                                if (m[row, col] != 0)
                                {
                                    g.FillRectangle(b, blockSize * (row + 1), blockSize * (col + 1),
                                        blockSize, blockSize);
                                }
                            }
                        }
                    }
                    Bitmap ngnl = Resources.ngnl;
                    int div = 13, div_l = 5, div_r = 8;
                    int l = (m.Width * div_l + div - 1) / div * blockSize, r = (m.Width * div_r + div - 1) / div * blockSize;
                    g.DrawImage(ngnl, new Rectangle(l + blockSize, l + blockSize, r - l, r - l));
                }
                picQRcode.Image = drawArea;
                picQRcode.Visible = true;
                _modifiedConfiguration.isHideTips = true;
            }
            else
            {
                //PictureQRcode.Visible = false;
                DrawLogo(picQRcode.Width);
            }
        }

        private void LoadSelectedServer()
        {
            if (lstServers.SelectedIndex >= 0 && lstServers.SelectedIndex < _modifiedConfiguration.configs.Count)
            {
                Server server = _modifiedConfiguration.configs[lstServers.SelectedIndex];

                txtIP.Text = server.server;
                nudServerPort.Value = server.server_port;
                nudUdpPort.Value = server.server_udp_port;
                txtPassword.Text = server.password;
                cmbEncryption.Text = server.method ?? "aes-256-cfb";
                if (string.IsNullOrEmpty(server.protocol))
                {
                    cmbTcpProtocol.Text = "origin";
                }
                else
                {
                    cmbTcpProtocol.Text = server.protocol ?? "origin";
                }
                string obfs_text = server.obfs ?? "plain";
                cmbObfs.Text = obfs_text;
                txtProtocolParam.Text = server.protocolparam;
                txtObfsParam.Text = server.obfsparam;
                txtRemarks.Text = server.remarks;
                txtGroup.Text = server.group;
                chkUdpOverTcp.Checked = server.udp_over_tcp;
                //CheckObfsUDP.Checked = server.obfs_udp;
                _SelectedID = server.id;

                ServerGroupBox.Visible = true;

                if (cmbTcpProtocol.Text == "origin"
                    && obfs_text == "plain"
                    && !chkUdpOverTcp.Checked
                    )
                {
                    chkAdvSetting.Checked = false;
                }

                if (chkSSRLink.Checked)
                {
                    txtLink.Text = server.GetSSRLinkForServer();
                }
                else
                {
                    txtLink.Text = server.GetSSLinkForServer();
                }

                if (chkTcpOverUdp.Checked || chkUdpOverTcp.Checked || server.server_udp_port != 0)
                {
                    chkAdvSetting.Checked = true;
                }

                //PasswordLabel.Checked = false;
                //IPLabel.Checked = false;
                Update_SSR_controls_Visable();
                UpdateObfsTextbox();
                txtLink.SelectAll();
                GenQR(txtLink.Text);
            }
            else
            {
                ServerGroupBox.Visible = false;
            }
        }

        private void LoadConfiguration(Configuration configuration)
        {
            if (lstServers.Items.Count != _modifiedConfiguration.configs.Count)
            {
                lstServers.Items.Clear();
                foreach (Server server in _modifiedConfiguration.configs)
                {
                    if (!string.IsNullOrEmpty(server.group))
                    {
                        lstServers.Items.Add(server.group + " - " + server.HiddenName());
                    }
                    else
                    {
                        lstServers.Items.Add("      " + server.HiddenName());
                    }
                }
            }
            else
            {
                for (int i = 0; i < _modifiedConfiguration.configs.Count; ++i)
                {
                    if (!string.IsNullOrEmpty(_modifiedConfiguration.configs[i].group))
                    {
                        lstServers.Items[i] = _modifiedConfiguration.configs[i].group + " - " + _modifiedConfiguration.configs[i].HiddenName();
                    }
                    else
                    {
                        lstServers.Items[i] = "      " + _modifiedConfiguration.configs[i].HiddenName();
                    }
                }
            }
        }

        public void SetServerListSelectedIndex(int index)
        {
            lstServers.ClearSelected();
            if (index < lstServers.Items.Count)
                lstServers.SelectedIndex = index;
            else
                _oldSelectedIndex = lstServers.SelectedIndex;
        }

        private void LoadCurrentConfiguration()
        {
            _modifiedConfiguration = controller.GetConfiguration();
            LoadConfiguration(_modifiedConfiguration);
            _allowSave = false;
            SetServerListSelectedIndex(_modifiedConfiguration.index);
            _allowSave = true;
            LoadSelectedServer();
        }

        private void ServersListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_oldSelectedIndex == lstServers.SelectedIndex || lstServers.SelectedIndex == -1)
            {
                // we are moving back to oldSelectedIndex or doing a force move
                return;
            }
            if (_allowSave)
            {
                int change = SaveOldSelectedServer();
                if (change == -1)
                {
                    lstServers.SelectedIndex = _oldSelectedIndex; // go back
                    return;
                }
                if (change == 1)
                {
                    LoadConfiguration(_modifiedConfiguration);
                }
            }
            if (!_ignoreLoad) LoadSelectedServer();
            _oldSelectedIndex = lstServers.SelectedIndex;
        }

        private void UpdateServersListBoxTopIndex(int style = 0)
        {
            int visibleItems = lstServers.ClientSize.Height / lstServers.ItemHeight;
            int index;
            if (style == 0)
            {
                index = lstServers.SelectedIndex;
            }
            else
            {
                var items = lstServers.SelectedIndices;
                if (0 == items.Count)
                    index = 0;
                else
                    index = (style == 1 ? items[0] : items[items.Count - 1]);
            }
            int topIndex = Math.Max(index - visibleItems / 2, 0);
            lstServers.TopIndex = topIndex;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (SaveOldSelectedServer() == -1)
            {
                return;
            }
            Server server = _oldSelectedIndex >=0 && _oldSelectedIndex < _modifiedConfiguration.configs.Count
                ? Configuration.CopyServer(_modifiedConfiguration.configs[_oldSelectedIndex])
                : Configuration.GetDefaultServer();
            _modifiedConfiguration.configs.Insert(_oldSelectedIndex < 0 ? 0 : _oldSelectedIndex + 1, server);
            LoadConfiguration(_modifiedConfiguration);
            _SelectedID = server.id;
            lstServers.SelectedIndex = _oldSelectedIndex + 1;
            _oldSelectedIndex = lstServers.SelectedIndex;
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            _oldSelectedIndex = lstServers.SelectedIndex;
            var items = lstServers.SelectedIndices;
            if (items.Count > 0)
            {
                int[] array = new int[items.Count];
                int i = 0;
                foreach (int index in items)
                {
                    array[i++] = index;
                }
                Array.Sort(array);
                for (--i; i >= 0; --i)
                {
                    int index = array[i];
                    if (index >= 0 && index < _modifiedConfiguration.configs.Count)
                    {
                        _modifiedConfiguration.configs.RemoveAt(index);
                    }
                }
            }
            if (_oldSelectedIndex >= _modifiedConfiguration.configs.Count)
            {
                _oldSelectedIndex = _modifiedConfiguration.configs.Count - 1;
            }
            if (_oldSelectedIndex < 0)
            {
                _oldSelectedIndex = 0;
            }
            if (_oldSelectedIndex < _modifiedConfiguration.configs.Count)
                lstServers.SelectedIndex = _oldSelectedIndex;
            LoadConfiguration(_modifiedConfiguration);
            SetServerListSelectedIndex(_oldSelectedIndex);
            LoadSelectedServer();
            UpdateServersListBoxTopIndex();
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            if (SaveOldSelectedServer() == -1)
            {
                return;
            }
            if (_modifiedConfiguration.configs.Count == 0)
            {
                MessageBox.Show(I18N.GetString("Please add at least one server"));
                return;
            }
            if (_oldSelectedID != null)
            {
                for (int i = 0; i < _modifiedConfiguration.configs.Count; ++i)
                {
                    if (_modifiedConfiguration.configs[i].id == _oldSelectedID)
                    {
                        _modifiedConfiguration.index = i;
                        break;
                    }
                }
            }
            controller.SaveServersConfig(_modifiedConfiguration);
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ConfigForm_Shown(object sender, EventArgs e)
        {
            txtIP.Focus();
        }

        private void ConfigForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            controller.ConfigChanged -= controller_ConfigChanged;
        }

        private void UpButton_Click(object sender, EventArgs e)
        {
            _oldSelectedIndex = lstServers.SelectedIndex;
            int index = _oldSelectedIndex;
            SaveOldSelectedServer();
            var items = lstServers.SelectedIndices;
            if (items.Count == 1)
            {
                if (index > 0 && index < _modifiedConfiguration.configs.Count)
                {
                    _modifiedConfiguration.configs.Reverse(index - 1, 2);
                    lstServers.ClearSelected();
                    lstServers.SelectedIndex = _oldSelectedIndex = index - 1;
                    LoadConfiguration(_modifiedConfiguration);
                    lstServers.ClearSelected();
                    lstServers.SelectedIndex = _oldSelectedIndex = index - 1;
                    LoadSelectedServer();
                }
            }
            else if (0 == items.Count)
            {
                // Handle when server list is empty.
                _oldSelectedIndex = -1;
                lstServers.ClearSelected();
                LoadSelectedServer();
            }
            else
            {
                List<int> all_items = new List<int>();
                foreach (int item in items)
                {
                    if (item == 0)
                        return;
                    all_items.Add(item);
                }
                foreach (int item in all_items)
                {
                    _modifiedConfiguration.configs.Reverse(item - 1, 2);
                }
                _allowSave = false;
                _ignoreLoad = true;

                lstServers.SelectedIndex = _oldSelectedIndex = index - 1;

                LoadConfiguration(_modifiedConfiguration);
                lstServers.ClearSelected();
                foreach (int item in all_items)
                {
                    if (item != index)
                        lstServers.SelectedIndex = _oldSelectedIndex = item - 1;
                }

                lstServers.SelectedIndex = _oldSelectedIndex = index - 1;

                _ignoreLoad = false;
                _allowSave = true;
                LoadSelectedServer();
            }
            UpdateServersListBoxTopIndex(1);
        }

        private void DownButton_Click(object sender, EventArgs e)
        {
            _oldSelectedIndex = lstServers.SelectedIndex;
            int index = _oldSelectedIndex;
            SaveOldSelectedServer();
            var items = lstServers.SelectedIndices;
            if (items.Count == 1)
            {
                if (_oldSelectedIndex >= 0 && _oldSelectedIndex < _modifiedConfiguration.configs.Count - 1)
                {
                    _modifiedConfiguration.configs.Reverse(index, 2);
                    lstServers.ClearSelected();
                    lstServers.SelectedIndex = _oldSelectedIndex = index + 1;
                    LoadConfiguration(_modifiedConfiguration);
                    lstServers.ClearSelected();
                    lstServers.SelectedIndex = _oldSelectedIndex = index + 1;
                    LoadSelectedServer();
                }
            }
            else if (0 == items.Count)
            {
                // Handle when server list is empty.
                _oldSelectedIndex = -1;
                lstServers.ClearSelected();
                LoadSelectedServer();
            }
            else
            {
                List<int> rev_items = new List<int>();
                int max_index = lstServers.Items.Count - 1;
                foreach (int item in items)
                {
                    if (item == max_index)
                        return;
                    rev_items.Insert(0, item);
                }
                foreach (int item in rev_items)
                {
                    _modifiedConfiguration.configs.Reverse(item, 2);
                }
                _allowSave = false;
                _ignoreLoad = true;

                lstServers.SelectedIndex = _oldSelectedIndex = index + 1;

                LoadConfiguration(_modifiedConfiguration);
                lstServers.ClearSelected();
                foreach (int item in rev_items)
                {
                    if (item != index)
                        lstServers.SelectedIndex = _oldSelectedIndex = item + 1;
                }

                lstServers.SelectedIndex = _oldSelectedIndex = index + 1;

                _ignoreLoad = false;
                _allowSave = true;
                LoadSelectedServer();
            }
            UpdateServersListBoxTopIndex(2);
        }

        private void TextBox_Enter(object sender, EventArgs e)
        {
            int change = SaveOldSelectedServer();
            if (change == 1)
            {
                LoadConfiguration(_modifiedConfiguration);
            }
            LoadSelectedServer();
            ((TextBox)sender).SelectAll();
        }

        private void TextBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                ((TextBox)sender).SelectAll();
            }
        }

        private void LinkUpdate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(updateChecker.LatestVersionURL);
        }

        private void PasswordLabel_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPassword.Checked)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void UpdateObfsTextbox()
        {
            try
            {
                Obfs.ObfsBase obfs = (Obfs.ObfsBase)Obfs.ObfsFactory.GetObfs(cmbObfs.Text);
                int[] properties = obfs.GetObfs()[cmbObfs.Text];
                if (properties[2] > 0)
                {
                    txtObfsParam.Enabled = true;
                }
                else
                {
                    txtObfsParam.Enabled = false;
                }
            }
            catch
            {
                txtObfsParam.Enabled = true;
            }
        }

        private void ObfsCombo_TextChanged(object sender, EventArgs e)
        {
            UpdateObfsTextbox();
        }

        private void checkSSRLink_CheckedChanged(object sender, EventArgs e)
        {
            int change = SaveOldSelectedServer();
            if (change == 1)
            {
                LoadConfiguration(_modifiedConfiguration);
            }
            LoadSelectedServer();
        }

        private void checkAdvSetting_CheckedChanged(object sender, EventArgs e)
        {
            Update_SSR_controls_Visable();
        }

        private void Update_SSR_controls_Visable()
        {
            SuspendLayout();
            if (chkAdvSetting.Checked)
            {
                lblUDPPort.Visible = true;
                nudUdpPort.Visible = true;
                //TCPoverUDPLabel.Visible = true;
                //CheckTCPoverUDP.Visible = true;
            }
            else
            {
                lblUDPPort.Visible = false;
                nudUdpPort.Visible = false;
                //TCPoverUDPLabel.Visible = false;
                //CheckTCPoverUDP.Visible = false;
            }
            if (chkAdvSetting.Checked)
            {
                lblUdpOverTcp.Visible = true;
                chkUdpOverTcp.Visible = true;
            }
            else
            {
                lblUdpOverTcp.Visible = false;
                chkUdpOverTcp.Visible = false;
            }
            ResumeLayout();
        }

        private void IPLabel_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIP.Checked)
            {
                txtIP.UseSystemPasswordChar = false;
            }
            else
            {
                txtIP.UseSystemPasswordChar = true;
            }
        }
    }
}
