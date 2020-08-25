using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.delivery{
	
	
	
	public class CreateDeliveryResponseHelper : BeanSerializer<CreateDeliveryResponse>
	{
		
		public static CreateDeliveryResponseHelper OBJ = new CreateDeliveryResponseHelper();
		
		public static CreateDeliveryResponseHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(CreateDeliveryResponse structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("delivery_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetDelivery_id(value);
					}
					
					
					
					
					
					if ("storage_no".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetStorage_no(value);
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
		
		
		public void Write(CreateDeliveryResponse structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetDelivery_id() != null) {
				
				oprot.WriteFieldBegin("delivery_id");
				oprot.WriteString(structs.GetDelivery_id());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetStorage_no() != null) {
				
				oprot.WriteFieldBegin("storage_no");
				oprot.WriteString(structs.GetStorage_no());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(CreateDeliveryResponse bean){
			
			
		}
		
	}
	
}