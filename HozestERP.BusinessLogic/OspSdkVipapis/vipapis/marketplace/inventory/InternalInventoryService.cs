using System;
using System.Collections.Generic;

namespace vipapis.marketplace.inventory{
	
	
	public interface InternalInventoryService {
		
		
		Dictionary<string, vipapis.marketplace.inventory.UpdateSkuStockResult> batchTotalUpdateSkuInventory( string storeId_,   List<vipapis.marketplace.inventory.ProductSkuStock> skuStocks_ );
		
		com.vip.hermes.core.health.CheckResult healthCheck();
		
		vipapis.marketplace.inventory.UpdateSkuStockResult totalUpdateSkuInventory( vipapis.marketplace.inventory.StoreSkuStock stock_ );
		
	}
	
}