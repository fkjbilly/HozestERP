using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.domain.inventory{
	
	
	
	public class RealtimeInventoryItemInfoHelper : TBeanSerializer<RealtimeInventoryItemInfo>
	{
		
		public static RealtimeInventoryItemInfoHelper OBJ = new RealtimeInventoryItemInfoHelper();
		
		public static RealtimeInventoryItemInfoHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(RealtimeInventoryItemInfo structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("vendor_code".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetVendor_code(value);
					}
					
					
					
					
					
					if ("warehouse_code".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetWarehouse_code(value);
					}
					
					
					
					
					
					if ("po_no".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPo_no(value);
					}
					
					
					
					
					
					if ("item_code".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetItem_code(value);
					}
					
					
					
					
					
					if ("item_name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetItem_name(value);
					}
					
					
					
					
					
					if ("brand_code".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBrand_code(value);
					}
					
					
					
					
					
					if ("brand_name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBrand_name(value);
					}
					
					
					
					
					
					if ("inventory_location_parameter".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetInventory_location_parameter(value);
					}
					
					
					
					
					
					if ("commodity_parameter".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCommodity_parameter(value);
					}
					
					
					
					
					
					if ("vendor_item".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetVendor_item(value);
					}
					
					
					
					
					
					if ("quantity".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetQuantity(value);
					}
					
					
					
					
					
					if ("occupancy_quantity".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetOccupancy_quantity(value);
					}
					
					
					
					
					
					if ("allocated_qunatity".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetAllocated_qunatity(value);
					}
					
					
					
					
					
					if ("available_quantity".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetAvailable_quantity(value);
					}
					
					
					
					
					
					if ("vip3pl_qty".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetVip3pl_qty(value);
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
		
		
		public void Write(RealtimeInventoryItemInfo structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetVendor_code() != null) {
				
				oprot.WriteFieldBegin("vendor_code");
				oprot.WriteString(structs.GetVendor_code());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetWarehouse_code() != null) {
				
				oprot.WriteFieldBegin("warehouse_code");
				oprot.WriteString(structs.GetWarehouse_code());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPo_no() != null) {
				
				oprot.WriteFieldBegin("po_no");
				oprot.WriteString(structs.GetPo_no());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetItem_code() != null) {
				
				oprot.WriteFieldBegin("item_code");
				oprot.WriteString(structs.GetItem_code());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetItem_name() != null) {
				
				oprot.WriteFieldBegin("item_name");
				oprot.WriteString(structs.GetItem_name());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBrand_code() != null) {
				
				oprot.WriteFieldBegin("brand_code");
				oprot.WriteString(structs.GetBrand_code());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBrand_name() != null) {
				
				oprot.WriteFieldBegin("brand_name");
				oprot.WriteString(structs.GetBrand_name());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetInventory_location_parameter() != null) {
				
				oprot.WriteFieldBegin("inventory_location_parameter");
				oprot.WriteString(structs.GetInventory_location_parameter());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCommodity_parameter() != null) {
				
				oprot.WriteFieldBegin("commodity_parameter");
				oprot.WriteString(structs.GetCommodity_parameter());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetVendor_item() != null) {
				
				oprot.WriteFieldBegin("vendor_item");
				oprot.WriteString(structs.GetVendor_item());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetQuantity() != null) {
				
				oprot.WriteFieldBegin("quantity");
				oprot.WriteI32((int)structs.GetQuantity()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOccupancy_quantity() != null) {
				
				oprot.WriteFieldBegin("occupancy_quantity");
				oprot.WriteI32((int)structs.GetOccupancy_quantity()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetAllocated_qunatity() != null) {
				
				oprot.WriteFieldBegin("allocated_qunatity");
				oprot.WriteI32((int)structs.GetAllocated_qunatity()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetAvailable_quantity() != null) {
				
				oprot.WriteFieldBegin("available_quantity");
				oprot.WriteI32((int)structs.GetAvailable_quantity()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetVip3pl_qty() != null) {
				
				oprot.WriteFieldBegin("vip3pl_qty");
				oprot.WriteI32((int)structs.GetVip3pl_qty()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(RealtimeInventoryItemInfo bean){
			
			
		}
		
	}
	
}