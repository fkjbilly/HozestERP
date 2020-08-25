using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.order{
	
	
	
	public class ChannelOrderResultHelper : BeanSerializer<ChannelOrderResult>
	{
		
		public static ChannelOrderResultHelper OBJ = new ChannelOrderResultHelper();
		
		public static ChannelOrderResultHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(ChannelOrderResult structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("order_sn".Equals(schemeField.Trim())){
						
						needSkip = false;
						long value;
						value = iprot.ReadI64(); 
						
						structs.SetOrder_sn(value);
					}
					
					
					
					
					
					if ("order_status".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOrder_status(value);
					}
					
					
					
					
					
					if ("carriage".Equals(schemeField.Trim())){
						
						needSkip = false;
						double? value;
						value = iprot.ReadDouble();
						
						structs.SetCarriage(value);
					}
					
					
					
					
					
					if ("money".Equals(schemeField.Trim())){
						
						needSkip = false;
						double? value;
						value = iprot.ReadDouble();
						
						structs.SetMoney(value);
					}
					
					
					
					
					
					if ("add_time".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetAdd_time(value);
					}
					
					
					
					
					
					if ("pay_time".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPay_time(value);
					}
					
					
					
					
					
					if ("update_time".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetUpdate_time(value);
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
		
		
		public void Write(ChannelOrderResult structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetOrder_sn() != null) {
				
				oprot.WriteFieldBegin("order_sn");
				oprot.WriteI64((long)structs.GetOrder_sn()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("order_sn can not be null!");
			}
			
			
			if(structs.GetOrder_status() != null) {
				
				oprot.WriteFieldBegin("order_status");
				oprot.WriteString(structs.GetOrder_status());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("order_status can not be null!");
			}
			
			
			if(structs.GetCarriage() != null) {
				
				oprot.WriteFieldBegin("carriage");
				oprot.WriteDouble((double)structs.GetCarriage());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetMoney() != null) {
				
				oprot.WriteFieldBegin("money");
				oprot.WriteDouble((double)structs.GetMoney());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetAdd_time() != null) {
				
				oprot.WriteFieldBegin("add_time");
				oprot.WriteString(structs.GetAdd_time());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPay_time() != null) {
				
				oprot.WriteFieldBegin("pay_time");
				oprot.WriteString(structs.GetPay_time());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetUpdate_time() != null) {
				
				oprot.WriteFieldBegin("update_time");
				oprot.WriteString(structs.GetUpdate_time());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(ChannelOrderResult bean){
			
			
		}
		
	}
	
}