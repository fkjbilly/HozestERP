using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;

namespace vipapis.report{
	
	
	public class ReportServiceHelper {
		
		
		
		public class getCountOfServiceInvoke_args {
			
			///<summary>
			/// 调用时间YYYYMMDD
			/// @sampleValue invoke_date 20160111
			///</summary>
			
			private string invoke_date_;
			
			public string GetInvoke_date(){
				return this.invoke_date_;
			}
			
			public void SetInvoke_date(string value){
				this.invoke_date_ = value;
			}
			
		}
		
		
		
		
		public class healthCheck_args {
			
			
		}
		
		
		
		
		public class getCountOfServiceInvoke_result {
			
			///<summary>
			///</summary>
			
			private List<vipapis.report.CountOfServiceInvoke> success_;
			
			public List<vipapis.report.CountOfServiceInvoke> GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(List<vipapis.report.CountOfServiceInvoke> value){
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
		
		
		
		
		
		public class getCountOfServiceInvoke_argsHelper : TBeanSerializer<getCountOfServiceInvoke_args>
		{
			
			public static getCountOfServiceInvoke_argsHelper OBJ = new getCountOfServiceInvoke_argsHelper();
			
			public static getCountOfServiceInvoke_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getCountOfServiceInvoke_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetInvoke_date(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getCountOfServiceInvoke_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetInvoke_date() != null) {
					
					oprot.WriteFieldBegin("invoke_date");
					oprot.WriteString(structs.GetInvoke_date());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("invoke_date can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getCountOfServiceInvoke_args bean){
				
				
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
		
		
		
		
		public class getCountOfServiceInvoke_resultHelper : TBeanSerializer<getCountOfServiceInvoke_result>
		{
			
			public static getCountOfServiceInvoke_resultHelper OBJ = new getCountOfServiceInvoke_resultHelper();
			
			public static getCountOfServiceInvoke_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getCountOfServiceInvoke_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					List<vipapis.report.CountOfServiceInvoke> value;
					
					value = new List<vipapis.report.CountOfServiceInvoke>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							vipapis.report.CountOfServiceInvoke elem0;
							
							elem0 = new vipapis.report.CountOfServiceInvoke();
							vipapis.report.CountOfServiceInvokeHelper.getInstance().Read(elem0, iprot);
							
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
			
			
			public void Write(getCountOfServiceInvoke_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					oprot.WriteListBegin();
					foreach(vipapis.report.CountOfServiceInvoke _item0 in structs.GetSuccess()){
						
						
						vipapis.report.CountOfServiceInvokeHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getCountOfServiceInvoke_result bean){
				
				
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
		
		
		
		
		public class ReportServiceClient : OspRestStub , ReportService  {
			
			
			public ReportServiceClient():base("vipapis.report.ReportService","1.0.0") {
				
				
			}
			
			
			
			public List<vipapis.report.CountOfServiceInvoke> getCountOfServiceInvoke(string invoke_date_) {
				
				send_getCountOfServiceInvoke(invoke_date_);
				return recv_getCountOfServiceInvoke(); 
				
			}
			
			
			private void send_getCountOfServiceInvoke(string invoke_date_){
				
				InitInvocation("getCountOfServiceInvoke");
				
				getCountOfServiceInvoke_args args = new getCountOfServiceInvoke_args();
				args.SetInvoke_date(invoke_date_);
				
				SendBase(args, getCountOfServiceInvoke_argsHelper.getInstance());
			}
			
			
			private List<vipapis.report.CountOfServiceInvoke> recv_getCountOfServiceInvoke(){
				
				getCountOfServiceInvoke_result result = new getCountOfServiceInvoke_result();
				ReceiveBase(result, getCountOfServiceInvoke_resultHelper.getInstance());
				
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