
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
    public partial interface IActivityLogTypeService
    {
        #region IActivityLogTypeService成员
        /// <summary>
        /// Insert into ActivityLogType
        /// </summary>
        /// <param name="activitylogtype">ActivityLogType</param>
    	void InsertActivityLogType(ActivityLogType activitylogtype);
    	
        /// <summary>
        /// Update into ActivityLogType
        /// </summary>
        /// <param name="activitylogtype">ActivityLogType</param>
        void UpdateActivityLogType(ActivityLogType activitylogtype);	
    	
        /// <summary>
        /// get to ActivityLogType list
        /// </summary>
        List<ActivityLogType> GetActivityLogTypeList();
    	       
    	/// <summary>
    	/// get to ActivityLogType Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>ActivityLogType Page List</returns>
    	PagedList<ActivityLogType> SearchActivityLogType(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a ActivityLogType by ActivityLogTypeID
        /// </summary>
        /// <param name="activitylogtypeid">ActivityLogType ActivityLogTypeID</param>
        /// <returns>ActivityLogType</returns>   
        ActivityLogType GetActivityLogTypeByActivityLogTypeID(int activitylogtypeid);
    
    	/// <summary>
        /// delete ActivityLogType by ActivityLogTypeID
        /// </summary>
        /// <param name="ActivityLogTypeID">ActivityLogType ActivityLogTypeID</param>
        void DeleteActivityLogType(int activitylogtypeid);
    	
    	/// <summary>
        /// Batch delete ActivityLogType by ActivityLogTypeID
        /// </summary>
        /// <param name="ActivityLogTypeIDs">ActivityLogType ActivityLogTypeID</param>
        void BatchDeleteActivityLogType(List<int> activitylogtypeids);

        #endregion
    }
}
