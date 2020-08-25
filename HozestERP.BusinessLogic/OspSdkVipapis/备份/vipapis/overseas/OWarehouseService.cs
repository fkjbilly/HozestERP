using System;
using System.Collections.Generic;

namespace vipapis.overseas{
	
	
	public interface OWarehouseService {
		
		
		List<string> deliverOrderStatus( string warehouse_,   List<vipapis.overseas.OrderStatusItem> order_status_items_ );
		
		List<string> deliverSaleOrder( string warehouse_,   List<vipapis.overseas.SaleOrders> sale_orders_ );
		
		vipapis.overseas.GetPurchaseOrderBatchListResponse getPoBatchList( string warehouse_,   int? start_batch_id_,   int? num_,   string po_no_,   List<string> batch_no_list_,   string vendor_code_,   int? total_ );
		
		com.vip.hermes.core.health.CheckResult healthCheck();
		
		string updatePoBatchStatus( string warehouse_,   List<string> batch_nos_ );
		
	}
	
}