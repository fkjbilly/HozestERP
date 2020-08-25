
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
    public partial class ACLService: IACLService
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
    	public ACLService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region IACLService成员
        /// <summary>
        /// Insert into ACL
        /// </summary>
        /// <param name="acl">ACL</param>
    	public void InsertACL(ACL acl)
    	{	
            if (acl == null)
                return;
    
            if (!this._context.IsAttached(acl))
    			
                this._context.ACLs.AddObject(acl);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into ACL
        /// </summary>
        /// <param name="acl">ACL</param>
        public void UpdateACL(ACL acl)
        {
            if (acl == null)
                return;
    
            if (this._context.IsAttached(acl))
                this._context.ACLs.Attach(acl);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to ACL list
        /// </summary>
        public List<ACL> GetACLList()
        {		
            var query = from p in this._context.ACLs
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to ACL Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>ACL Page List</returns>
        public PagedList<ACL> SearchACL(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.ACLs
                        orderby p.ACLID
                        select p;
            return new PagedList<ACL>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a ACL by ACLID
        /// </summary>
        /// <param name="aclid">ACL ACLID</param>
        /// <returns>ACL</returns>   
        public ACL GetACLByACLID(int aclid)
        {
            var query = from p in this._context.ACLs
                        where p.ACLID.Equals(aclid)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete ACL by ACLID
        /// </summary>
        /// <param name="ACLID">ACL ACLID</param>
        public void DeleteACL(int aclid)
        {
            var acl = this.GetACLByACLID(aclid);
            if (acl == null)
                return;
    
            if (!this._context.IsAttached(acl))
                this._context.ACLs.Attach(acl);
    
            this._context.DeleteObject(acl);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete ACL by ACLID
        /// </summary>
        /// <param name="ACLIDs">ACL ACLID</param>
        public void BatchDeleteACL(List<int> aclids)
        {
    	   var query = from q in _context.ACLs
                    where aclids.Contains(q.ACLID)
                    select q;
            var acls = query.ToList();
            foreach (var item in acls)
            {
                if (!_context.IsAttached(item))
                    _context.ACLs.Attach(item);  
    
                _context.ACLs.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
