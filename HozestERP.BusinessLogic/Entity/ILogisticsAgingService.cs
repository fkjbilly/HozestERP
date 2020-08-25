
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2017-04-26 15:27:57
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

namespace HozestERP.BusinessLogic.Entity
{
    public partial interface ILogisticsAgingService
    {
        #region ILogisticsAgingService成员
        /// <summary>
        /// Insert into LogisticsAging
        /// </summary>
        /// <param name="logisticsaging">LogisticsAging</param>
    	void InsertLogisticsAging(LogisticsAging logisticsaging);
    	
        /// <summary>
        /// Update into LogisticsAging
        /// </summary>
        /// <param name="logisticsaging">LogisticsAging</param>
        void UpdateLogisticsAging(LogisticsAging logisticsaging);	
    	
        /// <summary>
        /// get to LogisticsAging list
        /// </summary>
        List<LogisticsAging> GetLogisticsAgingList();
    	       
    	/// <summary>
    	/// get to LogisticsAging Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>LogisticsAging Page List</returns>
    	PagedList<LogisticsAging> SearchLogisticsAging(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a LogisticsAging by ID
        /// </summary>
        /// <param name="id">LogisticsAging ID</param>
        /// <returns>LogisticsAging</returns>   
        LogisticsAging GetLogisticsAgingByID(int id);
    
    	/// <summary>
        /// delete LogisticsAging by ID
        /// </summary>
        /// <param name="ID">LogisticsAging ID</param>
        void DeleteLogisticsAging(int id);
    	
    	/// <summary>
        /// Batch delete LogisticsAging by ID
        /// </summary>
        /// <param name="IDs">LogisticsAging ID</param>
        void BatchDeleteLogisticsAging(List<int> ids);

        #endregion
    }
}
