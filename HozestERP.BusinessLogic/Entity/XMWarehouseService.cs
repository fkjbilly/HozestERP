
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
    public partial class XMWarehouseService: IXMWarehouseService
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
    	public XMWarehouseService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region IXMWarehouseService成员
        /// <summary>
        /// Insert into XMWarehouse
        /// </summary>
        /// <param name="xmwarehouse">XMWarehouse</param>
    	public void InsertXMWarehouse(XMWarehouse xmwarehouse)
    	{	
            if (xmwarehouse == null)
                return;
    
            if (!this._context.IsAttached(xmwarehouse))
    			
                this._context.XMWarehouses.AddObject(xmwarehouse);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into XMWarehouse
        /// </summary>
        /// <param name="xmwarehouse">XMWarehouse</param>
        public void UpdateXMWarehouse(XMWarehouse xmwarehouse)
        {
            if (xmwarehouse == null)
                return;
    
            if (this._context.IsAttached(xmwarehouse))
                this._context.XMWarehouses.Attach(xmwarehouse);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to XMWarehouse list
        /// </summary>
        public List<XMWarehouse> GetXMWarehouseList()
        {		
            var query = from p in this._context.XMWarehouses
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to XMWarehouse Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMWarehouse Page List</returns>
        public PagedList<XMWarehouse> SearchXMWarehouse(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMWarehouses
                        orderby p.ID
                        select p;
            return new PagedList<XMWarehouse>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a XMWarehouse by ID
        /// </summary>
        /// <param name="id">XMWarehouse ID</param>
        /// <returns>XMWarehouse</returns>   
        public XMWarehouse GetXMWarehouseByID(int id)
        {
            var query = from p in this._context.XMWarehouses
                        where p.ID.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete XMWarehouse by ID
        /// </summary>
        /// <param name="ID">XMWarehouse ID</param>
        public void DeleteXMWarehouse(int id)
        {
            var xmwarehouse = this.GetXMWarehouseByID(id);
            if (xmwarehouse == null)
                return;
    
            if (!this._context.IsAttached(xmwarehouse))
                this._context.XMWarehouses.Attach(xmwarehouse);
    
            this._context.DeleteObject(xmwarehouse);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete XMWarehouse by ID
        /// </summary>
        /// <param name="IDs">XMWarehouse ID</param>
        public void BatchDeleteXMWarehouse(List<int> ids)
        {
    	   var query = from q in _context.XMWarehouses
                    where ids.Contains(q.ID)
                    select q;
            var xmwarehouses = query.ToList();
            foreach (var item in xmwarehouses)
            {
                if (!_context.IsAttached(item))
                    _context.XMWarehouses.Attach(item);  
    
                _context.XMWarehouses.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
