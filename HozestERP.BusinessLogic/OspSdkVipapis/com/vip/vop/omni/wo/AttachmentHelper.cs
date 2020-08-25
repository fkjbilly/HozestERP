using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.vop.omni.wo{
	
	
	
	public class AttachmentHelper : TBeanSerializer<Attachment>
	{
		
		public static AttachmentHelper OBJ = new AttachmentHelper();
		
		public static AttachmentHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(Attachment structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("file_name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetFile_name(value);
					}
					
					
					
					
					
					if ("file_path".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetFile_path(value);
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
		
		
		public void Write(Attachment structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetFile_name() != null) {
				
				oprot.WriteFieldBegin("file_name");
				oprot.WriteString(structs.GetFile_name());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("file_name can not be null!");
			}
			
			
			if(structs.GetFile_path() != null) {
				
				oprot.WriteFieldBegin("file_path");
				oprot.WriteString(structs.GetFile_path());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("file_path can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(Attachment bean){
			
			
		}
		
	}
	
}