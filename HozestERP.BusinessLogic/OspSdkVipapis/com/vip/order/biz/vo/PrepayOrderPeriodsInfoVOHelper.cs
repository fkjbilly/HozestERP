using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.biz.vo{
	
	
	
	public class PrepayOrderPeriodsInfoVOHelper : TBeanSerializer<PrepayOrderPeriodsInfoVO>
	{
		
		public static PrepayOrderPeriodsInfoVOHelper OBJ = new PrepayOrderPeriodsInfoVOHelper();
		
		public static PrepayOrderPeriodsInfoVOHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(PrepayOrderPeriodsInfoVO structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("seq".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetSeq(value);
					}
					
					
					
					
					
					if ("money".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetMoney(value);
					}
					
					
					
					
					
					if ("walletMoney".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetWalletMoney(value);
					}
					
					
					
					
					
					if ("virtualMoney".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetVirtualMoney(value);
					}
					
					
					
					
					
					if ("couponMoney".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCouponMoney(value);
					}
					
					
					
					
					
					if ("payType".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetPayType(value);
					}
					
					
					
					
					
					if ("payId".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetPayId(value);
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
		
		
		public void Write(PrepayOrderPeriodsInfoVO structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetSeq() != null) {
				
				oprot.WriteFieldBegin("seq");
				oprot.WriteI32((int)structs.GetSeq()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetMoney() != null) {
				
				oprot.WriteFieldBegin("money");
				oprot.WriteString(structs.GetMoney());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetWalletMoney() != null) {
				
				oprot.WriteFieldBegin("walletMoney");
				oprot.WriteString(structs.GetWalletMoney());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetVirtualMoney() != null) {
				
				oprot.WriteFieldBegin("virtualMoney");
				oprot.WriteString(structs.GetVirtualMoney());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCouponMoney() != null) {
				
				oprot.WriteFieldBegin("couponMoney");
				oprot.WriteString(structs.GetCouponMoney());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPayType() != null) {
				
				oprot.WriteFieldBegin("payType");
				oprot.WriteI32((int)structs.GetPayType()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPayId() != null) {
				
				oprot.WriteFieldBegin("payId");
				oprot.WriteI64((long)structs.GetPayId()); 
				
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
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(PrepayOrderPeriodsInfoVO bean){
			
			
		}
		
	}
	
}