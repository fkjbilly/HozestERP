
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2017-04-26 15:28:32
** 修改人:
** 修改日期:
** 描 述: 接口实现类
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
    public partial class ActivityLogService: IActivityLogService
    {
        #region Fields
    	/// <summary>
    	/// Object context
    	/// </summary>
    	private readonly HozestERPObjectContext _context;
    	/// <summary>
    	/// Cache manager
    	/// </summary>
    	private readonly ICacheManager _cacheManager;

        #endregion
    	
        #region Ctor
    	
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="context">Object context</param>
    	public ActivityLogService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region IActivityLogService成员
        /// <summary>
        /// Insert into ActivityLog
        /// </summary>
        /// <param name="activitylog">ActivityLog</param>
    	public void InsertActivityLog(ActivityLog activitylog)
    	{	
            if (activitylog == null)
                return;
    
            if (!this._context.IsAttached(activitylog))
    			
                this._context.ActivityLogs.AddObject(activitylog);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into ActivityLog
        /// </summary>
        /// <param name="activitylog">ActivityLog</param>
        public void UpdateActivityLog(ActivityLog activitylog)
        {
            if (activitylog == null)
                return;
    
            if (this._context.IsAttached(activitylog))
                this._context.ActivityLogs.Attach(activitylog);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to ActivityLog list
        /// </summary>
        public List<ActivityLog> GetActivityLogList()
        {		
            var query = from p in this._context.ActivityLogs
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to ActivityLog Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>ActivityLog Page List</returns>
        public PagedList<ActivityLog> SearchActivityLog(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.ActivityLogs
                        orderby p.ActivityLogID
                        select p;
            return new PagedList<ActivityLog>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a ActivityLog by ActivityLogID
        /// </summary>
        /// <param name="activitylogid">ActivityLog ActivityLogID</param>
        /// <returns>ActivityLog</returns>   
        public ActivityLog GetActivityLogByActivityLogID(int activitylogid)
        {
            var query = from p in this._context.ActivityLogs
                        where p.ActivityLogID.Equals(activitylogid)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete ActivityLog by ActivityLogID
        /// </summary>
        /// <param name="ActivityLogID">ActivityLog ActivityLogID</param>
        public void DeleteActivityLog(int activitylogid)
        {
            var activitylog = this.GetActivityLogByActivityLogID(activitylogid);
            if (activitylog == null)
                return;
    
            if (!this._context.IsAttached(activitylog))
                this._context.ActivityLogs.Attach(activitylog);
    
            this._context.DeleteObject(activitylog);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete ActivityLog by ActivityLogID
        /// </summary>
        /// <param name="ActivityLogIDs">ActivityLog ActivityLogID</param>
        public void BatchDeleteActivityLog(List<int> activitylogids)
        {
    	   var query = from q in _context.ActivityLogs
                    where activitylogids.Contains(q.ActivityLogID)
                    select q;
            var activitylogs = query.ToList();
            foreach (var item in activitylogs)
            {
                if (!_context.IsAttached(item))
                    _context.ActivityLogs.Attach(item);  
    
                _context.ActivityLogs.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
