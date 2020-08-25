using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.biz.request{
	
	
	
	public class CancelOrderReqHelper : TBeanSerializer<CancelOrderReq>
	{
		
		public static CancelOrderReqHelper OBJ = new CancelOrderReqHelper();
		
		public static CancelOrderReqHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(CancelOrderReq structs, Protocol iprot){
			
			
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
					
					
					
					
					
					if ("orderCategory".Equals(schemeField.Trim())){
						
						needSkip = false;
						byte? value;
						value = iprot.ReadByte(); 
						
						structs.SetOrderCategory(value);
					}
					
					
					
					
					
					if ("orderId".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetOrderId(value);
					}
					
					
					
					
					
					if ("orderSn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOrderSn(value);
					}
					
					
					
					
					
					if ("reasonChoice".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetReasonChoice(value);
					}
					
					
					
					
					
					if ("reasonRemark".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetReasonRemark(value);
					}
					
					
					
					
					
					if ("isPreview".Equals(schemeField.Trim())){
						
						needSkip = false;
						bool? value;
						value = iprot.ReadBool();
						
						structs.SetIsPreview(value);
					}
					
					
					
					
					
					if ("appVersion".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetAppVersion(value);
					}
					
					
					
					
					
					if ("opType".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetOpType(value);
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
		
		
		public void Write(CancelOrderReq structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetUserId() != null) {
				
				oprot.WriteFieldBegin("userId");
				oprot.WriteI64((long)structs.GetUserId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderCategory() != null) {
				
				oprot.WriteFieldBegin("orderCategory");
				oprot.WriteByte((byte)structs.GetOrderCategory()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderId() != null) {
				
				oprot.WriteFieldBegin("orderId");
				oprot.WriteI64((long)structs.GetOrderId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderSn() != null) {
				
				oprot.WriteFieldBegin("orderSn");
				oprot.WriteString(structs.GetOrderSn());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetReasonChoice() != null) {
				
				oprot.WriteFieldBegin("reasonChoice");
				oprot.WriteI32((int)structs.GetReasonChoice()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetReasonRemark() != null) {
				
				oprot.WriteFieldBegin("reasonRemark");
				oprot.WriteString(structs.GetReasonRemark());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetIsPreview() != null) {
				
				oprot.WriteFieldBegin("isPreview");
				oprot.WriteBool((bool)structs.GetIsPreview());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetAppVersion() != null) {
				
				oprot.WriteFieldBegin("appVersion");
				oprot.WriteString(structs.GetAppVersion());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOpType() != null) {
				
				oprot.WriteFieldBegin("opType");
				oprot.WriteI32((int)structs.GetOpType()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(CancelOrderReq bean){
			
			
		}
		
	}
	
}