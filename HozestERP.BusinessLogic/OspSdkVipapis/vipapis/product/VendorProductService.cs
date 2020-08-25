using System;
using System.Collections.Generic;

namespace vipapis.product{
	
	
	public interface VendorProductService {
		
		
		vipapis.product.AppendSkuResponse appendSkus( int vendor_id_,   string sn_,   int brand_id_,   List<vipapis.product.CreateSkuItem> sku_item_list_ );
		
		vipapis.product.SaveVSpuSizeTableRelationResponse autoBindVendorProductSizeTableRelationship( int vendor_id_,   int brand_id_,   string sn_,   int sizetable_tpl_id_ );
		
		void batchBindVendorProductImages( int vendor_id_,   int brand_id_,   string sn_,   Dictionary<int?, string> url_map_,   string group_sn_ );
		
		vipapis.product.BatchUploadAndBindImageResult batchUploadAndBindVendorProductImage( int vendor_id_,   int brand_id_,   string sn_,   Dictionary<int?, string> product_image_map_,   string group_sn_ );
		
		List<vipapis.product.CancelSubmissionResult> cancelProductSubmission( int vendor_id_,   List<vipapis.product.VendorProductSN> snList_ );
		
		vipapis.product.VendorProductResponse createProduct( int vendor_id_,   List<vipapis.product.CreateProductItem> vendor_products_ );
		
		List<vipapis.product.ProductForMultiColorResponse> createProductForMultiColor( int vendor_id_,   List<vipapis.product.CreateSpuItem> spu_item_list_ );
		
		bool? deleteVendorImageRelationship( int vendor_id_,   int brand_id_,   string sn_,   List<int?> img_index_list_,   string group_sn_ );
		
		vipapis.product.DeleteVSpuSizeTableRelationResponse deleteVendorProductSizeTableRelationship( int vendor_id_,   int brand_id_,   string sn_ );
		
		vipapis.product.VendorProductResponse editProduct( int vendor_id_,   List<vipapis.product.EditProductItem> vendor_products_ );
		
		vipapis.product.ProductForMultiColorResponse editProductForMultiColor( int vendor_id_,   string sn_,   int brand_id_,   vipapis.product.EditSpuItem edit_spu_item_list_ );
		
		string getProductPreviewData( int vendor_id_,   int brand_id_,   string sn_,   string group_sn_ );
		
		string getProductPreviewUrl( int vendor_id_,   int brand_id_,   string sn_,   string group_sn_ );
		
		vipapis.product.ProductSkuInfo getRealVendorSkuByBarcode( int vendor_id_,   string barcode_,   int? source_ );
		
		vipapis.product.ProductSpuInfo getSpuBySnVendorIdAndBrandId( string sn_,   int vendor_id_,   int brand_id_,   int? source_ );
		
		Dictionary<long?, vipapis.product.UploadTaskExecutionResult> getVendorImageRelationshipTaskStatus( List<long?> task_id_list_ );
		
		com.vip.hermes.core.health.CheckResult healthCheck();
		
		vipapis.product.MultiGetProductSkuResponse multiGetProductSkuInfo( int vendor_id_,   string barcode_,   int? brand_id_,   int? category_id_,   string sn_,   int? page_,   int? limit_,   int? source_ );
		
		vipapis.product.MultiGetProductSpuResponse multiGetProductSpuInfo( int vendor_id_,   int? brand_id_,   int? category_id_,   string sn_,   vipapis.product.ProductStatus? status_,   int? page_,   int? limit_,   int? source_ );
		
		vipapis.product.SaveVSpuSizeTableRelationResponse saveVendorProductSizeTableRelationship( int vendor_id_,   int brand_id_,   string sn_,   long size_table_id_,   Dictionary<string, long?> sku_size_detail_id_mappings_ );
		
		List<vipapis.product.VendorProductSubmitResult> submitProducts( int vendor_id_,   List<vipapis.product.VendorProductSN> vendor_productSN_list_ );
		
		vipapis.product.UploadAndBindImageResult uploadAndBindVendorProductImage( int vendor_id_,   int brand_id_,   string sn_,   int img_index_,   string img_content_,   string group_sn_ );
		
		vipapis.product.ImageInfo uploadImage( int vendor_id_,   string file_name_,   string is_override_,   string img_content_ );
		
		vipapis.product.ImageUploadResult uploadVendorProductImage( int vendor_id_,   int brand_id_,   string sn_,   Dictionary<int?, string> product_image_map_,   string group_sn_ );
		
	}
	
}