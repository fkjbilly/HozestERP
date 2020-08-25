
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
    public partial class PortalColumnNumberService: IPortalColumnNumberService
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
    	public PortalColumnNumberService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region IPortalColumnNumberService成员
        /// <summary>
        /// Insert into PortalColumnNumber
        /// </summary>
        /// <param name="portalcolumnnumber">PortalColumnNumber</param>
    	public void InsertPortalColumnNumber(PortalColumnNumber portalcolumnnumber)
    	{	
            if (portalcolumnnumber == null)
                return;
    
            if (!this._context.IsAttached(portalcolumnnumber))
    			
                this._context.PortalColumnNumbers.AddObject(portalcolumnnumber);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into PortalColumnNumber
        /// </summary>
        /// <param name="portalcolumnnumber">PortalColumnNumber</param>
        public void UpdatePortalColumnNumber(PortalColumnNumber portalcolumnnumber)
        {
            if (portalcolumnnumber == null)
                return;
    
            if (this._context.IsAttached(portalcolumnnumber))
                this._context.PortalColumnNumbers.Attach(portalcolumnnumber);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to PortalColumnNumber list
        /// </summary>
        public List<PortalColumnNumber> GetPortalColumnNumberList()
        {		
            var query = from p in this._context.PortalColumnNumbers
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to PortalColumnNumber Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>PortalColumnNumber Page List</returns>
        public PagedList<PortalColumnNumber> SearchPortalColumnNumber(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.PortalColumnNumbers
                        orderby p.ID
                        select p;
            return new PagedList<PortalColumnNumber>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a PortalColumnNumber by ID
        /// </summary>
        /// <param name="id">PortalColumnNumber ID</param>
        /// <returns>PortalColumnNumber</returns>   
        public PortalColumnNumber GetPortalColumnNumberByID(int id)
        {
            var query = from p in this._context.PortalColumnNumbers
                        where p.ID.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete PortalColumnNumber by ID
        /// </summary>
        /// <param name="ID">PortalColumnNumber ID</param>
        public void DeletePortalColumnNumber(int id)
        {
            var portalcolumnnumber = this.GetPortalColumnNumberByID(id);
            if (portalcolumnnumber == null)
                return;
    
            if (!this._context.IsAttached(portalcolumnnumber))
                this._context.PortalColumnNumbers.Attach(portalcolumnnumber);
    
            this._context.DeleteObject(portalcolumnnumber);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete PortalColumnNumber by ID
        /// </summary>
        /// <param name="IDs">PortalColumnNumber ID</param>
        public void BatchDeletePortalColumnNumber(List<int> ids)
        {
    	   var query = from q in _context.PortalColumnNumbers
                    where ids.Contains(q.ID)
                    select q;
            var portalcolumnnumbers = query.ToList();
            foreach (var item in portalcolumnnumbers)
            {
                if (!_context.IsAttached(item))
                    _context.PortalColumnNumbers.Attach(item);  
    
                _context.PortalColumnNumbers.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
