
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2016-05-09 16:59:13
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

namespace HozestERP.BusinessLogic.ManageInventory
{
    public partial interface IXMPurchaseProductDetailsService
    {
        #region IXMPurchaseProductDetailsService成员
        /// <summary>
        /// Insert into XMPurchaseProductDetails
        /// </summary>
        /// <param name="xmpurchaseproductdetails">XMPurchaseProductDetails</param>
        void InsertXMPurchaseProductDetails(XMPurchaseProductDetails xmpurchaseproductdetails);

        /// <summary>
        /// Update into XMPurchaseProductDetails
        /// </summary>
        /// <param name="xmpurchaseproductdetails">XMPurchaseProductDetails</param>
        void UpdateXMPurchaseProductDetails(XMPurchaseProductDetails xmpurchaseproductdetails);

        /// <summary>
        /// get to XMPurchaseProductDetails list
        /// </summary>
        List<XMPurchaseProductDetails> GetXMPurchaseProductDetailsList();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="purchaseID"></param>
        /// <returns></returns>
        List<XMPurchaseProductDetails> GetXMPurchaseProductDetailsByPurchaseID(int purchaseID);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="purchaseID"></param>
        /// <param name="platformMerchantCode"></param>
        /// <returns></returns>
        List<XMPurchaseProductDetails> GetXMPurchaseProductDetailsByPurchaseIDAndPlatformMerchantCode(int purchaseID, string platformMerchantCode);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="StartDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="PlatformMerchantCode"></param>
        /// <returns></returns>
        List<XMPurchaseProductDetails> GetXMPurchaseProductDetailsByDateTime(DateTime StartDate, DateTime EndDate, string PlatformMerchantCode);

        /// <summary>
        /// get to XMPurchaseProductDetails Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMPurchaseProductDetails Page List</returns>
        PagedList<XMPurchaseProductDetails> SearchXMPurchaseProductDetails(int pageIndex, int pageSize, string sortExpression, string sortDirection);

        /// <summary>
        /// get a XMPurchaseProductDetails by Id
        /// </summary>
        /// <param name="id">XMPurchaseProductDetails Id</param>
        /// <returns>XMPurchaseProductDetails</returns>   
        XMPurchaseProductDetails GetXMPurchaseProductDetailsById(int id);

        /// <summary>
        /// delete XMPurchaseProductDetails by Id
        /// </summary>
        /// <param name="Id">XMPurchaseProductDetails Id</param>
        void DeleteXMPurchaseProductDetails(int id);

        /// <summary>
        /// Batch delete XMPurchaseProductDetails by Id
        /// </summary>
        /// <param name="Ids">XMPurchaseProductDetails Id</param>
        void BatchDeleteXMPurchaseProductDetails(List<int> ids);

        #endregion
    }
}
