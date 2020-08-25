using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.marketplace.product{
	
	
	
	public class AddSkuItemHelper : TBeanSerializer<AddSkuItem>
	{
		
		public static AddSkuItemHelper OBJ = new AddSkuItemHelper();
		
		public static AddSkuItemHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(AddSkuItem structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("outer_sku_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOuter_sku_id(value);
					}
					
					
					
					
					
					if ("market_price".Equals(schemeField.Trim())){
						
						needSkip = false;
						double value;
						value = iprot.ReadDouble();
						
						structs.SetMarket_price(value);
					}
					
					
					
					
					
					if ("sell_price".Equals(schemeField.Trim())){
						
						needSkip = false;
						double value;
						value = iprot.ReadDouble();
						
						structs.SetSell_price(value);
					}
					
					
					
					
					
					if ("simple_sale_props".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.marketplace.product.SimpleProperty> value;
						
						value = new List<vipapis.marketplace.product.SimpleProperty>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.marketplace.product.SimpleProperty elem0;
								
								elem0 = new vipapis.marketplace.product.SimpleProperty();
								vipapis.marketplace.product.SimplePropertyHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
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
		
		
		public void Write(AddSkuItem structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetOuter_sku_id() != null) {
				
				oprot.WriteFieldBegin("outer_sku_id");
				oprot.WriteString(structs.GetOuter_sku_id());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("outer_sku_id can not be null!");
			}
			
			
			if(structs.GetMarket_price() != null) {
				
				oprot.WriteFieldBegin("market_price");
				oprot.WriteDouble((double)structs.GetMarket_price());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("market_price can not be null!");
			}
			
			
			if(structs.GetSell_price() != null) {
				
				oprot.WriteFieldBegin("sell_price");
				oprot.WriteDouble((double)structs.GetSell_price());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("sell_price can not be null!");
			}
			
			
			if(structs.GetSimple_sale_props() != null) {
				
				oprot.WriteFieldBegin("simple_sale_props");
				
				oprot.WriteListBegin();
				foreach(vipapis.marketplace.product.SimpleProperty _item0 in structs.GetSimple_sale_props()){
					
					
					vipapis.marketplace.product.SimplePropertyHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("simple_sale_props can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(AddSkuItem bean){
			
			
		}
		
	}
	
}