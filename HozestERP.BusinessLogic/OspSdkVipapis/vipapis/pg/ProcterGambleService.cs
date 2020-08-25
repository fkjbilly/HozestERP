using System;
using System.Collections.Generic;

namespace vipapis.pg{
	
	
	public interface ProcterGambleService {
		
		
		vipapis.pg.GetProductListResponse getGoods( vipapis.pg.GetProductListRequest request_ );
		
		vipapis.pg.GetProductInventoryListResponse getGoodsStock( vipapis.pg.GetProductInventoryListRequest request_ );
		
		vipapis.pg.GetOrderListResponse getOrders( vipapis.pg.GetOrderListRequest request_ );
		
		com.vip.hermes.core.health.CheckResult healthCheck();
		
	}
	
}