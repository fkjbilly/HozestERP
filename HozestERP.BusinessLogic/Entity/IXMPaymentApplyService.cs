
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
    public partial interface IXMPaymentApplyService
    {
        #region IXMPaymentApplyService成员
        /// <summary>
        /// Insert into XMPaymentApply
        /// </summary>
        /// <param name="xmpaymentapply">XMPaymentApply</param>
    	void InsertXMPaymentApply(XMPaymentApply xmpaymentapply);
    	
        /// <summary>
        /// Update into XMPaymentApply
        /// </summary>
        /// <param name="xmpaymentapply">XMPaymentApply</param>
        void UpdateXMPaymentApply(XMPaymentApply xmpaymentapply);	
    	
        /// <summary>
        /// get to XMPaymentApply list
        /// </summary>
        List<XMPaymentApply> GetXMPaymentApplyList();
    	       
    	/// <summary>
    	/// get to XMPaymentApply Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>XMPaymentApply Page List</returns>
    	PagedList<XMPaymentApply> SearchXMPaymentApply(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a XMPaymentApply by Id
        /// </summary>
        /// <param name="id">XMPaymentApply Id</param>
        /// <returns>XMPaymentApply</returns>   
        XMPaymentApply GetXMPaymentApplyById(int id);
    
    	/// <summary>
        /// delete XMPaymentApply by Id
        /// </summary>
        /// <param name="Id">XMPaymentApply Id</param>
        void DeleteXMPaymentApply(int id);
    	
    	/// <summary>
        /// Batch delete XMPaymentApply by Id
        /// </summary>
        /// <param name="Ids">XMPaymentApply Id</param>
        void BatchDeleteXMPaymentApply(List<int> ids);

        #endregion
    }
}
