using System;
using System.Collections.Generic;

namespace vipapis.marketplace.category{
	
	
	public interface CategoryService {
		
		
		vipapis.marketplace.category.GetStoreCategoriesResponse getStoreCategories();
		
		com.vip.hermes.core.health.CheckResult healthCheck();
		
	}
	
}