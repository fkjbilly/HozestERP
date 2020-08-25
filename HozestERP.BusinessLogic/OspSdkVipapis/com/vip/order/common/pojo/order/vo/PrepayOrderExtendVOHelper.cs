using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.common.pojo.order.vo{
	
	
	
	public class PrepayOrderExtendVOHelper : TBeanSerializer<PrepayOrderExtendVO>
	{
		
		public static PrepayOrderExtendVOHelper OBJ = new PrepayOrderExtendVOHelper();
		
		public static PrepayOrderExtendVOHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(PrepayOrderExtendVO structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("parentSn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetParentSn(value);
					}
					
					
					
					
					
					if ("orderCode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOrderCode(value);
					}
					
					
					
					
					
					if ("periods".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetPeriods(value);
					}
					
					
					
					
					
					if ("isFirst".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetIsFirst(value);
					}
					
					
					
					
					
					if ("isLast".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetIsLast(value);
					}
					
					
					
					
					
					if ("isLock".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetIsLock(value);
					}
					
					
					
					
					
					if ("payId".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetPayId(value);
					}
					
					
					
					
					
					if ("totalMoney".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTotalMoney(value);
					}
					
					
					
					
					
					if ("startPayTime".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetStartPayTime(value);
					}
					
					
					
					
					
					if ("endPayTime".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetEndPayTime(value);
					}
					
					
					
					
					
					if ("orderId".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetOrderId(value);
					}
					
					
					
					
					
					if ("orderAddTime".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetOrderAddTime(value);
					}
					
					
					
					
					
					if ("createTime".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetCreateTime(value);
					}
					
					
					
					
					
					if ("moneyPaid".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetMoneyPaid(value);
					}
					
					
					
					
					
					if ("auditTime".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetAuditTime(value);
					}
					
					
					
					
					
					if ("couponId".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetCouponId(value);
					}
					
					
					
					
					
					if ("couponMoneyPaid".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCouponMoneyPaid(value);
					}
					
					
					
					
					
					if ("currency".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCurrency(value);
					}
					
					
					
					
					
					if ("orderDate".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetOrderDate(value);
					}
					
					
					
					
					
					if ("discountRate".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetDiscountRate(value);
					}
					
					
					
					
					
					if ("userIp".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetUserIp(value);
					}
					
					
					
					
					
					if ("isHold".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetIsHold(value);
					}
					
					
					
					
					
					if ("isSpecial".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetIsSpecial(value);
					}
					
					
					
					
					
					if ("opFlag".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetOpFlag(value);
					}
					
					
					
					
					
					if ("operator".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOperator(value);
					}
					
					
					
					
					
					if ("orderFlag".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOrderFlag(value);
					}
					
					
					
					
					
					if ("payStatus".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetPayStatus(value);
					}
					
					
					
					
					
					if ("payTime".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetPayTime(value);
					}
					
					
					
					
					
					if ("payType".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetPayType(value);
					}
					
					
					
					
					
					if ("returnType".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetReturnType(value);
					}
					
					
					
					
					
					if ("source".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSource(value);
					}
					
					
					
					
					
					if ("orderStatus".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetOrderStatus(value);
					}
					
					
					
					
					
					if ("walletMoneyPaid".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetWalletMoneyPaid(value);
					}
					
					
					
					
					
					if ("orderType".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetOrderType(value);
					}
					
					
					
					
					
					if ("orderUpdateTime".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetOrderUpdateTime(value);
					}
					
					
					
					
					
					if ("userId".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetUserId(value);
					}
					
					
					
					
					
					if ("userName".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetUserName(value);
					}
					
					
					
					
					
					if ("virtualMoneyPaid".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetVirtualMoneyPaid(value);
					}
					
					
					
					
					
					if ("wmsFlag".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetWmsFlag(value);
					}
					
					
					
					
					
					if ("payTypeName".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPayTypeName(value);
					}
					
					
					
					
					
					if ("realPayTypeName".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetRealPayTypeName(value);
					}
					
					
					
					
					
					if ("payStatusName".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPayStatusName(value);
					}
					
					
					
					
					
					if ("orderTypeName".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOrderTypeName(value);
					}
					
					
					
					
					
					if ("orderStatusName".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOrderStatusName(value);
					}
					
					
					
					
					
					if ("clientType".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetClientType(value);
					}
					
					
					
					
					
					if ("queueStatus".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetQueueStatus(value);
					}
					
					
					
					
					
					if ("orderSubStatus".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetOrderSubStatus(value);
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
		
		
		public void Write(PrepayOrderExtendVO structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetParentSn() != null) {
				
				oprot.WriteFieldBegin("parentSn");
				oprot.WriteString(structs.GetParentSn());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderCode() != null) {
				
				oprot.WriteFieldBegin("orderCode");
				oprot.WriteString(structs.GetOrderCode());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPeriods() != null) {
				
				oprot.WriteFieldBegin("periods");
				oprot.WriteI32((int)structs.GetPeriods()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetIsFirst() != null) {
				
				oprot.WriteFieldBegin("isFirst");
				oprot.WriteI32((int)structs.GetIsFirst()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetIsLast() != null) {
				
				oprot.WriteFieldBegin("isLast");
				oprot.WriteI32((int)structs.GetIsLast()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetIsLock() != null) {
				
				oprot.WriteFieldBegin("isLock");
				oprot.WriteI32((int)structs.GetIsLock()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPayId() != null) {
				
				oprot.WriteFieldBegin("payId");
				oprot.WriteI64((long)structs.GetPayId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTotalMoney() != null) {
				
				oprot.WriteFieldBegin("totalMoney");
				oprot.WriteString(structs.GetTotalMoney());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetStartPayTime() != null) {
				
				oprot.WriteFieldBegin("startPayTime");
				oprot.WriteI64((long)structs.GetStartPayTime()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetEndPayTime() != null) {
				
				oprot.WriteFieldBegin("endPayTime");
				oprot.WriteI64((long)structs.GetEndPayTime()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderId() != null) {
				
				oprot.WriteFieldBegin("orderId");
				oprot.WriteI64((long)structs.GetOrderId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderAddTime() != null) {
				
				oprot.WriteFieldBegin("orderAddTime");
				oprot.WriteI64((long)structs.GetOrderAddTime()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCreateTime() != null) {
				
				oprot.WriteFieldBegin("createTime");
				oprot.WriteI64((long)structs.GetCreateTime()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetMoneyPaid() != null) {
				
				oprot.WriteFieldBegin("moneyPaid");
				oprot.WriteString(structs.GetMoneyPaid());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetAuditTime() != null) {
				
				oprot.WriteFieldBegin("auditTime");
				oprot.WriteI64((long)structs.GetAuditTime()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCouponId() != null) {
				
				oprot.WriteFieldBegin("couponId");
				oprot.WriteI32((int)structs.GetCouponId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCouponMoneyPaid() != null) {
				
				oprot.WriteFieldBegin("couponMoneyPaid");
				oprot.WriteString(structs.GetCouponMoneyPaid());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCurrency() != null) {
				
				oprot.WriteFieldBegin("currency");
				oprot.WriteString(structs.GetCurrency());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderDate() != null) {
				
				oprot.WriteFieldBegin("orderDate");
				oprot.WriteI64((long)structs.GetOrderDate()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetDiscountRate() != null) {
				
				oprot.WriteFieldBegin("discountRate");
				oprot.WriteString(structs.GetDiscountRate());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetUserIp() != null) {
				
				oprot.WriteFieldBegin("userIp");
				oprot.WriteString(structs.GetUserIp());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetIsHold() != null) {
				
				oprot.WriteFieldBegin("isHold");
				oprot.WriteI32((int)structs.GetIsHold()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetIsSpecial() != null) {
				
				oprot.WriteFieldBegin("isSpecial");
				oprot.WriteI32((int)structs.GetIsSpecial()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOpFlag() != null) {
				
				oprot.WriteFieldBegin("opFlag");
				oprot.WriteI32((int)structs.GetOpFlag()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOperator() != null) {
				
				oprot.WriteFieldBegin("operator");
				oprot.WriteString(structs.GetOperator());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderFlag() != null) {
				
				oprot.WriteFieldBegin("orderFlag");
				oprot.WriteString(structs.GetOrderFlag());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPayStatus() != null) {
				
				oprot.WriteFieldBegin("payStatus");
				oprot.WriteI32((int)structs.GetPayStatus()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPayTime() != null) {
				
				oprot.WriteFieldBegin("payTime");
				oprot.WriteI64((long)structs.GetPayTime()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPayType() != null) {
				
				oprot.WriteFieldBegin("payType");
				oprot.WriteI32((int)structs.GetPayType()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetReturnType() != null) {
				
				oprot.WriteFieldBegin("returnType");
				oprot.WriteI32((int)structs.GetReturnType()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSource() != null) {
				
				oprot.WriteFieldBegin("source");
				oprot.WriteString(structs.GetSource());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderStatus() != null) {
				
				oprot.WriteFieldBegin("orderStatus");
				oprot.WriteI32((int)structs.GetOrderStatus()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetWalletMoneyPaid() != null) {
				
				oprot.WriteFieldBegin("walletMoneyPaid");
				oprot.WriteString(structs.GetWalletMoneyPaid());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderType() != null) {
				
				oprot.WriteFieldBegin("orderType");
				oprot.WriteI32((int)structs.GetOrderType()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderUpdateTime() != null) {
				
				oprot.WriteFieldBegin("orderUpdateTime");
				oprot.WriteI64((long)structs.GetOrderUpdateTime()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetUserId() != null) {
				
				oprot.WriteFieldBegin("userId");
				oprot.WriteI64((long)structs.GetUserId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetUserName() != null) {
				
				oprot.WriteFieldBegin("userName");
				oprot.WriteString(structs.GetUserName());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetVirtualMoneyPaid() != null) {
				
				oprot.WriteFieldBegin("virtualMoneyPaid");
				oprot.WriteString(structs.GetVirtualMoneyPaid());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetWmsFlag() != null) {
				
				oprot.WriteFieldBegin("wmsFlag");
				oprot.WriteI32((int)structs.GetWmsFlag()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPayTypeName() != null) {
				
				oprot.WriteFieldBegin("payTypeName");
				oprot.WriteString(structs.GetPayTypeName());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetRealPayTypeName() != null) {
				
				oprot.WriteFieldBegin("realPayTypeName");
				oprot.WriteString(structs.GetRealPayTypeName());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPayStatusName() != null) {
				
				oprot.WriteFieldBegin("payStatusName");
				oprot.WriteString(structs.GetPayStatusName());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderTypeName() != null) {
				
				oprot.WriteFieldBegin("orderTypeName");
				oprot.WriteString(structs.GetOrderTypeName());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderStatusName() != null) {
				
				oprot.WriteFieldBegin("orderStatusName");
				oprot.WriteString(structs.GetOrderStatusName());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetClientType() != null) {
				
				oprot.WriteFieldBegin("clientType");
				oprot.WriteI32((int)structs.GetClientType()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetQueueStatus() != null) {
				
				oprot.WriteFieldBegin("queueStatus");
				oprot.WriteI32((int)structs.GetQueueStatus()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderSubStatus() != null) {
				
				oprot.WriteFieldBegin("orderSubStatus");
				oprot.WriteI32((int)structs.GetOrderSubStatus()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(PrepayOrderExtendVO bean){
			
			
		}
		
	}
	
}