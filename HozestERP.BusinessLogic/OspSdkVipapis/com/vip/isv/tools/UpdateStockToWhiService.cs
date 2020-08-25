using System;
using System.Collections.Generic;

namespace com.vip.isv.tools{
	
	
	public interface UpdateStockToWhiService {
		
		
		com.vip.hermes.core.health.CheckResult healthCheck();
		
		List<com.vip.isv.tools.UpdateStockToWhiResponse> updateStockToWhi( List<com.vip.isv.tools.UpdateStockToWhiRequest> requests_ );
		
	}
	
}