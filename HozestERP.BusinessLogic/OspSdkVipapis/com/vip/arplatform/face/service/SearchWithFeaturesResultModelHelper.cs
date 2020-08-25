using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.arplatform.face.service{
	
	
	
	public class SearchWithFeaturesResultModelHelper : TBeanSerializer<SearchWithFeaturesResultModel>
	{
		
		public static SearchWithFeaturesResultModelHelper OBJ = new SearchWithFeaturesResultModelHelper();
		
		public static SearchWithFeaturesResultModelHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(SearchWithFeaturesResultModel structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("token".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetToken(value);
					}
					
					
					
					
					
					if ("image_src_mix".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetImage_src_mix(value);
					}
					
					
					
					
					
					if ("image_target_mix".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetImage_target_mix(value);
					}
					
					
					
					
					
					if ("image_url".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetImage_url(value);
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
		
		
		public void Write(SearchWithFeaturesResultModel structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetToken() != null) {
				
				oprot.WriteFieldBegin("token");
				oprot.WriteString(structs.GetToken());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetImage_src_mix() != null) {
				
				oprot.WriteFieldBegin("image_src_mix");
				oprot.WriteString(structs.GetImage_src_mix());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetImage_target_mix() != null) {
				
				oprot.WriteFieldBegin("image_target_mix");
				oprot.WriteString(structs.GetImage_target_mix());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetImage_url() != null) {
				
				oprot.WriteFieldBegin("image_url");
				oprot.WriteString(structs.GetImage_url());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(SearchWithFeaturesResultModel bean){
			
			
		}
		
	}
	
}