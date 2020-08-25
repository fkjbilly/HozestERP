using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.domain.order{
	
	
	
	public class CustomerBackOrderItemInfoHelper : TBeanSerializer<CustomerBackOrderItemInfo>
	{
		
		public static CustomerBackOrderItemInfoHelper OBJ = new CustomerBackOrderItemInfoHelper();
		
		public static CustomerBackOrderItemInfoHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(CustomerBackOrderItemInfo structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("size_sn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSize_sn(value);
					}
					
					
					
					
					
					if ("quantity".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetQuantity(value);
					}
					
					
					
					
					
					if ("unit".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetUnit(value);
					}
					
					
					
					
					
					if ("return_reason_name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetReturn_reason_name(value);
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
		
		
		public void Write(CustomerBackOrderItemInfo structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetSize_sn() != null) {
				
				oprot.WriteFieldBegin("size_sn");
				oprot.WriteString(structs.GetSize_sn());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("size_sn can not be null!");
			}
			
			
			if(structs.GetQuantity() != null) {
				
				oprot.WriteFieldBegin("quantity");
				oprot.WriteI32((int)structs.GetQuantity()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("quantity can not be null!");
			}
			
			
			if(structs.GetUnit() != null) {
				
				oprot.WriteFieldBegin("unit");
				oprot.WriteString(structs.GetUnit());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("unit can not be null!");
			}
			
			
			if(structs.GetReturn_reason_name() != null) {
				
				oprot.WriteFieldBegin("return_reason_name");
				oprot.WriteString(structs.GetReturn_reason_name());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("return_reason_name can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(CustomerBackOrderItemInfo bean){
			
			
		}
		
	}
	
}