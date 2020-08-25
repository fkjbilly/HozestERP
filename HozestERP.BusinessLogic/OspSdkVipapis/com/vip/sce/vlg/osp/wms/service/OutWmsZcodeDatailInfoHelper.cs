using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.sce.vlg.osp.wms.service{
	
	
	
	public class OutWmsZcodeDatailInfoHelper : TBeanSerializer<OutWmsZcodeDatailInfo>
	{
		
		public static OutWmsZcodeDatailInfoHelper OBJ = new OutWmsZcodeDatailInfoHelper();
		
		public static OutWmsZcodeDatailInfoHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(OutWmsZcodeDatailInfo structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("ID".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetID(value);
					}
					
					
					
					
					
					if ("Z_CODE".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetZ_CODE(value);
					}
					
					
					
					
					
					if ("Z_IMAGE".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetZ_IMAGE(value);
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
		
		
		public void Write(OutWmsZcodeDatailInfo structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetID() != null) {
				
				oprot.WriteFieldBegin("ID");
				oprot.WriteString(structs.GetID());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("ID can not be null!");
			}
			
			
			if(structs.GetZ_CODE() != null) {
				
				oprot.WriteFieldBegin("Z_CODE");
				oprot.WriteString(structs.GetZ_CODE());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("Z_CODE can not be null!");
			}
			
			
			if(structs.GetZ_IMAGE() != null) {
				
				oprot.WriteFieldBegin("Z_IMAGE");
				oprot.WriteString(structs.GetZ_IMAGE());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("Z_IMAGE can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(OutWmsZcodeDatailInfo bean){
			
			
		}
		
	}
	
}