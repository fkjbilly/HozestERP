using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.product{
	
	
	
	public class ImageUrlHelper : BeanSerializer<ImageUrl>
	{
		
		public static ImageUrlHelper OBJ = new ImageUrlHelper();
		
		public static ImageUrlHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(ImageUrl structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("small_image".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSmall_image(value);
					}
					
					
					
					
					
					if ("middle_image".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetMiddle_image(value);
					}
					
					
					
					
					
					if ("big_image".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBig_image(value);
					}
					
					
					
					
					
					if ("list_image".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetList_image(value);
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
		
		
		public void Write(ImageUrl structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetSmall_image() != null) {
				
				oprot.WriteFieldBegin("small_image");
				oprot.WriteString(structs.GetSmall_image());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetMiddle_image() != null) {
				
				oprot.WriteFieldBegin("middle_image");
				oprot.WriteString(structs.GetMiddle_image());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBig_image() != null) {
				
				oprot.WriteFieldBegin("big_image");
				oprot.WriteString(structs.GetBig_image());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetList_image() != null) {
				
				oprot.WriteFieldBegin("list_image");
				oprot.WriteString(structs.GetList_image());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(ImageUrl bean){
			
			
		}
		
	}
	
}