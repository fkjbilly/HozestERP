using System;
using System.Collections.Generic;

namespace vipapis.report{
	
	
	public interface ReportService {
		
		
		List<vipapis.report.CountOfServiceInvoke> getCountOfServiceInvoke( string invoke_date_ );
		
		com.vip.hermes.core.health.CheckResult healthCheck();
		
	}
	
}