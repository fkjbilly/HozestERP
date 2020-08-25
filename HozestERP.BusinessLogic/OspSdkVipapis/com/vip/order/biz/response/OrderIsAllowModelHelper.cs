using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.biz.response{
	
	
	
	public class OrderIsAllowModelHelper : TBeanSerializer<OrderIsAllowModel>
	{
		
		public static OrderIsAllowModelHelper OBJ = new OrderIsAllowModelHelper();
		
		public static OrderIsAllowModelHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(OrderIsAllowModel structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("isAllow".Equals(schemeField.Trim())){
						
						needSkip = false;
						bool? value;
						value = iprot.ReadBool();
						
						structs.SetIsAllow(value);
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
		
		
		public void Write(OrderIsAllowModel structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetIsAllow() != null) {
				
				oprot.WriteFieldBegin("isAllow");
				oprot.WriteBool((bool)structs.GetIsAllow());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(OrderIsAllowModel bean){
			
			
		}
		
	}
	
}