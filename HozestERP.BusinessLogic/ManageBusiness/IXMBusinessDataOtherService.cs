
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2015-12-16 08:53:14
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

namespace HozestERP.BusinessLogic.ManageBusiness
{
    public partial interface IXMBusinessDataOtherService
    {
        #region IXMBusinessDataOtherService成员
        /// <summary>
        /// Insert into XMBusinessDataOther
        /// </summary>
        /// <param name="xmbusinessdataother">XMBusinessDataOther</param>
    	void InsertXMBusinessDataOther(XMBusinessDataOther xmbusinessdataother);
    	
        /// <summary>
        /// Update into XMBusinessDataOther
        /// </summary>
        /// <param name="xmbusinessdataother">XMBusinessDataOther</param>
        void UpdateXMBusinessDataOther(XMBusinessDataOther xmbusinessdataother);	
    	
        /// <summary>
        /// get to XMBusinessDataOther list
        /// </summary>
        List<XMBusinessDataOther> GetXMBusinessDataOtherList();
    	       
        List<XMBusinessDataOther> GetXMBusinessDataOtherListByData(string StrObject, int BelongingDep, int AmountType, int FinancialStatus, int BusinessType, int ContractlStatus);

        List<XMBusinessDataOther> GetXMBusinessDataOtherListByProjectID(string ProjectID, string DateType);

        List<XMBusinessDataOther> GetXMBusinessDataOtherResults(string ProjectID, DateTime Begin, DateTime End);

        List<XMBusinessDataOther> GetXMBusinessDataOtherListByYear(string ProjectID, string DateType, DateTime Begin, DateTime End);

        decimal? GetXMBusinessDataOtherListByMonth(string ProjectID, string DateType, int Month, int BusinessTypeID);

    	/// <summary>
    	/// get to XMBusinessDataOther Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>XMBusinessDataOther Page List</returns>
    	PagedList<XMBusinessDataOther> SearchXMBusinessDataOther(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a XMBusinessDataOther by ID
        /// </summary>
        /// <param name="id">XMBusinessDataOther ID</param>
        /// <returns>XMBusinessDataOther</returns>   
        XMBusinessDataOther GetXMBusinessDataOtherByID(int id);
    
    	/// <summary>
        /// delete XMBusinessDataOther by ID
        /// </summary>
        /// <param name="ID">XMBusinessDataOther ID</param>
        void DeleteXMBusinessDataOther(int id);
    	
    	/// <summary>
        /// Batch delete XMBusinessDataOther by ID
        /// </summary>
        /// <param name="IDs">XMBusinessDataOther ID</param>
        void BatchDeleteXMBusinessDataOther(List<int> ids);

        #endregion
    }
}
