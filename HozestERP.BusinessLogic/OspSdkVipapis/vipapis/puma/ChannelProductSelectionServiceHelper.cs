using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;

namespace vipapis.puma{
	
	
	public class ChannelProductSelectionServiceHelper {
		
		
		
		public class getProductSelection_args {
			
			///<summary>
			/// 商品url
			///</summary>
			
			private string product_url_;
			
			public string GetProduct_url(){
				return this.product_url_;
			}
			
			public void SetProduct_url(string value){
				this.product_url_ = value;
			}
			
		}
		
		
		
		
		public class healthCheck_args {
			
			
		}
		
		
		
		
		public class getProductSelection_result {
			
			///<summary>
			/// 返回商品营销信息
			///</summary>
			
			private vipapis.puma.ChannelProductSelection success_;
			
			public vipapis.puma.ChannelProductSelection GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.puma.ChannelProductSelection value){
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
		
		
		
		
		
		public class getProductSelection_argsHelper : TBeanSerializer<getProductSelection_args>
		{
			
			public static getProductSelection_argsHelper OBJ = new getProductSelection_argsHelper();
			
			public static getProductSelection_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getProductSelection_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetProduct_url(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getProductSelection_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetProduct_url() != null) {
					
					oprot.WriteFieldBegin("product_url");
					oprot.WriteString(structs.GetProduct_url());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("product_url can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getProductSelection_args bean){
				
				
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
		
		
		
		
		public class getProductSelection_resultHelper : TBeanSerializer<getProductSelection_result>
		{
			
			public static getProductSelection_resultHelper OBJ = new getProductSelection_resultHelper();
			
			public static getProductSelection_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getProductSelection_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.puma.ChannelProductSelection value;
					
					value = new vipapis.puma.ChannelProductSelection();
					vipapis.puma.ChannelProductSelectionHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getProductSelection_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.puma.ChannelProductSelectionHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getProductSelection_result bean){
				
				
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
		
		
		
		
		public class ChannelProductSelectionServiceClient : OspRestStub , ChannelProductSelectionService  {
			
			
			public ChannelProductSelectionServiceClient():base("vipapis.puma.ChannelProductSelectionService","1.0.0") {
				
				
			}
			
			
			
			public vipapis.puma.ChannelProductSelection getProductSelection(string product_url_) {
				
				send_getProductSelection(product_url_);
				return recv_getProductSelection(); 
				
			}
			
			
			private void send_getProductSelection(string product_url_){
				
				InitInvocation("getProductSelection");
				
				getProductSelection_args args = new getProductSelection_args();
				args.SetProduct_url(product_url_);
				
				SendBase(args, getProductSelection_argsHelper.getInstance());
			}
			
			
			private vipapis.puma.ChannelProductSelection recv_getProductSelection(){
				
				getProductSelection_result result = new getProductSelection_result();
				ReceiveBase(result, getProductSelection_resultHelper.getInstance());
				
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