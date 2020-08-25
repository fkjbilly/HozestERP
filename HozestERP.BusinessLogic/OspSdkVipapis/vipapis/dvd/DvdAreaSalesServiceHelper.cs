using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;

namespace vipapis.dvd{
	
	
	public class DvdAreaSalesServiceHelper {
		
		
		
		public class getAreaOccupiedOrders_args {
			
			///<summary>
			/// 实时订单请求
			///</summary>
			
			private vipapis.dvd.AreaOccupiedOrdersRequest request_;
			
			public vipapis.dvd.AreaOccupiedOrdersRequest GetRequest(){
				return this.request_;
			}
			
			public void SetRequest(vipapis.dvd.AreaOccupiedOrdersRequest value){
				this.request_ = value;
			}
			
		}
		
		
		
		
		public class getAreaWarehouse_args {
			
			///<summary>
			/// 供应商ID
			///</summary>
			
			private long? vendor_id_;
			
			public long? GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(long? value){
				this.vendor_id_ = value;
			}
			
		}
		
		
		
		
		public class healthCheck_args {
			
			
		}
		
		
		
		
		public class getAreaOccupiedOrders_result {
			
			///<summary>
			///</summary>
			
			private vipapis.dvd.AreaOccupiedOrderResponse success_;
			
			public vipapis.dvd.AreaOccupiedOrderResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.dvd.AreaOccupiedOrderResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getAreaWarehouse_result {
			
			///<summary>
			///</summary>
			
			private List<vipapis.dvd.AreaWarehouse> success_;
			
			public List<vipapis.dvd.AreaWarehouse> GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(List<vipapis.dvd.AreaWarehouse> value){
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
		
		
		
		
		
		public class getAreaOccupiedOrders_argsHelper : TBeanSerializer<getAreaOccupiedOrders_args>
		{
			
			public static getAreaOccupiedOrders_argsHelper OBJ = new getAreaOccupiedOrders_argsHelper();
			
			public static getAreaOccupiedOrders_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getAreaOccupiedOrders_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.dvd.AreaOccupiedOrdersRequest value;
					
					value = new vipapis.dvd.AreaOccupiedOrdersRequest();
					vipapis.dvd.AreaOccupiedOrdersRequestHelper.getInstance().Read(value, iprot);
					
					structs.SetRequest(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getAreaOccupiedOrders_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequest() != null) {
					
					oprot.WriteFieldBegin("request");
					
					vipapis.dvd.AreaOccupiedOrdersRequestHelper.getInstance().Write(structs.GetRequest(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getAreaOccupiedOrders_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getAreaWarehouse_argsHelper : TBeanSerializer<getAreaWarehouse_args>
		{
			
			public static getAreaWarehouse_argsHelper OBJ = new getAreaWarehouse_argsHelper();
			
			public static getAreaWarehouse_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getAreaWarehouse_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					long value;
					value = iprot.ReadI64(); 
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getAreaWarehouse_args structs, Protocol oprot){
				
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
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getAreaWarehouse_args bean){
				
				
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
		
		
		
		
		public class getAreaOccupiedOrders_resultHelper : TBeanSerializer<getAreaOccupiedOrders_result>
		{
			
			public static getAreaOccupiedOrders_resultHelper OBJ = new getAreaOccupiedOrders_resultHelper();
			
			public static getAreaOccupiedOrders_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getAreaOccupiedOrders_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.dvd.AreaOccupiedOrderResponse value;
					
					value = new vipapis.dvd.AreaOccupiedOrderResponse();
					vipapis.dvd.AreaOccupiedOrderResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getAreaOccupiedOrders_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.dvd.AreaOccupiedOrderResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getAreaOccupiedOrders_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getAreaWarehouse_resultHelper : TBeanSerializer<getAreaWarehouse_result>
		{
			
			public static getAreaWarehouse_resultHelper OBJ = new getAreaWarehouse_resultHelper();
			
			public static getAreaWarehouse_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getAreaWarehouse_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					List<vipapis.dvd.AreaWarehouse> value;
					
					value = new List<vipapis.dvd.AreaWarehouse>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							vipapis.dvd.AreaWarehouse elem0;
							
							elem0 = new vipapis.dvd.AreaWarehouse();
							vipapis.dvd.AreaWarehouseHelper.getInstance().Read(elem0, iprot);
							
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
			
			
			public void Write(getAreaWarehouse_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					oprot.WriteListBegin();
					foreach(vipapis.dvd.AreaWarehouse _item0 in structs.GetSuccess()){
						
						
						vipapis.dvd.AreaWarehouseHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getAreaWarehouse_result bean){
				
				
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
		
		
		
		
		public class DvdAreaSalesServiceClient : OspRestStub , DvdAreaSalesService  {
			
			
			public DvdAreaSalesServiceClient():base("vipapis.dvd.DvdAreaSalesService","1.0.0") {
				
				
			}
			
			
			
			public vipapis.dvd.AreaOccupiedOrderResponse getAreaOccupiedOrders(vipapis.dvd.AreaOccupiedOrdersRequest request_) {
				
				send_getAreaOccupiedOrders(request_);
				return recv_getAreaOccupiedOrders(); 
				
			}
			
			
			private void send_getAreaOccupiedOrders(vipapis.dvd.AreaOccupiedOrdersRequest request_){
				
				InitInvocation("getAreaOccupiedOrders");
				
				getAreaOccupiedOrders_args args = new getAreaOccupiedOrders_args();
				args.SetRequest(request_);
				
				SendBase(args, getAreaOccupiedOrders_argsHelper.getInstance());
			}
			
			
			private vipapis.dvd.AreaOccupiedOrderResponse recv_getAreaOccupiedOrders(){
				
				getAreaOccupiedOrders_result result = new getAreaOccupiedOrders_result();
				ReceiveBase(result, getAreaOccupiedOrders_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public List<vipapis.dvd.AreaWarehouse> getAreaWarehouse(long vendor_id_) {
				
				send_getAreaWarehouse(vendor_id_);
				return recv_getAreaWarehouse(); 
				
			}
			
			
			private void send_getAreaWarehouse(long vendor_id_){
				
				InitInvocation("getAreaWarehouse");
				
				getAreaWarehouse_args args = new getAreaWarehouse_args();
				args.SetVendor_id(vendor_id_);
				
				SendBase(args, getAreaWarehouse_argsHelper.getInstance());
			}
			
			
			private List<vipapis.dvd.AreaWarehouse> recv_getAreaWarehouse(){
				
				getAreaWarehouse_result result = new getAreaWarehouse_result();
				ReceiveBase(result, getAreaWarehouse_resultHelper.getInstance());
				
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