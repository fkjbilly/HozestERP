using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.marketplace.product{
	
	
	
	public class SimplePropertyHelper : TBeanSerializer<SimpleProperty>
	{
		
		public static SimplePropertyHelper OBJ = new SimplePropertyHelper();
		
		public static SimplePropertyHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(SimpleProperty structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("pid".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetPid(value);
					}
					
					
					
					
					
					if ("vid".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetVid(value);
					}
					
					
					
					
					
					if ("alias".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetAlias(value);
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
		
		
		public void Write(SimpleProperty structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetPid() != null) {
				
				oprot.WriteFieldBegin("pid");
				oprot.WriteI32((int)structs.GetPid()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetVid() != null) {
				
				oprot.WriteFieldBegin("vid");
				oprot.WriteI32((int)structs.GetVid()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetAlias() != null) {
				
				oprot.WriteFieldBegin("alias");
				oprot.WriteString(structs.GetAlias());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(SimpleProperty bean){
			
			
		}
		
	}
	
}