using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.puma{
	
	
	
	public class SalesTimeRangeHelper : TBeanSerializer<SalesTimeRange>
	{
		
		public static SalesTimeRangeHelper OBJ = new SalesTimeRangeHelper();
		
		public static SalesTimeRangeHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(SalesTimeRange structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("sales_time_from_begin".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetSales_time_from_begin(value);
					}
					
					
					
					
					
					if ("sales_time_from_end".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetSales_time_from_end(value);
					}
					
					
					
					
					
					if ("sales_time_to_begin".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetSales_time_to_begin(value);
					}
					
					
					
					
					
					if ("sales_time_to_end".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetSales_time_to_end(value);
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
		
		
		public void Write(SalesTimeRange structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetSales_time_from_begin() != null) {
				
				oprot.WriteFieldBegin("sales_time_from_begin");
				oprot.WriteI64((long)structs.GetSales_time_from_begin()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSales_time_from_end() != null) {
				
				oprot.WriteFieldBegin("sales_time_from_end");
				oprot.WriteI64((long)structs.GetSales_time_from_end()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSales_time_to_begin() != null) {
				
				oprot.WriteFieldBegin("sales_time_to_begin");
				oprot.WriteI64((long)structs.GetSales_time_to_begin()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSales_time_to_end() != null) {
				
				oprot.WriteFieldBegin("sales_time_to_end");
				oprot.WriteI64((long)structs.GetSales_time_to_end()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(SalesTimeRange bean){
			
			
		}
		
	}
	
}