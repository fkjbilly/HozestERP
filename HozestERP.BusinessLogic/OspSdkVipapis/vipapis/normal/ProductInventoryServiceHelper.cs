using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;

namespace vipapis.normal{
	
	
	public class ProductInventoryServiceHelper {
		
		
		
		public class getInitialQuantityResult_args {
			
			///<summary>
			/// 供应商id
			/// @sampleValue vendor_id 550
			///</summary>
			
			private int? vendor_id_;
			
			///<summary>
			/// 申请单号
			/// @sampleValue apply_id 
			///</summary>
			
			private long? apply_id_;
			
			///<summary>
			/// 页码
			/// @sampleValue page 
			///</summary>
			
			private int? page_;
			
			///<summary>
			/// 一页数据条目数量
			/// @sampleValue limit 
			///</summary>
			
			private int? limit_;
			
			public int? GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(int? value){
				this.vendor_id_ = value;
			}
			public long? GetApply_id(){
				return this.apply_id_;
			}
			
			public void SetApply_id(long? value){
				this.apply_id_ = value;
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
		
		
		
		
		public class getInventoryDeductOrders_args {
			
			///<summary>
			/// 获取拣货订单查询请求
			///</summary>
			
			private vipapis.normal.InventoryDeductOrdersRequest inventoryDeductOrdersRequest_;
			
			public vipapis.normal.InventoryDeductOrdersRequest GetInventoryDeductOrdersRequest(){
				return this.inventoryDeductOrdersRequest_;
			}
			
			public void SetInventoryDeductOrdersRequest(vipapis.normal.InventoryDeductOrdersRequest value){
				this.inventoryDeductOrdersRequest_ = value;
			}
			
		}
		
		
		
		
		public class getInventoryOccupiedOrders_args {
			
			///<summary>
			/// 获取销售订单请求
			///</summary>
			
			private vipapis.normal.InventoryOccupiedOrdersRequest inventoryOccupiedOrdersRequest_;
			
			public vipapis.normal.InventoryOccupiedOrdersRequest GetInventoryOccupiedOrdersRequest(){
				return this.inventoryOccupiedOrdersRequest_;
			}
			
			public void SetInventoryOccupiedOrdersRequest(vipapis.normal.InventoryOccupiedOrdersRequest value){
				this.inventoryOccupiedOrdersRequest_ = value;
			}
			
		}
		
		
		
		
		public class getInventoryUpdateResult_args {
			
			///<summary>
			/// 调增调减结果请求
			///</summary>
			
			private vipapis.normal.InventoryUpdateResultRequest inventoryUpdateResultRequest_;
			
			public vipapis.normal.InventoryUpdateResultRequest GetInventoryUpdateResultRequest(){
				return this.inventoryUpdateResultRequest_;
			}
			
			public void SetInventoryUpdateResultRequest(vipapis.normal.InventoryUpdateResultRequest value){
				this.inventoryUpdateResultRequest_ = value;
			}
			
		}
		
		
		
		
		public class getScheduleProductList_args {
			
			///<summary>
			/// 常态档期商品查询请求
			///</summary>
			
			private vipapis.normal.ScheduleProductRequest scheduleProductRequest_;
			
			public vipapis.normal.ScheduleProductRequest GetScheduleProductRequest(){
				return this.scheduleProductRequest_;
			}
			
			public void SetScheduleProductRequest(vipapis.normal.ScheduleProductRequest value){
				this.scheduleProductRequest_ = value;
			}
			
		}
		
		
		
		
		public class healthCheck_args {
			
			
		}
		
		
		
		
		public class importInitialInventory_args {
			
			///<summary>
			/// 常态合作编码信息
			///</summary>
			
			private vipapis.normal.Cooperation cooperation_;
			
			///<summary>
			/// 初始库存列表
			///</summary>
			
			private List<vipapis.normal.Initialnventory> inventorys_;
			
			public vipapis.normal.Cooperation GetCooperation(){
				return this.cooperation_;
			}
			
			public void SetCooperation(vipapis.normal.Cooperation value){
				this.cooperation_ = value;
			}
			public List<vipapis.normal.Initialnventory> GetInventorys(){
				return this.inventorys_;
			}
			
			public void SetInventorys(List<vipapis.normal.Initialnventory> value){
				this.inventorys_ = value;
			}
			
		}
		
		
		
		
		public class pullUpdateInventoryResult_args {
			
			///<summary>
			/// 更新库存调整结果请求
			///</summary>
			
			private List<vipapis.normal.UpdateInventoryResult> updateInventoryResultList_;
			
			public List<vipapis.normal.UpdateInventoryResult> GetUpdateInventoryResultList(){
				return this.updateInventoryResultList_;
			}
			
			public void SetUpdateInventoryResultList(List<vipapis.normal.UpdateInventoryResult> value){
				this.updateInventoryResultList_ = value;
			}
			
		}
		
		
		
		
		public class updateAvailableInventory_args {
			
			///<summary>
			/// 商品库存全量更新请求
			///</summary>
			
			private vipapis.normal.AvailableInventoryRequest availableInventoryRequest_;
			
			public vipapis.normal.AvailableInventoryRequest GetAvailableInventoryRequest(){
				return this.availableInventoryRequest_;
			}
			
			public void SetAvailableInventoryRequest(vipapis.normal.AvailableInventoryRequest value){
				this.availableInventoryRequest_ = value;
			}
			
		}
		
		
		
		
		public class updateSellableInventory_args {
			
			///<summary>
			/// 商品库存调增调减更新请求
			///</summary>
			
			private vipapis.normal.SellableUpdateInventoryRequest sellableUpdateInventoryRequest_;
			
			public vipapis.normal.SellableUpdateInventoryRequest GetSellableUpdateInventoryRequest(){
				return this.sellableUpdateInventoryRequest_;
			}
			
			public void SetSellableUpdateInventoryRequest(vipapis.normal.SellableUpdateInventoryRequest value){
				this.sellableUpdateInventoryRequest_ = value;
			}
			
		}
		
		
		
		
		public class getInitialQuantityResult_result {
			
			///<summary>
			///</summary>
			
			private vipapis.normal.ImportInitialQuantityResult success_;
			
			public vipapis.normal.ImportInitialQuantityResult GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.normal.ImportInitialQuantityResult value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getInventoryDeductOrders_result {
			
			///<summary>
			///</summary>
			
			private vipapis.normal.InventoryDeductOrdersResponse success_;
			
			public vipapis.normal.InventoryDeductOrdersResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.normal.InventoryDeductOrdersResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getInventoryOccupiedOrders_result {
			
			///<summary>
			///</summary>
			
			private vipapis.normal.OccupiedOrderResponse success_;
			
			public vipapis.normal.OccupiedOrderResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.normal.OccupiedOrderResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getInventoryUpdateResult_result {
			
			///<summary>
			///</summary>
			
			private vipapis.normal.InventoryUpdateResultResponse success_;
			
			public vipapis.normal.InventoryUpdateResultResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.normal.InventoryUpdateResultResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getScheduleProductList_result {
			
			///<summary>
			/// 返回档期商品列表信息
			///</summary>
			
			private vipapis.normal.ScheduleProductResponse success_;
			
			public vipapis.normal.ScheduleProductResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.normal.ScheduleProductResponse value){
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
		
		
		
		
		public class importInitialInventory_result {
			
			///<summary>
			///</summary>
			
			private string success_;
			
			public string GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(string value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class pullUpdateInventoryResult_result {
			
			
		}
		
		
		
		
		public class updateAvailableInventory_result {
			
			
		}
		
		
		
		
		public class updateSellableInventory_result {
			
			
		}
		
		
		
		
		
		public class getInitialQuantityResult_argsHelper : TBeanSerializer<getInitialQuantityResult_args>
		{
			
			public static getInitialQuantityResult_argsHelper OBJ = new getInitialQuantityResult_argsHelper();
			
			public static getInitialQuantityResult_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getInitialQuantityResult_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				
				if(true){
					
					long value;
					value = iprot.ReadI64(); 
					
					structs.SetApply_id(value);
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
			
			
			public void Write(getInitialQuantityResult_args structs, Protocol oprot){
				
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
				
				
				if(structs.GetApply_id() != null) {
					
					oprot.WriteFieldBegin("apply_id");
					oprot.WriteI64((long)structs.GetApply_id()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("apply_id can not be null!");
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
			
			
			public void Validate(getInitialQuantityResult_args bean){
				
				
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
					
					vipapis.normal.InventoryDeductOrdersRequest value;
					
					value = new vipapis.normal.InventoryDeductOrdersRequest();
					vipapis.normal.InventoryDeductOrdersRequestHelper.getInstance().Read(value, iprot);
					
					structs.SetInventoryDeductOrdersRequest(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getInventoryDeductOrders_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetInventoryDeductOrdersRequest() != null) {
					
					oprot.WriteFieldBegin("inventoryDeductOrdersRequest");
					
					vipapis.normal.InventoryDeductOrdersRequestHelper.getInstance().Write(structs.GetInventoryDeductOrdersRequest(), oprot);
					
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
					
					vipapis.normal.InventoryOccupiedOrdersRequest value;
					
					value = new vipapis.normal.InventoryOccupiedOrdersRequest();
					vipapis.normal.InventoryOccupiedOrdersRequestHelper.getInstance().Read(value, iprot);
					
					structs.SetInventoryOccupiedOrdersRequest(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getInventoryOccupiedOrders_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetInventoryOccupiedOrdersRequest() != null) {
					
					oprot.WriteFieldBegin("inventoryOccupiedOrdersRequest");
					
					vipapis.normal.InventoryOccupiedOrdersRequestHelper.getInstance().Write(structs.GetInventoryOccupiedOrdersRequest(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getInventoryOccupiedOrders_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getInventoryUpdateResult_argsHelper : TBeanSerializer<getInventoryUpdateResult_args>
		{
			
			public static getInventoryUpdateResult_argsHelper OBJ = new getInventoryUpdateResult_argsHelper();
			
			public static getInventoryUpdateResult_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getInventoryUpdateResult_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.normal.InventoryUpdateResultRequest value;
					
					value = new vipapis.normal.InventoryUpdateResultRequest();
					vipapis.normal.InventoryUpdateResultRequestHelper.getInstance().Read(value, iprot);
					
					structs.SetInventoryUpdateResultRequest(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getInventoryUpdateResult_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetInventoryUpdateResultRequest() != null) {
					
					oprot.WriteFieldBegin("inventoryUpdateResultRequest");
					
					vipapis.normal.InventoryUpdateResultRequestHelper.getInstance().Write(structs.GetInventoryUpdateResultRequest(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("inventoryUpdateResultRequest can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getInventoryUpdateResult_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getScheduleProductList_argsHelper : TBeanSerializer<getScheduleProductList_args>
		{
			
			public static getScheduleProductList_argsHelper OBJ = new getScheduleProductList_argsHelper();
			
			public static getScheduleProductList_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getScheduleProductList_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.normal.ScheduleProductRequest value;
					
					value = new vipapis.normal.ScheduleProductRequest();
					vipapis.normal.ScheduleProductRequestHelper.getInstance().Read(value, iprot);
					
					structs.SetScheduleProductRequest(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getScheduleProductList_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetScheduleProductRequest() != null) {
					
					oprot.WriteFieldBegin("scheduleProductRequest");
					
					vipapis.normal.ScheduleProductRequestHelper.getInstance().Write(structs.GetScheduleProductRequest(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("scheduleProductRequest can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getScheduleProductList_args bean){
				
				
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
		
		
		
		
		public class importInitialInventory_argsHelper : TBeanSerializer<importInitialInventory_args>
		{
			
			public static importInitialInventory_argsHelper OBJ = new importInitialInventory_argsHelper();
			
			public static importInitialInventory_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(importInitialInventory_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.normal.Cooperation value;
					
					value = new vipapis.normal.Cooperation();
					vipapis.normal.CooperationHelper.getInstance().Read(value, iprot);
					
					structs.SetCooperation(value);
				}
				
				
				
				
				
				if(true){
					
					List<vipapis.normal.Initialnventory> value;
					
					value = new List<vipapis.normal.Initialnventory>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							vipapis.normal.Initialnventory elem1;
							
							elem1 = new vipapis.normal.Initialnventory();
							vipapis.normal.InitialnventoryHelper.getInstance().Read(elem1, iprot);
							
							value.Add(elem1);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetInventorys(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(importInitialInventory_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetCooperation() != null) {
					
					oprot.WriteFieldBegin("cooperation");
					
					vipapis.normal.CooperationHelper.getInstance().Write(structs.GetCooperation(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("cooperation can not be null!");
				}
				
				
				if(structs.GetInventorys() != null) {
					
					oprot.WriteFieldBegin("inventorys");
					
					oprot.WriteListBegin();
					foreach(vipapis.normal.Initialnventory _item0 in structs.GetInventorys()){
						
						
						vipapis.normal.InitialnventoryHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("inventorys can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(importInitialInventory_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class pullUpdateInventoryResult_argsHelper : TBeanSerializer<pullUpdateInventoryResult_args>
		{
			
			public static pullUpdateInventoryResult_argsHelper OBJ = new pullUpdateInventoryResult_argsHelper();
			
			public static pullUpdateInventoryResult_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(pullUpdateInventoryResult_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					List<vipapis.normal.UpdateInventoryResult> value;
					
					value = new List<vipapis.normal.UpdateInventoryResult>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							vipapis.normal.UpdateInventoryResult elem1;
							
							elem1 = new vipapis.normal.UpdateInventoryResult();
							vipapis.normal.UpdateInventoryResultHelper.getInstance().Read(elem1, iprot);
							
							value.Add(elem1);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetUpdateInventoryResultList(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(pullUpdateInventoryResult_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetUpdateInventoryResultList() != null) {
					
					oprot.WriteFieldBegin("updateInventoryResultList");
					
					oprot.WriteListBegin();
					foreach(vipapis.normal.UpdateInventoryResult _item0 in structs.GetUpdateInventoryResultList()){
						
						
						vipapis.normal.UpdateInventoryResultHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("updateInventoryResultList can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(pullUpdateInventoryResult_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class updateAvailableInventory_argsHelper : TBeanSerializer<updateAvailableInventory_args>
		{
			
			public static updateAvailableInventory_argsHelper OBJ = new updateAvailableInventory_argsHelper();
			
			public static updateAvailableInventory_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(updateAvailableInventory_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.normal.AvailableInventoryRequest value;
					
					value = new vipapis.normal.AvailableInventoryRequest();
					vipapis.normal.AvailableInventoryRequestHelper.getInstance().Read(value, iprot);
					
					structs.SetAvailableInventoryRequest(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(updateAvailableInventory_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetAvailableInventoryRequest() != null) {
					
					oprot.WriteFieldBegin("availableInventoryRequest");
					
					vipapis.normal.AvailableInventoryRequestHelper.getInstance().Write(structs.GetAvailableInventoryRequest(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(updateAvailableInventory_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class updateSellableInventory_argsHelper : TBeanSerializer<updateSellableInventory_args>
		{
			
			public static updateSellableInventory_argsHelper OBJ = new updateSellableInventory_argsHelper();
			
			public static updateSellableInventory_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(updateSellableInventory_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.normal.SellableUpdateInventoryRequest value;
					
					value = new vipapis.normal.SellableUpdateInventoryRequest();
					vipapis.normal.SellableUpdateInventoryRequestHelper.getInstance().Read(value, iprot);
					
					structs.SetSellableUpdateInventoryRequest(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(updateSellableInventory_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSellableUpdateInventoryRequest() != null) {
					
					oprot.WriteFieldBegin("sellableUpdateInventoryRequest");
					
					vipapis.normal.SellableUpdateInventoryRequestHelper.getInstance().Write(structs.GetSellableUpdateInventoryRequest(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("sellableUpdateInventoryRequest can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(updateSellableInventory_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getInitialQuantityResult_resultHelper : TBeanSerializer<getInitialQuantityResult_result>
		{
			
			public static getInitialQuantityResult_resultHelper OBJ = new getInitialQuantityResult_resultHelper();
			
			public static getInitialQuantityResult_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getInitialQuantityResult_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.normal.ImportInitialQuantityResult value;
					
					value = new vipapis.normal.ImportInitialQuantityResult();
					vipapis.normal.ImportInitialQuantityResultHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getInitialQuantityResult_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.normal.ImportInitialQuantityResultHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getInitialQuantityResult_result bean){
				
				
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
					
					vipapis.normal.InventoryDeductOrdersResponse value;
					
					value = new vipapis.normal.InventoryDeductOrdersResponse();
					vipapis.normal.InventoryDeductOrdersResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getInventoryDeductOrders_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.normal.InventoryDeductOrdersResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
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
					
					vipapis.normal.OccupiedOrderResponse value;
					
					value = new vipapis.normal.OccupiedOrderResponse();
					vipapis.normal.OccupiedOrderResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getInventoryOccupiedOrders_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.normal.OccupiedOrderResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getInventoryOccupiedOrders_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getInventoryUpdateResult_resultHelper : TBeanSerializer<getInventoryUpdateResult_result>
		{
			
			public static getInventoryUpdateResult_resultHelper OBJ = new getInventoryUpdateResult_resultHelper();
			
			public static getInventoryUpdateResult_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getInventoryUpdateResult_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.normal.InventoryUpdateResultResponse value;
					
					value = new vipapis.normal.InventoryUpdateResultResponse();
					vipapis.normal.InventoryUpdateResultResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getInventoryUpdateResult_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.normal.InventoryUpdateResultResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getInventoryUpdateResult_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getScheduleProductList_resultHelper : TBeanSerializer<getScheduleProductList_result>
		{
			
			public static getScheduleProductList_resultHelper OBJ = new getScheduleProductList_resultHelper();
			
			public static getScheduleProductList_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getScheduleProductList_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.normal.ScheduleProductResponse value;
					
					value = new vipapis.normal.ScheduleProductResponse();
					vipapis.normal.ScheduleProductResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getScheduleProductList_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.normal.ScheduleProductResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getScheduleProductList_result bean){
				
				
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
		
		
		
		
		public class importInitialInventory_resultHelper : TBeanSerializer<importInitialInventory_result>
		{
			
			public static importInitialInventory_resultHelper OBJ = new importInitialInventory_resultHelper();
			
			public static importInitialInventory_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(importInitialInventory_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(importInitialInventory_result structs, Protocol oprot){
				
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
			
			
			public void Validate(importInitialInventory_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class pullUpdateInventoryResult_resultHelper : TBeanSerializer<pullUpdateInventoryResult_result>
		{
			
			public static pullUpdateInventoryResult_resultHelper OBJ = new pullUpdateInventoryResult_resultHelper();
			
			public static pullUpdateInventoryResult_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(pullUpdateInventoryResult_result structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(pullUpdateInventoryResult_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(pullUpdateInventoryResult_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class updateAvailableInventory_resultHelper : TBeanSerializer<updateAvailableInventory_result>
		{
			
			public static updateAvailableInventory_resultHelper OBJ = new updateAvailableInventory_resultHelper();
			
			public static updateAvailableInventory_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(updateAvailableInventory_result structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(updateAvailableInventory_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(updateAvailableInventory_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class updateSellableInventory_resultHelper : TBeanSerializer<updateSellableInventory_result>
		{
			
			public static updateSellableInventory_resultHelper OBJ = new updateSellableInventory_resultHelper();
			
			public static updateSellableInventory_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(updateSellableInventory_result structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(updateSellableInventory_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(updateSellableInventory_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class ProductInventoryServiceClient : OspRestStub , ProductInventoryService  {
			
			
			public ProductInventoryServiceClient():base("vipapis.normal.ProductInventoryService","1.0.0") {
				
				
			}
			
			
			
			public vipapis.normal.ImportInitialQuantityResult getInitialQuantityResult(int vendor_id_,long apply_id_,int? page_,int? limit_) {
				
				send_getInitialQuantityResult(vendor_id_,apply_id_,page_,limit_);
				return recv_getInitialQuantityResult(); 
				
			}
			
			
			private void send_getInitialQuantityResult(int vendor_id_,long apply_id_,int? page_,int? limit_){
				
				InitInvocation("getInitialQuantityResult");
				
				getInitialQuantityResult_args args = new getInitialQuantityResult_args();
				args.SetVendor_id(vendor_id_);
				args.SetApply_id(apply_id_);
				args.SetPage(page_);
				args.SetLimit(limit_);
				
				SendBase(args, getInitialQuantityResult_argsHelper.getInstance());
			}
			
			
			private vipapis.normal.ImportInitialQuantityResult recv_getInitialQuantityResult(){
				
				getInitialQuantityResult_result result = new getInitialQuantityResult_result();
				ReceiveBase(result, getInitialQuantityResult_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public vipapis.normal.InventoryDeductOrdersResponse getInventoryDeductOrders(vipapis.normal.InventoryDeductOrdersRequest inventoryDeductOrdersRequest_) {
				
				send_getInventoryDeductOrders(inventoryDeductOrdersRequest_);
				return recv_getInventoryDeductOrders(); 
				
			}
			
			
			private void send_getInventoryDeductOrders(vipapis.normal.InventoryDeductOrdersRequest inventoryDeductOrdersRequest_){
				
				InitInvocation("getInventoryDeductOrders");
				
				getInventoryDeductOrders_args args = new getInventoryDeductOrders_args();
				args.SetInventoryDeductOrdersRequest(inventoryDeductOrdersRequest_);
				
				SendBase(args, getInventoryDeductOrders_argsHelper.getInstance());
			}
			
			
			private vipapis.normal.InventoryDeductOrdersResponse recv_getInventoryDeductOrders(){
				
				getInventoryDeductOrders_result result = new getInventoryDeductOrders_result();
				ReceiveBase(result, getInventoryDeductOrders_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public vipapis.normal.OccupiedOrderResponse getInventoryOccupiedOrders(vipapis.normal.InventoryOccupiedOrdersRequest inventoryOccupiedOrdersRequest_) {
				
				send_getInventoryOccupiedOrders(inventoryOccupiedOrdersRequest_);
				return recv_getInventoryOccupiedOrders(); 
				
			}
			
			
			private void send_getInventoryOccupiedOrders(vipapis.normal.InventoryOccupiedOrdersRequest inventoryOccupiedOrdersRequest_){
				
				InitInvocation("getInventoryOccupiedOrders");
				
				getInventoryOccupiedOrders_args args = new getInventoryOccupiedOrders_args();
				args.SetInventoryOccupiedOrdersRequest(inventoryOccupiedOrdersRequest_);
				
				SendBase(args, getInventoryOccupiedOrders_argsHelper.getInstance());
			}
			
			
			private vipapis.normal.OccupiedOrderResponse recv_getInventoryOccupiedOrders(){
				
				getInventoryOccupiedOrders_result result = new getInventoryOccupiedOrders_result();
				ReceiveBase(result, getInventoryOccupiedOrders_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public vipapis.normal.InventoryUpdateResultResponse getInventoryUpdateResult(vipapis.normal.InventoryUpdateResultRequest inventoryUpdateResultRequest_) {
				
				send_getInventoryUpdateResult(inventoryUpdateResultRequest_);
				return recv_getInventoryUpdateResult(); 
				
			}
			
			
			private void send_getInventoryUpdateResult(vipapis.normal.InventoryUpdateResultRequest inventoryUpdateResultRequest_){
				
				InitInvocation("getInventoryUpdateResult");
				
				getInventoryUpdateResult_args args = new getInventoryUpdateResult_args();
				args.SetInventoryUpdateResultRequest(inventoryUpdateResultRequest_);
				
				SendBase(args, getInventoryUpdateResult_argsHelper.getInstance());
			}
			
			
			private vipapis.normal.InventoryUpdateResultResponse recv_getInventoryUpdateResult(){
				
				getInventoryUpdateResult_result result = new getInventoryUpdateResult_result();
				ReceiveBase(result, getInventoryUpdateResult_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public vipapis.normal.ScheduleProductResponse getScheduleProductList(vipapis.normal.ScheduleProductRequest scheduleProductRequest_) {
				
				send_getScheduleProductList(scheduleProductRequest_);
				return recv_getScheduleProductList(); 
				
			}
			
			
			private void send_getScheduleProductList(vipapis.normal.ScheduleProductRequest scheduleProductRequest_){
				
				InitInvocation("getScheduleProductList");
				
				getScheduleProductList_args args = new getScheduleProductList_args();
				args.SetScheduleProductRequest(scheduleProductRequest_);
				
				SendBase(args, getScheduleProductList_argsHelper.getInstance());
			}
			
			
			private vipapis.normal.ScheduleProductResponse recv_getScheduleProductList(){
				
				getScheduleProductList_result result = new getScheduleProductList_result();
				ReceiveBase(result, getScheduleProductList_resultHelper.getInstance());
				
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
			
			
			public string importInitialInventory(vipapis.normal.Cooperation cooperation_,List<vipapis.normal.Initialnventory> inventorys_) {
				
				send_importInitialInventory(cooperation_,inventorys_);
				return recv_importInitialInventory(); 
				
			}
			
			
			private void send_importInitialInventory(vipapis.normal.Cooperation cooperation_,List<vipapis.normal.Initialnventory> inventorys_){
				
				InitInvocation("importInitialInventory");
				
				importInitialInventory_args args = new importInitialInventory_args();
				args.SetCooperation(cooperation_);
				args.SetInventorys(inventorys_);
				
				SendBase(args, importInitialInventory_argsHelper.getInstance());
			}
			
			
			private string recv_importInitialInventory(){
				
				importInitialInventory_result result = new importInitialInventory_result();
				ReceiveBase(result, importInitialInventory_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public void pullUpdateInventoryResult(List<vipapis.normal.UpdateInventoryResult> updateInventoryResultList_) {
				
				send_pullUpdateInventoryResult(updateInventoryResultList_);
				recv_pullUpdateInventoryResult();
				
			}
			
			
			private void send_pullUpdateInventoryResult(List<vipapis.normal.UpdateInventoryResult> updateInventoryResultList_){
				
				InitInvocation("pullUpdateInventoryResult");
				
				pullUpdateInventoryResult_args args = new pullUpdateInventoryResult_args();
				args.SetUpdateInventoryResultList(updateInventoryResultList_);
				
				SendBase(args, pullUpdateInventoryResult_argsHelper.getInstance());
			}
			
			
			private void recv_pullUpdateInventoryResult(){
				
				pullUpdateInventoryResult_result result = new pullUpdateInventoryResult_result();
				ReceiveBase(result, pullUpdateInventoryResult_resultHelper.getInstance());
				
				
			}
			
			
			public void updateAvailableInventory(vipapis.normal.AvailableInventoryRequest availableInventoryRequest_) {
				
				send_updateAvailableInventory(availableInventoryRequest_);
				recv_updateAvailableInventory();
				
			}
			
			
			private void send_updateAvailableInventory(vipapis.normal.AvailableInventoryRequest availableInventoryRequest_){
				
				InitInvocation("updateAvailableInventory");
				
				updateAvailableInventory_args args = new updateAvailableInventory_args();
				args.SetAvailableInventoryRequest(availableInventoryRequest_);
				
				SendBase(args, updateAvailableInventory_argsHelper.getInstance());
			}
			
			
			private void recv_updateAvailableInventory(){
				
				updateAvailableInventory_result result = new updateAvailableInventory_result();
				ReceiveBase(result, updateAvailableInventory_resultHelper.getInstance());
				
				
			}
			
			
			public void updateSellableInventory(vipapis.normal.SellableUpdateInventoryRequest sellableUpdateInventoryRequest_) {
				
				send_updateSellableInventory(sellableUpdateInventoryRequest_);
				recv_updateSellableInventory();
				
			}
			
			
			private void send_updateSellableInventory(vipapis.normal.SellableUpdateInventoryRequest sellableUpdateInventoryRequest_){
				
				InitInvocation("updateSellableInventory");
				
				updateSellableInventory_args args = new updateSellableInventory_args();
				args.SetSellableUpdateInventoryRequest(sellableUpdateInventoryRequest_);
				
				SendBase(args, updateSellableInventory_argsHelper.getInstance());
			}
			
			
			private void recv_updateSellableInventory(){
				
				updateSellableInventory_result result = new updateSellableInventory_result();
				ReceiveBase(result, updateSellableInventory_resultHelper.getInstance());
				
				
			}
			
			
		}
		
		
	}
	
}