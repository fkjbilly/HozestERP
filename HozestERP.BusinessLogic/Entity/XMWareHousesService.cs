
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
    public partial class XMWareHousesService: IXMWareHousesService
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
    	public XMWareHousesService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region IXMWareHousesService成员
        /// <summary>
        /// Insert into XMWareHouses
        /// </summary>
        /// <param name="xmwarehouses">XMWareHouses</param>
    	public void InsertXMWareHouses(XMWareHouses xmwarehouses)
    	{	
            if (xmwarehouses == null)
                return;
    
            if (!this._context.IsAttached(xmwarehouses))
    			
                this._context.XMWareHouses.AddObject(xmwarehouses);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into XMWareHouses
        /// </summary>
        /// <param name="xmwarehouses">XMWareHouses</param>
        public void UpdateXMWareHouses(XMWareHouses xmwarehouses)
        {
            if (xmwarehouses == null)
                return;
    
            if (this._context.IsAttached(xmwarehouses))
                this._context.XMWareHouses.Attach(xmwarehouses);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to XMWareHouses list
        /// </summary>
        public List<XMWareHouses> GetXMWareHousesList()
        {		
            var query = from p in this._context.XMWareHouses
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to XMWareHouses Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMWareHouses Page List</returns>
        public PagedList<XMWareHouses> SearchXMWareHouses(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMWareHouses
                        orderby p.Id
                        select p;
            return new PagedList<XMWareHouses>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a XMWareHouses by Id
        /// </summary>
        /// <param name="id">XMWareHouses Id</param>
        /// <returns>XMWareHouses</returns>   
        public XMWareHouses GetXMWareHousesById(int id)
        {
            var query = from p in this._context.XMWareHouses
                        where p.Id.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete XMWareHouses by Id
        /// </summary>
        /// <param name="Id">XMWareHouses Id</param>
        public void DeleteXMWareHouses(int id)
        {
            var xmwarehouses = this.GetXMWareHousesById(id);
            if (xmwarehouses == null)
                return;
    
            if (!this._context.IsAttached(xmwarehouses))
                this._context.XMWareHouses.Attach(xmwarehouses);
    
            this._context.DeleteObject(xmwarehouses);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete XMWareHouses by Id
        /// </summary>
        /// <param name="Ids">XMWareHouses Id</param>
        public void BatchDeleteXMWareHouses(List<int> ids)
        {
    	   var query = from q in _context.XMWareHouses
                    where ids.Contains(q.Id)
                    select q;
            var xmwarehousess = query.ToList();
            foreach (var item in xmwarehousess)
            {
                if (!_context.IsAttached(item))
                    _context.XMWareHouses.Attach(item);  
    
                _context.XMWareHouses.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
