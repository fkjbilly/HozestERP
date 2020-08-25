using System;
using System.Collections.Generic;

namespace vipapis.message{
	
	
	public interface MessageService {
		
		
		com.vip.hermes.core.health.CheckResult healthCheck();
		
		bool? publishMessage( int? vendor_id_,   int? vendor_code_,   string subject_,   string message_content_ );
		
	}
	
}