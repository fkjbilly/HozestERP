using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.finance{
	
	
	
	public class OrderItemHelper : TBeanSerializer<OrderItem>
	{
		
		public static OrderItemHelper OBJ = new OrderItemHelper();
		
		public static OrderItemHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(OrderItem structs, Protocol iprot){
			
			
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
					
					
					
					
					
					if ("transaction_time".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetTransaction_time(value);
					}
					
					
					
					
					
					if ("create_time".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetCreate_time(value);
					}
					
					
					
					
					
					if ("barcode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBarcode(value);
					}
					
					
					
					
					
					if ("document_type".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetDocument_type(value);
					}
					
					
					
					
					
					if ("quantity".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetQuantity(value);
					}
					
					
					
					
					
					if ("warehouse".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetWarehouse(value);
					}
					
					
					
					
					
					if ("sale_price".Equals(schemeField.Trim())){
						
						needSkip = false;
						double? value;
						value = iprot.ReadDouble();
						
						structs.SetSale_price(value);
					}
					
					
					
					
					
					if ("bill_amount".Equals(schemeField.Trim())){
						
						needSkip = false;
						double? value;
						value = iprot.ReadDouble();
						
						structs.SetBill_amount(value);
					}
					
					
					
					
					
					if ("total_promotion_amount".Equals(schemeField.Trim())){
						
						needSkip = false;
						double? value;
						value = iprot.ReadDouble();
						
						structs.SetTotal_promotion_amount(value);
					}
					
					
					
					
					
					if ("vendor_amount".Equals(schemeField.Trim())){
						
						needSkip = false;
						double? value;
						value = iprot.ReadDouble();
						
						structs.SetVendor_amount(value);
					}
					
					
					
					
					
					if ("vendor_rate".Equals(schemeField.Trim())){
						
						needSkip = false;
						double? value;
						value = iprot.ReadDouble();
						
						structs.SetVendor_rate(value);
					}
					
					
					
					
					
					if ("process_status".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetProcess_status(value);
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
		
		
		public void Write(OrderItem structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetOrder_id() != null) {
				
				oprot.WriteFieldBegin("order_id");
				oprot.WriteString(structs.GetOrder_id());
				
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
			
			
			if(structs.GetTransaction_time() != null) {
				
				oprot.WriteFieldBegin("transaction_time");
				oprot.WriteI64((long)structs.GetTransaction_time()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCreate_time() != null) {
				
				oprot.WriteFieldBegin("create_time");
				oprot.WriteI64((long)structs.GetCreate_time()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBarcode() != null) {
				
				oprot.WriteFieldBegin("barcode");
				oprot.WriteString(structs.GetBarcode());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetDocument_type() != null) {
				
				oprot.WriteFieldBegin("document_type");
				oprot.WriteString(structs.GetDocument_type());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetQuantity() != null) {
				
				oprot.WriteFieldBegin("quantity");
				oprot.WriteI64((long)structs.GetQuantity()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetWarehouse() != null) {
				
				oprot.WriteFieldBegin("warehouse");
				oprot.WriteString(structs.GetWarehouse());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSale_price() != null) {
				
				oprot.WriteFieldBegin("sale_price");
				oprot.WriteDouble((double)structs.GetSale_price());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBill_amount() != null) {
				
				oprot.WriteFieldBegin("bill_amount");
				oprot.WriteDouble((double)structs.GetBill_amount());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTotal_promotion_amount() != null) {
				
				oprot.WriteFieldBegin("total_promotion_amount");
				oprot.WriteDouble((double)structs.GetTotal_promotion_amount());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetVendor_amount() != null) {
				
				oprot.WriteFieldBegin("vendor_amount");
				oprot.WriteDouble((double)structs.GetVendor_amount());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetVendor_rate() != null) {
				
				oprot.WriteFieldBegin("vendor_rate");
				oprot.WriteDouble((double)structs.GetVendor_rate());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetProcess_status() != null) {
				
				oprot.WriteFieldBegin("process_status");
				oprot.WriteString(structs.GetProcess_status());
				
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
		
		
		public void Validate(OrderItem bean){
			
			
		}
		
	}
	
}