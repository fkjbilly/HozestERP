using System;
using System.Collections.Generic;

namespace vipapis.orderservice.service{
	
	
	public interface HtSaleOrderVopService {
		
		
		List<com.vip.haitao.orderservice.service.HtSaleOrderResult> findOrderResultByParams( string warehouse_,   string orderSn_,   int? num_ );
		
		List<com.vip.haitao.orderservice.service.HtSaleOrderResultModel> findOrderResultModelByParams( string warehouse_,   string orderSn_,   int? num_ );
		
		com.vip.haitao.orderservice.service.HtSaleOrderCancellationResult getSaleOrderCancellation( string carrierCode_,   string customsCode_,   int? num_ );
		
		com.vip.haitao.orderservice.service.HtCarrierSaleOrderResult getSaleOrderList( string carriercode_,   string orderSn_,   int? num_,   string customsCode_ );
		
		com.vip.haitao.orderservice.service.HtCarrierSaleOrderResult getSaleOrderListByOrderType( string carriercode_,   string orderSn_,   int? num_,   string customsCode_,   string orderType_ );
		
		com.vip.haitao.orderservice.service.HtCarrierSaleOrderResultModel getSaleOrderModelList( string carriercode_,   string orderSn_,   int? num_,   string customsCode_ );
		
		com.vip.haitao.orderservice.service.HtCarrierSaleOrderResultModel getSaleOrderModelListByOrderType( string carriercode_,   string orderSn_,   int? num_,   string customsCode_,   string orderType_ );
		
		com.vip.hermes.core.health.CheckResult healthCheck();
		
		bool? updateCancelOrderStatus( string carriercode_,   com.vip.haitao.orderservice.service.HtSaleOrderCancellationCallbackResult resultList_,   bool isUpdateStatus_ );
		
		com.vip.haitao.orderservice.service.HtSaleTransferBatchNoResult updateSendChbOrderStatusByOrderSn( string carriercode_,   string orderSn_,   string customsCode_ );
		
		com.vip.haitao.orderservice.service.HtSaleTransferBatchNoResult updateSendOrderStatusByOrderSn( string warehouse_,   string orderSn_ );
		
	}
	
}