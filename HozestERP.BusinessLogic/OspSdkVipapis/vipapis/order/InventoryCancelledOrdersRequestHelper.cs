using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.order{
	
	
	
	public class InventoryCancelledOrdersRequestHelper : TBeanSerializer<InventoryCancelledOrdersRequest>
	{
		
		public static InventoryCancelledOrdersRequestHelper OBJ = new InventoryCancelledOrdersRequestHelper();
		
		public static InventoryCancelledOrdersRequestHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(InventoryCancelledOrdersRequest structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("vendor_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						long value;
						value = iprot.ReadI64(); 
						
						structs.SetVendor_id(value);
					}
					
					
					
					
					
					if ("brand_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetBrand_id(value);
					}
					
					
					
					
					
					if ("st_query_time".Equals(schemeField.Trim())){
						
						needSkip = false;
						long value;
						value = iprot.ReadI64(); 
						
						structs.SetSt_query_time(value);
					}
					
					
					
					
					
					if ("et_query_time".Equals(schemeField.Trim())){
						
						needSkip = false;
						long value;
						value = iprot.ReadI64(); 
						
						structs.SetEt_query_time(value);
					}
					
					
					
					
					
					if ("limit".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetLimit(value);
					}
					
					
					
					
					
					if ("page".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetPage(value);
					}
					
					
					
					
					
					if ("business_type".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetBusiness_type(value);
					}
					
					
					
					
					if(needSkip){
						
						ProtocolUtil.skip(iprot);
					}
					
					iprot.ReadFieldEnd();
				}
				
				iprot.ReadStructEnd();
				Validate(structs);
			}
			else{
				
				throw new OspException();
			}
			
			
		}
		
		
		public void Write(InventoryCancelledOrdersRequest structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetVendor_id() != null) {
				
				oprot.WriteFieldBegin("vendor_id");
				oprot.WriteI64((long)structs.GetVendor_id()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("vendor_id can not be null!");
			}
			
			
			if(structs.GetBrand_id() != null) {
				
				oprot.WriteFieldBegin("brand_id");
				oprot.WriteI64((long)structs.GetBrand_id()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSt_query_time() != null) {
				
				oprot.WriteFieldBegin("st_query_time");
				oprot.WriteI64((long)structs.GetSt_query_time()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("st_query_time can not be null!");
			}
			
			
			if(structs.GetEt_query_time() != null) {
				
				oprot.WriteFieldBegin("et_query_time");
				oprot.WriteI64((long)structs.GetEt_query_time()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("et_query_time can not be null!");
			}
			
			
			if(structs.GetLimit() != null) {
				
				oprot.WriteFieldBegin("limit");
				oprot.WriteI32((int)structs.GetLimit()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPage() != null) {
				
				oprot.WriteFieldBegin("page");
				oprot.WriteI32((int)structs.GetPage()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBusiness_type() != null) {
				
				oprot.WriteFieldBegin("business_type");
				oprot.WriteI32((int)structs.GetBusiness_type()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(InventoryCancelledOrdersRequest bean){
			
			
		}
		
	}
	
}