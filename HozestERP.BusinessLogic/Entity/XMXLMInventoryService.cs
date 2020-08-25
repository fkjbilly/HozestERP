
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
    public partial class XMXLMInventoryService: IXMXLMInventoryService
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
    	public XMXLMInventoryService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region IXMXLMInventoryService成员
        /// <summary>
        /// Insert into XMXLMInventory
        /// </summary>
        /// <param name="xmxlminventory">XMXLMInventory</param>
    	public void InsertXMXLMInventory(XMXLMInventory xmxlminventory)
    	{	
            if (xmxlminventory == null)
                return;
    
            if (!this._context.IsAttached(xmxlminventory))
    			
                this._context.XMXLMInventories.AddObject(xmxlminventory);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into XMXLMInventory
        /// </summary>
        /// <param name="xmxlminventory">XMXLMInventory</param>
        public void UpdateXMXLMInventory(XMXLMInventory xmxlminventory)
        {
            if (xmxlminventory == null)
                return;
    
            if (this._context.IsAttached(xmxlminventory))
                this._context.XMXLMInventories.Attach(xmxlminventory);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to XMXLMInventory list
        /// </summary>
        public List<XMXLMInventory> GetXMXLMInventoryList()
        {		
            var query = from p in this._context.XMXLMInventories
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to XMXLMInventory Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMXLMInventory Page List</returns>
        public PagedList<XMXLMInventory> SearchXMXLMInventory(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMXLMInventories
                        orderby p.ID
                        select p;
            return new PagedList<XMXLMInventory>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a XMXLMInventory by ID
        /// </summary>
        /// <param name="id">XMXLMInventory ID</param>
        /// <returns>XMXLMInventory</returns>   
        public XMXLMInventory GetXMXLMInventoryByID(int id)
        {
            var query = from p in this._context.XMXLMInventories
                        where p.ID.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete XMXLMInventory by ID
        /// </summary>
        /// <param name="ID">XMXLMInventory ID</param>
        public void DeleteXMXLMInventory(int id)
        {
            var xmxlminventory = this.GetXMXLMInventoryByID(id);
            if (xmxlminventory == null)
                return;
    
            if (!this._context.IsAttached(xmxlminventory))
                this._context.XMXLMInventories.Attach(xmxlminventory);
    
            this._context.DeleteObject(xmxlminventory);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete XMXLMInventory by ID
        /// </summary>
        /// <param name="IDs">XMXLMInventory ID</param>
        public void BatchDeleteXMXLMInventory(List<int> ids)
        {
    	   var query = from q in _context.XMXLMInventories
                    where ids.Contains(q.ID)
                    select q;
            var xmxlminventorys = query.ToList();
            foreach (var item in xmxlminventorys)
            {
                if (!_context.IsAttached(item))
                    _context.XMXLMInventories.Attach(item);  
    
                _context.XMXLMInventories.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
