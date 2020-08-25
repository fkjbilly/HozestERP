using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.svip.osp.service{
	
	
	
	public class DoubleSvipStatusHelper : TBeanSerializer<DoubleSvipStatus>
	{
		
		public static DoubleSvipStatusHelper OBJ = new DoubleSvipStatusHelper();
		
		public static DoubleSvipStatusHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(DoubleSvipStatus structs, Protocol iprot){
			
			
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
					
					
					
					
					
					if ("token".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.svip.osp.service.DoubleSvipToken value;
						
						value = new com.vip.svip.osp.service.DoubleSvipToken();
						com.vip.svip.osp.service.DoubleSvipTokenHelper.getInstance().Read(value, iprot);
						
						structs.SetToken(value);
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
		
		
		public void Write(DoubleSvipStatus structs, Protocol oprot){
			
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
			
			
			if(structs.GetToken() != null) {
				
				oprot.WriteFieldBegin("token");
				
				com.vip.svip.osp.service.DoubleSvipTokenHelper.getInstance().Write(structs.GetToken(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(DoubleSvipStatus bean){
			
			
		}
		
	}
	
}