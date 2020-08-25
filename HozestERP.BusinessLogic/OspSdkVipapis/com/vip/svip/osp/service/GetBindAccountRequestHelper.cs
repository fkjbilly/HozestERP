using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.svip.osp.service{
	
	
	
	public class GetBindAccountRequestHelper : TBeanSerializer<GetBindAccountRequest>
	{
		
		public static GetBindAccountRequestHelper OBJ = new GetBindAccountRequestHelper();
		
		public static GetBindAccountRequestHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(GetBindAccountRequest structs, Protocol iprot){
			
			
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
					
					
					
					
					
					if ("openId".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOpenId(value);
					}
					
					
					
					
					
					if ("openIdType".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetOpenIdType(value);
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
		
		
		public void Write(GetBindAccountRequest structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetUserId() != null) {
				
				oprot.WriteFieldBegin("userId");
				oprot.WriteI64((long)structs.GetUserId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOpenId() != null) {
				
				oprot.WriteFieldBegin("openId");
				oprot.WriteString(structs.GetOpenId());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOpenIdType() != null) {
				
				oprot.WriteFieldBegin("openIdType");
				oprot.WriteI32((int)structs.GetOpenIdType()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(GetBindAccountRequest bean){
			
			
		}
		
	}
	
}