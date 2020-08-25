using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.arplatform.face.service{
	
	
	
	public class CartoonModelHelper : TBeanSerializer<CartoonModel>
	{
		
		public static CartoonModelHelper OBJ = new CartoonModelHelper();
		
		public static CartoonModelHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(CartoonModel structs, Protocol iprot){
			
			
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
					
					
					
					
					
					if ("faceUrl".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetFaceUrl(value);
					}
					
					
					
					
					
					if ("faceLessUrl".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetFaceLessUrl(value);
					}
					
					
					
					
					
					if ("cr".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetCr(value);
					}
					
					
					
					
					
					if ("cb".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetCb(value);
					}
					
					
					
					
					
					if ("point".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPoint(value);
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
		
		
		public void Write(CartoonModel structs, Protocol oprot){
			
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
			
			
			if(structs.GetFaceUrl() != null) {
				
				oprot.WriteFieldBegin("faceUrl");
				oprot.WriteString(structs.GetFaceUrl());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetFaceLessUrl() != null) {
				
				oprot.WriteFieldBegin("faceLessUrl");
				oprot.WriteString(structs.GetFaceLessUrl());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCr() != null) {
				
				oprot.WriteFieldBegin("cr");
				oprot.WriteI32((int)structs.GetCr()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCb() != null) {
				
				oprot.WriteFieldBegin("cb");
				oprot.WriteI32((int)structs.GetCb()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPoint() != null) {
				
				oprot.WriteFieldBegin("point");
				oprot.WriteString(structs.GetPoint());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(CartoonModel bean){
			
			
		}
		
	}
	
}