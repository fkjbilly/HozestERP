using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.arplatform.face.service{
	
	
	
	public class CrCbModelHelper : TBeanSerializer<CrCbModel>
	{
		
		public static CrCbModelHelper OBJ = new CrCbModelHelper();
		
		public static CrCbModelHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(CrCbModel structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("cr".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetCr(value);
					}
					
					
					
					
					
					if ("cb".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetCb(value);
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
		
		
		public void Write(CrCbModel structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetCr() != null) {
				
				oprot.WriteFieldBegin("cr");
				oprot.WriteI32((int)structs.GetCr()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCb() != null) {
				
				oprot.WriteFieldBegin("cb");
				oprot.WriteI32((int)structs.GetCb()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(CrCbModel bean){
			
			
		}
		
	}
	
}