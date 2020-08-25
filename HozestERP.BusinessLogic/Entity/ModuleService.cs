
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
    public partial class ModuleService: IModuleService
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
    	public ModuleService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region IModuleService成员
        /// <summary>
        /// Insert into Module
        /// </summary>
        /// <param name="module">Module</param>
    	public void InsertModule(Module module)
    	{	
            if (module == null)
                return;
    
            if (!this._context.IsAttached(module))
    			
                this._context.Modules.AddObject(module);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into Module
        /// </summary>
        /// <param name="module">Module</param>
        public void UpdateModule(Module module)
        {
            if (module == null)
                return;
    
            if (this._context.IsAttached(module))
                this._context.Modules.Attach(module);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to Module list
        /// </summary>
        public List<Module> GetModuleList()
        {		
            var query = from p in this._context.Modules
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to Module Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>Module Page List</returns>
        public PagedList<Module> SearchModule(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.Modules
                        orderby p.ModuleID
                        select p;
            return new PagedList<Module>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a Module by ModuleID
        /// </summary>
        /// <param name="moduleid">Module ModuleID</param>
        /// <returns>Module</returns>   
        public Module GetModuleByModuleID(int moduleid)
        {
            var query = from p in this._context.Modules
                        where p.ModuleID.Equals(moduleid)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete Module by ModuleID
        /// </summary>
        /// <param name="ModuleID">Module ModuleID</param>
        public void DeleteModule(int moduleid)
        {
            var module = this.GetModuleByModuleID(moduleid);
            if (module == null)
                return;
    
            if (!this._context.IsAttached(module))
                this._context.Modules.Attach(module);
    
            this._context.DeleteObject(module);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete Module by ModuleID
        /// </summary>
        /// <param name="ModuleIDs">Module ModuleID</param>
        public void BatchDeleteModule(List<int> moduleids)
        {
    	   var query = from q in _context.Modules
                    where moduleids.Contains(q.ModuleID)
                    select q;
            var modules = query.ToList();
            foreach (var item in modules)
            {
                if (!_context.IsAttached(item))
                    _context.Modules.Attach(item);  
    
                _context.Modules.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
