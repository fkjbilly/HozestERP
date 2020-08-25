
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
    public partial interface IXMFinancialCapitalFlowService
    {
        #region IXMFinancialCapitalFlowService成员
        /// <summary>
        /// Insert into XMFinancialCapitalFlow
        /// </summary>
        /// <param name="xmfinancialcapitalflow">XMFinancialCapitalFlow</param>
    	void InsertXMFinancialCapitalFlow(XMFinancialCapitalFlow xmfinancialcapitalflow);
    	
        /// <summary>
        /// Update into XMFinancialCapitalFlow
        /// </summary>
        /// <param name="xmfinancialcapitalflow">XMFinancialCapitalFlow</param>
        void UpdateXMFinancialCapitalFlow(XMFinancialCapitalFlow xmfinancialcapitalflow);	
    	
        /// <summary>
        /// get to XMFinancialCapitalFlow list
        /// </summary>
        List<XMFinancialCapitalFlow> GetXMFinancialCapitalFlowList();
    	       
    	/// <summary>
    	/// get to XMFinancialCapitalFlow Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>XMFinancialCapitalFlow Page List</returns>
    	PagedList<XMFinancialCapitalFlow> SearchXMFinancialCapitalFlow(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a XMFinancialCapitalFlow by ID
        /// </summary>
        /// <param name="id">XMFinancialCapitalFlow ID</param>
        /// <returns>XMFinancialCapitalFlow</returns>   
        XMFinancialCapitalFlow GetXMFinancialCapitalFlowByID(int id);
    
    	/// <summary>
        /// delete XMFinancialCapitalFlow by ID
        /// </summary>
        /// <param name="ID">XMFinancialCapitalFlow ID</param>
        void DeleteXMFinancialCapitalFlow(int id);
    	
    	/// <summary>
        /// Batch delete XMFinancialCapitalFlow by ID
        /// </summary>
        /// <param name="IDs">XMFinancialCapitalFlow ID</param>
        void BatchDeleteXMFinancialCapitalFlow(List<int> ids);

        #endregion
    }
}
