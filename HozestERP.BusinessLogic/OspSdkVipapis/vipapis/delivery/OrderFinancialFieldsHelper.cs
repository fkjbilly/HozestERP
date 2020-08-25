using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.delivery{
	
	
	
	public class OrderFinancialFieldsHelper : TBeanSerializer<OrderFinancialFields>
	{
		
		public static OrderFinancialFieldsHelper OBJ = new OrderFinancialFieldsHelper();
		
		public static OrderFinancialFieldsHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(OrderFinancialFields structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("order_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOrder_id(value);
					}
					
					
					
					
					
					if ("vip_order_total_amount".Equals(schemeField.Trim())){
						
						needSkip = false;
						double? value;
						value = iprot.ReadDouble();
						
						structs.SetVip_order_total_amount(value);
					}
					
					
					
					
					
					if ("carriage".Equals(schemeField.Trim())){
						
						needSkip = false;
						double? value;
						value = iprot.ReadDouble();
						
						structs.SetCarriage(value);
					}
					
					
					
					
					
					if ("vendor_discount".Equals(schemeField.Trim())){
						
						needSkip = false;
						double? value;
						value = iprot.ReadDouble();
						
						structs.SetVendor_discount(value);
					}
					
					
					
					
					
					if ("vip_total_deduction".Equals(schemeField.Trim())){
						
						needSkip = false;
						double? value;
						value = iprot.ReadDouble();
						
						structs.SetVip_total_deduction(value);
					}
					
					
					
					
					
					if ("actual_payment_amount".Equals(schemeField.Trim())){
						
						needSkip = false;
						double? value;
						value = iprot.ReadDouble();
						
						structs.SetActual_payment_amount(value);
					}
					
					
					
					
					
					if ("invoice_amount".Equals(schemeField.Trim())){
						
						needSkip = false;
						double? value;
						value = iprot.ReadDouble();
						
						structs.SetInvoice_amount(value);
					}
					
					
					
					
					
					if ("vip_card_amount".Equals(schemeField.Trim())){
						
						needSkip = false;
						double? value;
						value = iprot.ReadDouble();
						
						structs.SetVip_card_amount(value);
					}
					
					
					
					
					
					if ("pay_time".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetPay_time(value);
					}
					
					
					
					
					
					if ("invoice_type".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetInvoice_type(value);
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
		
		
		public void Write(OrderFinancialFields structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetOrder_id() != null) {
				
				oprot.WriteFieldBegin("order_id");
				oprot.WriteString(structs.GetOrder_id());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetVip_order_total_amount() != null) {
				
				oprot.WriteFieldBegin("vip_order_total_amount");
				oprot.WriteDouble((double)structs.GetVip_order_total_amount());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCarriage() != null) {
				
				oprot.WriteFieldBegin("carriage");
				oprot.WriteDouble((double)structs.GetCarriage());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetVendor_discount() != null) {
				
				oprot.WriteFieldBegin("vendor_discount");
				oprot.WriteDouble((double)structs.GetVendor_discount());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetVip_total_deduction() != null) {
				
				oprot.WriteFieldBegin("vip_total_deduction");
				oprot.WriteDouble((double)structs.GetVip_total_deduction());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetActual_payment_amount() != null) {
				
				oprot.WriteFieldBegin("actual_payment_amount");
				oprot.WriteDouble((double)structs.GetActual_payment_amount());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetInvoice_amount() != null) {
				
				oprot.WriteFieldBegin("invoice_amount");
				oprot.WriteDouble((double)structs.GetInvoice_amount());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetVip_card_amount() != null) {
				
				oprot.WriteFieldBegin("vip_card_amount");
				oprot.WriteDouble((double)structs.GetVip_card_amount());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPay_time() != null) {
				
				oprot.WriteFieldBegin("pay_time");
				oprot.WriteI64((long)structs.GetPay_time()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetInvoice_type() != null) {
				
				oprot.WriteFieldBegin("invoice_type");
				oprot.WriteString(structs.GetInvoice_type());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(OrderFinancialFields bean){
			
			
		}
		
	}
	
}