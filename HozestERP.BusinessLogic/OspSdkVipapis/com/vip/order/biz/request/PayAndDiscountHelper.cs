using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.biz.request{
	
	
	
	public class PayAndDiscountHelper : TBeanSerializer<PayAndDiscount>
	{
		
		public static PayAndDiscountHelper OBJ = new PayAndDiscountHelper();
		
		public static PayAndDiscountHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(PayAndDiscount structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("couponId".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetCouponId(value);
					}
					
					
					
					
					
					if ("couponMoney".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCouponMoney(value);
					}
					
					
					
					
					
					if ("isCancelCoupon".Equals(schemeField.Trim())){
						
						needSkip = false;
						bool? value;
						value = iprot.ReadBool();
						
						structs.SetIsCancelCoupon(value);
					}
					
					
					
					
					
					if ("isForceUseCoupon".Equals(schemeField.Trim())){
						
						needSkip = false;
						bool? value;
						value = iprot.ReadBool();
						
						structs.SetIsForceUseCoupon(value);
					}
					
					
					
					
					
					if ("useWalletMoney".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetUseWalletMoney(value);
					}
					
					
					
					
					
					if ("discountRate".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetDiscountRate(value);
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
		
		
		public void Write(PayAndDiscount structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetCouponId() != null) {
				
				oprot.WriteFieldBegin("couponId");
				oprot.WriteI64((long)structs.GetCouponId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCouponMoney() != null) {
				
				oprot.WriteFieldBegin("couponMoney");
				oprot.WriteString(structs.GetCouponMoney());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetIsCancelCoupon() != null) {
				
				oprot.WriteFieldBegin("isCancelCoupon");
				oprot.WriteBool((bool)structs.GetIsCancelCoupon());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetIsForceUseCoupon() != null) {
				
				oprot.WriteFieldBegin("isForceUseCoupon");
				oprot.WriteBool((bool)structs.GetIsForceUseCoupon());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetUseWalletMoney() != null) {
				
				oprot.WriteFieldBegin("useWalletMoney");
				oprot.WriteI32((int)structs.GetUseWalletMoney()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetDiscountRate() != null) {
				
				oprot.WriteFieldBegin("discountRate");
				oprot.WriteString(structs.GetDiscountRate());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(PayAndDiscount bean){
			
			
		}
		
	}
	
}