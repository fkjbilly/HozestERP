using System;
using System.Collections.Generic;

namespace vipapis.order{
	
	
	public interface WopOrderService {
		
		
		com.vip.domain.order.RequestResult createCancelCustomerBackOrder( string vendor_id_,   List<com.vip.domain.order.CreateCancelCustomerBackOrderInfo> orderList_ );
		
		com.vip.domain.order.RequestResult createCancelOrder( string vendor_id_,   List<com.vip.domain.order.CancelOrderInfo> cancelOrderList_ );
		
		com.vip.domain.order.RequestResult createCustomerBackOrder( string vendor_id_,   List<com.vip.domain.order.CustomerBackOrderInfo> orderList_ );
		
		com.vip.domain.order.RequestResult createOrder( string vendor_id_,   List<com.vip.domain.order.OrderInfo> orderList_ );
		
		List<com.vip.domain.order.CustomerBackOrderStatusInfo> geCustomerBackOrderStatus( string vendor_id_,   com.vip.domain.order.ResultQueryCondition condition_ );
		
		List<com.vip.domain.order.CancelOrderResult> getCancelOrderResult( string vendor_id_,   com.vip.domain.order.ResultQueryCondition condition_ );
		
		List<com.vip.domain.order.CreateCancelCustomerBackOrderResult> getCreateCancelCustomerBackOrderResult( string vendor_id_,   com.vip.domain.order.ResultQueryCondition condition_ );
		
		List<com.vip.domain.order.CreateCustomerBackOrderResult> getCreateCustomerBackOrderResult( string vendor_id_,   com.vip.domain.order.ResultQueryCondition condition_ );
		
		List<com.vip.domain.order.CreateOrderResult> getCreateOrderResult( string vendor_id_,   com.vip.domain.order.ResultQueryCondition condition_ );
		
		com.vip.domain.order.CustomerBackOrderDetailInfo getCustomerBackOrderDetailInfo( string vendor_id_,   com.vip.domain.order.CustomerBackOrderInfoQueryCondition condition_ );
		
		List<com.vip.domain.order.CustomerBackOrderTrackInfo> getCustomerBackOrderTrack( string vendor_id_,   com.vip.domain.order.CustomerBackOrderTrackQueryCondition condition_ );
		
		List<com.vip.domain.order.OrderStatusInfo> getOrderStatus( string vendor_id_,   com.vip.domain.order.ResultQueryCondition condition_ );
		
		List<com.vip.domain.order.OrderTrackInfo> getOrderTrack( string vendor_id_,   com.vip.domain.order.OrderTrackQueryCondition condition_ );
		
		com.vip.hermes.core.health.CheckResult healthCheck();
		
	}
	
}