using System;
using System.Collections.Generic;

namespace vipapis.inventory{
	
	
	public interface VrwInvIncomeOspService {
		
		
		com.vip.hermes.core.health.CheckResult healthCheck();
		
		com.vipshop.cis.sdk.api.datain.si.response.SyncVrwIncrInvResponse syncVrwIncrInv( com.vipshop.cis.sdk.api.datain.si.request.SyncVrwIncrInvRequest request_ );
		
	}
	
}