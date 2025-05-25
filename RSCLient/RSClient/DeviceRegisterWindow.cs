using MaterialSkin.Controls;
using System;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Globalization;
using System.Net;
using System.Resources;
using System.Threading;
using System.Windows.Forms;

namespace RSClient
{
    public partial class DeviceRegisterWindow : MaterialForm
    {
        CultureInfo cultureInfo;
        User CurrentUser;
        public DeviceRegisterWindow(User user)
        {
            InitializeComponent();
            CurrentUser = user;
            string SystemLanguage = System.Globalization.CultureInfo.CurrentCulture.Name;
            if (SystemLanguage == "tr-TR")
            {
                cultureInfo = new CultureInfo("tr-TR");
            }
            else
            {
                cultureInfo = new CultureInfo("en-US");
            }
            SetGuiLanguage();
        }

        string GetLanguagTxt(string Key)
        {
            ResourceManager resourceManager = new ResourceManager("RSClient.Languages.Localization", typeof(MainWindow).Assembly);
            return resourceManager.GetString(Key, cultureInfo);
        }

        void SetGuiLanguage()
        {
            this.Text = GetLanguagTxt("txtDeviceRegister") + " | Remote System";
            lblHwid.Text = GetLanguagTxt("txtHwid");
            btnSave.Text = GetLanguagTxt("txtSave");
        }

        MaterialSnackBar msgDialogLoad;
        private void DeviceRegisterWindow_Load(object sender, EventArgs e)
        {
            txtHwid.Text = Library.GetHWID();
            msgDialogLoad = new MaterialSnackBar(GetLanguagTxt("txtError6"), GetLanguagTxt("txtOk"), true);
            msgDialogLoad.Show(this);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
            msgDialogLoad.Hide();
            Thread.Sleep(100);
            progressBar.Value = 10;
            {
                var msgDialog = new MaterialSnackBar(GetLanguagTxt("txtInfo1"), GetLanguagTxt("txtOk"), true);
                msgDialog.Show(this);
            }
            using (var webClient = new WebClient())
            {
                var Values = new NameValueCollection
                {
                    { "Hwid", Cryptography.EncryptData(Library.GetHWID()) },
                    { "HardwareInfo", Cryptography.EncryptData(new HardwareInfo(new OpenHardwareMonitor.Hardware.Computer()).Data()) },
                    { "ClientInfo", Cryptography.EncryptData(new ClientInfo().Data()) },
                    { "UserID", Cryptography.EncryptData(CurrentUser.UserID) },
                    { "Token", Cryptography.EncryptData(CurrentUser.Token) },
                };

                progressBar.Value = 50;
                var Response = webClient.UploadValues(Config.ApiPath + "?operation=adddevice", Values);
                progressBar.Value = 100;
                var ResponseData = System.Text.Encoding.UTF8.GetString(Response);
                if (ResponseData == "Error: Token not approved!" || ResponseData == "Error: Unauthorized access!")
                {
                    var msgDialog = new MaterialDialog(this, GetLanguagTxt("txtStop"), GetLanguagTxt("txtError4"), GetLanguagTxt("txtOk"));
                    msgDialog.ShowDialog(this);
                    btnSave.Enabled = true;
                    return;
                }
                else if (ResponseData == "Error: The device could not be registered!")
                {
                    var msgDialog = new MaterialDialog(this, GetLanguagTxt("txtStop"), GetLanguagTxt("txtError7"), GetLanguagTxt("txtOk"));
                    msgDialog.ShowDialog(this);
                    btnSave.Enabled = true;
                    return;
                }
                else if (ResponseData == "OK")
                {
                    var msgDialog = new MaterialDialog(this, GetLanguagTxt("txtInfo3"), GetLanguagTxt("txtInfo2"), GetLanguagTxt("txtOk"));
                    msgDialog.ShowDialog(this);
                    Application.Exit();
                }
                else
                {
                    var msgDialog = new MaterialDialog(this, GetLanguagTxt("txtStop"), GetLanguagTxt("txtError7"), GetLanguagTxt("txtOk"));
                    msgDialog.ShowDialog(this);
                    btnSave.Enabled = true;
                    return;
                }
            }
        }

        private void DeviceRegisterWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            Process.GetProcessById(Process.GetCurrentProcess().Id).Kill();
        }
    }
}