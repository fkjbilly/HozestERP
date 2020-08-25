using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.product{
	
	
	
	public class ProductSkuInfoHelper : TBeanSerializer<ProductSkuInfo>
	{
		
		public static ProductSkuInfoHelper OBJ = new ProductSkuInfoHelper();
		
		public static ProductSkuInfoHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(ProductSkuInfo structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("vendor_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetVendor_id(value);
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
					
					
					
					
					
					if ("product_name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetProduct_name(value);
					}
					
					
					
					
					
					if ("product_description".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetProduct_description(value);
					}
					
					
					
					
					
					if ("category_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetCategory_id(value);
					}
					
					
					
					
					
					if ("sn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSn(value);
					}
					
					
					
					
					
					if ("barcode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBarcode(value);
					}
					
					
					
					
					
					if ("product_props".Equals(schemeField.Trim())){
						
						needSkip = false;
						Dictionary<string, string> value;
						
						value = new Dictionary<string, string>();
						iprot.ReadMapBegin();
						while(true){
							
							try{
								
								string _key0;
								string _val0;
								_key0 = iprot.ReadString();
								
								_val0 = iprot.ReadString();
								
								value.Add(_key0, _val0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadMapEnd();
						
						structs.SetProduct_props(value);
					}
					
					
					
					
					
					if ("flat_sale_props".Equals(schemeField.Trim())){
						
						needSkip = false;
						Dictionary<string, string> value;
						
						value = new Dictionary<string, string>();
						iprot.ReadMapBegin();
						while(true){
							
							try{
								
								string _key1;
								string _val1;
								_key1 = iprot.ReadString();
								
								_val1 = iprot.ReadString();
								
								value.Add(_key1, _val1);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadMapEnd();
						
						structs.SetFlat_sale_props(value);
					}
					
					
					
					
					
					if ("market_price".Equals(schemeField.Trim())){
						
						needSkip = false;
						double? value;
						value = iprot.ReadDouble();
						
						structs.SetMarket_price(value);
					}
					
					
					
					
					
					if ("sell_price".Equals(schemeField.Trim())){
						
						needSkip = false;
						double? value;
						value = iprot.ReadDouble();
						
						structs.SetSell_price(value);
					}
					
					
					
					
					
					if ("tax_rate".Equals(schemeField.Trim())){
						
						needSkip = false;
						double? value;
						value = iprot.ReadDouble();
						
						structs.SetTax_rate(value);
					}
					
					
					
					
					
					if ("unit".Equals(schemeField.Trim())){
						
						needSkip = false;
						vipapis.product.Unit? value;
						
						value = vipapis.product.UnitUtil.FindByName(iprot.ReadString());
						
						structs.SetUnit(value);
					}
					
					
					
					
					
					if ("is_embargo".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetIs_embargo(value);
					}
					
					
					
					
					
					if ("is_fragile".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetIs_fragile(value);
					}
					
					
					
					
					
					if ("is_large".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetIs_large(value);
					}
					
					
					
					
					
					if ("is_precious".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetIs_precious(value);
					}
					
					
					
					
					
					if ("is_consumption_tax".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetIs_consumption_tax(value);
					}
					
					
					
					
					
					if ("is_makeup".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetIs_makeup(value);
					}
					
					
					
					
					
					if ("is_3d_try".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetIs_3d_try(value);
					}
					
					
					
					
					
					if ("is_need_valid".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetIs_need_valid(value);
					}
					
					
					
					
					
					if ("washing_instruct".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetWashing_instruct(value);
					}
					
					
					
					
					
					if ("sale_service".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSale_service(value);
					}
					
					
					
					
					
					if ("sub_title".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSub_title(value);
					}
					
					
					
					
					
					if ("accessory_info".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetAccessory_info(value);
					}
					
					
					
					
					
					if ("video_url".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetVideo_url(value);
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
					
					
					
					
					
					if ("small_image".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSmall_image(value);
					}
					
					
					
					
					
					if ("product_image".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetProduct_image(value);
					}
					
					
					
					
					
					if ("product_type".Equals(schemeField.Trim())){
						
						needSkip = false;
						vipapis.product.ProductType? value;
						
						value = vipapis.product.ProductTypeUtil.FindByName(iprot.ReadString());
						
						structs.SetProduct_type(value);
					}
					
					
					
					
					
					if ("size_table_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetSize_table_id(value);
					}
					
					
					
					
					
					if ("size_detail_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetSize_detail_id(value);
					}
					
					
					
					
					
					if ("currency".Equals(schemeField.Trim())){
						
						needSkip = false;
						vipapis.common.Currency? value;
						
						value = vipapis.common.CurrencyUtil.FindByName(iprot.ReadString());
						
						structs.SetCurrency(value);
					}
					
					
					
					
					
					if ("supply_price".Equals(schemeField.Trim())){
						
						needSkip = false;
						double? value;
						value = iprot.ReadDouble();
						
						structs.SetSupply_price(value);
					}
					
					
					
					
					
					if ("gross_weight".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetGross_weight(value);
					}
					
					
					
					
					
					if ("ogn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOgn(value);
					}
					
					
					
					
					
					if ("vendor_product_props".Equals(schemeField.Trim())){
						
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
						
						structs.SetVendor_product_props(value);
					}
					
					
					
					
					
					if ("spu_image_list".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.product.ProductImage> value;
						
						value = new List<vipapis.product.ProductImage>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.product.ProductImage elem3;
								
								elem3 = new vipapis.product.ProductImage();
								vipapis.product.ProductImageHelper.getInstance().Read(elem3, iprot);
								
								value.Add(elem3);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetSpu_image_list(value);
					}
					
					
					
					
					
					if ("color_image_list".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.product.ProductImage> value;
						
						value = new List<vipapis.product.ProductImage>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.product.ProductImage elem5;
								
								elem5 = new vipapis.product.ProductImage();
								vipapis.product.ProductImageHelper.getInstance().Read(elem5, iprot);
								
								value.Add(elem5);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetColor_image_list(value);
					}
					
					
					
					
					
					if ("group_sn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetGroup_sn(value);
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
		
		
		public void Write(ProductSkuInfo structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetVendor_id() != null) {
				
				oprot.WriteFieldBegin("vendor_id");
				oprot.WriteI32((int)structs.GetVendor_id()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("vendor_id can not be null!");
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
			
			
			if(structs.GetProduct_name() != null) {
				
				oprot.WriteFieldBegin("product_name");
				oprot.WriteString(structs.GetProduct_name());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetProduct_description() != null) {
				
				oprot.WriteFieldBegin("product_description");
				oprot.WriteString(structs.GetProduct_description());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCategory_id() != null) {
				
				oprot.WriteFieldBegin("category_id");
				oprot.WriteI32((int)structs.GetCategory_id()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSn() != null) {
				
				oprot.WriteFieldBegin("sn");
				oprot.WriteString(structs.GetSn());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBarcode() != null) {
				
				oprot.WriteFieldBegin("barcode");
				oprot.WriteString(structs.GetBarcode());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("barcode can not be null!");
			}
			
			
			if(structs.GetProduct_props() != null) {
				
				oprot.WriteFieldBegin("product_props");
				
				oprot.WriteMapBegin();
				foreach(KeyValuePair< string, string > _ir0 in structs.GetProduct_props()){
					
					string _key0 = _ir0.Key;
					string _value0 = _ir0.Value;
					oprot.WriteString(_key0);
					
					oprot.WriteString(_value0);
					
				}
				
				oprot.WriteMapEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetFlat_sale_props() != null) {
				
				oprot.WriteFieldBegin("flat_sale_props");
				
				oprot.WriteMapBegin();
				foreach(KeyValuePair< string, string > _ir0 in structs.GetFlat_sale_props()){
					
					string _key0 = _ir0.Key;
					string _value0 = _ir0.Value;
					oprot.WriteString(_key0);
					
					oprot.WriteString(_value0);
					
				}
				
				oprot.WriteMapEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetMarket_price() != null) {
				
				oprot.WriteFieldBegin("market_price");
				oprot.WriteDouble((double)structs.GetMarket_price());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSell_price() != null) {
				
				oprot.WriteFieldBegin("sell_price");
				oprot.WriteDouble((double)structs.GetSell_price());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTax_rate() != null) {
				
				oprot.WriteFieldBegin("tax_rate");
				oprot.WriteDouble((double)structs.GetTax_rate());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetUnit() != null) {
				
				oprot.WriteFieldBegin("unit");
				oprot.WriteString(structs.GetUnit().ToString());  
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetIs_embargo() != null) {
				
				oprot.WriteFieldBegin("is_embargo");
				oprot.WriteI32((int)structs.GetIs_embargo()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetIs_fragile() != null) {
				
				oprot.WriteFieldBegin("is_fragile");
				oprot.WriteI32((int)structs.GetIs_fragile()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetIs_large() != null) {
				
				oprot.WriteFieldBegin("is_large");
				oprot.WriteI32((int)structs.GetIs_large()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetIs_precious() != null) {
				
				oprot.WriteFieldBegin("is_precious");
				oprot.WriteI32((int)structs.GetIs_precious()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetIs_consumption_tax() != null) {
				
				oprot.WriteFieldBegin("is_consumption_tax");
				oprot.WriteI32((int)structs.GetIs_consumption_tax()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetIs_makeup() != null) {
				
				oprot.WriteFieldBegin("is_makeup");
				oprot.WriteI32((int)structs.GetIs_makeup()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetIs_3d_try() != null) {
				
				oprot.WriteFieldBegin("is_3d_try");
				oprot.WriteI32((int)structs.GetIs_3d_try()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetIs_need_valid() != null) {
				
				oprot.WriteFieldBegin("is_need_valid");
				oprot.WriteI32((int)structs.GetIs_need_valid()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetWashing_instruct() != null) {
				
				oprot.WriteFieldBegin("washing_instruct");
				oprot.WriteString(structs.GetWashing_instruct());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSale_service() != null) {
				
				oprot.WriteFieldBegin("sale_service");
				oprot.WriteString(structs.GetSale_service());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSub_title() != null) {
				
				oprot.WriteFieldBegin("sub_title");
				oprot.WriteString(structs.GetSub_title());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetAccessory_info() != null) {
				
				oprot.WriteFieldBegin("accessory_info");
				oprot.WriteString(structs.GetAccessory_info());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetVideo_url() != null) {
				
				oprot.WriteFieldBegin("video_url");
				oprot.WriteString(structs.GetVideo_url());
				
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
			
			
			if(structs.GetSmall_image() != null) {
				
				oprot.WriteFieldBegin("small_image");
				oprot.WriteString(structs.GetSmall_image());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetProduct_image() != null) {
				
				oprot.WriteFieldBegin("product_image");
				oprot.WriteString(structs.GetProduct_image());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetProduct_type() != null) {
				
				oprot.WriteFieldBegin("product_type");
				oprot.WriteString(structs.GetProduct_type().ToString());  
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSize_table_id() != null) {
				
				oprot.WriteFieldBegin("size_table_id");
				oprot.WriteI64((long)structs.GetSize_table_id()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSize_detail_id() != null) {
				
				oprot.WriteFieldBegin("size_detail_id");
				oprot.WriteI64((long)structs.GetSize_detail_id()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCurrency() != null) {
				
				oprot.WriteFieldBegin("currency");
				oprot.WriteString(structs.GetCurrency().ToString());  
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSupply_price() != null) {
				
				oprot.WriteFieldBegin("supply_price");
				oprot.WriteDouble((double)structs.GetSupply_price());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetGross_weight() != null) {
				
				oprot.WriteFieldBegin("gross_weight");
				oprot.WriteI32((int)structs.GetGross_weight()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOgn() != null) {
				
				oprot.WriteFieldBegin("ogn");
				oprot.WriteString(structs.GetOgn());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetVendor_product_props() != null) {
				
				oprot.WriteFieldBegin("vendor_product_props");
				
				oprot.WriteMapBegin();
				foreach(KeyValuePair< string, string > _ir0 in structs.GetVendor_product_props()){
					
					string _key0 = _ir0.Key;
					string _value0 = _ir0.Value;
					oprot.WriteString(_key0);
					
					oprot.WriteString(_value0);
					
				}
				
				oprot.WriteMapEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSpu_image_list() != null) {
				
				oprot.WriteFieldBegin("spu_image_list");
				
				oprot.WriteListBegin();
				foreach(vipapis.product.ProductImage _item0 in structs.GetSpu_image_list()){
					
					
					vipapis.product.ProductImageHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetColor_image_list() != null) {
				
				oprot.WriteFieldBegin("color_image_list");
				
				oprot.WriteListBegin();
				foreach(vipapis.product.ProductImage _item0 in structs.GetColor_image_list()){
					
					
					vipapis.product.ProductImageHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetGroup_sn() != null) {
				
				oprot.WriteFieldBegin("group_sn");
				oprot.WriteString(structs.GetGroup_sn());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(ProductSkuInfo bean){
			
			
		}
		
	}
	
}