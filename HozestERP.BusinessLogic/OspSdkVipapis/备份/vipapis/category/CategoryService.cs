using System;
using System.Collections.Generic;

namespace vipapis.category{
	
	
	public interface CategoryService {
		
		
		List<vipapis.category.Attribute> getCategoryAttributeListById( int category_id_ );
		
		vipapis.category.Category getCategoryById( int category_id_ );
		
		List<vipapis.category.Category> getCategoryListByName( string category_name_,   int limit_ );
		
		vipapis.category.Category getCategoryTreeById( int category_id_ );
		
		vipapis.category.CategoryUpdates getUpdatedCategoryList( long since_updatetime_,   int hierarchyId_ );
		
		com.vip.hermes.core.health.CheckResult healthCheck();
		
	}
	
}