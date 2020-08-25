using System;
using System.Collections.Generic;

namespace vipapis.delivery{
	
	
	public interface JitDeliveryService {
		
		
		string confirmDelivery( int vendor_id_,   string storage_no_,   string po_no_ );
		
		vipapis.delivery.CreateDeliveryResponse createDelivery( int vendor_id_,   string po_no_,   string delivery_no_,   vipapis.common.Warehouse? warehouse_,   string delivery_time_,   string arrival_time_,   string race_time_,   string carrier_name_,   string tel_,   string driver_,   string driver_tel_,   string plate_number_,   int? page_,   int? limit_ );
		
		List<vipapis.delivery.SimplePick> createPick( string po_no_,   int vendor_id_ );
		
		List<vipapis.delivery.DeleteDeliveryDetail> deleteDeliveryDetail( int vendor_id_,   string storage_no_,   string po_no_ );
		
		string editDelivery( int vendor_id_,   string storage_no_,   string delivery_no_,   vipapis.common.Warehouse? warehouse_,   string delivery_time_,   string arrival_time_,   string race_time_,   string carrier_name_,   string tel_,   string driver_,   string driver_tel_,   string plate_number_,   int? page_,   int? limit_ );
		
		vipapis.delivery.GetDeliveryGoodsResponse getDeliveryGoods( string vendor_id_,   string storage_no_,   int? page_,   int? limit_ );
		
		vipapis.delivery.GetDeliveryListResponse getDeliveryList( string vendor_id_,   string po_no_,   string delivery_no_,   vipapis.common.Warehouse? warehouse_,   string out_flag_,   string st_out_time_,   string et_out_time_,   string st_estimate_arrive_time_,   string et_estimate_arrive_time_,   string st_arrive_time_,   string et_arrive_time_,   int? page_,   int? limit_ );
		
		vipapis.delivery.PickDetail getPickDetail( string po_no_,   int vendor_id_,   string pick_no_,   int? page_,   int? limit_ );
		
		vipapis.delivery.GetPickListResponse getPickList( int vendor_id_,   string po_no_,   string pick_no_,   vipapis.common.Warehouse? warehouse_,   string co_mode_,   string order_cate_,   string st_create_time_,   string et_create_time_,   string st_sell_time_from_,   string et_sell_time_from_,   string st_sell_time_to_,   string et_sell_time_to_,   int? is_export_,   int? page_,   int? limit_ );
		
		vipapis.delivery.GetPoListResponse getPoList( string st_create_time_,   string et_create_time_,   vipapis.common.Warehouse? warehouse_,   string po_no_,   string co_mode_,   string vendor_id_,   string st_sell_st_time_,   string et_sell_st_time_,   string st_sell_et_time_,   string et_sell_et_time_,   int? page_,   int? limit_ );
		
		vipapis.delivery.GetPoSkuListResponse getPoSkuList( int vendor_id_,   string po_no_,   string sell_site_,   vipapis.common.Warehouse? warehouse_,   string order_status_,   string st_aduity_time_,   string et_aduity_time_,   string order_id_,   string pick_no_,   string delivery_no_,   string st_pick_time_,   string et_pick_time_,   string st_delivery_time_,   string et_delivery_time_,   int? page_,   int? limit_ );
		
		vipapis.delivery.GetPrintBoxResponse getPrintBox( string pick_no_,   string vendor_id_ );
		
		vipapis.delivery.GetPrintDeliveryResponse getPrintDelivery( int vendor_id_,   string storage_no_,   string po_no_,   string box_no_ );
		
		com.vip.hermes.core.health.CheckResult healthCheck();
		
		string importDeliveryDetail( int vendor_id_,   string po_no_,   string storage_no_,   string delivery_no_,   string store_sn_,   List<vipapis.delivery.Delivery> delivery_list_ );
		
	}
	
}