using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.product{
	
	
	
	public class SalePropsHelper : TBeanSerializer<SaleProps>
	{
		
		public static SalePropsHelper OBJ = new SalePropsHelper();
		
		public static SalePropsHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(SaleProps structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("props_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetProps_id(value);
					}
					
					
					
					
					
					if ("props_name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetProps_name(value);
					}
					
					
					
					
					
					if ("props_value".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetProps_value(value);
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
		
		
		public void Write(SaleProps structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetProps_id() != null) {
				
				oprot.WriteFieldBegin("props_id");
				oprot.WriteI32((int)structs.GetProps_id()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetProps_name() != null) {
				
				oprot.WriteFieldBegin("props_name");
				oprot.WriteString(structs.GetProps_name());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetProps_value() != null) {
				
				oprot.WriteFieldBegin("props_value");
				oprot.WriteString(structs.GetProps_value());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(SaleProps bean){
			
			
		}
		
	}
	
}