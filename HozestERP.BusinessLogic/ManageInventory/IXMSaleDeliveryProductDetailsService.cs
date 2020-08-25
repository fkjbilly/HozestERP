
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
    public partial interface IXMSaleDeliveryProductDetailsService
    {
        #region IXMSaleDeliveryProductDetailsService成员
        /// <summary>
        /// Insert into XMSaleDeliveryProductDetails
        /// </summary>
        /// <param name="xmsaledeliveryproductdetails">XMSaleDeliveryProductDetails</param>
        void InsertXMSaleDeliveryProductDetails(XMSaleDeliveryProductDetails xmsaledeliveryproductdetails);

        /// <summary>
        /// Update into XMSaleDeliveryProductDetails
        /// </summary>
        /// <param name="xmsaledeliveryproductdetails">XMSaleDeliveryProductDetails</param>
        void UpdateXMSaleDeliveryProductDetails(XMSaleDeliveryProductDetails xmsaledeliveryproductdetails);

        /// <summary>
        /// get to XMSaleDeliveryProductDetails list
        /// </summary>
        List<XMSaleDeliveryProductDetails> GetXMSaleDeliveryProductDetailsList();
        List<XMSaleDeliveryProductDetails> GetXMSaleDeliveryListJDSelf(DateTime begin, DateTime end, List<int> WareHousesList);
        List<XMSaleDeliveryProductDetails> GetXMSaleDeliveryListOtherProject(DateTime begin, DateTime end, List<int> WareHousesList);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="saleDeliveryID"></param>
        /// <returns></returns>
        List<XMSaleDeliveryProductDetails> GetXMSaleDeliveryProductDetailsBySaleDeliveryID(int saleDeliveryID);

        /// <summary>
        /// 根据商品编码和销售出库主表ID
        /// </summary>
        /// <param name="platformMerchantCode"></param>
        /// <param name="saleDeliveryId"></param>
        /// <returns></returns>
        XMSaleDeliveryProductDetails GetXMSaleDeliveryProductDetailsByParm(string platformMerchantCode, int saleDeliveryId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="wareHousesID"></param>
        /// <param name="PlatformMerchantCode"></param>
        /// <returns></returns>
        List<XMSaleDeliveryProductDetails> GetXMSaleDeliveryProductDetailsByParm(DateTime startDate, DateTime endDate, int wareHousesID, string PlatformMerchantCode);

        /// <summary>
        /// get to XMSaleDeliveryProductDetails Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMSaleDeliveryProductDetails Page List</returns>
        PagedList<XMSaleDeliveryProductDetails> SearchXMSaleDeliveryProductDetails(int pageIndex, int pageSize, string sortExpression, string sortDirection);

        /// <summary>
        /// get a XMSaleDeliveryProductDetails by Id
        /// </summary>
        /// <param name="id">XMSaleDeliveryProductDetails Id</param>
        /// <returns>XMSaleDeliveryProductDetails</returns>   
        XMSaleDeliveryProductDetails GetXMSaleDeliveryProductDetailsById(int id);

        /// <summary>
        /// delete XMSaleDeliveryProductDetails by Id
        /// </summary>
        /// <param name="Id">XMSaleDeliveryProductDetails Id</param>
        void DeleteXMSaleDeliveryProductDetails(int id);

        /// <summary>
        /// Batch delete XMSaleDeliveryProductDetails by Id
        /// </summary>
        /// <param name="Ids">XMSaleDeliveryProductDetails Id</param>
        void BatchDeleteXMSaleDeliveryProductDetails(List<int> ids);

        #endregion
    }
}
