using System;
using System.Collections.Generic;

namespace com.vip.order.biz.service{
	
	
	public interface OrdersBizService {
		
		
		com.vip.order.biz.response.AddOrderTransportResp addOrderTransport( com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,   com.vip.order.biz.request.AddOrderTransportReq addOrderTransportReq_ );
		
		com.vip.order.biz.response.AutoPayResp autoPay( com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,   com.vip.order.biz.request.AutoPayReq req_ );
		
		com.vip.order.biz.response.AutoPayFailResp autoPayFail( com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,   com.vip.order.biz.request.AutoPayFailReq req_ );
		
		com.vip.order.biz.response.AutoTakeInventoryResp autoTakeInventory( com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,   com.vip.order.biz.request.AutoTakeInventoryReq req_ );
		
		com.vip.order.biz.response.B2CSupportSendSmsResp b2cSupportSendSms( com.vip.order.common.pojo.order.request.RequestHeader header_,   com.vip.order.biz.request.B2CSupportSendSmsReq req_ );
		
		com.vip.order.biz.response.BatchGetOrderActiveDetailResp batchGetOrderActiveDetail( com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,   com.vip.order.biz.request.BatchGetOrderActiveDetailReq batchGetOrderActiveDetailReq_ );
		
		com.vip.order.biz.response.BatchGetOrderListResp batchGetOrderList( com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,   com.vip.order.biz.request.BatchGetOrderListReq searchOrderReq_,   com.vip.order.common.pojo.order.request.ResultFilter resultFilter_ );
		
		com.vip.order.biz.response.BatchGetOrderTransportListResp batchGetOrderTransportList( com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,   com.vip.order.biz.request.BatchGetOrderTransportListReq batchGetOrderTransportListReq_,   com.vip.order.common.pojo.order.request.ResultFilter resultFilter_ );
		
		com.vip.order.biz.response.BatchModifyOrderInvoiceResp batchModifyOrderInvoice( com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,   com.vip.order.biz.request.BatchModifyOrderInvoiceReq batchModifyOrderInvoiceReq_ );
		
		com.vip.order.biz.response.BatchUpdateWmsFlagResp batchUpdateWmsFlag( com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,   com.vip.order.biz.request.BatchUpdateWmsFlagReq batchUpdateWmsFlagReq_ );
		
		com.vip.order.biz.response.CalculateSplitOrderMoneyResp calculateSplitOrderMoney( com.vip.order.common.pojo.order.request.RequestHeader header_,   com.vip.order.biz.request.CalculateSplitOrderMoneyReq req_ );
		
		com.vip.order.biz.response.CancelOrderFixDataResp cancelOFixData( com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,   com.vip.order.biz.request.CancelOrderFixDataReq cancelOrderFixDataReq_ );
		
		com.vip.order.biz.response.CancelOrderResp cancelOrder( com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,   com.vip.order.biz.request.CancelOrderReq reqParam_,   com.vip.order.biz.request.CancelOrderPrivilegeReq privParam_ );
		
		com.vip.order.biz.response.CancelOrderResp cancelPresellOrder( com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,   com.vip.order.biz.request.CancelOrderReq reqParam_,   com.vip.order.biz.request.CancelOrderPrivilegeReq privParam_ );
		
		com.vip.order.biz.response.CheckCashOnDeliveryResp checkCashOnDelivery( com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,   com.vip.order.biz.request.CheckCashOnDeliveryReq checkCashOnDeliveryReq_ );
		
		com.vip.order.biz.response.CheckDeliveryFetchExchangeResp checkDeliveryFetchExchange( com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,   com.vip.order.biz.request.CheckDeliveryFetchExchangeReq checkDeliveryFetchExchangeReq_ );
		
		com.vip.order.biz.response.CheckDeliveryFetchReturnResp checkDeliveryFetchReturn( com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,   com.vip.order.biz.request.CheckDeliveryFetchReturnReq checkDeliveryFetchReturnReq_ );
		
		com.vip.order.biz.response.CheckOrderReturnVendorAuditResp checkOrderReturnVendorAudit( com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,   com.vip.order.biz.request.CheckOrderReturnVendorAuditReq checkOrderReturnVendorAuditReq_ );
		
		com.vip.order.biz.response.ConfirmDeliveredResp confirmDelivered( com.vip.order.common.pojo.order.request.RequestHeader header_,   com.vip.order.biz.request.ConfirmDeliveredReq req_ );
		
		com.vip.order.biz.response.ConfirmOrderGroupBuyResp confirmOrderGroupBuyResult( com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,   com.vip.order.biz.request.ConfirmOrderGroupBuyReq req_ );
		
		com.vip.order.biz.response.CreateOrderResp createOrder( com.vip.order.biz.request.RequestHeader requestHeader_,   int orderCategory_,   List<com.vip.order.biz.request.CreateOrderReq> createOrderParam_ );
		
		com.vip.order.biz.response.CreateOrderElectronicInvoiceResp createOrderElectronicInvoice( com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,   com.vip.order.biz.request.CreateOrderElectronicInvoiceReq createOrderElectronicInvoiceReq_ );
		
		com.vip.order.biz.response.CreateOrderPostProcResp createOrderPostProc( com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,   com.vip.order.biz.request.CreateOrderPostProcReq req_ );
		
		com.vip.order.biz.response.CreateOrderSnRespV2 createOrderSnV2( com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,   string warehouse_,   int number_ );
		
		com.vip.order.biz.response.CreateOrderSnRespV3 createOrderSnV3( com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,   com.vip.order.biz.request.CreateOrderSnReqV3 req_ );
		
		com.vip.order.biz.response.CreateOrderRespV2 createOrderV2( com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,   int orderCategory_,   List<com.vip.order.biz.request.CreateOrderReqV2> createOrderParam_ );
		
		com.vip.order.biz.response.CreateOrderRespV3 createOrderV3( com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,   int orderCategory_,   List<com.vip.order.biz.request.CreateOrderReqV3> createOrderParam_ );
		
		com.vip.order.biz.response.CSCCancelBackResp cscCancelBack( com.vip.order.common.pojo.order.request.RequestHeader header_,   com.vip.order.biz.request.CSCCancelBackReq req_ );
		
		com.vip.order.biz.response.DisplayOrderResp displayOrder( com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,   com.vip.order.biz.request.DisplayOrderReq req_ );
		
		com.vip.order.biz.response.GetAfterSaleOpTypeResp getAfterSaleOpType( com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,   com.vip.order.biz.request.GetAfterSaleOpTypeReq req_ );
		
		com.vip.order.biz.response.GetCanAfterSaleOrderListResp getCanAfterSaleOrderListByUserId( com.vip.order.common.pojo.order.request.RequestHeader header_,   com.vip.order.biz.request.GetCanAfterSaleOrderListReq req_,   com.vip.order.common.pojo.order.request.PageResultFilter pageResultFilter_ );
		
		com.vip.order.biz.response.GetCanRefundOrderCountResp getCanRefundOrderCount( com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,   com.vip.order.biz.request.GetCanRefundOrderCountReq getCanRefundOrderCountReq_ );
		
		com.vip.order.biz.response.GetCanRefundOrderListResp getCanRefundOrderList( com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,   com.vip.order.biz.request.GetCanRefundOrderListReq getCanRefundOrderListReq_ );
		
		com.vip.order.biz.response.GetEbsGoodsListResp getEbsGoodsList( com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,   com.vip.order.biz.request.GetEbsGoodsListReq getEbsGoodsListReq_ );
		
		com.vip.order.biz.response.GetGoodsDispatchWarehouseResp getGoodsDispatchWarehouse( com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,   com.vip.order.biz.request.GetGoodsDispatchWarehouseReq req_ );
		
		com.vip.order.biz.response.GetLimitedOrderGoodsCountResp getLimitedOrderGoodsCount( com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,   com.vip.order.biz.request.GetLimitedOrderGoodsCountReq getLimitedOrderGoodsCountReq_ );
		
		com.vip.order.biz.response.LinkageOrderResp getLinkageOrders( com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,   com.vip.order.biz.request.SearchLinkageOrderReq req_ );
		
		com.vip.order.biz.response.GetMergeOrderResp getMergeOrderList( com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,   com.vip.order.biz.request.GetMergeOrderReq getMergeOrderReq_ );
		
		com.vip.order.biz.response.OrderListCountResp getOrderCounts( com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,   com.vip.order.biz.request.SearchOrderReq searchOrderReq_ );
		
		com.vip.order.biz.response.OrderListCountResp getOrderCountsByUserId( com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,   com.vip.order.biz.request.GetOrderByUserIdReq getOrderByUserIdReq_ );
		
		com.vip.order.biz.response.GetOrderDeliveryBoxNumResp getOrderDeliveryBoxNum( com.vip.order.common.pojo.order.request.RequestHeader requestHeaderParam_,   string orderSn_ );
		
		com.vip.order.biz.response.SearchOrderDetailResp getOrderDetail( com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,   com.vip.order.biz.request.SearchOrderDetailReq searchOrderDetailReq_ );
		
		com.vip.order.biz.response.OrderElectronicInvoicesV2Resp getOrderElectronicInvoicesV2( com.vip.order.common.pojo.order.request.RequestHeader requestHeaderParam_,   com.vip.order.biz.request.SearchOrderElectronicInvoicesReq searchOrderElectronicInvoiceParam_,   com.vip.order.biz.request.ResultRequirement resultRequirement_ );
		
		com.vip.order.biz.response.GetOrderFavResp getOrderFav( com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,   List<string> orderSnList_ );
		
		com.vip.order.biz.response.GetOrderGoodsCountResultResp getOrderGoodsCount( com.vip.order.common.pojo.order.request.RequestHeader requestHeaderParam_,   com.vip.order.biz.request.GetOrderGoodsReq getOrderGoodsParam_ );
		
		com.vip.order.biz.response.GetOrderGoodsResultResp getOrderGoodsList( com.vip.order.common.pojo.order.request.RequestHeader requestHeaderParam_,   com.vip.order.biz.request.GetOrderGoodsReq getOrderGoodsParam_,   com.vip.order.common.pojo.order.request.ResultFilter resultFilter_ );
		
		com.vip.order.biz.response.GetOrderInstalmentsListResp getOrderInstalmentsList( com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,   com.vip.order.biz.request.GetOrderInstalmentsReq req_,   com.vip.order.common.pojo.order.request.ResultFilter filter_ );
		
		com.vip.order.biz.response.OrderInvoicesV2Resp getOrderInvoicesV2( com.vip.order.common.pojo.order.request.RequestHeader requestHeaderParam_,   com.vip.order.biz.request.SearchOrderInvoicesReq searchOrderInvoiceParam_ );
		
		com.vip.order.biz.response.SearchOrderListResp getOrderList( com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,   com.vip.order.biz.request.SearchOrderReq searchOrderReq_,   com.vip.order.common.pojo.order.request.ResultFilter resultFilter_ );
		
		com.vip.order.biz.response.GetOrderListByPosNoResp getOrderListByPosNo( com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,   com.vip.order.biz.request.GetOrderListByPosNoReq req_ );
		
		com.vip.order.biz.response.GetOrderListByUserIdResp getOrderListByUserId( com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,   com.vip.order.biz.request.GetOrderByUserIdReq getOrderByUserIdReq_,   com.vip.order.common.pojo.order.request.ResultFilter resultFilter_ );
		
		com.vip.order.biz.response.GetOrderLogsResp getOrderLogs( com.vip.order.common.pojo.order.request.RequestHeader requestHeaderParam_,   com.vip.order.biz.request.SearchOrderLogsReq searchOrderLogsParam_,   com.vip.order.biz.request.requirement.GetOrderLogsRequirement getOrderLogsRequirement_ );
		
		com.vip.order.biz.response.GetOrderOpStatusResp getOrderOpStatus( com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,   com.vip.order.biz.request.GetOrderOpStatusReq getOrderOpStatusReq_ );
		
		com.vip.order.biz.response.GetOrderPackageListResp getOrderPackageList( com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,   com.vip.order.biz.request.GetOrderPackageListReq getPackageListReq_ );
		
		com.vip.order.biz.response.GetOrderPayTypeResp getOrderPayType( com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,   com.vip.order.biz.request.GetOrderPayTypeReq getOrderPayTypeParam_,   com.vip.order.common.pojo.order.request.ResultFilter resultFilter_ );
		
		com.vip.order.biz.response.GetOrderSnByExOrderSnResp getOrderSnByExOrderSn( com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,   List<string> exOrderSns_ );
		
		com.vip.order.biz.response.GetOrderTransportResp getOrderTransport( com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,   com.vip.order.biz.request.GetOrderTransportReq getOrderTransportReq_ );
		
		com.vip.order.biz.response.GetOrderTransportDetailResp getOrderTransportDetail( com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,   com.vip.order.biz.request.GetOrderTransportDetailReq getOrderTransportDetailReq_ );
		
		com.vip.order.biz.response.GetTransportListByCodesResp getOrderTransportListByCodes( com.vip.order.common.pojo.order.request.RequestHeader requestHeaderParam_,   com.vip.order.biz.request.GetTransportListByCodesReq getTransportListByCodesParam_ );
		
		com.vip.order.biz.response.GetOrdersBySizeIdResp getOrdersBySizeId( com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,   com.vip.order.biz.request.GetOrdersBySizeIdReq req_,   com.vip.order.common.pojo.order.request.ResultFilter filter_ );
		
		com.vip.order.biz.response.GetPrepayOrderStatusResp getPrepayOrderStatus( com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,   com.vip.order.biz.request.GetPrepayOrderStatusReq req_ );
		
		com.vip.order.biz.response.GetPrepayOrderUnpayMsgResp getPrepayOrderUnpayMsg( com.vip.order.common.pojo.order.request.RequestHeader header_,   com.vip.order.biz.request.GetPrepayOrderUnpayMsgReq req_ );
		
		com.vip.order.biz.response.GetRdcResp getRdc( com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,   com.vip.order.biz.request.GetRdcReq getRdcReq_ );
		
		com.vip.order.biz.response.GetRdcInvoiceResp getRdcInvoice( com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,   com.vip.order.biz.request.GetRdcInvoiceReq req_ );
		
		com.vip.order.biz.response.GetReturnOrExchangeGoodsResp getReturnOrExchangeGoods( com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,   com.vip.order.biz.request.GetReturnOrExchangeGoodsReq req_ );
		
		com.vip.order.biz.response.GetSimpleOrderFlowFlagResp getSimpleOrderFlowFlag( com.vip.order.common.pojo.order.request.RequestHeader requestHeaderParam_,   com.vip.order.biz.request.GetSimpleOrderFlowFlagReq getSimpleOrderFlowFlagParam_ );
		
		com.vip.order.biz.response.GetUnpayOrderResp getUnpayOrderList( com.vip.order.common.pojo.order.request.RequestHeader requestHeaderParam_,   com.vip.order.biz.request.GetUnpayOrderReq getUnpayOrderParam_ );
		
		com.vip.order.biz.response.GetUserDeliveryAddressResp getUserDeliveryAddress( com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,   com.vip.order.biz.request.GetUserDeliveryAddressReq getUserDeliveryAddressReq_,   com.vip.order.common.pojo.order.request.ResultFilter resultFilter_ );
		
		com.vip.order.biz.response.GetUserFirstOrderResp getUserFirstOrder( com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,   com.vip.order.biz.request.GetUserFirstOrderReq getUserFirstOrderReq_ );
		
		com.vip.hermes.core.health.CheckResult healthCheck();
		
		com.vip.order.biz.response.MergeOrderResp mergeOrder( com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,   com.vip.order.biz.request.MergeOrderReq reqParam_ );
		
		com.vip.order.biz.response.ModifyOrderConsigneeResp modifyOrderConsignee( com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,   com.vip.order.biz.request.ModifyOrderConsigneeReq modifyOrderConsigneeReq_ );
		
		com.vip.order.biz.response.ModifyOrderElectronicInvoiceResp modifyOrderElectronicInvoice( com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,   com.vip.order.biz.request.ModifyOrderElectronicInvoiceReq modifyOrderElectronicInvoiceReq_ );
		
		com.vip.order.biz.response.ModifyOrderGoodsResp modifyOrderGoods( com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,   com.vip.order.biz.request.ModifyOrderGoodsReq orderGoodsReq_ );
		
		com.vip.order.biz.request.ModifyOrderPayTypeRsp modifyOrderPayType( com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,   com.vip.order.common.pojo.order.vo.ModifyPayTypeReq ModifyPayTypeReq_ );
		
		com.vip.order.biz.response.ModifyOrderQualifiedResp modifyOrderQualified( com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,   com.vip.order.biz.param.ModifyOrderQualifiedReq req_ );
		
		com.vip.order.biz.response.ModifyOrderShippedResp modifyOrderShipped( com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,   com.vip.order.biz.request.ModifyOrderShippedReq modifyOrderShippedReq_ );
		
		com.vip.order.biz.request.ModifyOrderPayTypeRsp modifyPrepayOrderPayType( com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,   com.vip.order.biz.request.ModifyPrepayOrderPayTypeReq modifyPrepayOrderPayTypeReq_ );
		
		com.vip.order.biz.response.NotifyCustomsDeclarationFailedResp notifyCustomsDeclarationFailed( com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,   com.vip.order.biz.request.NotifyCustomsDeclarationFailedReq req_ );
		
		com.vip.order.biz.response.OfcEntranceGrayControlResp ofcEntranceGrayControl( com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,   com.vip.order.biz.request.OfcEntranceGrayControlReq req_ );
		
		com.vip.order.biz.response.PaymentReceivedResp paymentReceived( com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,   com.vip.order.biz.request.PaymentReceivedReq req_ );
		
		com.vip.order.biz.response.PostOrderVMSMessageResp postOrderVMSMessage( com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,   com.vip.order.biz.request.PostOrderVMSMessageReq postOrderVMSMessageReq_ );
		
		com.vip.order.biz.response.PutIntoSplitQueueResp putIntoSplitQueue( com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,   com.vip.order.biz.request.PutIntoSplitQueueReq putIntoSplitQueueReq_ );
		
		com.vip.order.biz.response.PutKeyToRollbackQueueResp putKeyToRollbackQueue( com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,   com.vip.order.biz.request.PutKeyToRollbackQueueReq req_ );
		
		com.vip.order.biz.response.PutOrderToRollbackQueueResp putOrderToRollbackQueue( com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,   com.vip.order.biz.request.PutOrderToRollbackQueueReq req_ );
		
		com.vip.order.biz.response.ReceptionConfirmDeliveredResp receptionConfirmDelivered( com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,   com.vip.order.biz.request.ReceptionConfirmDeliveredReq req_ );
		
		com.vip.order.biz.response.OrderRefundResp refundOrder( com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,   com.vip.order.biz.request.OrderRefundReq orderRefundReq_ );
		
		com.vip.order.biz.response.ReleaseStockResp releaseStock( com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,   com.vip.order.biz.request.ReleaseStockReq releaseStockReq_ );
		
		com.vip.order.biz.response.RollbackOrderResp rollbackOrder( com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,   com.vip.order.biz.request.RollbackOrderReq rollbackOrderReq_ );
		
		com.vip.order.biz.response.SearchOrderListByUserIdResp searchOrderListByUserId( com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,   com.vip.order.biz.request.SearchOrderListByUserIdReq getOrderHistoryReq_,   com.vip.order.common.pojo.order.request.ResultFilter resultFilter_ );
		
		com.vip.order.biz.response.SignOrderResp signOrder( com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,   com.vip.order.biz.request.SignOrderReq signOrderReq_ );
		
		com.vip.order.biz.response.GroupByOrderAuditResp triggerGroupByAuditOrder( com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,   com.vip.order.biz.request.GroupByOrderAuditReq groupByOrderAuditReq_ );
		
		com.vip.order.biz.response.UpdateAutoPayAuthResp updateAutoPayAuth( com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,   com.vip.order.biz.request.UpdateAutoPayAuthReq req_ );
		
		com.vip.order.biz.response.UpdateOrderPayResultResp updateOrderPayResult( com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,   com.vip.order.biz.request.UpdateOrderPayResultReq updateOrderPayResultReq_ );
		
		com.vip.order.biz.response.UpdateOrderToReturnVerifiedResp updateOrderToReturnVerified( com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,   com.vip.order.biz.request.UpdateOrderToReturnVerifiedReq updateOrderToReturnVerifiedReq_ );
		
		com.vip.order.biz.response.UpdatePayTypeToCODResp updatePayTypeToCOD( com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,   com.vip.order.biz.request.UpdatePayTypeToCODReq updatePayTypeToCODReq_ );
		
		com.vip.order.biz.response.UpdatePrePayToVerifiedResp updatePrePayToVerified( com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,   com.vip.order.biz.request.UpdatePrePayToVerifiedReq updatePrePayToVerifiedReq_ );
		
		com.vip.order.biz.response.UpdateReservationStateResp updateReservationState( com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,   com.vip.order.biz.request.UpdateReservationStateReq req_ );
		
		com.vip.order.biz.response.UserDeleteOrderResp userDeleteOrder( com.vip.order.common.pojo.order.request.RequestHeader header_,   com.vip.order.biz.request.UserDeleteOrderReq req_ );
		
		com.vip.order.biz.response.VerifyStockAndGetPayableFlagResp verifyStockAndGetPayableFlag( com.vip.order.common.pojo.order.request.RequestHeader requestHeader_,   com.vip.order.biz.request.VerifyStockAndGetPayableFlagReq req_ );
		
	}
	
}