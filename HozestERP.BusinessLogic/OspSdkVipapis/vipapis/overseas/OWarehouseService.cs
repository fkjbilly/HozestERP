using System;
using System.Collections.Generic;

namespace vipapis.overseas{
	
	
	public interface OWarehouseService {
		
		
		vipapis.overseas.CreateBatchRsResponse createBatchRs( vipapis.overseas.BatchRsInfo batchRsInfo_ );
		
		vipapis.overseas.CreateBatchResponse createPatch( vipapis.overseas.BatchInfo batchInfo_ );
		
		List<string> deliverOrderStatus( string warehouse_,   List<vipapis.overseas.OrderStatusItem> order_status_items_ );
		
		List<string> deliverSaleOrder( string warehouse_,   List<vipapis.overseas.SaleOrders> sale_orders_ );
		
		vipapis.overseas.Ht3plPoListResponse get3PLPoList( vipapis.overseas.Ht3plPoListRequest request_ );
		
		vipapis.overseas.GetPurchaseOrderBatchListResponse getPoBatchList( string warehouse_,   int? start_batch_id_,   int? num_,   string po_no_,   List<string> batch_no_list_,   string vendor_code_,   int? total_ );
		
		List<vipapis.overseas.RdcTransferForm> getRdcTransferForms( string warehouse_,   int num_ );
		
		List<string> getRdcTransferFormsAck( string warehouse_,   List<string> rdc_ids_ );
		
		List<vipapis.overseas.ReturnOrder> getReturnOrders( string warehouse_,   int num_ );
		
		List<string> getReturnOrdersAck( string warehouse_,   List<string> transaction_ids_ );
		
		vipapis.overseas.SaleOrderResult getSaleOrders( string warehouse_,   int num_ );
		
		List<vipapis.overseas.TransferForm> getTransferForms( string warehouse_,   int num_ );
		
		List<string> getTransferFormsAck( string warehouse_,   List<string> transaction_ids_ );
		
		com.vip.hermes.core.health.CheckResult healthCheck();
		
		List<vipapis.overseas.ResultTuple> updateCarrierStatus( string warehouse_,   vipapis.overseas.CarrierInfoRequest carrierInfoRequest_ );
		
		string updatePoBatchStatus( string warehouse_,   List<string> batch_nos_ );
		
		List<string> uploadOrderOutInfo( string warehouse_,   vipapis.overseas.OrderOutGoodsInfo order_out_goods_info_ );
		
		List<string> uploadRdcDeliverDetail( string warehouse_,   List<vipapis.overseas.RdcDeliverDetail> details_ );
		
		List<string> uploadReturnOrderStatus( string warehouse_,   List<vipapis.overseas.ReturnOrderStatus> details_ );
		
		List<string> uploadReturnOutDetail( string warehouse_,   List<vipapis.overseas.ReturnOutInfo> details_ );
		
		List<string> uploadTransactionDetail( string warehouse_,   List<vipapis.overseas.Transaction> details_ );
		
	}
	
}