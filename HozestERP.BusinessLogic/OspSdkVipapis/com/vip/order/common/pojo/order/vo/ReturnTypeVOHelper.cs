using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.common.pojo.order.vo{
	
	
	
	public class ReturnTypeVOHelper : TBeanSerializer<ReturnTypeVO>
	{
		
		public static ReturnTypeVOHelper OBJ = new ReturnTypeVOHelper();
		
		public static ReturnTypeVOHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(ReturnTypeVO structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("type".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetType(value);
					}
					
					
					
					
					
					if ("wallet".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetWallet(value);
					}
					
					
					
					
					
					if ("giftMoney".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetGiftMoney(value);
					}
					
					
					
					
					
					if ("favMoney".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetFavMoney(value);
					}
					
					
					
					
					
					if ("creditCardMoney".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCreditCardMoney(value);
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
		
		
		public void Write(ReturnTypeVO structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetType() != null) {
				
				oprot.WriteFieldBegin("type");
				oprot.WriteString(structs.GetType());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetWallet() != null) {
				
				oprot.WriteFieldBegin("wallet");
				oprot.WriteString(structs.GetWallet());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetGiftMoney() != null) {
				
				oprot.WriteFieldBegin("giftMoney");
				oprot.WriteString(structs.GetGiftMoney());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetFavMoney() != null) {
				
				oprot.WriteFieldBegin("favMoney");
				oprot.WriteString(structs.GetFavMoney());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCreditCardMoney() != null) {
				
				oprot.WriteFieldBegin("creditCardMoney");
				oprot.WriteString(structs.GetCreditCardMoney());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(ReturnTypeVO bean){
			
			
		}
		
	}
	
}