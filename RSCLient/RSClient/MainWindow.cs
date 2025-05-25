using MaterialSkin.Controls;
using Microsoft.Win32;
using OpenHardwareMonitor.Hardware;
using System;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Resources;
using System.Threading;
using System.Windows.Forms;

namespace RSClient
{
    public partial class MainWindow : MaterialForm
    {
        CultureInfo cultureInfo;
        User CurrentUser;
        Device CurrentDevice;
        Screen SelectedScreen = null;

        Thread thData, thScreen, thTask, thPing;

        string DeviceID, UserID, Token;
        public MainWindow(Device device, User user, bool autostart)
        {
            InitializeComponent();
            CurrentDevice = device;
            CurrentUser = user;
            if (autostart == true)
            {
                this.Visible = false;
                this.Opacity = 0;
                this.ShowInTaskbar = false;
            }

            string Language = RSClient.Properties.Settings.Default.Language;
            if(Language == "en-US")
            {
                cultureInfo = new CultureInfo("en-US");
                LanguagePicker.SelectedIndex = 0;
            }
            else if (Language == "tr-TR")
            {
                cultureInfo = new CultureInfo("tr-TR");
                LanguagePicker.SelectedIndex = 1;
            }
            else
            {
                string SystemLanguage = System.Globalization.CultureInfo.CurrentCulture.Name;
                if(SystemLanguage == "tr-TR")
                {
                    cultureInfo = new CultureInfo("tr-TR");
                    RSClient.Properties.Settings.Default.Language = "tr-TR";
                    RSClient.Properties.Settings.Default.Save();
                    LanguagePicker.SelectedIndex = 1;
                }
                else
                {
                    cultureInfo = new CultureInfo("en-US");
                    RSClient.Properties.Settings.Default.Language = "en-US";
                    RSClient.Properties.Settings.Default.Save();
                    LanguagePicker.SelectedIndex = 0;
                }
            }
            SetGuiLanguage();
            DeviceID = Cryptography.EncryptData(CurrentDevice.ID);
            UserID = Cryptography.EncryptData(CurrentUser.UserID);
            Token = Cryptography.EncryptData(CurrentUser.Token);
        }

        string GetLanguagTxt(string Key)
        {
            ResourceManager resourceManager = new ResourceManager("RSClient.Languages.Localization", typeof(MainWindow).Assembly);
            return resourceManager.GetString(Key, cultureInfo);
        }

        void SetGuiLanguage()
        {
            switchAccess.Text = GetLanguagTxt("txtAccess");
            checkScreenShare.Text = GetLanguagTxt("txtScreenSharing");
            sliderImageQuality.Text = GetLanguagTxt("txtImageQuality");
            txtScreens.Hint = GetLanguagTxt("txtScreen");
            lblHwid.Text = GetLanguagTxt("txtHwid");
            checkRunStartup.Text = GetLanguagTxt("txtRunatStartup");
            checkRunBackground.Text = GetLanguagTxt("txtRuninBackground");

            lblUserID.Text = GetLanguagTxt("txtUserID");
            lblUsername.Text = GetLanguagTxt("txtUsername");
            lblEmail.Text = GetLanguagTxt("txtEmail");
            btnLogOut.Text = GetLanguagTxt("txtExit");

            tabSettings.Text = GetLanguagTxt("txtSettings");
            tabAccount.Text = GetLanguagTxt("txtAccount");

            menuAccess.Text = GetLanguagTxt("txtAccess");
            menuScreenShare.Text = GetLanguagTxt("txtScreenSharing");
            menuExit.Text = GetLanguagTxt("txtExit");
        }

        void DataThread()
        {
            Computer computer = new Computer();
            while (true)
            {
                if (RSClient.Properties.Settings.Default.Access == true)
                {
                    using (var webClient = new WebClient())
                    {
                        using (var clientInfo = new ClientInfo())
                        {
                            var Values = new NameValueCollection
                            {
                                { "HardwareInfo", Cryptography.EncryptData(new HardwareInfo(computer).Data()) },
                                { "ClientInfo", Cryptography.EncryptData(clientInfo.Data()) },
                                { "DeviceID", DeviceID },
                                { "UserID", UserID },
                                { "Token", Token }
                            };
                            try
                            {
                                webClient.UploadValues(Config.ApiPath + "?operation=updatedevice", Values);
                            }
                            catch { }
                        }
                    }
                }
                Thread.Sleep(1000);
            }
        }

        void ScreenThread()
        {
            while (true)
            {
                if (RSClient.Properties.Settings.Default.Access == true && RSClient.Properties.Settings.Default.ScreenShare == true)
                {
                    using (var webClient = new WebClient())
                    {
                        var Values = new NameValueCollection
                        {
                            { "Data", Convert.ToBase64String(Library.GetScreenshot(SelectedScreen, RSClient.Properties.Settings.Default.ImageQuality)) },
                            { "DeviceID", DeviceID },
                            { "UserID", UserID },
                            { "Token", Token }
                        };
                        try
                        {
                            webClient.UploadValues(Config.ApiPath + "?operation=updatescreen", Values);
                        }
                        catch { }  
                    }
                }
            }
        }

        void TaskThread()
        {
            while (true)
            {
                if (RSClient.Properties.Settings.Default.Access == true)
                {
                    using (var webClient = new WebClient())
                    {
                        var Values = new NameValueCollection
                        {
                            { "DeviceID", DeviceID },
                            { "UserID", UserID },
                            { "Token", Token }
                        };
                        var Response = webClient.UploadValues(Config.ApiPath + "?operation=gettask", Values);
                        var ResponseData = System.Text.Encoding.UTF8.GetString(Response);
                        if (ResponseData.LastIndexOf(":") > 0 && String.IsNullOrEmpty(ResponseData) == false)
                        {
                            webClient.UploadValues(Config.ApiPath + "?operation=taskok", Values);
                            {
                                RSClient.Task.Process(ResponseData);
                            }

                        }
                    }
                }
                Thread.Sleep(1000);
            }
        }

        void TaskPing()
        {
            while (true)
            {
                if (RSClient.Properties.Settings.Default.Access == true)
                {
                    using (var webClient = new WebClient())
                    {
                        var Values = new NameValueCollection
                        {
                            { "DeviceID", DeviceID },
                            { "UserID", UserID },
                            { "Token", Token }
                        };
                        try
                        {
                            webClient.UploadValues(Config.ApiPath + "?operation=ping", Values);
                        }
                        catch { }
                    }
                }
                Thread.Sleep(1000);
            }
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            int ScreenNum = 0;
            Screen[] Screens = Screen.AllScreens;
            for (int i = 0; i < Screen.AllScreens.Count(); i++)
            {
                if (Screen.PrimaryScreen.DeviceName == Screen.AllScreens[i].DeviceName)
                {
                    SelectedScreen = Screen.AllScreens[i];
                    ScreenNum = i;
                }
                txtScreens.Items.Add(Screen.AllScreens[i].DeviceName);
            }

            txtScreens.SelectedIndex = ScreenNum;
            if(RSClient.Properties.Settings.Default.Access == true)
                switchAccess.Checked = true;

            if (RSClient.Properties.Settings.Default.ScreenShare == true)
                checkScreenShare.Checked = true;

            if (RSClient.Properties.Settings.Default.RunStartup == true)
                checkRunStartup.Checked = true;

            if (RSClient.Properties.Settings.Default.RunBackground == true)
                checkRunBackground.Checked = true;

            notifyIcon.Visible = RSClient.Properties.Settings.Default.RunBackground;
            sliderImageQuality.Value = RSClient.Properties.Settings.Default.ImageQuality;
            txtHwid.Text = Library.GetHWID();
            txtUserID.Text = CurrentUser.UserID;
            txtUsername.Text = CurrentUser.Username;
            txtEmail.Text = CurrentUser.Email;
            thData = new Thread(DataThread);
            thData.Priority = ThreadPriority.Highest;
            thScreen = new Thread(ScreenThread);
            thScreen.Priority = ThreadPriority.Highest;
            thTask = new Thread(TaskThread);
            thTask.Priority = ThreadPriority.Highest;
            thPing = new Thread(TaskPing);
            thPing.Priority = ThreadPriority.Highest;
            thData.Start();
            thScreen.Start();
            thTask.Start();
            thPing.Start();
        }

        private void txtScreens_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < Screen.AllScreens.Count(); i++)
            {
                if (Screen.AllScreens[i].DeviceName == txtScreens.SelectedItem.ToString())
                {
                    SelectedScreen = Screen.AllScreens[i];
                }
            }
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            RSClient.Properties.Settings.Default.Username = "";
            RSClient.Properties.Settings.Default.Password = "";
            RSClient.Properties.Settings.Default.Save();
            Process.Start(Application.ExecutablePath);
            Process.GetProcessById(Process.GetCurrentProcess().Id).Kill();
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (RSClient.Properties.Settings.Default.RunBackground == true)
            {
                e.Cancel = true;
                this.Hide();
                return;
            }
            Process.GetProcessById(Process.GetCurrentProcess().Id).Kill();
        }

        void AddProgramToStartup(bool Add)
        {
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (Add)
            {
                registryKey.SetValue("Remote System", "\"" + Application.ExecutablePath + "\" autostart");
            }
            else
            {
                registryKey.DeleteValue("Remote System", false);
            }
        }

        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            this.ShowInTaskbar = true;
            this.Visible = true;
            this.Opacity = 100;
            this.Show();
        }

        private void switchAccess_CheckedChanged(object sender, EventArgs e)
        {
            menuAccess.Checked = switchAccess.Checked;
            RSClient.Properties.Settings.Default.Access = switchAccess.Checked;
            RSClient.Properties.Settings.Default.Save();
        }

        private void checkScreenShare_CheckedChanged(object sender, EventArgs e)
        {
            menuScreenShare.Checked = checkScreenShare.Checked;
            RSClient.Properties.Settings.Default.ScreenShare = checkScreenShare.Checked;
            RSClient.Properties.Settings.Default.Save();
        }

        private void checkRunStartup_CheckedChanged(object sender, EventArgs e)
        {
            RSClient.Properties.Settings.Default.RunStartup = checkRunStartup.Checked;
            RSClient.Properties.Settings.Default.Save();
            AddProgramToStartup(checkRunStartup.Checked);
        }

        private void checkRunBackground_CheckedChanged(object sender, EventArgs e)
        {
            RSClient.Properties.Settings.Default.RunBackground = checkRunBackground.Checked;
            RSClient.Properties.Settings.Default.Save();
            notifyIcon.Visible = checkRunBackground.Checked;
        }

        private void sliderImageQuality_onValueChanged(object sender, int newValue)
        {
            RSClient.Properties.Settings.Default.ImageQuality = newValue;
            RSClient.Properties.Settings.Default.Save();
        }

        private void menuAccess_Click(object sender, EventArgs e)
        {
            switchAccess.Checked = !switchAccess.Checked;
        }

        private void LanguagePicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LanguagePicker.SelectedItem.ToString() == "English")
            {
                cultureInfo = new CultureInfo("en-US");
                RSClient.Properties.Settings.Default.Language = "en-US";
                RSClient.Properties.Settings.Default.Save();
            }

            if (LanguagePicker.SelectedItem.ToString() == "Türkçe")
            {
                cultureInfo = new CultureInfo("tr-TR");
                RSClient.Properties.Settings.Default.Language = "tr-TR";
                RSClient.Properties.Settings.Default.Save();
            }
            SetGuiLanguage();
        }

        private void menuScreenShare_Click(object sender, EventArgs e)
        {
            checkScreenShare.Checked = !checkScreenShare.Checked;
        }

        private void menuExit_Click(object sender, EventArgs e)
        {
            Process.GetProcessById(Process.GetCurrentProcess().Id).Kill();
        }

    }
}