
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
    public partial interface IActivityLogService
    {
        #region IActivityLogService成员
        /// <summary>
        /// Insert into ActivityLog
        /// </summary>
        /// <param name="activitylog">ActivityLog</param>
    	void InsertActivityLog(ActivityLog activitylog);
    	
        /// <summary>
        /// Update into ActivityLog
        /// </summary>
        /// <param name="activitylog">ActivityLog</param>
        void UpdateActivityLog(ActivityLog activitylog);	
    	
        /// <summary>
        /// get to ActivityLog list
        /// </summary>
        List<ActivityLog> GetActivityLogList();
    	       
    	/// <summary>
    	/// get to ActivityLog Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>ActivityLog Page List</returns>
    	PagedList<ActivityLog> SearchActivityLog(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a ActivityLog by ActivityLogID
        /// </summary>
        /// <param name="activitylogid">ActivityLog ActivityLogID</param>
        /// <returns>ActivityLog</returns>   
        ActivityLog GetActivityLogByActivityLogID(int activitylogid);
    
    	/// <summary>
        /// delete ActivityLog by ActivityLogID
        /// </summary>
        /// <param name="ActivityLogID">ActivityLog ActivityLogID</param>
        void DeleteActivityLog(int activitylogid);
    	
    	/// <summary>
        /// Batch delete ActivityLog by ActivityLogID
        /// </summary>
        /// <param name="ActivityLogIDs">ActivityLog ActivityLogID</param>
        void BatchDeleteActivityLog(List<int> activitylogids);

        #endregion
    }
}
