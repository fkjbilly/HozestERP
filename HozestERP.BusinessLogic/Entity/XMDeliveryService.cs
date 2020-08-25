
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
    public partial class XMDeliveryService: IXMDeliveryService
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
    	public XMDeliveryService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region IXMDeliveryService成员
        /// <summary>
        /// Insert into XMDelivery
        /// </summary>
        /// <param name="xmdelivery">XMDelivery</param>
    	public void InsertXMDelivery(XMDelivery xmdelivery)
    	{	
            if (xmdelivery == null)
                return;
    
            if (!this._context.IsAttached(xmdelivery))
    			
                this._context.XMDeliveries.AddObject(xmdelivery);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into XMDelivery
        /// </summary>
        /// <param name="xmdelivery">XMDelivery</param>
        public void UpdateXMDelivery(XMDelivery xmdelivery)
        {
            if (xmdelivery == null)
                return;
    
            if (this._context.IsAttached(xmdelivery))
                this._context.XMDeliveries.Attach(xmdelivery);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to XMDelivery list
        /// </summary>
        public List<XMDelivery> GetXMDeliveryList()
        {		
            var query = from p in this._context.XMDeliveries
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to XMDelivery Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMDelivery Page List</returns>
        public PagedList<XMDelivery> SearchXMDelivery(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMDeliveries
                        orderby p.Id
                        select p;
            return new PagedList<XMDelivery>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a XMDelivery by Id
        /// </summary>
        /// <param name="id">XMDelivery Id</param>
        /// <returns>XMDelivery</returns>   
        public XMDelivery GetXMDeliveryById(int id)
        {
            var query = from p in this._context.XMDeliveries
                        where p.Id.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete XMDelivery by Id
        /// </summary>
        /// <param name="Id">XMDelivery Id</param>
        public void DeleteXMDelivery(int id)
        {
            var xmdelivery = this.GetXMDeliveryById(id);
            if (xmdelivery == null)
                return;
    
            if (!this._context.IsAttached(xmdelivery))
                this._context.XMDeliveries.Attach(xmdelivery);
    
            this._context.DeleteObject(xmdelivery);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete XMDelivery by Id
        /// </summary>
        /// <param name="Ids">XMDelivery Id</param>
        public void BatchDeleteXMDelivery(List<int> ids)
        {
    	   var query = from q in _context.XMDeliveries
                    where ids.Contains(q.Id)
                    select q;
            var xmdeliverys = query.ToList();
            foreach (var item in xmdeliverys)
            {
                if (!_context.IsAttached(item))
                    _context.XMDeliveries.Attach(item);  
    
                _context.XMDeliveries.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
