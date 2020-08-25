using System;
using System.Collections.Generic;

namespace vipapis.product{
	
	
	public interface ChannelProductService {
		
		
		vipapis.product.HtProductListResult getHtProductList( string type_,   int page_ );
		
		com.vip.hermes.core.health.CheckResult healthCheck();
		
	}
	
}