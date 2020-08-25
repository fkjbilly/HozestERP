using System;
using System.Collections.Generic;

namespace vipapis.stock{
	
	
	public interface StockService {
		
		
		List<vipapis.stock.AddWarehouseInfoResult> addWarehouseInfo( int vendor_id_,   List<vipapis.stock.AddWarehouseInfo> add_warehouse_list_ );
		
		vipapis.stock.ConfirmFrozenInventoryResponse confirmFrozenInventory( int vendor_id_,   int frozen_trans_id_,   int inventory_type_,   List<vipapis.stock.ConfirmFrozenInventory> confirm_frozen_inventory_list_ );
		
		bool? confirmUnfrozenInventory( int vendor_id_,   List<int?> frozen_trans_ids_ );
		
		List<vipapis.stock.DelResult> delWarehouseInfo( int vendor_id_,   List<vipapis.stock.InputWarehouseInfo> vendor_warehouse_id_list_ );
		
		List<vipapis.stock.FreezeTransIdAndInventoryType> getFreezeStockTransId( int vendor_id_,   int frozeType_ );
		
		vipapis.stock.GetFrozenStockDetailsResponse getFreezingStockDetails( int vendor_id_,   int frozen_trans_id_,   int? page_,   int? limit_ );
		
		vipapis.stock.GetOxoShopOrderForJitResponse getOxoShopOrderForJit( int vendor_id_,   vipapis.common.Warehouse? warehouse_,   string vendor_warehouse_id_,   string start_date_,   string end_date_,   int? page_,   int? limit_ );
		
		vipapis.stock.GetOxoShopOrderForPopResponse getOxoShopOrderForPop( int vendor_id_,   vipapis.common.Warehouse? warehouse_,   string vendor_warehouse_id_,   string start_date_,   string end_date_,   int? page_,   int? limit_ );
		
		vipapis.stock.PoNoFrozenTransIdRelationShip getPoNoFrozenTransIdRelationship( int vendor_id_,   int? frozen_trans_id_,   string po_no_ );
		
		List<vipapis.stock.GetVendorScheduleFreezeStockResult> getVendorScheduleFreezeStock( int vendor_id_,   vipapis.stock.GetVendorScheduleFreezeStock get_vendor_schedule_freeze_stock_ );
		
		vipapis.stock.GetWarehouseInfoResponse getWarehouseInfo( int vendor_id_,   string vendor_warehouse_id_,   vipapis.common.Warehouse? vip_warehouse_code_ );
		
		com.vip.hermes.core.health.CheckResult healthCheck();
		
		string updateVendorWarehouseAndVIPWarehouseMap( int vendor_id_,   List<vipapis.stock.updateVendorWarehouseAndVIPWarehouseMap> update_warehousemap_list_ );
		
		List<vipapis.stock.UpdateWarehouseInfoResult> updateWarehouseInfo( int vendor_id_,   List<vipapis.stock.UpdateWarehouseInfo> update_warehouse_list_ );
		
		vipapis.stock.UpdateWarehouseInventoryResponse updateWarehouseInventory( int vendor_id_,   List<vipapis.stock.UpdateWarehouseInventory> update_warehouse_inventory_list_ );
		
	}
	
}