namespace RSClient
{
    partial class DeviceRegisterWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeviceRegisterWindow));
            this.txtHwid = new MaterialSkin.Controls.MaterialMaskedTextBox();
            this.btnSave = new MaterialSkin.Controls.MaterialButton();
            this.iconDeviceRegister = new System.Windows.Forms.PictureBox();
            this.lblHwid = new MaterialSkin.Controls.MaterialLabel();
            this.progressBar = new MaterialSkin.Controls.MaterialProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.iconDeviceRegister)).BeginInit();
            this.SuspendLayout();
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
            this.txtHwid.Location = new System.Drawing.Point(172, 295);
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
            this.txtHwid.Size = new System.Drawing.Size(502, 48);
            this.txtHwid.SkipLiterals = true;
            this.txtHwid.TabIndex = 9;
            this.txtHwid.TabStop = false;
            this.txtHwid.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtHwid.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals;
            this.txtHwid.TrailingIcon = null;
            this.txtHwid.UseSystemPasswordChar = false;
            this.txtHwid.ValidatingType = null;
            // 
            // btnSave
            // 
            this.btnSave.AutoSize = false;
            this.btnSave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSave.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnSave.Depth = 0;
            this.btnSave.HighEmphasis = true;
            this.btnSave.Icon = null;
            this.btnSave.Location = new System.Drawing.Point(515, 363);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnSave.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSave.Name = "btnSave";
            this.btnSave.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnSave.Size = new System.Drawing.Size(159, 36);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Kaydet";
            this.btnSave.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnSave.UseAccentColor = false;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // iconDeviceRegister
            // 
            this.iconDeviceRegister.Image = global::RSClient.Properties.Resources.icon_deviceregistration;
            this.iconDeviceRegister.Location = new System.Drawing.Point(373, 135);
            this.iconDeviceRegister.Name = "iconDeviceRegister";
            this.iconDeviceRegister.Size = new System.Drawing.Size(100, 100);
            this.iconDeviceRegister.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.iconDeviceRegister.TabIndex = 11;
            this.iconDeviceRegister.TabStop = false;
            // 
            // lblHwid
            // 
            this.lblHwid.AutoSize = true;
            this.lblHwid.Depth = 0;
            this.lblHwid.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblHwid.Location = new System.Drawing.Point(174, 273);
            this.lblHwid.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblHwid.Name = "lblHwid";
            this.lblHwid.Size = new System.Drawing.Size(41, 19);
            this.lblHwid.TabIndex = 12;
            this.lblHwid.Text = "Hwid:";
            // 
            // progressBar
            // 
            this.progressBar.Depth = 0;
            this.progressBar.Location = new System.Drawing.Point(172, 349);
            this.progressBar.MouseState = MaterialSkin.MouseState.HOVER;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(502, 5);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar.TabIndex = 13;
            // 
            // DeviceRegisterWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(850, 600);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.lblHwid);
            this.Controls.Add(this.iconDeviceRegister);
            this.Controls.Add(this.txtHwid);
            this.Controls.Add(this.btnSave);
            this.FormStyle = MaterialSkin.Controls.MaterialForm.FormStyles.ActionBar_48;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(850, 600);
            this.MinimumSize = new System.Drawing.Size(850, 600);
            this.Name = "DeviceRegisterWindow";
            this.Padding = new System.Windows.Forms.Padding(3, 72, 3, 3);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Remote System | Cihaz Kayıt";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DeviceRegisterWindow_FormClosing);
            this.Load += new System.EventHandler(this.DeviceRegisterWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.iconDeviceRegister)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox iconDeviceRegister;
        private MaterialSkin.Controls.MaterialMaskedTextBox txtHwid;
        private MaterialSkin.Controls.MaterialButton btnSave;
        private MaterialSkin.Controls.MaterialLabel lblHwid;
        private MaterialSkin.Controls.MaterialProgressBar progressBar;
    }
}