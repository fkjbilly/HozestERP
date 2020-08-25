using System;
using System.Collections.Generic;

namespace vipapis.stock{
	
	
	public interface StockService {
		
		
		List<vipapis.stock.AddWarehouseInfoResult> addWarehouseInfo( int vendor_id_,   List<vipapis.stock.AddWarehouseInfo> add_warehouse_list_ );
		
		List<vipapis.stock.DelResult> delWarehouseInfo( int vendor_id_,   List<vipapis.stock.InputWarehouseInfo> vendor_warehouse_id_list_ );
		
		vipapis.stock.GetOxoShopOrderForJitResponse getOxoShopOrderForJit( int vendor_id_,   vipapis.common.Warehouse? warehouse_,   string vendor_warehouse_id_,   string start_date_,   string end_date_,   int? page_,   int? limit_ );
		
		vipapis.stock.GetOxoShopOrderForPopResponse getOxoShopOrderForPop( int vendor_id_,   vipapis.common.Warehouse? warehouse_,   string vendor_warehouse_id_,   string start_date_,   string end_date_,   int? page_,   int? limit_ );
		
		List<vipapis.stock.GetVendorScheduleFreezeStockResult> getVendorScheduleFreezeStock( int vendor_id_,   vipapis.stock.GetVendorScheduleFreezeStock get_vendor_schedule_freeze_stock_ );
		
		vipapis.stock.GetWarehouseInfoResponse getWarehouseInfo( int vendor_id_,   string vendor_warehouse_id_,   vipapis.common.Warehouse? vip_warehouse_code_ );
		
		com.vip.hermes.core.health.CheckResult healthCheck();
		
		string updateVendorWarehouseAndVIPWarehouseMap( int vendor_id_,   List<vipapis.stock.updateVendorWarehouseAndVIPWarehouseMap> update_warehousemap_list_ );
		
		List<vipapis.stock.UpdateWarehouseInfoResult> updateWarehouseInfo( int vendor_id_,   List<vipapis.stock.UpdateWarehouseInfo> update_warehouse_list_ );
		
		List<vipapis.stock.UpdateWarehouseResponse> updateWarehouseInventory( int vendor_id_,   List<vipapis.stock.UpdateWarehouseInventory> data_ );
		
	}
	
}