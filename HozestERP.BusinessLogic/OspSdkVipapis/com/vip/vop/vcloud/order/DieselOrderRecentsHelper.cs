using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.vop.vcloud.order{
	
	
	
	public class DieselOrderRecentsHelper : TBeanSerializer<DieselOrderRecents>
	{
		
		public static DieselOrderRecentsHelper OBJ = new DieselOrderRecentsHelper();
		
		public static DieselOrderRecentsHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(DieselOrderRecents structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("type".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetType(value);
					}
					
					
					
					
					
					if ("incrementId".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetIncrementId(value);
					}
					
					
					
					
					
					if ("orderIncrementId".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOrderIncrementId(value);
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
		
		
		public void Write(DieselOrderRecents structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetType() != null) {
				
				oprot.WriteFieldBegin("type");
				oprot.WriteString(structs.GetType());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("type can not be null!");
			}
			
			
			if(structs.GetIncrementId() != null) {
				
				oprot.WriteFieldBegin("incrementId");
				oprot.WriteString(structs.GetIncrementId());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("incrementId can not be null!");
			}
			
			
			if(structs.GetOrderIncrementId() != null) {
				
				oprot.WriteFieldBegin("orderIncrementId");
				oprot.WriteString(structs.GetOrderIncrementId());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("orderIncrementId can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(DieselOrderRecents bean){
			
			
		}
		
	}
	
}