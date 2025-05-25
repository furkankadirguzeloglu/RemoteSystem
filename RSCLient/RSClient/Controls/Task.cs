using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.ServiceProcess;

namespace RSClient
{
    public static class Task
    {
        [Flags]
        public enum ThreadAccess : int
        {
            TERMINATE = (0x0001),
            SUSPEND_RESUME = (0x0002),
            GET_CONTEXT = (0x0008),
            SET_CONTEXT = (0x0010),
            SET_INFORMATION = (0x0020),
            QUERY_INFORMATION = (0x0040),
            SET_THREAD_TOKEN = (0x0080),
            IMPERSONATE = (0x0100),
            DIRECT_IMPERSONATION = (0x0200)
        }

        [DllImport("kernel32.dll")]
        static extern IntPtr OpenThread(ThreadAccess dwDesiredAccess, bool bInheritHandle, uint dwThreadId);
        [DllImport("kernel32.dll")]
        static extern uint SuspendThread(IntPtr hThread);
        [DllImport("kernel32.dll")]
        static extern int ResumeThread(IntPtr hThread);
        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true)]
        static extern bool CloseHandle(IntPtr handle);
        [DllImport("PowrProf.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool SetSuspendState(bool hibernate, bool forceCritical, bool disableWakeEvent);
        public static void SendCommand(string Command, bool WaitForExit = false)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "cmd.exe";
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.CreateNoWindow = true;
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardInput = true;
            startInfo.RedirectStandardOutput = true;
            Process process = new Process();
            process.StartInfo = startInfo;
            process.Start();
            process.StandardInput.WriteLine(Command);
            process.StandardInput.Flush();
            process.StandardInput.Close();

            if(WaitForExit == true)
                process.WaitForExit();
        }

        public static void ProcessKill(string ProcessName)
        {
            foreach (var Process in System.Diagnostics.Process.GetProcessesByName(ProcessName))
            {
                Process.Kill();
            }
        }

        public static void ProcessSuspend(string ProcessName)
        {
            foreach (var Process in System.Diagnostics.Process.GetProcessesByName(ProcessName))
            {
                foreach (ProcessThread thread in Process.Threads)
                {
                    var pOpenThread = OpenThread(ThreadAccess.SUSPEND_RESUME, false, (uint)thread.Id);
                    if (pOpenThread == IntPtr.Zero)
                    {
                        break;
                    }
                    SuspendThread(pOpenThread);
                }
            }      
        }

        public static void ProcessResume(string ProcessName)
        {
            foreach (var Process in System.Diagnostics.Process.GetProcessesByName(ProcessName))
            {
                foreach (ProcessThread thread in Process.Threads)
                {
                    var pOpenThread = OpenThread(ThreadAccess.SUSPEND_RESUME, false, (uint)thread.Id);
                    if (pOpenThread == IntPtr.Zero)
                    {
                        break;
                    }
                    ResumeThread(pOpenThread);
                }
            }
        }

        public static void StartService(string serviceName)
        {
            using (ServiceController serviceController = new ServiceController(serviceName))
            {
                if (serviceController.Status == ServiceControllerStatus.Stopped)
                {
                    serviceController.Start();
                    serviceController.WaitForStatus(ServiceControllerStatus.Running, TimeSpan.FromSeconds(10));
                }
            }
        }

        public static void StopService(string serviceName)
        {
            using (ServiceController serviceController = new ServiceController(serviceName))
            {
                if (serviceController.Status == ServiceControllerStatus.Running)
                {
                    serviceController.Stop();
                    serviceController.WaitForStatus(ServiceControllerStatus.Stopped, TimeSpan.FromSeconds(10));
                }
            }
        }

        public static void Process(string Task)
        {
            if(Task == "PowerOptions:Shutdown")
            {
                System.Diagnostics.Process.Start("shutdown", "/s /t 0");
                return;
            }
            if (Task == "PowerOptions:Restart")
            {
                System.Diagnostics.Process.Start("shutdown", "/r /t 0");
                return;
            }
            if (Task == "PowerOptions:Sleep")
            {
                SetSuspendState(false, true, true);
                return;
            }
            if (Task == "PowerOptions:Signout")
            {
                System.Diagnostics.Process.Start("shutdown", "/l /t 0");
                return;
            }

            string[] Data = Task.Split(':');
            if (Data[0] == "Command")
            {
                SendCommand(Cryptography.Base64Decode(Data[1]));
                return;
            }
            if (Data[0] == "ProcessKill")
            {
                string[] ProcessList = Cryptography.Base64Decode(Data[1]).Split(',');
                foreach (string Process in ProcessList)
                {
                    ProcessKill(Process.Replace(".exe", ""));
                }
                return;
            }
            if (Data[0] == "ProcessSuspend")
            {
                string[] ProcessList = Cryptography.Base64Decode(Data[1]).Split(',');
                foreach (string Process in ProcessList)
                {
                    ProcessSuspend(Process.Replace(".exe", ""));
                }
                return;
            }
            if (Data[0] == "ProcessResume")
            {
                string[] ProcessList = Cryptography.Base64Decode(Data[1]).Split(',');
                foreach (string Process in ProcessList)
                {
                    ProcessResume(Process.Replace(".exe", ""));
                }
                return;
            }
            if (Data[0] == "ServiceStart")
            {
                string[] ServicesList = Cryptography.Base64Decode(Data[1]).Split(',');
                foreach (string Service in ServicesList)
                {
                    StartService(Service);
                }
                return;
            }
            if (Data[0] == "ServiceStop")
            {
                string[] ServicesList = Cryptography.Base64Decode(Data[1]).Split(',');
                foreach (string Service in ServicesList)
                {
                    StopService(Service);
                }
                return;
            }
        }
    }
}
