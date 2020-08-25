using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.common.pojo.order.vo{
	
	
	
	public class OrderRefundDetailsVOHelper : TBeanSerializer<OrderRefundDetailsVO>
	{
		
		public static OrderRefundDetailsVOHelper OBJ = new OrderRefundDetailsVOHelper();
		
		public static OrderRefundDetailsVOHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(OrderRefundDetailsVO structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("orderId".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetOrderId(value);
					}
					
					
					
					
					
					if ("applyId".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetApplyId(value);
					}
					
					
					
					
					
					if ("orderScenario".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetOrderScenario(value);
					}
					
					
					
					
					
					if ("payOperation".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetPayOperation(value);
					}
					
					
					
					
					
					if ("payType".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetPayType(value);
					}
					
					
					
					
					
					if ("payId".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetPayId(value);
					}
					
					
					
					
					
					if ("paySn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPaySn(value);
					}
					
					
					
					
					
					if ("refundSn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetRefundSn(value);
					}
					
					
					
					
					
					if ("payAccount".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPayAccount(value);
					}
					
					
					
					
					
					if ("refundTime".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetRefundTime(value);
					}
					
					
					
					
					
					if ("currency".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCurrency(value);
					}
					
					
					
					
					
					if ("refundMoney".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetRefundMoney(value);
					}
					
					
					
					
					
					if ("refundStatus".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetRefundStatus(value);
					}
					
					
					
					
					
					if ("payTypeName".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPayTypeName(value);
					}
					
					
					
					
					
					if ("orderSn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOrderSn(value);
					}
					
					
					
					
					
					if ("type".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetType(value);
					}
					
					
					
					
					
					if ("createTime".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetCreateTime(value);
					}
					
					
					
					
					
					if ("updateTime".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetUpdateTime(value);
					}
					
					
					
					
					
					if ("isDeleted".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetIsDeleted(value);
					}
					
					
					
					
					
					if ("refundWay".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetRefundWay(value);
					}
					
					
					
					
					
					if ("refundRequestSn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetRefundRequestSn(value);
					}
					
					
					
					
					
					if ("originalOrderSn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOriginalOrderSn(value);
					}
					
					
					
					
					
					if ("id".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetId(value);
					}
					
					
					
					
					
					if ("refundRequestDetailSn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetRefundRequestDetailSn(value);
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
		
		
		public void Write(OrderRefundDetailsVO structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetOrderId() != null) {
				
				oprot.WriteFieldBegin("orderId");
				oprot.WriteI64((long)structs.GetOrderId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetApplyId() != null) {
				
				oprot.WriteFieldBegin("applyId");
				oprot.WriteI64((long)structs.GetApplyId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderScenario() != null) {
				
				oprot.WriteFieldBegin("orderScenario");
				oprot.WriteI32((int)structs.GetOrderScenario()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPayOperation() != null) {
				
				oprot.WriteFieldBegin("payOperation");
				oprot.WriteI32((int)structs.GetPayOperation()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPayType() != null) {
				
				oprot.WriteFieldBegin("payType");
				oprot.WriteI32((int)structs.GetPayType()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPayId() != null) {
				
				oprot.WriteFieldBegin("payId");
				oprot.WriteI32((int)structs.GetPayId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPaySn() != null) {
				
				oprot.WriteFieldBegin("paySn");
				oprot.WriteString(structs.GetPaySn());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetRefundSn() != null) {
				
				oprot.WriteFieldBegin("refundSn");
				oprot.WriteString(structs.GetRefundSn());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPayAccount() != null) {
				
				oprot.WriteFieldBegin("payAccount");
				oprot.WriteString(structs.GetPayAccount());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetRefundTime() != null) {
				
				oprot.WriteFieldBegin("refundTime");
				oprot.WriteI64((long)structs.GetRefundTime()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCurrency() != null) {
				
				oprot.WriteFieldBegin("currency");
				oprot.WriteString(structs.GetCurrency());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetRefundMoney() != null) {
				
				oprot.WriteFieldBegin("refundMoney");
				oprot.WriteString(structs.GetRefundMoney());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetRefundStatus() != null) {
				
				oprot.WriteFieldBegin("refundStatus");
				oprot.WriteI32((int)structs.GetRefundStatus()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPayTypeName() != null) {
				
				oprot.WriteFieldBegin("payTypeName");
				oprot.WriteString(structs.GetPayTypeName());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderSn() != null) {
				
				oprot.WriteFieldBegin("orderSn");
				oprot.WriteString(structs.GetOrderSn());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetType() != null) {
				
				oprot.WriteFieldBegin("type");
				oprot.WriteI32((int)structs.GetType()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCreateTime() != null) {
				
				oprot.WriteFieldBegin("createTime");
				oprot.WriteI64((long)structs.GetCreateTime()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetUpdateTime() != null) {
				
				oprot.WriteFieldBegin("updateTime");
				oprot.WriteI64((long)structs.GetUpdateTime()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetIsDeleted() != null) {
				
				oprot.WriteFieldBegin("isDeleted");
				oprot.WriteI32((int)structs.GetIsDeleted()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetRefundWay() != null) {
				
				oprot.WriteFieldBegin("refundWay");
				oprot.WriteI32((int)structs.GetRefundWay()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetRefundRequestSn() != null) {
				
				oprot.WriteFieldBegin("refundRequestSn");
				oprot.WriteString(structs.GetRefundRequestSn());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOriginalOrderSn() != null) {
				
				oprot.WriteFieldBegin("originalOrderSn");
				oprot.WriteString(structs.GetOriginalOrderSn());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetId() != null) {
				
				oprot.WriteFieldBegin("id");
				oprot.WriteI64((long)structs.GetId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetRefundRequestDetailSn() != null) {
				
				oprot.WriteFieldBegin("refundRequestDetailSn");
				oprot.WriteString(structs.GetRefundRequestDetailSn());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(OrderRefundDetailsVO bean){
			
			
		}
		
	}
	
}