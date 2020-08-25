using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.svip.osp.service{
	
	
	
	public class OpenLimitRequestHelper : TBeanSerializer<OpenLimitRequest>
	{
		
		public static OpenLimitRequestHelper OBJ = new OpenLimitRequestHelper();
		
		public static OpenLimitRequestHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(OpenLimitRequest structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("openId".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOpenId(value);
					}
					
					
					
					
					
					if ("userIp".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetUserIp(value);
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
		
		
		public void Write(OpenLimitRequest structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetOpenId() != null) {
				
				oprot.WriteFieldBegin("openId");
				oprot.WriteString(structs.GetOpenId());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetUserIp() != null) {
				
				oprot.WriteFieldBegin("userIp");
				oprot.WriteString(structs.GetUserIp());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(OpenLimitRequest bean){
			
			
		}
		
	}
	
}