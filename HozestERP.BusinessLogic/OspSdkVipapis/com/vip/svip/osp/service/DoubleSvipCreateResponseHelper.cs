using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.svip.osp.service{
	
	
	
	public class DoubleSvipCreateResponseHelper : TBeanSerializer<DoubleSvipCreateResponse>
	{
		
		public static DoubleSvipCreateResponseHelper OBJ = new DoubleSvipCreateResponseHelper();
		
		public static DoubleSvipCreateResponseHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(DoubleSvipCreateResponse structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("code".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetCode(value);
					}
					
					
					
					
					
					if ("msg".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetMsg(value);
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
		
		
		public void Write(DoubleSvipCreateResponse structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetCode() != null) {
				
				oprot.WriteFieldBegin("code");
				oprot.WriteI32((int)structs.GetCode()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetMsg() != null) {
				
				oprot.WriteFieldBegin("msg");
				oprot.WriteString(structs.GetMsg());
				
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
		
		
		public void Validate(DoubleSvipCreateResponse bean){
			
			
		}
		
	}
	
}