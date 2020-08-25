using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.biz.response{
	
	
	
	public class LinkageCancelOrderInfoHelper : TBeanSerializer<LinkageCancelOrderInfo>
	{
		
		public static LinkageCancelOrderInfoHelper OBJ = new LinkageCancelOrderInfoHelper();
		
		public static LinkageCancelOrderInfoHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(LinkageCancelOrderInfo structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("result".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.order.common.pojo.order.result.Result value;
						
						value = new com.vip.order.common.pojo.order.result.Result();
						com.vip.order.common.pojo.order.result.ResultHelper.getInstance().Read(value, iprot);
						
						structs.SetResult(value);
					}
					
					
					
					
					
					if ("returnBrandCouponStatus".Equals(schemeField.Trim())){
						
						needSkip = false;
						byte? value;
						value = iprot.ReadByte(); 
						
						structs.SetReturnBrandCouponStatus(value);
					}
					
					
					
					
					
					if ("returnType".Equals(schemeField.Trim())){
						
						needSkip = false;
						byte? value;
						value = iprot.ReadByte(); 
						
						structs.SetReturnType(value);
					}
					
					
					
					
					
					if ("previewInfo".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.order.biz.response.PreviewInfoResp value;
						
						value = new com.vip.order.biz.response.PreviewInfoResp();
						com.vip.order.biz.response.PreviewInfoRespHelper.getInstance().Read(value, iprot);
						
						structs.SetPreviewInfo(value);
					}
					
					
					
					
					
					if ("orderSn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOrderSn(value);
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
		
		
		public void Write(LinkageCancelOrderInfo structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetResult() != null) {
				
				oprot.WriteFieldBegin("result");
				
				com.vip.order.common.pojo.order.result.ResultHelper.getInstance().Write(structs.GetResult(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetReturnBrandCouponStatus() != null) {
				
				oprot.WriteFieldBegin("returnBrandCouponStatus");
				oprot.WriteByte((byte)structs.GetReturnBrandCouponStatus()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetReturnType() != null) {
				
				oprot.WriteFieldBegin("returnType");
				oprot.WriteByte((byte)structs.GetReturnType()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPreviewInfo() != null) {
				
				oprot.WriteFieldBegin("previewInfo");
				
				com.vip.order.biz.response.PreviewInfoRespHelper.getInstance().Write(structs.GetPreviewInfo(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderSn() != null) {
				
				oprot.WriteFieldBegin("orderSn");
				oprot.WriteString(structs.GetOrderSn());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(LinkageCancelOrderInfo bean){
			
			
		}
		
	}
	
}