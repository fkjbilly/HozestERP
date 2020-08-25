using System;
using System.Collections.Generic;

namespace vipapis.inventory{
	
	
	public interface InventoryService {
		
		
		vipapis.inventory.InventoryDeductOrderDetailResponse getDeductOrderDetail( vipapis.inventory.InventoryDeductOrdersRequest inventoryDeductOrdersRequest_ );
		
		vipapis.inventory.CancelledOrdersResponse getInventoryCancelledOrders( vipapis.inventory.InventoryCancelledOrdersRequest inventoryCancelledOrdersRequest_ );
		
		vipapis.inventory.InventoryDeductOrdersResponse getInventoryDeductOrders( vipapis.inventory.InventoryDeductOrdersRequest inventoryDeductOrdersRequest_ );
		
		vipapis.inventory.OccupiedOrderResponse getInventoryOccupiedOrders( vipapis.inventory.InventoryOccupiedOrdersRequest inventoryOccupiedOrdersRequest_ );
		
		vipapis.inventory.GetMpSkuStockResponse getMpSkuStock( vipapis.inventory.GetMpSkuStockRequest getSkuStockRequest_ );
		
		List<vipapis.inventory.SkuInfo> getSkuInfo( vipapis.inventory.GetSkuInfoRequest request_ );
		
		vipapis.inventory.GetScheduleSkuListResult getSkuList( vipapis.inventory.GetScheduleSkuListCriteria criteria_,   int? page_,   int? limit_ );
		
		List<vipapis.inventory.GetSkuInventoryResult> getSkuStock( int vendor_id_,   int? cooperation_no_,   string warehouse_,   string barcode_,   string area_warehouse_id_ );
		
		com.vip.hermes.core.health.CheckResult healthCheck();
		
		void updateInventory( vipapis.inventory.UpdateSkuInventoryRequest request_ );
		
		vipapis.inventory.UpdateMpSkuStockResponse updateMpSkuStock( vipapis.inventory.UpdateMpSkuStockRequest updateSkuStockRequest_ );
		
	}
	
}