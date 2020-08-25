using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.common.pojo.order.vo{
	
	
	
	public class OrderCancelDataVOHelper : TBeanSerializer<OrderCancelDataVO>
	{
		
		public static OrderCancelDataVOHelper OBJ = new OrderCancelDataVOHelper();
		
		public static OrderCancelDataVOHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(OrderCancelDataVO structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
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
					
					
					
					
					
					if ("totalMoney".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTotalMoney(value);
					}
					
					
					
					
					
					if ("couponMoney".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCouponMoney(value);
					}
					
					
					
					
					
					if ("returnCouponType".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetReturnCouponType(value);
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
		
		
		public void Write(OrderCancelDataVO structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
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
			
			
			if(structs.GetTotalMoney() != null) {
				
				oprot.WriteFieldBegin("totalMoney");
				oprot.WriteString(structs.GetTotalMoney());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCouponMoney() != null) {
				
				oprot.WriteFieldBegin("couponMoney");
				oprot.WriteString(structs.GetCouponMoney());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetReturnCouponType() != null) {
				
				oprot.WriteFieldBegin("returnCouponType");
				oprot.WriteI32((int)structs.GetReturnCouponType()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(OrderCancelDataVO bean){
			
			
		}
		
	}
	
}