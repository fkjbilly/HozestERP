using System;
using System.Collections.Generic;

namespace vipapis.marketplace.inventory{
	
	
	public interface InventoryService {
		
		
		vipapis.marketplace.inventory.GetSkuStockResponse getSkuStock( vipapis.marketplace.inventory.GetSkuStockRequest getSkuStockRequest_ );
		
		com.vip.hermes.core.health.CheckResult healthCheck();
		
		vipapis.marketplace.inventory.UpdateSkuStockResponse updateSkuStock( vipapis.marketplace.inventory.UpdateSkuStockRequest updateSkuStockRequest_ );
		
	}
	
}