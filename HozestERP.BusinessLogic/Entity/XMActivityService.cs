
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
    public partial class XMActivityService: IXMActivityService
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
    	public XMActivityService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region IXMActivityService成员
        /// <summary>
        /// Insert into XMActivity
        /// </summary>
        /// <param name="xmactivity">XMActivity</param>
    	public void InsertXMActivity(XMActivity xmactivity)
    	{	
            if (xmactivity == null)
                return;
    
            if (!this._context.IsAttached(xmactivity))
    			
                this._context.XMActivities.AddObject(xmactivity);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into XMActivity
        /// </summary>
        /// <param name="xmactivity">XMActivity</param>
        public void UpdateXMActivity(XMActivity xmactivity)
        {
            if (xmactivity == null)
                return;
    
            if (this._context.IsAttached(xmactivity))
                this._context.XMActivities.Attach(xmactivity);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to XMActivity list
        /// </summary>
        public List<XMActivity> GetXMActivityList()
        {		
            var query = from p in this._context.XMActivities
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to XMActivity Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMActivity Page List</returns>
        public PagedList<XMActivity> SearchXMActivity(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMActivities
                        orderby p.Id
                        select p;
            return new PagedList<XMActivity>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a XMActivity by Id
        /// </summary>
        /// <param name="id">XMActivity Id</param>
        /// <returns>XMActivity</returns>   
        public XMActivity GetXMActivityById(int id)
        {
            var query = from p in this._context.XMActivities
                        where p.Id.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete XMActivity by Id
        /// </summary>
        /// <param name="Id">XMActivity Id</param>
        public void DeleteXMActivity(int id)
        {
            var xmactivity = this.GetXMActivityById(id);
            if (xmactivity == null)
                return;
    
            if (!this._context.IsAttached(xmactivity))
                this._context.XMActivities.Attach(xmactivity);
    
            this._context.DeleteObject(xmactivity);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete XMActivity by Id
        /// </summary>
        /// <param name="Ids">XMActivity Id</param>
        public void BatchDeleteXMActivity(List<int> ids)
        {
    	   var query = from q in _context.XMActivities
                    where ids.Contains(q.Id)
                    select q;
            var xmactivitys = query.ToList();
            foreach (var item in xmactivitys)
            {
                if (!_context.IsAttached(item))
                    _context.XMActivities.Attach(item);  
    
                _context.XMActivities.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
