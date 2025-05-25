using OpenHardwareMonitor.Hardware;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

public class HardwareInfo
{
    private Computer computer;
    private List<IHardware> hardwareList;

    public string CPUName { get; private set; }
    public float CPUTemperature { get; private set; }
    public float CPULoad { get; private set; }
    public string GPUName { get; private set; }
    public float GPUTemperature { get; private set; }
    public float GPULoad { get; private set; }
    public string MemorySize { get; private set; }
    public float MemoryLoad { get; private set; }
    public float StorageLoad { get; private set; }
    public HardwareInfo(Computer computer)
    {
        computer.Open();
        computer.CPUEnabled = true;
        computer.GPUEnabled = true;
        hardwareList = computer.Hardware.ToList();
        CPUName = "";
        CPUTemperature = 0;
        CPULoad = 0;
        GPUName = "";
        GPUTemperature = 0;
        GPULoad = 0;
        MemorySize = "";
        MemoryLoad = 0;
        StorageLoad = 0;
        GetHardwareInfo();
    }
    public string Data()
    {
        return CPUName.Trim() + "½" + CPUTemperature.ToString().Trim() + "½" + CPULoad.ToString().Trim() + "½" + GPUName.ToString().Trim() + "½" + GPUTemperature.ToString().Trim() + "½" + GPULoad.ToString().Trim() + "½" + MemorySize.ToString().Trim() + "½" + MemoryLoad.ToString().Trim() + "½" + StorageLoad.ToString().Trim();
    }

    [DllImport("kernel32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    static extern bool GlobalMemoryStatusEx(ref MEMORYSTATUSEX lpBuffer);

    [StructLayout(LayoutKind.Sequential)]
    public struct MEMORYSTATUSEX
    {
        public uint dwLength;
        public uint dwMemoryLoad;
        public ulong ullTotalPhys;
        public ulong ullAvailPhys;
        public ulong ullTotalPageFile;
        public ulong ullAvailPageFile;
        public ulong ullTotalVirtual;
        public ulong ullAvailVirtual;
        public ulong ullAvailExtendedVirtual;
        public void Init()
        {
            dwLength = (uint)Marshal.SizeOf(typeof(MEMORYSTATUSEX));
        }
    }

    private void GetHardwareInfo()
    {
        foreach (IHardware hardware in hardwareList)
        {
            hardware.Update();
            if (hardware.HardwareType == HardwareType.CPU)
            {
                CPUName = hardware.Name;
                foreach (ISensor sensor in hardware.Sensors)
                {
                    if (sensor.SensorType == SensorType.Temperature)
                    {
                        CPUTemperature = (float)sensor.Value;
                    }
                    else if ((sensor.SensorType == SensorType.Load && sensor.Name == "Total") || (sensor.SensorType == SensorType.Load && sensor.Name == "CPU Total"))
                    {
                        CPULoad = (float)sensor.Value;
                    }
                }
            }
            else if (hardware.HardwareType == HardwareType.GpuNvidia || hardware.HardwareType == HardwareType.GpuAti)
            {
                GPUName = hardware.Name;
                foreach (ISensor sensor in hardware.Sensors)
                {
                    if (sensor.SensorType == SensorType.Temperature)
                    {
                        GPUTemperature = (float)sensor.Value;
                    }
                    else if (sensor.SensorType == SensorType.Load && sensor.Name.Contains("GPU Core"))
                    {
                        GPULoad = (float)sensor.Value;
                    }
                }
            }
            else if (hardware.HardwareType == HardwareType.CPU)
            {
                CPUName = hardware.Name;
                foreach (ISensor sensor in hardware.Sensors)
                {
                    if (sensor.SensorType == SensorType.Temperature)
                    {
                        CPUTemperature = (float)sensor.Value;
                    }
                    else if (sensor.SensorType == SensorType.Load && sensor.Name.Contains("Total"))
                    {
                        CPULoad = (float)sensor.Value;
                    }
                }
            }
        }

        var memStatus = new MEMORYSTATUSEX();
        memStatus.Init();
        GlobalMemoryStatusEx(ref memStatus);
        ulong totalMemory = memStatus.ullTotalPhys;

        ulong kb = 1024;
        ulong mb = kb * 1024;
        ulong gb = mb * 1024;
        ulong tb = gb * 1024;

        if (totalMemory >= tb)
        {
            MemorySize = $"{(double)totalMemory / tb:0} TB";
        }
        else if (totalMemory >= gb)
        {
            MemorySize = $"{(double)totalMemory / gb:0} GB";
        }
        else if (totalMemory >= mb)
        {
            MemorySize = $"{(double)totalMemory / mb:0} MB";
        }
        else if (totalMemory >= kb)
        {
            MemorySize = $"{(double)totalMemory / kb:0} KB";
        }
        else
        {
            MemorySize = $"{totalMemory} bytes";
        }

        MemoryLoad = (totalMemory - new PerformanceCounter("Memory", "Available Bytes").NextValue()) / (float)totalMemory * 100;

        DriveInfo[] drives = DriveInfo.GetDrives();
        long totalFreeSpace = 0;
        long totalSize = 0;

        foreach (DriveInfo drive in drives)
        {
            if (drive.DriveType == DriveType.Fixed)
            {
                totalFreeSpace += drive.TotalFreeSpace;
                totalSize += drive.TotalSize;
            }
        }
        StorageLoad = 100 - (float)totalFreeSpace / totalSize * 100;
    }
}
