using System;
using System.Collections.Generic;

namespace com.vip.vop.vcloud.product{
	
	
	public interface DieselPriceSynService {
		
		
		com.vip.hermes.core.health.CheckResult healthCheck();
		
		void processPriceItem();
		
		void pushPriceToVdg();
		
	}
	
}