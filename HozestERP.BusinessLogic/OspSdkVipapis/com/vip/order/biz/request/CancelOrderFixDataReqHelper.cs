using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.biz.request{
	
	
	
	public class CancelOrderFixDataReqHelper : TBeanSerializer<CancelOrderFixDataReq>
	{
		
		public static CancelOrderFixDataReqHelper OBJ = new CancelOrderFixDataReqHelper();
		
		public static CancelOrderFixDataReqHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(CancelOrderFixDataReq structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("operation".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOperation(value);
					}
					
					
					
					
					
					if ("orderSn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOrderSn(value);
					}
					
					
					
					
					
					if ("goodsStatus".Equals(schemeField.Trim())){
						
						needSkip = false;
						bool? value;
						value = iprot.ReadBool();
						
						structs.SetGoodsStatus(value);
					}
					
					
					
					
					
					if ("refundType".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetRefundType(value);
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
		
		
		public void Write(CancelOrderFixDataReq structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetOperation() != null) {
				
				oprot.WriteFieldBegin("operation");
				oprot.WriteString(structs.GetOperation());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderSn() != null) {
				
				oprot.WriteFieldBegin("orderSn");
				oprot.WriteString(structs.GetOrderSn());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetGoodsStatus() != null) {
				
				oprot.WriteFieldBegin("goodsStatus");
				oprot.WriteBool((bool)structs.GetGoodsStatus());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetRefundType() != null) {
				
				oprot.WriteFieldBegin("refundType");
				oprot.WriteI32((int)structs.GetRefundType()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(CancelOrderFixDataReq bean){
			
			
		}
		
	}
	
}