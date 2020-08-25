using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.biz.request{
	
	
	
	public class PmsInfoHelper : TBeanSerializer<PmsInfo>
	{
		
		public static PmsInfoHelper OBJ = new PmsInfoHelper();
		
		public static PmsInfoHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(PmsInfo structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("pmsTicketId".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPmsTicketId(value);
					}
					
					
					
					
					
					if ("isFreeCarriage".Equals(schemeField.Trim())){
						
						needSkip = false;
						bool? value;
						value = iprot.ReadBool();
						
						structs.SetIsFreeCarriage(value);
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
		
		
		public void Write(PmsInfo structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetPmsTicketId() != null) {
				
				oprot.WriteFieldBegin("pmsTicketId");
				oprot.WriteString(structs.GetPmsTicketId());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetIsFreeCarriage() != null) {
				
				oprot.WriteFieldBegin("isFreeCarriage");
				oprot.WriteBool((bool)structs.GetIsFreeCarriage());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(PmsInfo bean){
			
			
		}
		
	}
	
}