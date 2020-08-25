using System;
using System.Collections.Generic;

namespace vipapis.order{
	
	
	public interface OmniOrderService {
		
		
		void confirmInvoice( int vendor_id_,   vipapis.order.OrderInvoiceReq order_invoice_ );
		
		vipapis.order.OrderInvoiceConfirmResp confirmOrderInvoice( int vendor_id_,   List<vipapis.order.OrderInvoiceReq> order_invoices_ );
		
		vipapis.order.ConfirmDeliveryResp confirmOxoDelivery( long vendor_id_,   string order_id_,   string store_sn_,   byte? notice_type_,   string package_no_,   long? estimate_delivery_time_ );
		
		void confirmOxoShipment( long vendor_id_,   string order_id_,   string store_sn_,   string carrier_name_,   string carrier_code_,   string transport_no_ );
		
		void confirmStoreDelivery( long vendor_id_,   string order_id_,   string store_sn_,   string package_no_,   long? estimate_delivery_time_ );
		
		List<vipapis.order.OrderDeliveryInfo> getDeliveryInfo( int vendor_id_,   string store_sn_,   List<string> orders_ );
		
		vipapis.order.CancelledOrdersResponse getInventoryCancelledOrders( vipapis.order.InventoryCancelledOrdersRequest inventoryCancelledOrdersRequest_ );
		
		vipapis.order.InventoryDeductOrdersResponse getInventoryDeductOrders( vipapis.order.InventoryDeductOrdersRequest inventoryDeductOrdersRequest_ );
		
		vipapis.order.OccupiedOrderResponse getInventoryOccupiedOrders( vipapis.order.InventoryOccupiedOrdersRequest inventoryOccupiedOrdersRequest_ );
		
		vipapis.order.GetOmniCancelledOrdersResp getOmniCancelledOrders( long vendor_id_,   long? brand_id_,   byte? order_type_,   long st_query_time_,   long et_query_time_,   int? limit_,   int? page_ );
		
		vipapis.order.GetOmniOrdersResp getOmniOrders( long vendor_id_,   long? brand_id_,   byte? business_type_,   long st_query_time_,   long et_query_time_,   int? limit_,   int? page_ );
		
		List<vipapis.order.EInvoiceInfo> getOrderEInvoiceInfo( int vendorId_,   List<string> orders_ );
		
		vipapis.order.OrderInvoiceQueryResp getOrderInvoice( int vendor_id_,   List<string> orders_ );
		
		vipapis.order.OxoOrderResponse getOxoOrders( vipapis.order.OxoOrderRequest ordersRequest_ );
		
		com.vip.hermes.core.health.CheckResult healthCheck();
		
		vipapis.order.PrintInvoiceResp printInvoice( long vendor_id_,   string store_sn_,   string batch_no_,   List<vipapis.order.OrderSeq> orders_,   vipapis.order.ExtInfo ext_info_,   int? print_type_ );
		
		void pushOrderEInvoice();
		
		vipapis.order.PushOrderPackageWeightResp pushOrderPackageWeight( long vendor_id_,   string store_sn_,   List<vipapis.order.OrderPackageWeight> orders_ );
		
		vipapis.order.PushQCResultResp pushQCResult( long vendor_id_,   string store_sn_,   List<vipapis.order.OrderQCResult> orders_ );
		
		vipapis.order.ReplyStoreSnResp replyStoreSn( long vendor_id_,   List<vipapis.order.OrderStoreMapping> order_store_mapping_ );
		
		void responseOrderStore( long vendor_id_,   string order_id_,   string store_sn_ );
		
		vipapis.order.UpdateStoreSnResp updateStoreSn( long vendor_id_,   List<vipapis.order.OrderStoreMappingEx> order_store_mapping_ );
		
	}
	
}