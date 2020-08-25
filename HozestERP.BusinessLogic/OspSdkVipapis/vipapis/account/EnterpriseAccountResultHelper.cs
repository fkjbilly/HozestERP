using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.account{
	
	
	
	public class EnterpriseAccountResultHelper : TBeanSerializer<EnterpriseAccountResult>
	{
		
		public static EnterpriseAccountResultHelper OBJ = new EnterpriseAccountResultHelper();
		
		public static EnterpriseAccountResultHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(EnterpriseAccountResult structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("apply_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetApply_id(value);
					}
					
					
					
					
					
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
					
					
					
					
					
					if ("phone_no".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPhone_no(value);
					}
					
					
					
					
					
					if ("account_type".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetAccount_type(value);
					}
					
					
					
					
					
					if ("proc_state".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetProc_state(value);
					}
					
					
					
					
					
					if ("result_code".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetResult_code(value);
					}
					
					
					
					
					
					if ("result_desc".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetResult_desc(value);
					}
					
					
					
					
					
					if ("is_deleted".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetIs_deleted(value);
					}
					
					
					
					
					
					if ("create_time".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCreate_time(value);
					}
					
					
					
					
					
					if ("update_time".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetUpdate_time(value);
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
		
		
		public void Write(EnterpriseAccountResult structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetApply_id() != null) {
				
				oprot.WriteFieldBegin("apply_id");
				oprot.WriteI64((long)structs.GetApply_id()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetEnterprise_code() != null) {
				
				oprot.WriteFieldBegin("enterprise_code");
				oprot.WriteString(structs.GetEnterprise_code());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetEnterprise_employee_no() != null) {
				
				oprot.WriteFieldBegin("enterprise_employee_no");
				oprot.WriteString(structs.GetEnterprise_employee_no());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPhone_no() != null) {
				
				oprot.WriteFieldBegin("phone_no");
				oprot.WriteString(structs.GetPhone_no());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetAccount_type() != null) {
				
				oprot.WriteFieldBegin("account_type");
				oprot.WriteI32((int)structs.GetAccount_type()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetProc_state() != null) {
				
				oprot.WriteFieldBegin("proc_state");
				oprot.WriteI32((int)structs.GetProc_state()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetResult_code() != null) {
				
				oprot.WriteFieldBegin("result_code");
				oprot.WriteString(structs.GetResult_code());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetResult_desc() != null) {
				
				oprot.WriteFieldBegin("result_desc");
				oprot.WriteString(structs.GetResult_desc());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetIs_deleted() != null) {
				
				oprot.WriteFieldBegin("is_deleted");
				oprot.WriteI32((int)structs.GetIs_deleted()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCreate_time() != null) {
				
				oprot.WriteFieldBegin("create_time");
				oprot.WriteString(structs.GetCreate_time());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetUpdate_time() != null) {
				
				oprot.WriteFieldBegin("update_time");
				oprot.WriteString(structs.GetUpdate_time());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(EnterpriseAccountResult bean){
			
			
		}
		
	}
	
}