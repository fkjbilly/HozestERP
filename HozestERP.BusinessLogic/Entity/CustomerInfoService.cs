
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
    public partial class CustomerInfoService: ICustomerInfoService
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
    	public CustomerInfoService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region ICustomerInfoService成员
        /// <summary>
        /// Insert into CustomerInfo
        /// </summary>
        /// <param name="customerinfo">CustomerInfo</param>
    	public void InsertCustomerInfo(CustomerInfo customerinfo)
    	{	
            if (customerinfo == null)
                return;
    
            if (!this._context.IsAttached(customerinfo))
    			
                this._context.CustomerInfoes.AddObject(customerinfo);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into CustomerInfo
        /// </summary>
        /// <param name="customerinfo">CustomerInfo</param>
        public void UpdateCustomerInfo(CustomerInfo customerinfo)
        {
            if (customerinfo == null)
                return;
    
            if (this._context.IsAttached(customerinfo))
                this._context.CustomerInfoes.Attach(customerinfo);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to CustomerInfo list
        /// </summary>
        public List<CustomerInfo> GetCustomerInfoList()
        {		
            var query = from p in this._context.CustomerInfoes
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to CustomerInfo Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>CustomerInfo Page List</returns>
        public PagedList<CustomerInfo> SearchCustomerInfo(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.CustomerInfoes
                        orderby p.CustomerID
                        select p;
            return new PagedList<CustomerInfo>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a CustomerInfo by CustomerID
        /// </summary>
        /// <param name="customerid">CustomerInfo CustomerID</param>
        /// <returns>CustomerInfo</returns>   
        public CustomerInfo GetCustomerInfoByCustomerID(int customerid)
        {
            var query = from p in this._context.CustomerInfoes
                        where p.CustomerID.Equals(customerid)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete CustomerInfo by CustomerID
        /// </summary>
        /// <param name="CustomerID">CustomerInfo CustomerID</param>
        public void DeleteCustomerInfo(int customerid)
        {
            var customerinfo = this.GetCustomerInfoByCustomerID(customerid);
            if (customerinfo == null)
                return;
    
            if (!this._context.IsAttached(customerinfo))
                this._context.CustomerInfoes.Attach(customerinfo);
    
            this._context.DeleteObject(customerinfo);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete CustomerInfo by CustomerID
        /// </summary>
        /// <param name="CustomerIDs">CustomerInfo CustomerID</param>
        public void BatchDeleteCustomerInfo(List<int> customerids)
        {
    	   var query = from q in _context.CustomerInfoes
                    where customerids.Contains(q.CustomerID)
                    select q;
            var customerinfos = query.ToList();
            foreach (var item in customerinfos)
            {
                if (!_context.IsAttached(item))
                    _context.CustomerInfoes.Attach(item);  
    
                _context.CustomerInfoes.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
