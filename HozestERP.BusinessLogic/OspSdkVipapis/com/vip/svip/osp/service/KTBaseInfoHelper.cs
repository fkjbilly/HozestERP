using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.svip.osp.service{
	
	
	
	public class KTBaseInfoHelper : TBeanSerializer<KTBaseInfo>
	{
		
		public static KTBaseInfoHelper OBJ = new KTBaseInfoHelper();
		
		public static KTBaseInfoHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(KTBaseInfo structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("vpid".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetVpid(value);
					}
					
					
					
					
					
					if ("nickName".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetNickName(value);
					}
					
					
					
					
					
					if ("userStatus".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetUserStatus(value);
					}
					
					
					
					
					
					if ("canTrial".Equals(schemeField.Trim())){
						
						needSkip = false;
						bool value;
						value = iprot.ReadBool();
						
						structs.SetCanTrial(value);
					}
					
					
					
					
					
					if ("canOpen".Equals(schemeField.Trim())){
						
						needSkip = false;
						bool value;
						value = iprot.ReadBool();
						
						structs.SetCanOpen(value);
					}
					
					
					
					
					
					if ("expireTime".Equals(schemeField.Trim())){
						
						needSkip = false;
						long value;
						value = iprot.ReadI64(); 
						
						structs.SetExpireTime(value);
					}
					
					
					
					
					
					if ("remainingDays".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetRemainingDays(value);
					}
					
					
					
					
					
					if ("userLv".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetUserLv(value);
					}
					
					
					
					
					
					if ("averComp".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetAverComp(value);
					}
					
					
					
					
					
					if ("saveAmount".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSaveAmount(value);
					}
					
					
					
					
					
					if ("saveCarriageAmount".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSaveCarriageAmount(value);
					}
					
					
					
					
					
					if ("price".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPrice(value);
					}
					
					
					
					
					
					if ("updating".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetUpdating(value);
					}
					
					
					
					
					
					if ("imminentExpiry".Equals(schemeField.Trim())){
						
						needSkip = false;
						bool value;
						value = iprot.ReadBool();
						
						structs.SetImminentExpiry(value);
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
		
		
		public void Write(KTBaseInfo structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetVpid() != null) {
				
				oprot.WriteFieldBegin("vpid");
				oprot.WriteString(structs.GetVpid());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetNickName() != null) {
				
				oprot.WriteFieldBegin("nickName");
				oprot.WriteString(structs.GetNickName());
				
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
			
			
			if(structs.GetCanTrial() != null) {
				
				oprot.WriteFieldBegin("canTrial");
				oprot.WriteBool((bool)structs.GetCanTrial());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("canTrial can not be null!");
			}
			
			
			if(structs.GetCanOpen() != null) {
				
				oprot.WriteFieldBegin("canOpen");
				oprot.WriteBool((bool)structs.GetCanOpen());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("canOpen can not be null!");
			}
			
			
			if(structs.GetExpireTime() != null) {
				
				oprot.WriteFieldBegin("expireTime");
				oprot.WriteI64((long)structs.GetExpireTime()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("expireTime can not be null!");
			}
			
			
			if(structs.GetRemainingDays() != null) {
				
				oprot.WriteFieldBegin("remainingDays");
				oprot.WriteI32((int)structs.GetRemainingDays()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("remainingDays can not be null!");
			}
			
			
			if(structs.GetUserLv() != null) {
				
				oprot.WriteFieldBegin("userLv");
				oprot.WriteString(structs.GetUserLv());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetAverComp() != null) {
				
				oprot.WriteFieldBegin("averComp");
				oprot.WriteI32((int)structs.GetAverComp()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("averComp can not be null!");
			}
			
			
			if(structs.GetSaveAmount() != null) {
				
				oprot.WriteFieldBegin("saveAmount");
				oprot.WriteString(structs.GetSaveAmount());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSaveCarriageAmount() != null) {
				
				oprot.WriteFieldBegin("saveCarriageAmount");
				oprot.WriteString(structs.GetSaveCarriageAmount());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPrice() != null) {
				
				oprot.WriteFieldBegin("price");
				oprot.WriteString(structs.GetPrice());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetUpdating() != null) {
				
				oprot.WriteFieldBegin("updating");
				oprot.WriteI32((int)structs.GetUpdating()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("updating can not be null!");
			}
			
			
			if(structs.GetImminentExpiry() != null) {
				
				oprot.WriteFieldBegin("imminentExpiry");
				oprot.WriteBool((bool)structs.GetImminentExpiry());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("imminentExpiry can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(KTBaseInfo bean){
			
			
		}
		
	}
	
}