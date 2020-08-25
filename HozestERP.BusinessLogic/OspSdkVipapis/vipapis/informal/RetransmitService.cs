using System;
using System.Collections.Generic;

namespace vipapis.informal{
	
	
	public interface RetransmitService {
		
		
		com.vip.hermes.core.health.CheckResult healthCheck();
		
		string retransmit( string routingKey_,   Dictionary<string, string> parameters_,   string body_ );
		
	}
	
}