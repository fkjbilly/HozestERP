using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;

namespace vipapis.inventory{
	
	
	public class InventoryServiceHelper {
		
		
		
		public class getDeductOrderDetail_args {
			
			///<summary>
			/// 获取拣货订单查询请求
			///</summary>
			
			private vipapis.inventory.InventoryDeductOrdersRequest inventoryDeductOrdersRequest_;
			
			public vipapis.inventory.InventoryDeductOrdersRequest GetInventoryDeductOrdersRequest(){
				return this.inventoryDeductOrdersRequest_;
			}
			
			public void SetInventoryDeductOrdersRequest(vipapis.inventory.InventoryDeductOrdersRequest value){
				this.inventoryDeductOrdersRequest_ = value;
			}
			
		}
		
		
		
		
		public class getInventoryCancelledOrders_args {
			
			///<summary>
			/// 获取已取消订单请求
			///</summary>
			
			private vipapis.inventory.InventoryCancelledOrdersRequest inventoryCancelledOrdersRequest_;
			
			public vipapis.inventory.InventoryCancelledOrdersRequest GetInventoryCancelledOrdersRequest(){
				return this.inventoryCancelledOrdersRequest_;
			}
			
			public void SetInventoryCancelledOrdersRequest(vipapis.inventory.InventoryCancelledOrdersRequest value){
				this.inventoryCancelledOrdersRequest_ = value;
			}
			
		}
		
		
		
		
		public class getInventoryDeductOrders_args {
			
			///<summary>
			/// 获取拣货订单查询请求
			///</summary>
			
			private vipapis.inventory.InventoryDeductOrdersRequest inventoryDeductOrdersRequest_;
			
			public vipapis.inventory.InventoryDeductOrdersRequest GetInventoryDeductOrdersRequest(){
				return this.inventoryDeductOrdersRequest_;
			}
			
			public void SetInventoryDeductOrdersRequest(vipapis.inventory.InventoryDeductOrdersRequest value){
				this.inventoryDeductOrdersRequest_ = value;
			}
			
		}
		
		
		
		
		public class getInventoryOccupiedOrders_args {
			
			///<summary>
			/// 获取销售订单请求
			///</summary>
			
			private vipapis.inventory.InventoryOccupiedOrdersRequest inventoryOccupiedOrdersRequest_;
			
			public vipapis.inventory.InventoryOccupiedOrdersRequest GetInventoryOccupiedOrdersRequest(){
				return this.inventoryOccupiedOrdersRequest_;
			}
			
			public void SetInventoryOccupiedOrdersRequest(vipapis.inventory.InventoryOccupiedOrdersRequest value){
				this.inventoryOccupiedOrdersRequest_ = value;
			}
			
		}
		
		
		
		
		public class getMpSkuStock_args {
			
			///<summary>
			/// MP商品库存查询请求参数
			///</summary>
			
			private vipapis.inventory.GetMpSkuStockRequest getSkuStockRequest_;
			
			public vipapis.inventory.GetMpSkuStockRequest GetGetSkuStockRequest(){
				return this.getSkuStockRequest_;
			}
			
			public void SetGetSkuStockRequest(vipapis.inventory.GetMpSkuStockRequest value){
				this.getSkuStockRequest_ = value;
			}
			
		}
		
		
		
		
		public class getSkuInfo_args {
			
			///<summary>
			/// 档期单个商品查询条件
			///</summary>
			
			private vipapis.inventory.GetSkuInfoRequest request_;
			
			public vipapis.inventory.GetSkuInfoRequest GetRequest(){
				return this.request_;
			}
			
			public void SetRequest(vipapis.inventory.GetSkuInfoRequest value){
				this.request_ = value;
			}
			
		}
		
		
		
		
		public class getSkuList_args {
			
			///<summary>
			/// 档期商品列表查询条件
			///</summary>
			
			private vipapis.inventory.GetScheduleSkuListCriteria criteria_;
			
			///<summary>
			/// 页码，默认为1
			///</summary>
			
			private int? page_;
			
			///<summary>
			/// 每页查询条数，默认为200
			///</summary>
			
			private int? limit_;
			
			public vipapis.inventory.GetScheduleSkuListCriteria GetCriteria(){
				return this.criteria_;
			}
			
			public void SetCriteria(vipapis.inventory.GetScheduleSkuListCriteria value){
				this.criteria_ = value;
			}
			public int? GetPage(){
				return this.page_;
			}
			
			public void SetPage(int? value){
				this.page_ = value;
			}
			public int? GetLimit(){
				return this.limit_;
			}
			
			public void SetLimit(int? value){
				this.limit_ = value;
			}
			
		}
		
		
		
		
		public class getSkuStock_args {
			
			///<summary>
			/// 供应商ID
			/// @sampleValue vendor_id 550
			///</summary>
			
			private int? vendor_id_;
			
			///<summary>
			/// 常态合作编码（如果为分区销售模式，此字段必填）
			///</summary>
			
			private int? cooperation_no_;
			
			///<summary>
			/// 仓库编码
			///</summary>
			
			private string warehouse_;
			
			///<summary>
			/// 商品条形码
			///</summary>
			
			private string barcode_;
			
			///<summary>
			/// 分区仓库代码（如果为分区销售模式，此字段必填）
			///</summary>
			
			private string area_warehouse_id_;
			
			public int? GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(int? value){
				this.vendor_id_ = value;
			}
			public int? GetCooperation_no(){
				return this.cooperation_no_;
			}
			
			public void SetCooperation_no(int? value){
				this.cooperation_no_ = value;
			}
			public string GetWarehouse(){
				return this.warehouse_;
			}
			
			public void SetWarehouse(string value){
				this.warehouse_ = value;
			}
			public string GetBarcode(){
				return this.barcode_;
			}
			
			public void SetBarcode(string value){
				this.barcode_ = value;
			}
			public string GetArea_warehouse_id(){
				return this.area_warehouse_id_;
			}
			
			public void SetArea_warehouse_id(string value){
				this.area_warehouse_id_ = value;
			}
			
		}
		
		
		
		
		public class healthCheck_args {
			
			
		}
		
		
		
		
		public class updateInventory_args {
			
			///<summary>
			/// 更新商品库存请求
			///</summary>
			
			private vipapis.inventory.UpdateSkuInventoryRequest request_;
			
			public vipapis.inventory.UpdateSkuInventoryRequest GetRequest(){
				return this.request_;
			}
			
			public void SetRequest(vipapis.inventory.UpdateSkuInventoryRequest value){
				this.request_ = value;
			}
			
		}
		
		
		
		
		public class updateMpSkuStock_args {
			
			///<summary>
			/// MP更新sku库存参数
			///</summary>
			
			private vipapis.inventory.UpdateMpSkuStockRequest updateSkuStockRequest_;
			
			public vipapis.inventory.UpdateMpSkuStockRequest GetUpdateSkuStockRequest(){
				return this.updateSkuStockRequest_;
			}
			
			public void SetUpdateSkuStockRequest(vipapis.inventory.UpdateMpSkuStockRequest value){
				this.updateSkuStockRequest_ = value;
			}
			
		}
		
		
		
		
		public class getDeductOrderDetail_result {
			
			///<summary>
			///</summary>
			
			private vipapis.inventory.InventoryDeductOrderDetailResponse success_;
			
			public vipapis.inventory.InventoryDeductOrderDetailResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.inventory.InventoryDeductOrderDetailResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getInventoryCancelledOrders_result {
			
			///<summary>
			///</summary>
			
			private vipapis.inventory.CancelledOrdersResponse success_;
			
			public vipapis.inventory.CancelledOrdersResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.inventory.CancelledOrdersResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getInventoryDeductOrders_result {
			
			///<summary>
			///</summary>
			
			private vipapis.inventory.InventoryDeductOrdersResponse success_;
			
			public vipapis.inventory.InventoryDeductOrdersResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.inventory.InventoryDeductOrdersResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getInventoryOccupiedOrders_result {
			
			///<summary>
			///</summary>
			
			private vipapis.inventory.OccupiedOrderResponse success_;
			
			public vipapis.inventory.OccupiedOrderResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.inventory.OccupiedOrderResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getMpSkuStock_result {
			
			///<summary>
			///</summary>
			
			private vipapis.inventory.GetMpSkuStockResponse success_;
			
			public vipapis.inventory.GetMpSkuStockResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.inventory.GetMpSkuStockResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getSkuInfo_result {
			
			///<summary>
			///</summary>
			
			private List<vipapis.inventory.SkuInfo> success_;
			
			public List<vipapis.inventory.SkuInfo> GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(List<vipapis.inventory.SkuInfo> value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getSkuList_result {
			
			///<summary>
			///</summary>
			
			private vipapis.inventory.GetScheduleSkuListResult success_;
			
			public vipapis.inventory.GetScheduleSkuListResult GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.inventory.GetScheduleSkuListResult value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getSkuStock_result {
			
			///<summary>
			///</summary>
			
			private List<vipapis.inventory.GetSkuInventoryResult> success_;
			
			public List<vipapis.inventory.GetSkuInventoryResult> GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(List<vipapis.inventory.GetSkuInventoryResult> value){
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
		
		
		
		
		public class updateInventory_result {
			
			
		}
		
		
		
		
		public class updateMpSkuStock_result {
			
			///<summary>
			///</summary>
			
			private vipapis.inventory.UpdateMpSkuStockResponse success_;
			
			public vipapis.inventory.UpdateMpSkuStockResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.inventory.UpdateMpSkuStockResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		
		public class getDeductOrderDetail_argsHelper : TBeanSerializer<getDeductOrderDetail_args>
		{
			
			public static getDeductOrderDetail_argsHelper OBJ = new getDeductOrderDetail_argsHelper();
			
			public static getDeductOrderDetail_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getDeductOrderDetail_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.inventory.InventoryDeductOrdersRequest value;
					
					value = new vipapis.inventory.InventoryDeductOrdersRequest();
					vipapis.inventory.InventoryDeductOrdersRequestHelper.getInstance().Read(value, iprot);
					
					structs.SetInventoryDeductOrdersRequest(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getDeductOrderDetail_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetInventoryDeductOrdersRequest() != null) {
					
					oprot.WriteFieldBegin("inventoryDeductOrdersRequest");
					
					vipapis.inventory.InventoryDeductOrdersRequestHelper.getInstance().Write(structs.GetInventoryDeductOrdersRequest(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getDeductOrderDetail_args bean){
				
				
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
					
					vipapis.inventory.InventoryCancelledOrdersRequest value;
					
					value = new vipapis.inventory.InventoryCancelledOrdersRequest();
					vipapis.inventory.InventoryCancelledOrdersRequestHelper.getInstance().Read(value, iprot);
					
					structs.SetInventoryCancelledOrdersRequest(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getInventoryCancelledOrders_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetInventoryCancelledOrdersRequest() != null) {
					
					oprot.WriteFieldBegin("inventoryCancelledOrdersRequest");
					
					vipapis.inventory.InventoryCancelledOrdersRequestHelper.getInstance().Write(structs.GetInventoryCancelledOrdersRequest(), oprot);
					
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
					
					vipapis.inventory.InventoryDeductOrdersRequest value;
					
					value = new vipapis.inventory.InventoryDeductOrdersRequest();
					vipapis.inventory.InventoryDeductOrdersRequestHelper.getInstance().Read(value, iprot);
					
					structs.SetInventoryDeductOrdersRequest(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getInventoryDeductOrders_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetInventoryDeductOrdersRequest() != null) {
					
					oprot.WriteFieldBegin("inventoryDeductOrdersRequest");
					
					vipapis.inventory.InventoryDeductOrdersRequestHelper.getInstance().Write(structs.GetInventoryDeductOrdersRequest(), oprot);
					
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
					
					vipapis.inventory.InventoryOccupiedOrdersRequest value;
					
					value = new vipapis.inventory.InventoryOccupiedOrdersRequest();
					vipapis.inventory.InventoryOccupiedOrdersRequestHelper.getInstance().Read(value, iprot);
					
					structs.SetInventoryOccupiedOrdersRequest(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getInventoryOccupiedOrders_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetInventoryOccupiedOrdersRequest() != null) {
					
					oprot.WriteFieldBegin("inventoryOccupiedOrdersRequest");
					
					vipapis.inventory.InventoryOccupiedOrdersRequestHelper.getInstance().Write(structs.GetInventoryOccupiedOrdersRequest(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getInventoryOccupiedOrders_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getMpSkuStock_argsHelper : TBeanSerializer<getMpSkuStock_args>
		{
			
			public static getMpSkuStock_argsHelper OBJ = new getMpSkuStock_argsHelper();
			
			public static getMpSkuStock_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getMpSkuStock_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.inventory.GetMpSkuStockRequest value;
					
					value = new vipapis.inventory.GetMpSkuStockRequest();
					vipapis.inventory.GetMpSkuStockRequestHelper.getInstance().Read(value, iprot);
					
					structs.SetGetSkuStockRequest(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getMpSkuStock_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetGetSkuStockRequest() != null) {
					
					oprot.WriteFieldBegin("getSkuStockRequest");
					
					vipapis.inventory.GetMpSkuStockRequestHelper.getInstance().Write(structs.GetGetSkuStockRequest(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getMpSkuStock_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getSkuInfo_argsHelper : TBeanSerializer<getSkuInfo_args>
		{
			
			public static getSkuInfo_argsHelper OBJ = new getSkuInfo_argsHelper();
			
			public static getSkuInfo_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getSkuInfo_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.inventory.GetSkuInfoRequest value;
					
					value = new vipapis.inventory.GetSkuInfoRequest();
					vipapis.inventory.GetSkuInfoRequestHelper.getInstance().Read(value, iprot);
					
					structs.SetRequest(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getSkuInfo_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequest() != null) {
					
					oprot.WriteFieldBegin("request");
					
					vipapis.inventory.GetSkuInfoRequestHelper.getInstance().Write(structs.GetRequest(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("request can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getSkuInfo_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getSkuList_argsHelper : TBeanSerializer<getSkuList_args>
		{
			
			public static getSkuList_argsHelper OBJ = new getSkuList_argsHelper();
			
			public static getSkuList_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getSkuList_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.inventory.GetScheduleSkuListCriteria value;
					
					value = new vipapis.inventory.GetScheduleSkuListCriteria();
					vipapis.inventory.GetScheduleSkuListCriteriaHelper.getInstance().Read(value, iprot);
					
					structs.SetCriteria(value);
				}
				
				
				
				
				
				if(true){
					
					int? value;
					value = iprot.ReadI32(); 
					
					structs.SetPage(value);
				}
				
				
				
				
				
				if(true){
					
					int? value;
					value = iprot.ReadI32(); 
					
					structs.SetLimit(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getSkuList_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetCriteria() != null) {
					
					oprot.WriteFieldBegin("criteria");
					
					vipapis.inventory.GetScheduleSkuListCriteriaHelper.getInstance().Write(structs.GetCriteria(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("criteria can not be null!");
				}
				
				
				if(structs.GetPage() != null) {
					
					oprot.WriteFieldBegin("page");
					oprot.WriteI32((int)structs.GetPage()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetLimit() != null) {
					
					oprot.WriteFieldBegin("limit");
					oprot.WriteI32((int)structs.GetLimit()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getSkuList_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getSkuStock_argsHelper : TBeanSerializer<getSkuStock_args>
		{
			
			public static getSkuStock_argsHelper OBJ = new getSkuStock_argsHelper();
			
			public static getSkuStock_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getSkuStock_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				
				if(true){
					
					int? value;
					value = iprot.ReadI32(); 
					
					structs.SetCooperation_no(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetWarehouse(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetBarcode(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetArea_warehouse_id(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getSkuStock_args structs, Protocol oprot){
				
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
				
				
				if(structs.GetCooperation_no() != null) {
					
					oprot.WriteFieldBegin("cooperation_no");
					oprot.WriteI32((int)structs.GetCooperation_no()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetWarehouse() != null) {
					
					oprot.WriteFieldBegin("warehouse");
					oprot.WriteString(structs.GetWarehouse());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetBarcode() != null) {
					
					oprot.WriteFieldBegin("barcode");
					oprot.WriteString(structs.GetBarcode());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("barcode can not be null!");
				}
				
				
				if(structs.GetArea_warehouse_id() != null) {
					
					oprot.WriteFieldBegin("area_warehouse_id");
					oprot.WriteString(structs.GetArea_warehouse_id());
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getSkuStock_args bean){
				
				
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
		
		
		
		
		public class updateInventory_argsHelper : TBeanSerializer<updateInventory_args>
		{
			
			public static updateInventory_argsHelper OBJ = new updateInventory_argsHelper();
			
			public static updateInventory_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(updateInventory_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.inventory.UpdateSkuInventoryRequest value;
					
					value = new vipapis.inventory.UpdateSkuInventoryRequest();
					vipapis.inventory.UpdateSkuInventoryRequestHelper.getInstance().Read(value, iprot);
					
					structs.SetRequest(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(updateInventory_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequest() != null) {
					
					oprot.WriteFieldBegin("request");
					
					vipapis.inventory.UpdateSkuInventoryRequestHelper.getInstance().Write(structs.GetRequest(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("request can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(updateInventory_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class updateMpSkuStock_argsHelper : TBeanSerializer<updateMpSkuStock_args>
		{
			
			public static updateMpSkuStock_argsHelper OBJ = new updateMpSkuStock_argsHelper();
			
			public static updateMpSkuStock_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(updateMpSkuStock_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.inventory.UpdateMpSkuStockRequest value;
					
					value = new vipapis.inventory.UpdateMpSkuStockRequest();
					vipapis.inventory.UpdateMpSkuStockRequestHelper.getInstance().Read(value, iprot);
					
					structs.SetUpdateSkuStockRequest(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(updateMpSkuStock_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetUpdateSkuStockRequest() != null) {
					
					oprot.WriteFieldBegin("updateSkuStockRequest");
					
					vipapis.inventory.UpdateMpSkuStockRequestHelper.getInstance().Write(structs.GetUpdateSkuStockRequest(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(updateMpSkuStock_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getDeductOrderDetail_resultHelper : TBeanSerializer<getDeductOrderDetail_result>
		{
			
			public static getDeductOrderDetail_resultHelper OBJ = new getDeductOrderDetail_resultHelper();
			
			public static getDeductOrderDetail_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getDeductOrderDetail_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.inventory.InventoryDeductOrderDetailResponse value;
					
					value = new vipapis.inventory.InventoryDeductOrderDetailResponse();
					vipapis.inventory.InventoryDeductOrderDetailResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getDeductOrderDetail_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.inventory.InventoryDeductOrderDetailResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getDeductOrderDetail_result bean){
				
				
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
					
					vipapis.inventory.CancelledOrdersResponse value;
					
					value = new vipapis.inventory.CancelledOrdersResponse();
					vipapis.inventory.CancelledOrdersResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getInventoryCancelledOrders_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.inventory.CancelledOrdersResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
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
					
					vipapis.inventory.InventoryDeductOrdersResponse value;
					
					value = new vipapis.inventory.InventoryDeductOrdersResponse();
					vipapis.inventory.InventoryDeductOrdersResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getInventoryDeductOrders_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.inventory.InventoryDeductOrdersResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
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
					
					vipapis.inventory.OccupiedOrderResponse value;
					
					value = new vipapis.inventory.OccupiedOrderResponse();
					vipapis.inventory.OccupiedOrderResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getInventoryOccupiedOrders_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.inventory.OccupiedOrderResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getInventoryOccupiedOrders_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getMpSkuStock_resultHelper : TBeanSerializer<getMpSkuStock_result>
		{
			
			public static getMpSkuStock_resultHelper OBJ = new getMpSkuStock_resultHelper();
			
			public static getMpSkuStock_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getMpSkuStock_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.inventory.GetMpSkuStockResponse value;
					
					value = new vipapis.inventory.GetMpSkuStockResponse();
					vipapis.inventory.GetMpSkuStockResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getMpSkuStock_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.inventory.GetMpSkuStockResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getMpSkuStock_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getSkuInfo_resultHelper : TBeanSerializer<getSkuInfo_result>
		{
			
			public static getSkuInfo_resultHelper OBJ = new getSkuInfo_resultHelper();
			
			public static getSkuInfo_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getSkuInfo_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					List<vipapis.inventory.SkuInfo> value;
					
					value = new List<vipapis.inventory.SkuInfo>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							vipapis.inventory.SkuInfo elem0;
							
							elem0 = new vipapis.inventory.SkuInfo();
							vipapis.inventory.SkuInfoHelper.getInstance().Read(elem0, iprot);
							
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
			
			
			public void Write(getSkuInfo_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					oprot.WriteListBegin();
					foreach(vipapis.inventory.SkuInfo _item0 in structs.GetSuccess()){
						
						
						vipapis.inventory.SkuInfoHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getSkuInfo_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getSkuList_resultHelper : TBeanSerializer<getSkuList_result>
		{
			
			public static getSkuList_resultHelper OBJ = new getSkuList_resultHelper();
			
			public static getSkuList_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getSkuList_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.inventory.GetScheduleSkuListResult value;
					
					value = new vipapis.inventory.GetScheduleSkuListResult();
					vipapis.inventory.GetScheduleSkuListResultHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getSkuList_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.inventory.GetScheduleSkuListResultHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getSkuList_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getSkuStock_resultHelper : TBeanSerializer<getSkuStock_result>
		{
			
			public static getSkuStock_resultHelper OBJ = new getSkuStock_resultHelper();
			
			public static getSkuStock_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getSkuStock_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					List<vipapis.inventory.GetSkuInventoryResult> value;
					
					value = new List<vipapis.inventory.GetSkuInventoryResult>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							vipapis.inventory.GetSkuInventoryResult elem0;
							
							elem0 = new vipapis.inventory.GetSkuInventoryResult();
							vipapis.inventory.GetSkuInventoryResultHelper.getInstance().Read(elem0, iprot);
							
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
			
			
			public void Write(getSkuStock_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					oprot.WriteListBegin();
					foreach(vipapis.inventory.GetSkuInventoryResult _item0 in structs.GetSuccess()){
						
						
						vipapis.inventory.GetSkuInventoryResultHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getSkuStock_result bean){
				
				
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
		
		
		
		
		public class updateInventory_resultHelper : TBeanSerializer<updateInventory_result>
		{
			
			public static updateInventory_resultHelper OBJ = new updateInventory_resultHelper();
			
			public static updateInventory_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(updateInventory_result structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(updateInventory_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(updateInventory_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class updateMpSkuStock_resultHelper : TBeanSerializer<updateMpSkuStock_result>
		{
			
			public static updateMpSkuStock_resultHelper OBJ = new updateMpSkuStock_resultHelper();
			
			public static updateMpSkuStock_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(updateMpSkuStock_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.inventory.UpdateMpSkuStockResponse value;
					
					value = new vipapis.inventory.UpdateMpSkuStockResponse();
					vipapis.inventory.UpdateMpSkuStockResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(updateMpSkuStock_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.inventory.UpdateMpSkuStockResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(updateMpSkuStock_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class InventoryServiceClient : OspRestStub , InventoryService  {
			
			
			public InventoryServiceClient():base("vipapis.inventory.InventoryService","1.0.0") {
				
				
			}
			
			
			
			public vipapis.inventory.InventoryDeductOrderDetailResponse getDeductOrderDetail(vipapis.inventory.InventoryDeductOrdersRequest inventoryDeductOrdersRequest_) {
				
				send_getDeductOrderDetail(inventoryDeductOrdersRequest_);
				return recv_getDeductOrderDetail(); 
				
			}
			
			
			private void send_getDeductOrderDetail(vipapis.inventory.InventoryDeductOrdersRequest inventoryDeductOrdersRequest_){
				
				InitInvocation("getDeductOrderDetail");
				
				getDeductOrderDetail_args args = new getDeductOrderDetail_args();
				args.SetInventoryDeductOrdersRequest(inventoryDeductOrdersRequest_);
				
				SendBase(args, getDeductOrderDetail_argsHelper.getInstance());
			}
			
			
			private vipapis.inventory.InventoryDeductOrderDetailResponse recv_getDeductOrderDetail(){
				
				getDeductOrderDetail_result result = new getDeductOrderDetail_result();
				ReceiveBase(result, getDeductOrderDetail_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public vipapis.inventory.CancelledOrdersResponse getInventoryCancelledOrders(vipapis.inventory.InventoryCancelledOrdersRequest inventoryCancelledOrdersRequest_) {
				
				send_getInventoryCancelledOrders(inventoryCancelledOrdersRequest_);
				return recv_getInventoryCancelledOrders(); 
				
			}
			
			
			private void send_getInventoryCancelledOrders(vipapis.inventory.InventoryCancelledOrdersRequest inventoryCancelledOrdersRequest_){
				
				InitInvocation("getInventoryCancelledOrders");
				
				getInventoryCancelledOrders_args args = new getInventoryCancelledOrders_args();
				args.SetInventoryCancelledOrdersRequest(inventoryCancelledOrdersRequest_);
				
				SendBase(args, getInventoryCancelledOrders_argsHelper.getInstance());
			}
			
			
			private vipapis.inventory.CancelledOrdersResponse recv_getInventoryCancelledOrders(){
				
				getInventoryCancelledOrders_result result = new getInventoryCancelledOrders_result();
				ReceiveBase(result, getInventoryCancelledOrders_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public vipapis.inventory.InventoryDeductOrdersResponse getInventoryDeductOrders(vipapis.inventory.InventoryDeductOrdersRequest inventoryDeductOrdersRequest_) {
				
				send_getInventoryDeductOrders(inventoryDeductOrdersRequest_);
				return recv_getInventoryDeductOrders(); 
				
			}
			
			
			private void send_getInventoryDeductOrders(vipapis.inventory.InventoryDeductOrdersRequest inventoryDeductOrdersRequest_){
				
				InitInvocation("getInventoryDeductOrders");
				
				getInventoryDeductOrders_args args = new getInventoryDeductOrders_args();
				args.SetInventoryDeductOrdersRequest(inventoryDeductOrdersRequest_);
				
				SendBase(args, getInventoryDeductOrders_argsHelper.getInstance());
			}
			
			
			private vipapis.inventory.InventoryDeductOrdersResponse recv_getInventoryDeductOrders(){
				
				getInventoryDeductOrders_result result = new getInventoryDeductOrders_result();
				ReceiveBase(result, getInventoryDeductOrders_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public vipapis.inventory.OccupiedOrderResponse getInventoryOccupiedOrders(vipapis.inventory.InventoryOccupiedOrdersRequest inventoryOccupiedOrdersRequest_) {
				
				send_getInventoryOccupiedOrders(inventoryOccupiedOrdersRequest_);
				return recv_getInventoryOccupiedOrders(); 
				
			}
			
			
			private void send_getInventoryOccupiedOrders(vipapis.inventory.InventoryOccupiedOrdersRequest inventoryOccupiedOrdersRequest_){
				
				InitInvocation("getInventoryOccupiedOrders");
				
				getInventoryOccupiedOrders_args args = new getInventoryOccupiedOrders_args();
				args.SetInventoryOccupiedOrdersRequest(inventoryOccupiedOrdersRequest_);
				
				SendBase(args, getInventoryOccupiedOrders_argsHelper.getInstance());
			}
			
			
			private vipapis.inventory.OccupiedOrderResponse recv_getInventoryOccupiedOrders(){
				
				getInventoryOccupiedOrders_result result = new getInventoryOccupiedOrders_result();
				ReceiveBase(result, getInventoryOccupiedOrders_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public vipapis.inventory.GetMpSkuStockResponse getMpSkuStock(vipapis.inventory.GetMpSkuStockRequest getSkuStockRequest_) {
				
				send_getMpSkuStock(getSkuStockRequest_);
				return recv_getMpSkuStock(); 
				
			}
			
			
			private void send_getMpSkuStock(vipapis.inventory.GetMpSkuStockRequest getSkuStockRequest_){
				
				InitInvocation("getMpSkuStock");
				
				getMpSkuStock_args args = new getMpSkuStock_args();
				args.SetGetSkuStockRequest(getSkuStockRequest_);
				
				SendBase(args, getMpSkuStock_argsHelper.getInstance());
			}
			
			
			private vipapis.inventory.GetMpSkuStockResponse recv_getMpSkuStock(){
				
				getMpSkuStock_result result = new getMpSkuStock_result();
				ReceiveBase(result, getMpSkuStock_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public List<vipapis.inventory.SkuInfo> getSkuInfo(vipapis.inventory.GetSkuInfoRequest request_) {
				
				send_getSkuInfo(request_);
				return recv_getSkuInfo(); 
				
			}
			
			
			private void send_getSkuInfo(vipapis.inventory.GetSkuInfoRequest request_){
				
				InitInvocation("getSkuInfo");
				
				getSkuInfo_args args = new getSkuInfo_args();
				args.SetRequest(request_);
				
				SendBase(args, getSkuInfo_argsHelper.getInstance());
			}
			
			
			private List<vipapis.inventory.SkuInfo> recv_getSkuInfo(){
				
				getSkuInfo_result result = new getSkuInfo_result();
				ReceiveBase(result, getSkuInfo_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public vipapis.inventory.GetScheduleSkuListResult getSkuList(vipapis.inventory.GetScheduleSkuListCriteria criteria_,int? page_,int? limit_) {
				
				send_getSkuList(criteria_,page_,limit_);
				return recv_getSkuList(); 
				
			}
			
			
			private void send_getSkuList(vipapis.inventory.GetScheduleSkuListCriteria criteria_,int? page_,int? limit_){
				
				InitInvocation("getSkuList");
				
				getSkuList_args args = new getSkuList_args();
				args.SetCriteria(criteria_);
				args.SetPage(page_);
				args.SetLimit(limit_);
				
				SendBase(args, getSkuList_argsHelper.getInstance());
			}
			
			
			private vipapis.inventory.GetScheduleSkuListResult recv_getSkuList(){
				
				getSkuList_result result = new getSkuList_result();
				ReceiveBase(result, getSkuList_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public List<vipapis.inventory.GetSkuInventoryResult> getSkuStock(int vendor_id_,int? cooperation_no_,string warehouse_,string barcode_,string area_warehouse_id_) {
				
				send_getSkuStock(vendor_id_,cooperation_no_,warehouse_,barcode_,area_warehouse_id_);
				return recv_getSkuStock(); 
				
			}
			
			
			private void send_getSkuStock(int vendor_id_,int? cooperation_no_,string warehouse_,string barcode_,string area_warehouse_id_){
				
				InitInvocation("getSkuStock");
				
				getSkuStock_args args = new getSkuStock_args();
				args.SetVendor_id(vendor_id_);
				args.SetCooperation_no(cooperation_no_);
				args.SetWarehouse(warehouse_);
				args.SetBarcode(barcode_);
				args.SetArea_warehouse_id(area_warehouse_id_);
				
				SendBase(args, getSkuStock_argsHelper.getInstance());
			}
			
			
			private List<vipapis.inventory.GetSkuInventoryResult> recv_getSkuStock(){
				
				getSkuStock_result result = new getSkuStock_result();
				ReceiveBase(result, getSkuStock_resultHelper.getInstance());
				
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
			
			
			public void updateInventory(vipapis.inventory.UpdateSkuInventoryRequest request_) {
				
				send_updateInventory(request_);
				recv_updateInventory();
				
			}
			
			
			private void send_updateInventory(vipapis.inventory.UpdateSkuInventoryRequest request_){
				
				InitInvocation("updateInventory");
				
				updateInventory_args args = new updateInventory_args();
				args.SetRequest(request_);
				
				SendBase(args, updateInventory_argsHelper.getInstance());
			}
			
			
			private void recv_updateInventory(){
				
				updateInventory_result result = new updateInventory_result();
				ReceiveBase(result, updateInventory_resultHelper.getInstance());
				
				
			}
			
			
			public vipapis.inventory.UpdateMpSkuStockResponse updateMpSkuStock(vipapis.inventory.UpdateMpSkuStockRequest updateSkuStockRequest_) {
				
				send_updateMpSkuStock(updateSkuStockRequest_);
				return recv_updateMpSkuStock(); 
				
			}
			
			
			private void send_updateMpSkuStock(vipapis.inventory.UpdateMpSkuStockRequest updateSkuStockRequest_){
				
				InitInvocation("updateMpSkuStock");
				
				updateMpSkuStock_args args = new updateMpSkuStock_args();
				args.SetUpdateSkuStockRequest(updateSkuStockRequest_);
				
				SendBase(args, updateMpSkuStock_argsHelper.getInstance());
			}
			
			
			private vipapis.inventory.UpdateMpSkuStockResponse recv_updateMpSkuStock(){
				
				updateMpSkuStock_result result = new updateMpSkuStock_result();
				ReceiveBase(result, updateMpSkuStock_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
		}
		
		
	}
	
}