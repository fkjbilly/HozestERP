using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.marketplace.product{
	
	
	
	public class SkuDetailHelper : TBeanSerializer<SkuDetail>
	{
		
		public static SkuDetailHelper OBJ = new SkuDetailHelper();
		
		public static SkuDetailHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(SkuDetail structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("sku_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSku_id(value);
					}
					
					
					
					
					
					if ("outer_sku_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOuter_sku_id(value);
					}
					
					
					
					
					
					if ("sale_props".Equals(schemeField.Trim())){
						
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
						
						structs.SetSale_props(value);
					}
					
					
					
					
					
					if ("size_detail_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetSize_detail_id(value);
					}
					
					
					
					
					
					if ("color_images".Equals(schemeField.Trim())){
						
						needSkip = false;
						vipapis.marketplace.product.ColorImage value;
						
						value = new vipapis.marketplace.product.ColorImage();
						vipapis.marketplace.product.ColorImageHelper.getInstance().Read(value, iprot);
						
						structs.SetColor_images(value);
					}
					
					
					
					
					
					if ("spu_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSpu_id(value);
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
		
		
		public void Write(SkuDetail structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetSku_id() != null) {
				
				oprot.WriteFieldBegin("sku_id");
				oprot.WriteString(structs.GetSku_id());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("sku_id can not be null!");
			}
			
			
			if(structs.GetOuter_sku_id() != null) {
				
				oprot.WriteFieldBegin("outer_sku_id");
				oprot.WriteString(structs.GetOuter_sku_id());
				
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
			
			
			if(structs.GetSize_detail_id() != null) {
				
				oprot.WriteFieldBegin("size_detail_id");
				oprot.WriteI64((long)structs.GetSize_detail_id()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetColor_images() != null) {
				
				oprot.WriteFieldBegin("color_images");
				
				vipapis.marketplace.product.ColorImageHelper.getInstance().Write(structs.GetColor_images(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSpu_id() != null) {
				
				oprot.WriteFieldBegin("spu_id");
				oprot.WriteString(structs.GetSpu_id());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(SkuDetail bean){
			
			
		}
		
	}
	
}