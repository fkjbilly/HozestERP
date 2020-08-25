
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
    public partial class XMPremiumsDetailsService: IXMPremiumsDetailsService
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
    	public XMPremiumsDetailsService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region IXMPremiumsDetailsService成员
        /// <summary>
        /// Insert into XMPremiumsDetails
        /// </summary>
        /// <param name="xmpremiumsdetails">XMPremiumsDetails</param>
    	public void InsertXMPremiumsDetails(XMPremiumsDetails xmpremiumsdetails)
    	{	
            if (xmpremiumsdetails == null)
                return;
    
            if (!this._context.IsAttached(xmpremiumsdetails))
    			
                this._context.XMPremiumsDetails.AddObject(xmpremiumsdetails);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into XMPremiumsDetails
        /// </summary>
        /// <param name="xmpremiumsdetails">XMPremiumsDetails</param>
        public void UpdateXMPremiumsDetails(XMPremiumsDetails xmpremiumsdetails)
        {
            if (xmpremiumsdetails == null)
                return;
    
            if (this._context.IsAttached(xmpremiumsdetails))
                this._context.XMPremiumsDetails.Attach(xmpremiumsdetails);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to XMPremiumsDetails list
        /// </summary>
        public List<XMPremiumsDetails> GetXMPremiumsDetailsList()
        {		
            var query = from p in this._context.XMPremiumsDetails
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to XMPremiumsDetails Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMPremiumsDetails Page List</returns>
        public PagedList<XMPremiumsDetails> SearchXMPremiumsDetails(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMPremiumsDetails
                        orderby p.Id
                        select p;
            return new PagedList<XMPremiumsDetails>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a XMPremiumsDetails by Id
        /// </summary>
        /// <param name="id">XMPremiumsDetails Id</param>
        /// <returns>XMPremiumsDetails</returns>   
        public XMPremiumsDetails GetXMPremiumsDetailsById(int id)
        {
            var query = from p in this._context.XMPremiumsDetails
                        where p.Id.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete XMPremiumsDetails by Id
        /// </summary>
        /// <param name="Id">XMPremiumsDetails Id</param>
        public void DeleteXMPremiumsDetails(int id)
        {
            var xmpremiumsdetails = this.GetXMPremiumsDetailsById(id);
            if (xmpremiumsdetails == null)
                return;
    
            if (!this._context.IsAttached(xmpremiumsdetails))
                this._context.XMPremiumsDetails.Attach(xmpremiumsdetails);
    
            this._context.DeleteObject(xmpremiumsdetails);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete XMPremiumsDetails by Id
        /// </summary>
        /// <param name="Ids">XMPremiumsDetails Id</param>
        public void BatchDeleteXMPremiumsDetails(List<int> ids)
        {
    	   var query = from q in _context.XMPremiumsDetails
                    where ids.Contains(q.Id)
                    select q;
            var xmpremiumsdetailss = query.ToList();
            foreach (var item in xmpremiumsdetailss)
            {
                if (!_context.IsAttached(item))
                    _context.XMPremiumsDetails.Attach(item);  
    
                _context.XMPremiumsDetails.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
