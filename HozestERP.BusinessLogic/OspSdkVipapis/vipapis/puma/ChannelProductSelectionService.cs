using System;
using System.Collections.Generic;

namespace vipapis.puma{
	
	
	public interface ChannelProductSelectionService {
		
		
		vipapis.puma.ChannelProductSelection getProductSelection( string product_url_ );
		
		com.vip.hermes.core.health.CheckResult healthCheck();
		
	}
	
}