
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
    public partial class XMInstallationListService: IXMInstallationListService
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
    	public XMInstallationListService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region IXMInstallationListService成员
        /// <summary>
        /// Insert into XMInstallationList
        /// </summary>
        /// <param name="xminstallationlist">XMInstallationList</param>
    	public void InsertXMInstallationList(XMInstallationList xminstallationlist)
    	{	
            if (xminstallationlist == null)
                return;
    
            if (!this._context.IsAttached(xminstallationlist))
    			
                this._context.XMInstallationLists.AddObject(xminstallationlist);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into XMInstallationList
        /// </summary>
        /// <param name="xminstallationlist">XMInstallationList</param>
        public void UpdateXMInstallationList(XMInstallationList xminstallationlist)
        {
            if (xminstallationlist == null)
                return;
    
            if (this._context.IsAttached(xminstallationlist))
                this._context.XMInstallationLists.Attach(xminstallationlist);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to XMInstallationList list
        /// </summary>
        public List<XMInstallationList> GetXMInstallationListList()
        {		
            var query = from p in this._context.XMInstallationLists
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to XMInstallationList Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMInstallationList Page List</returns>
        public PagedList<XMInstallationList> SearchXMInstallationList(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMInstallationLists
                        orderby p.ID
                        select p;
            return new PagedList<XMInstallationList>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a XMInstallationList by ID
        /// </summary>
        /// <param name="id">XMInstallationList ID</param>
        /// <returns>XMInstallationList</returns>   
        public XMInstallationList GetXMInstallationListByID(int id)
        {
            var query = from p in this._context.XMInstallationLists
                        where p.ID.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete XMInstallationList by ID
        /// </summary>
        /// <param name="ID">XMInstallationList ID</param>
        public void DeleteXMInstallationList(int id)
        {
            var xminstallationlist = this.GetXMInstallationListByID(id);
            if (xminstallationlist == null)
                return;
    
            if (!this._context.IsAttached(xminstallationlist))
                this._context.XMInstallationLists.Attach(xminstallationlist);
    
            this._context.DeleteObject(xminstallationlist);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete XMInstallationList by ID
        /// </summary>
        /// <param name="IDs">XMInstallationList ID</param>
        public void BatchDeleteXMInstallationList(List<int> ids)
        {
    	   var query = from q in _context.XMInstallationLists
                    where ids.Contains(q.ID)
                    select q;
            var xminstallationlists = query.ToList();
            foreach (var item in xminstallationlists)
            {
                if (!_context.IsAttached(item))
                    _context.XMInstallationLists.Attach(item);  
    
                _context.XMInstallationLists.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
