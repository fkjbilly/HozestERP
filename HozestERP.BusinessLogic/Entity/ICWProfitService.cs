
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
    public partial interface ICWProfitService
    {
        #region ICWProfitService成员
        /// <summary>
        /// Insert into CWProfit
        /// </summary>
        /// <param name="cwprofit">CWProfit</param>
    	void InsertCWProfit(CWProfit cwprofit);
    	
        /// <summary>
        /// Update into CWProfit
        /// </summary>
        /// <param name="cwprofit">CWProfit</param>
        void UpdateCWProfit(CWProfit cwprofit);	
    	
        /// <summary>
        /// get to CWProfit list
        /// </summary>
        List<CWProfit> GetCWProfitList();
    	       
    	/// <summary>
    	/// get to CWProfit Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>CWProfit Page List</returns>
    	PagedList<CWProfit> SearchCWProfit(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a CWProfit by Id
        /// </summary>
        /// <param name="id">CWProfit Id</param>
        /// <returns>CWProfit</returns>   
        CWProfit GetCWProfitById(int id);
    
    	/// <summary>
        /// delete CWProfit by Id
        /// </summary>
        /// <param name="Id">CWProfit Id</param>
        void DeleteCWProfit(int id);
    	
    	/// <summary>
        /// Batch delete CWProfit by Id
        /// </summary>
        /// <param name="Ids">CWProfit Id</param>
        void BatchDeleteCWProfit(List<int> ids);

        #endregion
    }
}
