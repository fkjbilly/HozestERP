using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.biz.request{
	
	
	
	public class InvoiceInfoHelper : TBeanSerializer<InvoiceInfo>
	{
		
		public static InvoiceInfoHelper OBJ = new InvoiceInfoHelper();
		
		public static InvoiceInfoHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(InvoiceInfo structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("invoiceFlag".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetInvoiceFlag(value);
					}
					
					
					
					
					
					if ("invoiceHeader".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetInvoiceHeader(value);
					}
					
					
					
					
					
					if ("invoiceType".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetInvoiceType(value);
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
		
		
		public void Write(InvoiceInfo structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetInvoiceFlag() != null) {
				
				oprot.WriteFieldBegin("invoiceFlag");
				oprot.WriteI32((int)structs.GetInvoiceFlag()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetInvoiceHeader() != null) {
				
				oprot.WriteFieldBegin("invoiceHeader");
				oprot.WriteString(structs.GetInvoiceHeader());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetInvoiceType() != null) {
				
				oprot.WriteFieldBegin("invoiceType");
				oprot.WriteI32((int)structs.GetInvoiceType()); 
				
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
		
		
		public void Validate(InvoiceInfo bean){
			
			
		}
		
	}
	
}