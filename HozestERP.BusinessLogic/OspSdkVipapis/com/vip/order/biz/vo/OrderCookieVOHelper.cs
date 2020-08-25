using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.biz.vo{
	
	
	
	public class OrderCookieVOHelper : TBeanSerializer<OrderCookieVO>
	{
		
		public static OrderCookieVOHelper OBJ = new OrderCookieVOHelper();
		
		public static OrderCookieVOHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(OrderCookieVO structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("phpsessionId".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPhpsessionId(value);
					}
					
					
					
					
					
					if ("marsCid".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetMarsCid(value);
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
		
		
		public void Write(OrderCookieVO structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetPhpsessionId() != null) {
				
				oprot.WriteFieldBegin("phpsessionId");
				oprot.WriteString(structs.GetPhpsessionId());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetMarsCid() != null) {
				
				oprot.WriteFieldBegin("marsCid");
				oprot.WriteString(structs.GetMarsCid());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(OrderCookieVO bean){
			
			
		}
		
	}
	
}