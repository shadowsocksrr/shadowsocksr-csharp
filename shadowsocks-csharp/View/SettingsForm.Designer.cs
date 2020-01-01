namespace Shadowsocks.View
{
    partial class SettingsForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.chkLogEnable = new System.Windows.Forms.CheckBox();
            this.lblLogging = new System.Windows.Forms.Label();
            this.lblBalance = new System.Windows.Forms.Label();
            this.cmbBalance = new System.Windows.Forms.ComboBox();
            this.chkAutoBan = new System.Windows.Forms.CheckBox();
            this.chkBalance = new System.Windows.Forms.CheckBox();
            this.chkAutoStartup = new System.Windows.Forms.CheckBox();
            this.chkBalanceInGroup = new System.Windows.Forms.CheckBox();
            this.chkSwitchAutoCloseAll = new System.Windows.Forms.CheckBox();
            this.gbxSocks5Proxy = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.lblS5Password = new System.Windows.Forms.Label();
            this.lblS5Username = new System.Windows.Forms.Label();
            this.txtS5Pass = new System.Windows.Forms.TextBox();
            this.lblS5Port = new System.Windows.Forms.Label();
            this.txtS5User = new System.Windows.Forms.TextBox();
            this.lblS5Server = new System.Windows.Forms.Label();
            this.nudS5Port = new System.Windows.Forms.NumericUpDown();
            this.txtS5Server = new System.Windows.Forms.TextBox();
            this.cmbProxyType = new System.Windows.Forms.ComboBox();
            this.chkSockProxy = new System.Windows.Forms.CheckBox();
            this.chkPacProxy = new System.Windows.Forms.CheckBox();
            this.lblUserAgent = new System.Windows.Forms.Label();
            this.txtUserAgent = new System.Windows.Forms.TextBox();
            this.gbxListen = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.txtAuthPass = new System.Windows.Forms.TextBox();
            this.lblAuthPass = new System.Windows.Forms.Label();
            this.txtAuthUser = new System.Windows.Forms.TextBox();
            this.lblAuthUser = new System.Windows.Forms.Label();
            this.checkShareOverLan = new System.Windows.Forms.CheckBox();
            this.nudProxyPort = new System.Windows.Forms.NumericUpDown();
            this.lblProxyPort = new System.Windows.Forms.Label();
            this.tableLayoutPanel10 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.lblReconnect = new System.Windows.Forms.Label();
            this.nudReconnect = new System.Windows.Forms.NumericUpDown();
            this.lblTtl = new System.Windows.Forms.Label();
            this.nudTTL = new System.Windows.Forms.NumericUpDown();
            this.lblTimeout = new System.Windows.Forms.Label();
            this.nudTimeout = new System.Windows.Forms.NumericUpDown();
            this.txtDNS = new System.Windows.Forms.TextBox();
            this.btnDefault = new System.Windows.Forms.Button();
            this.lblDns = new System.Windows.Forms.Label();
            this.lblLocalDns = new System.Windows.Forms.Label();
            this.txtLocalDNS = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.gbxSocks5Proxy.SuspendLayout();
            this.tableLayoutPanel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudS5Port)).BeginInit();
            this.gbxListen.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudProxyPort)).BeginInit();
            this.tableLayoutPanel10.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudReconnect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTTL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTimeout)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.gbxSocks5Proxy, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.gbxListen, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel10, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 1, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(15, 16);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(599, 451);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.chkLogEnable, 1, 6);
            this.tableLayoutPanel2.Controls.Add(this.lblLogging, 0, 6);
            this.tableLayoutPanel2.Controls.Add(this.lblBalance, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.cmbBalance, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.chkAutoBan, 1, 5);
            this.tableLayoutPanel2.Controls.Add(this.chkBalance, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.chkAutoStartup, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.chkBalanceInGroup, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.chkSwitchAutoCloseAll, 1, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(346, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 7;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(245, 127);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // chkLogEnable
            // 
            this.chkLogEnable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.chkLogEnable.AutoSize = true;
            this.chkLogEnable.Location = new System.Drawing.Point(56, 111);
            this.chkLogEnable.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.chkLogEnable.Name = "chkLogEnable";
            this.chkLogEnable.Size = new System.Drawing.Size(186, 16);
            this.chkLogEnable.TabIndex = 18;
            this.chkLogEnable.Text = "Enable Log";
            this.chkLogEnable.UseVisualStyleBackColor = true;
            // 
            // lblLogging
            // 
            this.lblLogging.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblLogging.AutoSize = true;
            this.lblLogging.Location = new System.Drawing.Point(3, 112);
            this.lblLogging.Margin = new System.Windows.Forms.Padding(3, 0, 3, 1);
            this.lblLogging.Name = "lblLogging";
            this.lblLogging.Size = new System.Drawing.Size(47, 12);
            this.lblLogging.TabIndex = 17;
            this.lblLogging.Text = "Logging";
            this.lblLogging.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBalance
            // 
            this.lblBalance.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblBalance.AutoSize = true;
            this.lblBalance.Location = new System.Drawing.Point(3, 56);
            this.lblBalance.Margin = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(47, 12);
            this.lblBalance.TabIndex = 12;
            this.lblBalance.Text = "Balance";
            this.lblBalance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbBalance
            // 
            this.cmbBalance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbBalance.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBalance.FormattingEnabled = true;
            this.cmbBalance.Items.AddRange(new object[] {
            "OneByOne",
            "Random",
            "FastDownloadSpeed",
            "LowLatency",
            "LowException",
            "SelectedFirst",
            "Timer"});
            this.cmbBalance.Location = new System.Drawing.Point(56, 51);
            this.cmbBalance.Margin = new System.Windows.Forms.Padding(3, 3, 3, 8);
            this.cmbBalance.Name = "cmbBalance";
            this.cmbBalance.Size = new System.Drawing.Size(186, 20);
            this.cmbBalance.TabIndex = 14;
            // 
            // chkAutoBan
            // 
            this.chkAutoBan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.chkAutoBan.AutoSize = true;
            this.chkAutoBan.Location = new System.Drawing.Point(56, 95);
            this.chkAutoBan.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.chkAutoBan.Name = "chkAutoBan";
            this.chkAutoBan.Size = new System.Drawing.Size(186, 16);
            this.chkAutoBan.TabIndex = 15;
            this.chkAutoBan.Text = "AutoBan";
            this.chkAutoBan.UseVisualStyleBackColor = true;
            // 
            // chkBalance
            // 
            this.chkBalance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.chkBalance.AutoSize = true;
            this.chkBalance.Location = new System.Drawing.Point(56, 32);
            this.chkBalance.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.chkBalance.Name = "chkBalance";
            this.chkBalance.Size = new System.Drawing.Size(186, 16);
            this.chkBalance.TabIndex = 13;
            this.chkBalance.Text = "Load balance";
            this.chkBalance.UseVisualStyleBackColor = true;
            // 
            // chkAutoStartup
            // 
            this.chkAutoStartup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.chkAutoStartup.AutoSize = true;
            this.chkAutoStartup.Location = new System.Drawing.Point(56, 0);
            this.chkAutoStartup.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.chkAutoStartup.Name = "chkAutoStartup";
            this.chkAutoStartup.Size = new System.Drawing.Size(186, 16);
            this.chkAutoStartup.TabIndex = 12;
            this.chkAutoStartup.Text = "Start on Boot";
            this.chkAutoStartup.UseVisualStyleBackColor = true;
            // 
            // chkBalanceInGroup
            // 
            this.chkBalanceInGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.chkBalanceInGroup.AutoSize = true;
            this.chkBalanceInGroup.Location = new System.Drawing.Point(56, 79);
            this.chkBalanceInGroup.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.chkBalanceInGroup.Name = "chkBalanceInGroup";
            this.chkBalanceInGroup.Size = new System.Drawing.Size(186, 16);
            this.chkBalanceInGroup.TabIndex = 15;
            this.chkBalanceInGroup.Text = "Balance in group";
            this.chkBalanceInGroup.UseVisualStyleBackColor = true;
            // 
            // chkSwitchAutoCloseAll
            // 
            this.chkSwitchAutoCloseAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.chkSwitchAutoCloseAll.AutoSize = true;
            this.chkSwitchAutoCloseAll.Location = new System.Drawing.Point(56, 16);
            this.chkSwitchAutoCloseAll.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.chkSwitchAutoCloseAll.Name = "chkSwitchAutoCloseAll";
            this.chkSwitchAutoCloseAll.Size = new System.Drawing.Size(186, 16);
            this.chkSwitchAutoCloseAll.TabIndex = 16;
            this.chkSwitchAutoCloseAll.Text = "Switch auto close TCP links";
            this.chkSwitchAutoCloseAll.UseVisualStyleBackColor = true;
            // 
            // gbxSocks5Proxy
            // 
            this.gbxSocks5Proxy.AutoSize = true;
            this.gbxSocks5Proxy.Controls.Add(this.tableLayoutPanel9);
            this.gbxSocks5Proxy.Location = new System.Drawing.Point(0, 0);
            this.gbxSocks5Proxy.Margin = new System.Windows.Forms.Padding(0);
            this.gbxSocks5Proxy.Name = "gbxSocks5Proxy";
            this.gbxSocks5Proxy.Size = new System.Drawing.Size(343, 229);
            this.gbxSocks5Proxy.TabIndex = 0;
            this.gbxSocks5Proxy.TabStop = false;
            this.gbxSocks5Proxy.Text = "Remote proxy";
            // 
            // tableLayoutPanel9
            // 
            this.tableLayoutPanel9.AutoSize = true;
            this.tableLayoutPanel9.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel9.ColumnCount = 2;
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 240F));
            this.tableLayoutPanel9.Controls.Add(this.lblS5Password, 0, 5);
            this.tableLayoutPanel9.Controls.Add(this.lblS5Username, 0, 4);
            this.tableLayoutPanel9.Controls.Add(this.txtS5Pass, 1, 5);
            this.tableLayoutPanel9.Controls.Add(this.lblS5Port, 0, 3);
            this.tableLayoutPanel9.Controls.Add(this.txtS5User, 1, 4);
            this.tableLayoutPanel9.Controls.Add(this.lblS5Server, 0, 2);
            this.tableLayoutPanel9.Controls.Add(this.nudS5Port, 1, 3);
            this.tableLayoutPanel9.Controls.Add(this.txtS5Server, 1, 2);
            this.tableLayoutPanel9.Controls.Add(this.cmbProxyType, 1, 1);
            this.tableLayoutPanel9.Controls.Add(this.chkSockProxy, 0, 0);
            this.tableLayoutPanel9.Controls.Add(this.chkPacProxy, 1, 0);
            this.tableLayoutPanel9.Controls.Add(this.lblUserAgent, 0, 6);
            this.tableLayoutPanel9.Controls.Add(this.txtUserAgent, 1, 6);
            this.tableLayoutPanel9.Location = new System.Drawing.Point(15, 25);
            this.tableLayoutPanel9.Margin = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            this.tableLayoutPanel9.RowCount = 7;
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel9.Size = new System.Drawing.Size(320, 182);
            this.tableLayoutPanel9.TabIndex = 0;
            // 
            // lblS5Password
            // 
            this.lblS5Password.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblS5Password.AutoSize = true;
            this.lblS5Password.Location = new System.Drawing.Point(24, 135);
            this.lblS5Password.Margin = new System.Windows.Forms.Padding(3);
            this.lblS5Password.Name = "lblS5Password";
            this.lblS5Password.Size = new System.Drawing.Size(53, 12);
            this.lblS5Password.TabIndex = 5;
            this.lblS5Password.Text = "Password";
            this.lblS5Password.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblS5Username
            // 
            this.lblS5Username.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblS5Username.AutoSize = true;
            this.lblS5Username.Location = new System.Drawing.Point(24, 108);
            this.lblS5Username.Margin = new System.Windows.Forms.Padding(3);
            this.lblS5Username.Name = "lblS5Username";
            this.lblS5Username.Size = new System.Drawing.Size(53, 12);
            this.lblS5Username.TabIndex = 4;
            this.lblS5Username.Text = "Username";
            this.lblS5Username.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtS5Pass
            // 
            this.txtS5Pass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtS5Pass.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtS5Pass.Location = new System.Drawing.Point(83, 131);
            this.txtS5Pass.Name = "txtS5Pass";
            this.txtS5Pass.Size = new System.Drawing.Size(234, 21);
            this.txtS5Pass.TabIndex = 6;
            // 
            // lblS5Port
            // 
            this.lblS5Port.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblS5Port.AutoSize = true;
            this.lblS5Port.Location = new System.Drawing.Point(48, 81);
            this.lblS5Port.Margin = new System.Windows.Forms.Padding(3);
            this.lblS5Port.Name = "lblS5Port";
            this.lblS5Port.Size = new System.Drawing.Size(29, 12);
            this.lblS5Port.TabIndex = 1;
            this.lblS5Port.Text = "Port";
            this.lblS5Port.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtS5User
            // 
            this.txtS5User.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtS5User.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtS5User.Location = new System.Drawing.Point(83, 104);
            this.txtS5User.Name = "txtS5User";
            this.txtS5User.Size = new System.Drawing.Size(234, 21);
            this.txtS5User.TabIndex = 5;
            // 
            // lblS5Server
            // 
            this.lblS5Server.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblS5Server.AutoSize = true;
            this.lblS5Server.Location = new System.Drawing.Point(18, 54);
            this.lblS5Server.Margin = new System.Windows.Forms.Padding(3);
            this.lblS5Server.Name = "lblS5Server";
            this.lblS5Server.Size = new System.Drawing.Size(59, 12);
            this.lblS5Server.TabIndex = 0;
            this.lblS5Server.Text = "Server IP";
            this.lblS5Server.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nudS5Port
            // 
            this.nudS5Port.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.nudS5Port.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.nudS5Port.Location = new System.Drawing.Point(83, 77);
            this.nudS5Port.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nudS5Port.Name = "nudS5Port";
            this.nudS5Port.Size = new System.Drawing.Size(234, 21);
            this.nudS5Port.TabIndex = 4;
            // 
            // txtS5Server
            // 
            this.txtS5Server.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtS5Server.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtS5Server.Location = new System.Drawing.Point(83, 50);
            this.txtS5Server.Name = "txtS5Server";
            this.txtS5Server.Size = new System.Drawing.Size(234, 21);
            this.txtS5Server.TabIndex = 3;
            // 
            // cmbProxyType
            // 
            this.cmbProxyType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbProxyType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProxyType.FormattingEnabled = true;
            this.cmbProxyType.Items.AddRange(new object[] {
            "Socks5(support UDP)",
            "Http tunnel",
            "TCP Port tunnel"});
            this.cmbProxyType.Location = new System.Drawing.Point(83, 19);
            this.cmbProxyType.Margin = new System.Windows.Forms.Padding(3, 3, 3, 8);
            this.cmbProxyType.Name = "cmbProxyType";
            this.cmbProxyType.Size = new System.Drawing.Size(234, 20);
            this.cmbProxyType.TabIndex = 2;
            // 
            // chkSockProxy
            // 
            this.chkSockProxy.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.chkSockProxy.AutoSize = true;
            this.chkSockProxy.Location = new System.Drawing.Point(5, 0);
            this.chkSockProxy.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.chkSockProxy.Name = "chkSockProxy";
            this.chkSockProxy.Size = new System.Drawing.Size(72, 16);
            this.chkSockProxy.TabIndex = 0;
            this.chkSockProxy.Text = "Proxy On";
            this.chkSockProxy.UseVisualStyleBackColor = true;
            // 
            // chkPacProxy
            // 
            this.chkPacProxy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.chkPacProxy.AutoSize = true;
            this.chkPacProxy.Location = new System.Drawing.Point(83, 0);
            this.chkPacProxy.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.chkPacProxy.Name = "chkPacProxy";
            this.chkPacProxy.Size = new System.Drawing.Size(234, 16);
            this.chkPacProxy.TabIndex = 1;
            this.chkPacProxy.Text = "PAC \"direct\" return this proxy";
            this.chkPacProxy.UseVisualStyleBackColor = true;
            // 
            // lblUserAgent
            // 
            this.lblUserAgent.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblUserAgent.AutoSize = true;
            this.lblUserAgent.Location = new System.Drawing.Point(12, 162);
            this.lblUserAgent.Margin = new System.Windows.Forms.Padding(3);
            this.lblUserAgent.Name = "lblUserAgent";
            this.lblUserAgent.Size = new System.Drawing.Size(65, 12);
            this.lblUserAgent.TabIndex = 5;
            this.lblUserAgent.Text = "User Agent";
            this.lblUserAgent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtUserAgent
            // 
            this.txtUserAgent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUserAgent.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtUserAgent.Location = new System.Drawing.Point(83, 158);
            this.txtUserAgent.Name = "txtUserAgent";
            this.txtUserAgent.Size = new System.Drawing.Size(234, 21);
            this.txtUserAgent.TabIndex = 7;
            // 
            // gbxListen
            // 
            this.gbxListen.AutoSize = true;
            this.gbxListen.Controls.Add(this.tableLayoutPanel4);
            this.gbxListen.Location = new System.Drawing.Point(0, 229);
            this.gbxListen.Margin = new System.Windows.Forms.Padding(0);
            this.gbxListen.Name = "gbxListen";
            this.gbxListen.Size = new System.Drawing.Size(343, 144);
            this.gbxListen.TabIndex = 1;
            this.gbxListen.TabStop = false;
            this.gbxListen.Text = "Local proxy";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.AutoSize = true;
            this.tableLayoutPanel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 240F));
            this.tableLayoutPanel4.Controls.Add(this.txtAuthPass, 1, 3);
            this.tableLayoutPanel4.Controls.Add(this.lblAuthPass, 0, 3);
            this.tableLayoutPanel4.Controls.Add(this.txtAuthUser, 1, 2);
            this.tableLayoutPanel4.Controls.Add(this.lblAuthUser, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.checkShareOverLan, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.nudProxyPort, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.lblProxyPort, 0, 1);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(15, 25);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 4;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.Size = new System.Drawing.Size(320, 97);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // txtAuthPass
            // 
            this.txtAuthPass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAuthPass.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtAuthPass.Location = new System.Drawing.Point(83, 73);
            this.txtAuthPass.Name = "txtAuthPass";
            this.txtAuthPass.Size = new System.Drawing.Size(234, 21);
            this.txtAuthPass.TabIndex = 11;
            // 
            // lblAuthPass
            // 
            this.lblAuthPass.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblAuthPass.AutoSize = true;
            this.lblAuthPass.Location = new System.Drawing.Point(24, 77);
            this.lblAuthPass.Margin = new System.Windows.Forms.Padding(3);
            this.lblAuthPass.Name = "lblAuthPass";
            this.lblAuthPass.Size = new System.Drawing.Size(53, 12);
            this.lblAuthPass.TabIndex = 8;
            this.lblAuthPass.Text = "Password";
            this.lblAuthPass.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtAuthUser
            // 
            this.txtAuthUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAuthUser.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtAuthUser.Location = new System.Drawing.Point(83, 46);
            this.txtAuthUser.Name = "txtAuthUser";
            this.txtAuthUser.Size = new System.Drawing.Size(234, 21);
            this.txtAuthUser.TabIndex = 10;
            // 
            // lblAuthUser
            // 
            this.lblAuthUser.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblAuthUser.AutoSize = true;
            this.lblAuthUser.Location = new System.Drawing.Point(24, 50);
            this.lblAuthUser.Margin = new System.Windows.Forms.Padding(3);
            this.lblAuthUser.Name = "lblAuthUser";
            this.lblAuthUser.Size = new System.Drawing.Size(53, 12);
            this.lblAuthUser.TabIndex = 5;
            this.lblAuthUser.Text = "Username";
            this.lblAuthUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // checkShareOverLan
            // 
            this.checkShareOverLan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.checkShareOverLan.AutoSize = true;
            this.checkShareOverLan.Location = new System.Drawing.Point(83, 0);
            this.checkShareOverLan.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.checkShareOverLan.Name = "checkShareOverLan";
            this.checkShareOverLan.Size = new System.Drawing.Size(234, 16);
            this.checkShareOverLan.TabIndex = 8;
            this.checkShareOverLan.Text = "Allow Clients from LAN";
            this.checkShareOverLan.UseVisualStyleBackColor = true;
            // 
            // nudProxyPort
            // 
            this.nudProxyPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.nudProxyPort.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.nudProxyPort.Location = new System.Drawing.Point(83, 19);
            this.nudProxyPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nudProxyPort.Name = "nudProxyPort";
            this.nudProxyPort.Size = new System.Drawing.Size(234, 21);
            this.nudProxyPort.TabIndex = 9;
            // 
            // lblProxyPort
            // 
            this.lblProxyPort.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblProxyPort.AutoSize = true;
            this.lblProxyPort.Location = new System.Drawing.Point(48, 23);
            this.lblProxyPort.Margin = new System.Windows.Forms.Padding(3);
            this.lblProxyPort.Name = "lblProxyPort";
            this.lblProxyPort.Size = new System.Drawing.Size(29, 12);
            this.lblProxyPort.TabIndex = 3;
            this.lblProxyPort.Text = "Port";
            this.lblProxyPort.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel10
            // 
            this.tableLayoutPanel10.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel10.AutoSize = true;
            this.tableLayoutPanel10.ColumnCount = 1;
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel10.Controls.Add(this.tableLayoutPanel5, 1, 1);
            this.tableLayoutPanel10.Location = new System.Drawing.Point(346, 232);
            this.tableLayoutPanel10.Name = "tableLayoutPanel10";
            this.tableLayoutPanel10.RowCount = 3;
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel10.Size = new System.Drawing.Size(250, 166);
            this.tableLayoutPanel10.TabIndex = 3;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.AutoSize = true;
            this.tableLayoutPanel5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel5.Controls.Add(this.lblReconnect, 0, 4);
            this.tableLayoutPanel5.Controls.Add(this.nudReconnect, 1, 4);
            this.tableLayoutPanel5.Controls.Add(this.lblTtl, 0, 6);
            this.tableLayoutPanel5.Controls.Add(this.nudTTL, 1, 6);
            this.tableLayoutPanel5.Controls.Add(this.lblTimeout, 0, 5);
            this.tableLayoutPanel5.Controls.Add(this.nudTimeout, 1, 5);
            this.tableLayoutPanel5.Controls.Add(this.txtDNS, 1, 1);
            this.tableLayoutPanel5.Controls.Add(this.btnDefault, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.lblDns, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.lblLocalDns, 0, 2);
            this.tableLayoutPanel5.Controls.Add(this.txtLocalDNS, 1, 2);
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 7;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.Size = new System.Drawing.Size(250, 166);
            this.tableLayoutPanel5.TabIndex = 3;
            // 
            // lblReconnect
            // 
            this.lblReconnect.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblReconnect.AutoSize = true;
            this.lblReconnect.Location = new System.Drawing.Point(38, 92);
            this.lblReconnect.Margin = new System.Windows.Forms.Padding(3);
            this.lblReconnect.Name = "lblReconnect";
            this.lblReconnect.Size = new System.Drawing.Size(59, 12);
            this.lblReconnect.TabIndex = 3;
            this.lblReconnect.Text = "Reconnect";
            this.lblReconnect.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nudReconnect
            // 
            this.nudReconnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.nudReconnect.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.nudReconnect.Location = new System.Drawing.Point(103, 88);
            this.nudReconnect.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudReconnect.Name = "nudReconnect";
            this.nudReconnect.Size = new System.Drawing.Size(144, 21);
            this.nudReconnect.TabIndex = 18;
            // 
            // lblTtl
            // 
            this.lblTtl.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblTtl.AutoSize = true;
            this.lblTtl.Location = new System.Drawing.Point(74, 146);
            this.lblTtl.Margin = new System.Windows.Forms.Padding(3);
            this.lblTtl.Name = "lblTtl";
            this.lblTtl.Size = new System.Drawing.Size(23, 12);
            this.lblTtl.TabIndex = 3;
            this.lblTtl.Text = "TTL";
            this.lblTtl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nudTTL
            // 
            this.nudTTL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.nudTTL.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.nudTTL.Location = new System.Drawing.Point(103, 142);
            this.nudTTL.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.nudTTL.Name = "nudTTL";
            this.nudTTL.Size = new System.Drawing.Size(144, 21);
            this.nudTTL.TabIndex = 20;
            // 
            // lblTimeout
            // 
            this.lblTimeout.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblTimeout.AutoSize = true;
            this.lblTimeout.Location = new System.Drawing.Point(8, 119);
            this.lblTimeout.Margin = new System.Windows.Forms.Padding(3);
            this.lblTimeout.Name = "lblTimeout";
            this.lblTimeout.Size = new System.Drawing.Size(89, 12);
            this.lblTimeout.TabIndex = 3;
            this.lblTimeout.Text = "ConnectTimeout";
            this.lblTimeout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nudTimeout
            // 
            this.nudTimeout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.nudTimeout.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.nudTimeout.Location = new System.Drawing.Point(103, 115);
            this.nudTimeout.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.nudTimeout.Name = "nudTimeout";
            this.nudTimeout.Size = new System.Drawing.Size(144, 21);
            this.nudTimeout.TabIndex = 19;
            // 
            // txtDNS
            // 
            this.txtDNS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDNS.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtDNS.Location = new System.Drawing.Point(103, 34);
            this.txtDNS.MaxLength = 0;
            this.txtDNS.Name = "txtDNS";
            this.txtDNS.Size = new System.Drawing.Size(144, 21);
            this.txtDNS.TabIndex = 17;
            this.txtDNS.WordWrap = false;
            // 
            // btnDefault
            // 
            this.btnDefault.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDefault.Location = new System.Drawing.Point(103, 3);
            this.btnDefault.Name = "btnDefault";
            this.btnDefault.Size = new System.Drawing.Size(144, 25);
            this.btnDefault.TabIndex = 16;
            this.btnDefault.Text = "Set Default";
            this.btnDefault.UseVisualStyleBackColor = true;
            this.btnDefault.Click += new System.EventHandler(this.buttonDefault_Click);
            // 
            // lblDns
            // 
            this.lblDns.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblDns.AutoSize = true;
            this.lblDns.Location = new System.Drawing.Point(74, 38);
            this.lblDns.Margin = new System.Windows.Forms.Padding(3);
            this.lblDns.Name = "lblDns";
            this.lblDns.Size = new System.Drawing.Size(23, 12);
            this.lblDns.TabIndex = 3;
            this.lblDns.Text = "DNS";
            this.lblDns.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLocalDns
            // 
            this.lblLocalDns.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblLocalDns.AutoSize = true;
            this.lblLocalDns.Location = new System.Drawing.Point(38, 65);
            this.lblLocalDns.Margin = new System.Windows.Forms.Padding(3);
            this.lblLocalDns.Name = "lblLocalDns";
            this.lblLocalDns.Size = new System.Drawing.Size(59, 12);
            this.lblLocalDns.TabIndex = 3;
            this.lblLocalDns.Text = "Local DNS";
            this.lblLocalDns.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtLocalDNS
            // 
            this.txtLocalDNS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLocalDNS.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtLocalDNS.Location = new System.Drawing.Point(103, 61);
            this.txtLocalDNS.MaxLength = 0;
            this.txtLocalDNS.Name = "txtLocalDNS";
            this.txtLocalDNS.Size = new System.Drawing.Size(144, 21);
            this.txtLocalDNS.TabIndex = 17;
            this.txtLocalDNS.WordWrap = false;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel3.Controls.Add(this.btnCancel, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnOK, 0, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(413, 406);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.Size = new System.Drawing.Size(186, 45);
            this.tableLayoutPanel3.TabIndex = 14;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCancel.Location = new System.Drawing.Point(96, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(87, 39);
            this.btnCancel.TabIndex = 22;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnOK.Location = new System.Drawing.Point(3, 3);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(87, 39);
            this.btnOK.TabIndex = 21;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(728, 513);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.Padding = new System.Windows.Forms.Padding(12, 13, 12, 13);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SettingsForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SettingsForm_FormClosed);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.gbxSocks5Proxy.ResumeLayout(false);
            this.gbxSocks5Proxy.PerformLayout();
            this.tableLayoutPanel9.ResumeLayout(false);
            this.tableLayoutPanel9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudS5Port)).EndInit();
            this.gbxListen.ResumeLayout(false);
            this.gbxListen.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudProxyPort)).EndInit();
            this.tableLayoutPanel10.ResumeLayout(false);
            this.tableLayoutPanel10.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudReconnect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTTL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTimeout)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox gbxSocks5Proxy;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
        private System.Windows.Forms.TextBox txtS5Pass;
        private System.Windows.Forms.TextBox txtS5User;
        private System.Windows.Forms.Label lblS5Password;
        private System.Windows.Forms.Label lblS5Server;
        private System.Windows.Forms.Label lblS5Port;
        private System.Windows.Forms.TextBox txtS5Server;
        private System.Windows.Forms.NumericUpDown nudS5Port;
        private System.Windows.Forms.Label lblS5Username;
        private System.Windows.Forms.CheckBox chkSockProxy;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel10;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.NumericUpDown nudProxyPort;
        private System.Windows.Forms.Label lblProxyPort;
        private System.Windows.Forms.Label lblReconnect;
        private System.Windows.Forms.NumericUpDown nudReconnect;
        private System.Windows.Forms.Label lblTtl;
        private System.Windows.Forms.NumericUpDown nudTTL;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.ComboBox cmbBalance;
        private System.Windows.Forms.CheckBox chkAutoBan;
        private System.Windows.Forms.CheckBox chkBalance;
        private System.Windows.Forms.CheckBox chkAutoStartup;
        private System.Windows.Forms.CheckBox checkShareOverLan;
        private System.Windows.Forms.ComboBox cmbProxyType;
        private System.Windows.Forms.GroupBox gbxListen;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TextBox txtAuthPass;
        private System.Windows.Forms.Label lblAuthPass;
        private System.Windows.Forms.TextBox txtAuthUser;
        private System.Windows.Forms.Label lblAuthUser;
        private System.Windows.Forms.CheckBox chkPacProxy;
        private System.Windows.Forms.Label lblUserAgent;
        private System.Windows.Forms.TextBox txtUserAgent;
        private System.Windows.Forms.Label lblDns;
        private System.Windows.Forms.TextBox txtDNS;
        private System.Windows.Forms.Label lblTimeout;
        private System.Windows.Forms.NumericUpDown nudTimeout;
        private System.Windows.Forms.Button btnDefault;
        private System.Windows.Forms.CheckBox chkBalanceInGroup;
        private System.Windows.Forms.CheckBox chkSwitchAutoCloseAll;
        private System.Windows.Forms.Label lblLocalDns;
        private System.Windows.Forms.TextBox txtLocalDNS;
        private System.Windows.Forms.CheckBox chkLogEnable;
        private System.Windows.Forms.Label lblLogging;
    }
}