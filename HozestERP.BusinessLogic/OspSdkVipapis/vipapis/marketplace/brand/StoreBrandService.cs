using System;
using System.Collections.Generic;

namespace vipapis.marketplace.brand{
	
	
	public interface StoreBrandService {
		
		
		List<vipapis.marketplace.brand.StoreBrand> getStoreBrands();
		
		com.vip.hermes.core.health.CheckResult healthCheck();
		
	}
	
}