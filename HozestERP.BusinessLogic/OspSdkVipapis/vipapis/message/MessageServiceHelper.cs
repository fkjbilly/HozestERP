using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;

namespace vipapis.message{
	
	
	public class MessageServiceHelper {
		
		
		
		public class healthCheck_args {
			
			
		}
		
		
		
		
		public class publishMessage_args {
			
			///<summary>
			/// 供应商ID,vendor_id或vendor_code必填其一
			/// @sampleValue vendor_id 525
			///</summary>
			
			private int? vendor_id_;
			
			///<summary>
			/// 供应商编码,vendor_id或vendor_code必填其一
			/// @sampleValue vendor_code 243
			///</summary>
			
			private int? vendor_code_;
			
			///<summary>
			/// 消息主题
			/// @sampleValue subject storeFrozen
			///</summary>
			
			private string subject_;
			
			///<summary>
			/// 消息内容, 1.必须是json格式的数据
			/// 2.必须符合我们的消息模板
			/// @sampleValue message_content 
			///</summary>
			
			private string message_content_;
			
			public int? GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(int? value){
				this.vendor_id_ = value;
			}
			public int? GetVendor_code(){
				return this.vendor_code_;
			}
			
			public void SetVendor_code(int? value){
				this.vendor_code_ = value;
			}
			public string GetSubject(){
				return this.subject_;
			}
			
			public void SetSubject(string value){
				this.subject_ = value;
			}
			public string GetMessage_content(){
				return this.message_content_;
			}
			
			public void SetMessage_content(string value){
				this.message_content_ = value;
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
		
		
		
		
		public class publishMessage_result {
			
			///<summary>
			///</summary>
			
			private bool? success_;
			
			public bool? GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(bool? value){
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
		
		
		
		
		public class publishMessage_argsHelper : TBeanSerializer<publishMessage_args>
		{
			
			public static publishMessage_argsHelper OBJ = new publishMessage_argsHelper();
			
			public static publishMessage_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(publishMessage_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					int? value;
					value = iprot.ReadI32(); 
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				
				if(true){
					
					int? value;
					value = iprot.ReadI32(); 
					
					structs.SetVendor_code(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetSubject(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetMessage_content(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(publishMessage_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetVendor_id() != null) {
					
					oprot.WriteFieldBegin("vendor_id");
					oprot.WriteI32((int)structs.GetVendor_id()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetVendor_code() != null) {
					
					oprot.WriteFieldBegin("vendor_code");
					oprot.WriteI32((int)structs.GetVendor_code()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetSubject() != null) {
					
					oprot.WriteFieldBegin("subject");
					oprot.WriteString(structs.GetSubject());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("subject can not be null!");
				}
				
				
				if(structs.GetMessage_content() != null) {
					
					oprot.WriteFieldBegin("message_content");
					oprot.WriteString(structs.GetMessage_content());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("message_content can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(publishMessage_args bean){
				
				
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
		
		
		
		
		public class publishMessage_resultHelper : TBeanSerializer<publishMessage_result>
		{
			
			public static publishMessage_resultHelper OBJ = new publishMessage_resultHelper();
			
			public static publishMessage_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(publishMessage_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					bool value;
					value = iprot.ReadBool();
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(publishMessage_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					oprot.WriteBool((bool)structs.GetSuccess());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("success can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(publishMessage_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class MessageServiceClient : OspRestStub , MessageService  {
			
			
			public MessageServiceClient():base("vipapis.message.MessageService","1.0.0") {
				
				
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
			
			
			public bool? publishMessage(int? vendor_id_,int? vendor_code_,string subject_,string message_content_) {
				
				send_publishMessage(vendor_id_,vendor_code_,subject_,message_content_);
				return recv_publishMessage(); 
				
			}
			
			
			private void send_publishMessage(int? vendor_id_,int? vendor_code_,string subject_,string message_content_){
				
				InitInvocation("publishMessage");
				
				publishMessage_args args = new publishMessage_args();
				args.SetVendor_id(vendor_id_);
				args.SetVendor_code(vendor_code_);
				args.SetSubject(subject_);
				args.SetMessage_content(message_content_);
				
				SendBase(args, publishMessage_argsHelper.getInstance());
			}
			
			
			private bool? recv_publishMessage(){
				
				publishMessage_result result = new publishMessage_result();
				ReceiveBase(result, publishMessage_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
		}
		
		
	}
	
}