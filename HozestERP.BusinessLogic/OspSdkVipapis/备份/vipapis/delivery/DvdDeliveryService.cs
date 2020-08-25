using System;
using System.Collections.Generic;

namespace vipapis.delivery{
	
	
	public interface DvdDeliveryService {
		
		
		vipapis.delivery.ShipResult editShipInfo( int vendor_id_,   List<vipapis.delivery.Ship> ship_list_ );
		
		vipapis.delivery.ExportOrderByIdResponse exportOrderById( int vendor_id_,   string order_id_ );
		
		vipapis.delivery.GetCarrierListResponse getCarrierList( string vendor_id_,   int? page_,   int? limit_ );
		
		vipapis.delivery.GetOrderDetailResponse getOrderDetail( int vendor_id_,   string order_id_,   int? page_,   int? limit_ );
		
		vipapis.delivery.GetOrderListResponse getOrderList( string st_add_time_,   string et_add_time_,   vipapis.common.OrderStatus? order_status_,   string po_no_,   string order_id_,   string vendor_id_,   int? page_,   int? limit_ );
		
		vipapis.delivery.GetOrderListByCreateTimeResponse getOrderListByCreateTime( string st_create_time_,   string et_create_time_,   vipapis.common.OrderStatus? order_status_,   string po_no_,   string order_id_,   string vendor_id_,   int? page_,   int? limit_ );
		
		List<vipapis.delivery.DvdOrderStatus> getOrderStatusById( int vendor_id_,   string order_id_ );
		
		vipapis.delivery.PrintTemplateResponse getPrintTemplate( int vendor_id_,   string print_type_,   string order_id_ );
		
		vipapis.delivery.GetReturnListResponse getReturnList( int vendor_id_,   string st_create_time_,   string et_create_time_,   int? return_status_,   int? page_,   int? limit_ );
		
		vipapis.delivery.GetReturnProductResponse getReturnProduct( int vendor_id_,   string back_sn_,   int? page_,   int? limit_ );
		
		com.vip.hermes.core.health.CheckResult healthCheck();
		
		bool? mergeAfterSaleAddress( string vendor_id_,   string username_,   string address_,   string postcode_,   string tel_ );
		
		vipapis.delivery.RefuseOrReturnProductResponse refuseOrder( string vendor_id_,   List<vipapis.delivery.RefuseOrReturnOrder> refuse_product_list_ );
		
		vipapis.delivery.RefuseOrReturnProductResponse returnOrder( string vendor_id_,   List<vipapis.delivery.RefuseOrReturnOrder> dvd_return_list_ );
		
		vipapis.delivery.ShipResult ship( int vendor_id_,   List<vipapis.delivery.Ship> ship_list_ );
		
	}
	
}