using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;

namespace vip.vop.omni.inventory{
	
	
	public class OmniInventoryServiceHelper {
		
		
		
		public class healthCheck_args {
			
			
		}
		
		
		
		
		public class updateStoreInventory_args {
			
			///<summary>
			/// 库存更新请求
			///</summary>
			
			private com.vip.vop.omni.inventory.InventoryUpdateRequest request_;
			
			public com.vip.vop.omni.inventory.InventoryUpdateRequest GetRequest(){
				return this.request_;
			}
			
			public void SetRequest(com.vip.vop.omni.inventory.InventoryUpdateRequest value){
				this.request_ = value;
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
		
		
		
		
		public class updateStoreInventory_result {
			
			
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
		
		
		
		
		public class updateStoreInventory_argsHelper : TBeanSerializer<updateStoreInventory_args>
		{
			
			public static updateStoreInventory_argsHelper OBJ = new updateStoreInventory_argsHelper();
			
			public static updateStoreInventory_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(updateStoreInventory_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.vop.omni.inventory.InventoryUpdateRequest value;
					
					value = new com.vip.vop.omni.inventory.InventoryUpdateRequest();
					com.vip.vop.omni.inventory.InventoryUpdateRequestHelper.getInstance().Read(value, iprot);
					
					structs.SetRequest(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(updateStoreInventory_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequest() != null) {
					
					oprot.WriteFieldBegin("request");
					
					com.vip.vop.omni.inventory.InventoryUpdateRequestHelper.getInstance().Write(structs.GetRequest(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("request can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(updateStoreInventory_args bean){
				
				
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
		
		
		
		
		public class updateStoreInventory_resultHelper : TBeanSerializer<updateStoreInventory_result>
		{
			
			public static updateStoreInventory_resultHelper OBJ = new updateStoreInventory_resultHelper();
			
			public static updateStoreInventory_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(updateStoreInventory_result structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(updateStoreInventory_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(updateStoreInventory_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class OmniInventoryServiceClient : OspRestStub , OmniInventoryService  {
			
			
			public OmniInventoryServiceClient():base("vip.vop.omni.inventory.OmniInventoryService","1.0.0") {
				
				
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
			
			
			public void updateStoreInventory(com.vip.vop.omni.inventory.InventoryUpdateRequest request_) {
				
				send_updateStoreInventory(request_);
				recv_updateStoreInventory();
				
			}
			
			
			private void send_updateStoreInventory(com.vip.vop.omni.inventory.InventoryUpdateRequest request_){
				
				InitInvocation("updateStoreInventory");
				
				updateStoreInventory_args args = new updateStoreInventory_args();
				args.SetRequest(request_);
				
				SendBase(args, updateStoreInventory_argsHelper.getInstance());
			}
			
			
			private void recv_updateStoreInventory(){
				
				updateStoreInventory_result result = new updateStoreInventory_result();
				ReceiveBase(result, updateStoreInventory_resultHelper.getInstance());
				
				
			}
			
			
		}
		
		
	}
	
}