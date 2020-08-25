using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.biz.request{
	
	
	
	public class OrderByHelper : TBeanSerializer<OrderBy>
	{
		
		public static OrderByHelper OBJ = new OrderByHelper();
		
		public static OrderByHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(OrderBy structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("field".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetField(value);
					}
					
					
					
					
					
					if ("direction".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetDirection(value);
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
		
		
		public void Write(OrderBy structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetField() != null) {
				
				oprot.WriteFieldBegin("field");
				oprot.WriteString(structs.GetField());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetDirection() != null) {
				
				oprot.WriteFieldBegin("direction");
				oprot.WriteString(structs.GetDirection());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(OrderBy bean){
			
			
		}
		
	}
	
}