
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
    public partial interface IXMFinancialFieldService
    {
        #region IXMFinancialFieldService成员
        /// <summary>
        /// Insert into XMFinancialField
        /// </summary>
        /// <param name="xmfinancialfield">XMFinancialField</param>
    	void InsertXMFinancialField(XMFinancialField xmfinancialfield);
    	
        /// <summary>
        /// Update into XMFinancialField
        /// </summary>
        /// <param name="xmfinancialfield">XMFinancialField</param>
        void UpdateXMFinancialField(XMFinancialField xmfinancialfield);	
    	
        /// <summary>
        /// get to XMFinancialField list
        /// </summary>
        List<XMFinancialField> GetXMFinancialFieldList();
    	       
    	/// <summary>
    	/// get to XMFinancialField Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>XMFinancialField Page List</returns>
    	PagedList<XMFinancialField> SearchXMFinancialField(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a XMFinancialField by Id
        /// </summary>
        /// <param name="id">XMFinancialField Id</param>
        /// <returns>XMFinancialField</returns>   
        XMFinancialField GetXMFinancialFieldById(int id);
    
    	/// <summary>
        /// delete XMFinancialField by Id
        /// </summary>
        /// <param name="Id">XMFinancialField Id</param>
        void DeleteXMFinancialField(int id);
    	
    	/// <summary>
        /// Batch delete XMFinancialField by Id
        /// </summary>
        /// <param name="Ids">XMFinancialField Id</param>
        void BatchDeleteXMFinancialField(List<int> ids);

        #endregion
    }
}
