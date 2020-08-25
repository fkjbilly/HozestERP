using System;
using System.Collections.Generic;

namespace vipapis.product{
	
	
	public interface ImprovedVendorProductService {
		
		
		vipapis.product.CreateBaseProductResponse createBaseProducts( int vendor_id_,   List<vipapis.product.CreateBaseProductItem> vendor_products_ );
		
		vipapis.product.ImprovedVendorProductResponse createProductWithProdInfoMapping( int vendor_id_,   int vendor_category_tree_id_,   List<vipapis.product.CreateVendorProductItem> vendor_products_ );
		
		vipapis.product.ImprovedVendorProductResponse editProductWithProdInfoMapping( int vendor_id_,   int vendor_category_tree_id_,   List<vipapis.product.EditVendorProductItem> vendor_products_ );
		
		com.vip.hermes.core.health.CheckResult healthCheck();
		
		int? uploadVendorCategory( int vendor_id_,   string vendor_category_tree_name_,   List<vipapis.product.VendorCategory> vendor_categories_ );
		
		Dictionary<int?, vipapis.product.UploadImageResult> uploadVendorFullScaleProductImage( int vendor_id_,   int brand_id_,   string sn_,   Dictionary<int?, vipapis.product.UploadImageInfo> product_image_map_ );
		
	}
	
}