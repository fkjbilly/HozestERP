
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
    public partial class LogisticsAgingService: ILogisticsAgingService
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
    	public LogisticsAgingService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region ILogisticsAgingService成员
        /// <summary>
        /// Insert into LogisticsAging
        /// </summary>
        /// <param name="logisticsaging">LogisticsAging</param>
    	public void InsertLogisticsAging(LogisticsAging logisticsaging)
    	{	
            if (logisticsaging == null)
                return;
    
            if (!this._context.IsAttached(logisticsaging))
    			
                this._context.LogisticsAgings.AddObject(logisticsaging);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into LogisticsAging
        /// </summary>
        /// <param name="logisticsaging">LogisticsAging</param>
        public void UpdateLogisticsAging(LogisticsAging logisticsaging)
        {
            if (logisticsaging == null)
                return;
    
            if (this._context.IsAttached(logisticsaging))
                this._context.LogisticsAgings.Attach(logisticsaging);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to LogisticsAging list
        /// </summary>
        public List<LogisticsAging> GetLogisticsAgingList()
        {		
            var query = from p in this._context.LogisticsAgings
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to LogisticsAging Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>LogisticsAging Page List</returns>
        public PagedList<LogisticsAging> SearchLogisticsAging(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.LogisticsAgings
                        orderby p.ID
                        select p;
            return new PagedList<LogisticsAging>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a LogisticsAging by ID
        /// </summary>
        /// <param name="id">LogisticsAging ID</param>
        /// <returns>LogisticsAging</returns>   
        public LogisticsAging GetLogisticsAgingByID(int id)
        {
            var query = from p in this._context.LogisticsAgings
                        where p.ID.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete LogisticsAging by ID
        /// </summary>
        /// <param name="ID">LogisticsAging ID</param>
        public void DeleteLogisticsAging(int id)
        {
            var logisticsaging = this.GetLogisticsAgingByID(id);
            if (logisticsaging == null)
                return;
    
            if (!this._context.IsAttached(logisticsaging))
                this._context.LogisticsAgings.Attach(logisticsaging);
    
            this._context.DeleteObject(logisticsaging);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete LogisticsAging by ID
        /// </summary>
        /// <param name="IDs">LogisticsAging ID</param>
        public void BatchDeleteLogisticsAging(List<int> ids)
        {
    	   var query = from q in _context.LogisticsAgings
                    where ids.Contains(q.ID)
                    select q;
            var logisticsagings = query.ToList();
            foreach (var item in logisticsagings)
            {
                if (!_context.IsAttached(item))
                    _context.LogisticsAgings.Attach(item);  
    
                _context.LogisticsAgings.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
