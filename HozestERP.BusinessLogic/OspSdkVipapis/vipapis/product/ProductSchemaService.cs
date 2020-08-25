using System;
using System.Collections.Generic;

namespace vipapis.product{
	
	
	public interface ProductSchemaService {
		
		
		List<com.vip.isv.schema.ProductResponse> createProductBySchema( com.vip.isv.schema.CreateProductBySchemaRequest createProductSchemaRequest_ );
		
		string getProductSchema( com.vip.isv.schema.GetProductSchemaRequest getProductSchemaRequest_ );
		
		com.vip.hermes.core.health.CheckResult healthCheck();
		
		com.vip.isv.schema.ProductResponse updateProductBySchema( com.vip.isv.schema.UpdateProductBySchemaRequest updateProductSchemaRequest_ );
		
	}
	
}