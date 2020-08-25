
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
    public partial class CWProfitService: ICWProfitService
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
    	public CWProfitService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region ICWProfitService成员
        /// <summary>
        /// Insert into CWProfit
        /// </summary>
        /// <param name="cwprofit">CWProfit</param>
    	public void InsertCWProfit(CWProfit cwprofit)
    	{	
            if (cwprofit == null)
                return;
    
            if (!this._context.IsAttached(cwprofit))
    			
                this._context.CWProfits.AddObject(cwprofit);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into CWProfit
        /// </summary>
        /// <param name="cwprofit">CWProfit</param>
        public void UpdateCWProfit(CWProfit cwprofit)
        {
            if (cwprofit == null)
                return;
    
            if (this._context.IsAttached(cwprofit))
                this._context.CWProfits.Attach(cwprofit);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to CWProfit list
        /// </summary>
        public List<CWProfit> GetCWProfitList()
        {		
            var query = from p in this._context.CWProfits
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to CWProfit Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>CWProfit Page List</returns>
        public PagedList<CWProfit> SearchCWProfit(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.CWProfits
                        orderby p.Id
                        select p;
            return new PagedList<CWProfit>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a CWProfit by Id
        /// </summary>
        /// <param name="id">CWProfit Id</param>
        /// <returns>CWProfit</returns>   
        public CWProfit GetCWProfitById(int id)
        {
            var query = from p in this._context.CWProfits
                        where p.Id.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete CWProfit by Id
        /// </summary>
        /// <param name="Id">CWProfit Id</param>
        public void DeleteCWProfit(int id)
        {
            var cwprofit = this.GetCWProfitById(id);
            if (cwprofit == null)
                return;
    
            if (!this._context.IsAttached(cwprofit))
                this._context.CWProfits.Attach(cwprofit);
    
            this._context.DeleteObject(cwprofit);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete CWProfit by Id
        /// </summary>
        /// <param name="Ids">CWProfit Id</param>
        public void BatchDeleteCWProfit(List<int> ids)
        {
    	   var query = from q in _context.CWProfits
                    where ids.Contains(q.Id)
                    select q;
            var cwprofits = query.ToList();
            foreach (var item in cwprofits)
            {
                if (!_context.IsAttached(item))
                    _context.CWProfits.Attach(item);  
    
                _context.CWProfits.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
