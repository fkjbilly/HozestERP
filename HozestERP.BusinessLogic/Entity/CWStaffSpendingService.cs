
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
    public partial class CWStaffSpendingService: ICWStaffSpendingService
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
    	public CWStaffSpendingService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region ICWStaffSpendingService成员
        /// <summary>
        /// Insert into CWStaffSpending
        /// </summary>
        /// <param name="cwstaffspending">CWStaffSpending</param>
    	public void InsertCWStaffSpending(CWStaffSpending cwstaffspending)
    	{	
            if (cwstaffspending == null)
                return;
    
            if (!this._context.IsAttached(cwstaffspending))
    			
                this._context.CWStaffSpendings.AddObject(cwstaffspending);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into CWStaffSpending
        /// </summary>
        /// <param name="cwstaffspending">CWStaffSpending</param>
        public void UpdateCWStaffSpending(CWStaffSpending cwstaffspending)
        {
            if (cwstaffspending == null)
                return;
    
            if (this._context.IsAttached(cwstaffspending))
                this._context.CWStaffSpendings.Attach(cwstaffspending);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to CWStaffSpending list
        /// </summary>
        public List<CWStaffSpending> GetCWStaffSpendingList()
        {		
            var query = from p in this._context.CWStaffSpendings
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to CWStaffSpending Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>CWStaffSpending Page List</returns>
        public PagedList<CWStaffSpending> SearchCWStaffSpending(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.CWStaffSpendings
                        orderby p.Id
                        select p;
            return new PagedList<CWStaffSpending>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a CWStaffSpending by Id
        /// </summary>
        /// <param name="id">CWStaffSpending Id</param>
        /// <returns>CWStaffSpending</returns>   
        public CWStaffSpending GetCWStaffSpendingById(int id)
        {
            var query = from p in this._context.CWStaffSpendings
                        where p.Id.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete CWStaffSpending by Id
        /// </summary>
        /// <param name="Id">CWStaffSpending Id</param>
        public void DeleteCWStaffSpending(int id)
        {
            var cwstaffspending = this.GetCWStaffSpendingById(id);
            if (cwstaffspending == null)
                return;
    
            if (!this._context.IsAttached(cwstaffspending))
                this._context.CWStaffSpendings.Attach(cwstaffspending);
    
            this._context.DeleteObject(cwstaffspending);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete CWStaffSpending by Id
        /// </summary>
        /// <param name="Ids">CWStaffSpending Id</param>
        public void BatchDeleteCWStaffSpending(List<int> ids)
        {
    	   var query = from q in _context.CWStaffSpendings
                    where ids.Contains(q.Id)
                    select q;
            var cwstaffspendings = query.ToList();
            foreach (var item in cwstaffspendings)
            {
                if (!_context.IsAttached(item))
                    _context.CWStaffSpendings.Attach(item);  
    
                _context.CWStaffSpendings.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
