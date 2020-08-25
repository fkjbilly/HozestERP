using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.oauth{
	
	
	
	public class RefreshTokenRequestHelper : TBeanSerializer<RefreshTokenRequest>
	{
		
		public static RefreshTokenRequestHelper OBJ = new RefreshTokenRequestHelper();
		
		public static RefreshTokenRequestHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(RefreshTokenRequest structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("refresh_token".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetRefresh_token(value);
					}
					
					
					
					
					
					if ("client_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetClient_id(value);
					}
					
					
					
					
					
					if ("client_secret".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetClient_secret(value);
					}
					
					
					
					
					
					if ("request_client_ip".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetRequest_client_ip(value);
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
		
		
		public void Write(RefreshTokenRequest structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetRefresh_token() != null) {
				
				oprot.WriteFieldBegin("refresh_token");
				oprot.WriteString(structs.GetRefresh_token());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("refresh_token can not be null!");
			}
			
			
			if(structs.GetClient_id() != null) {
				
				oprot.WriteFieldBegin("client_id");
				oprot.WriteString(structs.GetClient_id());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("client_id can not be null!");
			}
			
			
			if(structs.GetClient_secret() != null) {
				
				oprot.WriteFieldBegin("client_secret");
				oprot.WriteString(structs.GetClient_secret());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("client_secret can not be null!");
			}
			
			
			if(structs.GetRequest_client_ip() != null) {
				
				oprot.WriteFieldBegin("request_client_ip");
				oprot.WriteString(structs.GetRequest_client_ip());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("request_client_ip can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(RefreshTokenRequest bean){
			
			
		}
		
	}
	
}