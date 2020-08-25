using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.account{
	
	
	
	public class EnterpriseAccountBatchUpdateRequestHelper : TBeanSerializer<EnterpriseAccountBatchUpdateRequest>
	{
		
		public static EnterpriseAccountBatchUpdateRequestHelper OBJ = new EnterpriseAccountBatchUpdateRequestHelper();
		
		public static EnterpriseAccountBatchUpdateRequestHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(EnterpriseAccountBatchUpdateRequest structs, Protocol iprot){
			
			
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
					
					
					
					
					
					if ("apply_employees".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.account.EnterpriseEmployeeApplyInfo> value;
						
						value = new List<vipapis.account.EnterpriseEmployeeApplyInfo>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.account.EnterpriseEmployeeApplyInfo elem0;
								
								elem0 = new vipapis.account.EnterpriseEmployeeApplyInfo();
								vipapis.account.EnterpriseEmployeeApplyInfoHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetApply_employees(value);
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
		
		
		public void Write(EnterpriseAccountBatchUpdateRequest structs, Protocol oprot){
			
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
			
			
			if(structs.GetApply_employees() != null) {
				
				oprot.WriteFieldBegin("apply_employees");
				
				oprot.WriteListBegin();
				foreach(vipapis.account.EnterpriseEmployeeApplyInfo _item0 in structs.GetApply_employees()){
					
					
					vipapis.account.EnterpriseEmployeeApplyInfoHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("apply_employees can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(EnterpriseAccountBatchUpdateRequest bean){
			
			
		}
		
	}
	
}