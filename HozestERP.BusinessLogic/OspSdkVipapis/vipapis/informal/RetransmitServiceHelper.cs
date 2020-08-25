using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;

namespace vipapis.informal{
	
	
	public class RetransmitServiceHelper {
		
		
		
		public class healthCheck_args {
			
			
		}
		
		
		
		
		public class retransmit_args {
			
			///<summary>
			/// 服务标识
			///</summary>
			
			private string routingKey_;
			
			///<summary>
			/// get参数，如果body不传值，默认为GET请求
			///</summary>
			
			private Dictionary<string, string> parameters_;
			
			///<summary>
			/// post参数，如果该参数传值，将默认为POST请求
			///</summary>
			
			private string body_;
			
			public string GetRoutingKey(){
				return this.routingKey_;
			}
			
			public void SetRoutingKey(string value){
				this.routingKey_ = value;
			}
			public Dictionary<string, string> GetParameters(){
				return this.parameters_;
			}
			
			public void SetParameters(Dictionary<string, string> value){
				this.parameters_ = value;
			}
			public string GetBody(){
				return this.body_;
			}
			
			public void SetBody(string value){
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
		
		
		
		
		public class retransmit_result {
			
			///<summary>
			///</summary>
			
			private string success_;
			
			public string GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(string value){
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
		
		
		
		
		public class retransmit_argsHelper : TBeanSerializer<retransmit_args>
		{
			
			public static retransmit_argsHelper OBJ = new retransmit_argsHelper();
			
			public static retransmit_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(retransmit_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetRoutingKey(value);
				}
				
				
				
				
				
				if(true){
					
					Dictionary<string, string> value;
					
					value = new Dictionary<string, string>();
					iprot.ReadMapBegin();
					while(true){
						
						try{
							
							string _key1;
							string _val1;
							_key1 = iprot.ReadString();
							
							_val1 = iprot.ReadString();
							
							value.Add(_key1, _val1);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadMapEnd();
					
					structs.SetParameters(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetBody(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(retransmit_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRoutingKey() != null) {
					
					oprot.WriteFieldBegin("routingKey");
					oprot.WriteString(structs.GetRoutingKey());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("routingKey can not be null!");
				}
				
				
				if(structs.GetParameters() != null) {
					
					oprot.WriteFieldBegin("parameters");
					
					oprot.WriteMapBegin();
					foreach(KeyValuePair< string, string > _ir0 in structs.GetParameters()){
						
						string _key0 = _ir0.Key;
						string _value0 = _ir0.Value;
						oprot.WriteString(_key0);
						
						oprot.WriteString(_value0);
						
					}
					
					oprot.WriteMapEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetBody() != null) {
					
					oprot.WriteFieldBegin("body");
					oprot.WriteString(structs.GetBody());
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(retransmit_args bean){
				
				
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
		
		
		
		
		public class retransmit_resultHelper : TBeanSerializer<retransmit_result>
		{
			
			public static retransmit_resultHelper OBJ = new retransmit_resultHelper();
			
			public static retransmit_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(retransmit_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(retransmit_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					oprot.WriteString(structs.GetSuccess());
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(retransmit_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class RetransmitServiceClient : OspRestStub , RetransmitService  {
			
			
			public RetransmitServiceClient():base("vipapis.informal.RetransmitService","1.0.0") {
				
				
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
			
			
			public string retransmit(string routingKey_,Dictionary<string, string> parameters_,string body_) {
				
				send_retransmit(routingKey_,parameters_,body_);
				return recv_retransmit(); 
				
			}
			
			
			private void send_retransmit(string routingKey_,Dictionary<string, string> parameters_,string body_){
				
				InitInvocation("retransmit");
				
				retransmit_args args = new retransmit_args();
				args.SetRoutingKey(routingKey_);
				args.SetParameters(parameters_);
				args.SetBody(body_);
				
				SendBase(args, retransmit_argsHelper.getInstance());
			}
			
			
			private string recv_retransmit(){
				
				retransmit_result result = new retransmit_result();
				ReceiveBase(result, retransmit_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
		}
		
		
	}
	
}