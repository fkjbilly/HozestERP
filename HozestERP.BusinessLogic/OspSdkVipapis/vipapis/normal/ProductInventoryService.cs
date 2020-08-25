using System;
using System.Collections.Generic;

namespace vipapis.normal{
	
	
	public interface ProductInventoryService {
		
		
		vipapis.normal.ImportInitialQuantityResult getInitialQuantityResult( int vendor_id_,   long apply_id_,   int? page_,   int? limit_ );
		
		vipapis.normal.InventoryDeductOrdersResponse getInventoryDeductOrders( vipapis.normal.InventoryDeductOrdersRequest inventoryDeductOrdersRequest_ );
		
		vipapis.normal.OccupiedOrderResponse getInventoryOccupiedOrders( vipapis.normal.InventoryOccupiedOrdersRequest inventoryOccupiedOrdersRequest_ );
		
		vipapis.normal.InventoryUpdateResultResponse getInventoryUpdateResult( vipapis.normal.InventoryUpdateResultRequest inventoryUpdateResultRequest_ );
		
		vipapis.normal.ScheduleProductResponse getScheduleProductList( vipapis.normal.ScheduleProductRequest scheduleProductRequest_ );
		
		com.vip.hermes.core.health.CheckResult healthCheck();
		
		string importInitialInventory( vipapis.normal.Cooperation cooperation_,   List<vipapis.normal.Initialnventory> inventorys_ );
		
		void pullUpdateInventoryResult( List<vipapis.normal.UpdateInventoryResult> updateInventoryResultList_ );
		
		void updateAvailableInventory( vipapis.normal.AvailableInventoryRequest availableInventoryRequest_ );
		
		void updateSellableInventory( vipapis.normal.SellableUpdateInventoryRequest sellableUpdateInventoryRequest_ );
		
	}
	
}