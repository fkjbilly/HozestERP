using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.svip.osp.service{
	
	
	
	public class BuyLimitStateHelper : TBeanSerializer<BuyLimitState>
	{
		
		public static BuyLimitStateHelper OBJ = new BuyLimitStateHelper();
		
		public static BuyLimitStateHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(BuyLimitState structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("limit".Equals(schemeField.Trim())){
						
						needSkip = false;
						bool value;
						value = iprot.ReadBool();
						
						structs.SetLimit(value);
					}
					
					
					
					
					
					if ("limitState".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetLimitState(value);
					}
					
					
					
					
					
					if ("limitMsg".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetLimitMsg(value);
					}
					
					
					
					
					
					if ("userStatus".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetUserStatus(value);
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
		
		
		public void Write(BuyLimitState structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetLimit() != null) {
				
				oprot.WriteFieldBegin("limit");
				oprot.WriteBool((bool)structs.GetLimit());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("limit can not be null!");
			}
			
			
			if(structs.GetLimitState() != null) {
				
				oprot.WriteFieldBegin("limitState");
				oprot.WriteI32((int)structs.GetLimitState()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("limitState can not be null!");
			}
			
			
			if(structs.GetLimitMsg() != null) {
				
				oprot.WriteFieldBegin("limitMsg");
				oprot.WriteString(structs.GetLimitMsg());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetUserStatus() != null) {
				
				oprot.WriteFieldBegin("userStatus");
				oprot.WriteI32((int)structs.GetUserStatus()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("userStatus can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(BuyLimitState bean){
			
			
		}
		
	}
	
}