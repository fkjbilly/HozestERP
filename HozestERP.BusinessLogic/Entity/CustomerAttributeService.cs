
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
    public partial class CustomerAttributeService: ICustomerAttributeService
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
    	public CustomerAttributeService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region ICustomerAttributeService成员
        /// <summary>
        /// Insert into CustomerAttribute
        /// </summary>
        /// <param name="customerattribute">CustomerAttribute</param>
    	public void InsertCustomerAttribute(CustomerAttribute customerattribute)
    	{	
            if (customerattribute == null)
                return;
    
            if (!this._context.IsAttached(customerattribute))
    			
                this._context.CustomerAttributes.AddObject(customerattribute);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into CustomerAttribute
        /// </summary>
        /// <param name="customerattribute">CustomerAttribute</param>
        public void UpdateCustomerAttribute(CustomerAttribute customerattribute)
        {
            if (customerattribute == null)
                return;
    
            if (this._context.IsAttached(customerattribute))
                this._context.CustomerAttributes.Attach(customerattribute);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to CustomerAttribute list
        /// </summary>
        public List<CustomerAttribute> GetCustomerAttributeList()
        {		
            var query = from p in this._context.CustomerAttributes
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to CustomerAttribute Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>CustomerAttribute Page List</returns>
        public PagedList<CustomerAttribute> SearchCustomerAttribute(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.CustomerAttributes
                        orderby p.CustomerAttributeId
                        select p;
            return new PagedList<CustomerAttribute>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a CustomerAttribute by CustomerAttributeId
        /// </summary>
        /// <param name="customerattributeid">CustomerAttribute CustomerAttributeId</param>
        /// <returns>CustomerAttribute</returns>   
        public CustomerAttribute GetCustomerAttributeByCustomerAttributeId(int customerattributeid)
        {
            var query = from p in this._context.CustomerAttributes
                        where p.CustomerAttributeId.Equals(customerattributeid)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete CustomerAttribute by CustomerAttributeId
        /// </summary>
        /// <param name="CustomerAttributeId">CustomerAttribute CustomerAttributeId</param>
        public void DeleteCustomerAttribute(int customerattributeid)
        {
            var customerattribute = this.GetCustomerAttributeByCustomerAttributeId(customerattributeid);
            if (customerattribute == null)
                return;
    
            if (!this._context.IsAttached(customerattribute))
                this._context.CustomerAttributes.Attach(customerattribute);
    
            this._context.DeleteObject(customerattribute);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete CustomerAttribute by CustomerAttributeId
        /// </summary>
        /// <param name="CustomerAttributeIds">CustomerAttribute CustomerAttributeId</param>
        public void BatchDeleteCustomerAttribute(List<int> customerattributeids)
        {
    	   var query = from q in _context.CustomerAttributes
                    where customerattributeids.Contains(q.CustomerAttributeId)
                    select q;
            var customerattributes = query.ToList();
            foreach (var item in customerattributes)
            {
                if (!_context.IsAttached(item))
                    _context.CustomerAttributes.Attach(item);  
    
                _context.CustomerAttributes.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
