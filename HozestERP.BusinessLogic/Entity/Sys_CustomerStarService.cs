
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
    public partial class Sys_CustomerStarService: ISys_CustomerStarService
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
    	public Sys_CustomerStarService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region ISys_CustomerStarService成员
        /// <summary>
        /// Insert into Sys_CustomerStar
        /// </summary>
        /// <param name="sys_customerstar">Sys_CustomerStar</param>
    	public void InsertSys_CustomerStar(Sys_CustomerStar sys_customerstar)
    	{	
            if (sys_customerstar == null)
                return;
    
            if (!this._context.IsAttached(sys_customerstar))
    			
                this._context.Sys_CustomerStar.AddObject(sys_customerstar);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into Sys_CustomerStar
        /// </summary>
        /// <param name="sys_customerstar">Sys_CustomerStar</param>
        public void UpdateSys_CustomerStar(Sys_CustomerStar sys_customerstar)
        {
            if (sys_customerstar == null)
                return;
    
            if (this._context.IsAttached(sys_customerstar))
                this._context.Sys_CustomerStar.Attach(sys_customerstar);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to Sys_CustomerStar list
        /// </summary>
        public List<Sys_CustomerStar> GetSys_CustomerStarList()
        {		
            var query = from p in this._context.Sys_CustomerStar
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to Sys_CustomerStar Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>Sys_CustomerStar Page List</returns>
        public PagedList<Sys_CustomerStar> SearchSys_CustomerStar(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.Sys_CustomerStar
                        orderby p.ID
                        select p;
            return new PagedList<Sys_CustomerStar>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a Sys_CustomerStar by ID
        /// </summary>
        /// <param name="id">Sys_CustomerStar ID</param>
        /// <returns>Sys_CustomerStar</returns>   
        public Sys_CustomerStar GetSys_CustomerStarByID(int id)
        {
            var query = from p in this._context.Sys_CustomerStar
                        where p.ID.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete Sys_CustomerStar by ID
        /// </summary>
        /// <param name="ID">Sys_CustomerStar ID</param>
        public void DeleteSys_CustomerStar(int id)
        {
            var sys_customerstar = this.GetSys_CustomerStarByID(id);
            if (sys_customerstar == null)
                return;
    
            if (!this._context.IsAttached(sys_customerstar))
                this._context.Sys_CustomerStar.Attach(sys_customerstar);
    
            this._context.DeleteObject(sys_customerstar);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete Sys_CustomerStar by ID
        /// </summary>
        /// <param name="IDs">Sys_CustomerStar ID</param>
        public void BatchDeleteSys_CustomerStar(List<int> ids)
        {
    	   var query = from q in _context.Sys_CustomerStar
                    where ids.Contains(q.ID)
                    select q;
            var sys_customerstars = query.ToList();
            foreach (var item in sys_customerstars)
            {
                if (!_context.IsAttached(item))
                    _context.Sys_CustomerStar.Attach(item);  
    
                _context.Sys_CustomerStar.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
