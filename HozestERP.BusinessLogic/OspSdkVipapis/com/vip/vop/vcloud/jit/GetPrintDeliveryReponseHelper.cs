using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.vop.vcloud.jit{
	
	
	
	public class GetPrintDeliveryReponseHelper : TBeanSerializer<GetPrintDeliveryReponse>
	{
		
		public static GetPrintDeliveryReponseHelper OBJ = new GetPrintDeliveryReponseHelper();
		
		public static GetPrintDeliveryReponseHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(GetPrintDeliveryReponse structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("template".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTemplate(value);
					}
					
					
					
					
					
					if ("total".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetTotal(value);
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
		
		
		public void Write(GetPrintDeliveryReponse structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetTemplate() != null) {
				
				oprot.WriteFieldBegin("template");
				oprot.WriteString(structs.GetTemplate());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTotal() != null) {
				
				oprot.WriteFieldBegin("total");
				oprot.WriteI32((int)structs.GetTotal()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(GetPrintDeliveryReponse bean){
			
			
		}
		
	}
	
}