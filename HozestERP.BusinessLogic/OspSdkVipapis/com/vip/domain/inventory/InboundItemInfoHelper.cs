using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.domain.inventory{
	
	
	
	public class InboundItemInfoHelper : TBeanSerializer<InboundItemInfo>
	{
		
		public static InboundItemInfoHelper OBJ = new InboundItemInfoHelper();
		
		public static InboundItemInfoHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(InboundItemInfo structs, Protocol iprot){
			
			
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
					
					
					
					
					
					if ("inbound_status".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetInbound_status(value);
					}
					
					
					
					
					
					if ("created_date".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCreated_date(value);
					}
					
					
					
					
					
					if ("inbound_date".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetInbound_date(value);
					}
					
					
					
					
					
					if ("poTotal_qty".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetPoTotal_qty(value);
					}
					
					
					
					
					
					if ("check_qty".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetCheck_qty(value);
					}
					
					
					
					
					
					if ("diff_qty".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetDiff_qty(value);
					}
					
					
					
					
					
					if ("defect_qty".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetDefect_qty(value);
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
		
		
		public void Write(InboundItemInfo structs, Protocol oprot){
			
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
			
			
			if(structs.GetInbound_status() != null) {
				
				oprot.WriteFieldBegin("inbound_status");
				oprot.WriteString(structs.GetInbound_status());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCreated_date() != null) {
				
				oprot.WriteFieldBegin("created_date");
				oprot.WriteString(structs.GetCreated_date());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetInbound_date() != null) {
				
				oprot.WriteFieldBegin("inbound_date");
				oprot.WriteString(structs.GetInbound_date());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPoTotal_qty() != null) {
				
				oprot.WriteFieldBegin("poTotal_qty");
				oprot.WriteI32((int)structs.GetPoTotal_qty()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCheck_qty() != null) {
				
				oprot.WriteFieldBegin("check_qty");
				oprot.WriteI32((int)structs.GetCheck_qty()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetDiff_qty() != null) {
				
				oprot.WriteFieldBegin("diff_qty");
				oprot.WriteI32((int)structs.GetDiff_qty()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetDefect_qty() != null) {
				
				oprot.WriteFieldBegin("defect_qty");
				oprot.WriteI32((int)structs.GetDefect_qty()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(InboundItemInfo bean){
			
			
		}
		
	}
	
}