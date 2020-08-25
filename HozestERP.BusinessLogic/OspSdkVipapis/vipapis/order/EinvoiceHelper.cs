using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.order{
	
	
	
	public class EinvoiceHelper : TBeanSerializer<Einvoice>
	{
		
		public static EinvoiceHelper OBJ = new EinvoiceHelper();
		
		public static EinvoiceHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(Einvoice structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("e_invoice_url".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetE_invoice_url(value);
					}
					
					
					
					
					
					if ("e_invoice_code".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetE_invoice_code(value);
					}
					
					
					
					
					
					if ("e_invoice_serial_no".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetE_invoice_serial_no(value);
					}
					
					
					
					
					
					if ("vendor_tax_pay_no".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetVendor_tax_pay_no(value);
					}
					
					
					
					
					
					if ("is_writeback".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetIs_writeback(value);
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
		
		
		public void Write(Einvoice structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetE_invoice_url() != null) {
				
				oprot.WriteFieldBegin("e_invoice_url");
				oprot.WriteString(structs.GetE_invoice_url());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("e_invoice_url can not be null!");
			}
			
			
			if(structs.GetE_invoice_code() != null) {
				
				oprot.WriteFieldBegin("e_invoice_code");
				oprot.WriteString(structs.GetE_invoice_code());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("e_invoice_code can not be null!");
			}
			
			
			if(structs.GetE_invoice_serial_no() != null) {
				
				oprot.WriteFieldBegin("e_invoice_serial_no");
				oprot.WriteString(structs.GetE_invoice_serial_no());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("e_invoice_serial_no can not be null!");
			}
			
			
			if(structs.GetVendor_tax_pay_no() != null) {
				
				oprot.WriteFieldBegin("vendor_tax_pay_no");
				oprot.WriteString(structs.GetVendor_tax_pay_no());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("vendor_tax_pay_no can not be null!");
			}
			
			
			if(structs.GetIs_writeback() != null) {
				
				oprot.WriteFieldBegin("is_writeback");
				oprot.WriteString(structs.GetIs_writeback());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("is_writeback can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(Einvoice bean){
			
			
		}
		
	}
	
}