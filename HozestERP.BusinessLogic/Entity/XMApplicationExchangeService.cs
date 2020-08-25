
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
    public partial class XMApplicationExchangeService: IXMApplicationExchangeService
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
    	public XMApplicationExchangeService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region IXMApplicationExchangeService成员
        /// <summary>
        /// Insert into XMApplicationExchange
        /// </summary>
        /// <param name="xmapplicationexchange">XMApplicationExchange</param>
    	public void InsertXMApplicationExchange(XMApplicationExchange xmapplicationexchange)
    	{	
            if (xmapplicationexchange == null)
                return;
    
            if (!this._context.IsAttached(xmapplicationexchange))
    			
                this._context.XMApplicationExchanges.AddObject(xmapplicationexchange);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into XMApplicationExchange
        /// </summary>
        /// <param name="xmapplicationexchange">XMApplicationExchange</param>
        public void UpdateXMApplicationExchange(XMApplicationExchange xmapplicationexchange)
        {
            if (xmapplicationexchange == null)
                return;
    
            if (this._context.IsAttached(xmapplicationexchange))
                this._context.XMApplicationExchanges.Attach(xmapplicationexchange);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to XMApplicationExchange list
        /// </summary>
        public List<XMApplicationExchange> GetXMApplicationExchangeList()
        {		
            var query = from p in this._context.XMApplicationExchanges
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to XMApplicationExchange Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMApplicationExchange Page List</returns>
        public PagedList<XMApplicationExchange> SearchXMApplicationExchange(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMApplicationExchanges
                        orderby p.ID
                        select p;
            return new PagedList<XMApplicationExchange>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a XMApplicationExchange by ID
        /// </summary>
        /// <param name="id">XMApplicationExchange ID</param>
        /// <returns>XMApplicationExchange</returns>   
        public XMApplicationExchange GetXMApplicationExchangeByID(int id)
        {
            var query = from p in this._context.XMApplicationExchanges
                        where p.ID.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete XMApplicationExchange by ID
        /// </summary>
        /// <param name="ID">XMApplicationExchange ID</param>
        public void DeleteXMApplicationExchange(int id)
        {
            var xmapplicationexchange = this.GetXMApplicationExchangeByID(id);
            if (xmapplicationexchange == null)
                return;
    
            if (!this._context.IsAttached(xmapplicationexchange))
                this._context.XMApplicationExchanges.Attach(xmapplicationexchange);
    
            this._context.DeleteObject(xmapplicationexchange);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete XMApplicationExchange by ID
        /// </summary>
        /// <param name="IDs">XMApplicationExchange ID</param>
        public void BatchDeleteXMApplicationExchange(List<int> ids)
        {
    	   var query = from q in _context.XMApplicationExchanges
                    where ids.Contains(q.ID)
                    select q;
            var xmapplicationexchanges = query.ToList();
            foreach (var item in xmapplicationexchanges)
            {
                if (!_context.IsAttached(item))
                    _context.XMApplicationExchanges.Attach(item);  
    
                _context.XMApplicationExchanges.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
