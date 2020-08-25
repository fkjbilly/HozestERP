using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.puma{
	
	
	
	public class NumRangeHelper : TBeanSerializer<NumRange>
	{
		
		public static NumRangeHelper OBJ = new NumRangeHelper();
		
		public static NumRangeHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(NumRange structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("min_num".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetMin_num(value);
					}
					
					
					
					
					
					if ("max_num".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetMax_num(value);
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
		
		
		public void Write(NumRange structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetMin_num() != null) {
				
				oprot.WriteFieldBegin("min_num");
				oprot.WriteI32((int)structs.GetMin_num()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetMax_num() != null) {
				
				oprot.WriteFieldBegin("max_num");
				oprot.WriteI32((int)structs.GetMax_num()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(NumRange bean){
			
			
		}
		
	}
	
}