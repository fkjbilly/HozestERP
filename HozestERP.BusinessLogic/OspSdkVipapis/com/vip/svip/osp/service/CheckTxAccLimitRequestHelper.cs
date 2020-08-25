using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.svip.osp.service{
	
	
	
	public class CheckTxAccLimitRequestHelper : TBeanSerializer<CheckTxAccLimitRequest>
	{
		
		public static CheckTxAccLimitRequestHelper OBJ = new CheckTxAccLimitRequestHelper();
		
		public static CheckTxAccLimitRequestHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(CheckTxAccLimitRequest structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("userId".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetUserId(value);
					}
					
					
					
					
					
					if ("userIp".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetUserIp(value);
					}
					
					
					
					
					
					if ("mid".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetMid(value);
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
					
					
					
					
					
					if ("appId".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetAppId(value);
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
		
		
		public void Write(CheckTxAccLimitRequest structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetUserId() != null) {
				
				oprot.WriteFieldBegin("userId");
				oprot.WriteI64((long)structs.GetUserId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetUserIp() != null) {
				
				oprot.WriteFieldBegin("userIp");
				oprot.WriteString(structs.GetUserIp());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetMid() != null) {
				
				oprot.WriteFieldBegin("mid");
				oprot.WriteString(structs.GetMid());
				
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
			
			
			if(structs.GetAppId() != null) {
				
				oprot.WriteFieldBegin("appId");
				oprot.WriteString(structs.GetAppId());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(CheckTxAccLimitRequest bean){
			
			
		}
		
	}
	
}