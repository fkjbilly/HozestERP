
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
    public partial class XMApplicationService: IXMApplicationService
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
    	public XMApplicationService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region IXMApplicationService成员
        /// <summary>
        /// Insert into XMApplication
        /// </summary>
        /// <param name="xmapplication">XMApplication</param>
    	public void InsertXMApplication(XMApplication xmapplication)
    	{	
            if (xmapplication == null)
                return;
    
            if (!this._context.IsAttached(xmapplication))
    			
                this._context.XMApplications.AddObject(xmapplication);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into XMApplication
        /// </summary>
        /// <param name="xmapplication">XMApplication</param>
        public void UpdateXMApplication(XMApplication xmapplication)
        {
            if (xmapplication == null)
                return;
    
            if (this._context.IsAttached(xmapplication))
                this._context.XMApplications.Attach(xmapplication);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to XMApplication list
        /// </summary>
        public List<XMApplication> GetXMApplicationList()
        {		
            var query = from p in this._context.XMApplications
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to XMApplication Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMApplication Page List</returns>
        public PagedList<XMApplication> SearchXMApplication(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMApplications
                        orderby p.ID
                        select p;
            return new PagedList<XMApplication>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a XMApplication by ID
        /// </summary>
        /// <param name="id">XMApplication ID</param>
        /// <returns>XMApplication</returns>   
        public XMApplication GetXMApplicationByID(int id)
        {
            var query = from p in this._context.XMApplications
                        where p.ID.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete XMApplication by ID
        /// </summary>
        /// <param name="ID">XMApplication ID</param>
        public void DeleteXMApplication(int id)
        {
            var xmapplication = this.GetXMApplicationByID(id);
            if (xmapplication == null)
                return;
    
            if (!this._context.IsAttached(xmapplication))
                this._context.XMApplications.Attach(xmapplication);
    
            this._context.DeleteObject(xmapplication);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete XMApplication by ID
        /// </summary>
        /// <param name="IDs">XMApplication ID</param>
        public void BatchDeleteXMApplication(List<int> ids)
        {
    	   var query = from q in _context.XMApplications
                    where ids.Contains(q.ID)
                    select q;
            var xmapplications = query.ToList();
            foreach (var item in xmapplications)
            {
                if (!_context.IsAttached(item))
                    _context.XMApplications.Attach(item);  
    
                _context.XMApplications.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
