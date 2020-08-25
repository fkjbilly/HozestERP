using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.marketplace.product{
	
	
	
	public class AddProductRequestHelper : TBeanSerializer<AddProductRequest>
	{
		
		public static AddProductRequestHelper OBJ = new AddProductRequestHelper();
		
		public static AddProductRequestHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(AddProductRequest structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
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
					
					
					
					
					
					if ("third_category_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetThird_category_id(value);
					}
					
					
					
					
					
					if ("brand_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetBrand_id(value);
					}
					
					
					
					
					
					if ("images".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.marketplace.product.Image> value;
						
						value = new List<vipapis.marketplace.product.Image>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.marketplace.product.Image elem1;
								
								elem1 = new vipapis.marketplace.product.Image();
								vipapis.marketplace.product.ImageHelper.getInstance().Read(elem1, iprot);
								
								value.Add(elem1);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetImages(value);
					}
					
					
					
					
					
					if ("sub_title".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSub_title(value);
					}
					
					
					
					
					
					if ("prod_props".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.marketplace.product.SimpleProperty> value;
						
						value = new List<vipapis.marketplace.product.SimpleProperty>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.marketplace.product.SimpleProperty elem3;
								
								elem3 = new vipapis.marketplace.product.SimpleProperty();
								vipapis.marketplace.product.SimplePropertyHelper.getInstance().Read(elem3, iprot);
								
								value.Add(elem3);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetProd_props(value);
					}
					
					
					
					
					
					if ("custom_prod_props".Equals(schemeField.Trim())){
						
						needSkip = false;
						Dictionary<string, string> value;
						
						value = new Dictionary<string, string>();
						iprot.ReadMapBegin();
						while(true){
							
							try{
								
								string _key5;
								string _val5;
								_key5 = iprot.ReadString();
								
								_val5 = iprot.ReadString();
								
								value.Add(_key5, _val5);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadMapEnd();
						
						structs.SetCustom_prod_props(value);
					}
					
					
					
					
					
					if ("area_output".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetArea_output(value);
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
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetLength(value);
					}
					
					
					
					
					
					if ("width".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetWidth(value);
					}
					
					
					
					
					
					if ("height".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetHeight(value);
					}
					
					
					
					
					
					if ("weight".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetWeight(value);
					}
					
					
					
					
					
					if ("gross_weight".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetGross_weight(value);
					}
					
					
					
					
					
					if ("skus".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.marketplace.product.AddSkuItem> value;
						
						value = new List<vipapis.marketplace.product.AddSkuItem>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.marketplace.product.AddSkuItem elem6;
								
								elem6 = new vipapis.marketplace.product.AddSkuItem();
								vipapis.marketplace.product.AddSkuItemHelper.getInstance().Read(elem6, iprot);
								
								value.Add(elem6);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetSkus(value);
					}
					
					
					
					
					
					if ("color_images".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.marketplace.product.ColorImage> value;
						
						value = new List<vipapis.marketplace.product.ColorImage>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.marketplace.product.ColorImage elem8;
								
								elem8 = new vipapis.marketplace.product.ColorImage();
								vipapis.marketplace.product.ColorImageHelper.getInstance().Read(elem8, iprot);
								
								value.Add(elem8);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetColor_images(value);
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
		
		
		public void Write(AddProductRequest structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetOuter_spu_id() != null) {
				
				oprot.WriteFieldBegin("outer_spu_id");
				oprot.WriteString(structs.GetOuter_spu_id());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("outer_spu_id can not be null!");
			}
			
			
			if(structs.GetTitle() != null) {
				
				oprot.WriteFieldBegin("title");
				oprot.WriteString(structs.GetTitle());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("title can not be null!");
			}
			
			
			if(structs.GetThird_category_id() != null) {
				
				oprot.WriteFieldBegin("third_category_id");
				oprot.WriteI32((int)structs.GetThird_category_id()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("third_category_id can not be null!");
			}
			
			
			if(structs.GetBrand_id() != null) {
				
				oprot.WriteFieldBegin("brand_id");
				oprot.WriteI32((int)structs.GetBrand_id()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("brand_id can not be null!");
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
			
			
			if(structs.GetSub_title() != null) {
				
				oprot.WriteFieldBegin("sub_title");
				oprot.WriteString(structs.GetSub_title());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetProd_props() != null) {
				
				oprot.WriteFieldBegin("prod_props");
				
				oprot.WriteListBegin();
				foreach(vipapis.marketplace.product.SimpleProperty _item0 in structs.GetProd_props()){
					
					
					vipapis.marketplace.product.SimplePropertyHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
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
			
			
			if(structs.GetArea_output() != null) {
				
				oprot.WriteFieldBegin("area_output");
				oprot.WriteString(structs.GetArea_output());
				
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
				oprot.WriteI32((int)structs.GetLength()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetWidth() != null) {
				
				oprot.WriteFieldBegin("width");
				oprot.WriteI32((int)structs.GetWidth()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetHeight() != null) {
				
				oprot.WriteFieldBegin("height");
				oprot.WriteI32((int)structs.GetHeight()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetWeight() != null) {
				
				oprot.WriteFieldBegin("weight");
				oprot.WriteI32((int)structs.GetWeight()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetGross_weight() != null) {
				
				oprot.WriteFieldBegin("gross_weight");
				oprot.WriteI32((int)structs.GetGross_weight()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSkus() != null) {
				
				oprot.WriteFieldBegin("skus");
				
				oprot.WriteListBegin();
				foreach(vipapis.marketplace.product.AddSkuItem _item0 in structs.GetSkus()){
					
					
					vipapis.marketplace.product.AddSkuItemHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetColor_images() != null) {
				
				oprot.WriteFieldBegin("color_images");
				
				oprot.WriteListBegin();
				foreach(vipapis.marketplace.product.ColorImage _item0 in structs.GetColor_images()){
					
					
					vipapis.marketplace.product.ColorImageHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(AddProductRequest bean){
			
			
		}
		
	}
	
}