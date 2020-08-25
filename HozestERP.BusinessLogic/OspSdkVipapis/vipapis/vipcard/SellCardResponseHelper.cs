using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.vipcard{
	
	
	
	public class SellCardResponseHelper : TBeanSerializer<SellCardResponse>
	{
		
		public static SellCardResponseHelper OBJ = new SellCardResponseHelper();
		
		public static SellCardResponseHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(SellCardResponse structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("card_code".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCard_code(value);
					}
					
					
					
					
					
					if ("money".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetMoney(value);
					}
					
					
					
					
					
					if ("activate_code".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetActivate_code(value);
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
		
		
		public void Write(SellCardResponse structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetCard_code() != null) {
				
				oprot.WriteFieldBegin("card_code");
				oprot.WriteString(structs.GetCard_code());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("card_code can not be null!");
			}
			
			
			if(structs.GetMoney() != null) {
				
				oprot.WriteFieldBegin("money");
				oprot.WriteString(structs.GetMoney());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("money can not be null!");
			}
			
			
			if(structs.GetActivate_code() != null) {
				
				oprot.WriteFieldBegin("activate_code");
				oprot.WriteString(structs.GetActivate_code());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(SellCardResponse bean){
			
			
		}
		
	}
	
}