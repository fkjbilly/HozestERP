using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.account{
	
	
	
	public class EnterpriseEmployeeApplyFailHelper : TBeanSerializer<EnterpriseEmployeeApplyFail>
	{
		
		public static EnterpriseEmployeeApplyFailHelper OBJ = new EnterpriseEmployeeApplyFailHelper();
		
		public static EnterpriseEmployeeApplyFailHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(EnterpriseEmployeeApplyFail structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("apply_info".Equals(schemeField.Trim())){
						
						needSkip = false;
						vipapis.account.EnterpriseEmployeeApplyInfo value;
						
						value = new vipapis.account.EnterpriseEmployeeApplyInfo();
						vipapis.account.EnterpriseEmployeeApplyInfoHelper.getInstance().Read(value, iprot);
						
						structs.SetApply_info(value);
					}
					
					
					
					
					
					if ("error_msg".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetError_msg(value);
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
		
		
		public void Write(EnterpriseEmployeeApplyFail structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetApply_info() != null) {
				
				oprot.WriteFieldBegin("apply_info");
				
				vipapis.account.EnterpriseEmployeeApplyInfoHelper.getInstance().Write(structs.GetApply_info(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("apply_info can not be null!");
			}
			
			
			if(structs.GetError_msg() != null) {
				
				oprot.WriteFieldBegin("error_msg");
				oprot.WriteString(structs.GetError_msg());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("error_msg can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(EnterpriseEmployeeApplyFail bean){
			
			
		}
		
	}
	
}