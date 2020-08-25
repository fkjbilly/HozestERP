
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
using HozestERP.BusinessLogic.ManageApplication;
using HozestERP.Common;
using HozestERP.BusinessLogic.ManageProtal;

namespace HozestERP.BusinessLogic.ManageProject
{
    public partial interface IXMOrderInfoService
    {
        #region IXMOrderInfoService成员
        /// <summary>
        /// Insert into XMOrderInfo
        /// </summary>
        /// <param name="xmorderinfo">XMOrderInfo</param>
        void InsertXMOrderInfo(XMOrderInfo xmorderinfo);

        /// <summary>
        /// 实时平台费用（根据指定时间）
        /// </summary>
        /// <param name="PlatformTypeId">平台Id</param>
        /// <param name="nickIds">店铺集合</param>
        /// <param name="OrderInfoModifiedStart">开始时间</param>
        /// <param name="OrderInfoModifiedEnd">结束时间</param>
        /// <param name="OrderStatusId">时间类型</param>
        /// <returns></returns>
        List<OrderInfoSalesDetails> GetCWPlatformSpendingSearchListSSS(int PlatformTypeId, List<int> nickIds, DateTime? OrderInfoModifiedStart, DateTime? OrderInfoModifiedEnd, int OrderStatusId);

        /// <summary>
        /// 实时平台费用（根据指定时间）
        /// </summary>
        /// <param name="PlatformTypeId">平台Id</param>
        /// <param name="nickIds">店铺集合</param>
        /// <param name="OrderInfoModifiedStart">开始时间</param>
        /// <param name="OrderInfoModifiedEnd">结束时间</param>
        /// <param name="OrderStatusId">时间类型</param>
        /// <returns></returns>
        List<OrderInfoSalesDetails> GetCWPlatformSpendingSearchListSSS2(int PlatformTypeId, List<int> nickIds, DateTime? OrderInfoModifiedStart, DateTime? OrderInfoModifiedEnd, int OrderStatusId);

        /// <summary>
        /// Update into XMOrderInfo
        /// </summary>
        /// <param name="xmorderinfo">XMOrderInfo</param>
        void UpdateXMOrderInfo(XMOrderInfo xmorderinfo);

        /// <summary>
        /// get to XMOrderInfo list
        /// </summary>
        List<XMOrderInfo> GetXMOrderInfoList();

        List<XMOrderInfo> GetXMOrderInfoListBySingleRow(List<XMOrderInfo> list, int SingleRow, string ManufacturersCode, int CodeContain);

        List<XMOrderInfo> GetXMOrderInfoListByFullNameAndPlatformMerchantCode(string fullName, string[] platformMerchantCode);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="OrderCode"></param>
        /// <param name="type">1 一般订单 2 京东订单</param>
        /// <returns></returns>
        List<XMOrderInfoNew> getXMOrderInfoListByOrderCode(string OrderCode,int type);

        /// <summary>
        /// 用于安装单输入订单号提示
        /// </summary>
        /// <param name="OrderCode"></param>
        /// <returns></returns>
        List<XMOrderInfoNew> getXMOrderInfoListByOrderCodeForXMInstallationList(string OrderCode);

        List<int> GetVPHXMOrderInfoListByDateTime(DateTime Begin, DateTime End);

        /// <summary>
        /// 根据客服姓名查询相关记录
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="StartDate"></param>
        /// <param name="EndDate"></param>
        /// <returns></returns>
        List<XMOrderInfo> GetJingMoTongJiByParm(string Name, DateTime StartDate, DateTime EndDate);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="CustomerId"></param>
        /// <param name="StartDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="PlatformTypeId"></param>
        /// <param name="nickIds"></param>
        /// <returns></returns>
        List<XMOrderInfo> GetCustomerSaleMoneyParm(int CustomerId, DateTime StartDate, DateTime EndDate, int PlatformTypeId, List<int> nickIds);

        /// <summary>
        /// 订单审核通过
        /// </summary>
        /// <returns></returns>
        List<XMOrderInfo> GetXMOrderInfoListByDetails(List<int> NickId);

        /// <summary>
        /// 根据订单号查询
        /// </summary>
        List<XMOrderInfo> GetXMOrderInfoListByOrderEqs(string ordercode);
        List<XMOrderInfo> GetXMOrderInfoListByDeliveryTime(DateTime Begin, DateTime End);
        List<XMOrderInfo> GetXMOrderInfoListByCreateDateNickID(DateTime Begin, int NickID);

        /// <summary>
        /// 查找再途库存明细
        /// </summary>
        /// <param name="Begin"></param>
        /// <param name="End"></param>
        /// <returns></returns>
        List<XMOrderInfoProductDetails> GetrderInfoProductDetailsListNotShipped(DateTime Begin, DateTime End);

        /// <summary>
        /// 查询订单明细
        /// </summary>
        /// <param name="PlatformTypeId">平台Id</param>
        /// <param name="nickIds">店铺集合</param>
        /// <param name="OrderInfoModifiedStart">开始时间</param>
        /// <param name="OrderInfoModifiedEnd">结束时间</param>
        /// <param name="OrderStatusId">时间类型Id</param>
        /// <param name="ManufacturersCode">厂家编码</param>
        /// <returns></returns>
        List<OrderInfoSalesDetails> getXMOrderInfoList(int PlatformTypeId, List<int> nickIds, DateTime? OrderInfoModifiedStart, DateTime? OrderInfoModifiedEnd, int OrderStatusId, string ManufacturersCode);

        /// <summary>
        /// 查询订单明细
        /// </summary>
        /// <param name="PlatformTypeId">平台Id</param>
        /// <param name="nickIds">店铺集合</param>
        /// <param name="OrderInfoModifiedStart">开始时间</param>
        /// <param name="OrderInfoModifiedEnd">结束时间</param>
        /// <param name="OrderStatusId">时间类型Id</param>
        /// <param name="ManufacturersCode">厂家编码</param>
        /// <returns></returns>
        List<OrderInfoSalesDetails> getXMOrderInfoListToExport(int PlatformTypeId, List<int> nickIds, DateTime? OrderInfoModifiedStart, DateTime? OrderInfoModifiedEnd, int OrderStatusId, string ManufacturersCode);
        List<XMOrderInfoProductDetails> getXMOrderInfoListByBrandType(List<OrderInfoSalesDetails> List, int BrandType);
        List<OrderInfoSalesDetails> GetXMOrderInfoListByBrandType(List<OrderInfoSalesDetails> List, int BrandType);

        /// <summary>
        /// 查询订单赠品明细
        /// </summary>
        /// <param name="PlatformTypeId">平台Id</param>
        /// <param name="nickIds">店铺集合</param>
        /// <param name="OrderInfoModifiedStart">开始时间</param>
        /// <param name="OrderInfoModifiedEnd">结束时间</param>
        /// <param name="OrderStatusId">时间类型</param> 
        /// <returns></returns>
        List<OrderInfoSalesDetails> getXMOrderInfoAndPremiumsDetailsList(int PlatformTypeId, List<int> nickIds, DateTime? OrderInfoModifiedStart, DateTime? OrderInfoModifiedEnd, int OrderStatusId);

        /// <summary>
        /// 获取赠品成本
        /// </summary>
        /// <param name="PlatformTypeId"></param>
        /// <param name="nickIds"></param>
        /// <param name="OrderInfoModifiedStart"></param>
        /// <param name="OrderInfoModifiedEnd"></param>
        /// <param name="OrderStatusId"></param>
        /// <returns></returns>
        decimal getPremiumsCost(int PlatformTypeId, List<int> nickIds, DateTime? OrderInfoModifiedStart, DateTime? OrderInfoModifiedEnd);

        /// <summary>
        /// get to XMOrderInfo Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMOrderInfo Page List</returns>
        PagedList<XMOrderInfo> SearchXMOrderInfo(int pageIndex, int pageSize, string sortExpression, string sortDirection);

        bool AgreeMoveCargo(List<XMOrderInfoProductDetails> list, XMApplication ApplicationInfo);

        /// <summary>
        /// get a XMOrderInfo by ID
        /// </summary>
        /// <param name="id">XMOrderInfo ID</param>
        /// <returns>XMOrderInfo</returns>   
        XMOrderInfo GetXMOrderInfoByID(int id);

        XMOrderInfo GetXMOrderInfoByOrderCode(string OrderCode);

        List<XMOrderInfo> GetXMOrderInfoList(int[] ids);
        /// <summary>
        /// 根据订单Id集合 查询
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns>
        List<XMOrderInfo> GetXMOrderInfoListByIds(List<int> Ids);


        List<XMOrderInfo> GetXMOrderInfoByOrderCodeList(List<string> OrderCodes);

        /// <summary>
        /// delete XMOrderInfo by ID
        /// </summary>
        /// <param name="ID">XMOrderInfo ID</param>
        void DeleteXMOrderInfo(int id);

        /// <summary>
        /// Batch delete XMOrderInfo by ID
        /// </summary>
        /// <param name="IDs">XMOrderInfo ID</param>
        void BatchDeleteXMOrderInfo(List<int> ids);

        XMOrderInfo GetXMOrderAndOrderProductInfo(string ordercode, string jdid);

        /// <summary>
        /// 根据订单号查询
        /// </summary>
        /// <param name="ordercode"></param>
        /// <returns></returns>
        XMOrderInfo GetXMOrderByOrderCode(string ordercode);

        List<XMOrderInfo> GetXMOrderByOrderCode2(string ordercode);

        List<XMOrderInfo> GetXMOrderListByParm(int ProjectId, int NickId, int PlatformTypeId);

        /// <summary>
        /// 根据订单号查询(已确认收货订单)
        /// </summary>
        /// <param name="ordercode"></param>
        /// <returns></returns>
        List<XMOrderInfoMapping> GetXMOrderByOrderCodeList(string ordercode);

        /// <summary>
        /// 判断该订单是否刷单   true 是刷单  false 不是刷单
        /// </summary>
        /// <param name="ordercode"></param>
        /// <returns></returns>
        bool JudgeIsScalpingOrder(int platformtypeid, int nickid, string ordercode, string remark, string CustomerServiceRemark, string wantid, string productname, decimal saleprice, DateTime? orderInfoCreateDate);

        string ReturnDistributeMethod(string DistributeMethod);

        string ReturnPayMethod(string PayMethod);

        /// <summary>
        /// 根据订单OrderCode
        /// </summary>
        /// <param name="OrderCode"></param>
        /// <returns></returns>
        List<XMOrderInfoMapping> GetXMOrderInfoByOrderCodeList(string OrderCode);

        List<AbnormalOrder> getUnusualOrder();
        #endregion
    }
}
