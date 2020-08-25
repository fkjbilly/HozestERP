using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.vipcard{
	
	
	
	public class CardNumberHelper : TBeanSerializer<CardNumber>
	{
		
		public static CardNumberHelper OBJ = new CardNumberHelper();
		
		public static CardNumberHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(CardNumber structs, Protocol iprot){
			
			
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
		
		
		public void Write(CardNumber structs, Protocol oprot){
			
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
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(CardNumber bean){
			
			
		}
		
	}
	
}