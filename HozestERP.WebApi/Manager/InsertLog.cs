using HozestERP.WebApi.SQl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HozestERP.WebApi.Manager
{
    public class InsertLog
    {
        private static object obj = new object();
        public static void Insert(string message, Exception exception)
        {
             InsertLogs( message, exception);
        }

        private static void InsertLogs(string message, Exception exception)
        {
            lock (obj)
            {
                if ((exception != null) && (exception is System.Threading.ThreadAbortException))
                    return;

                string exceptionStr = exception == null ? string.Empty : exception.ToString();
                string IPAddress = "127.0.0.1";
                string pageUrl = "OrderInsertManager";
                string referrerUrl = string.Empty;
                if (HttpContext.Current != null &&
                    HttpContext.Current.Request != null &&
                    HttpContext.Current.Request.UrlReferrer != null)
                    referrerUrl = HttpContext.Current.Request.UrlReferrer.ToString();

                message = CommonHelper.EnsureNotNull(message);
                message = CommonHelper.EnsureMaximumLength(message, 1000);
                exceptionStr = CommonHelper.EnsureNotNull(exceptionStr);
                exceptionStr = CommonHelper.EnsureMaximumLength(exceptionStr, 4000);
                IPAddress = CommonHelper.EnsureNotNull(IPAddress);
                IPAddress = CommonHelper.EnsureMaximumLength(IPAddress, 100);
                pageUrl = CommonHelper.EnsureNotNull(pageUrl);
                pageUrl = CommonHelper.EnsureMaximumLength(pageUrl, 100);
                referrerUrl = CommonHelper.EnsureNotNull(referrerUrl);
                referrerUrl = CommonHelper.EnsureMaximumLength(referrerUrl, 100);

                var sql = "insert into Sys_Log ( LogTypeID,Severity,Message,Exception,IPAddress,CustomerID,PageURL,ReferrerURL,CreatedOn ) values ( 20,11,'"+ message + "','"+ exceptionStr + "','"+ IPAddress + "',7,'"+ pageUrl + "','"+ referrerUrl + "','"+ DateTime.Now + "')";//插入主表的sql语句
                SqlDataHelper.ExecuteNonQuery(sql);

             
            }

        }

        public static void Insert(string message, string exception)
        {
            Insert(message, new Exception(String.IsNullOrEmpty(exception) ? string.Empty : exception));
        }
    }
}