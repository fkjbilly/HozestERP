
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
    public partial interface IAdvanceApplicationDetailService
    {
        #region IAdvanceApplicationDetailService成员
        /// <summary>
        /// Insert into AdvanceApplicationDetail
        /// </summary>
        /// <param name="advanceapplicationdetail">AdvanceApplicationDetail</param>
    	void InsertAdvanceApplicationDetail(AdvanceApplicationDetail advanceapplicationdetail);
    	
        /// <summary>
        /// Update into AdvanceApplicationDetail
        /// </summary>
        /// <param name="advanceapplicationdetail">AdvanceApplicationDetail</param>
        void UpdateAdvanceApplicationDetail(AdvanceApplicationDetail advanceapplicationdetail);	
    	
        /// <summary>
        /// get to AdvanceApplicationDetail list
        /// </summary>
        List<AdvanceApplicationDetail> GetAdvanceApplicationDetailList();
    	       
    	/// <summary>
    	/// get to AdvanceApplicationDetail Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>AdvanceApplicationDetail Page List</returns>
    	PagedList<AdvanceApplicationDetail> SearchAdvanceApplicationDetail(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a AdvanceApplicationDetail by Id
        /// </summary>
        /// <param name="id">AdvanceApplicationDetail Id</param>
        /// <returns>AdvanceApplicationDetail</returns>   
        AdvanceApplicationDetail GetAdvanceApplicationDetailById(int id);
    
    	/// <summary>
        /// delete AdvanceApplicationDetail by Id
        /// </summary>
        /// <param name="Id">AdvanceApplicationDetail Id</param>
        void DeleteAdvanceApplicationDetail(int id);
    	
    	/// <summary>
        /// Batch delete AdvanceApplicationDetail by Id
        /// </summary>
        /// <param name="Ids">AdvanceApplicationDetail Id</param>
        void BatchDeleteAdvanceApplicationDetail(List<int> ids);

        #endregion
    }
}
