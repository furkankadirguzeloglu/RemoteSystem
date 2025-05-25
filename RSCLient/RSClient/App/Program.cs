using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace RSClient
{
    internal static class Program
    {
        [STAThread]
        [DllImport("user32.dll")]
        private static extern bool IsIconic(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        static extern uint GetCompressedFileSize(string lpFileName, out uint lpFileSizeHigh);

        private const int SW_RESTORE = 9;
        static bool DeveloperMode = false;


        static long GetFileSizeInBytes(string filePath)
        {
            uint highSize;
            long fileSize = GetCompressedFileSize(filePath, out highSize) + ((long)highSize << 32);
            return fileSize;
        }

        static long GetFileSize(string Url)
        {
            long FileSize = 0;
            try
            {
                var Request = WebRequest.Create(Url);
                Request.Method = "HEAD";
                using (WebResponse response = Request.GetResponse())
                {
                    if (long.TryParse(response.Headers.Get("Content-Length"), out long contentLength))
                    {
                        FileSize = contentLength;
                    }
                }
            }
            catch
            {
                return 0;
            }
            return FileSize;
        }

        static void DownloadFile(string Url, string Path)
        {
            try
            {
                using (WebClient webClient = new WebClient())
                {
                    webClient.DownloadFile(Url, Path);
                }
            }
            catch { }
        }

        static void Main(string[] args)
        {
            Process[] processes = Process.GetProcessesByName(Assembly.GetEntryAssembly().GetName().Name);
            if (processes.Length > 1)
            {
                foreach (Process process in processes)
                {
                    if (process.Id != Process.GetCurrentProcess().Id)
                    {
                        IntPtr hWnd = process.MainWindowHandle;
                        if (IsIconic(hWnd))
                        {
                            ShowWindowAsync(hWnd, SW_RESTORE);
                        }
                        SetForegroundWindow(hWnd);
                        break;
                    }
                }
                return;
            }

            bool networkAvailable = Library.CheckNetwork();
            if (!networkAvailable)
            {
                DateTime startTime = DateTime.Now;
                TimeSpan duration = TimeSpan.FromMinutes(5);
                bool internetRecovered = false;
                while (DateTime.Now - startTime < duration)
                {
                    Thread.Sleep(100);
                    networkAvailable = Library.CheckNetwork();
                    if (networkAvailable)
                    {
                        internetRecovered = true;
                        break;
                    }
                }
                if (!internetRecovered)
                {
                    MessageBox.Show("Internet connection is required for this software. The program is closing.", "Internet connection not found!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (DeveloperMode == false)
            {
                string NewAppPath = "https://raw.githubusercontent.com/furkankadirguzeloglu/RemoteSystem/main/files/RSClient.exe";
                string CurrentExePath = System.Reflection.Assembly.GetEntryAssembly().Location;
                long NewApp = GetFileSize(NewAppPath);
                long CurrentApp = GetFileSizeInBytes(CurrentExePath);

                if (File.Exists(CurrentExePath + "_old") == true)
                {
                    File.Delete(CurrentExePath + "_old");
                }

                if (NewApp != CurrentApp)
                {
                    File.Move(CurrentExePath, CurrentExePath + "_old");
                    DownloadFile(NewAppPath, CurrentExePath + "_new");
                    Thread.Sleep(1000);
                    MessageBox.Show("Remote System has been updated! Please restart the program.", "Auto Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (File.Exists(CurrentExePath + "_new") == true)
                    {
                        File.Move(CurrentExePath + "_new", CurrentExePath);
                    }
                    Environment.Exit(0);
                }
            }

            if (Library.CheckServer() == false)
            {
                MessageBox.Show("The software could not connect to the server! Please try again later...", "Could not connect to server!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginWindow(args));
        }
    }
}
