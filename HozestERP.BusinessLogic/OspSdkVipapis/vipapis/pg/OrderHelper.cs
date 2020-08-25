using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.pg{
	
	
	
	public class OrderHelper : TBeanSerializer<Order>
	{
		
		public static OrderHelper OBJ = new OrderHelper();
		
		public static OrderHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(Order structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("order_sn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOrder_sn(value);
					}
					
					
					
					
					
					if ("goods_name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetGoods_name(value);
					}
					
					
					
					
					
					if ("goods_barcode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetGoods_barcode(value);
					}
					
					
					
					
					
					if ("cat1_name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCat1_name(value);
					}
					
					
					
					
					
					if ("warehouse_code".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetWarehouse_code(value);
					}
					
					
					
					
					
					if ("order_date".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOrder_date(value);
					}
					
					
					
					
					
					if ("purchase_quantity".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetPurchase_quantity(value);
					}
					
					
					
					
					
					if ("order_status".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOrder_status(value);
					}
					
					
					
					
					
					if ("order_quantity".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetOrder_quantity(value);
					}
					
					
					
					
					
					if ("receive_quantity".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetReceive_quantity(value);
					}
					
					
					
					
					
					if ("arrival_time".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetArrival_time(value);
					}
					
					
					
					
					
					if ("stock_date".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetStock_date(value);
					}
					
					
					
					
					
					if ("modified_time".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetModified_time(value);
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
		
		
		public void Write(Order structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetOrder_sn() != null) {
				
				oprot.WriteFieldBegin("order_sn");
				oprot.WriteString(structs.GetOrder_sn());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetGoods_name() != null) {
				
				oprot.WriteFieldBegin("goods_name");
				oprot.WriteString(structs.GetGoods_name());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetGoods_barcode() != null) {
				
				oprot.WriteFieldBegin("goods_barcode");
				oprot.WriteString(structs.GetGoods_barcode());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCat1_name() != null) {
				
				oprot.WriteFieldBegin("cat1_name");
				oprot.WriteString(structs.GetCat1_name());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetWarehouse_code() != null) {
				
				oprot.WriteFieldBegin("warehouse_code");
				oprot.WriteString(structs.GetWarehouse_code());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrder_date() != null) {
				
				oprot.WriteFieldBegin("order_date");
				oprot.WriteString(structs.GetOrder_date());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPurchase_quantity() != null) {
				
				oprot.WriteFieldBegin("purchase_quantity");
				oprot.WriteI32((int)structs.GetPurchase_quantity()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrder_status() != null) {
				
				oprot.WriteFieldBegin("order_status");
				oprot.WriteString(structs.GetOrder_status());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrder_quantity() != null) {
				
				oprot.WriteFieldBegin("order_quantity");
				oprot.WriteI32((int)structs.GetOrder_quantity()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetReceive_quantity() != null) {
				
				oprot.WriteFieldBegin("receive_quantity");
				oprot.WriteString(structs.GetReceive_quantity());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetArrival_time() != null) {
				
				oprot.WriteFieldBegin("arrival_time");
				oprot.WriteString(structs.GetArrival_time());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetStock_date() != null) {
				
				oprot.WriteFieldBegin("stock_date");
				oprot.WriteString(structs.GetStock_date());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetModified_time() != null) {
				
				oprot.WriteFieldBegin("modified_time");
				oprot.WriteString(structs.GetModified_time());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(Order bean){
			
			
		}
		
	}
	
}