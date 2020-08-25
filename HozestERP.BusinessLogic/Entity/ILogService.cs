
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2017-04-26 15:27:57
** 修改人:
** 修改日期:
** 描 述: 接口类
 *          
** 版 本:1.0
**----------------------------------------------------------------------------
******************************************************************/
using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.Serialization;

using HozestERP.BusinessLogic.Data;
using HozestERP.BusinessLogic.Caching;
using HozestERP.Common;

namespace HozestERP.BusinessLogic.Entity
{
    public partial interface ILogService
    {
        #region ILogService成员
        /// <summary>
        /// Insert into Log
        /// </summary>
        /// <param name="log">Log</param>
    	void InsertLog(Log log);
    	
        /// <summary>
        /// Update into Log
        /// </summary>
        /// <param name="log">Log</param>
        void UpdateLog(Log log);	
    	
        /// <summary>
        /// get to Log list
        /// </summary>
        List<Log> GetLogList();
    	       
    	/// <summary>
    	/// get to Log Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>Log Page List</returns>
    	PagedList<Log> SearchLog(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a Log by LogID
        /// </summary>
        /// <param name="logid">Log LogID</param>
        /// <returns>Log</returns>   
        Log GetLogByLogID(int logid);
    
    	/// <summary>
        /// delete Log by LogID
        /// </summary>
        /// <param name="LogID">Log LogID</param>
        void DeleteLog(int logid);
    	
    	/// <summary>
        /// Batch delete Log by LogID
        /// </summary>
        /// <param name="LogIDs">Log LogID</param>
        void BatchDeleteLog(List<int> logids);

        #endregion
    }
}
