using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.account{
	
	
	
	public class EnterpriseEmployeeApplyInfoHelper : TBeanSerializer<EnterpriseEmployeeApplyInfo>
	{
		
		public static EnterpriseEmployeeApplyInfoHelper OBJ = new EnterpriseEmployeeApplyInfoHelper();
		
		public static EnterpriseEmployeeApplyInfoHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(EnterpriseEmployeeApplyInfo structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("enterprise_employee_no".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetEnterprise_employee_no(value);
					}
					
					
					
					
					
					if ("phone_no".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPhone_no(value);
					}
					
					
					
					
					
					if ("account_type".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetAccount_type(value);
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
		
		
		public void Write(EnterpriseEmployeeApplyInfo structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetEnterprise_employee_no() != null) {
				
				oprot.WriteFieldBegin("enterprise_employee_no");
				oprot.WriteString(structs.GetEnterprise_employee_no());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("enterprise_employee_no can not be null!");
			}
			
			
			if(structs.GetPhone_no() != null) {
				
				oprot.WriteFieldBegin("phone_no");
				oprot.WriteString(structs.GetPhone_no());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("phone_no can not be null!");
			}
			
			
			if(structs.GetAccount_type() != null) {
				
				oprot.WriteFieldBegin("account_type");
				oprot.WriteI32((int)structs.GetAccount_type()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("account_type can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(EnterpriseEmployeeApplyInfo bean){
			
			
		}
		
	}
	
}