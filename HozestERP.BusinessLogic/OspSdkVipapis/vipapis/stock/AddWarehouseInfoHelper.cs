using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.stock{
	
	
	
	public class AddWarehouseInfoHelper : TBeanSerializer<AddWarehouseInfo>
	{
		
		public static AddWarehouseInfoHelper OBJ = new AddWarehouseInfoHelper();
		
		public static AddWarehouseInfoHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(AddWarehouseInfo structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("vendor_warehouse_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetVendor_warehouse_id(value);
					}
					
					
					
					
					
					if ("vendor_warehouse_name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetVendor_warehouse_name(value);
					}
					
					
					
					
					
					if ("vendor_warehouse_province".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetVendor_warehouse_province(value);
					}
					
					
					
					
					
					if ("vendor_warehouse_city".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetVendor_warehouse_city(value);
					}
					
					
					
					
					
					if ("vendor_warehouse_country".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetVendor_warehouse_country(value);
					}
					
					
					
					
					
					if ("vendor_warehouse_street".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetVendor_warehouse_street(value);
					}
					
					
					
					
					
					if ("vendor_warehouse_addresses".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetVendor_warehouse_addresses(value);
					}
					
					
					
					
					
					if ("name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetName(value);
					}
					
					
					
					
					
					if ("tel".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTel(value);
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
		
		
		public void Write(AddWarehouseInfo structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetVendor_warehouse_id() != null) {
				
				oprot.WriteFieldBegin("vendor_warehouse_id");
				oprot.WriteString(structs.GetVendor_warehouse_id());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("vendor_warehouse_id can not be null!");
			}
			
			
			if(structs.GetVendor_warehouse_name() != null) {
				
				oprot.WriteFieldBegin("vendor_warehouse_name");
				oprot.WriteString(structs.GetVendor_warehouse_name());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("vendor_warehouse_name can not be null!");
			}
			
			
			if(structs.GetVendor_warehouse_province() != null) {
				
				oprot.WriteFieldBegin("vendor_warehouse_province");
				oprot.WriteString(structs.GetVendor_warehouse_province());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("vendor_warehouse_province can not be null!");
			}
			
			
			if(structs.GetVendor_warehouse_city() != null) {
				
				oprot.WriteFieldBegin("vendor_warehouse_city");
				oprot.WriteString(structs.GetVendor_warehouse_city());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("vendor_warehouse_city can not be null!");
			}
			
			
			if(structs.GetVendor_warehouse_country() != null) {
				
				oprot.WriteFieldBegin("vendor_warehouse_country");
				oprot.WriteString(structs.GetVendor_warehouse_country());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("vendor_warehouse_country can not be null!");
			}
			
			
			if(structs.GetVendor_warehouse_street() != null) {
				
				oprot.WriteFieldBegin("vendor_warehouse_street");
				oprot.WriteString(structs.GetVendor_warehouse_street());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("vendor_warehouse_street can not be null!");
			}
			
			
			if(structs.GetVendor_warehouse_addresses() != null) {
				
				oprot.WriteFieldBegin("vendor_warehouse_addresses");
				oprot.WriteString(structs.GetVendor_warehouse_addresses());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("vendor_warehouse_addresses can not be null!");
			}
			
			
			if(structs.GetName() != null) {
				
				oprot.WriteFieldBegin("name");
				oprot.WriteString(structs.GetName());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("name can not be null!");
			}
			
			
			if(structs.GetTel() != null) {
				
				oprot.WriteFieldBegin("tel");
				oprot.WriteString(structs.GetTel());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("tel can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(AddWarehouseInfo bean){
			
			
		}
		
	}
	
}