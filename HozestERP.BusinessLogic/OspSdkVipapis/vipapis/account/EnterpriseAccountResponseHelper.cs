using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.account{
	
	
	
	public class EnterpriseAccountResponseHelper : TBeanSerializer<EnterpriseAccountResponse>
	{
		
		public static EnterpriseAccountResponseHelper OBJ = new EnterpriseAccountResponseHelper();
		
		public static EnterpriseAccountResponseHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(EnterpriseAccountResponse structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("total_count".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetTotal_count(value);
					}
					
					
					
					
					
					if ("total_page".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetTotal_page(value);
					}
					
					
					
					
					
					if ("enterpriseAccounts".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.account.EnterpriseAccountResult> value;
						
						value = new List<vipapis.account.EnterpriseAccountResult>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.account.EnterpriseAccountResult elem0;
								
								elem0 = new vipapis.account.EnterpriseAccountResult();
								vipapis.account.EnterpriseAccountResultHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetEnterpriseAccounts(value);
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
		
		
		public void Write(EnterpriseAccountResponse structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetTotal_count() != null) {
				
				oprot.WriteFieldBegin("total_count");
				oprot.WriteI32((int)structs.GetTotal_count()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("total_count can not be null!");
			}
			
			
			if(structs.GetTotal_page() != null) {
				
				oprot.WriteFieldBegin("total_page");
				oprot.WriteI32((int)structs.GetTotal_page()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("total_page can not be null!");
			}
			
			
			if(structs.GetEnterpriseAccounts() != null) {
				
				oprot.WriteFieldBegin("enterpriseAccounts");
				
				oprot.WriteListBegin();
				foreach(vipapis.account.EnterpriseAccountResult _item0 in structs.GetEnterpriseAccounts()){
					
					
					vipapis.account.EnterpriseAccountResultHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("enterpriseAccounts can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(EnterpriseAccountResponse bean){
			
			
		}
		
	}
	
}