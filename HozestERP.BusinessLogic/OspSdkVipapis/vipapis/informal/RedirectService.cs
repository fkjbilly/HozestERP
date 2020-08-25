using System;
using System.Collections.Generic;

namespace vipapis.informal{
	
	
	public interface RedirectService {
		
		
		string doRedirect( string url_,   Dictionary<string, string> getValues_,   Dictionary<string, string> postValues_ );
		
		com.vip.hermes.core.health.CheckResult healthCheck();
		
	}
	
}