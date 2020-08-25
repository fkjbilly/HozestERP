
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
    public partial class CustomerRoleService: ICustomerRoleService
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
    	public CustomerRoleService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region ICustomerRoleService成员
        /// <summary>
        /// Insert into CustomerRole
        /// </summary>
        /// <param name="customerrole">CustomerRole</param>
    	public void InsertCustomerRole(CustomerRole customerrole)
    	{	
            if (customerrole == null)
                return;
    
            if (!this._context.IsAttached(customerrole))
    			
                this._context.CustomerRoles.AddObject(customerrole);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into CustomerRole
        /// </summary>
        /// <param name="customerrole">CustomerRole</param>
        public void UpdateCustomerRole(CustomerRole customerrole)
        {
            if (customerrole == null)
                return;
    
            if (this._context.IsAttached(customerrole))
                this._context.CustomerRoles.Attach(customerrole);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to CustomerRole list
        /// </summary>
        public List<CustomerRole> GetCustomerRoleList()
        {		
            var query = from p in this._context.CustomerRoles
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to CustomerRole Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>CustomerRole Page List</returns>
        public PagedList<CustomerRole> SearchCustomerRole(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.CustomerRoles
                        orderby p.CustomerRoleID
                        select p;
            return new PagedList<CustomerRole>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a CustomerRole by CustomerRoleID
        /// </summary>
        /// <param name="customerroleid">CustomerRole CustomerRoleID</param>
        /// <returns>CustomerRole</returns>   
        public CustomerRole GetCustomerRoleByCustomerRoleID(int customerroleid)
        {
            var query = from p in this._context.CustomerRoles
                        where p.CustomerRoleID.Equals(customerroleid)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete CustomerRole by CustomerRoleID
        /// </summary>
        /// <param name="CustomerRoleID">CustomerRole CustomerRoleID</param>
        public void DeleteCustomerRole(int customerroleid)
        {
            var customerrole = this.GetCustomerRoleByCustomerRoleID(customerroleid);
            if (customerrole == null)
                return;
    
            if (!this._context.IsAttached(customerrole))
                this._context.CustomerRoles.Attach(customerrole);
    
            this._context.DeleteObject(customerrole);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete CustomerRole by CustomerRoleID
        /// </summary>
        /// <param name="CustomerRoleIDs">CustomerRole CustomerRoleID</param>
        public void BatchDeleteCustomerRole(List<int> customerroleids)
        {
    	   var query = from q in _context.CustomerRoles
                    where customerroleids.Contains(q.CustomerRoleID)
                    select q;
            var customerroles = query.ToList();
            foreach (var item in customerroles)
            {
                if (!_context.IsAttached(item))
                    _context.CustomerRoles.Attach(item);  
    
                _context.CustomerRoles.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
