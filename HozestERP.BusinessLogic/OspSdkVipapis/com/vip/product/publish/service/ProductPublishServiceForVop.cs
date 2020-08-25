using System;
using System.Collections.Generic;

namespace com.vip.product.publish.service{
	
	
	public interface ProductPublishServiceForVop {
		
		
		List<com.vip.product.publish.service.ShoeReportReturn> batchSaveShoeReport( List<com.vip.product.publish.service.ShoeReportParameter> shoeReports_,   string appId_ );
		
		com.vip.hermes.core.health.CheckResult healthCheck();
		
	}
	
}