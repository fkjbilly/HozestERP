using System;
using System.Collections.Generic;

namespace vipapis.puma{
	
	
	public interface ChannelPumaService {
		
		
		vipapis.puma.ProductQueryResponse getPumaProducts( vipapis.puma.ProductQueryRequest request_ );
		
		com.vip.hermes.core.health.CheckResult healthCheck();
		
	}
	
}