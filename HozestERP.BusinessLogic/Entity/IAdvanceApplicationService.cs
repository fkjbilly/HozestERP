
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
    public partial interface IAdvanceApplicationService
    {
        #region IAdvanceApplicationService成员
        /// <summary>
        /// Insert into AdvanceApplication
        /// </summary>
        /// <param name="advanceapplication">AdvanceApplication</param>
    	void InsertAdvanceApplication(AdvanceApplication advanceapplication);
    	
        /// <summary>
        /// Update into AdvanceApplication
        /// </summary>
        /// <param name="advanceapplication">AdvanceApplication</param>
        void UpdateAdvanceApplication(AdvanceApplication advanceapplication);	
    	
        /// <summary>
        /// get to AdvanceApplication list
        /// </summary>
        List<AdvanceApplication> GetAdvanceApplicationList();
    	       
    	/// <summary>
    	/// get to AdvanceApplication Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>AdvanceApplication Page List</returns>
    	PagedList<AdvanceApplication> SearchAdvanceApplication(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a AdvanceApplication by Id
        /// </summary>
        /// <param name="id">AdvanceApplication Id</param>
        /// <returns>AdvanceApplication</returns>   
        AdvanceApplication GetAdvanceApplicationById(int id);
    
    	/// <summary>
        /// delete AdvanceApplication by Id
        /// </summary>
        /// <param name="Id">AdvanceApplication Id</param>
        void DeleteAdvanceApplication(int id);
    	
    	/// <summary>
        /// Batch delete AdvanceApplication by Id
        /// </summary>
        /// <param name="Ids">AdvanceApplication Id</param>
        void BatchDeleteAdvanceApplication(List<int> ids);

        #endregion
    }
}
