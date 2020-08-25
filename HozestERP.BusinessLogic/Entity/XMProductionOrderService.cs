
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
    public partial class XMProductionOrderService: IXMProductionOrderService
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
    	public XMProductionOrderService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region IXMProductionOrderService成员
        /// <summary>
        /// Insert into XMProductionOrder
        /// </summary>
        /// <param name="xmproductionorder">XMProductionOrder</param>
    	public void InsertXMProductionOrder(XMProductionOrder xmproductionorder)
    	{	
            if (xmproductionorder == null)
                return;
    
            if (!this._context.IsAttached(xmproductionorder))
    			
                this._context.XMProductionOrders.AddObject(xmproductionorder);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into XMProductionOrder
        /// </summary>
        /// <param name="xmproductionorder">XMProductionOrder</param>
        public void UpdateXMProductionOrder(XMProductionOrder xmproductionorder)
        {
            if (xmproductionorder == null)
                return;
    
            if (this._context.IsAttached(xmproductionorder))
                this._context.XMProductionOrders.Attach(xmproductionorder);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to XMProductionOrder list
        /// </summary>
        public List<XMProductionOrder> GetXMProductionOrderList()
        {		
            var query = from p in this._context.XMProductionOrders
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to XMProductionOrder Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMProductionOrder Page List</returns>
        public PagedList<XMProductionOrder> SearchXMProductionOrder(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMProductionOrders
                        orderby p.Id
                        select p;
            return new PagedList<XMProductionOrder>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a XMProductionOrder by Id
        /// </summary>
        /// <param name="id">XMProductionOrder Id</param>
        /// <returns>XMProductionOrder</returns>   
        public XMProductionOrder GetXMProductionOrderById(int id)
        {
            var query = from p in this._context.XMProductionOrders
                        where p.Id.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete XMProductionOrder by Id
        /// </summary>
        /// <param name="Id">XMProductionOrder Id</param>
        public void DeleteXMProductionOrder(int id)
        {
            var xmproductionorder = this.GetXMProductionOrderById(id);
            if (xmproductionorder == null)
                return;
    
            if (!this._context.IsAttached(xmproductionorder))
                this._context.XMProductionOrders.Attach(xmproductionorder);
    
            this._context.DeleteObject(xmproductionorder);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete XMProductionOrder by Id
        /// </summary>
        /// <param name="Ids">XMProductionOrder Id</param>
        public void BatchDeleteXMProductionOrder(List<int> ids)
        {
    	   var query = from q in _context.XMProductionOrders
                    where ids.Contains(q.Id)
                    select q;
            var xmproductionorders = query.ToList();
            foreach (var item in xmproductionorders)
            {
                if (!_context.IsAttached(item))
                    _context.XMProductionOrders.Attach(item);  
    
                _context.XMProductionOrders.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
