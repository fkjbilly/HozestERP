using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.biz.request{
	
	
	
	public class OrderRefundReqHelper : TBeanSerializer<OrderRefundReq>
	{
		
		public static OrderRefundReqHelper OBJ = new OrderRefundReqHelper();
		
		public static OrderRefundReqHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(OrderRefundReq structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("refundMoney".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.order.biz.request.RefundMoneyUnit value;
						
						value = new com.vip.order.biz.request.RefundMoneyUnit();
						com.vip.order.biz.request.RefundMoneyUnitHelper.getInstance().Read(value, iprot);
						
						structs.SetRefundMoney(value);
					}
					
					
					
					
					
					if ("orderSn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOrderSn(value);
					}
					
					
					
					
					
					if ("userId".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetUserId(value);
					}
					
					
					
					
					
					if ("orderCategory".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetOrderCategory(value);
					}
					
					
					
					
					
					if ("sceneType".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetSceneType(value);
					}
					
					
					
					
					
					if ("billType".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetBillType(value);
					}
					
					
					
					
					
					if ("refundReason".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetRefundReason(value);
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
		
		
		public void Write(OrderRefundReq structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetRefundMoney() != null) {
				
				oprot.WriteFieldBegin("refundMoney");
				
				com.vip.order.biz.request.RefundMoneyUnitHelper.getInstance().Write(structs.GetRefundMoney(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderSn() != null) {
				
				oprot.WriteFieldBegin("orderSn");
				oprot.WriteString(structs.GetOrderSn());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetUserId() != null) {
				
				oprot.WriteFieldBegin("userId");
				oprot.WriteI64((long)structs.GetUserId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderCategory() != null) {
				
				oprot.WriteFieldBegin("orderCategory");
				oprot.WriteI32((int)structs.GetOrderCategory()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSceneType() != null) {
				
				oprot.WriteFieldBegin("sceneType");
				oprot.WriteI32((int)structs.GetSceneType()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBillType() != null) {
				
				oprot.WriteFieldBegin("billType");
				oprot.WriteI32((int)structs.GetBillType()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetRefundReason() != null) {
				
				oprot.WriteFieldBegin("refundReason");
				oprot.WriteString(structs.GetRefundReason());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(OrderRefundReq bean){
			
			
		}
		
	}
	
}