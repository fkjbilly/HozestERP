using System;
using System.Collections.Generic;

namespace vipapis.inventory{
	
	
	public interface WopInventoryQueryService {
		
		
		com.vip.domain.inventory.GetChannelInventoryResponse getChannelInventory( string vendor_id_,   int? page_index_,   int? page_count_,   com.vip.domain.inventory.ChannelInventoryQueryCondition queryCondition_ );
		
		com.vip.domain.inventory.GetInboundResponse getInbound( string vendor_id_,   int? page_index_,   int? page_count_,   com.vip.domain.inventory.InboundCondition queryCondition_ );
		
		com.vip.domain.inventory.PurchaseSalesInventoryResponse getPurchaseSalesInventory( string vendor_id_,   int? page_index_,   int? page_count_,   com.vip.domain.inventory.PurchaseSalesInventoryCondition queryCondition_ );
		
		com.vip.domain.inventory.GetRealtimeInventoryResponse getRealtimeInventory( string vendor_id_,   int? page_index_,   int? page_count_,   com.vip.domain.inventory.RealtimeInventoryCondition queryCondition_ );
		
		com.vip.hermes.core.health.CheckResult healthCheck();
		
	}
	
}