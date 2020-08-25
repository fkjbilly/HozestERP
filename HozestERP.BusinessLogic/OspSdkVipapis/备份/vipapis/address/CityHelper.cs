using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.address{
	
	
	
	public class CityHelper : BeanSerializer<City>
	{
		
		public static CityHelper OBJ = new CityHelper();
		
		public static CityHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(City structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("city_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCity_id(value);
					}
					
					
					
					
					
					if ("city_name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCity_name(value);
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
		
		
		public void Write(City structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetCity_id() != null) {
				
				oprot.WriteFieldBegin("city_id");
				oprot.WriteString(structs.GetCity_id());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("city_id can not be null!");
			}
			
			
			if(structs.GetCity_name() != null) {
				
				oprot.WriteFieldBegin("city_name");
				oprot.WriteString(structs.GetCity_name());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("city_name can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(City bean){
			
			
		}
		
	}
	
}