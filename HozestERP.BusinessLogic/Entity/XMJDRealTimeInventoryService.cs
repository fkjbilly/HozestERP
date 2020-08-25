
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
    public partial class XMJDRealTimeInventoryService: IXMJDRealTimeInventoryService
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
    	public XMJDRealTimeInventoryService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region IXMJDRealTimeInventoryService成员
        /// <summary>
        /// Insert into XMJDRealTimeInventory
        /// </summary>
        /// <param name="xmjdrealtimeinventory">XMJDRealTimeInventory</param>
    	public void InsertXMJDRealTimeInventory(XMJDRealTimeInventory xmjdrealtimeinventory)
    	{	
            if (xmjdrealtimeinventory == null)
                return;
    
            if (!this._context.IsAttached(xmjdrealtimeinventory))
    			
                this._context.XMJDRealTimeInventories.AddObject(xmjdrealtimeinventory);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into XMJDRealTimeInventory
        /// </summary>
        /// <param name="xmjdrealtimeinventory">XMJDRealTimeInventory</param>
        public void UpdateXMJDRealTimeInventory(XMJDRealTimeInventory xmjdrealtimeinventory)
        {
            if (xmjdrealtimeinventory == null)
                return;
    
            if (this._context.IsAttached(xmjdrealtimeinventory))
                this._context.XMJDRealTimeInventories.Attach(xmjdrealtimeinventory);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to XMJDRealTimeInventory list
        /// </summary>
        public List<XMJDRealTimeInventory> GetXMJDRealTimeInventoryList()
        {		
            var query = from p in this._context.XMJDRealTimeInventories
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to XMJDRealTimeInventory Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMJDRealTimeInventory Page List</returns>
        public PagedList<XMJDRealTimeInventory> SearchXMJDRealTimeInventory(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMJDRealTimeInventories
                        orderby p.Id
                        select p;
            return new PagedList<XMJDRealTimeInventory>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a XMJDRealTimeInventory by Id
        /// </summary>
        /// <param name="id">XMJDRealTimeInventory Id</param>
        /// <returns>XMJDRealTimeInventory</returns>   
        public XMJDRealTimeInventory GetXMJDRealTimeInventoryById(int id)
        {
            var query = from p in this._context.XMJDRealTimeInventories
                        where p.Id.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete XMJDRealTimeInventory by Id
        /// </summary>
        /// <param name="Id">XMJDRealTimeInventory Id</param>
        public void DeleteXMJDRealTimeInventory(int id)
        {
            var xmjdrealtimeinventory = this.GetXMJDRealTimeInventoryById(id);
            if (xmjdrealtimeinventory == null)
                return;
    
            if (!this._context.IsAttached(xmjdrealtimeinventory))
                this._context.XMJDRealTimeInventories.Attach(xmjdrealtimeinventory);
    
            this._context.DeleteObject(xmjdrealtimeinventory);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete XMJDRealTimeInventory by Id
        /// </summary>
        /// <param name="Ids">XMJDRealTimeInventory Id</param>
        public void BatchDeleteXMJDRealTimeInventory(List<int> ids)
        {
    	   var query = from q in _context.XMJDRealTimeInventories
                    where ids.Contains(q.Id)
                    select q;
            var xmjdrealtimeinventorys = query.ToList();
            foreach (var item in xmjdrealtimeinventorys)
            {
                if (!_context.IsAttached(item))
                    _context.XMJDRealTimeInventories.Attach(item);  
    
                _context.XMJDRealTimeInventories.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
