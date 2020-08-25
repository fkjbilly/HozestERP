using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;

namespace com.vip.product.publish.service{
	
	
	public class ProductPublishServiceForVopHelper {
		
		
		
		public class batchSaveShoeReport_args {
			
			///<summary>
			/// 测鞋报告
			///</summary>
			
			private List<com.vip.product.publish.service.ShoeReportParameter> shoeReports_;
			
			///<summary>
			/// 操作来源
			///</summary>
			
			private string appId_;
			
			public List<com.vip.product.publish.service.ShoeReportParameter> GetShoeReports(){
				return this.shoeReports_;
			}
			
			public void SetShoeReports(List<com.vip.product.publish.service.ShoeReportParameter> value){
				this.shoeReports_ = value;
			}
			public string GetAppId(){
				return this.appId_;
			}
			
			public void SetAppId(string value){
				this.appId_ = value;
			}
			
		}
		
		
		
		
		public class healthCheck_args {
			
			
		}
		
		
		
		
		public class batchSaveShoeReport_result {
			
			///<summary>
			///</summary>
			
			private List<com.vip.product.publish.service.ShoeReportReturn> success_;
			
			public List<com.vip.product.publish.service.ShoeReportReturn> GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(List<com.vip.product.publish.service.ShoeReportReturn> value){
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
		
		
		
		
		
		public class batchSaveShoeReport_argsHelper : TBeanSerializer<batchSaveShoeReport_args>
		{
			
			public static batchSaveShoeReport_argsHelper OBJ = new batchSaveShoeReport_argsHelper();
			
			public static batchSaveShoeReport_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(batchSaveShoeReport_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					List<com.vip.product.publish.service.ShoeReportParameter> value;
					
					value = new List<com.vip.product.publish.service.ShoeReportParameter>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							com.vip.product.publish.service.ShoeReportParameter elem0;
							
							elem0 = new com.vip.product.publish.service.ShoeReportParameter();
							com.vip.product.publish.service.ShoeReportParameterHelper.getInstance().Read(elem0, iprot);
							
							value.Add(elem0);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetShoeReports(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetAppId(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(batchSaveShoeReport_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetShoeReports() != null) {
					
					oprot.WriteFieldBegin("shoeReports");
					
					oprot.WriteListBegin();
					foreach(com.vip.product.publish.service.ShoeReportParameter _item0 in structs.GetShoeReports()){
						
						
						com.vip.product.publish.service.ShoeReportParameterHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("shoeReports can not be null!");
				}
				
				
				if(structs.GetAppId() != null) {
					
					oprot.WriteFieldBegin("appId");
					oprot.WriteString(structs.GetAppId());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("appId can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(batchSaveShoeReport_args bean){
				
				
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
		
		
		
		
		public class batchSaveShoeReport_resultHelper : TBeanSerializer<batchSaveShoeReport_result>
		{
			
			public static batchSaveShoeReport_resultHelper OBJ = new batchSaveShoeReport_resultHelper();
			
			public static batchSaveShoeReport_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(batchSaveShoeReport_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					List<com.vip.product.publish.service.ShoeReportReturn> value;
					
					value = new List<com.vip.product.publish.service.ShoeReportReturn>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							com.vip.product.publish.service.ShoeReportReturn elem0;
							
							elem0 = new com.vip.product.publish.service.ShoeReportReturn();
							com.vip.product.publish.service.ShoeReportReturnHelper.getInstance().Read(elem0, iprot);
							
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
			
			
			public void Write(batchSaveShoeReport_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					oprot.WriteListBegin();
					foreach(com.vip.product.publish.service.ShoeReportReturn _item0 in structs.GetSuccess()){
						
						
						com.vip.product.publish.service.ShoeReportReturnHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(batchSaveShoeReport_result bean){
				
				
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
		
		
		
		
		public class ProductPublishServiceForVopClient : OspRestStub , ProductPublishServiceForVop  {
			
			
			public ProductPublishServiceForVopClient():base("com.vip.product.publish.service.ProductPublishServiceForVop","1.0.0") {
				
				
			}
			
			
			
			public List<com.vip.product.publish.service.ShoeReportReturn> batchSaveShoeReport(List<com.vip.product.publish.service.ShoeReportParameter> shoeReports_,string appId_) {
				
				send_batchSaveShoeReport(shoeReports_,appId_);
				return recv_batchSaveShoeReport(); 
				
			}
			
			
			private void send_batchSaveShoeReport(List<com.vip.product.publish.service.ShoeReportParameter> shoeReports_,string appId_){
				
				InitInvocation("batchSaveShoeReport");
				
				batchSaveShoeReport_args args = new batchSaveShoeReport_args();
				args.SetShoeReports(shoeReports_);
				args.SetAppId(appId_);
				
				SendBase(args, batchSaveShoeReport_argsHelper.getInstance());
			}
			
			
			private List<com.vip.product.publish.service.ShoeReportReturn> recv_batchSaveShoeReport(){
				
				batchSaveShoeReport_result result = new batchSaveShoeReport_result();
				ReceiveBase(result, batchSaveShoeReport_resultHelper.getInstance());
				
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