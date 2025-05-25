using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Management;
using System.Net;
using System.Windows.Forms;

namespace RSClient
{
    public static class Library
    {
        public static string DownloadString(string Url)
        {
            try
            {
                using (var webClient = new WebClient())
                {
                    return webClient.DownloadString(Url);
                }
            }
            catch
            {
                return "NULL";
            }
        }
        
        public static bool CheckNetwork()
        {
            try
            {
                using (var webClient = new WebClient())
                using (var stream = webClient.OpenRead("http://www.google.com"))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public static bool CheckServer()
        {
            try
            {
                if (DownloadString(Config.ApiPath + "?operation=checkserver") == "OK")
                {
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public static string GetHWID()
        {
            string hardwareID = "";
            var managementClass = new ManagementClass("Win32_ComputerSystemProduct");
            var managementBaseObjects = managementClass.GetInstances();
            foreach (var managementObject in managementBaseObjects)
            {
                hardwareID = managementObject.Properties["UUID"].Value.ToString();
                break;
            }
            return hardwareID;
        }

        static byte[] CompressedBitmap(Bitmap Bitmap, long Quality)
        {
            using (var memStream = new MemoryStream())
            {
                using (var compressionStream = new MemoryStream())
                {
                    var QualityParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, Quality);
                    var ImageCodec = ImageCodecInfo.GetImageEncoders().FirstOrDefault(o => o.FormatID == ImageFormat.Jpeg.Guid);
                    var Parameters = new EncoderParameters(1);
                    Parameters.Param[0] = QualityParam;
                    Bitmap.Save(compressionStream, ImageCodec, Parameters);
                    using (var gzipStream = new GZipStream(memStream, CompressionMode.Compress))
                    {
                        compressionStream.Seek(0, SeekOrigin.Begin);
                        compressionStream.CopyTo(gzipStream);
                    }
                }
                return memStream.ToArray();
            }
        }


        public static byte[] GetScreenshot(Screen Screen, long quality)
        {
            using (var screenshot = new Bitmap(Screen.Bounds.Width, Screen.Bounds.Height, PixelFormat.Format32bppArgb))
            {
                using (var gfxScreenshot = Graphics.FromImage(screenshot))
                {
                    gfxScreenshot.CopyFromScreen(Screen.Bounds.X, Screen.Bounds.Y, 0, 0, Screen.Bounds.Size, CopyPixelOperation.SourceCopy);
                }
                return CompressedBitmap(screenshot, quality);
            }
        }

    }
}
