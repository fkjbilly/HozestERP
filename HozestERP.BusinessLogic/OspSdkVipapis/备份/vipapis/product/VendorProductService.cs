using System;
using System.Collections.Generic;

namespace vipapis.product{
	
	
	public interface VendorProductService {
		
		
		vipapis.product.VendorProductResponse createProduct( List<vipapis.product.CreateProductItem> vendor_products_ );
		
		vipapis.product.DeleteVSpuSizeTableRelationResponse deleteVendorProductSizeTableRelationship( int vendor_id_,   int brand_id_,   string sn_ );
		
		vipapis.product.VendorProductResponse editProduct( List<vipapis.product.EditProductItem> vendor_products_ );
		
		Dictionary<long?, vipapis.product.UploadTaskExecutionResult> getVendorImageRelationshipTaskStatus( List<long?> task_id_list_ );
		
		com.vip.hermes.core.health.CheckResult healthCheck();
		
		vipapis.product.MultiGetProductSkuResponse multiGetProductSkuInfo( int vendor_id_,   string barcode_,   int? brand_id_,   int? category_id_,   string sn_,   int? page_,   int? limit_ );
		
		vipapis.product.MultiGetProductSpuResponse multiGetProductSpuInfo( int vendor_id_,   int? brand_id_,   int? category_id_,   string sn_,   vipapis.product.ProductStatus? status_,   int? page_,   int? limit_ );
		
		vipapis.product.SaveVSpuSizeTableRelationResponse saveVendorProductSizeTableRelationship( int vendor_id_,   int brand_id_,   string sn_,   long size_table_id_,   Dictionary<string, long?> sku_size_detail_id_mappings_ );
		
		List<vipapis.product.VendorProductSubmitResult> submitProducts( int vendor_id_,   List<vipapis.product.VendorProductSN> vendor_productSN_list_ );
		
		vipapis.product.ImageUploadResult uploadVendorProductImage( int vendor_id_,   int brand_id_,   string sn_,   Dictionary<int?, string> product_image_map_ );
		
	}
	
}