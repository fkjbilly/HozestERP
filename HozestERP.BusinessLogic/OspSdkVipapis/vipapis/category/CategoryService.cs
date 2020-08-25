using System;
using System.Collections.Generic;

namespace vipapis.category{
	
	
	public interface CategoryService {
		
		
		List<vipapis.category.Attribute> getAttributes( int category_id_,   string attr_text_ );
		
		List<vipapis.category.Attribute> getCategoryAttributeListById( int category_id_,   bool? is_include_children_ );
		
		vipapis.category.Category getCategoryById( int category_id_ );
		
		List<vipapis.category.Category> getCategoryListByName( string category_name_,   int limit_,   bool? only_leaf_ );
		
		List<vipapis.category.Category> getCategoryTreeById( int category_id_ );
		
		vipapis.category.CategoryUpdates getUpdatedCategoryList( long since_updatetime_,   int hierarchyId_ );
		
		com.vip.hermes.core.health.CheckResult healthCheck();
		
		int? uploadVendorCategory( int vendor_id_,   string vendor_category_tree_name_,   List<vipapis.category.VendorCategory> vendor_categories_ );
		
	}
	
}