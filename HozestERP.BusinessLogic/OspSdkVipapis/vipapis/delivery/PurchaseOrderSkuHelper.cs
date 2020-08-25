using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.delivery{
	
	
	
	public class PurchaseOrderSkuHelper : TBeanSerializer<PurchaseOrderSku>
	{
		
		public static PurchaseOrderSkuHelper OBJ = new PurchaseOrderSkuHelper();
		
		public static PurchaseOrderSkuHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(PurchaseOrderSku structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("sell_site".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSell_site(value);
					}
					
					
					
					
					
					if ("warehouse".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetWarehouse(value);
					}
					
					
					
					
					
					if ("barcode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBarcode(value);
					}
					
					
					
					
					
					if ("amount".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetAmount(value);
					}
					
					
					
					
					
					if ("order_cate".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOrder_cate(value);
					}
					
					
					
					
					
					if ("order_status".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOrder_status(value);
					}
					
					
					
					
					
					if ("create_time".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCreate_time(value);
					}
					
					
					
					
					
					if ("audit_time".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetAudit_time(value);
					}
					
					
					
					
					
					if ("actual_unit_price".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetActual_unit_price(value);
					}
					
					
					
					
					
					if ("actual_market_price".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetActual_market_price(value);
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
		
		
		public void Write(PurchaseOrderSku structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetSell_site() != null) {
				
				oprot.WriteFieldBegin("sell_site");
				oprot.WriteString(structs.GetSell_site());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetWarehouse() != null) {
				
				oprot.WriteFieldBegin("warehouse");
				oprot.WriteString(structs.GetWarehouse());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBarcode() != null) {
				
				oprot.WriteFieldBegin("barcode");
				oprot.WriteString(structs.GetBarcode());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetAmount() != null) {
				
				oprot.WriteFieldBegin("amount");
				oprot.WriteI32((int)structs.GetAmount()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrder_cate() != null) {
				
				oprot.WriteFieldBegin("order_cate");
				oprot.WriteString(structs.GetOrder_cate());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrder_status() != null) {
				
				oprot.WriteFieldBegin("order_status");
				oprot.WriteString(structs.GetOrder_status());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCreate_time() != null) {
				
				oprot.WriteFieldBegin("create_time");
				oprot.WriteString(structs.GetCreate_time());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetAudit_time() != null) {
				
				oprot.WriteFieldBegin("audit_time");
				oprot.WriteString(structs.GetAudit_time());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetActual_unit_price() != null) {
				
				oprot.WriteFieldBegin("actual_unit_price");
				oprot.WriteString(structs.GetActual_unit_price());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetActual_market_price() != null) {
				
				oprot.WriteFieldBegin("actual_market_price");
				oprot.WriteString(structs.GetActual_market_price());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(PurchaseOrderSku bean){
			
			
		}
		
	}
	
}