
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2015-01-09 11:02:50
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
using HozestERP.BusinessLogic.ManageBusiness;
using HozestERP.Common;
using HozestERP.BusinessLogic.ManageFinance;

namespace HozestERP.BusinessLogic.ManageProject
{
    public partial interface IXMOrderInfoProductDetailsService
    {
        #region IXMOrderInfoProductDetailsService成员
        /// <summary>
        /// Insert into XMOrderInfoProductDetails
        /// </summary>
        /// <param name="xmorderinfoproductdetails">XMOrderInfoProductDetails</param>
        void InsertXMOrderInfoProductDetails(XMOrderInfoProductDetails xmorderinfoproductdetails);

        /// <summary>
        /// Update into XMOrderInfoProductDetails
        /// </summary>
        /// <param name="xmorderinfoproductdetails">XMOrderInfoProductDetails</param>
        void UpdateXMOrderInfoProductDetails(XMOrderInfoProductDetails xmorderinfoproductdetails);

        /// <summary>
        /// get to XMOrderInfoProductDetails list
        /// </summary>
        List<XMOrderInfoProductDetails> GetXMOrderInfoProductDetailsList(int OrderInfoID);


        List<WarningOrder> GetWarningOrderList();
        /// <summary>
        /// 退款货物明细
        /// </summary>
        List<XMBackProductDetails> GetBackProductDetails(int platform, List<int> nickIdList, string OrderCode, DateTime? BeginDate, DateTime? EndDate, int timeType);

        List<ProductSalesData> GetProductSales(DateTime BeginDate, DateTime EndDate, int ProjectId, List<int?> NickIdList, List<ProductSalesData> GroupList, int WarehouseID, int ProvinceNameID);

        List<ProductSalesData> GetWarehouseSales(DateTime BeginDate, DateTime EndDate, int ProjectId, List<int?> NickIdList, int WarehouseID, int ProvinceNameID);

        List<ProductSalesData> GetNotShippedSales(string Begin, string End, int ProjectId, List<int?> NickIdList, List<ProductSalesData> GroupList, int WaitNotice, int Urgent, int CanDeliver, int AppointDeliveryTime, int remarks, DateTime PayBeginDate, DateTime PayEndDate);

        /// <summary>
        /// 根据订单编码查询 商品信息
        /// </summary>
        List<XMOrderInfoProductDetails> GetXMOrderInfoProductDetailsListByOrderCode(string OrderCode);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="OrderCode"></param>
        /// <returns></returns>
        List<XMAlipaymentAccount> GetXMOrderInfoProductDetailsListByOrderCode2(string OrderCode);

        /// <summary>
        /// 根据订单Id、商品编码查询
        /// </summary>
        List<XMOrderInfoProductDetails> GetXMOrderInfoProductDetailsListByPlatformMerchantCode(int OrderId, string PlatformMerchantCode);

        /// <summary>
        /// 根据平台ID 商品编码  时间类型 查询订单列表
        /// </summary>
        /// <param name="platFormTypeId">平台ID</param>
        /// <param name="merchantCode">商品编码</param>
        /// <param name="startDateTime">开始时间</param>
        /// <param name="endDateTime">结束时间</param>
        /// <param name="endDateTime">时间类型</param>
        /// <returns></returns>
        List<XMOrderInfoProductDetails> GetXMOrderInfoProductListByParms(string platformMerchantCode, DateTime? startDateTime, DateTime? endDateTime, int timeType, int PlatformTypeId);


        /// <summary>
        /// 根据订单Id
        /// </summary>
        List<XMOrderInfoProductDetails> GetXMOrderInfoProductDetailsListByOrderId(int OrderId);

        /// <summary>
        /// 产品明细
        /// </summary>
        /// <param name="OrderInfoListNew">订单列表</param>
        /// <param name="ManufacturersCode">厂家编码</param>
        /// <returns></returns>
        List<OrderInfoSalesDetails> GetOrderInfoSalesDetailsList(int PlatformTypeId, List<int> nickIdList, DateTime? OrderInfoModifiedStart, DateTime? OrderInfoModifiedEnd, int OrderStatusId);
        /// <summary>
        /// 产品明细
        /// </summary>
        /// <param name="OrderInfoListNew">订单列表</param>
        /// <param name="ManufacturersCode">厂家编码</param>
        /// <returns></returns>
        List<OrderInfoSalesDetails> GetOrderInfoSalesDetailsListToExport(int PlatformTypeId, List<int> nickIdList, DateTime? OrderInfoModifiedStart, DateTime? OrderInfoModifiedEnd, int OrderStatusId);
        List<OrderInfoSalesDetails> GetOrderInfoSalesDetailsListByBrandType(List<OrderInfoSalesDetails> List, int BrandType);

        /// <summary>
        /// 获取产品名称和数量列表
        /// </summary>
        /// <returns></returns>
        List<SimpleInfoProductDetail> GetProductNameNum(int OrderInfoID);

        /// <summary>
        /// get to XMOrderInfoProductDetails Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMOrderInfoProductDetails Page List</returns>
        PagedList<XMOrderInfoProductDetails> SearchXMOrderInfoProductDetails(int pageIndex, int pageSize, string sortExpression, string sortDirection);

        /// <summary>
        /// get a XMOrderInfoProductDetails by ID
        /// </summary>
        /// <param name="id">XMOrderInfoProductDetails ID</param>
        /// <returns>XMOrderInfoProductDetails</returns>   
        XMOrderInfoProductDetails GetXMOrderInfoProductDetailsByID(int id);

        /// <summary>
        /// delete XMOrderInfoProductDetails by ID
        /// </summary>
        /// <param name="ID">XMOrderInfoProductDetails ID</param>
        void DeleteXMOrderInfoProductDetails(int id);

        /// <summary>
        /// Batch delete XMOrderInfoProductDetails by ID
        /// </summary>
        /// <param name="IDs">XMOrderInfoProductDetails ID</param>
        void BatchDeleteXMOrderInfoProductDetails(List<int> ids);

        #endregion
    }
}
