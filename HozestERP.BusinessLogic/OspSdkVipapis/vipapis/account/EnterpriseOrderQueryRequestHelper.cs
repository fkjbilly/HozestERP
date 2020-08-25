using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.account{
	
	
	
	public class EnterpriseOrderQueryRequestHelper : TBeanSerializer<EnterpriseOrderQueryRequest>
	{
		
		public static EnterpriseOrderQueryRequestHelper OBJ = new EnterpriseOrderQueryRequestHelper();
		
		public static EnterpriseOrderQueryRequestHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(EnterpriseOrderQueryRequest structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("enterprise_code".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetEnterprise_code(value);
					}
					
					
					
					
					
					if ("enterprise_employee_no".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetEnterprise_employee_no(value);
					}
					
					
					
					
					
					if ("start_time".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetStart_time(value);
					}
					
					
					
					
					
					if ("end_time".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetEnd_time(value);
					}
					
					
					
					
					
					if ("page".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetPage(value);
					}
					
					
					
					
					
					if ("limit".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetLimit(value);
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
		
		
		public void Write(EnterpriseOrderQueryRequest structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetEnterprise_code() != null) {
				
				oprot.WriteFieldBegin("enterprise_code");
				oprot.WriteString(structs.GetEnterprise_code());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("enterprise_code can not be null!");
			}
			
			
			if(structs.GetEnterprise_employee_no() != null) {
				
				oprot.WriteFieldBegin("enterprise_employee_no");
				oprot.WriteString(structs.GetEnterprise_employee_no());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetStart_time() != null) {
				
				oprot.WriteFieldBegin("start_time");
				oprot.WriteString(structs.GetStart_time());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetEnd_time() != null) {
				
				oprot.WriteFieldBegin("end_time");
				oprot.WriteString(structs.GetEnd_time());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPage() != null) {
				
				oprot.WriteFieldBegin("page");
				oprot.WriteI32((int)structs.GetPage()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("page can not be null!");
			}
			
			
			if(structs.GetLimit() != null) {
				
				oprot.WriteFieldBegin("limit");
				oprot.WriteI32((int)structs.GetLimit()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("limit can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(EnterpriseOrderQueryRequest bean){
			
			
		}
		
	}
	
}