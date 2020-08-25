using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.brand{
	
	
	
	public class BrandStoryHelper : TBeanSerializer<BrandStory>
	{
		
		public static BrandStoryHelper OBJ = new BrandStoryHelper();
		
		public static BrandStoryHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(BrandStory structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("brand_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBrand_id(value);
					}
					
					
					
					
					
					if ("cn_name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCn_name(value);
					}
					
					
					
					
					
					if ("en_name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetEn_name(value);
					}
					
					
					
					
					
					if ("logo_url".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetLogo_url(value);
					}
					
					
					
					
					
					if ("brand_url".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBrand_url(value);
					}
					
					
					
					
					
					if ("bg_path".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBg_path(value);
					}
					
					
					
					
					
					if ("bg_path_mobile".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBg_path_mobile(value);
					}
					
					
					
					
					
					if ("store_url_path".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetStore_url_path(value);
					}
					
					
					
					
					
					if ("description".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetDescription(value);
					}
					
					
					
					
					
					if ("brand_index".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBrand_index(value);
					}
					
					
					
					
					
					if ("brand_story_content".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBrand_story_content(value);
					}
					
					
					
					
					
					if ("showcase_pic_urls".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<string> value;
						
						value = new List<string>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								string elem0;
								elem0 = iprot.ReadString();
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetShowcase_pic_urls(value);
					}
					
					
					
					
					
					if ("exhibition_pic_urls".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<string> value;
						
						value = new List<string>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								string elem1;
								elem1 = iprot.ReadString();
								
								value.Add(elem1);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetExhibition_pic_urls(value);
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
		
		
		public void Write(BrandStory structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetBrand_id() != null) {
				
				oprot.WriteFieldBegin("brand_id");
				oprot.WriteString(structs.GetBrand_id());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("brand_id can not be null!");
			}
			
			
			if(structs.GetCn_name() != null) {
				
				oprot.WriteFieldBegin("cn_name");
				oprot.WriteString(structs.GetCn_name());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetEn_name() != null) {
				
				oprot.WriteFieldBegin("en_name");
				oprot.WriteString(structs.GetEn_name());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetLogo_url() != null) {
				
				oprot.WriteFieldBegin("logo_url");
				oprot.WriteString(structs.GetLogo_url());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBrand_url() != null) {
				
				oprot.WriteFieldBegin("brand_url");
				oprot.WriteString(structs.GetBrand_url());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBg_path() != null) {
				
				oprot.WriteFieldBegin("bg_path");
				oprot.WriteString(structs.GetBg_path());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBg_path_mobile() != null) {
				
				oprot.WriteFieldBegin("bg_path_mobile");
				oprot.WriteString(structs.GetBg_path_mobile());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetStore_url_path() != null) {
				
				oprot.WriteFieldBegin("store_url_path");
				oprot.WriteString(structs.GetStore_url_path());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetDescription() != null) {
				
				oprot.WriteFieldBegin("description");
				oprot.WriteString(structs.GetDescription());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBrand_index() != null) {
				
				oprot.WriteFieldBegin("brand_index");
				oprot.WriteString(structs.GetBrand_index());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBrand_story_content() != null) {
				
				oprot.WriteFieldBegin("brand_story_content");
				oprot.WriteString(structs.GetBrand_story_content());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetShowcase_pic_urls() != null) {
				
				oprot.WriteFieldBegin("showcase_pic_urls");
				
				oprot.WriteListBegin();
				foreach(string _item0 in structs.GetShowcase_pic_urls()){
					
					oprot.WriteString(_item0);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetExhibition_pic_urls() != null) {
				
				oprot.WriteFieldBegin("exhibition_pic_urls");
				
				oprot.WriteListBegin();
				foreach(string _item0 in structs.GetExhibition_pic_urls()){
					
					oprot.WriteString(_item0);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(BrandStory bean){
			
			
		}
		
	}
	
}