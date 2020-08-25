
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
    public partial interface IXMPurchaseRejectedProductDetailsService
    {
        #region IXMPurchaseRejectedProductDetailsService成员
        /// <summary>
        /// Insert into XMPurchaseRejectedProductDetails
        /// </summary>
        /// <param name="xmpurchaserejectedproductdetails">XMPurchaseRejectedProductDetails</param>
    	void InsertXMPurchaseRejectedProductDetails(XMPurchaseRejectedProductDetails xmpurchaserejectedproductdetails);
    	
        /// <summary>
        /// Update into XMPurchaseRejectedProductDetails
        /// </summary>
        /// <param name="xmpurchaserejectedproductdetails">XMPurchaseRejectedProductDetails</param>
        void UpdateXMPurchaseRejectedProductDetails(XMPurchaseRejectedProductDetails xmpurchaserejectedproductdetails);	
    	
        /// <summary>
        /// get to XMPurchaseRejectedProductDetails list
        /// </summary>
        List<XMPurchaseRejectedProductDetails> GetXMPurchaseRejectedProductDetailsList();
    	       
    	/// <summary>
    	/// get to XMPurchaseRejectedProductDetails Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>XMPurchaseRejectedProductDetails Page List</returns>
    	PagedList<XMPurchaseRejectedProductDetails> SearchXMPurchaseRejectedProductDetails(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a XMPurchaseRejectedProductDetails by Id
        /// </summary>
        /// <param name="id">XMPurchaseRejectedProductDetails Id</param>
        /// <returns>XMPurchaseRejectedProductDetails</returns>   
        XMPurchaseRejectedProductDetails GetXMPurchaseRejectedProductDetailsById(int id);
    
    	/// <summary>
        /// delete XMPurchaseRejectedProductDetails by Id
        /// </summary>
        /// <param name="Id">XMPurchaseRejectedProductDetails Id</param>
        void DeleteXMPurchaseRejectedProductDetails(int id);
    	
    	/// <summary>
        /// Batch delete XMPurchaseRejectedProductDetails by Id
        /// </summary>
        /// <param name="Ids">XMPurchaseRejectedProductDetails Id</param>
        void BatchDeleteXMPurchaseRejectedProductDetails(List<int> ids);

        #endregion
    }
}
