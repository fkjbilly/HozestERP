using System;
using System.Collections.Generic;

namespace vipapis.vlg.wms{
	
	
	public interface OutWmsService {
		
		
		com.vip.sce.vlg.osp.wms.service.PostResponse callbackOrders( string sysKey_,   string warehouse_,   List<string> orderSnList_ );
		
		com.vip.sce.vlg.osp.wms.service.PostResponse callbackOutOubShipment( string sysKey_,   string warehouse_,   List<string> orderSns_ );
		
		com.vip.sce.vlg.osp.wms.service.PostResponse callbackOutZcodeApplys( string sysKey_,   string warehouse_,   List<string> appNums_ );
		
		com.vip.sce.vlg.osp.wms.service.PostResponse callbackReturnOrders( string sysKey_,   string warehouse_,   List<string> ids_ );
		
		com.vip.sce.vlg.osp.wms.service.PostResponse deliverOrderContainer( string sysKey_,   string warehouse_,   List<com.vip.sce.vlg.osp.wms.service.OrderContainer> orders_ );
		
		com.vip.sce.vlg.osp.wms.service.PostResponse deliverSaleOrder( string sysKey_,   string warehouse_,   List<com.vip.sce.vlg.osp.wms.service.SaleOrders> sale_orders_ );
		
		com.vip.sce.vlg.osp.wms.service.PostResponse getGlobalDeliverBatch( string sysKey_,   string warehouse_,   com.vip.sce.vlg.osp.wms.service.OutWmsGlobalDeliverBatchParam globalDeliverBatchInfo_ );
		
		com.vip.sce.vlg.osp.wms.service.OutWmsOrderGetHeaderResponse getOrders( string sysKey_,   string warehouse_,   List<string> orderSnList_,   int? num_ );
		
		com.vip.sce.vlg.osp.wms.service.GetOutWmsOubShipmentResponse getOutOubShipments( string sysKey_,   string warehouse_,   int pageSize_ );
		
		com.vip.sce.vlg.osp.wms.service.PostResponse getOutWmsPackageTransferOrders( string sysKey_,   string warehouse_,   string carrierCode_,   string customsCode_,   List<com.vip.sce.vlg.osp.wms.service.OrdersVo> orders_ );
		
		com.vip.sce.vlg.osp.wms.service.GetOutWmsZcodeApplyResponse getOutZcodeApplys( string sysKey_,   string warehouse_,   int pageSize_ );
		
		com.vip.sce.vlg.osp.wms.service.OspOutWmsPoGetHeaderResponse getPoBatchList( string sysKey_,   string warehouse_,   int start_batch_id_,   int num_,   string po_no_,   List<string> batch_no_list_,   string vendor_code_,   int? total_ );
		
		com.vip.sce.vlg.osp.wms.service.OutWmsReturnOrderHeaderResponse getReturnOrders( string sysKey_,   string warehouse_,   int num_ );
		
		com.vip.sce.vlg.osp.wms.service.PostResponse getTransferLadingBillS( string sysKey_,   string warehouse_,   com.vip.sce.vlg.osp.wms.service.OutWmsLadingBillIDLParam requestParam_ );
		
		com.vip.hermes.core.health.CheckResult healthCheck();
		
		com.vip.sce.vlg.osp.wms.service.PostResponse pushOrderStatusList( string sysKey_,   string warehouse_,   List<com.vip.sce.vlg.osp.wms.service.OspOutWmsOrderStatusSModel> order_status_detail_list_ );
		
		com.vip.sce.vlg.osp.wms.service.PostResponse pushOutInbShipment( string sysKey_,   string warehouse_,   com.vip.sce.vlg.osp.wms.service.OutInbShipmentInfo outInbShipmentInfo_ );
		
		com.vip.sce.vlg.osp.wms.service.PostResponse pushOutWmsOrderBatch( string sysKey_,   string warehouse_,   string warehouseCode_,   List<com.vip.sce.vlg.osp.wms.service.OrderBatchInfo> orderBatchInfos_ );
		
		com.vip.sce.vlg.osp.wms.service.PostResponse pushOutZcode( string sysKey_,   string warehouse_,   com.vip.sce.vlg.osp.wms.service.OutWmsZcodeInfo outWmsZcodeInfo_ );
		
		com.vip.sce.vlg.osp.wms.service.PostResponse updateCarrierStatus( string sysKey_,   string warehouse_,   com.vip.sce.vlg.osp.wms.service.CarrierInfoRequest carrierInfoRequest_ );
		
		com.vip.sce.vlg.osp.wms.service.PostResponse updatePoBatchStatus( string sysKey_,   string warehouse_,   List<string> batch_nos_ );
		
		com.vip.sce.vlg.osp.wms.service.PostResponse uploadInvAdjustment( string sysKey_,   string warehouse_,   List<com.vip.sce.vlg.osp.wms.service.InvAdjustment> invAdjustments_ );
		
		com.vip.sce.vlg.osp.wms.service.PostResponse uploadReturnOrderStatus( string sysKey_,   string warehouse_,   List<com.vip.sce.vlg.osp.wms.service.ReturnOrderStatus> details_ );
		
		com.vip.sce.vlg.osp.wms.service.PostResponse uploadReturnOutDetail( string sysKey_,   string warehouse_,   List<com.vip.sce.vlg.osp.wms.service.ReturnOutInfo> details_ );
		
	}
	
}