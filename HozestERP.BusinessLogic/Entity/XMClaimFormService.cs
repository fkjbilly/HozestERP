
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
    public partial class XMClaimFormService: IXMClaimFormService
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
    	public XMClaimFormService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region IXMClaimFormService成员
        /// <summary>
        /// Insert into XMClaimForm
        /// </summary>
        /// <param name="xmclaimform">XMClaimForm</param>
    	public void InsertXMClaimForm(XMClaimForm xmclaimform)
    	{	
            if (xmclaimform == null)
                return;
    
            if (!this._context.IsAttached(xmclaimform))
    			
                this._context.XMClaimForms.AddObject(xmclaimform);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into XMClaimForm
        /// </summary>
        /// <param name="xmclaimform">XMClaimForm</param>
        public void UpdateXMClaimForm(XMClaimForm xmclaimform)
        {
            if (xmclaimform == null)
                return;
    
            if (this._context.IsAttached(xmclaimform))
                this._context.XMClaimForms.Attach(xmclaimform);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to XMClaimForm list
        /// </summary>
        public List<XMClaimForm> GetXMClaimFormList()
        {		
            var query = from p in this._context.XMClaimForms
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to XMClaimForm Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMClaimForm Page List</returns>
        public PagedList<XMClaimForm> SearchXMClaimForm(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMClaimForms
                        orderby p.ID
                        select p;
            return new PagedList<XMClaimForm>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a XMClaimForm by ID
        /// </summary>
        /// <param name="id">XMClaimForm ID</param>
        /// <returns>XMClaimForm</returns>   
        public XMClaimForm GetXMClaimFormByID(int id)
        {
            var query = from p in this._context.XMClaimForms
                        where p.ID.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete XMClaimForm by ID
        /// </summary>
        /// <param name="ID">XMClaimForm ID</param>
        public void DeleteXMClaimForm(int id)
        {
            var xmclaimform = this.GetXMClaimFormByID(id);
            if (xmclaimform == null)
                return;
    
            if (!this._context.IsAttached(xmclaimform))
                this._context.XMClaimForms.Attach(xmclaimform);
    
            this._context.DeleteObject(xmclaimform);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete XMClaimForm by ID
        /// </summary>
        /// <param name="IDs">XMClaimForm ID</param>
        public void BatchDeleteXMClaimForm(List<int> ids)
        {
    	   var query = from q in _context.XMClaimForms
                    where ids.Contains(q.ID)
                    select q;
            var xmclaimforms = query.ToList();
            foreach (var item in xmclaimforms)
            {
                if (!_context.IsAttached(item))
                    _context.XMClaimForms.Attach(item);  
    
                _context.XMClaimForms.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
