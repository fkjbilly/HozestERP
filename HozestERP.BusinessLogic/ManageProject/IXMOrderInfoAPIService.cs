using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using HozestERP.BusinessLogic.Codes;
using HozestERP.BusinessLogic.CustomerManagement;
using JdSdk;
using JdSdk.Domain;
using JdSdk.Domains;
using JdSdk.Response;
using Top.Api.Domain;
using Top.Api;
using JdSdk.Response;

namespace HozestERP.BusinessLogic.ManageProject
{
    public partial interface IXMOrderInfoAPIService
    {
        List<XMProject> GetXMProjectClientId(int ClientId);

        List<XMOrderInfo> GetXMOrderInfoByCreateDate(int timetype, int xMProjectId, string NickId, string OrderCode, string PartNo, string FullName, string[] status, int PlatformTypeNameId, string PrdouctName, DateTime? dtStartOrderInfoCreateDate, DateTime? dtEndOrderInfoCreateDate, int IsAudit, bool remarks, int IsScapling, int IsAbnormal, string SourceType, bool IsCM);

        List<XMOrderInfo> GetXMOrderInfoListOther(int xMProjectId, int NickId, string OrderCode, string FullName, string Status, int PlatformTypeId, DateTime? dtStartOrderInfoCreateDate, DateTime? dtEndOrderInfoCreateDate, int IsAudit, bool Remarks, int IsScalping, int IsAbnormal, int TimeType, string SourceType, string WantID);

        List<XMOrderInfo> GetXMOrderInfoListSearch(int xMProjectId, int NickId, string OrderCode, string FullName, string Status, int PlatformTypeId, DateTime? dtStartOrderInfoCreateDate, DateTime? dtEndOrderInfoCreateDate, int IsAudit, bool Remarks, int IsScapling, int IsAbnormal, int TimeType, string SourceType, string WantID, int IsOurOrder, string Mobile, string Address, int WaitNotice, int Urgent, int CanDeliver, int AppointDeliveryTime, DateTime AppointDeliveryBeginDate, DateTime AppointDeliveryEndDate, string CustomerServiceRemark);

        string XMOrderInfoDate(string param, string[] value, string OrderCodes, string timetype);

        string XMOrderInfoCreateDate(string param, string[] value, string OrderCodes, string timetype);

        XMNick GetXMNickByID(int nickID);

        List<XMNick> GetXMNickList();

        List<XMNick> GetXMNickList(string nick, int IsEnable, int ProjectId);

        List<XMNick> GetXMNickListbyPlatformId(string nick, int IsEnable, int PlatformId);

        List<XMNick> GetXMNickListSS(string nick, int IsEnable, int ProjectId, int userid, int ProjectName);

        Trade GetTrade(long Tid, XMOrderInfoApp xMorderInfoApp);

        Trade ReturnTradeMemoUpdate(long Tid, string memo, XMOrderInfoApp xMorderInfoApp);

        List<XMOrderInfo> GetXMOrderInfoByOrderCodeList(string OrderCode);

        AccessToken GetAccessTokenByAuthorizationCode();

        string DoAccessTokenPost(IDictionary<string, string> parameters);

        HttpWebRequest GetWebRequest(string url, string method);

        OrderInfo getOrderInfo(string orderId, XMOrderInfoApp xMorderInfoApp);

        OrderVenderRemarkUpdateResponseOne SetOrderVenderRemark(string OrderId, string Remark, string TradeNo, XMOrderInfoApp xMorderInfoApp);

        List<OrderInfo> GetOrderList(DateTime startDate, DateTime endDate, string orderState, int page, int pageSize, out Int32 totalCount, bool recursive, XMOrderInfoApp xMorderInfoApp);

        List<XMProductDetails> GetProductList(string paramProductName, string paramMerchantcode, int nickId);

        List<XMProductDetails> GetXMProductListByMerchantcode(string PlatFormMerchantCode);


        /// <summary>
        /// 根据订单号，抓取数据 京东
        /// </summary>
        /// <param name="orderInfo"></param>
        /// <param name="InsertCount"></param>
        /// <param name="UpdateCount"></param>
        void getOrderInfoJD(JDsingleServiceReference.OrderInfo orderInfo, ref int InsertCount, ref int UpdateCount, XMOrderInfoApp xMorderInfoApp);

        /// <summary>
        /// 根据订单号，抓取数据 天猫
        /// </summary>
        /// <param name="trade"></param>
        /// <param name="InsertCount"></param>
        /// <param name="UpdateCount"></param>
        void getTradeTM(Trade trade, ref int InsertCount, ref int UpdateCount, XMOrderInfoApp xMorderInfoApp);

        /// <summary>
        /// 根据订单号，抓取数据 唯品会
        /// </summary>
        void getOrderVPH(string startdate, string enddate, string ordercode, ref int InsertCount, ref int UpdateCount, XMOrderInfoApp xMorderInfoAppVPH);

        /// <summary>
        /// 根据订单号，抓取数据 唯品会MP
        /// </summary>
        /// <param name="ordercode"></param>
        /// <param name="InsertCount"></param>
        /// <param name="UpdateCount"></param>
        /// <param name="xMorderInfoApp"></param>
        void getOrderVPHMP(string ordercode, ref int InsertCount, ref int UpdateCount, XMOrderInfoApp xMorderInfoApp);

        /// <summary>
        /// 根据订单号，抓取数据 一号店
        /// </summary>
        /// <param name="ordercode"></param>
        /// <param name="InsertCount"></param>
        /// <param name="UpdateCount"></param>
        /// <param name="xMorderInfoApp"></param>
        void getOrderYHD(string ordercode, ref int InsertCount, ref int UpdateCount, XMOrderInfoApp xMorderInfoApp);


        /// <summary>
        /// yhd.order.merchant.remark.update 更新单个订单的卖家备注信息(一号店)
        /// </summary>
        /// <param name="ordercode">订单号</param>
        /// <param name="Remark">备注</param>
        /// <param name="xMOrderInfoApp"></param>
        int OrderMerchantRemarkUpdate(string ordercode, string Remark, XMOrderInfoApp xMOrderInfoApp);


        /// <summary>
        /// 根据订单号，抓取数据 苏宁易购
        /// </summary>
        /// <param name="ordercode"></param>
        /// <param name="InsertCount"></param>
        /// <param name="UpdateCount"></param>
        /// <param name="xMorderInfoApp"></param>
        void getOrderSuning(string ordercode, ref int InsertCount, ref int UpdateCount, XMOrderInfoApp xMorderInfoApp);


        /// <summary>
        /// 订单备注修改  suning.custom.ordernote.modify 苏宁易购
        /// </summary>
        /// <param name="ordercode"></param>
        /// <param name="InsertCount"></param>
        /// <param name="UpdateCount"></param>
        /// <param name="xMorderInfoApp"></param>
        string OrdernoteModifyUpdate(string ordercode, string noteContent, string colorMarkFlag, XMOrderInfoApp xMorderInfoApp);


        void SynchronousJDOrderData(string createDateStart, string createDateEnd, string newApiOrderStates, XMOrderInfoApp xMorderInfoApp);


        /// <summary>
        /// 同步天猫数据  taobao.trades.sold.increment.get 查询卖家已卖出的增量交易数据（根据修改时间）
        /// </summary>
        /// <param name="createDateStart"></param>
        /// <param name="createDateEnd"></param>
        /// <param name="Status"></param>
        /// <param name="InsertCount"></param>
        /// <param name="UpdateCount"></param>
        /// <param name="xMorderInfoApp"></param>
        void SynchronousTMTradesSoldIncrementGetList(string createDateStart, string createDateEnd, string Status, ref int InsertCount, ref int UpdateCount, XMOrderInfoApp xMorderInfoApp);

        /// <summary>
        /// taobao.trades.sold.get 查询卖家已卖出的交易数据（根据创建时间）
        /// </summary>
        /// <param name="createDateStart"></param>
        /// <param name="createDateEnd"></param>
        /// <param name="Status"></param>
        /// <param name="InsertCount"></param>
        /// <param name="UpdateCount"></param>
        /// <param name="xMorderInfoApp"></param>
        void SynchronousTMOrderData(string createDateStart, string createDateEnd, string Status, ref int InsertCount, ref int UpdateCount, XMOrderInfoApp xMorderInfoApp);

        void SynchronousYHDOrderData(string createDateStart, string createDateEnd, ref int InsertCount, ref int UpdateCount, XMOrderInfoApp xMorderInfoApp);


        /// <summary>
        /// 一号店 yhd.trades.sold.increment.get 查询卖家已卖出的增量交易数据（根据修改时间,兼容淘宝接口）
        /// </summary>
        /// <param name="createDateStart"></param>
        /// <param name="createDateEnd"></param>
        /// <param name="InsertCount"></param>
        /// <param name="UpdateCount"></param>
        /// <param name="xMorderInfoApp"></param>
        void SynchronousYHDTradesSoldIncrementData(string createDateStart, string createDateEnd, ref int InsertCount, ref int UpdateCount, XMOrderInfoApp xMorderInfoApp);

        void SynchronousVPHOrderData(string createDateStart, string createDateEnd, ref int InsertCount, ref int UpdateCount, XMOrderInfoApp xMorderInfoApp);

        void SynchronousVPHMPOrderData(string createDateStart, string createDateEnd, ref int InsertCount, ref int UpdateCount, XMOrderInfoApp xMorderInfoApp);

        /// <summary>
        /// 同步苏宁易购数据   批量获取订单（三个月内的订单） 
        /// </summary>
        /// <param name="createDateStart"></param>
        /// <param name="createDateEnd"></param>
        /// <param name="InsertCount"></param>
        /// <param name="UpdateCount"></param>
        /// <param name="xMorderInfoApp"></param>
        void SynchronousSuningOrderData(string createDateStart, string createDateEnd, ref int InsertCount, ref int UpdateCount, XMOrderInfoApp xMorderInfoApp);

        /// <summary>
        /// 同步苏宁易购数据  根据订单修改时间批量查询订单信息 
        /// </summary>
        /// <param name="createDateStart"></param>
        /// <param name="createDateEnd"></param>
        /// <param name="InsertCount"></param>
        /// <param name="UpdateCount"></param>
        /// <param name="xMorderInfoApp"></param>
        void SynchronousSuningOrdData(string createDateStart, string createDateEnd, ref int InsertCount, ref int UpdateCount, XMOrderInfoApp xMorderInfoApp);



        XMOrderInfo GetXMOrderInfoByOrderCode(string OrderCode);

        List<Trade> GetTradeList(string dateTimeStart, string dateTimeEnd, string status, int page, int pageSize, out Int64 totalCount, bool recursive, XMOrderInfoApp xMorderInfoApp);

        //void GetJDAndTMAfsServiceMessage(int page, int pageSize, ref Int64 totalCount, DateTime payDateStart, DateTime payDateEnd, XMOrderInfoApp xMorderInfoAppJD, XMOrderInfoApp xMorderInfoAppTM);

        List<AfsServiceMessage> GetAfsServiceMessage(int page, int pageSize, DateTime startDate, DateTime endDate, out Int64 totalCount, XMOrderInfoApp xMorderInfoApp);

        AfsServiceOut GetAfsServiceOut(long AfsServiceId, XMOrderInfoApp xMorderInfoApp);

        List<AfsFinanceDetailOut> GetAfsRefundInfoOut(long AfsServiceId, out List<AfsSignatureOut> aso, out AfsFinanceOut afo, out AfsRefundOut aro, XMOrderInfoApp xMorderInfoApp);

        void OrderInfoApplyPolicy();

        VenderRemark GetOrderVenderRemark(string orderId, XMOrderInfoApp xMorderInfoApp);

        List<XMProductNew> GetXMProductListByPlatFormMerchantCode(string PlatFormMerchantCode, int PlatformTypeId);

        JindingOutstoragePesponse GetOutstorage(string OrderId, string LogisticsId, string Waybill, XMOrderInfoApp xMorderInfoApp);

        bool SendTM(string OrderId, string CompanyCode, string Waybill, XMOrderInfoApp xMorderInfoApp);

        #region 赠品、返现

        /// <summary>
        /// 返现、赔付（除天猫 其它平台）
        /// </summary>
        /// <param name="CustomerServiceRemark">备注信息</param>
        /// <param name="WantNo">旺旺号</param>
        /// <param name="OrderCode">订单号</param>
        /// <param name="ApplicationTypeId">申请类型：返现、赔付</param>
        /// <param name="Dmoney">返现设置—金额（小于不需要运营审核，大于需运营审核）</param>
        int CashBackApplicationInst(string CustomerServiceRemark, string WantNo, string OrderCode, string FullName, int ApplicationTypeId, ref string paramMessage);


        /// <summary>
        /// 返现 （天猫）
        /// </summary>
        /// <param name="CustomerServiceRemark"></param>
        /// <param name="WantNo"></param>
        /// <param name="OrderCode"></param>
        /// <param name="FullName"></param>
        /// <param name="ApplicationTypeId"></param>
        /// <param name="paramMessage"></param>
        /// <returns></returns>
        int TMCashBackApplicationInst(string CustomerServiceRemark, string WantNo, string OrderCode, string FullName, int ApplicationTypeId, ref string paramMessage);
        /// <summary>
        /// 赠品
        /// </summary>
        /// <param name="CustomerServiceRemark">备注信息</param>
        /// <param name="WantNo">旺旺号</param>
        /// <param name="OrderCode">订单号</param>
        int XMPremiumsInst(string CustomerServiceRemark, string WantNo, string OrderCode, int ChildPremiums, ref string paramMessage, int platformTypeId, int nickID);



        /// <summary>
        /// 数据库原备注 与最新备注 作比较 最新备注有修改执行XMPremiumsAndCashBackApplication 
        /// </summary>
        /// <param name="CustomerServiceRemarkOld">原备注</param>
        /// <param name="CustomerServiceRemarkNew">最新备注</param>
        /// <param name="OrderCode">订单号</param>
        /// <param name="WantID">旺旺号</param>
        /// <param name="FullName">姓名</param>
        void XMPremiumsAndCashBackApplication(string CustomerServiceRemarkOld, string CustomerServiceRemarkNew, string OrderCode, string WantID, string FullName, int platformTypeId, int nickID);

        #endregion

        void PageJDOrderData(HozestERP.BusinessLogic.JDsingleServiceReference.OrderInfo[] orderlst, XMOrderInfoApp xMorderInfoApp);

        void TimingGetOrderInfo();

        void TimingGetOrderInfoIsUpdate();

        /// <summary>
        /// 电子面单云打印接口
        /// </summary>
        /// <returns>GetCaiNiaoWaybilInfo</returns>
        string GetCaiNiaoWaybilInfo(XMDelivery paramXMDelivery, string CpCode);//发货单管理>
        string GetCaiNiaoWaybilInfo(XMDelivery paramXMDelivery, string CpCode, XMOrderInfoApp XMOrderInfoAppList, ITopClient client);//发货单管理
        string GetCaiNiaoWaybilInfo(XMExpressManagement ExpressInfo, string CpCode);//快递管理

        string GetCaiNiaoWaybilInfo(XMExpressManagement ExpressInfo, string CpCode,XMOrderInfoApp XMOrderInfoAppList, ITopClient client);//快递管理

        /// <summary>
        /// 获取商家使用的标准模板
        /// </summary>
        string GetisvTemplates(string type, string cp_code);

        /// <summary>
        /// 商家取消获取的电子面单号-发货单管理
        /// </summary>
        string CancelWaybill(List<XMDelivery> paramXMDelivery);

        /// <summary>
        /// 商家取消获取的电子面单号-快递管理
        /// </summary>
        string CancelWaybill(List<XMExpressManagement> ExpressList);
        /// <summary>
        /// 根据组合商品编码获取组合商品信息
        /// </summary>
        /// <param name="PlatFormMerchantCode"></param>
        /// <param name="PlatformTypeId"></param>
        /// <returns></returns>

        List<XMProductNew> GetXMProductListByzuheCode(string PlatFormMerchantCode, int PlatformTypeId);

    }
}
