
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2016-03-03 11:11:26
** 修改人:
** 修改日期:
** 描 述: 接口类
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
    public partial interface IBudgetSettingService
    {
        #region IBudgetSettingService成员
        /// <summary>
        /// Insert into BudgetSetting
        /// </summary>
        /// <param name="budgetsetting">BudgetSetting</param>
    	void InsertBudgetSetting(BudgetSetting budgetsetting);
    	
        /// <summary>
        /// Update into BudgetSetting
        /// </summary>
        /// <param name="budgetsetting">BudgetSetting</param>
        void UpdateBudgetSetting(BudgetSetting budgetsetting);	
    	
        /// <summary>
        /// get to BudgetSetting list
        /// </summary>
        List<BudgetSetting> GetBudgetSettingList();
        List<BudgetSetting> GetBudgetSettingListByData(string Name, int IsCost);
        List<BudgetSetting> GetBudgetSettingListByData(string Name);
    	/// <summary>
    	/// get to BudgetSetting Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>BudgetSetting Page List</returns>
    	PagedList<BudgetSetting> SearchBudgetSetting(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a BudgetSetting by ID
        /// </summary>
        /// <param name="id">BudgetSetting ID</param>
        /// <returns>BudgetSetting</returns>   
        BudgetSetting GetBudgetSettingByID(int id);
    
    	/// <summary>
        /// delete BudgetSetting by ID
        /// </summary>
        /// <param name="ID">BudgetSetting ID</param>
        void DeleteBudgetSetting(int id);
    	
    	/// <summary>
        /// Batch delete BudgetSetting by ID
        /// </summary>
        /// <param name="IDs">BudgetSetting ID</param>
        void BatchDeleteBudgetSetting(List<int> ids);

        #endregion
    }
}
