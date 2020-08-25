using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;

namespace com.vip.order.biz.service{
	
	
	public class OrdersBizServiceHelper {
		
		
		
		public class addOrderTransport_args {
			
			///<summary>
			///</summary>
			
			private com.vip.order.common.pojo.order.request.RequestHeader requestHeader_;
			
			///<summary>
			///</summary>
			
			private com.vip.order.biz.request.AddOrderTransportReq addOrderTransportReq_;
			
			public com.vip.order.common.pojo.order.request.RequestHeader GetRequestHeader(){
				return this.requestHeader_;
			}
			
			public void SetRequestHeader(com.vip.order.common.pojo.order.request.RequestHeader value){
				this.requestHeader_ = value;
			}
			public com.vip.order.biz.request.AddOrderTransportReq GetAddOrderTransportReq(){
				return this.addOrderTransportReq_;
			}
			
			public void SetAddOrderTransportReq(com.vip.order.biz.request.AddOrderTransportReq value){
				this.addOrderTransportReq_ = value;
			}
			
		}
		
		
		
		
		public class autoPay_args {
			
			///<summary>
			///</summary>
			
			private com.vip.order.common.pojo.order.request.RequestHeader requestHeader_;
			
			///<summary>
			///</summary>
			
			private com.vip.order.biz.request.AutoPayReq req_;
			
			public com.vip.order.common.pojo.order.request.RequestHeader GetRequestHeader(){
				return this.requestHeader_;
			}
			
			public void SetRequestHeader(com.vip.order.common.pojo.order.request.RequestHeader value){
				this.requestHeader_ = value;
			}
			public com.vip.order.biz.request.AutoPayReq GetReq(){
				return this.req_;
			}
			
			public void SetReq(com.vip.order.biz.request.AutoPayReq value){
				this.req_ = value;
			}
			
		}
		
		
		
		
		public class autoPayFail_args {
			
			///<summary>
			///</summary>
			
			private com.vip.order.common.pojo.order.request.RequestHeader requestHeader_;
			
			///<summary>
			///</summary>
			
			private com.vip.order.biz.request.AutoPayFailReq req_;
			
			public com.vip.order.common.pojo.order.request.RequestHeader GetRequestHeader(){
				return this.requestHeader_;
			}
			
			public void SetRequestHeader(com.vip.order.common.pojo.order.request.RequestHeader value){
				this.requestHeader_ = value;
			}
			public com.vip.order.biz.request.AutoPayFailReq GetReq(){
				return this.req_;
			}
			
			public void SetReq(com.vip.order.biz.request.AutoPayFailReq value){
				this.req_ = value;
			}
			
		}
		
		
		
		
		public class autoTakeInventory_args {
			
			///<summary>
			///</summary>
			
			private com.vip.order.common.pojo.order.request.RequestHeader requestHeader_;
			
			///<summary>
			///</summary>
			
			private com.vip.order.biz.request.AutoTakeInventoryReq req_;
			
			public com.vip.order.common.pojo.order.request.RequestHeader GetRequestHeader(){
				return this.requestHeader_;
			}
			
			public void SetRequestHeader(com.vip.order.common.pojo.order.request.RequestHeader value){
				this.requestHeader_ = value;
			}
			public com.vip.order.biz.request.AutoTakeInventoryReq GetReq(){
				return this.req_;
			}
			
			public void SetReq(com.vip.order.biz.request.AutoTakeInventoryReq value){
				this.req_ = value;
			}
			
		}
		
		
		
		
		public class b2cSupportSendSms_args {
			
			///<summary>
			///</summary>
			
			private com.vip.order.common.pojo.order.request.RequestHeader header_;
			
			///<summary>
			///</summary>
			
			private com.vip.order.biz.request.B2CSupportSendSmsReq req_;
			
			public com.vip.order.common.pojo.order.request.RequestHeader GetHeader(){
				return this.header_;
			}
			
			public void SetHeader(com.vip.order.common.pojo.order.request.RequestHeader value){
				this.header_ = value;
			}
			public com.vip.order.biz.request.B2CSupportSendSmsReq GetReq(){
				return this.req_;
			}
			
			public void SetReq(com.vip.order.biz.request.B2CSupportSendSmsReq value){
				this.req_ = value;
			}
			
		}
		
		
		
		
		public class batchGetOrderActiveDetail_args {
			
			///<summary>
			///</summary>
			
			private com.vip.order.common.pojo.order.request.RequestHeader requestHeader_;
			
			///<summary>
			///</summary>
			
			private com.vip.order.biz.request.BatchGetOrderActiveDetailReq batchGetOrderActiveDetailReq_;
			
			public com.vip.order.common.pojo.order.request.RequestHeader GetRequestHeader(){
				return this.requestHeader_;
			}
			
			public void SetRequestHeader(com.vip.order.common.pojo.order.request.RequestHeader value){
				this.requestHeader_ = value;
			}
			public com.vip.order.biz.request.BatchGetOrderActiveDetailReq GetBatchGetOrderActiveDetailReq(){
				return this.batchGetOrderActiveDetailReq_;
			}
			
			public void SetBatchGetOrderActiveDetailReq(com.vip.order.biz.request.BatchGetOrderActiveDetailReq value){
				this.batchGetOrderActiveDetailReq_ = value;
			}
			
		}
		
		
		
		
		public class batchGetOrderList_args {
			
			///<summary>
			///</summary>
			
			private com.vip.order.common.pojo.order.request.RequestHeader requestHeader_;
			
			///<summary>
			///</summary>
			
			private com.vip.order.biz.request.BatchGetOrderListReq searchOrderReq_;
			
			///<summary>
			///</summary>
			
			private com.vip.order.common.pojo.order.request.ResultFilter resultFilter_;
			
			public com.vip.order.common.pojo.order.request.RequestHeader GetRequestHeader(){
				return this.requestHeader_;
			}
			
			public void SetRequestHeader(com.vip.order.common.pojo.order.request.RequestHeader value){
				this.requestHeader_ = value;
			}
			public com.vip.order.biz.request.BatchGetOrderListReq GetSearchOrderReq(){
				return this.searchOrderReq_;
			}
			
			public void SetSearchOrderReq(com.vip.order.biz.request.BatchGetOrderListReq value){
				this.searchOrderReq_ = value;
			}
			public com.vip.order.common.pojo.order.request.ResultFilter GetResultFilter(){
				return this.resultFilter_;
			}
			
			public void SetResultFilter(com.vip.order.common.pojo.order.request.ResultFilter value){
				this.resultFilter_ = value;
			}
			
		}
		
		
		
		
		public class batchGetOrderTransportList_args {
			
			///<summary>
			///</summary>
			
			private com.vip.order.common.pojo.order.request.RequestHeader requestHeader_;
			
			///<summary>
			///</summary>
			
			private com.vip.order.biz.request.BatchGetOrderTransportListReq batchGetOrderTransportListReq_;
			
			///<summary>
			///</summary>
			
			private com.vip.order.common.pojo.order.request.ResultFilter resultFilter_;
			
			public com.vip.order.common.pojo.order.request.RequestHeader GetRequestHeader(){
				return this.requestHeader_;
			}
			
			public void SetRequestHeader(com.vip.order.common.pojo.order.request.RequestHeader value){
				this.requestHeader_ = value;
			}
			public com.vip.order.biz.request.BatchGetOrderTransportListReq GetBatchGetOrderTransportListReq(){
				return this.batchGetOrderTransportListReq_;
			}
			
			public void SetBatchGetOrderTransportListReq(com.vip.order.biz.request.BatchGetOrderTransportListReq value){
				this.batchGetOrderTransportListReq_ = value;
			}
			public com.vip.order.common.pojo.order.request.ResultFilter GetResultFilter(){
				return this.resultFilter_;
			}
			
			public void SetResultFilter(com.vip.order.common.pojo.order.request.ResultFilter value){
				this.resultFilter_ = value;
			}
			
		}
		
		
		
		
		public class batchModifyOrderInvoice_args {
			
			///<summary>
			///</summary>
			
			private com.vip.order.common.pojo.order.request.RequestHeader requestHeader_;
			
			///<summary>
			///</summary>
			
			private com.vip.order.biz.request.BatchModifyOrderInvoiceReq batchModifyOrderInvoiceReq_;
			
			public com.vip.order.common.pojo.order.request.RequestHeader GetRequestHeader(){
				return this.requestHeader_;
			}
			
			public void SetRequestHeader(com.vip.order.common.pojo.order.request.RequestHeader value){
				this.requestHeader_ = value;
			}
			public com.vip.order.biz.request.BatchModifyOrderInvoiceReq GetBatchModifyOrderInvoiceReq(){
				return this.batchModifyOrderInvoiceReq_;
			}
			
			public void SetBatchModifyOrderInvoiceReq(com.vip.order.biz.request.BatchModifyOrderInvoiceReq value){
				this.batchModifyOrderInvoiceReq_ = value;
			}
			
		}
		
		
		
		
		public class batchUpdateWmsFlag_args {
			
			///<summary>
			///</summary>
			
			private com.vip.order.common.pojo.order.request.RequestHeader requestHeader_;
			
			///<summary>
			///</summary>
			
			private com.vip.order.biz.request.BatchUpdateWmsFlagReq batchUpdateWmsFlagReq_;
			
			public com.vip.order.common.pojo.order.request.RequestHeader GetRequestHeader(){
				return this.requestHeader_;
			}
			
			public void SetRequestHeader(com.vip.order.common.pojo.order.request.RequestHeader value){
				this.requestHeader_ = value;
			}
			public com.vip.order.biz.request.BatchUpdateWmsFlagReq GetBatchUpdateWmsFlagReq(){
				return this.batchUpdateWmsFlagReq_;
			}
			
			public void SetBatchUpdateWmsFlagReq(com.vip.order.biz.request.BatchUpdateWmsFlagReq value){
				this.batchUpdateWmsFlagReq_ = value;
			}
			
		}
		
		
		
		
		public class calculateSplitOrderMoney_args {
			
			///<summary>
			///</summary>
			
			private com.vip.order.common.pojo.order.request.RequestHeader header_;
			
			///<summary>
			///</summary>
			
			private com.vip.order.biz.request.CalculateSplitOrderMoneyReq req_;
			
			public com.vip.order.common.pojo.order.request.RequestHeader GetHeader(){
				return this.header_;
			}
			
			public void SetHeader(com.vip.order.common.pojo.order.request.RequestHeader value){
				this.header_ = value;
			}
			public com.vip.order.biz.request.CalculateSplitOrderMoneyReq GetReq(){
				return this.req_;
			}
			
			public void SetReq(com.vip.order.biz.request.CalculateSplitOrderMoneyReq value){
				this.req_ = value;
			}
			
		}
		
		
		
		
		public class cancelOFixData_args {
			
			///<summary>
			///</summary>
			
			private com.vip.order.common.pojo.order.request.RequestHeader requestHeader_;
			
			///<summary>
			///</summary>
			
			private com.vip.order.biz.request.CancelOrderFixDataReq cancelOrderFixDataReq_;
			
			public com.vip.order.common.pojo.order.request.RequestHeader GetRequestHeader(){
				return this.requestHeader_;
			}
			
			public void SetRequestHeader(com.vip.order.common.pojo.order.request.RequestHeader value){
				this.requestHeader_ = value;
			}
			public com.vip.order.biz.request.CancelOrderFixDataReq GetCancelOrderFixDataReq(){
				return this.cancelOrderFixDataReq_;
			}
			
			public void SetCancelOrderFixDataReq(com.vip.order.biz.request.CancelOrderFixDataReq value){
				this.cancelOrderFixDataReq_ = value;
			}
			
		}
		
		
		
		
		public class cancelOrder_args {
			
			///<summary>
			///</summary>
			
			private com.vip.order.common.pojo.order.request.RequestHeader requestHeader_;
			
			///<summary>
			///</summary>
			
			private com.vip.order.biz.request.CancelOrderReq reqParam_;
			
			///<summary>
			///</summary>
			
			private com.vip.order.biz.request.CancelOrderPrivilegeReq privParam_;
			
			public com.vip.order.common.pojo.order.request.RequestHeader GetRequestHeader(){
				return this.requestHeader_;
			}
			
			public void SetRequestHeader(com.vip.order.common.pojo.order.request.RequestHeader value){
				this.requestHeader_ = value;
			}
			public com.vip.order.biz.request.CancelOrderReq GetReqParam(){
				return this.reqParam_;
			}
			
			public void SetReqParam(com.vip.order.biz.request.CancelOrderReq value){
				this.reqParam_ = value;
			}
			public com.vip.order.biz.request.CancelOrderPrivilegeReq GetPrivParam(){
				return this.privParam_;
			}
			
			public void SetPrivParam(com.vip.order.biz.request.CancelOrderPrivilegeReq value){
				this.privParam_ = value;
			}
			
		}
		
		
		
		
		public class cancelPresellOrder_args {
			
			///<summary>
			///</summary>
			
			private com.vip.order.common.pojo.order.request.RequestHeader requestHeader_;
			
			///<summary>
			///</summary>
			
			private com.vip.order.biz.request.CancelOrderReq reqParam_;
			
			///<summary>
			///</summary>
			
			private com.vip.order.biz.request.CancelOrderPrivilegeReq privParam_;
			
			public com.vip.order.common.pojo.order.request.RequestHeader GetRequestHeader(){
				return this.requestHeader_;
			}
			
			public void SetRequestHeader(com.vip.order.common.pojo.order.request.RequestHeader value){
				this.requestHeader_ = value;
			}
			public com.vip.order.biz.request.CancelOrderReq GetReqParam(){
				return this.reqParam_;
			}
			
			public void SetReqParam(com.vip.order.biz.request.CancelOrderReq value){
				this.reqParam_ = value;
			}
			public com.vip.order.biz.request.CancelOrderPrivilegeReq GetPrivParam(){
				return this.privParam_;
			}
			
			public void SetPrivParam(com.vip.order.biz.request.CancelOrderPrivilegeReq value){
				this.privParam_ = value;
			}
			
		}
		
		
		
		
		public class checkCashOnDelivery_args {
			
			///<summary>
			///</summary>
			
			private com.vip.order.common.pojo.order.request.RequestHeader requestHeader_;
			
			///<summary>
			///</summary>
			
			private com.vip.order.biz.request.CheckCashOnDeliveryReq checkCashOnDeliveryReq_;
			
			public com.vip.order.common.pojo.order.request.RequestHeader GetRequestHeader(){
				return this.requestHeader_;
			}
			
			public void SetRequestHeader(com.vip.order.common.pojo.order.request.RequestHeader value){
				this.requestHeader_ = value;
			}
			public com.vip.order.biz.request.CheckCashOnDeliveryReq GetCheckCashOnDeliveryReq(){
				return this.checkCashOnDeliveryReq_;
			}
			
			public void SetCheckCashOnDeliveryReq(com.vip.order.biz.request.CheckCashOnDeliveryReq value){
				this.checkCashOnDeliveryReq_ = value;
			}
			
		}
		
		
		
		
		public class checkDeliveryFetchExchange_args {
			
			///<summary>
			///</summary>
			
			private com.vip.order.common.pojo.order.request.RequestHeader requestHeader_;
			
			///<summary>
			///</summary>
			
			private com.vip.order.biz.request.CheckDeliveryFetchExchangeReq checkDeliveryFetchExchangeReq_;
			
			public com.vip.order.common.pojo.order.request.RequestHeader GetRequestHeader(){
				return this.requestHeader_;
			}
			
			public void SetRequestHeader(com.vip.order.common.pojo.order.request.RequestHeader value){
				this.requestHeader_ = value;
			}
			public com.vip.order.biz.request.CheckDeliveryFetchExchangeReq GetCheckDeliveryFetchExchangeReq(){
				return this.checkDeliveryFetchExchangeReq_;
			}
			
			public void SetCheckDeliveryFetchExchangeReq(com.vip.order.biz.request.CheckDeliveryFetchExchangeReq value){
				this.checkDeliveryFetchExchangeReq_ = value;
			}
			
		}
		
		
		
		
		public class checkDeliveryFetchReturn_args {
			
			///<summary>
			///</summary>
			
			private com.vip.order.common.pojo.order.request.RequestHeader requestHeader_;
			
			///<summary>
			///</summary>
			
			private com.vip.order.biz.request.CheckDeliveryFetchReturnReq checkDeliveryFetchReturnReq_;
			
			public com.vip.order.common.pojo.order.request.RequestHeader GetRequestHeader(){
				return this.requestHeader_;
			}
			
			public void SetRequestHeader(com.vip.order.common.pojo.order.request.RequestHeader value){
				this.requestHeader_ = value;
			}
			public com.vip.order.biz.request.CheckDeliveryFetchReturnReq GetCheckDeliveryFetchReturnReq(){
				return this.checkDeliveryFetchReturnReq_;
			}
			
			public void SetCheckDeliveryFetchReturnReq(com.vip.order.biz.request.CheckDeliveryFetchReturnReq value){
				this.checkDeliveryFetchReturnReq_ = value;
			}
			
		}
		
		
		
		
		public class checkOrderReturnVendorAudit_args {
			
			///<summary>
			///</summary>
			
			private com.vip.order.common.pojo.order.request.RequestHeader requestHeader_;
			
			///<summary>
			///</summary>
			
			private com.vip.order.biz.request.CheckOrderReturnVendorAuditReq checkOrderReturnVendorAuditReq_;
			
			public com.vip.order.common.pojo.order.request.RequestHeader GetRequestHeader(){
				return this.requestHeader_;
			}
			
			public void SetRequestHeader(com.vip.order.common.pojo.order.request.RequestHeader value){
				this.requestHeader_ = value;
			}
			public com.vip.order.biz.request.CheckOrderReturnVendorAuditReq GetCheckOrderReturnVendorAuditReq(){
				return this.checkOrderReturnVendorAuditReq_;
			}
			
			public void SetCheckOrderReturnVendorAuditReq(com.vip.order.biz.request.CheckOrderReturnVendorAuditReq value){
				this.checkOrderReturnVendorAuditReq_ = value;
			}
			
		}
		
		
		
		
		public class confirmDelivered_args {
			
			///<summary>
			///</summary>
			
			private com.vip.order.common.pojo.order.request.RequestHeader header_;
			
			///<summary>
			///</summary>
			
			private com.vip.order.biz.request.ConfirmDeliveredReq req_;
			
			public com.vip.order.common.pojo.order.request.RequestHeader GetHeader(){
				return this.header_;
			}
			
			public void SetHeader(com.vip.order.common.pojo.order.request.RequestHeader value){
				this.header_ = value;
			}
			public com.vip.order.biz.request.ConfirmDeliveredReq GetReq(){
				return this.req_;
			}
			
			public void SetReq(com.vip.order.biz.request.ConfirmDeliveredReq value){
				this.req_ = value;
			}
			
		}
		
		
		
		
		public class confirmOrderGroupBuyResult_args {
			
			///<summary>
			///</summary>
			
			private com.vip.order.common.pojo.order.request.RequestHeader requestHeader_;
			
			///<summary>
			///</summary>
			
			private com.vip.order.biz.request.ConfirmOrderGroupBuyReq req_;
			
			public com.vip.order.common.pojo.order.request.RequestHeader GetRequestHeader(){
				return this.requestHeader_;
			}
			
			public void SetRequestHeader(com.vip.order.common.pojo.order.request.RequestHeader value){
				this.requestHeader_ = value;
			}
			public com.vip.order.biz.request.ConfirmOrderGroupBuyReq GetReq(){
				return this.req_;
			}
			
			public void SetReq(com.vip.order.biz.request.ConfirmOrderGroupBuyReq value){
				this.req_ = value;
			}
			
		}
		
		
		
		
		public class createOrder_args {
			
			///<summary>
			///</summary>
			
			private com.vip.order.biz.request.RequestHeader requestHeader_;
			
			///<summary>
			///</summary>
			
			private int? orderCategory_;
			
			///<summary>
			///</summary>
			
			private List<com.vip.order.biz.request.CreateOrderReq> createOrderParam_;
			
			public com.vip.order.biz.request.RequestHeader GetRequestHeader(){
				return this.requestHeader_;
			}
			
			public void SetRequestHeader(com.vip.order.biz.request.RequestHeader value){
				this.requestHeader_ = value;
			}
			public int? GetOrderCategory(){
				return this.orderCategory_;
			}
			
			public void SetOrderCategory(int? value){
				this.orderCategory_ = value;
			}
			public List<com.vip.order.biz.request.CreateOrderReq> GetCreateOrderParam(){
				return this.createOrderParam_;
			}
			
			public void SetCreateOrderParam(List<com.vip.order.biz.request.CreateOrderReq> value){
				this.createOrderParam_ = value;
			}
			
		}
		
		
		
		
		public class createOrderElectronicInvoice_args {
			
			///<summary>
			///</summary>
			
			private com.vip.order.common.pojo.order.request.RequestHeader requestHeader_;
			
			///<summary>
			///</summary>
			
			private com.vip.order.biz.request.CreateOrderElectronicInvoiceReq createOrderElectronicInvoiceReq_;
			
			public com.vip.order.common.pojo.order.request.RequestHeader GetRequestHeader(){
				return this.requestHeader_;
			}
			
			public void SetRequestHeader(com.vip.order.common.pojo.order.request.RequestHeader value){
				this.requestHeader_ = value;
			}
			public com.vip.order.biz.request.CreateOrderElectronicInvoiceReq GetCreateOrderElectronicInvoiceReq(){
				return this.createOrderElectronicInvoiceReq_;
			}
			
			public void SetCreateOrderElectronicInvoiceReq(com.vip.order.biz.request.CreateOrderElectronicInvoiceReq value){
				this.createOrderElectronicInvoiceReq_ = value;
			}
			
		}
		
		
		
		
		public class createOrderPostProc_args {
			
			///<summary>
			///</summary>
			
			private com.vip.order.common.pojo.order.request.RequestHeader requestHeader_;
			
			///<summary>
			///</summary>
			
			private com.vip.order.biz.request.CreateOrderPostProcReq req_;
			
			public com.vip.order.common.pojo.order.request.RequestHeader GetRequestHeader(){
				return this.requestHeader_;
			}
			
			public void SetRequestHeader(com.vip.order.common.pojo.order.request.RequestHeader value){
				this.requestHeader_ = value;
			}
			public com.vip.order.biz.request.CreateOrderPostProcReq GetReq(){
				return this.req_;
			}
			
			public void SetReq(com.vip.order.biz.request.CreateOrderPostProcReq value){
				this.req_ = value;
			}
			
		}
		
		
		
		
		public class createOrderSnV2_args {
			
			///<summary>
			///</summary>
			
			private com.vip.order.common.pojo.order.request.RequestHeader requestHeader_;
			
			///<summary>
			/// 仓库标识
			///</summary>
			
			private string warehouse_;
			
			///<summary>
			/// 需要生成的订单号数量，默认为1，最大50
			///</summary>
			
			private int? number_;
			
			public com.vip.order.common.pojo.order.request.RequestHeader GetRequestHeader(){
				return this.requestHeader_;
			}
			
			public void SetRequestHeader(com.vip.order.common.pojo.order.request.RequestHeader value){
				this.requestHeader_ = value;
			}
			public string GetWarehouse(){
				return this.warehouse_;
			}
			
			public void SetWarehouse(string value){
				this.warehouse_ = value;
			}
			public int? GetNumber(){
				return this.number_;
			}
			
			public void SetNumber(int? value){
				this.number_ = value;
			}
			
		}
		
		
		
		
		public class createOrderSnV3_args {
			
			///<summary>
			///</summary>
			
			private com.vip.order.common.pojo.order.request.RequestHeader requestHeader_;
			
			///<summary>
			///</summary>
			
			private com.vip.order.biz.request.CreateOrderSnReqV3 req_;
			
			public com.vip.order.common.pojo.order.request.RequestHeader GetRequestHeader(){
				return this.requestHeader_;
			}
			
			public void SetRequestHeader(com.vip.order.common.pojo.order.request.RequestHeader value){
				this.requestHeader_ = value;
			}
			public com.vip.order.biz.request.CreateOrderSnReqV3 GetReq(){
				return this.req_;
			}
			
			public void SetReq(com.vip.order.biz.request.CreateOrderSnReqV3 value){
				this.req_ = value;
			}
			
		}
		
		
		
		
		public class createOrderV2_args {
			
			///<summary>
			///</summary>
			
			private com.vip.order.common.pojo.order.request.RequestHeader requestHeader_;
			
			///<summary>
			///</summary>
			
			private int? orderCategory_;
			
			///<summary>
			///</summary>
			
			private List<com.vip.order.biz.request.CreateOrderReqV2> createOrderParam_;
			
			public com.vip.order.common.pojo.order.request.RequestHeader GetRequestHeader(){
				return this.requestHeader_;
			}
			
			public void SetRequestHeader(com.vip.order.common.pojo.order.request.RequestHeader value){
				this.requestHeader_ = value;
			}
			public int? GetOrderCategory(){
				return this.orderCategory_;
			}
			
			public void SetOrderCategory(int? value){
				this.orderCategory_ = value;
			}
			public List<com.vip.order.biz.request.CreateOrderReqV2> GetCreateOrderParam(){
				return this.createOrderParam_;
			}
			
			public void SetCreateOrderParam(List<com.vip.order.biz.request.CreateOrderReqV2> value){
				this.createOrderParam_ = value;
			}
			
		}
		
		
		
		
		public class createOrderV3_args {
			
			///<summary>
			///</summary>
			
			private com.vip.order.common.pojo.order.request.RequestHeader requestHeader_;
			
			///<summary>
			///</summary>
			
			private int? orderCategory_;
			
			///<summary>
			///</summary>
			
			private List<com.vip.order.biz.request.CreateOrderReqV3> createOrderParam_;
			
			public com.vip.order.common.pojo.order.request.RequestHeader GetRequestHeader(){
				return this.requestHeader_;
			}
			
			public void SetRequestHeader(com.vip.order.common.pojo.order.request.RequestHeader value){
				this.requestHeader_ = value;
			}
			public int? GetOrderCategory(){
				return this.orderCategory_;
			}
			
			public void SetOrderCategory(int? value){
				this.orderCategory_ = value;
			}
			public List<com.vip.order.biz.request.CreateOrderReqV3> GetCreateOrderParam(){
				return this.createOrderParam_;
			}
			
			public void SetCreateOrderParam(List<com.vip.order.biz.request.CreateOrderReqV3> value){
				this.createOrderParam_ = value;
			}
			
		}
		
		
		
		
		public class cscCancelBack_args {
			
			///<summary>
			///</summary>
			
			private com.vip.order.common.pojo.order.request.RequestHeader header_;
			
			///<summary>
			///</summary>
			
			private com.vip.order.biz.request.CSCCancelBackReq req_;
			
			public com.vip.order.common.pojo.order.request.RequestHeader GetHeader(){
				return this.header_;
			}
			
			public void SetHeader(com.vip.order.common.pojo.order.request.RequestHeader value){
				this.header_ = value;
			}
			public com.vip.order.biz.request.CSCCancelBackReq GetReq(){
				return this.req_;
			}
			
			public void SetReq(com.vip.order.biz.request.CSCCancelBackReq value){
				this.req_ = value;
			}
			
		}
		
		
		
		
		public class displayOrder_args {
			
			///<summary>
			///</summary>
			
			private com.vip.order.common.pojo.order.request.RequestHeader requestHeader_;
			
			///<summary>
			///</summary>
			
			private com.vip.order.biz.request.DisplayOrderReq req_;
			
			public com.vip.order.common.pojo.order.request.RequestHeader GetRequestHeader(){
				return this.requestHeader_;
			}
			
			public void SetRequestHeader(com.vip.order.common.pojo.order.request.RequestHeader value){
				this.requestHeader_ = value;
			}
			public com.vip.order.biz.request.DisplayOrderReq GetReq(){
				return this.req_;
			}
			
			public void SetReq(com.vip.order.biz.request.DisplayOrderReq value){
				this.req_ = value;
			}
			
		}
		
		
		
		
		public class getAfterSaleOpType_args {
			
			///<summary>
			///</summary>
			
			private com.vip.order.common.pojo.order.request.RequestHeader requestHeader_;
			
			///<summary>
			///</summary>
			
			private com.vip.order.biz.request.GetAfterSaleOpTypeReq req_;
			
			public com.vip.order.common.pojo.order.request.RequestHeader GetRequestHeader(){
				return this.requestHeader_;
			}
			
			public void SetRequestHeader(com.vip.order.common.pojo.order.request.RequestHeader value){
				this.requestHeader_ = value;
			}
			public com.vip.order.biz.request.GetAfterSaleOpTypeReq GetReq(){
				return this.req_;
			}
			
			public void SetReq(com.vip.order.biz.request.GetAfterSaleOpTypeReq value){
				this.req_ = value;
			}
			
		}
		
		
		
		
		public class getCanAfterSaleOrderListByUserId_args {
			
			///<summary>
			///</summary>
			
			private com.vip.order.common.pojo.order.request.RequestHeader header_;
			
			///<summary>
			///</summary>
			
			private com.vip.order.biz.request.GetCanAfterSaleOrderListReq req_;
			
			///<summary>
			///</summary>
			
			private com.vip.order.common.pojo.order.request.PageResultFilter pageResultFilter_;
			
			public com.vip.order.common.pojo.order.request.RequestHeader GetHeader(){
				return this.header_;
			}
			
			public void SetHeader(com.vip.order.common.pojo.order.request.RequestHeader value){
				this.header_ = value;
			}
			public com.vip.order.biz.request.GetCanAfterSaleOrderListReq GetReq(){
				return this.req_;
			}
			
			public void SetReq(com.vip.order.biz.request.GetCanAfterSaleOrderListReq value){
				this.req_ = value;
			}
			public com.vip.order.common.pojo.order.request.PageResultFilter GetPageResultFilter(){
				return this.pageResultFilter_;
			}
			
			public void SetPageResultFilter(com.vip.order.common.pojo.order.request.PageResultFilter value){
				this.pageResultFilter_ = value;
			}
			
		}
		
		
		
		
		public class getCanRefundOrderCount_args {
			
			///<summary>
			///</summary>
			
			private com.vip.order.common.pojo.order.request.RequestHeader requestHeader_;
			
			///<summary>
			///</summary>
			
			private com.vip.order.biz.request.GetCanRefundOrderCountReq getCanRefundOrderCountReq_;
			
			public com.vip.order.common.pojo.order.request.RequestHeader GetRequestHeader(){
				return this.requestHeader_;
			}
			
			public void SetRequestHeader(com.vip.order.common.pojo.order.request.RequestHeader value){
				this.requestHeader_ = value;
			}
			public com.vip.order.biz.request.GetCanRefundOrderCountReq GetGetCanRefundOrderCountReq(){
				return this.getCanRefundOrderCountReq_;
			}
			
			public void SetGetCanRefundOrderCountReq(com.vip.order.biz.request.GetCanRefundOrderCountReq value){
				this.getCanRefundOrderCountReq_ = value;
			}
			
		}
		
		
		
		
		public class getCanRefundOrderList_args {
			
			///<summary>
			///</summary>
			
			private com.vip.order.common.pojo.order.request.RequestHeader requestHeader_;
			
			///<summary>
			///</summary>
			
			private com.vip.order.biz.request.GetCanRefundOrderListReq getCanRefundOrderListReq_;
			
			public com.vip.order.common.pojo.order.request.RequestHeader GetRequestHeader(){
				return this.requestHeader_;
			}
			
			public void SetRequestHeader(com.vip.order.common.pojo.order.request.RequestHeader value){
				this.requestHeader_ = value;
			}
			public com.vip.order.biz.request.GetCanRefundOrderListReq GetGetCanRefundOrderListReq(){
				return this.getCanRefundOrderListReq_;
			}
			
			public void SetGetCanRefundOrderListReq(com.vip.order.biz.request.GetCanRefundOrderListReq value){
				this.getCanRefundOrderListReq_ = value;
			}
			
		}
		
		
		
		
		public class getEbsGoodsList_args {
			
			///<summary>
			///</summary>
			
			private com.vip.order.common.pojo.order.request.RequestHeader requestHeader_;
			
			///<summary>
			///</summary>
			
			private com.vip.order.biz.request.GetEbsGoodsListReq getEbsGoodsListReq_;
			
			public com.vip.order.common.pojo.order.request.RequestHeader GetRequestHeader(){
				return this.requestHeader_;
			}
			
			public void SetRequestHeader(com.vip.order.common.pojo.order.request.RequestHeader value){
				this.requestHeader_ = value;
			}
			public com.vip.order.biz.request.GetEbsGoodsListReq GetGetEbsGoodsListReq(){
				return this.getEbsGoodsListReq_;
			}
			
			public void SetGetEbsGoodsListReq(com.vip.order.biz.request.GetEbsGoodsListReq value){
				this.getEbsGoodsListReq_ = value;
			}
			
		}
		
		
		
		
		public class getGoodsDispatchWarehouse_args {
			
			///<summary>
			///</summary>
			
			private com.vip.order.common.pojo.order.request.RequestHeader requestHeader_;
			
			///<summary>
			///</summary>
			
			private com.vip.order.biz.request.GetGoodsDispatchWarehouseReq req_;
			
			public com.vip.order.common.pojo.order.request.RequestHeader GetRequestHeader(){
				return this.requestHeader_;
			}
			
			public void SetRequestHeader(com.vip.order.common.pojo.order.request.RequestHeader value){
				this.requestHeader_ = value;
			}
			public com.vip.order.biz.request.GetGoodsDispatchWarehouseReq GetReq(){
				return this.req_;
			}
			
			public void SetReq(com.vip.order.biz.request.GetGoodsDispatchWarehouseReq value){
				this.req_ = value;
			}
			
		}
		
		
		
		
		public class getLimitedOrderGoodsCount_args {
			
			///<summary>
			///</summary>
			
			private com.vip.order.common.pojo.order.request.RequestHeader requestHeader_;
			
			///<summary>
			///</summary>
			
			private com.vip.order.biz.request.GetLimitedOrderGoodsCountReq getLimitedOrderGoodsCountReq_;
			
			public com.vip.order.common.pojo.order.request.RequestHeader GetRequestHeader(){
				return this.requestHeader_;
			}
			
			public void SetRequestHeader(com.vip.order.common.pojo.order.request.RequestHeader value){
				this.requestHeader_ = value;
			}
			public com.vip.order.biz.request.GetLimitedOrderGoodsCountReq GetGetLimitedOrderGoodsCountReq(){
				return this.getLimitedOrderGoodsCountReq_;
			}
			
			public void SetGetLimitedOrderGoodsCountReq(com.vip.order.biz.request.GetLimitedOrderGoodsCountReq value){
				this.getLimitedOrderGoodsCountReq_ = value;
			}
			
		}
		
		
		
		
		public class getLinkageOrders_args {
			
			///<summary>
			///</summary>
			
			private com.vip.order.common.pojo.order.request.RequestHeader requestHeader_;
			
			///<summary>
			///</summary>
			
			private com.vip.order.biz.request.SearchLinkageOrderReq req_;
			
			public com.vip.order.common.pojo.order.request.RequestHeader GetRequestHeader(){
				return this.requestHeader_;
			}
			
			public void SetRequestHeader(com.vip.order.common.pojo.order.request.RequestHeader value){
				this.requestHeader_ = value;
			}
			public com.vip.order.biz.request.SearchLinkageOrderReq GetReq(){
				return this.req_;
			}
			
			public void SetReq(com.vip.order.biz.request.SearchLinkageOrderReq value){
				this.req_ = value;
			}
			
		}
		
		
		
		
		public class getMergeOrderList_args {
			
			///<summary>
			///</summary>
			
			private com.vip.order.common.pojo.order.request.RequestHeader requestHeader_;
			
			///<summary>
			///</summary>
			
			private com.vip.order.biz.request.GetMergeOrderReq getMergeOrderReq_;
			
			public com.vip.order.common.pojo.order.request.RequestHeader GetRequestHeader(){
				return this.requestHeader_;
			}
			
			public void SetRequestHeader(com.vip.order.common.pojo.order.request.RequestHeader value){
				this.requestHeader_ = value;
			}
			public com.vip.order.biz.request.GetMergeOrderReq GetGetMergeOrderReq(){
				return this.getMergeOrderReq_;
			}
			
			public void SetGetMergeOrderReq(com.vip.order.biz.request.GetMergeOrderReq value){
				this.getMergeOrderReq_ = value;
			}
			
		}
		
		
		
		
		public class getOrderCounts_args {
			
			///<summary>
			///</summary>
			
			private com.vip.order.common.pojo.order.request.RequestHeader requestHeader_;
			
			///<summary>
			///</summary>
			
			private com.vip.order.biz.request.SearchOrderReq searchOrderReq_;
			
			public com.vip.order.common.pojo.order.request.RequestHeader GetRequestHeader(){
				return this.requestHeader_;
			}
			
			public void SetRequestHeader(com.vip.order.common.pojo.order.request.RequestHeader value){
				this.requestHeader_ = value;
			}
			public com.vip.order.biz.request.SearchOrderReq GetSearchOrderReq(){
				return this.searchOrderReq_;
			}
			
			public void SetSearchOrderReq(com.vip.order.biz.request.SearchOrderReq value){
				this.searchOrderReq_ = value;
			}
			
		}
		
		
		
		
		public class getOrderCountsByUserId_args {
			
			///<summary>
			///</summary>
			
			private com.vip.order.common.pojo.order.request.RequestHeader requestHeader_;
			
			///<summary>
			///</summary>
			
			private com.vip.order.biz.request.GetOrderByUserIdReq getOrderByUserIdReq_;
			
			public com.vip.order.common.pojo.order.request.RequestHeader GetRequestHeader(){
				return this.requestHeader_;
			}
			
			public void SetRequestHeader(com.vip.order.common.pojo.order.request.RequestHeader value){
				this.requestHeader_ = value;
			}
			public com.vip.order.biz.request.GetOrderByUserIdReq GetGetOrderByUserIdReq(){
				return this.getOrderByUserIdReq_;
			}
			
			public void SetGetOrderByUserIdReq(com.vip.order.biz.request.GetOrderByUserIdReq value){
				this.getOrderByUserIdReq_ = value;
			}
			
		}
		
		
		
		
		public class getOrderDeliveryBoxNum_args {
			
			///<summary>
			///</summary>
			
			private com.vip.order.common.pojo.order.request.RequestHeader requestHeaderParam_;
			
			///<summary>
			///</summary>
			
			private string orderSn_;
			
			public com.vip.order.common.pojo.order.request.RequestHeader GetRequestHeaderParam(){
				return this.requestHeaderParam_;
			}
			
			public void SetRequestHeaderParam(com.vip.order.common.pojo.order.request.RequestHeader value){
				this.requestHeaderParam_ = value;
			}
			public string GetOrderSn(){
				return this.orderSn_;
			}
			
			public void SetOrderSn(string value){
				this.orderSn_ = value;
			}
			
		}
		
		
		
		
		public class getOrderDetail_args {
			
			///<summary>
			///</summary>
			
			private com.vip.order.common.pojo.order.request.RequestHeader requestHeader_;
			
			///<summary>
			///</summary>
			
			private com.vip.order.biz.request.SearchOrderDetailReq searchOrderDetailReq_;
			
			public com.vip.order.common.pojo.order.request.RequestHeader GetRequestHeader(){
				return this.requestHeader_;
			}
			
			public void SetRequestHeader(com.vip.order.common.pojo.order.request.RequestHeader value){
				this.requestHeader_ = value;
			}
			public com.vip.order.biz.request.SearchOrderDetailReq GetSearchOrderDetailReq(){
				return this.searchOrderDetailReq_;
			}
			
			public void SetSearchOrderDetailReq(com.vip.order.biz.request.SearchOrderDetailReq value){
				this.searchOrderDetailReq_ = value;
			}
			
		}
		
		
		
		
		public class getOrderElectronicInvoicesV2_args {
			
			///<summary>
			///</summary>
			
			private com.vip.order.common.pojo.order.request.RequestHeader requestHeaderParam_;
			
			///<summary>
			///</summary>
			
			private com.vip.order.biz.request.SearchOrderElectronicInvoicesReq searchOrderElectronicInvoiceParam_;
			
			///<summary>
			///</summary>
			
			private com.vip.order.biz.request.ResultRequirement resultRequirement_;
			
			public com.vip.order.common.pojo.order.request.RequestHeader GetRequestHeaderParam(){
				return this.requestHeaderParam_;
			}
			
			public void SetRequestHeaderParam(com.vip.order.common.pojo.order.request.RequestHeader value){
				this.requestHeaderParam_ = value;
			}
			public com.vip.order.biz.request.SearchOrderElectronicInvoicesReq GetSearchOrderElectronicInvoiceParam(){
				return this.searchOrderElectronicInvoiceParam_;
			}
			
			public void SetSearchOrderElectronicInvoiceParam(com.vip.order.biz.request.SearchOrderElectronicInvoicesReq value){
				this.searchOrderElectronicInvoiceParam_ = value;
			}
			public com.vip.order.biz.request.ResultRequirement GetResultRequirement(){
				return this.resultRequirement_;
			}
			
			public void SetResultRequirement(com.vip.order.biz.request.ResultRequirement value){
				this.resultRequirement_ = value;
			}
			
		}
		
		
		
		
		public class getOrderFav_args {
			
			///<summary>
			///</summary>
			
			private com.vip.order.common.pojo.order.request.RequestHeader requestHeader_;
			
			///<summary>
			///</summary>
			
			private List<string> orderSnList_;
			
			public com.vip.order.common.pojo.order.request.RequestHeader GetRequestHeader(){
				return this.requestHeader_;
			}
			
			public void SetRequestHeader(com.vip.order.common.pojo.order.request.RequestHeader value){
				this.requestHeader_ = value;
			}
			public List<string> GetOrderSnList(){
				return this.orderSnList_;
			}
			
			public void SetOrderSnList(List<string> value){
				this.orderSnList_ = value;
			}
			
		}
		
		
		
		
		public class getOrderGoodsCount_args {
			
			///<summary>
			///</summary>
			
			private com.vip.order.common.pojo.order.request.RequestHeader requestHeaderParam_;
			
			///<summary>
			///</summary>
			
			private com.vip.order.biz.request.GetOrderGoodsReq getOrderGoodsParam_;
			
			public com.vip.order.common.pojo.order.request.RequestHeader GetRequestHeaderParam(){
				return this.requestHeaderParam_;
			}
			
			public void SetRequestHeaderParam(com.vip.order.common.pojo.order.request.RequestHeader value){
				this.requestHeaderParam_ = value;
			}
			public com.vip.order.biz.request.GetOrderGoodsReq GetGetOrderGoodsParam(){
				return this.getOrderGoodsParam_;
			}
			
			public void SetGetOrderGoodsParam(com.vip.order.biz.request.GetOrderGoodsReq value){
				this.getOrderGoodsParam_ = value;
			}
			
		}
		
		
		
		
		public class getOrderGoodsList_args {
			
			///<summary>
			///</summary>
			
			private com.vip.order.common.pojo.order.request.RequestHeader requestHeaderParam_;
			
			///<summary>
			///</summary>
			
			private com.vip.order.biz.request.GetOrderGoodsReq getOrderGoodsParam_;
			
			///<summary>
			///</summary>
			
			private com.vip.order.common.pojo.order.request.ResultFilter resultFilter_;
			
			public com.vip.order.common.pojo.order.request.RequestHeader GetRequestHeaderParam(){
				return this.requestHeaderParam_;
			}
			
			public void SetRequestHeaderParam(com.vip.order.common.pojo.order.request.RequestHeader value){
				this.requestHeaderParam_ = value;
			}
			public com.vip.order.biz.request.GetOrderGoodsReq GetGetOrderGoodsParam(){
				return this.getOrderGoodsParam_;
			}
			
			public void SetGetOrderGoodsParam(com.vip.order.biz.request.GetOrderGoodsReq value){
				this.getOrderGoodsParam_ = value;
			}
			public com.vip.order.common.pojo.order.request.ResultFilter GetResultFilter(){
				return this.resultFilter_;
			}
			
			public void SetResultFilter(com.vip.order.common.pojo.order.request.ResultFilter value){
				this.resultFilter_ = value;
			}
			
		}
		
		
		
		
		public class getOrderInstalmentsList_args {
			
			///<summary>
			///</summary>
			
			private com.vip.order.common.pojo.order.request.RequestHeader requestHeader_;
			
			///<summary>
			///</summary>
			
			private com.vip.order.biz.request.GetOrderInstalmentsReq req_;
			
			///<summary>
			///</summary>
			
			private com.vip.order.common.pojo.order.request.ResultFilter filter_;
			
			public com.vip.order.common.pojo.order.request.RequestHeader GetRequestHeader(){
				return this.requestHeader_;
			}
			
			public void SetRequestHeader(com.vip.order.common.pojo.order.request.RequestHeader value){
				this.requestHeader_ = value;
			}
			public com.vip.order.biz.request.GetOrderInstalmentsReq GetReq(){
				return this.req_;
			}
			
			public void SetReq(com.vip.order.biz.request.GetOrderInstalmentsReq value){
				this.req_ = value;
			}
			public com.vip.order.common.pojo.order.request.ResultFilter GetFilter(){
				return this.filter_;
			}
			
			public void SetFilter(com.vip.order.common.pojo.order.request.ResultFilter value){
				this.filter_ = value;
			}
			
		}
		
		
		
		
		public class getOrderInvoicesV2_args {
			
			///<summary>
			///</summary>
			
			private com.vip.order.common.pojo.order.request.RequestHeader requestHeaderParam_;
			
			///<summary>
			///</summary>
			
			private com.vip.order.biz.request.SearchOrderInvoicesReq searchOrderInvoiceParam_;
			
			public com.vip.order.common.pojo.order.request.RequestHeader GetRequestHeaderParam(){
				return this.requestHeaderParam_;
			}
			
			public void SetRequestHeaderParam(com.vip.order.common.pojo.order.request.RequestHeader value){
				this.requestHeaderParam_ = value;
			}
			public com.vip.order.biz.request.SearchOrderInvoicesReq GetSearchOrderInvoiceParam(){
				return this.searchOrderInvoiceParam_;
			}
			
			public void SetSearchOrderInvoiceParam(com.vip.order.biz.request.SearchOrderInvoicesReq value){
				this.searchOrderInvoiceParam_ = value;
			}
			
		}
		
		
		
		
		public class getOrderList_args {
			
			///<summary>
			///</summary>
			
			private com.vip.order.common.pojo.order.request.RequestHeader requestHeader_;
			
			///<summary>
			///</summary>
			
			private com.vip.order.biz.request.SearchOrderReq searchOrderReq_;
			
			///<summary>
			///</summary>
			
			private com.vip.order.common.pojo.order.request.ResultFilter resultFilter_;
			
			public com.vip.order.common.pojo.order.request.RequestHeader GetRequestHeader(){
				return this.requestHeader_;
			}
			
			public void SetRequestHeader(com.vip.order.common.pojo.order.request.RequestHeader value){
				this.requestHeader_ = value;
			}
			public com.vip.order.biz.request.SearchOrderReq GetSearchOrderReq(){
				return this.searchOrderReq_;
			}
			
			public void SetSearchOrderReq(com.vip.order.biz.request.SearchOrderReq value){
				this.searchOrderReq_ = value;
			}
			public com.vip.order.common.pojo.order.request.ResultFilter GetResultFilter(){
				return this.resultFilter_;
			}
			
			public void SetResultFilter(com.vip.order.common.pojo.order.request.ResultFilter value){
				this.resultFilter_ = value;
			}
			
		}
		
		
		
		
		public class getOrderListByPosNo_args {
			
			///<summary>
			///</summary>
			
			private com.vip.order.common.pojo.order.request.RequestHeader requestHeader_;
			
			///<summary>
			///</summary>
			
			private com.vip.order.biz.request.GetOrderListByPosNoReq req_;
			
			public com.vip.order.common.pojo.order.request.RequestHeader GetRequestHeader(){
				return this.requestHeader_;
			}
			
			public void SetRequestHeader(com.vip.order.common.pojo.order.request.RequestHeader value){
				this.requestHeader_ = value;
			}
			public com.vip.order.biz.request.GetOrderListByPosNoReq GetReq(){
				return this.req_;
			}
			
			public void SetReq(com.vip.order.biz.request.GetOrderListByPosNoReq value){
				this.req_ = value;
			}
			
		}
		
		
		
		
		public class getOrderListByUserId_args {
			
			///<summary>
			///</summary>
			
			private com.vip.order.common.pojo.order.request.RequestHeader requestHeader_;
			
			///<summary>
			///</summary>
			
			private com.vip.order.biz.request.GetOrderByUserIdReq getOrderByUserIdReq_;
			
			///<summary>
			///</summary>
			
			private com.vip.order.common.pojo.order.request.ResultFilter resultFilter_;
			
			public com.vip.order.common.pojo.order.request.RequestHeader GetRequestHeader(){
				return this.requestHeader_;
			}
			
			public void SetRequestHeader(com.vip.order.common.pojo.order.request.RequestHeader value){
				this.requestHeader_ = value;
			}
			public com.vip.order.biz.request.GetOrderByUserIdReq GetGetOrderByUserIdReq(){
				return this.getOrderByUserIdReq_;
			}
			
			public void SetGetOrderByUserIdReq(com.vip.order.biz.request.GetOrderByUserIdReq value){
				this.getOrderByUserIdReq_ = value;
			}
			public com.vip.order.common.pojo.order.request.ResultFilter GetResultFilter(){
				return this.resultFilter_;
			}
			
			public void SetResultFilter(com.vip.order.common.pojo.order.request.ResultFilter value){
				this.resultFilter_ = value;
			}
			
		}
		
		
		
		
		public class getOrderLogs_args {
			
			///<summary>
			///</summary>
			
			private com.vip.order.common.pojo.order.request.RequestHeader requestHeaderParam_;
			
			///<summary>
			///</summary>
			
			private com.vip.order.biz.request.SearchOrderLogsReq searchOrderLogsParam_;
			
			///<summary>
			///</summary>
			
			private com.vip.order.biz.request.requirement.GetOrderLogsRequirement getOrderLogsRequirement_;
			
			public com.vip.order.common.pojo.order.request.RequestHeader GetRequestHeaderParam(){
				return this.requestHeaderParam_;
			}
			
			public void SetRequestHeaderParam(com.vip.order.common.pojo.order.request.RequestHeader value){
				this.requestHeaderParam_ = value;
			}
			public com.vip.order.biz.request.SearchOrderLogsReq GetSearchOrderLogsParam(){
				return this.searchOrderLogsParam_;
			}
			
			public void SetSearchOrderLogsParam(com.vip.order.biz.request.SearchOrderLogsReq value){
				this.searchOrderLogsParam_ = value;
			}
			public com.vip.order.biz.request.requirement.GetOrderLogsRequirement GetGetOrderLogsRequirement(){
				return this.getOrderLogsRequirement_;
			}
			
			public void SetGetOrderLogsRequirement(com.vip.order.biz.request.requirement.GetOrderLogsRequirement value){
				this.getOrderLogsRequirement_ = value;
			}
			
		}
		
		
		
		
		public class getOrderOpStatus_args {
			
			///<summary>
			///</summary>
			
			private com.vip.order.common.pojo.order.request.RequestHeader requestHeader_;
			
			///<summary>
			///</summary>
			
			private com.vip.order.biz.request.GetOrderOpStatusReq getOrderOpStatusReq_;
			
			public com.vip.order.common.pojo.order.request.RequestHeader GetRequestHeader(){
				return this.requestHeader_;
			}
			
			public void SetRequestHeader(com.vip.order.common.pojo.order.request.RequestHeader value){
				this.requestHeader_ = value;
			}
			public com.vip.order.biz.request.GetOrderOpStatusReq GetGetOrderOpStatusReq(){
				return this.getOrderOpStatusReq_;
			}
			
			public void SetGetOrderOpStatusReq(com.vip.order.biz.request.GetOrderOpStatusReq value){
				this.getOrderOpStatusReq_ = value;
			}
			
		}
		
		
		
		
		public class getOrderPackageList_args {
			
			///<summary>
			///</summary>
			
			private com.vip.order.common.pojo.order.request.RequestHeader requestHeader_;
			
			///<summary>
			///</summary>
			
			private com.vip.order.biz.request.GetOrderPackageListReq getPackageListReq_;
			
			public com.vip.order.common.pojo.order.request.RequestHeader GetRequestHeader(){
				return this.requestHeader_;
			}
			
			public void SetRequestHeader(com.vip.order.common.pojo.order.request.RequestHeader value){
				this.requestHeader_ = value;
			}
			public com.vip.order.biz.request.GetOrderPackageListReq GetGetPackageListReq(){
				return this.getPackageListReq_;
			}
			
			public void SetGetPackageListReq(com.vip.order.biz.request.GetOrderPackageListReq value){
				this.getPackageListReq_ = value;
			}
			
		}
		
		
		
		
		public class getOrderPayType_args {
			
			///<summary>
			///</summary>
			
			private com.vip.order.common.pojo.order.request.RequestHeader requestHeader_;
			
			///<summary>
			///</summary>
			
			private com.vip.order.biz.request.GetOrderPayTypeReq getOrderPayTypeParam_;
			
			///<summary>
			///</summary>
			
			private com.vip.order.common.pojo.order.request.ResultFilter resultFilter_;
			
			public com.vip.order.common.pojo.order.request.RequestHeader GetRequestHeader(){
				return this.requestHeader_;
			}
			
			public void SetRequestHeader(com.vip.order.common.pojo.order.request.RequestHeader value){
				this.requestHeader_ = value;
			}
			public com.vip.order.biz.request.GetOrderPayTypeReq GetGetOrderPayTypeParam(){
				return this.getOrderPayTypeParam_;
			}
			
			public void SetGetOrderPayTypeParam(com.vip.order.biz.request.GetOrderPayTypeReq value){
				this.getOrderPayTypeParam_ = value;
			}
			public com.vip.order.common.pojo.order.request.ResultFilter GetResultFilter(){
				return this.resultFilter_;
			}
			
			public void SetResultFilter(com.vip.order.common.pojo.order.request.ResultFilter value){
				this.resultFilter_ = value;
			}
			
		}
		
		
		
		
		public class getOrderSnByExOrderSn_args {
			
			///<summary>
			///</summary>
			
			private com.vip.order.common.pojo.order.request.RequestHeader requestHeader_;
			
			///<summary>
			/// 第三方订单号列表
			///</summary>
			
			private List<string> exOrderSns_;
			
			public com.vip.order.common.pojo.order.request.RequestHeader GetRequestHeader(){
				return this.requestHeader_;
			}
			
			public void SetRequestHeader(com.vip.order.common.pojo.order.request.RequestHeader value){
				this.requestHeader_ = value;
			}
			public List<string> GetExOrderSns(){
				return this.exOrderSns_;
			}
			
			public void SetExOrderSns(List<string> value){
				this.exOrderSns_ = value;
			}
			
		}
		
		
		
		
		public class getOrderTransport_args {
			
			///<summary>
			///</summary>
			
			private com.vip.order.common.pojo.order.request.RequestHeader requestHeader_;
			
			///<summary>
			///</summary>
			
			private com.vip.order.biz.request.GetOrderTransportReq getOrderTransportReq_;
			
			public com.vip.order.common.pojo.order.request.RequestHeader GetRequestHeader(){
				return this.requestHeader_;
			}
			
			public void SetRequestHeader(com.vip.order.common.pojo.order.request.RequestHeader value){
				this.requestHeader_ = value;
			}
			public com.vip.order.biz.request.GetOrderTransportReq GetGetOrderTransportReq(){
				return this.getOrderTransportReq_;
			}
			
			public void SetGetOrderTransportReq(com.vip.order.biz.request.GetOrderTransportReq value){
				this.getOrderTransportReq_ = value;
			}
			
		}
		
		
		
		
		public class getOrderTransportDetail_args {
			
			///<summary>
			///</summary>
			
			private com.vip.order.common.pojo.order.request.RequestHeader requestHeader_;
			
			///<summary>
			///</summary>
			
			private com.vip.order.biz.request.GetOrderTransportDetailReq getOrderTransportDetailReq_;
			
			public com.vip.order.common.pojo.order.request.RequestHeader GetRequestHeader(){
				return this.requestHeader_;
			}
			
			public void SetRequestHeader(com.vip.order.common.pojo.order.request.RequestHeader value){
				this.requestHeader_ = value;
			}
			public com.vip.order.biz.request.GetOrderTransportDetailReq GetGetOrderTransportDetailReq(){
				return this.getOrderTransportDetailReq_;
			}
			
			public void SetGetOrderTransportDetailReq(com.vip.order.biz.request.GetOrderTransportDetailReq value){
				this.getOrderTransportDetailReq_ = value;
			}
			
		}
		
		
		
		
		public class getOrderTransportListByCodes_args {
			
			///<summary>
			///</summary>
			
			private com.vip.order.common.pojo.order.request.RequestHeader requestHeaderParam_;
			
			///<summary>
			///</summary>
			
			private com.vip.order.biz.request.GetTransportListByCodesReq getTransportListByCodesParam_;
			
			public com.vip.order.common.pojo.order.request.RequestHeader GetRequestHeaderParam(){
				return this.requestHeaderParam_;
			}
			
			public void SetRequestHeaderParam(com.vip.order.common.pojo.order.request.RequestHeader value){
				this.requestHeaderParam_ = value;
			}
			public com.vip.order.biz.request.GetTransportListByCodesReq GetGetTransportListByCodesParam(){
				return this.getTransportListByCodesParam_;
			}
			
			public void SetGetTransportListByCodesParam(com.vip.order.biz.request.GetTransportListByCodesReq value){
				this.getTransportListByCodesParam_ = value;
			}
			
		}
		
		
		
		
		public class getOrdersBySizeId_args {
			
			///<summary>
			///</summary>
			
			private com.vip.order.common.pojo.order.request.RequestHeader requestHeader_;
			
			///<summary>
			///</summary>
			
			private com.vip.order.biz.request.GetOrdersBySizeIdReq req_;
			
			///<summary>
			///</summary>
			
			private com.vip.order.common.pojo.order.request.ResultFilter filter_;
			
			public com.vip.order.common.pojo.order.request.RequestHeader GetRequestHeader(){
				return this.requestHeader_;
			}
			
			public void SetRequestHeader(com.vip.order.common.pojo.order.request.RequestHeader value){
				this.requestHeader_ = value;
			}
			public com.vip.order.biz.request.GetOrdersBySizeIdReq GetReq(){
				return this.req_;
			}
			
			public void SetReq(com.vip.order.biz.request.GetOrdersBySizeIdReq value){
				this.req_ = value;
			}
			public com.vip.order.common.pojo.order.request.ResultFilter GetFilter(){
				return this.filter_;
			}
			
			public void SetFilter(com.vip.order.common.pojo.order.request.ResultFilter value){
				this.filter_ = value;
			}
			
		}
		
		
		
		
		public class getPrepayOrderStatus_args {
			
			///<summary>
			///</summary>
			
			private com.vip.order.common.pojo.order.request.RequestHeader requestHeader_;
			
			///<summary>
			///</summary>
			
			private com.vip.order.biz.request.GetPrepayOrderStatusReq req_;
			
			public com.vip.order.common.pojo.order.request.RequestHeader GetRequestHeader(){
				return this.requestHeader_;
			}
			
			public void SetRequestHeader(com.vip.order.common.pojo.order.request.RequestHeader value){
				this.requestHeader_ = value;
			}
			public com.vip.order.biz.request.GetPrepayOrderStatusReq GetReq(){
				return this.req_;
			}
			
			public void SetReq(com.vip.order.biz.request.GetPrepayOrderStatusReq value){
				this.req_ = value;
			}
			
		}
		
		
		
		
		public class getPrepayOrderUnpayMsg_args {
			
			///<summary>
			///</summary>
			
			private com.vip.order.common.pojo.order.request.RequestHeader header_;
			
			///<summary>
			///</summary>
			
			private com.vip.order.biz.request.GetPrepayOrderUnpayMsgReq req_;
			
			public com.vip.order.common.pojo.order.request.RequestHeader GetHeader(){
				return this.header_;
			}
			
			public void SetHeader(com.vip.order.common.pojo.order.request.RequestHeader value){
				this.header_ = value;
			}
			public com.vip.order.biz.request.GetPrepayOrderUnpayMsgReq GetReq(){
				return this.req_;
			}
			
			public void SetReq(com.vip.order.biz.request.GetPrepayOrderUnpayMsgReq value){
				this.req_ = value;
			}
			
		}
		
		
		
		
		public class getRdc_args {
			
			///<summary>
			///</summary>
			
			private com.vip.order.common.pojo.order.request.RequestHeader requestHeader_;
			
			///<summary>
			///</summary>
			
			private com.vip.order.biz.request.GetRdcReq getRdcReq_;
			
			public com.vip.order.common.pojo.order.request.RequestHeader GetRequestHeader(){
				return this.requestHeader_;
			}
			
			public void SetRequestHeader(com.vip.order.common.pojo.order.request.RequestHeader value){
				this.requestHeader_ = value;
			}
			public com.vip.order.biz.request.GetRdcReq GetGetRdcReq(){
				return this.getRdcReq_;
			}
			
			public void SetGetRdcReq(com.vip.order.biz.request.GetRdcReq value){
				this.getRdcReq_ = value;
			}
			
		}
		
		
		
		
		public class getRdcInvoice_args {
			
			///<summary>
			///</summary>
			
			private com.vip.order.common.pojo.order.request.RequestHeader requestHeader_;
			
			///<summary>
			///</summary>
			
			private com.vip.order.biz.request.GetRdcInvoiceReq req_;
			
			public com.vip.order.common.pojo.order.request.RequestHeader GetRequestHeader(){
				return this.requestHeader_;
			}
			
			public void SetRequestHeader(com.vip.order.common.pojo.order.request.RequestHeader value){
				this.requestHeader_ = value;
			}
			public com.vip.order.biz.request.GetRdcInvoiceReq GetReq(){
				return this.req_;
			}
			
			public void SetReq(com.vip.order.biz.request.GetRdcInvoiceReq value){
				this.req_ = value;
			}
			
		}
		
		
		
		
		public class getReturnOrExchangeGoods_args {
			
			///<summary>
			///</summary>
			
			private com.vip.order.common.pojo.order.request.RequestHeader requestHeader_;
			
			///<summary>
			///</summary>
			
			private com.vip.order.biz.request.GetReturnOrExchangeGoodsReq req_;
			
			public com.vip.order.common.pojo.order.request.RequestHeader GetRequestHeader(){
				return this.requestHeader_;
			}
			
			public void SetRequestHeader(com.vip.order.common.pojo.order.request.RequestHeader value){
				this.requestHeader_ = value;
			}
			public com.vip.order.biz.request.GetReturnOrExchangeGoodsReq GetReq(){
				return this.req_;
			}
			
			public void SetReq(com.vip.order.biz.request.GetReturnOrExchangeGoodsReq value){
				this.req_ = value;
			}
			
		}
		
		
		
		
		public class getSimpleOrderFlowFlag_args {
			
			///<summary>
			///</summary>
			
			private com.vip.order.common.pojo.order.request.RequestHeader requestHeaderParam_;
			
			///<summary>
			///</summary>
			
			private com.vip.order.biz.request.GetSimpleOrderFlowFlagReq getSimpleOrderFlowFlagParam_;
			
			public com.vip.order.common.pojo.order.request.RequestHeader GetRequestHeaderParam(){
				return this.requestHeaderParam_;
			}
			
			public void SetRequestHeaderParam(com.vip.order.common.pojo.order.request.RequestHeader value){
				this.requestHeaderParam_ = value;
			}
			public com.vip.order.biz.request.GetSimpleOrderFlowFlagReq GetGetSimpleOrderFlowFlagParam(){
				return this.getSimpleOrderFlowFlagParam_;
			}
			
			public void SetGetSimpleOrderFlowFlagParam(com.vip.order.biz.request.GetSimpleOrderFlowFlagReq value){
				this.getSimpleOrderFlowFlagParam_ = value;
			}
			
		}
		
		
		
		
		public class getUnpayOrderList_args {
			
			///<summary>
			///</summary>
			
			private com.vip.order.common.pojo.order.request.RequestHeader requestHeaderParam_;
			
			///<summary>
			///</summary>
			
			private com.vip.order.biz.request.GetUnpayOrderReq getUnpayOrderParam_;
			
			public com.vip.order.common.pojo.order.request.RequestHeader GetRequestHeaderParam(){
				return this.requestHeaderParam_;
			}
			
			public void SetRequestHeaderParam(com.vip.order.common.pojo.order.request.RequestHeader value){
				this.requestHeaderParam_ = value;
			}
			public com.vip.order.biz.request.GetUnpayOrderReq GetGetUnpayOrderParam(){
				return this.getUnpayOrderParam_;
			}
			
			public void SetGetUnpayOrderParam(com.vip.order.biz.request.GetUnpayOrderReq value){
				this.getUnpayOrderParam_ = value;
			}
			
		}
		
		
		
		
		public class getUserDeliveryAddress_args {
			
			///<summary>
			///</summary>
			
			private com.vip.order.common.pojo.order.request.RequestHeader requestHeader_;
			
			///<summary>
			///</summary>
			
			private com.vip.order.biz.request.GetUserDeliveryAddressReq getUserDeliveryAddressReq_;
			
			///<summary>
			///</summary>
			
			private com.vip.order.common.pojo.order.request.ResultFilter resultFilter_;
			
			public com.vip.order.common.pojo.order.request.RequestHeader GetRequestHeader(){
				return this.requestHeader_;
			}
			
			public void SetRequestHeader(com.vip.order.common.pojo.order.request.RequestHeader value){
				this.requestHeader_ = value;
			}
			public com.vip.order.biz.request.GetUserDeliveryAddressReq GetGetUserDeliveryAddressReq(){
				return this.getUserDeliveryAddressReq_;
			}
			
			public void SetGetUserDeliveryAddressReq(com.vip.order.biz.request.GetUserDeliveryAddressReq value){
				this.getUserDeliveryAddressReq_ = value;
			}
			public com.vip.order.common.pojo.order.request.ResultFilter GetResultFilter(){
				return this.resultFilter_;
			}
			
			public void SetResultFilter(com.vip.order.common.pojo.order.request.ResultFilter value){
				this.resultFilter_ = value;
			}
			
		}
		
		
		
		
		public class getUserFirstOrder_args {
			
			///<summary>
			///</summary>
			
			private com.vip.order.common.pojo.order.request.RequestHeader requestHeader_;
			
			///<summary>
			///</summary>
			
			private com.vip.order.biz.request.GetUserFirstOrderReq getUserFirstOrderReq_;
			
			public com.vip.order.common.pojo.order.request.RequestHeader GetRequestHeader(){
				return this.requestHeader_;
			}
			
			public void SetRequestHeader(com.vip.order.common.pojo.order.request.RequestHeader value){
				this.requestHeader_ = value;
			}
			public com.vip.order.biz.request.GetUserFirstOrderReq GetGetUserFirstOrderReq(){
				return this.getUserFirstOrderReq_;
			}
			
			public void SetGetUserFirstOrderReq(com.vip.order.biz.request.GetUserFirstOrderReq value){
				this.getUserFirstOrderReq_ = value;
			}
			
		}
		
		
		
		
		public class healthCheck_args {
			
			
		}
		
		
		
		
		public class mergeOrder_args {
			
			///<summary>
			///</summary>
			
			private com.vip.order.common.pojo.order.request.RequestHeader requestHeader_;
			
			///<summary>
			///</summary>
			
			private com.vip.order.biz.request.MergeOrderReq reqParam_;
			
			public com.vip.order.common.pojo.order.request.RequestHeader GetRequestHeader(){
				return this.requestHeader_;
			}
			
			public void SetRequestHeader(com.vip.order.common.pojo.order.request.RequestHeader value){
				this.requestHeader_ = value;
			}
			public com.vip.order.biz.request.MergeOrderReq GetReqParam(){
				return this.reqParam_;
			}
			
			public void SetReqParam(com.vip.order.biz.request.MergeOrderReq value){
				this.reqParam_ = value;
			}
			
		}
		
		
		
		
		public class modifyOrderConsignee_args {
			
			///<summary>
			///</summary>
			
			private com.vip.order.common.pojo.order.request.RequestHeader requestHeader_;
			
			///<summary>
			///</summary>
			
			private com.vip.order.biz.request.ModifyOrderConsigneeReq modifyOrderConsigneeReq_;
			
			public com.vip.order.common.pojo.order.request.RequestHeader GetRequestHeader(){
				return this.requestHeader_;
			}
			
			public void SetRequestHeader(com.vip.order.common.pojo.order.request.RequestHeader value){
				this.requestHeader_ = value;
			}
			public com.vip.order.biz.request.ModifyOrderConsigneeReq GetModifyOrderConsigneeReq(){
				return this.modifyOrderConsigneeReq_;
			}
			
			public void SetModifyOrderConsigneeReq(com.vip.order.biz.request.ModifyOrderConsigneeReq value){
				this.modifyOrderConsigneeReq_ = value;
			}
			
		}
		
		
		
		
		public class modifyOrderElectronicInvoice_args {
			
			///<summary>
			///</summary>
			
			private com.vip.order.common.pojo.order.request.RequestHeader requestHeader_;
			
			///<summary>
			///</summary>
			
			private com.vip.order.biz.request.ModifyOrderElectronicInvoiceReq modifyOrderElectronicInvoiceReq_;
			
			public com.vip.order.common.pojo.order.request.RequestHeader GetRequestHeader(){
				return this.requestHeader_;
			}
			
			public void SetRequestHeader(com.vip.order.common.pojo.order.request.RequestHeader value){
				this.requestHeader_ = value;
			}
			public com.vip.order.biz.request.ModifyOrderElectronicInvoiceReq GetModifyOrderElectronicInvoiceReq(){
				return this.modifyOrderElectronicInvoiceReq_;
			}
			
			public void SetModifyOrderElectronicInvoiceReq(com.vip.order.biz.request.ModifyOrderElectronicInvoiceReq value){
				this.modifyOrderElectronicInvoiceReq_ = value;
			}
			
		}
		
		
		
		
		public class modifyOrderGoods_args {
			
			///<summary>
			///</summary>
			
			private com.vip.order.common.pojo.order.request.RequestHeader requestHeader_;
			
			///<summary>
			///</summary>
			
			private com.vip.order.biz.request.ModifyOrderGoodsReq orderGoodsReq_;
			
			public com.vip.order.common.pojo.order.request.RequestHeader GetRequestHeader(){
				return this.requestHeader_;
			}
			
			public void SetRequestHeader(com.vip.order.common.pojo.order.request.RequestHeader value){
				this.requestHeader_ = value;
			}
			public com.vip.order.biz.request.ModifyOrderGoodsReq GetOrderGoodsReq(){
				return this.orderGoodsReq_;
			}
			
			public void SetOrderGoodsReq(com.vip.order.biz.request.ModifyOrderGoodsReq value){
				this.orderGoodsReq_ = value;
			}
			
		}
		
		
		
		
		public class modifyOrderPayType_args {
			
			///<summary>
			///</summary>
			
			private com.vip.order.common.pojo.order.request.RequestHeader requestHeader_;
			
			///<summary>
			///</summary>
			
			private com.vip.order.common.pojo.order.vo.ModifyPayTypeReq ModifyPayTypeReq_;
			
			public com.vip.order.common.pojo.order.request.RequestHeader GetRequestHeader(){
				return this.requestHeader_;
			}
			
			public void SetRequestHeader(com.vip.order.common.pojo.order.request.RequestHeader value){
				this.requestHeader_ = value;
			}
			public com.vip.order.common.pojo.order.vo.ModifyPayTypeReq GetModifyPayTypeReq(){
				return this.ModifyPayTypeReq_;
			}
			
			public void SetModifyPayTypeReq(com.vip.order.common.pojo.order.vo.ModifyPayTypeReq value){
				this.ModifyPayTypeReq_ = value;
			}
			
		}
		
		
		
		
		public class modifyOrderQualified_args {
			
			///<summary>
			///</summary>
			
			private com.vip.order.common.pojo.order.request.RequestHeader requestHeader_;
			
			///<summary>
			///</summary>
			
			private com.vip.order.biz.param.ModifyOrderQualifiedReq req_;
			
			public com.vip.order.common.pojo.order.request.RequestHeader GetRequestHeader(){
				return this.requestHeader_;
			}
			
			public void SetRequestHeader(com.vip.order.common.pojo.order.request.RequestHeader value){
				this.requestHeader_ = value;
			}
			public com.vip.order.biz.param.ModifyOrderQualifiedReq GetReq(){
				return this.req_;
			}
			
			public void SetReq(com.vip.order.biz.param.ModifyOrderQualifiedReq value){
				this.req_ = value;
			}
			
		}
		
		
		
		
		public class modifyOrderShipped_args {
			
			///<summary>
			///</summary>
			
			private com.vip.order.common.pojo.order.request.RequestHeader requestHeader_;
			
			///<summary>
			///</summary>
			
			private com.vip.order.biz.request.ModifyOrderShippedReq modifyOrderShippedReq_;
			
			public com.vip.order.common.pojo.order.request.RequestHeader GetRequestHeader(){
				return this.requestHeader_;
			}
			
			public void SetRequestHeader(com.vip.order.common.pojo.order.request.RequestHeader value){
				this.requestHeader_ = value;
			}
			public com.vip.order.biz.request.ModifyOrderShippedReq GetModifyOrderShippedReq(){
				return this.modifyOrderShippedReq_;
			}
			
			public void SetModifyOrderShippedReq(com.vip.order.biz.request.ModifyOrderShippedReq value){
				this.modifyOrderShippedReq_ = value;
			}
			
		}
		
		
		
		
		public class modifyPrepayOrderPayType_args {
			
			///<summary>
			///</summary>
			
			private com.vip.order.common.pojo.order.request.RequestHeader requestHeader_;
			
			///<summary>
			///</summary>
			
			private com.vip.order.biz.request.ModifyPrepayOrderPayTypeReq modifyPrepayOrderPayTypeReq_;
			
			public com.vip.order.common.pojo.order.request.RequestHeader GetRequestHeader(){
				return this.requestHeader_;
			}
			
			public void SetRequestHeader(com.vip.order.common.pojo.order.request.RequestHeader value){
				this.requestHeader_ = value;
			}
			public com.vip.order.biz.request.ModifyPrepayOrderPayTypeReq GetModifyPrepayOrderPayTypeReq(){
				return this.modifyPrepayOrderPayTypeReq_;
			}
			
			public void SetModifyPrepayOrderPayTypeReq(com.vip.order.biz.request.ModifyPrepayOrderPayTypeReq value){
				this.modifyPrepayOrderPayTypeReq_ = value;
			}
			
		}
		
		
		
		
		public class notifyCustomsDeclarationFailed_args {
			
			///<summary>
			///</summary>
			
			private com.vip.order.common.pojo.order.request.RequestHeader requestHeader_;
			
			///<summary>
			///</summary>
			
			private com.vip.order.biz.request.NotifyCustomsDeclarationFailedReq req_;
			
			public com.vip.order.common.pojo.order.request.RequestHeader GetRequestHeader(){
				return this.requestHeader_;
			}
			
			public void SetRequestHeader(com.vip.order.common.pojo.order.request.RequestHeader value){
				this.requestHeader_ = value;
			}
			public com.vip.order.biz.request.NotifyCustomsDeclarationFailedReq GetReq(){
				return this.req_;
			}
			
			public void SetReq(com.vip.order.biz.request.NotifyCustomsDeclarationFailedReq value){
				this.req_ = value;
			}
			
		}
		
		
		
		
		public class ofcEntranceGrayControl_args {
			
			///<summary>
			///</summary>
			
			private com.vip.order.common.pojo.order.request.RequestHeader requestHeader_;
			
			///<summary>
			///</summary>
			
			private com.vip.order.biz.request.OfcEntranceGrayControlReq req_;
			
			public com.vip.order.common.pojo.order.request.RequestHeader GetRequestHeader(){
				return this.requestHeader_;
			}
			
			public void SetRequestHeader(com.vip.order.common.pojo.order.request.RequestHeader value){
				this.requestHeader_ = value;
			}
			public com.vip.order.biz.request.OfcEntranceGrayControlReq GetReq(){
				return this.req_;
			}
			
			public void SetReq(com.vip.order.biz.request.OfcEntranceGrayControlReq value){
				this.req_ = value;
			}
			
		}
		
		
		
		
		public class paymentReceived_args {
			
			///<summary>
			///</summary>
			
			private com.vip.order.common.pojo.order.request.RequestHeader requestHeader_;
			
			///<summary>
			///</summary>
			
			private com.vip.order.biz.request.PaymentReceivedReq req_;
			
			public com.vip.order.common.pojo.order.request.RequestHeader GetRequestHeader(){
				return this.requestHeader_;
			}
			
			public void SetRequestHeader(com.vip.order.common.pojo.order.request.RequestHeader value){
				this.requestHeader_ = value;
			}
			public com.vip.order.biz.request.PaymentReceivedReq GetReq(){
				return this.req_;
			}
			
			public void SetReq(com.vip.order.biz.request.PaymentReceivedReq value){
				this.req_ = value;
			}
			
		}
		
		
		
		
		public class postOrderVMSMessage_args {
			
			///<summary>
			///</summary>
			
			private com.vip.order.common.pojo.order.request.RequestHeader requestHeader_;
			
			///<summary>
			///</summary>
			
			private com.vip.order.biz.request.PostOrderVMSMessageReq postOrderVMSMessageReq_;
			
			public com.vip.order.common.pojo.order.request.RequestHeader GetRequestHeader(){
				return this.requestHeader_;
			}
			
			public void SetRequestHeader(com.vip.order.common.pojo.order.request.RequestHeader value){
				this.requestHeader_ = value;
			}
			public com.vip.order.biz.request.PostOrderVMSMessageReq GetPostOrderVMSMessageReq(){
				return this.postOrderVMSMessageReq_;
			}
			
			public void SetPostOrderVMSMessageReq(com.vip.order.biz.request.PostOrderVMSMessageReq value){
				this.postOrderVMSMessageReq_ = value;
			}
			
		}
		
		
		
		
		public class putIntoSplitQueue_args {
			
			///<summary>
			///</summary>
			
			private com.vip.order.common.pojo.order.request.RequestHeader requestHeader_;
			
			///<summary>
			///</summary>
			
			private com.vip.order.biz.request.PutIntoSplitQueueReq putIntoSplitQueueReq_;
			
			public com.vip.order.common.pojo.order.request.RequestHeader GetRequestHeader(){
				return this.requestHeader_;
			}
			
			public void SetRequestHeader(com.vip.order.common.pojo.order.request.RequestHeader value){
				this.requestHeader_ = value;
			}
			public com.vip.order.biz.request.PutIntoSplitQueueReq GetPutIntoSplitQueueReq(){
				return this.putIntoSplitQueueReq_;
			}
			
			public void SetPutIntoSplitQueueReq(com.vip.order.biz.request.PutIntoSplitQueueReq value){
				this.putIntoSplitQueueReq_ = value;
			}
			
		}
		
		
		
		
		public class putKeyToRollbackQueue_args {
			
			///<summary>
			///</summary>
			
			private com.vip.order.common.pojo.order.request.RequestHeader requestHeader_;
			
			///<summary>
			///</summary>
			
			private com.vip.order.biz.request.PutKeyToRollbackQueueReq req_;
			
			public com.vip.order.common.pojo.order.request.RequestHeader GetRequestHeader(){
				return this.requestHeader_;
			}
			
			public void SetRequestHeader(com.vip.order.common.pojo.order.request.RequestHeader value){
				this.requestHeader_ = value;
			}
			public com.vip.order.biz.request.PutKeyToRollbackQueueReq GetReq(){
				return this.req_;
			}
			
			public void SetReq(com.vip.order.biz.request.PutKeyToRollbackQueueReq value){
				this.req_ = value;
			}
			
		}
		
		
		
		
		public class putOrderToRollbackQueue_args {
			
			///<summary>
			///</summary>
			
			private com.vip.order.common.pojo.order.request.RequestHeader requestHeader_;
			
			///<summary>
			///</summary>
			
			private com.vip.order.biz.request.PutOrderToRollbackQueueReq req_;
			
			public com.vip.order.common.pojo.order.request.RequestHeader GetRequestHeader(){
				return this.requestHeader_;
			}
			
			public void SetRequestHeader(com.vip.order.common.pojo.order.request.RequestHeader value){
				this.requestHeader_ = value;
			}
			public com.vip.order.biz.request.PutOrderToRollbackQueueReq GetReq(){
				return this.req_;
			}
			
			public void SetReq(com.vip.order.biz.request.PutOrderToRollbackQueueReq value){
				this.req_ = value;
			}
			
		}
		
		
		
		
		public class receptionConfirmDelivered_args {
			
			///<summary>
			///</summary>
			
			private com.vip.order.common.pojo.order.request.RequestHeader requestHeader_;
			
			///<summary>
			///</summary>
			
			private com.vip.order.biz.request.ReceptionConfirmDeliveredReq req_;
			
			public com.vip.order.common.pojo.order.request.RequestHeader GetRequestHeader(){
				return this.requestHeader_;
			}
			
			public void SetRequestHeader(com.vip.order.common.pojo.order.request.RequestHeader value){
				this.requestHeader_ = value;
			}
			public com.vip.order.biz.request.ReceptionConfirmDeliveredReq GetReq(){
				return this.req_;
			}
			
			public void SetReq(com.vip.order.biz.request.ReceptionConfirmDeliveredReq value){
				this.req_ = value;
			}
			
		}
		
		
		
		
		public class refundOrder_args {
			
			///<summary>
			///</summary>
			
			private com.vip.order.common.pojo.order.request.RequestHeader requestHeader_;
			
			///<summary>
			///</summary>
			
			private com.vip.order.biz.request.OrderRefundReq orderRefundReq_;
			
			public com.vip.order.common.pojo.order.request.RequestHeader GetRequestHeader(){
				return this.requestHeader_;
			}
			
			public void SetRequestHeader(com.vip.order.common.pojo.order.request.RequestHeader value){
				this.requestHeader_ = value;
			}
			public com.vip.order.biz.request.OrderRefundReq GetOrderRefundReq(){
				return this.orderRefundReq_;
			}
			
			public void SetOrderRefundReq(com.vip.order.biz.request.OrderRefundReq value){
				this.orderRefundReq_ = value;
			}
			
		}
		
		
		
		
		public class releaseStock_args {
			
			///<summary>
			///</summary>
			
			private com.vip.order.common.pojo.order.request.RequestHeader requestHeader_;
			
			///<summary>
			///</summary>
			
			private com.vip.order.biz.request.ReleaseStockReq releaseStockReq_;
			
			public com.vip.order.common.pojo.order.request.RequestHeader GetRequestHeader(){
				return this.requestHeader_;
			}
			
			public void SetRequestHeader(com.vip.order.common.pojo.order.request.RequestHeader value){
				this.requestHeader_ = value;
			}
			public com.vip.order.biz.request.ReleaseStockReq GetReleaseStockReq(){
				return this.releaseStockReq_;
			}
			
			public void SetReleaseStockReq(com.vip.order.biz.request.ReleaseStockReq value){
				this.releaseStockReq_ = value;
			}
			
		}
		
		
		
		
		public class rollbackOrder_args {
			
			///<summary>
			///</summary>
			
			private com.vip.order.common.pojo.order.request.RequestHeader requestHeader_;
			
			///<summary>
			///</summary>
			
			private com.vip.order.biz.request.RollbackOrderReq rollbackOrderReq_;
			
			public com.vip.order.common.pojo.order.request.RequestHeader GetRequestHeader(){
				return this.requestHeader_;
			}
			
			public void SetRequestHeader(com.vip.order.common.pojo.order.request.RequestHeader value){
				this.requestHeader_ = value;
			}
			public com.vip.order.biz.request.RollbackOrderReq GetRollbackOrderReq(){
				return this.rollbackOrderReq_;
			}
			
			public void SetRollbackOrderReq(com.vip.order.biz.request.RollbackOrderReq value){
				this.rollbackOrderReq_ = value;
			}
			
		}
		
		
		
		
		public class searchOrderListByUserId_args {
			
			///<summary>
			///</summary>
			
			private com.vip.order.common.pojo.order.request.RequestHeader requestHeader_;
			
			///<summary>
			///</summary>
			
			private com.vip.order.biz.request.SearchOrderListByUserIdReq getOrderHistoryReq_;
			
			///<summary>
			///</summary>
			
			private com.vip.order.common.pojo.order.request.ResultFilter resultFilter_;
			
			public com.vip.order.common.pojo.order.request.RequestHeader GetRequestHeader(){
				return this.requestHeader_;
			}
			
			public void SetRequestHeader(com.vip.order.common.pojo.order.request.RequestHeader value){
				this.requestHeader_ = value;
			}
			public com.vip.order.biz.request.SearchOrderListByUserIdReq GetGetOrderHistoryReq(){
				return this.getOrderHistoryReq_;
			}
			
			public void SetGetOrderHistoryReq(com.vip.order.biz.request.SearchOrderListByUserIdReq value){
				this.getOrderHistoryReq_ = value;
			}
			public com.vip.order.common.pojo.order.request.ResultFilter GetResultFilter(){
				return this.resultFilter_;
			}
			
			public void SetResultFilter(com.vip.order.common.pojo.order.request.ResultFilter value){
				this.resultFilter_ = value;
			}
			
		}
		
		
		
		
		public class signOrder_args {
			
			///<summary>
			///</summary>
			
			private com.vip.order.common.pojo.order.request.RequestHeader requestHeader_;
			
			///<summary>
			///</summary>
			
			private com.vip.order.biz.request.SignOrderReq signOrderReq_;
			
			public com.vip.order.common.pojo.order.request.RequestHeader GetRequestHeader(){
				return this.requestHeader_;
			}
			
			public void SetRequestHeader(com.vip.order.common.pojo.order.request.RequestHeader value){
				this.requestHeader_ = value;
			}
			public com.vip.order.biz.request.SignOrderReq GetSignOrderReq(){
				return this.signOrderReq_;
			}
			
			public void SetSignOrderReq(com.vip.order.biz.request.SignOrderReq value){
				this.signOrderReq_ = value;
			}
			
		}
		
		
		
		
		public class triggerGroupByAuditOrder_args {
			
			///<summary>
			///</summary>
			
			private com.vip.order.common.pojo.order.request.RequestHeader requestHeader_;
			
			///<summary>
			///</summary>
			
			private com.vip.order.biz.request.GroupByOrderAuditReq groupByOrderAuditReq_;
			
			public com.vip.order.common.pojo.order.request.RequestHeader GetRequestHeader(){
				return this.requestHeader_;
			}
			
			public void SetRequestHeader(com.vip.order.common.pojo.order.request.RequestHeader value){
				this.requestHeader_ = value;
			}
			public com.vip.order.biz.request.GroupByOrderAuditReq GetGroupByOrderAuditReq(){
				return this.groupByOrderAuditReq_;
			}
			
			public void SetGroupByOrderAuditReq(com.vip.order.biz.request.GroupByOrderAuditReq value){
				this.groupByOrderAuditReq_ = value;
			}
			
		}
		
		
		
		
		public class updateAutoPayAuth_args {
			
			///<summary>
			///</summary>
			
			private com.vip.order.common.pojo.order.request.RequestHeader requestHeader_;
			
			///<summary>
			///</summary>
			
			private com.vip.order.biz.request.UpdateAutoPayAuthReq req_;
			
			public com.vip.order.common.pojo.order.request.RequestHeader GetRequestHeader(){
				return this.requestHeader_;
			}
			
			public void SetRequestHeader(com.vip.order.common.pojo.order.request.RequestHeader value){
				this.requestHeader_ = value;
			}
			public com.vip.order.biz.request.UpdateAutoPayAuthReq GetReq(){
				return this.req_;
			}
			
			public void SetReq(com.vip.order.biz.request.UpdateAutoPayAuthReq value){
				this.req_ = value;
			}
			
		}
		
		
		
		
		public class updateOrderPayResult_args {
			
			///<summary>
			///</summary>
			
			private com.vip.order.common.pojo.order.request.RequestHeader requestHeader_;
			
			///<summary>
			///</summary>
			
			private com.vip.order.biz.request.UpdateOrderPayResultReq updateOrderPayResultReq_;
			
			public com.vip.order.common.pojo.order.request.RequestHeader GetRequestHeader(){
				return this.requestHeader_;
			}
			
			public void SetRequestHeader(com.vip.order.common.pojo.order.request.RequestHeader value){
				this.requestHeader_ = value;
			}
			public com.vip.order.biz.request.UpdateOrderPayResultReq GetUpdateOrderPayResultReq(){
				return this.updateOrderPayResultReq_;
			}
			
			public void SetUpdateOrderPayResultReq(com.vip.order.biz.request.UpdateOrderPayResultReq value){
				this.updateOrderPayResultReq_ = value;
			}
			
		}
		
		
		
		
		public class updateOrderToReturnVerified_args {
			
			///<summary>
			///</summary>
			
			private com.vip.order.common.pojo.order.request.RequestHeader requestHeader_;
			
			///<summary>
			///</summary>
			
			private com.vip.order.biz.request.UpdateOrderToReturnVerifiedReq updateOrderToReturnVerifiedReq_;
			
			public com.vip.order.common.pojo.order.request.RequestHeader GetRequestHeader(){
				return this.requestHeader_;
			}
			
			public void SetRequestHeader(com.vip.order.common.pojo.order.request.RequestHeader value){
				this.requestHeader_ = value;
			}
			public com.vip.order.biz.request.UpdateOrderToReturnVerifiedReq GetUpdateOrderToReturnVerifiedReq(){
				return this.updateOrderToReturnVerifiedReq_;
			}
			
			public void SetUpdateOrderToReturnVerifiedReq(com.vip.order.biz.request.UpdateOrderToReturnVerifiedReq value){
				this.updateOrderToReturnVerifiedReq_ = value;
			}
			
		}
		
		
		
		
		public class updatePayTypeToCOD_args {
			
			///<summary>
			///</summary>
			
			private com.vip.order.common.pojo.order.request.RequestHeader requestHeader_;
			
			///<summary>
			///</summary>
			
			private com.vip.order.biz.request.UpdatePayTypeToCODReq updatePayTypeToCODReq_;
			
			public com.vip.order.common.pojo.order.request.RequestHeader GetRequestHeader(){
				return this.requestHeader_;
			}
			
			public void SetRequestHeader(com.vip.order.common.pojo.order.request.RequestHeader value){
				this.requestHeader_ = value;
			}
			public com.vip.order.biz.request.UpdatePayTypeToCODReq GetUpdatePayTypeToCODReq(){
				return this.updatePayTypeToCODReq_;
			}
			
			public void SetUpdatePayTypeToCODReq(com.vip.order.biz.request.UpdatePayTypeToCODReq value){
				this.updatePayTypeToCODReq_ = value;
			}
			
		}
		
		
		
		
		public class updatePrePayToVerified_args {
			
			///<summary>
			///</summary>
			
			private com.vip.order.common.pojo.order.request.RequestHeader requestHeader_;
			
			///<summary>
			///</summary>
			
			private com.vip.order.biz.request.UpdatePrePayToVerifiedReq updatePrePayToVerifiedReq_;
			
			public com.vip.order.common.pojo.order.request.RequestHeader GetRequestHeader(){
				return this.requestHeader_;
			}
			
			public void SetRequestHeader(com.vip.order.common.pojo.order.request.RequestHeader value){
				this.requestHeader_ = value;
			}
			public com.vip.order.biz.request.UpdatePrePayToVerifiedReq GetUpdatePrePayToVerifiedReq(){
				return this.updatePrePayToVerifiedReq_;
			}
			
			public void SetUpdatePrePayToVerifiedReq(com.vip.order.biz.request.UpdatePrePayToVerifiedReq value){
				this.updatePrePayToVerifiedReq_ = value;
			}
			
		}
		
		
		
		
		public class updateReservationState_args {
			
			///<summary>
			///</summary>
			
			private com.vip.order.common.pojo.order.request.RequestHeader requestHeader_;
			
			///<summary>
			///</summary>
			
			private com.vip.order.biz.request.UpdateReservationStateReq req_;
			
			public com.vip.order.common.pojo.order.request.RequestHeader GetRequestHeader(){
				return this.requestHeader_;
			}
			
			public void SetRequestHeader(com.vip.order.common.pojo.order.request.RequestHeader value){
				this.requestHeader_ = value;
			}
			public com.vip.order.biz.request.UpdateReservationStateReq GetReq(){
				return this.req_;
			}
			
			public void SetReq(com.vip.order.biz.request.UpdateReservationStateReq value){
				this.req_ = value;
			}
			
		}
		
		
		
		
		public class userDeleteOrder_args {
			
			///<summary>
			///</summary>
			
			private com.vip.order.common.pojo.order.request.RequestHeader header_;
			
			///<summary>
			///</summary>
			
			private com.vip.order.biz.request.UserDeleteOrderReq req_;
			
			public com.vip.order.common.pojo.order.request.RequestHeader GetHeader(){
				return this.header_;
			}
			
			public void SetHeader(com.vip.order.common.pojo.order.request.RequestHeader value){
				this.header_ = value;
			}
			public com.vip.order.biz.request.UserDeleteOrderReq GetReq(){
				return this.req_;
			}
			
			public void SetReq(com.vip.order.biz.request.UserDeleteOrderReq value){
				this.req_ = value;
			}
			
		}
		
		
		
		
		public class verifyStockAndGetPayableFlag_args {
			
			///<summary>
			///</summary>
			
			private com.vip.order.common.pojo.order.request.RequestHeader requestHeader_;
			
			///<summary>
			///</summary>
			
			private com.vip.order.biz.request.VerifyStockAndGetPayableFlagReq req_;
			
			public com.vip.order.common.pojo.order.request.RequestHeader GetRequestHeader(){
				return this.requestHeader_;
			}
			
			public void SetRequestHeader(com.vip.order.common.pojo.order.request.RequestHeader value){
				this.requestHeader_ = value;
			}
			public com.vip.order.biz.request.VerifyStockAndGetPayableFlagReq GetReq(){
				return this.req_;
			}
			
			public void SetReq(com.vip.order.biz.request.VerifyStockAndGetPayableFlagReq value){
				this.req_ = value;
			}
			
		}
		
		
		
		
		public class addOrderTransport_result {
			
			///<summary>
			/// 插入结果
			///</summary>
			
			private com.vip.order.biz.response.AddOrderTransportResp success_;
			
			public com.vip.order.biz.response.AddOrderTransportResp GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.order.biz.response.AddOrderTransportResp value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class autoPay_result {
			
			///<summary>
			/// Pay自动扣款
			///</summary>
			
			private com.vip.order.biz.response.AutoPayResp success_;
			
			public com.vip.order.biz.response.AutoPayResp GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.order.biz.response.AutoPayResp value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class autoPayFail_result {
			
			///<summary>
			/// Pay扣款失败回调
			///</summary>
			
			private com.vip.order.biz.response.AutoPayFailResp success_;
			
			public com.vip.order.biz.response.AutoPayFailResp GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.order.biz.response.AutoPayFailResp value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class autoTakeInventory_result {
			
			///<summary>
			/// 预约购买占用库存回调
			///</summary>
			
			private com.vip.order.biz.response.AutoTakeInventoryResp success_;
			
			public com.vip.order.biz.response.AutoTakeInventoryResp GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.order.biz.response.AutoTakeInventoryResp value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class b2cSupportSendSms_result {
			
			///<summary>
			/// 短信发送结果（成功的号码列表，失败的号码列表）
			///</summary>
			
			private com.vip.order.biz.response.B2CSupportSendSmsResp success_;
			
			public com.vip.order.biz.response.B2CSupportSendSmsResp GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.order.biz.response.B2CSupportSendSmsResp value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class batchGetOrderActiveDetail_result {
			
			///<summary>
			/// 批量查询订单优惠明细
			///</summary>
			
			private com.vip.order.biz.response.BatchGetOrderActiveDetailResp success_;
			
			public com.vip.order.biz.response.BatchGetOrderActiveDetailResp GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.order.biz.response.BatchGetOrderActiveDetailResp value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class batchGetOrderList_result {
			
			///<summary>
			/// 
			///</summary>
			
			private com.vip.order.biz.response.BatchGetOrderListResp success_;
			
			public com.vip.order.biz.response.BatchGetOrderListResp GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.order.biz.response.BatchGetOrderListResp value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class batchGetOrderTransportList_result {
			
			///<summary>
			/// 批量查询订单物流信息
			///</summary>
			
			private com.vip.order.biz.response.BatchGetOrderTransportListResp success_;
			
			public com.vip.order.biz.response.BatchGetOrderTransportListResp GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.order.biz.response.BatchGetOrderTransportListResp value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class batchModifyOrderInvoice_result {
			
			///<summary>
			/// 批量修改订单发票信息
			///</summary>
			
			private com.vip.order.biz.response.BatchModifyOrderInvoiceResp success_;
			
			public com.vip.order.biz.response.BatchModifyOrderInvoiceResp GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.order.biz.response.BatchModifyOrderInvoiceResp value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class batchUpdateWmsFlag_result {
			
			///<summary>
			/// 批量更新订单WMS标志结果
			///</summary>
			
			private com.vip.order.biz.response.BatchUpdateWmsFlagResp success_;
			
			public com.vip.order.biz.response.BatchUpdateWmsFlagResp GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.order.biz.response.BatchUpdateWmsFlagResp value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class calculateSplitOrderMoney_result {
			
			///<summary>
			/// 拆单金额计算结果
			///</summary>
			
			private com.vip.order.biz.response.CalculateSplitOrderMoneyResp success_;
			
			public com.vip.order.biz.response.CalculateSplitOrderMoneyResp GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.order.biz.response.CalculateSplitOrderMoneyResp value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class cancelOFixData_result {
			
			///<summary>
			/// 取消订单工具
			///</summary>
			
			private com.vip.order.biz.response.CancelOrderFixDataResp success_;
			
			public com.vip.order.biz.response.CancelOrderFixDataResp GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.order.biz.response.CancelOrderFixDataResp value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class cancelOrder_result {
			
			///<summary>
			///</summary>
			
			private com.vip.order.biz.response.CancelOrderResp success_;
			
			public com.vip.order.biz.response.CancelOrderResp GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.order.biz.response.CancelOrderResp value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class cancelPresellOrder_result {
			
			///<summary>
			///</summary>
			
			private com.vip.order.biz.response.CancelOrderResp success_;
			
			public com.vip.order.biz.response.CancelOrderResp GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.order.biz.response.CancelOrderResp value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class checkCashOnDelivery_result {
			
			///<summary>
			/// 
			///</summary>
			
			private com.vip.order.biz.response.CheckCashOnDeliveryResp success_;
			
			public com.vip.order.biz.response.CheckCashOnDeliveryResp GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.order.biz.response.CheckCashOnDeliveryResp value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class checkDeliveryFetchExchange_result {
			
			///<summary>
			/// 查询是否支持上门揽换
			///</summary>
			
			private com.vip.order.biz.response.CheckDeliveryFetchExchangeResp success_;
			
			public com.vip.order.biz.response.CheckDeliveryFetchExchangeResp GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.order.biz.response.CheckDeliveryFetchExchangeResp value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class checkDeliveryFetchReturn_result {
			
			///<summary>
			/// 查询是否支持上门揽退
			///</summary>
			
			private com.vip.order.biz.response.CheckDeliveryFetchReturnResp success_;
			
			public com.vip.order.biz.response.CheckDeliveryFetchReturnResp GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.order.biz.response.CheckDeliveryFetchReturnResp value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class checkOrderReturnVendorAudit_result {
			
			///<summary>
			///</summary>
			
			private com.vip.order.biz.response.CheckOrderReturnVendorAuditResp success_;
			
			public com.vip.order.biz.response.CheckOrderReturnVendorAuditResp GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.order.biz.response.CheckOrderReturnVendorAuditResp value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class confirmDelivered_result {
			
			///<summary>
			/// 修改结果
			///</summary>
			
			private com.vip.order.biz.response.ConfirmDeliveredResp success_;
			
			public com.vip.order.biz.response.ConfirmDeliveredResp GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.order.biz.response.ConfirmDeliveredResp value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class confirmOrderGroupBuyResult_result {
			
			///<summary>
			/// 拼团成团确认
			///</summary>
			
			private com.vip.order.biz.response.ConfirmOrderGroupBuyResp success_;
			
			public com.vip.order.biz.response.ConfirmOrderGroupBuyResp GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.order.biz.response.ConfirmOrderGroupBuyResp value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class createOrder_result {
			
			///<summary>
			/// 订单ID
			///</summary>
			
			private com.vip.order.biz.response.CreateOrderResp success_;
			
			public com.vip.order.biz.response.CreateOrderResp GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.order.biz.response.CreateOrderResp value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class createOrderElectronicInvoice_result {
			
			///<summary>
			/// 添加电子发票
			///</summary>
			
			private com.vip.order.biz.response.CreateOrderElectronicInvoiceResp success_;
			
			public com.vip.order.biz.response.CreateOrderElectronicInvoiceResp GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.order.biz.response.CreateOrderElectronicInvoiceResp value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class createOrderPostProc_result {
			
			///<summary>
			/// 
			///</summary>
			
			private com.vip.order.biz.response.CreateOrderPostProcResp success_;
			
			public com.vip.order.biz.response.CreateOrderPostProcResp GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.order.biz.response.CreateOrderPostProcResp value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class createOrderSnV2_result {
			
			///<summary>
			///</summary>
			
			private com.vip.order.biz.response.CreateOrderSnRespV2 success_;
			
			public com.vip.order.biz.response.CreateOrderSnRespV2 GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.order.biz.response.CreateOrderSnRespV2 value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class createOrderSnV3_result {
			
			///<summary>
			///</summary>
			
			private com.vip.order.biz.response.CreateOrderSnRespV3 success_;
			
			public com.vip.order.biz.response.CreateOrderSnRespV3 GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.order.biz.response.CreateOrderSnRespV3 value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class createOrderV2_result {
			
			///<summary>
			/// 订单ID
			///</summary>
			
			private com.vip.order.biz.response.CreateOrderRespV2 success_;
			
			public com.vip.order.biz.response.CreateOrderRespV2 GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.order.biz.response.CreateOrderRespV2 value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class createOrderV3_result {
			
			///<summary>
			/// 订单ID
			///</summary>
			
			private com.vip.order.biz.response.CreateOrderRespV3 success_;
			
			public com.vip.order.biz.response.CreateOrderRespV3 GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.order.biz.response.CreateOrderRespV3 value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class cscCancelBack_result {
			
			///<summary>
			/// 取消售后结果
			///</summary>
			
			private com.vip.order.biz.response.CSCCancelBackResp success_;
			
			public com.vip.order.biz.response.CSCCancelBackResp GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.order.biz.response.CSCCancelBackResp value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class displayOrder_result {
			
			///<summary>
			/// 隐藏订单
			///</summary>
			
			private com.vip.order.biz.response.DisplayOrderResp success_;
			
			public com.vip.order.biz.response.DisplayOrderResp GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.order.biz.response.DisplayOrderResp value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getAfterSaleOpType_result {
			
			///<summary>
			/// 订单售后服务类型
			///</summary>
			
			private com.vip.order.biz.response.GetAfterSaleOpTypeResp success_;
			
			public com.vip.order.biz.response.GetAfterSaleOpTypeResp GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.order.biz.response.GetAfterSaleOpTypeResp value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getCanAfterSaleOrderListByUserId_result {
			
			///<summary>
			/// 返回可售后订单列表
			///</summary>
			
			private com.vip.order.biz.response.GetCanAfterSaleOrderListResp success_;
			
			public com.vip.order.biz.response.GetCanAfterSaleOrderListResp GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.order.biz.response.GetCanAfterSaleOrderListResp value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getCanRefundOrderCount_result {
			
			///<summary>
			/// 查询订单可特殊退款接口总数
			///</summary>
			
			private com.vip.order.biz.response.GetCanRefundOrderCountResp success_;
			
			public com.vip.order.biz.response.GetCanRefundOrderCountResp GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.order.biz.response.GetCanRefundOrderCountResp value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getCanRefundOrderList_result {
			
			///<summary>
			///  查询订单可特殊退款列表
			///</summary>
			
			private com.vip.order.biz.response.GetCanRefundOrderListResp success_;
			
			public com.vip.order.biz.response.GetCanRefundOrderListResp GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.order.biz.response.GetCanRefundOrderListResp value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getEbsGoodsList_result {
			
			///<summary>
			/// 
			///</summary>
			
			private com.vip.order.biz.response.GetEbsGoodsListResp success_;
			
			public com.vip.order.biz.response.GetEbsGoodsListResp GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.order.biz.response.GetEbsGoodsListResp value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getGoodsDispatchWarehouse_result {
			
			///<summary>
			/// 查询商品发货仓返回结果
			///</summary>
			
			private com.vip.order.biz.response.GetGoodsDispatchWarehouseResp success_;
			
			public com.vip.order.biz.response.GetGoodsDispatchWarehouseResp GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.order.biz.response.GetGoodsDispatchWarehouseResp value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getLimitedOrderGoodsCount_result {
			
			///<summary>
			/// 查询限购商品用户购买的商品数量
			///</summary>
			
			private com.vip.order.biz.response.GetLimitedOrderGoodsCountResp success_;
			
			public com.vip.order.biz.response.GetLimitedOrderGoodsCountResp GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.order.biz.response.GetLimitedOrderGoodsCountResp value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getLinkageOrders_result {
			
			///<summary>
			/// 查询联动取消订单接口（流程层）
			///</summary>
			
			private com.vip.order.biz.response.LinkageOrderResp success_;
			
			public com.vip.order.biz.response.LinkageOrderResp GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.order.biz.response.LinkageOrderResp value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getMergeOrderList_result {
			
			///<summary>
			/// 可合并订单列表
			///</summary>
			
			private com.vip.order.biz.response.GetMergeOrderResp success_;
			
			public com.vip.order.biz.response.GetMergeOrderResp GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.order.biz.response.GetMergeOrderResp value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getOrderCounts_result {
			
			///<summary>
			///</summary>
			
			private com.vip.order.biz.response.OrderListCountResp success_;
			
			public com.vip.order.biz.response.OrderListCountResp GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.order.biz.response.OrderListCountResp value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getOrderCountsByUserId_result {
			
			///<summary>
			///</summary>
			
			private com.vip.order.biz.response.OrderListCountResp success_;
			
			public com.vip.order.biz.response.OrderListCountResp GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.order.biz.response.OrderListCountResp value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getOrderDeliveryBoxNum_result {
			
			///<summary>
			///</summary>
			
			private com.vip.order.biz.response.GetOrderDeliveryBoxNumResp success_;
			
			public com.vip.order.biz.response.GetOrderDeliveryBoxNumResp GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.order.biz.response.GetOrderDeliveryBoxNumResp value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getOrderDetail_result {
			
			///<summary>
			/// 订单ID
			///</summary>
			
			private com.vip.order.biz.response.SearchOrderDetailResp success_;
			
			public com.vip.order.biz.response.SearchOrderDetailResp GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.order.biz.response.SearchOrderDetailResp value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getOrderElectronicInvoicesV2_result {
			
			///<summary>
			///</summary>
			
			private com.vip.order.biz.response.OrderElectronicInvoicesV2Resp success_;
			
			public com.vip.order.biz.response.OrderElectronicInvoicesV2Resp GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.order.biz.response.OrderElectronicInvoicesV2Resp value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getOrderFav_result {
			
			///<summary>
			///</summary>
			
			private com.vip.order.biz.response.GetOrderFavResp success_;
			
			public com.vip.order.biz.response.GetOrderFavResp GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.order.biz.response.GetOrderFavResp value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getOrderGoodsCount_result {
			
			///<summary>
			/// 根据传入的参数查询商品总数
			///</summary>
			
			private com.vip.order.biz.response.GetOrderGoodsCountResultResp success_;
			
			public com.vip.order.biz.response.GetOrderGoodsCountResultResp GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.order.biz.response.GetOrderGoodsCountResultResp value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getOrderGoodsList_result {
			
			///<summary>
			/// 根据传入的参数查询商品列表信息
			///</summary>
			
			private com.vip.order.biz.response.GetOrderGoodsResultResp success_;
			
			public com.vip.order.biz.response.GetOrderGoodsResultResp GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.order.biz.response.GetOrderGoodsResultResp value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getOrderInstalmentsList_result {
			
			///<summary>
			/// 订单分期付款列表
			///</summary>
			
			private com.vip.order.biz.response.GetOrderInstalmentsListResp success_;
			
			public com.vip.order.biz.response.GetOrderInstalmentsListResp GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.order.biz.response.GetOrderInstalmentsListResp value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getOrderInvoicesV2_result {
			
			///<summary>
			///</summary>
			
			private com.vip.order.biz.response.OrderInvoicesV2Resp success_;
			
			public com.vip.order.biz.response.OrderInvoicesV2Resp GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.order.biz.response.OrderInvoicesV2Resp value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getOrderList_result {
			
			///<summary>
			/// 
			///</summary>
			
			private com.vip.order.biz.response.SearchOrderListResp success_;
			
			public com.vip.order.biz.response.SearchOrderListResp GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.order.biz.response.SearchOrderListResp value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getOrderListByPosNo_result {
			
			///<summary>
			/// 根据posNo查询订单列表
			///</summary>
			
			private com.vip.order.biz.response.GetOrderListByPosNoResp success_;
			
			public com.vip.order.biz.response.GetOrderListByPosNoResp GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.order.biz.response.GetOrderListByPosNoResp value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getOrderListByUserId_result {
			
			///<summary>
			///</summary>
			
			private com.vip.order.biz.response.GetOrderListByUserIdResp success_;
			
			public com.vip.order.biz.response.GetOrderListByUserIdResp GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.order.biz.response.GetOrderListByUserIdResp value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getOrderLogs_result {
			
			///<summary>
			///</summary>
			
			private com.vip.order.biz.response.GetOrderLogsResp success_;
			
			public com.vip.order.biz.response.GetOrderLogsResp GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.order.biz.response.GetOrderLogsResp value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getOrderOpStatus_result {
			
			///<summary>
			/// 
			///</summary>
			
			private com.vip.order.biz.response.GetOrderOpStatusResp success_;
			
			public com.vip.order.biz.response.GetOrderOpStatusResp GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.order.biz.response.GetOrderOpStatusResp value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getOrderPackageList_result {
			
			///<summary>
			/// 订单包裹列表
			///</summary>
			
			private com.vip.order.biz.response.GetOrderPackageListResp success_;
			
			public com.vip.order.biz.response.GetOrderPackageListResp GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.order.biz.response.GetOrderPackageListResp value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getOrderPayType_result {
			
			///<summary>
			///</summary>
			
			private com.vip.order.biz.response.GetOrderPayTypeResp success_;
			
			public com.vip.order.biz.response.GetOrderPayTypeResp GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.order.biz.response.GetOrderPayTypeResp value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getOrderSnByExOrderSn_result {
			
			///<summary>
			///</summary>
			
			private com.vip.order.biz.response.GetOrderSnByExOrderSnResp success_;
			
			public com.vip.order.biz.response.GetOrderSnByExOrderSnResp GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.order.biz.response.GetOrderSnByExOrderSnResp value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getOrderTransport_result {
			
			///<summary>
			/// 订单物流可视化流程服务
			///</summary>
			
			private com.vip.order.biz.response.GetOrderTransportResp success_;
			
			public com.vip.order.biz.response.GetOrderTransportResp GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.order.biz.response.GetOrderTransportResp value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getOrderTransportDetail_result {
			
			///<summary>
			/// 查询订单物流详细信息
			///</summary>
			
			private com.vip.order.biz.response.GetOrderTransportDetailResp success_;
			
			public com.vip.order.biz.response.GetOrderTransportDetailResp GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.order.biz.response.GetOrderTransportDetailResp value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getOrderTransportListByCodes_result {
			
			///<summary>
			///</summary>
			
			private com.vip.order.biz.response.GetTransportListByCodesResp success_;
			
			public com.vip.order.biz.response.GetTransportListByCodesResp GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.order.biz.response.GetTransportListByCodesResp value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getOrdersBySizeId_result {
			
			///<summary>
			/// 通过商品sizeId插查询订单信息
			///</summary>
			
			private com.vip.order.biz.response.GetOrdersBySizeIdResp success_;
			
			public com.vip.order.biz.response.GetOrdersBySizeIdResp GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.order.biz.response.GetOrdersBySizeIdResp value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getPrepayOrderStatus_result {
			
			///<summary>
			/// 查询预付订单状态
			///</summary>
			
			private com.vip.order.biz.response.GetPrepayOrderStatusResp success_;
			
			public com.vip.order.biz.response.GetPrepayOrderStatusResp GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.order.biz.response.GetPrepayOrderStatusResp value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getPrepayOrderUnpayMsg_result {
			
			///<summary>
			/// 查询预付订单尾单支付提醒消息--只返回需要提醒的消息
			///</summary>
			
			private com.vip.order.biz.response.GetPrepayOrderUnpayMsgResp success_;
			
			public com.vip.order.biz.response.GetPrepayOrderUnpayMsgResp GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.order.biz.response.GetPrepayOrderUnpayMsgResp value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getRdc_result {
			
			///<summary>
			/// 获取RDC
			///</summary>
			
			private com.vip.order.biz.response.GetRdcResp success_;
			
			public com.vip.order.biz.response.GetRdcResp GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.order.biz.response.GetRdcResp value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getRdcInvoice_result {
			
			///<summary>
			/// 获取Rdc增值税发票
			///</summary>
			
			private com.vip.order.biz.response.GetRdcInvoiceResp success_;
			
			public com.vip.order.biz.response.GetRdcInvoiceResp GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.order.biz.response.GetRdcInvoiceResp value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getReturnOrExchangeGoods_result {
			
			///<summary>
			/// 订单可退换商品及数量
			///</summary>
			
			private com.vip.order.biz.response.GetReturnOrExchangeGoodsResp success_;
			
			public com.vip.order.biz.response.GetReturnOrExchangeGoodsResp GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.order.biz.response.GetReturnOrExchangeGoodsResp value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getSimpleOrderFlowFlag_result {
			
			///<summary>
			///</summary>
			
			private com.vip.order.biz.response.GetSimpleOrderFlowFlagResp success_;
			
			public com.vip.order.biz.response.GetSimpleOrderFlowFlagResp GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.order.biz.response.GetSimpleOrderFlowFlagResp value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getUnpayOrderList_result {
			
			///<summary>
			///</summary>
			
			private com.vip.order.biz.response.GetUnpayOrderResp success_;
			
			public com.vip.order.biz.response.GetUnpayOrderResp GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.order.biz.response.GetUnpayOrderResp value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getUserDeliveryAddress_result {
			
			///<summary>
			/// 获取会员订单收货地址信息
			///</summary>
			
			private com.vip.order.biz.response.GetUserDeliveryAddressResp success_;
			
			public com.vip.order.biz.response.GetUserDeliveryAddressResp GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.order.biz.response.GetUserDeliveryAddressResp value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getUserFirstOrder_result {
			
			///<summary>
			/// 查询会员首单信息
			///</summary>
			
			private com.vip.order.biz.response.GetUserFirstOrderResp success_;
			
			public com.vip.order.biz.response.GetUserFirstOrderResp GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.order.biz.response.GetUserFirstOrderResp value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class healthCheck_result {
			
			///<summary>
			///</summary>
			
			private com.vip.hermes.core.health.CheckResult success_;
			
			public com.vip.hermes.core.health.CheckResult GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.hermes.core.health.CheckResult value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class mergeOrder_result {
			
			///<summary>
			///</summary>
			
			private com.vip.order.biz.response.MergeOrderResp success_;
			
			public com.vip.order.biz.response.MergeOrderResp GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.order.biz.response.MergeOrderResp value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class modifyOrderConsignee_result {
			
			///<summary>
			/// 修改结果
			///</summary>
			
			private com.vip.order.biz.response.ModifyOrderConsigneeResp success_;
			
			public com.vip.order.biz.response.ModifyOrderConsigneeResp GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.order.biz.response.ModifyOrderConsigneeResp value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class modifyOrderElectronicInvoice_result {
			
			///<summary>
			/// 更新电子发票
			///</summary>
			
			private com.vip.order.biz.response.ModifyOrderElectronicInvoiceResp success_;
			
			public com.vip.order.biz.response.ModifyOrderElectronicInvoiceResp GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.order.biz.response.ModifyOrderElectronicInvoiceResp value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class modifyOrderGoods_result {
			
			///<summary>
			/// 修改订单商品
			///</summary>
			
			private com.vip.order.biz.response.ModifyOrderGoodsResp success_;
			
			public com.vip.order.biz.response.ModifyOrderGoodsResp GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.order.biz.response.ModifyOrderGoodsResp value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class modifyOrderPayType_result {
			
			///<summary>
			/// 
			///</summary>
			
			private com.vip.order.biz.request.ModifyOrderPayTypeRsp success_;
			
			public com.vip.order.biz.request.ModifyOrderPayTypeRsp GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.order.biz.request.ModifyOrderPayTypeRsp value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class modifyOrderQualified_result {
			
			///<summary>
			/// 修改订单为已合格结果
			///</summary>
			
			private com.vip.order.biz.response.ModifyOrderQualifiedResp success_;
			
			public com.vip.order.biz.response.ModifyOrderQualifiedResp GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.order.biz.response.ModifyOrderQualifiedResp value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class modifyOrderShipped_result {
			
			///<summary>
			/// 修改订单为已发货结果
			///</summary>
			
			private com.vip.order.biz.response.ModifyOrderShippedResp success_;
			
			public com.vip.order.biz.response.ModifyOrderShippedResp GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.order.biz.response.ModifyOrderShippedResp value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class modifyPrepayOrderPayType_result {
			
			///<summary>
			/// 更改结果
			///</summary>
			
			private com.vip.order.biz.request.ModifyOrderPayTypeRsp success_;
			
			public com.vip.order.biz.request.ModifyOrderPayTypeRsp GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.order.biz.request.ModifyOrderPayTypeRsp value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class notifyCustomsDeclarationFailed_result {
			
			///<summary>
			/// HTS反馈海淘报关失败
			///</summary>
			
			private com.vip.order.biz.response.NotifyCustomsDeclarationFailedResp success_;
			
			public com.vip.order.biz.response.NotifyCustomsDeclarationFailedResp GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.order.biz.response.NotifyCustomsDeclarationFailedResp value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class ofcEntranceGrayControl_result {
			
			///<summary>
			/// ofc入口灰度
			///</summary>
			
			private com.vip.order.biz.response.OfcEntranceGrayControlResp success_;
			
			public com.vip.order.biz.response.OfcEntranceGrayControlResp GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.order.biz.response.OfcEntranceGrayControlResp value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class paymentReceived_result {
			
			///<summary>
			/// 货款已收到
			///</summary>
			
			private com.vip.order.biz.response.PaymentReceivedResp success_;
			
			public com.vip.order.biz.response.PaymentReceivedResp GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.order.biz.response.PaymentReceivedResp value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class postOrderVMSMessage_result {
			
			///<summary>
			/// 透传结果
			///</summary>
			
			private com.vip.order.biz.response.PostOrderVMSMessageResp success_;
			
			public com.vip.order.biz.response.PostOrderVMSMessageResp GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.order.biz.response.PostOrderVMSMessageResp value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class putIntoSplitQueue_result {
			
			///<summary>
			///</summary>
			
			private com.vip.order.biz.response.PutIntoSplitQueueResp success_;
			
			public com.vip.order.biz.response.PutIntoSplitQueueResp GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.order.biz.response.PutIntoSplitQueueResp value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class putKeyToRollbackQueue_result {
			
			///<summary>
			///</summary>
			
			private com.vip.order.biz.response.PutKeyToRollbackQueueResp success_;
			
			public com.vip.order.biz.response.PutKeyToRollbackQueueResp GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.order.biz.response.PutKeyToRollbackQueueResp value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class putOrderToRollbackQueue_result {
			
			///<summary>
			///</summary>
			
			private com.vip.order.biz.response.PutOrderToRollbackQueueResp success_;
			
			public com.vip.order.biz.response.PutOrderToRollbackQueueResp GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.order.biz.response.PutOrderToRollbackQueueResp value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class receptionConfirmDelivered_result {
			
			///<summary>
			/// 前台已签收
			///</summary>
			
			private com.vip.order.biz.response.ReceptionConfirmDeliveredResp success_;
			
			public com.vip.order.biz.response.ReceptionConfirmDeliveredResp GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.order.biz.response.ReceptionConfirmDeliveredResp value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class refundOrder_result {
			
			///<summary>
			/// 订单退款
			///</summary>
			
			private com.vip.order.biz.response.OrderRefundResp success_;
			
			public com.vip.order.biz.response.OrderRefundResp GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.order.biz.response.OrderRefundResp value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class releaseStock_result {
			
			///<summary>
			/// 释放库存结果
			///</summary>
			
			private com.vip.order.biz.response.ReleaseStockResp success_;
			
			public com.vip.order.biz.response.ReleaseStockResp GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.order.biz.response.ReleaseStockResp value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class rollbackOrder_result {
			
			///<summary>
			/// 成功回滚条数
			///</summary>
			
			private com.vip.order.biz.response.RollbackOrderResp success_;
			
			public com.vip.order.biz.response.RollbackOrderResp GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.order.biz.response.RollbackOrderResp value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class searchOrderListByUserId_result {
			
			///<summary>
			/// 用户历史订单列表
			///</summary>
			
			private com.vip.order.biz.response.SearchOrderListByUserIdResp success_;
			
			public com.vip.order.biz.response.SearchOrderListByUserIdResp GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.order.biz.response.SearchOrderListByUserIdResp value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class signOrder_result {
			
			///<summary>
			/// 会员确认签收订单--未上线
			///</summary>
			
			private com.vip.order.biz.response.SignOrderResp success_;
			
			public com.vip.order.biz.response.SignOrderResp GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.order.biz.response.SignOrderResp value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class triggerGroupByAuditOrder_result {
			
			///<summary>
			/// 拼团触发审核订单结果
			///</summary>
			
			private com.vip.order.biz.response.GroupByOrderAuditResp success_;
			
			public com.vip.order.biz.response.GroupByOrderAuditResp GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.order.biz.response.GroupByOrderAuditResp value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class updateAutoPayAuth_result {
			
			///<summary>
			/// 预约购买Pay授权成功回调
			///</summary>
			
			private com.vip.order.biz.response.UpdateAutoPayAuthResp success_;
			
			public com.vip.order.biz.response.UpdateAutoPayAuthResp GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.order.biz.response.UpdateAutoPayAuthResp value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class updateOrderPayResult_result {
			
			///<summary>
			/// 
			///</summary>
			
			private com.vip.order.biz.response.UpdateOrderPayResultResp success_;
			
			public com.vip.order.biz.response.UpdateOrderPayResultResp GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.order.biz.response.UpdateOrderPayResultResp value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class updateOrderToReturnVerified_result {
			
			///<summary>
			/// 更新结果
			///</summary>
			
			private com.vip.order.biz.response.UpdateOrderToReturnVerifiedResp success_;
			
			public com.vip.order.biz.response.UpdateOrderToReturnVerifiedResp GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.order.biz.response.UpdateOrderToReturnVerifiedResp value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class updatePayTypeToCOD_result {
			
			///<summary>
			/// 修改结果
			///</summary>
			
			private com.vip.order.biz.response.UpdatePayTypeToCODResp success_;
			
			public com.vip.order.biz.response.UpdatePayTypeToCODResp GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.order.biz.response.UpdatePayTypeToCODResp value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class updatePrePayToVerified_result {
			
			///<summary>
			/// 修改结果
			///</summary>
			
			private com.vip.order.biz.response.UpdatePrePayToVerifiedResp success_;
			
			public com.vip.order.biz.response.UpdatePrePayToVerifiedResp GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.order.biz.response.UpdatePrePayToVerifiedResp value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class updateReservationState_result {
			
			///<summary>
			/// 修改预约购买单排队状态
			///</summary>
			
			private com.vip.order.biz.response.UpdateReservationStateResp success_;
			
			public com.vip.order.biz.response.UpdateReservationStateResp GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.order.biz.response.UpdateReservationStateResp value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class userDeleteOrder_result {
			
			///<summary>
			/// 前台删除订单结果
			///</summary>
			
			private com.vip.order.biz.response.UserDeleteOrderResp success_;
			
			public com.vip.order.biz.response.UserDeleteOrderResp GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.order.biz.response.UserDeleteOrderResp value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class verifyStockAndGetPayableFlag_result {
			
			///<summary>
			/// 验证库存获取可支付标识-对应php二次支付-结果
			///</summary>
			
			private com.vip.order.biz.response.VerifyStockAndGetPayableFlagResp success_;
			
			public com.vip.order.biz.response.VerifyStockAndGetPayableFlagResp GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.order.biz.response.VerifyStockAndGetPayableFlagResp value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		
		public class addOrderTransport_argsHelper : TBeanSerializer<addOrderTransport_args>
		{
			
			public static addOrderTransport_argsHelper OBJ = new addOrderTransport_argsHelper();
			
			public static addOrderTransport_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(addOrderTransport_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.common.pojo.order.request.RequestHeader value;
					
					value = new com.vip.order.common.pojo.order.request.RequestHeader();
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Read(value, iprot);
					
					structs.SetRequestHeader(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.order.biz.request.AddOrderTransportReq value;
					
					value = new com.vip.order.biz.request.AddOrderTransportReq();
					com.vip.order.biz.request.AddOrderTransportReqHelper.getInstance().Read(value, iprot);
					
					structs.SetAddOrderTransportReq(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(addOrderTransport_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequestHeader() != null) {
					
					oprot.WriteFieldBegin("requestHeader");
					
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Write(structs.GetRequestHeader(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetAddOrderTransportReq() != null) {
					
					oprot.WriteFieldBegin("addOrderTransportReq");
					
					com.vip.order.biz.request.AddOrderTransportReqHelper.getInstance().Write(structs.GetAddOrderTransportReq(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(addOrderTransport_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class autoPay_argsHelper : TBeanSerializer<autoPay_args>
		{
			
			public static autoPay_argsHelper OBJ = new autoPay_argsHelper();
			
			public static autoPay_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(autoPay_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.common.pojo.order.request.RequestHeader value;
					
					value = new com.vip.order.common.pojo.order.request.RequestHeader();
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Read(value, iprot);
					
					structs.SetRequestHeader(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.order.biz.request.AutoPayReq value;
					
					value = new com.vip.order.biz.request.AutoPayReq();
					com.vip.order.biz.request.AutoPayReqHelper.getInstance().Read(value, iprot);
					
					structs.SetReq(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(autoPay_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequestHeader() != null) {
					
					oprot.WriteFieldBegin("requestHeader");
					
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Write(structs.GetRequestHeader(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetReq() != null) {
					
					oprot.WriteFieldBegin("req");
					
					com.vip.order.biz.request.AutoPayReqHelper.getInstance().Write(structs.GetReq(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(autoPay_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class autoPayFail_argsHelper : TBeanSerializer<autoPayFail_args>
		{
			
			public static autoPayFail_argsHelper OBJ = new autoPayFail_argsHelper();
			
			public static autoPayFail_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(autoPayFail_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.common.pojo.order.request.RequestHeader value;
					
					value = new com.vip.order.common.pojo.order.request.RequestHeader();
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Read(value, iprot);
					
					structs.SetRequestHeader(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.order.biz.request.AutoPayFailReq value;
					
					value = new com.vip.order.biz.request.AutoPayFailReq();
					com.vip.order.biz.request.AutoPayFailReqHelper.getInstance().Read(value, iprot);
					
					structs.SetReq(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(autoPayFail_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequestHeader() != null) {
					
					oprot.WriteFieldBegin("requestHeader");
					
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Write(structs.GetRequestHeader(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetReq() != null) {
					
					oprot.WriteFieldBegin("req");
					
					com.vip.order.biz.request.AutoPayFailReqHelper.getInstance().Write(structs.GetReq(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(autoPayFail_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class autoTakeInventory_argsHelper : TBeanSerializer<autoTakeInventory_args>
		{
			
			public static autoTakeInventory_argsHelper OBJ = new autoTakeInventory_argsHelper();
			
			public static autoTakeInventory_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(autoTakeInventory_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.common.pojo.order.request.RequestHeader value;
					
					value = new com.vip.order.common.pojo.order.request.RequestHeader();
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Read(value, iprot);
					
					structs.SetRequestHeader(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.order.biz.request.AutoTakeInventoryReq value;
					
					value = new com.vip.order.biz.request.AutoTakeInventoryReq();
					com.vip.order.biz.request.AutoTakeInventoryReqHelper.getInstance().Read(value, iprot);
					
					structs.SetReq(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(autoTakeInventory_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequestHeader() != null) {
					
					oprot.WriteFieldBegin("requestHeader");
					
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Write(structs.GetRequestHeader(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetReq() != null) {
					
					oprot.WriteFieldBegin("req");
					
					com.vip.order.biz.request.AutoTakeInventoryReqHelper.getInstance().Write(structs.GetReq(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(autoTakeInventory_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class b2cSupportSendSms_argsHelper : TBeanSerializer<b2cSupportSendSms_args>
		{
			
			public static b2cSupportSendSms_argsHelper OBJ = new b2cSupportSendSms_argsHelper();
			
			public static b2cSupportSendSms_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(b2cSupportSendSms_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.common.pojo.order.request.RequestHeader value;
					
					value = new com.vip.order.common.pojo.order.request.RequestHeader();
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Read(value, iprot);
					
					structs.SetHeader(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.order.biz.request.B2CSupportSendSmsReq value;
					
					value = new com.vip.order.biz.request.B2CSupportSendSmsReq();
					com.vip.order.biz.request.B2CSupportSendSmsReqHelper.getInstance().Read(value, iprot);
					
					structs.SetReq(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(b2cSupportSendSms_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetHeader() != null) {
					
					oprot.WriteFieldBegin("header");
					
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Write(structs.GetHeader(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetReq() != null) {
					
					oprot.WriteFieldBegin("req");
					
					com.vip.order.biz.request.B2CSupportSendSmsReqHelper.getInstance().Write(structs.GetReq(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(b2cSupportSendSms_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class batchGetOrderActiveDetail_argsHelper : TBeanSerializer<batchGetOrderActiveDetail_args>
		{
			
			public static batchGetOrderActiveDetail_argsHelper OBJ = new batchGetOrderActiveDetail_argsHelper();
			
			public static batchGetOrderActiveDetail_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(batchGetOrderActiveDetail_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.common.pojo.order.request.RequestHeader value;
					
					value = new com.vip.order.common.pojo.order.request.RequestHeader();
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Read(value, iprot);
					
					structs.SetRequestHeader(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.order.biz.request.BatchGetOrderActiveDetailReq value;
					
					value = new com.vip.order.biz.request.BatchGetOrderActiveDetailReq();
					com.vip.order.biz.request.BatchGetOrderActiveDetailReqHelper.getInstance().Read(value, iprot);
					
					structs.SetBatchGetOrderActiveDetailReq(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(batchGetOrderActiveDetail_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequestHeader() != null) {
					
					oprot.WriteFieldBegin("requestHeader");
					
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Write(structs.GetRequestHeader(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetBatchGetOrderActiveDetailReq() != null) {
					
					oprot.WriteFieldBegin("batchGetOrderActiveDetailReq");
					
					com.vip.order.biz.request.BatchGetOrderActiveDetailReqHelper.getInstance().Write(structs.GetBatchGetOrderActiveDetailReq(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(batchGetOrderActiveDetail_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class batchGetOrderList_argsHelper : TBeanSerializer<batchGetOrderList_args>
		{
			
			public static batchGetOrderList_argsHelper OBJ = new batchGetOrderList_argsHelper();
			
			public static batchGetOrderList_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(batchGetOrderList_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.common.pojo.order.request.RequestHeader value;
					
					value = new com.vip.order.common.pojo.order.request.RequestHeader();
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Read(value, iprot);
					
					structs.SetRequestHeader(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.order.biz.request.BatchGetOrderListReq value;
					
					value = new com.vip.order.biz.request.BatchGetOrderListReq();
					com.vip.order.biz.request.BatchGetOrderListReqHelper.getInstance().Read(value, iprot);
					
					structs.SetSearchOrderReq(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.order.common.pojo.order.request.ResultFilter value;
					
					value = new com.vip.order.common.pojo.order.request.ResultFilter();
					com.vip.order.common.pojo.order.request.ResultFilterHelper.getInstance().Read(value, iprot);
					
					structs.SetResultFilter(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(batchGetOrderList_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequestHeader() != null) {
					
					oprot.WriteFieldBegin("requestHeader");
					
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Write(structs.GetRequestHeader(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetSearchOrderReq() != null) {
					
					oprot.WriteFieldBegin("searchOrderReq");
					
					com.vip.order.biz.request.BatchGetOrderListReqHelper.getInstance().Write(structs.GetSearchOrderReq(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetResultFilter() != null) {
					
					oprot.WriteFieldBegin("resultFilter");
					
					com.vip.order.common.pojo.order.request.ResultFilterHelper.getInstance().Write(structs.GetResultFilter(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(batchGetOrderList_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class batchGetOrderTransportList_argsHelper : TBeanSerializer<batchGetOrderTransportList_args>
		{
			
			public static batchGetOrderTransportList_argsHelper OBJ = new batchGetOrderTransportList_argsHelper();
			
			public static batchGetOrderTransportList_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(batchGetOrderTransportList_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.common.pojo.order.request.RequestHeader value;
					
					value = new com.vip.order.common.pojo.order.request.RequestHeader();
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Read(value, iprot);
					
					structs.SetRequestHeader(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.order.biz.request.BatchGetOrderTransportListReq value;
					
					value = new com.vip.order.biz.request.BatchGetOrderTransportListReq();
					com.vip.order.biz.request.BatchGetOrderTransportListReqHelper.getInstance().Read(value, iprot);
					
					structs.SetBatchGetOrderTransportListReq(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.order.common.pojo.order.request.ResultFilter value;
					
					value = new com.vip.order.common.pojo.order.request.ResultFilter();
					com.vip.order.common.pojo.order.request.ResultFilterHelper.getInstance().Read(value, iprot);
					
					structs.SetResultFilter(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(batchGetOrderTransportList_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequestHeader() != null) {
					
					oprot.WriteFieldBegin("requestHeader");
					
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Write(structs.GetRequestHeader(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetBatchGetOrderTransportListReq() != null) {
					
					oprot.WriteFieldBegin("batchGetOrderTransportListReq");
					
					com.vip.order.biz.request.BatchGetOrderTransportListReqHelper.getInstance().Write(structs.GetBatchGetOrderTransportListReq(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetResultFilter() != null) {
					
					oprot.WriteFieldBegin("resultFilter");
					
					com.vip.order.common.pojo.order.request.ResultFilterHelper.getInstance().Write(structs.GetResultFilter(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(batchGetOrderTransportList_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class batchModifyOrderInvoice_argsHelper : TBeanSerializer<batchModifyOrderInvoice_args>
		{
			
			public static batchModifyOrderInvoice_argsHelper OBJ = new batchModifyOrderInvoice_argsHelper();
			
			public static batchModifyOrderInvoice_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(batchModifyOrderInvoice_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.common.pojo.order.request.RequestHeader value;
					
					value = new com.vip.order.common.pojo.order.request.RequestHeader();
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Read(value, iprot);
					
					structs.SetRequestHeader(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.order.biz.request.BatchModifyOrderInvoiceReq value;
					
					value = new com.vip.order.biz.request.BatchModifyOrderInvoiceReq();
					com.vip.order.biz.request.BatchModifyOrderInvoiceReqHelper.getInstance().Read(value, iprot);
					
					structs.SetBatchModifyOrderInvoiceReq(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(batchModifyOrderInvoice_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequestHeader() != null) {
					
					oprot.WriteFieldBegin("requestHeader");
					
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Write(structs.GetRequestHeader(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetBatchModifyOrderInvoiceReq() != null) {
					
					oprot.WriteFieldBegin("batchModifyOrderInvoiceReq");
					
					com.vip.order.biz.request.BatchModifyOrderInvoiceReqHelper.getInstance().Write(structs.GetBatchModifyOrderInvoiceReq(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(batchModifyOrderInvoice_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class batchUpdateWmsFlag_argsHelper : TBeanSerializer<batchUpdateWmsFlag_args>
		{
			
			public static batchUpdateWmsFlag_argsHelper OBJ = new batchUpdateWmsFlag_argsHelper();
			
			public static batchUpdateWmsFlag_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(batchUpdateWmsFlag_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.common.pojo.order.request.RequestHeader value;
					
					value = new com.vip.order.common.pojo.order.request.RequestHeader();
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Read(value, iprot);
					
					structs.SetRequestHeader(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.order.biz.request.BatchUpdateWmsFlagReq value;
					
					value = new com.vip.order.biz.request.BatchUpdateWmsFlagReq();
					com.vip.order.biz.request.BatchUpdateWmsFlagReqHelper.getInstance().Read(value, iprot);
					
					structs.SetBatchUpdateWmsFlagReq(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(batchUpdateWmsFlag_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequestHeader() != null) {
					
					oprot.WriteFieldBegin("requestHeader");
					
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Write(structs.GetRequestHeader(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetBatchUpdateWmsFlagReq() != null) {
					
					oprot.WriteFieldBegin("batchUpdateWmsFlagReq");
					
					com.vip.order.biz.request.BatchUpdateWmsFlagReqHelper.getInstance().Write(structs.GetBatchUpdateWmsFlagReq(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(batchUpdateWmsFlag_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class calculateSplitOrderMoney_argsHelper : TBeanSerializer<calculateSplitOrderMoney_args>
		{
			
			public static calculateSplitOrderMoney_argsHelper OBJ = new calculateSplitOrderMoney_argsHelper();
			
			public static calculateSplitOrderMoney_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(calculateSplitOrderMoney_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.common.pojo.order.request.RequestHeader value;
					
					value = new com.vip.order.common.pojo.order.request.RequestHeader();
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Read(value, iprot);
					
					structs.SetHeader(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.order.biz.request.CalculateSplitOrderMoneyReq value;
					
					value = new com.vip.order.biz.request.CalculateSplitOrderMoneyReq();
					com.vip.order.biz.request.CalculateSplitOrderMoneyReqHelper.getInstance().Read(value, iprot);
					
					structs.SetReq(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(calculateSplitOrderMoney_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetHeader() != null) {
					
					oprot.WriteFieldBegin("header");
					
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Write(structs.GetHeader(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetReq() != null) {
					
					oprot.WriteFieldBegin("req");
					
					com.vip.order.biz.request.CalculateSplitOrderMoneyReqHelper.getInstance().Write(structs.GetReq(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(calculateSplitOrderMoney_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class cancelOFixData_argsHelper : TBeanSerializer<cancelOFixData_args>
		{
			
			public static cancelOFixData_argsHelper OBJ = new cancelOFixData_argsHelper();
			
			public static cancelOFixData_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(cancelOFixData_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.common.pojo.order.request.RequestHeader value;
					
					value = new com.vip.order.common.pojo.order.request.RequestHeader();
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Read(value, iprot);
					
					structs.SetRequestHeader(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.order.biz.request.CancelOrderFixDataReq value;
					
					value = new com.vip.order.biz.request.CancelOrderFixDataReq();
					com.vip.order.biz.request.CancelOrderFixDataReqHelper.getInstance().Read(value, iprot);
					
					structs.SetCancelOrderFixDataReq(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(cancelOFixData_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequestHeader() != null) {
					
					oprot.WriteFieldBegin("requestHeader");
					
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Write(structs.GetRequestHeader(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetCancelOrderFixDataReq() != null) {
					
					oprot.WriteFieldBegin("cancelOrderFixDataReq");
					
					com.vip.order.biz.request.CancelOrderFixDataReqHelper.getInstance().Write(structs.GetCancelOrderFixDataReq(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(cancelOFixData_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class cancelOrder_argsHelper : TBeanSerializer<cancelOrder_args>
		{
			
			public static cancelOrder_argsHelper OBJ = new cancelOrder_argsHelper();
			
			public static cancelOrder_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(cancelOrder_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.common.pojo.order.request.RequestHeader value;
					
					value = new com.vip.order.common.pojo.order.request.RequestHeader();
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Read(value, iprot);
					
					structs.SetRequestHeader(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.order.biz.request.CancelOrderReq value;
					
					value = new com.vip.order.biz.request.CancelOrderReq();
					com.vip.order.biz.request.CancelOrderReqHelper.getInstance().Read(value, iprot);
					
					structs.SetReqParam(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.order.biz.request.CancelOrderPrivilegeReq value;
					
					value = new com.vip.order.biz.request.CancelOrderPrivilegeReq();
					com.vip.order.biz.request.CancelOrderPrivilegeReqHelper.getInstance().Read(value, iprot);
					
					structs.SetPrivParam(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(cancelOrder_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequestHeader() != null) {
					
					oprot.WriteFieldBegin("requestHeader");
					
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Write(structs.GetRequestHeader(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetReqParam() != null) {
					
					oprot.WriteFieldBegin("reqParam");
					
					com.vip.order.biz.request.CancelOrderReqHelper.getInstance().Write(structs.GetReqParam(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetPrivParam() != null) {
					
					oprot.WriteFieldBegin("privParam");
					
					com.vip.order.biz.request.CancelOrderPrivilegeReqHelper.getInstance().Write(structs.GetPrivParam(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(cancelOrder_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class cancelPresellOrder_argsHelper : TBeanSerializer<cancelPresellOrder_args>
		{
			
			public static cancelPresellOrder_argsHelper OBJ = new cancelPresellOrder_argsHelper();
			
			public static cancelPresellOrder_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(cancelPresellOrder_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.common.pojo.order.request.RequestHeader value;
					
					value = new com.vip.order.common.pojo.order.request.RequestHeader();
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Read(value, iprot);
					
					structs.SetRequestHeader(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.order.biz.request.CancelOrderReq value;
					
					value = new com.vip.order.biz.request.CancelOrderReq();
					com.vip.order.biz.request.CancelOrderReqHelper.getInstance().Read(value, iprot);
					
					structs.SetReqParam(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.order.biz.request.CancelOrderPrivilegeReq value;
					
					value = new com.vip.order.biz.request.CancelOrderPrivilegeReq();
					com.vip.order.biz.request.CancelOrderPrivilegeReqHelper.getInstance().Read(value, iprot);
					
					structs.SetPrivParam(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(cancelPresellOrder_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequestHeader() != null) {
					
					oprot.WriteFieldBegin("requestHeader");
					
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Write(structs.GetRequestHeader(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetReqParam() != null) {
					
					oprot.WriteFieldBegin("reqParam");
					
					com.vip.order.biz.request.CancelOrderReqHelper.getInstance().Write(structs.GetReqParam(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetPrivParam() != null) {
					
					oprot.WriteFieldBegin("privParam");
					
					com.vip.order.biz.request.CancelOrderPrivilegeReqHelper.getInstance().Write(structs.GetPrivParam(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(cancelPresellOrder_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class checkCashOnDelivery_argsHelper : TBeanSerializer<checkCashOnDelivery_args>
		{
			
			public static checkCashOnDelivery_argsHelper OBJ = new checkCashOnDelivery_argsHelper();
			
			public static checkCashOnDelivery_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(checkCashOnDelivery_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.common.pojo.order.request.RequestHeader value;
					
					value = new com.vip.order.common.pojo.order.request.RequestHeader();
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Read(value, iprot);
					
					structs.SetRequestHeader(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.order.biz.request.CheckCashOnDeliveryReq value;
					
					value = new com.vip.order.biz.request.CheckCashOnDeliveryReq();
					com.vip.order.biz.request.CheckCashOnDeliveryReqHelper.getInstance().Read(value, iprot);
					
					structs.SetCheckCashOnDeliveryReq(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(checkCashOnDelivery_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequestHeader() != null) {
					
					oprot.WriteFieldBegin("requestHeader");
					
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Write(structs.GetRequestHeader(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetCheckCashOnDeliveryReq() != null) {
					
					oprot.WriteFieldBegin("checkCashOnDeliveryReq");
					
					com.vip.order.biz.request.CheckCashOnDeliveryReqHelper.getInstance().Write(structs.GetCheckCashOnDeliveryReq(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(checkCashOnDelivery_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class checkDeliveryFetchExchange_argsHelper : TBeanSerializer<checkDeliveryFetchExchange_args>
		{
			
			public static checkDeliveryFetchExchange_argsHelper OBJ = new checkDeliveryFetchExchange_argsHelper();
			
			public static checkDeliveryFetchExchange_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(checkDeliveryFetchExchange_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.common.pojo.order.request.RequestHeader value;
					
					value = new com.vip.order.common.pojo.order.request.RequestHeader();
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Read(value, iprot);
					
					structs.SetRequestHeader(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.order.biz.request.CheckDeliveryFetchExchangeReq value;
					
					value = new com.vip.order.biz.request.CheckDeliveryFetchExchangeReq();
					com.vip.order.biz.request.CheckDeliveryFetchExchangeReqHelper.getInstance().Read(value, iprot);
					
					structs.SetCheckDeliveryFetchExchangeReq(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(checkDeliveryFetchExchange_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequestHeader() != null) {
					
					oprot.WriteFieldBegin("requestHeader");
					
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Write(structs.GetRequestHeader(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetCheckDeliveryFetchExchangeReq() != null) {
					
					oprot.WriteFieldBegin("checkDeliveryFetchExchangeReq");
					
					com.vip.order.biz.request.CheckDeliveryFetchExchangeReqHelper.getInstance().Write(structs.GetCheckDeliveryFetchExchangeReq(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(checkDeliveryFetchExchange_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class checkDeliveryFetchReturn_argsHelper : TBeanSerializer<checkDeliveryFetchReturn_args>
		{
			
			public static checkDeliveryFetchReturn_argsHelper OBJ = new checkDeliveryFetchReturn_argsHelper();
			
			public static checkDeliveryFetchReturn_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(checkDeliveryFetchReturn_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.common.pojo.order.request.RequestHeader value;
					
					value = new com.vip.order.common.pojo.order.request.RequestHeader();
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Read(value, iprot);
					
					structs.SetRequestHeader(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.order.biz.request.CheckDeliveryFetchReturnReq value;
					
					value = new com.vip.order.biz.request.CheckDeliveryFetchReturnReq();
					com.vip.order.biz.request.CheckDeliveryFetchReturnReqHelper.getInstance().Read(value, iprot);
					
					structs.SetCheckDeliveryFetchReturnReq(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(checkDeliveryFetchReturn_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequestHeader() != null) {
					
					oprot.WriteFieldBegin("requestHeader");
					
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Write(structs.GetRequestHeader(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetCheckDeliveryFetchReturnReq() != null) {
					
					oprot.WriteFieldBegin("checkDeliveryFetchReturnReq");
					
					com.vip.order.biz.request.CheckDeliveryFetchReturnReqHelper.getInstance().Write(structs.GetCheckDeliveryFetchReturnReq(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(checkDeliveryFetchReturn_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class checkOrderReturnVendorAudit_argsHelper : TBeanSerializer<checkOrderReturnVendorAudit_args>
		{
			
			public static checkOrderReturnVendorAudit_argsHelper OBJ = new checkOrderReturnVendorAudit_argsHelper();
			
			public static checkOrderReturnVendorAudit_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(checkOrderReturnVendorAudit_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.common.pojo.order.request.RequestHeader value;
					
					value = new com.vip.order.common.pojo.order.request.RequestHeader();
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Read(value, iprot);
					
					structs.SetRequestHeader(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.order.biz.request.CheckOrderReturnVendorAuditReq value;
					
					value = new com.vip.order.biz.request.CheckOrderReturnVendorAuditReq();
					com.vip.order.biz.request.CheckOrderReturnVendorAuditReqHelper.getInstance().Read(value, iprot);
					
					structs.SetCheckOrderReturnVendorAuditReq(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(checkOrderReturnVendorAudit_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequestHeader() != null) {
					
					oprot.WriteFieldBegin("requestHeader");
					
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Write(structs.GetRequestHeader(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetCheckOrderReturnVendorAuditReq() != null) {
					
					oprot.WriteFieldBegin("checkOrderReturnVendorAuditReq");
					
					com.vip.order.biz.request.CheckOrderReturnVendorAuditReqHelper.getInstance().Write(structs.GetCheckOrderReturnVendorAuditReq(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(checkOrderReturnVendorAudit_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class confirmDelivered_argsHelper : TBeanSerializer<confirmDelivered_args>
		{
			
			public static confirmDelivered_argsHelper OBJ = new confirmDelivered_argsHelper();
			
			public static confirmDelivered_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(confirmDelivered_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.common.pojo.order.request.RequestHeader value;
					
					value = new com.vip.order.common.pojo.order.request.RequestHeader();
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Read(value, iprot);
					
					structs.SetHeader(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.order.biz.request.ConfirmDeliveredReq value;
					
					value = new com.vip.order.biz.request.ConfirmDeliveredReq();
					com.vip.order.biz.request.ConfirmDeliveredReqHelper.getInstance().Read(value, iprot);
					
					structs.SetReq(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(confirmDelivered_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetHeader() != null) {
					
					oprot.WriteFieldBegin("header");
					
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Write(structs.GetHeader(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetReq() != null) {
					
					oprot.WriteFieldBegin("req");
					
					com.vip.order.biz.request.ConfirmDeliveredReqHelper.getInstance().Write(structs.GetReq(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(confirmDelivered_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class confirmOrderGroupBuyResult_argsHelper : TBeanSerializer<confirmOrderGroupBuyResult_args>
		{
			
			public static confirmOrderGroupBuyResult_argsHelper OBJ = new confirmOrderGroupBuyResult_argsHelper();
			
			public static confirmOrderGroupBuyResult_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(confirmOrderGroupBuyResult_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.common.pojo.order.request.RequestHeader value;
					
					value = new com.vip.order.common.pojo.order.request.RequestHeader();
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Read(value, iprot);
					
					structs.SetRequestHeader(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.order.biz.request.ConfirmOrderGroupBuyReq value;
					
					value = new com.vip.order.biz.request.ConfirmOrderGroupBuyReq();
					com.vip.order.biz.request.ConfirmOrderGroupBuyReqHelper.getInstance().Read(value, iprot);
					
					structs.SetReq(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(confirmOrderGroupBuyResult_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequestHeader() != null) {
					
					oprot.WriteFieldBegin("requestHeader");
					
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Write(structs.GetRequestHeader(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetReq() != null) {
					
					oprot.WriteFieldBegin("req");
					
					com.vip.order.biz.request.ConfirmOrderGroupBuyReqHelper.getInstance().Write(structs.GetReq(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(confirmOrderGroupBuyResult_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class createOrder_argsHelper : TBeanSerializer<createOrder_args>
		{
			
			public static createOrder_argsHelper OBJ = new createOrder_argsHelper();
			
			public static createOrder_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(createOrder_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.biz.request.RequestHeader value;
					
					value = new com.vip.order.biz.request.RequestHeader();
					com.vip.order.biz.request.RequestHeaderHelper.getInstance().Read(value, iprot);
					
					structs.SetRequestHeader(value);
				}
				
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetOrderCategory(value);
				}
				
				
				
				
				
				if(true){
					
					List<com.vip.order.biz.request.CreateOrderReq> value;
					
					value = new List<com.vip.order.biz.request.CreateOrderReq>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							com.vip.order.biz.request.CreateOrderReq elem1;
							
							elem1 = new com.vip.order.biz.request.CreateOrderReq();
							com.vip.order.biz.request.CreateOrderReqHelper.getInstance().Read(elem1, iprot);
							
							value.Add(elem1);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetCreateOrderParam(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(createOrder_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequestHeader() != null) {
					
					oprot.WriteFieldBegin("requestHeader");
					
					com.vip.order.biz.request.RequestHeaderHelper.getInstance().Write(structs.GetRequestHeader(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetOrderCategory() != null) {
					
					oprot.WriteFieldBegin("orderCategory");
					oprot.WriteI32((int)structs.GetOrderCategory()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("orderCategory can not be null!");
				}
				
				
				if(structs.GetCreateOrderParam() != null) {
					
					oprot.WriteFieldBegin("createOrderParam");
					
					oprot.WriteListBegin();
					foreach(com.vip.order.biz.request.CreateOrderReq _item0 in structs.GetCreateOrderParam()){
						
						
						com.vip.order.biz.request.CreateOrderReqHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(createOrder_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class createOrderElectronicInvoice_argsHelper : TBeanSerializer<createOrderElectronicInvoice_args>
		{
			
			public static createOrderElectronicInvoice_argsHelper OBJ = new createOrderElectronicInvoice_argsHelper();
			
			public static createOrderElectronicInvoice_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(createOrderElectronicInvoice_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.common.pojo.order.request.RequestHeader value;
					
					value = new com.vip.order.common.pojo.order.request.RequestHeader();
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Read(value, iprot);
					
					structs.SetRequestHeader(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.order.biz.request.CreateOrderElectronicInvoiceReq value;
					
					value = new com.vip.order.biz.request.CreateOrderElectronicInvoiceReq();
					com.vip.order.biz.request.CreateOrderElectronicInvoiceReqHelper.getInstance().Read(value, iprot);
					
					structs.SetCreateOrderElectronicInvoiceReq(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(createOrderElectronicInvoice_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequestHeader() != null) {
					
					oprot.WriteFieldBegin("requestHeader");
					
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Write(structs.GetRequestHeader(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetCreateOrderElectronicInvoiceReq() != null) {
					
					oprot.WriteFieldBegin("createOrderElectronicInvoiceReq");
					
					com.vip.order.biz.request.CreateOrderElectronicInvoiceReqHelper.getInstance().Write(structs.GetCreateOrderElectronicInvoiceReq(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(createOrderElectronicInvoice_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class createOrderPostProc_argsHelper : TBeanSerializer<createOrderPostProc_args>
		{
			
			public static createOrderPostProc_argsHelper OBJ = new createOrderPostProc_argsHelper();
			
			public static createOrderPostProc_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(createOrderPostProc_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.common.pojo.order.request.RequestHeader value;
					
					value = new com.vip.order.common.pojo.order.request.RequestHeader();
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Read(value, iprot);
					
					structs.SetRequestHeader(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.order.biz.request.CreateOrderPostProcReq value;
					
					value = new com.vip.order.biz.request.CreateOrderPostProcReq();
					com.vip.order.biz.request.CreateOrderPostProcReqHelper.getInstance().Read(value, iprot);
					
					structs.SetReq(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(createOrderPostProc_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequestHeader() != null) {
					
					oprot.WriteFieldBegin("requestHeader");
					
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Write(structs.GetRequestHeader(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetReq() != null) {
					
					oprot.WriteFieldBegin("req");
					
					com.vip.order.biz.request.CreateOrderPostProcReqHelper.getInstance().Write(structs.GetReq(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(createOrderPostProc_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class createOrderSnV2_argsHelper : TBeanSerializer<createOrderSnV2_args>
		{
			
			public static createOrderSnV2_argsHelper OBJ = new createOrderSnV2_argsHelper();
			
			public static createOrderSnV2_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(createOrderSnV2_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.common.pojo.order.request.RequestHeader value;
					
					value = new com.vip.order.common.pojo.order.request.RequestHeader();
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Read(value, iprot);
					
					structs.SetRequestHeader(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetWarehouse(value);
				}
				
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetNumber(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(createOrderSnV2_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequestHeader() != null) {
					
					oprot.WriteFieldBegin("requestHeader");
					
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Write(structs.GetRequestHeader(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetWarehouse() != null) {
					
					oprot.WriteFieldBegin("warehouse");
					oprot.WriteString(structs.GetWarehouse());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetNumber() != null) {
					
					oprot.WriteFieldBegin("number");
					oprot.WriteI32((int)structs.GetNumber()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("number can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(createOrderSnV2_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class createOrderSnV3_argsHelper : TBeanSerializer<createOrderSnV3_args>
		{
			
			public static createOrderSnV3_argsHelper OBJ = new createOrderSnV3_argsHelper();
			
			public static createOrderSnV3_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(createOrderSnV3_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.common.pojo.order.request.RequestHeader value;
					
					value = new com.vip.order.common.pojo.order.request.RequestHeader();
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Read(value, iprot);
					
					structs.SetRequestHeader(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.order.biz.request.CreateOrderSnReqV3 value;
					
					value = new com.vip.order.biz.request.CreateOrderSnReqV3();
					com.vip.order.biz.request.CreateOrderSnReqV3Helper.getInstance().Read(value, iprot);
					
					structs.SetReq(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(createOrderSnV3_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequestHeader() != null) {
					
					oprot.WriteFieldBegin("requestHeader");
					
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Write(structs.GetRequestHeader(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetReq() != null) {
					
					oprot.WriteFieldBegin("req");
					
					com.vip.order.biz.request.CreateOrderSnReqV3Helper.getInstance().Write(structs.GetReq(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(createOrderSnV3_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class createOrderV2_argsHelper : TBeanSerializer<createOrderV2_args>
		{
			
			public static createOrderV2_argsHelper OBJ = new createOrderV2_argsHelper();
			
			public static createOrderV2_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(createOrderV2_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.common.pojo.order.request.RequestHeader value;
					
					value = new com.vip.order.common.pojo.order.request.RequestHeader();
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Read(value, iprot);
					
					structs.SetRequestHeader(value);
				}
				
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetOrderCategory(value);
				}
				
				
				
				
				
				if(true){
					
					List<com.vip.order.biz.request.CreateOrderReqV2> value;
					
					value = new List<com.vip.order.biz.request.CreateOrderReqV2>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							com.vip.order.biz.request.CreateOrderReqV2 elem1;
							
							elem1 = new com.vip.order.biz.request.CreateOrderReqV2();
							com.vip.order.biz.request.CreateOrderReqV2Helper.getInstance().Read(elem1, iprot);
							
							value.Add(elem1);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetCreateOrderParam(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(createOrderV2_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequestHeader() != null) {
					
					oprot.WriteFieldBegin("requestHeader");
					
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Write(structs.GetRequestHeader(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetOrderCategory() != null) {
					
					oprot.WriteFieldBegin("orderCategory");
					oprot.WriteI32((int)structs.GetOrderCategory()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("orderCategory can not be null!");
				}
				
				
				if(structs.GetCreateOrderParam() != null) {
					
					oprot.WriteFieldBegin("createOrderParam");
					
					oprot.WriteListBegin();
					foreach(com.vip.order.biz.request.CreateOrderReqV2 _item0 in structs.GetCreateOrderParam()){
						
						
						com.vip.order.biz.request.CreateOrderReqV2Helper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(createOrderV2_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class createOrderV3_argsHelper : TBeanSerializer<createOrderV3_args>
		{
			
			public static createOrderV3_argsHelper OBJ = new createOrderV3_argsHelper();
			
			public static createOrderV3_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(createOrderV3_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.common.pojo.order.request.RequestHeader value;
					
					value = new com.vip.order.common.pojo.order.request.RequestHeader();
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Read(value, iprot);
					
					structs.SetRequestHeader(value);
				}
				
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetOrderCategory(value);
				}
				
				
				
				
				
				if(true){
					
					List<com.vip.order.biz.request.CreateOrderReqV3> value;
					
					value = new List<com.vip.order.biz.request.CreateOrderReqV3>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							com.vip.order.biz.request.CreateOrderReqV3 elem2;
							
							elem2 = new com.vip.order.biz.request.CreateOrderReqV3();
							com.vip.order.biz.request.CreateOrderReqV3Helper.getInstance().Read(elem2, iprot);
							
							value.Add(elem2);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetCreateOrderParam(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(createOrderV3_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequestHeader() != null) {
					
					oprot.WriteFieldBegin("requestHeader");
					
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Write(structs.GetRequestHeader(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetOrderCategory() != null) {
					
					oprot.WriteFieldBegin("orderCategory");
					oprot.WriteI32((int)structs.GetOrderCategory()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("orderCategory can not be null!");
				}
				
				
				if(structs.GetCreateOrderParam() != null) {
					
					oprot.WriteFieldBegin("createOrderParam");
					
					oprot.WriteListBegin();
					foreach(com.vip.order.biz.request.CreateOrderReqV3 _item0 in structs.GetCreateOrderParam()){
						
						
						com.vip.order.biz.request.CreateOrderReqV3Helper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(createOrderV3_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class cscCancelBack_argsHelper : TBeanSerializer<cscCancelBack_args>
		{
			
			public static cscCancelBack_argsHelper OBJ = new cscCancelBack_argsHelper();
			
			public static cscCancelBack_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(cscCancelBack_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.common.pojo.order.request.RequestHeader value;
					
					value = new com.vip.order.common.pojo.order.request.RequestHeader();
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Read(value, iprot);
					
					structs.SetHeader(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.order.biz.request.CSCCancelBackReq value;
					
					value = new com.vip.order.biz.request.CSCCancelBackReq();
					com.vip.order.biz.request.CSCCancelBackReqHelper.getInstance().Read(value, iprot);
					
					structs.SetReq(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(cscCancelBack_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetHeader() != null) {
					
					oprot.WriteFieldBegin("header");
					
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Write(structs.GetHeader(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetReq() != null) {
					
					oprot.WriteFieldBegin("req");
					
					com.vip.order.biz.request.CSCCancelBackReqHelper.getInstance().Write(structs.GetReq(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(cscCancelBack_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class displayOrder_argsHelper : TBeanSerializer<displayOrder_args>
		{
			
			public static displayOrder_argsHelper OBJ = new displayOrder_argsHelper();
			
			public static displayOrder_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(displayOrder_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.common.pojo.order.request.RequestHeader value;
					
					value = new com.vip.order.common.pojo.order.request.RequestHeader();
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Read(value, iprot);
					
					structs.SetRequestHeader(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.order.biz.request.DisplayOrderReq value;
					
					value = new com.vip.order.biz.request.DisplayOrderReq();
					com.vip.order.biz.request.DisplayOrderReqHelper.getInstance().Read(value, iprot);
					
					structs.SetReq(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(displayOrder_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequestHeader() != null) {
					
					oprot.WriteFieldBegin("requestHeader");
					
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Write(structs.GetRequestHeader(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetReq() != null) {
					
					oprot.WriteFieldBegin("req");
					
					com.vip.order.biz.request.DisplayOrderReqHelper.getInstance().Write(structs.GetReq(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(displayOrder_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getAfterSaleOpType_argsHelper : TBeanSerializer<getAfterSaleOpType_args>
		{
			
			public static getAfterSaleOpType_argsHelper OBJ = new getAfterSaleOpType_argsHelper();
			
			public static getAfterSaleOpType_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getAfterSaleOpType_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.common.pojo.order.request.RequestHeader value;
					
					value = new com.vip.order.common.pojo.order.request.RequestHeader();
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Read(value, iprot);
					
					structs.SetRequestHeader(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.order.biz.request.GetAfterSaleOpTypeReq value;
					
					value = new com.vip.order.biz.request.GetAfterSaleOpTypeReq();
					com.vip.order.biz.request.GetAfterSaleOpTypeReqHelper.getInstance().Read(value, iprot);
					
					structs.SetReq(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getAfterSaleOpType_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequestHeader() != null) {
					
					oprot.WriteFieldBegin("requestHeader");
					
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Write(structs.GetRequestHeader(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetReq() != null) {
					
					oprot.WriteFieldBegin("req");
					
					com.vip.order.biz.request.GetAfterSaleOpTypeReqHelper.getInstance().Write(structs.GetReq(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getAfterSaleOpType_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getCanAfterSaleOrderListByUserId_argsHelper : TBeanSerializer<getCanAfterSaleOrderListByUserId_args>
		{
			
			public static getCanAfterSaleOrderListByUserId_argsHelper OBJ = new getCanAfterSaleOrderListByUserId_argsHelper();
			
			public static getCanAfterSaleOrderListByUserId_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getCanAfterSaleOrderListByUserId_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.common.pojo.order.request.RequestHeader value;
					
					value = new com.vip.order.common.pojo.order.request.RequestHeader();
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Read(value, iprot);
					
					structs.SetHeader(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.order.biz.request.GetCanAfterSaleOrderListReq value;
					
					value = new com.vip.order.biz.request.GetCanAfterSaleOrderListReq();
					com.vip.order.biz.request.GetCanAfterSaleOrderListReqHelper.getInstance().Read(value, iprot);
					
					structs.SetReq(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.order.common.pojo.order.request.PageResultFilter value;
					
					value = new com.vip.order.common.pojo.order.request.PageResultFilter();
					com.vip.order.common.pojo.order.request.PageResultFilterHelper.getInstance().Read(value, iprot);
					
					structs.SetPageResultFilter(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getCanAfterSaleOrderListByUserId_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetHeader() != null) {
					
					oprot.WriteFieldBegin("header");
					
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Write(structs.GetHeader(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetReq() != null) {
					
					oprot.WriteFieldBegin("req");
					
					com.vip.order.biz.request.GetCanAfterSaleOrderListReqHelper.getInstance().Write(structs.GetReq(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetPageResultFilter() != null) {
					
					oprot.WriteFieldBegin("pageResultFilter");
					
					com.vip.order.common.pojo.order.request.PageResultFilterHelper.getInstance().Write(structs.GetPageResultFilter(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getCanAfterSaleOrderListByUserId_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getCanRefundOrderCount_argsHelper : TBeanSerializer<getCanRefundOrderCount_args>
		{
			
			public static getCanRefundOrderCount_argsHelper OBJ = new getCanRefundOrderCount_argsHelper();
			
			public static getCanRefundOrderCount_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getCanRefundOrderCount_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.common.pojo.order.request.RequestHeader value;
					
					value = new com.vip.order.common.pojo.order.request.RequestHeader();
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Read(value, iprot);
					
					structs.SetRequestHeader(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.order.biz.request.GetCanRefundOrderCountReq value;
					
					value = new com.vip.order.biz.request.GetCanRefundOrderCountReq();
					com.vip.order.biz.request.GetCanRefundOrderCountReqHelper.getInstance().Read(value, iprot);
					
					structs.SetGetCanRefundOrderCountReq(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getCanRefundOrderCount_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequestHeader() != null) {
					
					oprot.WriteFieldBegin("requestHeader");
					
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Write(structs.GetRequestHeader(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetGetCanRefundOrderCountReq() != null) {
					
					oprot.WriteFieldBegin("getCanRefundOrderCountReq");
					
					com.vip.order.biz.request.GetCanRefundOrderCountReqHelper.getInstance().Write(structs.GetGetCanRefundOrderCountReq(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getCanRefundOrderCount_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getCanRefundOrderList_argsHelper : TBeanSerializer<getCanRefundOrderList_args>
		{
			
			public static getCanRefundOrderList_argsHelper OBJ = new getCanRefundOrderList_argsHelper();
			
			public static getCanRefundOrderList_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getCanRefundOrderList_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.common.pojo.order.request.RequestHeader value;
					
					value = new com.vip.order.common.pojo.order.request.RequestHeader();
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Read(value, iprot);
					
					structs.SetRequestHeader(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.order.biz.request.GetCanRefundOrderListReq value;
					
					value = new com.vip.order.biz.request.GetCanRefundOrderListReq();
					com.vip.order.biz.request.GetCanRefundOrderListReqHelper.getInstance().Read(value, iprot);
					
					structs.SetGetCanRefundOrderListReq(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getCanRefundOrderList_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequestHeader() != null) {
					
					oprot.WriteFieldBegin("requestHeader");
					
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Write(structs.GetRequestHeader(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetGetCanRefundOrderListReq() != null) {
					
					oprot.WriteFieldBegin("getCanRefundOrderListReq");
					
					com.vip.order.biz.request.GetCanRefundOrderListReqHelper.getInstance().Write(structs.GetGetCanRefundOrderListReq(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getCanRefundOrderList_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getEbsGoodsList_argsHelper : TBeanSerializer<getEbsGoodsList_args>
		{
			
			public static getEbsGoodsList_argsHelper OBJ = new getEbsGoodsList_argsHelper();
			
			public static getEbsGoodsList_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getEbsGoodsList_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.common.pojo.order.request.RequestHeader value;
					
					value = new com.vip.order.common.pojo.order.request.RequestHeader();
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Read(value, iprot);
					
					structs.SetRequestHeader(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.order.biz.request.GetEbsGoodsListReq value;
					
					value = new com.vip.order.biz.request.GetEbsGoodsListReq();
					com.vip.order.biz.request.GetEbsGoodsListReqHelper.getInstance().Read(value, iprot);
					
					structs.SetGetEbsGoodsListReq(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getEbsGoodsList_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequestHeader() != null) {
					
					oprot.WriteFieldBegin("requestHeader");
					
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Write(structs.GetRequestHeader(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetGetEbsGoodsListReq() != null) {
					
					oprot.WriteFieldBegin("getEbsGoodsListReq");
					
					com.vip.order.biz.request.GetEbsGoodsListReqHelper.getInstance().Write(structs.GetGetEbsGoodsListReq(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getEbsGoodsList_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getGoodsDispatchWarehouse_argsHelper : TBeanSerializer<getGoodsDispatchWarehouse_args>
		{
			
			public static getGoodsDispatchWarehouse_argsHelper OBJ = new getGoodsDispatchWarehouse_argsHelper();
			
			public static getGoodsDispatchWarehouse_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getGoodsDispatchWarehouse_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.common.pojo.order.request.RequestHeader value;
					
					value = new com.vip.order.common.pojo.order.request.RequestHeader();
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Read(value, iprot);
					
					structs.SetRequestHeader(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.order.biz.request.GetGoodsDispatchWarehouseReq value;
					
					value = new com.vip.order.biz.request.GetGoodsDispatchWarehouseReq();
					com.vip.order.biz.request.GetGoodsDispatchWarehouseReqHelper.getInstance().Read(value, iprot);
					
					structs.SetReq(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getGoodsDispatchWarehouse_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequestHeader() != null) {
					
					oprot.WriteFieldBegin("requestHeader");
					
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Write(structs.GetRequestHeader(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetReq() != null) {
					
					oprot.WriteFieldBegin("req");
					
					com.vip.order.biz.request.GetGoodsDispatchWarehouseReqHelper.getInstance().Write(structs.GetReq(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getGoodsDispatchWarehouse_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getLimitedOrderGoodsCount_argsHelper : TBeanSerializer<getLimitedOrderGoodsCount_args>
		{
			
			public static getLimitedOrderGoodsCount_argsHelper OBJ = new getLimitedOrderGoodsCount_argsHelper();
			
			public static getLimitedOrderGoodsCount_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getLimitedOrderGoodsCount_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.common.pojo.order.request.RequestHeader value;
					
					value = new com.vip.order.common.pojo.order.request.RequestHeader();
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Read(value, iprot);
					
					structs.SetRequestHeader(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.order.biz.request.GetLimitedOrderGoodsCountReq value;
					
					value = new com.vip.order.biz.request.GetLimitedOrderGoodsCountReq();
					com.vip.order.biz.request.GetLimitedOrderGoodsCountReqHelper.getInstance().Read(value, iprot);
					
					structs.SetGetLimitedOrderGoodsCountReq(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getLimitedOrderGoodsCount_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequestHeader() != null) {
					
					oprot.WriteFieldBegin("requestHeader");
					
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Write(structs.GetRequestHeader(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetGetLimitedOrderGoodsCountReq() != null) {
					
					oprot.WriteFieldBegin("getLimitedOrderGoodsCountReq");
					
					com.vip.order.biz.request.GetLimitedOrderGoodsCountReqHelper.getInstance().Write(structs.GetGetLimitedOrderGoodsCountReq(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getLimitedOrderGoodsCount_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getLinkageOrders_argsHelper : TBeanSerializer<getLinkageOrders_args>
		{
			
			public static getLinkageOrders_argsHelper OBJ = new getLinkageOrders_argsHelper();
			
			public static getLinkageOrders_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getLinkageOrders_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.common.pojo.order.request.RequestHeader value;
					
					value = new com.vip.order.common.pojo.order.request.RequestHeader();
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Read(value, iprot);
					
					structs.SetRequestHeader(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.order.biz.request.SearchLinkageOrderReq value;
					
					value = new com.vip.order.biz.request.SearchLinkageOrderReq();
					com.vip.order.biz.request.SearchLinkageOrderReqHelper.getInstance().Read(value, iprot);
					
					structs.SetReq(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getLinkageOrders_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequestHeader() != null) {
					
					oprot.WriteFieldBegin("requestHeader");
					
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Write(structs.GetRequestHeader(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetReq() != null) {
					
					oprot.WriteFieldBegin("req");
					
					com.vip.order.biz.request.SearchLinkageOrderReqHelper.getInstance().Write(structs.GetReq(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getLinkageOrders_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getMergeOrderList_argsHelper : TBeanSerializer<getMergeOrderList_args>
		{
			
			public static getMergeOrderList_argsHelper OBJ = new getMergeOrderList_argsHelper();
			
			public static getMergeOrderList_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getMergeOrderList_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.common.pojo.order.request.RequestHeader value;
					
					value = new com.vip.order.common.pojo.order.request.RequestHeader();
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Read(value, iprot);
					
					structs.SetRequestHeader(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.order.biz.request.GetMergeOrderReq value;
					
					value = new com.vip.order.biz.request.GetMergeOrderReq();
					com.vip.order.biz.request.GetMergeOrderReqHelper.getInstance().Read(value, iprot);
					
					structs.SetGetMergeOrderReq(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getMergeOrderList_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequestHeader() != null) {
					
					oprot.WriteFieldBegin("requestHeader");
					
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Write(structs.GetRequestHeader(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetGetMergeOrderReq() != null) {
					
					oprot.WriteFieldBegin("getMergeOrderReq");
					
					com.vip.order.biz.request.GetMergeOrderReqHelper.getInstance().Write(structs.GetGetMergeOrderReq(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getMergeOrderList_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getOrderCounts_argsHelper : TBeanSerializer<getOrderCounts_args>
		{
			
			public static getOrderCounts_argsHelper OBJ = new getOrderCounts_argsHelper();
			
			public static getOrderCounts_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getOrderCounts_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.common.pojo.order.request.RequestHeader value;
					
					value = new com.vip.order.common.pojo.order.request.RequestHeader();
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Read(value, iprot);
					
					structs.SetRequestHeader(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.order.biz.request.SearchOrderReq value;
					
					value = new com.vip.order.biz.request.SearchOrderReq();
					com.vip.order.biz.request.SearchOrderReqHelper.getInstance().Read(value, iprot);
					
					structs.SetSearchOrderReq(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getOrderCounts_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequestHeader() != null) {
					
					oprot.WriteFieldBegin("requestHeader");
					
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Write(structs.GetRequestHeader(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetSearchOrderReq() != null) {
					
					oprot.WriteFieldBegin("searchOrderReq");
					
					com.vip.order.biz.request.SearchOrderReqHelper.getInstance().Write(structs.GetSearchOrderReq(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getOrderCounts_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getOrderCountsByUserId_argsHelper : TBeanSerializer<getOrderCountsByUserId_args>
		{
			
			public static getOrderCountsByUserId_argsHelper OBJ = new getOrderCountsByUserId_argsHelper();
			
			public static getOrderCountsByUserId_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getOrderCountsByUserId_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.common.pojo.order.request.RequestHeader value;
					
					value = new com.vip.order.common.pojo.order.request.RequestHeader();
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Read(value, iprot);
					
					structs.SetRequestHeader(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.order.biz.request.GetOrderByUserIdReq value;
					
					value = new com.vip.order.biz.request.GetOrderByUserIdReq();
					com.vip.order.biz.request.GetOrderByUserIdReqHelper.getInstance().Read(value, iprot);
					
					structs.SetGetOrderByUserIdReq(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getOrderCountsByUserId_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequestHeader() != null) {
					
					oprot.WriteFieldBegin("requestHeader");
					
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Write(structs.GetRequestHeader(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetGetOrderByUserIdReq() != null) {
					
					oprot.WriteFieldBegin("getOrderByUserIdReq");
					
					com.vip.order.biz.request.GetOrderByUserIdReqHelper.getInstance().Write(structs.GetGetOrderByUserIdReq(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getOrderCountsByUserId_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getOrderDeliveryBoxNum_argsHelper : TBeanSerializer<getOrderDeliveryBoxNum_args>
		{
			
			public static getOrderDeliveryBoxNum_argsHelper OBJ = new getOrderDeliveryBoxNum_argsHelper();
			
			public static getOrderDeliveryBoxNum_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getOrderDeliveryBoxNum_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.common.pojo.order.request.RequestHeader value;
					
					value = new com.vip.order.common.pojo.order.request.RequestHeader();
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Read(value, iprot);
					
					structs.SetRequestHeaderParam(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetOrderSn(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getOrderDeliveryBoxNum_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequestHeaderParam() != null) {
					
					oprot.WriteFieldBegin("requestHeaderParam");
					
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Write(structs.GetRequestHeaderParam(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetOrderSn() != null) {
					
					oprot.WriteFieldBegin("orderSn");
					oprot.WriteString(structs.GetOrderSn());
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getOrderDeliveryBoxNum_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getOrderDetail_argsHelper : TBeanSerializer<getOrderDetail_args>
		{
			
			public static getOrderDetail_argsHelper OBJ = new getOrderDetail_argsHelper();
			
			public static getOrderDetail_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getOrderDetail_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.common.pojo.order.request.RequestHeader value;
					
					value = new com.vip.order.common.pojo.order.request.RequestHeader();
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Read(value, iprot);
					
					structs.SetRequestHeader(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.order.biz.request.SearchOrderDetailReq value;
					
					value = new com.vip.order.biz.request.SearchOrderDetailReq();
					com.vip.order.biz.request.SearchOrderDetailReqHelper.getInstance().Read(value, iprot);
					
					structs.SetSearchOrderDetailReq(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getOrderDetail_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequestHeader() != null) {
					
					oprot.WriteFieldBegin("requestHeader");
					
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Write(structs.GetRequestHeader(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetSearchOrderDetailReq() != null) {
					
					oprot.WriteFieldBegin("searchOrderDetailReq");
					
					com.vip.order.biz.request.SearchOrderDetailReqHelper.getInstance().Write(structs.GetSearchOrderDetailReq(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getOrderDetail_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getOrderElectronicInvoicesV2_argsHelper : TBeanSerializer<getOrderElectronicInvoicesV2_args>
		{
			
			public static getOrderElectronicInvoicesV2_argsHelper OBJ = new getOrderElectronicInvoicesV2_argsHelper();
			
			public static getOrderElectronicInvoicesV2_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getOrderElectronicInvoicesV2_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.common.pojo.order.request.RequestHeader value;
					
					value = new com.vip.order.common.pojo.order.request.RequestHeader();
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Read(value, iprot);
					
					structs.SetRequestHeaderParam(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.order.biz.request.SearchOrderElectronicInvoicesReq value;
					
					value = new com.vip.order.biz.request.SearchOrderElectronicInvoicesReq();
					com.vip.order.biz.request.SearchOrderElectronicInvoicesReqHelper.getInstance().Read(value, iprot);
					
					structs.SetSearchOrderElectronicInvoiceParam(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.order.biz.request.ResultRequirement value;
					
					value = new com.vip.order.biz.request.ResultRequirement();
					com.vip.order.biz.request.ResultRequirementHelper.getInstance().Read(value, iprot);
					
					structs.SetResultRequirement(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getOrderElectronicInvoicesV2_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequestHeaderParam() != null) {
					
					oprot.WriteFieldBegin("requestHeaderParam");
					
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Write(structs.GetRequestHeaderParam(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetSearchOrderElectronicInvoiceParam() != null) {
					
					oprot.WriteFieldBegin("searchOrderElectronicInvoiceParam");
					
					com.vip.order.biz.request.SearchOrderElectronicInvoicesReqHelper.getInstance().Write(structs.GetSearchOrderElectronicInvoiceParam(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetResultRequirement() != null) {
					
					oprot.WriteFieldBegin("resultRequirement");
					
					com.vip.order.biz.request.ResultRequirementHelper.getInstance().Write(structs.GetResultRequirement(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getOrderElectronicInvoicesV2_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getOrderFav_argsHelper : TBeanSerializer<getOrderFav_args>
		{
			
			public static getOrderFav_argsHelper OBJ = new getOrderFav_argsHelper();
			
			public static getOrderFav_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getOrderFav_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.common.pojo.order.request.RequestHeader value;
					
					value = new com.vip.order.common.pojo.order.request.RequestHeader();
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Read(value, iprot);
					
					structs.SetRequestHeader(value);
				}
				
				
				
				
				
				if(true){
					
					List<string> value;
					
					value = new List<string>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							string elem1;
							elem1 = iprot.ReadString();
							
							value.Add(elem1);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetOrderSnList(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getOrderFav_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequestHeader() != null) {
					
					oprot.WriteFieldBegin("requestHeader");
					
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Write(structs.GetRequestHeader(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetOrderSnList() != null) {
					
					oprot.WriteFieldBegin("orderSnList");
					
					oprot.WriteListBegin();
					foreach(string _item0 in structs.GetOrderSnList()){
						
						oprot.WriteString(_item0);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getOrderFav_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getOrderGoodsCount_argsHelper : TBeanSerializer<getOrderGoodsCount_args>
		{
			
			public static getOrderGoodsCount_argsHelper OBJ = new getOrderGoodsCount_argsHelper();
			
			public static getOrderGoodsCount_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getOrderGoodsCount_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.common.pojo.order.request.RequestHeader value;
					
					value = new com.vip.order.common.pojo.order.request.RequestHeader();
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Read(value, iprot);
					
					structs.SetRequestHeaderParam(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.order.biz.request.GetOrderGoodsReq value;
					
					value = new com.vip.order.biz.request.GetOrderGoodsReq();
					com.vip.order.biz.request.GetOrderGoodsReqHelper.getInstance().Read(value, iprot);
					
					structs.SetGetOrderGoodsParam(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getOrderGoodsCount_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequestHeaderParam() != null) {
					
					oprot.WriteFieldBegin("requestHeaderParam");
					
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Write(structs.GetRequestHeaderParam(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetGetOrderGoodsParam() != null) {
					
					oprot.WriteFieldBegin("getOrderGoodsParam");
					
					com.vip.order.biz.request.GetOrderGoodsReqHelper.getInstance().Write(structs.GetGetOrderGoodsParam(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getOrderGoodsCount_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getOrderGoodsList_argsHelper : TBeanSerializer<getOrderGoodsList_args>
		{
			
			public static getOrderGoodsList_argsHelper OBJ = new getOrderGoodsList_argsHelper();
			
			public static getOrderGoodsList_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getOrderGoodsList_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.common.pojo.order.request.RequestHeader value;
					
					value = new com.vip.order.common.pojo.order.request.RequestHeader();
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Read(value, iprot);
					
					structs.SetRequestHeaderParam(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.order.biz.request.GetOrderGoodsReq value;
					
					value = new com.vip.order.biz.request.GetOrderGoodsReq();
					com.vip.order.biz.request.GetOrderGoodsReqHelper.getInstance().Read(value, iprot);
					
					structs.SetGetOrderGoodsParam(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.order.common.pojo.order.request.ResultFilter value;
					
					value = new com.vip.order.common.pojo.order.request.ResultFilter();
					com.vip.order.common.pojo.order.request.ResultFilterHelper.getInstance().Read(value, iprot);
					
					structs.SetResultFilter(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getOrderGoodsList_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequestHeaderParam() != null) {
					
					oprot.WriteFieldBegin("requestHeaderParam");
					
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Write(structs.GetRequestHeaderParam(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetGetOrderGoodsParam() != null) {
					
					oprot.WriteFieldBegin("getOrderGoodsParam");
					
					com.vip.order.biz.request.GetOrderGoodsReqHelper.getInstance().Write(structs.GetGetOrderGoodsParam(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetResultFilter() != null) {
					
					oprot.WriteFieldBegin("resultFilter");
					
					com.vip.order.common.pojo.order.request.ResultFilterHelper.getInstance().Write(structs.GetResultFilter(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getOrderGoodsList_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getOrderInstalmentsList_argsHelper : TBeanSerializer<getOrderInstalmentsList_args>
		{
			
			public static getOrderInstalmentsList_argsHelper OBJ = new getOrderInstalmentsList_argsHelper();
			
			public static getOrderInstalmentsList_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getOrderInstalmentsList_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.common.pojo.order.request.RequestHeader value;
					
					value = new com.vip.order.common.pojo.order.request.RequestHeader();
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Read(value, iprot);
					
					structs.SetRequestHeader(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.order.biz.request.GetOrderInstalmentsReq value;
					
					value = new com.vip.order.biz.request.GetOrderInstalmentsReq();
					com.vip.order.biz.request.GetOrderInstalmentsReqHelper.getInstance().Read(value, iprot);
					
					structs.SetReq(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.order.common.pojo.order.request.ResultFilter value;
					
					value = new com.vip.order.common.pojo.order.request.ResultFilter();
					com.vip.order.common.pojo.order.request.ResultFilterHelper.getInstance().Read(value, iprot);
					
					structs.SetFilter(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getOrderInstalmentsList_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequestHeader() != null) {
					
					oprot.WriteFieldBegin("requestHeader");
					
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Write(structs.GetRequestHeader(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetReq() != null) {
					
					oprot.WriteFieldBegin("req");
					
					com.vip.order.biz.request.GetOrderInstalmentsReqHelper.getInstance().Write(structs.GetReq(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetFilter() != null) {
					
					oprot.WriteFieldBegin("filter");
					
					com.vip.order.common.pojo.order.request.ResultFilterHelper.getInstance().Write(structs.GetFilter(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getOrderInstalmentsList_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getOrderInvoicesV2_argsHelper : TBeanSerializer<getOrderInvoicesV2_args>
		{
			
			public static getOrderInvoicesV2_argsHelper OBJ = new getOrderInvoicesV2_argsHelper();
			
			public static getOrderInvoicesV2_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getOrderInvoicesV2_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.common.pojo.order.request.RequestHeader value;
					
					value = new com.vip.order.common.pojo.order.request.RequestHeader();
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Read(value, iprot);
					
					structs.SetRequestHeaderParam(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.order.biz.request.SearchOrderInvoicesReq value;
					
					value = new com.vip.order.biz.request.SearchOrderInvoicesReq();
					com.vip.order.biz.request.SearchOrderInvoicesReqHelper.getInstance().Read(value, iprot);
					
					structs.SetSearchOrderInvoiceParam(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getOrderInvoicesV2_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequestHeaderParam() != null) {
					
					oprot.WriteFieldBegin("requestHeaderParam");
					
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Write(structs.GetRequestHeaderParam(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetSearchOrderInvoiceParam() != null) {
					
					oprot.WriteFieldBegin("searchOrderInvoiceParam");
					
					com.vip.order.biz.request.SearchOrderInvoicesReqHelper.getInstance().Write(structs.GetSearchOrderInvoiceParam(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getOrderInvoicesV2_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getOrderList_argsHelper : TBeanSerializer<getOrderList_args>
		{
			
			public static getOrderList_argsHelper OBJ = new getOrderList_argsHelper();
			
			public static getOrderList_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getOrderList_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.common.pojo.order.request.RequestHeader value;
					
					value = new com.vip.order.common.pojo.order.request.RequestHeader();
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Read(value, iprot);
					
					structs.SetRequestHeader(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.order.biz.request.SearchOrderReq value;
					
					value = new com.vip.order.biz.request.SearchOrderReq();
					com.vip.order.biz.request.SearchOrderReqHelper.getInstance().Read(value, iprot);
					
					structs.SetSearchOrderReq(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.order.common.pojo.order.request.ResultFilter value;
					
					value = new com.vip.order.common.pojo.order.request.ResultFilter();
					com.vip.order.common.pojo.order.request.ResultFilterHelper.getInstance().Read(value, iprot);
					
					structs.SetResultFilter(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getOrderList_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequestHeader() != null) {
					
					oprot.WriteFieldBegin("requestHeader");
					
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Write(structs.GetRequestHeader(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetSearchOrderReq() != null) {
					
					oprot.WriteFieldBegin("searchOrderReq");
					
					com.vip.order.biz.request.SearchOrderReqHelper.getInstance().Write(structs.GetSearchOrderReq(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetResultFilter() != null) {
					
					oprot.WriteFieldBegin("resultFilter");
					
					com.vip.order.common.pojo.order.request.ResultFilterHelper.getInstance().Write(structs.GetResultFilter(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getOrderList_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getOrderListByPosNo_argsHelper : TBeanSerializer<getOrderListByPosNo_args>
		{
			
			public static getOrderListByPosNo_argsHelper OBJ = new getOrderListByPosNo_argsHelper();
			
			public static getOrderListByPosNo_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getOrderListByPosNo_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.common.pojo.order.request.RequestHeader value;
					
					value = new com.vip.order.common.pojo.order.request.RequestHeader();
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Read(value, iprot);
					
					structs.SetRequestHeader(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.order.biz.request.GetOrderListByPosNoReq value;
					
					value = new com.vip.order.biz.request.GetOrderListByPosNoReq();
					com.vip.order.biz.request.GetOrderListByPosNoReqHelper.getInstance().Read(value, iprot);
					
					structs.SetReq(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getOrderListByPosNo_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequestHeader() != null) {
					
					oprot.WriteFieldBegin("requestHeader");
					
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Write(structs.GetRequestHeader(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetReq() != null) {
					
					oprot.WriteFieldBegin("req");
					
					com.vip.order.biz.request.GetOrderListByPosNoReqHelper.getInstance().Write(structs.GetReq(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getOrderListByPosNo_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getOrderListByUserId_argsHelper : TBeanSerializer<getOrderListByUserId_args>
		{
			
			public static getOrderListByUserId_argsHelper OBJ = new getOrderListByUserId_argsHelper();
			
			public static getOrderListByUserId_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getOrderListByUserId_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.common.pojo.order.request.RequestHeader value;
					
					value = new com.vip.order.common.pojo.order.request.RequestHeader();
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Read(value, iprot);
					
					structs.SetRequestHeader(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.order.biz.request.GetOrderByUserIdReq value;
					
					value = new com.vip.order.biz.request.GetOrderByUserIdReq();
					com.vip.order.biz.request.GetOrderByUserIdReqHelper.getInstance().Read(value, iprot);
					
					structs.SetGetOrderByUserIdReq(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.order.common.pojo.order.request.ResultFilter value;
					
					value = new com.vip.order.common.pojo.order.request.ResultFilter();
					com.vip.order.common.pojo.order.request.ResultFilterHelper.getInstance().Read(value, iprot);
					
					structs.SetResultFilter(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getOrderListByUserId_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequestHeader() != null) {
					
					oprot.WriteFieldBegin("requestHeader");
					
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Write(structs.GetRequestHeader(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetGetOrderByUserIdReq() != null) {
					
					oprot.WriteFieldBegin("getOrderByUserIdReq");
					
					com.vip.order.biz.request.GetOrderByUserIdReqHelper.getInstance().Write(structs.GetGetOrderByUserIdReq(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetResultFilter() != null) {
					
					oprot.WriteFieldBegin("resultFilter");
					
					com.vip.order.common.pojo.order.request.ResultFilterHelper.getInstance().Write(structs.GetResultFilter(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getOrderListByUserId_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getOrderLogs_argsHelper : TBeanSerializer<getOrderLogs_args>
		{
			
			public static getOrderLogs_argsHelper OBJ = new getOrderLogs_argsHelper();
			
			public static getOrderLogs_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getOrderLogs_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.common.pojo.order.request.RequestHeader value;
					
					value = new com.vip.order.common.pojo.order.request.RequestHeader();
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Read(value, iprot);
					
					structs.SetRequestHeaderParam(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.order.biz.request.SearchOrderLogsReq value;
					
					value = new com.vip.order.biz.request.SearchOrderLogsReq();
					com.vip.order.biz.request.SearchOrderLogsReqHelper.getInstance().Read(value, iprot);
					
					structs.SetSearchOrderLogsParam(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.order.biz.request.requirement.GetOrderLogsRequirement value;
					
					value = new com.vip.order.biz.request.requirement.GetOrderLogsRequirement();
					com.vip.order.biz.request.requirement.GetOrderLogsRequirementHelper.getInstance().Read(value, iprot);
					
					structs.SetGetOrderLogsRequirement(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getOrderLogs_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequestHeaderParam() != null) {
					
					oprot.WriteFieldBegin("requestHeaderParam");
					
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Write(structs.GetRequestHeaderParam(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetSearchOrderLogsParam() != null) {
					
					oprot.WriteFieldBegin("searchOrderLogsParam");
					
					com.vip.order.biz.request.SearchOrderLogsReqHelper.getInstance().Write(structs.GetSearchOrderLogsParam(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetGetOrderLogsRequirement() != null) {
					
					oprot.WriteFieldBegin("getOrderLogsRequirement");
					
					com.vip.order.biz.request.requirement.GetOrderLogsRequirementHelper.getInstance().Write(structs.GetGetOrderLogsRequirement(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getOrderLogs_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getOrderOpStatus_argsHelper : TBeanSerializer<getOrderOpStatus_args>
		{
			
			public static getOrderOpStatus_argsHelper OBJ = new getOrderOpStatus_argsHelper();
			
			public static getOrderOpStatus_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getOrderOpStatus_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.common.pojo.order.request.RequestHeader value;
					
					value = new com.vip.order.common.pojo.order.request.RequestHeader();
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Read(value, iprot);
					
					structs.SetRequestHeader(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.order.biz.request.GetOrderOpStatusReq value;
					
					value = new com.vip.order.biz.request.GetOrderOpStatusReq();
					com.vip.order.biz.request.GetOrderOpStatusReqHelper.getInstance().Read(value, iprot);
					
					structs.SetGetOrderOpStatusReq(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getOrderOpStatus_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequestHeader() != null) {
					
					oprot.WriteFieldBegin("requestHeader");
					
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Write(structs.GetRequestHeader(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetGetOrderOpStatusReq() != null) {
					
					oprot.WriteFieldBegin("getOrderOpStatusReq");
					
					com.vip.order.biz.request.GetOrderOpStatusReqHelper.getInstance().Write(structs.GetGetOrderOpStatusReq(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getOrderOpStatus_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getOrderPackageList_argsHelper : TBeanSerializer<getOrderPackageList_args>
		{
			
			public static getOrderPackageList_argsHelper OBJ = new getOrderPackageList_argsHelper();
			
			public static getOrderPackageList_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getOrderPackageList_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.common.pojo.order.request.RequestHeader value;
					
					value = new com.vip.order.common.pojo.order.request.RequestHeader();
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Read(value, iprot);
					
					structs.SetRequestHeader(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.order.biz.request.GetOrderPackageListReq value;
					
					value = new com.vip.order.biz.request.GetOrderPackageListReq();
					com.vip.order.biz.request.GetOrderPackageListReqHelper.getInstance().Read(value, iprot);
					
					structs.SetGetPackageListReq(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getOrderPackageList_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequestHeader() != null) {
					
					oprot.WriteFieldBegin("requestHeader");
					
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Write(structs.GetRequestHeader(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetGetPackageListReq() != null) {
					
					oprot.WriteFieldBegin("getPackageListReq");
					
					com.vip.order.biz.request.GetOrderPackageListReqHelper.getInstance().Write(structs.GetGetPackageListReq(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getOrderPackageList_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getOrderPayType_argsHelper : TBeanSerializer<getOrderPayType_args>
		{
			
			public static getOrderPayType_argsHelper OBJ = new getOrderPayType_argsHelper();
			
			public static getOrderPayType_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getOrderPayType_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.common.pojo.order.request.RequestHeader value;
					
					value = new com.vip.order.common.pojo.order.request.RequestHeader();
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Read(value, iprot);
					
					structs.SetRequestHeader(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.order.biz.request.GetOrderPayTypeReq value;
					
					value = new com.vip.order.biz.request.GetOrderPayTypeReq();
					com.vip.order.biz.request.GetOrderPayTypeReqHelper.getInstance().Read(value, iprot);
					
					structs.SetGetOrderPayTypeParam(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.order.common.pojo.order.request.ResultFilter value;
					
					value = new com.vip.order.common.pojo.order.request.ResultFilter();
					com.vip.order.common.pojo.order.request.ResultFilterHelper.getInstance().Read(value, iprot);
					
					structs.SetResultFilter(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getOrderPayType_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequestHeader() != null) {
					
					oprot.WriteFieldBegin("requestHeader");
					
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Write(structs.GetRequestHeader(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetGetOrderPayTypeParam() != null) {
					
					oprot.WriteFieldBegin("getOrderPayTypeParam");
					
					com.vip.order.biz.request.GetOrderPayTypeReqHelper.getInstance().Write(structs.GetGetOrderPayTypeParam(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetResultFilter() != null) {
					
					oprot.WriteFieldBegin("resultFilter");
					
					com.vip.order.common.pojo.order.request.ResultFilterHelper.getInstance().Write(structs.GetResultFilter(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getOrderPayType_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getOrderSnByExOrderSn_argsHelper : TBeanSerializer<getOrderSnByExOrderSn_args>
		{
			
			public static getOrderSnByExOrderSn_argsHelper OBJ = new getOrderSnByExOrderSn_argsHelper();
			
			public static getOrderSnByExOrderSn_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getOrderSnByExOrderSn_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.common.pojo.order.request.RequestHeader value;
					
					value = new com.vip.order.common.pojo.order.request.RequestHeader();
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Read(value, iprot);
					
					structs.SetRequestHeader(value);
				}
				
				
				
				
				
				if(true){
					
					List<string> value;
					
					value = new List<string>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							string elem1;
							elem1 = iprot.ReadString();
							
							value.Add(elem1);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetExOrderSns(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getOrderSnByExOrderSn_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequestHeader() != null) {
					
					oprot.WriteFieldBegin("requestHeader");
					
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Write(structs.GetRequestHeader(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetExOrderSns() != null) {
					
					oprot.WriteFieldBegin("exOrderSns");
					
					oprot.WriteListBegin();
					foreach(string _item0 in structs.GetExOrderSns()){
						
						oprot.WriteString(_item0);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getOrderSnByExOrderSn_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getOrderTransport_argsHelper : TBeanSerializer<getOrderTransport_args>
		{
			
			public static getOrderTransport_argsHelper OBJ = new getOrderTransport_argsHelper();
			
			public static getOrderTransport_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getOrderTransport_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.common.pojo.order.request.RequestHeader value;
					
					value = new com.vip.order.common.pojo.order.request.RequestHeader();
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Read(value, iprot);
					
					structs.SetRequestHeader(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.order.biz.request.GetOrderTransportReq value;
					
					value = new com.vip.order.biz.request.GetOrderTransportReq();
					com.vip.order.biz.request.GetOrderTransportReqHelper.getInstance().Read(value, iprot);
					
					structs.SetGetOrderTransportReq(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getOrderTransport_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequestHeader() != null) {
					
					oprot.WriteFieldBegin("requestHeader");
					
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Write(structs.GetRequestHeader(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetGetOrderTransportReq() != null) {
					
					oprot.WriteFieldBegin("getOrderTransportReq");
					
					com.vip.order.biz.request.GetOrderTransportReqHelper.getInstance().Write(structs.GetGetOrderTransportReq(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getOrderTransport_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getOrderTransportDetail_argsHelper : TBeanSerializer<getOrderTransportDetail_args>
		{
			
			public static getOrderTransportDetail_argsHelper OBJ = new getOrderTransportDetail_argsHelper();
			
			public static getOrderTransportDetail_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getOrderTransportDetail_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.common.pojo.order.request.RequestHeader value;
					
					value = new com.vip.order.common.pojo.order.request.RequestHeader();
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Read(value, iprot);
					
					structs.SetRequestHeader(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.order.biz.request.GetOrderTransportDetailReq value;
					
					value = new com.vip.order.biz.request.GetOrderTransportDetailReq();
					com.vip.order.biz.request.GetOrderTransportDetailReqHelper.getInstance().Read(value, iprot);
					
					structs.SetGetOrderTransportDetailReq(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getOrderTransportDetail_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequestHeader() != null) {
					
					oprot.WriteFieldBegin("requestHeader");
					
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Write(structs.GetRequestHeader(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetGetOrderTransportDetailReq() != null) {
					
					oprot.WriteFieldBegin("getOrderTransportDetailReq");
					
					com.vip.order.biz.request.GetOrderTransportDetailReqHelper.getInstance().Write(structs.GetGetOrderTransportDetailReq(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getOrderTransportDetail_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getOrderTransportListByCodes_argsHelper : TBeanSerializer<getOrderTransportListByCodes_args>
		{
			
			public static getOrderTransportListByCodes_argsHelper OBJ = new getOrderTransportListByCodes_argsHelper();
			
			public static getOrderTransportListByCodes_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getOrderTransportListByCodes_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.common.pojo.order.request.RequestHeader value;
					
					value = new com.vip.order.common.pojo.order.request.RequestHeader();
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Read(value, iprot);
					
					structs.SetRequestHeaderParam(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.order.biz.request.GetTransportListByCodesReq value;
					
					value = new com.vip.order.biz.request.GetTransportListByCodesReq();
					com.vip.order.biz.request.GetTransportListByCodesReqHelper.getInstance().Read(value, iprot);
					
					structs.SetGetTransportListByCodesParam(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getOrderTransportListByCodes_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequestHeaderParam() != null) {
					
					oprot.WriteFieldBegin("requestHeaderParam");
					
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Write(structs.GetRequestHeaderParam(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetGetTransportListByCodesParam() != null) {
					
					oprot.WriteFieldBegin("getTransportListByCodesParam");
					
					com.vip.order.biz.request.GetTransportListByCodesReqHelper.getInstance().Write(structs.GetGetTransportListByCodesParam(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getOrderTransportListByCodes_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getOrdersBySizeId_argsHelper : TBeanSerializer<getOrdersBySizeId_args>
		{
			
			public static getOrdersBySizeId_argsHelper OBJ = new getOrdersBySizeId_argsHelper();
			
			public static getOrdersBySizeId_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getOrdersBySizeId_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.common.pojo.order.request.RequestHeader value;
					
					value = new com.vip.order.common.pojo.order.request.RequestHeader();
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Read(value, iprot);
					
					structs.SetRequestHeader(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.order.biz.request.GetOrdersBySizeIdReq value;
					
					value = new com.vip.order.biz.request.GetOrdersBySizeIdReq();
					com.vip.order.biz.request.GetOrdersBySizeIdReqHelper.getInstance().Read(value, iprot);
					
					structs.SetReq(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.order.common.pojo.order.request.ResultFilter value;
					
					value = new com.vip.order.common.pojo.order.request.ResultFilter();
					com.vip.order.common.pojo.order.request.ResultFilterHelper.getInstance().Read(value, iprot);
					
					structs.SetFilter(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getOrdersBySizeId_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequestHeader() != null) {
					
					oprot.WriteFieldBegin("requestHeader");
					
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Write(structs.GetRequestHeader(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetReq() != null) {
					
					oprot.WriteFieldBegin("req");
					
					com.vip.order.biz.request.GetOrdersBySizeIdReqHelper.getInstance().Write(structs.GetReq(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetFilter() != null) {
					
					oprot.WriteFieldBegin("filter");
					
					com.vip.order.common.pojo.order.request.ResultFilterHelper.getInstance().Write(structs.GetFilter(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getOrdersBySizeId_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getPrepayOrderStatus_argsHelper : TBeanSerializer<getPrepayOrderStatus_args>
		{
			
			public static getPrepayOrderStatus_argsHelper OBJ = new getPrepayOrderStatus_argsHelper();
			
			public static getPrepayOrderStatus_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getPrepayOrderStatus_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.common.pojo.order.request.RequestHeader value;
					
					value = new com.vip.order.common.pojo.order.request.RequestHeader();
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Read(value, iprot);
					
					structs.SetRequestHeader(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.order.biz.request.GetPrepayOrderStatusReq value;
					
					value = new com.vip.order.biz.request.GetPrepayOrderStatusReq();
					com.vip.order.biz.request.GetPrepayOrderStatusReqHelper.getInstance().Read(value, iprot);
					
					structs.SetReq(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getPrepayOrderStatus_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequestHeader() != null) {
					
					oprot.WriteFieldBegin("requestHeader");
					
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Write(structs.GetRequestHeader(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetReq() != null) {
					
					oprot.WriteFieldBegin("req");
					
					com.vip.order.biz.request.GetPrepayOrderStatusReqHelper.getInstance().Write(structs.GetReq(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getPrepayOrderStatus_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getPrepayOrderUnpayMsg_argsHelper : TBeanSerializer<getPrepayOrderUnpayMsg_args>
		{
			
			public static getPrepayOrderUnpayMsg_argsHelper OBJ = new getPrepayOrderUnpayMsg_argsHelper();
			
			public static getPrepayOrderUnpayMsg_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getPrepayOrderUnpayMsg_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.common.pojo.order.request.RequestHeader value;
					
					value = new com.vip.order.common.pojo.order.request.RequestHeader();
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Read(value, iprot);
					
					structs.SetHeader(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.order.biz.request.GetPrepayOrderUnpayMsgReq value;
					
					value = new com.vip.order.biz.request.GetPrepayOrderUnpayMsgReq();
					com.vip.order.biz.request.GetPrepayOrderUnpayMsgReqHelper.getInstance().Read(value, iprot);
					
					structs.SetReq(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getPrepayOrderUnpayMsg_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetHeader() != null) {
					
					oprot.WriteFieldBegin("header");
					
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Write(structs.GetHeader(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetReq() != null) {
					
					oprot.WriteFieldBegin("req");
					
					com.vip.order.biz.request.GetPrepayOrderUnpayMsgReqHelper.getInstance().Write(structs.GetReq(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getPrepayOrderUnpayMsg_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getRdc_argsHelper : TBeanSerializer<getRdc_args>
		{
			
			public static getRdc_argsHelper OBJ = new getRdc_argsHelper();
			
			public static getRdc_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getRdc_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.common.pojo.order.request.RequestHeader value;
					
					value = new com.vip.order.common.pojo.order.request.RequestHeader();
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Read(value, iprot);
					
					structs.SetRequestHeader(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.order.biz.request.GetRdcReq value;
					
					value = new com.vip.order.biz.request.GetRdcReq();
					com.vip.order.biz.request.GetRdcReqHelper.getInstance().Read(value, iprot);
					
					structs.SetGetRdcReq(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getRdc_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequestHeader() != null) {
					
					oprot.WriteFieldBegin("requestHeader");
					
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Write(structs.GetRequestHeader(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetGetRdcReq() != null) {
					
					oprot.WriteFieldBegin("getRdcReq");
					
					com.vip.order.biz.request.GetRdcReqHelper.getInstance().Write(structs.GetGetRdcReq(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getRdc_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getRdcInvoice_argsHelper : TBeanSerializer<getRdcInvoice_args>
		{
			
			public static getRdcInvoice_argsHelper OBJ = new getRdcInvoice_argsHelper();
			
			public static getRdcInvoice_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getRdcInvoice_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.common.pojo.order.request.RequestHeader value;
					
					value = new com.vip.order.common.pojo.order.request.RequestHeader();
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Read(value, iprot);
					
					structs.SetRequestHeader(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.order.biz.request.GetRdcInvoiceReq value;
					
					value = new com.vip.order.biz.request.GetRdcInvoiceReq();
					com.vip.order.biz.request.GetRdcInvoiceReqHelper.getInstance().Read(value, iprot);
					
					structs.SetReq(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getRdcInvoice_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequestHeader() != null) {
					
					oprot.WriteFieldBegin("requestHeader");
					
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Write(structs.GetRequestHeader(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetReq() != null) {
					
					oprot.WriteFieldBegin("req");
					
					com.vip.order.biz.request.GetRdcInvoiceReqHelper.getInstance().Write(structs.GetReq(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getRdcInvoice_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getReturnOrExchangeGoods_argsHelper : TBeanSerializer<getReturnOrExchangeGoods_args>
		{
			
			public static getReturnOrExchangeGoods_argsHelper OBJ = new getReturnOrExchangeGoods_argsHelper();
			
			public static getReturnOrExchangeGoods_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getReturnOrExchangeGoods_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.common.pojo.order.request.RequestHeader value;
					
					value = new com.vip.order.common.pojo.order.request.RequestHeader();
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Read(value, iprot);
					
					structs.SetRequestHeader(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.order.biz.request.GetReturnOrExchangeGoodsReq value;
					
					value = new com.vip.order.biz.request.GetReturnOrExchangeGoodsReq();
					com.vip.order.biz.request.GetReturnOrExchangeGoodsReqHelper.getInstance().Read(value, iprot);
					
					structs.SetReq(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getReturnOrExchangeGoods_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequestHeader() != null) {
					
					oprot.WriteFieldBegin("requestHeader");
					
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Write(structs.GetRequestHeader(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetReq() != null) {
					
					oprot.WriteFieldBegin("req");
					
					com.vip.order.biz.request.GetReturnOrExchangeGoodsReqHelper.getInstance().Write(structs.GetReq(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getReturnOrExchangeGoods_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getSimpleOrderFlowFlag_argsHelper : TBeanSerializer<getSimpleOrderFlowFlag_args>
		{
			
			public static getSimpleOrderFlowFlag_argsHelper OBJ = new getSimpleOrderFlowFlag_argsHelper();
			
			public static getSimpleOrderFlowFlag_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getSimpleOrderFlowFlag_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.common.pojo.order.request.RequestHeader value;
					
					value = new com.vip.order.common.pojo.order.request.RequestHeader();
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Read(value, iprot);
					
					structs.SetRequestHeaderParam(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.order.biz.request.GetSimpleOrderFlowFlagReq value;
					
					value = new com.vip.order.biz.request.GetSimpleOrderFlowFlagReq();
					com.vip.order.biz.request.GetSimpleOrderFlowFlagReqHelper.getInstance().Read(value, iprot);
					
					structs.SetGetSimpleOrderFlowFlagParam(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getSimpleOrderFlowFlag_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequestHeaderParam() != null) {
					
					oprot.WriteFieldBegin("requestHeaderParam");
					
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Write(structs.GetRequestHeaderParam(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetGetSimpleOrderFlowFlagParam() != null) {
					
					oprot.WriteFieldBegin("getSimpleOrderFlowFlagParam");
					
					com.vip.order.biz.request.GetSimpleOrderFlowFlagReqHelper.getInstance().Write(structs.GetGetSimpleOrderFlowFlagParam(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getSimpleOrderFlowFlag_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getUnpayOrderList_argsHelper : TBeanSerializer<getUnpayOrderList_args>
		{
			
			public static getUnpayOrderList_argsHelper OBJ = new getUnpayOrderList_argsHelper();
			
			public static getUnpayOrderList_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getUnpayOrderList_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.common.pojo.order.request.RequestHeader value;
					
					value = new com.vip.order.common.pojo.order.request.RequestHeader();
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Read(value, iprot);
					
					structs.SetRequestHeaderParam(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.order.biz.request.GetUnpayOrderReq value;
					
					value = new com.vip.order.biz.request.GetUnpayOrderReq();
					com.vip.order.biz.request.GetUnpayOrderReqHelper.getInstance().Read(value, iprot);
					
					structs.SetGetUnpayOrderParam(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getUnpayOrderList_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequestHeaderParam() != null) {
					
					oprot.WriteFieldBegin("requestHeaderParam");
					
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Write(structs.GetRequestHeaderParam(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetGetUnpayOrderParam() != null) {
					
					oprot.WriteFieldBegin("getUnpayOrderParam");
					
					com.vip.order.biz.request.GetUnpayOrderReqHelper.getInstance().Write(structs.GetGetUnpayOrderParam(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getUnpayOrderList_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getUserDeliveryAddress_argsHelper : TBeanSerializer<getUserDeliveryAddress_args>
		{
			
			public static getUserDeliveryAddress_argsHelper OBJ = new getUserDeliveryAddress_argsHelper();
			
			public static getUserDeliveryAddress_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getUserDeliveryAddress_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.common.pojo.order.request.RequestHeader value;
					
					value = new com.vip.order.common.pojo.order.request.RequestHeader();
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Read(value, iprot);
					
					structs.SetRequestHeader(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.order.biz.request.GetUserDeliveryAddressReq value;
					
					value = new com.vip.order.biz.request.GetUserDeliveryAddressReq();
					com.vip.order.biz.request.GetUserDeliveryAddressReqHelper.getInstance().Read(value, iprot);
					
					structs.SetGetUserDeliveryAddressReq(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.order.common.pojo.order.request.ResultFilter value;
					
					value = new com.vip.order.common.pojo.order.request.ResultFilter();
					com.vip.order.common.pojo.order.request.ResultFilterHelper.getInstance().Read(value, iprot);
					
					structs.SetResultFilter(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getUserDeliveryAddress_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequestHeader() != null) {
					
					oprot.WriteFieldBegin("requestHeader");
					
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Write(structs.GetRequestHeader(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetGetUserDeliveryAddressReq() != null) {
					
					oprot.WriteFieldBegin("getUserDeliveryAddressReq");
					
					com.vip.order.biz.request.GetUserDeliveryAddressReqHelper.getInstance().Write(structs.GetGetUserDeliveryAddressReq(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetResultFilter() != null) {
					
					oprot.WriteFieldBegin("resultFilter");
					
					com.vip.order.common.pojo.order.request.ResultFilterHelper.getInstance().Write(structs.GetResultFilter(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getUserDeliveryAddress_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getUserFirstOrder_argsHelper : TBeanSerializer<getUserFirstOrder_args>
		{
			
			public static getUserFirstOrder_argsHelper OBJ = new getUserFirstOrder_argsHelper();
			
			public static getUserFirstOrder_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getUserFirstOrder_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.common.pojo.order.request.RequestHeader value;
					
					value = new com.vip.order.common.pojo.order.request.RequestHeader();
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Read(value, iprot);
					
					structs.SetRequestHeader(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.order.biz.request.GetUserFirstOrderReq value;
					
					value = new com.vip.order.biz.request.GetUserFirstOrderReq();
					com.vip.order.biz.request.GetUserFirstOrderReqHelper.getInstance().Read(value, iprot);
					
					structs.SetGetUserFirstOrderReq(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getUserFirstOrder_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequestHeader() != null) {
					
					oprot.WriteFieldBegin("requestHeader");
					
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Write(structs.GetRequestHeader(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetGetUserFirstOrderReq() != null) {
					
					oprot.WriteFieldBegin("getUserFirstOrderReq");
					
					com.vip.order.biz.request.GetUserFirstOrderReqHelper.getInstance().Write(structs.GetGetUserFirstOrderReq(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getUserFirstOrder_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class healthCheck_argsHelper : TBeanSerializer<healthCheck_args>
		{
			
			public static healthCheck_argsHelper OBJ = new healthCheck_argsHelper();
			
			public static healthCheck_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(healthCheck_args structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(healthCheck_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(healthCheck_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class mergeOrder_argsHelper : TBeanSerializer<mergeOrder_args>
		{
			
			public static mergeOrder_argsHelper OBJ = new mergeOrder_argsHelper();
			
			public static mergeOrder_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(mergeOrder_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.common.pojo.order.request.RequestHeader value;
					
					value = new com.vip.order.common.pojo.order.request.RequestHeader();
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Read(value, iprot);
					
					structs.SetRequestHeader(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.order.biz.request.MergeOrderReq value;
					
					value = new com.vip.order.biz.request.MergeOrderReq();
					com.vip.order.biz.request.MergeOrderReqHelper.getInstance().Read(value, iprot);
					
					structs.SetReqParam(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(mergeOrder_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequestHeader() != null) {
					
					oprot.WriteFieldBegin("requestHeader");
					
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Write(structs.GetRequestHeader(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetReqParam() != null) {
					
					oprot.WriteFieldBegin("reqParam");
					
					com.vip.order.biz.request.MergeOrderReqHelper.getInstance().Write(structs.GetReqParam(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(mergeOrder_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class modifyOrderConsignee_argsHelper : TBeanSerializer<modifyOrderConsignee_args>
		{
			
			public static modifyOrderConsignee_argsHelper OBJ = new modifyOrderConsignee_argsHelper();
			
			public static modifyOrderConsignee_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(modifyOrderConsignee_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.common.pojo.order.request.RequestHeader value;
					
					value = new com.vip.order.common.pojo.order.request.RequestHeader();
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Read(value, iprot);
					
					structs.SetRequestHeader(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.order.biz.request.ModifyOrderConsigneeReq value;
					
					value = new com.vip.order.biz.request.ModifyOrderConsigneeReq();
					com.vip.order.biz.request.ModifyOrderConsigneeReqHelper.getInstance().Read(value, iprot);
					
					structs.SetModifyOrderConsigneeReq(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(modifyOrderConsignee_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequestHeader() != null) {
					
					oprot.WriteFieldBegin("requestHeader");
					
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Write(structs.GetRequestHeader(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetModifyOrderConsigneeReq() != null) {
					
					oprot.WriteFieldBegin("modifyOrderConsigneeReq");
					
					com.vip.order.biz.request.ModifyOrderConsigneeReqHelper.getInstance().Write(structs.GetModifyOrderConsigneeReq(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(modifyOrderConsignee_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class modifyOrderElectronicInvoice_argsHelper : TBeanSerializer<modifyOrderElectronicInvoice_args>
		{
			
			public static modifyOrderElectronicInvoice_argsHelper OBJ = new modifyOrderElectronicInvoice_argsHelper();
			
			public static modifyOrderElectronicInvoice_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(modifyOrderElectronicInvoice_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.common.pojo.order.request.RequestHeader value;
					
					value = new com.vip.order.common.pojo.order.request.RequestHeader();
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Read(value, iprot);
					
					structs.SetRequestHeader(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.order.biz.request.ModifyOrderElectronicInvoiceReq value;
					
					value = new com.vip.order.biz.request.ModifyOrderElectronicInvoiceReq();
					com.vip.order.biz.request.ModifyOrderElectronicInvoiceReqHelper.getInstance().Read(value, iprot);
					
					structs.SetModifyOrderElectronicInvoiceReq(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(modifyOrderElectronicInvoice_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequestHeader() != null) {
					
					oprot.WriteFieldBegin("requestHeader");
					
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Write(structs.GetRequestHeader(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetModifyOrderElectronicInvoiceReq() != null) {
					
					oprot.WriteFieldBegin("modifyOrderElectronicInvoiceReq");
					
					com.vip.order.biz.request.ModifyOrderElectronicInvoiceReqHelper.getInstance().Write(structs.GetModifyOrderElectronicInvoiceReq(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(modifyOrderElectronicInvoice_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class modifyOrderGoods_argsHelper : TBeanSerializer<modifyOrderGoods_args>
		{
			
			public static modifyOrderGoods_argsHelper OBJ = new modifyOrderGoods_argsHelper();
			
			public static modifyOrderGoods_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(modifyOrderGoods_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.common.pojo.order.request.RequestHeader value;
					
					value = new com.vip.order.common.pojo.order.request.RequestHeader();
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Read(value, iprot);
					
					structs.SetRequestHeader(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.order.biz.request.ModifyOrderGoodsReq value;
					
					value = new com.vip.order.biz.request.ModifyOrderGoodsReq();
					com.vip.order.biz.request.ModifyOrderGoodsReqHelper.getInstance().Read(value, iprot);
					
					structs.SetOrderGoodsReq(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(modifyOrderGoods_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequestHeader() != null) {
					
					oprot.WriteFieldBegin("requestHeader");
					
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Write(structs.GetRequestHeader(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetOrderGoodsReq() != null) {
					
					oprot.WriteFieldBegin("orderGoodsReq");
					
					com.vip.order.biz.request.ModifyOrderGoodsReqHelper.getInstance().Write(structs.GetOrderGoodsReq(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(modifyOrderGoods_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class modifyOrderPayType_argsHelper : TBeanSerializer<modifyOrderPayType_args>
		{
			
			public static modifyOrderPayType_argsHelper OBJ = new modifyOrderPayType_argsHelper();
			
			public static modifyOrderPayType_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(modifyOrderPayType_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.common.pojo.order.request.RequestHeader value;
					
					value = new com.vip.order.common.pojo.order.request.RequestHeader();
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Read(value, iprot);
					
					structs.SetRequestHeader(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.order.common.pojo.order.vo.ModifyPayTypeReq value;
					
					value = new com.vip.order.common.pojo.order.vo.ModifyPayTypeReq();
					com.vip.order.common.pojo.order.vo.ModifyPayTypeReqHelper.getInstance().Read(value, iprot);
					
					structs.SetModifyPayTypeReq(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(modifyOrderPayType_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequestHeader() != null) {
					
					oprot.WriteFieldBegin("requestHeader");
					
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Write(structs.GetRequestHeader(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetModifyPayTypeReq() != null) {
					
					oprot.WriteFieldBegin("ModifyPayTypeReq");
					
					com.vip.order.common.pojo.order.vo.ModifyPayTypeReqHelper.getInstance().Write(structs.GetModifyPayTypeReq(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(modifyOrderPayType_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class modifyOrderQualified_argsHelper : TBeanSerializer<modifyOrderQualified_args>
		{
			
			public static modifyOrderQualified_argsHelper OBJ = new modifyOrderQualified_argsHelper();
			
			public static modifyOrderQualified_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(modifyOrderQualified_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.common.pojo.order.request.RequestHeader value;
					
					value = new com.vip.order.common.pojo.order.request.RequestHeader();
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Read(value, iprot);
					
					structs.SetRequestHeader(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.order.biz.param.ModifyOrderQualifiedReq value;
					
					value = new com.vip.order.biz.param.ModifyOrderQualifiedReq();
					com.vip.order.biz.param.ModifyOrderQualifiedReqHelper.getInstance().Read(value, iprot);
					
					structs.SetReq(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(modifyOrderQualified_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequestHeader() != null) {
					
					oprot.WriteFieldBegin("requestHeader");
					
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Write(structs.GetRequestHeader(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetReq() != null) {
					
					oprot.WriteFieldBegin("req");
					
					com.vip.order.biz.param.ModifyOrderQualifiedReqHelper.getInstance().Write(structs.GetReq(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(modifyOrderQualified_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class modifyOrderShipped_argsHelper : TBeanSerializer<modifyOrderShipped_args>
		{
			
			public static modifyOrderShipped_argsHelper OBJ = new modifyOrderShipped_argsHelper();
			
			public static modifyOrderShipped_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(modifyOrderShipped_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.common.pojo.order.request.RequestHeader value;
					
					value = new com.vip.order.common.pojo.order.request.RequestHeader();
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Read(value, iprot);
					
					structs.SetRequestHeader(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.order.biz.request.ModifyOrderShippedReq value;
					
					value = new com.vip.order.biz.request.ModifyOrderShippedReq();
					com.vip.order.biz.request.ModifyOrderShippedReqHelper.getInstance().Read(value, iprot);
					
					structs.SetModifyOrderShippedReq(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(modifyOrderShipped_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequestHeader() != null) {
					
					oprot.WriteFieldBegin("requestHeader");
					
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Write(structs.GetRequestHeader(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetModifyOrderShippedReq() != null) {
					
					oprot.WriteFieldBegin("modifyOrderShippedReq");
					
					com.vip.order.biz.request.ModifyOrderShippedReqHelper.getInstance().Write(structs.GetModifyOrderShippedReq(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(modifyOrderShipped_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class modifyPrepayOrderPayType_argsHelper : TBeanSerializer<modifyPrepayOrderPayType_args>
		{
			
			public static modifyPrepayOrderPayType_argsHelper OBJ = new modifyPrepayOrderPayType_argsHelper();
			
			public static modifyPrepayOrderPayType_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(modifyPrepayOrderPayType_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.common.pojo.order.request.RequestHeader value;
					
					value = new com.vip.order.common.pojo.order.request.RequestHeader();
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Read(value, iprot);
					
					structs.SetRequestHeader(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.order.biz.request.ModifyPrepayOrderPayTypeReq value;
					
					value = new com.vip.order.biz.request.ModifyPrepayOrderPayTypeReq();
					com.vip.order.biz.request.ModifyPrepayOrderPayTypeReqHelper.getInstance().Read(value, iprot);
					
					structs.SetModifyPrepayOrderPayTypeReq(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(modifyPrepayOrderPayType_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequestHeader() != null) {
					
					oprot.WriteFieldBegin("requestHeader");
					
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Write(structs.GetRequestHeader(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetModifyPrepayOrderPayTypeReq() != null) {
					
					oprot.WriteFieldBegin("modifyPrepayOrderPayTypeReq");
					
					com.vip.order.biz.request.ModifyPrepayOrderPayTypeReqHelper.getInstance().Write(structs.GetModifyPrepayOrderPayTypeReq(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(modifyPrepayOrderPayType_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class notifyCustomsDeclarationFailed_argsHelper : TBeanSerializer<notifyCustomsDeclarationFailed_args>
		{
			
			public static notifyCustomsDeclarationFailed_argsHelper OBJ = new notifyCustomsDeclarationFailed_argsHelper();
			
			public static notifyCustomsDeclarationFailed_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(notifyCustomsDeclarationFailed_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.common.pojo.order.request.RequestHeader value;
					
					value = new com.vip.order.common.pojo.order.request.RequestHeader();
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Read(value, iprot);
					
					structs.SetRequestHeader(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.order.biz.request.NotifyCustomsDeclarationFailedReq value;
					
					value = new com.vip.order.biz.request.NotifyCustomsDeclarationFailedReq();
					com.vip.order.biz.request.NotifyCustomsDeclarationFailedReqHelper.getInstance().Read(value, iprot);
					
					structs.SetReq(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(notifyCustomsDeclarationFailed_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequestHeader() != null) {
					
					oprot.WriteFieldBegin("requestHeader");
					
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Write(structs.GetRequestHeader(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetReq() != null) {
					
					oprot.WriteFieldBegin("req");
					
					com.vip.order.biz.request.NotifyCustomsDeclarationFailedReqHelper.getInstance().Write(structs.GetReq(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(notifyCustomsDeclarationFailed_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class ofcEntranceGrayControl_argsHelper : TBeanSerializer<ofcEntranceGrayControl_args>
		{
			
			public static ofcEntranceGrayControl_argsHelper OBJ = new ofcEntranceGrayControl_argsHelper();
			
			public static ofcEntranceGrayControl_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(ofcEntranceGrayControl_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.common.pojo.order.request.RequestHeader value;
					
					value = new com.vip.order.common.pojo.order.request.RequestHeader();
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Read(value, iprot);
					
					structs.SetRequestHeader(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.order.biz.request.OfcEntranceGrayControlReq value;
					
					value = new com.vip.order.biz.request.OfcEntranceGrayControlReq();
					com.vip.order.biz.request.OfcEntranceGrayControlReqHelper.getInstance().Read(value, iprot);
					
					structs.SetReq(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(ofcEntranceGrayControl_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequestHeader() != null) {
					
					oprot.WriteFieldBegin("requestHeader");
					
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Write(structs.GetRequestHeader(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetReq() != null) {
					
					oprot.WriteFieldBegin("req");
					
					com.vip.order.biz.request.OfcEntranceGrayControlReqHelper.getInstance().Write(structs.GetReq(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(ofcEntranceGrayControl_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class paymentReceived_argsHelper : TBeanSerializer<paymentReceived_args>
		{
			
			public static paymentReceived_argsHelper OBJ = new paymentReceived_argsHelper();
			
			public static paymentReceived_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(paymentReceived_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.common.pojo.order.request.RequestHeader value;
					
					value = new com.vip.order.common.pojo.order.request.RequestHeader();
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Read(value, iprot);
					
					structs.SetRequestHeader(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.order.biz.request.PaymentReceivedReq value;
					
					value = new com.vip.order.biz.request.PaymentReceivedReq();
					com.vip.order.biz.request.PaymentReceivedReqHelper.getInstance().Read(value, iprot);
					
					structs.SetReq(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(paymentReceived_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequestHeader() != null) {
					
					oprot.WriteFieldBegin("requestHeader");
					
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Write(structs.GetRequestHeader(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetReq() != null) {
					
					oprot.WriteFieldBegin("req");
					
					com.vip.order.biz.request.PaymentReceivedReqHelper.getInstance().Write(structs.GetReq(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(paymentReceived_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class postOrderVMSMessage_argsHelper : TBeanSerializer<postOrderVMSMessage_args>
		{
			
			public static postOrderVMSMessage_argsHelper OBJ = new postOrderVMSMessage_argsHelper();
			
			public static postOrderVMSMessage_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(postOrderVMSMessage_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.common.pojo.order.request.RequestHeader value;
					
					value = new com.vip.order.common.pojo.order.request.RequestHeader();
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Read(value, iprot);
					
					structs.SetRequestHeader(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.order.biz.request.PostOrderVMSMessageReq value;
					
					value = new com.vip.order.biz.request.PostOrderVMSMessageReq();
					com.vip.order.biz.request.PostOrderVMSMessageReqHelper.getInstance().Read(value, iprot);
					
					structs.SetPostOrderVMSMessageReq(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(postOrderVMSMessage_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequestHeader() != null) {
					
					oprot.WriteFieldBegin("requestHeader");
					
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Write(structs.GetRequestHeader(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetPostOrderVMSMessageReq() != null) {
					
					oprot.WriteFieldBegin("postOrderVMSMessageReq");
					
					com.vip.order.biz.request.PostOrderVMSMessageReqHelper.getInstance().Write(structs.GetPostOrderVMSMessageReq(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(postOrderVMSMessage_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class putIntoSplitQueue_argsHelper : TBeanSerializer<putIntoSplitQueue_args>
		{
			
			public static putIntoSplitQueue_argsHelper OBJ = new putIntoSplitQueue_argsHelper();
			
			public static putIntoSplitQueue_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(putIntoSplitQueue_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.common.pojo.order.request.RequestHeader value;
					
					value = new com.vip.order.common.pojo.order.request.RequestHeader();
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Read(value, iprot);
					
					structs.SetRequestHeader(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.order.biz.request.PutIntoSplitQueueReq value;
					
					value = new com.vip.order.biz.request.PutIntoSplitQueueReq();
					com.vip.order.biz.request.PutIntoSplitQueueReqHelper.getInstance().Read(value, iprot);
					
					structs.SetPutIntoSplitQueueReq(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(putIntoSplitQueue_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequestHeader() != null) {
					
					oprot.WriteFieldBegin("requestHeader");
					
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Write(structs.GetRequestHeader(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetPutIntoSplitQueueReq() != null) {
					
					oprot.WriteFieldBegin("putIntoSplitQueueReq");
					
					com.vip.order.biz.request.PutIntoSplitQueueReqHelper.getInstance().Write(structs.GetPutIntoSplitQueueReq(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(putIntoSplitQueue_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class putKeyToRollbackQueue_argsHelper : TBeanSerializer<putKeyToRollbackQueue_args>
		{
			
			public static putKeyToRollbackQueue_argsHelper OBJ = new putKeyToRollbackQueue_argsHelper();
			
			public static putKeyToRollbackQueue_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(putKeyToRollbackQueue_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.common.pojo.order.request.RequestHeader value;
					
					value = new com.vip.order.common.pojo.order.request.RequestHeader();
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Read(value, iprot);
					
					structs.SetRequestHeader(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.order.biz.request.PutKeyToRollbackQueueReq value;
					
					value = new com.vip.order.biz.request.PutKeyToRollbackQueueReq();
					com.vip.order.biz.request.PutKeyToRollbackQueueReqHelper.getInstance().Read(value, iprot);
					
					structs.SetReq(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(putKeyToRollbackQueue_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequestHeader() != null) {
					
					oprot.WriteFieldBegin("requestHeader");
					
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Write(structs.GetRequestHeader(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetReq() != null) {
					
					oprot.WriteFieldBegin("req");
					
					com.vip.order.biz.request.PutKeyToRollbackQueueReqHelper.getInstance().Write(structs.GetReq(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(putKeyToRollbackQueue_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class putOrderToRollbackQueue_argsHelper : TBeanSerializer<putOrderToRollbackQueue_args>
		{
			
			public static putOrderToRollbackQueue_argsHelper OBJ = new putOrderToRollbackQueue_argsHelper();
			
			public static putOrderToRollbackQueue_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(putOrderToRollbackQueue_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.common.pojo.order.request.RequestHeader value;
					
					value = new com.vip.order.common.pojo.order.request.RequestHeader();
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Read(value, iprot);
					
					structs.SetRequestHeader(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.order.biz.request.PutOrderToRollbackQueueReq value;
					
					value = new com.vip.order.biz.request.PutOrderToRollbackQueueReq();
					com.vip.order.biz.request.PutOrderToRollbackQueueReqHelper.getInstance().Read(value, iprot);
					
					structs.SetReq(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(putOrderToRollbackQueue_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequestHeader() != null) {
					
					oprot.WriteFieldBegin("requestHeader");
					
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Write(structs.GetRequestHeader(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetReq() != null) {
					
					oprot.WriteFieldBegin("req");
					
					com.vip.order.biz.request.PutOrderToRollbackQueueReqHelper.getInstance().Write(structs.GetReq(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(putOrderToRollbackQueue_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class receptionConfirmDelivered_argsHelper : TBeanSerializer<receptionConfirmDelivered_args>
		{
			
			public static receptionConfirmDelivered_argsHelper OBJ = new receptionConfirmDelivered_argsHelper();
			
			public static receptionConfirmDelivered_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(receptionConfirmDelivered_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.common.pojo.order.request.RequestHeader value;
					
					value = new com.vip.order.common.pojo.order.request.RequestHeader();
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Read(value, iprot);
					
					structs.SetRequestHeader(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.order.biz.request.ReceptionConfirmDeliveredReq value;
					
					value = new com.vip.order.biz.request.ReceptionConfirmDeliveredReq();
					com.vip.order.biz.request.ReceptionConfirmDeliveredReqHelper.getInstance().Read(value, iprot);
					
					structs.SetReq(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(receptionConfirmDelivered_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequestHeader() != null) {
					
					oprot.WriteFieldBegin("requestHeader");
					
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Write(structs.GetRequestHeader(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetReq() != null) {
					
					oprot.WriteFieldBegin("req");
					
					com.vip.order.biz.request.ReceptionConfirmDeliveredReqHelper.getInstance().Write(structs.GetReq(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(receptionConfirmDelivered_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class refundOrder_argsHelper : TBeanSerializer<refundOrder_args>
		{
			
			public static refundOrder_argsHelper OBJ = new refundOrder_argsHelper();
			
			public static refundOrder_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(refundOrder_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.common.pojo.order.request.RequestHeader value;
					
					value = new com.vip.order.common.pojo.order.request.RequestHeader();
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Read(value, iprot);
					
					structs.SetRequestHeader(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.order.biz.request.OrderRefundReq value;
					
					value = new com.vip.order.biz.request.OrderRefundReq();
					com.vip.order.biz.request.OrderRefundReqHelper.getInstance().Read(value, iprot);
					
					structs.SetOrderRefundReq(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(refundOrder_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequestHeader() != null) {
					
					oprot.WriteFieldBegin("requestHeader");
					
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Write(structs.GetRequestHeader(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetOrderRefundReq() != null) {
					
					oprot.WriteFieldBegin("orderRefundReq");
					
					com.vip.order.biz.request.OrderRefundReqHelper.getInstance().Write(structs.GetOrderRefundReq(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(refundOrder_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class releaseStock_argsHelper : TBeanSerializer<releaseStock_args>
		{
			
			public static releaseStock_argsHelper OBJ = new releaseStock_argsHelper();
			
			public static releaseStock_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(releaseStock_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.common.pojo.order.request.RequestHeader value;
					
					value = new com.vip.order.common.pojo.order.request.RequestHeader();
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Read(value, iprot);
					
					structs.SetRequestHeader(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.order.biz.request.ReleaseStockReq value;
					
					value = new com.vip.order.biz.request.ReleaseStockReq();
					com.vip.order.biz.request.ReleaseStockReqHelper.getInstance().Read(value, iprot);
					
					structs.SetReleaseStockReq(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(releaseStock_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequestHeader() != null) {
					
					oprot.WriteFieldBegin("requestHeader");
					
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Write(structs.GetRequestHeader(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetReleaseStockReq() != null) {
					
					oprot.WriteFieldBegin("releaseStockReq");
					
					com.vip.order.biz.request.ReleaseStockReqHelper.getInstance().Write(structs.GetReleaseStockReq(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(releaseStock_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class rollbackOrder_argsHelper : TBeanSerializer<rollbackOrder_args>
		{
			
			public static rollbackOrder_argsHelper OBJ = new rollbackOrder_argsHelper();
			
			public static rollbackOrder_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(rollbackOrder_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.common.pojo.order.request.RequestHeader value;
					
					value = new com.vip.order.common.pojo.order.request.RequestHeader();
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Read(value, iprot);
					
					structs.SetRequestHeader(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.order.biz.request.RollbackOrderReq value;
					
					value = new com.vip.order.biz.request.RollbackOrderReq();
					com.vip.order.biz.request.RollbackOrderReqHelper.getInstance().Read(value, iprot);
					
					structs.SetRollbackOrderReq(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(rollbackOrder_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequestHeader() != null) {
					
					oprot.WriteFieldBegin("requestHeader");
					
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Write(structs.GetRequestHeader(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetRollbackOrderReq() != null) {
					
					oprot.WriteFieldBegin("rollbackOrderReq");
					
					com.vip.order.biz.request.RollbackOrderReqHelper.getInstance().Write(structs.GetRollbackOrderReq(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(rollbackOrder_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class searchOrderListByUserId_argsHelper : TBeanSerializer<searchOrderListByUserId_args>
		{
			
			public static searchOrderListByUserId_argsHelper OBJ = new searchOrderListByUserId_argsHelper();
			
			public static searchOrderListByUserId_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(searchOrderListByUserId_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.common.pojo.order.request.RequestHeader value;
					
					value = new com.vip.order.common.pojo.order.request.RequestHeader();
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Read(value, iprot);
					
					structs.SetRequestHeader(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.order.biz.request.SearchOrderListByUserIdReq value;
					
					value = new com.vip.order.biz.request.SearchOrderListByUserIdReq();
					com.vip.order.biz.request.SearchOrderListByUserIdReqHelper.getInstance().Read(value, iprot);
					
					structs.SetGetOrderHistoryReq(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.order.common.pojo.order.request.ResultFilter value;
					
					value = new com.vip.order.common.pojo.order.request.ResultFilter();
					com.vip.order.common.pojo.order.request.ResultFilterHelper.getInstance().Read(value, iprot);
					
					structs.SetResultFilter(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(searchOrderListByUserId_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequestHeader() != null) {
					
					oprot.WriteFieldBegin("requestHeader");
					
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Write(structs.GetRequestHeader(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetGetOrderHistoryReq() != null) {
					
					oprot.WriteFieldBegin("getOrderHistoryReq");
					
					com.vip.order.biz.request.SearchOrderListByUserIdReqHelper.getInstance().Write(structs.GetGetOrderHistoryReq(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetResultFilter() != null) {
					
					oprot.WriteFieldBegin("resultFilter");
					
					com.vip.order.common.pojo.order.request.ResultFilterHelper.getInstance().Write(structs.GetResultFilter(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(searchOrderListByUserId_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class signOrder_argsHelper : TBeanSerializer<signOrder_args>
		{
			
			public static signOrder_argsHelper OBJ = new signOrder_argsHelper();
			
			public static signOrder_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(signOrder_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.common.pojo.order.request.RequestHeader value;
					
					value = new com.vip.order.common.pojo.order.request.RequestHeader();
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Read(value, iprot);
					
					structs.SetRequestHeader(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.order.biz.request.SignOrderReq value;
					
					value = new com.vip.order.biz.request.SignOrderReq();
					com.vip.order.biz.request.SignOrderReqHelper.getInstance().Read(value, iprot);
					
					structs.SetSignOrderReq(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(signOrder_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequestHeader() != null) {
					
					oprot.WriteFieldBegin("requestHeader");
					
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Write(structs.GetRequestHeader(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetSignOrderReq() != null) {
					
					oprot.WriteFieldBegin("signOrderReq");
					
					com.vip.order.biz.request.SignOrderReqHelper.getInstance().Write(structs.GetSignOrderReq(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(signOrder_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class triggerGroupByAuditOrder_argsHelper : TBeanSerializer<triggerGroupByAuditOrder_args>
		{
			
			public static triggerGroupByAuditOrder_argsHelper OBJ = new triggerGroupByAuditOrder_argsHelper();
			
			public static triggerGroupByAuditOrder_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(triggerGroupByAuditOrder_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.common.pojo.order.request.RequestHeader value;
					
					value = new com.vip.order.common.pojo.order.request.RequestHeader();
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Read(value, iprot);
					
					structs.SetRequestHeader(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.order.biz.request.GroupByOrderAuditReq value;
					
					value = new com.vip.order.biz.request.GroupByOrderAuditReq();
					com.vip.order.biz.request.GroupByOrderAuditReqHelper.getInstance().Read(value, iprot);
					
					structs.SetGroupByOrderAuditReq(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(triggerGroupByAuditOrder_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequestHeader() != null) {
					
					oprot.WriteFieldBegin("requestHeader");
					
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Write(structs.GetRequestHeader(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetGroupByOrderAuditReq() != null) {
					
					oprot.WriteFieldBegin("groupByOrderAuditReq");
					
					com.vip.order.biz.request.GroupByOrderAuditReqHelper.getInstance().Write(structs.GetGroupByOrderAuditReq(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(triggerGroupByAuditOrder_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class updateAutoPayAuth_argsHelper : TBeanSerializer<updateAutoPayAuth_args>
		{
			
			public static updateAutoPayAuth_argsHelper OBJ = new updateAutoPayAuth_argsHelper();
			
			public static updateAutoPayAuth_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(updateAutoPayAuth_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.common.pojo.order.request.RequestHeader value;
					
					value = new com.vip.order.common.pojo.order.request.RequestHeader();
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Read(value, iprot);
					
					structs.SetRequestHeader(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.order.biz.request.UpdateAutoPayAuthReq value;
					
					value = new com.vip.order.biz.request.UpdateAutoPayAuthReq();
					com.vip.order.biz.request.UpdateAutoPayAuthReqHelper.getInstance().Read(value, iprot);
					
					structs.SetReq(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(updateAutoPayAuth_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequestHeader() != null) {
					
					oprot.WriteFieldBegin("requestHeader");
					
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Write(structs.GetRequestHeader(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetReq() != null) {
					
					oprot.WriteFieldBegin("req");
					
					com.vip.order.biz.request.UpdateAutoPayAuthReqHelper.getInstance().Write(structs.GetReq(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(updateAutoPayAuth_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class updateOrderPayResult_argsHelper : TBeanSerializer<updateOrderPayResult_args>
		{
			
			public static updateOrderPayResult_argsHelper OBJ = new updateOrderPayResult_argsHelper();
			
			public static updateOrderPayResult_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(updateOrderPayResult_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.common.pojo.order.request.RequestHeader value;
					
					value = new com.vip.order.common.pojo.order.request.RequestHeader();
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Read(value, iprot);
					
					structs.SetRequestHeader(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.order.biz.request.UpdateOrderPayResultReq value;
					
					value = new com.vip.order.biz.request.UpdateOrderPayResultReq();
					com.vip.order.biz.request.UpdateOrderPayResultReqHelper.getInstance().Read(value, iprot);
					
					structs.SetUpdateOrderPayResultReq(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(updateOrderPayResult_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequestHeader() != null) {
					
					oprot.WriteFieldBegin("requestHeader");
					
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Write(structs.GetRequestHeader(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetUpdateOrderPayResultReq() != null) {
					
					oprot.WriteFieldBegin("updateOrderPayResultReq");
					
					com.vip.order.biz.request.UpdateOrderPayResultReqHelper.getInstance().Write(structs.GetUpdateOrderPayResultReq(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(updateOrderPayResult_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class updateOrderToReturnVerified_argsHelper : TBeanSerializer<updateOrderToReturnVerified_args>
		{
			
			public static updateOrderToReturnVerified_argsHelper OBJ = new updateOrderToReturnVerified_argsHelper();
			
			public static updateOrderToReturnVerified_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(updateOrderToReturnVerified_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.common.pojo.order.request.RequestHeader value;
					
					value = new com.vip.order.common.pojo.order.request.RequestHeader();
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Read(value, iprot);
					
					structs.SetRequestHeader(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.order.biz.request.UpdateOrderToReturnVerifiedReq value;
					
					value = new com.vip.order.biz.request.UpdateOrderToReturnVerifiedReq();
					com.vip.order.biz.request.UpdateOrderToReturnVerifiedReqHelper.getInstance().Read(value, iprot);
					
					structs.SetUpdateOrderToReturnVerifiedReq(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(updateOrderToReturnVerified_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequestHeader() != null) {
					
					oprot.WriteFieldBegin("requestHeader");
					
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Write(structs.GetRequestHeader(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetUpdateOrderToReturnVerifiedReq() != null) {
					
					oprot.WriteFieldBegin("updateOrderToReturnVerifiedReq");
					
					com.vip.order.biz.request.UpdateOrderToReturnVerifiedReqHelper.getInstance().Write(structs.GetUpdateOrderToReturnVerifiedReq(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(updateOrderToReturnVerified_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class updatePayTypeToCOD_argsHelper : TBeanSerializer<updatePayTypeToCOD_args>
		{
			
			public static updatePayTypeToCOD_argsHelper OBJ = new updatePayTypeToCOD_argsHelper();
			
			public static updatePayTypeToCOD_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(updatePayTypeToCOD_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.common.pojo.order.request.RequestHeader value;
					
					value = new com.vip.order.common.pojo.order.request.RequestHeader();
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Read(value, iprot);
					
					structs.SetRequestHeader(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.order.biz.request.UpdatePayTypeToCODReq value;
					
					value = new com.vip.order.biz.request.UpdatePayTypeToCODReq();
					com.vip.order.biz.request.UpdatePayTypeToCODReqHelper.getInstance().Read(value, iprot);
					
					structs.SetUpdatePayTypeToCODReq(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(updatePayTypeToCOD_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequestHeader() != null) {
					
					oprot.WriteFieldBegin("requestHeader");
					
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Write(structs.GetRequestHeader(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetUpdatePayTypeToCODReq() != null) {
					
					oprot.WriteFieldBegin("updatePayTypeToCODReq");
					
					com.vip.order.biz.request.UpdatePayTypeToCODReqHelper.getInstance().Write(structs.GetUpdatePayTypeToCODReq(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(updatePayTypeToCOD_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class updatePrePayToVerified_argsHelper : TBeanSerializer<updatePrePayToVerified_args>
		{
			
			public static updatePrePayToVerified_argsHelper OBJ = new updatePrePayToVerified_argsHelper();
			
			public static updatePrePayToVerified_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(updatePrePayToVerified_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.common.pojo.order.request.RequestHeader value;
					
					value = new com.vip.order.common.pojo.order.request.RequestHeader();
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Read(value, iprot);
					
					structs.SetRequestHeader(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.order.biz.request.UpdatePrePayToVerifiedReq value;
					
					value = new com.vip.order.biz.request.UpdatePrePayToVerifiedReq();
					com.vip.order.biz.request.UpdatePrePayToVerifiedReqHelper.getInstance().Read(value, iprot);
					
					structs.SetUpdatePrePayToVerifiedReq(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(updatePrePayToVerified_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequestHeader() != null) {
					
					oprot.WriteFieldBegin("requestHeader");
					
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Write(structs.GetRequestHeader(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetUpdatePrePayToVerifiedReq() != null) {
					
					oprot.WriteFieldBegin("updatePrePayToVerifiedReq");
					
					com.vip.order.biz.request.UpdatePrePayToVerifiedReqHelper.getInstance().Write(structs.GetUpdatePrePayToVerifiedReq(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(updatePrePayToVerified_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class updateReservationState_argsHelper : TBeanSerializer<updateReservationState_args>
		{
			
			public static updateReservationState_argsHelper OBJ = new updateReservationState_argsHelper();
			
			public static updateReservationState_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(updateReservationState_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.common.pojo.order.request.RequestHeader value;
					
					value = new com.vip.order.common.pojo.order.request.RequestHeader();
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Read(value, iprot);
					
					structs.SetRequestHeader(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.order.biz.request.UpdateReservationStateReq value;
					
					value = new com.vip.order.biz.request.UpdateReservationStateReq();
					com.vip.order.biz.request.UpdateReservationStateReqHelper.getInstance().Read(value, iprot);
					
					structs.SetReq(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(updateReservationState_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequestHeader() != null) {
					
					oprot.WriteFieldBegin("requestHeader");
					
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Write(structs.GetRequestHeader(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetReq() != null) {
					
					oprot.WriteFieldBegin("req");
					
					com.vip.order.biz.request.UpdateReservationStateReqHelper.getInstance().Write(structs.GetReq(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(updateReservationState_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class userDeleteOrder_argsHelper : TBeanSerializer<userDeleteOrder_args>
		{
			
			public static userDeleteOrder_argsHelper OBJ = new userDeleteOrder_argsHelper();
			
			public static userDeleteOrder_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(userDeleteOrder_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.common.pojo.order.request.RequestHeader value;
					
					value = new com.vip.order.common.pojo.order.request.RequestHeader();
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Read(value, iprot);
					
					structs.SetHeader(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.order.biz.request.UserDeleteOrderReq value;
					
					value = new com.vip.order.biz.request.UserDeleteOrderReq();
					com.vip.order.biz.request.UserDeleteOrderReqHelper.getInstance().Read(value, iprot);
					
					structs.SetReq(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(userDeleteOrder_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetHeader() != null) {
					
					oprot.WriteFieldBegin("header");
					
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Write(structs.GetHeader(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetReq() != null) {
					
					oprot.WriteFieldBegin("req");
					
					com.vip.order.biz.request.UserDeleteOrderReqHelper.getInstance().Write(structs.GetReq(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(userDeleteOrder_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class verifyStockAndGetPayableFlag_argsHelper : TBeanSerializer<verifyStockAndGetPayableFlag_args>
		{
			
			public static verifyStockAndGetPayableFlag_argsHelper OBJ = new verifyStockAndGetPayableFlag_argsHelper();
			
			public static verifyStockAndGetPayableFlag_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(verifyStockAndGetPayableFlag_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.common.pojo.order.request.RequestHeader value;
					
					value = new com.vip.order.common.pojo.order.request.RequestHeader();
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Read(value, iprot);
					
					structs.SetRequestHeader(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.order.biz.request.VerifyStockAndGetPayableFlagReq value;
					
					value = new com.vip.order.biz.request.VerifyStockAndGetPayableFlagReq();
					com.vip.order.biz.request.VerifyStockAndGetPayableFlagReqHelper.getInstance().Read(value, iprot);
					
					structs.SetReq(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(verifyStockAndGetPayableFlag_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequestHeader() != null) {
					
					oprot.WriteFieldBegin("requestHeader");
					
					com.vip.order.common.pojo.order.request.RequestHeaderHelper.getInstance().Write(structs.GetRequestHeader(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetReq() != null) {
					
					oprot.WriteFieldBegin("req");
					
					com.vip.order.biz.request.VerifyStockAndGetPayableFlagReqHelper.getInstance().Write(structs.GetReq(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(verifyStockAndGetPayableFlag_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class addOrderTransport_resultHelper : TBeanSerializer<addOrderTransport_result>
		{
			
			public static addOrderTransport_resultHelper OBJ = new addOrderTransport_resultHelper();
			
			public static addOrderTransport_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(addOrderTransport_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.biz.response.AddOrderTransportResp value;
					
					value = new com.vip.order.biz.response.AddOrderTransportResp();
					com.vip.order.biz.response.AddOrderTransportRespHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(addOrderTransport_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.order.biz.response.AddOrderTransportRespHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(addOrderTransport_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class autoPay_resultHelper : TBeanSerializer<autoPay_result>
		{
			
			public static autoPay_resultHelper OBJ = new autoPay_resultHelper();
			
			public static autoPay_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(autoPay_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.biz.response.AutoPayResp value;
					
					value = new com.vip.order.biz.response.AutoPayResp();
					com.vip.order.biz.response.AutoPayRespHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(autoPay_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.order.biz.response.AutoPayRespHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(autoPay_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class autoPayFail_resultHelper : TBeanSerializer<autoPayFail_result>
		{
			
			public static autoPayFail_resultHelper OBJ = new autoPayFail_resultHelper();
			
			public static autoPayFail_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(autoPayFail_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.biz.response.AutoPayFailResp value;
					
					value = new com.vip.order.biz.response.AutoPayFailResp();
					com.vip.order.biz.response.AutoPayFailRespHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(autoPayFail_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.order.biz.response.AutoPayFailRespHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(autoPayFail_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class autoTakeInventory_resultHelper : TBeanSerializer<autoTakeInventory_result>
		{
			
			public static autoTakeInventory_resultHelper OBJ = new autoTakeInventory_resultHelper();
			
			public static autoTakeInventory_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(autoTakeInventory_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.biz.response.AutoTakeInventoryResp value;
					
					value = new com.vip.order.biz.response.AutoTakeInventoryResp();
					com.vip.order.biz.response.AutoTakeInventoryRespHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(autoTakeInventory_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.order.biz.response.AutoTakeInventoryRespHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(autoTakeInventory_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class b2cSupportSendSms_resultHelper : TBeanSerializer<b2cSupportSendSms_result>
		{
			
			public static b2cSupportSendSms_resultHelper OBJ = new b2cSupportSendSms_resultHelper();
			
			public static b2cSupportSendSms_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(b2cSupportSendSms_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.biz.response.B2CSupportSendSmsResp value;
					
					value = new com.vip.order.biz.response.B2CSupportSendSmsResp();
					com.vip.order.biz.response.B2CSupportSendSmsRespHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(b2cSupportSendSms_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.order.biz.response.B2CSupportSendSmsRespHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(b2cSupportSendSms_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class batchGetOrderActiveDetail_resultHelper : TBeanSerializer<batchGetOrderActiveDetail_result>
		{
			
			public static batchGetOrderActiveDetail_resultHelper OBJ = new batchGetOrderActiveDetail_resultHelper();
			
			public static batchGetOrderActiveDetail_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(batchGetOrderActiveDetail_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.biz.response.BatchGetOrderActiveDetailResp value;
					
					value = new com.vip.order.biz.response.BatchGetOrderActiveDetailResp();
					com.vip.order.biz.response.BatchGetOrderActiveDetailRespHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(batchGetOrderActiveDetail_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.order.biz.response.BatchGetOrderActiveDetailRespHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(batchGetOrderActiveDetail_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class batchGetOrderList_resultHelper : TBeanSerializer<batchGetOrderList_result>
		{
			
			public static batchGetOrderList_resultHelper OBJ = new batchGetOrderList_resultHelper();
			
			public static batchGetOrderList_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(batchGetOrderList_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.biz.response.BatchGetOrderListResp value;
					
					value = new com.vip.order.biz.response.BatchGetOrderListResp();
					com.vip.order.biz.response.BatchGetOrderListRespHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(batchGetOrderList_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.order.biz.response.BatchGetOrderListRespHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(batchGetOrderList_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class batchGetOrderTransportList_resultHelper : TBeanSerializer<batchGetOrderTransportList_result>
		{
			
			public static batchGetOrderTransportList_resultHelper OBJ = new batchGetOrderTransportList_resultHelper();
			
			public static batchGetOrderTransportList_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(batchGetOrderTransportList_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.biz.response.BatchGetOrderTransportListResp value;
					
					value = new com.vip.order.biz.response.BatchGetOrderTransportListResp();
					com.vip.order.biz.response.BatchGetOrderTransportListRespHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(batchGetOrderTransportList_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.order.biz.response.BatchGetOrderTransportListRespHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(batchGetOrderTransportList_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class batchModifyOrderInvoice_resultHelper : TBeanSerializer<batchModifyOrderInvoice_result>
		{
			
			public static batchModifyOrderInvoice_resultHelper OBJ = new batchModifyOrderInvoice_resultHelper();
			
			public static batchModifyOrderInvoice_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(batchModifyOrderInvoice_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.biz.response.BatchModifyOrderInvoiceResp value;
					
					value = new com.vip.order.biz.response.BatchModifyOrderInvoiceResp();
					com.vip.order.biz.response.BatchModifyOrderInvoiceRespHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(batchModifyOrderInvoice_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.order.biz.response.BatchModifyOrderInvoiceRespHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(batchModifyOrderInvoice_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class batchUpdateWmsFlag_resultHelper : TBeanSerializer<batchUpdateWmsFlag_result>
		{
			
			public static batchUpdateWmsFlag_resultHelper OBJ = new batchUpdateWmsFlag_resultHelper();
			
			public static batchUpdateWmsFlag_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(batchUpdateWmsFlag_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.biz.response.BatchUpdateWmsFlagResp value;
					
					value = new com.vip.order.biz.response.BatchUpdateWmsFlagResp();
					com.vip.order.biz.response.BatchUpdateWmsFlagRespHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(batchUpdateWmsFlag_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.order.biz.response.BatchUpdateWmsFlagRespHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(batchUpdateWmsFlag_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class calculateSplitOrderMoney_resultHelper : TBeanSerializer<calculateSplitOrderMoney_result>
		{
			
			public static calculateSplitOrderMoney_resultHelper OBJ = new calculateSplitOrderMoney_resultHelper();
			
			public static calculateSplitOrderMoney_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(calculateSplitOrderMoney_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.biz.response.CalculateSplitOrderMoneyResp value;
					
					value = new com.vip.order.biz.response.CalculateSplitOrderMoneyResp();
					com.vip.order.biz.response.CalculateSplitOrderMoneyRespHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(calculateSplitOrderMoney_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.order.biz.response.CalculateSplitOrderMoneyRespHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(calculateSplitOrderMoney_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class cancelOFixData_resultHelper : TBeanSerializer<cancelOFixData_result>
		{
			
			public static cancelOFixData_resultHelper OBJ = new cancelOFixData_resultHelper();
			
			public static cancelOFixData_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(cancelOFixData_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.biz.response.CancelOrderFixDataResp value;
					
					value = new com.vip.order.biz.response.CancelOrderFixDataResp();
					com.vip.order.biz.response.CancelOrderFixDataRespHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(cancelOFixData_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.order.biz.response.CancelOrderFixDataRespHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(cancelOFixData_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class cancelOrder_resultHelper : TBeanSerializer<cancelOrder_result>
		{
			
			public static cancelOrder_resultHelper OBJ = new cancelOrder_resultHelper();
			
			public static cancelOrder_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(cancelOrder_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.biz.response.CancelOrderResp value;
					
					value = new com.vip.order.biz.response.CancelOrderResp();
					com.vip.order.biz.response.CancelOrderRespHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(cancelOrder_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.order.biz.response.CancelOrderRespHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(cancelOrder_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class cancelPresellOrder_resultHelper : TBeanSerializer<cancelPresellOrder_result>
		{
			
			public static cancelPresellOrder_resultHelper OBJ = new cancelPresellOrder_resultHelper();
			
			public static cancelPresellOrder_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(cancelPresellOrder_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.biz.response.CancelOrderResp value;
					
					value = new com.vip.order.biz.response.CancelOrderResp();
					com.vip.order.biz.response.CancelOrderRespHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(cancelPresellOrder_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.order.biz.response.CancelOrderRespHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(cancelPresellOrder_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class checkCashOnDelivery_resultHelper : TBeanSerializer<checkCashOnDelivery_result>
		{
			
			public static checkCashOnDelivery_resultHelper OBJ = new checkCashOnDelivery_resultHelper();
			
			public static checkCashOnDelivery_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(checkCashOnDelivery_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.biz.response.CheckCashOnDeliveryResp value;
					
					value = new com.vip.order.biz.response.CheckCashOnDeliveryResp();
					com.vip.order.biz.response.CheckCashOnDeliveryRespHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(checkCashOnDelivery_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.order.biz.response.CheckCashOnDeliveryRespHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(checkCashOnDelivery_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class checkDeliveryFetchExchange_resultHelper : TBeanSerializer<checkDeliveryFetchExchange_result>
		{
			
			public static checkDeliveryFetchExchange_resultHelper OBJ = new checkDeliveryFetchExchange_resultHelper();
			
			public static checkDeliveryFetchExchange_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(checkDeliveryFetchExchange_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.biz.response.CheckDeliveryFetchExchangeResp value;
					
					value = new com.vip.order.biz.response.CheckDeliveryFetchExchangeResp();
					com.vip.order.biz.response.CheckDeliveryFetchExchangeRespHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(checkDeliveryFetchExchange_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.order.biz.response.CheckDeliveryFetchExchangeRespHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(checkDeliveryFetchExchange_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class checkDeliveryFetchReturn_resultHelper : TBeanSerializer<checkDeliveryFetchReturn_result>
		{
			
			public static checkDeliveryFetchReturn_resultHelper OBJ = new checkDeliveryFetchReturn_resultHelper();
			
			public static checkDeliveryFetchReturn_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(checkDeliveryFetchReturn_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.biz.response.CheckDeliveryFetchReturnResp value;
					
					value = new com.vip.order.biz.response.CheckDeliveryFetchReturnResp();
					com.vip.order.biz.response.CheckDeliveryFetchReturnRespHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(checkDeliveryFetchReturn_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.order.biz.response.CheckDeliveryFetchReturnRespHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(checkDeliveryFetchReturn_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class checkOrderReturnVendorAudit_resultHelper : TBeanSerializer<checkOrderReturnVendorAudit_result>
		{
			
			public static checkOrderReturnVendorAudit_resultHelper OBJ = new checkOrderReturnVendorAudit_resultHelper();
			
			public static checkOrderReturnVendorAudit_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(checkOrderReturnVendorAudit_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.biz.response.CheckOrderReturnVendorAuditResp value;
					
					value = new com.vip.order.biz.response.CheckOrderReturnVendorAuditResp();
					com.vip.order.biz.response.CheckOrderReturnVendorAuditRespHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(checkOrderReturnVendorAudit_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.order.biz.response.CheckOrderReturnVendorAuditRespHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(checkOrderReturnVendorAudit_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class confirmDelivered_resultHelper : TBeanSerializer<confirmDelivered_result>
		{
			
			public static confirmDelivered_resultHelper OBJ = new confirmDelivered_resultHelper();
			
			public static confirmDelivered_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(confirmDelivered_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.biz.response.ConfirmDeliveredResp value;
					
					value = new com.vip.order.biz.response.ConfirmDeliveredResp();
					com.vip.order.biz.response.ConfirmDeliveredRespHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(confirmDelivered_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.order.biz.response.ConfirmDeliveredRespHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(confirmDelivered_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class confirmOrderGroupBuyResult_resultHelper : TBeanSerializer<confirmOrderGroupBuyResult_result>
		{
			
			public static confirmOrderGroupBuyResult_resultHelper OBJ = new confirmOrderGroupBuyResult_resultHelper();
			
			public static confirmOrderGroupBuyResult_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(confirmOrderGroupBuyResult_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.biz.response.ConfirmOrderGroupBuyResp value;
					
					value = new com.vip.order.biz.response.ConfirmOrderGroupBuyResp();
					com.vip.order.biz.response.ConfirmOrderGroupBuyRespHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(confirmOrderGroupBuyResult_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.order.biz.response.ConfirmOrderGroupBuyRespHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(confirmOrderGroupBuyResult_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class createOrder_resultHelper : TBeanSerializer<createOrder_result>
		{
			
			public static createOrder_resultHelper OBJ = new createOrder_resultHelper();
			
			public static createOrder_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(createOrder_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.biz.response.CreateOrderResp value;
					
					value = new com.vip.order.biz.response.CreateOrderResp();
					com.vip.order.biz.response.CreateOrderRespHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(createOrder_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.order.biz.response.CreateOrderRespHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(createOrder_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class createOrderElectronicInvoice_resultHelper : TBeanSerializer<createOrderElectronicInvoice_result>
		{
			
			public static createOrderElectronicInvoice_resultHelper OBJ = new createOrderElectronicInvoice_resultHelper();
			
			public static createOrderElectronicInvoice_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(createOrderElectronicInvoice_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.biz.response.CreateOrderElectronicInvoiceResp value;
					
					value = new com.vip.order.biz.response.CreateOrderElectronicInvoiceResp();
					com.vip.order.biz.response.CreateOrderElectronicInvoiceRespHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(createOrderElectronicInvoice_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.order.biz.response.CreateOrderElectronicInvoiceRespHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(createOrderElectronicInvoice_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class createOrderPostProc_resultHelper : TBeanSerializer<createOrderPostProc_result>
		{
			
			public static createOrderPostProc_resultHelper OBJ = new createOrderPostProc_resultHelper();
			
			public static createOrderPostProc_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(createOrderPostProc_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.biz.response.CreateOrderPostProcResp value;
					
					value = new com.vip.order.biz.response.CreateOrderPostProcResp();
					com.vip.order.biz.response.CreateOrderPostProcRespHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(createOrderPostProc_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.order.biz.response.CreateOrderPostProcRespHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(createOrderPostProc_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class createOrderSnV2_resultHelper : TBeanSerializer<createOrderSnV2_result>
		{
			
			public static createOrderSnV2_resultHelper OBJ = new createOrderSnV2_resultHelper();
			
			public static createOrderSnV2_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(createOrderSnV2_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.biz.response.CreateOrderSnRespV2 value;
					
					value = new com.vip.order.biz.response.CreateOrderSnRespV2();
					com.vip.order.biz.response.CreateOrderSnRespV2Helper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(createOrderSnV2_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.order.biz.response.CreateOrderSnRespV2Helper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(createOrderSnV2_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class createOrderSnV3_resultHelper : TBeanSerializer<createOrderSnV3_result>
		{
			
			public static createOrderSnV3_resultHelper OBJ = new createOrderSnV3_resultHelper();
			
			public static createOrderSnV3_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(createOrderSnV3_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.biz.response.CreateOrderSnRespV3 value;
					
					value = new com.vip.order.biz.response.CreateOrderSnRespV3();
					com.vip.order.biz.response.CreateOrderSnRespV3Helper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(createOrderSnV3_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.order.biz.response.CreateOrderSnRespV3Helper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(createOrderSnV3_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class createOrderV2_resultHelper : TBeanSerializer<createOrderV2_result>
		{
			
			public static createOrderV2_resultHelper OBJ = new createOrderV2_resultHelper();
			
			public static createOrderV2_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(createOrderV2_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.biz.response.CreateOrderRespV2 value;
					
					value = new com.vip.order.biz.response.CreateOrderRespV2();
					com.vip.order.biz.response.CreateOrderRespV2Helper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(createOrderV2_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.order.biz.response.CreateOrderRespV2Helper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(createOrderV2_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class createOrderV3_resultHelper : TBeanSerializer<createOrderV3_result>
		{
			
			public static createOrderV3_resultHelper OBJ = new createOrderV3_resultHelper();
			
			public static createOrderV3_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(createOrderV3_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.biz.response.CreateOrderRespV3 value;
					
					value = new com.vip.order.biz.response.CreateOrderRespV3();
					com.vip.order.biz.response.CreateOrderRespV3Helper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(createOrderV3_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.order.biz.response.CreateOrderRespV3Helper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(createOrderV3_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class cscCancelBack_resultHelper : TBeanSerializer<cscCancelBack_result>
		{
			
			public static cscCancelBack_resultHelper OBJ = new cscCancelBack_resultHelper();
			
			public static cscCancelBack_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(cscCancelBack_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.biz.response.CSCCancelBackResp value;
					
					value = new com.vip.order.biz.response.CSCCancelBackResp();
					com.vip.order.biz.response.CSCCancelBackRespHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(cscCancelBack_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.order.biz.response.CSCCancelBackRespHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(cscCancelBack_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class displayOrder_resultHelper : TBeanSerializer<displayOrder_result>
		{
			
			public static displayOrder_resultHelper OBJ = new displayOrder_resultHelper();
			
			public static displayOrder_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(displayOrder_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.biz.response.DisplayOrderResp value;
					
					value = new com.vip.order.biz.response.DisplayOrderResp();
					com.vip.order.biz.response.DisplayOrderRespHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(displayOrder_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.order.biz.response.DisplayOrderRespHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(displayOrder_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getAfterSaleOpType_resultHelper : TBeanSerializer<getAfterSaleOpType_result>
		{
			
			public static getAfterSaleOpType_resultHelper OBJ = new getAfterSaleOpType_resultHelper();
			
			public static getAfterSaleOpType_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getAfterSaleOpType_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.biz.response.GetAfterSaleOpTypeResp value;
					
					value = new com.vip.order.biz.response.GetAfterSaleOpTypeResp();
					com.vip.order.biz.response.GetAfterSaleOpTypeRespHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getAfterSaleOpType_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.order.biz.response.GetAfterSaleOpTypeRespHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getAfterSaleOpType_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getCanAfterSaleOrderListByUserId_resultHelper : TBeanSerializer<getCanAfterSaleOrderListByUserId_result>
		{
			
			public static getCanAfterSaleOrderListByUserId_resultHelper OBJ = new getCanAfterSaleOrderListByUserId_resultHelper();
			
			public static getCanAfterSaleOrderListByUserId_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getCanAfterSaleOrderListByUserId_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.biz.response.GetCanAfterSaleOrderListResp value;
					
					value = new com.vip.order.biz.response.GetCanAfterSaleOrderListResp();
					com.vip.order.biz.response.GetCanAfterSaleOrderListRespHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getCanAfterSaleOrderListByUserId_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.order.biz.response.GetCanAfterSaleOrderListRespHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getCanAfterSaleOrderListByUserId_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getCanRefundOrderCount_resultHelper : TBeanSerializer<getCanRefundOrderCount_result>
		{
			
			public static getCanRefundOrderCount_resultHelper OBJ = new getCanRefundOrderCount_resultHelper();
			
			public static getCanRefundOrderCount_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getCanRefundOrderCount_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.biz.response.GetCanRefundOrderCountResp value;
					
					value = new com.vip.order.biz.response.GetCanRefundOrderCountResp();
					com.vip.order.biz.response.GetCanRefundOrderCountRespHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getCanRefundOrderCount_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.order.biz.response.GetCanRefundOrderCountRespHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getCanRefundOrderCount_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getCanRefundOrderList_resultHelper : TBeanSerializer<getCanRefundOrderList_result>
		{
			
			public static getCanRefundOrderList_resultHelper OBJ = new getCanRefundOrderList_resultHelper();
			
			public static getCanRefundOrderList_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getCanRefundOrderList_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.biz.response.GetCanRefundOrderListResp value;
					
					value = new com.vip.order.biz.response.GetCanRefundOrderListResp();
					com.vip.order.biz.response.GetCanRefundOrderListRespHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getCanRefundOrderList_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.order.biz.response.GetCanRefundOrderListRespHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getCanRefundOrderList_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getEbsGoodsList_resultHelper : TBeanSerializer<getEbsGoodsList_result>
		{
			
			public static getEbsGoodsList_resultHelper OBJ = new getEbsGoodsList_resultHelper();
			
			public static getEbsGoodsList_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getEbsGoodsList_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.biz.response.GetEbsGoodsListResp value;
					
					value = new com.vip.order.biz.response.GetEbsGoodsListResp();
					com.vip.order.biz.response.GetEbsGoodsListRespHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getEbsGoodsList_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.order.biz.response.GetEbsGoodsListRespHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getEbsGoodsList_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getGoodsDispatchWarehouse_resultHelper : TBeanSerializer<getGoodsDispatchWarehouse_result>
		{
			
			public static getGoodsDispatchWarehouse_resultHelper OBJ = new getGoodsDispatchWarehouse_resultHelper();
			
			public static getGoodsDispatchWarehouse_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getGoodsDispatchWarehouse_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.biz.response.GetGoodsDispatchWarehouseResp value;
					
					value = new com.vip.order.biz.response.GetGoodsDispatchWarehouseResp();
					com.vip.order.biz.response.GetGoodsDispatchWarehouseRespHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getGoodsDispatchWarehouse_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.order.biz.response.GetGoodsDispatchWarehouseRespHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getGoodsDispatchWarehouse_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getLimitedOrderGoodsCount_resultHelper : TBeanSerializer<getLimitedOrderGoodsCount_result>
		{
			
			public static getLimitedOrderGoodsCount_resultHelper OBJ = new getLimitedOrderGoodsCount_resultHelper();
			
			public static getLimitedOrderGoodsCount_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getLimitedOrderGoodsCount_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.biz.response.GetLimitedOrderGoodsCountResp value;
					
					value = new com.vip.order.biz.response.GetLimitedOrderGoodsCountResp();
					com.vip.order.biz.response.GetLimitedOrderGoodsCountRespHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getLimitedOrderGoodsCount_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.order.biz.response.GetLimitedOrderGoodsCountRespHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getLimitedOrderGoodsCount_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getLinkageOrders_resultHelper : TBeanSerializer<getLinkageOrders_result>
		{
			
			public static getLinkageOrders_resultHelper OBJ = new getLinkageOrders_resultHelper();
			
			public static getLinkageOrders_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getLinkageOrders_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.biz.response.LinkageOrderResp value;
					
					value = new com.vip.order.biz.response.LinkageOrderResp();
					com.vip.order.biz.response.LinkageOrderRespHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getLinkageOrders_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.order.biz.response.LinkageOrderRespHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getLinkageOrders_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getMergeOrderList_resultHelper : TBeanSerializer<getMergeOrderList_result>
		{
			
			public static getMergeOrderList_resultHelper OBJ = new getMergeOrderList_resultHelper();
			
			public static getMergeOrderList_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getMergeOrderList_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.biz.response.GetMergeOrderResp value;
					
					value = new com.vip.order.biz.response.GetMergeOrderResp();
					com.vip.order.biz.response.GetMergeOrderRespHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getMergeOrderList_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.order.biz.response.GetMergeOrderRespHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getMergeOrderList_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getOrderCounts_resultHelper : TBeanSerializer<getOrderCounts_result>
		{
			
			public static getOrderCounts_resultHelper OBJ = new getOrderCounts_resultHelper();
			
			public static getOrderCounts_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getOrderCounts_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.biz.response.OrderListCountResp value;
					
					value = new com.vip.order.biz.response.OrderListCountResp();
					com.vip.order.biz.response.OrderListCountRespHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getOrderCounts_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.order.biz.response.OrderListCountRespHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getOrderCounts_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getOrderCountsByUserId_resultHelper : TBeanSerializer<getOrderCountsByUserId_result>
		{
			
			public static getOrderCountsByUserId_resultHelper OBJ = new getOrderCountsByUserId_resultHelper();
			
			public static getOrderCountsByUserId_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getOrderCountsByUserId_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.biz.response.OrderListCountResp value;
					
					value = new com.vip.order.biz.response.OrderListCountResp();
					com.vip.order.biz.response.OrderListCountRespHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getOrderCountsByUserId_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.order.biz.response.OrderListCountRespHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getOrderCountsByUserId_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getOrderDeliveryBoxNum_resultHelper : TBeanSerializer<getOrderDeliveryBoxNum_result>
		{
			
			public static getOrderDeliveryBoxNum_resultHelper OBJ = new getOrderDeliveryBoxNum_resultHelper();
			
			public static getOrderDeliveryBoxNum_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getOrderDeliveryBoxNum_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.biz.response.GetOrderDeliveryBoxNumResp value;
					
					value = new com.vip.order.biz.response.GetOrderDeliveryBoxNumResp();
					com.vip.order.biz.response.GetOrderDeliveryBoxNumRespHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getOrderDeliveryBoxNum_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.order.biz.response.GetOrderDeliveryBoxNumRespHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getOrderDeliveryBoxNum_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getOrderDetail_resultHelper : TBeanSerializer<getOrderDetail_result>
		{
			
			public static getOrderDetail_resultHelper OBJ = new getOrderDetail_resultHelper();
			
			public static getOrderDetail_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getOrderDetail_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.biz.response.SearchOrderDetailResp value;
					
					value = new com.vip.order.biz.response.SearchOrderDetailResp();
					com.vip.order.biz.response.SearchOrderDetailRespHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getOrderDetail_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.order.biz.response.SearchOrderDetailRespHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getOrderDetail_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getOrderElectronicInvoicesV2_resultHelper : TBeanSerializer<getOrderElectronicInvoicesV2_result>
		{
			
			public static getOrderElectronicInvoicesV2_resultHelper OBJ = new getOrderElectronicInvoicesV2_resultHelper();
			
			public static getOrderElectronicInvoicesV2_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getOrderElectronicInvoicesV2_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.biz.response.OrderElectronicInvoicesV2Resp value;
					
					value = new com.vip.order.biz.response.OrderElectronicInvoicesV2Resp();
					com.vip.order.biz.response.OrderElectronicInvoicesV2RespHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getOrderElectronicInvoicesV2_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.order.biz.response.OrderElectronicInvoicesV2RespHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getOrderElectronicInvoicesV2_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getOrderFav_resultHelper : TBeanSerializer<getOrderFav_result>
		{
			
			public static getOrderFav_resultHelper OBJ = new getOrderFav_resultHelper();
			
			public static getOrderFav_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getOrderFav_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.biz.response.GetOrderFavResp value;
					
					value = new com.vip.order.biz.response.GetOrderFavResp();
					com.vip.order.biz.response.GetOrderFavRespHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getOrderFav_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.order.biz.response.GetOrderFavRespHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getOrderFav_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getOrderGoodsCount_resultHelper : TBeanSerializer<getOrderGoodsCount_result>
		{
			
			public static getOrderGoodsCount_resultHelper OBJ = new getOrderGoodsCount_resultHelper();
			
			public static getOrderGoodsCount_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getOrderGoodsCount_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.biz.response.GetOrderGoodsCountResultResp value;
					
					value = new com.vip.order.biz.response.GetOrderGoodsCountResultResp();
					com.vip.order.biz.response.GetOrderGoodsCountResultRespHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getOrderGoodsCount_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.order.biz.response.GetOrderGoodsCountResultRespHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getOrderGoodsCount_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getOrderGoodsList_resultHelper : TBeanSerializer<getOrderGoodsList_result>
		{
			
			public static getOrderGoodsList_resultHelper OBJ = new getOrderGoodsList_resultHelper();
			
			public static getOrderGoodsList_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getOrderGoodsList_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.biz.response.GetOrderGoodsResultResp value;
					
					value = new com.vip.order.biz.response.GetOrderGoodsResultResp();
					com.vip.order.biz.response.GetOrderGoodsResultRespHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getOrderGoodsList_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.order.biz.response.GetOrderGoodsResultRespHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getOrderGoodsList_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getOrderInstalmentsList_resultHelper : TBeanSerializer<getOrderInstalmentsList_result>
		{
			
			public static getOrderInstalmentsList_resultHelper OBJ = new getOrderInstalmentsList_resultHelper();
			
			public static getOrderInstalmentsList_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getOrderInstalmentsList_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.biz.response.GetOrderInstalmentsListResp value;
					
					value = new com.vip.order.biz.response.GetOrderInstalmentsListResp();
					com.vip.order.biz.response.GetOrderInstalmentsListRespHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getOrderInstalmentsList_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.order.biz.response.GetOrderInstalmentsListRespHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getOrderInstalmentsList_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getOrderInvoicesV2_resultHelper : TBeanSerializer<getOrderInvoicesV2_result>
		{
			
			public static getOrderInvoicesV2_resultHelper OBJ = new getOrderInvoicesV2_resultHelper();
			
			public static getOrderInvoicesV2_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getOrderInvoicesV2_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.biz.response.OrderInvoicesV2Resp value;
					
					value = new com.vip.order.biz.response.OrderInvoicesV2Resp();
					com.vip.order.biz.response.OrderInvoicesV2RespHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getOrderInvoicesV2_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.order.biz.response.OrderInvoicesV2RespHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getOrderInvoicesV2_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getOrderList_resultHelper : TBeanSerializer<getOrderList_result>
		{
			
			public static getOrderList_resultHelper OBJ = new getOrderList_resultHelper();
			
			public static getOrderList_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getOrderList_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.biz.response.SearchOrderListResp value;
					
					value = new com.vip.order.biz.response.SearchOrderListResp();
					com.vip.order.biz.response.SearchOrderListRespHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getOrderList_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.order.biz.response.SearchOrderListRespHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getOrderList_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getOrderListByPosNo_resultHelper : TBeanSerializer<getOrderListByPosNo_result>
		{
			
			public static getOrderListByPosNo_resultHelper OBJ = new getOrderListByPosNo_resultHelper();
			
			public static getOrderListByPosNo_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getOrderListByPosNo_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.biz.response.GetOrderListByPosNoResp value;
					
					value = new com.vip.order.biz.response.GetOrderListByPosNoResp();
					com.vip.order.biz.response.GetOrderListByPosNoRespHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getOrderListByPosNo_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.order.biz.response.GetOrderListByPosNoRespHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getOrderListByPosNo_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getOrderListByUserId_resultHelper : TBeanSerializer<getOrderListByUserId_result>
		{
			
			public static getOrderListByUserId_resultHelper OBJ = new getOrderListByUserId_resultHelper();
			
			public static getOrderListByUserId_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getOrderListByUserId_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.biz.response.GetOrderListByUserIdResp value;
					
					value = new com.vip.order.biz.response.GetOrderListByUserIdResp();
					com.vip.order.biz.response.GetOrderListByUserIdRespHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getOrderListByUserId_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.order.biz.response.GetOrderListByUserIdRespHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getOrderListByUserId_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getOrderLogs_resultHelper : TBeanSerializer<getOrderLogs_result>
		{
			
			public static getOrderLogs_resultHelper OBJ = new getOrderLogs_resultHelper();
			
			public static getOrderLogs_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getOrderLogs_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.biz.response.GetOrderLogsResp value;
					
					value = new com.vip.order.biz.response.GetOrderLogsResp();
					com.vip.order.biz.response.GetOrderLogsRespHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getOrderLogs_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.order.biz.response.GetOrderLogsRespHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getOrderLogs_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getOrderOpStatus_resultHelper : TBeanSerializer<getOrderOpStatus_result>
		{
			
			public static getOrderOpStatus_resultHelper OBJ = new getOrderOpStatus_resultHelper();
			
			public static getOrderOpStatus_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getOrderOpStatus_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.biz.response.GetOrderOpStatusResp value;
					
					value = new com.vip.order.biz.response.GetOrderOpStatusResp();
					com.vip.order.biz.response.GetOrderOpStatusRespHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getOrderOpStatus_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.order.biz.response.GetOrderOpStatusRespHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getOrderOpStatus_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getOrderPackageList_resultHelper : TBeanSerializer<getOrderPackageList_result>
		{
			
			public static getOrderPackageList_resultHelper OBJ = new getOrderPackageList_resultHelper();
			
			public static getOrderPackageList_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getOrderPackageList_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.biz.response.GetOrderPackageListResp value;
					
					value = new com.vip.order.biz.response.GetOrderPackageListResp();
					com.vip.order.biz.response.GetOrderPackageListRespHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getOrderPackageList_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.order.biz.response.GetOrderPackageListRespHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getOrderPackageList_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getOrderPayType_resultHelper : TBeanSerializer<getOrderPayType_result>
		{
			
			public static getOrderPayType_resultHelper OBJ = new getOrderPayType_resultHelper();
			
			public static getOrderPayType_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getOrderPayType_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.biz.response.GetOrderPayTypeResp value;
					
					value = new com.vip.order.biz.response.GetOrderPayTypeResp();
					com.vip.order.biz.response.GetOrderPayTypeRespHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getOrderPayType_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.order.biz.response.GetOrderPayTypeRespHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getOrderPayType_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getOrderSnByExOrderSn_resultHelper : TBeanSerializer<getOrderSnByExOrderSn_result>
		{
			
			public static getOrderSnByExOrderSn_resultHelper OBJ = new getOrderSnByExOrderSn_resultHelper();
			
			public static getOrderSnByExOrderSn_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getOrderSnByExOrderSn_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.biz.response.GetOrderSnByExOrderSnResp value;
					
					value = new com.vip.order.biz.response.GetOrderSnByExOrderSnResp();
					com.vip.order.biz.response.GetOrderSnByExOrderSnRespHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getOrderSnByExOrderSn_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.order.biz.response.GetOrderSnByExOrderSnRespHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getOrderSnByExOrderSn_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getOrderTransport_resultHelper : TBeanSerializer<getOrderTransport_result>
		{
			
			public static getOrderTransport_resultHelper OBJ = new getOrderTransport_resultHelper();
			
			public static getOrderTransport_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getOrderTransport_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.biz.response.GetOrderTransportResp value;
					
					value = new com.vip.order.biz.response.GetOrderTransportResp();
					com.vip.order.biz.response.GetOrderTransportRespHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getOrderTransport_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.order.biz.response.GetOrderTransportRespHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getOrderTransport_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getOrderTransportDetail_resultHelper : TBeanSerializer<getOrderTransportDetail_result>
		{
			
			public static getOrderTransportDetail_resultHelper OBJ = new getOrderTransportDetail_resultHelper();
			
			public static getOrderTransportDetail_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getOrderTransportDetail_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.biz.response.GetOrderTransportDetailResp value;
					
					value = new com.vip.order.biz.response.GetOrderTransportDetailResp();
					com.vip.order.biz.response.GetOrderTransportDetailRespHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getOrderTransportDetail_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.order.biz.response.GetOrderTransportDetailRespHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getOrderTransportDetail_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getOrderTransportListByCodes_resultHelper : TBeanSerializer<getOrderTransportListByCodes_result>
		{
			
			public static getOrderTransportListByCodes_resultHelper OBJ = new getOrderTransportListByCodes_resultHelper();
			
			public static getOrderTransportListByCodes_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getOrderTransportListByCodes_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.biz.response.GetTransportListByCodesResp value;
					
					value = new com.vip.order.biz.response.GetTransportListByCodesResp();
					com.vip.order.biz.response.GetTransportListByCodesRespHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getOrderTransportListByCodes_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.order.biz.response.GetTransportListByCodesRespHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getOrderTransportListByCodes_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getOrdersBySizeId_resultHelper : TBeanSerializer<getOrdersBySizeId_result>
		{
			
			public static getOrdersBySizeId_resultHelper OBJ = new getOrdersBySizeId_resultHelper();
			
			public static getOrdersBySizeId_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getOrdersBySizeId_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.biz.response.GetOrdersBySizeIdResp value;
					
					value = new com.vip.order.biz.response.GetOrdersBySizeIdResp();
					com.vip.order.biz.response.GetOrdersBySizeIdRespHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getOrdersBySizeId_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.order.biz.response.GetOrdersBySizeIdRespHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getOrdersBySizeId_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getPrepayOrderStatus_resultHelper : TBeanSerializer<getPrepayOrderStatus_result>
		{
			
			public static getPrepayOrderStatus_resultHelper OBJ = new getPrepayOrderStatus_resultHelper();
			
			public static getPrepayOrderStatus_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getPrepayOrderStatus_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.biz.response.GetPrepayOrderStatusResp value;
					
					value = new com.vip.order.biz.response.GetPrepayOrderStatusResp();
					com.vip.order.biz.response.GetPrepayOrderStatusRespHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getPrepayOrderStatus_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.order.biz.response.GetPrepayOrderStatusRespHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getPrepayOrderStatus_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getPrepayOrderUnpayMsg_resultHelper : TBeanSerializer<getPrepayOrderUnpayMsg_result>
		{
			
			public static getPrepayOrderUnpayMsg_resultHelper OBJ = new getPrepayOrderUnpayMsg_resultHelper();
			
			public static getPrepayOrderUnpayMsg_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getPrepayOrderUnpayMsg_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.biz.response.GetPrepayOrderUnpayMsgResp value;
					
					value = new com.vip.order.biz.response.GetPrepayOrderUnpayMsgResp();
					com.vip.order.biz.response.GetPrepayOrderUnpayMsgRespHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getPrepayOrderUnpayMsg_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.order.biz.response.GetPrepayOrderUnpayMsgRespHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getPrepayOrderUnpayMsg_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getRdc_resultHelper : TBeanSerializer<getRdc_result>
		{
			
			public static getRdc_resultHelper OBJ = new getRdc_resultHelper();
			
			public static getRdc_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getRdc_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.biz.response.GetRdcResp value;
					
					value = new com.vip.order.biz.response.GetRdcResp();
					com.vip.order.biz.response.GetRdcRespHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getRdc_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.order.biz.response.GetRdcRespHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getRdc_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getRdcInvoice_resultHelper : TBeanSerializer<getRdcInvoice_result>
		{
			
			public static getRdcInvoice_resultHelper OBJ = new getRdcInvoice_resultHelper();
			
			public static getRdcInvoice_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getRdcInvoice_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.biz.response.GetRdcInvoiceResp value;
					
					value = new com.vip.order.biz.response.GetRdcInvoiceResp();
					com.vip.order.biz.response.GetRdcInvoiceRespHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getRdcInvoice_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.order.biz.response.GetRdcInvoiceRespHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getRdcInvoice_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getReturnOrExchangeGoods_resultHelper : TBeanSerializer<getReturnOrExchangeGoods_result>
		{
			
			public static getReturnOrExchangeGoods_resultHelper OBJ = new getReturnOrExchangeGoods_resultHelper();
			
			public static getReturnOrExchangeGoods_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getReturnOrExchangeGoods_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.biz.response.GetReturnOrExchangeGoodsResp value;
					
					value = new com.vip.order.biz.response.GetReturnOrExchangeGoodsResp();
					com.vip.order.biz.response.GetReturnOrExchangeGoodsRespHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getReturnOrExchangeGoods_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.order.biz.response.GetReturnOrExchangeGoodsRespHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getReturnOrExchangeGoods_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getSimpleOrderFlowFlag_resultHelper : TBeanSerializer<getSimpleOrderFlowFlag_result>
		{
			
			public static getSimpleOrderFlowFlag_resultHelper OBJ = new getSimpleOrderFlowFlag_resultHelper();
			
			public static getSimpleOrderFlowFlag_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getSimpleOrderFlowFlag_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.biz.response.GetSimpleOrderFlowFlagResp value;
					
					value = new com.vip.order.biz.response.GetSimpleOrderFlowFlagResp();
					com.vip.order.biz.response.GetSimpleOrderFlowFlagRespHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getSimpleOrderFlowFlag_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.order.biz.response.GetSimpleOrderFlowFlagRespHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getSimpleOrderFlowFlag_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getUnpayOrderList_resultHelper : TBeanSerializer<getUnpayOrderList_result>
		{
			
			public static getUnpayOrderList_resultHelper OBJ = new getUnpayOrderList_resultHelper();
			
			public static getUnpayOrderList_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getUnpayOrderList_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.biz.response.GetUnpayOrderResp value;
					
					value = new com.vip.order.biz.response.GetUnpayOrderResp();
					com.vip.order.biz.response.GetUnpayOrderRespHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getUnpayOrderList_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.order.biz.response.GetUnpayOrderRespHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getUnpayOrderList_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getUserDeliveryAddress_resultHelper : TBeanSerializer<getUserDeliveryAddress_result>
		{
			
			public static getUserDeliveryAddress_resultHelper OBJ = new getUserDeliveryAddress_resultHelper();
			
			public static getUserDeliveryAddress_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getUserDeliveryAddress_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.biz.response.GetUserDeliveryAddressResp value;
					
					value = new com.vip.order.biz.response.GetUserDeliveryAddressResp();
					com.vip.order.biz.response.GetUserDeliveryAddressRespHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getUserDeliveryAddress_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.order.biz.response.GetUserDeliveryAddressRespHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getUserDeliveryAddress_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getUserFirstOrder_resultHelper : TBeanSerializer<getUserFirstOrder_result>
		{
			
			public static getUserFirstOrder_resultHelper OBJ = new getUserFirstOrder_resultHelper();
			
			public static getUserFirstOrder_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getUserFirstOrder_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.biz.response.GetUserFirstOrderResp value;
					
					value = new com.vip.order.biz.response.GetUserFirstOrderResp();
					com.vip.order.biz.response.GetUserFirstOrderRespHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getUserFirstOrder_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.order.biz.response.GetUserFirstOrderRespHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getUserFirstOrder_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class healthCheck_resultHelper : TBeanSerializer<healthCheck_result>
		{
			
			public static healthCheck_resultHelper OBJ = new healthCheck_resultHelper();
			
			public static healthCheck_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(healthCheck_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.hermes.core.health.CheckResult value;
					
					value = new com.vip.hermes.core.health.CheckResult();
					com.vip.hermes.core.health.CheckResultHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(healthCheck_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.hermes.core.health.CheckResultHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(healthCheck_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class mergeOrder_resultHelper : TBeanSerializer<mergeOrder_result>
		{
			
			public static mergeOrder_resultHelper OBJ = new mergeOrder_resultHelper();
			
			public static mergeOrder_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(mergeOrder_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.biz.response.MergeOrderResp value;
					
					value = new com.vip.order.biz.response.MergeOrderResp();
					com.vip.order.biz.response.MergeOrderRespHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(mergeOrder_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.order.biz.response.MergeOrderRespHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(mergeOrder_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class modifyOrderConsignee_resultHelper : TBeanSerializer<modifyOrderConsignee_result>
		{
			
			public static modifyOrderConsignee_resultHelper OBJ = new modifyOrderConsignee_resultHelper();
			
			public static modifyOrderConsignee_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(modifyOrderConsignee_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.biz.response.ModifyOrderConsigneeResp value;
					
					value = new com.vip.order.biz.response.ModifyOrderConsigneeResp();
					com.vip.order.biz.response.ModifyOrderConsigneeRespHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(modifyOrderConsignee_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.order.biz.response.ModifyOrderConsigneeRespHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(modifyOrderConsignee_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class modifyOrderElectronicInvoice_resultHelper : TBeanSerializer<modifyOrderElectronicInvoice_result>
		{
			
			public static modifyOrderElectronicInvoice_resultHelper OBJ = new modifyOrderElectronicInvoice_resultHelper();
			
			public static modifyOrderElectronicInvoice_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(modifyOrderElectronicInvoice_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.biz.response.ModifyOrderElectronicInvoiceResp value;
					
					value = new com.vip.order.biz.response.ModifyOrderElectronicInvoiceResp();
					com.vip.order.biz.response.ModifyOrderElectronicInvoiceRespHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(modifyOrderElectronicInvoice_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.order.biz.response.ModifyOrderElectronicInvoiceRespHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(modifyOrderElectronicInvoice_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class modifyOrderGoods_resultHelper : TBeanSerializer<modifyOrderGoods_result>
		{
			
			public static modifyOrderGoods_resultHelper OBJ = new modifyOrderGoods_resultHelper();
			
			public static modifyOrderGoods_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(modifyOrderGoods_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.biz.response.ModifyOrderGoodsResp value;
					
					value = new com.vip.order.biz.response.ModifyOrderGoodsResp();
					com.vip.order.biz.response.ModifyOrderGoodsRespHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(modifyOrderGoods_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.order.biz.response.ModifyOrderGoodsRespHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(modifyOrderGoods_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class modifyOrderPayType_resultHelper : TBeanSerializer<modifyOrderPayType_result>
		{
			
			public static modifyOrderPayType_resultHelper OBJ = new modifyOrderPayType_resultHelper();
			
			public static modifyOrderPayType_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(modifyOrderPayType_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.biz.request.ModifyOrderPayTypeRsp value;
					
					value = new com.vip.order.biz.request.ModifyOrderPayTypeRsp();
					com.vip.order.biz.request.ModifyOrderPayTypeRspHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(modifyOrderPayType_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.order.biz.request.ModifyOrderPayTypeRspHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(modifyOrderPayType_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class modifyOrderQualified_resultHelper : TBeanSerializer<modifyOrderQualified_result>
		{
			
			public static modifyOrderQualified_resultHelper OBJ = new modifyOrderQualified_resultHelper();
			
			public static modifyOrderQualified_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(modifyOrderQualified_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.biz.response.ModifyOrderQualifiedResp value;
					
					value = new com.vip.order.biz.response.ModifyOrderQualifiedResp();
					com.vip.order.biz.response.ModifyOrderQualifiedRespHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(modifyOrderQualified_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.order.biz.response.ModifyOrderQualifiedRespHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(modifyOrderQualified_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class modifyOrderShipped_resultHelper : TBeanSerializer<modifyOrderShipped_result>
		{
			
			public static modifyOrderShipped_resultHelper OBJ = new modifyOrderShipped_resultHelper();
			
			public static modifyOrderShipped_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(modifyOrderShipped_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.biz.response.ModifyOrderShippedResp value;
					
					value = new com.vip.order.biz.response.ModifyOrderShippedResp();
					com.vip.order.biz.response.ModifyOrderShippedRespHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(modifyOrderShipped_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.order.biz.response.ModifyOrderShippedRespHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(modifyOrderShipped_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class modifyPrepayOrderPayType_resultHelper : TBeanSerializer<modifyPrepayOrderPayType_result>
		{
			
			public static modifyPrepayOrderPayType_resultHelper OBJ = new modifyPrepayOrderPayType_resultHelper();
			
			public static modifyPrepayOrderPayType_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(modifyPrepayOrderPayType_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.biz.request.ModifyOrderPayTypeRsp value;
					
					value = new com.vip.order.biz.request.ModifyOrderPayTypeRsp();
					com.vip.order.biz.request.ModifyOrderPayTypeRspHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(modifyPrepayOrderPayType_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.order.biz.request.ModifyOrderPayTypeRspHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(modifyPrepayOrderPayType_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class notifyCustomsDeclarationFailed_resultHelper : TBeanSerializer<notifyCustomsDeclarationFailed_result>
		{
			
			public static notifyCustomsDeclarationFailed_resultHelper OBJ = new notifyCustomsDeclarationFailed_resultHelper();
			
			public static notifyCustomsDeclarationFailed_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(notifyCustomsDeclarationFailed_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.biz.response.NotifyCustomsDeclarationFailedResp value;
					
					value = new com.vip.order.biz.response.NotifyCustomsDeclarationFailedResp();
					com.vip.order.biz.response.NotifyCustomsDeclarationFailedRespHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(notifyCustomsDeclarationFailed_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.order.biz.response.NotifyCustomsDeclarationFailedRespHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(notifyCustomsDeclarationFailed_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class ofcEntranceGrayControl_resultHelper : TBeanSerializer<ofcEntranceGrayControl_result>
		{
			
			public static ofcEntranceGrayControl_resultHelper OBJ = new ofcEntranceGrayControl_resultHelper();
			
			public static ofcEntranceGrayControl_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(ofcEntranceGrayControl_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.biz.response.OfcEntranceGrayControlResp value;
					
					value = new com.vip.order.biz.response.OfcEntranceGrayControlResp();
					com.vip.order.biz.response.OfcEntranceGrayControlRespHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(ofcEntranceGrayControl_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.order.biz.response.OfcEntranceGrayControlRespHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(ofcEntranceGrayControl_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class paymentReceived_resultHelper : TBeanSerializer<paymentReceived_result>
		{
			
			public static paymentReceived_resultHelper OBJ = new paymentReceived_resultHelper();
			
			public static paymentReceived_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(paymentReceived_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.biz.response.PaymentReceivedResp value;
					
					value = new com.vip.order.biz.response.PaymentReceivedResp();
					com.vip.order.biz.response.PaymentReceivedRespHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(paymentReceived_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.order.biz.response.PaymentReceivedRespHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(paymentReceived_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class postOrderVMSMessage_resultHelper : TBeanSerializer<postOrderVMSMessage_result>
		{
			
			public static postOrderVMSMessage_resultHelper OBJ = new postOrderVMSMessage_resultHelper();
			
			public static postOrderVMSMessage_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(postOrderVMSMessage_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.biz.response.PostOrderVMSMessageResp value;
					
					value = new com.vip.order.biz.response.PostOrderVMSMessageResp();
					com.vip.order.biz.response.PostOrderVMSMessageRespHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(postOrderVMSMessage_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.order.biz.response.PostOrderVMSMessageRespHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(postOrderVMSMessage_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class putIntoSplitQueue_resultHelper : TBeanSerializer<putIntoSplitQueue_result>
		{
			
			public static putIntoSplitQueue_resultHelper OBJ = new putIntoSplitQueue_resultHelper();
			
			public static putIntoSplitQueue_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(putIntoSplitQueue_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.biz.response.PutIntoSplitQueueResp value;
					
					value = new com.vip.order.biz.response.PutIntoSplitQueueResp();
					com.vip.order.biz.response.PutIntoSplitQueueRespHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(putIntoSplitQueue_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.order.biz.response.PutIntoSplitQueueRespHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(putIntoSplitQueue_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class putKeyToRollbackQueue_resultHelper : TBeanSerializer<putKeyToRollbackQueue_result>
		{
			
			public static putKeyToRollbackQueue_resultHelper OBJ = new putKeyToRollbackQueue_resultHelper();
			
			public static putKeyToRollbackQueue_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(putKeyToRollbackQueue_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.biz.response.PutKeyToRollbackQueueResp value;
					
					value = new com.vip.order.biz.response.PutKeyToRollbackQueueResp();
					com.vip.order.biz.response.PutKeyToRollbackQueueRespHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(putKeyToRollbackQueue_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.order.biz.response.PutKeyToRollbackQueueRespHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(putKeyToRollbackQueue_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class putOrderToRollbackQueue_resultHelper : TBeanSerializer<putOrderToRollbackQueue_result>
		{
			
			public static putOrderToRollbackQueue_resultHelper OBJ = new putOrderToRollbackQueue_resultHelper();
			
			public static putOrderToRollbackQueue_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(putOrderToRollbackQueue_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.biz.response.PutOrderToRollbackQueueResp value;
					
					value = new com.vip.order.biz.response.PutOrderToRollbackQueueResp();
					com.vip.order.biz.response.PutOrderToRollbackQueueRespHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(putOrderToRollbackQueue_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.order.biz.response.PutOrderToRollbackQueueRespHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(putOrderToRollbackQueue_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class receptionConfirmDelivered_resultHelper : TBeanSerializer<receptionConfirmDelivered_result>
		{
			
			public static receptionConfirmDelivered_resultHelper OBJ = new receptionConfirmDelivered_resultHelper();
			
			public static receptionConfirmDelivered_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(receptionConfirmDelivered_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.biz.response.ReceptionConfirmDeliveredResp value;
					
					value = new com.vip.order.biz.response.ReceptionConfirmDeliveredResp();
					com.vip.order.biz.response.ReceptionConfirmDeliveredRespHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(receptionConfirmDelivered_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.order.biz.response.ReceptionConfirmDeliveredRespHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(receptionConfirmDelivered_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class refundOrder_resultHelper : TBeanSerializer<refundOrder_result>
		{
			
			public static refundOrder_resultHelper OBJ = new refundOrder_resultHelper();
			
			public static refundOrder_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(refundOrder_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.biz.response.OrderRefundResp value;
					
					value = new com.vip.order.biz.response.OrderRefundResp();
					com.vip.order.biz.response.OrderRefundRespHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(refundOrder_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.order.biz.response.OrderRefundRespHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(refundOrder_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class releaseStock_resultHelper : TBeanSerializer<releaseStock_result>
		{
			
			public static releaseStock_resultHelper OBJ = new releaseStock_resultHelper();
			
			public static releaseStock_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(releaseStock_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.biz.response.ReleaseStockResp value;
					
					value = new com.vip.order.biz.response.ReleaseStockResp();
					com.vip.order.biz.response.ReleaseStockRespHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(releaseStock_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.order.biz.response.ReleaseStockRespHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(releaseStock_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class rollbackOrder_resultHelper : TBeanSerializer<rollbackOrder_result>
		{
			
			public static rollbackOrder_resultHelper OBJ = new rollbackOrder_resultHelper();
			
			public static rollbackOrder_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(rollbackOrder_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.biz.response.RollbackOrderResp value;
					
					value = new com.vip.order.biz.response.RollbackOrderResp();
					com.vip.order.biz.response.RollbackOrderRespHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(rollbackOrder_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.order.biz.response.RollbackOrderRespHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(rollbackOrder_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class searchOrderListByUserId_resultHelper : TBeanSerializer<searchOrderListByUserId_result>
		{
			
			public static searchOrderListByUserId_resultHelper OBJ = new searchOrderListByUserId_resultHelper();
			
			public static searchOrderListByUserId_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(searchOrderListByUserId_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.biz.response.SearchOrderListByUserIdResp value;
					
					value = new com.vip.order.biz.response.SearchOrderListByUserIdResp();
					com.vip.order.biz.response.SearchOrderListByUserIdRespHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(searchOrderListByUserId_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.order.biz.response.SearchOrderListByUserIdRespHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(searchOrderListByUserId_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class signOrder_resultHelper : TBeanSerializer<signOrder_result>
		{
			
			public static signOrder_resultHelper OBJ = new signOrder_resultHelper();
			
			public static signOrder_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(signOrder_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.biz.response.SignOrderResp value;
					
					value = new com.vip.order.biz.response.SignOrderResp();
					com.vip.order.biz.response.SignOrderRespHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(signOrder_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.order.biz.response.SignOrderRespHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(signOrder_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class triggerGroupByAuditOrder_resultHelper : TBeanSerializer<triggerGroupByAuditOrder_result>
		{
			
			public static triggerGroupByAuditOrder_resultHelper OBJ = new triggerGroupByAuditOrder_resultHelper();
			
			public static triggerGroupByAuditOrder_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(triggerGroupByAuditOrder_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.biz.response.GroupByOrderAuditResp value;
					
					value = new com.vip.order.biz.response.GroupByOrderAuditResp();
					com.vip.order.biz.response.GroupByOrderAuditRespHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(triggerGroupByAuditOrder_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.order.biz.response.GroupByOrderAuditRespHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(triggerGroupByAuditOrder_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class updateAutoPayAuth_resultHelper : TBeanSerializer<updateAutoPayAuth_result>
		{
			
			public static updateAutoPayAuth_resultHelper OBJ = new updateAutoPayAuth_resultHelper();
			
			public static updateAutoPayAuth_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(updateAutoPayAuth_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.biz.response.UpdateAutoPayAuthResp value;
					
					value = new com.vip.order.biz.response.UpdateAutoPayAuthResp();
					com.vip.order.biz.response.UpdateAutoPayAuthRespHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(updateAutoPayAuth_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.order.biz.response.UpdateAutoPayAuthRespHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(updateAutoPayAuth_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class updateOrderPayResult_resultHelper : TBeanSerializer<updateOrderPayResult_result>
		{
			
			public static updateOrderPayResult_resultHelper OBJ = new updateOrderPayResult_resultHelper();
			
			public static updateOrderPayResult_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(updateOrderPayResult_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.biz.response.UpdateOrderPayResultResp value;
					
					value = new com.vip.order.biz.response.UpdateOrderPayResultResp();
					com.vip.order.biz.response.UpdateOrderPayResultRespHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(updateOrderPayResult_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.order.biz.response.UpdateOrderPayResultRespHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(updateOrderPayResult_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class updateOrderToReturnVerified_resultHelper : TBeanSerializer<updateOrderToReturnVerified_result>
		{
			
			public static updateOrderToReturnVerified_resultHelper OBJ = new updateOrderToReturnVerified_resultHelper();
			
			public static updateOrderToReturnVerified_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(updateOrderToReturnVerified_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.biz.response.UpdateOrderToReturnVerifiedResp value;
					
					value = new com.vip.order.biz.response.UpdateOrderToReturnVerifiedResp();
					com.vip.order.biz.response.UpdateOrderToReturnVerifiedRespHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(updateOrderToReturnVerified_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.order.biz.response.UpdateOrderToReturnVerifiedRespHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(updateOrderToReturnVerified_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class updatePayTypeToCOD_resultHelper : TBeanSerializer<updatePayTypeToCOD_result>
		{
			
			public static updatePayTypeToCOD_resultHelper OBJ = new updatePayTypeToCOD_resultHelper();
			
			public static updatePayTypeToCOD_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(updatePayTypeToCOD_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.biz.response.UpdatePayTypeToCODResp value;
					
					value = new com.vip.order.biz.response.UpdatePayTypeToCODResp();
					com.vip.order.biz.response.UpdatePayTypeToCODRespHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(updatePayTypeToCOD_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.order.biz.response.UpdatePayTypeToCODRespHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(updatePayTypeToCOD_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class updatePrePayToVerified_resultHelper : TBeanSerializer<updatePrePayToVerified_result>
		{
			
			public static updatePrePayToVerified_resultHelper OBJ = new updatePrePayToVerified_resultHelper();
			
			public static updatePrePayToVerified_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(updatePrePayToVerified_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.biz.response.UpdatePrePayToVerifiedResp value;
					
					value = new com.vip.order.biz.response.UpdatePrePayToVerifiedResp();
					com.vip.order.biz.response.UpdatePrePayToVerifiedRespHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(updatePrePayToVerified_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.order.biz.response.UpdatePrePayToVerifiedRespHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(updatePrePayToVerified_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class updateReservationState_resultHelper : TBeanSerializer<updateReservationState_result>
		{
			
			public static updateReservationState_resultHelper OBJ = new updateReservationState_resultHelper();
			
			public static updateReservationState_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(updateReservationState_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.biz.response.UpdateReservationStateResp value;
					
					value = new com.vip.order.biz.response.UpdateReservationStateResp();
					com.vip.order.biz.response.UpdateReservationStateRespHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(updateReservationState_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.order.biz.response.UpdateReservationStateRespHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(updateReservationState_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class userDeleteOrder_resultHelper : TBeanSerializer<userDeleteOrder_result>
		{
			
			public static userDeleteOrder_resultHelper OBJ = new userDeleteOrder_resultHelper();
			
			public static userDeleteOrder_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(userDeleteOrder_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.biz.response.UserDeleteOrderResp value;
					
					value = new com.vip.order.biz.response.UserDeleteOrderResp();
					com.vip.order.biz.response.UserDeleteOrderRespHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(userDeleteOrder_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.order.biz.response.UserDeleteOrderRespHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(userDeleteOrder_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class verifyStockAndGetPayableFlag_resultHelper : TBeanSerializer<verifyStockAndGetPayableFlag_result>
		{
			
			public static verifyStockAndGetPayableFlag_resultHelper OBJ = new verifyStockAndGetPayableFlag_resultHelper();
			
			public static verifyStockAndGetPayableFlag_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(verifyStockAndGetPayableFlag_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.order.biz.response.VerifyStockAndGetPayableFlagResp value;
					
					value = new com.vip.order.biz.response.VerifyStockAndGetPayableFlagResp();
					com.vip.order.biz.response.VerifyStockAndGetPayableFlagRespHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(verifyStockAndGetPayableFlag_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.order.biz.response.VerifyStockAndGetPayableFlagRespHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(verifyStockAndGetPayableFlag_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class OrdersBizServiceClient : OspRestStub , OrdersBizService  {
			
			
			public OrdersBizServiceClient():base("com.vip.order.biz.service.OrdersBizService","1.7.24") {
				
				
			}
			
			
			
			public com.vip.order.biz.response.AddOrderTransportResp addOrderTransport(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.AddOrderTransportReq addOrderTransportReq_) {
				
				send_addOrderTransport(requestHeader_,addOrderTransportReq_);
				return recv_addOrderTransport(); 
				
			}
			
			
			private void send_addOrderTransport(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.AddOrderTransportReq addOrderTransportReq_){
				
				InitInvocation("addOrderTransport");
				
				addOrderTransport_args args = new addOrderTransport_args();
				args.SetRequestHeader(requestHeader_);
				args.SetAddOrderTransportReq(addOrderTransportReq_);
				
				SendBase(args, addOrderTransport_argsHelper.getInstance());
			}
			
			
			private com.vip.order.biz.response.AddOrderTransportResp recv_addOrderTransport(){
				
				addOrderTransport_result result = new addOrderTransport_result();
				ReceiveBase(result, addOrderTransport_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.order.biz.response.AutoPayResp autoPay(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.AutoPayReq req_) {
				
				send_autoPay(requestHeader_,req_);
				return recv_autoPay(); 
				
			}
			
			
			private void send_autoPay(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.AutoPayReq req_){
				
				InitInvocation("autoPay");
				
				autoPay_args args = new autoPay_args();
				args.SetRequestHeader(requestHeader_);
				args.SetReq(req_);
				
				SendBase(args, autoPay_argsHelper.getInstance());
			}
			
			
			private com.vip.order.biz.response.AutoPayResp recv_autoPay(){
				
				autoPay_result result = new autoPay_result();
				ReceiveBase(result, autoPay_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.order.biz.response.AutoPayFailResp autoPayFail(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.AutoPayFailReq req_) {
				
				send_autoPayFail(requestHeader_,req_);
				return recv_autoPayFail(); 
				
			}
			
			
			private void send_autoPayFail(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.AutoPayFailReq req_){
				
				InitInvocation("autoPayFail");
				
				autoPayFail_args args = new autoPayFail_args();
				args.SetRequestHeader(requestHeader_);
				args.SetReq(req_);
				
				SendBase(args, autoPayFail_argsHelper.getInstance());
			}
			
			
			private com.vip.order.biz.response.AutoPayFailResp recv_autoPayFail(){
				
				autoPayFail_result result = new autoPayFail_result();
				ReceiveBase(result, autoPayFail_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.order.biz.response.AutoTakeInventoryResp autoTakeInventory(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.AutoTakeInventoryReq req_) {
				
				send_autoTakeInventory(requestHeader_,req_);
				return recv_autoTakeInventory(); 
				
			}
			
			
			private void send_autoTakeInventory(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.AutoTakeInventoryReq req_){
				
				InitInvocation("autoTakeInventory");
				
				autoTakeInventory_args args = new autoTakeInventory_args();
				args.SetRequestHeader(requestHeader_);
				args.SetReq(req_);
				
				SendBase(args, autoTakeInventory_argsHelper.getInstance());
			}
			
			
			private com.vip.order.biz.response.AutoTakeInventoryResp recv_autoTakeInventory(){
				
				autoTakeInventory_result result = new autoTakeInventory_result();
				ReceiveBase(result, autoTakeInventory_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.order.biz.response.B2CSupportSendSmsResp b2cSupportSendSms(com.vip.order.common.pojo.order.request.RequestHeader header_,com.vip.order.biz.request.B2CSupportSendSmsReq req_) {
				
				send_b2cSupportSendSms(header_,req_);
				return recv_b2cSupportSendSms(); 
				
			}
			
			
			private void send_b2cSupportSendSms(com.vip.order.common.pojo.order.request.RequestHeader header_,com.vip.order.biz.request.B2CSupportSendSmsReq req_){
				
				InitInvocation("b2cSupportSendSms");
				
				b2cSupportSendSms_args args = new b2cSupportSendSms_args();
				args.SetHeader(header_);
				args.SetReq(req_);
				
				SendBase(args, b2cSupportSendSms_argsHelper.getInstance());
			}
			
			
			private com.vip.order.biz.response.B2CSupportSendSmsResp recv_b2cSupportSendSms(){
				
				b2cSupportSendSms_result result = new b2cSupportSendSms_result();
				ReceiveBase(result, b2cSupportSendSms_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.order.biz.response.BatchGetOrderActiveDetailResp batchGetOrderActiveDetail(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.BatchGetOrderActiveDetailReq batchGetOrderActiveDetailReq_) {
				
				send_batchGetOrderActiveDetail(requestHeader_,batchGetOrderActiveDetailReq_);
				return recv_batchGetOrderActiveDetail(); 
				
			}
			
			
			private void send_batchGetOrderActiveDetail(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.BatchGetOrderActiveDetailReq batchGetOrderActiveDetailReq_){
				
				InitInvocation("batchGetOrderActiveDetail");
				
				batchGetOrderActiveDetail_args args = new batchGetOrderActiveDetail_args();
				args.SetRequestHeader(requestHeader_);
				args.SetBatchGetOrderActiveDetailReq(batchGetOrderActiveDetailReq_);
				
				SendBase(args, batchGetOrderActiveDetail_argsHelper.getInstance());
			}
			
			
			private com.vip.order.biz.response.BatchGetOrderActiveDetailResp recv_batchGetOrderActiveDetail(){
				
				batchGetOrderActiveDetail_result result = new batchGetOrderActiveDetail_result();
				ReceiveBase(result, batchGetOrderActiveDetail_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.order.biz.response.BatchGetOrderListResp batchGetOrderList(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.BatchGetOrderListReq searchOrderReq_,com.vip.order.common.pojo.order.request.ResultFilter resultFilter_) {
				
				send_batchGetOrderList(requestHeader_,searchOrderReq_,resultFilter_);
				return recv_batchGetOrderList(); 
				
			}
			
			
			private void send_batchGetOrderList(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.BatchGetOrderListReq searchOrderReq_,com.vip.order.common.pojo.order.request.ResultFilter resultFilter_){
				
				InitInvocation("batchGetOrderList");
				
				batchGetOrderList_args args = new batchGetOrderList_args();
				args.SetRequestHeader(requestHeader_);
				args.SetSearchOrderReq(searchOrderReq_);
				args.SetResultFilter(resultFilter_);
				
				SendBase(args, batchGetOrderList_argsHelper.getInstance());
			}
			
			
			private com.vip.order.biz.response.BatchGetOrderListResp recv_batchGetOrderList(){
				
				batchGetOrderList_result result = new batchGetOrderList_result();
				ReceiveBase(result, batchGetOrderList_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.order.biz.response.BatchGetOrderTransportListResp batchGetOrderTransportList(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.BatchGetOrderTransportListReq batchGetOrderTransportListReq_,com.vip.order.common.pojo.order.request.ResultFilter resultFilter_) {
				
				send_batchGetOrderTransportList(requestHeader_,batchGetOrderTransportListReq_,resultFilter_);
				return recv_batchGetOrderTransportList(); 
				
			}
			
			
			private void send_batchGetOrderTransportList(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.BatchGetOrderTransportListReq batchGetOrderTransportListReq_,com.vip.order.common.pojo.order.request.ResultFilter resultFilter_){
				
				InitInvocation("batchGetOrderTransportList");
				
				batchGetOrderTransportList_args args = new batchGetOrderTransportList_args();
				args.SetRequestHeader(requestHeader_);
				args.SetBatchGetOrderTransportListReq(batchGetOrderTransportListReq_);
				args.SetResultFilter(resultFilter_);
				
				SendBase(args, batchGetOrderTransportList_argsHelper.getInstance());
			}
			
			
			private com.vip.order.biz.response.BatchGetOrderTransportListResp recv_batchGetOrderTransportList(){
				
				batchGetOrderTransportList_result result = new batchGetOrderTransportList_result();
				ReceiveBase(result, batchGetOrderTransportList_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.order.biz.response.BatchModifyOrderInvoiceResp batchModifyOrderInvoice(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.BatchModifyOrderInvoiceReq batchModifyOrderInvoiceReq_) {
				
				send_batchModifyOrderInvoice(requestHeader_,batchModifyOrderInvoiceReq_);
				return recv_batchModifyOrderInvoice(); 
				
			}
			
			
			private void send_batchModifyOrderInvoice(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.BatchModifyOrderInvoiceReq batchModifyOrderInvoiceReq_){
				
				InitInvocation("batchModifyOrderInvoice");
				
				batchModifyOrderInvoice_args args = new batchModifyOrderInvoice_args();
				args.SetRequestHeader(requestHeader_);
				args.SetBatchModifyOrderInvoiceReq(batchModifyOrderInvoiceReq_);
				
				SendBase(args, batchModifyOrderInvoice_argsHelper.getInstance());
			}
			
			
			private com.vip.order.biz.response.BatchModifyOrderInvoiceResp recv_batchModifyOrderInvoice(){
				
				batchModifyOrderInvoice_result result = new batchModifyOrderInvoice_result();
				ReceiveBase(result, batchModifyOrderInvoice_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.order.biz.response.BatchUpdateWmsFlagResp batchUpdateWmsFlag(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.BatchUpdateWmsFlagReq batchUpdateWmsFlagReq_) {
				
				send_batchUpdateWmsFlag(requestHeader_,batchUpdateWmsFlagReq_);
				return recv_batchUpdateWmsFlag(); 
				
			}
			
			
			private void send_batchUpdateWmsFlag(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.BatchUpdateWmsFlagReq batchUpdateWmsFlagReq_){
				
				InitInvocation("batchUpdateWmsFlag");
				
				batchUpdateWmsFlag_args args = new batchUpdateWmsFlag_args();
				args.SetRequestHeader(requestHeader_);
				args.SetBatchUpdateWmsFlagReq(batchUpdateWmsFlagReq_);
				
				SendBase(args, batchUpdateWmsFlag_argsHelper.getInstance());
			}
			
			
			private com.vip.order.biz.response.BatchUpdateWmsFlagResp recv_batchUpdateWmsFlag(){
				
				batchUpdateWmsFlag_result result = new batchUpdateWmsFlag_result();
				ReceiveBase(result, batchUpdateWmsFlag_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.order.biz.response.CalculateSplitOrderMoneyResp calculateSplitOrderMoney(com.vip.order.common.pojo.order.request.RequestHeader header_,com.vip.order.biz.request.CalculateSplitOrderMoneyReq req_) {
				
				send_calculateSplitOrderMoney(header_,req_);
				return recv_calculateSplitOrderMoney(); 
				
			}
			
			
			private void send_calculateSplitOrderMoney(com.vip.order.common.pojo.order.request.RequestHeader header_,com.vip.order.biz.request.CalculateSplitOrderMoneyReq req_){
				
				InitInvocation("calculateSplitOrderMoney");
				
				calculateSplitOrderMoney_args args = new calculateSplitOrderMoney_args();
				args.SetHeader(header_);
				args.SetReq(req_);
				
				SendBase(args, calculateSplitOrderMoney_argsHelper.getInstance());
			}
			
			
			private com.vip.order.biz.response.CalculateSplitOrderMoneyResp recv_calculateSplitOrderMoney(){
				
				calculateSplitOrderMoney_result result = new calculateSplitOrderMoney_result();
				ReceiveBase(result, calculateSplitOrderMoney_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.order.biz.response.CancelOrderFixDataResp cancelOFixData(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.CancelOrderFixDataReq cancelOrderFixDataReq_) {
				
				send_cancelOFixData(requestHeader_,cancelOrderFixDataReq_);
				return recv_cancelOFixData(); 
				
			}
			
			
			private void send_cancelOFixData(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.CancelOrderFixDataReq cancelOrderFixDataReq_){
				
				InitInvocation("cancelOFixData");
				
				cancelOFixData_args args = new cancelOFixData_args();
				args.SetRequestHeader(requestHeader_);
				args.SetCancelOrderFixDataReq(cancelOrderFixDataReq_);
				
				SendBase(args, cancelOFixData_argsHelper.getInstance());
			}
			
			
			private com.vip.order.biz.response.CancelOrderFixDataResp recv_cancelOFixData(){
				
				cancelOFixData_result result = new cancelOFixData_result();
				ReceiveBase(result, cancelOFixData_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.order.biz.response.CancelOrderResp cancelOrder(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.CancelOrderReq reqParam_,com.vip.order.biz.request.CancelOrderPrivilegeReq privParam_) {
				
				send_cancelOrder(requestHeader_,reqParam_,privParam_);
				return recv_cancelOrder(); 
				
			}
			
			
			private void send_cancelOrder(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.CancelOrderReq reqParam_,com.vip.order.biz.request.CancelOrderPrivilegeReq privParam_){
				
				InitInvocation("cancelOrder");
				
				cancelOrder_args args = new cancelOrder_args();
				args.SetRequestHeader(requestHeader_);
				args.SetReqParam(reqParam_);
				args.SetPrivParam(privParam_);
				
				SendBase(args, cancelOrder_argsHelper.getInstance());
			}
			
			
			private com.vip.order.biz.response.CancelOrderResp recv_cancelOrder(){
				
				cancelOrder_result result = new cancelOrder_result();
				ReceiveBase(result, cancelOrder_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.order.biz.response.CancelOrderResp cancelPresellOrder(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.CancelOrderReq reqParam_,com.vip.order.biz.request.CancelOrderPrivilegeReq privParam_) {
				
				send_cancelPresellOrder(requestHeader_,reqParam_,privParam_);
				return recv_cancelPresellOrder(); 
				
			}
			
			
			private void send_cancelPresellOrder(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.CancelOrderReq reqParam_,com.vip.order.biz.request.CancelOrderPrivilegeReq privParam_){
				
				InitInvocation("cancelPresellOrder");
				
				cancelPresellOrder_args args = new cancelPresellOrder_args();
				args.SetRequestHeader(requestHeader_);
				args.SetReqParam(reqParam_);
				args.SetPrivParam(privParam_);
				
				SendBase(args, cancelPresellOrder_argsHelper.getInstance());
			}
			
			
			private com.vip.order.biz.response.CancelOrderResp recv_cancelPresellOrder(){
				
				cancelPresellOrder_result result = new cancelPresellOrder_result();
				ReceiveBase(result, cancelPresellOrder_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.order.biz.response.CheckCashOnDeliveryResp checkCashOnDelivery(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.CheckCashOnDeliveryReq checkCashOnDeliveryReq_) {
				
				send_checkCashOnDelivery(requestHeader_,checkCashOnDeliveryReq_);
				return recv_checkCashOnDelivery(); 
				
			}
			
			
			private void send_checkCashOnDelivery(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.CheckCashOnDeliveryReq checkCashOnDeliveryReq_){
				
				InitInvocation("checkCashOnDelivery");
				
				checkCashOnDelivery_args args = new checkCashOnDelivery_args();
				args.SetRequestHeader(requestHeader_);
				args.SetCheckCashOnDeliveryReq(checkCashOnDeliveryReq_);
				
				SendBase(args, checkCashOnDelivery_argsHelper.getInstance());
			}
			
			
			private com.vip.order.biz.response.CheckCashOnDeliveryResp recv_checkCashOnDelivery(){
				
				checkCashOnDelivery_result result = new checkCashOnDelivery_result();
				ReceiveBase(result, checkCashOnDelivery_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.order.biz.response.CheckDeliveryFetchExchangeResp checkDeliveryFetchExchange(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.CheckDeliveryFetchExchangeReq checkDeliveryFetchExchangeReq_) {
				
				send_checkDeliveryFetchExchange(requestHeader_,checkDeliveryFetchExchangeReq_);
				return recv_checkDeliveryFetchExchange(); 
				
			}
			
			
			private void send_checkDeliveryFetchExchange(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.CheckDeliveryFetchExchangeReq checkDeliveryFetchExchangeReq_){
				
				InitInvocation("checkDeliveryFetchExchange");
				
				checkDeliveryFetchExchange_args args = new checkDeliveryFetchExchange_args();
				args.SetRequestHeader(requestHeader_);
				args.SetCheckDeliveryFetchExchangeReq(checkDeliveryFetchExchangeReq_);
				
				SendBase(args, checkDeliveryFetchExchange_argsHelper.getInstance());
			}
			
			
			private com.vip.order.biz.response.CheckDeliveryFetchExchangeResp recv_checkDeliveryFetchExchange(){
				
				checkDeliveryFetchExchange_result result = new checkDeliveryFetchExchange_result();
				ReceiveBase(result, checkDeliveryFetchExchange_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.order.biz.response.CheckDeliveryFetchReturnResp checkDeliveryFetchReturn(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.CheckDeliveryFetchReturnReq checkDeliveryFetchReturnReq_) {
				
				send_checkDeliveryFetchReturn(requestHeader_,checkDeliveryFetchReturnReq_);
				return recv_checkDeliveryFetchReturn(); 
				
			}
			
			
			private void send_checkDeliveryFetchReturn(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.CheckDeliveryFetchReturnReq checkDeliveryFetchReturnReq_){
				
				InitInvocation("checkDeliveryFetchReturn");
				
				checkDeliveryFetchReturn_args args = new checkDeliveryFetchReturn_args();
				args.SetRequestHeader(requestHeader_);
				args.SetCheckDeliveryFetchReturnReq(checkDeliveryFetchReturnReq_);
				
				SendBase(args, checkDeliveryFetchReturn_argsHelper.getInstance());
			}
			
			
			private com.vip.order.biz.response.CheckDeliveryFetchReturnResp recv_checkDeliveryFetchReturn(){
				
				checkDeliveryFetchReturn_result result = new checkDeliveryFetchReturn_result();
				ReceiveBase(result, checkDeliveryFetchReturn_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.order.biz.response.CheckOrderReturnVendorAuditResp checkOrderReturnVendorAudit(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.CheckOrderReturnVendorAuditReq checkOrderReturnVendorAuditReq_) {
				
				send_checkOrderReturnVendorAudit(requestHeader_,checkOrderReturnVendorAuditReq_);
				return recv_checkOrderReturnVendorAudit(); 
				
			}
			
			
			private void send_checkOrderReturnVendorAudit(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.CheckOrderReturnVendorAuditReq checkOrderReturnVendorAuditReq_){
				
				InitInvocation("checkOrderReturnVendorAudit");
				
				checkOrderReturnVendorAudit_args args = new checkOrderReturnVendorAudit_args();
				args.SetRequestHeader(requestHeader_);
				args.SetCheckOrderReturnVendorAuditReq(checkOrderReturnVendorAuditReq_);
				
				SendBase(args, checkOrderReturnVendorAudit_argsHelper.getInstance());
			}
			
			
			private com.vip.order.biz.response.CheckOrderReturnVendorAuditResp recv_checkOrderReturnVendorAudit(){
				
				checkOrderReturnVendorAudit_result result = new checkOrderReturnVendorAudit_result();
				ReceiveBase(result, checkOrderReturnVendorAudit_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.order.biz.response.ConfirmDeliveredResp confirmDelivered(com.vip.order.common.pojo.order.request.RequestHeader header_,com.vip.order.biz.request.ConfirmDeliveredReq req_) {
				
				send_confirmDelivered(header_,req_);
				return recv_confirmDelivered(); 
				
			}
			
			
			private void send_confirmDelivered(com.vip.order.common.pojo.order.request.RequestHeader header_,com.vip.order.biz.request.ConfirmDeliveredReq req_){
				
				InitInvocation("confirmDelivered");
				
				confirmDelivered_args args = new confirmDelivered_args();
				args.SetHeader(header_);
				args.SetReq(req_);
				
				SendBase(args, confirmDelivered_argsHelper.getInstance());
			}
			
			
			private com.vip.order.biz.response.ConfirmDeliveredResp recv_confirmDelivered(){
				
				confirmDelivered_result result = new confirmDelivered_result();
				ReceiveBase(result, confirmDelivered_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.order.biz.response.ConfirmOrderGroupBuyResp confirmOrderGroupBuyResult(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.ConfirmOrderGroupBuyReq req_) {
				
				send_confirmOrderGroupBuyResult(requestHeader_,req_);
				return recv_confirmOrderGroupBuyResult(); 
				
			}
			
			
			private void send_confirmOrderGroupBuyResult(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.ConfirmOrderGroupBuyReq req_){
				
				InitInvocation("confirmOrderGroupBuyResult");
				
				confirmOrderGroupBuyResult_args args = new confirmOrderGroupBuyResult_args();
				args.SetRequestHeader(requestHeader_);
				args.SetReq(req_);
				
				SendBase(args, confirmOrderGroupBuyResult_argsHelper.getInstance());
			}
			
			
			private com.vip.order.biz.response.ConfirmOrderGroupBuyResp recv_confirmOrderGroupBuyResult(){
				
				confirmOrderGroupBuyResult_result result = new confirmOrderGroupBuyResult_result();
				ReceiveBase(result, confirmOrderGroupBuyResult_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.order.biz.response.CreateOrderResp createOrder(com.vip.order.biz.request.RequestHeader requestHeader_,int orderCategory_,List<com.vip.order.biz.request.CreateOrderReq> createOrderParam_) {
				
				send_createOrder(requestHeader_,orderCategory_,createOrderParam_);
				return recv_createOrder(); 
				
			}
			
			
			private void send_createOrder(com.vip.order.biz.request.RequestHeader requestHeader_,int orderCategory_,List<com.vip.order.biz.request.CreateOrderReq> createOrderParam_){
				
				InitInvocation("createOrder");
				
				createOrder_args args = new createOrder_args();
				args.SetRequestHeader(requestHeader_);
				args.SetOrderCategory(orderCategory_);
				args.SetCreateOrderParam(createOrderParam_);
				
				SendBase(args, createOrder_argsHelper.getInstance());
			}
			
			
			private com.vip.order.biz.response.CreateOrderResp recv_createOrder(){
				
				createOrder_result result = new createOrder_result();
				ReceiveBase(result, createOrder_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.order.biz.response.CreateOrderElectronicInvoiceResp createOrderElectronicInvoice(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.CreateOrderElectronicInvoiceReq createOrderElectronicInvoiceReq_) {
				
				send_createOrderElectronicInvoice(requestHeader_,createOrderElectronicInvoiceReq_);
				return recv_createOrderElectronicInvoice(); 
				
			}
			
			
			private void send_createOrderElectronicInvoice(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.CreateOrderElectronicInvoiceReq createOrderElectronicInvoiceReq_){
				
				InitInvocation("createOrderElectronicInvoice");
				
				createOrderElectronicInvoice_args args = new createOrderElectronicInvoice_args();
				args.SetRequestHeader(requestHeader_);
				args.SetCreateOrderElectronicInvoiceReq(createOrderElectronicInvoiceReq_);
				
				SendBase(args, createOrderElectronicInvoice_argsHelper.getInstance());
			}
			
			
			private com.vip.order.biz.response.CreateOrderElectronicInvoiceResp recv_createOrderElectronicInvoice(){
				
				createOrderElectronicInvoice_result result = new createOrderElectronicInvoice_result();
				ReceiveBase(result, createOrderElectronicInvoice_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.order.biz.response.CreateOrderPostProcResp createOrderPostProc(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.CreateOrderPostProcReq req_) {
				
				send_createOrderPostProc(requestHeader_,req_);
				return recv_createOrderPostProc(); 
				
			}
			
			
			private void send_createOrderPostProc(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.CreateOrderPostProcReq req_){
				
				InitInvocation("createOrderPostProc");
				
				createOrderPostProc_args args = new createOrderPostProc_args();
				args.SetRequestHeader(requestHeader_);
				args.SetReq(req_);
				
				SendBase(args, createOrderPostProc_argsHelper.getInstance());
			}
			
			
			private com.vip.order.biz.response.CreateOrderPostProcResp recv_createOrderPostProc(){
				
				createOrderPostProc_result result = new createOrderPostProc_result();
				ReceiveBase(result, createOrderPostProc_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.order.biz.response.CreateOrderSnRespV2 createOrderSnV2(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,string warehouse_,int number_) {
				
				send_createOrderSnV2(requestHeader_,warehouse_,number_);
				return recv_createOrderSnV2(); 
				
			}
			
			
			private void send_createOrderSnV2(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,string warehouse_,int number_){
				
				InitInvocation("createOrderSnV2");
				
				createOrderSnV2_args args = new createOrderSnV2_args();
				args.SetRequestHeader(requestHeader_);
				args.SetWarehouse(warehouse_);
				args.SetNumber(number_);
				
				SendBase(args, createOrderSnV2_argsHelper.getInstance());
			}
			
			
			private com.vip.order.biz.response.CreateOrderSnRespV2 recv_createOrderSnV2(){
				
				createOrderSnV2_result result = new createOrderSnV2_result();
				ReceiveBase(result, createOrderSnV2_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.order.biz.response.CreateOrderSnRespV3 createOrderSnV3(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.CreateOrderSnReqV3 req_) {
				
				send_createOrderSnV3(requestHeader_,req_);
				return recv_createOrderSnV3(); 
				
			}
			
			
			private void send_createOrderSnV3(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.CreateOrderSnReqV3 req_){
				
				InitInvocation("createOrderSnV3");
				
				createOrderSnV3_args args = new createOrderSnV3_args();
				args.SetRequestHeader(requestHeader_);
				args.SetReq(req_);
				
				SendBase(args, createOrderSnV3_argsHelper.getInstance());
			}
			
			
			private com.vip.order.biz.response.CreateOrderSnRespV3 recv_createOrderSnV3(){
				
				createOrderSnV3_result result = new createOrderSnV3_result();
				ReceiveBase(result, createOrderSnV3_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.order.biz.response.CreateOrderRespV2 createOrderV2(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,int orderCategory_,List<com.vip.order.biz.request.CreateOrderReqV2> createOrderParam_) {
				
				send_createOrderV2(requestHeader_,orderCategory_,createOrderParam_);
				return recv_createOrderV2(); 
				
			}
			
			
			private void send_createOrderV2(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,int orderCategory_,List<com.vip.order.biz.request.CreateOrderReqV2> createOrderParam_){
				
				InitInvocation("createOrderV2");
				
				createOrderV2_args args = new createOrderV2_args();
				args.SetRequestHeader(requestHeader_);
				args.SetOrderCategory(orderCategory_);
				args.SetCreateOrderParam(createOrderParam_);
				
				SendBase(args, createOrderV2_argsHelper.getInstance());
			}
			
			
			private com.vip.order.biz.response.CreateOrderRespV2 recv_createOrderV2(){
				
				createOrderV2_result result = new createOrderV2_result();
				ReceiveBase(result, createOrderV2_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.order.biz.response.CreateOrderRespV3 createOrderV3(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,int orderCategory_,List<com.vip.order.biz.request.CreateOrderReqV3> createOrderParam_) {
				
				send_createOrderV3(requestHeader_,orderCategory_,createOrderParam_);
				return recv_createOrderV3(); 
				
			}
			
			
			private void send_createOrderV3(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,int orderCategory_,List<com.vip.order.biz.request.CreateOrderReqV3> createOrderParam_){
				
				InitInvocation("createOrderV3");
				
				createOrderV3_args args = new createOrderV3_args();
				args.SetRequestHeader(requestHeader_);
				args.SetOrderCategory(orderCategory_);
				args.SetCreateOrderParam(createOrderParam_);
				
				SendBase(args, createOrderV3_argsHelper.getInstance());
			}
			
			
			private com.vip.order.biz.response.CreateOrderRespV3 recv_createOrderV3(){
				
				createOrderV3_result result = new createOrderV3_result();
				ReceiveBase(result, createOrderV3_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.order.biz.response.CSCCancelBackResp cscCancelBack(com.vip.order.common.pojo.order.request.RequestHeader header_,com.vip.order.biz.request.CSCCancelBackReq req_) {
				
				send_cscCancelBack(header_,req_);
				return recv_cscCancelBack(); 
				
			}
			
			
			private void send_cscCancelBack(com.vip.order.common.pojo.order.request.RequestHeader header_,com.vip.order.biz.request.CSCCancelBackReq req_){
				
				InitInvocation("cscCancelBack");
				
				cscCancelBack_args args = new cscCancelBack_args();
				args.SetHeader(header_);
				args.SetReq(req_);
				
				SendBase(args, cscCancelBack_argsHelper.getInstance());
			}
			
			
			private com.vip.order.biz.response.CSCCancelBackResp recv_cscCancelBack(){
				
				cscCancelBack_result result = new cscCancelBack_result();
				ReceiveBase(result, cscCancelBack_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.order.biz.response.DisplayOrderResp displayOrder(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.DisplayOrderReq req_) {
				
				send_displayOrder(requestHeader_,req_);
				return recv_displayOrder(); 
				
			}
			
			
			private void send_displayOrder(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.DisplayOrderReq req_){
				
				InitInvocation("displayOrder");
				
				displayOrder_args args = new displayOrder_args();
				args.SetRequestHeader(requestHeader_);
				args.SetReq(req_);
				
				SendBase(args, displayOrder_argsHelper.getInstance());
			}
			
			
			private com.vip.order.biz.response.DisplayOrderResp recv_displayOrder(){
				
				displayOrder_result result = new displayOrder_result();
				ReceiveBase(result, displayOrder_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.order.biz.response.GetAfterSaleOpTypeResp getAfterSaleOpType(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.GetAfterSaleOpTypeReq req_) {
				
				send_getAfterSaleOpType(requestHeader_,req_);
				return recv_getAfterSaleOpType(); 
				
			}
			
			
			private void send_getAfterSaleOpType(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.GetAfterSaleOpTypeReq req_){
				
				InitInvocation("getAfterSaleOpType");
				
				getAfterSaleOpType_args args = new getAfterSaleOpType_args();
				args.SetRequestHeader(requestHeader_);
				args.SetReq(req_);
				
				SendBase(args, getAfterSaleOpType_argsHelper.getInstance());
			}
			
			
			private com.vip.order.biz.response.GetAfterSaleOpTypeResp recv_getAfterSaleOpType(){
				
				getAfterSaleOpType_result result = new getAfterSaleOpType_result();
				ReceiveBase(result, getAfterSaleOpType_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.order.biz.response.GetCanAfterSaleOrderListResp getCanAfterSaleOrderListByUserId(com.vip.order.common.pojo.order.request.RequestHeader header_,com.vip.order.biz.request.GetCanAfterSaleOrderListReq req_,com.vip.order.common.pojo.order.request.PageResultFilter pageResultFilter_) {
				
				send_getCanAfterSaleOrderListByUserId(header_,req_,pageResultFilter_);
				return recv_getCanAfterSaleOrderListByUserId(); 
				
			}
			
			
			private void send_getCanAfterSaleOrderListByUserId(com.vip.order.common.pojo.order.request.RequestHeader header_,com.vip.order.biz.request.GetCanAfterSaleOrderListReq req_,com.vip.order.common.pojo.order.request.PageResultFilter pageResultFilter_){
				
				InitInvocation("getCanAfterSaleOrderListByUserId");
				
				getCanAfterSaleOrderListByUserId_args args = new getCanAfterSaleOrderListByUserId_args();
				args.SetHeader(header_);
				args.SetReq(req_);
				args.SetPageResultFilter(pageResultFilter_);
				
				SendBase(args, getCanAfterSaleOrderListByUserId_argsHelper.getInstance());
			}
			
			
			private com.vip.order.biz.response.GetCanAfterSaleOrderListResp recv_getCanAfterSaleOrderListByUserId(){
				
				getCanAfterSaleOrderListByUserId_result result = new getCanAfterSaleOrderListByUserId_result();
				ReceiveBase(result, getCanAfterSaleOrderListByUserId_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.order.biz.response.GetCanRefundOrderCountResp getCanRefundOrderCount(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.GetCanRefundOrderCountReq getCanRefundOrderCountReq_) {
				
				send_getCanRefundOrderCount(requestHeader_,getCanRefundOrderCountReq_);
				return recv_getCanRefundOrderCount(); 
				
			}
			
			
			private void send_getCanRefundOrderCount(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.GetCanRefundOrderCountReq getCanRefundOrderCountReq_){
				
				InitInvocation("getCanRefundOrderCount");
				
				getCanRefundOrderCount_args args = new getCanRefundOrderCount_args();
				args.SetRequestHeader(requestHeader_);
				args.SetGetCanRefundOrderCountReq(getCanRefundOrderCountReq_);
				
				SendBase(args, getCanRefundOrderCount_argsHelper.getInstance());
			}
			
			
			private com.vip.order.biz.response.GetCanRefundOrderCountResp recv_getCanRefundOrderCount(){
				
				getCanRefundOrderCount_result result = new getCanRefundOrderCount_result();
				ReceiveBase(result, getCanRefundOrderCount_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.order.biz.response.GetCanRefundOrderListResp getCanRefundOrderList(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.GetCanRefundOrderListReq getCanRefundOrderListReq_) {
				
				send_getCanRefundOrderList(requestHeader_,getCanRefundOrderListReq_);
				return recv_getCanRefundOrderList(); 
				
			}
			
			
			private void send_getCanRefundOrderList(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.GetCanRefundOrderListReq getCanRefundOrderListReq_){
				
				InitInvocation("getCanRefundOrderList");
				
				getCanRefundOrderList_args args = new getCanRefundOrderList_args();
				args.SetRequestHeader(requestHeader_);
				args.SetGetCanRefundOrderListReq(getCanRefundOrderListReq_);
				
				SendBase(args, getCanRefundOrderList_argsHelper.getInstance());
			}
			
			
			private com.vip.order.biz.response.GetCanRefundOrderListResp recv_getCanRefundOrderList(){
				
				getCanRefundOrderList_result result = new getCanRefundOrderList_result();
				ReceiveBase(result, getCanRefundOrderList_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.order.biz.response.GetEbsGoodsListResp getEbsGoodsList(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.GetEbsGoodsListReq getEbsGoodsListReq_) {
				
				send_getEbsGoodsList(requestHeader_,getEbsGoodsListReq_);
				return recv_getEbsGoodsList(); 
				
			}
			
			
			private void send_getEbsGoodsList(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.GetEbsGoodsListReq getEbsGoodsListReq_){
				
				InitInvocation("getEbsGoodsList");
				
				getEbsGoodsList_args args = new getEbsGoodsList_args();
				args.SetRequestHeader(requestHeader_);
				args.SetGetEbsGoodsListReq(getEbsGoodsListReq_);
				
				SendBase(args, getEbsGoodsList_argsHelper.getInstance());
			}
			
			
			private com.vip.order.biz.response.GetEbsGoodsListResp recv_getEbsGoodsList(){
				
				getEbsGoodsList_result result = new getEbsGoodsList_result();
				ReceiveBase(result, getEbsGoodsList_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.order.biz.response.GetGoodsDispatchWarehouseResp getGoodsDispatchWarehouse(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.GetGoodsDispatchWarehouseReq req_) {
				
				send_getGoodsDispatchWarehouse(requestHeader_,req_);
				return recv_getGoodsDispatchWarehouse(); 
				
			}
			
			
			private void send_getGoodsDispatchWarehouse(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.GetGoodsDispatchWarehouseReq req_){
				
				InitInvocation("getGoodsDispatchWarehouse");
				
				getGoodsDispatchWarehouse_args args = new getGoodsDispatchWarehouse_args();
				args.SetRequestHeader(requestHeader_);
				args.SetReq(req_);
				
				SendBase(args, getGoodsDispatchWarehouse_argsHelper.getInstance());
			}
			
			
			private com.vip.order.biz.response.GetGoodsDispatchWarehouseResp recv_getGoodsDispatchWarehouse(){
				
				getGoodsDispatchWarehouse_result result = new getGoodsDispatchWarehouse_result();
				ReceiveBase(result, getGoodsDispatchWarehouse_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.order.biz.response.GetLimitedOrderGoodsCountResp getLimitedOrderGoodsCount(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.GetLimitedOrderGoodsCountReq getLimitedOrderGoodsCountReq_) {
				
				send_getLimitedOrderGoodsCount(requestHeader_,getLimitedOrderGoodsCountReq_);
				return recv_getLimitedOrderGoodsCount(); 
				
			}
			
			
			private void send_getLimitedOrderGoodsCount(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.GetLimitedOrderGoodsCountReq getLimitedOrderGoodsCountReq_){
				
				InitInvocation("getLimitedOrderGoodsCount");
				
				getLimitedOrderGoodsCount_args args = new getLimitedOrderGoodsCount_args();
				args.SetRequestHeader(requestHeader_);
				args.SetGetLimitedOrderGoodsCountReq(getLimitedOrderGoodsCountReq_);
				
				SendBase(args, getLimitedOrderGoodsCount_argsHelper.getInstance());
			}
			
			
			private com.vip.order.biz.response.GetLimitedOrderGoodsCountResp recv_getLimitedOrderGoodsCount(){
				
				getLimitedOrderGoodsCount_result result = new getLimitedOrderGoodsCount_result();
				ReceiveBase(result, getLimitedOrderGoodsCount_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.order.biz.response.LinkageOrderResp getLinkageOrders(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.SearchLinkageOrderReq req_) {
				
				send_getLinkageOrders(requestHeader_,req_);
				return recv_getLinkageOrders(); 
				
			}
			
			
			private void send_getLinkageOrders(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.SearchLinkageOrderReq req_){
				
				InitInvocation("getLinkageOrders");
				
				getLinkageOrders_args args = new getLinkageOrders_args();
				args.SetRequestHeader(requestHeader_);
				args.SetReq(req_);
				
				SendBase(args, getLinkageOrders_argsHelper.getInstance());
			}
			
			
			private com.vip.order.biz.response.LinkageOrderResp recv_getLinkageOrders(){
				
				getLinkageOrders_result result = new getLinkageOrders_result();
				ReceiveBase(result, getLinkageOrders_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.order.biz.response.GetMergeOrderResp getMergeOrderList(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.GetMergeOrderReq getMergeOrderReq_) {
				
				send_getMergeOrderList(requestHeader_,getMergeOrderReq_);
				return recv_getMergeOrderList(); 
				
			}
			
			
			private void send_getMergeOrderList(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.GetMergeOrderReq getMergeOrderReq_){
				
				InitInvocation("getMergeOrderList");
				
				getMergeOrderList_args args = new getMergeOrderList_args();
				args.SetRequestHeader(requestHeader_);
				args.SetGetMergeOrderReq(getMergeOrderReq_);
				
				SendBase(args, getMergeOrderList_argsHelper.getInstance());
			}
			
			
			private com.vip.order.biz.response.GetMergeOrderResp recv_getMergeOrderList(){
				
				getMergeOrderList_result result = new getMergeOrderList_result();
				ReceiveBase(result, getMergeOrderList_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.order.biz.response.OrderListCountResp getOrderCounts(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.SearchOrderReq searchOrderReq_) {
				
				send_getOrderCounts(requestHeader_,searchOrderReq_);
				return recv_getOrderCounts(); 
				
			}
			
			
			private void send_getOrderCounts(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.SearchOrderReq searchOrderReq_){
				
				InitInvocation("getOrderCounts");
				
				getOrderCounts_args args = new getOrderCounts_args();
				args.SetRequestHeader(requestHeader_);
				args.SetSearchOrderReq(searchOrderReq_);
				
				SendBase(args, getOrderCounts_argsHelper.getInstance());
			}
			
			
			private com.vip.order.biz.response.OrderListCountResp recv_getOrderCounts(){
				
				getOrderCounts_result result = new getOrderCounts_result();
				ReceiveBase(result, getOrderCounts_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.order.biz.response.OrderListCountResp getOrderCountsByUserId(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.GetOrderByUserIdReq getOrderByUserIdReq_) {
				
				send_getOrderCountsByUserId(requestHeader_,getOrderByUserIdReq_);
				return recv_getOrderCountsByUserId(); 
				
			}
			
			
			private void send_getOrderCountsByUserId(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.GetOrderByUserIdReq getOrderByUserIdReq_){
				
				InitInvocation("getOrderCountsByUserId");
				
				getOrderCountsByUserId_args args = new getOrderCountsByUserId_args();
				args.SetRequestHeader(requestHeader_);
				args.SetGetOrderByUserIdReq(getOrderByUserIdReq_);
				
				SendBase(args, getOrderCountsByUserId_argsHelper.getInstance());
			}
			
			
			private com.vip.order.biz.response.OrderListCountResp recv_getOrderCountsByUserId(){
				
				getOrderCountsByUserId_result result = new getOrderCountsByUserId_result();
				ReceiveBase(result, getOrderCountsByUserId_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.order.biz.response.GetOrderDeliveryBoxNumResp getOrderDeliveryBoxNum(com.vip.order.common.pojo.order.request.RequestHeader requestHeaderParam_,string orderSn_) {
				
				send_getOrderDeliveryBoxNum(requestHeaderParam_,orderSn_);
				return recv_getOrderDeliveryBoxNum(); 
				
			}
			
			
			private void send_getOrderDeliveryBoxNum(com.vip.order.common.pojo.order.request.RequestHeader requestHeaderParam_,string orderSn_){
				
				InitInvocation("getOrderDeliveryBoxNum");
				
				getOrderDeliveryBoxNum_args args = new getOrderDeliveryBoxNum_args();
				args.SetRequestHeaderParam(requestHeaderParam_);
				args.SetOrderSn(orderSn_);
				
				SendBase(args, getOrderDeliveryBoxNum_argsHelper.getInstance());
			}
			
			
			private com.vip.order.biz.response.GetOrderDeliveryBoxNumResp recv_getOrderDeliveryBoxNum(){
				
				getOrderDeliveryBoxNum_result result = new getOrderDeliveryBoxNum_result();
				ReceiveBase(result, getOrderDeliveryBoxNum_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.order.biz.response.SearchOrderDetailResp getOrderDetail(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.SearchOrderDetailReq searchOrderDetailReq_) {
				
				send_getOrderDetail(requestHeader_,searchOrderDetailReq_);
				return recv_getOrderDetail(); 
				
			}
			
			
			private void send_getOrderDetail(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.SearchOrderDetailReq searchOrderDetailReq_){
				
				InitInvocation("getOrderDetail");
				
				getOrderDetail_args args = new getOrderDetail_args();
				args.SetRequestHeader(requestHeader_);
				args.SetSearchOrderDetailReq(searchOrderDetailReq_);
				
				SendBase(args, getOrderDetail_argsHelper.getInstance());
			}
			
			
			private com.vip.order.biz.response.SearchOrderDetailResp recv_getOrderDetail(){
				
				getOrderDetail_result result = new getOrderDetail_result();
				ReceiveBase(result, getOrderDetail_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.order.biz.response.OrderElectronicInvoicesV2Resp getOrderElectronicInvoicesV2(com.vip.order.common.pojo.order.request.RequestHeader requestHeaderParam_,com.vip.order.biz.request.SearchOrderElectronicInvoicesReq searchOrderElectronicInvoiceParam_,com.vip.order.biz.request.ResultRequirement resultRequirement_) {
				
				send_getOrderElectronicInvoicesV2(requestHeaderParam_,searchOrderElectronicInvoiceParam_,resultRequirement_);
				return recv_getOrderElectronicInvoicesV2(); 
				
			}
			
			
			private void send_getOrderElectronicInvoicesV2(com.vip.order.common.pojo.order.request.RequestHeader requestHeaderParam_,com.vip.order.biz.request.SearchOrderElectronicInvoicesReq searchOrderElectronicInvoiceParam_,com.vip.order.biz.request.ResultRequirement resultRequirement_){
				
				InitInvocation("getOrderElectronicInvoicesV2");
				
				getOrderElectronicInvoicesV2_args args = new getOrderElectronicInvoicesV2_args();
				args.SetRequestHeaderParam(requestHeaderParam_);
				args.SetSearchOrderElectronicInvoiceParam(searchOrderElectronicInvoiceParam_);
				args.SetResultRequirement(resultRequirement_);
				
				SendBase(args, getOrderElectronicInvoicesV2_argsHelper.getInstance());
			}
			
			
			private com.vip.order.biz.response.OrderElectronicInvoicesV2Resp recv_getOrderElectronicInvoicesV2(){
				
				getOrderElectronicInvoicesV2_result result = new getOrderElectronicInvoicesV2_result();
				ReceiveBase(result, getOrderElectronicInvoicesV2_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.order.biz.response.GetOrderFavResp getOrderFav(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,List<string> orderSnList_) {
				
				send_getOrderFav(requestHeader_,orderSnList_);
				return recv_getOrderFav(); 
				
			}
			
			
			private void send_getOrderFav(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,List<string> orderSnList_){
				
				InitInvocation("getOrderFav");
				
				getOrderFav_args args = new getOrderFav_args();
				args.SetRequestHeader(requestHeader_);
				args.SetOrderSnList(orderSnList_);
				
				SendBase(args, getOrderFav_argsHelper.getInstance());
			}
			
			
			private com.vip.order.biz.response.GetOrderFavResp recv_getOrderFav(){
				
				getOrderFav_result result = new getOrderFav_result();
				ReceiveBase(result, getOrderFav_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.order.biz.response.GetOrderGoodsCountResultResp getOrderGoodsCount(com.vip.order.common.pojo.order.request.RequestHeader requestHeaderParam_,com.vip.order.biz.request.GetOrderGoodsReq getOrderGoodsParam_) {
				
				send_getOrderGoodsCount(requestHeaderParam_,getOrderGoodsParam_);
				return recv_getOrderGoodsCount(); 
				
			}
			
			
			private void send_getOrderGoodsCount(com.vip.order.common.pojo.order.request.RequestHeader requestHeaderParam_,com.vip.order.biz.request.GetOrderGoodsReq getOrderGoodsParam_){
				
				InitInvocation("getOrderGoodsCount");
				
				getOrderGoodsCount_args args = new getOrderGoodsCount_args();
				args.SetRequestHeaderParam(requestHeaderParam_);
				args.SetGetOrderGoodsParam(getOrderGoodsParam_);
				
				SendBase(args, getOrderGoodsCount_argsHelper.getInstance());
			}
			
			
			private com.vip.order.biz.response.GetOrderGoodsCountResultResp recv_getOrderGoodsCount(){
				
				getOrderGoodsCount_result result = new getOrderGoodsCount_result();
				ReceiveBase(result, getOrderGoodsCount_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.order.biz.response.GetOrderGoodsResultResp getOrderGoodsList(com.vip.order.common.pojo.order.request.RequestHeader requestHeaderParam_,com.vip.order.biz.request.GetOrderGoodsReq getOrderGoodsParam_,com.vip.order.common.pojo.order.request.ResultFilter resultFilter_) {
				
				send_getOrderGoodsList(requestHeaderParam_,getOrderGoodsParam_,resultFilter_);
				return recv_getOrderGoodsList(); 
				
			}
			
			
			private void send_getOrderGoodsList(com.vip.order.common.pojo.order.request.RequestHeader requestHeaderParam_,com.vip.order.biz.request.GetOrderGoodsReq getOrderGoodsParam_,com.vip.order.common.pojo.order.request.ResultFilter resultFilter_){
				
				InitInvocation("getOrderGoodsList");
				
				getOrderGoodsList_args args = new getOrderGoodsList_args();
				args.SetRequestHeaderParam(requestHeaderParam_);
				args.SetGetOrderGoodsParam(getOrderGoodsParam_);
				args.SetResultFilter(resultFilter_);
				
				SendBase(args, getOrderGoodsList_argsHelper.getInstance());
			}
			
			
			private com.vip.order.biz.response.GetOrderGoodsResultResp recv_getOrderGoodsList(){
				
				getOrderGoodsList_result result = new getOrderGoodsList_result();
				ReceiveBase(result, getOrderGoodsList_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.order.biz.response.GetOrderInstalmentsListResp getOrderInstalmentsList(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.GetOrderInstalmentsReq req_,com.vip.order.common.pojo.order.request.ResultFilter filter_) {
				
				send_getOrderInstalmentsList(requestHeader_,req_,filter_);
				return recv_getOrderInstalmentsList(); 
				
			}
			
			
			private void send_getOrderInstalmentsList(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.GetOrderInstalmentsReq req_,com.vip.order.common.pojo.order.request.ResultFilter filter_){
				
				InitInvocation("getOrderInstalmentsList");
				
				getOrderInstalmentsList_args args = new getOrderInstalmentsList_args();
				args.SetRequestHeader(requestHeader_);
				args.SetReq(req_);
				args.SetFilter(filter_);
				
				SendBase(args, getOrderInstalmentsList_argsHelper.getInstance());
			}
			
			
			private com.vip.order.biz.response.GetOrderInstalmentsListResp recv_getOrderInstalmentsList(){
				
				getOrderInstalmentsList_result result = new getOrderInstalmentsList_result();
				ReceiveBase(result, getOrderInstalmentsList_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.order.biz.response.OrderInvoicesV2Resp getOrderInvoicesV2(com.vip.order.common.pojo.order.request.RequestHeader requestHeaderParam_,com.vip.order.biz.request.SearchOrderInvoicesReq searchOrderInvoiceParam_) {
				
				send_getOrderInvoicesV2(requestHeaderParam_,searchOrderInvoiceParam_);
				return recv_getOrderInvoicesV2(); 
				
			}
			
			
			private void send_getOrderInvoicesV2(com.vip.order.common.pojo.order.request.RequestHeader requestHeaderParam_,com.vip.order.biz.request.SearchOrderInvoicesReq searchOrderInvoiceParam_){
				
				InitInvocation("getOrderInvoicesV2");
				
				getOrderInvoicesV2_args args = new getOrderInvoicesV2_args();
				args.SetRequestHeaderParam(requestHeaderParam_);
				args.SetSearchOrderInvoiceParam(searchOrderInvoiceParam_);
				
				SendBase(args, getOrderInvoicesV2_argsHelper.getInstance());
			}
			
			
			private com.vip.order.biz.response.OrderInvoicesV2Resp recv_getOrderInvoicesV2(){
				
				getOrderInvoicesV2_result result = new getOrderInvoicesV2_result();
				ReceiveBase(result, getOrderInvoicesV2_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.order.biz.response.SearchOrderListResp getOrderList(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.SearchOrderReq searchOrderReq_,com.vip.order.common.pojo.order.request.ResultFilter resultFilter_) {
				
				send_getOrderList(requestHeader_,searchOrderReq_,resultFilter_);
				return recv_getOrderList(); 
				
			}
			
			
			private void send_getOrderList(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.SearchOrderReq searchOrderReq_,com.vip.order.common.pojo.order.request.ResultFilter resultFilter_){
				
				InitInvocation("getOrderList");
				
				getOrderList_args args = new getOrderList_args();
				args.SetRequestHeader(requestHeader_);
				args.SetSearchOrderReq(searchOrderReq_);
				args.SetResultFilter(resultFilter_);
				
				SendBase(args, getOrderList_argsHelper.getInstance());
			}
			
			
			private com.vip.order.biz.response.SearchOrderListResp recv_getOrderList(){
				
				getOrderList_result result = new getOrderList_result();
				ReceiveBase(result, getOrderList_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.order.biz.response.GetOrderListByPosNoResp getOrderListByPosNo(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.GetOrderListByPosNoReq req_) {
				
				send_getOrderListByPosNo(requestHeader_,req_);
				return recv_getOrderListByPosNo(); 
				
			}
			
			
			private void send_getOrderListByPosNo(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.GetOrderListByPosNoReq req_){
				
				InitInvocation("getOrderListByPosNo");
				
				getOrderListByPosNo_args args = new getOrderListByPosNo_args();
				args.SetRequestHeader(requestHeader_);
				args.SetReq(req_);
				
				SendBase(args, getOrderListByPosNo_argsHelper.getInstance());
			}
			
			
			private com.vip.order.biz.response.GetOrderListByPosNoResp recv_getOrderListByPosNo(){
				
				getOrderListByPosNo_result result = new getOrderListByPosNo_result();
				ReceiveBase(result, getOrderListByPosNo_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.order.biz.response.GetOrderListByUserIdResp getOrderListByUserId(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.GetOrderByUserIdReq getOrderByUserIdReq_,com.vip.order.common.pojo.order.request.ResultFilter resultFilter_) {
				
				send_getOrderListByUserId(requestHeader_,getOrderByUserIdReq_,resultFilter_);
				return recv_getOrderListByUserId(); 
				
			}
			
			
			private void send_getOrderListByUserId(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.GetOrderByUserIdReq getOrderByUserIdReq_,com.vip.order.common.pojo.order.request.ResultFilter resultFilter_){
				
				InitInvocation("getOrderListByUserId");
				
				getOrderListByUserId_args args = new getOrderListByUserId_args();
				args.SetRequestHeader(requestHeader_);
				args.SetGetOrderByUserIdReq(getOrderByUserIdReq_);
				args.SetResultFilter(resultFilter_);
				
				SendBase(args, getOrderListByUserId_argsHelper.getInstance());
			}
			
			
			private com.vip.order.biz.response.GetOrderListByUserIdResp recv_getOrderListByUserId(){
				
				getOrderListByUserId_result result = new getOrderListByUserId_result();
				ReceiveBase(result, getOrderListByUserId_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.order.biz.response.GetOrderLogsResp getOrderLogs(com.vip.order.common.pojo.order.request.RequestHeader requestHeaderParam_,com.vip.order.biz.request.SearchOrderLogsReq searchOrderLogsParam_,com.vip.order.biz.request.requirement.GetOrderLogsRequirement getOrderLogsRequirement_) {
				
				send_getOrderLogs(requestHeaderParam_,searchOrderLogsParam_,getOrderLogsRequirement_);
				return recv_getOrderLogs(); 
				
			}
			
			
			private void send_getOrderLogs(com.vip.order.common.pojo.order.request.RequestHeader requestHeaderParam_,com.vip.order.biz.request.SearchOrderLogsReq searchOrderLogsParam_,com.vip.order.biz.request.requirement.GetOrderLogsRequirement getOrderLogsRequirement_){
				
				InitInvocation("getOrderLogs");
				
				getOrderLogs_args args = new getOrderLogs_args();
				args.SetRequestHeaderParam(requestHeaderParam_);
				args.SetSearchOrderLogsParam(searchOrderLogsParam_);
				args.SetGetOrderLogsRequirement(getOrderLogsRequirement_);
				
				SendBase(args, getOrderLogs_argsHelper.getInstance());
			}
			
			
			private com.vip.order.biz.response.GetOrderLogsResp recv_getOrderLogs(){
				
				getOrderLogs_result result = new getOrderLogs_result();
				ReceiveBase(result, getOrderLogs_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.order.biz.response.GetOrderOpStatusResp getOrderOpStatus(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.GetOrderOpStatusReq getOrderOpStatusReq_) {
				
				send_getOrderOpStatus(requestHeader_,getOrderOpStatusReq_);
				return recv_getOrderOpStatus(); 
				
			}
			
			
			private void send_getOrderOpStatus(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.GetOrderOpStatusReq getOrderOpStatusReq_){
				
				InitInvocation("getOrderOpStatus");
				
				getOrderOpStatus_args args = new getOrderOpStatus_args();
				args.SetRequestHeader(requestHeader_);
				args.SetGetOrderOpStatusReq(getOrderOpStatusReq_);
				
				SendBase(args, getOrderOpStatus_argsHelper.getInstance());
			}
			
			
			private com.vip.order.biz.response.GetOrderOpStatusResp recv_getOrderOpStatus(){
				
				getOrderOpStatus_result result = new getOrderOpStatus_result();
				ReceiveBase(result, getOrderOpStatus_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.order.biz.response.GetOrderPackageListResp getOrderPackageList(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.GetOrderPackageListReq getPackageListReq_) {
				
				send_getOrderPackageList(requestHeader_,getPackageListReq_);
				return recv_getOrderPackageList(); 
				
			}
			
			
			private void send_getOrderPackageList(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.GetOrderPackageListReq getPackageListReq_){
				
				InitInvocation("getOrderPackageList");
				
				getOrderPackageList_args args = new getOrderPackageList_args();
				args.SetRequestHeader(requestHeader_);
				args.SetGetPackageListReq(getPackageListReq_);
				
				SendBase(args, getOrderPackageList_argsHelper.getInstance());
			}
			
			
			private com.vip.order.biz.response.GetOrderPackageListResp recv_getOrderPackageList(){
				
				getOrderPackageList_result result = new getOrderPackageList_result();
				ReceiveBase(result, getOrderPackageList_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.order.biz.response.GetOrderPayTypeResp getOrderPayType(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.GetOrderPayTypeReq getOrderPayTypeParam_,com.vip.order.common.pojo.order.request.ResultFilter resultFilter_) {
				
				send_getOrderPayType(requestHeader_,getOrderPayTypeParam_,resultFilter_);
				return recv_getOrderPayType(); 
				
			}
			
			
			private void send_getOrderPayType(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.GetOrderPayTypeReq getOrderPayTypeParam_,com.vip.order.common.pojo.order.request.ResultFilter resultFilter_){
				
				InitInvocation("getOrderPayType");
				
				getOrderPayType_args args = new getOrderPayType_args();
				args.SetRequestHeader(requestHeader_);
				args.SetGetOrderPayTypeParam(getOrderPayTypeParam_);
				args.SetResultFilter(resultFilter_);
				
				SendBase(args, getOrderPayType_argsHelper.getInstance());
			}
			
			
			private com.vip.order.biz.response.GetOrderPayTypeResp recv_getOrderPayType(){
				
				getOrderPayType_result result = new getOrderPayType_result();
				ReceiveBase(result, getOrderPayType_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.order.biz.response.GetOrderSnByExOrderSnResp getOrderSnByExOrderSn(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,List<string> exOrderSns_) {
				
				send_getOrderSnByExOrderSn(requestHeader_,exOrderSns_);
				return recv_getOrderSnByExOrderSn(); 
				
			}
			
			
			private void send_getOrderSnByExOrderSn(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,List<string> exOrderSns_){
				
				InitInvocation("getOrderSnByExOrderSn");
				
				getOrderSnByExOrderSn_args args = new getOrderSnByExOrderSn_args();
				args.SetRequestHeader(requestHeader_);
				args.SetExOrderSns(exOrderSns_);
				
				SendBase(args, getOrderSnByExOrderSn_argsHelper.getInstance());
			}
			
			
			private com.vip.order.biz.response.GetOrderSnByExOrderSnResp recv_getOrderSnByExOrderSn(){
				
				getOrderSnByExOrderSn_result result = new getOrderSnByExOrderSn_result();
				ReceiveBase(result, getOrderSnByExOrderSn_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.order.biz.response.GetOrderTransportResp getOrderTransport(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.GetOrderTransportReq getOrderTransportReq_) {
				
				send_getOrderTransport(requestHeader_,getOrderTransportReq_);
				return recv_getOrderTransport(); 
				
			}
			
			
			private void send_getOrderTransport(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.GetOrderTransportReq getOrderTransportReq_){
				
				InitInvocation("getOrderTransport");
				
				getOrderTransport_args args = new getOrderTransport_args();
				args.SetRequestHeader(requestHeader_);
				args.SetGetOrderTransportReq(getOrderTransportReq_);
				
				SendBase(args, getOrderTransport_argsHelper.getInstance());
			}
			
			
			private com.vip.order.biz.response.GetOrderTransportResp recv_getOrderTransport(){
				
				getOrderTransport_result result = new getOrderTransport_result();
				ReceiveBase(result, getOrderTransport_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.order.biz.response.GetOrderTransportDetailResp getOrderTransportDetail(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.GetOrderTransportDetailReq getOrderTransportDetailReq_) {
				
				send_getOrderTransportDetail(requestHeader_,getOrderTransportDetailReq_);
				return recv_getOrderTransportDetail(); 
				
			}
			
			
			private void send_getOrderTransportDetail(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.GetOrderTransportDetailReq getOrderTransportDetailReq_){
				
				InitInvocation("getOrderTransportDetail");
				
				getOrderTransportDetail_args args = new getOrderTransportDetail_args();
				args.SetRequestHeader(requestHeader_);
				args.SetGetOrderTransportDetailReq(getOrderTransportDetailReq_);
				
				SendBase(args, getOrderTransportDetail_argsHelper.getInstance());
			}
			
			
			private com.vip.order.biz.response.GetOrderTransportDetailResp recv_getOrderTransportDetail(){
				
				getOrderTransportDetail_result result = new getOrderTransportDetail_result();
				ReceiveBase(result, getOrderTransportDetail_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.order.biz.response.GetTransportListByCodesResp getOrderTransportListByCodes(com.vip.order.common.pojo.order.request.RequestHeader requestHeaderParam_,com.vip.order.biz.request.GetTransportListByCodesReq getTransportListByCodesParam_) {
				
				send_getOrderTransportListByCodes(requestHeaderParam_,getTransportListByCodesParam_);
				return recv_getOrderTransportListByCodes(); 
				
			}
			
			
			private void send_getOrderTransportListByCodes(com.vip.order.common.pojo.order.request.RequestHeader requestHeaderParam_,com.vip.order.biz.request.GetTransportListByCodesReq getTransportListByCodesParam_){
				
				InitInvocation("getOrderTransportListByCodes");
				
				getOrderTransportListByCodes_args args = new getOrderTransportListByCodes_args();
				args.SetRequestHeaderParam(requestHeaderParam_);
				args.SetGetTransportListByCodesParam(getTransportListByCodesParam_);
				
				SendBase(args, getOrderTransportListByCodes_argsHelper.getInstance());
			}
			
			
			private com.vip.order.biz.response.GetTransportListByCodesResp recv_getOrderTransportListByCodes(){
				
				getOrderTransportListByCodes_result result = new getOrderTransportListByCodes_result();
				ReceiveBase(result, getOrderTransportListByCodes_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.order.biz.response.GetOrdersBySizeIdResp getOrdersBySizeId(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.GetOrdersBySizeIdReq req_,com.vip.order.common.pojo.order.request.ResultFilter filter_) {
				
				send_getOrdersBySizeId(requestHeader_,req_,filter_);
				return recv_getOrdersBySizeId(); 
				
			}
			
			
			private void send_getOrdersBySizeId(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.GetOrdersBySizeIdReq req_,com.vip.order.common.pojo.order.request.ResultFilter filter_){
				
				InitInvocation("getOrdersBySizeId");
				
				getOrdersBySizeId_args args = new getOrdersBySizeId_args();
				args.SetRequestHeader(requestHeader_);
				args.SetReq(req_);
				args.SetFilter(filter_);
				
				SendBase(args, getOrdersBySizeId_argsHelper.getInstance());
			}
			
			
			private com.vip.order.biz.response.GetOrdersBySizeIdResp recv_getOrdersBySizeId(){
				
				getOrdersBySizeId_result result = new getOrdersBySizeId_result();
				ReceiveBase(result, getOrdersBySizeId_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.order.biz.response.GetPrepayOrderStatusResp getPrepayOrderStatus(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.GetPrepayOrderStatusReq req_) {
				
				send_getPrepayOrderStatus(requestHeader_,req_);
				return recv_getPrepayOrderStatus(); 
				
			}
			
			
			private void send_getPrepayOrderStatus(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.GetPrepayOrderStatusReq req_){
				
				InitInvocation("getPrepayOrderStatus");
				
				getPrepayOrderStatus_args args = new getPrepayOrderStatus_args();
				args.SetRequestHeader(requestHeader_);
				args.SetReq(req_);
				
				SendBase(args, getPrepayOrderStatus_argsHelper.getInstance());
			}
			
			
			private com.vip.order.biz.response.GetPrepayOrderStatusResp recv_getPrepayOrderStatus(){
				
				getPrepayOrderStatus_result result = new getPrepayOrderStatus_result();
				ReceiveBase(result, getPrepayOrderStatus_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.order.biz.response.GetPrepayOrderUnpayMsgResp getPrepayOrderUnpayMsg(com.vip.order.common.pojo.order.request.RequestHeader header_,com.vip.order.biz.request.GetPrepayOrderUnpayMsgReq req_) {
				
				send_getPrepayOrderUnpayMsg(header_,req_);
				return recv_getPrepayOrderUnpayMsg(); 
				
			}
			
			
			private void send_getPrepayOrderUnpayMsg(com.vip.order.common.pojo.order.request.RequestHeader header_,com.vip.order.biz.request.GetPrepayOrderUnpayMsgReq req_){
				
				InitInvocation("getPrepayOrderUnpayMsg");
				
				getPrepayOrderUnpayMsg_args args = new getPrepayOrderUnpayMsg_args();
				args.SetHeader(header_);
				args.SetReq(req_);
				
				SendBase(args, getPrepayOrderUnpayMsg_argsHelper.getInstance());
			}
			
			
			private com.vip.order.biz.response.GetPrepayOrderUnpayMsgResp recv_getPrepayOrderUnpayMsg(){
				
				getPrepayOrderUnpayMsg_result result = new getPrepayOrderUnpayMsg_result();
				ReceiveBase(result, getPrepayOrderUnpayMsg_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.order.biz.response.GetRdcResp getRdc(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.GetRdcReq getRdcReq_) {
				
				send_getRdc(requestHeader_,getRdcReq_);
				return recv_getRdc(); 
				
			}
			
			
			private void send_getRdc(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.GetRdcReq getRdcReq_){
				
				InitInvocation("getRdc");
				
				getRdc_args args = new getRdc_args();
				args.SetRequestHeader(requestHeader_);
				args.SetGetRdcReq(getRdcReq_);
				
				SendBase(args, getRdc_argsHelper.getInstance());
			}
			
			
			private com.vip.order.biz.response.GetRdcResp recv_getRdc(){
				
				getRdc_result result = new getRdc_result();
				ReceiveBase(result, getRdc_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.order.biz.response.GetRdcInvoiceResp getRdcInvoice(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.GetRdcInvoiceReq req_) {
				
				send_getRdcInvoice(requestHeader_,req_);
				return recv_getRdcInvoice(); 
				
			}
			
			
			private void send_getRdcInvoice(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.GetRdcInvoiceReq req_){
				
				InitInvocation("getRdcInvoice");
				
				getRdcInvoice_args args = new getRdcInvoice_args();
				args.SetRequestHeader(requestHeader_);
				args.SetReq(req_);
				
				SendBase(args, getRdcInvoice_argsHelper.getInstance());
			}
			
			
			private com.vip.order.biz.response.GetRdcInvoiceResp recv_getRdcInvoice(){
				
				getRdcInvoice_result result = new getRdcInvoice_result();
				ReceiveBase(result, getRdcInvoice_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.order.biz.response.GetReturnOrExchangeGoodsResp getReturnOrExchangeGoods(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.GetReturnOrExchangeGoodsReq req_) {
				
				send_getReturnOrExchangeGoods(requestHeader_,req_);
				return recv_getReturnOrExchangeGoods(); 
				
			}
			
			
			private void send_getReturnOrExchangeGoods(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.GetReturnOrExchangeGoodsReq req_){
				
				InitInvocation("getReturnOrExchangeGoods");
				
				getReturnOrExchangeGoods_args args = new getReturnOrExchangeGoods_args();
				args.SetRequestHeader(requestHeader_);
				args.SetReq(req_);
				
				SendBase(args, getReturnOrExchangeGoods_argsHelper.getInstance());
			}
			
			
			private com.vip.order.biz.response.GetReturnOrExchangeGoodsResp recv_getReturnOrExchangeGoods(){
				
				getReturnOrExchangeGoods_result result = new getReturnOrExchangeGoods_result();
				ReceiveBase(result, getReturnOrExchangeGoods_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.order.biz.response.GetSimpleOrderFlowFlagResp getSimpleOrderFlowFlag(com.vip.order.common.pojo.order.request.RequestHeader requestHeaderParam_,com.vip.order.biz.request.GetSimpleOrderFlowFlagReq getSimpleOrderFlowFlagParam_) {
				
				send_getSimpleOrderFlowFlag(requestHeaderParam_,getSimpleOrderFlowFlagParam_);
				return recv_getSimpleOrderFlowFlag(); 
				
			}
			
			
			private void send_getSimpleOrderFlowFlag(com.vip.order.common.pojo.order.request.RequestHeader requestHeaderParam_,com.vip.order.biz.request.GetSimpleOrderFlowFlagReq getSimpleOrderFlowFlagParam_){
				
				InitInvocation("getSimpleOrderFlowFlag");
				
				getSimpleOrderFlowFlag_args args = new getSimpleOrderFlowFlag_args();
				args.SetRequestHeaderParam(requestHeaderParam_);
				args.SetGetSimpleOrderFlowFlagParam(getSimpleOrderFlowFlagParam_);
				
				SendBase(args, getSimpleOrderFlowFlag_argsHelper.getInstance());
			}
			
			
			private com.vip.order.biz.response.GetSimpleOrderFlowFlagResp recv_getSimpleOrderFlowFlag(){
				
				getSimpleOrderFlowFlag_result result = new getSimpleOrderFlowFlag_result();
				ReceiveBase(result, getSimpleOrderFlowFlag_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.order.biz.response.GetUnpayOrderResp getUnpayOrderList(com.vip.order.common.pojo.order.request.RequestHeader requestHeaderParam_,com.vip.order.biz.request.GetUnpayOrderReq getUnpayOrderParam_) {
				
				send_getUnpayOrderList(requestHeaderParam_,getUnpayOrderParam_);
				return recv_getUnpayOrderList(); 
				
			}
			
			
			private void send_getUnpayOrderList(com.vip.order.common.pojo.order.request.RequestHeader requestHeaderParam_,com.vip.order.biz.request.GetUnpayOrderReq getUnpayOrderParam_){
				
				InitInvocation("getUnpayOrderList");
				
				getUnpayOrderList_args args = new getUnpayOrderList_args();
				args.SetRequestHeaderParam(requestHeaderParam_);
				args.SetGetUnpayOrderParam(getUnpayOrderParam_);
				
				SendBase(args, getUnpayOrderList_argsHelper.getInstance());
			}
			
			
			private com.vip.order.biz.response.GetUnpayOrderResp recv_getUnpayOrderList(){
				
				getUnpayOrderList_result result = new getUnpayOrderList_result();
				ReceiveBase(result, getUnpayOrderList_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.order.biz.response.GetUserDeliveryAddressResp getUserDeliveryAddress(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.GetUserDeliveryAddressReq getUserDeliveryAddressReq_,com.vip.order.common.pojo.order.request.ResultFilter resultFilter_) {
				
				send_getUserDeliveryAddress(requestHeader_,getUserDeliveryAddressReq_,resultFilter_);
				return recv_getUserDeliveryAddress(); 
				
			}
			
			
			private void send_getUserDeliveryAddress(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.GetUserDeliveryAddressReq getUserDeliveryAddressReq_,com.vip.order.common.pojo.order.request.ResultFilter resultFilter_){
				
				InitInvocation("getUserDeliveryAddress");
				
				getUserDeliveryAddress_args args = new getUserDeliveryAddress_args();
				args.SetRequestHeader(requestHeader_);
				args.SetGetUserDeliveryAddressReq(getUserDeliveryAddressReq_);
				args.SetResultFilter(resultFilter_);
				
				SendBase(args, getUserDeliveryAddress_argsHelper.getInstance());
			}
			
			
			private com.vip.order.biz.response.GetUserDeliveryAddressResp recv_getUserDeliveryAddress(){
				
				getUserDeliveryAddress_result result = new getUserDeliveryAddress_result();
				ReceiveBase(result, getUserDeliveryAddress_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.order.biz.response.GetUserFirstOrderResp getUserFirstOrder(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.GetUserFirstOrderReq getUserFirstOrderReq_) {
				
				send_getUserFirstOrder(requestHeader_,getUserFirstOrderReq_);
				return recv_getUserFirstOrder(); 
				
			}
			
			
			private void send_getUserFirstOrder(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.GetUserFirstOrderReq getUserFirstOrderReq_){
				
				InitInvocation("getUserFirstOrder");
				
				getUserFirstOrder_args args = new getUserFirstOrder_args();
				args.SetRequestHeader(requestHeader_);
				args.SetGetUserFirstOrderReq(getUserFirstOrderReq_);
				
				SendBase(args, getUserFirstOrder_argsHelper.getInstance());
			}
			
			
			private com.vip.order.biz.response.GetUserFirstOrderResp recv_getUserFirstOrder(){
				
				getUserFirstOrder_result result = new getUserFirstOrder_result();
				ReceiveBase(result, getUserFirstOrder_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.hermes.core.health.CheckResult healthCheck() {
				
				send_healthCheck();
				return recv_healthCheck(); 
				
			}
			
			
			private void send_healthCheck(){
				
				InitInvocation("healthCheck");
				
				healthCheck_args args = new healthCheck_args();
				
				SendBase(args, healthCheck_argsHelper.getInstance());
			}
			
			
			private com.vip.hermes.core.health.CheckResult recv_healthCheck(){
				
				healthCheck_result result = new healthCheck_result();
				ReceiveBase(result, healthCheck_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.order.biz.response.MergeOrderResp mergeOrder(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.MergeOrderReq reqParam_) {
				
				send_mergeOrder(requestHeader_,reqParam_);
				return recv_mergeOrder(); 
				
			}
			
			
			private void send_mergeOrder(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.MergeOrderReq reqParam_){
				
				InitInvocation("mergeOrder");
				
				mergeOrder_args args = new mergeOrder_args();
				args.SetRequestHeader(requestHeader_);
				args.SetReqParam(reqParam_);
				
				SendBase(args, mergeOrder_argsHelper.getInstance());
			}
			
			
			private com.vip.order.biz.response.MergeOrderResp recv_mergeOrder(){
				
				mergeOrder_result result = new mergeOrder_result();
				ReceiveBase(result, mergeOrder_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.order.biz.response.ModifyOrderConsigneeResp modifyOrderConsignee(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.ModifyOrderConsigneeReq modifyOrderConsigneeReq_) {
				
				send_modifyOrderConsignee(requestHeader_,modifyOrderConsigneeReq_);
				return recv_modifyOrderConsignee(); 
				
			}
			
			
			private void send_modifyOrderConsignee(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.ModifyOrderConsigneeReq modifyOrderConsigneeReq_){
				
				InitInvocation("modifyOrderConsignee");
				
				modifyOrderConsignee_args args = new modifyOrderConsignee_args();
				args.SetRequestHeader(requestHeader_);
				args.SetModifyOrderConsigneeReq(modifyOrderConsigneeReq_);
				
				SendBase(args, modifyOrderConsignee_argsHelper.getInstance());
			}
			
			
			private com.vip.order.biz.response.ModifyOrderConsigneeResp recv_modifyOrderConsignee(){
				
				modifyOrderConsignee_result result = new modifyOrderConsignee_result();
				ReceiveBase(result, modifyOrderConsignee_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.order.biz.response.ModifyOrderElectronicInvoiceResp modifyOrderElectronicInvoice(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.ModifyOrderElectronicInvoiceReq modifyOrderElectronicInvoiceReq_) {
				
				send_modifyOrderElectronicInvoice(requestHeader_,modifyOrderElectronicInvoiceReq_);
				return recv_modifyOrderElectronicInvoice(); 
				
			}
			
			
			private void send_modifyOrderElectronicInvoice(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.ModifyOrderElectronicInvoiceReq modifyOrderElectronicInvoiceReq_){
				
				InitInvocation("modifyOrderElectronicInvoice");
				
				modifyOrderElectronicInvoice_args args = new modifyOrderElectronicInvoice_args();
				args.SetRequestHeader(requestHeader_);
				args.SetModifyOrderElectronicInvoiceReq(modifyOrderElectronicInvoiceReq_);
				
				SendBase(args, modifyOrderElectronicInvoice_argsHelper.getInstance());
			}
			
			
			private com.vip.order.biz.response.ModifyOrderElectronicInvoiceResp recv_modifyOrderElectronicInvoice(){
				
				modifyOrderElectronicInvoice_result result = new modifyOrderElectronicInvoice_result();
				ReceiveBase(result, modifyOrderElectronicInvoice_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.order.biz.response.ModifyOrderGoodsResp modifyOrderGoods(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.ModifyOrderGoodsReq orderGoodsReq_) {
				
				send_modifyOrderGoods(requestHeader_,orderGoodsReq_);
				return recv_modifyOrderGoods(); 
				
			}
			
			
			private void send_modifyOrderGoods(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.ModifyOrderGoodsReq orderGoodsReq_){
				
				InitInvocation("modifyOrderGoods");
				
				modifyOrderGoods_args args = new modifyOrderGoods_args();
				args.SetRequestHeader(requestHeader_);
				args.SetOrderGoodsReq(orderGoodsReq_);
				
				SendBase(args, modifyOrderGoods_argsHelper.getInstance());
			}
			
			
			private com.vip.order.biz.response.ModifyOrderGoodsResp recv_modifyOrderGoods(){
				
				modifyOrderGoods_result result = new modifyOrderGoods_result();
				ReceiveBase(result, modifyOrderGoods_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.order.biz.request.ModifyOrderPayTypeRsp modifyOrderPayType(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.common.pojo.order.vo.ModifyPayTypeReq ModifyPayTypeReq_) {
				
				send_modifyOrderPayType(requestHeader_,ModifyPayTypeReq_);
				return recv_modifyOrderPayType(); 
				
			}
			
			
			private void send_modifyOrderPayType(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.common.pojo.order.vo.ModifyPayTypeReq ModifyPayTypeReq_){
				
				InitInvocation("modifyOrderPayType");
				
				modifyOrderPayType_args args = new modifyOrderPayType_args();
				args.SetRequestHeader(requestHeader_);
				args.SetModifyPayTypeReq(ModifyPayTypeReq_);
				
				SendBase(args, modifyOrderPayType_argsHelper.getInstance());
			}
			
			
			private com.vip.order.biz.request.ModifyOrderPayTypeRsp recv_modifyOrderPayType(){
				
				modifyOrderPayType_result result = new modifyOrderPayType_result();
				ReceiveBase(result, modifyOrderPayType_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.order.biz.response.ModifyOrderQualifiedResp modifyOrderQualified(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.param.ModifyOrderQualifiedReq req_) {
				
				send_modifyOrderQualified(requestHeader_,req_);
				return recv_modifyOrderQualified(); 
				
			}
			
			
			private void send_modifyOrderQualified(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.param.ModifyOrderQualifiedReq req_){
				
				InitInvocation("modifyOrderQualified");
				
				modifyOrderQualified_args args = new modifyOrderQualified_args();
				args.SetRequestHeader(requestHeader_);
				args.SetReq(req_);
				
				SendBase(args, modifyOrderQualified_argsHelper.getInstance());
			}
			
			
			private com.vip.order.biz.response.ModifyOrderQualifiedResp recv_modifyOrderQualified(){
				
				modifyOrderQualified_result result = new modifyOrderQualified_result();
				ReceiveBase(result, modifyOrderQualified_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.order.biz.response.ModifyOrderShippedResp modifyOrderShipped(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.ModifyOrderShippedReq modifyOrderShippedReq_) {
				
				send_modifyOrderShipped(requestHeader_,modifyOrderShippedReq_);
				return recv_modifyOrderShipped(); 
				
			}
			
			
			private void send_modifyOrderShipped(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.ModifyOrderShippedReq modifyOrderShippedReq_){
				
				InitInvocation("modifyOrderShipped");
				
				modifyOrderShipped_args args = new modifyOrderShipped_args();
				args.SetRequestHeader(requestHeader_);
				args.SetModifyOrderShippedReq(modifyOrderShippedReq_);
				
				SendBase(args, modifyOrderShipped_argsHelper.getInstance());
			}
			
			
			private com.vip.order.biz.response.ModifyOrderShippedResp recv_modifyOrderShipped(){
				
				modifyOrderShipped_result result = new modifyOrderShipped_result();
				ReceiveBase(result, modifyOrderShipped_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.order.biz.request.ModifyOrderPayTypeRsp modifyPrepayOrderPayType(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.ModifyPrepayOrderPayTypeReq modifyPrepayOrderPayTypeReq_) {
				
				send_modifyPrepayOrderPayType(requestHeader_,modifyPrepayOrderPayTypeReq_);
				return recv_modifyPrepayOrderPayType(); 
				
			}
			
			
			private void send_modifyPrepayOrderPayType(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.ModifyPrepayOrderPayTypeReq modifyPrepayOrderPayTypeReq_){
				
				InitInvocation("modifyPrepayOrderPayType");
				
				modifyPrepayOrderPayType_args args = new modifyPrepayOrderPayType_args();
				args.SetRequestHeader(requestHeader_);
				args.SetModifyPrepayOrderPayTypeReq(modifyPrepayOrderPayTypeReq_);
				
				SendBase(args, modifyPrepayOrderPayType_argsHelper.getInstance());
			}
			
			
			private com.vip.order.biz.request.ModifyOrderPayTypeRsp recv_modifyPrepayOrderPayType(){
				
				modifyPrepayOrderPayType_result result = new modifyPrepayOrderPayType_result();
				ReceiveBase(result, modifyPrepayOrderPayType_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.order.biz.response.NotifyCustomsDeclarationFailedResp notifyCustomsDeclarationFailed(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.NotifyCustomsDeclarationFailedReq req_) {
				
				send_notifyCustomsDeclarationFailed(requestHeader_,req_);
				return recv_notifyCustomsDeclarationFailed(); 
				
			}
			
			
			private void send_notifyCustomsDeclarationFailed(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.NotifyCustomsDeclarationFailedReq req_){
				
				InitInvocation("notifyCustomsDeclarationFailed");
				
				notifyCustomsDeclarationFailed_args args = new notifyCustomsDeclarationFailed_args();
				args.SetRequestHeader(requestHeader_);
				args.SetReq(req_);
				
				SendBase(args, notifyCustomsDeclarationFailed_argsHelper.getInstance());
			}
			
			
			private com.vip.order.biz.response.NotifyCustomsDeclarationFailedResp recv_notifyCustomsDeclarationFailed(){
				
				notifyCustomsDeclarationFailed_result result = new notifyCustomsDeclarationFailed_result();
				ReceiveBase(result, notifyCustomsDeclarationFailed_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.order.biz.response.OfcEntranceGrayControlResp ofcEntranceGrayControl(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.OfcEntranceGrayControlReq req_) {
				
				send_ofcEntranceGrayControl(requestHeader_,req_);
				return recv_ofcEntranceGrayControl(); 
				
			}
			
			
			private void send_ofcEntranceGrayControl(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.OfcEntranceGrayControlReq req_){
				
				InitInvocation("ofcEntranceGrayControl");
				
				ofcEntranceGrayControl_args args = new ofcEntranceGrayControl_args();
				args.SetRequestHeader(requestHeader_);
				args.SetReq(req_);
				
				SendBase(args, ofcEntranceGrayControl_argsHelper.getInstance());
			}
			
			
			private com.vip.order.biz.response.OfcEntranceGrayControlResp recv_ofcEntranceGrayControl(){
				
				ofcEntranceGrayControl_result result = new ofcEntranceGrayControl_result();
				ReceiveBase(result, ofcEntranceGrayControl_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.order.biz.response.PaymentReceivedResp paymentReceived(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.PaymentReceivedReq req_) {
				
				send_paymentReceived(requestHeader_,req_);
				return recv_paymentReceived(); 
				
			}
			
			
			private void send_paymentReceived(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.PaymentReceivedReq req_){
				
				InitInvocation("paymentReceived");
				
				paymentReceived_args args = new paymentReceived_args();
				args.SetRequestHeader(requestHeader_);
				args.SetReq(req_);
				
				SendBase(args, paymentReceived_argsHelper.getInstance());
			}
			
			
			private com.vip.order.biz.response.PaymentReceivedResp recv_paymentReceived(){
				
				paymentReceived_result result = new paymentReceived_result();
				ReceiveBase(result, paymentReceived_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.order.biz.response.PostOrderVMSMessageResp postOrderVMSMessage(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.PostOrderVMSMessageReq postOrderVMSMessageReq_) {
				
				send_postOrderVMSMessage(requestHeader_,postOrderVMSMessageReq_);
				return recv_postOrderVMSMessage(); 
				
			}
			
			
			private void send_postOrderVMSMessage(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.PostOrderVMSMessageReq postOrderVMSMessageReq_){
				
				InitInvocation("postOrderVMSMessage");
				
				postOrderVMSMessage_args args = new postOrderVMSMessage_args();
				args.SetRequestHeader(requestHeader_);
				args.SetPostOrderVMSMessageReq(postOrderVMSMessageReq_);
				
				SendBase(args, postOrderVMSMessage_argsHelper.getInstance());
			}
			
			
			private com.vip.order.biz.response.PostOrderVMSMessageResp recv_postOrderVMSMessage(){
				
				postOrderVMSMessage_result result = new postOrderVMSMessage_result();
				ReceiveBase(result, postOrderVMSMessage_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.order.biz.response.PutIntoSplitQueueResp putIntoSplitQueue(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.PutIntoSplitQueueReq putIntoSplitQueueReq_) {
				
				send_putIntoSplitQueue(requestHeader_,putIntoSplitQueueReq_);
				return recv_putIntoSplitQueue(); 
				
			}
			
			
			private void send_putIntoSplitQueue(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.PutIntoSplitQueueReq putIntoSplitQueueReq_){
				
				InitInvocation("putIntoSplitQueue");
				
				putIntoSplitQueue_args args = new putIntoSplitQueue_args();
				args.SetRequestHeader(requestHeader_);
				args.SetPutIntoSplitQueueReq(putIntoSplitQueueReq_);
				
				SendBase(args, putIntoSplitQueue_argsHelper.getInstance());
			}
			
			
			private com.vip.order.biz.response.PutIntoSplitQueueResp recv_putIntoSplitQueue(){
				
				putIntoSplitQueue_result result = new putIntoSplitQueue_result();
				ReceiveBase(result, putIntoSplitQueue_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.order.biz.response.PutKeyToRollbackQueueResp putKeyToRollbackQueue(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.PutKeyToRollbackQueueReq req_) {
				
				send_putKeyToRollbackQueue(requestHeader_,req_);
				return recv_putKeyToRollbackQueue(); 
				
			}
			
			
			private void send_putKeyToRollbackQueue(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.PutKeyToRollbackQueueReq req_){
				
				InitInvocation("putKeyToRollbackQueue");
				
				putKeyToRollbackQueue_args args = new putKeyToRollbackQueue_args();
				args.SetRequestHeader(requestHeader_);
				args.SetReq(req_);
				
				SendBase(args, putKeyToRollbackQueue_argsHelper.getInstance());
			}
			
			
			private com.vip.order.biz.response.PutKeyToRollbackQueueResp recv_putKeyToRollbackQueue(){
				
				putKeyToRollbackQueue_result result = new putKeyToRollbackQueue_result();
				ReceiveBase(result, putKeyToRollbackQueue_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.order.biz.response.PutOrderToRollbackQueueResp putOrderToRollbackQueue(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.PutOrderToRollbackQueueReq req_) {
				
				send_putOrderToRollbackQueue(requestHeader_,req_);
				return recv_putOrderToRollbackQueue(); 
				
			}
			
			
			private void send_putOrderToRollbackQueue(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.PutOrderToRollbackQueueReq req_){
				
				InitInvocation("putOrderToRollbackQueue");
				
				putOrderToRollbackQueue_args args = new putOrderToRollbackQueue_args();
				args.SetRequestHeader(requestHeader_);
				args.SetReq(req_);
				
				SendBase(args, putOrderToRollbackQueue_argsHelper.getInstance());
			}
			
			
			private com.vip.order.biz.response.PutOrderToRollbackQueueResp recv_putOrderToRollbackQueue(){
				
				putOrderToRollbackQueue_result result = new putOrderToRollbackQueue_result();
				ReceiveBase(result, putOrderToRollbackQueue_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.order.biz.response.ReceptionConfirmDeliveredResp receptionConfirmDelivered(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.ReceptionConfirmDeliveredReq req_) {
				
				send_receptionConfirmDelivered(requestHeader_,req_);
				return recv_receptionConfirmDelivered(); 
				
			}
			
			
			private void send_receptionConfirmDelivered(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.ReceptionConfirmDeliveredReq req_){
				
				InitInvocation("receptionConfirmDelivered");
				
				receptionConfirmDelivered_args args = new receptionConfirmDelivered_args();
				args.SetRequestHeader(requestHeader_);
				args.SetReq(req_);
				
				SendBase(args, receptionConfirmDelivered_argsHelper.getInstance());
			}
			
			
			private com.vip.order.biz.response.ReceptionConfirmDeliveredResp recv_receptionConfirmDelivered(){
				
				receptionConfirmDelivered_result result = new receptionConfirmDelivered_result();
				ReceiveBase(result, receptionConfirmDelivered_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.order.biz.response.OrderRefundResp refundOrder(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.OrderRefundReq orderRefundReq_) {
				
				send_refundOrder(requestHeader_,orderRefundReq_);
				return recv_refundOrder(); 
				
			}
			
			
			private void send_refundOrder(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.OrderRefundReq orderRefundReq_){
				
				InitInvocation("refundOrder");
				
				refundOrder_args args = new refundOrder_args();
				args.SetRequestHeader(requestHeader_);
				args.SetOrderRefundReq(orderRefundReq_);
				
				SendBase(args, refundOrder_argsHelper.getInstance());
			}
			
			
			private com.vip.order.biz.response.OrderRefundResp recv_refundOrder(){
				
				refundOrder_result result = new refundOrder_result();
				ReceiveBase(result, refundOrder_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.order.biz.response.ReleaseStockResp releaseStock(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.ReleaseStockReq releaseStockReq_) {
				
				send_releaseStock(requestHeader_,releaseStockReq_);
				return recv_releaseStock(); 
				
			}
			
			
			private void send_releaseStock(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.ReleaseStockReq releaseStockReq_){
				
				InitInvocation("releaseStock");
				
				releaseStock_args args = new releaseStock_args();
				args.SetRequestHeader(requestHeader_);
				args.SetReleaseStockReq(releaseStockReq_);
				
				SendBase(args, releaseStock_argsHelper.getInstance());
			}
			
			
			private com.vip.order.biz.response.ReleaseStockResp recv_releaseStock(){
				
				releaseStock_result result = new releaseStock_result();
				ReceiveBase(result, releaseStock_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.order.biz.response.RollbackOrderResp rollbackOrder(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.RollbackOrderReq rollbackOrderReq_) {
				
				send_rollbackOrder(requestHeader_,rollbackOrderReq_);
				return recv_rollbackOrder(); 
				
			}
			
			
			private void send_rollbackOrder(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.RollbackOrderReq rollbackOrderReq_){
				
				InitInvocation("rollbackOrder");
				
				rollbackOrder_args args = new rollbackOrder_args();
				args.SetRequestHeader(requestHeader_);
				args.SetRollbackOrderReq(rollbackOrderReq_);
				
				SendBase(args, rollbackOrder_argsHelper.getInstance());
			}
			
			
			private com.vip.order.biz.response.RollbackOrderResp recv_rollbackOrder(){
				
				rollbackOrder_result result = new rollbackOrder_result();
				ReceiveBase(result, rollbackOrder_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.order.biz.response.SearchOrderListByUserIdResp searchOrderListByUserId(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.SearchOrderListByUserIdReq getOrderHistoryReq_,com.vip.order.common.pojo.order.request.ResultFilter resultFilter_) {
				
				send_searchOrderListByUserId(requestHeader_,getOrderHistoryReq_,resultFilter_);
				return recv_searchOrderListByUserId(); 
				
			}
			
			
			private void send_searchOrderListByUserId(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.SearchOrderListByUserIdReq getOrderHistoryReq_,com.vip.order.common.pojo.order.request.ResultFilter resultFilter_){
				
				InitInvocation("searchOrderListByUserId");
				
				searchOrderListByUserId_args args = new searchOrderListByUserId_args();
				args.SetRequestHeader(requestHeader_);
				args.SetGetOrderHistoryReq(getOrderHistoryReq_);
				args.SetResultFilter(resultFilter_);
				
				SendBase(args, searchOrderListByUserId_argsHelper.getInstance());
			}
			
			
			private com.vip.order.biz.response.SearchOrderListByUserIdResp recv_searchOrderListByUserId(){
				
				searchOrderListByUserId_result result = new searchOrderListByUserId_result();
				ReceiveBase(result, searchOrderListByUserId_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.order.biz.response.SignOrderResp signOrder(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.SignOrderReq signOrderReq_) {
				
				send_signOrder(requestHeader_,signOrderReq_);
				return recv_signOrder(); 
				
			}
			
			
			private void send_signOrder(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.SignOrderReq signOrderReq_){
				
				InitInvocation("signOrder");
				
				signOrder_args args = new signOrder_args();
				args.SetRequestHeader(requestHeader_);
				args.SetSignOrderReq(signOrderReq_);
				
				SendBase(args, signOrder_argsHelper.getInstance());
			}
			
			
			private com.vip.order.biz.response.SignOrderResp recv_signOrder(){
				
				signOrder_result result = new signOrder_result();
				ReceiveBase(result, signOrder_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.order.biz.response.GroupByOrderAuditResp triggerGroupByAuditOrder(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.GroupByOrderAuditReq groupByOrderAuditReq_) {
				
				send_triggerGroupByAuditOrder(requestHeader_,groupByOrderAuditReq_);
				return recv_triggerGroupByAuditOrder(); 
				
			}
			
			
			private void send_triggerGroupByAuditOrder(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.GroupByOrderAuditReq groupByOrderAuditReq_){
				
				InitInvocation("triggerGroupByAuditOrder");
				
				triggerGroupByAuditOrder_args args = new triggerGroupByAuditOrder_args();
				args.SetRequestHeader(requestHeader_);
				args.SetGroupByOrderAuditReq(groupByOrderAuditReq_);
				
				SendBase(args, triggerGroupByAuditOrder_argsHelper.getInstance());
			}
			
			
			private com.vip.order.biz.response.GroupByOrderAuditResp recv_triggerGroupByAuditOrder(){
				
				triggerGroupByAuditOrder_result result = new triggerGroupByAuditOrder_result();
				ReceiveBase(result, triggerGroupByAuditOrder_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.order.biz.response.UpdateAutoPayAuthResp updateAutoPayAuth(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.UpdateAutoPayAuthReq req_) {
				
				send_updateAutoPayAuth(requestHeader_,req_);
				return recv_updateAutoPayAuth(); 
				
			}
			
			
			private void send_updateAutoPayAuth(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.UpdateAutoPayAuthReq req_){
				
				InitInvocation("updateAutoPayAuth");
				
				updateAutoPayAuth_args args = new updateAutoPayAuth_args();
				args.SetRequestHeader(requestHeader_);
				args.SetReq(req_);
				
				SendBase(args, updateAutoPayAuth_argsHelper.getInstance());
			}
			
			
			private com.vip.order.biz.response.UpdateAutoPayAuthResp recv_updateAutoPayAuth(){
				
				updateAutoPayAuth_result result = new updateAutoPayAuth_result();
				ReceiveBase(result, updateAutoPayAuth_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.order.biz.response.UpdateOrderPayResultResp updateOrderPayResult(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.UpdateOrderPayResultReq updateOrderPayResultReq_) {
				
				send_updateOrderPayResult(requestHeader_,updateOrderPayResultReq_);
				return recv_updateOrderPayResult(); 
				
			}
			
			
			private void send_updateOrderPayResult(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.UpdateOrderPayResultReq updateOrderPayResultReq_){
				
				InitInvocation("updateOrderPayResult");
				
				updateOrderPayResult_args args = new updateOrderPayResult_args();
				args.SetRequestHeader(requestHeader_);
				args.SetUpdateOrderPayResultReq(updateOrderPayResultReq_);
				
				SendBase(args, updateOrderPayResult_argsHelper.getInstance());
			}
			
			
			private com.vip.order.biz.response.UpdateOrderPayResultResp recv_updateOrderPayResult(){
				
				updateOrderPayResult_result result = new updateOrderPayResult_result();
				ReceiveBase(result, updateOrderPayResult_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.order.biz.response.UpdateOrderToReturnVerifiedResp updateOrderToReturnVerified(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.UpdateOrderToReturnVerifiedReq updateOrderToReturnVerifiedReq_) {
				
				send_updateOrderToReturnVerified(requestHeader_,updateOrderToReturnVerifiedReq_);
				return recv_updateOrderToReturnVerified(); 
				
			}
			
			
			private void send_updateOrderToReturnVerified(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.UpdateOrderToReturnVerifiedReq updateOrderToReturnVerifiedReq_){
				
				InitInvocation("updateOrderToReturnVerified");
				
				updateOrderToReturnVerified_args args = new updateOrderToReturnVerified_args();
				args.SetRequestHeader(requestHeader_);
				args.SetUpdateOrderToReturnVerifiedReq(updateOrderToReturnVerifiedReq_);
				
				SendBase(args, updateOrderToReturnVerified_argsHelper.getInstance());
			}
			
			
			private com.vip.order.biz.response.UpdateOrderToReturnVerifiedResp recv_updateOrderToReturnVerified(){
				
				updateOrderToReturnVerified_result result = new updateOrderToReturnVerified_result();
				ReceiveBase(result, updateOrderToReturnVerified_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.order.biz.response.UpdatePayTypeToCODResp updatePayTypeToCOD(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.UpdatePayTypeToCODReq updatePayTypeToCODReq_) {
				
				send_updatePayTypeToCOD(requestHeader_,updatePayTypeToCODReq_);
				return recv_updatePayTypeToCOD(); 
				
			}
			
			
			private void send_updatePayTypeToCOD(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.UpdatePayTypeToCODReq updatePayTypeToCODReq_){
				
				InitInvocation("updatePayTypeToCOD");
				
				updatePayTypeToCOD_args args = new updatePayTypeToCOD_args();
				args.SetRequestHeader(requestHeader_);
				args.SetUpdatePayTypeToCODReq(updatePayTypeToCODReq_);
				
				SendBase(args, updatePayTypeToCOD_argsHelper.getInstance());
			}
			
			
			private com.vip.order.biz.response.UpdatePayTypeToCODResp recv_updatePayTypeToCOD(){
				
				updatePayTypeToCOD_result result = new updatePayTypeToCOD_result();
				ReceiveBase(result, updatePayTypeToCOD_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.order.biz.response.UpdatePrePayToVerifiedResp updatePrePayToVerified(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.UpdatePrePayToVerifiedReq updatePrePayToVerifiedReq_) {
				
				send_updatePrePayToVerified(requestHeader_,updatePrePayToVerifiedReq_);
				return recv_updatePrePayToVerified(); 
				
			}
			
			
			private void send_updatePrePayToVerified(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.UpdatePrePayToVerifiedReq updatePrePayToVerifiedReq_){
				
				InitInvocation("updatePrePayToVerified");
				
				updatePrePayToVerified_args args = new updatePrePayToVerified_args();
				args.SetRequestHeader(requestHeader_);
				args.SetUpdatePrePayToVerifiedReq(updatePrePayToVerifiedReq_);
				
				SendBase(args, updatePrePayToVerified_argsHelper.getInstance());
			}
			
			
			private com.vip.order.biz.response.UpdatePrePayToVerifiedResp recv_updatePrePayToVerified(){
				
				updatePrePayToVerified_result result = new updatePrePayToVerified_result();
				ReceiveBase(result, updatePrePayToVerified_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.order.biz.response.UpdateReservationStateResp updateReservationState(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.UpdateReservationStateReq req_) {
				
				send_updateReservationState(requestHeader_,req_);
				return recv_updateReservationState(); 
				
			}
			
			
			private void send_updateReservationState(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.UpdateReservationStateReq req_){
				
				InitInvocation("updateReservationState");
				
				updateReservationState_args args = new updateReservationState_args();
				args.SetRequestHeader(requestHeader_);
				args.SetReq(req_);
				
				SendBase(args, updateReservationState_argsHelper.getInstance());
			}
			
			
			private com.vip.order.biz.response.UpdateReservationStateResp recv_updateReservationState(){
				
				updateReservationState_result result = new updateReservationState_result();
				ReceiveBase(result, updateReservationState_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.order.biz.response.UserDeleteOrderResp userDeleteOrder(com.vip.order.common.pojo.order.request.RequestHeader header_,com.vip.order.biz.request.UserDeleteOrderReq req_) {
				
				send_userDeleteOrder(header_,req_);
				return recv_userDeleteOrder(); 
				
			}
			
			
			private void send_userDeleteOrder(com.vip.order.common.pojo.order.request.RequestHeader header_,com.vip.order.biz.request.UserDeleteOrderReq req_){
				
				InitInvocation("userDeleteOrder");
				
				userDeleteOrder_args args = new userDeleteOrder_args();
				args.SetHeader(header_);
				args.SetReq(req_);
				
				SendBase(args, userDeleteOrder_argsHelper.getInstance());
			}
			
			
			private com.vip.order.biz.response.UserDeleteOrderResp recv_userDeleteOrder(){
				
				userDeleteOrder_result result = new userDeleteOrder_result();
				ReceiveBase(result, userDeleteOrder_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.order.biz.response.VerifyStockAndGetPayableFlagResp verifyStockAndGetPayableFlag(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.VerifyStockAndGetPayableFlagReq req_) {
				
				send_verifyStockAndGetPayableFlag(requestHeader_,req_);
				return recv_verifyStockAndGetPayableFlag(); 
				
			}
			
			
			private void send_verifyStockAndGetPayableFlag(com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,com.vip.order.biz.request.VerifyStockAndGetPayableFlagReq req_){
				
				InitInvocation("verifyStockAndGetPayableFlag");
				
				verifyStockAndGetPayableFlag_args args = new verifyStockAndGetPayableFlag_args();
				args.SetRequestHeader(requestHeader_);
				args.SetReq(req_);
				
				SendBase(args, verifyStockAndGetPayableFlag_argsHelper.getInstance());
			}
			
			
			private com.vip.order.biz.response.VerifyStockAndGetPayableFlagResp recv_verifyStockAndGetPayableFlag(){
				
				verifyStockAndGetPayableFlag_result result = new verifyStockAndGetPayableFlag_result();
				ReceiveBase(result, verifyStockAndGetPayableFlag_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
		}
		
		
	}
	
}