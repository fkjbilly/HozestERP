using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.marketplace.delivery{
	
	
	
	public class SovOrderHelper : TBeanSerializer<SovOrder>
	{
		
		public static SovOrderHelper OBJ = new SovOrderHelper();
		
		public static SovOrderHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(SovOrder structs, Protocol iprot){
			
			
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
					
					
					
					
					
					if ("receiver_district".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetReceiver_district(value);
					}
					
					
					
					
					
					if ("receiver_city".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetReceiver_city(value);
					}
					
					
					
					
					
					if ("receiver_state".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetReceiver_state(value);
					}
					
					
					
					
					
					if ("country_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCountry_id(value);
					}
					
					
					
					
					
					if ("remark".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetRemark(value);
					}
					
					
					
					
					
					if ("invoice_title".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetInvoice_title(value);
					}
					
					
					
					
					
					if ("tax_pay_no".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTax_pay_no(value);
					}
					
					
					
					
					
					if ("invoice_amount".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetInvoice_amount(value);
					}
					
					
					
					
					
					if ("total_fee".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTotal_fee(value);
					}
					
					
					
					
					
					if ("post_fee".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPost_fee(value);
					}
					
					
					
					
					
					if ("discount_fee".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetDiscount_fee(value);
					}
					
					
					
					
					
					if ("ex_discount_fee".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetEx_discount_fee(value);
					}
					
					
					
					
					
					if ("created".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCreated(value);
					}
					
					
					
					
					
					if ("store_add_time".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetStore_add_time(value);
					}
					
					
					
					
					
					if ("old_order_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOld_order_id(value);
					}
					
					
					
					
					
					if ("warehouse".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetWarehouse(value);
					}
					
					
					
					
					
					if ("is_export".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetIs_export(value);
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
		
		
		public void Write(SovOrder structs, Protocol oprot){
			
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
			
			
			if(structs.GetReceiver_district() != null) {
				
				oprot.WriteFieldBegin("receiver_district");
				oprot.WriteString(structs.GetReceiver_district());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetReceiver_city() != null) {
				
				oprot.WriteFieldBegin("receiver_city");
				oprot.WriteString(structs.GetReceiver_city());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetReceiver_state() != null) {
				
				oprot.WriteFieldBegin("receiver_state");
				oprot.WriteString(structs.GetReceiver_state());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCountry_id() != null) {
				
				oprot.WriteFieldBegin("country_id");
				oprot.WriteString(structs.GetCountry_id());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetRemark() != null) {
				
				oprot.WriteFieldBegin("remark");
				oprot.WriteString(structs.GetRemark());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetInvoice_title() != null) {
				
				oprot.WriteFieldBegin("invoice_title");
				oprot.WriteString(structs.GetInvoice_title());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTax_pay_no() != null) {
				
				oprot.WriteFieldBegin("tax_pay_no");
				oprot.WriteString(structs.GetTax_pay_no());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetInvoice_amount() != null) {
				
				oprot.WriteFieldBegin("invoice_amount");
				oprot.WriteString(structs.GetInvoice_amount());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTotal_fee() != null) {
				
				oprot.WriteFieldBegin("total_fee");
				oprot.WriteString(structs.GetTotal_fee());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPost_fee() != null) {
				
				oprot.WriteFieldBegin("post_fee");
				oprot.WriteString(structs.GetPost_fee());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetDiscount_fee() != null) {
				
				oprot.WriteFieldBegin("discount_fee");
				oprot.WriteString(structs.GetDiscount_fee());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetEx_discount_fee() != null) {
				
				oprot.WriteFieldBegin("ex_discount_fee");
				oprot.WriteString(structs.GetEx_discount_fee());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCreated() != null) {
				
				oprot.WriteFieldBegin("created");
				oprot.WriteString(structs.GetCreated());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetStore_add_time() != null) {
				
				oprot.WriteFieldBegin("store_add_time");
				oprot.WriteString(structs.GetStore_add_time());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOld_order_id() != null) {
				
				oprot.WriteFieldBegin("old_order_id");
				oprot.WriteString(structs.GetOld_order_id());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetWarehouse() != null) {
				
				oprot.WriteFieldBegin("warehouse");
				oprot.WriteString(structs.GetWarehouse());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetIs_export() != null) {
				
				oprot.WriteFieldBegin("is_export");
				oprot.WriteString(structs.GetIs_export());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(SovOrder bean){
			
			
		}
		
	}
	
}