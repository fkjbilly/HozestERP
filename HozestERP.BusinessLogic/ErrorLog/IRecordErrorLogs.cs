using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HozestERP.BusinessLogic.ErrorLog
{
   

    public partial interface IRecordErrorLogs
    {
         /// <summary>
        /// 记录错误日志
        /// </summary>
        /// <param name="strformat">错误信息</param> 
        void WriteErrorLog(string strformat);    
    }
}
