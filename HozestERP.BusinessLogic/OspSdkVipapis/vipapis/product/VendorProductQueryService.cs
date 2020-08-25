using System;
using System.Collections.Generic;

namespace vipapis.product{
	
	
	public interface VendorProductQueryService {
		
		
		com.vip.hermes.core.health.CheckResult healthCheck();
		
		List<vipapis.product.SpuWithSkusBaseInfo> queryByBarcode( int vendor_id_,   string barcode_,   int? source_ );
		
		List<vipapis.product.SpuWithSkusBaseInfo> queryByBrandAndSn( int vendor_id_,   int brand_id_,   string sn_,   int? source_ );
		
	}
	
}