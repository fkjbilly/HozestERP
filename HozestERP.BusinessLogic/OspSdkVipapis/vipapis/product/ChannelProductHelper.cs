using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.product{
	
	
	
	public class ChannelProductHelper : BeanSerializer<ChannelProduct>
	{
		
		public static ChannelProductHelper OBJ = new ChannelProductHelper();
		
		public static ChannelProductHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(ChannelProduct structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("vendor_spu_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetVendor_spu_id(value);
					}
					
					
					
					
					
					if ("schedule_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						long value;
						value = iprot.ReadI64(); 
						
						structs.SetSchedule_id(value);
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
					
					
					
					
					
					if ("art_no".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetArt_no(value);
					}
					
					
					
					
					
					if ("product_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						long value;
						value = iprot.ReadI64(); 
						
						structs.SetProduct_id(value);
					}
					
					
					
					
					
					if ("product_name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetProduct_name(value);
					}
					
					
					
					
					
					if ("sell_price".Equals(schemeField.Trim())){
						
						needSkip = false;
						double value;
						value = iprot.ReadDouble();
						
						structs.SetSell_price(value);
					}
					
					
					
					
					
					if ("market_price".Equals(schemeField.Trim())){
						
						needSkip = false;
						double value;
						value = iprot.ReadDouble();
						
						structs.SetMarket_price(value);
					}
					
					
					
					
					
					if ("agio".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetAgio(value);
					}
					
					
					
					
					
					if ("status".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetStatus(value);
					}
					
					
					
					
					
					if ("standard".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetStandard(value);
					}
					
					
					
					
					
					if ("washing_instruct".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetWashing_instruct(value);
					}
					
					
					
					
					
					if ("color".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetColor(value);
					}
					
					
					
					
					
					if ("material".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetMaterial(value);
					}
					
					
					
					
					
					if ("accessory_info".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetAccessory_info(value);
					}
					
					
					
					
					
					if ("product_description".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetProduct_description(value);
					}
					
					
					
					
					
					if ("weight_type".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetWeight_type(value);
					}
					
					
					
					
					
					if ("title_big".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTitle_big(value);
					}
					
					
					
					
					
					if ("title_small".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTitle_small(value);
					}
					
					
					
					
					
					if ("sale_service".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSale_service(value);
					}
					
					
					
					
					
					if ("area_output".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetArea_output(value);
					}
					
					
					
					
					
					if ("brand_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBrand_id(value);
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
					
					
					
					
					
					if ("warehouses".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetWarehouses(value);
					}
					
					
					
					
					
					if ("size".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSize(value);
					}
					
					
					
					
					
					if ("size_table_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetSize_table_id(value);
					}
					
					
					
					
					
					if ("point_describe".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPoint_describe(value);
					}
					
					
					
					
					
					if ("product_url".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetProduct_url(value);
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
		
		
		public void Write(ChannelProduct structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetVendor_spu_id() != null) {
				
				oprot.WriteFieldBegin("vendor_spu_id");
				oprot.WriteString(structs.GetVendor_spu_id());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("vendor_spu_id can not be null!");
			}
			
			
			if(structs.GetSchedule_id() != null) {
				
				oprot.WriteFieldBegin("schedule_id");
				oprot.WriteI64((long)structs.GetSchedule_id()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("schedule_id can not be null!");
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
			
			
			if(structs.GetArt_no() != null) {
				
				oprot.WriteFieldBegin("art_no");
				oprot.WriteString(structs.GetArt_no());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetProduct_id() != null) {
				
				oprot.WriteFieldBegin("product_id");
				oprot.WriteI64((long)structs.GetProduct_id()); 
				
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
			
			
			if(structs.GetSell_price() != null) {
				
				oprot.WriteFieldBegin("sell_price");
				oprot.WriteDouble((double)structs.GetSell_price());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("sell_price can not be null!");
			}
			
			
			if(structs.GetMarket_price() != null) {
				
				oprot.WriteFieldBegin("market_price");
				oprot.WriteDouble((double)structs.GetMarket_price());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("market_price can not be null!");
			}
			
			
			if(structs.GetAgio() != null) {
				
				oprot.WriteFieldBegin("agio");
				oprot.WriteString(structs.GetAgio());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetStatus() != null) {
				
				oprot.WriteFieldBegin("status");
				oprot.WriteString(structs.GetStatus());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetStandard() != null) {
				
				oprot.WriteFieldBegin("standard");
				oprot.WriteString(structs.GetStandard());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetWashing_instruct() != null) {
				
				oprot.WriteFieldBegin("washing_instruct");
				oprot.WriteString(structs.GetWashing_instruct());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetColor() != null) {
				
				oprot.WriteFieldBegin("color");
				oprot.WriteString(structs.GetColor());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetMaterial() != null) {
				
				oprot.WriteFieldBegin("material");
				oprot.WriteString(structs.GetMaterial());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetAccessory_info() != null) {
				
				oprot.WriteFieldBegin("accessory_info");
				oprot.WriteString(structs.GetAccessory_info());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetProduct_description() != null) {
				
				oprot.WriteFieldBegin("product_description");
				oprot.WriteString(structs.GetProduct_description());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetWeight_type() != null) {
				
				oprot.WriteFieldBegin("weight_type");
				oprot.WriteString(structs.GetWeight_type());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTitle_big() != null) {
				
				oprot.WriteFieldBegin("title_big");
				oprot.WriteString(structs.GetTitle_big());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTitle_small() != null) {
				
				oprot.WriteFieldBegin("title_small");
				oprot.WriteString(structs.GetTitle_small());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSale_service() != null) {
				
				oprot.WriteFieldBegin("sale_service");
				oprot.WriteString(structs.GetSale_service());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetArea_output() != null) {
				
				oprot.WriteFieldBegin("area_output");
				oprot.WriteString(structs.GetArea_output());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBrand_id() != null) {
				
				oprot.WriteFieldBegin("brand_id");
				oprot.WriteString(structs.GetBrand_id());
				
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
			
			
			if(structs.GetWarehouses() != null) {
				
				oprot.WriteFieldBegin("warehouses");
				oprot.WriteString(structs.GetWarehouses());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSize() != null) {
				
				oprot.WriteFieldBegin("size");
				oprot.WriteString(structs.GetSize());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSize_table_id() != null) {
				
				oprot.WriteFieldBegin("size_table_id");
				oprot.WriteI64((long)structs.GetSize_table_id()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPoint_describe() != null) {
				
				oprot.WriteFieldBegin("point_describe");
				oprot.WriteString(structs.GetPoint_describe());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetProduct_url() != null) {
				
				oprot.WriteFieldBegin("product_url");
				oprot.WriteString(structs.GetProduct_url());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(ChannelProduct bean){
			
			
		}
		
	}
	
}