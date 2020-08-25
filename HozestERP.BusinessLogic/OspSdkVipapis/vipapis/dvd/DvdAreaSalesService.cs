using System;
using System.Collections.Generic;

namespace vipapis.dvd{
	
	
	public interface DvdAreaSalesService {
		
		
		vipapis.dvd.AreaOccupiedOrderResponse getAreaOccupiedOrders( vipapis.dvd.AreaOccupiedOrdersRequest request_ );
		
		List<vipapis.dvd.AreaWarehouse> getAreaWarehouse( long vendor_id_ );
		
		com.vip.hermes.core.health.CheckResult healthCheck();
		
	}
	
}