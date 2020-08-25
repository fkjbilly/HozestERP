using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.pg{
	
	
	
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
					
					
					if ("goods_name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetGoods_name(value);
					}
					
					
					
					
					
					if ("goods_barcode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetGoods_barcode(value);
					}
					
					
					
					
					
					if ("under_goods_barcode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetUnder_goods_barcode(value);
					}
					
					
					
					
					
					if ("under_goods_name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetUnder_goods_name(value);
					}
					
					
					
					
					
					if ("under_goods_quantity".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetUnder_goods_quantity(value);
					}
					
					
					
					
					
					if ("goods_no".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetGoods_no(value);
					}
					
					
					
					
					
					if ("cat1_name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCat1_name(value);
					}
					
					
					
					
					
					if ("purchase_status".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPurchase_status(value);
					}
					
					
					
					
					
					if ("page_sale_price".Equals(schemeField.Trim())){
						
						needSkip = false;
						double? value;
						value = iprot.ReadDouble();
						
						structs.SetPage_sale_price(value);
					}
					
					
					
					
					
					if ("page_url".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPage_url(value);
					}
					
					
					
					
					
					if ("goods_image_1".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetGoods_image_1(value);
					}
					
					
					
					
					
					if ("goods_image_2".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetGoods_image_2(value);
					}
					
					
					
					
					
					if ("goods_image_3".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetGoods_image_3(value);
					}
					
					
					
					
					
					if ("goods_image_4".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetGoods_image_4(value);
					}
					
					
					
					
					
					if ("goods_image_5".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetGoods_image_5(value);
					}
					
					
					
					
					
					if ("goods_image_6".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetGoods_image_6(value);
					}
					
					
					
					
					
					if ("brand_name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBrand_name(value);
					}
					
					
					
					
					
					if ("put_shelves_time".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPut_shelves_time(value);
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
			
			if(structs.GetGoods_name() != null) {
				
				oprot.WriteFieldBegin("goods_name");
				oprot.WriteString(structs.GetGoods_name());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetGoods_barcode() != null) {
				
				oprot.WriteFieldBegin("goods_barcode");
				oprot.WriteString(structs.GetGoods_barcode());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetUnder_goods_barcode() != null) {
				
				oprot.WriteFieldBegin("under_goods_barcode");
				oprot.WriteString(structs.GetUnder_goods_barcode());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetUnder_goods_name() != null) {
				
				oprot.WriteFieldBegin("under_goods_name");
				oprot.WriteString(structs.GetUnder_goods_name());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetUnder_goods_quantity() != null) {
				
				oprot.WriteFieldBegin("under_goods_quantity");
				oprot.WriteI32((int)structs.GetUnder_goods_quantity()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetGoods_no() != null) {
				
				oprot.WriteFieldBegin("goods_no");
				oprot.WriteString(structs.GetGoods_no());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCat1_name() != null) {
				
				oprot.WriteFieldBegin("cat1_name");
				oprot.WriteString(structs.GetCat1_name());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPurchase_status() != null) {
				
				oprot.WriteFieldBegin("purchase_status");
				oprot.WriteString(structs.GetPurchase_status());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPage_sale_price() != null) {
				
				oprot.WriteFieldBegin("page_sale_price");
				oprot.WriteDouble((double)structs.GetPage_sale_price());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPage_url() != null) {
				
				oprot.WriteFieldBegin("page_url");
				oprot.WriteString(structs.GetPage_url());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetGoods_image_1() != null) {
				
				oprot.WriteFieldBegin("goods_image_1");
				oprot.WriteString(structs.GetGoods_image_1());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetGoods_image_2() != null) {
				
				oprot.WriteFieldBegin("goods_image_2");
				oprot.WriteString(structs.GetGoods_image_2());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetGoods_image_3() != null) {
				
				oprot.WriteFieldBegin("goods_image_3");
				oprot.WriteString(structs.GetGoods_image_3());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetGoods_image_4() != null) {
				
				oprot.WriteFieldBegin("goods_image_4");
				oprot.WriteString(structs.GetGoods_image_4());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetGoods_image_5() != null) {
				
				oprot.WriteFieldBegin("goods_image_5");
				oprot.WriteString(structs.GetGoods_image_5());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetGoods_image_6() != null) {
				
				oprot.WriteFieldBegin("goods_image_6");
				oprot.WriteString(structs.GetGoods_image_6());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBrand_name() != null) {
				
				oprot.WriteFieldBegin("brand_name");
				oprot.WriteString(structs.GetBrand_name());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPut_shelves_time() != null) {
				
				oprot.WriteFieldBegin("put_shelves_time");
				oprot.WriteString(structs.GetPut_shelves_time());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(Product bean){
			
			
		}
		
	}
	
}