using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.common.pojo.order.vo{
	
	
	
	public class OrderExchangeApplyVOHelper : TBeanSerializer<OrderExchangeApplyVO>
	{
		
		public static OrderExchangeApplyVOHelper OBJ = new OrderExchangeApplyVOHelper();
		
		public static OrderExchangeApplyVOHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(OrderExchangeApplyVO structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("applyId".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetApplyId(value);
					}
					
					
					
					
					
					if ("userId".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetUserId(value);
					}
					
					
					
					
					
					if ("orderSn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOrderSn(value);
					}
					
					
					
					
					
					if ("orderId".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetOrderId(value);
					}
					
					
					
					
					
					if ("operator".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOperator(value);
					}
					
					
					
					
					
					if ("remark".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetRemark(value);
					}
					
					
					
					
					
					if ("orderAfterStatus".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetOrderAfterStatus(value);
					}
					
					
					
					
					
					if ("orderAfterStatusUpdtime".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetOrderAfterStatusUpdtime(value);
					}
					
					
					
					
					
					if ("applyTime".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetApplyTime(value);
					}
					
					
					
					
					
					if ("newOrderSn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetNewOrderSn(value);
					}
					
					
					
					
					
					if ("returnMethod".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetReturnMethod(value);
					}
					
					
					
					
					
					if ("exchangeProcessStatus".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetExchangeProcessStatus(value);
					}
					
					
					
					
					
					if ("returnTransportNo".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetReturnTransportNo(value);
					}
					
					
					
					
					
					if ("updateTime".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetUpdateTime(value);
					}
					
					
					
					
					
					if ("ip".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetIp(value);
					}
					
					
					
					
					
					if ("subExchangeStatus".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetSubExchangeStatus(value);
					}
					
					
					
					
					
					if ("returnsPayType".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetReturnsPayType(value);
					}
					
					
					
					
					
					if ("returnWarehouse".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetReturnWarehouse(value);
					}
					
					
					
					
					
					if ("afterSaleSn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetAfterSaleSn(value);
					}
					
					
					
					
					
					if ("afterSaleStatus".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetAfterSaleStatus(value);
					}
					
					
					
					
					
					if ("isDeleted".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetIsDeleted(value);
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
		
		
		public void Write(OrderExchangeApplyVO structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetApplyId() != null) {
				
				oprot.WriteFieldBegin("applyId");
				oprot.WriteI64((long)structs.GetApplyId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetUserId() != null) {
				
				oprot.WriteFieldBegin("userId");
				oprot.WriteI64((long)structs.GetUserId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderSn() != null) {
				
				oprot.WriteFieldBegin("orderSn");
				oprot.WriteString(structs.GetOrderSn());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderId() != null) {
				
				oprot.WriteFieldBegin("orderId");
				oprot.WriteI64((long)structs.GetOrderId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOperator() != null) {
				
				oprot.WriteFieldBegin("operator");
				oprot.WriteString(structs.GetOperator());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetRemark() != null) {
				
				oprot.WriteFieldBegin("remark");
				oprot.WriteString(structs.GetRemark());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderAfterStatus() != null) {
				
				oprot.WriteFieldBegin("orderAfterStatus");
				oprot.WriteI32((int)structs.GetOrderAfterStatus()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderAfterStatusUpdtime() != null) {
				
				oprot.WriteFieldBegin("orderAfterStatusUpdtime");
				oprot.WriteI64((long)structs.GetOrderAfterStatusUpdtime()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetApplyTime() != null) {
				
				oprot.WriteFieldBegin("applyTime");
				oprot.WriteI64((long)structs.GetApplyTime()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetNewOrderSn() != null) {
				
				oprot.WriteFieldBegin("newOrderSn");
				oprot.WriteString(structs.GetNewOrderSn());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetReturnMethod() != null) {
				
				oprot.WriteFieldBegin("returnMethod");
				oprot.WriteI32((int)structs.GetReturnMethod()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetExchangeProcessStatus() != null) {
				
				oprot.WriteFieldBegin("exchangeProcessStatus");
				oprot.WriteI32((int)structs.GetExchangeProcessStatus()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetReturnTransportNo() != null) {
				
				oprot.WriteFieldBegin("returnTransportNo");
				oprot.WriteString(structs.GetReturnTransportNo());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetUpdateTime() != null) {
				
				oprot.WriteFieldBegin("updateTime");
				oprot.WriteI64((long)structs.GetUpdateTime()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetIp() != null) {
				
				oprot.WriteFieldBegin("ip");
				oprot.WriteString(structs.GetIp());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSubExchangeStatus() != null) {
				
				oprot.WriteFieldBegin("subExchangeStatus");
				oprot.WriteI32((int)structs.GetSubExchangeStatus()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetReturnsPayType() != null) {
				
				oprot.WriteFieldBegin("returnsPayType");
				oprot.WriteI32((int)structs.GetReturnsPayType()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetReturnWarehouse() != null) {
				
				oprot.WriteFieldBegin("returnWarehouse");
				oprot.WriteString(structs.GetReturnWarehouse());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetAfterSaleSn() != null) {
				
				oprot.WriteFieldBegin("afterSaleSn");
				oprot.WriteString(structs.GetAfterSaleSn());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetAfterSaleStatus() != null) {
				
				oprot.WriteFieldBegin("afterSaleStatus");
				oprot.WriteI32((int)structs.GetAfterSaleStatus()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetIsDeleted() != null) {
				
				oprot.WriteFieldBegin("isDeleted");
				oprot.WriteI32((int)structs.GetIsDeleted()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(OrderExchangeApplyVO bean){
			
			
		}
		
	}
	
}