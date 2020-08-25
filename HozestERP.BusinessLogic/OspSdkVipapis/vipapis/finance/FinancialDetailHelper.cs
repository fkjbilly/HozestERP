using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.finance{
	
	
	
	public class FinancialDetailHelper : TBeanSerializer<FinancialDetail>
	{
		
		public static FinancialDetailHelper OBJ = new FinancialDetailHelper();
		
		public static FinancialDetailHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(FinancialDetail structs, Protocol iprot){
			
			
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
					
					
					
					
					
					if ("trx_date".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTrx_date(value);
					}
					
					
					
					
					
					if ("order_type".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOrder_type(value);
					}
					
					
					
					
					
					if ("detail_type".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetDetail_type(value);
					}
					
					
					
					
					
					if ("type_description".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetType_description(value);
					}
					
					
					
					
					
					if ("detail_create_time".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetDetail_create_time(value);
					}
					
					
					
					
					
					if ("sku".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSku(value);
					}
					
					
					
					
					
					if ("quantity".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetQuantity(value);
					}
					
					
					
					
					
					if ("amount".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetAmount(value);
					}
					
					
					
					
					
					if ("commission_rate".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCommission_rate(value);
					}
					
					
					
					
					
					if ("vendor_scale".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetVendor_scale(value);
					}
					
					
					
					
					
					if ("vendor_total_receivable_fee".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetVendor_total_receivable_fee(value);
					}
					
					
					
					
					
					if ("last_account_date".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetLast_account_date(value);
					}
					
					
					
					
					
					if ("received_amount".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetReceived_amount(value);
					}
					
					
					
					
					
					if ("unpaid_amount".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetUnpaid_amount(value);
					}
					
					
					
					
					
					if ("promotion_no".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPromotion_no(value);
					}
					
					
					
					
					
					if ("promotion_description".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPromotion_description(value);
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
		
		
		public void Write(FinancialDetail structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetOrder_id() != null) {
				
				oprot.WriteFieldBegin("order_id");
				oprot.WriteString(structs.GetOrder_id());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTrx_date() != null) {
				
				oprot.WriteFieldBegin("trx_date");
				oprot.WriteString(structs.GetTrx_date());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrder_type() != null) {
				
				oprot.WriteFieldBegin("order_type");
				oprot.WriteString(structs.GetOrder_type());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetDetail_type() != null) {
				
				oprot.WriteFieldBegin("detail_type");
				oprot.WriteString(structs.GetDetail_type());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetType_description() != null) {
				
				oprot.WriteFieldBegin("type_description");
				oprot.WriteString(structs.GetType_description());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetDetail_create_time() != null) {
				
				oprot.WriteFieldBegin("detail_create_time");
				oprot.WriteString(structs.GetDetail_create_time());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSku() != null) {
				
				oprot.WriteFieldBegin("sku");
				oprot.WriteString(structs.GetSku());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetQuantity() != null) {
				
				oprot.WriteFieldBegin("quantity");
				oprot.WriteString(structs.GetQuantity());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetAmount() != null) {
				
				oprot.WriteFieldBegin("amount");
				oprot.WriteString(structs.GetAmount());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCommission_rate() != null) {
				
				oprot.WriteFieldBegin("commission_rate");
				oprot.WriteString(structs.GetCommission_rate());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetVendor_scale() != null) {
				
				oprot.WriteFieldBegin("vendor_scale");
				oprot.WriteString(structs.GetVendor_scale());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetVendor_total_receivable_fee() != null) {
				
				oprot.WriteFieldBegin("vendor_total_receivable_fee");
				oprot.WriteString(structs.GetVendor_total_receivable_fee());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetLast_account_date() != null) {
				
				oprot.WriteFieldBegin("last_account_date");
				oprot.WriteString(structs.GetLast_account_date());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetReceived_amount() != null) {
				
				oprot.WriteFieldBegin("received_amount");
				oprot.WriteString(structs.GetReceived_amount());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetUnpaid_amount() != null) {
				
				oprot.WriteFieldBegin("unpaid_amount");
				oprot.WriteString(structs.GetUnpaid_amount());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPromotion_no() != null) {
				
				oprot.WriteFieldBegin("promotion_no");
				oprot.WriteString(structs.GetPromotion_no());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPromotion_description() != null) {
				
				oprot.WriteFieldBegin("promotion_description");
				oprot.WriteString(structs.GetPromotion_description());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(FinancialDetail bean){
			
			
		}
		
	}
	
}