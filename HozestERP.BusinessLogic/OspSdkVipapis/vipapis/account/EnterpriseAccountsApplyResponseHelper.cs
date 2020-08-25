using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.account{
	
	
	
	public class EnterpriseAccountsApplyResponseHelper : TBeanSerializer<EnterpriseAccountsApplyResponse>
	{
		
		public static EnterpriseAccountsApplyResponseHelper OBJ = new EnterpriseAccountsApplyResponseHelper();
		
		public static EnterpriseAccountsApplyResponseHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(EnterpriseAccountsApplyResponse structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("apply_fail".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.account.EnterpriseEmployeeApplyFail> value;
						
						value = new List<vipapis.account.EnterpriseEmployeeApplyFail>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.account.EnterpriseEmployeeApplyFail elem0;
								
								elem0 = new vipapis.account.EnterpriseEmployeeApplyFail();
								vipapis.account.EnterpriseEmployeeApplyFailHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetApply_fail(value);
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
		
		
		public void Write(EnterpriseAccountsApplyResponse structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetApply_fail() != null) {
				
				oprot.WriteFieldBegin("apply_fail");
				
				oprot.WriteListBegin();
				foreach(vipapis.account.EnterpriseEmployeeApplyFail _item0 in structs.GetApply_fail()){
					
					
					vipapis.account.EnterpriseEmployeeApplyFailHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("apply_fail can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(EnterpriseAccountsApplyResponse bean){
			
			
		}
		
	}
	
}