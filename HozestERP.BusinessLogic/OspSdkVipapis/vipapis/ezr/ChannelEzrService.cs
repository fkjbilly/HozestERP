using System;
using System.Collections.Generic;

namespace vipapis.ezr{
	
	
	public interface ChannelEzrService {
		
		
		void closePCStore( string phoneNo_,   long vendorCode_ );
		
		void createPCStore( string phoneNo_,   long vendorCode_,   string storeName_ );
		
		com.vip.hermes.core.health.CheckResult healthCheck();
		
	}
	
}