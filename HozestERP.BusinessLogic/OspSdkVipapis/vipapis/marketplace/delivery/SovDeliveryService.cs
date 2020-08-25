using System;
using System.Collections.Generic;

namespace vipapis.marketplace.delivery{
	
	
	public interface SovDeliveryService {
		
		
		vipapis.marketplace.delivery.EditedShipInfoResponse editShipInfo( vipapis.marketplace.delivery.EditedShipInfo edited_ship_info_ );
		
		vipapis.marketplace.delivery.ExportOrderByIdResponse exportOrderById( vipapis.marketplace.delivery.ExportOrderByIdRequest request_ );
		
		List<vipapis.marketplace.delivery.Carrier> getCarriers();
		
		List<vipapis.marketplace.delivery.OrderDetail> getOrderDetail( List<string> order_ids_ );
		
		vipapis.marketplace.delivery.GetOrderStatusByIdResponse getOrderStatusById( vipapis.marketplace.delivery.GetOrderStatusByIdRequest request_ );
		
		vipapis.marketplace.delivery.GetOrdersResponse getOrders( vipapis.marketplace.delivery.GetOrdersRequest request_ );
		
		vipapis.marketplace.delivery.GetPrintTemplateResponse getPrintTemplate( string order_id_ );
		
		com.vip.hermes.core.health.CheckResult healthCheck();
		
		vipapis.marketplace.delivery.ShipResponse ship( vipapis.marketplace.delivery.ShipRequest request_ );
		
	}
	
}