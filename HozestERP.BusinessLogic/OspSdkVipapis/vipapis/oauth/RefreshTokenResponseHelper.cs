using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.oauth{
	
	
	
	public class RefreshTokenResponseHelper : TBeanSerializer<RefreshTokenResponse>
	{
		
		public static RefreshTokenResponseHelper OBJ = new RefreshTokenResponseHelper();
		
		public static RefreshTokenResponseHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(RefreshTokenResponse structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("access_token".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetAccess_token(value);
					}
					
					
					
					
					
					if ("create_at".Equals(schemeField.Trim())){
						
						needSkip = false;
						System.DateTime? value;
						value = Osp.Sdk.Util.TimeUtil.FromUnixTime(iprot.ReadI64()); 
						
						structs.SetCreate_at(value);
					}
					
					
					
					
					
					if ("expires_in".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetExpires_in(value);
					}
					
					
					
					
					
					if ("expires_time".Equals(schemeField.Trim())){
						
						needSkip = false;
						System.DateTime? value;
						value = Osp.Sdk.Util.TimeUtil.FromUnixTime(iprot.ReadI64()); 
						
						structs.SetExpires_time(value);
					}
					
					
					
					
					
					if ("is_expired".Equals(schemeField.Trim())){
						
						needSkip = false;
						bool? value;
						value = iprot.ReadBool();
						
						structs.SetIs_expired(value);
					}
					
					
					
					
					
					if ("refresh_token".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetRefresh_token(value);
					}
					
					
					
					
					
					if ("refresh_expires_time".Equals(schemeField.Trim())){
						
						needSkip = false;
						System.DateTime? value;
						value = Osp.Sdk.Util.TimeUtil.FromUnixTime(iprot.ReadI64()); 
						
						structs.SetRefresh_expires_time(value);
					}
					
					
					
					
					
					if ("status".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetStatus(value);
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
		
		
		public void Write(RefreshTokenResponse structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetAccess_token() != null) {
				
				oprot.WriteFieldBegin("access_token");
				oprot.WriteString(structs.GetAccess_token());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCreate_at() != null) {
				
				oprot.WriteFieldBegin("create_at");
				oprot.WriteI64(Osp.Sdk.Util.TimeUtil.ToUnixTime((System.DateTime)structs.GetCreate_at())); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetExpires_in() != null) {
				
				oprot.WriteFieldBegin("expires_in");
				oprot.WriteI64((long)structs.GetExpires_in()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetExpires_time() != null) {
				
				oprot.WriteFieldBegin("expires_time");
				oprot.WriteI64(Osp.Sdk.Util.TimeUtil.ToUnixTime((System.DateTime)structs.GetExpires_time())); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetIs_expired() != null) {
				
				oprot.WriteFieldBegin("is_expired");
				oprot.WriteBool((bool)structs.GetIs_expired());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetRefresh_token() != null) {
				
				oprot.WriteFieldBegin("refresh_token");
				oprot.WriteString(structs.GetRefresh_token());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetRefresh_expires_time() != null) {
				
				oprot.WriteFieldBegin("refresh_expires_time");
				oprot.WriteI64(Osp.Sdk.Util.TimeUtil.ToUnixTime((System.DateTime)structs.GetRefresh_expires_time())); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetStatus() != null) {
				
				oprot.WriteFieldBegin("status");
				oprot.WriteString(structs.GetStatus());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(RefreshTokenResponse bean){
			
			
		}
		
	}
	
}