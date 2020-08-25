using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;

namespace vipapis.vlg.wms{
	
	
	public class OutWmsServiceHelper {
		
		
		
		public class callbackOrders_args {
			
			///<summary>
			/// 系统KEY
			///</summary>
			
			private string sysKey_;
			
			///<summary>
			/// 仓库编码,如:云仓代运营 HT_NBYC
			///</summary>
			
			private string warehouse_;
			
			///<summary>
			/// 请求订单号集合
			///</summary>
			
			private List<string> orderSnList_;
			
			public string GetSysKey(){
				return this.sysKey_;
			}
			
			public void SetSysKey(string value){
				this.sysKey_ = value;
			}
			public string GetWarehouse(){
				return this.warehouse_;
			}
			
			public void SetWarehouse(string value){
				this.warehouse_ = value;
			}
			public List<string> GetOrderSnList(){
				return this.orderSnList_;
			}
			
			public void SetOrderSnList(List<string> value){
				this.orderSnList_ = value;
			}
			
		}
		
		
		
		
		public class callbackOutOubShipment_args {
			
			///<summary>
			/// 系统KEY
			///</summary>
			
			private string sysKey_;
			
			///<summary>
			/// 调用方的仓库编码
			///</summary>
			
			private string warehouse_;
			
			///<summary>
			/// 订单号集合
			///</summary>
			
			private List<string> orderSns_;
			
			public string GetSysKey(){
				return this.sysKey_;
			}
			
			public void SetSysKey(string value){
				this.sysKey_ = value;
			}
			public string GetWarehouse(){
				return this.warehouse_;
			}
			
			public void SetWarehouse(string value){
				this.warehouse_ = value;
			}
			public List<string> GetOrderSns(){
				return this.orderSns_;
			}
			
			public void SetOrderSns(List<string> value){
				this.orderSns_ = value;
			}
			
		}
		
		
		
		
		public class callbackOutZcodeApplys_args {
			
			///<summary>
			/// 系统KEY
			///</summary>
			
			private string sysKey_;
			
			///<summary>
			/// 调用方的仓库编码
			///</summary>
			
			private string warehouse_;
			
			///<summary>
			/// 申请号集合
			///</summary>
			
			private List<string> appNums_;
			
			public string GetSysKey(){
				return this.sysKey_;
			}
			
			public void SetSysKey(string value){
				this.sysKey_ = value;
			}
			public string GetWarehouse(){
				return this.warehouse_;
			}
			
			public void SetWarehouse(string value){
				this.warehouse_ = value;
			}
			public List<string> GetAppNums(){
				return this.appNums_;
			}
			
			public void SetAppNums(List<string> value){
				this.appNums_ = value;
			}
			
		}
		
		
		
		
		public class callbackReturnOrders_args {
			
			///<summary>
			/// 系统KEY
			///</summary>
			
			private string sysKey_;
			
			///<summary>
			/// 调用方的仓库编码
			///</summary>
			
			private string warehouse_;
			
			///<summary>
			/// 流水ID集合
			///</summary>
			
			private List<string> ids_;
			
			public string GetSysKey(){
				return this.sysKey_;
			}
			
			public void SetSysKey(string value){
				this.sysKey_ = value;
			}
			public string GetWarehouse(){
				return this.warehouse_;
			}
			
			public void SetWarehouse(string value){
				this.warehouse_ = value;
			}
			public List<string> GetIds(){
				return this.ids_;
			}
			
			public void SetIds(List<string> value){
				this.ids_ = value;
			}
			
		}
		
		
		
		
		public class deliverOrderContainer_args {
			
			///<summary>
			/// 系统KEY
			///</summary>
			
			private string sysKey_;
			
			///<summary>
			/// 海外仓仓库编码
			///</summary>
			
			private string warehouse_;
			
			///<summary>
			/// 订单出仓通知
			///</summary>
			
			private List<com.vip.sce.vlg.osp.wms.service.OrderContainer> orders_;
			
			public string GetSysKey(){
				return this.sysKey_;
			}
			
			public void SetSysKey(string value){
				this.sysKey_ = value;
			}
			public string GetWarehouse(){
				return this.warehouse_;
			}
			
			public void SetWarehouse(string value){
				this.warehouse_ = value;
			}
			public List<com.vip.sce.vlg.osp.wms.service.OrderContainer> GetOrders(){
				return this.orders_;
			}
			
			public void SetOrders(List<com.vip.sce.vlg.osp.wms.service.OrderContainer> value){
				this.orders_ = value;
			}
			
		}
		
		
		
		
		public class deliverSaleOrder_args {
			
			///<summary>
			/// 系统KEY
			///</summary>
			
			private string sysKey_;
			
			///<summary>
			/// 海外仓仓库编码
			///</summary>
			
			private string warehouse_;
			
			///<summary>
			/// 订单列表
			///</summary>
			
			private List<com.vip.sce.vlg.osp.wms.service.SaleOrders> sale_orders_;
			
			public string GetSysKey(){
				return this.sysKey_;
			}
			
			public void SetSysKey(string value){
				this.sysKey_ = value;
			}
			public string GetWarehouse(){
				return this.warehouse_;
			}
			
			public void SetWarehouse(string value){
				this.warehouse_ = value;
			}
			public List<com.vip.sce.vlg.osp.wms.service.SaleOrders> GetSale_orders(){
				return this.sale_orders_;
			}
			
			public void SetSale_orders(List<com.vip.sce.vlg.osp.wms.service.SaleOrders> value){
				this.sale_orders_ = value;
			}
			
		}
		
		
		
		
		public class getGlobalDeliverBatch_args {
			
			///<summary>
			/// 系统KEY
			///</summary>
			
			private string sysKey_;
			
			///<summary>
			/// 仓库编码
			///</summary>
			
			private string warehouse_;
			
			///<summary>
			/// 国际发货批次订单列表
			///</summary>
			
			private com.vip.sce.vlg.osp.wms.service.OutWmsGlobalDeliverBatchParam globalDeliverBatchInfo_;
			
			public string GetSysKey(){
				return this.sysKey_;
			}
			
			public void SetSysKey(string value){
				this.sysKey_ = value;
			}
			public string GetWarehouse(){
				return this.warehouse_;
			}
			
			public void SetWarehouse(string value){
				this.warehouse_ = value;
			}
			public com.vip.sce.vlg.osp.wms.service.OutWmsGlobalDeliverBatchParam GetGlobalDeliverBatchInfo(){
				return this.globalDeliverBatchInfo_;
			}
			
			public void SetGlobalDeliverBatchInfo(com.vip.sce.vlg.osp.wms.service.OutWmsGlobalDeliverBatchParam value){
				this.globalDeliverBatchInfo_ = value;
			}
			
		}
		
		
		
		
		public class getOrders_args {
			
			///<summary>
			/// 系统KEY
			///</summary>
			
			private string sysKey_;
			
			///<summary>
			/// 仓库编码
			///</summary>
			
			private string warehouse_;
			
			///<summary>
			/// 请求订单号集合,最大单次查询数为100
			///</summary>
			
			private List<string> orderSnList_;
			
			///<summary>
			/// 数量,最大单次查询数为100
			///</summary>
			
			private int? num_;
			
			public string GetSysKey(){
				return this.sysKey_;
			}
			
			public void SetSysKey(string value){
				this.sysKey_ = value;
			}
			public string GetWarehouse(){
				return this.warehouse_;
			}
			
			public void SetWarehouse(string value){
				this.warehouse_ = value;
			}
			public List<string> GetOrderSnList(){
				return this.orderSnList_;
			}
			
			public void SetOrderSnList(List<string> value){
				this.orderSnList_ = value;
			}
			public int? GetNum(){
				return this.num_;
			}
			
			public void SetNum(int? value){
				this.num_ = value;
			}
			
		}
		
		
		
		
		public class getOutOubShipments_args {
			
			///<summary>
			/// 系统KEY
			///</summary>
			
			private string sysKey_;
			
			///<summary>
			/// 调用方的仓库编码
			///</summary>
			
			private string warehouse_;
			
			///<summary>
			/// 请求数据条数，默认：200，最大2000条
			///</summary>
			
			private int? pageSize_;
			
			public string GetSysKey(){
				return this.sysKey_;
			}
			
			public void SetSysKey(string value){
				this.sysKey_ = value;
			}
			public string GetWarehouse(){
				return this.warehouse_;
			}
			
			public void SetWarehouse(string value){
				this.warehouse_ = value;
			}
			public int? GetPageSize(){
				return this.pageSize_;
			}
			
			public void SetPageSize(int? value){
				this.pageSize_ = value;
			}
			
		}
		
		
		
		
		public class getOutWmsPackageTransferOrders_args {
			
			///<summary>
			/// 系统KEY
			///</summary>
			
			private string sysKey_;
			
			///<summary>
			/// 仓库编码
			///</summary>
			
			private string warehouse_;
			
			///<summary>
			/// 货代编号
			///</summary>
			
			private string carrierCode_;
			
			///<summary>
			/// 海关编号
			///</summary>
			
			private string customsCode_;
			
			///<summary>
			/// 订单列表
			///</summary>
			
			private List<com.vip.sce.vlg.osp.wms.service.OrdersVo> orders_;
			
			public string GetSysKey(){
				return this.sysKey_;
			}
			
			public void SetSysKey(string value){
				this.sysKey_ = value;
			}
			public string GetWarehouse(){
				return this.warehouse_;
			}
			
			public void SetWarehouse(string value){
				this.warehouse_ = value;
			}
			public string GetCarrierCode(){
				return this.carrierCode_;
			}
			
			public void SetCarrierCode(string value){
				this.carrierCode_ = value;
			}
			public string GetCustomsCode(){
				return this.customsCode_;
			}
			
			public void SetCustomsCode(string value){
				this.customsCode_ = value;
			}
			public List<com.vip.sce.vlg.osp.wms.service.OrdersVo> GetOrders(){
				return this.orders_;
			}
			
			public void SetOrders(List<com.vip.sce.vlg.osp.wms.service.OrdersVo> value){
				this.orders_ = value;
			}
			
		}
		
		
		
		
		public class getOutZcodeApplys_args {
			
			///<summary>
			/// 系统KEY
			///</summary>
			
			private string sysKey_;
			
			///<summary>
			/// 调用方的仓库编码
			///</summary>
			
			private string warehouse_;
			
			///<summary>
			/// 请求数据条数，默认：200，最大2000条
			///</summary>
			
			private int? pageSize_;
			
			public string GetSysKey(){
				return this.sysKey_;
			}
			
			public void SetSysKey(string value){
				this.sysKey_ = value;
			}
			public string GetWarehouse(){
				return this.warehouse_;
			}
			
			public void SetWarehouse(string value){
				this.warehouse_ = value;
			}
			public int? GetPageSize(){
				return this.pageSize_;
			}
			
			public void SetPageSize(int? value){
				this.pageSize_ = value;
			}
			
		}
		
		
		
		
		public class getPoBatchList_args {
			
			///<summary>
			/// 系统KEY
			///</summary>
			
			private string sysKey_;
			
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
			
			public string GetSysKey(){
				return this.sysKey_;
			}
			
			public void SetSysKey(string value){
				this.sysKey_ = value;
			}
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
		
		
		
		
		public class getReturnOrders_args {
			
			///<summary>
			/// 系统KEY
			///</summary>
			
			private string sysKey_;
			
			///<summary>
			/// 调用方的仓库编码
			///</summary>
			
			private string warehouse_;
			
			///<summary>
			/// 请求数据条数，默认：200，最大2000条
			///</summary>
			
			private int? num_;
			
			public string GetSysKey(){
				return this.sysKey_;
			}
			
			public void SetSysKey(string value){
				this.sysKey_ = value;
			}
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
		
		
		
		
		public class getTransferLadingBillS_args {
			
			///<summary>
			/// 系统KEY
			///</summary>
			
			private string sysKey_;
			
			///<summary>
			/// 仓库
			///</summary>
			
			private string warehouse_;
			
			///<summary>
			/// 提单信息
			///</summary>
			
			private com.vip.sce.vlg.osp.wms.service.OutWmsLadingBillIDLParam requestParam_;
			
			public string GetSysKey(){
				return this.sysKey_;
			}
			
			public void SetSysKey(string value){
				this.sysKey_ = value;
			}
			public string GetWarehouse(){
				return this.warehouse_;
			}
			
			public void SetWarehouse(string value){
				this.warehouse_ = value;
			}
			public com.vip.sce.vlg.osp.wms.service.OutWmsLadingBillIDLParam GetRequestParam(){
				return this.requestParam_;
			}
			
			public void SetRequestParam(com.vip.sce.vlg.osp.wms.service.OutWmsLadingBillIDLParam value){
				this.requestParam_ = value;
			}
			
		}
		
		
		
		
		public class healthCheck_args {
			
			
		}
		
		
		
		
		public class pushOrderStatusList_args {
			
			///<summary>
			/// 系统KEY
			///</summary>
			
			private string sysKey_;
			
			///<summary>
			/// 调用方的仓库编码
			///</summary>
			
			private string warehouse_;
			
			///<summary>
			/// 订单仓库作业状态
			///</summary>
			
			private List<com.vip.sce.vlg.osp.wms.service.OspOutWmsOrderStatusSModel> order_status_detail_list_;
			
			public string GetSysKey(){
				return this.sysKey_;
			}
			
			public void SetSysKey(string value){
				this.sysKey_ = value;
			}
			public string GetWarehouse(){
				return this.warehouse_;
			}
			
			public void SetWarehouse(string value){
				this.warehouse_ = value;
			}
			public List<com.vip.sce.vlg.osp.wms.service.OspOutWmsOrderStatusSModel> GetOrder_status_detail_list(){
				return this.order_status_detail_list_;
			}
			
			public void SetOrder_status_detail_list(List<com.vip.sce.vlg.osp.wms.service.OspOutWmsOrderStatusSModel> value){
				this.order_status_detail_list_ = value;
			}
			
		}
		
		
		
		
		public class pushOutInbShipment_args {
			
			///<summary>
			/// 系统KEY
			///</summary>
			
			private string sysKey_;
			
			///<summary>
			/// 调用方的仓库编码
			///</summary>
			
			private string warehouse_;
			
			///<summary>
			/// 入仓批次信息
			///</summary>
			
			private com.vip.sce.vlg.osp.wms.service.OutInbShipmentInfo outInbShipmentInfo_;
			
			public string GetSysKey(){
				return this.sysKey_;
			}
			
			public void SetSysKey(string value){
				this.sysKey_ = value;
			}
			public string GetWarehouse(){
				return this.warehouse_;
			}
			
			public void SetWarehouse(string value){
				this.warehouse_ = value;
			}
			public com.vip.sce.vlg.osp.wms.service.OutInbShipmentInfo GetOutInbShipmentInfo(){
				return this.outInbShipmentInfo_;
			}
			
			public void SetOutInbShipmentInfo(com.vip.sce.vlg.osp.wms.service.OutInbShipmentInfo value){
				this.outInbShipmentInfo_ = value;
			}
			
		}
		
		
		
		
		public class pushOutWmsOrderBatch_args {
			
			///<summary>
			/// 系统KEY
			///</summary>
			
			private string sysKey_;
			
			///<summary>
			/// 调用方的仓库编码
			///</summary>
			
			private string warehouse_;
			
			///<summary>
			/// vip大仓仓库编码
			///</summary>
			
			private string warehouseCode_;
			
			///<summary>
			/// 入仓批次信息
			///</summary>
			
			private List<com.vip.sce.vlg.osp.wms.service.OrderBatchInfo> orderBatchInfos_;
			
			public string GetSysKey(){
				return this.sysKey_;
			}
			
			public void SetSysKey(string value){
				this.sysKey_ = value;
			}
			public string GetWarehouse(){
				return this.warehouse_;
			}
			
			public void SetWarehouse(string value){
				this.warehouse_ = value;
			}
			public string GetWarehouseCode(){
				return this.warehouseCode_;
			}
			
			public void SetWarehouseCode(string value){
				this.warehouseCode_ = value;
			}
			public List<com.vip.sce.vlg.osp.wms.service.OrderBatchInfo> GetOrderBatchInfos(){
				return this.orderBatchInfos_;
			}
			
			public void SetOrderBatchInfos(List<com.vip.sce.vlg.osp.wms.service.OrderBatchInfo> value){
				this.orderBatchInfos_ = value;
			}
			
		}
		
		
		
		
		public class pushOutZcode_args {
			
			///<summary>
			/// 系统KEY
			///</summary>
			
			private string sysKey_;
			
			///<summary>
			/// 调用方的仓库编码
			///</summary>
			
			private string warehouse_;
			
			///<summary>
			/// 真知码下发信息
			///</summary>
			
			private com.vip.sce.vlg.osp.wms.service.OutWmsZcodeInfo outWmsZcodeInfo_;
			
			public string GetSysKey(){
				return this.sysKey_;
			}
			
			public void SetSysKey(string value){
				this.sysKey_ = value;
			}
			public string GetWarehouse(){
				return this.warehouse_;
			}
			
			public void SetWarehouse(string value){
				this.warehouse_ = value;
			}
			public com.vip.sce.vlg.osp.wms.service.OutWmsZcodeInfo GetOutWmsZcodeInfo(){
				return this.outWmsZcodeInfo_;
			}
			
			public void SetOutWmsZcodeInfo(com.vip.sce.vlg.osp.wms.service.OutWmsZcodeInfo value){
				this.outWmsZcodeInfo_ = value;
			}
			
		}
		
		
		
		
		public class updateCarrierStatus_args {
			
			///<summary>
			/// 系统KEY
			///</summary>
			
			private string sysKey_;
			
			///<summary>
			/// 海外仓仓库编码
			///</summary>
			
			private string warehouse_;
			
			///<summary>
			/// 国外订单物流明细状态
			///</summary>
			
			private com.vip.sce.vlg.osp.wms.service.CarrierInfoRequest carrierInfoRequest_;
			
			public string GetSysKey(){
				return this.sysKey_;
			}
			
			public void SetSysKey(string value){
				this.sysKey_ = value;
			}
			public string GetWarehouse(){
				return this.warehouse_;
			}
			
			public void SetWarehouse(string value){
				this.warehouse_ = value;
			}
			public com.vip.sce.vlg.osp.wms.service.CarrierInfoRequest GetCarrierInfoRequest(){
				return this.carrierInfoRequest_;
			}
			
			public void SetCarrierInfoRequest(com.vip.sce.vlg.osp.wms.service.CarrierInfoRequest value){
				this.carrierInfoRequest_ = value;
			}
			
		}
		
		
		
		
		public class updatePoBatchStatus_args {
			
			///<summary>
			/// 系统KEY
			///</summary>
			
			private string sysKey_;
			
			///<summary>
			/// 调用方的仓库编码
			///</summary>
			
			private string warehouse_;
			
			///<summary>
			/// 批次号列表，每次请求不能超过100个批次号
			///</summary>
			
			private List<string> batch_nos_;
			
			public string GetSysKey(){
				return this.sysKey_;
			}
			
			public void SetSysKey(string value){
				this.sysKey_ = value;
			}
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
		
		
		
		
		public class uploadInvAdjustment_args {
			
			///<summary>
			/// 系统KEY
			///</summary>
			
			private string sysKey_;
			
			///<summary>
			/// 海外仓仓库编码
			///</summary>
			
			private string warehouse_;
			
			///<summary>
			/// 库存信息
			///</summary>
			
			private List<com.vip.sce.vlg.osp.wms.service.InvAdjustment> invAdjustments_;
			
			public string GetSysKey(){
				return this.sysKey_;
			}
			
			public void SetSysKey(string value){
				this.sysKey_ = value;
			}
			public string GetWarehouse(){
				return this.warehouse_;
			}
			
			public void SetWarehouse(string value){
				this.warehouse_ = value;
			}
			public List<com.vip.sce.vlg.osp.wms.service.InvAdjustment> GetInvAdjustments(){
				return this.invAdjustments_;
			}
			
			public void SetInvAdjustments(List<com.vip.sce.vlg.osp.wms.service.InvAdjustment> value){
				this.invAdjustments_ = value;
			}
			
		}
		
		
		
		
		public class uploadReturnOrderStatus_args {
			
			///<summary>
			/// 系统KEY
			///</summary>
			
			private string sysKey_;
			
			///<summary>
			/// 调用方的仓库编码
			///</summary>
			
			private string warehouse_;
			
			///<summary>
			/// 出仓明细列表
			///</summary>
			
			private List<com.vip.sce.vlg.osp.wms.service.ReturnOrderStatus> details_;
			
			public string GetSysKey(){
				return this.sysKey_;
			}
			
			public void SetSysKey(string value){
				this.sysKey_ = value;
			}
			public string GetWarehouse(){
				return this.warehouse_;
			}
			
			public void SetWarehouse(string value){
				this.warehouse_ = value;
			}
			public List<com.vip.sce.vlg.osp.wms.service.ReturnOrderStatus> GetDetails(){
				return this.details_;
			}
			
			public void SetDetails(List<com.vip.sce.vlg.osp.wms.service.ReturnOrderStatus> value){
				this.details_ = value;
			}
			
		}
		
		
		
		
		public class uploadReturnOutDetail_args {
			
			///<summary>
			/// 系统KEY
			///</summary>
			
			private string sysKey_;
			
			///<summary>
			/// 调用方的仓库编码
			///</summary>
			
			private string warehouse_;
			
			///<summary>
			/// 出仓明细列表
			///</summary>
			
			private List<com.vip.sce.vlg.osp.wms.service.ReturnOutInfo> details_;
			
			public string GetSysKey(){
				return this.sysKey_;
			}
			
			public void SetSysKey(string value){
				this.sysKey_ = value;
			}
			public string GetWarehouse(){
				return this.warehouse_;
			}
			
			public void SetWarehouse(string value){
				this.warehouse_ = value;
			}
			public List<com.vip.sce.vlg.osp.wms.service.ReturnOutInfo> GetDetails(){
				return this.details_;
			}
			
			public void SetDetails(List<com.vip.sce.vlg.osp.wms.service.ReturnOutInfo> value){
				this.details_ = value;
			}
			
		}
		
		
		
		
		public class callbackOrders_result {
			
			///<summary>
			///</summary>
			
			private com.vip.sce.vlg.osp.wms.service.PostResponse success_;
			
			public com.vip.sce.vlg.osp.wms.service.PostResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.sce.vlg.osp.wms.service.PostResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class callbackOutOubShipment_result {
			
			///<summary>
			///</summary>
			
			private com.vip.sce.vlg.osp.wms.service.PostResponse success_;
			
			public com.vip.sce.vlg.osp.wms.service.PostResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.sce.vlg.osp.wms.service.PostResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class callbackOutZcodeApplys_result {
			
			///<summary>
			///</summary>
			
			private com.vip.sce.vlg.osp.wms.service.PostResponse success_;
			
			public com.vip.sce.vlg.osp.wms.service.PostResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.sce.vlg.osp.wms.service.PostResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class callbackReturnOrders_result {
			
			///<summary>
			///</summary>
			
			private com.vip.sce.vlg.osp.wms.service.PostResponse success_;
			
			public com.vip.sce.vlg.osp.wms.service.PostResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.sce.vlg.osp.wms.service.PostResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class deliverOrderContainer_result {
			
			///<summary>
			///</summary>
			
			private com.vip.sce.vlg.osp.wms.service.PostResponse success_;
			
			public com.vip.sce.vlg.osp.wms.service.PostResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.sce.vlg.osp.wms.service.PostResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class deliverSaleOrder_result {
			
			///<summary>
			///</summary>
			
			private com.vip.sce.vlg.osp.wms.service.PostResponse success_;
			
			public com.vip.sce.vlg.osp.wms.service.PostResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.sce.vlg.osp.wms.service.PostResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getGlobalDeliverBatch_result {
			
			///<summary>
			///</summary>
			
			private com.vip.sce.vlg.osp.wms.service.PostResponse success_;
			
			public com.vip.sce.vlg.osp.wms.service.PostResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.sce.vlg.osp.wms.service.PostResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getOrders_result {
			
			///<summary>
			///</summary>
			
			private com.vip.sce.vlg.osp.wms.service.OutWmsOrderGetHeaderResponse success_;
			
			public com.vip.sce.vlg.osp.wms.service.OutWmsOrderGetHeaderResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.sce.vlg.osp.wms.service.OutWmsOrderGetHeaderResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getOutOubShipments_result {
			
			///<summary>
			///</summary>
			
			private com.vip.sce.vlg.osp.wms.service.GetOutWmsOubShipmentResponse success_;
			
			public com.vip.sce.vlg.osp.wms.service.GetOutWmsOubShipmentResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.sce.vlg.osp.wms.service.GetOutWmsOubShipmentResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getOutWmsPackageTransferOrders_result {
			
			///<summary>
			///</summary>
			
			private com.vip.sce.vlg.osp.wms.service.PostResponse success_;
			
			public com.vip.sce.vlg.osp.wms.service.PostResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.sce.vlg.osp.wms.service.PostResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getOutZcodeApplys_result {
			
			///<summary>
			///</summary>
			
			private com.vip.sce.vlg.osp.wms.service.GetOutWmsZcodeApplyResponse success_;
			
			public com.vip.sce.vlg.osp.wms.service.GetOutWmsZcodeApplyResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.sce.vlg.osp.wms.service.GetOutWmsZcodeApplyResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getPoBatchList_result {
			
			///<summary>
			///</summary>
			
			private com.vip.sce.vlg.osp.wms.service.OspOutWmsPoGetHeaderResponse success_;
			
			public com.vip.sce.vlg.osp.wms.service.OspOutWmsPoGetHeaderResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.sce.vlg.osp.wms.service.OspOutWmsPoGetHeaderResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getReturnOrders_result {
			
			///<summary>
			///</summary>
			
			private com.vip.sce.vlg.osp.wms.service.OutWmsReturnOrderHeaderResponse success_;
			
			public com.vip.sce.vlg.osp.wms.service.OutWmsReturnOrderHeaderResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.sce.vlg.osp.wms.service.OutWmsReturnOrderHeaderResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getTransferLadingBillS_result {
			
			///<summary>
			///</summary>
			
			private com.vip.sce.vlg.osp.wms.service.PostResponse success_;
			
			public com.vip.sce.vlg.osp.wms.service.PostResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.sce.vlg.osp.wms.service.PostResponse value){
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
		
		
		
		
		public class pushOrderStatusList_result {
			
			///<summary>
			///</summary>
			
			private com.vip.sce.vlg.osp.wms.service.PostResponse success_;
			
			public com.vip.sce.vlg.osp.wms.service.PostResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.sce.vlg.osp.wms.service.PostResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class pushOutInbShipment_result {
			
			///<summary>
			///</summary>
			
			private com.vip.sce.vlg.osp.wms.service.PostResponse success_;
			
			public com.vip.sce.vlg.osp.wms.service.PostResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.sce.vlg.osp.wms.service.PostResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class pushOutWmsOrderBatch_result {
			
			///<summary>
			///</summary>
			
			private com.vip.sce.vlg.osp.wms.service.PostResponse success_;
			
			public com.vip.sce.vlg.osp.wms.service.PostResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.sce.vlg.osp.wms.service.PostResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class pushOutZcode_result {
			
			///<summary>
			///</summary>
			
			private com.vip.sce.vlg.osp.wms.service.PostResponse success_;
			
			public com.vip.sce.vlg.osp.wms.service.PostResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.sce.vlg.osp.wms.service.PostResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class updateCarrierStatus_result {
			
			///<summary>
			///</summary>
			
			private com.vip.sce.vlg.osp.wms.service.PostResponse success_;
			
			public com.vip.sce.vlg.osp.wms.service.PostResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.sce.vlg.osp.wms.service.PostResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class updatePoBatchStatus_result {
			
			///<summary>
			///</summary>
			
			private com.vip.sce.vlg.osp.wms.service.PostResponse success_;
			
			public com.vip.sce.vlg.osp.wms.service.PostResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.sce.vlg.osp.wms.service.PostResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class uploadInvAdjustment_result {
			
			///<summary>
			///</summary>
			
			private com.vip.sce.vlg.osp.wms.service.PostResponse success_;
			
			public com.vip.sce.vlg.osp.wms.service.PostResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.sce.vlg.osp.wms.service.PostResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class uploadReturnOrderStatus_result {
			
			///<summary>
			///</summary>
			
			private com.vip.sce.vlg.osp.wms.service.PostResponse success_;
			
			public com.vip.sce.vlg.osp.wms.service.PostResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.sce.vlg.osp.wms.service.PostResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class uploadReturnOutDetail_result {
			
			///<summary>
			///</summary>
			
			private com.vip.sce.vlg.osp.wms.service.PostResponse success_;
			
			public com.vip.sce.vlg.osp.wms.service.PostResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.sce.vlg.osp.wms.service.PostResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		
		public class callbackOrders_argsHelper : TBeanSerializer<callbackOrders_args>
		{
			
			public static callbackOrders_argsHelper OBJ = new callbackOrders_argsHelper();
			
			public static callbackOrders_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(callbackOrders_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetSysKey(value);
				}
				
				
				
				
				
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
					
					structs.SetOrderSnList(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(callbackOrders_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSysKey() != null) {
					
					oprot.WriteFieldBegin("sysKey");
					oprot.WriteString(structs.GetSysKey());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("sysKey can not be null!");
				}
				
				
				if(structs.GetWarehouse() != null) {
					
					oprot.WriteFieldBegin("warehouse");
					oprot.WriteString(structs.GetWarehouse());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("warehouse can not be null!");
				}
				
				
				if(structs.GetOrderSnList() != null) {
					
					oprot.WriteFieldBegin("orderSnList");
					
					oprot.WriteListBegin();
					foreach(string _item0 in structs.GetOrderSnList()){
						
						oprot.WriteString(_item0);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("orderSnList can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(callbackOrders_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class callbackOutOubShipment_argsHelper : TBeanSerializer<callbackOutOubShipment_args>
		{
			
			public static callbackOutOubShipment_argsHelper OBJ = new callbackOutOubShipment_argsHelper();
			
			public static callbackOutOubShipment_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(callbackOutOubShipment_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetSysKey(value);
				}
				
				
				
				
				
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
							
							string elem1;
							elem1 = iprot.ReadString();
							
							value.Add(elem1);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetOrderSns(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(callbackOutOubShipment_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSysKey() != null) {
					
					oprot.WriteFieldBegin("sysKey");
					oprot.WriteString(structs.GetSysKey());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("sysKey can not be null!");
				}
				
				
				if(structs.GetWarehouse() != null) {
					
					oprot.WriteFieldBegin("warehouse");
					oprot.WriteString(structs.GetWarehouse());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("warehouse can not be null!");
				}
				
				
				if(structs.GetOrderSns() != null) {
					
					oprot.WriteFieldBegin("orderSns");
					
					oprot.WriteListBegin();
					foreach(string _item0 in structs.GetOrderSns()){
						
						oprot.WriteString(_item0);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("orderSns can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(callbackOutOubShipment_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class callbackOutZcodeApplys_argsHelper : TBeanSerializer<callbackOutZcodeApplys_args>
		{
			
			public static callbackOutZcodeApplys_argsHelper OBJ = new callbackOutZcodeApplys_argsHelper();
			
			public static callbackOutZcodeApplys_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(callbackOutZcodeApplys_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetSysKey(value);
				}
				
				
				
				
				
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
							
							string elem1;
							elem1 = iprot.ReadString();
							
							value.Add(elem1);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetAppNums(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(callbackOutZcodeApplys_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSysKey() != null) {
					
					oprot.WriteFieldBegin("sysKey");
					oprot.WriteString(structs.GetSysKey());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("sysKey can not be null!");
				}
				
				
				if(structs.GetWarehouse() != null) {
					
					oprot.WriteFieldBegin("warehouse");
					oprot.WriteString(structs.GetWarehouse());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("warehouse can not be null!");
				}
				
				
				if(structs.GetAppNums() != null) {
					
					oprot.WriteFieldBegin("appNums");
					
					oprot.WriteListBegin();
					foreach(string _item0 in structs.GetAppNums()){
						
						oprot.WriteString(_item0);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("appNums can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(callbackOutZcodeApplys_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class callbackReturnOrders_argsHelper : TBeanSerializer<callbackReturnOrders_args>
		{
			
			public static callbackReturnOrders_argsHelper OBJ = new callbackReturnOrders_argsHelper();
			
			public static callbackReturnOrders_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(callbackReturnOrders_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetSysKey(value);
				}
				
				
				
				
				
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
							
							string elem1;
							elem1 = iprot.ReadString();
							
							value.Add(elem1);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetIds(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(callbackReturnOrders_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSysKey() != null) {
					
					oprot.WriteFieldBegin("sysKey");
					oprot.WriteString(structs.GetSysKey());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("sysKey can not be null!");
				}
				
				
				if(structs.GetWarehouse() != null) {
					
					oprot.WriteFieldBegin("warehouse");
					oprot.WriteString(structs.GetWarehouse());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("warehouse can not be null!");
				}
				
				
				if(structs.GetIds() != null) {
					
					oprot.WriteFieldBegin("ids");
					
					oprot.WriteListBegin();
					foreach(string _item0 in structs.GetIds()){
						
						oprot.WriteString(_item0);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("ids can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(callbackReturnOrders_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class deliverOrderContainer_argsHelper : TBeanSerializer<deliverOrderContainer_args>
		{
			
			public static deliverOrderContainer_argsHelper OBJ = new deliverOrderContainer_argsHelper();
			
			public static deliverOrderContainer_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(deliverOrderContainer_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetSysKey(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetWarehouse(value);
				}
				
				
				
				
				
				if(true){
					
					List<com.vip.sce.vlg.osp.wms.service.OrderContainer> value;
					
					value = new List<com.vip.sce.vlg.osp.wms.service.OrderContainer>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							com.vip.sce.vlg.osp.wms.service.OrderContainer elem1;
							
							elem1 = new com.vip.sce.vlg.osp.wms.service.OrderContainer();
							com.vip.sce.vlg.osp.wms.service.OrderContainerHelper.getInstance().Read(elem1, iprot);
							
							value.Add(elem1);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetOrders(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(deliverOrderContainer_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSysKey() != null) {
					
					oprot.WriteFieldBegin("sysKey");
					oprot.WriteString(structs.GetSysKey());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("sysKey can not be null!");
				}
				
				
				if(structs.GetWarehouse() != null) {
					
					oprot.WriteFieldBegin("warehouse");
					oprot.WriteString(structs.GetWarehouse());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("warehouse can not be null!");
				}
				
				
				if(structs.GetOrders() != null) {
					
					oprot.WriteFieldBegin("orders");
					
					oprot.WriteListBegin();
					foreach(com.vip.sce.vlg.osp.wms.service.OrderContainer _item0 in structs.GetOrders()){
						
						
						com.vip.sce.vlg.osp.wms.service.OrderContainerHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("orders can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(deliverOrderContainer_args bean){
				
				
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
					
					structs.SetSysKey(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetWarehouse(value);
				}
				
				
				
				
				
				if(true){
					
					List<com.vip.sce.vlg.osp.wms.service.SaleOrders> value;
					
					value = new List<com.vip.sce.vlg.osp.wms.service.SaleOrders>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							com.vip.sce.vlg.osp.wms.service.SaleOrders elem1;
							
							elem1 = new com.vip.sce.vlg.osp.wms.service.SaleOrders();
							com.vip.sce.vlg.osp.wms.service.SaleOrdersHelper.getInstance().Read(elem1, iprot);
							
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
				
				if(structs.GetSysKey() != null) {
					
					oprot.WriteFieldBegin("sysKey");
					oprot.WriteString(structs.GetSysKey());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("sysKey can not be null!");
				}
				
				
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
					foreach(com.vip.sce.vlg.osp.wms.service.SaleOrders _item0 in structs.GetSale_orders()){
						
						
						com.vip.sce.vlg.osp.wms.service.SaleOrdersHelper.getInstance().Write(_item0, oprot);
						
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
		
		
		
		
		public class getGlobalDeliverBatch_argsHelper : TBeanSerializer<getGlobalDeliverBatch_args>
		{
			
			public static getGlobalDeliverBatch_argsHelper OBJ = new getGlobalDeliverBatch_argsHelper();
			
			public static getGlobalDeliverBatch_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getGlobalDeliverBatch_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetSysKey(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetWarehouse(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.sce.vlg.osp.wms.service.OutWmsGlobalDeliverBatchParam value;
					
					value = new com.vip.sce.vlg.osp.wms.service.OutWmsGlobalDeliverBatchParam();
					com.vip.sce.vlg.osp.wms.service.OutWmsGlobalDeliverBatchParamHelper.getInstance().Read(value, iprot);
					
					structs.SetGlobalDeliverBatchInfo(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getGlobalDeliverBatch_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSysKey() != null) {
					
					oprot.WriteFieldBegin("sysKey");
					oprot.WriteString(structs.GetSysKey());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("sysKey can not be null!");
				}
				
				
				if(structs.GetWarehouse() != null) {
					
					oprot.WriteFieldBegin("warehouse");
					oprot.WriteString(structs.GetWarehouse());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("warehouse can not be null!");
				}
				
				
				if(structs.GetGlobalDeliverBatchInfo() != null) {
					
					oprot.WriteFieldBegin("globalDeliverBatchInfo");
					
					com.vip.sce.vlg.osp.wms.service.OutWmsGlobalDeliverBatchParamHelper.getInstance().Write(structs.GetGlobalDeliverBatchInfo(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("globalDeliverBatchInfo can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getGlobalDeliverBatch_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getOrders_argsHelper : TBeanSerializer<getOrders_args>
		{
			
			public static getOrders_argsHelper OBJ = new getOrders_argsHelper();
			
			public static getOrders_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getOrders_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetSysKey(value);
				}
				
				
				
				
				
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
					
					structs.SetOrderSnList(value);
				}
				
				
				
				
				
				if(true){
					
					int? value;
					value = iprot.ReadI32(); 
					
					structs.SetNum(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getOrders_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSysKey() != null) {
					
					oprot.WriteFieldBegin("sysKey");
					oprot.WriteString(structs.GetSysKey());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("sysKey can not be null!");
				}
				
				
				if(structs.GetWarehouse() != null) {
					
					oprot.WriteFieldBegin("warehouse");
					oprot.WriteString(structs.GetWarehouse());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("warehouse can not be null!");
				}
				
				
				if(structs.GetOrderSnList() != null) {
					
					oprot.WriteFieldBegin("orderSnList");
					
					oprot.WriteListBegin();
					foreach(string _item0 in structs.GetOrderSnList()){
						
						oprot.WriteString(_item0);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetNum() != null) {
					
					oprot.WriteFieldBegin("num");
					oprot.WriteI32((int)structs.GetNum()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getOrders_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getOutOubShipments_argsHelper : TBeanSerializer<getOutOubShipments_args>
		{
			
			public static getOutOubShipments_argsHelper OBJ = new getOutOubShipments_argsHelper();
			
			public static getOutOubShipments_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getOutOubShipments_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetSysKey(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetWarehouse(value);
				}
				
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetPageSize(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getOutOubShipments_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSysKey() != null) {
					
					oprot.WriteFieldBegin("sysKey");
					oprot.WriteString(structs.GetSysKey());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("sysKey can not be null!");
				}
				
				
				if(structs.GetWarehouse() != null) {
					
					oprot.WriteFieldBegin("warehouse");
					oprot.WriteString(structs.GetWarehouse());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("warehouse can not be null!");
				}
				
				
				if(structs.GetPageSize() != null) {
					
					oprot.WriteFieldBegin("pageSize");
					oprot.WriteI32((int)structs.GetPageSize()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("pageSize can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getOutOubShipments_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getOutWmsPackageTransferOrders_argsHelper : TBeanSerializer<getOutWmsPackageTransferOrders_args>
		{
			
			public static getOutWmsPackageTransferOrders_argsHelper OBJ = new getOutWmsPackageTransferOrders_argsHelper();
			
			public static getOutWmsPackageTransferOrders_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getOutWmsPackageTransferOrders_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetSysKey(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetWarehouse(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetCarrierCode(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetCustomsCode(value);
				}
				
				
				
				
				
				if(true){
					
					List<com.vip.sce.vlg.osp.wms.service.OrdersVo> value;
					
					value = new List<com.vip.sce.vlg.osp.wms.service.OrdersVo>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							com.vip.sce.vlg.osp.wms.service.OrdersVo elem0;
							
							elem0 = new com.vip.sce.vlg.osp.wms.service.OrdersVo();
							com.vip.sce.vlg.osp.wms.service.OrdersVoHelper.getInstance().Read(elem0, iprot);
							
							value.Add(elem0);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetOrders(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getOutWmsPackageTransferOrders_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSysKey() != null) {
					
					oprot.WriteFieldBegin("sysKey");
					oprot.WriteString(structs.GetSysKey());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("sysKey can not be null!");
				}
				
				
				if(structs.GetWarehouse() != null) {
					
					oprot.WriteFieldBegin("warehouse");
					oprot.WriteString(structs.GetWarehouse());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("warehouse can not be null!");
				}
				
				
				if(structs.GetCarrierCode() != null) {
					
					oprot.WriteFieldBegin("carrierCode");
					oprot.WriteString(structs.GetCarrierCode());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("carrierCode can not be null!");
				}
				
				
				if(structs.GetCustomsCode() != null) {
					
					oprot.WriteFieldBegin("customsCode");
					oprot.WriteString(structs.GetCustomsCode());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("customsCode can not be null!");
				}
				
				
				if(structs.GetOrders() != null) {
					
					oprot.WriteFieldBegin("orders");
					
					oprot.WriteListBegin();
					foreach(com.vip.sce.vlg.osp.wms.service.OrdersVo _item0 in structs.GetOrders()){
						
						
						com.vip.sce.vlg.osp.wms.service.OrdersVoHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("orders can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getOutWmsPackageTransferOrders_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getOutZcodeApplys_argsHelper : TBeanSerializer<getOutZcodeApplys_args>
		{
			
			public static getOutZcodeApplys_argsHelper OBJ = new getOutZcodeApplys_argsHelper();
			
			public static getOutZcodeApplys_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getOutZcodeApplys_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetSysKey(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetWarehouse(value);
				}
				
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetPageSize(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getOutZcodeApplys_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSysKey() != null) {
					
					oprot.WriteFieldBegin("sysKey");
					oprot.WriteString(structs.GetSysKey());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("sysKey can not be null!");
				}
				
				
				if(structs.GetWarehouse() != null) {
					
					oprot.WriteFieldBegin("warehouse");
					oprot.WriteString(structs.GetWarehouse());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("warehouse can not be null!");
				}
				
				
				if(structs.GetPageSize() != null) {
					
					oprot.WriteFieldBegin("pageSize");
					oprot.WriteI32((int)structs.GetPageSize()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("pageSize can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getOutZcodeApplys_args bean){
				
				
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
					
					structs.SetSysKey(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetWarehouse(value);
				}
				
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetStart_batch_id(value);
				}
				
				
				
				
				
				if(true){
					
					int value;
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
				
				if(structs.GetSysKey() != null) {
					
					oprot.WriteFieldBegin("sysKey");
					oprot.WriteString(structs.GetSysKey());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("sysKey can not be null!");
				}
				
				
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
				
				else{
					throw new ArgumentException("start_batch_id can not be null!");
				}
				
				
				if(structs.GetNum() != null) {
					
					oprot.WriteFieldBegin("num");
					oprot.WriteI32((int)structs.GetNum()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("num can not be null!");
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
					
					structs.SetSysKey(value);
				}
				
				
				
				
				
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
				
				if(structs.GetSysKey() != null) {
					
					oprot.WriteFieldBegin("sysKey");
					oprot.WriteString(structs.GetSysKey());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("sysKey can not be null!");
				}
				
				
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
		
		
		
		
		public class getTransferLadingBillS_argsHelper : TBeanSerializer<getTransferLadingBillS_args>
		{
			
			public static getTransferLadingBillS_argsHelper OBJ = new getTransferLadingBillS_argsHelper();
			
			public static getTransferLadingBillS_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getTransferLadingBillS_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetSysKey(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetWarehouse(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.sce.vlg.osp.wms.service.OutWmsLadingBillIDLParam value;
					
					value = new com.vip.sce.vlg.osp.wms.service.OutWmsLadingBillIDLParam();
					com.vip.sce.vlg.osp.wms.service.OutWmsLadingBillIDLParamHelper.getInstance().Read(value, iprot);
					
					structs.SetRequestParam(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getTransferLadingBillS_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSysKey() != null) {
					
					oprot.WriteFieldBegin("sysKey");
					oprot.WriteString(structs.GetSysKey());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("sysKey can not be null!");
				}
				
				
				if(structs.GetWarehouse() != null) {
					
					oprot.WriteFieldBegin("warehouse");
					oprot.WriteString(structs.GetWarehouse());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("warehouse can not be null!");
				}
				
				
				if(structs.GetRequestParam() != null) {
					
					oprot.WriteFieldBegin("requestParam");
					
					com.vip.sce.vlg.osp.wms.service.OutWmsLadingBillIDLParamHelper.getInstance().Write(structs.GetRequestParam(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("requestParam can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getTransferLadingBillS_args bean){
				
				
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
		
		
		
		
		public class pushOrderStatusList_argsHelper : TBeanSerializer<pushOrderStatusList_args>
		{
			
			public static pushOrderStatusList_argsHelper OBJ = new pushOrderStatusList_argsHelper();
			
			public static pushOrderStatusList_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(pushOrderStatusList_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetSysKey(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetWarehouse(value);
				}
				
				
				
				
				
				if(true){
					
					List<com.vip.sce.vlg.osp.wms.service.OspOutWmsOrderStatusSModel> value;
					
					value = new List<com.vip.sce.vlg.osp.wms.service.OspOutWmsOrderStatusSModel>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							com.vip.sce.vlg.osp.wms.service.OspOutWmsOrderStatusSModel elem0;
							
							elem0 = new com.vip.sce.vlg.osp.wms.service.OspOutWmsOrderStatusSModel();
							com.vip.sce.vlg.osp.wms.service.OspOutWmsOrderStatusSModelHelper.getInstance().Read(elem0, iprot);
							
							value.Add(elem0);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetOrder_status_detail_list(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(pushOrderStatusList_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSysKey() != null) {
					
					oprot.WriteFieldBegin("sysKey");
					oprot.WriteString(structs.GetSysKey());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("sysKey can not be null!");
				}
				
				
				if(structs.GetWarehouse() != null) {
					
					oprot.WriteFieldBegin("warehouse");
					oprot.WriteString(structs.GetWarehouse());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("warehouse can not be null!");
				}
				
				
				if(structs.GetOrder_status_detail_list() != null) {
					
					oprot.WriteFieldBegin("order_status_detail_list");
					
					oprot.WriteListBegin();
					foreach(com.vip.sce.vlg.osp.wms.service.OspOutWmsOrderStatusSModel _item0 in structs.GetOrder_status_detail_list()){
						
						
						com.vip.sce.vlg.osp.wms.service.OspOutWmsOrderStatusSModelHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("order_status_detail_list can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(pushOrderStatusList_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class pushOutInbShipment_argsHelper : TBeanSerializer<pushOutInbShipment_args>
		{
			
			public static pushOutInbShipment_argsHelper OBJ = new pushOutInbShipment_argsHelper();
			
			public static pushOutInbShipment_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(pushOutInbShipment_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetSysKey(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetWarehouse(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.sce.vlg.osp.wms.service.OutInbShipmentInfo value;
					
					value = new com.vip.sce.vlg.osp.wms.service.OutInbShipmentInfo();
					com.vip.sce.vlg.osp.wms.service.OutInbShipmentInfoHelper.getInstance().Read(value, iprot);
					
					structs.SetOutInbShipmentInfo(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(pushOutInbShipment_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSysKey() != null) {
					
					oprot.WriteFieldBegin("sysKey");
					oprot.WriteString(structs.GetSysKey());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("sysKey can not be null!");
				}
				
				
				if(structs.GetWarehouse() != null) {
					
					oprot.WriteFieldBegin("warehouse");
					oprot.WriteString(structs.GetWarehouse());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("warehouse can not be null!");
				}
				
				
				if(structs.GetOutInbShipmentInfo() != null) {
					
					oprot.WriteFieldBegin("outInbShipmentInfo");
					
					com.vip.sce.vlg.osp.wms.service.OutInbShipmentInfoHelper.getInstance().Write(structs.GetOutInbShipmentInfo(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("outInbShipmentInfo can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(pushOutInbShipment_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class pushOutWmsOrderBatch_argsHelper : TBeanSerializer<pushOutWmsOrderBatch_args>
		{
			
			public static pushOutWmsOrderBatch_argsHelper OBJ = new pushOutWmsOrderBatch_argsHelper();
			
			public static pushOutWmsOrderBatch_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(pushOutWmsOrderBatch_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetSysKey(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetWarehouse(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetWarehouseCode(value);
				}
				
				
				
				
				
				if(true){
					
					List<com.vip.sce.vlg.osp.wms.service.OrderBatchInfo> value;
					
					value = new List<com.vip.sce.vlg.osp.wms.service.OrderBatchInfo>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							com.vip.sce.vlg.osp.wms.service.OrderBatchInfo elem0;
							
							elem0 = new com.vip.sce.vlg.osp.wms.service.OrderBatchInfo();
							com.vip.sce.vlg.osp.wms.service.OrderBatchInfoHelper.getInstance().Read(elem0, iprot);
							
							value.Add(elem0);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetOrderBatchInfos(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(pushOutWmsOrderBatch_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSysKey() != null) {
					
					oprot.WriteFieldBegin("sysKey");
					oprot.WriteString(structs.GetSysKey());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("sysKey can not be null!");
				}
				
				
				if(structs.GetWarehouse() != null) {
					
					oprot.WriteFieldBegin("warehouse");
					oprot.WriteString(structs.GetWarehouse());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("warehouse can not be null!");
				}
				
				
				if(structs.GetWarehouseCode() != null) {
					
					oprot.WriteFieldBegin("warehouseCode");
					oprot.WriteString(structs.GetWarehouseCode());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetOrderBatchInfos() != null) {
					
					oprot.WriteFieldBegin("orderBatchInfos");
					
					oprot.WriteListBegin();
					foreach(com.vip.sce.vlg.osp.wms.service.OrderBatchInfo _item0 in structs.GetOrderBatchInfos()){
						
						
						com.vip.sce.vlg.osp.wms.service.OrderBatchInfoHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("orderBatchInfos can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(pushOutWmsOrderBatch_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class pushOutZcode_argsHelper : TBeanSerializer<pushOutZcode_args>
		{
			
			public static pushOutZcode_argsHelper OBJ = new pushOutZcode_argsHelper();
			
			public static pushOutZcode_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(pushOutZcode_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetSysKey(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetWarehouse(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.sce.vlg.osp.wms.service.OutWmsZcodeInfo value;
					
					value = new com.vip.sce.vlg.osp.wms.service.OutWmsZcodeInfo();
					com.vip.sce.vlg.osp.wms.service.OutWmsZcodeInfoHelper.getInstance().Read(value, iprot);
					
					structs.SetOutWmsZcodeInfo(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(pushOutZcode_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSysKey() != null) {
					
					oprot.WriteFieldBegin("sysKey");
					oprot.WriteString(structs.GetSysKey());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("sysKey can not be null!");
				}
				
				
				if(structs.GetWarehouse() != null) {
					
					oprot.WriteFieldBegin("warehouse");
					oprot.WriteString(structs.GetWarehouse());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("warehouse can not be null!");
				}
				
				
				if(structs.GetOutWmsZcodeInfo() != null) {
					
					oprot.WriteFieldBegin("outWmsZcodeInfo");
					
					com.vip.sce.vlg.osp.wms.service.OutWmsZcodeInfoHelper.getInstance().Write(structs.GetOutWmsZcodeInfo(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("outWmsZcodeInfo can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(pushOutZcode_args bean){
				
				
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
					
					structs.SetSysKey(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetWarehouse(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.sce.vlg.osp.wms.service.CarrierInfoRequest value;
					
					value = new com.vip.sce.vlg.osp.wms.service.CarrierInfoRequest();
					com.vip.sce.vlg.osp.wms.service.CarrierInfoRequestHelper.getInstance().Read(value, iprot);
					
					structs.SetCarrierInfoRequest(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(updateCarrierStatus_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSysKey() != null) {
					
					oprot.WriteFieldBegin("sysKey");
					oprot.WriteString(structs.GetSysKey());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("sysKey can not be null!");
				}
				
				
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
					
					com.vip.sce.vlg.osp.wms.service.CarrierInfoRequestHelper.getInstance().Write(structs.GetCarrierInfoRequest(), oprot);
					
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
					
					structs.SetSysKey(value);
				}
				
				
				
				
				
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
				
				if(structs.GetSysKey() != null) {
					
					oprot.WriteFieldBegin("sysKey");
					oprot.WriteString(structs.GetSysKey());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("sysKey can not be null!");
				}
				
				
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
		
		
		
		
		public class uploadInvAdjustment_argsHelper : TBeanSerializer<uploadInvAdjustment_args>
		{
			
			public static uploadInvAdjustment_argsHelper OBJ = new uploadInvAdjustment_argsHelper();
			
			public static uploadInvAdjustment_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(uploadInvAdjustment_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetSysKey(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetWarehouse(value);
				}
				
				
				
				
				
				if(true){
					
					List<com.vip.sce.vlg.osp.wms.service.InvAdjustment> value;
					
					value = new List<com.vip.sce.vlg.osp.wms.service.InvAdjustment>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							com.vip.sce.vlg.osp.wms.service.InvAdjustment elem1;
							
							elem1 = new com.vip.sce.vlg.osp.wms.service.InvAdjustment();
							com.vip.sce.vlg.osp.wms.service.InvAdjustmentHelper.getInstance().Read(elem1, iprot);
							
							value.Add(elem1);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetInvAdjustments(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(uploadInvAdjustment_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSysKey() != null) {
					
					oprot.WriteFieldBegin("sysKey");
					oprot.WriteString(structs.GetSysKey());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("sysKey can not be null!");
				}
				
				
				if(structs.GetWarehouse() != null) {
					
					oprot.WriteFieldBegin("warehouse");
					oprot.WriteString(structs.GetWarehouse());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("warehouse can not be null!");
				}
				
				
				if(structs.GetInvAdjustments() != null) {
					
					oprot.WriteFieldBegin("invAdjustments");
					
					oprot.WriteListBegin();
					foreach(com.vip.sce.vlg.osp.wms.service.InvAdjustment _item0 in structs.GetInvAdjustments()){
						
						
						com.vip.sce.vlg.osp.wms.service.InvAdjustmentHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("invAdjustments can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(uploadInvAdjustment_args bean){
				
				
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
					
					structs.SetSysKey(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetWarehouse(value);
				}
				
				
				
				
				
				if(true){
					
					List<com.vip.sce.vlg.osp.wms.service.ReturnOrderStatus> value;
					
					value = new List<com.vip.sce.vlg.osp.wms.service.ReturnOrderStatus>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							com.vip.sce.vlg.osp.wms.service.ReturnOrderStatus elem1;
							
							elem1 = new com.vip.sce.vlg.osp.wms.service.ReturnOrderStatus();
							com.vip.sce.vlg.osp.wms.service.ReturnOrderStatusHelper.getInstance().Read(elem1, iprot);
							
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
				
				if(structs.GetSysKey() != null) {
					
					oprot.WriteFieldBegin("sysKey");
					oprot.WriteString(structs.GetSysKey());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("sysKey can not be null!");
				}
				
				
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
					foreach(com.vip.sce.vlg.osp.wms.service.ReturnOrderStatus _item0 in structs.GetDetails()){
						
						
						com.vip.sce.vlg.osp.wms.service.ReturnOrderStatusHelper.getInstance().Write(_item0, oprot);
						
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
					
					structs.SetSysKey(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetWarehouse(value);
				}
				
				
				
				
				
				if(true){
					
					List<com.vip.sce.vlg.osp.wms.service.ReturnOutInfo> value;
					
					value = new List<com.vip.sce.vlg.osp.wms.service.ReturnOutInfo>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							com.vip.sce.vlg.osp.wms.service.ReturnOutInfo elem1;
							
							elem1 = new com.vip.sce.vlg.osp.wms.service.ReturnOutInfo();
							com.vip.sce.vlg.osp.wms.service.ReturnOutInfoHelper.getInstance().Read(elem1, iprot);
							
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
				
				if(structs.GetSysKey() != null) {
					
					oprot.WriteFieldBegin("sysKey");
					oprot.WriteString(structs.GetSysKey());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("sysKey can not be null!");
				}
				
				
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
					foreach(com.vip.sce.vlg.osp.wms.service.ReturnOutInfo _item0 in structs.GetDetails()){
						
						
						com.vip.sce.vlg.osp.wms.service.ReturnOutInfoHelper.getInstance().Write(_item0, oprot);
						
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
		
		
		
		
		public class callbackOrders_resultHelper : TBeanSerializer<callbackOrders_result>
		{
			
			public static callbackOrders_resultHelper OBJ = new callbackOrders_resultHelper();
			
			public static callbackOrders_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(callbackOrders_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.sce.vlg.osp.wms.service.PostResponse value;
					
					value = new com.vip.sce.vlg.osp.wms.service.PostResponse();
					com.vip.sce.vlg.osp.wms.service.PostResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(callbackOrders_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.sce.vlg.osp.wms.service.PostResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(callbackOrders_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class callbackOutOubShipment_resultHelper : TBeanSerializer<callbackOutOubShipment_result>
		{
			
			public static callbackOutOubShipment_resultHelper OBJ = new callbackOutOubShipment_resultHelper();
			
			public static callbackOutOubShipment_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(callbackOutOubShipment_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.sce.vlg.osp.wms.service.PostResponse value;
					
					value = new com.vip.sce.vlg.osp.wms.service.PostResponse();
					com.vip.sce.vlg.osp.wms.service.PostResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(callbackOutOubShipment_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.sce.vlg.osp.wms.service.PostResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(callbackOutOubShipment_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class callbackOutZcodeApplys_resultHelper : TBeanSerializer<callbackOutZcodeApplys_result>
		{
			
			public static callbackOutZcodeApplys_resultHelper OBJ = new callbackOutZcodeApplys_resultHelper();
			
			public static callbackOutZcodeApplys_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(callbackOutZcodeApplys_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.sce.vlg.osp.wms.service.PostResponse value;
					
					value = new com.vip.sce.vlg.osp.wms.service.PostResponse();
					com.vip.sce.vlg.osp.wms.service.PostResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(callbackOutZcodeApplys_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.sce.vlg.osp.wms.service.PostResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(callbackOutZcodeApplys_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class callbackReturnOrders_resultHelper : TBeanSerializer<callbackReturnOrders_result>
		{
			
			public static callbackReturnOrders_resultHelper OBJ = new callbackReturnOrders_resultHelper();
			
			public static callbackReturnOrders_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(callbackReturnOrders_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.sce.vlg.osp.wms.service.PostResponse value;
					
					value = new com.vip.sce.vlg.osp.wms.service.PostResponse();
					com.vip.sce.vlg.osp.wms.service.PostResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(callbackReturnOrders_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.sce.vlg.osp.wms.service.PostResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(callbackReturnOrders_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class deliverOrderContainer_resultHelper : TBeanSerializer<deliverOrderContainer_result>
		{
			
			public static deliverOrderContainer_resultHelper OBJ = new deliverOrderContainer_resultHelper();
			
			public static deliverOrderContainer_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(deliverOrderContainer_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.sce.vlg.osp.wms.service.PostResponse value;
					
					value = new com.vip.sce.vlg.osp.wms.service.PostResponse();
					com.vip.sce.vlg.osp.wms.service.PostResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(deliverOrderContainer_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.sce.vlg.osp.wms.service.PostResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(deliverOrderContainer_result bean){
				
				
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
					
					com.vip.sce.vlg.osp.wms.service.PostResponse value;
					
					value = new com.vip.sce.vlg.osp.wms.service.PostResponse();
					com.vip.sce.vlg.osp.wms.service.PostResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(deliverSaleOrder_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.sce.vlg.osp.wms.service.PostResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(deliverSaleOrder_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getGlobalDeliverBatch_resultHelper : TBeanSerializer<getGlobalDeliverBatch_result>
		{
			
			public static getGlobalDeliverBatch_resultHelper OBJ = new getGlobalDeliverBatch_resultHelper();
			
			public static getGlobalDeliverBatch_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getGlobalDeliverBatch_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.sce.vlg.osp.wms.service.PostResponse value;
					
					value = new com.vip.sce.vlg.osp.wms.service.PostResponse();
					com.vip.sce.vlg.osp.wms.service.PostResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getGlobalDeliverBatch_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.sce.vlg.osp.wms.service.PostResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getGlobalDeliverBatch_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getOrders_resultHelper : TBeanSerializer<getOrders_result>
		{
			
			public static getOrders_resultHelper OBJ = new getOrders_resultHelper();
			
			public static getOrders_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getOrders_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.sce.vlg.osp.wms.service.OutWmsOrderGetHeaderResponse value;
					
					value = new com.vip.sce.vlg.osp.wms.service.OutWmsOrderGetHeaderResponse();
					com.vip.sce.vlg.osp.wms.service.OutWmsOrderGetHeaderResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getOrders_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.sce.vlg.osp.wms.service.OutWmsOrderGetHeaderResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getOrders_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getOutOubShipments_resultHelper : TBeanSerializer<getOutOubShipments_result>
		{
			
			public static getOutOubShipments_resultHelper OBJ = new getOutOubShipments_resultHelper();
			
			public static getOutOubShipments_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getOutOubShipments_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.sce.vlg.osp.wms.service.GetOutWmsOubShipmentResponse value;
					
					value = new com.vip.sce.vlg.osp.wms.service.GetOutWmsOubShipmentResponse();
					com.vip.sce.vlg.osp.wms.service.GetOutWmsOubShipmentResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getOutOubShipments_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.sce.vlg.osp.wms.service.GetOutWmsOubShipmentResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getOutOubShipments_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getOutWmsPackageTransferOrders_resultHelper : TBeanSerializer<getOutWmsPackageTransferOrders_result>
		{
			
			public static getOutWmsPackageTransferOrders_resultHelper OBJ = new getOutWmsPackageTransferOrders_resultHelper();
			
			public static getOutWmsPackageTransferOrders_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getOutWmsPackageTransferOrders_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.sce.vlg.osp.wms.service.PostResponse value;
					
					value = new com.vip.sce.vlg.osp.wms.service.PostResponse();
					com.vip.sce.vlg.osp.wms.service.PostResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getOutWmsPackageTransferOrders_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.sce.vlg.osp.wms.service.PostResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getOutWmsPackageTransferOrders_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getOutZcodeApplys_resultHelper : TBeanSerializer<getOutZcodeApplys_result>
		{
			
			public static getOutZcodeApplys_resultHelper OBJ = new getOutZcodeApplys_resultHelper();
			
			public static getOutZcodeApplys_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getOutZcodeApplys_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.sce.vlg.osp.wms.service.GetOutWmsZcodeApplyResponse value;
					
					value = new com.vip.sce.vlg.osp.wms.service.GetOutWmsZcodeApplyResponse();
					com.vip.sce.vlg.osp.wms.service.GetOutWmsZcodeApplyResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getOutZcodeApplys_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.sce.vlg.osp.wms.service.GetOutWmsZcodeApplyResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getOutZcodeApplys_result bean){
				
				
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
					
					com.vip.sce.vlg.osp.wms.service.OspOutWmsPoGetHeaderResponse value;
					
					value = new com.vip.sce.vlg.osp.wms.service.OspOutWmsPoGetHeaderResponse();
					com.vip.sce.vlg.osp.wms.service.OspOutWmsPoGetHeaderResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getPoBatchList_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.sce.vlg.osp.wms.service.OspOutWmsPoGetHeaderResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getPoBatchList_result bean){
				
				
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
					
					com.vip.sce.vlg.osp.wms.service.OutWmsReturnOrderHeaderResponse value;
					
					value = new com.vip.sce.vlg.osp.wms.service.OutWmsReturnOrderHeaderResponse();
					com.vip.sce.vlg.osp.wms.service.OutWmsReturnOrderHeaderResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getReturnOrders_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.sce.vlg.osp.wms.service.OutWmsReturnOrderHeaderResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getReturnOrders_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getTransferLadingBillS_resultHelper : TBeanSerializer<getTransferLadingBillS_result>
		{
			
			public static getTransferLadingBillS_resultHelper OBJ = new getTransferLadingBillS_resultHelper();
			
			public static getTransferLadingBillS_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getTransferLadingBillS_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.sce.vlg.osp.wms.service.PostResponse value;
					
					value = new com.vip.sce.vlg.osp.wms.service.PostResponse();
					com.vip.sce.vlg.osp.wms.service.PostResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getTransferLadingBillS_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.sce.vlg.osp.wms.service.PostResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getTransferLadingBillS_result bean){
				
				
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
		
		
		
		
		public class pushOrderStatusList_resultHelper : TBeanSerializer<pushOrderStatusList_result>
		{
			
			public static pushOrderStatusList_resultHelper OBJ = new pushOrderStatusList_resultHelper();
			
			public static pushOrderStatusList_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(pushOrderStatusList_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.sce.vlg.osp.wms.service.PostResponse value;
					
					value = new com.vip.sce.vlg.osp.wms.service.PostResponse();
					com.vip.sce.vlg.osp.wms.service.PostResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(pushOrderStatusList_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.sce.vlg.osp.wms.service.PostResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(pushOrderStatusList_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class pushOutInbShipment_resultHelper : TBeanSerializer<pushOutInbShipment_result>
		{
			
			public static pushOutInbShipment_resultHelper OBJ = new pushOutInbShipment_resultHelper();
			
			public static pushOutInbShipment_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(pushOutInbShipment_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.sce.vlg.osp.wms.service.PostResponse value;
					
					value = new com.vip.sce.vlg.osp.wms.service.PostResponse();
					com.vip.sce.vlg.osp.wms.service.PostResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(pushOutInbShipment_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.sce.vlg.osp.wms.service.PostResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(pushOutInbShipment_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class pushOutWmsOrderBatch_resultHelper : TBeanSerializer<pushOutWmsOrderBatch_result>
		{
			
			public static pushOutWmsOrderBatch_resultHelper OBJ = new pushOutWmsOrderBatch_resultHelper();
			
			public static pushOutWmsOrderBatch_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(pushOutWmsOrderBatch_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.sce.vlg.osp.wms.service.PostResponse value;
					
					value = new com.vip.sce.vlg.osp.wms.service.PostResponse();
					com.vip.sce.vlg.osp.wms.service.PostResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(pushOutWmsOrderBatch_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.sce.vlg.osp.wms.service.PostResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(pushOutWmsOrderBatch_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class pushOutZcode_resultHelper : TBeanSerializer<pushOutZcode_result>
		{
			
			public static pushOutZcode_resultHelper OBJ = new pushOutZcode_resultHelper();
			
			public static pushOutZcode_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(pushOutZcode_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.sce.vlg.osp.wms.service.PostResponse value;
					
					value = new com.vip.sce.vlg.osp.wms.service.PostResponse();
					com.vip.sce.vlg.osp.wms.service.PostResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(pushOutZcode_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.sce.vlg.osp.wms.service.PostResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(pushOutZcode_result bean){
				
				
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
					
					com.vip.sce.vlg.osp.wms.service.PostResponse value;
					
					value = new com.vip.sce.vlg.osp.wms.service.PostResponse();
					com.vip.sce.vlg.osp.wms.service.PostResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(updateCarrierStatus_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.sce.vlg.osp.wms.service.PostResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
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
					
					com.vip.sce.vlg.osp.wms.service.PostResponse value;
					
					value = new com.vip.sce.vlg.osp.wms.service.PostResponse();
					com.vip.sce.vlg.osp.wms.service.PostResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(updatePoBatchStatus_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.sce.vlg.osp.wms.service.PostResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(updatePoBatchStatus_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class uploadInvAdjustment_resultHelper : TBeanSerializer<uploadInvAdjustment_result>
		{
			
			public static uploadInvAdjustment_resultHelper OBJ = new uploadInvAdjustment_resultHelper();
			
			public static uploadInvAdjustment_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(uploadInvAdjustment_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.sce.vlg.osp.wms.service.PostResponse value;
					
					value = new com.vip.sce.vlg.osp.wms.service.PostResponse();
					com.vip.sce.vlg.osp.wms.service.PostResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(uploadInvAdjustment_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.sce.vlg.osp.wms.service.PostResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(uploadInvAdjustment_result bean){
				
				
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
					
					com.vip.sce.vlg.osp.wms.service.PostResponse value;
					
					value = new com.vip.sce.vlg.osp.wms.service.PostResponse();
					com.vip.sce.vlg.osp.wms.service.PostResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(uploadReturnOrderStatus_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.sce.vlg.osp.wms.service.PostResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
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
					
					com.vip.sce.vlg.osp.wms.service.PostResponse value;
					
					value = new com.vip.sce.vlg.osp.wms.service.PostResponse();
					com.vip.sce.vlg.osp.wms.service.PostResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(uploadReturnOutDetail_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.sce.vlg.osp.wms.service.PostResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(uploadReturnOutDetail_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class OutWmsServiceClient : OspRestStub , OutWmsService  {
			
			
			public OutWmsServiceClient():base("vipapis.vlg.wms.OutWmsService","1.0.0") {
				
				
			}
			
			
			
			public com.vip.sce.vlg.osp.wms.service.PostResponse callbackOrders(string sysKey_,string warehouse_,List<string> orderSnList_) {
				
				send_callbackOrders(sysKey_,warehouse_,orderSnList_);
				return recv_callbackOrders(); 
				
			}
			
			
			private void send_callbackOrders(string sysKey_,string warehouse_,List<string> orderSnList_){
				
				InitInvocation("callbackOrders");
				
				callbackOrders_args args = new callbackOrders_args();
				args.SetSysKey(sysKey_);
				args.SetWarehouse(warehouse_);
				args.SetOrderSnList(orderSnList_);
				
				SendBase(args, callbackOrders_argsHelper.getInstance());
			}
			
			
			private com.vip.sce.vlg.osp.wms.service.PostResponse recv_callbackOrders(){
				
				callbackOrders_result result = new callbackOrders_result();
				ReceiveBase(result, callbackOrders_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.sce.vlg.osp.wms.service.PostResponse callbackOutOubShipment(string sysKey_,string warehouse_,List<string> orderSns_) {
				
				send_callbackOutOubShipment(sysKey_,warehouse_,orderSns_);
				return recv_callbackOutOubShipment(); 
				
			}
			
			
			private void send_callbackOutOubShipment(string sysKey_,string warehouse_,List<string> orderSns_){
				
				InitInvocation("callbackOutOubShipment");
				
				callbackOutOubShipment_args args = new callbackOutOubShipment_args();
				args.SetSysKey(sysKey_);
				args.SetWarehouse(warehouse_);
				args.SetOrderSns(orderSns_);
				
				SendBase(args, callbackOutOubShipment_argsHelper.getInstance());
			}
			
			
			private com.vip.sce.vlg.osp.wms.service.PostResponse recv_callbackOutOubShipment(){
				
				callbackOutOubShipment_result result = new callbackOutOubShipment_result();
				ReceiveBase(result, callbackOutOubShipment_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.sce.vlg.osp.wms.service.PostResponse callbackOutZcodeApplys(string sysKey_,string warehouse_,List<string> appNums_) {
				
				send_callbackOutZcodeApplys(sysKey_,warehouse_,appNums_);
				return recv_callbackOutZcodeApplys(); 
				
			}
			
			
			private void send_callbackOutZcodeApplys(string sysKey_,string warehouse_,List<string> appNums_){
				
				InitInvocation("callbackOutZcodeApplys");
				
				callbackOutZcodeApplys_args args = new callbackOutZcodeApplys_args();
				args.SetSysKey(sysKey_);
				args.SetWarehouse(warehouse_);
				args.SetAppNums(appNums_);
				
				SendBase(args, callbackOutZcodeApplys_argsHelper.getInstance());
			}
			
			
			private com.vip.sce.vlg.osp.wms.service.PostResponse recv_callbackOutZcodeApplys(){
				
				callbackOutZcodeApplys_result result = new callbackOutZcodeApplys_result();
				ReceiveBase(result, callbackOutZcodeApplys_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.sce.vlg.osp.wms.service.PostResponse callbackReturnOrders(string sysKey_,string warehouse_,List<string> ids_) {
				
				send_callbackReturnOrders(sysKey_,warehouse_,ids_);
				return recv_callbackReturnOrders(); 
				
			}
			
			
			private void send_callbackReturnOrders(string sysKey_,string warehouse_,List<string> ids_){
				
				InitInvocation("callbackReturnOrders");
				
				callbackReturnOrders_args args = new callbackReturnOrders_args();
				args.SetSysKey(sysKey_);
				args.SetWarehouse(warehouse_);
				args.SetIds(ids_);
				
				SendBase(args, callbackReturnOrders_argsHelper.getInstance());
			}
			
			
			private com.vip.sce.vlg.osp.wms.service.PostResponse recv_callbackReturnOrders(){
				
				callbackReturnOrders_result result = new callbackReturnOrders_result();
				ReceiveBase(result, callbackReturnOrders_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.sce.vlg.osp.wms.service.PostResponse deliverOrderContainer(string sysKey_,string warehouse_,List<com.vip.sce.vlg.osp.wms.service.OrderContainer> orders_) {
				
				send_deliverOrderContainer(sysKey_,warehouse_,orders_);
				return recv_deliverOrderContainer(); 
				
			}
			
			
			private void send_deliverOrderContainer(string sysKey_,string warehouse_,List<com.vip.sce.vlg.osp.wms.service.OrderContainer> orders_){
				
				InitInvocation("deliverOrderContainer");
				
				deliverOrderContainer_args args = new deliverOrderContainer_args();
				args.SetSysKey(sysKey_);
				args.SetWarehouse(warehouse_);
				args.SetOrders(orders_);
				
				SendBase(args, deliverOrderContainer_argsHelper.getInstance());
			}
			
			
			private com.vip.sce.vlg.osp.wms.service.PostResponse recv_deliverOrderContainer(){
				
				deliverOrderContainer_result result = new deliverOrderContainer_result();
				ReceiveBase(result, deliverOrderContainer_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.sce.vlg.osp.wms.service.PostResponse deliverSaleOrder(string sysKey_,string warehouse_,List<com.vip.sce.vlg.osp.wms.service.SaleOrders> sale_orders_) {
				
				send_deliverSaleOrder(sysKey_,warehouse_,sale_orders_);
				return recv_deliverSaleOrder(); 
				
			}
			
			
			private void send_deliverSaleOrder(string sysKey_,string warehouse_,List<com.vip.sce.vlg.osp.wms.service.SaleOrders> sale_orders_){
				
				InitInvocation("deliverSaleOrder");
				
				deliverSaleOrder_args args = new deliverSaleOrder_args();
				args.SetSysKey(sysKey_);
				args.SetWarehouse(warehouse_);
				args.SetSale_orders(sale_orders_);
				
				SendBase(args, deliverSaleOrder_argsHelper.getInstance());
			}
			
			
			private com.vip.sce.vlg.osp.wms.service.PostResponse recv_deliverSaleOrder(){
				
				deliverSaleOrder_result result = new deliverSaleOrder_result();
				ReceiveBase(result, deliverSaleOrder_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.sce.vlg.osp.wms.service.PostResponse getGlobalDeliverBatch(string sysKey_,string warehouse_,com.vip.sce.vlg.osp.wms.service.OutWmsGlobalDeliverBatchParam globalDeliverBatchInfo_) {
				
				send_getGlobalDeliverBatch(sysKey_,warehouse_,globalDeliverBatchInfo_);
				return recv_getGlobalDeliverBatch(); 
				
			}
			
			
			private void send_getGlobalDeliverBatch(string sysKey_,string warehouse_,com.vip.sce.vlg.osp.wms.service.OutWmsGlobalDeliverBatchParam globalDeliverBatchInfo_){
				
				InitInvocation("getGlobalDeliverBatch");
				
				getGlobalDeliverBatch_args args = new getGlobalDeliverBatch_args();
				args.SetSysKey(sysKey_);
				args.SetWarehouse(warehouse_);
				args.SetGlobalDeliverBatchInfo(globalDeliverBatchInfo_);
				
				SendBase(args, getGlobalDeliverBatch_argsHelper.getInstance());
			}
			
			
			private com.vip.sce.vlg.osp.wms.service.PostResponse recv_getGlobalDeliverBatch(){
				
				getGlobalDeliverBatch_result result = new getGlobalDeliverBatch_result();
				ReceiveBase(result, getGlobalDeliverBatch_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.sce.vlg.osp.wms.service.OutWmsOrderGetHeaderResponse getOrders(string sysKey_,string warehouse_,List<string> orderSnList_,int? num_) {
				
				send_getOrders(sysKey_,warehouse_,orderSnList_,num_);
				return recv_getOrders(); 
				
			}
			
			
			private void send_getOrders(string sysKey_,string warehouse_,List<string> orderSnList_,int? num_){
				
				InitInvocation("getOrders");
				
				getOrders_args args = new getOrders_args();
				args.SetSysKey(sysKey_);
				args.SetWarehouse(warehouse_);
				args.SetOrderSnList(orderSnList_);
				args.SetNum(num_);
				
				SendBase(args, getOrders_argsHelper.getInstance());
			}
			
			
			private com.vip.sce.vlg.osp.wms.service.OutWmsOrderGetHeaderResponse recv_getOrders(){
				
				getOrders_result result = new getOrders_result();
				ReceiveBase(result, getOrders_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.sce.vlg.osp.wms.service.GetOutWmsOubShipmentResponse getOutOubShipments(string sysKey_,string warehouse_,int pageSize_) {
				
				send_getOutOubShipments(sysKey_,warehouse_,pageSize_);
				return recv_getOutOubShipments(); 
				
			}
			
			
			private void send_getOutOubShipments(string sysKey_,string warehouse_,int pageSize_){
				
				InitInvocation("getOutOubShipments");
				
				getOutOubShipments_args args = new getOutOubShipments_args();
				args.SetSysKey(sysKey_);
				args.SetWarehouse(warehouse_);
				args.SetPageSize(pageSize_);
				
				SendBase(args, getOutOubShipments_argsHelper.getInstance());
			}
			
			
			private com.vip.sce.vlg.osp.wms.service.GetOutWmsOubShipmentResponse recv_getOutOubShipments(){
				
				getOutOubShipments_result result = new getOutOubShipments_result();
				ReceiveBase(result, getOutOubShipments_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.sce.vlg.osp.wms.service.PostResponse getOutWmsPackageTransferOrders(string sysKey_,string warehouse_,string carrierCode_,string customsCode_,List<com.vip.sce.vlg.osp.wms.service.OrdersVo> orders_) {
				
				send_getOutWmsPackageTransferOrders(sysKey_,warehouse_,carrierCode_,customsCode_,orders_);
				return recv_getOutWmsPackageTransferOrders(); 
				
			}
			
			
			private void send_getOutWmsPackageTransferOrders(string sysKey_,string warehouse_,string carrierCode_,string customsCode_,List<com.vip.sce.vlg.osp.wms.service.OrdersVo> orders_){
				
				InitInvocation("getOutWmsPackageTransferOrders");
				
				getOutWmsPackageTransferOrders_args args = new getOutWmsPackageTransferOrders_args();
				args.SetSysKey(sysKey_);
				args.SetWarehouse(warehouse_);
				args.SetCarrierCode(carrierCode_);
				args.SetCustomsCode(customsCode_);
				args.SetOrders(orders_);
				
				SendBase(args, getOutWmsPackageTransferOrders_argsHelper.getInstance());
			}
			
			
			private com.vip.sce.vlg.osp.wms.service.PostResponse recv_getOutWmsPackageTransferOrders(){
				
				getOutWmsPackageTransferOrders_result result = new getOutWmsPackageTransferOrders_result();
				ReceiveBase(result, getOutWmsPackageTransferOrders_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.sce.vlg.osp.wms.service.GetOutWmsZcodeApplyResponse getOutZcodeApplys(string sysKey_,string warehouse_,int pageSize_) {
				
				send_getOutZcodeApplys(sysKey_,warehouse_,pageSize_);
				return recv_getOutZcodeApplys(); 
				
			}
			
			
			private void send_getOutZcodeApplys(string sysKey_,string warehouse_,int pageSize_){
				
				InitInvocation("getOutZcodeApplys");
				
				getOutZcodeApplys_args args = new getOutZcodeApplys_args();
				args.SetSysKey(sysKey_);
				args.SetWarehouse(warehouse_);
				args.SetPageSize(pageSize_);
				
				SendBase(args, getOutZcodeApplys_argsHelper.getInstance());
			}
			
			
			private com.vip.sce.vlg.osp.wms.service.GetOutWmsZcodeApplyResponse recv_getOutZcodeApplys(){
				
				getOutZcodeApplys_result result = new getOutZcodeApplys_result();
				ReceiveBase(result, getOutZcodeApplys_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.sce.vlg.osp.wms.service.OspOutWmsPoGetHeaderResponse getPoBatchList(string sysKey_,string warehouse_,int start_batch_id_,int num_,string po_no_,List<string> batch_no_list_,string vendor_code_,int? total_) {
				
				send_getPoBatchList(sysKey_,warehouse_,start_batch_id_,num_,po_no_,batch_no_list_,vendor_code_,total_);
				return recv_getPoBatchList(); 
				
			}
			
			
			private void send_getPoBatchList(string sysKey_,string warehouse_,int start_batch_id_,int num_,string po_no_,List<string> batch_no_list_,string vendor_code_,int? total_){
				
				InitInvocation("getPoBatchList");
				
				getPoBatchList_args args = new getPoBatchList_args();
				args.SetSysKey(sysKey_);
				args.SetWarehouse(warehouse_);
				args.SetStart_batch_id(start_batch_id_);
				args.SetNum(num_);
				args.SetPo_no(po_no_);
				args.SetBatch_no_list(batch_no_list_);
				args.SetVendor_code(vendor_code_);
				args.SetTotal(total_);
				
				SendBase(args, getPoBatchList_argsHelper.getInstance());
			}
			
			
			private com.vip.sce.vlg.osp.wms.service.OspOutWmsPoGetHeaderResponse recv_getPoBatchList(){
				
				getPoBatchList_result result = new getPoBatchList_result();
				ReceiveBase(result, getPoBatchList_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.sce.vlg.osp.wms.service.OutWmsReturnOrderHeaderResponse getReturnOrders(string sysKey_,string warehouse_,int num_) {
				
				send_getReturnOrders(sysKey_,warehouse_,num_);
				return recv_getReturnOrders(); 
				
			}
			
			
			private void send_getReturnOrders(string sysKey_,string warehouse_,int num_){
				
				InitInvocation("getReturnOrders");
				
				getReturnOrders_args args = new getReturnOrders_args();
				args.SetSysKey(sysKey_);
				args.SetWarehouse(warehouse_);
				args.SetNum(num_);
				
				SendBase(args, getReturnOrders_argsHelper.getInstance());
			}
			
			
			private com.vip.sce.vlg.osp.wms.service.OutWmsReturnOrderHeaderResponse recv_getReturnOrders(){
				
				getReturnOrders_result result = new getReturnOrders_result();
				ReceiveBase(result, getReturnOrders_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.sce.vlg.osp.wms.service.PostResponse getTransferLadingBillS(string sysKey_,string warehouse_,com.vip.sce.vlg.osp.wms.service.OutWmsLadingBillIDLParam requestParam_) {
				
				send_getTransferLadingBillS(sysKey_,warehouse_,requestParam_);
				return recv_getTransferLadingBillS(); 
				
			}
			
			
			private void send_getTransferLadingBillS(string sysKey_,string warehouse_,com.vip.sce.vlg.osp.wms.service.OutWmsLadingBillIDLParam requestParam_){
				
				InitInvocation("getTransferLadingBillS");
				
				getTransferLadingBillS_args args = new getTransferLadingBillS_args();
				args.SetSysKey(sysKey_);
				args.SetWarehouse(warehouse_);
				args.SetRequestParam(requestParam_);
				
				SendBase(args, getTransferLadingBillS_argsHelper.getInstance());
			}
			
			
			private com.vip.sce.vlg.osp.wms.service.PostResponse recv_getTransferLadingBillS(){
				
				getTransferLadingBillS_result result = new getTransferLadingBillS_result();
				ReceiveBase(result, getTransferLadingBillS_resultHelper.getInstance());
				
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
			
			
			public com.vip.sce.vlg.osp.wms.service.PostResponse pushOrderStatusList(string sysKey_,string warehouse_,List<com.vip.sce.vlg.osp.wms.service.OspOutWmsOrderStatusSModel> order_status_detail_list_) {
				
				send_pushOrderStatusList(sysKey_,warehouse_,order_status_detail_list_);
				return recv_pushOrderStatusList(); 
				
			}
			
			
			private void send_pushOrderStatusList(string sysKey_,string warehouse_,List<com.vip.sce.vlg.osp.wms.service.OspOutWmsOrderStatusSModel> order_status_detail_list_){
				
				InitInvocation("pushOrderStatusList");
				
				pushOrderStatusList_args args = new pushOrderStatusList_args();
				args.SetSysKey(sysKey_);
				args.SetWarehouse(warehouse_);
				args.SetOrder_status_detail_list(order_status_detail_list_);
				
				SendBase(args, pushOrderStatusList_argsHelper.getInstance());
			}
			
			
			private com.vip.sce.vlg.osp.wms.service.PostResponse recv_pushOrderStatusList(){
				
				pushOrderStatusList_result result = new pushOrderStatusList_result();
				ReceiveBase(result, pushOrderStatusList_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.sce.vlg.osp.wms.service.PostResponse pushOutInbShipment(string sysKey_,string warehouse_,com.vip.sce.vlg.osp.wms.service.OutInbShipmentInfo outInbShipmentInfo_) {
				
				send_pushOutInbShipment(sysKey_,warehouse_,outInbShipmentInfo_);
				return recv_pushOutInbShipment(); 
				
			}
			
			
			private void send_pushOutInbShipment(string sysKey_,string warehouse_,com.vip.sce.vlg.osp.wms.service.OutInbShipmentInfo outInbShipmentInfo_){
				
				InitInvocation("pushOutInbShipment");
				
				pushOutInbShipment_args args = new pushOutInbShipment_args();
				args.SetSysKey(sysKey_);
				args.SetWarehouse(warehouse_);
				args.SetOutInbShipmentInfo(outInbShipmentInfo_);
				
				SendBase(args, pushOutInbShipment_argsHelper.getInstance());
			}
			
			
			private com.vip.sce.vlg.osp.wms.service.PostResponse recv_pushOutInbShipment(){
				
				pushOutInbShipment_result result = new pushOutInbShipment_result();
				ReceiveBase(result, pushOutInbShipment_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.sce.vlg.osp.wms.service.PostResponse pushOutWmsOrderBatch(string sysKey_,string warehouse_,string warehouseCode_,List<com.vip.sce.vlg.osp.wms.service.OrderBatchInfo> orderBatchInfos_) {
				
				send_pushOutWmsOrderBatch(sysKey_,warehouse_,warehouseCode_,orderBatchInfos_);
				return recv_pushOutWmsOrderBatch(); 
				
			}
			
			
			private void send_pushOutWmsOrderBatch(string sysKey_,string warehouse_,string warehouseCode_,List<com.vip.sce.vlg.osp.wms.service.OrderBatchInfo> orderBatchInfos_){
				
				InitInvocation("pushOutWmsOrderBatch");
				
				pushOutWmsOrderBatch_args args = new pushOutWmsOrderBatch_args();
				args.SetSysKey(sysKey_);
				args.SetWarehouse(warehouse_);
				args.SetWarehouseCode(warehouseCode_);
				args.SetOrderBatchInfos(orderBatchInfos_);
				
				SendBase(args, pushOutWmsOrderBatch_argsHelper.getInstance());
			}
			
			
			private com.vip.sce.vlg.osp.wms.service.PostResponse recv_pushOutWmsOrderBatch(){
				
				pushOutWmsOrderBatch_result result = new pushOutWmsOrderBatch_result();
				ReceiveBase(result, pushOutWmsOrderBatch_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.sce.vlg.osp.wms.service.PostResponse pushOutZcode(string sysKey_,string warehouse_,com.vip.sce.vlg.osp.wms.service.OutWmsZcodeInfo outWmsZcodeInfo_) {
				
				send_pushOutZcode(sysKey_,warehouse_,outWmsZcodeInfo_);
				return recv_pushOutZcode(); 
				
			}
			
			
			private void send_pushOutZcode(string sysKey_,string warehouse_,com.vip.sce.vlg.osp.wms.service.OutWmsZcodeInfo outWmsZcodeInfo_){
				
				InitInvocation("pushOutZcode");
				
				pushOutZcode_args args = new pushOutZcode_args();
				args.SetSysKey(sysKey_);
				args.SetWarehouse(warehouse_);
				args.SetOutWmsZcodeInfo(outWmsZcodeInfo_);
				
				SendBase(args, pushOutZcode_argsHelper.getInstance());
			}
			
			
			private com.vip.sce.vlg.osp.wms.service.PostResponse recv_pushOutZcode(){
				
				pushOutZcode_result result = new pushOutZcode_result();
				ReceiveBase(result, pushOutZcode_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.sce.vlg.osp.wms.service.PostResponse updateCarrierStatus(string sysKey_,string warehouse_,com.vip.sce.vlg.osp.wms.service.CarrierInfoRequest carrierInfoRequest_) {
				
				send_updateCarrierStatus(sysKey_,warehouse_,carrierInfoRequest_);
				return recv_updateCarrierStatus(); 
				
			}
			
			
			private void send_updateCarrierStatus(string sysKey_,string warehouse_,com.vip.sce.vlg.osp.wms.service.CarrierInfoRequest carrierInfoRequest_){
				
				InitInvocation("updateCarrierStatus");
				
				updateCarrierStatus_args args = new updateCarrierStatus_args();
				args.SetSysKey(sysKey_);
				args.SetWarehouse(warehouse_);
				args.SetCarrierInfoRequest(carrierInfoRequest_);
				
				SendBase(args, updateCarrierStatus_argsHelper.getInstance());
			}
			
			
			private com.vip.sce.vlg.osp.wms.service.PostResponse recv_updateCarrierStatus(){
				
				updateCarrierStatus_result result = new updateCarrierStatus_result();
				ReceiveBase(result, updateCarrierStatus_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.sce.vlg.osp.wms.service.PostResponse updatePoBatchStatus(string sysKey_,string warehouse_,List<string> batch_nos_) {
				
				send_updatePoBatchStatus(sysKey_,warehouse_,batch_nos_);
				return recv_updatePoBatchStatus(); 
				
			}
			
			
			private void send_updatePoBatchStatus(string sysKey_,string warehouse_,List<string> batch_nos_){
				
				InitInvocation("updatePoBatchStatus");
				
				updatePoBatchStatus_args args = new updatePoBatchStatus_args();
				args.SetSysKey(sysKey_);
				args.SetWarehouse(warehouse_);
				args.SetBatch_nos(batch_nos_);
				
				SendBase(args, updatePoBatchStatus_argsHelper.getInstance());
			}
			
			
			private com.vip.sce.vlg.osp.wms.service.PostResponse recv_updatePoBatchStatus(){
				
				updatePoBatchStatus_result result = new updatePoBatchStatus_result();
				ReceiveBase(result, updatePoBatchStatus_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.sce.vlg.osp.wms.service.PostResponse uploadInvAdjustment(string sysKey_,string warehouse_,List<com.vip.sce.vlg.osp.wms.service.InvAdjustment> invAdjustments_) {
				
				send_uploadInvAdjustment(sysKey_,warehouse_,invAdjustments_);
				return recv_uploadInvAdjustment(); 
				
			}
			
			
			private void send_uploadInvAdjustment(string sysKey_,string warehouse_,List<com.vip.sce.vlg.osp.wms.service.InvAdjustment> invAdjustments_){
				
				InitInvocation("uploadInvAdjustment");
				
				uploadInvAdjustment_args args = new uploadInvAdjustment_args();
				args.SetSysKey(sysKey_);
				args.SetWarehouse(warehouse_);
				args.SetInvAdjustments(invAdjustments_);
				
				SendBase(args, uploadInvAdjustment_argsHelper.getInstance());
			}
			
			
			private com.vip.sce.vlg.osp.wms.service.PostResponse recv_uploadInvAdjustment(){
				
				uploadInvAdjustment_result result = new uploadInvAdjustment_result();
				ReceiveBase(result, uploadInvAdjustment_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.sce.vlg.osp.wms.service.PostResponse uploadReturnOrderStatus(string sysKey_,string warehouse_,List<com.vip.sce.vlg.osp.wms.service.ReturnOrderStatus> details_) {
				
				send_uploadReturnOrderStatus(sysKey_,warehouse_,details_);
				return recv_uploadReturnOrderStatus(); 
				
			}
			
			
			private void send_uploadReturnOrderStatus(string sysKey_,string warehouse_,List<com.vip.sce.vlg.osp.wms.service.ReturnOrderStatus> details_){
				
				InitInvocation("uploadReturnOrderStatus");
				
				uploadReturnOrderStatus_args args = new uploadReturnOrderStatus_args();
				args.SetSysKey(sysKey_);
				args.SetWarehouse(warehouse_);
				args.SetDetails(details_);
				
				SendBase(args, uploadReturnOrderStatus_argsHelper.getInstance());
			}
			
			
			private com.vip.sce.vlg.osp.wms.service.PostResponse recv_uploadReturnOrderStatus(){
				
				uploadReturnOrderStatus_result result = new uploadReturnOrderStatus_result();
				ReceiveBase(result, uploadReturnOrderStatus_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.sce.vlg.osp.wms.service.PostResponse uploadReturnOutDetail(string sysKey_,string warehouse_,List<com.vip.sce.vlg.osp.wms.service.ReturnOutInfo> details_) {
				
				send_uploadReturnOutDetail(sysKey_,warehouse_,details_);
				return recv_uploadReturnOutDetail(); 
				
			}
			
			
			private void send_uploadReturnOutDetail(string sysKey_,string warehouse_,List<com.vip.sce.vlg.osp.wms.service.ReturnOutInfo> details_){
				
				InitInvocation("uploadReturnOutDetail");
				
				uploadReturnOutDetail_args args = new uploadReturnOutDetail_args();
				args.SetSysKey(sysKey_);
				args.SetWarehouse(warehouse_);
				args.SetDetails(details_);
				
				SendBase(args, uploadReturnOutDetail_argsHelper.getInstance());
			}
			
			
			private com.vip.sce.vlg.osp.wms.service.PostResponse recv_uploadReturnOutDetail(){
				
				uploadReturnOutDetail_result result = new uploadReturnOutDetail_result();
				ReceiveBase(result, uploadReturnOutDetail_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
		}
		
		
	}
	
}