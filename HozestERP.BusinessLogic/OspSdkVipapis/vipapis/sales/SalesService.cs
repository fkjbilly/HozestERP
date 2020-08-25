using System;
using System.Collections.Generic;

namespace vipapis.sales{
	
	
	public interface SalesService {
		
		
		vipapis.sales.GetEndingSalesSkusResult getEndingSalesSkus( int vendor_id_,   string brand_id_,   long st_query_,   long et_query_,   int page_,   int limit_ );
		
		vipapis.sales.GetSalesListResult getSalesList( int vendor_id_,   long? st_query_,   long? et_query_,   int? page_,   int? limit_ );
		
		vipapis.sales.GetSalesSkuListResult getSalesSkuList( int vendor_id_,   long sales_no_,   int? page_,   int? limit_ );
		
		vipapis.sales.GetUpcomingSalesSkusResult getUpcomingSalesSkus( int vendor_id_,   string brand_id_,   int page_,   int limit_ );
		
		com.vip.hermes.core.health.CheckResult healthCheck();
		
		vipapis.sales.SetSkuInventoryResult updateSalesSkusInventory( int batch_no_,   int vendor_id_,   bool is_full_,   string warehouse_supplier_,   List<vipapis.sales.BarcodeInventory> inventories_ );
		
	}
	
}