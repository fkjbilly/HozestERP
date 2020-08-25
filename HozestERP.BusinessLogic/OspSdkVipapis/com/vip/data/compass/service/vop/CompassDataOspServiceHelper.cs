using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;

namespace com.vip.data.compass.service.vop{
	
	
	public class CompassDataOspServiceHelper {
		
		
		
		public class data_args {
			
			///<summary>
			/// 查询条件,可传参数详见:魔方罗盘/取数/API/包含的数据及口径/传递参数及参数格式
			///</summary>
			
			private Dictionary<string, string> api_params_;
			
			///<summary>
			/// API code
			///</summary>
			
			private string path_;
			
			///<summary>
			/// 供应商ID
			///</summary>
			
			private string vendor_id_;
			
			public Dictionary<string, string> GetApi_params(){
				return this.api_params_;
			}
			
			public void SetApi_params(Dictionary<string, string> value){
				this.api_params_ = value;
			}
			public string GetPath(){
				return this.path_;
			}
			
			public void SetPath(string value){
				this.path_ = value;
			}
			public string GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(string value){
				this.vendor_id_ = value;
			}
			
		}
		
		
		
		
		public class healthCheck_args {
			
			
		}
		
		
		
		
		public class data_result {
			
			///<summary>
			/// 
			///</summary>
			
			private com.vip.data.compass.service.vop.CompassDataResponse success_;
			
			public com.vip.data.compass.service.vop.CompassDataResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.data.compass.service.vop.CompassDataResponse value){
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
		
		
		
		
		
		public class data_argsHelper : TBeanSerializer<data_args>
		{
			
			public static data_argsHelper OBJ = new data_argsHelper();
			
			public static data_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(data_args structs, Protocol iprot){
				
				
				
				
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
					
					structs.SetApi_params(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetPath(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(data_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetApi_params() != null) {
					
					oprot.WriteFieldBegin("api_params");
					
					oprot.WriteMapBegin();
					foreach(KeyValuePair< string, string > _ir0 in structs.GetApi_params()){
						
						string _key0 = _ir0.Key;
						string _value0 = _ir0.Value;
						oprot.WriteString(_key0);
						
						oprot.WriteString(_value0);
						
					}
					
					oprot.WriteMapEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetPath() != null) {
					
					oprot.WriteFieldBegin("path");
					oprot.WriteString(structs.GetPath());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("path can not be null!");
				}
				
				
				if(structs.GetVendor_id() != null) {
					
					oprot.WriteFieldBegin("vendor_id");
					oprot.WriteString(structs.GetVendor_id());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("vendor_id can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(data_args bean){
				
				
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
		
		
		
		
		public class data_resultHelper : TBeanSerializer<data_result>
		{
			
			public static data_resultHelper OBJ = new data_resultHelper();
			
			public static data_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(data_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.data.compass.service.vop.CompassDataResponse value;
					
					value = new com.vip.data.compass.service.vop.CompassDataResponse();
					com.vip.data.compass.service.vop.CompassDataResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(data_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.data.compass.service.vop.CompassDataResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(data_result bean){
				
				
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
		
		
		
		
		public class CompassDataOspServiceClient : OspRestStub , CompassDataOspService  {
			
			
			public CompassDataOspServiceClient():base("com.vip.data.compass.service.vop.CompassDataOspService","1.0.0") {
				
				
			}
			
			
			
			public com.vip.data.compass.service.vop.CompassDataResponse data(Dictionary<string, string> api_params_,string path_,string vendor_id_) {
				
				send_data(api_params_,path_,vendor_id_);
				return recv_data(); 
				
			}
			
			
			private void send_data(Dictionary<string, string> api_params_,string path_,string vendor_id_){
				
				InitInvocation("data");
				
				data_args args = new data_args();
				args.SetApi_params(api_params_);
				args.SetPath(path_);
				args.SetVendor_id(vendor_id_);
				
				SendBase(args, data_argsHelper.getInstance());
			}
			
			
			private com.vip.data.compass.service.vop.CompassDataResponse recv_data(){
				
				data_result result = new data_result();
				ReceiveBase(result, data_resultHelper.getInstance());
				
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