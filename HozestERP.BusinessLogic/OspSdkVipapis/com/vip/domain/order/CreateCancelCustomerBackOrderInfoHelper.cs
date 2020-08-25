using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.domain.order{
	
	
	
	public class CreateCancelCustomerBackOrderInfoHelper : TBeanSerializer<CreateCancelCustomerBackOrderInfo>
	{
		
		public static CreateCancelCustomerBackOrderInfoHelper OBJ = new CreateCancelCustomerBackOrderInfoHelper();
		
		public static CreateCancelCustomerBackOrderInfoHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(CreateCancelCustomerBackOrderInfo structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("transaction_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTransaction_id(value);
					}
					
					
					
					
					
					if ("erp_back_sn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetErp_back_sn(value);
					}
					
					
					
					
					
					if ("create_user".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCreate_user(value);
					}
					
					
					
					
					
					if ("remark".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetRemark(value);
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
		
		
		public void Write(CreateCancelCustomerBackOrderInfo structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetTransaction_id() != null) {
				
				oprot.WriteFieldBegin("transaction_id");
				oprot.WriteString(structs.GetTransaction_id());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("transaction_id can not be null!");
			}
			
			
			if(structs.GetErp_back_sn() != null) {
				
				oprot.WriteFieldBegin("erp_back_sn");
				oprot.WriteString(structs.GetErp_back_sn());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("erp_back_sn can not be null!");
			}
			
			
			if(structs.GetCreate_user() != null) {
				
				oprot.WriteFieldBegin("create_user");
				oprot.WriteString(structs.GetCreate_user());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("create_user can not be null!");
			}
			
			
			if(structs.GetRemark() != null) {
				
				oprot.WriteFieldBegin("remark");
				oprot.WriteString(structs.GetRemark());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(CreateCancelCustomerBackOrderInfo bean){
			
			
		}
		
	}
	
}