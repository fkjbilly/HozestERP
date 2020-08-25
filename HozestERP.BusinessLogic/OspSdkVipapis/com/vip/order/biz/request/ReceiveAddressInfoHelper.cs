using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.biz.request{
	
	
	
	public class ReceiveAddressInfoHelper : TBeanSerializer<ReceiveAddressInfo>
	{
		
		public static ReceiveAddressInfoHelper OBJ = new ReceiveAddressInfoHelper();
		
		public static ReceiveAddressInfoHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(ReceiveAddressInfo structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("addressId".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetAddressId(value);
					}
					
					
					
					
					
					if ("addressType".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetAddressType(value);
					}
					
					
					
					
					
					if ("transportDays".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetTransportDays(value);
					}
					
					
					
					
					
					if ("transportTimeType".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetTransportTimeType(value);
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
		
		
		public void Write(ReceiveAddressInfo structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetAddressId() != null) {
				
				oprot.WriteFieldBegin("addressId");
				oprot.WriteI64((long)structs.GetAddressId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetAddressType() != null) {
				
				oprot.WriteFieldBegin("addressType");
				oprot.WriteI32((int)structs.GetAddressType()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTransportDays() != null) {
				
				oprot.WriteFieldBegin("transportDays");
				oprot.WriteI32((int)structs.GetTransportDays()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTransportTimeType() != null) {
				
				oprot.WriteFieldBegin("transportTimeType");
				oprot.WriteI32((int)structs.GetTransportTimeType()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(ReceiveAddressInfo bean){
			
			
		}
		
	}
	
}