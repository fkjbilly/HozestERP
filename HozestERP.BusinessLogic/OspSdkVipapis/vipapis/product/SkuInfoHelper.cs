using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.product{
	
	
	
	public class SkuInfoHelper : TBeanSerializer<SkuInfo>
	{
		
		public static SkuInfoHelper OBJ = new SkuInfoHelper();
		
		public static SkuInfoHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(SkuInfo structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("barcode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBarcode(value);
					}
					
					
					
					
					
					if ("group_sn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetGroup_sn(value);
					}
					
					
					
					
					
					if ("sale_props".Equals(schemeField.Trim())){
						
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
						
						structs.SetSale_props(value);
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
					
					
					
					
					
					if ("supply_price".Equals(schemeField.Trim())){
						
						needSkip = false;
						double? value;
						value = iprot.ReadDouble();
						
						structs.SetSupply_price(value);
					}
					
					
					
					
					
					if ("size_detail_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetSize_detail_id(value);
					}
					
					
					
					
					
					if ("color_image_list".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.product.ProductImage> value;
						
						value = new List<vipapis.product.ProductImage>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.product.ProductImage elem1;
								
								elem1 = new vipapis.product.ProductImage();
								vipapis.product.ProductImageHelper.getInstance().Read(elem1, iprot);
								
								value.Add(elem1);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetColor_image_list(value);
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
		
		
		public void Write(SkuInfo structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetBarcode() != null) {
				
				oprot.WriteFieldBegin("barcode");
				oprot.WriteString(structs.GetBarcode());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetGroup_sn() != null) {
				
				oprot.WriteFieldBegin("group_sn");
				oprot.WriteString(structs.GetGroup_sn());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSale_props() != null) {
				
				oprot.WriteFieldBegin("sale_props");
				
				oprot.WriteMapBegin();
				foreach(KeyValuePair< string, string > _ir0 in structs.GetSale_props()){
					
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
			
			
			if(structs.GetSupply_price() != null) {
				
				oprot.WriteFieldBegin("supply_price");
				oprot.WriteDouble((double)structs.GetSupply_price());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSize_detail_id() != null) {
				
				oprot.WriteFieldBegin("size_detail_id");
				oprot.WriteI64((long)structs.GetSize_detail_id()); 
				
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
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(SkuInfo bean){
			
			
		}
		
	}
	
}