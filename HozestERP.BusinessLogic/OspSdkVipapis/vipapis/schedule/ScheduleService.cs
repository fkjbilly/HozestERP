using System;
using System.Collections.Generic;

namespace vipapis.schedule{
	
	
	public interface ScheduleService {
		
		
		vipapis.schedule.GetScheduleListResponse getSchedules( vipapis.common.Warehouse? warehouse_,   string start_date_,   string end_date_,   string schedule_id_,   string channel_id_,   int? page_,   int? limit_ );
		
		com.vip.hermes.core.health.CheckResult healthCheck();
		
	}
	
}