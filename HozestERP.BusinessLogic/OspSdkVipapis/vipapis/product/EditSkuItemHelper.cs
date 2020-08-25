using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.product{
	
	
	
	public class EditSkuItemHelper : TBeanSerializer<EditSkuItem>
	{
		
		public static EditSkuItemHelper OBJ = new EditSkuItemHelper();
		
		public static EditSkuItemHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(EditSkuItem structs, Protocol iprot){
			
			
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
					
					
					
					
					
					if ("supply_price".Equals(schemeField.Trim())){
						
						needSkip = false;
						double? value;
						value = iprot.ReadDouble();
						
						structs.SetSupply_price(value);
					}
					
					
					
					
					
					if ("simple_sale_props".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.product.SimpleProperty> value;
						
						value = new List<vipapis.product.SimpleProperty>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.product.SimpleProperty elem2;
								
								elem2 = new vipapis.product.SimpleProperty();
								vipapis.product.SimplePropertyHelper.getInstance().Read(elem2, iprot);
								
								value.Add(elem2);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetSimple_sale_props(value);
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
		
		
		public void Write(EditSkuItem structs, Protocol oprot){
			
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
			
			
			if(structs.GetSupply_price() != null) {
				
				oprot.WriteFieldBegin("supply_price");
				oprot.WriteDouble((double)structs.GetSupply_price());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSimple_sale_props() != null) {
				
				oprot.WriteFieldBegin("simple_sale_props");
				
				oprot.WriteListBegin();
				foreach(vipapis.product.SimpleProperty _item0 in structs.GetSimple_sale_props()){
					
					
					vipapis.product.SimplePropertyHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(EditSkuItem bean){
			
			
		}
		
	}
	
}