using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.marketplace.delivery{
	
	
	
	public class ExportOrderInfoHelper : TBeanSerializer<ExportOrderInfo>
	{
		
		public static ExportOrderInfoHelper OBJ = new ExportOrderInfoHelper();
		
		public static ExportOrderInfoHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(ExportOrderInfo structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("order_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOrder_id(value);
					}
					
					
					
					
					
					if ("status".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetStatus(value);
					}
					
					
					
					
					
					if ("sales_channel".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSales_channel(value);
					}
					
					
					
					
					
					if ("created".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCreated(value);
					}
					
					
					
					
					
					if ("update_time".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetUpdate_time(value);
					}
					
					
					
					
					
					if ("vendor_name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetVendor_name(value);
					}
					
					
					
					
					
					if ("transport_day".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTransport_day(value);
					}
					
					
					
					
					
					if ("receiver_name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetReceiver_name(value);
					}
					
					
					
					
					
					if ("receiver_address".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetReceiver_address(value);
					}
					
					
					
					
					
					if ("receiver_mobile".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetReceiver_mobile(value);
					}
					
					
					
					
					
					if ("receiver_phone".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetReceiver_phone(value);
					}
					
					
					
					
					
					if ("receiver_zip".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetReceiver_zip(value);
					}
					
					
					
					
					
					if ("is_export".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetIs_export(value);
					}
					
					
					
					
					
					if ("export_time".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetExport_time(value);
					}
					
					
					
					
					
					if ("invoice_title".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetInvoice_title(value);
					}
					
					
					
					
					
					if ("tax_no".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTax_no(value);
					}
					
					
					
					
					
					if ("invoice_amount".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetInvoice_amount(value);
					}
					
					
					
					
					
					if ("memo".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetMemo(value);
					}
					
					
					
					
					
					if ("po".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPo(value);
					}
					
					
					
					
					
					if ("brand_name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBrand_name(value);
					}
					
					
					
					
					
					if ("title".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTitle(value);
					}
					
					
					
					
					
					if ("num".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetNum(value);
					}
					
					
					
					
					
					if ("size".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSize(value);
					}
					
					
					
					
					
					if ("outer_spu_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOuter_spu_id(value);
					}
					
					
					
					
					
					if ("outer_sku_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOuter_sku_id(value);
					}
					
					
					
					
					
					if ("price".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPrice(value);
					}
					
					
					
					
					
					if ("customization".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCustomization(value);
					}
					
					
					
					
					
					if ("vendor_memo".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetVendor_memo(value);
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
		
		
		public void Write(ExportOrderInfo structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetOrder_id() != null) {
				
				oprot.WriteFieldBegin("order_id");
				oprot.WriteString(structs.GetOrder_id());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetStatus() != null) {
				
				oprot.WriteFieldBegin("status");
				oprot.WriteString(structs.GetStatus());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSales_channel() != null) {
				
				oprot.WriteFieldBegin("sales_channel");
				oprot.WriteString(structs.GetSales_channel());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCreated() != null) {
				
				oprot.WriteFieldBegin("created");
				oprot.WriteString(structs.GetCreated());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetUpdate_time() != null) {
				
				oprot.WriteFieldBegin("update_time");
				oprot.WriteString(structs.GetUpdate_time());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetVendor_name() != null) {
				
				oprot.WriteFieldBegin("vendor_name");
				oprot.WriteString(structs.GetVendor_name());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTransport_day() != null) {
				
				oprot.WriteFieldBegin("transport_day");
				oprot.WriteString(structs.GetTransport_day());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetReceiver_name() != null) {
				
				oprot.WriteFieldBegin("receiver_name");
				oprot.WriteString(structs.GetReceiver_name());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetReceiver_address() != null) {
				
				oprot.WriteFieldBegin("receiver_address");
				oprot.WriteString(structs.GetReceiver_address());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetReceiver_mobile() != null) {
				
				oprot.WriteFieldBegin("receiver_mobile");
				oprot.WriteString(structs.GetReceiver_mobile());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetReceiver_phone() != null) {
				
				oprot.WriteFieldBegin("receiver_phone");
				oprot.WriteString(structs.GetReceiver_phone());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetReceiver_zip() != null) {
				
				oprot.WriteFieldBegin("receiver_zip");
				oprot.WriteString(structs.GetReceiver_zip());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetIs_export() != null) {
				
				oprot.WriteFieldBegin("is_export");
				oprot.WriteString(structs.GetIs_export());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetExport_time() != null) {
				
				oprot.WriteFieldBegin("export_time");
				oprot.WriteString(structs.GetExport_time());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetInvoice_title() != null) {
				
				oprot.WriteFieldBegin("invoice_title");
				oprot.WriteString(structs.GetInvoice_title());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTax_no() != null) {
				
				oprot.WriteFieldBegin("tax_no");
				oprot.WriteString(structs.GetTax_no());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetInvoice_amount() != null) {
				
				oprot.WriteFieldBegin("invoice_amount");
				oprot.WriteString(structs.GetInvoice_amount());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetMemo() != null) {
				
				oprot.WriteFieldBegin("memo");
				oprot.WriteString(structs.GetMemo());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPo() != null) {
				
				oprot.WriteFieldBegin("po");
				oprot.WriteString(structs.GetPo());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBrand_name() != null) {
				
				oprot.WriteFieldBegin("brand_name");
				oprot.WriteString(structs.GetBrand_name());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTitle() != null) {
				
				oprot.WriteFieldBegin("title");
				oprot.WriteString(structs.GetTitle());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetNum() != null) {
				
				oprot.WriteFieldBegin("num");
				oprot.WriteI32((int)structs.GetNum()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSize() != null) {
				
				oprot.WriteFieldBegin("size");
				oprot.WriteString(structs.GetSize());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOuter_spu_id() != null) {
				
				oprot.WriteFieldBegin("outer_spu_id");
				oprot.WriteString(structs.GetOuter_spu_id());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOuter_sku_id() != null) {
				
				oprot.WriteFieldBegin("outer_sku_id");
				oprot.WriteString(structs.GetOuter_sku_id());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPrice() != null) {
				
				oprot.WriteFieldBegin("price");
				oprot.WriteString(structs.GetPrice());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCustomization() != null) {
				
				oprot.WriteFieldBegin("customization");
				oprot.WriteString(structs.GetCustomization());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetVendor_memo() != null) {
				
				oprot.WriteFieldBegin("vendor_memo");
				oprot.WriteString(structs.GetVendor_memo());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(ExportOrderInfo bean){
			
			
		}
		
	}
	
}