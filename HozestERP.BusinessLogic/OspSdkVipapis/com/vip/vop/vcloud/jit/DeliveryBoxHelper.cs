using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.vop.vcloud.jit{
	
	
	
	public class DeliveryBoxHelper : TBeanSerializer<DeliveryBox>
	{
		
		public static DeliveryBoxHelper OBJ = new DeliveryBoxHelper();
		
		public static DeliveryBoxHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(DeliveryBox structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("deliveryId".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetDeliveryId(value);
					}
					
					
					
					
					
					if ("boxNo".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBoxNo(value);
					}
					
					
					
					
					
					if ("boxedQuantity".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetBoxedQuantity(value);
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
		
		
		public void Write(DeliveryBox structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetDeliveryId() != null) {
				
				oprot.WriteFieldBegin("deliveryId");
				oprot.WriteI64((long)structs.GetDeliveryId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBoxNo() != null) {
				
				oprot.WriteFieldBegin("boxNo");
				oprot.WriteString(structs.GetBoxNo());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBoxedQuantity() != null) {
				
				oprot.WriteFieldBegin("boxedQuantity");
				oprot.WriteI32((int)structs.GetBoxedQuantity()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(DeliveryBox bean){
			
			
		}
		
	}
	
}