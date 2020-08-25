using System;
using System.Collections.Generic;

namespace vipapis.order{
	
	
	public interface OrderService {
		
		
		List<vipapis.order.ChannelOrderResult> getChannelOrderList( string channel_id_,   List<long?> order_sn_ );
		
		com.vip.hermes.core.health.CheckResult healthCheck();
		
	}
	
}