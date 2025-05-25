using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Resources;
using System.Windows.Forms;

namespace RSClient
{
    public partial class LoginWindow : MaterialForm
    {
        CultureInfo cultureInfo;
        User CurrentUser;
        Device CurrentDevice;
        List<Device> Devices;
        bool AutoStart = false;
        public LoginWindow(string[] args)
        {
            InitializeComponent();
            if (args.Count() > 0)
            {
                if (args[0] == "autostart")
                {
                    AutoStart = true;
                }
            }

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
            this.Text = GetLanguagTxt("txtLogin") + " | Remote System";
            txtUsername.Hint = GetLanguagTxt("txtUsername");
            txtPassword.Hint = GetLanguagTxt("txtPassword");
            checkRememberMe.Text = GetLanguagTxt("txtRememberMe");
            lblRegister.Text = GetLanguagTxt("txtDontHaveAnAccount?");
            btnLogin.Text = GetLanguagTxt("txtLogin");
        }

        private void LoginWindow_Load(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(RSClient.Properties.Settings.Default.Username) == false && String.IsNullOrEmpty(RSClient.Properties.Settings.Default.Password) == false)
            {
                if (Login(Cryptography.DecryptData(RSClient.Properties.Settings.Default.Username), Cryptography.DecryptData(RSClient.Properties.Settings.Default.Password)) == true)
                {
                    this.Hide();
                    this.WindowState = FormWindowState.Minimized;
                    this.ShowInTaskbar = false;
                    this.Visible = false;
                    LoadApp();
                }
            }
        }

        bool Login(string Username, string Password)
        {
            using (var webClient = new WebClient())
            {
                var Values = new NameValueCollection
                {
                    { "Username", Cryptography.EncryptData(Username) },
                    { "Password", Cryptography.EncryptData(Password) }
                };

                var Response = webClient.UploadValues(Config.ApiPath + "?operation=login", Values);
                var ResponseData = System.Text.Encoding.UTF8.GetString(Response);
                if (ResponseData == "Error: Username is blank" || ResponseData == "Error: Password is blank")
                {
                    var msgDialog = new MaterialDialog(this, GetLanguagTxt("txtStop"), GetLanguagTxt("txtError1"), GetLanguagTxt("txtOk"));
                    msgDialog.ShowDialog(this);
                    return false;
                }
                else if (ResponseData == "Error: Username or password is wrong!")
                {
                    var msgDialog = new MaterialDialog(this, GetLanguagTxt("txtStop"), GetLanguagTxt("txtError2"), GetLanguagTxt("txtOk"));
                    msgDialog.ShowDialog(this);
                    return false;
                }
                else if (String.IsNullOrEmpty(ResponseData) == true)
                {
                    var msgDialog = new MaterialDialog(this, GetLanguagTxt("txtStop"), GetLanguagTxt("txtError3"), GetLanguagTxt("txtOk"));
                    msgDialog.ShowDialog(this);
                    return false;
                }
                else
                {
                    string[] Data = ResponseData.Split(new char[] { '%' });
                    if (Data.Count() == 0 || Data.Length == 0)
                    {
                        var msgDialog = new MaterialDialog(this, GetLanguagTxt("txtStop"), GetLanguagTxt("txtError3"), GetLanguagTxt("txtOk"));
                        msgDialog.ShowDialog(this);
                        return false;
                    }
                    else
                    {
                        if (Data[0] == "OK")
                        {
                            CurrentUser = new User();
                            CurrentUser.UserID = Data[1];
                            CurrentUser.Username = Data[2];
                            CurrentUser.Password = Data[3];
                            CurrentUser.Email = Data[4];
                            CurrentUser.Token = Data[6];
                            return GetDevices(webClient, Data[5]);
                        }
                    }
                }
            }
            return false;
        }

        bool GetDevices(WebClient webClient, string Data)
        {
            Devices = new List<Device>();
            if (String.IsNullOrEmpty(Data) == true)
            {
                return true;
            }     
            
            string[] DeviceIDs = Data.Split(new char[] { ',' });
            for (int i = 0; i < DeviceIDs.Count(); i++)
            {
                var Values = new NameValueCollection
                {
                    { "DeviceID", Cryptography.EncryptData(DeviceIDs[i]) },
                    { "Token", Cryptography.EncryptData(CurrentUser.Token) }
                };

                var Response = webClient.UploadValues(Config.ApiPath + "?operation=getdevice", Values);
                var ResponseData = System.Text.Encoding.UTF8.GetString(Response);
                if (ResponseData == "Error: Unauthorized access!")
                {
                    var msgDialog = new MaterialDialog(this, GetLanguagTxt("txtStop"), GetLanguagTxt("txtError4"), GetLanguagTxt("txtOk"));
                    msgDialog.ShowDialog(this);
                    return false;
                }
                else
                {
                    string[] DeviceData = ResponseData.Split(new char[] { '%' });
                    if (DeviceData.Count() == 0 || DeviceData.Length == 0)
                    {
                        var msgDialog = new MaterialDialog(this, GetLanguagTxt("txtStop"), GetLanguagTxt("txtError3"), GetLanguagTxt("txtOk"));
                        msgDialog.ShowDialog(this);
                        return false;
                    }
                    else
                    {
                        if (DeviceData[0] == "OK")
                        {
                            var Device = new Device();
                            Device.ID = DeviceData[1];
                            Device.UserID = DeviceData[2];
                            Device.Hwid = DeviceData[3];
                            Devices.Add(Device);
                        }
                    }
                }
            }
            return true;
        }

        void LoadApp()
        {
            bool CheckThisDevice = false;
            string MyHwid = Library.GetHWID();
            for (int i = 0; i < Devices.Count(); i++)
            {
                if (Devices[i].Hwid == MyHwid)
                {
                    CheckThisDevice = true;
                    CurrentDevice = Devices[i];
                    break;
                }
            }

            if (Devices.Count() == 0 || CheckThisDevice == false)
            {
                var deviceRegisterWindow = new DeviceRegisterWindow(CurrentUser);
                deviceRegisterWindow.Show();
                this.Hide();
            }
            else
            {
                var mainWindow = new MainWindow(CurrentDevice, CurrentUser, AutoStart);
                mainWindow.Show();
                this.Hide();
            }

            Devices.Clear();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtUsername.Text) == true || String.IsNullOrEmpty(txtPassword.Text) == true)
            {
                var msgDialog = new MaterialDialog(this, GetLanguagTxt("txtStop"), GetLanguagTxt("txtError1"), GetLanguagTxt("txtOk"));
                msgDialog.ShowDialog(this);
                return;
            }

            txtUsername.ReadOnly = true;
            txtPassword.ReadOnly = true;
            if(Login(txtUsername.Text, txtPassword.Text) == false)
            {
                txtUsername.ReadOnly = false;
                txtPassword.ReadOnly = false;
                var msgDialog = new MaterialDialog(this, GetLanguagTxt("txtStop"), GetLanguagTxt("txtError5"), GetLanguagTxt("txtOk"));
                msgDialog.ShowDialog(this);
            }
            else
            {
                if (checkRememberMe.Checked == true)
                {
                    RSClient.Properties.Settings.Default.Username = Cryptography.EncryptData(txtUsername.Text);
                    RSClient.Properties.Settings.Default.Password = Cryptography.EncryptData(txtPassword.Text);
                    RSClient.Properties.Settings.Default.Save();
                }
                else
                {
                    RSClient.Properties.Settings.Default.Username = "";
                    RSClient.Properties.Settings.Default.Password = "";
                    RSClient.Properties.Settings.Default.Save();
                }
                LoadApp();
            }
        }

        private void lblRegister_Click(object sender, EventArgs e)
        {
            Process.Start(Config.PanelPath + "register");
        }

        private void LoginWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            Process.GetProcessById(Process.GetCurrentProcess().Id).Kill();
        }
    }
}