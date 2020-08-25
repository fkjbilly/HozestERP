
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
    public partial class ActivityLogTypeService: IActivityLogTypeService
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
    	public ActivityLogTypeService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region IActivityLogTypeService成员
        /// <summary>
        /// Insert into ActivityLogType
        /// </summary>
        /// <param name="activitylogtype">ActivityLogType</param>
    	public void InsertActivityLogType(ActivityLogType activitylogtype)
    	{	
            if (activitylogtype == null)
                return;
    
            if (!this._context.IsAttached(activitylogtype))
    			
                this._context.ActivityLogTypes.AddObject(activitylogtype);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into ActivityLogType
        /// </summary>
        /// <param name="activitylogtype">ActivityLogType</param>
        public void UpdateActivityLogType(ActivityLogType activitylogtype)
        {
            if (activitylogtype == null)
                return;
    
            if (this._context.IsAttached(activitylogtype))
                this._context.ActivityLogTypes.Attach(activitylogtype);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to ActivityLogType list
        /// </summary>
        public List<ActivityLogType> GetActivityLogTypeList()
        {		
            var query = from p in this._context.ActivityLogTypes
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to ActivityLogType Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>ActivityLogType Page List</returns>
        public PagedList<ActivityLogType> SearchActivityLogType(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.ActivityLogTypes
                        orderby p.ActivityLogTypeID
                        select p;
            return new PagedList<ActivityLogType>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a ActivityLogType by ActivityLogTypeID
        /// </summary>
        /// <param name="activitylogtypeid">ActivityLogType ActivityLogTypeID</param>
        /// <returns>ActivityLogType</returns>   
        public ActivityLogType GetActivityLogTypeByActivityLogTypeID(int activitylogtypeid)
        {
            var query = from p in this._context.ActivityLogTypes
                        where p.ActivityLogTypeID.Equals(activitylogtypeid)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete ActivityLogType by ActivityLogTypeID
        /// </summary>
        /// <param name="ActivityLogTypeID">ActivityLogType ActivityLogTypeID</param>
        public void DeleteActivityLogType(int activitylogtypeid)
        {
            var activitylogtype = this.GetActivityLogTypeByActivityLogTypeID(activitylogtypeid);
            if (activitylogtype == null)
                return;
    
            if (!this._context.IsAttached(activitylogtype))
                this._context.ActivityLogTypes.Attach(activitylogtype);
    
            this._context.DeleteObject(activitylogtype);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete ActivityLogType by ActivityLogTypeID
        /// </summary>
        /// <param name="ActivityLogTypeIDs">ActivityLogType ActivityLogTypeID</param>
        public void BatchDeleteActivityLogType(List<int> activitylogtypeids)
        {
    	   var query = from q in _context.ActivityLogTypes
                    where activitylogtypeids.Contains(q.ActivityLogTypeID)
                    select q;
            var activitylogtypes = query.ToList();
            foreach (var item in activitylogtypes)
            {
                if (!_context.IsAttached(item))
                    _context.ActivityLogTypes.Attach(item);  
    
                _context.ActivityLogTypes.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
