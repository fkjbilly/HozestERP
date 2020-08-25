using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.vipcard{
	
	
	
	public class GroupInfoHelper : TBeanSerializer<GroupInfo>
	{
		
		public static GroupInfoHelper OBJ = new GroupInfoHelper();
		
		public static GroupInfoHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(GroupInfo structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("id".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetId(value);
					}
					
					
					
					
					
					if ("activity_flag".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetActivity_flag(value);
					}
					
					
					
					
					
					if ("activity_name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetActivity_name(value);
					}
					
					
					
					
					
					if ("merchant_code".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetMerchant_code(value);
					}
					
					
					
					
					
					if ("total".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetTotal(value);
					}
					
					
					
					
					
					if ("money".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetMoney(value);
					}
					
					
					
					
					
					if ("finance_flag".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetFinance_flag(value);
					}
					
					
					
					
					
					if ("number_flag".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetNumber_flag(value);
					}
					
					
					
					
					
					if ("cancel_flag".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetCancel_flag(value);
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
		
		
		public void Write(GroupInfo structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetId() != null) {
				
				oprot.WriteFieldBegin("id");
				oprot.WriteI32((int)structs.GetId()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("id can not be null!");
			}
			
			
			if(structs.GetActivity_flag() != null) {
				
				oprot.WriteFieldBegin("activity_flag");
				oprot.WriteString(structs.GetActivity_flag());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("activity_flag can not be null!");
			}
			
			
			if(structs.GetActivity_name() != null) {
				
				oprot.WriteFieldBegin("activity_name");
				oprot.WriteString(structs.GetActivity_name());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("activity_name can not be null!");
			}
			
			
			if(structs.GetMerchant_code() != null) {
				
				oprot.WriteFieldBegin("merchant_code");
				oprot.WriteString(structs.GetMerchant_code());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("merchant_code can not be null!");
			}
			
			
			if(structs.GetTotal() != null) {
				
				oprot.WriteFieldBegin("total");
				oprot.WriteI32((int)structs.GetTotal()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("total can not be null!");
			}
			
			
			if(structs.GetMoney() != null) {
				
				oprot.WriteFieldBegin("money");
				oprot.WriteI32((int)structs.GetMoney()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("money can not be null!");
			}
			
			
			if(structs.GetFinance_flag() != null) {
				
				oprot.WriteFieldBegin("finance_flag");
				oprot.WriteI32((int)structs.GetFinance_flag()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("finance_flag can not be null!");
			}
			
			
			if(structs.GetNumber_flag() != null) {
				
				oprot.WriteFieldBegin("number_flag");
				oprot.WriteI32((int)structs.GetNumber_flag()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("number_flag can not be null!");
			}
			
			
			if(structs.GetCancel_flag() != null) {
				
				oprot.WriteFieldBegin("cancel_flag");
				oprot.WriteI32((int)structs.GetCancel_flag()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("cancel_flag can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(GroupInfo bean){
			
			
		}
		
	}
	
}