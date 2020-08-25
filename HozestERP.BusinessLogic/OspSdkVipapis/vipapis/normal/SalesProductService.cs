using System;
using System.Collections.Generic;

namespace vipapis.normal{
	
	
	public interface SalesProductService {
		
		
		com.vip.hermes.core.health.CheckResult healthCheck();
		
		void listingSpu( int vendor_id_,   string cooperation_no_,   string warehouse_supplier_,   string sn_ );
		
		void unlistingSpu( int vendor_id_,   string cooperation_no_,   string warehouse_supplier_,   string sn_ );
		
	}
	
}