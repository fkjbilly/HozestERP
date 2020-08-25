using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.order{
	
	
	
	public class OrderInvoiceRespHelper : TBeanSerializer<OrderInvoiceResp>
	{
		
		public static OrderInvoiceRespHelper OBJ = new OrderInvoiceRespHelper();
		
		public static OrderInvoiceRespHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(OrderInvoiceResp structs, Protocol iprot){
			
			
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
					
					
					
					
					
					if ("package_no".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPackage_no(value);
					}
					
					
					
					
					
					if ("invoice_title".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetInvoice_title(value);
					}
					
					
					
					
					
					if ("invoice_amount".Equals(schemeField.Trim())){
						
						needSkip = false;
						double? value;
						value = iprot.ReadDouble();
						
						structs.SetInvoice_amount(value);
					}
					
					
					
					
					
					if ("invoice_type".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetInvoice_type(value);
					}
					
					
					
					
					
					if ("tax_pay_no".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTax_pay_no(value);
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
		
		
		public void Write(OrderInvoiceResp structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetOrder_id() != null) {
				
				oprot.WriteFieldBegin("order_id");
				oprot.WriteString(structs.GetOrder_id());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("order_id can not be null!");
			}
			
			
			if(structs.GetPackage_no() != null) {
				
				oprot.WriteFieldBegin("package_no");
				oprot.WriteString(structs.GetPackage_no());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetInvoice_title() != null) {
				
				oprot.WriteFieldBegin("invoice_title");
				oprot.WriteString(structs.GetInvoice_title());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetInvoice_amount() != null) {
				
				oprot.WriteFieldBegin("invoice_amount");
				oprot.WriteDouble((double)structs.GetInvoice_amount());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetInvoice_type() != null) {
				
				oprot.WriteFieldBegin("invoice_type");
				oprot.WriteI32((int)structs.GetInvoice_type()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTax_pay_no() != null) {
				
				oprot.WriteFieldBegin("tax_pay_no");
				oprot.WriteString(structs.GetTax_pay_no());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(OrderInvoiceResp bean){
			
			
		}
		
	}
	
}