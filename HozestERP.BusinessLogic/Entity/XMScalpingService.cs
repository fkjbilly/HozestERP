
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
    public partial class XMScalpingService: IXMScalpingService
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
    	public XMScalpingService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region IXMScalpingService成员
        /// <summary>
        /// Insert into XMScalping
        /// </summary>
        /// <param name="xmscalping">XMScalping</param>
    	public void InsertXMScalping(XMScalping xmscalping)
    	{	
            if (xmscalping == null)
                return;
    
            if (!this._context.IsAttached(xmscalping))
    			
                this._context.XMScalpings.AddObject(xmscalping);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into XMScalping
        /// </summary>
        /// <param name="xmscalping">XMScalping</param>
        public void UpdateXMScalping(XMScalping xmscalping)
        {
            if (xmscalping == null)
                return;
    
            if (this._context.IsAttached(xmscalping))
                this._context.XMScalpings.Attach(xmscalping);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to XMScalping list
        /// </summary>
        public List<XMScalping> GetXMScalpingList()
        {		
            var query = from p in this._context.XMScalpings
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to XMScalping Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMScalping Page List</returns>
        public PagedList<XMScalping> SearchXMScalping(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMScalpings
                        orderby p.ID
                        select p;
            return new PagedList<XMScalping>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a XMScalping by ID
        /// </summary>
        /// <param name="id">XMScalping ID</param>
        /// <returns>XMScalping</returns>   
        public XMScalping GetXMScalpingByID(int id)
        {
            var query = from p in this._context.XMScalpings
                        where p.ID.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete XMScalping by ID
        /// </summary>
        /// <param name="ID">XMScalping ID</param>
        public void DeleteXMScalping(int id)
        {
            var xmscalping = this.GetXMScalpingByID(id);
            if (xmscalping == null)
                return;
    
            if (!this._context.IsAttached(xmscalping))
                this._context.XMScalpings.Attach(xmscalping);
    
            this._context.DeleteObject(xmscalping);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete XMScalping by ID
        /// </summary>
        /// <param name="IDs">XMScalping ID</param>
        public void BatchDeleteXMScalping(List<int> ids)
        {
    	   var query = from q in _context.XMScalpings
                    where ids.Contains(q.ID)
                    select q;
            var xmscalpings = query.ToList();
            foreach (var item in xmscalpings)
            {
                if (!_context.IsAttached(item))
                    _context.XMScalpings.Attach(item);  
    
                _context.XMScalpings.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
