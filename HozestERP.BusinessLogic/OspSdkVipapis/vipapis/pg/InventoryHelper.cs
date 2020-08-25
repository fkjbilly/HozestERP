using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.pg{
	
	
	
	public class InventoryHelper : TBeanSerializer<Inventory>
	{
		
		public static InventoryHelper OBJ = new InventoryHelper();
		
		public static InventoryHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(Inventory structs, Protocol iprot){
			
			
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
					
					
					
					
					
					if ("cat1_name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCat1_name(value);
					}
					
					
					
					
					
					if ("stock_quantity".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetStock_quantity(value);
					}
					
					
					
					
					
					if ("stock_day".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetStock_day(value);
					}
					
					
					
					
					
					if ("warehouse_code".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetWarehouse_code(value);
					}
					
					
					
					
					
					if ("vendor_name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetVendor_name(value);
					}
					
					
					
					
					
					if ("day_sale_average_one_week".Equals(schemeField.Trim())){
						
						needSkip = false;
						double? value;
						value = iprot.ReadDouble();
						
						structs.SetDay_sale_average_one_week(value);
					}
					
					
					
					
					
					if ("day_sale_average_two_week".Equals(schemeField.Trim())){
						
						needSkip = false;
						double? value;
						value = iprot.ReadDouble();
						
						structs.SetDay_sale_average_two_week(value);
					}
					
					
					
					
					
					if ("day_sale_average_four_week".Equals(schemeField.Trim())){
						
						needSkip = false;
						double? value;
						value = iprot.ReadDouble();
						
						structs.SetDay_sale_average_four_week(value);
					}
					
					
					
					
					
					if ("stock_date".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetStock_date(value);
					}
					
					
					
					
					
					if ("stock_age".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetStock_age(value);
					}
					
					
					
					
					
					if ("po".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPo(value);
					}
					
					
					
					
					
					if ("stock_type".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetStock_type(value);
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
		
		
		public void Write(Inventory structs, Protocol oprot){
			
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
			
			
			if(structs.GetCat1_name() != null) {
				
				oprot.WriteFieldBegin("cat1_name");
				oprot.WriteString(structs.GetCat1_name());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetStock_quantity() != null) {
				
				oprot.WriteFieldBegin("stock_quantity");
				oprot.WriteI32((int)structs.GetStock_quantity()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetStock_day() != null) {
				
				oprot.WriteFieldBegin("stock_day");
				oprot.WriteI32((int)structs.GetStock_day()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetWarehouse_code() != null) {
				
				oprot.WriteFieldBegin("warehouse_code");
				oprot.WriteString(structs.GetWarehouse_code());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetVendor_name() != null) {
				
				oprot.WriteFieldBegin("vendor_name");
				oprot.WriteString(structs.GetVendor_name());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetDay_sale_average_one_week() != null) {
				
				oprot.WriteFieldBegin("day_sale_average_one_week");
				oprot.WriteDouble((double)structs.GetDay_sale_average_one_week());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetDay_sale_average_two_week() != null) {
				
				oprot.WriteFieldBegin("day_sale_average_two_week");
				oprot.WriteDouble((double)structs.GetDay_sale_average_two_week());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetDay_sale_average_four_week() != null) {
				
				oprot.WriteFieldBegin("day_sale_average_four_week");
				oprot.WriteDouble((double)structs.GetDay_sale_average_four_week());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetStock_date() != null) {
				
				oprot.WriteFieldBegin("stock_date");
				oprot.WriteString(structs.GetStock_date());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetStock_age() != null) {
				
				oprot.WriteFieldBegin("stock_age");
				oprot.WriteI32((int)structs.GetStock_age()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPo() != null) {
				
				oprot.WriteFieldBegin("po");
				oprot.WriteString(structs.GetPo());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetStock_type() != null) {
				
				oprot.WriteFieldBegin("stock_type");
				oprot.WriteString(structs.GetStock_type());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(Inventory bean){
			
			
		}
		
	}
	
}