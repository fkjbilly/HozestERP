using System;
using System.Collections.Generic;

namespace vipapis.marketplace.product{
	
	
	public interface ProductService {
		
		
		vipapis.marketplace.product.AddProductResponse addProduct( vipapis.marketplace.product.AddProductRequest request_ );
		
		vipapis.marketplace.product.AppendSkusResponse appendSkus( vipapis.marketplace.product.AppendSkusRequest request_ );
		
		vipapis.marketplace.product.AutoBindProductSizeTableResponse autoBindProductSizeTable( vipapis.marketplace.product.AutoBindProductSizeTableRequest autoBindProductSizeTableRequest_ );
		
		void bindProductColorImage( vipapis.marketplace.product.ProductColorImageBindModel bindModel_ );
		
		void bindProductImage( vipapis.marketplace.product.ProductImageBindModel bindModel_ );
		
		vipapis.marketplace.product.EditProductResponse editProduct( vipapis.marketplace.product.EditProductRequest request_ );
		
		vipapis.marketplace.product.ProductDetail getProductById( string spu_id_ );
		
		string getProductPreviewUrl( string spu_id_,   string sku_id_ );
		
		vipapis.marketplace.product.GetProductsResponse getProducts( vipapis.marketplace.product.GetProductRequest request_ );
		
		vipapis.marketplace.product.SkuDetail getSkuById( string sku_id_ );
		
		com.vip.hermes.core.health.CheckResult healthCheck();
		
		vipapis.marketplace.product.OffShelfResponse offShelf( vipapis.marketplace.product.OffShelfProduct offShelfProduct_ );
		
		vipapis.marketplace.product.OnShelfResponse onShelf( vipapis.marketplace.product.OnShelfProduct onShelfProduct_ );
		
		vipapis.marketplace.product.SubmitProductsResponse submitProducts( List<string> spu_ids_ );
		
		void unbindProductImage( vipapis.marketplace.product.UnbindProductImageRequest unbindProductImageRequest_ );
		
		vipapis.marketplace.product.ImageInfo uploadImage( string file_name_,   string is_override_,   string img_content_ );
		
	}
	
}