
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
    public partial class XMOrderInfoService: IXMOrderInfoService
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
    	public XMOrderInfoService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region IXMOrderInfoService成员
        /// <summary>
        /// Insert into XMOrderInfo
        /// </summary>
        /// <param name="xmorderinfo">XMOrderInfo</param>
    	public void InsertXMOrderInfo(XMOrderInfo xmorderinfo)
    	{	
            if (xmorderinfo == null)
                return;
    
            if (!this._context.IsAttached(xmorderinfo))
    			
                this._context.XMOrderInfoes.AddObject(xmorderinfo);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into XMOrderInfo
        /// </summary>
        /// <param name="xmorderinfo">XMOrderInfo</param>
        public void UpdateXMOrderInfo(XMOrderInfo xmorderinfo)
        {
            if (xmorderinfo == null)
                return;
    
            if (this._context.IsAttached(xmorderinfo))
                this._context.XMOrderInfoes.Attach(xmorderinfo);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to XMOrderInfo list
        /// </summary>
        public List<XMOrderInfo> GetXMOrderInfoList()
        {		
            var query = from p in this._context.XMOrderInfoes
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to XMOrderInfo Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMOrderInfo Page List</returns>
        public PagedList<XMOrderInfo> SearchXMOrderInfo(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMOrderInfoes
                        orderby p.ID
                        select p;
            return new PagedList<XMOrderInfo>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a XMOrderInfo by ID
        /// </summary>
        /// <param name="id">XMOrderInfo ID</param>
        /// <returns>XMOrderInfo</returns>   
        public XMOrderInfo GetXMOrderInfoByID(int id)
        {
            var query = from p in this._context.XMOrderInfoes
                        where p.ID.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete XMOrderInfo by ID
        /// </summary>
        /// <param name="ID">XMOrderInfo ID</param>
        public void DeleteXMOrderInfo(int id)
        {
            var xmorderinfo = this.GetXMOrderInfoByID(id);
            if (xmorderinfo == null)
                return;
    
            if (!this._context.IsAttached(xmorderinfo))
                this._context.XMOrderInfoes.Attach(xmorderinfo);
    
            this._context.DeleteObject(xmorderinfo);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete XMOrderInfo by ID
        /// </summary>
        /// <param name="IDs">XMOrderInfo ID</param>
        public void BatchDeleteXMOrderInfo(List<int> ids)
        {
    	   var query = from q in _context.XMOrderInfoes
                    where ids.Contains(q.ID)
                    select q;
            var xmorderinfos = query.ToList();
            foreach (var item in xmorderinfos)
            {
                if (!_context.IsAttached(item))
                    _context.XMOrderInfoes.Attach(item);  
    
                _context.XMOrderInfoes.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
