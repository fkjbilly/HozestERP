using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.biz.vo{
	
	
	
	public class OrderPayDetailVOHelper : TBeanSerializer<OrderPayDetailVO>
	{
		
		public static OrderPayDetailVOHelper OBJ = new OrderPayDetailVOHelper();
		
		public static OrderPayDetailVOHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(OrderPayDetailVO structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("payStatus".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetPayStatus(value);
					}
					
					
					
					
					
					if ("payType".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetPayType(value);
					}
					
					
					
					
					
					if ("payTime".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetPayTime(value);
					}
					
					
					
					
					
					if ("paySn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPaySn(value);
					}
					
					
					
					
					
					if ("payOperation".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetPayOperation(value);
					}
					
					
					
					
					
					if ("payMoney".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPayMoney(value);
					}
					
					
					
					
					
					if ("payId".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetPayId(value);
					}
					
					
					
					
					
					if ("payAccount".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPayAccount(value);
					}
					
					
					
					
					
					if ("orderScenario".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetOrderScenario(value);
					}
					
					
					
					
					
					if ("currency".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCurrency(value);
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
		
		
		public void Write(OrderPayDetailVO structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetPayStatus() != null) {
				
				oprot.WriteFieldBegin("payStatus");
				oprot.WriteI32((int)structs.GetPayStatus()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPayType() != null) {
				
				oprot.WriteFieldBegin("payType");
				oprot.WriteI32((int)structs.GetPayType()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPayTime() != null) {
				
				oprot.WriteFieldBegin("payTime");
				oprot.WriteI64((long)structs.GetPayTime()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPaySn() != null) {
				
				oprot.WriteFieldBegin("paySn");
				oprot.WriteString(structs.GetPaySn());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPayOperation() != null) {
				
				oprot.WriteFieldBegin("payOperation");
				oprot.WriteI32((int)structs.GetPayOperation()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPayMoney() != null) {
				
				oprot.WriteFieldBegin("payMoney");
				oprot.WriteString(structs.GetPayMoney());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPayId() != null) {
				
				oprot.WriteFieldBegin("payId");
				oprot.WriteI32((int)structs.GetPayId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPayAccount() != null) {
				
				oprot.WriteFieldBegin("payAccount");
				oprot.WriteString(structs.GetPayAccount());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderScenario() != null) {
				
				oprot.WriteFieldBegin("orderScenario");
				oprot.WriteI32((int)structs.GetOrderScenario()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCurrency() != null) {
				
				oprot.WriteFieldBegin("currency");
				oprot.WriteString(structs.GetCurrency());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(OrderPayDetailVO bean){
			
			
		}
		
	}
	
}