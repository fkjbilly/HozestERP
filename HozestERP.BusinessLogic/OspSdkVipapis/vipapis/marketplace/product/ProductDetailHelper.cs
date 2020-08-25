using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.marketplace.product{
	
	
	
	public class ProductDetailHelper : TBeanSerializer<ProductDetail>
	{
		
		public static ProductDetailHelper OBJ = new ProductDetailHelper();
		
		public static ProductDetailHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(ProductDetail structs, Protocol iprot){
			
			
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
					
					
					
					
					
					if ("skus".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.marketplace.product.SkuDetail> value;
						
						value = new List<vipapis.marketplace.product.SkuDetail>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.marketplace.product.SkuDetail elem0;
								
								elem0 = new vipapis.marketplace.product.SkuDetail();
								vipapis.marketplace.product.SkuDetailHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetSkus(value);
					}
					
					
					
					
					
					if ("title".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTitle(value);
					}
					
					
					
					
					
					if ("sub_title".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSub_title(value);
					}
					
					
					
					
					
					if ("prod_props".Equals(schemeField.Trim())){
						
						needSkip = false;
						Dictionary<string, string> value;
						
						value = new Dictionary<string, string>();
						iprot.ReadMapBegin();
						while(true){
							
							try{
								
								string _key2;
								string _val2;
								_key2 = iprot.ReadString();
								
								_val2 = iprot.ReadString();
								
								value.Add(_key2, _val2);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadMapEnd();
						
						structs.SetProd_props(value);
					}
					
					
					
					
					
					if ("custom_prod_props".Equals(schemeField.Trim())){
						
						needSkip = false;
						Dictionary<string, string> value;
						
						value = new Dictionary<string, string>();
						iprot.ReadMapBegin();
						while(true){
							
							try{
								
								string _key3;
								string _val3;
								_key3 = iprot.ReadString();
								
								_val3 = iprot.ReadString();
								
								value.Add(_key3, _val3);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadMapEnd();
						
						structs.SetCustom_prod_props(value);
					}
					
					
					
					
					
					if ("images".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.marketplace.product.Image> value;
						
						value = new List<vipapis.marketplace.product.Image>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.marketplace.product.Image elem4;
								
								elem4 = new vipapis.marketplace.product.Image();
								vipapis.marketplace.product.ImageHelper.getInstance().Read(elem4, iprot);
								
								value.Add(elem4);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetImages(value);
					}
					
					
					
					
					
					if ("area_output".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetArea_output(value);
					}
					
					
					
					
					
					if ("brand_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetBrand_id(value);
					}
					
					
					
					
					
					if ("brand_name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBrand_name(value);
					}
					
					
					
					
					
					if ("third_category_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetThird_category_id(value);
					}
					
					
					
					
					
					if ("sale_service".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSale_service(value);
					}
					
					
					
					
					
					if ("accessories".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetAccessories(value);
					}
					
					
					
					
					
					if ("length".Equals(schemeField.Trim())){
						
						needSkip = false;
						double? value;
						value = iprot.ReadDouble();
						
						structs.SetLength(value);
					}
					
					
					
					
					
					if ("width".Equals(schemeField.Trim())){
						
						needSkip = false;
						double? value;
						value = iprot.ReadDouble();
						
						structs.SetWidth(value);
					}
					
					
					
					
					
					if ("high".Equals(schemeField.Trim())){
						
						needSkip = false;
						double? value;
						value = iprot.ReadDouble();
						
						structs.SetHigh(value);
					}
					
					
					
					
					
					if ("weight".Equals(schemeField.Trim())){
						
						needSkip = false;
						double? value;
						value = iprot.ReadDouble();
						
						structs.SetWeight(value);
					}
					
					
					
					
					
					if ("audit_status".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetAudit_status(value);
					}
					
					
					
					
					
					if ("size_table_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetSize_table_id(value);
					}
					
					
					
					
					
					if ("gross_weight".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetGross_weight(value);
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
		
		
		public void Write(ProductDetail structs, Protocol oprot){
			
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
			
			
			if(structs.GetSkus() != null) {
				
				oprot.WriteFieldBegin("skus");
				
				oprot.WriteListBegin();
				foreach(vipapis.marketplace.product.SkuDetail _item0 in structs.GetSkus()){
					
					
					vipapis.marketplace.product.SkuDetailHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTitle() != null) {
				
				oprot.WriteFieldBegin("title");
				oprot.WriteString(structs.GetTitle());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSub_title() != null) {
				
				oprot.WriteFieldBegin("sub_title");
				oprot.WriteString(structs.GetSub_title());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetProd_props() != null) {
				
				oprot.WriteFieldBegin("prod_props");
				
				oprot.WriteMapBegin();
				foreach(KeyValuePair< string, string > _ir0 in structs.GetProd_props()){
					
					string _key0 = _ir0.Key;
					string _value0 = _ir0.Value;
					oprot.WriteString(_key0);
					
					oprot.WriteString(_value0);
					
				}
				
				oprot.WriteMapEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCustom_prod_props() != null) {
				
				oprot.WriteFieldBegin("custom_prod_props");
				
				oprot.WriteMapBegin();
				foreach(KeyValuePair< string, string > _ir0 in structs.GetCustom_prod_props()){
					
					string _key0 = _ir0.Key;
					string _value0 = _ir0.Value;
					oprot.WriteString(_key0);
					
					oprot.WriteString(_value0);
					
				}
				
				oprot.WriteMapEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetImages() != null) {
				
				oprot.WriteFieldBegin("images");
				
				oprot.WriteListBegin();
				foreach(vipapis.marketplace.product.Image _item0 in structs.GetImages()){
					
					
					vipapis.marketplace.product.ImageHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetArea_output() != null) {
				
				oprot.WriteFieldBegin("area_output");
				oprot.WriteString(structs.GetArea_output());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBrand_id() != null) {
				
				oprot.WriteFieldBegin("brand_id");
				oprot.WriteI32((int)structs.GetBrand_id()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBrand_name() != null) {
				
				oprot.WriteFieldBegin("brand_name");
				oprot.WriteString(structs.GetBrand_name());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetThird_category_id() != null) {
				
				oprot.WriteFieldBegin("third_category_id");
				oprot.WriteI32((int)structs.GetThird_category_id()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSale_service() != null) {
				
				oprot.WriteFieldBegin("sale_service");
				oprot.WriteString(structs.GetSale_service());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetAccessories() != null) {
				
				oprot.WriteFieldBegin("accessories");
				oprot.WriteString(structs.GetAccessories());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetLength() != null) {
				
				oprot.WriteFieldBegin("length");
				oprot.WriteDouble((double)structs.GetLength());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetWidth() != null) {
				
				oprot.WriteFieldBegin("width");
				oprot.WriteDouble((double)structs.GetWidth());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetHigh() != null) {
				
				oprot.WriteFieldBegin("high");
				oprot.WriteDouble((double)structs.GetHigh());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetWeight() != null) {
				
				oprot.WriteFieldBegin("weight");
				oprot.WriteDouble((double)structs.GetWeight());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetAudit_status() != null) {
				
				oprot.WriteFieldBegin("audit_status");
				oprot.WriteString(structs.GetAudit_status());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSize_table_id() != null) {
				
				oprot.WriteFieldBegin("size_table_id");
				oprot.WriteI64((long)structs.GetSize_table_id()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetGross_weight() != null) {
				
				oprot.WriteFieldBegin("gross_weight");
				oprot.WriteI32((int)structs.GetGross_weight()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(ProductDetail bean){
			
			
		}
		
	}
	
}