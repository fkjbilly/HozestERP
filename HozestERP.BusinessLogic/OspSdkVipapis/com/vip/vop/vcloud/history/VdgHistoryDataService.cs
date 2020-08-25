using System;
using System.Collections.Generic;

namespace com.vip.vop.vcloud.history{
	
	
	public interface VdgHistoryDataService {
		
		
		com.vip.hermes.core.health.CheckResult healthCheck();
		
		void pullHistoryOrders( long channelId_,   long partnerId_,   string orderSn_,   System.DateTime? beginTime_,   long maxId_ );
		
		void synHistoricProductAndPrice( string bucket_,   string key_ );
		
	}
	
}