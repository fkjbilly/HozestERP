using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Security.AccessControl;

namespace HozestERP.BusinessLogic.ErrorLog
{ 
    public class Files
    {
        /// <summary>
        /// 给指定的操作系统用户赋操作权限
        /// </summary>
        /// <param name="pathname">文件的路径</param>
        /// <param name="username">操作系统用户名</param>
        /// <param name="power">操作权限，枚举型：FullControl，ReadOnly，Write，Modify</param>
        /// <returns>是否成功</returns>
        public static bool addpathPower(string pathname, string username, string power)
        {
            bool istrue = true;
            DirectoryInfo dirinfo = new DirectoryInfo(pathname);
 
            if ((dirinfo.Attributes & FileAttributes.ReadOnly) != 0)
            {
                dirinfo.Attributes = FileAttributes.Normal;
            }
            //取得访问控制列表  
            DirectorySecurity dirsecurity = dirinfo.GetAccessControl();
 
            switch (power)
            {
                case "FullControl":
                    dirsecurity.AddAccessRule(new FileSystemAccessRule(username, FileSystemRights.FullControl, InheritanceFlags.ContainerInherit, PropagationFlags.InheritOnly, AccessControlType.Allow));
                    break;
                case "ReadOnly":
                    dirsecurity.AddAccessRule(new FileSystemAccessRule(username, FileSystemRights.Read, AccessControlType.Allow));
                    break;
                case "Write":
                    dirsecurity.AddAccessRule(new FileSystemAccessRule(username, FileSystemRights.Write, AccessControlType.Allow));
                    break;
                case "Modify":
                    dirsecurity.AddAccessRule(new FileSystemAccessRule(username, FileSystemRights.Modify, AccessControlType.Allow));
                    break;
            }
            try
            {
                dirinfo.SetAccessControl(dirsecurity);
            }
            catch
            {
                istrue = false;
            }
            return istrue;
        }
    }
}
