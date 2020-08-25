using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vipshop.cis.sdk.api.datain.si.request{
	
	
	
	public class SyncVrwIncrInvRequestPayloadItemHelper : TBeanSerializer<SyncVrwIncrInvRequestPayloadItem>
	{
		
		public static SyncVrwIncrInvRequestPayloadItemHelper OBJ = new SyncVrwIncrInvRequestPayloadItemHelper();
		
		public static SyncVrwIncrInvRequestPayloadItemHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(SyncVrwIncrInvRequestPayloadItem structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("transaction_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTransaction_id(value);
					}
					
					
					
					
					
					if ("warehouse_code".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetWarehouse_code(value);
					}
					
					
					
					
					
					if ("vendor_code".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetVendor_code(value);
					}
					
					
					
					
					
					if ("item_code".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetItem_code(value);
					}
					
					
					
					
					
					if ("company_code".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCompany_code(value);
					}
					
					
					
					
					
					if ("po_no".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPo_no(value);
					}
					
					
					
					
					
					if ("type".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetType(value);
					}
					
					
					
					
					
					if ("quantity".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetQuantity(value);
					}
					
					
					
					
					
					if ("action_type".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetAction_type(value);
					}
					
					
					
					
					
					if ("action_time".Equals(schemeField.Trim())){
						
						needSkip = false;
						long value;
						value = iprot.ReadI64(); 
						
						structs.SetAction_time(value);
					}
					
					
					
					
					
					if ("system".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSystem(value);
					}
					
					
					
					
					
					if ("order_sn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOrder_sn(value);
					}
					
					
					
					
					
					if ("brand_name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBrand_name(value);
					}
					
					
					
					
					
					if ("product_name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetProduct_name(value);
					}
					
					
					
					
					
					if ("vendor_item".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetVendor_item(value);
					}
					
					
					
					
					
					if ("brand_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBrand_id(value);
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
					
					
					
					
					
					if ("expiration_date".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetExpiration_date(value);
					}
					
					
					
					
					
					if ("manufacture_date".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetManufacture_date(value);
					}
					
					
					
					
					
					if ("cntry_of_orgn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCntry_of_orgn(value);
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
		
		
		public void Write(SyncVrwIncrInvRequestPayloadItem structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetTransaction_id() != null) {
				
				oprot.WriteFieldBegin("transaction_id");
				oprot.WriteString(structs.GetTransaction_id());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("transaction_id can not be null!");
			}
			
			
			if(structs.GetWarehouse_code() != null) {
				
				oprot.WriteFieldBegin("warehouse_code");
				oprot.WriteString(structs.GetWarehouse_code());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("warehouse_code can not be null!");
			}
			
			
			if(structs.GetVendor_code() != null) {
				
				oprot.WriteFieldBegin("vendor_code");
				oprot.WriteString(structs.GetVendor_code());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("vendor_code can not be null!");
			}
			
			
			if(structs.GetItem_code() != null) {
				
				oprot.WriteFieldBegin("item_code");
				oprot.WriteString(structs.GetItem_code());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("item_code can not be null!");
			}
			
			
			if(structs.GetCompany_code() != null) {
				
				oprot.WriteFieldBegin("company_code");
				oprot.WriteString(structs.GetCompany_code());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("company_code can not be null!");
			}
			
			
			if(structs.GetPo_no() != null) {
				
				oprot.WriteFieldBegin("po_no");
				oprot.WriteString(structs.GetPo_no());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("po_no can not be null!");
			}
			
			
			if(structs.GetType() != null) {
				
				oprot.WriteFieldBegin("type");
				oprot.WriteString(structs.GetType());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("type can not be null!");
			}
			
			
			if(structs.GetQuantity() != null) {
				
				oprot.WriteFieldBegin("quantity");
				oprot.WriteI32((int)structs.GetQuantity()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetAction_type() != null) {
				
				oprot.WriteFieldBegin("action_type");
				oprot.WriteString(structs.GetAction_type());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("action_type can not be null!");
			}
			
			
			if(structs.GetAction_time() != null) {
				
				oprot.WriteFieldBegin("action_time");
				oprot.WriteI64((long)structs.GetAction_time()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("action_time can not be null!");
			}
			
			
			if(structs.GetSystem() != null) {
				
				oprot.WriteFieldBegin("system");
				oprot.WriteString(structs.GetSystem());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("system can not be null!");
			}
			
			
			if(structs.GetOrder_sn() != null) {
				
				oprot.WriteFieldBegin("order_sn");
				oprot.WriteString(structs.GetOrder_sn());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBrand_name() != null) {
				
				oprot.WriteFieldBegin("brand_name");
				oprot.WriteString(structs.GetBrand_name());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetProduct_name() != null) {
				
				oprot.WriteFieldBegin("product_name");
				oprot.WriteString(structs.GetProduct_name());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetVendor_item() != null) {
				
				oprot.WriteFieldBegin("vendor_item");
				oprot.WriteString(structs.GetVendor_item());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBrand_id() != null) {
				
				oprot.WriteFieldBegin("brand_id");
				oprot.WriteString(structs.GetBrand_id());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetGrade() != null) {
				
				oprot.WriteFieldBegin("grade");
				oprot.WriteString(structs.GetGrade());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("grade can not be null!");
			}
			
			
			if(structs.GetStatus() != null) {
				
				oprot.WriteFieldBegin("status");
				oprot.WriteString(structs.GetStatus());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("status can not be null!");
			}
			
			
			if(structs.GetExpiration_date() != null) {
				
				oprot.WriteFieldBegin("expiration_date");
				oprot.WriteI64((long)structs.GetExpiration_date()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetManufacture_date() != null) {
				
				oprot.WriteFieldBegin("manufacture_date");
				oprot.WriteI64((long)structs.GetManufacture_date()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCntry_of_orgn() != null) {
				
				oprot.WriteFieldBegin("cntry_of_orgn");
				oprot.WriteString(structs.GetCntry_of_orgn());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(SyncVrwIncrInvRequestPayloadItem bean){
			
			
		}
		
	}
	
}