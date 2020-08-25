using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;

namespace vipapis.puma{
	
	
	public class ChannelPumaServiceHelper {
		
		
		
		public class getPumaProducts_args {
			
			///<summary>
			/// 商品请求信息
			///</summary>
			
			private vipapis.puma.ProductQueryRequest request_;
			
			public vipapis.puma.ProductQueryRequest GetRequest(){
				return this.request_;
			}
			
			public void SetRequest(vipapis.puma.ProductQueryRequest value){
				this.request_ = value;
			}
			
		}
		
		
		
		
		public class healthCheck_args {
			
			
		}
		
		
		
		
		public class getPumaProducts_result {
			
			///<summary>
			/// 返回商品信息
			///</summary>
			
			private vipapis.puma.ProductQueryResponse success_;
			
			public vipapis.puma.ProductQueryResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.puma.ProductQueryResponse value){
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
		
		
		
		
		
		public class getPumaProducts_argsHelper : TBeanSerializer<getPumaProducts_args>
		{
			
			public static getPumaProducts_argsHelper OBJ = new getPumaProducts_argsHelper();
			
			public static getPumaProducts_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getPumaProducts_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.puma.ProductQueryRequest value;
					
					value = new vipapis.puma.ProductQueryRequest();
					vipapis.puma.ProductQueryRequestHelper.getInstance().Read(value, iprot);
					
					structs.SetRequest(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getPumaProducts_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequest() != null) {
					
					oprot.WriteFieldBegin("request");
					
					vipapis.puma.ProductQueryRequestHelper.getInstance().Write(structs.GetRequest(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("request can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getPumaProducts_args bean){
				
				
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
		
		
		
		
		public class getPumaProducts_resultHelper : TBeanSerializer<getPumaProducts_result>
		{
			
			public static getPumaProducts_resultHelper OBJ = new getPumaProducts_resultHelper();
			
			public static getPumaProducts_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getPumaProducts_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.puma.ProductQueryResponse value;
					
					value = new vipapis.puma.ProductQueryResponse();
					vipapis.puma.ProductQueryResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getPumaProducts_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.puma.ProductQueryResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getPumaProducts_result bean){
				
				
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
		
		
		
		
		public class ChannelPumaServiceClient : OspRestStub , ChannelPumaService  {
			
			
			public ChannelPumaServiceClient():base("vipapis.puma.ChannelPumaService","1.0.0") {
				
				
			}
			
			
			
			public vipapis.puma.ProductQueryResponse getPumaProducts(vipapis.puma.ProductQueryRequest request_) {
				
				send_getPumaProducts(request_);
				return recv_getPumaProducts(); 
				
			}
			
			
			private void send_getPumaProducts(vipapis.puma.ProductQueryRequest request_){
				
				InitInvocation("getPumaProducts");
				
				getPumaProducts_args args = new getPumaProducts_args();
				args.SetRequest(request_);
				
				SendBase(args, getPumaProducts_argsHelper.getInstance());
			}
			
			
			private vipapis.puma.ProductQueryResponse recv_getPumaProducts(){
				
				getPumaProducts_result result = new getPumaProducts_result();
				ReceiveBase(result, getPumaProducts_resultHelper.getInstance());
				
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