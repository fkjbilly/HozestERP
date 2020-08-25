using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Web;

namespace HozestERP.BusinessLogic.ErrorLog
{
    public class RecordErrorLogs : IRecordErrorLogs
    {
        #region  记录错误日志
        /// <summary>
        /// 记录错误日志
        /// </summary>
        /// <param name="strformat">错误信息</param>
        ///// <param name="path">日志存放位置</param>, string path
        public  void WriteErrorLog(string strformat)
        {
            try
            {
               // string path = @"c:\Program Files\cutt\_error.txt";
                
              string path= HttpRuntime.AppDomainAppPath.ToString();
              string fileDirectory = path + @"ErrorLogWeb";
              string partpath = fileDirectory + "\\" + DateTime.Now.ToString("yyyyMMdd") + ".txt";

              if (!File.Exists(partpath))
                {
                    string nofile = Path.GetDirectoryName(partpath);
                    if (!Directory.Exists(nofile))
                    {
                        Directory.CreateDirectory(nofile);
                        Files.addpathPower(nofile, "ASPNET", "FullControl");
                    }
                    FileStream fss = File.Create(partpath); ;
                    fss.Flush();
                    fss.Close();//创建之后进行关闭  
                }

              FileStream fs = new FileStream(partpath, FileMode.Append);
                StreamWriter streamWriter = new StreamWriter(fs);
                streamWriter.Write(DateTime.Now.ToString() + "：" + strformat + "\r\n" + "--------------------------\r\n");
                streamWriter.Flush();
                streamWriter.Close();
                fs.Close();
            }
            catch
            {

            }
        } 

        #endregion
    }
}