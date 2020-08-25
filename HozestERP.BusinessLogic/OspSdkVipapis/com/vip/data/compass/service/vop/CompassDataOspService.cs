using System;
using System.Collections.Generic;

namespace com.vip.data.compass.service.vop{
	
	
	public interface CompassDataOspService {
		
		
		com.vip.data.compass.service.vop.CompassDataResponse data( Dictionary<string, string> api_params_,   string path_,   string vendor_id_ );
		
		com.vip.hermes.core.health.CheckResult healthCheck();
		
	}
	
}