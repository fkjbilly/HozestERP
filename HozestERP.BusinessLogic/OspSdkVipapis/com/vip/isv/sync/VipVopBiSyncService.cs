using System;
using System.Collections.Generic;

namespace com.vip.isv.sync{
	
	
	public interface VipVopBiSyncService {
		
		
		com.vip.hermes.core.health.CheckResult healthCheck();
		
		void syncReturnDetail();
		
		void syncReturnHeader();
		
		void syncReturnOrder();
		
	}
	
}