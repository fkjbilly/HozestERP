using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.order{
	
	
	
	public class EInvoiceInfoHelper : TBeanSerializer<EInvoiceInfo>
	{
		
		public static EInvoiceInfoHelper OBJ = new EInvoiceInfoHelper();
		
		public static EInvoiceInfoHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(EInvoiceInfo structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("orderId".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOrderId(value);
					}
					
					
					
					
					
					if ("status".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetStatus(value);
					}
					
					
					
					
					
					if ("eInvoiceCode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetEInvoiceCode(value);
					}
					
					
					
					
					
					if ("eInvoiceSerialNo".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetEInvoiceSerialNo(value);
					}
					
					
					
					
					
					if ("msg".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetMsg(value);
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
		
		
		public void Write(EInvoiceInfo structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetOrderId() != null) {
				
				oprot.WriteFieldBegin("orderId");
				oprot.WriteString(structs.GetOrderId());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetStatus() != null) {
				
				oprot.WriteFieldBegin("status");
				oprot.WriteI32((int)structs.GetStatus()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetEInvoiceCode() != null) {
				
				oprot.WriteFieldBegin("eInvoiceCode");
				oprot.WriteString(structs.GetEInvoiceCode());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetEInvoiceSerialNo() != null) {
				
				oprot.WriteFieldBegin("eInvoiceSerialNo");
				oprot.WriteString(structs.GetEInvoiceSerialNo());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetMsg() != null) {
				
				oprot.WriteFieldBegin("msg");
				oprot.WriteString(structs.GetMsg());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(EInvoiceInfo bean){
			
			
		}
		
	}
	
}