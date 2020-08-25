
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
    public partial class ACLModuleService: IACLModuleService
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
    	public ACLModuleService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region IACLModuleService成员
        /// <summary>
        /// Insert into ACLModule
        /// </summary>
        /// <param name="aclmodule">ACLModule</param>
    	public void InsertACLModule(ACLModule aclmodule)
    	{	
            if (aclmodule == null)
                return;
    
            if (!this._context.IsAttached(aclmodule))
    			
                this._context.ACLModules.AddObject(aclmodule);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into ACLModule
        /// </summary>
        /// <param name="aclmodule">ACLModule</param>
        public void UpdateACLModule(ACLModule aclmodule)
        {
            if (aclmodule == null)
                return;
    
            if (this._context.IsAttached(aclmodule))
                this._context.ACLModules.Attach(aclmodule);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to ACLModule list
        /// </summary>
        public List<ACLModule> GetACLModuleList()
        {		
            var query = from p in this._context.ACLModules
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to ACLModule Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>ACLModule Page List</returns>
        public PagedList<ACLModule> SearchACLModule(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.ACLModules
                        orderby p.ACLModuleId
                        select p;
            return new PagedList<ACLModule>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a ACLModule by ACLModuleId
        /// </summary>
        /// <param name="aclmoduleid">ACLModule ACLModuleId</param>
        /// <returns>ACLModule</returns>   
        public ACLModule GetACLModuleByACLModuleId(int aclmoduleid)
        {
            var query = from p in this._context.ACLModules
                        where p.ACLModuleId.Equals(aclmoduleid)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete ACLModule by ACLModuleId
        /// </summary>
        /// <param name="ACLModuleId">ACLModule ACLModuleId</param>
        public void DeleteACLModule(int aclmoduleid)
        {
            var aclmodule = this.GetACLModuleByACLModuleId(aclmoduleid);
            if (aclmodule == null)
                return;
    
            if (!this._context.IsAttached(aclmodule))
                this._context.ACLModules.Attach(aclmodule);
    
            this._context.DeleteObject(aclmodule);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete ACLModule by ACLModuleId
        /// </summary>
        /// <param name="ACLModuleIds">ACLModule ACLModuleId</param>
        public void BatchDeleteACLModule(List<int> aclmoduleids)
        {
    	   var query = from q in _context.ACLModules
                    where aclmoduleids.Contains(q.ACLModuleId)
                    select q;
            var aclmodules = query.ToList();
            foreach (var item in aclmodules)
            {
                if (!_context.IsAttached(item))
                    _context.ACLModules.Attach(item);  
    
                _context.ACLModules.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
