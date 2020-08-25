using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.product{
	
	
	
	public class UploadImageInfoHelper : TBeanSerializer<UploadImageInfo>
	{
		
		public static UploadImageInfoHelper OBJ = new UploadImageInfoHelper();
		
		public static UploadImageInfoHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(UploadImageInfo structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("img_content".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetImg_content(value);
					}
					
					
					
					
					
					if ("padding_left".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetPadding_left(value);
					}
					
					
					
					
					
					if ("padding_top".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetPadding_top(value);
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
		
		
		public void Write(UploadImageInfo structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetImg_content() != null) {
				
				oprot.WriteFieldBegin("img_content");
				oprot.WriteString(structs.GetImg_content());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("img_content can not be null!");
			}
			
			
			if(structs.GetPadding_left() != null) {
				
				oprot.WriteFieldBegin("padding_left");
				oprot.WriteI32((int)structs.GetPadding_left()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPadding_top() != null) {
				
				oprot.WriteFieldBegin("padding_top");
				oprot.WriteI32((int)structs.GetPadding_top()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(UploadImageInfo bean){
			
			
		}
		
	}
	
}