
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
    public partial interface ICWStaffSpendingService
    {
        #region ICWStaffSpendingService成员
        /// <summary>
        /// Insert into CWStaffSpending
        /// </summary>
        /// <param name="cwstaffspending">CWStaffSpending</param>
    	void InsertCWStaffSpending(CWStaffSpending cwstaffspending);
    	
        /// <summary>
        /// Update into CWStaffSpending
        /// </summary>
        /// <param name="cwstaffspending">CWStaffSpending</param>
        void UpdateCWStaffSpending(CWStaffSpending cwstaffspending);	
    	
        /// <summary>
        /// get to CWStaffSpending list
        /// </summary>
        List<CWStaffSpending> GetCWStaffSpendingList();
    	       
    	/// <summary>
    	/// get to CWStaffSpending Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>CWStaffSpending Page List</returns>
    	PagedList<CWStaffSpending> SearchCWStaffSpending(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a CWStaffSpending by Id
        /// </summary>
        /// <param name="id">CWStaffSpending Id</param>
        /// <returns>CWStaffSpending</returns>   
        CWStaffSpending GetCWStaffSpendingById(int id);
    
    	/// <summary>
        /// delete CWStaffSpending by Id
        /// </summary>
        /// <param name="Id">CWStaffSpending Id</param>
        void DeleteCWStaffSpending(int id);
    	
    	/// <summary>
        /// Batch delete CWStaffSpending by Id
        /// </summary>
        /// <param name="Ids">CWStaffSpending Id</param>
        void BatchDeleteCWStaffSpending(List<int> ids);

        #endregion
    }
}
