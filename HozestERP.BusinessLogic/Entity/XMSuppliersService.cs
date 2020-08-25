
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
    public partial class XMSuppliersService: IXMSuppliersService
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
    	public XMSuppliersService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region IXMSuppliersService成员
        /// <summary>
        /// Insert into XMSuppliers
        /// </summary>
        /// <param name="xmsuppliers">XMSuppliers</param>
    	public void InsertXMSuppliers(XMSuppliers xmsuppliers)
    	{	
            if (xmsuppliers == null)
                return;
    
            if (!this._context.IsAttached(xmsuppliers))
    			
                this._context.XMSuppliers.AddObject(xmsuppliers);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into XMSuppliers
        /// </summary>
        /// <param name="xmsuppliers">XMSuppliers</param>
        public void UpdateXMSuppliers(XMSuppliers xmsuppliers)
        {
            if (xmsuppliers == null)
                return;
    
            if (this._context.IsAttached(xmsuppliers))
                this._context.XMSuppliers.Attach(xmsuppliers);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to XMSuppliers list
        /// </summary>
        public List<XMSuppliers> GetXMSuppliersList()
        {		
            var query = from p in this._context.XMSuppliers
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to XMSuppliers Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMSuppliers Page List</returns>
        public PagedList<XMSuppliers> SearchXMSuppliers(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMSuppliers
                        orderby p.Id
                        select p;
            return new PagedList<XMSuppliers>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a XMSuppliers by Id
        /// </summary>
        /// <param name="id">XMSuppliers Id</param>
        /// <returns>XMSuppliers</returns>   
        public XMSuppliers GetXMSuppliersById(int id)
        {
            var query = from p in this._context.XMSuppliers
                        where p.Id.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete XMSuppliers by Id
        /// </summary>
        /// <param name="Id">XMSuppliers Id</param>
        public void DeleteXMSuppliers(int id)
        {
            var xmsuppliers = this.GetXMSuppliersById(id);
            if (xmsuppliers == null)
                return;
    
            if (!this._context.IsAttached(xmsuppliers))
                this._context.XMSuppliers.Attach(xmsuppliers);
    
            this._context.DeleteObject(xmsuppliers);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete XMSuppliers by Id
        /// </summary>
        /// <param name="Ids">XMSuppliers Id</param>
        public void BatchDeleteXMSuppliers(List<int> ids)
        {
    	   var query = from q in _context.XMSuppliers
                    where ids.Contains(q.Id)
                    select q;
            var xmsupplierss = query.ToList();
            foreach (var item in xmsupplierss)
            {
                if (!_context.IsAttached(item))
                    _context.XMSuppliers.Attach(item);  
    
                _context.XMSuppliers.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
