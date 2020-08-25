using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.svip.osp.service{
	
	
	
	public class DoubleSvipTokenHelper : TBeanSerializer<DoubleSvipToken>
	{
		
		public static DoubleSvipTokenHelper OBJ = new DoubleSvipTokenHelper();
		
		public static DoubleSvipTokenHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(DoubleSvipToken structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("accessToken".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetAccessToken(value);
					}
					
					
					
					
					
					if ("svipToken".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSvipToken(value);
					}
					
					
					
					
					
					if ("expireTime".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetExpireTime(value);
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
		
		
		public void Write(DoubleSvipToken structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetAccessToken() != null) {
				
				oprot.WriteFieldBegin("accessToken");
				oprot.WriteString(structs.GetAccessToken());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSvipToken() != null) {
				
				oprot.WriteFieldBegin("svipToken");
				oprot.WriteString(structs.GetSvipToken());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetExpireTime() != null) {
				
				oprot.WriteFieldBegin("expireTime");
				oprot.WriteString(structs.GetExpireTime());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(DoubleSvipToken bean){
			
			
		}
		
	}
	
}