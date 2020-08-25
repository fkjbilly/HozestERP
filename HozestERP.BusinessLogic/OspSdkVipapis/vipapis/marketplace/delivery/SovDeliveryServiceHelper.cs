using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;

namespace vipapis.marketplace.delivery{
	
	
	public class SovDeliveryServiceHelper {
		
		
		
		public class editShipInfo_args {
			
			///<summary>
			/// 需要修改配送信息的发货单
			///</summary>
			
			private vipapis.marketplace.delivery.EditedShipInfo edited_ship_info_;
			
			public vipapis.marketplace.delivery.EditedShipInfo GetEdited_ship_info(){
				return this.edited_ship_info_;
			}
			
			public void SetEdited_ship_info(vipapis.marketplace.delivery.EditedShipInfo value){
				this.edited_ship_info_ = value;
			}
			
		}
		
		
		
		
		public class exportOrderById_args {
			
			///<summary>
			/// 输入参数
			///</summary>
			
			private vipapis.marketplace.delivery.ExportOrderByIdRequest request_;
			
			public vipapis.marketplace.delivery.ExportOrderByIdRequest GetRequest(){
				return this.request_;
			}
			
			public void SetRequest(vipapis.marketplace.delivery.ExportOrderByIdRequest value){
				this.request_ = value;
			}
			
		}
		
		
		
		
		public class getCarriers_args {
			
			
		}
		
		
		
		
		public class getOrderDetail_args {
			
			///<summary>
			/// 订单号集合
			///</summary>
			
			private List<string> order_ids_;
			
			public List<string> GetOrder_ids(){
				return this.order_ids_;
			}
			
			public void SetOrder_ids(List<string> value){
				this.order_ids_ = value;
			}
			
		}
		
		
		
		
		public class getOrderStatusById_args {
			
			///<summary>
			/// 输入参数
			///</summary>
			
			private vipapis.marketplace.delivery.GetOrderStatusByIdRequest request_;
			
			public vipapis.marketplace.delivery.GetOrderStatusByIdRequest GetRequest(){
				return this.request_;
			}
			
			public void SetRequest(vipapis.marketplace.delivery.GetOrderStatusByIdRequest value){
				this.request_ = value;
			}
			
		}
		
		
		
		
		public class getOrders_args {
			
			///<summary>
			/// 输入参数
			///</summary>
			
			private vipapis.marketplace.delivery.GetOrdersRequest request_;
			
			public vipapis.marketplace.delivery.GetOrdersRequest GetRequest(){
				return this.request_;
			}
			
			public void SetRequest(vipapis.marketplace.delivery.GetOrdersRequest value){
				this.request_ = value;
			}
			
		}
		
		
		
		
		public class getPrintTemplate_args {
			
			///<summary>
			/// 订单号
			///</summary>
			
			private string order_id_;
			
			public string GetOrder_id(){
				return this.order_id_;
			}
			
			public void SetOrder_id(string value){
				this.order_id_ = value;
			}
			
		}
		
		
		
		
		public class healthCheck_args {
			
			
		}
		
		
		
		
		public class ship_args {
			
			///<summary>
			/// 输入参数
			///</summary>
			
			private vipapis.marketplace.delivery.ShipRequest request_;
			
			public vipapis.marketplace.delivery.ShipRequest GetRequest(){
				return this.request_;
			}
			
			public void SetRequest(vipapis.marketplace.delivery.ShipRequest value){
				this.request_ = value;
			}
			
		}
		
		
		
		
		public class editShipInfo_result {
			
			///<summary>
			///</summary>
			
			private vipapis.marketplace.delivery.EditedShipInfoResponse success_;
			
			public vipapis.marketplace.delivery.EditedShipInfoResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.marketplace.delivery.EditedShipInfoResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class exportOrderById_result {
			
			///<summary>
			///</summary>
			
			private vipapis.marketplace.delivery.ExportOrderByIdResponse success_;
			
			public vipapis.marketplace.delivery.ExportOrderByIdResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.marketplace.delivery.ExportOrderByIdResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getCarriers_result {
			
			///<summary>
			///</summary>
			
			private List<vipapis.marketplace.delivery.Carrier> success_;
			
			public List<vipapis.marketplace.delivery.Carrier> GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(List<vipapis.marketplace.delivery.Carrier> value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getOrderDetail_result {
			
			///<summary>
			///</summary>
			
			private List<vipapis.marketplace.delivery.OrderDetail> success_;
			
			public List<vipapis.marketplace.delivery.OrderDetail> GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(List<vipapis.marketplace.delivery.OrderDetail> value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getOrderStatusById_result {
			
			///<summary>
			///</summary>
			
			private vipapis.marketplace.delivery.GetOrderStatusByIdResponse success_;
			
			public vipapis.marketplace.delivery.GetOrderStatusByIdResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.marketplace.delivery.GetOrderStatusByIdResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getOrders_result {
			
			///<summary>
			///</summary>
			
			private vipapis.marketplace.delivery.GetOrdersResponse success_;
			
			public vipapis.marketplace.delivery.GetOrdersResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.marketplace.delivery.GetOrdersResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getPrintTemplate_result {
			
			///<summary>
			///</summary>
			
			private vipapis.marketplace.delivery.GetPrintTemplateResponse success_;
			
			public vipapis.marketplace.delivery.GetPrintTemplateResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.marketplace.delivery.GetPrintTemplateResponse value){
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
		
		
		
		
		public class ship_result {
			
			///<summary>
			///</summary>
			
			private vipapis.marketplace.delivery.ShipResponse success_;
			
			public vipapis.marketplace.delivery.ShipResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.marketplace.delivery.ShipResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		
		public class editShipInfo_argsHelper : TBeanSerializer<editShipInfo_args>
		{
			
			public static editShipInfo_argsHelper OBJ = new editShipInfo_argsHelper();
			
			public static editShipInfo_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(editShipInfo_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.marketplace.delivery.EditedShipInfo value;
					
					value = new vipapis.marketplace.delivery.EditedShipInfo();
					vipapis.marketplace.delivery.EditedShipInfoHelper.getInstance().Read(value, iprot);
					
					structs.SetEdited_ship_info(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(editShipInfo_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetEdited_ship_info() != null) {
					
					oprot.WriteFieldBegin("edited_ship_info");
					
					vipapis.marketplace.delivery.EditedShipInfoHelper.getInstance().Write(structs.GetEdited_ship_info(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("edited_ship_info can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(editShipInfo_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class exportOrderById_argsHelper : TBeanSerializer<exportOrderById_args>
		{
			
			public static exportOrderById_argsHelper OBJ = new exportOrderById_argsHelper();
			
			public static exportOrderById_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(exportOrderById_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.marketplace.delivery.ExportOrderByIdRequest value;
					
					value = new vipapis.marketplace.delivery.ExportOrderByIdRequest();
					vipapis.marketplace.delivery.ExportOrderByIdRequestHelper.getInstance().Read(value, iprot);
					
					structs.SetRequest(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(exportOrderById_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequest() != null) {
					
					oprot.WriteFieldBegin("request");
					
					vipapis.marketplace.delivery.ExportOrderByIdRequestHelper.getInstance().Write(structs.GetRequest(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("request can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(exportOrderById_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getCarriers_argsHelper : TBeanSerializer<getCarriers_args>
		{
			
			public static getCarriers_argsHelper OBJ = new getCarriers_argsHelper();
			
			public static getCarriers_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getCarriers_args structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getCarriers_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getCarriers_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getOrderDetail_argsHelper : TBeanSerializer<getOrderDetail_args>
		{
			
			public static getOrderDetail_argsHelper OBJ = new getOrderDetail_argsHelper();
			
			public static getOrderDetail_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getOrderDetail_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					List<string> value;
					
					value = new List<string>();
					iprot.ReadSetBegin();
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
					
					iprot.ReadSetEnd();
					
					structs.SetOrder_ids(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getOrderDetail_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetOrder_ids() != null) {
					
					oprot.WriteFieldBegin("order_ids");
					
					oprot.WriteSetBegin();
					foreach(string _item0 in structs.GetOrder_ids()){
						
						oprot.WriteString(_item0);
						
					}
					
					oprot.WriteSetEnd();
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("order_ids can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getOrderDetail_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getOrderStatusById_argsHelper : TBeanSerializer<getOrderStatusById_args>
		{
			
			public static getOrderStatusById_argsHelper OBJ = new getOrderStatusById_argsHelper();
			
			public static getOrderStatusById_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getOrderStatusById_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.marketplace.delivery.GetOrderStatusByIdRequest value;
					
					value = new vipapis.marketplace.delivery.GetOrderStatusByIdRequest();
					vipapis.marketplace.delivery.GetOrderStatusByIdRequestHelper.getInstance().Read(value, iprot);
					
					structs.SetRequest(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getOrderStatusById_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequest() != null) {
					
					oprot.WriteFieldBegin("request");
					
					vipapis.marketplace.delivery.GetOrderStatusByIdRequestHelper.getInstance().Write(structs.GetRequest(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("request can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getOrderStatusById_args bean){
				
				
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
					
					vipapis.marketplace.delivery.GetOrdersRequest value;
					
					value = new vipapis.marketplace.delivery.GetOrdersRequest();
					vipapis.marketplace.delivery.GetOrdersRequestHelper.getInstance().Read(value, iprot);
					
					structs.SetRequest(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getOrders_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequest() != null) {
					
					oprot.WriteFieldBegin("request");
					
					vipapis.marketplace.delivery.GetOrdersRequestHelper.getInstance().Write(structs.GetRequest(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("request can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getOrders_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getPrintTemplate_argsHelper : TBeanSerializer<getPrintTemplate_args>
		{
			
			public static getPrintTemplate_argsHelper OBJ = new getPrintTemplate_argsHelper();
			
			public static getPrintTemplate_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getPrintTemplate_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetOrder_id(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getPrintTemplate_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetOrder_id() != null) {
					
					oprot.WriteFieldBegin("order_id");
					oprot.WriteString(structs.GetOrder_id());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("order_id can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getPrintTemplate_args bean){
				
				
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
		
		
		
		
		public class ship_argsHelper : TBeanSerializer<ship_args>
		{
			
			public static ship_argsHelper OBJ = new ship_argsHelper();
			
			public static ship_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(ship_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.marketplace.delivery.ShipRequest value;
					
					value = new vipapis.marketplace.delivery.ShipRequest();
					vipapis.marketplace.delivery.ShipRequestHelper.getInstance().Read(value, iprot);
					
					structs.SetRequest(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(ship_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequest() != null) {
					
					oprot.WriteFieldBegin("request");
					
					vipapis.marketplace.delivery.ShipRequestHelper.getInstance().Write(structs.GetRequest(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("request can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(ship_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class editShipInfo_resultHelper : TBeanSerializer<editShipInfo_result>
		{
			
			public static editShipInfo_resultHelper OBJ = new editShipInfo_resultHelper();
			
			public static editShipInfo_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(editShipInfo_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.marketplace.delivery.EditedShipInfoResponse value;
					
					value = new vipapis.marketplace.delivery.EditedShipInfoResponse();
					vipapis.marketplace.delivery.EditedShipInfoResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(editShipInfo_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.marketplace.delivery.EditedShipInfoResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(editShipInfo_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class exportOrderById_resultHelper : TBeanSerializer<exportOrderById_result>
		{
			
			public static exportOrderById_resultHelper OBJ = new exportOrderById_resultHelper();
			
			public static exportOrderById_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(exportOrderById_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.marketplace.delivery.ExportOrderByIdResponse value;
					
					value = new vipapis.marketplace.delivery.ExportOrderByIdResponse();
					vipapis.marketplace.delivery.ExportOrderByIdResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(exportOrderById_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.marketplace.delivery.ExportOrderByIdResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(exportOrderById_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getCarriers_resultHelper : TBeanSerializer<getCarriers_result>
		{
			
			public static getCarriers_resultHelper OBJ = new getCarriers_resultHelper();
			
			public static getCarriers_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getCarriers_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					List<vipapis.marketplace.delivery.Carrier> value;
					
					value = new List<vipapis.marketplace.delivery.Carrier>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							vipapis.marketplace.delivery.Carrier elem0;
							
							elem0 = new vipapis.marketplace.delivery.Carrier();
							vipapis.marketplace.delivery.CarrierHelper.getInstance().Read(elem0, iprot);
							
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
			
			
			public void Write(getCarriers_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					oprot.WriteListBegin();
					foreach(vipapis.marketplace.delivery.Carrier _item0 in structs.GetSuccess()){
						
						
						vipapis.marketplace.delivery.CarrierHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getCarriers_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getOrderDetail_resultHelper : TBeanSerializer<getOrderDetail_result>
		{
			
			public static getOrderDetail_resultHelper OBJ = new getOrderDetail_resultHelper();
			
			public static getOrderDetail_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getOrderDetail_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					List<vipapis.marketplace.delivery.OrderDetail> value;
					
					value = new List<vipapis.marketplace.delivery.OrderDetail>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							vipapis.marketplace.delivery.OrderDetail elem1;
							
							elem1 = new vipapis.marketplace.delivery.OrderDetail();
							vipapis.marketplace.delivery.OrderDetailHelper.getInstance().Read(elem1, iprot);
							
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
			
			
			public void Write(getOrderDetail_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					oprot.WriteListBegin();
					foreach(vipapis.marketplace.delivery.OrderDetail _item0 in structs.GetSuccess()){
						
						
						vipapis.marketplace.delivery.OrderDetailHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getOrderDetail_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getOrderStatusById_resultHelper : TBeanSerializer<getOrderStatusById_result>
		{
			
			public static getOrderStatusById_resultHelper OBJ = new getOrderStatusById_resultHelper();
			
			public static getOrderStatusById_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getOrderStatusById_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.marketplace.delivery.GetOrderStatusByIdResponse value;
					
					value = new vipapis.marketplace.delivery.GetOrderStatusByIdResponse();
					vipapis.marketplace.delivery.GetOrderStatusByIdResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getOrderStatusById_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.marketplace.delivery.GetOrderStatusByIdResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getOrderStatusById_result bean){
				
				
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
					
					vipapis.marketplace.delivery.GetOrdersResponse value;
					
					value = new vipapis.marketplace.delivery.GetOrdersResponse();
					vipapis.marketplace.delivery.GetOrdersResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getOrders_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.marketplace.delivery.GetOrdersResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getOrders_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getPrintTemplate_resultHelper : TBeanSerializer<getPrintTemplate_result>
		{
			
			public static getPrintTemplate_resultHelper OBJ = new getPrintTemplate_resultHelper();
			
			public static getPrintTemplate_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getPrintTemplate_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.marketplace.delivery.GetPrintTemplateResponse value;
					
					value = new vipapis.marketplace.delivery.GetPrintTemplateResponse();
					vipapis.marketplace.delivery.GetPrintTemplateResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getPrintTemplate_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.marketplace.delivery.GetPrintTemplateResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getPrintTemplate_result bean){
				
				
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
		
		
		
		
		public class ship_resultHelper : TBeanSerializer<ship_result>
		{
			
			public static ship_resultHelper OBJ = new ship_resultHelper();
			
			public static ship_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(ship_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.marketplace.delivery.ShipResponse value;
					
					value = new vipapis.marketplace.delivery.ShipResponse();
					vipapis.marketplace.delivery.ShipResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(ship_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.marketplace.delivery.ShipResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(ship_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class SovDeliveryServiceClient : OspRestStub , SovDeliveryService  {
			
			
			public SovDeliveryServiceClient():base("vipapis.marketplace.delivery.SovDeliveryService","1.0.0") {
				
				
			}
			
			
			
			public vipapis.marketplace.delivery.EditedShipInfoResponse editShipInfo(vipapis.marketplace.delivery.EditedShipInfo edited_ship_info_) {
				
				send_editShipInfo(edited_ship_info_);
				return recv_editShipInfo(); 
				
			}
			
			
			private void send_editShipInfo(vipapis.marketplace.delivery.EditedShipInfo edited_ship_info_){
				
				InitInvocation("editShipInfo");
				
				editShipInfo_args args = new editShipInfo_args();
				args.SetEdited_ship_info(edited_ship_info_);
				
				SendBase(args, editShipInfo_argsHelper.getInstance());
			}
			
			
			private vipapis.marketplace.delivery.EditedShipInfoResponse recv_editShipInfo(){
				
				editShipInfo_result result = new editShipInfo_result();
				ReceiveBase(result, editShipInfo_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public vipapis.marketplace.delivery.ExportOrderByIdResponse exportOrderById(vipapis.marketplace.delivery.ExportOrderByIdRequest request_) {
				
				send_exportOrderById(request_);
				return recv_exportOrderById(); 
				
			}
			
			
			private void send_exportOrderById(vipapis.marketplace.delivery.ExportOrderByIdRequest request_){
				
				InitInvocation("exportOrderById");
				
				exportOrderById_args args = new exportOrderById_args();
				args.SetRequest(request_);
				
				SendBase(args, exportOrderById_argsHelper.getInstance());
			}
			
			
			private vipapis.marketplace.delivery.ExportOrderByIdResponse recv_exportOrderById(){
				
				exportOrderById_result result = new exportOrderById_result();
				ReceiveBase(result, exportOrderById_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public List<vipapis.marketplace.delivery.Carrier> getCarriers() {
				
				send_getCarriers();
				return recv_getCarriers(); 
				
			}
			
			
			private void send_getCarriers(){
				
				InitInvocation("getCarriers");
				
				getCarriers_args args = new getCarriers_args();
				
				SendBase(args, getCarriers_argsHelper.getInstance());
			}
			
			
			private List<vipapis.marketplace.delivery.Carrier> recv_getCarriers(){
				
				getCarriers_result result = new getCarriers_result();
				ReceiveBase(result, getCarriers_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public List<vipapis.marketplace.delivery.OrderDetail> getOrderDetail(List<string> order_ids_) {
				
				send_getOrderDetail(order_ids_);
				return recv_getOrderDetail(); 
				
			}
			
			
			private void send_getOrderDetail(List<string> order_ids_){
				
				InitInvocation("getOrderDetail");
				
				getOrderDetail_args args = new getOrderDetail_args();
				args.SetOrder_ids(order_ids_);
				
				SendBase(args, getOrderDetail_argsHelper.getInstance());
			}
			
			
			private List<vipapis.marketplace.delivery.OrderDetail> recv_getOrderDetail(){
				
				getOrderDetail_result result = new getOrderDetail_result();
				ReceiveBase(result, getOrderDetail_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public vipapis.marketplace.delivery.GetOrderStatusByIdResponse getOrderStatusById(vipapis.marketplace.delivery.GetOrderStatusByIdRequest request_) {
				
				send_getOrderStatusById(request_);
				return recv_getOrderStatusById(); 
				
			}
			
			
			private void send_getOrderStatusById(vipapis.marketplace.delivery.GetOrderStatusByIdRequest request_){
				
				InitInvocation("getOrderStatusById");
				
				getOrderStatusById_args args = new getOrderStatusById_args();
				args.SetRequest(request_);
				
				SendBase(args, getOrderStatusById_argsHelper.getInstance());
			}
			
			
			private vipapis.marketplace.delivery.GetOrderStatusByIdResponse recv_getOrderStatusById(){
				
				getOrderStatusById_result result = new getOrderStatusById_result();
				ReceiveBase(result, getOrderStatusById_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public vipapis.marketplace.delivery.GetOrdersResponse getOrders(vipapis.marketplace.delivery.GetOrdersRequest request_) {
				
				send_getOrders(request_);
				return recv_getOrders(); 
				
			}
			
			
			private void send_getOrders(vipapis.marketplace.delivery.GetOrdersRequest request_){
				
				InitInvocation("getOrders");
				
				getOrders_args args = new getOrders_args();
				args.SetRequest(request_);
				
				SendBase(args, getOrders_argsHelper.getInstance());
			}
			
			
			private vipapis.marketplace.delivery.GetOrdersResponse recv_getOrders(){
				
				getOrders_result result = new getOrders_result();
				ReceiveBase(result, getOrders_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public vipapis.marketplace.delivery.GetPrintTemplateResponse getPrintTemplate(string order_id_) {
				
				send_getPrintTemplate(order_id_);
				return recv_getPrintTemplate(); 
				
			}
			
			
			private void send_getPrintTemplate(string order_id_){
				
				InitInvocation("getPrintTemplate");
				
				getPrintTemplate_args args = new getPrintTemplate_args();
				args.SetOrder_id(order_id_);
				
				SendBase(args, getPrintTemplate_argsHelper.getInstance());
			}
			
			
			private vipapis.marketplace.delivery.GetPrintTemplateResponse recv_getPrintTemplate(){
				
				getPrintTemplate_result result = new getPrintTemplate_result();
				ReceiveBase(result, getPrintTemplate_resultHelper.getInstance());
				
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
			
			
			public vipapis.marketplace.delivery.ShipResponse ship(vipapis.marketplace.delivery.ShipRequest request_) {
				
				send_ship(request_);
				return recv_ship(); 
				
			}
			
			
			private void send_ship(vipapis.marketplace.delivery.ShipRequest request_){
				
				InitInvocation("ship");
				
				ship_args args = new ship_args();
				args.SetRequest(request_);
				
				SendBase(args, ship_argsHelper.getInstance());
			}
			
			
			private vipapis.marketplace.delivery.ShipResponse recv_ship(){
				
				ship_result result = new ship_result();
				ReceiveBase(result, ship_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
		}
		
		
	}
	
}