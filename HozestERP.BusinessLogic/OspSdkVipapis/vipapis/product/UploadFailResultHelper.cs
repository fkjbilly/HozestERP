using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.product{
	
	
	
	public class UploadFailResultHelper : TBeanSerializer<UploadFailResult>
	{
		
		public static UploadFailResultHelper OBJ = new UploadFailResultHelper();
		
		public static UploadFailResultHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(UploadFailResult structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("img_index".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetImg_index(value);
					}
					
					
					
					
					
					if ("error_msg".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetError_msg(value);
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
		
		
		public void Write(UploadFailResult structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetImg_index() != null) {
				
				oprot.WriteFieldBegin("img_index");
				oprot.WriteI32((int)structs.GetImg_index()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetError_msg() != null) {
				
				oprot.WriteFieldBegin("error_msg");
				oprot.WriteString(structs.GetError_msg());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(UploadFailResult bean){
			
			
		}
		
	}
	
}