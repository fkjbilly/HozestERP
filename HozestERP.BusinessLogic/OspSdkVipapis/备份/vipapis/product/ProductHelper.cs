using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.product{
	
	
	
	public class ProductHelper : BeanSerializer<Product>
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
					
					
					if ("schedule_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetSchedule_id(value);
					}
					
					
					
					
					
					if ("product_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetProduct_id(value);
					}
					
					
					
					
					
					if ("product_name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetProduct_name(value);
					}
					
					
					
					
					
					if ("brand_store_sn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBrand_store_sn(value);
					}
					
					
					
					
					
					if ("brand_name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBrand_name(value);
					}
					
					
					
					
					
					if ("brand_name_eng".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBrand_name_eng(value);
					}
					
					
					
					
					
					if ("brand_url".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBrand_url(value);
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
					
					
					
					
					
					if ("agio".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetAgio(value);
					}
					
					
					
					
					
					if ("has_stock".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetHas_stock(value);
					}
					
					
					
					
					
					if ("product_url".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetProduct_url(value);
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
					
					
					
					
					
					if ("show_image".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<string> value;
						
						value = new List<string>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								string elem0;
								elem0 = iprot.ReadString();
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetShow_image(value);
					}
					
					
					
					
					
					if ("product_mobile_url".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetProduct_mobile_url(value);
					}
					
					
					
					
					
					if ("product_mobile_image".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetProduct_mobile_image(value);
					}
					
					
					
					
					
					if ("category_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetCategory_id(value);
					}
					
					
					
					
					
					if ("nav_category_id1".Equals(schemeField.Trim())){
						
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
						
						structs.SetNav_category_id1(value);
					}
					
					
					
					
					
					if ("nav_category_id2".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<string> value;
						
						value = new List<string>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								string elem2;
								elem2 = iprot.ReadString();
								
								value.Add(elem2);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetNav_category_id2(value);
					}
					
					
					
					
					
					if ("nav_category_id3".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<string> value;
						
						value = new List<string>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								string elem3;
								elem3 = iprot.ReadString();
								
								value.Add(elem3);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetNav_category_id3(value);
					}
					
					
					
					
					
					if ("nav_first_name".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<string> value;
						
						value = new List<string>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								string elem4;
								elem4 = iprot.ReadString();
								
								value.Add(elem4);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetNav_first_name(value);
					}
					
					
					
					
					
					if ("nav_second_name".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<string> value;
						
						value = new List<string>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								string elem5;
								elem5 = iprot.ReadString();
								
								value.Add(elem5);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetNav_second_name(value);
					}
					
					
					
					
					
					if ("nav_third_name".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<string> value;
						
						value = new List<string>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								string elem6;
								elem6 = iprot.ReadString();
								
								value.Add(elem6);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetNav_third_name(value);
					}
					
					
					
					
					
					if ("warehouses".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<string> value;
						
						value = new List<string>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								string elem7;
								elem7 = iprot.ReadString();
								
								value.Add(elem7);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetWarehouses(value);
					}
					
					
					
					
					
					if ("sell_time_from".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSell_time_from(value);
					}
					
					
					
					
					
					if ("sell_time_to".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSell_time_to(value);
					}
					
					
					
					
					
					if ("pc_show_from".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPc_show_from(value);
					}
					
					
					
					
					
					if ("pc_show_to".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPc_show_to(value);
					}
					
					
					
					
					
					if ("mobile_show_from".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetMobile_show_from(value);
					}
					
					
					
					
					
					if ("mobile_show_to".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetMobile_show_to(value);
					}
					
					
					
					
					
					if ("channels".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<string> value;
						
						value = new List<string>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								string elem8;
								elem8 = iprot.ReadString();
								
								value.Add(elem8);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetChannels(value);
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
			
			if(structs.GetSchedule_id() != null) {
				
				oprot.WriteFieldBegin("schedule_id");
				oprot.WriteI32((int)structs.GetSchedule_id()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("schedule_id can not be null!");
			}
			
			
			if(structs.GetProduct_id() != null) {
				
				oprot.WriteFieldBegin("product_id");
				oprot.WriteI32((int)structs.GetProduct_id()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("product_id can not be null!");
			}
			
			
			if(structs.GetProduct_name() != null) {
				
				oprot.WriteFieldBegin("product_name");
				oprot.WriteString(structs.GetProduct_name());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("product_name can not be null!");
			}
			
			
			if(structs.GetBrand_store_sn() != null) {
				
				oprot.WriteFieldBegin("brand_store_sn");
				oprot.WriteString(structs.GetBrand_store_sn());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBrand_name() != null) {
				
				oprot.WriteFieldBegin("brand_name");
				oprot.WriteString(structs.GetBrand_name());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBrand_name_eng() != null) {
				
				oprot.WriteFieldBegin("brand_name_eng");
				oprot.WriteString(structs.GetBrand_name_eng());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBrand_url() != null) {
				
				oprot.WriteFieldBegin("brand_url");
				oprot.WriteString(structs.GetBrand_url());
				
				oprot.WriteFieldEnd();
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
			
			
			if(structs.GetAgio() != null) {
				
				oprot.WriteFieldBegin("agio");
				oprot.WriteString(structs.GetAgio());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetHas_stock() != null) {
				
				oprot.WriteFieldBegin("has_stock");
				oprot.WriteI32((int)structs.GetHas_stock()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("has_stock can not be null!");
			}
			
			
			if(structs.GetProduct_url() != null) {
				
				oprot.WriteFieldBegin("product_url");
				oprot.WriteString(structs.GetProduct_url());
				
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
			
			
			if(structs.GetShow_image() != null) {
				
				oprot.WriteFieldBegin("show_image");
				
				oprot.WriteListBegin();
				foreach(string _item0 in structs.GetShow_image()){
					
					oprot.WriteString(_item0);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetProduct_mobile_url() != null) {
				
				oprot.WriteFieldBegin("product_mobile_url");
				oprot.WriteString(structs.GetProduct_mobile_url());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetProduct_mobile_image() != null) {
				
				oprot.WriteFieldBegin("product_mobile_image");
				oprot.WriteString(structs.GetProduct_mobile_image());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCategory_id() != null) {
				
				oprot.WriteFieldBegin("category_id");
				oprot.WriteI32((int)structs.GetCategory_id()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetNav_category_id1() != null) {
				
				oprot.WriteFieldBegin("nav_category_id1");
				
				oprot.WriteListBegin();
				foreach(string _item0 in structs.GetNav_category_id1()){
					
					oprot.WriteString(_item0);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetNav_category_id2() != null) {
				
				oprot.WriteFieldBegin("nav_category_id2");
				
				oprot.WriteListBegin();
				foreach(string _item0 in structs.GetNav_category_id2()){
					
					oprot.WriteString(_item0);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetNav_category_id3() != null) {
				
				oprot.WriteFieldBegin("nav_category_id3");
				
				oprot.WriteListBegin();
				foreach(string _item0 in structs.GetNav_category_id3()){
					
					oprot.WriteString(_item0);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetNav_first_name() != null) {
				
				oprot.WriteFieldBegin("nav_first_name");
				
				oprot.WriteListBegin();
				foreach(string _item0 in structs.GetNav_first_name()){
					
					oprot.WriteString(_item0);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetNav_second_name() != null) {
				
				oprot.WriteFieldBegin("nav_second_name");
				
				oprot.WriteListBegin();
				foreach(string _item0 in structs.GetNav_second_name()){
					
					oprot.WriteString(_item0);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetNav_third_name() != null) {
				
				oprot.WriteFieldBegin("nav_third_name");
				
				oprot.WriteListBegin();
				foreach(string _item0 in structs.GetNav_third_name()){
					
					oprot.WriteString(_item0);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetWarehouses() != null) {
				
				oprot.WriteFieldBegin("warehouses");
				
				oprot.WriteListBegin();
				foreach(string _item0 in structs.GetWarehouses()){
					
					oprot.WriteString(_item0);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSell_time_from() != null) {
				
				oprot.WriteFieldBegin("sell_time_from");
				oprot.WriteString(structs.GetSell_time_from());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSell_time_to() != null) {
				
				oprot.WriteFieldBegin("sell_time_to");
				oprot.WriteString(structs.GetSell_time_to());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPc_show_from() != null) {
				
				oprot.WriteFieldBegin("pc_show_from");
				oprot.WriteString(structs.GetPc_show_from());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPc_show_to() != null) {
				
				oprot.WriteFieldBegin("pc_show_to");
				oprot.WriteString(structs.GetPc_show_to());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetMobile_show_from() != null) {
				
				oprot.WriteFieldBegin("mobile_show_from");
				oprot.WriteString(structs.GetMobile_show_from());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetMobile_show_to() != null) {
				
				oprot.WriteFieldBegin("mobile_show_to");
				oprot.WriteString(structs.GetMobile_show_to());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetChannels() != null) {
				
				oprot.WriteFieldBegin("channels");
				
				oprot.WriteListBegin();
				foreach(string _item0 in structs.GetChannels()){
					
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