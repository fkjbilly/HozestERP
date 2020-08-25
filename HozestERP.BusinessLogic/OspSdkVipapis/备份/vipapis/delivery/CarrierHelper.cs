using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.delivery{
	
	
	
	public class CarrierHelper : BeanSerializer<Carrier>
	{
		
		public static CarrierHelper OBJ = new CarrierHelper();
		
		public static CarrierHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(Carrier structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("tms_carrier_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTms_carrier_id(value);
					}
					
					
					
					
					
					if ("carrier_name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCarrier_name(value);
					}
					
					
					
					
					
					if ("carrier_shortname".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCarrier_shortname(value);
					}
					
					
					
					
					
					if ("carrier_code".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCarrier_code(value);
					}
					
					
					
					
					
					if ("carrier_isvalid".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetCarrier_isvalid(value);
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
		
		
		public void Write(Carrier structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetTms_carrier_id() != null) {
				
				oprot.WriteFieldBegin("tms_carrier_id");
				oprot.WriteString(structs.GetTms_carrier_id());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCarrier_name() != null) {
				
				oprot.WriteFieldBegin("carrier_name");
				oprot.WriteString(structs.GetCarrier_name());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCarrier_shortname() != null) {
				
				oprot.WriteFieldBegin("carrier_shortname");
				oprot.WriteString(structs.GetCarrier_shortname());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCarrier_code() != null) {
				
				oprot.WriteFieldBegin("carrier_code");
				oprot.WriteString(structs.GetCarrier_code());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCarrier_isvalid() != null) {
				
				oprot.WriteFieldBegin("carrier_isvalid");
				oprot.WriteI32((int)structs.GetCarrier_isvalid()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(Carrier bean){
			
			
		}
		
	}
	
}