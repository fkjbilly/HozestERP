using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace HozestERP.BusinessLogic
{
    public static class Des
    {
        private const string key = "doyongwa";

        public static string DesDecrypt(string decryptString)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(Des.key.Substring(0, 8));
            byte[] rgbIV = bytes;
            byte[] buffer = Convert.FromBase64String(decryptString);
            DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
            MemoryStream stream = new MemoryStream();
            CryptoStream stream2 = new CryptoStream(stream, provider.CreateDecryptor(bytes, rgbIV), CryptoStreamMode.Write);
            stream2.Write(buffer, 0, buffer.Length);
            stream2.FlushFinalBlock();
            return Encoding.UTF8.GetString(stream.ToArray());
        }

        public static string DesEncrypt(string encryptString)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(Des.key.Substring(0, 8));
            byte[] rgbIV = bytes;
            byte[] buffer = Encoding.UTF8.GetBytes(encryptString);
            DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
            MemoryStream stream = new MemoryStream();
            CryptoStream stream2 = new CryptoStream(stream, provider.CreateEncryptor(bytes, rgbIV), CryptoStreamMode.Write);
            stream2.Write(buffer, 0, buffer.Length);
            stream2.FlushFinalBlock();
            return Convert.ToBase64String(stream.ToArray());
        }
    }
}
