using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.biz.vo{
	
	
	
	public class OrderCodeVOHelper : TBeanSerializer<OrderCodeVO>
	{
		
		public static OrderCodeVOHelper OBJ = new OrderCodeVOHelper();
		
		public static OrderCodeVOHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(OrderCodeVO structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("orderCodeId".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetOrderCodeId(value);
					}
					
					
					
					
					
					if ("orderCode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOrderCode(value);
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
		
		
		public void Write(OrderCodeVO structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetOrderCodeId() != null) {
				
				oprot.WriteFieldBegin("orderCodeId");
				oprot.WriteI64((long)structs.GetOrderCodeId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderCode() != null) {
				
				oprot.WriteFieldBegin("orderCode");
				oprot.WriteString(structs.GetOrderCode());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(OrderCodeVO bean){
			
			
		}
		
	}
	
}