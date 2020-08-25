using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;

namespace vipapis.inventory{
	
	
	public class VrwInvIncomeOspServiceHelper {
		
		
		
		public class healthCheck_args {
			
			
		}
		
		
		
		
		public class syncVrwIncrInv_args {
			
			///<summary>
			///</summary>
			
			private com.vipshop.cis.sdk.api.datain.si.request.SyncVrwIncrInvRequest request_;
			
			public com.vipshop.cis.sdk.api.datain.si.request.SyncVrwIncrInvRequest GetRequest(){
				return this.request_;
			}
			
			public void SetRequest(com.vipshop.cis.sdk.api.datain.si.request.SyncVrwIncrInvRequest value){
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
		
		
		
		
		public class syncVrwIncrInv_result {
			
			///<summary>
			///</summary>
			
			private com.vipshop.cis.sdk.api.datain.si.response.SyncVrwIncrInvResponse success_;
			
			public com.vipshop.cis.sdk.api.datain.si.response.SyncVrwIncrInvResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vipshop.cis.sdk.api.datain.si.response.SyncVrwIncrInvResponse value){
				this.success_ = value;
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
		
		
		
		
		public class syncVrwIncrInv_argsHelper : TBeanSerializer<syncVrwIncrInv_args>
		{
			
			public static syncVrwIncrInv_argsHelper OBJ = new syncVrwIncrInv_argsHelper();
			
			public static syncVrwIncrInv_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(syncVrwIncrInv_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vipshop.cis.sdk.api.datain.si.request.SyncVrwIncrInvRequest value;
					
					value = new com.vipshop.cis.sdk.api.datain.si.request.SyncVrwIncrInvRequest();
					com.vipshop.cis.sdk.api.datain.si.request.SyncVrwIncrInvRequestHelper.getInstance().Read(value, iprot);
					
					structs.SetRequest(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(syncVrwIncrInv_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequest() != null) {
					
					oprot.WriteFieldBegin("request");
					
					com.vipshop.cis.sdk.api.datain.si.request.SyncVrwIncrInvRequestHelper.getInstance().Write(structs.GetRequest(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("request can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(syncVrwIncrInv_args bean){
				
				
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
		
		
		
		
		public class syncVrwIncrInv_resultHelper : TBeanSerializer<syncVrwIncrInv_result>
		{
			
			public static syncVrwIncrInv_resultHelper OBJ = new syncVrwIncrInv_resultHelper();
			
			public static syncVrwIncrInv_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(syncVrwIncrInv_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vipshop.cis.sdk.api.datain.si.response.SyncVrwIncrInvResponse value;
					
					value = new com.vipshop.cis.sdk.api.datain.si.response.SyncVrwIncrInvResponse();
					com.vipshop.cis.sdk.api.datain.si.response.SyncVrwIncrInvResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(syncVrwIncrInv_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vipshop.cis.sdk.api.datain.si.response.SyncVrwIncrInvResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(syncVrwIncrInv_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class VrwInvIncomeOspServiceClient : OspRestStub , VrwInvIncomeOspService  {
			
			
			public VrwInvIncomeOspServiceClient():base("vipapis.inventory.VrwInvIncomeOspService","1.0.1") {
				
				
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
			
			
			public com.vipshop.cis.sdk.api.datain.si.response.SyncVrwIncrInvResponse syncVrwIncrInv(com.vipshop.cis.sdk.api.datain.si.request.SyncVrwIncrInvRequest request_) {
				
				send_syncVrwIncrInv(request_);
				return recv_syncVrwIncrInv(); 
				
			}
			
			
			private void send_syncVrwIncrInv(com.vipshop.cis.sdk.api.datain.si.request.SyncVrwIncrInvRequest request_){
				
				InitInvocation("syncVrwIncrInv");
				
				syncVrwIncrInv_args args = new syncVrwIncrInv_args();
				args.SetRequest(request_);
				
				SendBase(args, syncVrwIncrInv_argsHelper.getInstance());
			}
			
			
			private com.vipshop.cis.sdk.api.datain.si.response.SyncVrwIncrInvResponse recv_syncVrwIncrInv(){
				
				syncVrwIncrInv_result result = new syncVrwIncrInv_result();
				ReceiveBase(result, syncVrwIncrInv_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
		}
		
		
	}
	
}