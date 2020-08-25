using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.vipcard{
	
	
	
	public class CardNumberListHelper : TBeanSerializer<CardNumberList>
	{
		
		public static CardNumberListHelper OBJ = new CardNumberListHelper();
		
		public static CardNumberListHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(CardNumberList structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("total".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetTotal(value);
					}
					
					
					
					
					
					if ("list".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.vipcard.CardNumber> value;
						
						value = new List<vipapis.vipcard.CardNumber>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.vipcard.CardNumber elem0;
								
								elem0 = new vipapis.vipcard.CardNumber();
								vipapis.vipcard.CardNumberHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetList(value);
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
		
		
		public void Write(CardNumberList structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetTotal() != null) {
				
				oprot.WriteFieldBegin("total");
				oprot.WriteI32((int)structs.GetTotal()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("total can not be null!");
			}
			
			
			if(structs.GetList() != null) {
				
				oprot.WriteFieldBegin("list");
				
				oprot.WriteListBegin();
				foreach(vipapis.vipcard.CardNumber _item0 in structs.GetList()){
					
					
					vipapis.vipcard.CardNumberHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("list can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(CardNumberList bean){
			
			
		}
		
	}
	
}