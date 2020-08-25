using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.order{
	
	
	
	public class DeliveryInfoHelper : TBeanSerializer<DeliveryInfo>
	{
		
		public static DeliveryInfoHelper OBJ = new DeliveryInfoHelper();
		
		public static DeliveryInfoHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(DeliveryInfo structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("delivery_no".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetDelivery_no(value);
					}
					
					
					
					
					
					if ("container_no".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetContainer_no(value);
					}
					
					
					
					
					
					if ("record_type".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetRecord_type(value);
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
		
		
		public void Write(DeliveryInfo structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetDelivery_no() != null) {
				
				oprot.WriteFieldBegin("delivery_no");
				oprot.WriteString(structs.GetDelivery_no());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("delivery_no can not be null!");
			}
			
			
			if(structs.GetContainer_no() != null) {
				
				oprot.WriteFieldBegin("container_no");
				oprot.WriteString(structs.GetContainer_no());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("container_no can not be null!");
			}
			
			
			if(structs.GetRecord_type() != null) {
				
				oprot.WriteFieldBegin("record_type");
				oprot.WriteString(structs.GetRecord_type());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("record_type can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(DeliveryInfo bean){
			
			
		}
		
	}
	
}