using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.common.pojo.order.vo{
	
	
	
	public class OrderBizExtAttrVOHelper : TBeanSerializer<OrderBizExtAttrVO>
	{
		
		public static OrderBizExtAttrVOHelper OBJ = new OrderBizExtAttrVOHelper();
		
		public static OrderBizExtAttrVOHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(OrderBizExtAttrVO structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("customBodyId".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetCustomBodyId(value);
					}
					
					
					
					
					
					if ("customId".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetCustomId(value);
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
		
		
		public void Write(OrderBizExtAttrVO structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetCustomBodyId() != null) {
				
				oprot.WriteFieldBegin("customBodyId");
				oprot.WriteI64((long)structs.GetCustomBodyId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCustomId() != null) {
				
				oprot.WriteFieldBegin("customId");
				oprot.WriteI64((long)structs.GetCustomId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(OrderBizExtAttrVO bean){
			
			
		}
		
	}
	
}