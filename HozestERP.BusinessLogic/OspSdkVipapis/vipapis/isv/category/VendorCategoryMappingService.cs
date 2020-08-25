using System;
using System.Collections.Generic;

namespace vipapis.isv.category{
	
	
	public interface VendorCategoryMappingService {
		
		
		List<com.vip.isv.category.VendorCategoryMappingDo> findMatchedSuccessfullMapping( List<int?> id_ );
		
		List<com.vip.isv.category.MappedCategory> getVendorMappedCategories( int vendor_id_,   string vendor_category_id_,   com.vip.isv.category.MappedCategoryState? state_ );
		
		com.vip.hermes.core.health.CheckResult healthCheck();
		
		int? insertSelective( com.vip.isv.category.VendorCategoryMappingDo record_ );
		
		int? multiUpdateByPrimaryKeySelective( List<com.vip.isv.category.VendorCategoryMappingDo> records_ );
		
		List<com.vip.isv.category.VendorCategoryMappingDo> selectByCondition( com.vip.isv.category.VendorCategoryMappingDo condition_ );
		
		com.vip.isv.category.VendorCategoryMappingDo selectByPrimaryKey( int id_ );
		
		List<com.vip.isv.category.VendorCategoryMappingDo> selectByPrimaryKeys( List<int?> id_ );
		
		int? updateByPrimaryKeySelective( com.vip.isv.category.VendorCategoryMappingDo record_ );
		
	}
	
}