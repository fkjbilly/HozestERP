using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;

namespace vipapis.order{
	
	
	public class OmniOrderServiceHelper {
		
		
		
		public class confirmInvoice_args {
			
			///<summary>
			/// 供应商ID
			///</summary>
			
			private int? vendor_id_;
			
			///<summary>
			/// 订单开票结果
			///</summary>
			
			private vipapis.order.OrderInvoiceReq order_invoice_;
			
			public int? GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(int? value){
				this.vendor_id_ = value;
			}
			public vipapis.order.OrderInvoiceReq GetOrder_invoice(){
				return this.order_invoice_;
			}
			
			public void SetOrder_invoice(vipapis.order.OrderInvoiceReq value){
				this.order_invoice_ = value;
			}
			
		}
		
		
		
		
		public class confirmOrderInvoice_args {
			
			///<summary>
			/// 供应商ID
			///</summary>
			
			private int? vendor_id_;
			
			///<summary>
			/// 订单开票结果,批量最多20条
			///</summary>
			
			private List<vipapis.order.OrderInvoiceReq> order_invoices_;
			
			public int? GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(int? value){
				this.vendor_id_ = value;
			}
			public List<vipapis.order.OrderInvoiceReq> GetOrder_invoices(){
				return this.order_invoices_;
			}
			
			public void SetOrder_invoices(List<vipapis.order.OrderInvoiceReq> value){
				this.order_invoices_ = value;
			}
			
		}
		
		
		
		
		public class confirmOxoDelivery_args {
			
			///<summary>
			/// 供应商ID
			///</summary>
			
			private long? vendor_id_;
			
			///<summary>
			/// 订单号
			///</summary>
			
			private string order_id_;
			
			///<summary>
			/// 门店编码(当传12个1时忽略以下三字段)
			///</summary>
			
			private string store_sn_;
			
			///<summary>
			/// 通知发货类型(1线上通知，2线下通知.当线下通知时忽略以下两字段)
			///</summary>
			
			private byte? notice_type_;
			
			///<summary>
			/// 包裹号
			///</summary>
			
			private string package_no_;
			
			///<summary>
			/// 预约发货时间
			///</summary>
			
			private long? estimate_delivery_time_;
			
			public long? GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(long? value){
				this.vendor_id_ = value;
			}
			public string GetOrder_id(){
				return this.order_id_;
			}
			
			public void SetOrder_id(string value){
				this.order_id_ = value;
			}
			public string GetStore_sn(){
				return this.store_sn_;
			}
			
			public void SetStore_sn(string value){
				this.store_sn_ = value;
			}
			public byte? GetNotice_type(){
				return this.notice_type_;
			}
			
			public void SetNotice_type(byte? value){
				this.notice_type_ = value;
			}
			public string GetPackage_no(){
				return this.package_no_;
			}
			
			public void SetPackage_no(string value){
				this.package_no_ = value;
			}
			public long? GetEstimate_delivery_time(){
				return this.estimate_delivery_time_;
			}
			
			public void SetEstimate_delivery_time(long? value){
				this.estimate_delivery_time_ = value;
			}
			
		}
		
		
		
		
		public class confirmOxoShipment_args {
			
			///<summary>
			/// 供应商ID
			///</summary>
			
			private long? vendor_id_;
			
			///<summary>
			/// 订单号
			///</summary>
			
			private string order_id_;
			
			///<summary>
			/// 门店编码
			///</summary>
			
			private string store_sn_;
			
			///<summary>
			/// 承运商名称
			///</summary>
			
			private string carrier_name_;
			
			///<summary>
			/// 承运商编码
			///</summary>
			
			private string carrier_code_;
			
			///<summary>
			/// 运单号
			///</summary>
			
			private string transport_no_;
			
			public long? GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(long? value){
				this.vendor_id_ = value;
			}
			public string GetOrder_id(){
				return this.order_id_;
			}
			
			public void SetOrder_id(string value){
				this.order_id_ = value;
			}
			public string GetStore_sn(){
				return this.store_sn_;
			}
			
			public void SetStore_sn(string value){
				this.store_sn_ = value;
			}
			public string GetCarrier_name(){
				return this.carrier_name_;
			}
			
			public void SetCarrier_name(string value){
				this.carrier_name_ = value;
			}
			public string GetCarrier_code(){
				return this.carrier_code_;
			}
			
			public void SetCarrier_code(string value){
				this.carrier_code_ = value;
			}
			public string GetTransport_no(){
				return this.transport_no_;
			}
			
			public void SetTransport_no(string value){
				this.transport_no_ = value;
			}
			
		}
		
		
		
		
		public class confirmStoreDelivery_args {
			
			///<summary>
			/// 供应商ID
			///</summary>
			
			private long? vendor_id_;
			
			///<summary>
			/// 订单号
			///</summary>
			
			private string order_id_;
			
			///<summary>
			/// 门店编码
			///</summary>
			
			private string store_sn_;
			
			///<summary>
			/// 包裹号
			///</summary>
			
			private string package_no_;
			
			///<summary>
			/// 预约发货时间
			///</summary>
			
			private long? estimate_delivery_time_;
			
			public long? GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(long? value){
				this.vendor_id_ = value;
			}
			public string GetOrder_id(){
				return this.order_id_;
			}
			
			public void SetOrder_id(string value){
				this.order_id_ = value;
			}
			public string GetStore_sn(){
				return this.store_sn_;
			}
			
			public void SetStore_sn(string value){
				this.store_sn_ = value;
			}
			public string GetPackage_no(){
				return this.package_no_;
			}
			
			public void SetPackage_no(string value){
				this.package_no_ = value;
			}
			public long? GetEstimate_delivery_time(){
				return this.estimate_delivery_time_;
			}
			
			public void SetEstimate_delivery_time(long? value){
				this.estimate_delivery_time_ = value;
			}
			
		}
		
		
		
		
		public class getDeliveryInfo_args {
			
			///<summary>
			/// 供应商id
			///</summary>
			
			private int? vendor_id_;
			
			///<summary>
			/// 发货仓库编码
			///</summary>
			
			private string store_sn_;
			
			///<summary>
			/// 订单号列表，最大10条
			///</summary>
			
			private List<string> orders_;
			
			public int? GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(int? value){
				this.vendor_id_ = value;
			}
			public string GetStore_sn(){
				return this.store_sn_;
			}
			
			public void SetStore_sn(string value){
				this.store_sn_ = value;
			}
			public List<string> GetOrders(){
				return this.orders_;
			}
			
			public void SetOrders(List<string> value){
				this.orders_ = value;
			}
			
		}
		
		
		
		
		public class getInventoryCancelledOrders_args {
			
			///<summary>
			/// 获取已取消订单请求
			///</summary>
			
			private vipapis.order.InventoryCancelledOrdersRequest inventoryCancelledOrdersRequest_;
			
			public vipapis.order.InventoryCancelledOrdersRequest GetInventoryCancelledOrdersRequest(){
				return this.inventoryCancelledOrdersRequest_;
			}
			
			public void SetInventoryCancelledOrdersRequest(vipapis.order.InventoryCancelledOrdersRequest value){
				this.inventoryCancelledOrdersRequest_ = value;
			}
			
		}
		
		
		
		
		public class getInventoryDeductOrders_args {
			
			///<summary>
			/// 获取拣货订单查询请求
			///</summary>
			
			private vipapis.order.InventoryDeductOrdersRequest inventoryDeductOrdersRequest_;
			
			public vipapis.order.InventoryDeductOrdersRequest GetInventoryDeductOrdersRequest(){
				return this.inventoryDeductOrdersRequest_;
			}
			
			public void SetInventoryDeductOrdersRequest(vipapis.order.InventoryDeductOrdersRequest value){
				this.inventoryDeductOrdersRequest_ = value;
			}
			
		}
		
		
		
		
		public class getInventoryOccupiedOrders_args {
			
			///<summary>
			/// 获取销售订单请求
			///</summary>
			
			private vipapis.order.InventoryOccupiedOrdersRequest inventoryOccupiedOrdersRequest_;
			
			public vipapis.order.InventoryOccupiedOrdersRequest GetInventoryOccupiedOrdersRequest(){
				return this.inventoryOccupiedOrdersRequest_;
			}
			
			public void SetInventoryOccupiedOrdersRequest(vipapis.order.InventoryOccupiedOrdersRequest value){
				this.inventoryOccupiedOrdersRequest_ = value;
			}
			
		}
		
		
		
		
		public class getOmniCancelledOrders_args {
			
			///<summary>
			/// 供应商ID
			///</summary>
			
			private long? vendor_id_;
			
			///<summary>
			/// 品牌ID
			///</summary>
			
			private long? brand_id_;
			
			///<summary>
			/// 订单类型(2:仓中仓)
			///</summary>
			
			private byte? order_type_;
			
			///<summary>
			/// 取消单开始时间（Epoch格式）
			///</summary>
			
			private long? st_query_time_;
			
			///<summary>
			/// 取消单结束时间（Epoch格式）
			///</summary>
			
			private long? et_query_time_;
			
			///<summary>
			/// 每页记录数,默认为50,最大支持200
			///</summary>
			
			private int? limit_;
			
			///<summary>
			/// 页码,默认为1
			///</summary>
			
			private int? page_;
			
			public long? GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(long? value){
				this.vendor_id_ = value;
			}
			public long? GetBrand_id(){
				return this.brand_id_;
			}
			
			public void SetBrand_id(long? value){
				this.brand_id_ = value;
			}
			public byte? GetOrder_type(){
				return this.order_type_;
			}
			
			public void SetOrder_type(byte? value){
				this.order_type_ = value;
			}
			public long? GetSt_query_time(){
				return this.st_query_time_;
			}
			
			public void SetSt_query_time(long? value){
				this.st_query_time_ = value;
			}
			public long? GetEt_query_time(){
				return this.et_query_time_;
			}
			
			public void SetEt_query_time(long? value){
				this.et_query_time_ = value;
			}
			public int? GetLimit(){
				return this.limit_;
			}
			
			public void SetLimit(int? value){
				this.limit_ = value;
			}
			public int? GetPage(){
				return this.page_;
			}
			
			public void SetPage(int? value){
				this.page_ = value;
			}
			
		}
		
		
		
		
		public class getOmniOrders_args {
			
			///<summary>
			/// 供应商ID
			///</summary>
			
			private long? vendor_id_;
			
			///<summary>
			/// 品牌ID
			///</summary>
			
			private long? brand_id_;
			
			///<summary>
			/// 业务类型(2:仓中仓)
			///</summary>
			
			private byte? business_type_;
			
			///<summary>
			/// 订单开始时间（Epoch格式）
			///</summary>
			
			private long? st_query_time_;
			
			///<summary>
			/// 订单结束时间（Epoch格式）
			///</summary>
			
			private long? et_query_time_;
			
			///<summary>
			/// 每页记录数,默认为50,最大支持200
			///</summary>
			
			private int? limit_;
			
			///<summary>
			/// 页码,默认为1
			///</summary>
			
			private int? page_;
			
			public long? GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(long? value){
				this.vendor_id_ = value;
			}
			public long? GetBrand_id(){
				return this.brand_id_;
			}
			
			public void SetBrand_id(long? value){
				this.brand_id_ = value;
			}
			public byte? GetBusiness_type(){
				return this.business_type_;
			}
			
			public void SetBusiness_type(byte? value){
				this.business_type_ = value;
			}
			public long? GetSt_query_time(){
				return this.st_query_time_;
			}
			
			public void SetSt_query_time(long? value){
				this.st_query_time_ = value;
			}
			public long? GetEt_query_time(){
				return this.et_query_time_;
			}
			
			public void SetEt_query_time(long? value){
				this.et_query_time_ = value;
			}
			public int? GetLimit(){
				return this.limit_;
			}
			
			public void SetLimit(int? value){
				this.limit_ = value;
			}
			public int? GetPage(){
				return this.page_;
			}
			
			public void SetPage(int? value){
				this.page_ = value;
			}
			
		}
		
		
		
		
		public class getOrderEInvoiceInfo_args {
			
			///<summary>
			/// 供应商ID
			///</summary>
			
			private int? vendorId_;
			
			///<summary>
			/// 订单号,最多20条
			///</summary>
			
			private List<string> orders_;
			
			public int? GetVendorId(){
				return this.vendorId_;
			}
			
			public void SetVendorId(int? value){
				this.vendorId_ = value;
			}
			public List<string> GetOrders(){
				return this.orders_;
			}
			
			public void SetOrders(List<string> value){
				this.orders_ = value;
			}
			
		}
		
		
		
		
		public class getOrderInvoice_args {
			
			///<summary>
			/// 供应商ID
			///</summary>
			
			private int? vendor_id_;
			
			///<summary>
			/// 订单列表,批量最多20条
			///</summary>
			
			private List<string> orders_;
			
			public int? GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(int? value){
				this.vendor_id_ = value;
			}
			public List<string> GetOrders(){
				return this.orders_;
			}
			
			public void SetOrders(List<string> value){
				this.orders_ = value;
			}
			
		}
		
		
		
		
		public class getOxoOrders_args {
			
			///<summary>
			/// 获取销售订单请求
			///</summary>
			
			private vipapis.order.OxoOrderRequest ordersRequest_;
			
			public vipapis.order.OxoOrderRequest GetOrdersRequest(){
				return this.ordersRequest_;
			}
			
			public void SetOrdersRequest(vipapis.order.OxoOrderRequest value){
				this.ordersRequest_ = value;
			}
			
		}
		
		
		
		
		public class healthCheck_args {
			
			
		}
		
		
		
		
		public class printInvoice_args {
			
			///<summary>
			/// 供应商ID
			///</summary>
			
			private long? vendor_id_;
			
			///<summary>
			/// 发货仓库编码
			///</summary>
			
			private string store_sn_;
			
			///<summary>
			/// 批次号
			///</summary>
			
			private string batch_no_;
			
			///<summary>
			/// 订单列表
			///</summary>
			
			private List<vipapis.order.OrderSeq> orders_;
			
			///<summary>
			/// 自定义扩展信息
			///</summary>
			
			private vipapis.order.ExtInfo ext_info_;
			
			///<summary>
			/// 请求类型，0：非大件仓中仓, 1：大件仓中长，默认值：0
			///</summary>
			
			private int? print_type_;
			
			public long? GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(long? value){
				this.vendor_id_ = value;
			}
			public string GetStore_sn(){
				return this.store_sn_;
			}
			
			public void SetStore_sn(string value){
				this.store_sn_ = value;
			}
			public string GetBatch_no(){
				return this.batch_no_;
			}
			
			public void SetBatch_no(string value){
				this.batch_no_ = value;
			}
			public List<vipapis.order.OrderSeq> GetOrders(){
				return this.orders_;
			}
			
			public void SetOrders(List<vipapis.order.OrderSeq> value){
				this.orders_ = value;
			}
			public vipapis.order.ExtInfo GetExt_info(){
				return this.ext_info_;
			}
			
			public void SetExt_info(vipapis.order.ExtInfo value){
				this.ext_info_ = value;
			}
			public int? GetPrint_type(){
				return this.print_type_;
			}
			
			public void SetPrint_type(int? value){
				this.print_type_ = value;
			}
			
		}
		
		
		
		
		public class pushOrderEInvoice_args {
			
			
		}
		
		
		
		
		public class pushOrderPackageWeight_args {
			
			///<summary>
			/// 供应商ID
			///</summary>
			
			private long? vendor_id_;
			
			///<summary>
			/// 发货仓库编码
			///</summary>
			
			private string store_sn_;
			
			///<summary>
			/// 订单列表
			///</summary>
			
			private List<vipapis.order.OrderPackageWeight> orders_;
			
			public long? GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(long? value){
				this.vendor_id_ = value;
			}
			public string GetStore_sn(){
				return this.store_sn_;
			}
			
			public void SetStore_sn(string value){
				this.store_sn_ = value;
			}
			public List<vipapis.order.OrderPackageWeight> GetOrders(){
				return this.orders_;
			}
			
			public void SetOrders(List<vipapis.order.OrderPackageWeight> value){
				this.orders_ = value;
			}
			
		}
		
		
		
		
		public class pushQCResult_args {
			
			///<summary>
			/// 供应商ID
			///</summary>
			
			private long? vendor_id_;
			
			///<summary>
			/// 发货仓库编码
			///</summary>
			
			private string store_sn_;
			
			///<summary>
			/// 订单列表
			///</summary>
			
			private List<vipapis.order.OrderQCResult> orders_;
			
			public long? GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(long? value){
				this.vendor_id_ = value;
			}
			public string GetStore_sn(){
				return this.store_sn_;
			}
			
			public void SetStore_sn(string value){
				this.store_sn_ = value;
			}
			public List<vipapis.order.OrderQCResult> GetOrders(){
				return this.orders_;
			}
			
			public void SetOrders(List<vipapis.order.OrderQCResult> value){
				this.orders_ = value;
			}
			
		}
		
		
		
		
		public class replyStoreSn_args {
			
			///<summary>
			/// 供应商ID
			///</summary>
			
			private long? vendor_id_;
			
			///<summary>
			/// 订单与门店编码的映射关系表，批量最多20条
			///</summary>
			
			private List<vipapis.order.OrderStoreMapping> order_store_mapping_;
			
			public long? GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(long? value){
				this.vendor_id_ = value;
			}
			public List<vipapis.order.OrderStoreMapping> GetOrder_store_mapping(){
				return this.order_store_mapping_;
			}
			
			public void SetOrder_store_mapping(List<vipapis.order.OrderStoreMapping> value){
				this.order_store_mapping_ = value;
			}
			
		}
		
		
		
		
		public class responseOrderStore_args {
			
			///<summary>
			/// 供应商ID
			///</summary>
			
			private long? vendor_id_;
			
			///<summary>
			/// 订单号
			///</summary>
			
			private string order_id_;
			
			///<summary>
			/// 门店编码
			///</summary>
			
			private string store_sn_;
			
			public long? GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(long? value){
				this.vendor_id_ = value;
			}
			public string GetOrder_id(){
				return this.order_id_;
			}
			
			public void SetOrder_id(string value){
				this.order_id_ = value;
			}
			public string GetStore_sn(){
				return this.store_sn_;
			}
			
			public void SetStore_sn(string value){
				this.store_sn_ = value;
			}
			
		}
		
		
		
		
		public class updateStoreSn_args {
			
			///<summary>
			/// 供应商ID
			///</summary>
			
			private long? vendor_id_;
			
			///<summary>
			/// 发货门店修改列表，批量最多20条
			///</summary>
			
			private List<vipapis.order.OrderStoreMappingEx> order_store_mapping_;
			
			public long? GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(long? value){
				this.vendor_id_ = value;
			}
			public List<vipapis.order.OrderStoreMappingEx> GetOrder_store_mapping(){
				return this.order_store_mapping_;
			}
			
			public void SetOrder_store_mapping(List<vipapis.order.OrderStoreMappingEx> value){
				this.order_store_mapping_ = value;
			}
			
		}
		
		
		
		
		public class confirmInvoice_result {
			
			
		}
		
		
		
		
		public class confirmOrderInvoice_result {
			
			///<summary>
			///</summary>
			
			private vipapis.order.OrderInvoiceConfirmResp success_;
			
			public vipapis.order.OrderInvoiceConfirmResp GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.order.OrderInvoiceConfirmResp value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class confirmOxoDelivery_result {
			
			///<summary>
			///</summary>
			
			private vipapis.order.ConfirmDeliveryResp success_;
			
			public vipapis.order.ConfirmDeliveryResp GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.order.ConfirmDeliveryResp value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class confirmOxoShipment_result {
			
			
		}
		
		
		
		
		public class confirmStoreDelivery_result {
			
			
		}
		
		
		
		
		public class getDeliveryInfo_result {
			
			///<summary>
			///</summary>
			
			private List<vipapis.order.OrderDeliveryInfo> success_;
			
			public List<vipapis.order.OrderDeliveryInfo> GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(List<vipapis.order.OrderDeliveryInfo> value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getInventoryCancelledOrders_result {
			
			///<summary>
			///</summary>
			
			private vipapis.order.CancelledOrdersResponse success_;
			
			public vipapis.order.CancelledOrdersResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.order.CancelledOrdersResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getInventoryDeductOrders_result {
			
			///<summary>
			///</summary>
			
			private vipapis.order.InventoryDeductOrdersResponse success_;
			
			public vipapis.order.InventoryDeductOrdersResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.order.InventoryDeductOrdersResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getInventoryOccupiedOrders_result {
			
			///<summary>
			///</summary>
			
			private vipapis.order.OccupiedOrderResponse success_;
			
			public vipapis.order.OccupiedOrderResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.order.OccupiedOrderResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getOmniCancelledOrders_result {
			
			///<summary>
			///</summary>
			
			private vipapis.order.GetOmniCancelledOrdersResp success_;
			
			public vipapis.order.GetOmniCancelledOrdersResp GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.order.GetOmniCancelledOrdersResp value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getOmniOrders_result {
			
			///<summary>
			///</summary>
			
			private vipapis.order.GetOmniOrdersResp success_;
			
			public vipapis.order.GetOmniOrdersResp GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.order.GetOmniOrdersResp value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getOrderEInvoiceInfo_result {
			
			///<summary>
			///</summary>
			
			private List<vipapis.order.EInvoiceInfo> success_;
			
			public List<vipapis.order.EInvoiceInfo> GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(List<vipapis.order.EInvoiceInfo> value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getOrderInvoice_result {
			
			///<summary>
			///</summary>
			
			private vipapis.order.OrderInvoiceQueryResp success_;
			
			public vipapis.order.OrderInvoiceQueryResp GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.order.OrderInvoiceQueryResp value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getOxoOrders_result {
			
			///<summary>
			///</summary>
			
			private vipapis.order.OxoOrderResponse success_;
			
			public vipapis.order.OxoOrderResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.order.OxoOrderResponse value){
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
		
		
		
		
		public class printInvoice_result {
			
			///<summary>
			///</summary>
			
			private vipapis.order.PrintInvoiceResp success_;
			
			public vipapis.order.PrintInvoiceResp GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.order.PrintInvoiceResp value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class pushOrderEInvoice_result {
			
			
		}
		
		
		
		
		public class pushOrderPackageWeight_result {
			
			///<summary>
			///</summary>
			
			private vipapis.order.PushOrderPackageWeightResp success_;
			
			public vipapis.order.PushOrderPackageWeightResp GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.order.PushOrderPackageWeightResp value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class pushQCResult_result {
			
			///<summary>
			///</summary>
			
			private vipapis.order.PushQCResultResp success_;
			
			public vipapis.order.PushQCResultResp GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.order.PushQCResultResp value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class replyStoreSn_result {
			
			///<summary>
			///</summary>
			
			private vipapis.order.ReplyStoreSnResp success_;
			
			public vipapis.order.ReplyStoreSnResp GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.order.ReplyStoreSnResp value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class responseOrderStore_result {
			
			
		}
		
		
		
		
		public class updateStoreSn_result {
			
			///<summary>
			///</summary>
			
			private vipapis.order.UpdateStoreSnResp success_;
			
			public vipapis.order.UpdateStoreSnResp GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.order.UpdateStoreSnResp value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		
		public class confirmInvoice_argsHelper : TBeanSerializer<confirmInvoice_args>
		{
			
			public static confirmInvoice_argsHelper OBJ = new confirmInvoice_argsHelper();
			
			public static confirmInvoice_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(confirmInvoice_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				
				if(true){
					
					vipapis.order.OrderInvoiceReq value;
					
					value = new vipapis.order.OrderInvoiceReq();
					vipapis.order.OrderInvoiceReqHelper.getInstance().Read(value, iprot);
					
					structs.SetOrder_invoice(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(confirmInvoice_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetVendor_id() != null) {
					
					oprot.WriteFieldBegin("vendor_id");
					oprot.WriteI32((int)structs.GetVendor_id()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("vendor_id can not be null!");
				}
				
				
				if(structs.GetOrder_invoice() != null) {
					
					oprot.WriteFieldBegin("order_invoice");
					
					vipapis.order.OrderInvoiceReqHelper.getInstance().Write(structs.GetOrder_invoice(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("order_invoice can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(confirmInvoice_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class confirmOrderInvoice_argsHelper : TBeanSerializer<confirmOrderInvoice_args>
		{
			
			public static confirmOrderInvoice_argsHelper OBJ = new confirmOrderInvoice_argsHelper();
			
			public static confirmOrderInvoice_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(confirmOrderInvoice_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				
				if(true){
					
					List<vipapis.order.OrderInvoiceReq> value;
					
					value = new List<vipapis.order.OrderInvoiceReq>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							vipapis.order.OrderInvoiceReq elem0;
							
							elem0 = new vipapis.order.OrderInvoiceReq();
							vipapis.order.OrderInvoiceReqHelper.getInstance().Read(elem0, iprot);
							
							value.Add(elem0);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetOrder_invoices(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(confirmOrderInvoice_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetVendor_id() != null) {
					
					oprot.WriteFieldBegin("vendor_id");
					oprot.WriteI32((int)structs.GetVendor_id()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("vendor_id can not be null!");
				}
				
				
				if(structs.GetOrder_invoices() != null) {
					
					oprot.WriteFieldBegin("order_invoices");
					
					oprot.WriteListBegin();
					foreach(vipapis.order.OrderInvoiceReq _item0 in structs.GetOrder_invoices()){
						
						
						vipapis.order.OrderInvoiceReqHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("order_invoices can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(confirmOrderInvoice_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class confirmOxoDelivery_argsHelper : TBeanSerializer<confirmOxoDelivery_args>
		{
			
			public static confirmOxoDelivery_argsHelper OBJ = new confirmOxoDelivery_argsHelper();
			
			public static confirmOxoDelivery_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(confirmOxoDelivery_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					long value;
					value = iprot.ReadI64(); 
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetOrder_id(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetStore_sn(value);
				}
				
				
				
				
				
				if(true){
					
					byte? value;
					value = iprot.ReadByte(); 
					
					structs.SetNotice_type(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetPackage_no(value);
				}
				
				
				
				
				
				if(true){
					
					long? value;
					value = iprot.ReadI64(); 
					
					structs.SetEstimate_delivery_time(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(confirmOxoDelivery_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetVendor_id() != null) {
					
					oprot.WriteFieldBegin("vendor_id");
					oprot.WriteI64((long)structs.GetVendor_id()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("vendor_id can not be null!");
				}
				
				
				if(structs.GetOrder_id() != null) {
					
					oprot.WriteFieldBegin("order_id");
					oprot.WriteString(structs.GetOrder_id());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("order_id can not be null!");
				}
				
				
				if(structs.GetStore_sn() != null) {
					
					oprot.WriteFieldBegin("store_sn");
					oprot.WriteString(structs.GetStore_sn());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("store_sn can not be null!");
				}
				
				
				if(structs.GetNotice_type() != null) {
					
					oprot.WriteFieldBegin("notice_type");
					oprot.WriteByte((byte)structs.GetNotice_type()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetPackage_no() != null) {
					
					oprot.WriteFieldBegin("package_no");
					oprot.WriteString(structs.GetPackage_no());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetEstimate_delivery_time() != null) {
					
					oprot.WriteFieldBegin("estimate_delivery_time");
					oprot.WriteI64((long)structs.GetEstimate_delivery_time()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(confirmOxoDelivery_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class confirmOxoShipment_argsHelper : TBeanSerializer<confirmOxoShipment_args>
		{
			
			public static confirmOxoShipment_argsHelper OBJ = new confirmOxoShipment_argsHelper();
			
			public static confirmOxoShipment_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(confirmOxoShipment_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					long value;
					value = iprot.ReadI64(); 
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetOrder_id(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetStore_sn(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetCarrier_name(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetCarrier_code(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetTransport_no(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(confirmOxoShipment_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetVendor_id() != null) {
					
					oprot.WriteFieldBegin("vendor_id");
					oprot.WriteI64((long)structs.GetVendor_id()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("vendor_id can not be null!");
				}
				
				
				if(structs.GetOrder_id() != null) {
					
					oprot.WriteFieldBegin("order_id");
					oprot.WriteString(structs.GetOrder_id());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("order_id can not be null!");
				}
				
				
				if(structs.GetStore_sn() != null) {
					
					oprot.WriteFieldBegin("store_sn");
					oprot.WriteString(structs.GetStore_sn());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("store_sn can not be null!");
				}
				
				
				if(structs.GetCarrier_name() != null) {
					
					oprot.WriteFieldBegin("carrier_name");
					oprot.WriteString(structs.GetCarrier_name());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("carrier_name can not be null!");
				}
				
				
				if(structs.GetCarrier_code() != null) {
					
					oprot.WriteFieldBegin("carrier_code");
					oprot.WriteString(structs.GetCarrier_code());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("carrier_code can not be null!");
				}
				
				
				if(structs.GetTransport_no() != null) {
					
					oprot.WriteFieldBegin("transport_no");
					oprot.WriteString(structs.GetTransport_no());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("transport_no can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(confirmOxoShipment_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class confirmStoreDelivery_argsHelper : TBeanSerializer<confirmStoreDelivery_args>
		{
			
			public static confirmStoreDelivery_argsHelper OBJ = new confirmStoreDelivery_argsHelper();
			
			public static confirmStoreDelivery_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(confirmStoreDelivery_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					long value;
					value = iprot.ReadI64(); 
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetOrder_id(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetStore_sn(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetPackage_no(value);
				}
				
				
				
				
				
				if(true){
					
					long? value;
					value = iprot.ReadI64(); 
					
					structs.SetEstimate_delivery_time(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(confirmStoreDelivery_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetVendor_id() != null) {
					
					oprot.WriteFieldBegin("vendor_id");
					oprot.WriteI64((long)structs.GetVendor_id()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("vendor_id can not be null!");
				}
				
				
				if(structs.GetOrder_id() != null) {
					
					oprot.WriteFieldBegin("order_id");
					oprot.WriteString(structs.GetOrder_id());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("order_id can not be null!");
				}
				
				
				if(structs.GetStore_sn() != null) {
					
					oprot.WriteFieldBegin("store_sn");
					oprot.WriteString(structs.GetStore_sn());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("store_sn can not be null!");
				}
				
				
				if(structs.GetPackage_no() != null) {
					
					oprot.WriteFieldBegin("package_no");
					oprot.WriteString(structs.GetPackage_no());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetEstimate_delivery_time() != null) {
					
					oprot.WriteFieldBegin("estimate_delivery_time");
					oprot.WriteI64((long)structs.GetEstimate_delivery_time()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(confirmStoreDelivery_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getDeliveryInfo_argsHelper : TBeanSerializer<getDeliveryInfo_args>
		{
			
			public static getDeliveryInfo_argsHelper OBJ = new getDeliveryInfo_argsHelper();
			
			public static getDeliveryInfo_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getDeliveryInfo_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetStore_sn(value);
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
					
					structs.SetOrders(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getDeliveryInfo_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetVendor_id() != null) {
					
					oprot.WriteFieldBegin("vendor_id");
					oprot.WriteI32((int)structs.GetVendor_id()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("vendor_id can not be null!");
				}
				
				
				if(structs.GetStore_sn() != null) {
					
					oprot.WriteFieldBegin("store_sn");
					oprot.WriteString(structs.GetStore_sn());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("store_sn can not be null!");
				}
				
				
				if(structs.GetOrders() != null) {
					
					oprot.WriteFieldBegin("orders");
					
					oprot.WriteListBegin();
					foreach(string _item0 in structs.GetOrders()){
						
						oprot.WriteString(_item0);
						
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
			
			
			public void Validate(getDeliveryInfo_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getInventoryCancelledOrders_argsHelper : TBeanSerializer<getInventoryCancelledOrders_args>
		{
			
			public static getInventoryCancelledOrders_argsHelper OBJ = new getInventoryCancelledOrders_argsHelper();
			
			public static getInventoryCancelledOrders_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getInventoryCancelledOrders_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.order.InventoryCancelledOrdersRequest value;
					
					value = new vipapis.order.InventoryCancelledOrdersRequest();
					vipapis.order.InventoryCancelledOrdersRequestHelper.getInstance().Read(value, iprot);
					
					structs.SetInventoryCancelledOrdersRequest(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getInventoryCancelledOrders_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetInventoryCancelledOrdersRequest() != null) {
					
					oprot.WriteFieldBegin("inventoryCancelledOrdersRequest");
					
					vipapis.order.InventoryCancelledOrdersRequestHelper.getInstance().Write(structs.GetInventoryCancelledOrdersRequest(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getInventoryCancelledOrders_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getInventoryDeductOrders_argsHelper : TBeanSerializer<getInventoryDeductOrders_args>
		{
			
			public static getInventoryDeductOrders_argsHelper OBJ = new getInventoryDeductOrders_argsHelper();
			
			public static getInventoryDeductOrders_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getInventoryDeductOrders_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.order.InventoryDeductOrdersRequest value;
					
					value = new vipapis.order.InventoryDeductOrdersRequest();
					vipapis.order.InventoryDeductOrdersRequestHelper.getInstance().Read(value, iprot);
					
					structs.SetInventoryDeductOrdersRequest(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getInventoryDeductOrders_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetInventoryDeductOrdersRequest() != null) {
					
					oprot.WriteFieldBegin("inventoryDeductOrdersRequest");
					
					vipapis.order.InventoryDeductOrdersRequestHelper.getInstance().Write(structs.GetInventoryDeductOrdersRequest(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getInventoryDeductOrders_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getInventoryOccupiedOrders_argsHelper : TBeanSerializer<getInventoryOccupiedOrders_args>
		{
			
			public static getInventoryOccupiedOrders_argsHelper OBJ = new getInventoryOccupiedOrders_argsHelper();
			
			public static getInventoryOccupiedOrders_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getInventoryOccupiedOrders_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.order.InventoryOccupiedOrdersRequest value;
					
					value = new vipapis.order.InventoryOccupiedOrdersRequest();
					vipapis.order.InventoryOccupiedOrdersRequestHelper.getInstance().Read(value, iprot);
					
					structs.SetInventoryOccupiedOrdersRequest(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getInventoryOccupiedOrders_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetInventoryOccupiedOrdersRequest() != null) {
					
					oprot.WriteFieldBegin("inventoryOccupiedOrdersRequest");
					
					vipapis.order.InventoryOccupiedOrdersRequestHelper.getInstance().Write(structs.GetInventoryOccupiedOrdersRequest(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getInventoryOccupiedOrders_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getOmniCancelledOrders_argsHelper : TBeanSerializer<getOmniCancelledOrders_args>
		{
			
			public static getOmniCancelledOrders_argsHelper OBJ = new getOmniCancelledOrders_argsHelper();
			
			public static getOmniCancelledOrders_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getOmniCancelledOrders_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					long value;
					value = iprot.ReadI64(); 
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				
				if(true){
					
					long? value;
					value = iprot.ReadI64(); 
					
					structs.SetBrand_id(value);
				}
				
				
				
				
				
				if(true){
					
					byte? value;
					value = iprot.ReadByte(); 
					
					structs.SetOrder_type(value);
				}
				
				
				
				
				
				if(true){
					
					long value;
					value = iprot.ReadI64(); 
					
					structs.SetSt_query_time(value);
				}
				
				
				
				
				
				if(true){
					
					long value;
					value = iprot.ReadI64(); 
					
					structs.SetEt_query_time(value);
				}
				
				
				
				
				
				if(true){
					
					int? value;
					value = iprot.ReadI32(); 
					
					structs.SetLimit(value);
				}
				
				
				
				
				
				if(true){
					
					int? value;
					value = iprot.ReadI32(); 
					
					structs.SetPage(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getOmniCancelledOrders_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetVendor_id() != null) {
					
					oprot.WriteFieldBegin("vendor_id");
					oprot.WriteI64((long)structs.GetVendor_id()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("vendor_id can not be null!");
				}
				
				
				if(structs.GetBrand_id() != null) {
					
					oprot.WriteFieldBegin("brand_id");
					oprot.WriteI64((long)structs.GetBrand_id()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetOrder_type() != null) {
					
					oprot.WriteFieldBegin("order_type");
					oprot.WriteByte((byte)structs.GetOrder_type()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetSt_query_time() != null) {
					
					oprot.WriteFieldBegin("st_query_time");
					oprot.WriteI64((long)structs.GetSt_query_time()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("st_query_time can not be null!");
				}
				
				
				if(structs.GetEt_query_time() != null) {
					
					oprot.WriteFieldBegin("et_query_time");
					oprot.WriteI64((long)structs.GetEt_query_time()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("et_query_time can not be null!");
				}
				
				
				if(structs.GetLimit() != null) {
					
					oprot.WriteFieldBegin("limit");
					oprot.WriteI32((int)structs.GetLimit()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetPage() != null) {
					
					oprot.WriteFieldBegin("page");
					oprot.WriteI32((int)structs.GetPage()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getOmniCancelledOrders_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getOmniOrders_argsHelper : TBeanSerializer<getOmniOrders_args>
		{
			
			public static getOmniOrders_argsHelper OBJ = new getOmniOrders_argsHelper();
			
			public static getOmniOrders_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getOmniOrders_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					long value;
					value = iprot.ReadI64(); 
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				
				if(true){
					
					long? value;
					value = iprot.ReadI64(); 
					
					structs.SetBrand_id(value);
				}
				
				
				
				
				
				if(true){
					
					byte? value;
					value = iprot.ReadByte(); 
					
					structs.SetBusiness_type(value);
				}
				
				
				
				
				
				if(true){
					
					long value;
					value = iprot.ReadI64(); 
					
					structs.SetSt_query_time(value);
				}
				
				
				
				
				
				if(true){
					
					long value;
					value = iprot.ReadI64(); 
					
					structs.SetEt_query_time(value);
				}
				
				
				
				
				
				if(true){
					
					int? value;
					value = iprot.ReadI32(); 
					
					structs.SetLimit(value);
				}
				
				
				
				
				
				if(true){
					
					int? value;
					value = iprot.ReadI32(); 
					
					structs.SetPage(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getOmniOrders_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetVendor_id() != null) {
					
					oprot.WriteFieldBegin("vendor_id");
					oprot.WriteI64((long)structs.GetVendor_id()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("vendor_id can not be null!");
				}
				
				
				if(structs.GetBrand_id() != null) {
					
					oprot.WriteFieldBegin("brand_id");
					oprot.WriteI64((long)structs.GetBrand_id()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetBusiness_type() != null) {
					
					oprot.WriteFieldBegin("business_type");
					oprot.WriteByte((byte)structs.GetBusiness_type()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetSt_query_time() != null) {
					
					oprot.WriteFieldBegin("st_query_time");
					oprot.WriteI64((long)structs.GetSt_query_time()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("st_query_time can not be null!");
				}
				
				
				if(structs.GetEt_query_time() != null) {
					
					oprot.WriteFieldBegin("et_query_time");
					oprot.WriteI64((long)structs.GetEt_query_time()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("et_query_time can not be null!");
				}
				
				
				if(structs.GetLimit() != null) {
					
					oprot.WriteFieldBegin("limit");
					oprot.WriteI32((int)structs.GetLimit()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetPage() != null) {
					
					oprot.WriteFieldBegin("page");
					oprot.WriteI32((int)structs.GetPage()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getOmniOrders_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getOrderEInvoiceInfo_argsHelper : TBeanSerializer<getOrderEInvoiceInfo_args>
		{
			
			public static getOrderEInvoiceInfo_argsHelper OBJ = new getOrderEInvoiceInfo_argsHelper();
			
			public static getOrderEInvoiceInfo_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getOrderEInvoiceInfo_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetVendorId(value);
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
					
					structs.SetOrders(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getOrderEInvoiceInfo_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetVendorId() != null) {
					
					oprot.WriteFieldBegin("vendorId");
					oprot.WriteI32((int)structs.GetVendorId()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("vendorId can not be null!");
				}
				
				
				if(structs.GetOrders() != null) {
					
					oprot.WriteFieldBegin("orders");
					
					oprot.WriteListBegin();
					foreach(string _item0 in structs.GetOrders()){
						
						oprot.WriteString(_item0);
						
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
			
			
			public void Validate(getOrderEInvoiceInfo_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getOrderInvoice_argsHelper : TBeanSerializer<getOrderInvoice_args>
		{
			
			public static getOrderInvoice_argsHelper OBJ = new getOrderInvoice_argsHelper();
			
			public static getOrderInvoice_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getOrderInvoice_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetVendor_id(value);
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
					
					structs.SetOrders(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getOrderInvoice_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetVendor_id() != null) {
					
					oprot.WriteFieldBegin("vendor_id");
					oprot.WriteI32((int)structs.GetVendor_id()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("vendor_id can not be null!");
				}
				
				
				if(structs.GetOrders() != null) {
					
					oprot.WriteFieldBegin("orders");
					
					oprot.WriteListBegin();
					foreach(string _item0 in structs.GetOrders()){
						
						oprot.WriteString(_item0);
						
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
			
			
			public void Validate(getOrderInvoice_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getOxoOrders_argsHelper : TBeanSerializer<getOxoOrders_args>
		{
			
			public static getOxoOrders_argsHelper OBJ = new getOxoOrders_argsHelper();
			
			public static getOxoOrders_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getOxoOrders_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.order.OxoOrderRequest value;
					
					value = new vipapis.order.OxoOrderRequest();
					vipapis.order.OxoOrderRequestHelper.getInstance().Read(value, iprot);
					
					structs.SetOrdersRequest(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getOxoOrders_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetOrdersRequest() != null) {
					
					oprot.WriteFieldBegin("ordersRequest");
					
					vipapis.order.OxoOrderRequestHelper.getInstance().Write(structs.GetOrdersRequest(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getOxoOrders_args bean){
				
				
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
		
		
		
		
		public class printInvoice_argsHelper : TBeanSerializer<printInvoice_args>
		{
			
			public static printInvoice_argsHelper OBJ = new printInvoice_argsHelper();
			
			public static printInvoice_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(printInvoice_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					long value;
					value = iprot.ReadI64(); 
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetStore_sn(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetBatch_no(value);
				}
				
				
				
				
				
				if(true){
					
					List<vipapis.order.OrderSeq> value;
					
					value = new List<vipapis.order.OrderSeq>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							vipapis.order.OrderSeq elem0;
							
							elem0 = new vipapis.order.OrderSeq();
							vipapis.order.OrderSeqHelper.getInstance().Read(elem0, iprot);
							
							value.Add(elem0);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetOrders(value);
				}
				
				
				
				
				
				if(true){
					
					vipapis.order.ExtInfo value;
					
					value = new vipapis.order.ExtInfo();
					vipapis.order.ExtInfoHelper.getInstance().Read(value, iprot);
					
					structs.SetExt_info(value);
				}
				
				
				
				
				
				if(true){
					
					int? value;
					value = iprot.ReadI32(); 
					
					structs.SetPrint_type(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(printInvoice_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetVendor_id() != null) {
					
					oprot.WriteFieldBegin("vendor_id");
					oprot.WriteI64((long)structs.GetVendor_id()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("vendor_id can not be null!");
				}
				
				
				if(structs.GetStore_sn() != null) {
					
					oprot.WriteFieldBegin("store_sn");
					oprot.WriteString(structs.GetStore_sn());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("store_sn can not be null!");
				}
				
				
				if(structs.GetBatch_no() != null) {
					
					oprot.WriteFieldBegin("batch_no");
					oprot.WriteString(structs.GetBatch_no());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("batch_no can not be null!");
				}
				
				
				if(structs.GetOrders() != null) {
					
					oprot.WriteFieldBegin("orders");
					
					oprot.WriteListBegin();
					foreach(vipapis.order.OrderSeq _item0 in structs.GetOrders()){
						
						
						vipapis.order.OrderSeqHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("orders can not be null!");
				}
				
				
				if(structs.GetExt_info() != null) {
					
					oprot.WriteFieldBegin("ext_info");
					
					vipapis.order.ExtInfoHelper.getInstance().Write(structs.GetExt_info(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetPrint_type() != null) {
					
					oprot.WriteFieldBegin("print_type");
					oprot.WriteI32((int)structs.GetPrint_type()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(printInvoice_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class pushOrderEInvoice_argsHelper : TBeanSerializer<pushOrderEInvoice_args>
		{
			
			public static pushOrderEInvoice_argsHelper OBJ = new pushOrderEInvoice_argsHelper();
			
			public static pushOrderEInvoice_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(pushOrderEInvoice_args structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(pushOrderEInvoice_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(pushOrderEInvoice_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class pushOrderPackageWeight_argsHelper : TBeanSerializer<pushOrderPackageWeight_args>
		{
			
			public static pushOrderPackageWeight_argsHelper OBJ = new pushOrderPackageWeight_argsHelper();
			
			public static pushOrderPackageWeight_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(pushOrderPackageWeight_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					long value;
					value = iprot.ReadI64(); 
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetStore_sn(value);
				}
				
				
				
				
				
				if(true){
					
					List<vipapis.order.OrderPackageWeight> value;
					
					value = new List<vipapis.order.OrderPackageWeight>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							vipapis.order.OrderPackageWeight elem0;
							
							elem0 = new vipapis.order.OrderPackageWeight();
							vipapis.order.OrderPackageWeightHelper.getInstance().Read(elem0, iprot);
							
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
			
			
			public void Write(pushOrderPackageWeight_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetVendor_id() != null) {
					
					oprot.WriteFieldBegin("vendor_id");
					oprot.WriteI64((long)structs.GetVendor_id()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("vendor_id can not be null!");
				}
				
				
				if(structs.GetStore_sn() != null) {
					
					oprot.WriteFieldBegin("store_sn");
					oprot.WriteString(structs.GetStore_sn());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("store_sn can not be null!");
				}
				
				
				if(structs.GetOrders() != null) {
					
					oprot.WriteFieldBegin("orders");
					
					oprot.WriteListBegin();
					foreach(vipapis.order.OrderPackageWeight _item0 in structs.GetOrders()){
						
						
						vipapis.order.OrderPackageWeightHelper.getInstance().Write(_item0, oprot);
						
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
			
			
			public void Validate(pushOrderPackageWeight_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class pushQCResult_argsHelper : TBeanSerializer<pushQCResult_args>
		{
			
			public static pushQCResult_argsHelper OBJ = new pushQCResult_argsHelper();
			
			public static pushQCResult_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(pushQCResult_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					long value;
					value = iprot.ReadI64(); 
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetStore_sn(value);
				}
				
				
				
				
				
				if(true){
					
					List<vipapis.order.OrderQCResult> value;
					
					value = new List<vipapis.order.OrderQCResult>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							vipapis.order.OrderQCResult elem1;
							
							elem1 = new vipapis.order.OrderQCResult();
							vipapis.order.OrderQCResultHelper.getInstance().Read(elem1, iprot);
							
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
			
			
			public void Write(pushQCResult_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetVendor_id() != null) {
					
					oprot.WriteFieldBegin("vendor_id");
					oprot.WriteI64((long)structs.GetVendor_id()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("vendor_id can not be null!");
				}
				
				
				if(structs.GetStore_sn() != null) {
					
					oprot.WriteFieldBegin("store_sn");
					oprot.WriteString(structs.GetStore_sn());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("store_sn can not be null!");
				}
				
				
				if(structs.GetOrders() != null) {
					
					oprot.WriteFieldBegin("orders");
					
					oprot.WriteListBegin();
					foreach(vipapis.order.OrderQCResult _item0 in structs.GetOrders()){
						
						
						vipapis.order.OrderQCResultHelper.getInstance().Write(_item0, oprot);
						
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
			
			
			public void Validate(pushQCResult_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class replyStoreSn_argsHelper : TBeanSerializer<replyStoreSn_args>
		{
			
			public static replyStoreSn_argsHelper OBJ = new replyStoreSn_argsHelper();
			
			public static replyStoreSn_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(replyStoreSn_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					long value;
					value = iprot.ReadI64(); 
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				
				if(true){
					
					List<vipapis.order.OrderStoreMapping> value;
					
					value = new List<vipapis.order.OrderStoreMapping>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							vipapis.order.OrderStoreMapping elem1;
							
							elem1 = new vipapis.order.OrderStoreMapping();
							vipapis.order.OrderStoreMappingHelper.getInstance().Read(elem1, iprot);
							
							value.Add(elem1);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetOrder_store_mapping(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(replyStoreSn_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetVendor_id() != null) {
					
					oprot.WriteFieldBegin("vendor_id");
					oprot.WriteI64((long)structs.GetVendor_id()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("vendor_id can not be null!");
				}
				
				
				if(structs.GetOrder_store_mapping() != null) {
					
					oprot.WriteFieldBegin("order_store_mapping");
					
					oprot.WriteListBegin();
					foreach(vipapis.order.OrderStoreMapping _item0 in structs.GetOrder_store_mapping()){
						
						
						vipapis.order.OrderStoreMappingHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("order_store_mapping can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(replyStoreSn_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class responseOrderStore_argsHelper : TBeanSerializer<responseOrderStore_args>
		{
			
			public static responseOrderStore_argsHelper OBJ = new responseOrderStore_argsHelper();
			
			public static responseOrderStore_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(responseOrderStore_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					long value;
					value = iprot.ReadI64(); 
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetOrder_id(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetStore_sn(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(responseOrderStore_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetVendor_id() != null) {
					
					oprot.WriteFieldBegin("vendor_id");
					oprot.WriteI64((long)structs.GetVendor_id()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("vendor_id can not be null!");
				}
				
				
				if(structs.GetOrder_id() != null) {
					
					oprot.WriteFieldBegin("order_id");
					oprot.WriteString(structs.GetOrder_id());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("order_id can not be null!");
				}
				
				
				if(structs.GetStore_sn() != null) {
					
					oprot.WriteFieldBegin("store_sn");
					oprot.WriteString(structs.GetStore_sn());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("store_sn can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(responseOrderStore_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class updateStoreSn_argsHelper : TBeanSerializer<updateStoreSn_args>
		{
			
			public static updateStoreSn_argsHelper OBJ = new updateStoreSn_argsHelper();
			
			public static updateStoreSn_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(updateStoreSn_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					long value;
					value = iprot.ReadI64(); 
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				
				if(true){
					
					List<vipapis.order.OrderStoreMappingEx> value;
					
					value = new List<vipapis.order.OrderStoreMappingEx>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							vipapis.order.OrderStoreMappingEx elem0;
							
							elem0 = new vipapis.order.OrderStoreMappingEx();
							vipapis.order.OrderStoreMappingExHelper.getInstance().Read(elem0, iprot);
							
							value.Add(elem0);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetOrder_store_mapping(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(updateStoreSn_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetVendor_id() != null) {
					
					oprot.WriteFieldBegin("vendor_id");
					oprot.WriteI64((long)structs.GetVendor_id()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("vendor_id can not be null!");
				}
				
				
				if(structs.GetOrder_store_mapping() != null) {
					
					oprot.WriteFieldBegin("order_store_mapping");
					
					oprot.WriteListBegin();
					foreach(vipapis.order.OrderStoreMappingEx _item0 in structs.GetOrder_store_mapping()){
						
						
						vipapis.order.OrderStoreMappingExHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("order_store_mapping can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(updateStoreSn_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class confirmInvoice_resultHelper : TBeanSerializer<confirmInvoice_result>
		{
			
			public static confirmInvoice_resultHelper OBJ = new confirmInvoice_resultHelper();
			
			public static confirmInvoice_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(confirmInvoice_result structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(confirmInvoice_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(confirmInvoice_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class confirmOrderInvoice_resultHelper : TBeanSerializer<confirmOrderInvoice_result>
		{
			
			public static confirmOrderInvoice_resultHelper OBJ = new confirmOrderInvoice_resultHelper();
			
			public static confirmOrderInvoice_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(confirmOrderInvoice_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.order.OrderInvoiceConfirmResp value;
					
					value = new vipapis.order.OrderInvoiceConfirmResp();
					vipapis.order.OrderInvoiceConfirmRespHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(confirmOrderInvoice_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.order.OrderInvoiceConfirmRespHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(confirmOrderInvoice_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class confirmOxoDelivery_resultHelper : TBeanSerializer<confirmOxoDelivery_result>
		{
			
			public static confirmOxoDelivery_resultHelper OBJ = new confirmOxoDelivery_resultHelper();
			
			public static confirmOxoDelivery_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(confirmOxoDelivery_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.order.ConfirmDeliveryResp value;
					
					value = new vipapis.order.ConfirmDeliveryResp();
					vipapis.order.ConfirmDeliveryRespHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(confirmOxoDelivery_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.order.ConfirmDeliveryRespHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(confirmOxoDelivery_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class confirmOxoShipment_resultHelper : TBeanSerializer<confirmOxoShipment_result>
		{
			
			public static confirmOxoShipment_resultHelper OBJ = new confirmOxoShipment_resultHelper();
			
			public static confirmOxoShipment_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(confirmOxoShipment_result structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(confirmOxoShipment_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(confirmOxoShipment_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class confirmStoreDelivery_resultHelper : TBeanSerializer<confirmStoreDelivery_result>
		{
			
			public static confirmStoreDelivery_resultHelper OBJ = new confirmStoreDelivery_resultHelper();
			
			public static confirmStoreDelivery_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(confirmStoreDelivery_result structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(confirmStoreDelivery_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(confirmStoreDelivery_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getDeliveryInfo_resultHelper : TBeanSerializer<getDeliveryInfo_result>
		{
			
			public static getDeliveryInfo_resultHelper OBJ = new getDeliveryInfo_resultHelper();
			
			public static getDeliveryInfo_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getDeliveryInfo_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					List<vipapis.order.OrderDeliveryInfo> value;
					
					value = new List<vipapis.order.OrderDeliveryInfo>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							vipapis.order.OrderDeliveryInfo elem0;
							
							elem0 = new vipapis.order.OrderDeliveryInfo();
							vipapis.order.OrderDeliveryInfoHelper.getInstance().Read(elem0, iprot);
							
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
			
			
			public void Write(getDeliveryInfo_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					oprot.WriteListBegin();
					foreach(vipapis.order.OrderDeliveryInfo _item0 in structs.GetSuccess()){
						
						
						vipapis.order.OrderDeliveryInfoHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getDeliveryInfo_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getInventoryCancelledOrders_resultHelper : TBeanSerializer<getInventoryCancelledOrders_result>
		{
			
			public static getInventoryCancelledOrders_resultHelper OBJ = new getInventoryCancelledOrders_resultHelper();
			
			public static getInventoryCancelledOrders_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getInventoryCancelledOrders_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.order.CancelledOrdersResponse value;
					
					value = new vipapis.order.CancelledOrdersResponse();
					vipapis.order.CancelledOrdersResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getInventoryCancelledOrders_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.order.CancelledOrdersResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getInventoryCancelledOrders_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getInventoryDeductOrders_resultHelper : TBeanSerializer<getInventoryDeductOrders_result>
		{
			
			public static getInventoryDeductOrders_resultHelper OBJ = new getInventoryDeductOrders_resultHelper();
			
			public static getInventoryDeductOrders_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getInventoryDeductOrders_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.order.InventoryDeductOrdersResponse value;
					
					value = new vipapis.order.InventoryDeductOrdersResponse();
					vipapis.order.InventoryDeductOrdersResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getInventoryDeductOrders_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.order.InventoryDeductOrdersResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getInventoryDeductOrders_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getInventoryOccupiedOrders_resultHelper : TBeanSerializer<getInventoryOccupiedOrders_result>
		{
			
			public static getInventoryOccupiedOrders_resultHelper OBJ = new getInventoryOccupiedOrders_resultHelper();
			
			public static getInventoryOccupiedOrders_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getInventoryOccupiedOrders_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.order.OccupiedOrderResponse value;
					
					value = new vipapis.order.OccupiedOrderResponse();
					vipapis.order.OccupiedOrderResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getInventoryOccupiedOrders_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.order.OccupiedOrderResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getInventoryOccupiedOrders_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getOmniCancelledOrders_resultHelper : TBeanSerializer<getOmniCancelledOrders_result>
		{
			
			public static getOmniCancelledOrders_resultHelper OBJ = new getOmniCancelledOrders_resultHelper();
			
			public static getOmniCancelledOrders_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getOmniCancelledOrders_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.order.GetOmniCancelledOrdersResp value;
					
					value = new vipapis.order.GetOmniCancelledOrdersResp();
					vipapis.order.GetOmniCancelledOrdersRespHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getOmniCancelledOrders_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.order.GetOmniCancelledOrdersRespHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getOmniCancelledOrders_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getOmniOrders_resultHelper : TBeanSerializer<getOmniOrders_result>
		{
			
			public static getOmniOrders_resultHelper OBJ = new getOmniOrders_resultHelper();
			
			public static getOmniOrders_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getOmniOrders_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.order.GetOmniOrdersResp value;
					
					value = new vipapis.order.GetOmniOrdersResp();
					vipapis.order.GetOmniOrdersRespHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getOmniOrders_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.order.GetOmniOrdersRespHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getOmniOrders_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getOrderEInvoiceInfo_resultHelper : TBeanSerializer<getOrderEInvoiceInfo_result>
		{
			
			public static getOrderEInvoiceInfo_resultHelper OBJ = new getOrderEInvoiceInfo_resultHelper();
			
			public static getOrderEInvoiceInfo_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getOrderEInvoiceInfo_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					List<vipapis.order.EInvoiceInfo> value;
					
					value = new List<vipapis.order.EInvoiceInfo>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							vipapis.order.EInvoiceInfo elem0;
							
							elem0 = new vipapis.order.EInvoiceInfo();
							vipapis.order.EInvoiceInfoHelper.getInstance().Read(elem0, iprot);
							
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
			
			
			public void Write(getOrderEInvoiceInfo_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					oprot.WriteListBegin();
					foreach(vipapis.order.EInvoiceInfo _item0 in structs.GetSuccess()){
						
						
						vipapis.order.EInvoiceInfoHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getOrderEInvoiceInfo_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getOrderInvoice_resultHelper : TBeanSerializer<getOrderInvoice_result>
		{
			
			public static getOrderInvoice_resultHelper OBJ = new getOrderInvoice_resultHelper();
			
			public static getOrderInvoice_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getOrderInvoice_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.order.OrderInvoiceQueryResp value;
					
					value = new vipapis.order.OrderInvoiceQueryResp();
					vipapis.order.OrderInvoiceQueryRespHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getOrderInvoice_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.order.OrderInvoiceQueryRespHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getOrderInvoice_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getOxoOrders_resultHelper : TBeanSerializer<getOxoOrders_result>
		{
			
			public static getOxoOrders_resultHelper OBJ = new getOxoOrders_resultHelper();
			
			public static getOxoOrders_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getOxoOrders_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.order.OxoOrderResponse value;
					
					value = new vipapis.order.OxoOrderResponse();
					vipapis.order.OxoOrderResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getOxoOrders_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.order.OxoOrderResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getOxoOrders_result bean){
				
				
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
		
		
		
		
		public class printInvoice_resultHelper : TBeanSerializer<printInvoice_result>
		{
			
			public static printInvoice_resultHelper OBJ = new printInvoice_resultHelper();
			
			public static printInvoice_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(printInvoice_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.order.PrintInvoiceResp value;
					
					value = new vipapis.order.PrintInvoiceResp();
					vipapis.order.PrintInvoiceRespHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(printInvoice_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.order.PrintInvoiceRespHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(printInvoice_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class pushOrderEInvoice_resultHelper : TBeanSerializer<pushOrderEInvoice_result>
		{
			
			public static pushOrderEInvoice_resultHelper OBJ = new pushOrderEInvoice_resultHelper();
			
			public static pushOrderEInvoice_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(pushOrderEInvoice_result structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(pushOrderEInvoice_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(pushOrderEInvoice_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class pushOrderPackageWeight_resultHelper : TBeanSerializer<pushOrderPackageWeight_result>
		{
			
			public static pushOrderPackageWeight_resultHelper OBJ = new pushOrderPackageWeight_resultHelper();
			
			public static pushOrderPackageWeight_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(pushOrderPackageWeight_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.order.PushOrderPackageWeightResp value;
					
					value = new vipapis.order.PushOrderPackageWeightResp();
					vipapis.order.PushOrderPackageWeightRespHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(pushOrderPackageWeight_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.order.PushOrderPackageWeightRespHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(pushOrderPackageWeight_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class pushQCResult_resultHelper : TBeanSerializer<pushQCResult_result>
		{
			
			public static pushQCResult_resultHelper OBJ = new pushQCResult_resultHelper();
			
			public static pushQCResult_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(pushQCResult_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.order.PushQCResultResp value;
					
					value = new vipapis.order.PushQCResultResp();
					vipapis.order.PushQCResultRespHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(pushQCResult_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.order.PushQCResultRespHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(pushQCResult_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class replyStoreSn_resultHelper : TBeanSerializer<replyStoreSn_result>
		{
			
			public static replyStoreSn_resultHelper OBJ = new replyStoreSn_resultHelper();
			
			public static replyStoreSn_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(replyStoreSn_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.order.ReplyStoreSnResp value;
					
					value = new vipapis.order.ReplyStoreSnResp();
					vipapis.order.ReplyStoreSnRespHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(replyStoreSn_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.order.ReplyStoreSnRespHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(replyStoreSn_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class responseOrderStore_resultHelper : TBeanSerializer<responseOrderStore_result>
		{
			
			public static responseOrderStore_resultHelper OBJ = new responseOrderStore_resultHelper();
			
			public static responseOrderStore_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(responseOrderStore_result structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(responseOrderStore_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(responseOrderStore_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class updateStoreSn_resultHelper : TBeanSerializer<updateStoreSn_result>
		{
			
			public static updateStoreSn_resultHelper OBJ = new updateStoreSn_resultHelper();
			
			public static updateStoreSn_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(updateStoreSn_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.order.UpdateStoreSnResp value;
					
					value = new vipapis.order.UpdateStoreSnResp();
					vipapis.order.UpdateStoreSnRespHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(updateStoreSn_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.order.UpdateStoreSnRespHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(updateStoreSn_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class OmniOrderServiceClient : OspRestStub , OmniOrderService  {
			
			
			public OmniOrderServiceClient():base("vipapis.order.OmniOrderService","1.0.0") {
				
				
			}
			
			
			
			public void confirmInvoice(int vendor_id_,vipapis.order.OrderInvoiceReq order_invoice_) {
				
				send_confirmInvoice(vendor_id_,order_invoice_);
				recv_confirmInvoice();
				
			}
			
			
			private void send_confirmInvoice(int vendor_id_,vipapis.order.OrderInvoiceReq order_invoice_){
				
				InitInvocation("confirmInvoice");
				
				confirmInvoice_args args = new confirmInvoice_args();
				args.SetVendor_id(vendor_id_);
				args.SetOrder_invoice(order_invoice_);
				
				SendBase(args, confirmInvoice_argsHelper.getInstance());
			}
			
			
			private void recv_confirmInvoice(){
				
				confirmInvoice_result result = new confirmInvoice_result();
				ReceiveBase(result, confirmInvoice_resultHelper.getInstance());
				
				
			}
			
			
			public vipapis.order.OrderInvoiceConfirmResp confirmOrderInvoice(int vendor_id_,List<vipapis.order.OrderInvoiceReq> order_invoices_) {
				
				send_confirmOrderInvoice(vendor_id_,order_invoices_);
				return recv_confirmOrderInvoice(); 
				
			}
			
			
			private void send_confirmOrderInvoice(int vendor_id_,List<vipapis.order.OrderInvoiceReq> order_invoices_){
				
				InitInvocation("confirmOrderInvoice");
				
				confirmOrderInvoice_args args = new confirmOrderInvoice_args();
				args.SetVendor_id(vendor_id_);
				args.SetOrder_invoices(order_invoices_);
				
				SendBase(args, confirmOrderInvoice_argsHelper.getInstance());
			}
			
			
			private vipapis.order.OrderInvoiceConfirmResp recv_confirmOrderInvoice(){
				
				confirmOrderInvoice_result result = new confirmOrderInvoice_result();
				ReceiveBase(result, confirmOrderInvoice_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public vipapis.order.ConfirmDeliveryResp confirmOxoDelivery(long vendor_id_,string order_id_,string store_sn_,byte? notice_type_,string package_no_,long? estimate_delivery_time_) {
				
				send_confirmOxoDelivery(vendor_id_,order_id_,store_sn_,notice_type_,package_no_,estimate_delivery_time_);
				return recv_confirmOxoDelivery(); 
				
			}
			
			
			private void send_confirmOxoDelivery(long vendor_id_,string order_id_,string store_sn_,byte? notice_type_,string package_no_,long? estimate_delivery_time_){
				
				InitInvocation("confirmOxoDelivery");
				
				confirmOxoDelivery_args args = new confirmOxoDelivery_args();
				args.SetVendor_id(vendor_id_);
				args.SetOrder_id(order_id_);
				args.SetStore_sn(store_sn_);
				args.SetNotice_type(notice_type_);
				args.SetPackage_no(package_no_);
				args.SetEstimate_delivery_time(estimate_delivery_time_);
				
				SendBase(args, confirmOxoDelivery_argsHelper.getInstance());
			}
			
			
			private vipapis.order.ConfirmDeliveryResp recv_confirmOxoDelivery(){
				
				confirmOxoDelivery_result result = new confirmOxoDelivery_result();
				ReceiveBase(result, confirmOxoDelivery_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public void confirmOxoShipment(long vendor_id_,string order_id_,string store_sn_,string carrier_name_,string carrier_code_,string transport_no_) {
				
				send_confirmOxoShipment(vendor_id_,order_id_,store_sn_,carrier_name_,carrier_code_,transport_no_);
				recv_confirmOxoShipment();
				
			}
			
			
			private void send_confirmOxoShipment(long vendor_id_,string order_id_,string store_sn_,string carrier_name_,string carrier_code_,string transport_no_){
				
				InitInvocation("confirmOxoShipment");
				
				confirmOxoShipment_args args = new confirmOxoShipment_args();
				args.SetVendor_id(vendor_id_);
				args.SetOrder_id(order_id_);
				args.SetStore_sn(store_sn_);
				args.SetCarrier_name(carrier_name_);
				args.SetCarrier_code(carrier_code_);
				args.SetTransport_no(transport_no_);
				
				SendBase(args, confirmOxoShipment_argsHelper.getInstance());
			}
			
			
			private void recv_confirmOxoShipment(){
				
				confirmOxoShipment_result result = new confirmOxoShipment_result();
				ReceiveBase(result, confirmOxoShipment_resultHelper.getInstance());
				
				
			}
			
			
			public void confirmStoreDelivery(long vendor_id_,string order_id_,string store_sn_,string package_no_,long? estimate_delivery_time_) {
				
				send_confirmStoreDelivery(vendor_id_,order_id_,store_sn_,package_no_,estimate_delivery_time_);
				recv_confirmStoreDelivery();
				
			}
			
			
			private void send_confirmStoreDelivery(long vendor_id_,string order_id_,string store_sn_,string package_no_,long? estimate_delivery_time_){
				
				InitInvocation("confirmStoreDelivery");
				
				confirmStoreDelivery_args args = new confirmStoreDelivery_args();
				args.SetVendor_id(vendor_id_);
				args.SetOrder_id(order_id_);
				args.SetStore_sn(store_sn_);
				args.SetPackage_no(package_no_);
				args.SetEstimate_delivery_time(estimate_delivery_time_);
				
				SendBase(args, confirmStoreDelivery_argsHelper.getInstance());
			}
			
			
			private void recv_confirmStoreDelivery(){
				
				confirmStoreDelivery_result result = new confirmStoreDelivery_result();
				ReceiveBase(result, confirmStoreDelivery_resultHelper.getInstance());
				
				
			}
			
			
			public List<vipapis.order.OrderDeliveryInfo> getDeliveryInfo(int vendor_id_,string store_sn_,List<string> orders_) {
				
				send_getDeliveryInfo(vendor_id_,store_sn_,orders_);
				return recv_getDeliveryInfo(); 
				
			}
			
			
			private void send_getDeliveryInfo(int vendor_id_,string store_sn_,List<string> orders_){
				
				InitInvocation("getDeliveryInfo");
				
				getDeliveryInfo_args args = new getDeliveryInfo_args();
				args.SetVendor_id(vendor_id_);
				args.SetStore_sn(store_sn_);
				args.SetOrders(orders_);
				
				SendBase(args, getDeliveryInfo_argsHelper.getInstance());
			}
			
			
			private List<vipapis.order.OrderDeliveryInfo> recv_getDeliveryInfo(){
				
				getDeliveryInfo_result result = new getDeliveryInfo_result();
				ReceiveBase(result, getDeliveryInfo_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public vipapis.order.CancelledOrdersResponse getInventoryCancelledOrders(vipapis.order.InventoryCancelledOrdersRequest inventoryCancelledOrdersRequest_) {
				
				send_getInventoryCancelledOrders(inventoryCancelledOrdersRequest_);
				return recv_getInventoryCancelledOrders(); 
				
			}
			
			
			private void send_getInventoryCancelledOrders(vipapis.order.InventoryCancelledOrdersRequest inventoryCancelledOrdersRequest_){
				
				InitInvocation("getInventoryCancelledOrders");
				
				getInventoryCancelledOrders_args args = new getInventoryCancelledOrders_args();
				args.SetInventoryCancelledOrdersRequest(inventoryCancelledOrdersRequest_);
				
				SendBase(args, getInventoryCancelledOrders_argsHelper.getInstance());
			}
			
			
			private vipapis.order.CancelledOrdersResponse recv_getInventoryCancelledOrders(){
				
				getInventoryCancelledOrders_result result = new getInventoryCancelledOrders_result();
				ReceiveBase(result, getInventoryCancelledOrders_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public vipapis.order.InventoryDeductOrdersResponse getInventoryDeductOrders(vipapis.order.InventoryDeductOrdersRequest inventoryDeductOrdersRequest_) {
				
				send_getInventoryDeductOrders(inventoryDeductOrdersRequest_);
				return recv_getInventoryDeductOrders(); 
				
			}
			
			
			private void send_getInventoryDeductOrders(vipapis.order.InventoryDeductOrdersRequest inventoryDeductOrdersRequest_){
				
				InitInvocation("getInventoryDeductOrders");
				
				getInventoryDeductOrders_args args = new getInventoryDeductOrders_args();
				args.SetInventoryDeductOrdersRequest(inventoryDeductOrdersRequest_);
				
				SendBase(args, getInventoryDeductOrders_argsHelper.getInstance());
			}
			
			
			private vipapis.order.InventoryDeductOrdersResponse recv_getInventoryDeductOrders(){
				
				getInventoryDeductOrders_result result = new getInventoryDeductOrders_result();
				ReceiveBase(result, getInventoryDeductOrders_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public vipapis.order.OccupiedOrderResponse getInventoryOccupiedOrders(vipapis.order.InventoryOccupiedOrdersRequest inventoryOccupiedOrdersRequest_) {
				
				send_getInventoryOccupiedOrders(inventoryOccupiedOrdersRequest_);
				return recv_getInventoryOccupiedOrders(); 
				
			}
			
			
			private void send_getInventoryOccupiedOrders(vipapis.order.InventoryOccupiedOrdersRequest inventoryOccupiedOrdersRequest_){
				
				InitInvocation("getInventoryOccupiedOrders");
				
				getInventoryOccupiedOrders_args args = new getInventoryOccupiedOrders_args();
				args.SetInventoryOccupiedOrdersRequest(inventoryOccupiedOrdersRequest_);
				
				SendBase(args, getInventoryOccupiedOrders_argsHelper.getInstance());
			}
			
			
			private vipapis.order.OccupiedOrderResponse recv_getInventoryOccupiedOrders(){
				
				getInventoryOccupiedOrders_result result = new getInventoryOccupiedOrders_result();
				ReceiveBase(result, getInventoryOccupiedOrders_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public vipapis.order.GetOmniCancelledOrdersResp getOmniCancelledOrders(long vendor_id_,long? brand_id_,byte? order_type_,long st_query_time_,long et_query_time_,int? limit_,int? page_) {
				
				send_getOmniCancelledOrders(vendor_id_,brand_id_,order_type_,st_query_time_,et_query_time_,limit_,page_);
				return recv_getOmniCancelledOrders(); 
				
			}
			
			
			private void send_getOmniCancelledOrders(long vendor_id_,long? brand_id_,byte? order_type_,long st_query_time_,long et_query_time_,int? limit_,int? page_){
				
				InitInvocation("getOmniCancelledOrders");
				
				getOmniCancelledOrders_args args = new getOmniCancelledOrders_args();
				args.SetVendor_id(vendor_id_);
				args.SetBrand_id(brand_id_);
				args.SetOrder_type(order_type_);
				args.SetSt_query_time(st_query_time_);
				args.SetEt_query_time(et_query_time_);
				args.SetLimit(limit_);
				args.SetPage(page_);
				
				SendBase(args, getOmniCancelledOrders_argsHelper.getInstance());
			}
			
			
			private vipapis.order.GetOmniCancelledOrdersResp recv_getOmniCancelledOrders(){
				
				getOmniCancelledOrders_result result = new getOmniCancelledOrders_result();
				ReceiveBase(result, getOmniCancelledOrders_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public vipapis.order.GetOmniOrdersResp getOmniOrders(long vendor_id_,long? brand_id_,byte? business_type_,long st_query_time_,long et_query_time_,int? limit_,int? page_) {
				
				send_getOmniOrders(vendor_id_,brand_id_,business_type_,st_query_time_,et_query_time_,limit_,page_);
				return recv_getOmniOrders(); 
				
			}
			
			
			private void send_getOmniOrders(long vendor_id_,long? brand_id_,byte? business_type_,long st_query_time_,long et_query_time_,int? limit_,int? page_){
				
				InitInvocation("getOmniOrders");
				
				getOmniOrders_args args = new getOmniOrders_args();
				args.SetVendor_id(vendor_id_);
				args.SetBrand_id(brand_id_);
				args.SetBusiness_type(business_type_);
				args.SetSt_query_time(st_query_time_);
				args.SetEt_query_time(et_query_time_);
				args.SetLimit(limit_);
				args.SetPage(page_);
				
				SendBase(args, getOmniOrders_argsHelper.getInstance());
			}
			
			
			private vipapis.order.GetOmniOrdersResp recv_getOmniOrders(){
				
				getOmniOrders_result result = new getOmniOrders_result();
				ReceiveBase(result, getOmniOrders_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public List<vipapis.order.EInvoiceInfo> getOrderEInvoiceInfo(int vendorId_,List<string> orders_) {
				
				send_getOrderEInvoiceInfo(vendorId_,orders_);
				return recv_getOrderEInvoiceInfo(); 
				
			}
			
			
			private void send_getOrderEInvoiceInfo(int vendorId_,List<string> orders_){
				
				InitInvocation("getOrderEInvoiceInfo");
				
				getOrderEInvoiceInfo_args args = new getOrderEInvoiceInfo_args();
				args.SetVendorId(vendorId_);
				args.SetOrders(orders_);
				
				SendBase(args, getOrderEInvoiceInfo_argsHelper.getInstance());
			}
			
			
			private List<vipapis.order.EInvoiceInfo> recv_getOrderEInvoiceInfo(){
				
				getOrderEInvoiceInfo_result result = new getOrderEInvoiceInfo_result();
				ReceiveBase(result, getOrderEInvoiceInfo_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public vipapis.order.OrderInvoiceQueryResp getOrderInvoice(int vendor_id_,List<string> orders_) {
				
				send_getOrderInvoice(vendor_id_,orders_);
				return recv_getOrderInvoice(); 
				
			}
			
			
			private void send_getOrderInvoice(int vendor_id_,List<string> orders_){
				
				InitInvocation("getOrderInvoice");
				
				getOrderInvoice_args args = new getOrderInvoice_args();
				args.SetVendor_id(vendor_id_);
				args.SetOrders(orders_);
				
				SendBase(args, getOrderInvoice_argsHelper.getInstance());
			}
			
			
			private vipapis.order.OrderInvoiceQueryResp recv_getOrderInvoice(){
				
				getOrderInvoice_result result = new getOrderInvoice_result();
				ReceiveBase(result, getOrderInvoice_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public vipapis.order.OxoOrderResponse getOxoOrders(vipapis.order.OxoOrderRequest ordersRequest_) {
				
				send_getOxoOrders(ordersRequest_);
				return recv_getOxoOrders(); 
				
			}
			
			
			private void send_getOxoOrders(vipapis.order.OxoOrderRequest ordersRequest_){
				
				InitInvocation("getOxoOrders");
				
				getOxoOrders_args args = new getOxoOrders_args();
				args.SetOrdersRequest(ordersRequest_);
				
				SendBase(args, getOxoOrders_argsHelper.getInstance());
			}
			
			
			private vipapis.order.OxoOrderResponse recv_getOxoOrders(){
				
				getOxoOrders_result result = new getOxoOrders_result();
				ReceiveBase(result, getOxoOrders_resultHelper.getInstance());
				
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
			
			
			public vipapis.order.PrintInvoiceResp printInvoice(long vendor_id_,string store_sn_,string batch_no_,List<vipapis.order.OrderSeq> orders_,vipapis.order.ExtInfo ext_info_,int? print_type_) {
				
				send_printInvoice(vendor_id_,store_sn_,batch_no_,orders_,ext_info_,print_type_);
				return recv_printInvoice(); 
				
			}
			
			
			private void send_printInvoice(long vendor_id_,string store_sn_,string batch_no_,List<vipapis.order.OrderSeq> orders_,vipapis.order.ExtInfo ext_info_,int? print_type_){
				
				InitInvocation("printInvoice");
				
				printInvoice_args args = new printInvoice_args();
				args.SetVendor_id(vendor_id_);
				args.SetStore_sn(store_sn_);
				args.SetBatch_no(batch_no_);
				args.SetOrders(orders_);
				args.SetExt_info(ext_info_);
				args.SetPrint_type(print_type_);
				
				SendBase(args, printInvoice_argsHelper.getInstance());
			}
			
			
			private vipapis.order.PrintInvoiceResp recv_printInvoice(){
				
				printInvoice_result result = new printInvoice_result();
				ReceiveBase(result, printInvoice_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public void pushOrderEInvoice() {
				
				send_pushOrderEInvoice();
				recv_pushOrderEInvoice();
				
			}
			
			
			private void send_pushOrderEInvoice(){
				
				InitInvocation("pushOrderEInvoice");
				
				pushOrderEInvoice_args args = new pushOrderEInvoice_args();
				
				SendBase(args, pushOrderEInvoice_argsHelper.getInstance());
			}
			
			
			private void recv_pushOrderEInvoice(){
				
				pushOrderEInvoice_result result = new pushOrderEInvoice_result();
				ReceiveBase(result, pushOrderEInvoice_resultHelper.getInstance());
				
				
			}
			
			
			public vipapis.order.PushOrderPackageWeightResp pushOrderPackageWeight(long vendor_id_,string store_sn_,List<vipapis.order.OrderPackageWeight> orders_) {
				
				send_pushOrderPackageWeight(vendor_id_,store_sn_,orders_);
				return recv_pushOrderPackageWeight(); 
				
			}
			
			
			private void send_pushOrderPackageWeight(long vendor_id_,string store_sn_,List<vipapis.order.OrderPackageWeight> orders_){
				
				InitInvocation("pushOrderPackageWeight");
				
				pushOrderPackageWeight_args args = new pushOrderPackageWeight_args();
				args.SetVendor_id(vendor_id_);
				args.SetStore_sn(store_sn_);
				args.SetOrders(orders_);
				
				SendBase(args, pushOrderPackageWeight_argsHelper.getInstance());
			}
			
			
			private vipapis.order.PushOrderPackageWeightResp recv_pushOrderPackageWeight(){
				
				pushOrderPackageWeight_result result = new pushOrderPackageWeight_result();
				ReceiveBase(result, pushOrderPackageWeight_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public vipapis.order.PushQCResultResp pushQCResult(long vendor_id_,string store_sn_,List<vipapis.order.OrderQCResult> orders_) {
				
				send_pushQCResult(vendor_id_,store_sn_,orders_);
				return recv_pushQCResult(); 
				
			}
			
			
			private void send_pushQCResult(long vendor_id_,string store_sn_,List<vipapis.order.OrderQCResult> orders_){
				
				InitInvocation("pushQCResult");
				
				pushQCResult_args args = new pushQCResult_args();
				args.SetVendor_id(vendor_id_);
				args.SetStore_sn(store_sn_);
				args.SetOrders(orders_);
				
				SendBase(args, pushQCResult_argsHelper.getInstance());
			}
			
			
			private vipapis.order.PushQCResultResp recv_pushQCResult(){
				
				pushQCResult_result result = new pushQCResult_result();
				ReceiveBase(result, pushQCResult_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public vipapis.order.ReplyStoreSnResp replyStoreSn(long vendor_id_,List<vipapis.order.OrderStoreMapping> order_store_mapping_) {
				
				send_replyStoreSn(vendor_id_,order_store_mapping_);
				return recv_replyStoreSn(); 
				
			}
			
			
			private void send_replyStoreSn(long vendor_id_,List<vipapis.order.OrderStoreMapping> order_store_mapping_){
				
				InitInvocation("replyStoreSn");
				
				replyStoreSn_args args = new replyStoreSn_args();
				args.SetVendor_id(vendor_id_);
				args.SetOrder_store_mapping(order_store_mapping_);
				
				SendBase(args, replyStoreSn_argsHelper.getInstance());
			}
			
			
			private vipapis.order.ReplyStoreSnResp recv_replyStoreSn(){
				
				replyStoreSn_result result = new replyStoreSn_result();
				ReceiveBase(result, replyStoreSn_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public void responseOrderStore(long vendor_id_,string order_id_,string store_sn_) {
				
				send_responseOrderStore(vendor_id_,order_id_,store_sn_);
				recv_responseOrderStore();
				
			}
			
			
			private void send_responseOrderStore(long vendor_id_,string order_id_,string store_sn_){
				
				InitInvocation("responseOrderStore");
				
				responseOrderStore_args args = new responseOrderStore_args();
				args.SetVendor_id(vendor_id_);
				args.SetOrder_id(order_id_);
				args.SetStore_sn(store_sn_);
				
				SendBase(args, responseOrderStore_argsHelper.getInstance());
			}
			
			
			private void recv_responseOrderStore(){
				
				responseOrderStore_result result = new responseOrderStore_result();
				ReceiveBase(result, responseOrderStore_resultHelper.getInstance());
				
				
			}
			
			
			public vipapis.order.UpdateStoreSnResp updateStoreSn(long vendor_id_,List<vipapis.order.OrderStoreMappingEx> order_store_mapping_) {
				
				send_updateStoreSn(vendor_id_,order_store_mapping_);
				return recv_updateStoreSn(); 
				
			}
			
			
			private void send_updateStoreSn(long vendor_id_,List<vipapis.order.OrderStoreMappingEx> order_store_mapping_){
				
				InitInvocation("updateStoreSn");
				
				updateStoreSn_args args = new updateStoreSn_args();
				args.SetVendor_id(vendor_id_);
				args.SetOrder_store_mapping(order_store_mapping_);
				
				SendBase(args, updateStoreSn_argsHelper.getInstance());
			}
			
			
			private vipapis.order.UpdateStoreSnResp recv_updateStoreSn(){
				
				updateStoreSn_result result = new updateStoreSn_result();
				ReceiveBase(result, updateStoreSn_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
		}
		
		
	}
	
}