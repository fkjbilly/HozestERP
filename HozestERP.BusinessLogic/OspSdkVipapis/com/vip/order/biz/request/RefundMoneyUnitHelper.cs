using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.biz.request{
	
	
	
	public class RefundMoneyUnitHelper : TBeanSerializer<RefundMoneyUnit>
	{
		
		public static RefundMoneyUnitHelper OBJ = new RefundMoneyUnitHelper();
		
		public static RefundMoneyUnitHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(RefundMoneyUnit structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("refundType".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetRefundType(value);
					}
					
					
					
					
					
					if ("payType".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetPayType(value);
					}
					
					
					
					
					
					if ("money".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetMoney(value);
					}
					
					
					
					
					
					if ("surplus".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSurplus(value);
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
					
					
					
					
					
					if ("couponId".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetCouponId(value);
					}
					
					
					
					
					
					if ("totalPacketMoney".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTotalPacketMoney(value);
					}
					
					
					
					
					
					if ("total".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTotal(value);
					}
					
					
					
					
					
					if ("remark".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetRemark(value);
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
		
		
		public void Write(RefundMoneyUnit structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetRefundType() != null) {
				
				oprot.WriteFieldBegin("refundType");
				oprot.WriteI32((int)structs.GetRefundType()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPayType() != null) {
				
				oprot.WriteFieldBegin("payType");
				oprot.WriteI32((int)structs.GetPayType()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetMoney() != null) {
				
				oprot.WriteFieldBegin("money");
				oprot.WriteString(structs.GetMoney());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSurplus() != null) {
				
				oprot.WriteFieldBegin("surplus");
				oprot.WriteString(structs.GetSurplus());
				
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
			
			
			if(structs.GetCouponId() != null) {
				
				oprot.WriteFieldBegin("couponId");
				oprot.WriteI32((int)structs.GetCouponId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTotalPacketMoney() != null) {
				
				oprot.WriteFieldBegin("totalPacketMoney");
				oprot.WriteString(structs.GetTotalPacketMoney());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTotal() != null) {
				
				oprot.WriteFieldBegin("total");
				oprot.WriteString(structs.GetTotal());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetRemark() != null) {
				
				oprot.WriteFieldBegin("remark");
				oprot.WriteString(structs.GetRemark());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(RefundMoneyUnit bean){
			
			
		}
		
	}
	
}