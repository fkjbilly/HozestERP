using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.arplatform.face.service{
	
	
	
	public class ImageStylizationModelHelper : TBeanSerializer<ImageStylizationModel>
	{
		
		public static ImageStylizationModelHelper OBJ = new ImageStylizationModelHelper();
		
		public static ImageStylizationModelHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(ImageStylizationModel structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("imageInPath".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetImageInPath(value);
					}
					
					
					
					
					
					if ("imageOutPath".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetImageOutPath(value);
					}
					
					
					
					
					
					if ("type".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetType(value);
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
		
		
		public void Write(ImageStylizationModel structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetImageInPath() != null) {
				
				oprot.WriteFieldBegin("imageInPath");
				oprot.WriteString(structs.GetImageInPath());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetImageOutPath() != null) {
				
				oprot.WriteFieldBegin("imageOutPath");
				oprot.WriteString(structs.GetImageOutPath());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetType() != null) {
				
				oprot.WriteFieldBegin("type");
				oprot.WriteString(structs.GetType());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(ImageStylizationModel bean){
			
			
		}
		
	}
	
}