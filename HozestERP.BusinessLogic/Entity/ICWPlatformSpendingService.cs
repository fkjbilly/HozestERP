
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
    public partial interface ICWPlatformSpendingService
    {
        #region ICWPlatformSpendingService成员
        /// <summary>
        /// Insert into CWPlatformSpending
        /// </summary>
        /// <param name="cwplatformspending">CWPlatformSpending</param>
    	void InsertCWPlatformSpending(CWPlatformSpending cwplatformspending);
    	
        /// <summary>
        /// Update into CWPlatformSpending
        /// </summary>
        /// <param name="cwplatformspending">CWPlatformSpending</param>
        void UpdateCWPlatformSpending(CWPlatformSpending cwplatformspending);	
    	
        /// <summary>
        /// get to CWPlatformSpending list
        /// </summary>
        List<CWPlatformSpending> GetCWPlatformSpendingList();
    	       
    	/// <summary>
    	/// get to CWPlatformSpending Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>CWPlatformSpending Page List</returns>
    	PagedList<CWPlatformSpending> SearchCWPlatformSpending(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a CWPlatformSpending by Id
        /// </summary>
        /// <param name="id">CWPlatformSpending Id</param>
        /// <returns>CWPlatformSpending</returns>   
        CWPlatformSpending GetCWPlatformSpendingById(int id);
    
    	/// <summary>
        /// delete CWPlatformSpending by Id
        /// </summary>
        /// <param name="Id">CWPlatformSpending Id</param>
        void DeleteCWPlatformSpending(int id);
    	
    	/// <summary>
        /// Batch delete CWPlatformSpending by Id
        /// </summary>
        /// <param name="Ids">CWPlatformSpending Id</param>
        void BatchDeleteCWPlatformSpending(List<int> ids);

        #endregion
    }
}
