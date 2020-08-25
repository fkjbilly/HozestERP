using System;
using System.Collections.Generic;

namespace com.vip.vop.omni.logistics{
	
	
	public interface OmniLogisticsService {
		
		
		com.vip.vop.omni.logistics.LogisticsTrackResponse getOrderLogisticsTrack( com.vip.vop.omni.logistics.LogisticsTrackRequest trackRequest_ );
		
		com.vip.hermes.core.health.CheckResult healthCheck();
		
		void receiveRouteInfo( com.vip.vop.omni.logistics.WaybillRoute waybillRoute_ );
		
	}
	
}