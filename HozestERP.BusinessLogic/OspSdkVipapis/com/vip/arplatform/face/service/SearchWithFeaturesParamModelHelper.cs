using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.arplatform.face.service{
	
	
	
	public class SearchWithFeaturesParamModelHelper : TBeanSerializer<SearchWithFeaturesParamModel>
	{
		
		public static SearchWithFeaturesParamModelHelper OBJ = new SearchWithFeaturesParamModelHelper();
		
		public static SearchWithFeaturesParamModelHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(SearchWithFeaturesParamModel structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("facesetKey".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetFacesetKey(value);
					}
					
					
					
					
					
					if ("imageUrl".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetImageUrl(value);
					}
					
					
					
					
					
					if ("opacity".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetOpacity(value);
					}
					
					
					
					
					
					if ("asynchronization".Equals(schemeField.Trim())){
						
						needSkip = false;
						byte? value;
						value = iprot.ReadByte(); 
						
						structs.SetAsynchronization(value);
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
		
		
		public void Write(SearchWithFeaturesParamModel structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetFacesetKey() != null) {
				
				oprot.WriteFieldBegin("facesetKey");
				oprot.WriteString(structs.GetFacesetKey());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("facesetKey can not be null!");
			}
			
			
			if(structs.GetImageUrl() != null) {
				
				oprot.WriteFieldBegin("imageUrl");
				oprot.WriteString(structs.GetImageUrl());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("imageUrl can not be null!");
			}
			
			
			if(structs.GetOpacity() != null) {
				
				oprot.WriteFieldBegin("opacity");
				oprot.WriteI32((int)structs.GetOpacity()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetAsynchronization() != null) {
				
				oprot.WriteFieldBegin("asynchronization");
				oprot.WriteByte((byte)structs.GetAsynchronization()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(SearchWithFeaturesParamModel bean){
			
			
		}
		
	}
	
}