using System;
using System.Collections.Generic;

namespace vipapis.product{
	
	
	public interface ChannelProductService {
		
		
		vipapis.product.ImageUrl getProductImageUrl( long product_id_,   long vendor_spu_id_ );
		
		List<vipapis.product.ChannelProduct> getProductList( string channel_name_,   string start_date_,   string end_date_ );
		
		vipapis.product.SizeTable getSizeTable( long size_table_id_ );
		
		com.vip.hermes.core.health.CheckResult healthCheck();
		
	}
	
}