
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
        /// 
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="wdID"></param>
        /// <param name="PlatformMerchantCode"></param>
        /// <returns></returns>
        List<XMPurchaseRejectedProductDetails> GetXMPurchaseRejectedProductDetailsListByParm(DateTime startDate, DateTime endDate, int wdID, string PlatformMerchantCode);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rejectedCode"></param>
        /// <param name="productName"></param>
        /// <param name="beginTime"></param>
        /// <param name="endTime"></param>
        /// <param name="supplierId"></param>
        /// <param name="status"></param>
        /// <param name="customerids"></param>
        /// <param name="isStorage"></param>
        /// <returns></returns>
        List<PurchaseRejectedDetail> GetXMPurchaseRejectedProductDetailsListByParm(string rejectedCode, string productName, string beginTime, string endTime, int supplierId, int status, string customerids, bool isStorage);
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
        /// 
        /// </summary>
        /// <param name="rejectedID"></param>
        /// <returns></returns>
        List<XMPurchaseRejectedProductDetails> GetXMPurchaseRejectedProductDetailsByRejectedID(int rejectedID);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="purchaseId"></param>
        /// <param name="platformMerchantCode"></param>
        /// <returns></returns>
        List<XMPurchaseRejectedProductDetails> GetXMPurchaseRejectedProductDetailsByRejectedByParm(int purchaseId, string platformMerchantCode);

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
