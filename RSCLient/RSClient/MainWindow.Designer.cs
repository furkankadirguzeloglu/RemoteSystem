namespace RSClient
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.tabControl = new MaterialSkin.Controls.MaterialTabControl();
            this.tabSettings = new System.Windows.Forms.TabPage();
            this.LanguagePicker = new MaterialSkin.Controls.MaterialComboBox();
            this.sliderImageQuality = new MaterialSkin.Controls.MaterialSlider();
            this.txtScreens = new MaterialSkin.Controls.MaterialComboBox();
            this.checkScreenShare = new MaterialSkin.Controls.MaterialCheckbox();
            this.checkRunStartup = new MaterialSkin.Controls.MaterialCheckbox();
            this.checkRunBackground = new MaterialSkin.Controls.MaterialCheckbox();
            this.lblHwid = new MaterialSkin.Controls.MaterialLabel();
            this.iconHome = new System.Windows.Forms.PictureBox();
            this.txtHwid = new MaterialSkin.Controls.MaterialMaskedTextBox();
            this.switchAccess = new MaterialSkin.Controls.MaterialSwitch();
            this.tabAccount = new System.Windows.Forms.TabPage();
            this.btnLogOut = new MaterialSkin.Controls.MaterialButton();
            this.lblEmail = new MaterialSkin.Controls.MaterialLabel();
            this.lblUsername = new MaterialSkin.Controls.MaterialLabel();
            this.lblUserID = new MaterialSkin.Controls.MaterialLabel();
            this.iconAccount = new System.Windows.Forms.PictureBox();
            this.txtEmail = new MaterialSkin.Controls.MaterialMaskedTextBox();
            this.txtUsername = new MaterialSkin.Controls.MaterialMaskedTextBox();
            this.txtUserID = new MaterialSkin.Controls.MaterialMaskedTextBox();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuAccess = new System.Windows.Forms.ToolStripMenuItem();
            this.menuScreenShare = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.menuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl.SuspendLayout();
            this.tabSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconHome)).BeginInit();
            this.tabAccount.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconAccount)).BeginInit();
            this.contextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabSettings);
            this.tabControl.Controls.Add(this.tabAccount);
            this.tabControl.Depth = 0;
            this.tabControl.Location = new System.Drawing.Point(-5, 72);
            this.tabControl.MouseState = MaterialSkin.MouseState.HOVER;
            this.tabControl.Multiline = true;
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(863, 536);
            this.tabControl.TabIndex = 0;
            // 
            // tabSettings
            // 
            this.tabSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.tabSettings.Controls.Add(this.LanguagePicker);
            this.tabSettings.Controls.Add(this.sliderImageQuality);
            this.tabSettings.Controls.Add(this.txtScreens);
            this.tabSettings.Controls.Add(this.checkScreenShare);
            this.tabSettings.Controls.Add(this.checkRunStartup);
            this.tabSettings.Controls.Add(this.checkRunBackground);
            this.tabSettings.Controls.Add(this.lblHwid);
            this.tabSettings.Controls.Add(this.iconHome);
            this.tabSettings.Controls.Add(this.txtHwid);
            this.tabSettings.Controls.Add(this.switchAccess);
            this.tabSettings.Location = new System.Drawing.Point(4, 22);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.Size = new System.Drawing.Size(855, 510);
            this.tabSettings.TabIndex = 0;
            this.tabSettings.Text = "Settings";
            // 
            // LanguagePicker
            // 
            this.LanguagePicker.AutoResize = false;
            this.LanguagePicker.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.LanguagePicker.Depth = 0;
            this.LanguagePicker.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.LanguagePicker.DropDownHeight = 174;
            this.LanguagePicker.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LanguagePicker.DropDownWidth = 121;
            this.LanguagePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.LanguagePicker.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.LanguagePicker.FormattingEnabled = true;
            this.LanguagePicker.IntegralHeight = false;
            this.LanguagePicker.ItemHeight = 43;
            this.LanguagePicker.Items.AddRange(new object[] {
            "English",
            "Türkçe"});
            this.LanguagePicker.Location = new System.Drawing.Point(705, 6);
            this.LanguagePicker.MaxDropDownItems = 4;
            this.LanguagePicker.MouseState = MaterialSkin.MouseState.OUT;
            this.LanguagePicker.Name = "LanguagePicker";
            this.LanguagePicker.Size = new System.Drawing.Size(140, 49);
            this.LanguagePicker.StartIndex = 0;
            this.LanguagePicker.TabIndex = 17;
            this.LanguagePicker.SelectedIndexChanged += new System.EventHandler(this.LanguagePicker_SelectedIndexChanged);
            // 
            // sliderImageQuality
            // 
            this.sliderImageQuality.Depth = 0;
            this.sliderImageQuality.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sliderImageQuality.Location = new System.Drawing.Point(453, 179);
            this.sliderImageQuality.MouseState = MaterialSkin.MouseState.HOVER;
            this.sliderImageQuality.Name = "sliderImageQuality";
            this.sliderImageQuality.RangeMin = 10;
            this.sliderImageQuality.ShowValue = false;
            this.sliderImageQuality.Size = new System.Drawing.Size(219, 40);
            this.sliderImageQuality.TabIndex = 16;
            this.sliderImageQuality.Text = "Image Quality";
            this.sliderImageQuality.ValueMax = 100;
            this.sliderImageQuality.onValueChanged += new MaterialSkin.Controls.MaterialSlider.ValueChanged(this.sliderImageQuality_onValueChanged);
            // 
            // txtScreens
            // 
            this.txtScreens.AutoResize = false;
            this.txtScreens.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.txtScreens.Depth = 0;
            this.txtScreens.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.txtScreens.DropDownHeight = 174;
            this.txtScreens.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtScreens.DropDownWidth = 121;
            this.txtScreens.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.txtScreens.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtScreens.FormattingEnabled = true;
            this.txtScreens.Hint = "Screen";
            this.txtScreens.IntegralHeight = false;
            this.txtScreens.ItemHeight = 43;
            this.txtScreens.Location = new System.Drawing.Point(206, 222);
            this.txtScreens.MaxDropDownItems = 4;
            this.txtScreens.MouseState = MaterialSkin.MouseState.OUT;
            this.txtScreens.Name = "txtScreens";
            this.txtScreens.Size = new System.Drawing.Size(466, 49);
            this.txtScreens.StartIndex = 0;
            this.txtScreens.TabIndex = 15;
            this.txtScreens.SelectedIndexChanged += new System.EventHandler(this.txtScreens_SelectedIndexChanged);
            // 
            // checkScreenShare
            // 
            this.checkScreenShare.AutoSize = true;
            this.checkScreenShare.Depth = 0;
            this.checkScreenShare.Location = new System.Drawing.Point(198, 182);
            this.checkScreenShare.Margin = new System.Windows.Forms.Padding(0);
            this.checkScreenShare.MouseLocation = new System.Drawing.Point(-1, -1);
            this.checkScreenShare.MouseState = MaterialSkin.MouseState.HOVER;
            this.checkScreenShare.Name = "checkScreenShare";
            this.checkScreenShare.ReadOnly = false;
            this.checkScreenShare.Ripple = true;
            this.checkScreenShare.Size = new System.Drawing.Size(142, 37);
            this.checkScreenShare.TabIndex = 14;
            this.checkScreenShare.Text = "Screen Sharing";
            this.checkScreenShare.UseVisualStyleBackColor = true;
            this.checkScreenShare.CheckedChanged += new System.EventHandler(this.checkScreenShare_CheckedChanged);
            // 
            // checkRunStartup
            // 
            this.checkRunStartup.AutoSize = true;
            this.checkRunStartup.Depth = 0;
            this.checkRunStartup.Location = new System.Drawing.Point(198, 367);
            this.checkRunStartup.Margin = new System.Windows.Forms.Padding(0);
            this.checkRunStartup.MouseLocation = new System.Drawing.Point(-1, -1);
            this.checkRunStartup.MouseState = MaterialSkin.MouseState.HOVER;
            this.checkRunStartup.Name = "checkRunStartup";
            this.checkRunStartup.ReadOnly = false;
            this.checkRunStartup.Ripple = true;
            this.checkRunStartup.Size = new System.Drawing.Size(137, 37);
            this.checkRunStartup.TabIndex = 13;
            this.checkRunStartup.Text = "Run at Startup";
            this.checkRunStartup.UseVisualStyleBackColor = true;
            this.checkRunStartup.CheckedChanged += new System.EventHandler(this.checkRunStartup_CheckedChanged);
            // 
            // checkRunBackground
            // 
            this.checkRunBackground.AutoSize = true;
            this.checkRunBackground.Depth = 0;
            this.checkRunBackground.Location = new System.Drawing.Point(503, 367);
            this.checkRunBackground.Margin = new System.Windows.Forms.Padding(0);
            this.checkRunBackground.MouseLocation = new System.Drawing.Point(-1, -1);
            this.checkRunBackground.MouseState = MaterialSkin.MouseState.HOVER;
            this.checkRunBackground.Name = "checkRunBackground";
            this.checkRunBackground.ReadOnly = false;
            this.checkRunBackground.Ripple = true;
            this.checkRunBackground.Size = new System.Drawing.Size(169, 37);
            this.checkRunBackground.TabIndex = 12;
            this.checkRunBackground.Text = "Run in Background";
            this.checkRunBackground.UseVisualStyleBackColor = true;
            this.checkRunBackground.CheckedChanged += new System.EventHandler(this.checkRunBackground_CheckedChanged);
            // 
            // lblHwid
            // 
            this.lblHwid.AutoSize = true;
            this.lblHwid.Depth = 0;
            this.lblHwid.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblHwid.Location = new System.Drawing.Point(206, 285);
            this.lblHwid.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblHwid.Name = "lblHwid";
            this.lblHwid.Size = new System.Drawing.Size(41, 19);
            this.lblHwid.TabIndex = 10;
            this.lblHwid.Text = "Hwid:";
            // 
            // iconHome
            // 
            this.iconHome.Image = global::RSClient.Properties.Resources.icon_home;
            this.iconHome.Location = new System.Drawing.Point(372, 36);
            this.iconHome.Name = "iconHome";
            this.iconHome.Size = new System.Drawing.Size(100, 100);
            this.iconHome.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.iconHome.TabIndex = 9;
            this.iconHome.TabStop = false;
            // 
            // txtHwid
            // 
            this.txtHwid.AllowPromptAsInput = true;
            this.txtHwid.AnimateReadOnly = false;
            this.txtHwid.AsciiOnly = false;
            this.txtHwid.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtHwid.BeepOnError = false;
            this.txtHwid.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals;
            this.txtHwid.Depth = 0;
            this.txtHwid.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtHwid.HidePromptOnLeave = false;
            this.txtHwid.HideSelection = true;
            this.txtHwid.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Default;
            this.txtHwid.LeadingIcon = null;
            this.txtHwid.Location = new System.Drawing.Point(206, 307);
            this.txtHwid.Mask = "";
            this.txtHwid.MaxLength = 32767;
            this.txtHwid.MouseState = MaterialSkin.MouseState.OUT;
            this.txtHwid.Name = "txtHwid";
            this.txtHwid.PasswordChar = '\0';
            this.txtHwid.PrefixSuffixText = null;
            this.txtHwid.PromptChar = '_';
            this.txtHwid.ReadOnly = true;
            this.txtHwid.RejectInputOnFirstFailure = false;
            this.txtHwid.ResetOnPrompt = true;
            this.txtHwid.ResetOnSpace = true;
            this.txtHwid.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtHwid.SelectedText = "";
            this.txtHwid.SelectionLength = 0;
            this.txtHwid.SelectionStart = 0;
            this.txtHwid.ShortcutsEnabled = true;
            this.txtHwid.Size = new System.Drawing.Size(466, 48);
            this.txtHwid.SkipLiterals = true;
            this.txtHwid.TabIndex = 8;
            this.txtHwid.TabStop = false;
            this.txtHwid.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtHwid.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals;
            this.txtHwid.TrailingIcon = global::RSClient.Properties.Resources.icon_hwid;
            this.txtHwid.UseSystemPasswordChar = false;
            this.txtHwid.ValidatingType = null;
            // 
            // switchAccess
            // 
            this.switchAccess.AutoSize = true;
            this.switchAccess.Depth = 0;
            this.switchAccess.Location = new System.Drawing.Point(372, 139);
            this.switchAccess.Margin = new System.Windows.Forms.Padding(0);
            this.switchAccess.MouseLocation = new System.Drawing.Point(-1, -1);
            this.switchAccess.MouseState = MaterialSkin.MouseState.HOVER;
            this.switchAccess.Name = "switchAccess";
            this.switchAccess.Ripple = true;
            this.switchAccess.Size = new System.Drawing.Size(108, 37);
            this.switchAccess.TabIndex = 0;
            this.switchAccess.Text = "Access";
            this.switchAccess.UseVisualStyleBackColor = true;
            this.switchAccess.CheckedChanged += new System.EventHandler(this.switchAccess_CheckedChanged);
            // 
            // tabAccount
            // 
            this.tabAccount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.tabAccount.Controls.Add(this.btnLogOut);
            this.tabAccount.Controls.Add(this.lblEmail);
            this.tabAccount.Controls.Add(this.lblUsername);
            this.tabAccount.Controls.Add(this.lblUserID);
            this.tabAccount.Controls.Add(this.iconAccount);
            this.tabAccount.Controls.Add(this.txtEmail);
            this.tabAccount.Controls.Add(this.txtUsername);
            this.tabAccount.Controls.Add(this.txtUserID);
            this.tabAccount.Location = new System.Drawing.Point(4, 22);
            this.tabAccount.Name = "tabAccount";
            this.tabAccount.Padding = new System.Windows.Forms.Padding(3);
            this.tabAccount.Size = new System.Drawing.Size(855, 510);
            this.tabAccount.TabIndex = 5;
            this.tabAccount.Text = "Account";
            // 
            // btnLogOut
            // 
            this.btnLogOut.AutoSize = false;
            this.btnLogOut.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnLogOut.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnLogOut.Depth = 0;
            this.btnLogOut.HighEmphasis = true;
            this.btnLogOut.Icon = global::RSClient.Properties.Resources.icon_logout;
            this.btnLogOut.Location = new System.Drawing.Point(710, 6);
            this.btnLogOut.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnLogOut.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnLogOut.Size = new System.Drawing.Size(134, 36);
            this.btnLogOut.TabIndex = 10;
            this.btnLogOut.Text = "Logout";
            this.btnLogOut.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnLogOut.UseAccentColor = false;
            this.btnLogOut.UseVisualStyleBackColor = true;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Depth = 0;
            this.lblEmail.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblEmail.Location = new System.Drawing.Point(173, 390);
            this.lblEmail.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(45, 19);
            this.lblEmail.TabIndex = 9;
            this.lblEmail.Text = "Email:";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Depth = 0;
            this.lblUsername.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblUsername.Location = new System.Drawing.Point(173, 288);
            this.lblUsername.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(76, 19);
            this.lblUsername.TabIndex = 8;
            this.lblUsername.Text = "Username:";
            // 
            // lblUserID
            // 
            this.lblUserID.AutoSize = true;
            this.lblUserID.Depth = 0;
            this.lblUserID.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblUserID.Location = new System.Drawing.Point(173, 184);
            this.lblUserID.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.Size = new System.Drawing.Size(55, 19);
            this.lblUserID.TabIndex = 7;
            this.lblUserID.Text = "User ID:";
            // 
            // iconAccount
            // 
            this.iconAccount.Image = ((System.Drawing.Image)(resources.GetObject("iconAccount.Image")));
            this.iconAccount.Location = new System.Drawing.Point(372, 36);
            this.iconAccount.Name = "iconAccount";
            this.iconAccount.Size = new System.Drawing.Size(100, 100);
            this.iconAccount.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.iconAccount.TabIndex = 6;
            this.iconAccount.TabStop = false;
            // 
            // txtEmail
            // 
            this.txtEmail.AllowPromptAsInput = true;
            this.txtEmail.AnimateReadOnly = false;
            this.txtEmail.AsciiOnly = false;
            this.txtEmail.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtEmail.BeepOnError = false;
            this.txtEmail.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals;
            this.txtEmail.Depth = 0;
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtEmail.HidePromptOnLeave = false;
            this.txtEmail.HideSelection = true;
            this.txtEmail.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Default;
            this.txtEmail.LeadingIcon = null;
            this.txtEmail.Location = new System.Drawing.Point(171, 412);
            this.txtEmail.Mask = "";
            this.txtEmail.MaxLength = 32767;
            this.txtEmail.MouseState = MaterialSkin.MouseState.OUT;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.PasswordChar = '\0';
            this.txtEmail.PrefixSuffixText = null;
            this.txtEmail.PromptChar = '_';
            this.txtEmail.ReadOnly = true;
            this.txtEmail.RejectInputOnFirstFailure = false;
            this.txtEmail.ResetOnPrompt = true;
            this.txtEmail.ResetOnSpace = true;
            this.txtEmail.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtEmail.SelectedText = "";
            this.txtEmail.SelectionLength = 0;
            this.txtEmail.SelectionStart = 0;
            this.txtEmail.ShortcutsEnabled = true;
            this.txtEmail.Size = new System.Drawing.Size(502, 48);
            this.txtEmail.SkipLiterals = true;
            this.txtEmail.TabIndex = 5;
            this.txtEmail.TabStop = false;
            this.txtEmail.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtEmail.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals;
            this.txtEmail.TrailingIcon = global::RSClient.Properties.Resources.icon_email;
            this.txtEmail.UseSystemPasswordChar = false;
            this.txtEmail.ValidatingType = null;
            // 
            // txtUsername
            // 
            this.txtUsername.AllowPromptAsInput = true;
            this.txtUsername.AnimateReadOnly = false;
            this.txtUsername.AsciiOnly = false;
            this.txtUsername.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtUsername.BeepOnError = false;
            this.txtUsername.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals;
            this.txtUsername.Depth = 0;
            this.txtUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtUsername.HidePromptOnLeave = false;
            this.txtUsername.HideSelection = true;
            this.txtUsername.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Default;
            this.txtUsername.LeadingIcon = null;
            this.txtUsername.Location = new System.Drawing.Point(171, 310);
            this.txtUsername.Mask = "";
            this.txtUsername.MaxLength = 32767;
            this.txtUsername.MouseState = MaterialSkin.MouseState.OUT;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.PasswordChar = '\0';
            this.txtUsername.PrefixSuffixText = null;
            this.txtUsername.PromptChar = '_';
            this.txtUsername.ReadOnly = true;
            this.txtUsername.RejectInputOnFirstFailure = false;
            this.txtUsername.ResetOnPrompt = true;
            this.txtUsername.ResetOnSpace = true;
            this.txtUsername.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtUsername.SelectedText = "";
            this.txtUsername.SelectionLength = 0;
            this.txtUsername.SelectionStart = 0;
            this.txtUsername.ShortcutsEnabled = true;
            this.txtUsername.Size = new System.Drawing.Size(502, 48);
            this.txtUsername.SkipLiterals = true;
            this.txtUsername.TabIndex = 4;
            this.txtUsername.TabStop = false;
            this.txtUsername.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtUsername.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals;
            this.txtUsername.TrailingIcon = global::RSClient.Properties.Resources.icon_username;
            this.txtUsername.UseSystemPasswordChar = false;
            this.txtUsername.ValidatingType = null;
            // 
            // txtUserID
            // 
            this.txtUserID.AllowPromptAsInput = true;
            this.txtUserID.AnimateReadOnly = false;
            this.txtUserID.AsciiOnly = false;
            this.txtUserID.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtUserID.BeepOnError = false;
            this.txtUserID.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals;
            this.txtUserID.Depth = 0;
            this.txtUserID.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtUserID.HidePromptOnLeave = false;
            this.txtUserID.HideSelection = true;
            this.txtUserID.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Default;
            this.txtUserID.LeadingIcon = null;
            this.txtUserID.Location = new System.Drawing.Point(171, 209);
            this.txtUserID.Mask = "";
            this.txtUserID.MaxLength = 32767;
            this.txtUserID.MouseState = MaterialSkin.MouseState.OUT;
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.PasswordChar = '\0';
            this.txtUserID.PrefixSuffixText = null;
            this.txtUserID.PromptChar = '_';
            this.txtUserID.ReadOnly = true;
            this.txtUserID.RejectInputOnFirstFailure = false;
            this.txtUserID.ResetOnPrompt = true;
            this.txtUserID.ResetOnSpace = true;
            this.txtUserID.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtUserID.SelectedText = "";
            this.txtUserID.SelectionLength = 0;
            this.txtUserID.SelectionStart = 0;
            this.txtUserID.ShortcutsEnabled = true;
            this.txtUserID.Size = new System.Drawing.Size(502, 48);
            this.txtUserID.SkipLiterals = true;
            this.txtUserID.TabIndex = 3;
            this.txtUserID.TabStop = false;
            this.txtUserID.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtUserID.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals;
            this.txtUserID.TrailingIcon = global::RSClient.Properties.Resources.icon_userid;
            this.txtUserID.UseSystemPasswordChar = false;
            this.txtUserID.ValidatingType = null;   
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.contextMenu;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Remote System";
            this.notifyIcon.Visible = true;
            this.notifyIcon.DoubleClick += new System.EventHandler(this.notifyIcon_DoubleClick);
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAccess,
            this.menuScreenShare,
            this.menuSeparator,
            this.menuExit});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(153, 76);
            // 
            // menuAccess
            // 
            this.menuAccess.Name = "menuAccess";
            this.menuAccess.Size = new System.Drawing.Size(152, 22);
            this.menuAccess.Text = "Access";
            this.menuAccess.Click += new System.EventHandler(this.menuAccess_Click);
            // 
            // menuScreenShare
            // 
            this.menuScreenShare.Name = "menuScreenShare";
            this.menuScreenShare.Size = new System.Drawing.Size(152, 22);
            this.menuScreenShare.Text = "Screen Sharing";
            this.menuScreenShare.Click += new System.EventHandler(this.menuScreenShare_Click);
            // 
            // menuSeparator
            // 
            this.menuSeparator.Name = "menuSeparator";
            this.menuSeparator.Size = new System.Drawing.Size(149, 6);
            // 
            // menuExit
            // 
            this.menuExit.Name = "menuExit";
            this.menuExit.Size = new System.Drawing.Size(152, 22);
            this.menuExit.Text = "Exit";
            this.menuExit.Click += new System.EventHandler(this.menuExit_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(850, 600);
            this.Controls.Add(this.tabControl);
            this.DrawerTabControl = this.tabControl;
            this.FormStyle = MaterialSkin.Controls.MaterialForm.FormStyles.ActionBar_48;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(850, 600);
            this.MinimumSize = new System.Drawing.Size(850, 600);
            this.Name = "MainWindow";
            this.Padding = new System.Windows.Forms.Padding(3, 72, 3, 3);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Remote System";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.tabControl.ResumeLayout(false);
            this.tabSettings.ResumeLayout(false);
            this.tabSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconHome)).EndInit();
            this.tabAccount.ResumeLayout(false);
            this.tabAccount.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconAccount)).EndInit();
            this.contextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialTabControl tabControl;
        private System.Windows.Forms.TabPage tabSettings;
        private System.Windows.Forms.TabPage tabAccount;
        private MaterialSkin.Controls.MaterialMaskedTextBox txtEmail;
        private MaterialSkin.Controls.MaterialMaskedTextBox txtUsername;
        private MaterialSkin.Controls.MaterialMaskedTextBox txtUserID;
        private System.Windows.Forms.PictureBox iconAccount;
        private MaterialSkin.Controls.MaterialLabel lblUserID;
        private MaterialSkin.Controls.MaterialLabel lblEmail;
        private MaterialSkin.Controls.MaterialLabel lblUsername;
        private MaterialSkin.Controls.MaterialButton btnLogOut;
        private MaterialSkin.Controls.MaterialSwitch switchAccess;
        private MaterialSkin.Controls.MaterialLabel lblHwid;
        private System.Windows.Forms.PictureBox iconHome;
        private MaterialSkin.Controls.MaterialMaskedTextBox txtHwid;
        private MaterialSkin.Controls.MaterialCheckbox checkRunBackground;
        private MaterialSkin.Controls.MaterialComboBox txtScreens;
        private MaterialSkin.Controls.MaterialCheckbox checkScreenShare;
        private MaterialSkin.Controls.MaterialCheckbox checkRunStartup;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem menuAccess;
        private System.Windows.Forms.ToolStripMenuItem menuScreenShare;
        private System.Windows.Forms.ToolStripSeparator menuSeparator;
        private System.Windows.Forms.ToolStripMenuItem menuExit;
        private MaterialSkin.Controls.MaterialSlider sliderImageQuality;
        private MaterialSkin.Controls.MaterialComboBox LanguagePicker;
    }
}