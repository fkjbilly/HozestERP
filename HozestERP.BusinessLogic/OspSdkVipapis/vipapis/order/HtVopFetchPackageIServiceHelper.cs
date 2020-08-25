using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;

namespace vipapis.order{
	
	
	public class HtVopFetchPackageIServiceHelper {
		
		
		
		public class getFetchPackageOrderList_args {
			
			///<summary>
			/// 请求参数
			///</summary>
			
			private com.vip.haitao.orderservice.service.HtVopFetchPackageParam htVopFetchPackageParam_;
			
			public com.vip.haitao.orderservice.service.HtVopFetchPackageParam GetHtVopFetchPackageParam(){
				return this.htVopFetchPackageParam_;
			}
			
			public void SetHtVopFetchPackageParam(com.vip.haitao.orderservice.service.HtVopFetchPackageParam value){
				this.htVopFetchPackageParam_ = value;
			}
			
		}
		
		
		
		
		public class healthCheck_args {
			
			
		}
		
		
		
		
		public class getFetchPackageOrderList_result {
			
			///<summary>
			///</summary>
			
			private com.vip.haitao.orderservice.service.HtVopFetchPackageResult success_;
			
			public com.vip.haitao.orderservice.service.HtVopFetchPackageResult GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.haitao.orderservice.service.HtVopFetchPackageResult value){
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
		
		
		
		
		
		public class getFetchPackageOrderList_argsHelper : TBeanSerializer<getFetchPackageOrderList_args>
		{
			
			public static getFetchPackageOrderList_argsHelper OBJ = new getFetchPackageOrderList_argsHelper();
			
			public static getFetchPackageOrderList_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getFetchPackageOrderList_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.haitao.orderservice.service.HtVopFetchPackageParam value;
					
					value = new com.vip.haitao.orderservice.service.HtVopFetchPackageParam();
					com.vip.haitao.orderservice.service.HtVopFetchPackageParamHelper.getInstance().Read(value, iprot);
					
					structs.SetHtVopFetchPackageParam(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getFetchPackageOrderList_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetHtVopFetchPackageParam() != null) {
					
					oprot.WriteFieldBegin("htVopFetchPackageParam");
					
					com.vip.haitao.orderservice.service.HtVopFetchPackageParamHelper.getInstance().Write(structs.GetHtVopFetchPackageParam(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getFetchPackageOrderList_args bean){
				
				
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
		
		
		
		
		public class getFetchPackageOrderList_resultHelper : TBeanSerializer<getFetchPackageOrderList_result>
		{
			
			public static getFetchPackageOrderList_resultHelper OBJ = new getFetchPackageOrderList_resultHelper();
			
			public static getFetchPackageOrderList_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getFetchPackageOrderList_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.haitao.orderservice.service.HtVopFetchPackageResult value;
					
					value = new com.vip.haitao.orderservice.service.HtVopFetchPackageResult();
					com.vip.haitao.orderservice.service.HtVopFetchPackageResultHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getFetchPackageOrderList_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.haitao.orderservice.service.HtVopFetchPackageResultHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getFetchPackageOrderList_result bean){
				
				
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
		
		
		
		
		public class HtVopFetchPackageIServiceClient : OspRestStub , HtVopFetchPackageIService  {
			
			
			public HtVopFetchPackageIServiceClient():base("vipapis.order.HtVopFetchPackageIService","1.0.0") {
				
				
			}
			
			
			
			public com.vip.haitao.orderservice.service.HtVopFetchPackageResult getFetchPackageOrderList(com.vip.haitao.orderservice.service.HtVopFetchPackageParam htVopFetchPackageParam_) {
				
				send_getFetchPackageOrderList(htVopFetchPackageParam_);
				return recv_getFetchPackageOrderList(); 
				
			}
			
			
			private void send_getFetchPackageOrderList(com.vip.haitao.orderservice.service.HtVopFetchPackageParam htVopFetchPackageParam_){
				
				InitInvocation("getFetchPackageOrderList");
				
				getFetchPackageOrderList_args args = new getFetchPackageOrderList_args();
				args.SetHtVopFetchPackageParam(htVopFetchPackageParam_);
				
				SendBase(args, getFetchPackageOrderList_argsHelper.getInstance());
			}
			
			
			private com.vip.haitao.orderservice.service.HtVopFetchPackageResult recv_getFetchPackageOrderList(){
				
				getFetchPackageOrderList_result result = new getFetchPackageOrderList_result();
				ReceiveBase(result, getFetchPackageOrderList_resultHelper.getInstance());
				
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