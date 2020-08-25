using System;
using System.Collections.Generic;

namespace vipapis.order{
	
	
	public interface HtVopFetchPackageIService {
		
		
		com.vip.haitao.orderservice.service.HtVopFetchPackageResult getFetchPackageOrderList( com.vip.haitao.orderservice.service.HtVopFetchPackageParam htVopFetchPackageParam_ );
		
		com.vip.hermes.core.health.CheckResult healthCheck();
		
	}
	
}