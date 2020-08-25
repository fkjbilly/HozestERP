using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.order{
	
	
	
	public class ExtInfoHelper : TBeanSerializer<ExtInfo>
	{
		
		public static ExtInfoHelper OBJ = new ExtInfoHelper();
		
		public static ExtInfoHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(ExtInfo structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("ext_field1".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetExt_field1(value);
					}
					
					
					
					
					
					if ("ext_field2".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetExt_field2(value);
					}
					
					
					
					
					
					if ("ext_field3".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetExt_field3(value);
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
		
		
		public void Write(ExtInfo structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetExt_field1() != null) {
				
				oprot.WriteFieldBegin("ext_field1");
				oprot.WriteString(structs.GetExt_field1());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetExt_field2() != null) {
				
				oprot.WriteFieldBegin("ext_field2");
				oprot.WriteString(structs.GetExt_field2());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetExt_field3() != null) {
				
				oprot.WriteFieldBegin("ext_field3");
				oprot.WriteString(structs.GetExt_field3());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(ExtInfo bean){
			
			
		}
		
	}
	
}