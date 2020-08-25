using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;

namespace vipapis.overseas{
	
	
	public class OWarehouseServiceHelper {
		
		
		
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
		
		
		
		
		public class healthCheck_args {
			
			
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
		
		
		
		
		
		public class deliverOrderStatus_argsHelper : BeanSerializer<deliverOrderStatus_args>
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
							
							vipapis.overseas.OrderStatusItem elem1;
							
							elem1 = new vipapis.overseas.OrderStatusItem();
							vipapis.overseas.OrderStatusItemHelper.getInstance().Read(elem1, iprot);
							
							value.Add(elem1);
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
		
		
		
		
		public class deliverSaleOrder_argsHelper : BeanSerializer<deliverSaleOrder_args>
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
		
		
		
		
		public class getPoBatchList_argsHelper : BeanSerializer<getPoBatchList_args>
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
							
							string elem1;
							elem1 = iprot.ReadString();
							
							value.Add(elem1);
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
		
		
		
		
		public class healthCheck_argsHelper : BeanSerializer<healthCheck_args>
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
		
		
		
		
		public class updatePoBatchStatus_argsHelper : BeanSerializer<updatePoBatchStatus_args>
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
		
		
		
		
		public class deliverOrderStatus_resultHelper : BeanSerializer<deliverOrderStatus_result>
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
		
		
		
		
		public class deliverSaleOrder_resultHelper : BeanSerializer<deliverSaleOrder_result>
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
		
		
		
		
		public class getPoBatchList_resultHelper : BeanSerializer<getPoBatchList_result>
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
		
		
		
		
		public class healthCheck_resultHelper : BeanSerializer<healthCheck_result>
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
		
		
		
		
		public class updatePoBatchStatus_resultHelper : BeanSerializer<updatePoBatchStatus_result>
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
		
		
		
		
		public class OWarehouseServiceClient : OspRestStub , OWarehouseService  {
			
			
			public OWarehouseServiceClient():base("vipapis.overseas.OWarehouseService","1.0.0") {
				
				
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
			
			
		}
		
		
	}
	
}