using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;

namespace vipapis.haitaoervice{
	
	
	public class HtFeedbackMessageServiceHelper {
		
		
		
		public class healthCheck_args {
			
			
		}
		
		
		
		
		public class sendFeedback_args {
			
			///<summary>
			/// 发送方
			///</summary>
			
			private string sender_;
			
			///<summary>
			/// 回执报文类型
			///</summary>
			
			private string messageType_;
			
			///<summary>
			/// 报文列表
			///</summary>
			
			private List<com.vip.haitao.feedback.osp.service.HtFeedbackMessageModel> messageList_;
			
			public string GetSender(){
				return this.sender_;
			}
			
			public void SetSender(string value){
				this.sender_ = value;
			}
			public string GetMessageType(){
				return this.messageType_;
			}
			
			public void SetMessageType(string value){
				this.messageType_ = value;
			}
			public List<com.vip.haitao.feedback.osp.service.HtFeedbackMessageModel> GetMessageList(){
				return this.messageList_;
			}
			
			public void SetMessageList(List<com.vip.haitao.feedback.osp.service.HtFeedbackMessageModel> value){
				this.messageList_ = value;
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
		
		
		
		
		public class sendFeedback_result {
			
			///<summary>
			///</summary>
			
			private com.vip.haitao.feedback.osp.service.HtFeedbackMessageResponse success_;
			
			public com.vip.haitao.feedback.osp.service.HtFeedbackMessageResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.haitao.feedback.osp.service.HtFeedbackMessageResponse value){
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
		
		
		
		
		public class sendFeedback_argsHelper : TBeanSerializer<sendFeedback_args>
		{
			
			public static sendFeedback_argsHelper OBJ = new sendFeedback_argsHelper();
			
			public static sendFeedback_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(sendFeedback_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetSender(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetMessageType(value);
				}
				
				
				
				
				
				if(true){
					
					List<com.vip.haitao.feedback.osp.service.HtFeedbackMessageModel> value;
					
					value = new List<com.vip.haitao.feedback.osp.service.HtFeedbackMessageModel>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							com.vip.haitao.feedback.osp.service.HtFeedbackMessageModel elem1;
							
							elem1 = new com.vip.haitao.feedback.osp.service.HtFeedbackMessageModel();
							com.vip.haitao.feedback.osp.service.HtFeedbackMessageModelHelper.getInstance().Read(elem1, iprot);
							
							value.Add(elem1);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetMessageList(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(sendFeedback_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSender() != null) {
					
					oprot.WriteFieldBegin("sender");
					oprot.WriteString(structs.GetSender());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetMessageType() != null) {
					
					oprot.WriteFieldBegin("messageType");
					oprot.WriteString(structs.GetMessageType());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetMessageList() != null) {
					
					oprot.WriteFieldBegin("messageList");
					
					oprot.WriteListBegin();
					foreach(com.vip.haitao.feedback.osp.service.HtFeedbackMessageModel _item0 in structs.GetMessageList()){
						
						
						com.vip.haitao.feedback.osp.service.HtFeedbackMessageModelHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(sendFeedback_args bean){
				
				
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
		
		
		
		
		public class sendFeedback_resultHelper : TBeanSerializer<sendFeedback_result>
		{
			
			public static sendFeedback_resultHelper OBJ = new sendFeedback_resultHelper();
			
			public static sendFeedback_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(sendFeedback_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.haitao.feedback.osp.service.HtFeedbackMessageResponse value;
					
					value = new com.vip.haitao.feedback.osp.service.HtFeedbackMessageResponse();
					com.vip.haitao.feedback.osp.service.HtFeedbackMessageResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(sendFeedback_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.haitao.feedback.osp.service.HtFeedbackMessageResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(sendFeedback_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class HtFeedbackMessageServiceClient : OspRestStub , HtFeedbackMessageService  {
			
			
			public HtFeedbackMessageServiceClient():base("vipapis.haitaoervice.HtFeedbackMessageService","1.0.0") {
				
				
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
			
			
			public com.vip.haitao.feedback.osp.service.HtFeedbackMessageResponse sendFeedback(string sender_,string messageType_,List<com.vip.haitao.feedback.osp.service.HtFeedbackMessageModel> messageList_) {
				
				send_sendFeedback(sender_,messageType_,messageList_);
				return recv_sendFeedback(); 
				
			}
			
			
			private void send_sendFeedback(string sender_,string messageType_,List<com.vip.haitao.feedback.osp.service.HtFeedbackMessageModel> messageList_){
				
				InitInvocation("sendFeedback");
				
				sendFeedback_args args = new sendFeedback_args();
				args.SetSender(sender_);
				args.SetMessageType(messageType_);
				args.SetMessageList(messageList_);
				
				SendBase(args, sendFeedback_argsHelper.getInstance());
			}
			
			
			private com.vip.haitao.feedback.osp.service.HtFeedbackMessageResponse recv_sendFeedback(){
				
				sendFeedback_result result = new sendFeedback_result();
				ReceiveBase(result, sendFeedback_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
		}
		
		
	}
	
}