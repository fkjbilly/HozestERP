
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
    public partial class XMDeliveryProductInventoryService: IXMDeliveryProductInventoryService
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
    	public XMDeliveryProductInventoryService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region IXMDeliveryProductInventoryService成员
        /// <summary>
        /// Insert into XMDeliveryProductInventory
        /// </summary>
        /// <param name="xmdeliveryproductinventory">XMDeliveryProductInventory</param>
    	public void InsertXMDeliveryProductInventory(XMDeliveryProductInventory xmdeliveryproductinventory)
    	{	
            if (xmdeliveryproductinventory == null)
                return;
    
            if (!this._context.IsAttached(xmdeliveryproductinventory))
    			
                this._context.XMDeliveryProductInventories.AddObject(xmdeliveryproductinventory);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into XMDeliveryProductInventory
        /// </summary>
        /// <param name="xmdeliveryproductinventory">XMDeliveryProductInventory</param>
        public void UpdateXMDeliveryProductInventory(XMDeliveryProductInventory xmdeliveryproductinventory)
        {
            if (xmdeliveryproductinventory == null)
                return;
    
            if (this._context.IsAttached(xmdeliveryproductinventory))
                this._context.XMDeliveryProductInventories.Attach(xmdeliveryproductinventory);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to XMDeliveryProductInventory list
        /// </summary>
        public List<XMDeliveryProductInventory> GetXMDeliveryProductInventoryList()
        {		
            var query = from p in this._context.XMDeliveryProductInventories
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to XMDeliveryProductInventory Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMDeliveryProductInventory Page List</returns>
        public PagedList<XMDeliveryProductInventory> SearchXMDeliveryProductInventory(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMDeliveryProductInventories
                        orderby p.ID
                        select p;
            return new PagedList<XMDeliveryProductInventory>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a XMDeliveryProductInventory by ID
        /// </summary>
        /// <param name="id">XMDeliveryProductInventory ID</param>
        /// <returns>XMDeliveryProductInventory</returns>   
        public XMDeliveryProductInventory GetXMDeliveryProductInventoryByID(int id)
        {
            var query = from p in this._context.XMDeliveryProductInventories
                        where p.ID.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete XMDeliveryProductInventory by ID
        /// </summary>
        /// <param name="ID">XMDeliveryProductInventory ID</param>
        public void DeleteXMDeliveryProductInventory(int id)
        {
            var xmdeliveryproductinventory = this.GetXMDeliveryProductInventoryByID(id);
            if (xmdeliveryproductinventory == null)
                return;
    
            if (!this._context.IsAttached(xmdeliveryproductinventory))
                this._context.XMDeliveryProductInventories.Attach(xmdeliveryproductinventory);
    
            this._context.DeleteObject(xmdeliveryproductinventory);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete XMDeliveryProductInventory by ID
        /// </summary>
        /// <param name="IDs">XMDeliveryProductInventory ID</param>
        public void BatchDeleteXMDeliveryProductInventory(List<int> ids)
        {
    	   var query = from q in _context.XMDeliveryProductInventories
                    where ids.Contains(q.ID)
                    select q;
            var xmdeliveryproductinventorys = query.ToList();
            foreach (var item in xmdeliveryproductinventorys)
            {
                if (!_context.IsAttached(item))
                    _context.XMDeliveryProductInventories.Attach(item);  
    
                _context.XMDeliveryProductInventories.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
