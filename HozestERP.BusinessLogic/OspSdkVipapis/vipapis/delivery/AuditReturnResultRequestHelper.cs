using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.delivery{
	
	
	
	public class AuditReturnResultRequestHelper : TBeanSerializer<AuditReturnResultRequest>
	{
		
		public static AuditReturnResultRequestHelper OBJ = new AuditReturnResultRequestHelper();
		
		public static AuditReturnResultRequestHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(AuditReturnResultRequest structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("vendor_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						long value;
						value = iprot.ReadI64(); 
						
						structs.SetVendor_id(value);
					}
					
					
					
					
					
					if ("order_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOrder_id(value);
					}
					
					
					
					
					
					if ("order_return_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOrder_return_id(value);
					}
					
					
					
					
					
					if ("vendor_audit_stat".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetVendor_audit_stat(value);
					}
					
					
					
					
					
					if ("vendor_audit_opinion".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetVendor_audit_opinion(value);
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
		
		
		public void Write(AuditReturnResultRequest structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetVendor_id() != null) {
				
				oprot.WriteFieldBegin("vendor_id");
				oprot.WriteI64((long)structs.GetVendor_id()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("vendor_id can not be null!");
			}
			
			
			if(structs.GetOrder_id() != null) {
				
				oprot.WriteFieldBegin("order_id");
				oprot.WriteString(structs.GetOrder_id());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("order_id can not be null!");
			}
			
			
			if(structs.GetOrder_return_id() != null) {
				
				oprot.WriteFieldBegin("order_return_id");
				oprot.WriteString(structs.GetOrder_return_id());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("order_return_id can not be null!");
			}
			
			
			if(structs.GetVendor_audit_stat() != null) {
				
				oprot.WriteFieldBegin("vendor_audit_stat");
				oprot.WriteI32((int)structs.GetVendor_audit_stat()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("vendor_audit_stat can not be null!");
			}
			
			
			if(structs.GetVendor_audit_opinion() != null) {
				
				oprot.WriteFieldBegin("vendor_audit_opinion");
				oprot.WriteString(structs.GetVendor_audit_opinion());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(AuditReturnResultRequest bean){
			
			
		}
		
	}
	
}