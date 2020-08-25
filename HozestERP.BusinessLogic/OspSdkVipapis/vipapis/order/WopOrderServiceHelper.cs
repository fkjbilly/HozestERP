using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;

namespace vipapis.order{
	
	
	public class WopOrderServiceHelper {
		
		
		
		public class createCancelCustomerBackOrder_args {
			
			///<summary>
			/// 供应商ID
			///</summary>
			
			private string vendor_id_;
			
			///<summary>
			/// 订单列表
			///</summary>
			
			private List<com.vip.domain.order.CreateCancelCustomerBackOrderInfo> orderList_;
			
			public string GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(string value){
				this.vendor_id_ = value;
			}
			public List<com.vip.domain.order.CreateCancelCustomerBackOrderInfo> GetOrderList(){
				return this.orderList_;
			}
			
			public void SetOrderList(List<com.vip.domain.order.CreateCancelCustomerBackOrderInfo> value){
				this.orderList_ = value;
			}
			
		}
		
		
		
		
		public class createCancelOrder_args {
			
			///<summary>
			/// 供应商ID
			///</summary>
			
			private string vendor_id_;
			
			///<summary>
			/// 订单取消列表
			///</summary>
			
			private List<com.vip.domain.order.CancelOrderInfo> cancelOrderList_;
			
			public string GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(string value){
				this.vendor_id_ = value;
			}
			public List<com.vip.domain.order.CancelOrderInfo> GetCancelOrderList(){
				return this.cancelOrderList_;
			}
			
			public void SetCancelOrderList(List<com.vip.domain.order.CancelOrderInfo> value){
				this.cancelOrderList_ = value;
			}
			
		}
		
		
		
		
		public class createCustomerBackOrder_args {
			
			///<summary>
			/// 供应商ID
			///</summary>
			
			private string vendor_id_;
			
			///<summary>
			/// 订单列表
			///</summary>
			
			private List<com.vip.domain.order.CustomerBackOrderInfo> orderList_;
			
			public string GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(string value){
				this.vendor_id_ = value;
			}
			public List<com.vip.domain.order.CustomerBackOrderInfo> GetOrderList(){
				return this.orderList_;
			}
			
			public void SetOrderList(List<com.vip.domain.order.CustomerBackOrderInfo> value){
				this.orderList_ = value;
			}
			
		}
		
		
		
		
		public class createOrder_args {
			
			///<summary>
			/// 供应商ID
			///</summary>
			
			private string vendor_id_;
			
			///<summary>
			/// 订单列表
			///</summary>
			
			private List<com.vip.domain.order.OrderInfo> orderList_;
			
			public string GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(string value){
				this.vendor_id_ = value;
			}
			public List<com.vip.domain.order.OrderInfo> GetOrderList(){
				return this.orderList_;
			}
			
			public void SetOrderList(List<com.vip.domain.order.OrderInfo> value){
				this.orderList_ = value;
			}
			
		}
		
		
		
		
		public class geCustomerBackOrderStatus_args {
			
			///<summary>
			/// 供应商ID
			///</summary>
			
			private string vendor_id_;
			
			///<summary>
			/// 客退单结果查询条件
			///</summary>
			
			private com.vip.domain.order.ResultQueryCondition condition_;
			
			public string GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(string value){
				this.vendor_id_ = value;
			}
			public com.vip.domain.order.ResultQueryCondition GetCondition(){
				return this.condition_;
			}
			
			public void SetCondition(com.vip.domain.order.ResultQueryCondition value){
				this.condition_ = value;
			}
			
		}
		
		
		
		
		public class getCancelOrderResult_args {
			
			///<summary>
			/// 供应商ID
			///</summary>
			
			private string vendor_id_;
			
			///<summary>
			/// 订单结果查询条件
			///</summary>
			
			private com.vip.domain.order.ResultQueryCondition condition_;
			
			public string GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(string value){
				this.vendor_id_ = value;
			}
			public com.vip.domain.order.ResultQueryCondition GetCondition(){
				return this.condition_;
			}
			
			public void SetCondition(com.vip.domain.order.ResultQueryCondition value){
				this.condition_ = value;
			}
			
		}
		
		
		
		
		public class getCreateCancelCustomerBackOrderResult_args {
			
			///<summary>
			/// 供应商ID
			///</summary>
			
			private string vendor_id_;
			
			///<summary>
			/// 客退取消单结果查询条件
			///</summary>
			
			private com.vip.domain.order.ResultQueryCondition condition_;
			
			public string GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(string value){
				this.vendor_id_ = value;
			}
			public com.vip.domain.order.ResultQueryCondition GetCondition(){
				return this.condition_;
			}
			
			public void SetCondition(com.vip.domain.order.ResultQueryCondition value){
				this.condition_ = value;
			}
			
		}
		
		
		
		
		public class getCreateCustomerBackOrderResult_args {
			
			///<summary>
			/// 供应商ID
			///</summary>
			
			private string vendor_id_;
			
			///<summary>
			/// 客退单结果查询条件
			///</summary>
			
			private com.vip.domain.order.ResultQueryCondition condition_;
			
			public string GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(string value){
				this.vendor_id_ = value;
			}
			public com.vip.domain.order.ResultQueryCondition GetCondition(){
				return this.condition_;
			}
			
			public void SetCondition(com.vip.domain.order.ResultQueryCondition value){
				this.condition_ = value;
			}
			
		}
		
		
		
		
		public class getCreateOrderResult_args {
			
			///<summary>
			/// 供应商ID
			///</summary>
			
			private string vendor_id_;
			
			///<summary>
			/// 订单结果查询条件
			///</summary>
			
			private com.vip.domain.order.ResultQueryCondition condition_;
			
			public string GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(string value){
				this.vendor_id_ = value;
			}
			public com.vip.domain.order.ResultQueryCondition GetCondition(){
				return this.condition_;
			}
			
			public void SetCondition(com.vip.domain.order.ResultQueryCondition value){
				this.condition_ = value;
			}
			
		}
		
		
		
		
		public class getCustomerBackOrderDetailInfo_args {
			
			///<summary>
			/// 供应商ID
			///</summary>
			
			private string vendor_id_;
			
			///<summary>
			/// 客退单轨迹查询条件
			///</summary>
			
			private com.vip.domain.order.CustomerBackOrderInfoQueryCondition condition_;
			
			public string GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(string value){
				this.vendor_id_ = value;
			}
			public com.vip.domain.order.CustomerBackOrderInfoQueryCondition GetCondition(){
				return this.condition_;
			}
			
			public void SetCondition(com.vip.domain.order.CustomerBackOrderInfoQueryCondition value){
				this.condition_ = value;
			}
			
		}
		
		
		
		
		public class getCustomerBackOrderTrack_args {
			
			///<summary>
			/// 供应商ID
			///</summary>
			
			private string vendor_id_;
			
			///<summary>
			/// 客退单轨迹查询条件
			///</summary>
			
			private com.vip.domain.order.CustomerBackOrderTrackQueryCondition condition_;
			
			public string GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(string value){
				this.vendor_id_ = value;
			}
			public com.vip.domain.order.CustomerBackOrderTrackQueryCondition GetCondition(){
				return this.condition_;
			}
			
			public void SetCondition(com.vip.domain.order.CustomerBackOrderTrackQueryCondition value){
				this.condition_ = value;
			}
			
		}
		
		
		
		
		public class getOrderStatus_args {
			
			///<summary>
			/// 供应商ID
			///</summary>
			
			private string vendor_id_;
			
			///<summary>
			/// 订单结果查询条件
			///</summary>
			
			private com.vip.domain.order.ResultQueryCondition condition_;
			
			public string GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(string value){
				this.vendor_id_ = value;
			}
			public com.vip.domain.order.ResultQueryCondition GetCondition(){
				return this.condition_;
			}
			
			public void SetCondition(com.vip.domain.order.ResultQueryCondition value){
				this.condition_ = value;
			}
			
		}
		
		
		
		
		public class getOrderTrack_args {
			
			///<summary>
			/// 供应商ID
			///</summary>
			
			private string vendor_id_;
			
			///<summary>
			/// 订单轨迹查询条件
			///</summary>
			
			private com.vip.domain.order.OrderTrackQueryCondition condition_;
			
			public string GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(string value){
				this.vendor_id_ = value;
			}
			public com.vip.domain.order.OrderTrackQueryCondition GetCondition(){
				return this.condition_;
			}
			
			public void SetCondition(com.vip.domain.order.OrderTrackQueryCondition value){
				this.condition_ = value;
			}
			
		}
		
		
		
		
		public class healthCheck_args {
			
			
		}
		
		
		
		
		public class createCancelCustomerBackOrder_result {
			
			///<summary>
			///</summary>
			
			private com.vip.domain.order.RequestResult success_;
			
			public com.vip.domain.order.RequestResult GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.domain.order.RequestResult value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class createCancelOrder_result {
			
			///<summary>
			///</summary>
			
			private com.vip.domain.order.RequestResult success_;
			
			public com.vip.domain.order.RequestResult GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.domain.order.RequestResult value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class createCustomerBackOrder_result {
			
			///<summary>
			///</summary>
			
			private com.vip.domain.order.RequestResult success_;
			
			public com.vip.domain.order.RequestResult GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.domain.order.RequestResult value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class createOrder_result {
			
			///<summary>
			///</summary>
			
			private com.vip.domain.order.RequestResult success_;
			
			public com.vip.domain.order.RequestResult GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.domain.order.RequestResult value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class geCustomerBackOrderStatus_result {
			
			///<summary>
			///</summary>
			
			private List<com.vip.domain.order.CustomerBackOrderStatusInfo> success_;
			
			public List<com.vip.domain.order.CustomerBackOrderStatusInfo> GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(List<com.vip.domain.order.CustomerBackOrderStatusInfo> value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getCancelOrderResult_result {
			
			///<summary>
			///</summary>
			
			private List<com.vip.domain.order.CancelOrderResult> success_;
			
			public List<com.vip.domain.order.CancelOrderResult> GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(List<com.vip.domain.order.CancelOrderResult> value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getCreateCancelCustomerBackOrderResult_result {
			
			///<summary>
			///</summary>
			
			private List<com.vip.domain.order.CreateCancelCustomerBackOrderResult> success_;
			
			public List<com.vip.domain.order.CreateCancelCustomerBackOrderResult> GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(List<com.vip.domain.order.CreateCancelCustomerBackOrderResult> value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getCreateCustomerBackOrderResult_result {
			
			///<summary>
			///</summary>
			
			private List<com.vip.domain.order.CreateCustomerBackOrderResult> success_;
			
			public List<com.vip.domain.order.CreateCustomerBackOrderResult> GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(List<com.vip.domain.order.CreateCustomerBackOrderResult> value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getCreateOrderResult_result {
			
			///<summary>
			///</summary>
			
			private List<com.vip.domain.order.CreateOrderResult> success_;
			
			public List<com.vip.domain.order.CreateOrderResult> GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(List<com.vip.domain.order.CreateOrderResult> value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getCustomerBackOrderDetailInfo_result {
			
			///<summary>
			///</summary>
			
			private com.vip.domain.order.CustomerBackOrderDetailInfo success_;
			
			public com.vip.domain.order.CustomerBackOrderDetailInfo GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.domain.order.CustomerBackOrderDetailInfo value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getCustomerBackOrderTrack_result {
			
			///<summary>
			///</summary>
			
			private List<com.vip.domain.order.CustomerBackOrderTrackInfo> success_;
			
			public List<com.vip.domain.order.CustomerBackOrderTrackInfo> GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(List<com.vip.domain.order.CustomerBackOrderTrackInfo> value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getOrderStatus_result {
			
			///<summary>
			///</summary>
			
			private List<com.vip.domain.order.OrderStatusInfo> success_;
			
			public List<com.vip.domain.order.OrderStatusInfo> GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(List<com.vip.domain.order.OrderStatusInfo> value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getOrderTrack_result {
			
			///<summary>
			///</summary>
			
			private List<com.vip.domain.order.OrderTrackInfo> success_;
			
			public List<com.vip.domain.order.OrderTrackInfo> GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(List<com.vip.domain.order.OrderTrackInfo> value){
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
		
		
		
		
		
		public class createCancelCustomerBackOrder_argsHelper : TBeanSerializer<createCancelCustomerBackOrder_args>
		{
			
			public static createCancelCustomerBackOrder_argsHelper OBJ = new createCancelCustomerBackOrder_argsHelper();
			
			public static createCancelCustomerBackOrder_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(createCancelCustomerBackOrder_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				
				if(true){
					
					List<com.vip.domain.order.CreateCancelCustomerBackOrderInfo> value;
					
					value = new List<com.vip.domain.order.CreateCancelCustomerBackOrderInfo>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							com.vip.domain.order.CreateCancelCustomerBackOrderInfo elem1;
							
							elem1 = new com.vip.domain.order.CreateCancelCustomerBackOrderInfo();
							com.vip.domain.order.CreateCancelCustomerBackOrderInfoHelper.getInstance().Read(elem1, iprot);
							
							value.Add(elem1);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetOrderList(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(createCancelCustomerBackOrder_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetVendor_id() != null) {
					
					oprot.WriteFieldBegin("vendor_id");
					oprot.WriteString(structs.GetVendor_id());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("vendor_id can not be null!");
				}
				
				
				if(structs.GetOrderList() != null) {
					
					oprot.WriteFieldBegin("orderList");
					
					oprot.WriteListBegin();
					foreach(com.vip.domain.order.CreateCancelCustomerBackOrderInfo _item0 in structs.GetOrderList()){
						
						
						com.vip.domain.order.CreateCancelCustomerBackOrderInfoHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("orderList can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(createCancelCustomerBackOrder_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class createCancelOrder_argsHelper : TBeanSerializer<createCancelOrder_args>
		{
			
			public static createCancelOrder_argsHelper OBJ = new createCancelOrder_argsHelper();
			
			public static createCancelOrder_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(createCancelOrder_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				
				if(true){
					
					List<com.vip.domain.order.CancelOrderInfo> value;
					
					value = new List<com.vip.domain.order.CancelOrderInfo>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							com.vip.domain.order.CancelOrderInfo elem1;
							
							elem1 = new com.vip.domain.order.CancelOrderInfo();
							com.vip.domain.order.CancelOrderInfoHelper.getInstance().Read(elem1, iprot);
							
							value.Add(elem1);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetCancelOrderList(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(createCancelOrder_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetVendor_id() != null) {
					
					oprot.WriteFieldBegin("vendor_id");
					oprot.WriteString(structs.GetVendor_id());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("vendor_id can not be null!");
				}
				
				
				if(structs.GetCancelOrderList() != null) {
					
					oprot.WriteFieldBegin("cancelOrderList");
					
					oprot.WriteListBegin();
					foreach(com.vip.domain.order.CancelOrderInfo _item0 in structs.GetCancelOrderList()){
						
						
						com.vip.domain.order.CancelOrderInfoHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("cancelOrderList can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(createCancelOrder_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class createCustomerBackOrder_argsHelper : TBeanSerializer<createCustomerBackOrder_args>
		{
			
			public static createCustomerBackOrder_argsHelper OBJ = new createCustomerBackOrder_argsHelper();
			
			public static createCustomerBackOrder_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(createCustomerBackOrder_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				
				if(true){
					
					List<com.vip.domain.order.CustomerBackOrderInfo> value;
					
					value = new List<com.vip.domain.order.CustomerBackOrderInfo>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							com.vip.domain.order.CustomerBackOrderInfo elem1;
							
							elem1 = new com.vip.domain.order.CustomerBackOrderInfo();
							com.vip.domain.order.CustomerBackOrderInfoHelper.getInstance().Read(elem1, iprot);
							
							value.Add(elem1);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetOrderList(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(createCustomerBackOrder_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetVendor_id() != null) {
					
					oprot.WriteFieldBegin("vendor_id");
					oprot.WriteString(structs.GetVendor_id());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("vendor_id can not be null!");
				}
				
				
				if(structs.GetOrderList() != null) {
					
					oprot.WriteFieldBegin("orderList");
					
					oprot.WriteListBegin();
					foreach(com.vip.domain.order.CustomerBackOrderInfo _item0 in structs.GetOrderList()){
						
						
						com.vip.domain.order.CustomerBackOrderInfoHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("orderList can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(createCustomerBackOrder_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class createOrder_argsHelper : TBeanSerializer<createOrder_args>
		{
			
			public static createOrder_argsHelper OBJ = new createOrder_argsHelper();
			
			public static createOrder_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(createOrder_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				
				if(true){
					
					List<com.vip.domain.order.OrderInfo> value;
					
					value = new List<com.vip.domain.order.OrderInfo>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							com.vip.domain.order.OrderInfo elem1;
							
							elem1 = new com.vip.domain.order.OrderInfo();
							com.vip.domain.order.OrderInfoHelper.getInstance().Read(elem1, iprot);
							
							value.Add(elem1);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetOrderList(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(createOrder_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetVendor_id() != null) {
					
					oprot.WriteFieldBegin("vendor_id");
					oprot.WriteString(structs.GetVendor_id());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("vendor_id can not be null!");
				}
				
				
				if(structs.GetOrderList() != null) {
					
					oprot.WriteFieldBegin("orderList");
					
					oprot.WriteListBegin();
					foreach(com.vip.domain.order.OrderInfo _item0 in structs.GetOrderList()){
						
						
						com.vip.domain.order.OrderInfoHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("orderList can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(createOrder_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class geCustomerBackOrderStatus_argsHelper : TBeanSerializer<geCustomerBackOrderStatus_args>
		{
			
			public static geCustomerBackOrderStatus_argsHelper OBJ = new geCustomerBackOrderStatus_argsHelper();
			
			public static geCustomerBackOrderStatus_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(geCustomerBackOrderStatus_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.domain.order.ResultQueryCondition value;
					
					value = new com.vip.domain.order.ResultQueryCondition();
					com.vip.domain.order.ResultQueryConditionHelper.getInstance().Read(value, iprot);
					
					structs.SetCondition(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(geCustomerBackOrderStatus_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetVendor_id() != null) {
					
					oprot.WriteFieldBegin("vendor_id");
					oprot.WriteString(structs.GetVendor_id());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("vendor_id can not be null!");
				}
				
				
				if(structs.GetCondition() != null) {
					
					oprot.WriteFieldBegin("condition");
					
					com.vip.domain.order.ResultQueryConditionHelper.getInstance().Write(structs.GetCondition(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("condition can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(geCustomerBackOrderStatus_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getCancelOrderResult_argsHelper : TBeanSerializer<getCancelOrderResult_args>
		{
			
			public static getCancelOrderResult_argsHelper OBJ = new getCancelOrderResult_argsHelper();
			
			public static getCancelOrderResult_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getCancelOrderResult_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.domain.order.ResultQueryCondition value;
					
					value = new com.vip.domain.order.ResultQueryCondition();
					com.vip.domain.order.ResultQueryConditionHelper.getInstance().Read(value, iprot);
					
					structs.SetCondition(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getCancelOrderResult_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetVendor_id() != null) {
					
					oprot.WriteFieldBegin("vendor_id");
					oprot.WriteString(structs.GetVendor_id());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("vendor_id can not be null!");
				}
				
				
				if(structs.GetCondition() != null) {
					
					oprot.WriteFieldBegin("condition");
					
					com.vip.domain.order.ResultQueryConditionHelper.getInstance().Write(structs.GetCondition(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("condition can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getCancelOrderResult_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getCreateCancelCustomerBackOrderResult_argsHelper : TBeanSerializer<getCreateCancelCustomerBackOrderResult_args>
		{
			
			public static getCreateCancelCustomerBackOrderResult_argsHelper OBJ = new getCreateCancelCustomerBackOrderResult_argsHelper();
			
			public static getCreateCancelCustomerBackOrderResult_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getCreateCancelCustomerBackOrderResult_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.domain.order.ResultQueryCondition value;
					
					value = new com.vip.domain.order.ResultQueryCondition();
					com.vip.domain.order.ResultQueryConditionHelper.getInstance().Read(value, iprot);
					
					structs.SetCondition(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getCreateCancelCustomerBackOrderResult_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetVendor_id() != null) {
					
					oprot.WriteFieldBegin("vendor_id");
					oprot.WriteString(structs.GetVendor_id());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("vendor_id can not be null!");
				}
				
				
				if(structs.GetCondition() != null) {
					
					oprot.WriteFieldBegin("condition");
					
					com.vip.domain.order.ResultQueryConditionHelper.getInstance().Write(structs.GetCondition(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("condition can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getCreateCancelCustomerBackOrderResult_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getCreateCustomerBackOrderResult_argsHelper : TBeanSerializer<getCreateCustomerBackOrderResult_args>
		{
			
			public static getCreateCustomerBackOrderResult_argsHelper OBJ = new getCreateCustomerBackOrderResult_argsHelper();
			
			public static getCreateCustomerBackOrderResult_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getCreateCustomerBackOrderResult_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.domain.order.ResultQueryCondition value;
					
					value = new com.vip.domain.order.ResultQueryCondition();
					com.vip.domain.order.ResultQueryConditionHelper.getInstance().Read(value, iprot);
					
					structs.SetCondition(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getCreateCustomerBackOrderResult_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetVendor_id() != null) {
					
					oprot.WriteFieldBegin("vendor_id");
					oprot.WriteString(structs.GetVendor_id());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("vendor_id can not be null!");
				}
				
				
				if(structs.GetCondition() != null) {
					
					oprot.WriteFieldBegin("condition");
					
					com.vip.domain.order.ResultQueryConditionHelper.getInstance().Write(structs.GetCondition(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("condition can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getCreateCustomerBackOrderResult_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getCreateOrderResult_argsHelper : TBeanSerializer<getCreateOrderResult_args>
		{
			
			public static getCreateOrderResult_argsHelper OBJ = new getCreateOrderResult_argsHelper();
			
			public static getCreateOrderResult_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getCreateOrderResult_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.domain.order.ResultQueryCondition value;
					
					value = new com.vip.domain.order.ResultQueryCondition();
					com.vip.domain.order.ResultQueryConditionHelper.getInstance().Read(value, iprot);
					
					structs.SetCondition(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getCreateOrderResult_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetVendor_id() != null) {
					
					oprot.WriteFieldBegin("vendor_id");
					oprot.WriteString(structs.GetVendor_id());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("vendor_id can not be null!");
				}
				
				
				if(structs.GetCondition() != null) {
					
					oprot.WriteFieldBegin("condition");
					
					com.vip.domain.order.ResultQueryConditionHelper.getInstance().Write(structs.GetCondition(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("condition can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getCreateOrderResult_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getCustomerBackOrderDetailInfo_argsHelper : TBeanSerializer<getCustomerBackOrderDetailInfo_args>
		{
			
			public static getCustomerBackOrderDetailInfo_argsHelper OBJ = new getCustomerBackOrderDetailInfo_argsHelper();
			
			public static getCustomerBackOrderDetailInfo_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getCustomerBackOrderDetailInfo_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.domain.order.CustomerBackOrderInfoQueryCondition value;
					
					value = new com.vip.domain.order.CustomerBackOrderInfoQueryCondition();
					com.vip.domain.order.CustomerBackOrderInfoQueryConditionHelper.getInstance().Read(value, iprot);
					
					structs.SetCondition(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getCustomerBackOrderDetailInfo_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetVendor_id() != null) {
					
					oprot.WriteFieldBegin("vendor_id");
					oprot.WriteString(structs.GetVendor_id());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("vendor_id can not be null!");
				}
				
				
				if(structs.GetCondition() != null) {
					
					oprot.WriteFieldBegin("condition");
					
					com.vip.domain.order.CustomerBackOrderInfoQueryConditionHelper.getInstance().Write(structs.GetCondition(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("condition can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getCustomerBackOrderDetailInfo_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getCustomerBackOrderTrack_argsHelper : TBeanSerializer<getCustomerBackOrderTrack_args>
		{
			
			public static getCustomerBackOrderTrack_argsHelper OBJ = new getCustomerBackOrderTrack_argsHelper();
			
			public static getCustomerBackOrderTrack_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getCustomerBackOrderTrack_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.domain.order.CustomerBackOrderTrackQueryCondition value;
					
					value = new com.vip.domain.order.CustomerBackOrderTrackQueryCondition();
					com.vip.domain.order.CustomerBackOrderTrackQueryConditionHelper.getInstance().Read(value, iprot);
					
					structs.SetCondition(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getCustomerBackOrderTrack_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetVendor_id() != null) {
					
					oprot.WriteFieldBegin("vendor_id");
					oprot.WriteString(structs.GetVendor_id());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("vendor_id can not be null!");
				}
				
				
				if(structs.GetCondition() != null) {
					
					oprot.WriteFieldBegin("condition");
					
					com.vip.domain.order.CustomerBackOrderTrackQueryConditionHelper.getInstance().Write(structs.GetCondition(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("condition can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getCustomerBackOrderTrack_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getOrderStatus_argsHelper : TBeanSerializer<getOrderStatus_args>
		{
			
			public static getOrderStatus_argsHelper OBJ = new getOrderStatus_argsHelper();
			
			public static getOrderStatus_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getOrderStatus_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.domain.order.ResultQueryCondition value;
					
					value = new com.vip.domain.order.ResultQueryCondition();
					com.vip.domain.order.ResultQueryConditionHelper.getInstance().Read(value, iprot);
					
					structs.SetCondition(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getOrderStatus_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetVendor_id() != null) {
					
					oprot.WriteFieldBegin("vendor_id");
					oprot.WriteString(structs.GetVendor_id());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("vendor_id can not be null!");
				}
				
				
				if(structs.GetCondition() != null) {
					
					oprot.WriteFieldBegin("condition");
					
					com.vip.domain.order.ResultQueryConditionHelper.getInstance().Write(structs.GetCondition(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("condition can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getOrderStatus_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getOrderTrack_argsHelper : TBeanSerializer<getOrderTrack_args>
		{
			
			public static getOrderTrack_argsHelper OBJ = new getOrderTrack_argsHelper();
			
			public static getOrderTrack_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getOrderTrack_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.domain.order.OrderTrackQueryCondition value;
					
					value = new com.vip.domain.order.OrderTrackQueryCondition();
					com.vip.domain.order.OrderTrackQueryConditionHelper.getInstance().Read(value, iprot);
					
					structs.SetCondition(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getOrderTrack_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetVendor_id() != null) {
					
					oprot.WriteFieldBegin("vendor_id");
					oprot.WriteString(structs.GetVendor_id());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("vendor_id can not be null!");
				}
				
				
				if(structs.GetCondition() != null) {
					
					oprot.WriteFieldBegin("condition");
					
					com.vip.domain.order.OrderTrackQueryConditionHelper.getInstance().Write(structs.GetCondition(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("condition can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getOrderTrack_args bean){
				
				
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
		
		
		
		
		public class createCancelCustomerBackOrder_resultHelper : TBeanSerializer<createCancelCustomerBackOrder_result>
		{
			
			public static createCancelCustomerBackOrder_resultHelper OBJ = new createCancelCustomerBackOrder_resultHelper();
			
			public static createCancelCustomerBackOrder_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(createCancelCustomerBackOrder_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.domain.order.RequestResult value;
					
					value = new com.vip.domain.order.RequestResult();
					com.vip.domain.order.RequestResultHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(createCancelCustomerBackOrder_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.domain.order.RequestResultHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(createCancelCustomerBackOrder_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class createCancelOrder_resultHelper : TBeanSerializer<createCancelOrder_result>
		{
			
			public static createCancelOrder_resultHelper OBJ = new createCancelOrder_resultHelper();
			
			public static createCancelOrder_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(createCancelOrder_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.domain.order.RequestResult value;
					
					value = new com.vip.domain.order.RequestResult();
					com.vip.domain.order.RequestResultHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(createCancelOrder_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.domain.order.RequestResultHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(createCancelOrder_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class createCustomerBackOrder_resultHelper : TBeanSerializer<createCustomerBackOrder_result>
		{
			
			public static createCustomerBackOrder_resultHelper OBJ = new createCustomerBackOrder_resultHelper();
			
			public static createCustomerBackOrder_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(createCustomerBackOrder_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.domain.order.RequestResult value;
					
					value = new com.vip.domain.order.RequestResult();
					com.vip.domain.order.RequestResultHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(createCustomerBackOrder_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.domain.order.RequestResultHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(createCustomerBackOrder_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class createOrder_resultHelper : TBeanSerializer<createOrder_result>
		{
			
			public static createOrder_resultHelper OBJ = new createOrder_resultHelper();
			
			public static createOrder_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(createOrder_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.domain.order.RequestResult value;
					
					value = new com.vip.domain.order.RequestResult();
					com.vip.domain.order.RequestResultHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(createOrder_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.domain.order.RequestResultHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(createOrder_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class geCustomerBackOrderStatus_resultHelper : TBeanSerializer<geCustomerBackOrderStatus_result>
		{
			
			public static geCustomerBackOrderStatus_resultHelper OBJ = new geCustomerBackOrderStatus_resultHelper();
			
			public static geCustomerBackOrderStatus_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(geCustomerBackOrderStatus_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					List<com.vip.domain.order.CustomerBackOrderStatusInfo> value;
					
					value = new List<com.vip.domain.order.CustomerBackOrderStatusInfo>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							com.vip.domain.order.CustomerBackOrderStatusInfo elem0;
							
							elem0 = new com.vip.domain.order.CustomerBackOrderStatusInfo();
							com.vip.domain.order.CustomerBackOrderStatusInfoHelper.getInstance().Read(elem0, iprot);
							
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
			
			
			public void Write(geCustomerBackOrderStatus_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					oprot.WriteListBegin();
					foreach(com.vip.domain.order.CustomerBackOrderStatusInfo _item0 in structs.GetSuccess()){
						
						
						com.vip.domain.order.CustomerBackOrderStatusInfoHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(geCustomerBackOrderStatus_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getCancelOrderResult_resultHelper : TBeanSerializer<getCancelOrderResult_result>
		{
			
			public static getCancelOrderResult_resultHelper OBJ = new getCancelOrderResult_resultHelper();
			
			public static getCancelOrderResult_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getCancelOrderResult_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					List<com.vip.domain.order.CancelOrderResult> value;
					
					value = new List<com.vip.domain.order.CancelOrderResult>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							com.vip.domain.order.CancelOrderResult elem1;
							
							elem1 = new com.vip.domain.order.CancelOrderResult();
							com.vip.domain.order.CancelOrderResultHelper.getInstance().Read(elem1, iprot);
							
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
			
			
			public void Write(getCancelOrderResult_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					oprot.WriteListBegin();
					foreach(com.vip.domain.order.CancelOrderResult _item0 in structs.GetSuccess()){
						
						
						com.vip.domain.order.CancelOrderResultHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getCancelOrderResult_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getCreateCancelCustomerBackOrderResult_resultHelper : TBeanSerializer<getCreateCancelCustomerBackOrderResult_result>
		{
			
			public static getCreateCancelCustomerBackOrderResult_resultHelper OBJ = new getCreateCancelCustomerBackOrderResult_resultHelper();
			
			public static getCreateCancelCustomerBackOrderResult_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getCreateCancelCustomerBackOrderResult_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					List<com.vip.domain.order.CreateCancelCustomerBackOrderResult> value;
					
					value = new List<com.vip.domain.order.CreateCancelCustomerBackOrderResult>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							com.vip.domain.order.CreateCancelCustomerBackOrderResult elem1;
							
							elem1 = new com.vip.domain.order.CreateCancelCustomerBackOrderResult();
							com.vip.domain.order.CreateCancelCustomerBackOrderResultHelper.getInstance().Read(elem1, iprot);
							
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
			
			
			public void Write(getCreateCancelCustomerBackOrderResult_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					oprot.WriteListBegin();
					foreach(com.vip.domain.order.CreateCancelCustomerBackOrderResult _item0 in structs.GetSuccess()){
						
						
						com.vip.domain.order.CreateCancelCustomerBackOrderResultHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getCreateCancelCustomerBackOrderResult_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getCreateCustomerBackOrderResult_resultHelper : TBeanSerializer<getCreateCustomerBackOrderResult_result>
		{
			
			public static getCreateCustomerBackOrderResult_resultHelper OBJ = new getCreateCustomerBackOrderResult_resultHelper();
			
			public static getCreateCustomerBackOrderResult_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getCreateCustomerBackOrderResult_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					List<com.vip.domain.order.CreateCustomerBackOrderResult> value;
					
					value = new List<com.vip.domain.order.CreateCustomerBackOrderResult>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							com.vip.domain.order.CreateCustomerBackOrderResult elem1;
							
							elem1 = new com.vip.domain.order.CreateCustomerBackOrderResult();
							com.vip.domain.order.CreateCustomerBackOrderResultHelper.getInstance().Read(elem1, iprot);
							
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
			
			
			public void Write(getCreateCustomerBackOrderResult_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					oprot.WriteListBegin();
					foreach(com.vip.domain.order.CreateCustomerBackOrderResult _item0 in structs.GetSuccess()){
						
						
						com.vip.domain.order.CreateCustomerBackOrderResultHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getCreateCustomerBackOrderResult_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getCreateOrderResult_resultHelper : TBeanSerializer<getCreateOrderResult_result>
		{
			
			public static getCreateOrderResult_resultHelper OBJ = new getCreateOrderResult_resultHelper();
			
			public static getCreateOrderResult_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getCreateOrderResult_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					List<com.vip.domain.order.CreateOrderResult> value;
					
					value = new List<com.vip.domain.order.CreateOrderResult>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							com.vip.domain.order.CreateOrderResult elem1;
							
							elem1 = new com.vip.domain.order.CreateOrderResult();
							com.vip.domain.order.CreateOrderResultHelper.getInstance().Read(elem1, iprot);
							
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
			
			
			public void Write(getCreateOrderResult_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					oprot.WriteListBegin();
					foreach(com.vip.domain.order.CreateOrderResult _item0 in structs.GetSuccess()){
						
						
						com.vip.domain.order.CreateOrderResultHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getCreateOrderResult_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getCustomerBackOrderDetailInfo_resultHelper : TBeanSerializer<getCustomerBackOrderDetailInfo_result>
		{
			
			public static getCustomerBackOrderDetailInfo_resultHelper OBJ = new getCustomerBackOrderDetailInfo_resultHelper();
			
			public static getCustomerBackOrderDetailInfo_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getCustomerBackOrderDetailInfo_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.domain.order.CustomerBackOrderDetailInfo value;
					
					value = new com.vip.domain.order.CustomerBackOrderDetailInfo();
					com.vip.domain.order.CustomerBackOrderDetailInfoHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getCustomerBackOrderDetailInfo_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.domain.order.CustomerBackOrderDetailInfoHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getCustomerBackOrderDetailInfo_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getCustomerBackOrderTrack_resultHelper : TBeanSerializer<getCustomerBackOrderTrack_result>
		{
			
			public static getCustomerBackOrderTrack_resultHelper OBJ = new getCustomerBackOrderTrack_resultHelper();
			
			public static getCustomerBackOrderTrack_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getCustomerBackOrderTrack_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					List<com.vip.domain.order.CustomerBackOrderTrackInfo> value;
					
					value = new List<com.vip.domain.order.CustomerBackOrderTrackInfo>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							com.vip.domain.order.CustomerBackOrderTrackInfo elem0;
							
							elem0 = new com.vip.domain.order.CustomerBackOrderTrackInfo();
							com.vip.domain.order.CustomerBackOrderTrackInfoHelper.getInstance().Read(elem0, iprot);
							
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
			
			
			public void Write(getCustomerBackOrderTrack_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					oprot.WriteListBegin();
					foreach(com.vip.domain.order.CustomerBackOrderTrackInfo _item0 in structs.GetSuccess()){
						
						
						com.vip.domain.order.CustomerBackOrderTrackInfoHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getCustomerBackOrderTrack_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getOrderStatus_resultHelper : TBeanSerializer<getOrderStatus_result>
		{
			
			public static getOrderStatus_resultHelper OBJ = new getOrderStatus_resultHelper();
			
			public static getOrderStatus_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getOrderStatus_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					List<com.vip.domain.order.OrderStatusInfo> value;
					
					value = new List<com.vip.domain.order.OrderStatusInfo>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							com.vip.domain.order.OrderStatusInfo elem1;
							
							elem1 = new com.vip.domain.order.OrderStatusInfo();
							com.vip.domain.order.OrderStatusInfoHelper.getInstance().Read(elem1, iprot);
							
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
			
			
			public void Write(getOrderStatus_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					oprot.WriteListBegin();
					foreach(com.vip.domain.order.OrderStatusInfo _item0 in structs.GetSuccess()){
						
						
						com.vip.domain.order.OrderStatusInfoHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getOrderStatus_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getOrderTrack_resultHelper : TBeanSerializer<getOrderTrack_result>
		{
			
			public static getOrderTrack_resultHelper OBJ = new getOrderTrack_resultHelper();
			
			public static getOrderTrack_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getOrderTrack_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					List<com.vip.domain.order.OrderTrackInfo> value;
					
					value = new List<com.vip.domain.order.OrderTrackInfo>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							com.vip.domain.order.OrderTrackInfo elem1;
							
							elem1 = new com.vip.domain.order.OrderTrackInfo();
							com.vip.domain.order.OrderTrackInfoHelper.getInstance().Read(elem1, iprot);
							
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
			
			
			public void Write(getOrderTrack_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					oprot.WriteListBegin();
					foreach(com.vip.domain.order.OrderTrackInfo _item0 in structs.GetSuccess()){
						
						
						com.vip.domain.order.OrderTrackInfoHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getOrderTrack_result bean){
				
				
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
		
		
		
		
		public class WopOrderServiceClient : OspRestStub , WopOrderService  {
			
			
			public WopOrderServiceClient():base("vipapis.order.WopOrderService","1.0.0") {
				
				
			}
			
			
			
			public com.vip.domain.order.RequestResult createCancelCustomerBackOrder(string vendor_id_,List<com.vip.domain.order.CreateCancelCustomerBackOrderInfo> orderList_) {
				
				send_createCancelCustomerBackOrder(vendor_id_,orderList_);
				return recv_createCancelCustomerBackOrder(); 
				
			}
			
			
			private void send_createCancelCustomerBackOrder(string vendor_id_,List<com.vip.domain.order.CreateCancelCustomerBackOrderInfo> orderList_){
				
				InitInvocation("createCancelCustomerBackOrder");
				
				createCancelCustomerBackOrder_args args = new createCancelCustomerBackOrder_args();
				args.SetVendor_id(vendor_id_);
				args.SetOrderList(orderList_);
				
				SendBase(args, createCancelCustomerBackOrder_argsHelper.getInstance());
			}
			
			
			private com.vip.domain.order.RequestResult recv_createCancelCustomerBackOrder(){
				
				createCancelCustomerBackOrder_result result = new createCancelCustomerBackOrder_result();
				ReceiveBase(result, createCancelCustomerBackOrder_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.domain.order.RequestResult createCancelOrder(string vendor_id_,List<com.vip.domain.order.CancelOrderInfo> cancelOrderList_) {
				
				send_createCancelOrder(vendor_id_,cancelOrderList_);
				return recv_createCancelOrder(); 
				
			}
			
			
			private void send_createCancelOrder(string vendor_id_,List<com.vip.domain.order.CancelOrderInfo> cancelOrderList_){
				
				InitInvocation("createCancelOrder");
				
				createCancelOrder_args args = new createCancelOrder_args();
				args.SetVendor_id(vendor_id_);
				args.SetCancelOrderList(cancelOrderList_);
				
				SendBase(args, createCancelOrder_argsHelper.getInstance());
			}
			
			
			private com.vip.domain.order.RequestResult recv_createCancelOrder(){
				
				createCancelOrder_result result = new createCancelOrder_result();
				ReceiveBase(result, createCancelOrder_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.domain.order.RequestResult createCustomerBackOrder(string vendor_id_,List<com.vip.domain.order.CustomerBackOrderInfo> orderList_) {
				
				send_createCustomerBackOrder(vendor_id_,orderList_);
				return recv_createCustomerBackOrder(); 
				
			}
			
			
			private void send_createCustomerBackOrder(string vendor_id_,List<com.vip.domain.order.CustomerBackOrderInfo> orderList_){
				
				InitInvocation("createCustomerBackOrder");
				
				createCustomerBackOrder_args args = new createCustomerBackOrder_args();
				args.SetVendor_id(vendor_id_);
				args.SetOrderList(orderList_);
				
				SendBase(args, createCustomerBackOrder_argsHelper.getInstance());
			}
			
			
			private com.vip.domain.order.RequestResult recv_createCustomerBackOrder(){
				
				createCustomerBackOrder_result result = new createCustomerBackOrder_result();
				ReceiveBase(result, createCustomerBackOrder_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.domain.order.RequestResult createOrder(string vendor_id_,List<com.vip.domain.order.OrderInfo> orderList_) {
				
				send_createOrder(vendor_id_,orderList_);
				return recv_createOrder(); 
				
			}
			
			
			private void send_createOrder(string vendor_id_,List<com.vip.domain.order.OrderInfo> orderList_){
				
				InitInvocation("createOrder");
				
				createOrder_args args = new createOrder_args();
				args.SetVendor_id(vendor_id_);
				args.SetOrderList(orderList_);
				
				SendBase(args, createOrder_argsHelper.getInstance());
			}
			
			
			private com.vip.domain.order.RequestResult recv_createOrder(){
				
				createOrder_result result = new createOrder_result();
				ReceiveBase(result, createOrder_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public List<com.vip.domain.order.CustomerBackOrderStatusInfo> geCustomerBackOrderStatus(string vendor_id_,com.vip.domain.order.ResultQueryCondition condition_) {
				
				send_geCustomerBackOrderStatus(vendor_id_,condition_);
				return recv_geCustomerBackOrderStatus(); 
				
			}
			
			
			private void send_geCustomerBackOrderStatus(string vendor_id_,com.vip.domain.order.ResultQueryCondition condition_){
				
				InitInvocation("geCustomerBackOrderStatus");
				
				geCustomerBackOrderStatus_args args = new geCustomerBackOrderStatus_args();
				args.SetVendor_id(vendor_id_);
				args.SetCondition(condition_);
				
				SendBase(args, geCustomerBackOrderStatus_argsHelper.getInstance());
			}
			
			
			private List<com.vip.domain.order.CustomerBackOrderStatusInfo> recv_geCustomerBackOrderStatus(){
				
				geCustomerBackOrderStatus_result result = new geCustomerBackOrderStatus_result();
				ReceiveBase(result, geCustomerBackOrderStatus_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public List<com.vip.domain.order.CancelOrderResult> getCancelOrderResult(string vendor_id_,com.vip.domain.order.ResultQueryCondition condition_) {
				
				send_getCancelOrderResult(vendor_id_,condition_);
				return recv_getCancelOrderResult(); 
				
			}
			
			
			private void send_getCancelOrderResult(string vendor_id_,com.vip.domain.order.ResultQueryCondition condition_){
				
				InitInvocation("getCancelOrderResult");
				
				getCancelOrderResult_args args = new getCancelOrderResult_args();
				args.SetVendor_id(vendor_id_);
				args.SetCondition(condition_);
				
				SendBase(args, getCancelOrderResult_argsHelper.getInstance());
			}
			
			
			private List<com.vip.domain.order.CancelOrderResult> recv_getCancelOrderResult(){
				
				getCancelOrderResult_result result = new getCancelOrderResult_result();
				ReceiveBase(result, getCancelOrderResult_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public List<com.vip.domain.order.CreateCancelCustomerBackOrderResult> getCreateCancelCustomerBackOrderResult(string vendor_id_,com.vip.domain.order.ResultQueryCondition condition_) {
				
				send_getCreateCancelCustomerBackOrderResult(vendor_id_,condition_);
				return recv_getCreateCancelCustomerBackOrderResult(); 
				
			}
			
			
			private void send_getCreateCancelCustomerBackOrderResult(string vendor_id_,com.vip.domain.order.ResultQueryCondition condition_){
				
				InitInvocation("getCreateCancelCustomerBackOrderResult");
				
				getCreateCancelCustomerBackOrderResult_args args = new getCreateCancelCustomerBackOrderResult_args();
				args.SetVendor_id(vendor_id_);
				args.SetCondition(condition_);
				
				SendBase(args, getCreateCancelCustomerBackOrderResult_argsHelper.getInstance());
			}
			
			
			private List<com.vip.domain.order.CreateCancelCustomerBackOrderResult> recv_getCreateCancelCustomerBackOrderResult(){
				
				getCreateCancelCustomerBackOrderResult_result result = new getCreateCancelCustomerBackOrderResult_result();
				ReceiveBase(result, getCreateCancelCustomerBackOrderResult_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public List<com.vip.domain.order.CreateCustomerBackOrderResult> getCreateCustomerBackOrderResult(string vendor_id_,com.vip.domain.order.ResultQueryCondition condition_) {
				
				send_getCreateCustomerBackOrderResult(vendor_id_,condition_);
				return recv_getCreateCustomerBackOrderResult(); 
				
			}
			
			
			private void send_getCreateCustomerBackOrderResult(string vendor_id_,com.vip.domain.order.ResultQueryCondition condition_){
				
				InitInvocation("getCreateCustomerBackOrderResult");
				
				getCreateCustomerBackOrderResult_args args = new getCreateCustomerBackOrderResult_args();
				args.SetVendor_id(vendor_id_);
				args.SetCondition(condition_);
				
				SendBase(args, getCreateCustomerBackOrderResult_argsHelper.getInstance());
			}
			
			
			private List<com.vip.domain.order.CreateCustomerBackOrderResult> recv_getCreateCustomerBackOrderResult(){
				
				getCreateCustomerBackOrderResult_result result = new getCreateCustomerBackOrderResult_result();
				ReceiveBase(result, getCreateCustomerBackOrderResult_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public List<com.vip.domain.order.CreateOrderResult> getCreateOrderResult(string vendor_id_,com.vip.domain.order.ResultQueryCondition condition_) {
				
				send_getCreateOrderResult(vendor_id_,condition_);
				return recv_getCreateOrderResult(); 
				
			}
			
			
			private void send_getCreateOrderResult(string vendor_id_,com.vip.domain.order.ResultQueryCondition condition_){
				
				InitInvocation("getCreateOrderResult");
				
				getCreateOrderResult_args args = new getCreateOrderResult_args();
				args.SetVendor_id(vendor_id_);
				args.SetCondition(condition_);
				
				SendBase(args, getCreateOrderResult_argsHelper.getInstance());
			}
			
			
			private List<com.vip.domain.order.CreateOrderResult> recv_getCreateOrderResult(){
				
				getCreateOrderResult_result result = new getCreateOrderResult_result();
				ReceiveBase(result, getCreateOrderResult_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.domain.order.CustomerBackOrderDetailInfo getCustomerBackOrderDetailInfo(string vendor_id_,com.vip.domain.order.CustomerBackOrderInfoQueryCondition condition_) {
				
				send_getCustomerBackOrderDetailInfo(vendor_id_,condition_);
				return recv_getCustomerBackOrderDetailInfo(); 
				
			}
			
			
			private void send_getCustomerBackOrderDetailInfo(string vendor_id_,com.vip.domain.order.CustomerBackOrderInfoQueryCondition condition_){
				
				InitInvocation("getCustomerBackOrderDetailInfo");
				
				getCustomerBackOrderDetailInfo_args args = new getCustomerBackOrderDetailInfo_args();
				args.SetVendor_id(vendor_id_);
				args.SetCondition(condition_);
				
				SendBase(args, getCustomerBackOrderDetailInfo_argsHelper.getInstance());
			}
			
			
			private com.vip.domain.order.CustomerBackOrderDetailInfo recv_getCustomerBackOrderDetailInfo(){
				
				getCustomerBackOrderDetailInfo_result result = new getCustomerBackOrderDetailInfo_result();
				ReceiveBase(result, getCustomerBackOrderDetailInfo_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public List<com.vip.domain.order.CustomerBackOrderTrackInfo> getCustomerBackOrderTrack(string vendor_id_,com.vip.domain.order.CustomerBackOrderTrackQueryCondition condition_) {
				
				send_getCustomerBackOrderTrack(vendor_id_,condition_);
				return recv_getCustomerBackOrderTrack(); 
				
			}
			
			
			private void send_getCustomerBackOrderTrack(string vendor_id_,com.vip.domain.order.CustomerBackOrderTrackQueryCondition condition_){
				
				InitInvocation("getCustomerBackOrderTrack");
				
				getCustomerBackOrderTrack_args args = new getCustomerBackOrderTrack_args();
				args.SetVendor_id(vendor_id_);
				args.SetCondition(condition_);
				
				SendBase(args, getCustomerBackOrderTrack_argsHelper.getInstance());
			}
			
			
			private List<com.vip.domain.order.CustomerBackOrderTrackInfo> recv_getCustomerBackOrderTrack(){
				
				getCustomerBackOrderTrack_result result = new getCustomerBackOrderTrack_result();
				ReceiveBase(result, getCustomerBackOrderTrack_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public List<com.vip.domain.order.OrderStatusInfo> getOrderStatus(string vendor_id_,com.vip.domain.order.ResultQueryCondition condition_) {
				
				send_getOrderStatus(vendor_id_,condition_);
				return recv_getOrderStatus(); 
				
			}
			
			
			private void send_getOrderStatus(string vendor_id_,com.vip.domain.order.ResultQueryCondition condition_){
				
				InitInvocation("getOrderStatus");
				
				getOrderStatus_args args = new getOrderStatus_args();
				args.SetVendor_id(vendor_id_);
				args.SetCondition(condition_);
				
				SendBase(args, getOrderStatus_argsHelper.getInstance());
			}
			
			
			private List<com.vip.domain.order.OrderStatusInfo> recv_getOrderStatus(){
				
				getOrderStatus_result result = new getOrderStatus_result();
				ReceiveBase(result, getOrderStatus_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public List<com.vip.domain.order.OrderTrackInfo> getOrderTrack(string vendor_id_,com.vip.domain.order.OrderTrackQueryCondition condition_) {
				
				send_getOrderTrack(vendor_id_,condition_);
				return recv_getOrderTrack(); 
				
			}
			
			
			private void send_getOrderTrack(string vendor_id_,com.vip.domain.order.OrderTrackQueryCondition condition_){
				
				InitInvocation("getOrderTrack");
				
				getOrderTrack_args args = new getOrderTrack_args();
				args.SetVendor_id(vendor_id_);
				args.SetCondition(condition_);
				
				SendBase(args, getOrderTrack_argsHelper.getInstance());
			}
			
			
			private List<com.vip.domain.order.OrderTrackInfo> recv_getOrderTrack(){
				
				getOrderTrack_result result = new getOrderTrack_result();
				ReceiveBase(result, getOrderTrack_resultHelper.getInstance());
				
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
			
			
		}
		
		
	}
	
}