using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.inventory{
	
	
	
	public class GetScheduleSkuListCriteriaHelper : TBeanSerializer<GetScheduleSkuListCriteria>
	{
		
		public static GetScheduleSkuListCriteriaHelper OBJ = new GetScheduleSkuListCriteriaHelper();
		
		public static GetScheduleSkuListCriteriaHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(GetScheduleSkuListCriteria structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("vendor_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetVendor_id(value);
					}
					
					
					
					
					
					if ("cooperation_no".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetCooperation_no(value);
					}
					
					
					
					
					
					if ("warehouse".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetWarehouse(value);
					}
					
					
					
					
					
					if ("start_query".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetStart_query(value);
					}
					
					
					
					
					
					if ("end_query".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetEnd_query(value);
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
		
		
		public void Write(GetScheduleSkuListCriteria structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetVendor_id() != null) {
				
				oprot.WriteFieldBegin("vendor_id");
				oprot.WriteI32((int)structs.GetVendor_id()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("vendor_id can not be null!");
			}
			
			
			if(structs.GetCooperation_no() != null) {
				
				oprot.WriteFieldBegin("cooperation_no");
				oprot.WriteI32((int)structs.GetCooperation_no()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetWarehouse() != null) {
				
				oprot.WriteFieldBegin("warehouse");
				oprot.WriteString(structs.GetWarehouse());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetStart_query() != null) {
				
				oprot.WriteFieldBegin("start_query");
				oprot.WriteI64((long)structs.GetStart_query()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetEnd_query() != null) {
				
				oprot.WriteFieldBegin("end_query");
				oprot.WriteI64((long)structs.GetEnd_query()); 
				
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
		
		
		public void Validate(GetScheduleSkuListCriteria bean){
			
			
		}
		
	}
	
}