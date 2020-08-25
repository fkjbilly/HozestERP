using System;
using System.Collections.Generic;

namespace com.vip.eip.osp.vendor{
	
	
	public interface VendorService {
		
		
		com.vip.hermes.core.health.CheckResult healthCheck();
		
		com.vip.eip.osp.vendor.VendorSysResponse invoke( com.vip.eip.osp.vendor.VendorSysRequest req_ );
		
	}
	
}