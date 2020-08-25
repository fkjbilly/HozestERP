using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.domain.inventory{
	
	
	
	public class PurchaseSalesInventoryItemInfoHelper : TBeanSerializer<PurchaseSalesInventoryItemInfo>
	{
		
		public static PurchaseSalesInventoryItemInfoHelper OBJ = new PurchaseSalesInventoryItemInfoHelper();
		
		public static PurchaseSalesInventoryItemInfoHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(PurchaseSalesInventoryItemInfo structs, Protocol iprot){
			
			
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
					
					
					
					
					
					if ("pay_category".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPay_category(value);
					}
					
					
					
					
					
					if ("inventory_date".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetInventory_date(value);
					}
					
					
					
					
					
					if ("beginning_inventory_quantity".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetBeginning_inventory_quantity(value);
					}
					
					
					
					
					
					if ("inventory_in_quantity".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetInventory_in_quantity(value);
					}
					
					
					
					
					
					if ("inventory_out_quantity".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetInventory_out_quantity(value);
					}
					
					
					
					
					
					if ("return_to_vendor_qunatity".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetReturn_to_vendor_qunatity(value);
					}
					
					
					
					
					
					if ("allocated_inventory_in_qunatity".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetAllocated_inventory_in_qunatity(value);
					}
					
					
					
					
					
					if ("allocated_inventory_out_qunatity".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetAllocated_inventory_out_qunatity(value);
					}
					
					
					
					
					
					if ("inventory_profit_quantity".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetInventory_profit_quantity(value);
					}
					
					
					
					
					
					if ("inventory_losses_quantity".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetInventory_losses_quantity(value);
					}
					
					
					
					
					
					if ("return_from_customer_received_quantity".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetReturn_from_customer_received_quantity(value);
					}
					
					
					
					
					
					if ("subscribed_quantity".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetSubscribed_quantity(value);
					}
					
					
					
					
					
					if ("quality_inventory_quantity".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetQuality_inventory_quantity(value);
					}
					
					
					
					
					
					if ("defective_inventory_quantity".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetDefective_inventory_quantity(value);
					}
					
					
					
					
					
					if ("ending_inventory_quantity".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetEnding_inventory_quantity(value);
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
		
		
		public void Write(PurchaseSalesInventoryItemInfo structs, Protocol oprot){
			
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
			
			
			if(structs.GetPay_category() != null) {
				
				oprot.WriteFieldBegin("pay_category");
				oprot.WriteString(structs.GetPay_category());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetInventory_date() != null) {
				
				oprot.WriteFieldBegin("inventory_date");
				oprot.WriteString(structs.GetInventory_date());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBeginning_inventory_quantity() != null) {
				
				oprot.WriteFieldBegin("beginning_inventory_quantity");
				oprot.WriteI32((int)structs.GetBeginning_inventory_quantity()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetInventory_in_quantity() != null) {
				
				oprot.WriteFieldBegin("inventory_in_quantity");
				oprot.WriteI32((int)structs.GetInventory_in_quantity()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetInventory_out_quantity() != null) {
				
				oprot.WriteFieldBegin("inventory_out_quantity");
				oprot.WriteI32((int)structs.GetInventory_out_quantity()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetReturn_to_vendor_qunatity() != null) {
				
				oprot.WriteFieldBegin("return_to_vendor_qunatity");
				oprot.WriteI32((int)structs.GetReturn_to_vendor_qunatity()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetAllocated_inventory_in_qunatity() != null) {
				
				oprot.WriteFieldBegin("allocated_inventory_in_qunatity");
				oprot.WriteI32((int)structs.GetAllocated_inventory_in_qunatity()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetAllocated_inventory_out_qunatity() != null) {
				
				oprot.WriteFieldBegin("allocated_inventory_out_qunatity");
				oprot.WriteI32((int)structs.GetAllocated_inventory_out_qunatity()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetInventory_profit_quantity() != null) {
				
				oprot.WriteFieldBegin("inventory_profit_quantity");
				oprot.WriteI32((int)structs.GetInventory_profit_quantity()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetInventory_losses_quantity() != null) {
				
				oprot.WriteFieldBegin("inventory_losses_quantity");
				oprot.WriteI32((int)structs.GetInventory_losses_quantity()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetReturn_from_customer_received_quantity() != null) {
				
				oprot.WriteFieldBegin("return_from_customer_received_quantity");
				oprot.WriteI32((int)structs.GetReturn_from_customer_received_quantity()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSubscribed_quantity() != null) {
				
				oprot.WriteFieldBegin("subscribed_quantity");
				oprot.WriteI32((int)structs.GetSubscribed_quantity()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetQuality_inventory_quantity() != null) {
				
				oprot.WriteFieldBegin("quality_inventory_quantity");
				oprot.WriteI32((int)structs.GetQuality_inventory_quantity()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetDefective_inventory_quantity() != null) {
				
				oprot.WriteFieldBegin("defective_inventory_quantity");
				oprot.WriteI32((int)structs.GetDefective_inventory_quantity()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetEnding_inventory_quantity() != null) {
				
				oprot.WriteFieldBegin("ending_inventory_quantity");
				oprot.WriteI32((int)structs.GetEnding_inventory_quantity()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(PurchaseSalesInventoryItemInfo bean){
			
			
		}
		
	}
	
}