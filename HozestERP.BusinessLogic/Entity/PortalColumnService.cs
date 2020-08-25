
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
    public partial class PortalColumnService: IPortalColumnService
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
    	public PortalColumnService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region IPortalColumnService成员
        /// <summary>
        /// Insert into PortalColumn
        /// </summary>
        /// <param name="portalcolumn">PortalColumn</param>
    	public void InsertPortalColumn(PortalColumn portalcolumn)
    	{	
            if (portalcolumn == null)
                return;
    
            if (!this._context.IsAttached(portalcolumn))
    			
                this._context.PortalColumns.AddObject(portalcolumn);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into PortalColumn
        /// </summary>
        /// <param name="portalcolumn">PortalColumn</param>
        public void UpdatePortalColumn(PortalColumn portalcolumn)
        {
            if (portalcolumn == null)
                return;
    
            if (this._context.IsAttached(portalcolumn))
                this._context.PortalColumns.Attach(portalcolumn);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to PortalColumn list
        /// </summary>
        public List<PortalColumn> GetPortalColumnList()
        {		
            var query = from p in this._context.PortalColumns
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to PortalColumn Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>PortalColumn Page List</returns>
        public PagedList<PortalColumn> SearchPortalColumn(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.PortalColumns
                        orderby p.ID
                        select p;
            return new PagedList<PortalColumn>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a PortalColumn by ID
        /// </summary>
        /// <param name="id">PortalColumn ID</param>
        /// <returns>PortalColumn</returns>   
        public PortalColumn GetPortalColumnByID(int id)
        {
            var query = from p in this._context.PortalColumns
                        where p.ID.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete PortalColumn by ID
        /// </summary>
        /// <param name="ID">PortalColumn ID</param>
        public void DeletePortalColumn(int id)
        {
            var portalcolumn = this.GetPortalColumnByID(id);
            if (portalcolumn == null)
                return;
    
            if (!this._context.IsAttached(portalcolumn))
                this._context.PortalColumns.Attach(portalcolumn);
    
            this._context.DeleteObject(portalcolumn);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete PortalColumn by ID
        /// </summary>
        /// <param name="IDs">PortalColumn ID</param>
        public void BatchDeletePortalColumn(List<int> ids)
        {
    	   var query = from q in _context.PortalColumns
                    where ids.Contains(q.ID)
                    select q;
            var portalcolumns = query.ToList();
            foreach (var item in portalcolumns)
            {
                if (!_context.IsAttached(item))
                    _context.PortalColumns.Attach(item);  
    
                _context.PortalColumns.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
