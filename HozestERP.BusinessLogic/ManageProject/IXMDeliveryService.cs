
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2015-01-30 09:44:22
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

namespace HozestERP.BusinessLogic.ManageProject
{
    public partial interface IXMDeliveryService
    {
        #region IXMDeliveryService成员
        /// <summary>
        /// Insert into XMDelivery
        /// </summary>
        /// <param name="xmdelivery">XMDelivery</param>
        void InsertXMDelivery(XMDelivery xmdelivery);

        /// <summary>
        /// Update into XMDelivery
        /// </summary>
        /// <param name="xmdelivery">XMDelivery</param>
        void UpdateXMDelivery(XMDelivery xmdelivery);
        /// <summary>
        /// Update into XMDelivery
        /// </summary>
        /// <param name="xmdelivery">XMDelivery</param>
        int UpdateXMDelivery(List<XMDelivery> xmdeliverylist);

        /// <summary>
        /// get to XMDelivery list
        /// </summary>
        List<XMDelivery> GetXMDeliveryList();
        /// <summary>
        /// 获取打印批次最大的发货单
        /// </summary>
        /// <returns></returns>
        XMDelivery GetFirstXMDelivery();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <param name="ddXMProject"></param>
        /// <returns></returns>
        List<XMDeliveryNew> GetXMDeliveryListByParm(string begin, string end, int ddXMProject);
        List<XMDelivery> GetXMDeliveryListPrice(DateTime begin, DateTime end, int ProjectId, int NickID, int PlatformTypeId);

        /// <summary>
        /// 根据物流单号 查询相关记录
        /// </summary>
        /// <param name="logisticsNumber"></param>
        /// <returns></returns>
        List<XMDelivery> GetXMDeliveryListByLogisticsNumber(string logisticsNumber);
        /// <summary>
        /// get to XMDelivery list
        /// </summary>
        List<XMDeliveryNew> GetXMDeliveryList(string ordercode, string partno, string deliveryno);
        List<XMDelivery> GetXMOrderInfoListByDeliveryNumber(string DeliveryNumber);
        List<XMDelivery> GetXMDeliveryListByOrderCodeShipper(string OrderCode, int Shipper);

        List<XMDelivery> GetXMDeliveryListByInfo(string OrderCode, int Shipper,int DeliveryTypeId);

        /// <summary>
        /// 根据、订单号、商品编码、发货单号 查询
        /// </summary>
        ///  <param name="logisticsNumber">物流单号</param>
        /// <param name="ordercode">订单号</param>
        /// <param name="partno">商品编码</param>
        /// <param name="deliveryno">发货单号</param>
        /// <param name="ddPrintQuantity">是否打印</param>
        /// <param name="DeliveryTypeId">发货单类型</param>
        /// <param name="FullName">收货人姓名</param>
        /// <param name="MobileAndTel">电话</param>
        /// <param name="IsDelivery">是否发货</param>
        /// <param name="ddXMProject">项目名称</param>
        /// <param name="isPrint">是否打印发货单</param>
        /// <param name="verificationStatus">发货单状态</param>
        /// <returns></returns>
        List<XMDeliveryNew> GetXMDeliverySearchList(string logisticsNumber, string ordercode, string manufacturersCode, string deliveryno, int ddPrintQuantity, int DeliveryTypeId,
            string FullName, string MobileAndTel, string DeliveryAddress, int IsDelivery, int ddXMProject, string PrintBatch, int Shipper, string Nick,
            string Printegin, string PrintEnd, string CreateBegin, string CreateEnd, int IsShelve, bool NoOrder,int isPrint,string verificationStatus, bool packageCheck,string logisticsCompany);

                /// <summary>
        /// 导出发货清单
        /// </summary>
        ///  <param name="logisticsNumber">物流单号</param>
        /// <param name="ordercode">订单号</param>
        /// <param name="partno">商品编码</param>
        /// <param name="deliveryno">发货单号</param>
        /// <param name="ddPrintQuantity">是否打印</param>
        /// <param name="DeliveryTypeId">发货单类型</param>
        /// <param name="FullName">收货人姓名</param>
        /// <param name="MobileAndTel">电话</param>
        /// <param name="DeliveryAddress">收货地址</param>
        /// <param name="IsDelivery">是否发货</param>
        /// <param name="ddXMProject">项目名称</param>
        /// <returns></returns>
        List<XMDeliveryNew> GetXMDeliveryExportList(string logisticsNumber, string ordercode, string manufacturersCode, string deliveryno, int ddPrintQuantity, int DeliveryTypeId,
            string FullName, string MobileAndTel, string DeliveryAddress, int IsDelivery, int ddXMProject, string PrintBatch, int Shipper, int Nick,
            string PrintBegin, string PrintEnd, string CreateBegin, string CreateEnd, int IsShelve, bool NoOrder);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Printegin"></param>
        /// <param name="PrintEnd"></param>
        /// <returns></returns>
        List<XMDelivery> GetXMDeliveryByPrintDate(int year, int month, string expressID);


        /// <summary>
        /// get to XMDelivery Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMDelivery Page List</returns>
        PagedList<XMDelivery> SearchXMDelivery(int pageIndex, int pageSize, string sortExpression, string sortDirection);

        /// <summary>
        /// get a XMDelivery by Id
        /// </summary>
        /// <param name="id">XMDelivery Id</param>
        /// <returns>XMDelivery</returns>   
        XMDelivery GetXMDeliveryById(int id);
        XMDelivery GetXMDeliveryByInvoiceInfo(int InvoiceInfoID);

        /// <summary>
        /// 根据Id集合查询
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns> 
        List<XMDelivery> GetXMDeliveryByListIds(List<int> Ids);


        /// <summary>
        /// 根据Id集合查询
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns>
        List<XMDeliveryNew> GetXMDeliverySearchListById(List<int> Ids);


        /// <summary>
        /// 根据订单号  商品厂家编码查询
        /// </summary>
        /// <param name="OrderCode">订单号</param>
        /// <param name="PlatformMerchantCode">厂家编码</param>
        /// <returns></returns>
        List<XMDelivery> GetXMDeliveryByOrderCodeandPartNo(string OrderCode, string PlatformMerchantCode);

        /// <summary>
        /// 根据订单号、发货单类型查询
        /// </summary>
        /// <param name="OrderCode">订单号</param>
        /// <param name="DeliveryTypeId">发货单类型</param>
        /// <returns></returns>
        List<XMDelivery> GetXMDeliveryByOrderCodeAndDeliveryTypeId(string OrderCode, int DeliveryTypeId);

        /// <summary>
        /// delete XMDelivery by Id
        /// </summary>
        /// <param name="Id">XMDelivery Id</param>
        void DeleteXMDelivery(int id);

        /// <summary>
        /// Batch delete XMDelivery by Id
        /// </summary>
        /// <param name="Ids">XMDelivery Id</param>
        void BatchDeleteXMDelivery(List<int> ids);

        void DeliveryLogisticsCheck();

        /// <summary>
        /// 根据订单号、是否发货、未打印 查询 
        /// </summary>
        /// <param name="OrderCode">订单号</param>
        /// <param name="IsDelivery">是否发货：0：未发货，1 :已发货</param>
        /// <param name="PrintQuantity">打印次数 ：0：未打印</param>
        /// <returns></returns>
        List<XMDelivery> GetXMDeliverySearchByOrderCodeList(string OrderCode, int IsDelivery, int PrintQuantity);
        List<XMDelivery> GetXMOrderInfoListByCode(string OrderCode, string ManufacturersCode);
        List<XMDelivery> GetXMOrderInfoListByOrderCode(string OrderCode, List<string> DeliveryNumberList);
        List<string> GetXMDeliveryListByOrderCode(string OrderCode, List<string> DeliveryNumberList);
        List<XMDelivery> GetXMDeliveryListByOrderCode(string OrderCode, int DeliveryTypeId);

        /// <summary>
        /// get to XMDelivery list
        /// </summary>
        List<XMDelivery> GetXMDeliveryById(int[] ids);

        /// <summary>
        /// 获取无订单发货单店铺信息
        /// </summary>
        /// <param name="orderCode"></param>
        /// <returns></returns>
        XMNick getNoOrderNickInfo(string orderCode);

        XMDelivery GetXMDeliveryByLogisticsNumber(string logisticsNumber);
        #endregion
    }
}
