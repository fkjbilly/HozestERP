using System;
using System.Collections.Generic;

namespace vipapis.brand{
	
	
	public interface BrandService {
		
		
		vipapis.brand.BrandInfo getBrandInfo( string brand_id_ );
		
		List<vipapis.brand.BrandStory> getBrandStories( List<int?> brand_ids_ );
		
		List<vipapis.brand.VendorBrandRelationShip> getVendorBrandRelationshipByVendorId( int vendor_id_ );
		
		com.vip.hermes.core.health.CheckResult healthCheck();
		
		vipapis.brand.MultiGetBrandResponse multiGetBrand( vipapis.brand.BrandSearchType? search_type_,   string word_,   int? page_,   int? limit_ );
		
	}
	
}