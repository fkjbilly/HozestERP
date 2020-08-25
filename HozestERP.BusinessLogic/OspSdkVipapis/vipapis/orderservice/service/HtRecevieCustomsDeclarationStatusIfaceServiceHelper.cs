using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;

namespace vipapis.orderservice.service{
	
	
	public class HtRecevieCustomsDeclarationStatusIfaceServiceHelper {
		
		
		
		public class healthCheck_args {
			
			
		}
		
		
		
		
		public class receiveCustomsDeclarationStatus_args {
			
			///<summary>
			/// 调用方对应关口
			///</summary>
			
			private string customsCode_;
			
			///<summary>
			/// 调用方代码
			///</summary>
			
			private string userId_;
			
			///<summary>
			///</summary>
			
			private List<com.vip.haitao.orderservice.service.HtCustomsDeclarationContentBody> body_;
			
			public string GetCustomsCode(){
				return this.customsCode_;
			}
			
			public void SetCustomsCode(string value){
				this.customsCode_ = value;
			}
			public string GetUserId(){
				return this.userId_;
			}
			
			public void SetUserId(string value){
				this.userId_ = value;
			}
			public List<com.vip.haitao.orderservice.service.HtCustomsDeclarationContentBody> GetBody(){
				return this.body_;
			}
			
			public void SetBody(List<com.vip.haitao.orderservice.service.HtCustomsDeclarationContentBody> value){
				this.body_ = value;
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
		
		
		
		
		public class receiveCustomsDeclarationStatus_result {
			
			///<summary>
			///</summary>
			
			private com.vip.haitao.orderservice.service.HtCustomsDeclarationResponseMessage success_;
			
			public com.vip.haitao.orderservice.service.HtCustomsDeclarationResponseMessage GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.haitao.orderservice.service.HtCustomsDeclarationResponseMessage value){
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
		
		
		
		
		public class receiveCustomsDeclarationStatus_argsHelper : TBeanSerializer<receiveCustomsDeclarationStatus_args>
		{
			
			public static receiveCustomsDeclarationStatus_argsHelper OBJ = new receiveCustomsDeclarationStatus_argsHelper();
			
			public static receiveCustomsDeclarationStatus_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(receiveCustomsDeclarationStatus_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetCustomsCode(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetUserId(value);
				}
				
				
				
				
				
				if(true){
					
					List<com.vip.haitao.orderservice.service.HtCustomsDeclarationContentBody> value;
					
					value = new List<com.vip.haitao.orderservice.service.HtCustomsDeclarationContentBody>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							com.vip.haitao.orderservice.service.HtCustomsDeclarationContentBody elem1;
							
							elem1 = new com.vip.haitao.orderservice.service.HtCustomsDeclarationContentBody();
							com.vip.haitao.orderservice.service.HtCustomsDeclarationContentBodyHelper.getInstance().Read(elem1, iprot);
							
							value.Add(elem1);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetBody(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(receiveCustomsDeclarationStatus_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetCustomsCode() != null) {
					
					oprot.WriteFieldBegin("customsCode");
					oprot.WriteString(structs.GetCustomsCode());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetUserId() != null) {
					
					oprot.WriteFieldBegin("userId");
					oprot.WriteString(structs.GetUserId());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetBody() != null) {
					
					oprot.WriteFieldBegin("body");
					
					oprot.WriteListBegin();
					foreach(com.vip.haitao.orderservice.service.HtCustomsDeclarationContentBody _item0 in structs.GetBody()){
						
						
						com.vip.haitao.orderservice.service.HtCustomsDeclarationContentBodyHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(receiveCustomsDeclarationStatus_args bean){
				
				
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
		
		
		
		
		public class receiveCustomsDeclarationStatus_resultHelper : TBeanSerializer<receiveCustomsDeclarationStatus_result>
		{
			
			public static receiveCustomsDeclarationStatus_resultHelper OBJ = new receiveCustomsDeclarationStatus_resultHelper();
			
			public static receiveCustomsDeclarationStatus_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(receiveCustomsDeclarationStatus_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.haitao.orderservice.service.HtCustomsDeclarationResponseMessage value;
					
					value = new com.vip.haitao.orderservice.service.HtCustomsDeclarationResponseMessage();
					com.vip.haitao.orderservice.service.HtCustomsDeclarationResponseMessageHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(receiveCustomsDeclarationStatus_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.haitao.orderservice.service.HtCustomsDeclarationResponseMessageHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(receiveCustomsDeclarationStatus_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class HtRecevieCustomsDeclarationStatusIfaceServiceClient : OspRestStub , HtRecevieCustomsDeclarationStatusIfaceService  {
			
			
			public HtRecevieCustomsDeclarationStatusIfaceServiceClient():base("vipapis.orderservice.service.HtRecevieCustomsDeclarationStatusIfaceService","1.0.0") {
				
				
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
			
			
			public com.vip.haitao.orderservice.service.HtCustomsDeclarationResponseMessage receiveCustomsDeclarationStatus(string customsCode_,string userId_,List<com.vip.haitao.orderservice.service.HtCustomsDeclarationContentBody> body_) {
				
				send_receiveCustomsDeclarationStatus(customsCode_,userId_,body_);
				return recv_receiveCustomsDeclarationStatus(); 
				
			}
			
			
			private void send_receiveCustomsDeclarationStatus(string customsCode_,string userId_,List<com.vip.haitao.orderservice.service.HtCustomsDeclarationContentBody> body_){
				
				InitInvocation("receiveCustomsDeclarationStatus");
				
				receiveCustomsDeclarationStatus_args args = new receiveCustomsDeclarationStatus_args();
				args.SetCustomsCode(customsCode_);
				args.SetUserId(userId_);
				args.SetBody(body_);
				
				SendBase(args, receiveCustomsDeclarationStatus_argsHelper.getInstance());
			}
			
			
			private com.vip.haitao.orderservice.service.HtCustomsDeclarationResponseMessage recv_receiveCustomsDeclarationStatus(){
				
				receiveCustomsDeclarationStatus_result result = new receiveCustomsDeclarationStatus_result();
				ReceiveBase(result, receiveCustomsDeclarationStatus_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
		}
		
		
	}
	
}