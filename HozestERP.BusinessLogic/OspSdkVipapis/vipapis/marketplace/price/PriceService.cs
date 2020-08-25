using System;
using System.Collections.Generic;

namespace vipapis.marketplace.price{
	
	
	public interface PriceService {
		
		
		vipapis.marketplace.price.GetSkuPriceResponse getSkuPrice( string sku_id_ );
		
		com.vip.hermes.core.health.CheckResult healthCheck();
		
		vipapis.marketplace.price.UpdateSkuPriceResponse updateSkuPrice( string sku_id_,   double market_price_,   double sale_price_ );
		
	}
	
}