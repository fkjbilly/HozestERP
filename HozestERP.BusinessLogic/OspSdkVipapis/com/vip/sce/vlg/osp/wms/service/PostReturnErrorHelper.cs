using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.sce.vlg.osp.wms.service{
	
	
	
	public class PostReturnErrorHelper : TBeanSerializer<PostReturnError>
	{
		
		public static PostReturnErrorHelper OBJ = new PostReturnErrorHelper();
		
		public static PostReturnErrorHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(PostReturnError structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("returnErrorId".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetReturnErrorId(value);
					}
					
					
					
					
					
					if ("returnErrorCode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetReturnErrorCode(value);
					}
					
					
					
					
					
					if ("retrunErrorMessage".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetRetrunErrorMessage(value);
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
		
		
		public void Write(PostReturnError structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetReturnErrorId() != null) {
				
				oprot.WriteFieldBegin("returnErrorId");
				oprot.WriteString(structs.GetReturnErrorId());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetReturnErrorCode() != null) {
				
				oprot.WriteFieldBegin("returnErrorCode");
				oprot.WriteString(structs.GetReturnErrorCode());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetRetrunErrorMessage() != null) {
				
				oprot.WriteFieldBegin("retrunErrorMessage");
				oprot.WriteString(structs.GetRetrunErrorMessage());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(PostReturnError bean){
			
			
		}
		
	}
	
}