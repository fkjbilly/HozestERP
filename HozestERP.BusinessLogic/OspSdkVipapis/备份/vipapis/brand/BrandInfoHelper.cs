using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.brand{
	
	
	
	public class BrandInfoHelper : BeanSerializer<BrandInfo>
	{
		
		public static BrandInfoHelper OBJ = new BrandInfoHelper();
		
		public static BrandInfoHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(BrandInfo structs, Protocol iprot){
			
			
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
					
					
					
					
					
					if ("brand_name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBrand_name(value);
					}
					
					
					
					
					
					if ("brand_name_eng".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBrand_name_eng(value);
					}
					
					
					
					
					
					if ("brand_name_pinyin".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBrand_name_pinyin(value);
					}
					
					
					
					
					
					if ("brand_logo".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBrand_logo(value);
					}
					
					
					
					
					
					if ("brand_description".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBrand_description(value);
					}
					
					
					
					
					
					if ("brand_url".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBrand_url(value);
					}
					
					
					
					
					
					if ("brand_level".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBrand_level(value);
					}
					
					
					
					
					
					if ("last_modify_time".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetLast_modify_time(value);
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
		
		
		public void Write(BrandInfo structs, Protocol oprot){
			
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
			
			
			if(structs.GetBrand_name() != null) {
				
				oprot.WriteFieldBegin("brand_name");
				oprot.WriteString(structs.GetBrand_name());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBrand_name_eng() != null) {
				
				oprot.WriteFieldBegin("brand_name_eng");
				oprot.WriteString(structs.GetBrand_name_eng());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBrand_name_pinyin() != null) {
				
				oprot.WriteFieldBegin("brand_name_pinyin");
				oprot.WriteString(structs.GetBrand_name_pinyin());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBrand_logo() != null) {
				
				oprot.WriteFieldBegin("brand_logo");
				oprot.WriteString(structs.GetBrand_logo());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBrand_description() != null) {
				
				oprot.WriteFieldBegin("brand_description");
				oprot.WriteString(structs.GetBrand_description());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBrand_url() != null) {
				
				oprot.WriteFieldBegin("brand_url");
				oprot.WriteString(structs.GetBrand_url());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBrand_level() != null) {
				
				oprot.WriteFieldBegin("brand_level");
				oprot.WriteString(structs.GetBrand_level());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetLast_modify_time() != null) {
				
				oprot.WriteFieldBegin("last_modify_time");
				oprot.WriteString(structs.GetLast_modify_time());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(BrandInfo bean){
			
			
		}
		
	}
	
}