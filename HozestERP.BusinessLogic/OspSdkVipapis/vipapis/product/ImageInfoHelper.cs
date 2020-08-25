using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.product{
	
	
	
	public class ImageInfoHelper : TBeanSerializer<ImageInfo>
	{
		
		public static ImageInfoHelper OBJ = new ImageInfoHelper();
		
		public static ImageInfoHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(ImageInfo structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("url".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetUrl(value);
					}
					
					
					
					
					
					if ("id".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetId(value);
					}
					
					
					
					
					
					if ("bind_url".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBind_url(value);
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
		
		
		public void Write(ImageInfo structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetUrl() != null) {
				
				oprot.WriteFieldBegin("url");
				oprot.WriteString(structs.GetUrl());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("url can not be null!");
			}
			
			
			if(structs.GetId() != null) {
				
				oprot.WriteFieldBegin("id");
				oprot.WriteString(structs.GetId());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("id can not be null!");
			}
			
			
			if(structs.GetBind_url() != null) {
				
				oprot.WriteFieldBegin("bind_url");
				oprot.WriteString(structs.GetBind_url());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(ImageInfo bean){
			
			
		}
		
	}
	
}