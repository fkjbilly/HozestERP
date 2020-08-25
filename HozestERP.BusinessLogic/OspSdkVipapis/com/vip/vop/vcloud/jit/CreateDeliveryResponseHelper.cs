using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.vop.vcloud.jit{
	
	
	
	public class CreateDeliveryResponseHelper : TBeanSerializer<CreateDeliveryResponse>
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
					
					
					if ("storageNo".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetStorageNo(value);
					}
					
					
					
					
					
					if ("deliveryId".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetDeliveryId(value);
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
			
			if(structs.GetStorageNo() != null) {
				
				oprot.WriteFieldBegin("storageNo");
				oprot.WriteString(structs.GetStorageNo());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetDeliveryId() != null) {
				
				oprot.WriteFieldBegin("deliveryId");
				oprot.WriteString(structs.GetDeliveryId());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(CreateDeliveryResponse bean){
			
			
		}
		
	}
	
}