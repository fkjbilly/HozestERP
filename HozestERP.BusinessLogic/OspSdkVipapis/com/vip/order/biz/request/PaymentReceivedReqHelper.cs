using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.biz.request{
	
	
	
	public class PaymentReceivedReqHelper : TBeanSerializer<PaymentReceivedReq>
	{
		
		public static PaymentReceivedReqHelper OBJ = new PaymentReceivedReqHelper();
		
		public static PaymentReceivedReqHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(PaymentReceivedReq structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
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
					
					
					
					
					
					if ("isPaySuccess".Equals(schemeField.Trim())){
						
						needSkip = false;
						bool? value;
						value = iprot.ReadBool();
						
						structs.SetIsPaySuccess(value);
					}
					
					
					
					
					
					if ("hasPriv".Equals(schemeField.Trim())){
						
						needSkip = false;
						bool? value;
						value = iprot.ReadBool();
						
						structs.SetHasPriv(value);
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
		
		
		public void Write(PaymentReceivedReq structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
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
			
			
			if(structs.GetIsPaySuccess() != null) {
				
				oprot.WriteFieldBegin("isPaySuccess");
				oprot.WriteBool((bool)structs.GetIsPaySuccess());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetHasPriv() != null) {
				
				oprot.WriteFieldBegin("hasPriv");
				oprot.WriteBool((bool)structs.GetHasPriv());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(PaymentReceivedReq bean){
			
			
		}
		
	}
	
}