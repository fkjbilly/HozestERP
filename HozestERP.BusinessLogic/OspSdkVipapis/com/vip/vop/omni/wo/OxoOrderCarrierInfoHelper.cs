using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.vop.omni.wo{
	
	
	
	public class OxoOrderCarrierInfoHelper : TBeanSerializer<OxoOrderCarrierInfo>
	{
		
		public static OxoOrderCarrierInfoHelper OBJ = new OxoOrderCarrierInfoHelper();
		
		public static OxoOrderCarrierInfoHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(OxoOrderCarrierInfo structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("orderSn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOrderSn(value);
					}
					
					
					
					
					
					if ("businessType".Equals(schemeField.Trim())){
						
						needSkip = false;
						byte value;
						value = iprot.ReadByte(); 
						
						structs.SetBusinessType(value);
					}
					
					
					
					
					
					if ("isDelivered".Equals(schemeField.Trim())){
						
						needSkip = false;
						bool value;
						value = iprot.ReadBool();
						
						structs.SetIsDelivered(value);
					}
					
					
					
					
					
					if ("carrier".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCarrier(value);
					}
					
					
					
					
					
					if ("carrierCode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCarrierCode(value);
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
		
		
		public void Write(OxoOrderCarrierInfo structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetOrderSn() != null) {
				
				oprot.WriteFieldBegin("orderSn");
				oprot.WriteString(structs.GetOrderSn());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("orderSn can not be null!");
			}
			
			
			if(structs.GetBusinessType() != null) {
				
				oprot.WriteFieldBegin("businessType");
				oprot.WriteByte((byte)structs.GetBusinessType()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("businessType can not be null!");
			}
			
			
			if(structs.GetIsDelivered() != null) {
				
				oprot.WriteFieldBegin("isDelivered");
				oprot.WriteBool((bool)structs.GetIsDelivered());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("isDelivered can not be null!");
			}
			
			
			if(structs.GetCarrier() != null) {
				
				oprot.WriteFieldBegin("carrier");
				oprot.WriteString(structs.GetCarrier());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCarrierCode() != null) {
				
				oprot.WriteFieldBegin("carrierCode");
				oprot.WriteString(structs.GetCarrierCode());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(OxoOrderCarrierInfo bean){
			
			
		}
		
	}
	
}