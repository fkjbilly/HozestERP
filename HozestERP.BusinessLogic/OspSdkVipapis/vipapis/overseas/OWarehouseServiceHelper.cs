using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;

namespace vipapis.overseas{
	
	
	public class OWarehouseServiceHelper {
		
		
		
		public class createBatchRs_args {
			
			///<summary>
			/// 新增批次资料请求结构体
			///</summary>
			
			private vipapis.overseas.BatchRsInfo batchRsInfo_;
			
			public vipapis.overseas.BatchRsInfo GetBatchRsInfo(){
				return this.batchRsInfo_;
			}
			
			public void SetBatchRsInfo(vipapis.overseas.BatchRsInfo value){
				this.batchRsInfo_ = value;
			}
			
		}
		
		
		
		
		public class createPatch_args {
			
			///<summary>
			/// 新增批次请求结构体
			///</summary>
			
			private vipapis.overseas.BatchInfo batchInfo_;
			
			public vipapis.overseas.BatchInfo GetBatchInfo(){
				return this.batchInfo_;
			}
			
			public void SetBatchInfo(vipapis.overseas.BatchInfo value){
				this.batchInfo_ = value;
			}
			
		}
		
		
		
		
		public class deliverOrderStatus_args {
			
			///<summary>
			/// 仓库编号
			///</summary>
			
			private string warehouse_;
			
			///<summary>
			/// 更新订单状态的信息条目
			///</summary>
			
			private List<vipapis.overseas.OrderStatusItem> order_status_items_;
			
			public string GetWarehouse(){
				return this.warehouse_;
			}
			
			public void SetWarehouse(string value){
				this.warehouse_ = value;
			}
			public List<vipapis.overseas.OrderStatusItem> GetOrder_status_items(){
				return this.order_status_items_;
			}
			
			public void SetOrder_status_items(List<vipapis.overseas.OrderStatusItem> value){
				this.order_status_items_ = value;
			}
			
		}
		
		
		
		
		public class deliverSaleOrder_args {
			
			///<summary>
			/// 海外仓仓库编码
			///</summary>
			
			private string warehouse_;
			
			///<summary>
			/// 订单列表
			///</summary>
			
			private List<vipapis.overseas.SaleOrders> sale_orders_;
			
			public string GetWarehouse(){
				return this.warehouse_;
			}
			
			public void SetWarehouse(string value){
				this.warehouse_ = value;
			}
			public List<vipapis.overseas.SaleOrders> GetSale_orders(){
				return this.sale_orders_;
			}
			
			public void SetSale_orders(List<vipapis.overseas.SaleOrders> value){
				this.sale_orders_ = value;
			}
			
		}
		
		
		
		
		public class get3PLPoList_args {
			
			///<summary>
			/// 获取PO信息请求结构体
			///</summary>
			
			private vipapis.overseas.Ht3plPoListRequest request_;
			
			public vipapis.overseas.Ht3plPoListRequest GetRequest(){
				return this.request_;
			}
			
			public void SetRequest(vipapis.overseas.Ht3plPoListRequest value){
				this.request_ = value;
			}
			
		}
		
		
		
		
		public class getPoBatchList_args {
			
			///<summary>
			/// 调用方的仓库编码
			///</summary>
			
			private string warehouse_;
			
			///<summary>
			/// 起始批次id
			///</summary>
			
			private int? start_batch_id_;
			
			///<summary>
			/// 读取数量，最大不超过10条
			///</summary>
			
			private int? num_;
			
			///<summary>
			/// PO单号
			///</summary>
			
			private string po_no_;
			
			///<summary>
			/// 批次号列表
			///</summary>
			
			private List<string> batch_no_list_;
			
			///<summary>
			/// 供应商编码
			///</summary>
			
			private string vendor_code_;
			
			///<summary>
			/// 是否需要批次号总数,0:否，1:是
			///</summary>
			
			private int? total_;
			
			public string GetWarehouse(){
				return this.warehouse_;
			}
			
			public void SetWarehouse(string value){
				this.warehouse_ = value;
			}
			public int? GetStart_batch_id(){
				return this.start_batch_id_;
			}
			
			public void SetStart_batch_id(int? value){
				this.start_batch_id_ = value;
			}
			public int? GetNum(){
				return this.num_;
			}
			
			public void SetNum(int? value){
				this.num_ = value;
			}
			public string GetPo_no(){
				return this.po_no_;
			}
			
			public void SetPo_no(string value){
				this.po_no_ = value;
			}
			public List<string> GetBatch_no_list(){
				return this.batch_no_list_;
			}
			
			public void SetBatch_no_list(List<string> value){
				this.batch_no_list_ = value;
			}
			public string GetVendor_code(){
				return this.vendor_code_;
			}
			
			public void SetVendor_code(string value){
				this.vendor_code_ = value;
			}
			public int? GetTotal(){
				return this.total_;
			}
			
			public void SetTotal(int? value){
				this.total_ = value;
			}
			
		}
		
		
		
		
		public class getRdcTransferForms_args {
			
			///<summary>
			/// 仓库编号
			///</summary>
			
			private string warehouse_;
			
			///<summary>
			/// 数目
			///</summary>
			
			private int? num_;
			
			public string GetWarehouse(){
				return this.warehouse_;
			}
			
			public void SetWarehouse(string value){
				this.warehouse_ = value;
			}
			public int? GetNum(){
				return this.num_;
			}
			
			public void SetNum(int? value){
				this.num_ = value;
			}
			
		}
		
		
		
		
		public class getRdcTransferFormsAck_args {
			
			///<summary>
			/// 仓库编号
			///</summary>
			
			private string warehouse_;
			
			///<summary>
			/// 流水号
			///</summary>
			
			private List<string> rdc_ids_;
			
			public string GetWarehouse(){
				return this.warehouse_;
			}
			
			public void SetWarehouse(string value){
				this.warehouse_ = value;
			}
			public List<string> GetRdc_ids(){
				return this.rdc_ids_;
			}
			
			public void SetRdc_ids(List<string> value){
				this.rdc_ids_ = value;
			}
			
		}
		
		
		
		
		public class getReturnOrders_args {
			
			///<summary>
			/// 仓库编号
			///</summary>
			
			private string warehouse_;
			
			///<summary>
			/// 数目
			///</summary>
			
			private int? num_;
			
			public string GetWarehouse(){
				return this.warehouse_;
			}
			
			public void SetWarehouse(string value){
				this.warehouse_ = value;
			}
			public int? GetNum(){
				return this.num_;
			}
			
			public void SetNum(int? value){
				this.num_ = value;
			}
			
		}
		
		
		
		
		public class getReturnOrdersAck_args {
			
			///<summary>
			/// 仓库编号
			///</summary>
			
			private string warehouse_;
			
			///<summary>
			/// 流水号
			///</summary>
			
			private List<string> transaction_ids_;
			
			public string GetWarehouse(){
				return this.warehouse_;
			}
			
			public void SetWarehouse(string value){
				this.warehouse_ = value;
			}
			public List<string> GetTransaction_ids(){
				return this.transaction_ids_;
			}
			
			public void SetTransaction_ids(List<string> value){
				this.transaction_ids_ = value;
			}
			
		}
		
		
		
		
		public class getSaleOrders_args {
			
			///<summary>
			/// 仓库编号
			///</summary>
			
			private string warehouse_;
			
			///<summary>
			/// 数目
			///</summary>
			
			private int? num_;
			
			public string GetWarehouse(){
				return this.warehouse_;
			}
			
			public void SetWarehouse(string value){
				this.warehouse_ = value;
			}
			public int? GetNum(){
				return this.num_;
			}
			
			public void SetNum(int? value){
				this.num_ = value;
			}
			
		}
		
		
		
		
		public class getTransferForms_args {
			
			///<summary>
			/// 仓库编号
			///</summary>
			
			private string warehouse_;
			
			///<summary>
			/// 数目
			///</summary>
			
			private int? num_;
			
			public string GetWarehouse(){
				return this.warehouse_;
			}
			
			public void SetWarehouse(string value){
				this.warehouse_ = value;
			}
			public int? GetNum(){
				return this.num_;
			}
			
			public void SetNum(int? value){
				this.num_ = value;
			}
			
		}
		
		
		
		
		public class getTransferFormsAck_args {
			
			///<summary>
			/// 仓库编号
			///</summary>
			
			private string warehouse_;
			
			///<summary>
			/// 流水号
			///</summary>
			
			private List<string> transaction_ids_;
			
			public string GetWarehouse(){
				return this.warehouse_;
			}
			
			public void SetWarehouse(string value){
				this.warehouse_ = value;
			}
			public List<string> GetTransaction_ids(){
				return this.transaction_ids_;
			}
			
			public void SetTransaction_ids(List<string> value){
				this.transaction_ids_ = value;
			}
			
		}
		
		
		
		
		public class healthCheck_args {
			
			
		}
		
		
		
		
		public class updateCarrierStatus_args {
			
			///<summary>
			/// 仓库编号
			///</summary>
			
			private string warehouse_;
			
			///<summary>
			/// 物流状态请求信息
			///</summary>
			
			private vipapis.overseas.CarrierInfoRequest carrierInfoRequest_;
			
			public string GetWarehouse(){
				return this.warehouse_;
			}
			
			public void SetWarehouse(string value){
				this.warehouse_ = value;
			}
			public vipapis.overseas.CarrierInfoRequest GetCarrierInfoRequest(){
				return this.carrierInfoRequest_;
			}
			
			public void SetCarrierInfoRequest(vipapis.overseas.CarrierInfoRequest value){
				this.carrierInfoRequest_ = value;
			}
			
		}
		
		
		
		
		public class updatePoBatchStatus_args {
			
			///<summary>
			/// 仓库编码
			///</summary>
			
			private string warehouse_;
			
			///<summary>
			/// 批次号列表，每次请求不能超过100个批次号
			///</summary>
			
			private List<string> batch_nos_;
			
			public string GetWarehouse(){
				return this.warehouse_;
			}
			
			public void SetWarehouse(string value){
				this.warehouse_ = value;
			}
			public List<string> GetBatch_nos(){
				return this.batch_nos_;
			}
			
			public void SetBatch_nos(List<string> value){
				this.batch_nos_ = value;
			}
			
		}
		
		
		
		
		public class uploadOrderOutInfo_args {
			
			///<summary>
			/// 仓库编号
			///</summary>
			
			private string warehouse_;
			
			///<summary>
			/// 出仓货物信息
			///</summary>
			
			private vipapis.overseas.OrderOutGoodsInfo order_out_goods_info_;
			
			public string GetWarehouse(){
				return this.warehouse_;
			}
			
			public void SetWarehouse(string value){
				this.warehouse_ = value;
			}
			public vipapis.overseas.OrderOutGoodsInfo GetOrder_out_goods_info(){
				return this.order_out_goods_info_;
			}
			
			public void SetOrder_out_goods_info(vipapis.overseas.OrderOutGoodsInfo value){
				this.order_out_goods_info_ = value;
			}
			
		}
		
		
		
		
		public class uploadRdcDeliverDetail_args {
			
			///<summary>
			/// 仓库编号
			///</summary>
			
			private string warehouse_;
			
			///<summary>
			/// 出仓明细
			///</summary>
			
			private List<vipapis.overseas.RdcDeliverDetail> details_;
			
			public string GetWarehouse(){
				return this.warehouse_;
			}
			
			public void SetWarehouse(string value){
				this.warehouse_ = value;
			}
			public List<vipapis.overseas.RdcDeliverDetail> GetDetails(){
				return this.details_;
			}
			
			public void SetDetails(List<vipapis.overseas.RdcDeliverDetail> value){
				this.details_ = value;
			}
			
		}
		
		
		
		
		public class uploadReturnOrderStatus_args {
			
			///<summary>
			/// 仓库编号
			///</summary>
			
			private string warehouse_;
			
			///<summary>
			/// 出仓明细
			///</summary>
			
			private List<vipapis.overseas.ReturnOrderStatus> details_;
			
			public string GetWarehouse(){
				return this.warehouse_;
			}
			
			public void SetWarehouse(string value){
				this.warehouse_ = value;
			}
			public List<vipapis.overseas.ReturnOrderStatus> GetDetails(){
				return this.details_;
			}
			
			public void SetDetails(List<vipapis.overseas.ReturnOrderStatus> value){
				this.details_ = value;
			}
			
		}
		
		
		
		
		public class uploadReturnOutDetail_args {
			
			///<summary>
			/// 仓库编号
			///</summary>
			
			private string warehouse_;
			
			///<summary>
			/// 出仓明细
			///</summary>
			
			private List<vipapis.overseas.ReturnOutInfo> details_;
			
			public string GetWarehouse(){
				return this.warehouse_;
			}
			
			public void SetWarehouse(string value){
				this.warehouse_ = value;
			}
			public List<vipapis.overseas.ReturnOutInfo> GetDetails(){
				return this.details_;
			}
			
			public void SetDetails(List<vipapis.overseas.ReturnOutInfo> value){
				this.details_ = value;
			}
			
		}
		
		
		
		
		public class uploadTransactionDetail_args {
			
			///<summary>
			/// 仓库编号
			///</summary>
			
			private string warehouse_;
			
			///<summary>
			/// 出仓明细
			///</summary>
			
			private List<vipapis.overseas.Transaction> details_;
			
			public string GetWarehouse(){
				return this.warehouse_;
			}
			
			public void SetWarehouse(string value){
				this.warehouse_ = value;
			}
			public List<vipapis.overseas.Transaction> GetDetails(){
				return this.details_;
			}
			
			public void SetDetails(List<vipapis.overseas.Transaction> value){
				this.details_ = value;
			}
			
		}
		
		
		
		
		public class createBatchRs_result {
			
			///<summary>
			///</summary>
			
			private vipapis.overseas.CreateBatchRsResponse success_;
			
			public vipapis.overseas.CreateBatchRsResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.overseas.CreateBatchRsResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class createPatch_result {
			
			///<summary>
			///</summary>
			
			private vipapis.overseas.CreateBatchResponse success_;
			
			public vipapis.overseas.CreateBatchResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.overseas.CreateBatchResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class deliverOrderStatus_result {
			
			///<summary>
			/// 上报成功的ID列表
			///</summary>
			
			private List<string> success_;
			
			public List<string> GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(List<string> value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class deliverSaleOrder_result {
			
			///<summary>
			/// 集合
			///</summary>
			
			private List<string> success_;
			
			public List<string> GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(List<string> value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class get3PLPoList_result {
			
			///<summary>
			/// PO信息
			///</summary>
			
			private vipapis.overseas.Ht3plPoListResponse success_;
			
			public vipapis.overseas.Ht3plPoListResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.overseas.Ht3plPoListResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getPoBatchList_result {
			
			///<summary>
			/// po批次集合
			///</summary>
			
			private vipapis.overseas.GetPurchaseOrderBatchListResponse success_;
			
			public vipapis.overseas.GetPurchaseOrderBatchListResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.overseas.GetPurchaseOrderBatchListResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getRdcTransferForms_result {
			
			///<summary>
			///</summary>
			
			private List<vipapis.overseas.RdcTransferForm> success_;
			
			public List<vipapis.overseas.RdcTransferForm> GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(List<vipapis.overseas.RdcTransferForm> value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getRdcTransferFormsAck_result {
			
			///<summary>
			///</summary>
			
			private List<string> success_;
			
			public List<string> GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(List<string> value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getReturnOrders_result {
			
			///<summary>
			///</summary>
			
			private List<vipapis.overseas.ReturnOrder> success_;
			
			public List<vipapis.overseas.ReturnOrder> GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(List<vipapis.overseas.ReturnOrder> value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getReturnOrdersAck_result {
			
			///<summary>
			///</summary>
			
			private List<string> success_;
			
			public List<string> GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(List<string> value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getSaleOrders_result {
			
			///<summary>
			///</summary>
			
			private vipapis.overseas.SaleOrderResult success_;
			
			public vipapis.overseas.SaleOrderResult GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.overseas.SaleOrderResult value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getTransferForms_result {
			
			///<summary>
			///</summary>
			
			private List<vipapis.overseas.TransferForm> success_;
			
			public List<vipapis.overseas.TransferForm> GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(List<vipapis.overseas.TransferForm> value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getTransferFormsAck_result {
			
			///<summary>
			///</summary>
			
			private List<string> success_;
			
			public List<string> GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(List<string> value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class healthCheck_result {
			
			///<summary>
			///</summary>
			
			private com.vip.hermes.core.health.CheckResult success_;
			
			public com.vip.hermes.core.health.CheckResult GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.hermes.core.health.CheckResult value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class updateCarrierStatus_result {
			
			///<summary>
			/// 获取成功的订单号
			///</summary>
			
			private List<vipapis.overseas.ResultTuple> success_;
			
			public List<vipapis.overseas.ResultTuple> GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(List<vipapis.overseas.ResultTuple> value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class updatePoBatchStatus_result {
			
			///<summary>
			/// 返回以逗号(,)分隔的批次号字符串
			///</summary>
			
			private string success_;
			
			public string GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(string value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class uploadOrderOutInfo_result {
			
			///<summary>
			///</summary>
			
			private List<string> success_;
			
			public List<string> GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(List<string> value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class uploadRdcDeliverDetail_result {
			
			///<summary>
			///</summary>
			
			private List<string> success_;
			
			public List<string> GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(List<string> value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class uploadReturnOrderStatus_result {
			
			///<summary>
			///</summary>
			
			private List<string> success_;
			
			public List<string> GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(List<string> value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class uploadReturnOutDetail_result {
			
			///<summary>
			///</summary>
			
			private List<string> success_;
			
			public List<string> GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(List<string> value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class uploadTransactionDetail_result {
			
			///<summary>
			///</summary>
			
			private List<string> success_;
			
			public List<string> GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(List<string> value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		
		public class createBatchRs_argsHelper : TBeanSerializer<createBatchRs_args>
		{
			
			public static createBatchRs_argsHelper OBJ = new createBatchRs_argsHelper();
			
			public static createBatchRs_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(createBatchRs_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.overseas.BatchRsInfo value;
					
					value = new vipapis.overseas.BatchRsInfo();
					vipapis.overseas.BatchRsInfoHelper.getInstance().Read(value, iprot);
					
					structs.SetBatchRsInfo(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(createBatchRs_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetBatchRsInfo() != null) {
					
					oprot.WriteFieldBegin("batchRsInfo");
					
					vipapis.overseas.BatchRsInfoHelper.getInstance().Write(structs.GetBatchRsInfo(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("batchRsInfo can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(createBatchRs_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class createPatch_argsHelper : TBeanSerializer<createPatch_args>
		{
			
			public static createPatch_argsHelper OBJ = new createPatch_argsHelper();
			
			public static createPatch_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(createPatch_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.overseas.BatchInfo value;
					
					value = new vipapis.overseas.BatchInfo();
					vipapis.overseas.BatchInfoHelper.getInstance().Read(value, iprot);
					
					structs.SetBatchInfo(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(createPatch_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetBatchInfo() != null) {
					
					oprot.WriteFieldBegin("batchInfo");
					
					vipapis.overseas.BatchInfoHelper.getInstance().Write(structs.GetBatchInfo(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("batchInfo can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(createPatch_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class deliverOrderStatus_argsHelper : TBeanSerializer<deliverOrderStatus_args>
		{
			
			public static deliverOrderStatus_argsHelper OBJ = new deliverOrderStatus_argsHelper();
			
			public static deliverOrderStatus_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(deliverOrderStatus_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetWarehouse(value);
				}
				
				
				
				
				
				if(true){
					
					List<vipapis.overseas.OrderStatusItem> value;
					
					value = new List<vipapis.overseas.OrderStatusItem>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							vipapis.overseas.OrderStatusItem elem0;
							
							elem0 = new vipapis.overseas.OrderStatusItem();
							vipapis.overseas.OrderStatusItemHelper.getInstance().Read(elem0, iprot);
							
							value.Add(elem0);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetOrder_status_items(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(deliverOrderStatus_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetWarehouse() != null) {
					
					oprot.WriteFieldBegin("warehouse");
					oprot.WriteString(structs.GetWarehouse());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("warehouse can not be null!");
				}
				
				
				if(structs.GetOrder_status_items() != null) {
					
					oprot.WriteFieldBegin("order_status_items");
					
					oprot.WriteListBegin();
					foreach(vipapis.overseas.OrderStatusItem _item0 in structs.GetOrder_status_items()){
						
						
						vipapis.overseas.OrderStatusItemHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("order_status_items can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(deliverOrderStatus_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class deliverSaleOrder_argsHelper : TBeanSerializer<deliverSaleOrder_args>
		{
			
			public static deliverSaleOrder_argsHelper OBJ = new deliverSaleOrder_argsHelper();
			
			public static deliverSaleOrder_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(deliverSaleOrder_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetWarehouse(value);
				}
				
				
				
				
				
				if(true){
					
					List<vipapis.overseas.SaleOrders> value;
					
					value = new List<vipapis.overseas.SaleOrders>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							vipapis.overseas.SaleOrders elem1;
							
							elem1 = new vipapis.overseas.SaleOrders();
							vipapis.overseas.SaleOrdersHelper.getInstance().Read(elem1, iprot);
							
							value.Add(elem1);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetSale_orders(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(deliverSaleOrder_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetWarehouse() != null) {
					
					oprot.WriteFieldBegin("warehouse");
					oprot.WriteString(structs.GetWarehouse());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("warehouse can not be null!");
				}
				
				
				if(structs.GetSale_orders() != null) {
					
					oprot.WriteFieldBegin("sale_orders");
					
					oprot.WriteListBegin();
					foreach(vipapis.overseas.SaleOrders _item0 in structs.GetSale_orders()){
						
						
						vipapis.overseas.SaleOrdersHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("sale_orders can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(deliverSaleOrder_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class get3PLPoList_argsHelper : TBeanSerializer<get3PLPoList_args>
		{
			
			public static get3PLPoList_argsHelper OBJ = new get3PLPoList_argsHelper();
			
			public static get3PLPoList_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(get3PLPoList_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.overseas.Ht3plPoListRequest value;
					
					value = new vipapis.overseas.Ht3plPoListRequest();
					vipapis.overseas.Ht3plPoListRequestHelper.getInstance().Read(value, iprot);
					
					structs.SetRequest(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(get3PLPoList_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequest() != null) {
					
					oprot.WriteFieldBegin("request");
					
					vipapis.overseas.Ht3plPoListRequestHelper.getInstance().Write(structs.GetRequest(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("request can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(get3PLPoList_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getPoBatchList_argsHelper : TBeanSerializer<getPoBatchList_args>
		{
			
			public static getPoBatchList_argsHelper OBJ = new getPoBatchList_argsHelper();
			
			public static getPoBatchList_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getPoBatchList_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetWarehouse(value);
				}
				
				
				
				
				
				if(true){
					
					int? value;
					value = iprot.ReadI32(); 
					
					structs.SetStart_batch_id(value);
				}
				
				
				
				
				
				if(true){
					
					int? value;
					value = iprot.ReadI32(); 
					
					structs.SetNum(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetPo_no(value);
				}
				
				
				
				
				
				if(true){
					
					List<string> value;
					
					value = new List<string>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							string elem0;
							elem0 = iprot.ReadString();
							
							value.Add(elem0);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetBatch_no_list(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetVendor_code(value);
				}
				
				
				
				
				
				if(true){
					
					int? value;
					value = iprot.ReadI32(); 
					
					structs.SetTotal(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getPoBatchList_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetWarehouse() != null) {
					
					oprot.WriteFieldBegin("warehouse");
					oprot.WriteString(structs.GetWarehouse());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("warehouse can not be null!");
				}
				
				
				if(structs.GetStart_batch_id() != null) {
					
					oprot.WriteFieldBegin("start_batch_id");
					oprot.WriteI32((int)structs.GetStart_batch_id()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetNum() != null) {
					
					oprot.WriteFieldBegin("num");
					oprot.WriteI32((int)structs.GetNum()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetPo_no() != null) {
					
					oprot.WriteFieldBegin("po_no");
					oprot.WriteString(structs.GetPo_no());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetBatch_no_list() != null) {
					
					oprot.WriteFieldBegin("batch_no_list");
					
					oprot.WriteListBegin();
					foreach(string _item0 in structs.GetBatch_no_list()){
						
						oprot.WriteString(_item0);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetVendor_code() != null) {
					
					oprot.WriteFieldBegin("vendor_code");
					oprot.WriteString(structs.GetVendor_code());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetTotal() != null) {
					
					oprot.WriteFieldBegin("total");
					oprot.WriteI32((int)structs.GetTotal()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getPoBatchList_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getRdcTransferForms_argsHelper : TBeanSerializer<getRdcTransferForms_args>
		{
			
			public static getRdcTransferForms_argsHelper OBJ = new getRdcTransferForms_argsHelper();
			
			public static getRdcTransferForms_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getRdcTransferForms_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetWarehouse(value);
				}
				
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetNum(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getRdcTransferForms_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetWarehouse() != null) {
					
					oprot.WriteFieldBegin("warehouse");
					oprot.WriteString(structs.GetWarehouse());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("warehouse can not be null!");
				}
				
				
				if(structs.GetNum() != null) {
					
					oprot.WriteFieldBegin("num");
					oprot.WriteI32((int)structs.GetNum()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("num can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getRdcTransferForms_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getRdcTransferFormsAck_argsHelper : TBeanSerializer<getRdcTransferFormsAck_args>
		{
			
			public static getRdcTransferFormsAck_argsHelper OBJ = new getRdcTransferFormsAck_argsHelper();
			
			public static getRdcTransferFormsAck_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getRdcTransferFormsAck_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetWarehouse(value);
				}
				
				
				
				
				
				if(true){
					
					List<string> value;
					
					value = new List<string>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							string elem0;
							elem0 = iprot.ReadString();
							
							value.Add(elem0);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetRdc_ids(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getRdcTransferFormsAck_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetWarehouse() != null) {
					
					oprot.WriteFieldBegin("warehouse");
					oprot.WriteString(structs.GetWarehouse());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("warehouse can not be null!");
				}
				
				
				if(structs.GetRdc_ids() != null) {
					
					oprot.WriteFieldBegin("rdc_ids");
					
					oprot.WriteListBegin();
					foreach(string _item0 in structs.GetRdc_ids()){
						
						oprot.WriteString(_item0);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("rdc_ids can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getRdcTransferFormsAck_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getReturnOrders_argsHelper : TBeanSerializer<getReturnOrders_args>
		{
			
			public static getReturnOrders_argsHelper OBJ = new getReturnOrders_argsHelper();
			
			public static getReturnOrders_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getReturnOrders_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetWarehouse(value);
				}
				
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetNum(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getReturnOrders_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetWarehouse() != null) {
					
					oprot.WriteFieldBegin("warehouse");
					oprot.WriteString(structs.GetWarehouse());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("warehouse can not be null!");
				}
				
				
				if(structs.GetNum() != null) {
					
					oprot.WriteFieldBegin("num");
					oprot.WriteI32((int)structs.GetNum()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("num can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getReturnOrders_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getReturnOrdersAck_argsHelper : TBeanSerializer<getReturnOrdersAck_args>
		{
			
			public static getReturnOrdersAck_argsHelper OBJ = new getReturnOrdersAck_argsHelper();
			
			public static getReturnOrdersAck_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getReturnOrdersAck_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetWarehouse(value);
				}
				
				
				
				
				
				if(true){
					
					List<string> value;
					
					value = new List<string>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							string elem0;
							elem0 = iprot.ReadString();
							
							value.Add(elem0);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetTransaction_ids(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getReturnOrdersAck_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetWarehouse() != null) {
					
					oprot.WriteFieldBegin("warehouse");
					oprot.WriteString(structs.GetWarehouse());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("warehouse can not be null!");
				}
				
				
				if(structs.GetTransaction_ids() != null) {
					
					oprot.WriteFieldBegin("transaction_ids");
					
					oprot.WriteListBegin();
					foreach(string _item0 in structs.GetTransaction_ids()){
						
						oprot.WriteString(_item0);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("transaction_ids can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getReturnOrdersAck_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getSaleOrders_argsHelper : TBeanSerializer<getSaleOrders_args>
		{
			
			public static getSaleOrders_argsHelper OBJ = new getSaleOrders_argsHelper();
			
			public static getSaleOrders_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getSaleOrders_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetWarehouse(value);
				}
				
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetNum(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getSaleOrders_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetWarehouse() != null) {
					
					oprot.WriteFieldBegin("warehouse");
					oprot.WriteString(structs.GetWarehouse());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("warehouse can not be null!");
				}
				
				
				if(structs.GetNum() != null) {
					
					oprot.WriteFieldBegin("num");
					oprot.WriteI32((int)structs.GetNum()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("num can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getSaleOrders_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getTransferForms_argsHelper : TBeanSerializer<getTransferForms_args>
		{
			
			public static getTransferForms_argsHelper OBJ = new getTransferForms_argsHelper();
			
			public static getTransferForms_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getTransferForms_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetWarehouse(value);
				}
				
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetNum(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getTransferForms_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetWarehouse() != null) {
					
					oprot.WriteFieldBegin("warehouse");
					oprot.WriteString(structs.GetWarehouse());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("warehouse can not be null!");
				}
				
				
				if(structs.GetNum() != null) {
					
					oprot.WriteFieldBegin("num");
					oprot.WriteI32((int)structs.GetNum()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("num can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getTransferForms_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getTransferFormsAck_argsHelper : TBeanSerializer<getTransferFormsAck_args>
		{
			
			public static getTransferFormsAck_argsHelper OBJ = new getTransferFormsAck_argsHelper();
			
			public static getTransferFormsAck_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getTransferFormsAck_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetWarehouse(value);
				}
				
				
				
				
				
				if(true){
					
					List<string> value;
					
					value = new List<string>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							string elem0;
							elem0 = iprot.ReadString();
							
							value.Add(elem0);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetTransaction_ids(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getTransferFormsAck_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetWarehouse() != null) {
					
					oprot.WriteFieldBegin("warehouse");
					oprot.WriteString(structs.GetWarehouse());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("warehouse can not be null!");
				}
				
				
				if(structs.GetTransaction_ids() != null) {
					
					oprot.WriteFieldBegin("transaction_ids");
					
					oprot.WriteListBegin();
					foreach(string _item0 in structs.GetTransaction_ids()){
						
						oprot.WriteString(_item0);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("transaction_ids can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getTransferFormsAck_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class healthCheck_argsHelper : TBeanSerializer<healthCheck_args>
		{
			
			public static healthCheck_argsHelper OBJ = new healthCheck_argsHelper();
			
			public static healthCheck_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(healthCheck_args structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(healthCheck_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(healthCheck_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class updateCarrierStatus_argsHelper : TBeanSerializer<updateCarrierStatus_args>
		{
			
			public static updateCarrierStatus_argsHelper OBJ = new updateCarrierStatus_argsHelper();
			
			public static updateCarrierStatus_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(updateCarrierStatus_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetWarehouse(value);
				}
				
				
				
				
				
				if(true){
					
					vipapis.overseas.CarrierInfoRequest value;
					
					value = new vipapis.overseas.CarrierInfoRequest();
					vipapis.overseas.CarrierInfoRequestHelper.getInstance().Read(value, iprot);
					
					structs.SetCarrierInfoRequest(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(updateCarrierStatus_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetWarehouse() != null) {
					
					oprot.WriteFieldBegin("warehouse");
					oprot.WriteString(structs.GetWarehouse());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("warehouse can not be null!");
				}
				
				
				if(structs.GetCarrierInfoRequest() != null) {
					
					oprot.WriteFieldBegin("carrierInfoRequest");
					
					vipapis.overseas.CarrierInfoRequestHelper.getInstance().Write(structs.GetCarrierInfoRequest(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("carrierInfoRequest can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(updateCarrierStatus_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class updatePoBatchStatus_argsHelper : TBeanSerializer<updatePoBatchStatus_args>
		{
			
			public static updatePoBatchStatus_argsHelper OBJ = new updatePoBatchStatus_argsHelper();
			
			public static updatePoBatchStatus_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(updatePoBatchStatus_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetWarehouse(value);
				}
				
				
				
				
				
				if(true){
					
					List<string> value;
					
					value = new List<string>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							string elem0;
							elem0 = iprot.ReadString();
							
							value.Add(elem0);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetBatch_nos(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(updatePoBatchStatus_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetWarehouse() != null) {
					
					oprot.WriteFieldBegin("warehouse");
					oprot.WriteString(structs.GetWarehouse());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("warehouse can not be null!");
				}
				
				
				if(structs.GetBatch_nos() != null) {
					
					oprot.WriteFieldBegin("batch_nos");
					
					oprot.WriteListBegin();
					foreach(string _item0 in structs.GetBatch_nos()){
						
						oprot.WriteString(_item0);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("batch_nos can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(updatePoBatchStatus_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class uploadOrderOutInfo_argsHelper : TBeanSerializer<uploadOrderOutInfo_args>
		{
			
			public static uploadOrderOutInfo_argsHelper OBJ = new uploadOrderOutInfo_argsHelper();
			
			public static uploadOrderOutInfo_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(uploadOrderOutInfo_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetWarehouse(value);
				}
				
				
				
				
				
				if(true){
					
					vipapis.overseas.OrderOutGoodsInfo value;
					
					value = new vipapis.overseas.OrderOutGoodsInfo();
					vipapis.overseas.OrderOutGoodsInfoHelper.getInstance().Read(value, iprot);
					
					structs.SetOrder_out_goods_info(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(uploadOrderOutInfo_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetWarehouse() != null) {
					
					oprot.WriteFieldBegin("warehouse");
					oprot.WriteString(structs.GetWarehouse());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("warehouse can not be null!");
				}
				
				
				if(structs.GetOrder_out_goods_info() != null) {
					
					oprot.WriteFieldBegin("order_out_goods_info");
					
					vipapis.overseas.OrderOutGoodsInfoHelper.getInstance().Write(structs.GetOrder_out_goods_info(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("order_out_goods_info can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(uploadOrderOutInfo_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class uploadRdcDeliverDetail_argsHelper : TBeanSerializer<uploadRdcDeliverDetail_args>
		{
			
			public static uploadRdcDeliverDetail_argsHelper OBJ = new uploadRdcDeliverDetail_argsHelper();
			
			public static uploadRdcDeliverDetail_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(uploadRdcDeliverDetail_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetWarehouse(value);
				}
				
				
				
				
				
				if(true){
					
					List<vipapis.overseas.RdcDeliverDetail> value;
					
					value = new List<vipapis.overseas.RdcDeliverDetail>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							vipapis.overseas.RdcDeliverDetail elem0;
							
							elem0 = new vipapis.overseas.RdcDeliverDetail();
							vipapis.overseas.RdcDeliverDetailHelper.getInstance().Read(elem0, iprot);
							
							value.Add(elem0);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetDetails(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(uploadRdcDeliverDetail_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetWarehouse() != null) {
					
					oprot.WriteFieldBegin("warehouse");
					oprot.WriteString(structs.GetWarehouse());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("warehouse can not be null!");
				}
				
				
				if(structs.GetDetails() != null) {
					
					oprot.WriteFieldBegin("details");
					
					oprot.WriteListBegin();
					foreach(vipapis.overseas.RdcDeliverDetail _item0 in structs.GetDetails()){
						
						
						vipapis.overseas.RdcDeliverDetailHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("details can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(uploadRdcDeliverDetail_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class uploadReturnOrderStatus_argsHelper : TBeanSerializer<uploadReturnOrderStatus_args>
		{
			
			public static uploadReturnOrderStatus_argsHelper OBJ = new uploadReturnOrderStatus_argsHelper();
			
			public static uploadReturnOrderStatus_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(uploadReturnOrderStatus_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetWarehouse(value);
				}
				
				
				
				
				
				if(true){
					
					List<vipapis.overseas.ReturnOrderStatus> value;
					
					value = new List<vipapis.overseas.ReturnOrderStatus>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							vipapis.overseas.ReturnOrderStatus elem1;
							
							elem1 = new vipapis.overseas.ReturnOrderStatus();
							vipapis.overseas.ReturnOrderStatusHelper.getInstance().Read(elem1, iprot);
							
							value.Add(elem1);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetDetails(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(uploadReturnOrderStatus_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetWarehouse() != null) {
					
					oprot.WriteFieldBegin("warehouse");
					oprot.WriteString(structs.GetWarehouse());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("warehouse can not be null!");
				}
				
				
				if(structs.GetDetails() != null) {
					
					oprot.WriteFieldBegin("details");
					
					oprot.WriteListBegin();
					foreach(vipapis.overseas.ReturnOrderStatus _item0 in structs.GetDetails()){
						
						
						vipapis.overseas.ReturnOrderStatusHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("details can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(uploadReturnOrderStatus_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class uploadReturnOutDetail_argsHelper : TBeanSerializer<uploadReturnOutDetail_args>
		{
			
			public static uploadReturnOutDetail_argsHelper OBJ = new uploadReturnOutDetail_argsHelper();
			
			public static uploadReturnOutDetail_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(uploadReturnOutDetail_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetWarehouse(value);
				}
				
				
				
				
				
				if(true){
					
					List<vipapis.overseas.ReturnOutInfo> value;
					
					value = new List<vipapis.overseas.ReturnOutInfo>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							vipapis.overseas.ReturnOutInfo elem1;
							
							elem1 = new vipapis.overseas.ReturnOutInfo();
							vipapis.overseas.ReturnOutInfoHelper.getInstance().Read(elem1, iprot);
							
							value.Add(elem1);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetDetails(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(uploadReturnOutDetail_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetWarehouse() != null) {
					
					oprot.WriteFieldBegin("warehouse");
					oprot.WriteString(structs.GetWarehouse());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("warehouse can not be null!");
				}
				
				
				if(structs.GetDetails() != null) {
					
					oprot.WriteFieldBegin("details");
					
					oprot.WriteListBegin();
					foreach(vipapis.overseas.ReturnOutInfo _item0 in structs.GetDetails()){
						
						
						vipapis.overseas.ReturnOutInfoHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("details can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(uploadReturnOutDetail_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class uploadTransactionDetail_argsHelper : TBeanSerializer<uploadTransactionDetail_args>
		{
			
			public static uploadTransactionDetail_argsHelper OBJ = new uploadTransactionDetail_argsHelper();
			
			public static uploadTransactionDetail_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(uploadTransactionDetail_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetWarehouse(value);
				}
				
				
				
				
				
				if(true){
					
					List<vipapis.overseas.Transaction> value;
					
					value = new List<vipapis.overseas.Transaction>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							vipapis.overseas.Transaction elem1;
							
							elem1 = new vipapis.overseas.Transaction();
							vipapis.overseas.TransactionHelper.getInstance().Read(elem1, iprot);
							
							value.Add(elem1);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetDetails(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(uploadTransactionDetail_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetWarehouse() != null) {
					
					oprot.WriteFieldBegin("warehouse");
					oprot.WriteString(structs.GetWarehouse());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("warehouse can not be null!");
				}
				
				
				if(structs.GetDetails() != null) {
					
					oprot.WriteFieldBegin("details");
					
					oprot.WriteListBegin();
					foreach(vipapis.overseas.Transaction _item0 in structs.GetDetails()){
						
						
						vipapis.overseas.TransactionHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("details can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(uploadTransactionDetail_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class createBatchRs_resultHelper : TBeanSerializer<createBatchRs_result>
		{
			
			public static createBatchRs_resultHelper OBJ = new createBatchRs_resultHelper();
			
			public static createBatchRs_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(createBatchRs_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.overseas.CreateBatchRsResponse value;
					
					value = new vipapis.overseas.CreateBatchRsResponse();
					vipapis.overseas.CreateBatchRsResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(createBatchRs_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.overseas.CreateBatchRsResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(createBatchRs_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class createPatch_resultHelper : TBeanSerializer<createPatch_result>
		{
			
			public static createPatch_resultHelper OBJ = new createPatch_resultHelper();
			
			public static createPatch_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(createPatch_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.overseas.CreateBatchResponse value;
					
					value = new vipapis.overseas.CreateBatchResponse();
					vipapis.overseas.CreateBatchResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(createPatch_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.overseas.CreateBatchResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(createPatch_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class deliverOrderStatus_resultHelper : TBeanSerializer<deliverOrderStatus_result>
		{
			
			public static deliverOrderStatus_resultHelper OBJ = new deliverOrderStatus_resultHelper();
			
			public static deliverOrderStatus_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(deliverOrderStatus_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					List<string> value;
					
					value = new List<string>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							string elem0;
							elem0 = iprot.ReadString();
							
							value.Add(elem0);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(deliverOrderStatus_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					oprot.WriteListBegin();
					foreach(string _item0 in structs.GetSuccess()){
						
						oprot.WriteString(_item0);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(deliverOrderStatus_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class deliverSaleOrder_resultHelper : TBeanSerializer<deliverSaleOrder_result>
		{
			
			public static deliverSaleOrder_resultHelper OBJ = new deliverSaleOrder_resultHelper();
			
			public static deliverSaleOrder_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(deliverSaleOrder_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					List<string> value;
					
					value = new List<string>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							string elem1;
							elem1 = iprot.ReadString();
							
							value.Add(elem1);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(deliverSaleOrder_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					oprot.WriteListBegin();
					foreach(string _item0 in structs.GetSuccess()){
						
						oprot.WriteString(_item0);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(deliverSaleOrder_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class get3PLPoList_resultHelper : TBeanSerializer<get3PLPoList_result>
		{
			
			public static get3PLPoList_resultHelper OBJ = new get3PLPoList_resultHelper();
			
			public static get3PLPoList_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(get3PLPoList_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.overseas.Ht3plPoListResponse value;
					
					value = new vipapis.overseas.Ht3plPoListResponse();
					vipapis.overseas.Ht3plPoListResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(get3PLPoList_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.overseas.Ht3plPoListResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(get3PLPoList_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getPoBatchList_resultHelper : TBeanSerializer<getPoBatchList_result>
		{
			
			public static getPoBatchList_resultHelper OBJ = new getPoBatchList_resultHelper();
			
			public static getPoBatchList_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getPoBatchList_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.overseas.GetPurchaseOrderBatchListResponse value;
					
					value = new vipapis.overseas.GetPurchaseOrderBatchListResponse();
					vipapis.overseas.GetPurchaseOrderBatchListResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getPoBatchList_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.overseas.GetPurchaseOrderBatchListResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getPoBatchList_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getRdcTransferForms_resultHelper : TBeanSerializer<getRdcTransferForms_result>
		{
			
			public static getRdcTransferForms_resultHelper OBJ = new getRdcTransferForms_resultHelper();
			
			public static getRdcTransferForms_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getRdcTransferForms_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					List<vipapis.overseas.RdcTransferForm> value;
					
					value = new List<vipapis.overseas.RdcTransferForm>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							vipapis.overseas.RdcTransferForm elem0;
							
							elem0 = new vipapis.overseas.RdcTransferForm();
							vipapis.overseas.RdcTransferFormHelper.getInstance().Read(elem0, iprot);
							
							value.Add(elem0);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getRdcTransferForms_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					oprot.WriteListBegin();
					foreach(vipapis.overseas.RdcTransferForm _item0 in structs.GetSuccess()){
						
						
						vipapis.overseas.RdcTransferFormHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getRdcTransferForms_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getRdcTransferFormsAck_resultHelper : TBeanSerializer<getRdcTransferFormsAck_result>
		{
			
			public static getRdcTransferFormsAck_resultHelper OBJ = new getRdcTransferFormsAck_resultHelper();
			
			public static getRdcTransferFormsAck_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getRdcTransferFormsAck_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					List<string> value;
					
					value = new List<string>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							string elem1;
							elem1 = iprot.ReadString();
							
							value.Add(elem1);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getRdcTransferFormsAck_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					oprot.WriteListBegin();
					foreach(string _item0 in structs.GetSuccess()){
						
						oprot.WriteString(_item0);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getRdcTransferFormsAck_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getReturnOrders_resultHelper : TBeanSerializer<getReturnOrders_result>
		{
			
			public static getReturnOrders_resultHelper OBJ = new getReturnOrders_resultHelper();
			
			public static getReturnOrders_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getReturnOrders_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					List<vipapis.overseas.ReturnOrder> value;
					
					value = new List<vipapis.overseas.ReturnOrder>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							vipapis.overseas.ReturnOrder elem1;
							
							elem1 = new vipapis.overseas.ReturnOrder();
							vipapis.overseas.ReturnOrderHelper.getInstance().Read(elem1, iprot);
							
							value.Add(elem1);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getReturnOrders_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					oprot.WriteListBegin();
					foreach(vipapis.overseas.ReturnOrder _item0 in structs.GetSuccess()){
						
						
						vipapis.overseas.ReturnOrderHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getReturnOrders_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getReturnOrdersAck_resultHelper : TBeanSerializer<getReturnOrdersAck_result>
		{
			
			public static getReturnOrdersAck_resultHelper OBJ = new getReturnOrdersAck_resultHelper();
			
			public static getReturnOrdersAck_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getReturnOrdersAck_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					List<string> value;
					
					value = new List<string>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							string elem1;
							elem1 = iprot.ReadString();
							
							value.Add(elem1);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getReturnOrdersAck_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					oprot.WriteListBegin();
					foreach(string _item0 in structs.GetSuccess()){
						
						oprot.WriteString(_item0);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getReturnOrdersAck_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getSaleOrders_resultHelper : TBeanSerializer<getSaleOrders_result>
		{
			
			public static getSaleOrders_resultHelper OBJ = new getSaleOrders_resultHelper();
			
			public static getSaleOrders_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getSaleOrders_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.overseas.SaleOrderResult value;
					
					value = new vipapis.overseas.SaleOrderResult();
					vipapis.overseas.SaleOrderResultHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getSaleOrders_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.overseas.SaleOrderResultHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getSaleOrders_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getTransferForms_resultHelper : TBeanSerializer<getTransferForms_result>
		{
			
			public static getTransferForms_resultHelper OBJ = new getTransferForms_resultHelper();
			
			public static getTransferForms_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getTransferForms_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					List<vipapis.overseas.TransferForm> value;
					
					value = new List<vipapis.overseas.TransferForm>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							vipapis.overseas.TransferForm elem0;
							
							elem0 = new vipapis.overseas.TransferForm();
							vipapis.overseas.TransferFormHelper.getInstance().Read(elem0, iprot);
							
							value.Add(elem0);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getTransferForms_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					oprot.WriteListBegin();
					foreach(vipapis.overseas.TransferForm _item0 in structs.GetSuccess()){
						
						
						vipapis.overseas.TransferFormHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getTransferForms_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getTransferFormsAck_resultHelper : TBeanSerializer<getTransferFormsAck_result>
		{
			
			public static getTransferFormsAck_resultHelper OBJ = new getTransferFormsAck_resultHelper();
			
			public static getTransferFormsAck_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getTransferFormsAck_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					List<string> value;
					
					value = new List<string>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							string elem1;
							elem1 = iprot.ReadString();
							
							value.Add(elem1);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getTransferFormsAck_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					oprot.WriteListBegin();
					foreach(string _item0 in structs.GetSuccess()){
						
						oprot.WriteString(_item0);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getTransferFormsAck_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class healthCheck_resultHelper : TBeanSerializer<healthCheck_result>
		{
			
			public static healthCheck_resultHelper OBJ = new healthCheck_resultHelper();
			
			public static healthCheck_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(healthCheck_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.hermes.core.health.CheckResult value;
					
					value = new com.vip.hermes.core.health.CheckResult();
					com.vip.hermes.core.health.CheckResultHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(healthCheck_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.hermes.core.health.CheckResultHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(healthCheck_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class updateCarrierStatus_resultHelper : TBeanSerializer<updateCarrierStatus_result>
		{
			
			public static updateCarrierStatus_resultHelper OBJ = new updateCarrierStatus_resultHelper();
			
			public static updateCarrierStatus_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(updateCarrierStatus_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					List<vipapis.overseas.ResultTuple> value;
					
					value = new List<vipapis.overseas.ResultTuple>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							vipapis.overseas.ResultTuple elem0;
							
							elem0 = new vipapis.overseas.ResultTuple();
							vipapis.overseas.ResultTupleHelper.getInstance().Read(elem0, iprot);
							
							value.Add(elem0);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(updateCarrierStatus_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					oprot.WriteListBegin();
					foreach(vipapis.overseas.ResultTuple _item0 in structs.GetSuccess()){
						
						
						vipapis.overseas.ResultTupleHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(updateCarrierStatus_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class updatePoBatchStatus_resultHelper : TBeanSerializer<updatePoBatchStatus_result>
		{
			
			public static updatePoBatchStatus_resultHelper OBJ = new updatePoBatchStatus_resultHelper();
			
			public static updatePoBatchStatus_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(updatePoBatchStatus_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(updatePoBatchStatus_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					oprot.WriteString(structs.GetSuccess());
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(updatePoBatchStatus_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class uploadOrderOutInfo_resultHelper : TBeanSerializer<uploadOrderOutInfo_result>
		{
			
			public static uploadOrderOutInfo_resultHelper OBJ = new uploadOrderOutInfo_resultHelper();
			
			public static uploadOrderOutInfo_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(uploadOrderOutInfo_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					List<string> value;
					
					value = new List<string>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							string elem0;
							elem0 = iprot.ReadString();
							
							value.Add(elem0);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(uploadOrderOutInfo_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					oprot.WriteListBegin();
					foreach(string _item0 in structs.GetSuccess()){
						
						oprot.WriteString(_item0);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(uploadOrderOutInfo_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class uploadRdcDeliverDetail_resultHelper : TBeanSerializer<uploadRdcDeliverDetail_result>
		{
			
			public static uploadRdcDeliverDetail_resultHelper OBJ = new uploadRdcDeliverDetail_resultHelper();
			
			public static uploadRdcDeliverDetail_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(uploadRdcDeliverDetail_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					List<string> value;
					
					value = new List<string>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							string elem1;
							elem1 = iprot.ReadString();
							
							value.Add(elem1);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(uploadRdcDeliverDetail_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					oprot.WriteListBegin();
					foreach(string _item0 in structs.GetSuccess()){
						
						oprot.WriteString(_item0);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(uploadRdcDeliverDetail_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class uploadReturnOrderStatus_resultHelper : TBeanSerializer<uploadReturnOrderStatus_result>
		{
			
			public static uploadReturnOrderStatus_resultHelper OBJ = new uploadReturnOrderStatus_resultHelper();
			
			public static uploadReturnOrderStatus_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(uploadReturnOrderStatus_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					List<string> value;
					
					value = new List<string>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							string elem1;
							elem1 = iprot.ReadString();
							
							value.Add(elem1);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(uploadReturnOrderStatus_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					oprot.WriteListBegin();
					foreach(string _item0 in structs.GetSuccess()){
						
						oprot.WriteString(_item0);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(uploadReturnOrderStatus_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class uploadReturnOutDetail_resultHelper : TBeanSerializer<uploadReturnOutDetail_result>
		{
			
			public static uploadReturnOutDetail_resultHelper OBJ = new uploadReturnOutDetail_resultHelper();
			
			public static uploadReturnOutDetail_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(uploadReturnOutDetail_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					List<string> value;
					
					value = new List<string>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							string elem1;
							elem1 = iprot.ReadString();
							
							value.Add(elem1);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(uploadReturnOutDetail_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					oprot.WriteListBegin();
					foreach(string _item0 in structs.GetSuccess()){
						
						oprot.WriteString(_item0);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(uploadReturnOutDetail_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class uploadTransactionDetail_resultHelper : TBeanSerializer<uploadTransactionDetail_result>
		{
			
			public static uploadTransactionDetail_resultHelper OBJ = new uploadTransactionDetail_resultHelper();
			
			public static uploadTransactionDetail_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(uploadTransactionDetail_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					List<string> value;
					
					value = new List<string>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							string elem1;
							elem1 = iprot.ReadString();
							
							value.Add(elem1);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(uploadTransactionDetail_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					oprot.WriteListBegin();
					foreach(string _item0 in structs.GetSuccess()){
						
						oprot.WriteString(_item0);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(uploadTransactionDetail_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class OWarehouseServiceClient : OspRestStub , OWarehouseService  {
			
			
			public OWarehouseServiceClient():base("vipapis.overseas.OWarehouseService","1.0.0") {
				
				
			}
			
			
			
			public vipapis.overseas.CreateBatchRsResponse createBatchRs(vipapis.overseas.BatchRsInfo batchRsInfo_) {
				
				send_createBatchRs(batchRsInfo_);
				return recv_createBatchRs(); 
				
			}
			
			
			private void send_createBatchRs(vipapis.overseas.BatchRsInfo batchRsInfo_){
				
				InitInvocation("createBatchRs");
				
				createBatchRs_args args = new createBatchRs_args();
				args.SetBatchRsInfo(batchRsInfo_);
				
				SendBase(args, createBatchRs_argsHelper.getInstance());
			}
			
			
			private vipapis.overseas.CreateBatchRsResponse recv_createBatchRs(){
				
				createBatchRs_result result = new createBatchRs_result();
				ReceiveBase(result, createBatchRs_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public vipapis.overseas.CreateBatchResponse createPatch(vipapis.overseas.BatchInfo batchInfo_) {
				
				send_createPatch(batchInfo_);
				return recv_createPatch(); 
				
			}
			
			
			private void send_createPatch(vipapis.overseas.BatchInfo batchInfo_){
				
				InitInvocation("createPatch");
				
				createPatch_args args = new createPatch_args();
				args.SetBatchInfo(batchInfo_);
				
				SendBase(args, createPatch_argsHelper.getInstance());
			}
			
			
			private vipapis.overseas.CreateBatchResponse recv_createPatch(){
				
				createPatch_result result = new createPatch_result();
				ReceiveBase(result, createPatch_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public List<string> deliverOrderStatus(string warehouse_,List<vipapis.overseas.OrderStatusItem> order_status_items_) {
				
				send_deliverOrderStatus(warehouse_,order_status_items_);
				return recv_deliverOrderStatus(); 
				
			}
			
			
			private void send_deliverOrderStatus(string warehouse_,List<vipapis.overseas.OrderStatusItem> order_status_items_){
				
				InitInvocation("deliverOrderStatus");
				
				deliverOrderStatus_args args = new deliverOrderStatus_args();
				args.SetWarehouse(warehouse_);
				args.SetOrder_status_items(order_status_items_);
				
				SendBase(args, deliverOrderStatus_argsHelper.getInstance());
			}
			
			
			private List<string> recv_deliverOrderStatus(){
				
				deliverOrderStatus_result result = new deliverOrderStatus_result();
				ReceiveBase(result, deliverOrderStatus_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public List<string> deliverSaleOrder(string warehouse_,List<vipapis.overseas.SaleOrders> sale_orders_) {
				
				send_deliverSaleOrder(warehouse_,sale_orders_);
				return recv_deliverSaleOrder(); 
				
			}
			
			
			private void send_deliverSaleOrder(string warehouse_,List<vipapis.overseas.SaleOrders> sale_orders_){
				
				InitInvocation("deliverSaleOrder");
				
				deliverSaleOrder_args args = new deliverSaleOrder_args();
				args.SetWarehouse(warehouse_);
				args.SetSale_orders(sale_orders_);
				
				SendBase(args, deliverSaleOrder_argsHelper.getInstance());
			}
			
			
			private List<string> recv_deliverSaleOrder(){
				
				deliverSaleOrder_result result = new deliverSaleOrder_result();
				ReceiveBase(result, deliverSaleOrder_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public vipapis.overseas.Ht3plPoListResponse get3PLPoList(vipapis.overseas.Ht3plPoListRequest request_) {
				
				send_get3PLPoList(request_);
				return recv_get3PLPoList(); 
				
			}
			
			
			private void send_get3PLPoList(vipapis.overseas.Ht3plPoListRequest request_){
				
				InitInvocation("get3PLPoList");
				
				get3PLPoList_args args = new get3PLPoList_args();
				args.SetRequest(request_);
				
				SendBase(args, get3PLPoList_argsHelper.getInstance());
			}
			
			
			private vipapis.overseas.Ht3plPoListResponse recv_get3PLPoList(){
				
				get3PLPoList_result result = new get3PLPoList_result();
				ReceiveBase(result, get3PLPoList_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public vipapis.overseas.GetPurchaseOrderBatchListResponse getPoBatchList(string warehouse_,int? start_batch_id_,int? num_,string po_no_,List<string> batch_no_list_,string vendor_code_,int? total_) {
				
				send_getPoBatchList(warehouse_,start_batch_id_,num_,po_no_,batch_no_list_,vendor_code_,total_);
				return recv_getPoBatchList(); 
				
			}
			
			
			private void send_getPoBatchList(string warehouse_,int? start_batch_id_,int? num_,string po_no_,List<string> batch_no_list_,string vendor_code_,int? total_){
				
				InitInvocation("getPoBatchList");
				
				getPoBatchList_args args = new getPoBatchList_args();
				args.SetWarehouse(warehouse_);
				args.SetStart_batch_id(start_batch_id_);
				args.SetNum(num_);
				args.SetPo_no(po_no_);
				args.SetBatch_no_list(batch_no_list_);
				args.SetVendor_code(vendor_code_);
				args.SetTotal(total_);
				
				SendBase(args, getPoBatchList_argsHelper.getInstance());
			}
			
			
			private vipapis.overseas.GetPurchaseOrderBatchListResponse recv_getPoBatchList(){
				
				getPoBatchList_result result = new getPoBatchList_result();
				ReceiveBase(result, getPoBatchList_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public List<vipapis.overseas.RdcTransferForm> getRdcTransferForms(string warehouse_,int num_) {
				
				send_getRdcTransferForms(warehouse_,num_);
				return recv_getRdcTransferForms(); 
				
			}
			
			
			private void send_getRdcTransferForms(string warehouse_,int num_){
				
				InitInvocation("getRdcTransferForms");
				
				getRdcTransferForms_args args = new getRdcTransferForms_args();
				args.SetWarehouse(warehouse_);
				args.SetNum(num_);
				
				SendBase(args, getRdcTransferForms_argsHelper.getInstance());
			}
			
			
			private List<vipapis.overseas.RdcTransferForm> recv_getRdcTransferForms(){
				
				getRdcTransferForms_result result = new getRdcTransferForms_result();
				ReceiveBase(result, getRdcTransferForms_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public List<string> getRdcTransferFormsAck(string warehouse_,List<string> rdc_ids_) {
				
				send_getRdcTransferFormsAck(warehouse_,rdc_ids_);
				return recv_getRdcTransferFormsAck(); 
				
			}
			
			
			private void send_getRdcTransferFormsAck(string warehouse_,List<string> rdc_ids_){
				
				InitInvocation("getRdcTransferFormsAck");
				
				getRdcTransferFormsAck_args args = new getRdcTransferFormsAck_args();
				args.SetWarehouse(warehouse_);
				args.SetRdc_ids(rdc_ids_);
				
				SendBase(args, getRdcTransferFormsAck_argsHelper.getInstance());
			}
			
			
			private List<string> recv_getRdcTransferFormsAck(){
				
				getRdcTransferFormsAck_result result = new getRdcTransferFormsAck_result();
				ReceiveBase(result, getRdcTransferFormsAck_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public List<vipapis.overseas.ReturnOrder> getReturnOrders(string warehouse_,int num_) {
				
				send_getReturnOrders(warehouse_,num_);
				return recv_getReturnOrders(); 
				
			}
			
			
			private void send_getReturnOrders(string warehouse_,int num_){
				
				InitInvocation("getReturnOrders");
				
				getReturnOrders_args args = new getReturnOrders_args();
				args.SetWarehouse(warehouse_);
				args.SetNum(num_);
				
				SendBase(args, getReturnOrders_argsHelper.getInstance());
			}
			
			
			private List<vipapis.overseas.ReturnOrder> recv_getReturnOrders(){
				
				getReturnOrders_result result = new getReturnOrders_result();
				ReceiveBase(result, getReturnOrders_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public List<string> getReturnOrdersAck(string warehouse_,List<string> transaction_ids_) {
				
				send_getReturnOrdersAck(warehouse_,transaction_ids_);
				return recv_getReturnOrdersAck(); 
				
			}
			
			
			private void send_getReturnOrdersAck(string warehouse_,List<string> transaction_ids_){
				
				InitInvocation("getReturnOrdersAck");
				
				getReturnOrdersAck_args args = new getReturnOrdersAck_args();
				args.SetWarehouse(warehouse_);
				args.SetTransaction_ids(transaction_ids_);
				
				SendBase(args, getReturnOrdersAck_argsHelper.getInstance());
			}
			
			
			private List<string> recv_getReturnOrdersAck(){
				
				getReturnOrdersAck_result result = new getReturnOrdersAck_result();
				ReceiveBase(result, getReturnOrdersAck_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public vipapis.overseas.SaleOrderResult getSaleOrders(string warehouse_,int num_) {
				
				send_getSaleOrders(warehouse_,num_);
				return recv_getSaleOrders(); 
				
			}
			
			
			private void send_getSaleOrders(string warehouse_,int num_){
				
				InitInvocation("getSaleOrders");
				
				getSaleOrders_args args = new getSaleOrders_args();
				args.SetWarehouse(warehouse_);
				args.SetNum(num_);
				
				SendBase(args, getSaleOrders_argsHelper.getInstance());
			}
			
			
			private vipapis.overseas.SaleOrderResult recv_getSaleOrders(){
				
				getSaleOrders_result result = new getSaleOrders_result();
				ReceiveBase(result, getSaleOrders_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public List<vipapis.overseas.TransferForm> getTransferForms(string warehouse_,int num_) {
				
				send_getTransferForms(warehouse_,num_);
				return recv_getTransferForms(); 
				
			}
			
			
			private void send_getTransferForms(string warehouse_,int num_){
				
				InitInvocation("getTransferForms");
				
				getTransferForms_args args = new getTransferForms_args();
				args.SetWarehouse(warehouse_);
				args.SetNum(num_);
				
				SendBase(args, getTransferForms_argsHelper.getInstance());
			}
			
			
			private List<vipapis.overseas.TransferForm> recv_getTransferForms(){
				
				getTransferForms_result result = new getTransferForms_result();
				ReceiveBase(result, getTransferForms_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public List<string> getTransferFormsAck(string warehouse_,List<string> transaction_ids_) {
				
				send_getTransferFormsAck(warehouse_,transaction_ids_);
				return recv_getTransferFormsAck(); 
				
			}
			
			
			private void send_getTransferFormsAck(string warehouse_,List<string> transaction_ids_){
				
				InitInvocation("getTransferFormsAck");
				
				getTransferFormsAck_args args = new getTransferFormsAck_args();
				args.SetWarehouse(warehouse_);
				args.SetTransaction_ids(transaction_ids_);
				
				SendBase(args, getTransferFormsAck_argsHelper.getInstance());
			}
			
			
			private List<string> recv_getTransferFormsAck(){
				
				getTransferFormsAck_result result = new getTransferFormsAck_result();
				ReceiveBase(result, getTransferFormsAck_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.hermes.core.health.CheckResult healthCheck() {
				
				send_healthCheck();
				return recv_healthCheck(); 
				
			}
			
			
			private void send_healthCheck(){
				
				InitInvocation("healthCheck");
				
				healthCheck_args args = new healthCheck_args();
				
				SendBase(args, healthCheck_argsHelper.getInstance());
			}
			
			
			private com.vip.hermes.core.health.CheckResult recv_healthCheck(){
				
				healthCheck_result result = new healthCheck_result();
				ReceiveBase(result, healthCheck_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public List<vipapis.overseas.ResultTuple> updateCarrierStatus(string warehouse_,vipapis.overseas.CarrierInfoRequest carrierInfoRequest_) {
				
				send_updateCarrierStatus(warehouse_,carrierInfoRequest_);
				return recv_updateCarrierStatus(); 
				
			}
			
			
			private void send_updateCarrierStatus(string warehouse_,vipapis.overseas.CarrierInfoRequest carrierInfoRequest_){
				
				InitInvocation("updateCarrierStatus");
				
				updateCarrierStatus_args args = new updateCarrierStatus_args();
				args.SetWarehouse(warehouse_);
				args.SetCarrierInfoRequest(carrierInfoRequest_);
				
				SendBase(args, updateCarrierStatus_argsHelper.getInstance());
			}
			
			
			private List<vipapis.overseas.ResultTuple> recv_updateCarrierStatus(){
				
				updateCarrierStatus_result result = new updateCarrierStatus_result();
				ReceiveBase(result, updateCarrierStatus_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public string updatePoBatchStatus(string warehouse_,List<string> batch_nos_) {
				
				send_updatePoBatchStatus(warehouse_,batch_nos_);
				return recv_updatePoBatchStatus(); 
				
			}
			
			
			private void send_updatePoBatchStatus(string warehouse_,List<string> batch_nos_){
				
				InitInvocation("updatePoBatchStatus");
				
				updatePoBatchStatus_args args = new updatePoBatchStatus_args();
				args.SetWarehouse(warehouse_);
				args.SetBatch_nos(batch_nos_);
				
				SendBase(args, updatePoBatchStatus_argsHelper.getInstance());
			}
			
			
			private string recv_updatePoBatchStatus(){
				
				updatePoBatchStatus_result result = new updatePoBatchStatus_result();
				ReceiveBase(result, updatePoBatchStatus_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public List<string> uploadOrderOutInfo(string warehouse_,vipapis.overseas.OrderOutGoodsInfo order_out_goods_info_) {
				
				send_uploadOrderOutInfo(warehouse_,order_out_goods_info_);
				return recv_uploadOrderOutInfo(); 
				
			}
			
			
			private void send_uploadOrderOutInfo(string warehouse_,vipapis.overseas.OrderOutGoodsInfo order_out_goods_info_){
				
				InitInvocation("uploadOrderOutInfo");
				
				uploadOrderOutInfo_args args = new uploadOrderOutInfo_args();
				args.SetWarehouse(warehouse_);
				args.SetOrder_out_goods_info(order_out_goods_info_);
				
				SendBase(args, uploadOrderOutInfo_argsHelper.getInstance());
			}
			
			
			private List<string> recv_uploadOrderOutInfo(){
				
				uploadOrderOutInfo_result result = new uploadOrderOutInfo_result();
				ReceiveBase(result, uploadOrderOutInfo_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public List<string> uploadRdcDeliverDetail(string warehouse_,List<vipapis.overseas.RdcDeliverDetail> details_) {
				
				send_uploadRdcDeliverDetail(warehouse_,details_);
				return recv_uploadRdcDeliverDetail(); 
				
			}
			
			
			private void send_uploadRdcDeliverDetail(string warehouse_,List<vipapis.overseas.RdcDeliverDetail> details_){
				
				InitInvocation("uploadRdcDeliverDetail");
				
				uploadRdcDeliverDetail_args args = new uploadRdcDeliverDetail_args();
				args.SetWarehouse(warehouse_);
				args.SetDetails(details_);
				
				SendBase(args, uploadRdcDeliverDetail_argsHelper.getInstance());
			}
			
			
			private List<string> recv_uploadRdcDeliverDetail(){
				
				uploadRdcDeliverDetail_result result = new uploadRdcDeliverDetail_result();
				ReceiveBase(result, uploadRdcDeliverDetail_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public List<string> uploadReturnOrderStatus(string warehouse_,List<vipapis.overseas.ReturnOrderStatus> details_) {
				
				send_uploadReturnOrderStatus(warehouse_,details_);
				return recv_uploadReturnOrderStatus(); 
				
			}
			
			
			private void send_uploadReturnOrderStatus(string warehouse_,List<vipapis.overseas.ReturnOrderStatus> details_){
				
				InitInvocation("uploadReturnOrderStatus");
				
				uploadReturnOrderStatus_args args = new uploadReturnOrderStatus_args();
				args.SetWarehouse(warehouse_);
				args.SetDetails(details_);
				
				SendBase(args, uploadReturnOrderStatus_argsHelper.getInstance());
			}
			
			
			private List<string> recv_uploadReturnOrderStatus(){
				
				uploadReturnOrderStatus_result result = new uploadReturnOrderStatus_result();
				ReceiveBase(result, uploadReturnOrderStatus_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public List<string> uploadReturnOutDetail(string warehouse_,List<vipapis.overseas.ReturnOutInfo> details_) {
				
				send_uploadReturnOutDetail(warehouse_,details_);
				return recv_uploadReturnOutDetail(); 
				
			}
			
			
			private void send_uploadReturnOutDetail(string warehouse_,List<vipapis.overseas.ReturnOutInfo> details_){
				
				InitInvocation("uploadReturnOutDetail");
				
				uploadReturnOutDetail_args args = new uploadReturnOutDetail_args();
				args.SetWarehouse(warehouse_);
				args.SetDetails(details_);
				
				SendBase(args, uploadReturnOutDetail_argsHelper.getInstance());
			}
			
			
			private List<string> recv_uploadReturnOutDetail(){
				
				uploadReturnOutDetail_result result = new uploadReturnOutDetail_result();
				ReceiveBase(result, uploadReturnOutDetail_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public List<string> uploadTransactionDetail(string warehouse_,List<vipapis.overseas.Transaction> details_) {
				
				send_uploadTransactionDetail(warehouse_,details_);
				return recv_uploadTransactionDetail(); 
				
			}
			
			
			private void send_uploadTransactionDetail(string warehouse_,List<vipapis.overseas.Transaction> details_){
				
				InitInvocation("uploadTransactionDetail");
				
				uploadTransactionDetail_args args = new uploadTransactionDetail_args();
				args.SetWarehouse(warehouse_);
				args.SetDetails(details_);
				
				SendBase(args, uploadTransactionDetail_argsHelper.getInstance());
			}
			
			
			private List<string> recv_uploadTransactionDetail(){
				
				uploadTransactionDetail_result result = new uploadTransactionDetail_result();
				ReceiveBase(result, uploadTransactionDetail_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
		}
		
		
	}
	
}