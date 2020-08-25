
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
    public partial class XMCustomerWangNoService: IXMCustomerWangNoService
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
    	public XMCustomerWangNoService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region IXMCustomerWangNoService成员
        /// <summary>
        /// Insert into XMCustomerWangNo
        /// </summary>
        /// <param name="xmcustomerwangno">XMCustomerWangNo</param>
    	public void InsertXMCustomerWangNo(XMCustomerWangNo xmcustomerwangno)
    	{	
            if (xmcustomerwangno == null)
                return;
    
            if (!this._context.IsAttached(xmcustomerwangno))
    			
                this._context.XMCustomerWangNoes.AddObject(xmcustomerwangno);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into XMCustomerWangNo
        /// </summary>
        /// <param name="xmcustomerwangno">XMCustomerWangNo</param>
        public void UpdateXMCustomerWangNo(XMCustomerWangNo xmcustomerwangno)
        {
            if (xmcustomerwangno == null)
                return;
    
            if (this._context.IsAttached(xmcustomerwangno))
                this._context.XMCustomerWangNoes.Attach(xmcustomerwangno);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to XMCustomerWangNo list
        /// </summary>
        public List<XMCustomerWangNo> GetXMCustomerWangNoList()
        {		
            var query = from p in this._context.XMCustomerWangNoes
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to XMCustomerWangNo Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMCustomerWangNo Page List</returns>
        public PagedList<XMCustomerWangNo> SearchXMCustomerWangNo(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMCustomerWangNoes
                        orderby p.ID
                        select p;
            return new PagedList<XMCustomerWangNo>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a XMCustomerWangNo by ID
        /// </summary>
        /// <param name="id">XMCustomerWangNo ID</param>
        /// <returns>XMCustomerWangNo</returns>   
        public XMCustomerWangNo GetXMCustomerWangNoByID(int id)
        {
            var query = from p in this._context.XMCustomerWangNoes
                        where p.ID.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete XMCustomerWangNo by ID
        /// </summary>
        /// <param name="ID">XMCustomerWangNo ID</param>
        public void DeleteXMCustomerWangNo(int id)
        {
            var xmcustomerwangno = this.GetXMCustomerWangNoByID(id);
            if (xmcustomerwangno == null)
                return;
    
            if (!this._context.IsAttached(xmcustomerwangno))
                this._context.XMCustomerWangNoes.Attach(xmcustomerwangno);
    
            this._context.DeleteObject(xmcustomerwangno);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete XMCustomerWangNo by ID
        /// </summary>
        /// <param name="IDs">XMCustomerWangNo ID</param>
        public void BatchDeleteXMCustomerWangNo(List<int> ids)
        {
    	   var query = from q in _context.XMCustomerWangNoes
                    where ids.Contains(q.ID)
                    select q;
            var xmcustomerwangnos = query.ToList();
            foreach (var item in xmcustomerwangnos)
            {
                if (!_context.IsAttached(item))
                    _context.XMCustomerWangNoes.Attach(item);  
    
                _context.XMCustomerWangNoes.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
