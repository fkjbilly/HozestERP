using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.common.pojo.order.vo{
	
	
	
	public class OrderWarehouseVOHelper : TBeanSerializer<OrderWarehouseVO>
	{
		
		public static OrderWarehouseVOHelper OBJ = new OrderWarehouseVOHelper();
		
		public static OrderWarehouseVOHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(OrderWarehouseVO structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("merItemNo".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetMerItemNo(value);
					}
					
					
					
					
					
					if ("userId".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetUserId(value);
					}
					
					
					
					
					
					if ("orderId".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetOrderId(value);
					}
					
					
					
					
					
					if ("orderSn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOrderSn(value);
					}
					
					
					
					
					
					if ("saleWarehouse".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSaleWarehouse(value);
					}
					
					
					
					
					
					if ("scheduledSellingId".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetScheduledSellingId(value);
					}
					
					
					
					
					
					if ("warehouse".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetWarehouse(value);
					}
					
					
					
					
					
					if ("sourceWarehouse".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSourceWarehouse(value);
					}
					
					
					
					
					
					if ("amount".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetAmount(value);
					}
					
					
					
					
					
					if ("addTime".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetAddTime(value);
					}
					
					
					
					
					
					if ("updateTime".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetUpdateTime(value);
					}
					
					
					
					
					
					if ("id".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetId(value);
					}
					
					
					
					
					
					if ("subWarehouse".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSubWarehouse(value);
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
		
		
		public void Write(OrderWarehouseVO structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetMerItemNo() != null) {
				
				oprot.WriteFieldBegin("merItemNo");
				oprot.WriteI64((long)structs.GetMerItemNo()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetUserId() != null) {
				
				oprot.WriteFieldBegin("userId");
				oprot.WriteI64((long)structs.GetUserId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderId() != null) {
				
				oprot.WriteFieldBegin("orderId");
				oprot.WriteI64((long)structs.GetOrderId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderSn() != null) {
				
				oprot.WriteFieldBegin("orderSn");
				oprot.WriteString(structs.GetOrderSn());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSaleWarehouse() != null) {
				
				oprot.WriteFieldBegin("saleWarehouse");
				oprot.WriteString(structs.GetSaleWarehouse());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetScheduledSellingId() != null) {
				
				oprot.WriteFieldBegin("scheduledSellingId");
				oprot.WriteString(structs.GetScheduledSellingId());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetWarehouse() != null) {
				
				oprot.WriteFieldBegin("warehouse");
				oprot.WriteString(structs.GetWarehouse());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSourceWarehouse() != null) {
				
				oprot.WriteFieldBegin("sourceWarehouse");
				oprot.WriteString(structs.GetSourceWarehouse());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetAmount() != null) {
				
				oprot.WriteFieldBegin("amount");
				oprot.WriteI32((int)structs.GetAmount()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetAddTime() != null) {
				
				oprot.WriteFieldBegin("addTime");
				oprot.WriteI32((int)structs.GetAddTime()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetUpdateTime() != null) {
				
				oprot.WriteFieldBegin("updateTime");
				oprot.WriteI32((int)structs.GetUpdateTime()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetId() != null) {
				
				oprot.WriteFieldBegin("id");
				oprot.WriteI64((long)structs.GetId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSubWarehouse() != null) {
				
				oprot.WriteFieldBegin("subWarehouse");
				oprot.WriteString(structs.GetSubWarehouse());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(OrderWarehouseVO bean){
			
			
		}
		
	}
	
}