
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2016-03-03 11:11:27
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

namespace HozestERP.BusinessLogic.Enterprises
{
    public partial class BudgetSettingService: IBudgetSettingService
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
    	public BudgetSettingService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region IBudgetSettingService成员
        /// <summary>
        /// Insert into BudgetSetting
        /// </summary>
        /// <param name="budgetsetting">BudgetSetting</param>
    	public void InsertBudgetSetting(BudgetSetting budgetsetting)
    	{	
            if (budgetsetting == null)
                return;
    
            if (!this._context.IsAttached(budgetsetting))
    			
                this._context.BudgetSettings.AddObject(budgetsetting);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into BudgetSetting
        /// </summary>
        /// <param name="budgetsetting">BudgetSetting</param>
        public void UpdateBudgetSetting(BudgetSetting budgetsetting)
        {
            if (budgetsetting == null)
                return;
    
            if (this._context.IsAttached(budgetsetting))
                this._context.BudgetSettings.Attach(budgetsetting);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to BudgetSetting list
        /// </summary>
        public List<BudgetSetting> GetBudgetSettingList()
        {
            var query = from p in this._context.BudgetSettings
                        where p.IsEnabled == false
                        select p;
            return query.ToList();
        }

        public List<BudgetSetting> GetBudgetSettingListByData(string Name, int IsCost)
        {
            bool iscost = false;
            if (IsCost == 1)
            {
                iscost = true;
            }
            var query = from p in this._context.BudgetSettings
                        where p.IsEnabled == false
                        && p.Name.Contains(Name)
                        && (IsCost == -1 || p.IsCost == iscost)
                        select p;
            return query.ToList();
        }

        public List<BudgetSetting> GetBudgetSettingListByData(string Name)
        {
            var query = from p in this._context.BudgetSettings
                        where p.IsEnabled == false
                        && p.Name.Contains(Name)
                        select p;
            return query.ToList();
        }
    	
        /// <summary>
        /// get to BudgetSetting Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>BudgetSetting Page List</returns>
        public PagedList<BudgetSetting> SearchBudgetSetting(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.BudgetSettings
                        orderby p.ID
                        select p;
            return new PagedList<BudgetSetting>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a BudgetSetting by ID
        /// </summary>
        /// <param name="id">BudgetSetting ID</param>
        /// <returns>BudgetSetting</returns>   
        public BudgetSetting GetBudgetSettingByID(int id)
        {
            var query = from p in this._context.BudgetSettings
                        where p.ID.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete BudgetSetting by ID
        /// </summary>
        /// <param name="ID">BudgetSetting ID</param>
        public void DeleteBudgetSetting(int id)
        {
            var budgetsetting = this.GetBudgetSettingByID(id);
            if (budgetsetting == null)
                return;
    
            if (!this._context.IsAttached(budgetsetting))
                this._context.BudgetSettings.Attach(budgetsetting);
    
            this._context.DeleteObject(budgetsetting);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete BudgetSetting by ID
        /// </summary>
        /// <param name="IDs">BudgetSetting ID</param>
        public void BatchDeleteBudgetSetting(List<int> ids)
        {
    	   var query = from q in _context.BudgetSettings
                    where ids.Contains(q.ID)
                    select q;
            var budgetsettings = query.ToList();
            foreach (var item in budgetsettings)
            {
                if (!_context.IsAttached(item))
                    _context.BudgetSettings.Attach(item);  
    
                _context.BudgetSettings.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
