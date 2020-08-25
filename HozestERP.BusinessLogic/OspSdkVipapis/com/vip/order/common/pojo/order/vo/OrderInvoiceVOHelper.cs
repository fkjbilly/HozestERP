using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.common.pojo.order.vo{
	
	
	
	public class OrderInvoiceVOHelper : TBeanSerializer<OrderInvoiceVO>
	{
		
		public static OrderInvoiceVOHelper OBJ = new OrderInvoiceVOHelper();
		
		public static OrderInvoiceVOHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(OrderInvoiceVO structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("invoiceType".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetInvoiceType(value);
					}
					
					
					
					
					
					if ("invoice".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetInvoice(value);
					}
					
					
					
					
					
					if ("payMoney".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPayMoney(value);
					}
					
					
					
					
					
					if ("invoiceDeductMoney".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetInvoiceDeductMoney(value);
					}
					
					
					
					
					
					if ("payTime".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetPayTime(value);
					}
					
					
					
					
					
					if ("detail".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetDetail(value);
					}
					
					
					
					
					
					if ("orderId".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetOrderId(value);
					}
					
					
					
					
					
					if ("orderSn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOrderSn(value);
					}
					
					
					
					
					
					if ("taxPayerNo".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTaxPayerNo(value);
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
		
		
		public void Write(OrderInvoiceVO structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetInvoiceType() != null) {
				
				oprot.WriteFieldBegin("invoiceType");
				oprot.WriteI32((int)structs.GetInvoiceType()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetInvoice() != null) {
				
				oprot.WriteFieldBegin("invoice");
				oprot.WriteString(structs.GetInvoice());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPayMoney() != null) {
				
				oprot.WriteFieldBegin("payMoney");
				oprot.WriteString(structs.GetPayMoney());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetInvoiceDeductMoney() != null) {
				
				oprot.WriteFieldBegin("invoiceDeductMoney");
				oprot.WriteString(structs.GetInvoiceDeductMoney());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPayTime() != null) {
				
				oprot.WriteFieldBegin("payTime");
				oprot.WriteI64((long)structs.GetPayTime()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetDetail() != null) {
				
				oprot.WriteFieldBegin("detail");
				oprot.WriteString(structs.GetDetail());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderId() != null) {
				
				oprot.WriteFieldBegin("orderId");
				oprot.WriteI64((long)structs.GetOrderId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderSn() != null) {
				
				oprot.WriteFieldBegin("orderSn");
				oprot.WriteString(structs.GetOrderSn());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTaxPayerNo() != null) {
				
				oprot.WriteFieldBegin("taxPayerNo");
				oprot.WriteString(structs.GetTaxPayerNo());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(OrderInvoiceVO bean){
			
			
		}
		
	}
	
}