
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
    public partial class Sys_StarSetService: ISys_StarSetService
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
    	public Sys_StarSetService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region ISys_StarSetService成员
        /// <summary>
        /// Insert into Sys_StarSet
        /// </summary>
        /// <param name="sys_starset">Sys_StarSet</param>
    	public void InsertSys_StarSet(Sys_StarSet sys_starset)
    	{	
            if (sys_starset == null)
                return;
    
            if (!this._context.IsAttached(sys_starset))
    			
                this._context.Sys_StarSet.AddObject(sys_starset);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into Sys_StarSet
        /// </summary>
        /// <param name="sys_starset">Sys_StarSet</param>
        public void UpdateSys_StarSet(Sys_StarSet sys_starset)
        {
            if (sys_starset == null)
                return;
    
            if (this._context.IsAttached(sys_starset))
                this._context.Sys_StarSet.Attach(sys_starset);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to Sys_StarSet list
        /// </summary>
        public List<Sys_StarSet> GetSys_StarSetList()
        {		
            var query = from p in this._context.Sys_StarSet
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to Sys_StarSet Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>Sys_StarSet Page List</returns>
        public PagedList<Sys_StarSet> SearchSys_StarSet(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.Sys_StarSet
                        orderby p.ID
                        select p;
            return new PagedList<Sys_StarSet>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a Sys_StarSet by ID
        /// </summary>
        /// <param name="id">Sys_StarSet ID</param>
        /// <returns>Sys_StarSet</returns>   
        public Sys_StarSet GetSys_StarSetByID(int id)
        {
            var query = from p in this._context.Sys_StarSet
                        where p.ID.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete Sys_StarSet by ID
        /// </summary>
        /// <param name="ID">Sys_StarSet ID</param>
        public void DeleteSys_StarSet(int id)
        {
            var sys_starset = this.GetSys_StarSetByID(id);
            if (sys_starset == null)
                return;
    
            if (!this._context.IsAttached(sys_starset))
                this._context.Sys_StarSet.Attach(sys_starset);
    
            this._context.DeleteObject(sys_starset);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete Sys_StarSet by ID
        /// </summary>
        /// <param name="IDs">Sys_StarSet ID</param>
        public void BatchDeleteSys_StarSet(List<int> ids)
        {
    	   var query = from q in _context.Sys_StarSet
                    where ids.Contains(q.ID)
                    select q;
            var sys_starsets = query.ToList();
            foreach (var item in sys_starsets)
            {
                if (!_context.IsAttached(item))
                    _context.Sys_StarSet.Attach(item);  
    
                _context.Sys_StarSet.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
