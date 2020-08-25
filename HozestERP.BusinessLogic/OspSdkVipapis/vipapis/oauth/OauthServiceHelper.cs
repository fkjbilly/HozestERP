using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;

namespace vipapis.oauth{
	
	
	public class OauthServiceHelper {
		
		
		
		public class healthCheck_args {
			
			
		}
		
		
		
		
		public class refreshToken_args {
			
			///<summary>
			/// 刷新令牌请求结构体
			///</summary>
			
			private vipapis.oauth.RefreshTokenRequest request_;
			
			public vipapis.oauth.RefreshTokenRequest GetRequest(){
				return this.request_;
			}
			
			public void SetRequest(vipapis.oauth.RefreshTokenRequest value){
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
		
		
		
		
		public class refreshToken_result {
			
			///<summary>
			///</summary>
			
			private vipapis.oauth.RefreshTokenResponse success_;
			
			public vipapis.oauth.RefreshTokenResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.oauth.RefreshTokenResponse value){
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
		
		
		
		
		public class refreshToken_argsHelper : TBeanSerializer<refreshToken_args>
		{
			
			public static refreshToken_argsHelper OBJ = new refreshToken_argsHelper();
			
			public static refreshToken_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(refreshToken_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.oauth.RefreshTokenRequest value;
					
					value = new vipapis.oauth.RefreshTokenRequest();
					vipapis.oauth.RefreshTokenRequestHelper.getInstance().Read(value, iprot);
					
					structs.SetRequest(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(refreshToken_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequest() != null) {
					
					oprot.WriteFieldBegin("request");
					
					vipapis.oauth.RefreshTokenRequestHelper.getInstance().Write(structs.GetRequest(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("request can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(refreshToken_args bean){
				
				
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
		
		
		
		
		public class refreshToken_resultHelper : TBeanSerializer<refreshToken_result>
		{
			
			public static refreshToken_resultHelper OBJ = new refreshToken_resultHelper();
			
			public static refreshToken_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(refreshToken_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.oauth.RefreshTokenResponse value;
					
					value = new vipapis.oauth.RefreshTokenResponse();
					vipapis.oauth.RefreshTokenResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(refreshToken_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.oauth.RefreshTokenResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(refreshToken_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class OauthServiceClient : OspRestStub , OauthService  {
			
			
			public OauthServiceClient():base("vipapis.oauth.OauthService","1.0.0") {
				
				
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
			
			
			public vipapis.oauth.RefreshTokenResponse refreshToken(vipapis.oauth.RefreshTokenRequest request_) {
				
				send_refreshToken(request_);
				return recv_refreshToken(); 
				
			}
			
			
			private void send_refreshToken(vipapis.oauth.RefreshTokenRequest request_){
				
				InitInvocation("refreshToken");
				
				refreshToken_args args = new refreshToken_args();
				args.SetRequest(request_);
				
				SendBase(args, refreshToken_argsHelper.getInstance());
			}
			
			
			private vipapis.oauth.RefreshTokenResponse recv_refreshToken(){
				
				refreshToken_result result = new refreshToken_result();
				ReceiveBase(result, refreshToken_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
		}
		
		
	}
	
}