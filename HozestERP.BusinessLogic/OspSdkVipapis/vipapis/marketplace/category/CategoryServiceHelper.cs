using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;

namespace vipapis.marketplace.category{
	
	
	public class CategoryServiceHelper {
		
		
		
		public class getStoreCategories_args {
			
			
		}
		
		
		
		
		public class healthCheck_args {
			
			
		}
		
		
		
		
		public class getStoreCategories_result {
			
			///<summary>
			///</summary>
			
			private vipapis.marketplace.category.GetStoreCategoriesResponse success_;
			
			public vipapis.marketplace.category.GetStoreCategoriesResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.marketplace.category.GetStoreCategoriesResponse value){
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
		
		
		
		
		
		public class getStoreCategories_argsHelper : TBeanSerializer<getStoreCategories_args>
		{
			
			public static getStoreCategories_argsHelper OBJ = new getStoreCategories_argsHelper();
			
			public static getStoreCategories_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getStoreCategories_args structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getStoreCategories_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getStoreCategories_args bean){
				
				
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
		
		
		
		
		public class getStoreCategories_resultHelper : TBeanSerializer<getStoreCategories_result>
		{
			
			public static getStoreCategories_resultHelper OBJ = new getStoreCategories_resultHelper();
			
			public static getStoreCategories_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getStoreCategories_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.marketplace.category.GetStoreCategoriesResponse value;
					
					value = new vipapis.marketplace.category.GetStoreCategoriesResponse();
					vipapis.marketplace.category.GetStoreCategoriesResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getStoreCategories_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.marketplace.category.GetStoreCategoriesResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getStoreCategories_result bean){
				
				
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
		
		
		
		
		public class CategoryServiceClient : OspRestStub , CategoryService  {
			
			
			public CategoryServiceClient():base("vipapis.marketplace.category.CategoryService","1.0.0") {
				
				
			}
			
			
			
			public vipapis.marketplace.category.GetStoreCategoriesResponse getStoreCategories() {
				
				send_getStoreCategories();
				return recv_getStoreCategories(); 
				
			}
			
			
			private void send_getStoreCategories(){
				
				InitInvocation("getStoreCategories");
				
				getStoreCategories_args args = new getStoreCategories_args();
				
				SendBase(args, getStoreCategories_argsHelper.getInstance());
			}
			
			
			private vipapis.marketplace.category.GetStoreCategoriesResponse recv_getStoreCategories(){
				
				getStoreCategories_result result = new getStoreCategories_result();
				ReceiveBase(result, getStoreCategories_resultHelper.getInstance());
				
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