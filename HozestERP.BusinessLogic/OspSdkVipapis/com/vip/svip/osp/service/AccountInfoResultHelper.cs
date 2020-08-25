using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.svip.osp.service{
	
	
	
	public class AccountInfoResultHelper : TBeanSerializer<AccountInfoResult>
	{
		
		public static AccountInfoResultHelper OBJ = new AccountInfoResultHelper();
		
		public static AccountInfoResultHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(AccountInfoResult structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("vipAcc".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetVipAcc(value);
					}
					
					
					
					
					
					if ("vipFigureUrl".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetVipFigureUrl(value);
					}
					
					
					
					
					
					if ("txNickName".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTxNickName(value);
					}
					
					
					
					
					
					if ("txAccType".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetTxAccType(value);
					}
					
					
					
					
					
					if ("txOpenId".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTxOpenId(value);
					}
					
					
					
					
					
					if ("txFigureUrl".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTxFigureUrl(value);
					}
					
					
					
					
					
					if ("state".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetState(value);
					}
					
					
					
					
					
					if ("txAppId".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTxAppId(value);
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
		
		
		public void Write(AccountInfoResult structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetVipAcc() != null) {
				
				oprot.WriteFieldBegin("vipAcc");
				oprot.WriteString(structs.GetVipAcc());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetVipFigureUrl() != null) {
				
				oprot.WriteFieldBegin("vipFigureUrl");
				oprot.WriteString(structs.GetVipFigureUrl());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTxNickName() != null) {
				
				oprot.WriteFieldBegin("txNickName");
				oprot.WriteString(structs.GetTxNickName());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTxAccType() != null) {
				
				oprot.WriteFieldBegin("txAccType");
				oprot.WriteI32((int)structs.GetTxAccType()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("txAccType can not be null!");
			}
			
			
			if(structs.GetTxOpenId() != null) {
				
				oprot.WriteFieldBegin("txOpenId");
				oprot.WriteString(structs.GetTxOpenId());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTxFigureUrl() != null) {
				
				oprot.WriteFieldBegin("txFigureUrl");
				oprot.WriteString(structs.GetTxFigureUrl());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetState() != null) {
				
				oprot.WriteFieldBegin("state");
				oprot.WriteI32((int)structs.GetState()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("state can not be null!");
			}
			
			
			if(structs.GetTxAppId() != null) {
				
				oprot.WriteFieldBegin("txAppId");
				oprot.WriteString(structs.GetTxAppId());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(AccountInfoResult bean){
			
			
		}
		
	}
	
}