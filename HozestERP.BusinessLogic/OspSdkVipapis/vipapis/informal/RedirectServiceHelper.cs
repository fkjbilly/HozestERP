using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;

namespace vipapis.informal{
	
	
	public class RedirectServiceHelper {
		
		
		
		public class doRedirect_args {
			
			///<summary>
			/// 请求URL
			///</summary>
			
			private string url_;
			
			///<summary>
			/// get参数，如果postValues不传值，默认为GET请求
			///</summary>
			
			private Dictionary<string, string> getValues_;
			
			///<summary>
			/// post参数，如果该参数传值，将默认为POST请求
			///</summary>
			
			private Dictionary<string, string> postValues_;
			
			public string GetUrl(){
				return this.url_;
			}
			
			public void SetUrl(string value){
				this.url_ = value;
			}
			public Dictionary<string, string> GetGetValues(){
				return this.getValues_;
			}
			
			public void SetGetValues(Dictionary<string, string> value){
				this.getValues_ = value;
			}
			public Dictionary<string, string> GetPostValues(){
				return this.postValues_;
			}
			
			public void SetPostValues(Dictionary<string, string> value){
				this.postValues_ = value;
			}
			
		}
		
		
		
		
		public class healthCheck_args {
			
			
		}
		
		
		
		
		public class doRedirect_result {
			
			///<summary>
			/// 
			///</summary>
			
			private string success_;
			
			public string GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(string value){
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
		
		
		
		
		
		public class doRedirect_argsHelper : TBeanSerializer<doRedirect_args>
		{
			
			public static doRedirect_argsHelper OBJ = new doRedirect_argsHelper();
			
			public static doRedirect_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(doRedirect_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetUrl(value);
				}
				
				
				
				
				
				if(true){
					
					Dictionary<string, string> value;
					
					value = new Dictionary<string, string>();
					iprot.ReadMapBegin();
					while(true){
						
						try{
							
							string _key0;
							string _val0;
							_key0 = iprot.ReadString();
							
							_val0 = iprot.ReadString();
							
							value.Add(_key0, _val0);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadMapEnd();
					
					structs.SetGetValues(value);
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
					
					structs.SetPostValues(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(doRedirect_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetUrl() != null) {
					
					oprot.WriteFieldBegin("url");
					oprot.WriteString(structs.GetUrl());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("url can not be null!");
				}
				
				
				if(structs.GetGetValues() != null) {
					
					oprot.WriteFieldBegin("getValues");
					
					oprot.WriteMapBegin();
					foreach(KeyValuePair< string, string > _ir0 in structs.GetGetValues()){
						
						string _key0 = _ir0.Key;
						string _value0 = _ir0.Value;
						oprot.WriteString(_key0);
						
						oprot.WriteString(_value0);
						
					}
					
					oprot.WriteMapEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetPostValues() != null) {
					
					oprot.WriteFieldBegin("postValues");
					
					oprot.WriteMapBegin();
					foreach(KeyValuePair< string, string > _ir0 in structs.GetPostValues()){
						
						string _key0 = _ir0.Key;
						string _value0 = _ir0.Value;
						oprot.WriteString(_key0);
						
						oprot.WriteString(_value0);
						
					}
					
					oprot.WriteMapEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(doRedirect_args bean){
				
				
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
		
		
		
		
		public class doRedirect_resultHelper : TBeanSerializer<doRedirect_result>
		{
			
			public static doRedirect_resultHelper OBJ = new doRedirect_resultHelper();
			
			public static doRedirect_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(doRedirect_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(doRedirect_result structs, Protocol oprot){
				
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
			
			
			public void Validate(doRedirect_result bean){
				
				
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
		
		
		
		
		public class RedirectServiceClient : OspRestStub , RedirectService  {
			
			
			public RedirectServiceClient():base("vipapis.informal.RedirectService","1.0.0") {
				
				
			}
			
			
			
			public string doRedirect(string url_,Dictionary<string, string> getValues_,Dictionary<string, string> postValues_) {
				
				send_doRedirect(url_,getValues_,postValues_);
				return recv_doRedirect(); 
				
			}
			
			
			private void send_doRedirect(string url_,Dictionary<string, string> getValues_,Dictionary<string, string> postValues_){
				
				InitInvocation("doRedirect");
				
				doRedirect_args args = new doRedirect_args();
				args.SetUrl(url_);
				args.SetGetValues(getValues_);
				args.SetPostValues(postValues_);
				
				SendBase(args, doRedirect_argsHelper.getInstance());
			}
			
			
			private string recv_doRedirect(){
				
				doRedirect_result result = new doRedirect_result();
				ReceiveBase(result, doRedirect_resultHelper.getInstance());
				
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