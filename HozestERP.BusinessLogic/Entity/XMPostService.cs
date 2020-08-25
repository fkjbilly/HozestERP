
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
    public partial class XMPostService: IXMPostService
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
    	public XMPostService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region IXMPostService成员
        /// <summary>
        /// Insert into XMPost
        /// </summary>
        /// <param name="xmpost">XMPost</param>
    	public void InsertXMPost(XMPost xmpost)
    	{	
            if (xmpost == null)
                return;
    
            if (!this._context.IsAttached(xmpost))
    			
                this._context.XMPosts.AddObject(xmpost);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into XMPost
        /// </summary>
        /// <param name="xmpost">XMPost</param>
        public void UpdateXMPost(XMPost xmpost)
        {
            if (xmpost == null)
                return;
    
            if (this._context.IsAttached(xmpost))
                this._context.XMPosts.Attach(xmpost);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to XMPost list
        /// </summary>
        public List<XMPost> GetXMPostList()
        {		
            var query = from p in this._context.XMPosts
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to XMPost Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMPost Page List</returns>
        public PagedList<XMPost> SearchXMPost(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMPosts
                        orderby p.Id
                        select p;
            return new PagedList<XMPost>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a XMPost by Id
        /// </summary>
        /// <param name="id">XMPost Id</param>
        /// <returns>XMPost</returns>   
        public XMPost GetXMPostById(int id)
        {
            var query = from p in this._context.XMPosts
                        where p.Id.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete XMPost by Id
        /// </summary>
        /// <param name="Id">XMPost Id</param>
        public void DeleteXMPost(int id)
        {
            var xmpost = this.GetXMPostById(id);
            if (xmpost == null)
                return;
    
            if (!this._context.IsAttached(xmpost))
                this._context.XMPosts.Attach(xmpost);
    
            this._context.DeleteObject(xmpost);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete XMPost by Id
        /// </summary>
        /// <param name="Ids">XMPost Id</param>
        public void BatchDeleteXMPost(List<int> ids)
        {
    	   var query = from q in _context.XMPosts
                    where ids.Contains(q.Id)
                    select q;
            var xmposts = query.ToList();
            foreach (var item in xmposts)
            {
                if (!_context.IsAttached(item))
                    _context.XMPosts.Attach(item);  
    
                _context.XMPosts.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
