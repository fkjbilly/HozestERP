using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;

namespace vipapis.product{
	
	
	public class ChannelProductServiceHelper {
		
		
		
		public class getHtProductList_args {
			
			///<summary>
			/// 商品类型
			/// @sampleValue type index
			///</summary>
			
			private string type_;
			
			///<summary>
			/// 页码
			/// @sampleValue page 1
			///</summary>
			
			private int? page_;
			
			public string GetType(){
				return this.type_;
			}
			
			public void SetType(string value){
				this.type_ = value;
			}
			public int? GetPage(){
				return this.page_;
			}
			
			public void SetPage(int? value){
				this.page_ = value;
			}
			
		}
		
		
		
		
		public class healthCheck_args {
			
			
		}
		
		
		
		
		public class getHtProductList_result {
			
			///<summary>
			///</summary>
			
			private vipapis.product.HtProductListResult success_;
			
			public vipapis.product.HtProductListResult GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.product.HtProductListResult value){
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
		
		
		
		
		
		public class getHtProductList_argsHelper : TBeanSerializer<getHtProductList_args>
		{
			
			public static getHtProductList_argsHelper OBJ = new getHtProductList_argsHelper();
			
			public static getHtProductList_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getHtProductList_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetType(value);
				}
				
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetPage(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getHtProductList_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetType() != null) {
					
					oprot.WriteFieldBegin("type");
					oprot.WriteString(structs.GetType());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("type can not be null!");
				}
				
				
				if(structs.GetPage() != null) {
					
					oprot.WriteFieldBegin("page");
					oprot.WriteI32((int)structs.GetPage()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("page can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getHtProductList_args bean){
				
				
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
		
		
		
		
		public class getHtProductList_resultHelper : TBeanSerializer<getHtProductList_result>
		{
			
			public static getHtProductList_resultHelper OBJ = new getHtProductList_resultHelper();
			
			public static getHtProductList_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getHtProductList_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.product.HtProductListResult value;
					
					value = new vipapis.product.HtProductListResult();
					vipapis.product.HtProductListResultHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getHtProductList_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.product.HtProductListResultHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getHtProductList_result bean){
				
				
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
		
		
		
		
		public class ChannelProductServiceClient : OspRestStub , ChannelProductService  {
			
			
			public ChannelProductServiceClient():base("vipapis.product.ChannelProductService","1.0.0") {
				
				
			}
			
			
			
			public vipapis.product.HtProductListResult getHtProductList(string type_,int page_) {
				
				send_getHtProductList(type_,page_);
				return recv_getHtProductList(); 
				
			}
			
			
			private void send_getHtProductList(string type_,int page_){
				
				InitInvocation("getHtProductList");
				
				getHtProductList_args args = new getHtProductList_args();
				args.SetType(type_);
				args.SetPage(page_);
				
				SendBase(args, getHtProductList_argsHelper.getInstance());
			}
			
			
			private vipapis.product.HtProductListResult recv_getHtProductList(){
				
				getHtProductList_result result = new getHtProductList_result();
				ReceiveBase(result, getHtProductList_resultHelper.getInstance());
				
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