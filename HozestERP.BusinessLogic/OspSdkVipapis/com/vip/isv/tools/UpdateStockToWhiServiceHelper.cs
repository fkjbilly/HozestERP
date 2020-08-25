using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;

namespace com.vip.isv.tools{
	
	
	public class UpdateStockToWhiServiceHelper {
		
		
		
		public class healthCheck_args {
			
			
		}
		
		
		
		
		public class updateStockToWhi_args {
			
			///<summary>
			/// 请求参数
			///</summary>
			
			private List<com.vip.isv.tools.UpdateStockToWhiRequest> requests_;
			
			public List<com.vip.isv.tools.UpdateStockToWhiRequest> GetRequests(){
				return this.requests_;
			}
			
			public void SetRequests(List<com.vip.isv.tools.UpdateStockToWhiRequest> value){
				this.requests_ = value;
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
		
		
		
		
		public class updateStockToWhi_result {
			
			///<summary>
			///</summary>
			
			private List<com.vip.isv.tools.UpdateStockToWhiResponse> success_;
			
			public List<com.vip.isv.tools.UpdateStockToWhiResponse> GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(List<com.vip.isv.tools.UpdateStockToWhiResponse> value){
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
		
		
		
		
		public class updateStockToWhi_argsHelper : TBeanSerializer<updateStockToWhi_args>
		{
			
			public static updateStockToWhi_argsHelper OBJ = new updateStockToWhi_argsHelper();
			
			public static updateStockToWhi_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(updateStockToWhi_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					List<com.vip.isv.tools.UpdateStockToWhiRequest> value;
					
					value = new List<com.vip.isv.tools.UpdateStockToWhiRequest>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							com.vip.isv.tools.UpdateStockToWhiRequest elem0;
							
							elem0 = new com.vip.isv.tools.UpdateStockToWhiRequest();
							com.vip.isv.tools.UpdateStockToWhiRequestHelper.getInstance().Read(elem0, iprot);
							
							value.Add(elem0);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetRequests(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(updateStockToWhi_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequests() != null) {
					
					oprot.WriteFieldBegin("requests");
					
					oprot.WriteListBegin();
					foreach(com.vip.isv.tools.UpdateStockToWhiRequest _item0 in structs.GetRequests()){
						
						
						com.vip.isv.tools.UpdateStockToWhiRequestHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(updateStockToWhi_args bean){
				
				
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
		
		
		
		
		public class updateStockToWhi_resultHelper : TBeanSerializer<updateStockToWhi_result>
		{
			
			public static updateStockToWhi_resultHelper OBJ = new updateStockToWhi_resultHelper();
			
			public static updateStockToWhi_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(updateStockToWhi_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					List<com.vip.isv.tools.UpdateStockToWhiResponse> value;
					
					value = new List<com.vip.isv.tools.UpdateStockToWhiResponse>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							com.vip.isv.tools.UpdateStockToWhiResponse elem0;
							
							elem0 = new com.vip.isv.tools.UpdateStockToWhiResponse();
							com.vip.isv.tools.UpdateStockToWhiResponseHelper.getInstance().Read(elem0, iprot);
							
							value.Add(elem0);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(updateStockToWhi_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					oprot.WriteListBegin();
					foreach(com.vip.isv.tools.UpdateStockToWhiResponse _item0 in structs.GetSuccess()){
						
						
						com.vip.isv.tools.UpdateStockToWhiResponseHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(updateStockToWhi_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class UpdateStockToWhiServiceClient : OspRestStub , UpdateStockToWhiService  {
			
			
			public UpdateStockToWhiServiceClient():base("com.vip.isv.tools.UpdateStockToWhiService","1.0.0") {
				
				
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
			
			
			public List<com.vip.isv.tools.UpdateStockToWhiResponse> updateStockToWhi(List<com.vip.isv.tools.UpdateStockToWhiRequest> requests_) {
				
				send_updateStockToWhi(requests_);
				return recv_updateStockToWhi(); 
				
			}
			
			
			private void send_updateStockToWhi(List<com.vip.isv.tools.UpdateStockToWhiRequest> requests_){
				
				InitInvocation("updateStockToWhi");
				
				updateStockToWhi_args args = new updateStockToWhi_args();
				args.SetRequests(requests_);
				
				SendBase(args, updateStockToWhi_argsHelper.getInstance());
			}
			
			
			private List<com.vip.isv.tools.UpdateStockToWhiResponse> recv_updateStockToWhi(){
				
				updateStockToWhi_result result = new updateStockToWhi_result();
				ReceiveBase(result, updateStockToWhi_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
		}
		
		
	}
	
}