
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
    public partial class PortalService: IPortalService
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
    	public PortalService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region IPortalService成员
        /// <summary>
        /// Insert into Portal
        /// </summary>
        /// <param name="portal">Portal</param>
    	public void InsertPortal(Portal portal)
    	{	
            if (portal == null)
                return;
    
            if (!this._context.IsAttached(portal))
    			
                this._context.Portals.AddObject(portal);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into Portal
        /// </summary>
        /// <param name="portal">Portal</param>
        public void UpdatePortal(Portal portal)
        {
            if (portal == null)
                return;
    
            if (this._context.IsAttached(portal))
                this._context.Portals.Attach(portal);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to Portal list
        /// </summary>
        public List<Portal> GetPortalList()
        {		
            var query = from p in this._context.Portals
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to Portal Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>Portal Page List</returns>
        public PagedList<Portal> SearchPortal(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.Portals
                        orderby p.ID
                        select p;
            return new PagedList<Portal>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a Portal by ID
        /// </summary>
        /// <param name="id">Portal ID</param>
        /// <returns>Portal</returns>   
        public Portal GetPortalByID(int id)
        {
            var query = from p in this._context.Portals
                        where p.ID.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete Portal by ID
        /// </summary>
        /// <param name="ID">Portal ID</param>
        public void DeletePortal(int id)
        {
            var portal = this.GetPortalByID(id);
            if (portal == null)
                return;
    
            if (!this._context.IsAttached(portal))
                this._context.Portals.Attach(portal);
    
            this._context.DeleteObject(portal);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete Portal by ID
        /// </summary>
        /// <param name="IDs">Portal ID</param>
        public void BatchDeletePortal(List<int> ids)
        {
    	   var query = from q in _context.Portals
                    where ids.Contains(q.ID)
                    select q;
            var portals = query.ToList();
            foreach (var item in portals)
            {
                if (!_context.IsAttached(item))
                    _context.Portals.Attach(item);  
    
                _context.Portals.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
