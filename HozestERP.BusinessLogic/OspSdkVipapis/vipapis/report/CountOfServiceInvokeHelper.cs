using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.report{
	
	
	
	public class CountOfServiceInvokeHelper : TBeanSerializer<CountOfServiceInvoke>
	{
		
		public static CountOfServiceInvokeHelper OBJ = new CountOfServiceInvokeHelper();
		
		public static CountOfServiceInvokeHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(CountOfServiceInvoke structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("invoke_date".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetInvoke_date(value);
					}
					
					
					
					
					
					if ("app_key".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetApp_key(value);
					}
					
					
					
					
					
					if ("ext_attr_name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetExt_attr_name(value);
					}
					
					
					
					
					
					if ("ext_attr_value".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetExt_attr_value(value);
					}
					
					
					
					
					
					if ("service_name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetService_name(value);
					}
					
					
					
					
					
					if ("method_name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetMethod_name(value);
					}
					
					
					
					
					
					if ("business_amount".Equals(schemeField.Trim())){
						
						needSkip = false;
						long value;
						value = iprot.ReadI64(); 
						
						structs.SetBusiness_amount(value);
					}
					
					
					
					
					
					if ("invoke_amount".Equals(schemeField.Trim())){
						
						needSkip = false;
						long value;
						value = iprot.ReadI64(); 
						
						structs.SetInvoke_amount(value);
					}
					
					
					
					
					
					if ("exception_amount".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetException_amount(value);
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
		
		
		public void Write(CountOfServiceInvoke structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetInvoke_date() != null) {
				
				oprot.WriteFieldBegin("invoke_date");
				oprot.WriteString(structs.GetInvoke_date());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("invoke_date can not be null!");
			}
			
			
			if(structs.GetApp_key() != null) {
				
				oprot.WriteFieldBegin("app_key");
				oprot.WriteString(structs.GetApp_key());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("app_key can not be null!");
			}
			
			
			if(structs.GetExt_attr_name() != null) {
				
				oprot.WriteFieldBegin("ext_attr_name");
				oprot.WriteString(structs.GetExt_attr_name());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("ext_attr_name can not be null!");
			}
			
			
			if(structs.GetExt_attr_value() != null) {
				
				oprot.WriteFieldBegin("ext_attr_value");
				oprot.WriteString(structs.GetExt_attr_value());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("ext_attr_value can not be null!");
			}
			
			
			if(structs.GetService_name() != null) {
				
				oprot.WriteFieldBegin("service_name");
				oprot.WriteString(structs.GetService_name());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("service_name can not be null!");
			}
			
			
			if(structs.GetMethod_name() != null) {
				
				oprot.WriteFieldBegin("method_name");
				oprot.WriteString(structs.GetMethod_name());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("method_name can not be null!");
			}
			
			
			if(structs.GetBusiness_amount() != null) {
				
				oprot.WriteFieldBegin("business_amount");
				oprot.WriteI64((long)structs.GetBusiness_amount()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("business_amount can not be null!");
			}
			
			
			if(structs.GetInvoke_amount() != null) {
				
				oprot.WriteFieldBegin("invoke_amount");
				oprot.WriteI64((long)structs.GetInvoke_amount()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("invoke_amount can not be null!");
			}
			
			
			if(structs.GetException_amount() != null) {
				
				oprot.WriteFieldBegin("exception_amount");
				oprot.WriteI64((long)structs.GetException_amount()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(CountOfServiceInvoke bean){
			
			
		}
		
	}
	
}