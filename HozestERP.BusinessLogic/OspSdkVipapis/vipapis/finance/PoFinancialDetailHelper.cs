using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.finance{
	
	
	
	public class PoFinancialDetailHelper : TBeanSerializer<PoFinancialDetail>
	{
		
		public static PoFinancialDetailHelper OBJ = new PoFinancialDetailHelper();
		
		public static PoFinancialDetailHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(PoFinancialDetail structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("transaction_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetTransaction_id(value);
					}
					
					
					
					
					
					if ("transaction_type".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTransaction_type(value);
					}
					
					
					
					
					
					if ("transaction_type_name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTransaction_type_name(value);
					}
					
					
					
					
					
					if ("transaction_time".Equals(schemeField.Trim())){
						
						needSkip = false;
						System.DateTime? value;
						value = Osp.Sdk.Util.TimeUtil.FromUnixTime(iprot.ReadI64()); 
						
						structs.SetTransaction_time(value);
					}
					
					
					
					
					
					if ("schedule_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSchedule_id(value);
					}
					
					
					
					
					
					if ("po_no".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPo_no(value);
					}
					
					
					
					
					
					if ("po_org_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPo_org_id(value);
					}
					
					
					
					
					
					if ("create_time".Equals(schemeField.Trim())){
						
						needSkip = false;
						System.DateTime? value;
						value = Osp.Sdk.Util.TimeUtil.FromUnixTime(iprot.ReadI64()); 
						
						structs.SetCreate_time(value);
					}
					
					
					
					
					
					if ("transaction_quantity".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetTransaction_quantity(value);
					}
					
					
					
					
					
					if ("warehouse".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetWarehouse(value);
					}
					
					
					
					
					
					if ("order_no".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOrder_no(value);
					}
					
					
					
					
					
					if ("barcode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBarcode(value);
					}
					
					
					
					
					
					if ("sales_amount".Equals(schemeField.Trim())){
						
						needSkip = false;
						double? value;
						value = iprot.ReadDouble();
						
						structs.SetSales_amount(value);
					}
					
					
					
					
					
					if ("order_currency".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOrder_currency(value);
					}
					
					
					
					
					
					if ("bill_price".Equals(schemeField.Trim())){
						
						needSkip = false;
						double? value;
						value = iprot.ReadDouble();
						
						structs.SetBill_price(value);
					}
					
					
					
					
					
					if ("bill_amount".Equals(schemeField.Trim())){
						
						needSkip = false;
						double? value;
						value = iprot.ReadDouble();
						
						structs.SetBill_amount(value);
					}
					
					
					
					
					
					if ("bill_amount_tax".Equals(schemeField.Trim())){
						
						needSkip = false;
						double? value;
						value = iprot.ReadDouble();
						
						structs.SetBill_amount_tax(value);
					}
					
					
					
					
					
					if ("currency_code".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCurrency_code(value);
					}
					
					
					
					
					
					if ("tax_rate".Equals(schemeField.Trim())){
						
						needSkip = false;
						double? value;
						value = iprot.ReadDouble();
						
						structs.SetTax_rate(value);
					}
					
					
					
					
					
					if ("source_status".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSource_status(value);
					}
					
					
					
					
					
					if ("comments".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetComments(value);
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
		
		
		public void Write(PoFinancialDetail structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetTransaction_id() != null) {
				
				oprot.WriteFieldBegin("transaction_id");
				oprot.WriteI64((long)structs.GetTransaction_id()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTransaction_type() != null) {
				
				oprot.WriteFieldBegin("transaction_type");
				oprot.WriteString(structs.GetTransaction_type());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTransaction_type_name() != null) {
				
				oprot.WriteFieldBegin("transaction_type_name");
				oprot.WriteString(structs.GetTransaction_type_name());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTransaction_time() != null) {
				
				oprot.WriteFieldBegin("transaction_time");
				oprot.WriteI64(Osp.Sdk.Util.TimeUtil.ToUnixTime((System.DateTime)structs.GetTransaction_time())); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSchedule_id() != null) {
				
				oprot.WriteFieldBegin("schedule_id");
				oprot.WriteString(structs.GetSchedule_id());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPo_no() != null) {
				
				oprot.WriteFieldBegin("po_no");
				oprot.WriteString(structs.GetPo_no());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPo_org_id() != null) {
				
				oprot.WriteFieldBegin("po_org_id");
				oprot.WriteString(structs.GetPo_org_id());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCreate_time() != null) {
				
				oprot.WriteFieldBegin("create_time");
				oprot.WriteI64(Osp.Sdk.Util.TimeUtil.ToUnixTime((System.DateTime)structs.GetCreate_time())); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTransaction_quantity() != null) {
				
				oprot.WriteFieldBegin("transaction_quantity");
				oprot.WriteI64((long)structs.GetTransaction_quantity()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetWarehouse() != null) {
				
				oprot.WriteFieldBegin("warehouse");
				oprot.WriteString(structs.GetWarehouse());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrder_no() != null) {
				
				oprot.WriteFieldBegin("order_no");
				oprot.WriteString(structs.GetOrder_no());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBarcode() != null) {
				
				oprot.WriteFieldBegin("barcode");
				oprot.WriteString(structs.GetBarcode());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSales_amount() != null) {
				
				oprot.WriteFieldBegin("sales_amount");
				oprot.WriteDouble((double)structs.GetSales_amount());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrder_currency() != null) {
				
				oprot.WriteFieldBegin("order_currency");
				oprot.WriteString(structs.GetOrder_currency());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBill_price() != null) {
				
				oprot.WriteFieldBegin("bill_price");
				oprot.WriteDouble((double)structs.GetBill_price());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBill_amount() != null) {
				
				oprot.WriteFieldBegin("bill_amount");
				oprot.WriteDouble((double)structs.GetBill_amount());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBill_amount_tax() != null) {
				
				oprot.WriteFieldBegin("bill_amount_tax");
				oprot.WriteDouble((double)structs.GetBill_amount_tax());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCurrency_code() != null) {
				
				oprot.WriteFieldBegin("currency_code");
				oprot.WriteString(structs.GetCurrency_code());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTax_rate() != null) {
				
				oprot.WriteFieldBegin("tax_rate");
				oprot.WriteDouble((double)structs.GetTax_rate());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSource_status() != null) {
				
				oprot.WriteFieldBegin("source_status");
				oprot.WriteString(structs.GetSource_status());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetComments() != null) {
				
				oprot.WriteFieldBegin("comments");
				oprot.WriteString(structs.GetComments());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(PoFinancialDetail bean){
			
			
		}
		
	}
	
}