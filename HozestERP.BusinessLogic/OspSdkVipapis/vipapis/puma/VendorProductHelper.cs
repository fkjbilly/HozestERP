using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.puma{
	
	
	
	public class VendorProductHelper : TBeanSerializer<VendorProduct>
	{
		
		public static VendorProductHelper OBJ = new VendorProductHelper();
		
		public static VendorProductHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(VendorProduct structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("title".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTitle(value);
					}
					
					
					
					
					
					if ("image_url".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetImage_url(value);
					}
					
					
					
					
					
					if ("product_type".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetProduct_type(value);
					}
					
					
					
					
					
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
					
					
					
					
					
					if ("brand_cn_name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBrand_cn_name(value);
					}
					
					
					
					
					
					if ("brand_en_name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBrand_en_name(value);
					}
					
					
					
					
					
					if ("third_level_category_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetThird_level_category_id(value);
					}
					
					
					
					
					
					if ("third_level_category_name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetThird_level_category_name(value);
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
		
		
		public void Write(VendorProduct structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetTitle() != null) {
				
				oprot.WriteFieldBegin("title");
				oprot.WriteString(structs.GetTitle());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetImage_url() != null) {
				
				oprot.WriteFieldBegin("image_url");
				oprot.WriteString(structs.GetImage_url());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetProduct_type() != null) {
				
				oprot.WriteFieldBegin("product_type");
				oprot.WriteI32((int)structs.GetProduct_type()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBrand_id() != null) {
				
				oprot.WriteFieldBegin("brand_id");
				oprot.WriteString(structs.GetBrand_id());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBrand_name() != null) {
				
				oprot.WriteFieldBegin("brand_name");
				oprot.WriteString(structs.GetBrand_name());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBrand_cn_name() != null) {
				
				oprot.WriteFieldBegin("brand_cn_name");
				oprot.WriteString(structs.GetBrand_cn_name());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBrand_en_name() != null) {
				
				oprot.WriteFieldBegin("brand_en_name");
				oprot.WriteString(structs.GetBrand_en_name());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetThird_level_category_id() != null) {
				
				oprot.WriteFieldBegin("third_level_category_id");
				oprot.WriteI32((int)structs.GetThird_level_category_id()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetThird_level_category_name() != null) {
				
				oprot.WriteFieldBegin("third_level_category_name");
				oprot.WriteString(structs.GetThird_level_category_name());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(VendorProduct bean){
			
			
		}
		
	}
	
}