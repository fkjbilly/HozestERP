using System;
using System.Collections.Generic;

namespace vipapis.vreturn{
	
	
	public interface VendorReturnService {
		
		
		vipapis.vreturn.GetReturnDetailResponse getReturnDetail( int vendor_id_,   vipapis.common.Warehouse? warehouse_,   string return_sn_,   string out_time_start_,   string out_time_end_,   int? page_,   int? limit_ );
		
		vipapis.vreturn.GetReturnInfoResponse getReturnInfo( int vendor_id_,   vipapis.common.Warehouse? warehouse_,   string return_sn_,   string st_create_time_,   string ed_create_time_,   int? page_,   int? limit_ );
		
		com.vip.hermes.core.health.CheckResult healthCheck();
		
	}
	
}