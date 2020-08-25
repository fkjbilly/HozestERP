using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.common.pojo.order.vo{
	
	
	
	public class OrderAfterSaleOpTypeVOHelper : TBeanSerializer<OrderAfterSaleOpTypeVO>
	{
		
		public static OrderAfterSaleOpTypeVOHelper OBJ = new OrderAfterSaleOpTypeVOHelper();
		
		public static OrderAfterSaleOpTypeVOHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(OrderAfterSaleOpTypeVO structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("opFlag".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetOpFlag(value);
					}
					
					
					
					
					
					if ("reasonCode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetReasonCode(value);
					}
					
					
					
					
					
					if ("reason".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetReason(value);
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
		
		
		public void Write(OrderAfterSaleOpTypeVO structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetOpFlag() != null) {
				
				oprot.WriteFieldBegin("opFlag");
				oprot.WriteI32((int)structs.GetOpFlag()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetReasonCode() != null) {
				
				oprot.WriteFieldBegin("reasonCode");
				oprot.WriteString(structs.GetReasonCode());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetReason() != null) {
				
				oprot.WriteFieldBegin("reason");
				oprot.WriteString(structs.GetReason());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(OrderAfterSaleOpTypeVO bean){
			
			
		}
		
	}
	
}