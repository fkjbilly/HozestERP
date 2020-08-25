
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
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using HozestERP.BusinessLogic.Caching;
using HozestERP.BusinessLogic.Data;
using HozestERP.Common;

namespace HozestERP.BusinessLogic.ManageInventory
{
    public partial interface IXMStorageProductDetailsService
    {
        #region IXMStorageProductDetailsService成员
        /// <summary>
        /// Insert into XMStorageProductDetails
        /// </summary>
        /// <param name="xmstorageproductdetails">XMStorageProductDetails</param>
        void InsertXMStorageProductDetails(XMStorageProductDetails xmstorageproductdetails);

        /// <summary>
        /// Update into XMStorageProductDetails
        /// </summary>
        /// <param name="xmstorageproductdetails">XMStorageProductDetails</param>
        void UpdateXMStorageProductDetails(XMStorageProductDetails xmstorageproductdetails);

        /// <summary>
        /// get to XMStorageProductDetails list
        /// </summary>
        List<XMStorageProductDetails> GetXMStorageProductDetailsList();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="wareHouesesID"></param>
        /// <param name="PlatformMerchantCode"></param>
        /// <returns></returns>
        List<XMStorageProductDetails> GetXMStorageProductDetailsListByParm(DateTime startDate, DateTime endDate, int wareHouesesID, string PlatformMerchantCode);
        List<XMStorageProductDetails> GetXMStorageProductDetailsListByWareHousesList(List<int> WareHousesList);

        /// <summary>
        /// get to XMStorageProductDetails Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMStorageProductDetails Page List</returns>
        PagedList<XMStorageProductDetails> SearchXMStorageProductDetails(int pageIndex, int pageSize, string sortExpression, string sortDirection);

        /// <summary>
        /// get a XMStorageProductDetails by Id
        /// </summary>
        /// <param name="id">XMStorageProductDetails Id</param>
        /// <returns>XMStorageProductDetails</returns>   
        XMStorageProductDetails GetXMStorageProductDetailsById(int id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="storageID"></param>
        /// <returns></returns>
        List<XMStorageProductDetails> GetXMStorageProductDetailsByStorageID(int storageID);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="storageID"></param>
        /// <param name="PlatformMerchantCode"></param>
        /// <param name="ProductName"></param>
        /// <returns></returns>
        List<XMStorageProductDetails> GetXMStorageProductDetailsByIDOrProductInfo(int storageID, string PlatformMerchantCode, string ProductName);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <param name="productName"></param>
        /// <param name="supplierId"></param>
        /// <param name="wareHouseId"></param>
        /// <returns></returns>
        List<PurchaseDetail> GetXMStorageProductDetailsListByParm(string begin, string end, string productName, int supplierId, string wareHouseId, int projectId);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="purchaseId"></param>
        /// <param name="platformMerchantCode"></param>
        /// <returns></returns>
        List<XMStorageProductDetails> GetXMStorageProductDetailsListByParm(int purchaseId, string platformMerchantCode);

        /// <summary>
        /// delete XMStorageProductDetails by Id
        /// </summary>
        /// <param name="Id">XMStorageProductDetails Id</param>
        void DeleteXMStorageProductDetails(int id);

        /// <summary>
        /// Batch delete XMStorageProductDetails by Id
        /// </summary>
        /// <param name="Ids">XMStorageProductDetails Id</param>
        void BatchDeleteXMStorageProductDetails(List<int> ids);

        #endregion
    }
}
