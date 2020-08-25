using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.marketplace.product{
	
	
	
	public class ProductHelper : TBeanSerializer<Product>
	{
		
		public static ProductHelper OBJ = new ProductHelper();
		
		public static ProductHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(Product structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("spu_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSpu_id(value);
					}
					
					
					
					
					
					if ("outer_spu_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOuter_spu_id(value);
					}
					
					
					
					
					
					if ("title".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTitle(value);
					}
					
					
					
					
					
					if ("brand_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBrand_id(value);
					}
					
					
					
					
					
					if ("shelf_status".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetShelf_status(value);
					}
					
					
					
					
					
					if ("audit_status".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetAudit_status(value);
					}
					
					
					
					
					
					if ("first_category_name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetFirst_category_name(value);
					}
					
					
					
					
					
					if ("second_category_name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSecond_category_name(value);
					}
					
					
					
					
					
					if ("third_category_name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetThird_category_name(value);
					}
					
					
					
					
					
					if ("image_url".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetImage_url(value);
					}
					
					
					
					
					
					if ("sku_ids".Equals(schemeField.Trim())){
						
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
						
						structs.SetSku_ids(value);
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
		
		
		public void Write(Product structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetSpu_id() != null) {
				
				oprot.WriteFieldBegin("spu_id");
				oprot.WriteString(structs.GetSpu_id());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("spu_id can not be null!");
			}
			
			
			if(structs.GetOuter_spu_id() != null) {
				
				oprot.WriteFieldBegin("outer_spu_id");
				oprot.WriteString(structs.GetOuter_spu_id());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTitle() != null) {
				
				oprot.WriteFieldBegin("title");
				oprot.WriteString(structs.GetTitle());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBrand_id() != null) {
				
				oprot.WriteFieldBegin("brand_id");
				oprot.WriteString(structs.GetBrand_id());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetShelf_status() != null) {
				
				oprot.WriteFieldBegin("shelf_status");
				oprot.WriteString(structs.GetShelf_status());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetAudit_status() != null) {
				
				oprot.WriteFieldBegin("audit_status");
				oprot.WriteString(structs.GetAudit_status());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetFirst_category_name() != null) {
				
				oprot.WriteFieldBegin("first_category_name");
				oprot.WriteString(structs.GetFirst_category_name());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSecond_category_name() != null) {
				
				oprot.WriteFieldBegin("second_category_name");
				oprot.WriteString(structs.GetSecond_category_name());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetThird_category_name() != null) {
				
				oprot.WriteFieldBegin("third_category_name");
				oprot.WriteString(structs.GetThird_category_name());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetImage_url() != null) {
				
				oprot.WriteFieldBegin("image_url");
				oprot.WriteString(structs.GetImage_url());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSku_ids() != null) {
				
				oprot.WriteFieldBegin("sku_ids");
				
				oprot.WriteListBegin();
				foreach(string _item0 in structs.GetSku_ids()){
					
					oprot.WriteString(_item0);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(Product bean){
			
			
		}
		
	}
	
}