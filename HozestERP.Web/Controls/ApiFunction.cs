using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using Microsoft.Win32;

namespace HozestERP.Web
{
    public class ApiFunction
    {
        public ApiFunction()
        {
        }

        private const uint SHGFI_ICON = 0x100;
        private const uint SHGFI_LARGEICON = 0x0;
        private const uint SHGFI_SMALLICON = 0x1;

        [DllImport("kernel32.dll ")]
        internal static extern void ExitProcess(int a);

        [DllImport("shell32.dll ")]
        private static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttributes, ref   SHFILEINFO psfi, uint cbSizeFileInfo, uint uFlags);

        [StructLayout(LayoutKind.Sequential)]
        private struct SHFILEINFO
        {
            public IntPtr hIcon;
            public IntPtr iIcon;
            public uint dwAttributes;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string szDisplayName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
            public string szTypeName;
        }

        internal static string GetSmallIcon(string strFileName)
        {
            FileInfo myFileInfo = new FileInfo(strFileName);
            string name = string.Format("{1}images/ICON/{0}.ico", myFileInfo.Extension.Replace(".", ""), HttpContext.Current.Request.PhysicalApplicationPath);
            if (File.Exists(name))
            {
                return myFileInfo.Extension.Replace(".", "") + ".ico";
            }
            IntPtr hImgSmall;
            SHFILEINFO shinfo = new SHFILEINFO();

            hImgSmall = SHGetFileInfo(strFileName, 0, ref   shinfo, (uint)Marshal.SizeOf(shinfo), SHGFI_ICON | SHGFI_SMALLICON);
            Icon myIcon = System.Drawing.Icon.FromHandle(shinfo.hIcon);

            FileStream fileStream = new FileStream(name, FileMode.Create);
            myIcon.Save(fileStream);
            fileStream.Close();

            return myFileInfo.Extension.Replace(".", "") + ".ico";
        }

        internal static string GetLargeIcon(string strFileName)
        {
            FileInfo myFileInfo = new FileInfo(strFileName);
            string name = string.Format("{1}images/ICON/{0}.ico", myFileInfo.Extension.Replace(".", ""), HttpContext.Current.Request.PhysicalApplicationPath);
            if (File.Exists(name))
            {
                return myFileInfo.Extension.Replace(".", "") + ".ico";
            }
            IntPtr hImgSmall;
            SHFILEINFO shinfo = new SHFILEINFO();

            hImgSmall = SHGetFileInfo(strFileName, 0, ref   shinfo, (uint)Marshal.SizeOf(shinfo), SHGFI_ICON | SHGFI_LARGEICON);
            Icon myIcon = System.Drawing.Icon.FromHandle(shinfo.hIcon);


            FileStream fileStream = new FileStream(name, FileMode.Create);
            myIcon.Save(fileStream);
            fileStream.Close();

            return myFileInfo.Extension.Replace(".", "") + ".ico";
        }
    }
}
