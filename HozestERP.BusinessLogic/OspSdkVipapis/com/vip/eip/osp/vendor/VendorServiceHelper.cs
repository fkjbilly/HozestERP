using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;

namespace com.vip.eip.osp.vendor{
	
	
	public class VendorServiceHelper {
		
		
		
		public class healthCheck_args {
			
			
		}
		
		
		
		
		public class invoke_args {
			
			///<summary>
			///</summary>
			
			private com.vip.eip.osp.vendor.VendorSysRequest req_;
			
			public com.vip.eip.osp.vendor.VendorSysRequest GetReq(){
				return this.req_;
			}
			
			public void SetReq(com.vip.eip.osp.vendor.VendorSysRequest value){
				this.req_ = value;
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
		
		
		
		
		public class invoke_result {
			
			///<summary>
			///</summary>
			
			private com.vip.eip.osp.vendor.VendorSysResponse success_;
			
			public com.vip.eip.osp.vendor.VendorSysResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.eip.osp.vendor.VendorSysResponse value){
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
		
		
		
		
		public class invoke_argsHelper : TBeanSerializer<invoke_args>
		{
			
			public static invoke_argsHelper OBJ = new invoke_argsHelper();
			
			public static invoke_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(invoke_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.eip.osp.vendor.VendorSysRequest value;
					
					value = new com.vip.eip.osp.vendor.VendorSysRequest();
					com.vip.eip.osp.vendor.VendorSysRequestHelper.getInstance().Read(value, iprot);
					
					structs.SetReq(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(invoke_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetReq() != null) {
					
					oprot.WriteFieldBegin("req");
					
					com.vip.eip.osp.vendor.VendorSysRequestHelper.getInstance().Write(structs.GetReq(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("req can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(invoke_args bean){
				
				
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
		
		
		
		
		public class invoke_resultHelper : TBeanSerializer<invoke_result>
		{
			
			public static invoke_resultHelper OBJ = new invoke_resultHelper();
			
			public static invoke_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(invoke_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.eip.osp.vendor.VendorSysResponse value;
					
					value = new com.vip.eip.osp.vendor.VendorSysResponse();
					com.vip.eip.osp.vendor.VendorSysResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(invoke_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.eip.osp.vendor.VendorSysResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(invoke_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class VendorServiceClient : OspRestStub , VendorService  {
			
			
			public VendorServiceClient():base("com.vip.eip.osp.vendor.VendorService","1.0.0") {
				
				
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
			
			
			public com.vip.eip.osp.vendor.VendorSysResponse invoke(com.vip.eip.osp.vendor.VendorSysRequest req_) {
				
				send_invoke(req_);
				return recv_invoke(); 
				
			}
			
			
			private void send_invoke(com.vip.eip.osp.vendor.VendorSysRequest req_){
				
				InitInvocation("invoke");
				
				invoke_args args = new invoke_args();
				args.SetReq(req_);
				
				SendBase(args, invoke_argsHelper.getInstance());
			}
			
			
			private com.vip.eip.osp.vendor.VendorSysResponse recv_invoke(){
				
				invoke_result result = new invoke_result();
				ReceiveBase(result, invoke_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
		}
		
		
	}
	
}