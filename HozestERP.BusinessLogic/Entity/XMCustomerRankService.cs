
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
    public partial class XMCustomerRankService: IXMCustomerRankService
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
    	public XMCustomerRankService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region IXMCustomerRankService成员
        /// <summary>
        /// Insert into XMCustomerRank
        /// </summary>
        /// <param name="xmcustomerrank">XMCustomerRank</param>
    	public void InsertXMCustomerRank(XMCustomerRank xmcustomerrank)
    	{	
            if (xmcustomerrank == null)
                return;
    
            if (!this._context.IsAttached(xmcustomerrank))
    			
                this._context.XMCustomerRanks.AddObject(xmcustomerrank);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into XMCustomerRank
        /// </summary>
        /// <param name="xmcustomerrank">XMCustomerRank</param>
        public void UpdateXMCustomerRank(XMCustomerRank xmcustomerrank)
        {
            if (xmcustomerrank == null)
                return;
    
            if (this._context.IsAttached(xmcustomerrank))
                this._context.XMCustomerRanks.Attach(xmcustomerrank);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to XMCustomerRank list
        /// </summary>
        public List<XMCustomerRank> GetXMCustomerRankList()
        {		
            var query = from p in this._context.XMCustomerRanks
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to XMCustomerRank Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMCustomerRank Page List</returns>
        public PagedList<XMCustomerRank> SearchXMCustomerRank(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMCustomerRanks
                        orderby p.CustomerID
                        select p;
            return new PagedList<XMCustomerRank>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a XMCustomerRank by CustomerID
        /// </summary>
        /// <param name="customerid">XMCustomerRank CustomerID</param>
        /// <returns>XMCustomerRank</returns>   
        public XMCustomerRank GetXMCustomerRankByCustomerID(int customerid)
        {
            var query = from p in this._context.XMCustomerRanks
                        where p.CustomerID.Equals(customerid)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete XMCustomerRank by CustomerID
        /// </summary>
        /// <param name="CustomerID">XMCustomerRank CustomerID</param>
        public void DeleteXMCustomerRank(int customerid)
        {
            var xmcustomerrank = this.GetXMCustomerRankByCustomerID(customerid);
            if (xmcustomerrank == null)
                return;
    
            if (!this._context.IsAttached(xmcustomerrank))
                this._context.XMCustomerRanks.Attach(xmcustomerrank);
    
            this._context.DeleteObject(xmcustomerrank);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete XMCustomerRank by CustomerID
        /// </summary>
        /// <param name="CustomerIDs">XMCustomerRank CustomerID</param>
        public void BatchDeleteXMCustomerRank(List<int> customerids)
        {
    	   var query = from q in _context.XMCustomerRanks
                    where customerids.Contains(q.CustomerID)
                    select q;
            var xmcustomerranks = query.ToList();
            foreach (var item in xmcustomerranks)
            {
                if (!_context.IsAttached(item))
                    _context.XMCustomerRanks.Attach(item);  
    
                _context.XMCustomerRanks.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
