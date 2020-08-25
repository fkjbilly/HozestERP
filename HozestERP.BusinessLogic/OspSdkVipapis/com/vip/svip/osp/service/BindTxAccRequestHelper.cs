using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.svip.osp.service{
	
	
	
	public class BindTxAccRequestHelper : TBeanSerializer<BindTxAccRequest>
	{
		
		public static BindTxAccRequestHelper OBJ = new BindTxAccRequestHelper();
		
		public static BindTxAccRequestHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(BindTxAccRequest structs, Protocol iprot){
			
			
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
					
					
					
					
					
					if ("txFigureUrl".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTxFigureUrl(value);
					}
					
					
					
					
					
					if ("txNickName".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTxNickName(value);
					}
					
					
					
					
					
					if ("appId".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetAppId(value);
					}
					
					
					
					
					
					if ("dataSign".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetDataSign(value);
					}
					
					
					
					
					
					if ("accessToken".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetAccessToken(value);
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
		
		
		public void Write(BindTxAccRequest structs, Protocol oprot){
			
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
			
			
			if(structs.GetTxFigureUrl() != null) {
				
				oprot.WriteFieldBegin("txFigureUrl");
				oprot.WriteString(structs.GetTxFigureUrl());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTxNickName() != null) {
				
				oprot.WriteFieldBegin("txNickName");
				oprot.WriteString(structs.GetTxNickName());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetAppId() != null) {
				
				oprot.WriteFieldBegin("appId");
				oprot.WriteString(structs.GetAppId());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetDataSign() != null) {
				
				oprot.WriteFieldBegin("dataSign");
				oprot.WriteString(structs.GetDataSign());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetAccessToken() != null) {
				
				oprot.WriteFieldBegin("accessToken");
				oprot.WriteString(structs.GetAccessToken());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(BindTxAccRequest bean){
			
			
		}
		
	}
	
}