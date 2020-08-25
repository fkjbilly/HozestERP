using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.biz.vo{
	
	
	
	public class OrderPayAndDiscountVOHelper : TBeanSerializer<OrderPayAndDiscountVO>
	{
		
		public static OrderPayAndDiscountVOHelper OBJ = new OrderPayAndDiscountVOHelper();
		
		public static OrderPayAndDiscountVOHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(OrderPayAndDiscountVO structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("payId".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetPayId(value);
					}
					
					
					
					
					
					if ("payType".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetPayType(value);
					}
					
					
					
					
					
					if ("payStatus".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetPayStatus(value);
					}
					
					
					
					
					
					if ("currency".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCurrency(value);
					}
					
					
					
					
					
					if ("moneyPaid".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetMoneyPaid(value);
					}
					
					
					
					
					
					if ("moneyRemaining".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetMoneyRemaining(value);
					}
					
					
					
					
					
					if ("walletMoneyPaid".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetWalletMoneyPaid(value);
					}
					
					
					
					
					
					if ("walletMoneyRemaining".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetWalletMoneyRemaining(value);
					}
					
					
					
					
					
					if ("virtualMoneyPaid".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetVirtualMoneyPaid(value);
					}
					
					
					
					
					
					if ("virtualMoneyRemaining".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetVirtualMoneyRemaining(value);
					}
					
					
					
					
					
					if ("discountRate".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetDiscountRate(value);
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
					
					
					
					
					
					if ("couponMoneyRemaining".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCouponMoneyRemaining(value);
					}
					
					
					
					
					
					if ("exDiscountType".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetExDiscountType(value);
					}
					
					
					
					
					
					if ("exDiscountMoneyPaid".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetExDiscountMoneyPaid(value);
					}
					
					
					
					
					
					if ("exDiscountMoneyRemaining".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetExDiscountMoneyRemaining(value);
					}
					
					
					
					
					
					if ("returnType".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetReturnType(value);
					}
					
					
					
					
					
					if ("isDelete".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetIsDelete(value);
					}
					
					
					
					
					
					if ("payTime".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetPayTime(value);
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
		
		
		public void Write(OrderPayAndDiscountVO structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetPayId() != null) {
				
				oprot.WriteFieldBegin("payId");
				oprot.WriteI32((int)structs.GetPayId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPayType() != null) {
				
				oprot.WriteFieldBegin("payType");
				oprot.WriteI32((int)structs.GetPayType()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPayStatus() != null) {
				
				oprot.WriteFieldBegin("payStatus");
				oprot.WriteI32((int)structs.GetPayStatus()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCurrency() != null) {
				
				oprot.WriteFieldBegin("currency");
				oprot.WriteString(structs.GetCurrency());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetMoneyPaid() != null) {
				
				oprot.WriteFieldBegin("moneyPaid");
				oprot.WriteString(structs.GetMoneyPaid());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetMoneyRemaining() != null) {
				
				oprot.WriteFieldBegin("moneyRemaining");
				oprot.WriteString(structs.GetMoneyRemaining());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetWalletMoneyPaid() != null) {
				
				oprot.WriteFieldBegin("walletMoneyPaid");
				oprot.WriteString(structs.GetWalletMoneyPaid());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetWalletMoneyRemaining() != null) {
				
				oprot.WriteFieldBegin("walletMoneyRemaining");
				oprot.WriteString(structs.GetWalletMoneyRemaining());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetVirtualMoneyPaid() != null) {
				
				oprot.WriteFieldBegin("virtualMoneyPaid");
				oprot.WriteString(structs.GetVirtualMoneyPaid());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetVirtualMoneyRemaining() != null) {
				
				oprot.WriteFieldBegin("virtualMoneyRemaining");
				oprot.WriteString(structs.GetVirtualMoneyRemaining());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetDiscountRate() != null) {
				
				oprot.WriteFieldBegin("discountRate");
				oprot.WriteString(structs.GetDiscountRate());
				
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
			
			
			if(structs.GetCouponMoneyRemaining() != null) {
				
				oprot.WriteFieldBegin("couponMoneyRemaining");
				oprot.WriteString(structs.GetCouponMoneyRemaining());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetExDiscountType() != null) {
				
				oprot.WriteFieldBegin("exDiscountType");
				oprot.WriteString(structs.GetExDiscountType());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetExDiscountMoneyPaid() != null) {
				
				oprot.WriteFieldBegin("exDiscountMoneyPaid");
				oprot.WriteString(structs.GetExDiscountMoneyPaid());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetExDiscountMoneyRemaining() != null) {
				
				oprot.WriteFieldBegin("exDiscountMoneyRemaining");
				oprot.WriteString(structs.GetExDiscountMoneyRemaining());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetReturnType() != null) {
				
				oprot.WriteFieldBegin("returnType");
				oprot.WriteI32((int)structs.GetReturnType()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetIsDelete() != null) {
				
				oprot.WriteFieldBegin("isDelete");
				oprot.WriteI32((int)structs.GetIsDelete()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPayTime() != null) {
				
				oprot.WriteFieldBegin("payTime");
				oprot.WriteI64((long)structs.GetPayTime()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(OrderPayAndDiscountVO bean){
			
			
		}
		
	}
	
}