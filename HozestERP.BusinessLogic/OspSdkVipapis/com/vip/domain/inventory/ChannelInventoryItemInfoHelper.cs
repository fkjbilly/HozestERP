using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.domain.inventory{
	
	
	
	public class ChannelInventoryItemInfoHelper : TBeanSerializer<ChannelInventoryItemInfo>
	{
		
		public static ChannelInventoryItemInfoHelper OBJ = new ChannelInventoryItemInfoHelper();
		
		public static ChannelInventoryItemInfoHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(ChannelInventoryItemInfo structs, Protocol iprot){
			
			
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
					
					
					
					
					
					if ("channel".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetChannel(value);
					}
					
					
					
					
					
					if ("vendor_item".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetVendor_item(value);
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
					
					
					
					
					
					if ("first_categoryid".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetFirst_categoryid(value);
					}
					
					
					
					
					
					if ("second_categoryid".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSecond_categoryid(value);
					}
					
					
					
					
					
					if ("third_categoryid".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetThird_categoryid(value);
					}
					
					
					
					
					
					if ("grade".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetGrade(value);
					}
					
					
					
					
					
					if ("status".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetStatus(value);
					}
					
					
					
					
					
					if ("sales_plan_no".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSales_plan_no(value);
					}
					
					
					
					
					
					if ("ordered_qty".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetOrdered_qty(value);
					}
					
					
					
					
					
					if ("frozen_qty".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetFrozen_qty(value);
					}
					
					
					
					
					
					if ("return_held_qty".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetReturn_held_qty(value);
					}
					
					
					
					
					
					if ("quantity".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetQuantity(value);
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
		
		
		public void Write(ChannelInventoryItemInfo structs, Protocol oprot){
			
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
			
			
			if(structs.GetChannel() != null) {
				
				oprot.WriteFieldBegin("channel");
				oprot.WriteString(structs.GetChannel());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetVendor_item() != null) {
				
				oprot.WriteFieldBegin("vendor_item");
				oprot.WriteString(structs.GetVendor_item());
				
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
			
			
			if(structs.GetFirst_categoryid() != null) {
				
				oprot.WriteFieldBegin("first_categoryid");
				oprot.WriteString(structs.GetFirst_categoryid());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSecond_categoryid() != null) {
				
				oprot.WriteFieldBegin("second_categoryid");
				oprot.WriteString(structs.GetSecond_categoryid());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetThird_categoryid() != null) {
				
				oprot.WriteFieldBegin("third_categoryid");
				oprot.WriteString(structs.GetThird_categoryid());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetGrade() != null) {
				
				oprot.WriteFieldBegin("grade");
				oprot.WriteString(structs.GetGrade());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetStatus() != null) {
				
				oprot.WriteFieldBegin("status");
				oprot.WriteString(structs.GetStatus());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSales_plan_no() != null) {
				
				oprot.WriteFieldBegin("sales_plan_no");
				oprot.WriteString(structs.GetSales_plan_no());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrdered_qty() != null) {
				
				oprot.WriteFieldBegin("ordered_qty");
				oprot.WriteI32((int)structs.GetOrdered_qty()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetFrozen_qty() != null) {
				
				oprot.WriteFieldBegin("frozen_qty");
				oprot.WriteI32((int)structs.GetFrozen_qty()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetReturn_held_qty() != null) {
				
				oprot.WriteFieldBegin("return_held_qty");
				oprot.WriteI32((int)structs.GetReturn_held_qty()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetQuantity() != null) {
				
				oprot.WriteFieldBegin("quantity");
				oprot.WriteI32((int)structs.GetQuantity()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(ChannelInventoryItemInfo bean){
			
			
		}
		
	}
	
}