using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSClient
{
    public static class Cryptography
    {
        public static string Base64Encode(string Data)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(Data);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public static string Base64Decode(string Data)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(Data);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        public static string ToHexString(string Data)
        {
            var sb = new StringBuilder();
            var bytes = Encoding.Unicode.GetBytes(Data);
            foreach (var t in bytes)
            {
                sb.Append(t.ToString("X2"));
            }
            return sb.ToString();
        }

        public static string FromHexString(string Data)
        {
            var bytes = new byte[Data.Length / 2];
            for (var i = 0; i < bytes.Length; i++)
            {
                bytes[i] = Convert.ToByte(Data.Substring(i * 2, 2), 16);
            }
            return Encoding.Unicode.GetString(bytes);
        }

        static string Reverse(string Data)
        {
            return new string(Data.ToCharArray().Reverse().ToArray());
        }

        static public string EncryptData(string Data)
        {
            Data = Base64Encode(Data);
            Data = Reverse(Data);
            return Data;
        }

        static public string DecryptData(string Data)
        {
            Data = Reverse(Data);
            Data = Base64Decode(Data);
            return Data;
        }

    }
}
