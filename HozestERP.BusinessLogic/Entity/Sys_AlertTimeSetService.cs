
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
    public partial class Sys_AlertTimeSetService: ISys_AlertTimeSetService
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
    	public Sys_AlertTimeSetService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region ISys_AlertTimeSetService成员
        /// <summary>
        /// Insert into Sys_AlertTimeSet
        /// </summary>
        /// <param name="sys_alerttimeset">Sys_AlertTimeSet</param>
    	public void InsertSys_AlertTimeSet(Sys_AlertTimeSet sys_alerttimeset)
    	{	
            if (sys_alerttimeset == null)
                return;
    
            if (!this._context.IsAttached(sys_alerttimeset))
    			
                this._context.Sys_AlertTimeSet.AddObject(sys_alerttimeset);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into Sys_AlertTimeSet
        /// </summary>
        /// <param name="sys_alerttimeset">Sys_AlertTimeSet</param>
        public void UpdateSys_AlertTimeSet(Sys_AlertTimeSet sys_alerttimeset)
        {
            if (sys_alerttimeset == null)
                return;
    
            if (this._context.IsAttached(sys_alerttimeset))
                this._context.Sys_AlertTimeSet.Attach(sys_alerttimeset);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to Sys_AlertTimeSet list
        /// </summary>
        public List<Sys_AlertTimeSet> GetSys_AlertTimeSetList()
        {		
            var query = from p in this._context.Sys_AlertTimeSet
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to Sys_AlertTimeSet Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>Sys_AlertTimeSet Page List</returns>
        public PagedList<Sys_AlertTimeSet> SearchSys_AlertTimeSet(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.Sys_AlertTimeSet
                        orderby p.ID
                        select p;
            return new PagedList<Sys_AlertTimeSet>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a Sys_AlertTimeSet by ID
        /// </summary>
        /// <param name="id">Sys_AlertTimeSet ID</param>
        /// <returns>Sys_AlertTimeSet</returns>   
        public Sys_AlertTimeSet GetSys_AlertTimeSetByID(int id)
        {
            var query = from p in this._context.Sys_AlertTimeSet
                        where p.ID.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete Sys_AlertTimeSet by ID
        /// </summary>
        /// <param name="ID">Sys_AlertTimeSet ID</param>
        public void DeleteSys_AlertTimeSet(int id)
        {
            var sys_alerttimeset = this.GetSys_AlertTimeSetByID(id);
            if (sys_alerttimeset == null)
                return;
    
            if (!this._context.IsAttached(sys_alerttimeset))
                this._context.Sys_AlertTimeSet.Attach(sys_alerttimeset);
    
            this._context.DeleteObject(sys_alerttimeset);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete Sys_AlertTimeSet by ID
        /// </summary>
        /// <param name="IDs">Sys_AlertTimeSet ID</param>
        public void BatchDeleteSys_AlertTimeSet(List<int> ids)
        {
    	   var query = from q in _context.Sys_AlertTimeSet
                    where ids.Contains(q.ID)
                    select q;
            var sys_alerttimesets = query.ToList();
            foreach (var item in sys_alerttimesets)
            {
                if (!_context.IsAttached(item))
                    _context.Sys_AlertTimeSet.Attach(item);  
    
                _context.Sys_AlertTimeSet.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
