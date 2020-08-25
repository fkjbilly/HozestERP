using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;

namespace vipapis.marketplace.brand{
	
	
	public class StoreBrandServiceHelper {
		
		
		
		public class getStoreBrands_args {
			
			
		}
		
		
		
		
		public class healthCheck_args {
			
			
		}
		
		
		
		
		public class getStoreBrands_result {
			
			///<summary>
			///</summary>
			
			private List<vipapis.marketplace.brand.StoreBrand> success_;
			
			public List<vipapis.marketplace.brand.StoreBrand> GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(List<vipapis.marketplace.brand.StoreBrand> value){
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
		
		
		
		
		
		public class getStoreBrands_argsHelper : TBeanSerializer<getStoreBrands_args>
		{
			
			public static getStoreBrands_argsHelper OBJ = new getStoreBrands_argsHelper();
			
			public static getStoreBrands_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getStoreBrands_args structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getStoreBrands_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getStoreBrands_args bean){
				
				
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
		
		
		
		
		public class getStoreBrands_resultHelper : TBeanSerializer<getStoreBrands_result>
		{
			
			public static getStoreBrands_resultHelper OBJ = new getStoreBrands_resultHelper();
			
			public static getStoreBrands_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getStoreBrands_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					List<vipapis.marketplace.brand.StoreBrand> value;
					
					value = new List<vipapis.marketplace.brand.StoreBrand>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							vipapis.marketplace.brand.StoreBrand elem1;
							
							elem1 = new vipapis.marketplace.brand.StoreBrand();
							vipapis.marketplace.brand.StoreBrandHelper.getInstance().Read(elem1, iprot);
							
							value.Add(elem1);
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
			
			
			public void Write(getStoreBrands_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					oprot.WriteListBegin();
					foreach(vipapis.marketplace.brand.StoreBrand _item0 in structs.GetSuccess()){
						
						
						vipapis.marketplace.brand.StoreBrandHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getStoreBrands_result bean){
				
				
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
		
		
		
		
		public class StoreBrandServiceClient : OspRestStub , StoreBrandService  {
			
			
			public StoreBrandServiceClient():base("vipapis.marketplace.brand.StoreBrandService","1.0.0") {
				
				
			}
			
			
			
			public List<vipapis.marketplace.brand.StoreBrand> getStoreBrands() {
				
				send_getStoreBrands();
				return recv_getStoreBrands(); 
				
			}
			
			
			private void send_getStoreBrands(){
				
				InitInvocation("getStoreBrands");
				
				getStoreBrands_args args = new getStoreBrands_args();
				
				SendBase(args, getStoreBrands_argsHelper.getInstance());
			}
			
			
			private List<vipapis.marketplace.brand.StoreBrand> recv_getStoreBrands(){
				
				getStoreBrands_result result = new getStoreBrands_result();
				ReceiveBase(result, getStoreBrands_resultHelper.getInstance());
				
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