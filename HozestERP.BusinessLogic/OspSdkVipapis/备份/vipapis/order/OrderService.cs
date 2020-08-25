using System;
using System.Collections.Generic;

namespace vipapis.order{
	
	
	public interface OrderService {
		
		
		List<vipapis.order.ChannelOrderResult> getChannelOrderList( string channel_id_,   List<long?> order_sn_ );
		
		vipapis.order.OrderInfo getOrderInfo( long order_sn_,   string login_account_ );
		
		vipapis.order.OrderTrack getOrderTrackInfo( List<long?> order_sn_,   string transport_sn_ );
		
		List<vipapis.order.Order> getOrders( string start_date_,   string end_date_,   vipapis.order.OrderDateType? date_type_,   vipapis.common.OrderStatus? order_status_,   int? page_,   int? limit_ );
		
		com.vip.hermes.core.health.CheckResult healthCheck();
		
	}
	
}