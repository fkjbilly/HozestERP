using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;

namespace vipapis.marketplace.inventory{
	
	
	public class InventoryServiceHelper {
		
		
		
		public class getSkuStock_args {
			
			///<summary>
			/// 商品库存查询请求参数
			///</summary>
			
			private vipapis.marketplace.inventory.GetSkuStockRequest getSkuStockRequest_;
			
			public vipapis.marketplace.inventory.GetSkuStockRequest GetGetSkuStockRequest(){
				return this.getSkuStockRequest_;
			}
			
			public void SetGetSkuStockRequest(vipapis.marketplace.inventory.GetSkuStockRequest value){
				this.getSkuStockRequest_ = value;
			}
			
		}
		
		
		
		
		public class healthCheck_args {
			
			
		}
		
		
		
		
		public class updateSkuStock_args {
			
			///<summary>
			/// 更新sku库存请求参数
			///</summary>
			
			private vipapis.marketplace.inventory.UpdateSkuStockRequest updateSkuStockRequest_;
			
			public vipapis.marketplace.inventory.UpdateSkuStockRequest GetUpdateSkuStockRequest(){
				return this.updateSkuStockRequest_;
			}
			
			public void SetUpdateSkuStockRequest(vipapis.marketplace.inventory.UpdateSkuStockRequest value){
				this.updateSkuStockRequest_ = value;
			}
			
		}
		
		
		
		
		public class getSkuStock_result {
			
			///<summary>
			///</summary>
			
			private vipapis.marketplace.inventory.GetSkuStockResponse success_;
			
			public vipapis.marketplace.inventory.GetSkuStockResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.marketplace.inventory.GetSkuStockResponse value){
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
		
		
		
		
		public class updateSkuStock_result {
			
			///<summary>
			///</summary>
			
			private vipapis.marketplace.inventory.UpdateSkuStockResponse success_;
			
			public vipapis.marketplace.inventory.UpdateSkuStockResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.marketplace.inventory.UpdateSkuStockResponse value){
				this.success_ = value;
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
					
					vipapis.marketplace.inventory.GetSkuStockRequest value;
					
					value = new vipapis.marketplace.inventory.GetSkuStockRequest();
					vipapis.marketplace.inventory.GetSkuStockRequestHelper.getInstance().Read(value, iprot);
					
					structs.SetGetSkuStockRequest(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getSkuStock_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetGetSkuStockRequest() != null) {
					
					oprot.WriteFieldBegin("getSkuStockRequest");
					
					vipapis.marketplace.inventory.GetSkuStockRequestHelper.getInstance().Write(structs.GetGetSkuStockRequest(), oprot);
					
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
		
		
		
		
		public class updateSkuStock_argsHelper : TBeanSerializer<updateSkuStock_args>
		{
			
			public static updateSkuStock_argsHelper OBJ = new updateSkuStock_argsHelper();
			
			public static updateSkuStock_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(updateSkuStock_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.marketplace.inventory.UpdateSkuStockRequest value;
					
					value = new vipapis.marketplace.inventory.UpdateSkuStockRequest();
					vipapis.marketplace.inventory.UpdateSkuStockRequestHelper.getInstance().Read(value, iprot);
					
					structs.SetUpdateSkuStockRequest(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(updateSkuStock_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetUpdateSkuStockRequest() != null) {
					
					oprot.WriteFieldBegin("updateSkuStockRequest");
					
					vipapis.marketplace.inventory.UpdateSkuStockRequestHelper.getInstance().Write(structs.GetUpdateSkuStockRequest(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(updateSkuStock_args bean){
				
				
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
					
					vipapis.marketplace.inventory.GetSkuStockResponse value;
					
					value = new vipapis.marketplace.inventory.GetSkuStockResponse();
					vipapis.marketplace.inventory.GetSkuStockResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getSkuStock_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.marketplace.inventory.GetSkuStockResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
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
		
		
		
		
		public class updateSkuStock_resultHelper : TBeanSerializer<updateSkuStock_result>
		{
			
			public static updateSkuStock_resultHelper OBJ = new updateSkuStock_resultHelper();
			
			public static updateSkuStock_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(updateSkuStock_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.marketplace.inventory.UpdateSkuStockResponse value;
					
					value = new vipapis.marketplace.inventory.UpdateSkuStockResponse();
					vipapis.marketplace.inventory.UpdateSkuStockResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(updateSkuStock_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.marketplace.inventory.UpdateSkuStockResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(updateSkuStock_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class InventoryServiceClient : OspRestStub , InventoryService  {
			
			
			public InventoryServiceClient():base("vipapis.marketplace.inventory.InventoryService","1.0.0") {
				
				
			}
			
			
			
			public vipapis.marketplace.inventory.GetSkuStockResponse getSkuStock(vipapis.marketplace.inventory.GetSkuStockRequest getSkuStockRequest_) {
				
				send_getSkuStock(getSkuStockRequest_);
				return recv_getSkuStock(); 
				
			}
			
			
			private void send_getSkuStock(vipapis.marketplace.inventory.GetSkuStockRequest getSkuStockRequest_){
				
				InitInvocation("getSkuStock");
				
				getSkuStock_args args = new getSkuStock_args();
				args.SetGetSkuStockRequest(getSkuStockRequest_);
				
				SendBase(args, getSkuStock_argsHelper.getInstance());
			}
			
			
			private vipapis.marketplace.inventory.GetSkuStockResponse recv_getSkuStock(){
				
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
			
			
			public vipapis.marketplace.inventory.UpdateSkuStockResponse updateSkuStock(vipapis.marketplace.inventory.UpdateSkuStockRequest updateSkuStockRequest_) {
				
				send_updateSkuStock(updateSkuStockRequest_);
				return recv_updateSkuStock(); 
				
			}
			
			
			private void send_updateSkuStock(vipapis.marketplace.inventory.UpdateSkuStockRequest updateSkuStockRequest_){
				
				InitInvocation("updateSkuStock");
				
				updateSkuStock_args args = new updateSkuStock_args();
				args.SetUpdateSkuStockRequest(updateSkuStockRequest_);
				
				SendBase(args, updateSkuStock_argsHelper.getInstance());
			}
			
			
			private vipapis.marketplace.inventory.UpdateSkuStockResponse recv_updateSkuStock(){
				
				updateSkuStock_result result = new updateSkuStock_result();
				ReceiveBase(result, updateSkuStock_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
		}
		
		
	}
	
}