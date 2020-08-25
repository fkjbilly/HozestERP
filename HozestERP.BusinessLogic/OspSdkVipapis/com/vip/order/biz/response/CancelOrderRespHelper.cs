using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.biz.response{
	
	
	
	public class CancelOrderRespHelper : TBeanSerializer<CancelOrderResp>
	{
		
		public static CancelOrderRespHelper OBJ = new CancelOrderRespHelper();
		
		public static CancelOrderRespHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(CancelOrderResp structs, Protocol iprot){
			
			
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
					
					
					
					
					
					if ("linkageCancelOrderInfoList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.order.biz.response.LinkageCancelOrderInfo> value;
						
						value = new List<com.vip.order.biz.response.LinkageCancelOrderInfo>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.order.biz.response.LinkageCancelOrderInfo elem2;
								
								elem2 = new com.vip.order.biz.response.LinkageCancelOrderInfo();
								com.vip.order.biz.response.LinkageCancelOrderInfoHelper.getInstance().Read(elem2, iprot);
								
								value.Add(elem2);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetLinkageCancelOrderInfoList(value);
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
		
		
		public void Write(CancelOrderResp structs, Protocol oprot){
			
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
			
			
			if(structs.GetLinkageCancelOrderInfoList() != null) {
				
				oprot.WriteFieldBegin("linkageCancelOrderInfoList");
				
				oprot.WriteListBegin();
				foreach(com.vip.order.biz.response.LinkageCancelOrderInfo _item0 in structs.GetLinkageCancelOrderInfoList()){
					
					
					com.vip.order.biz.response.LinkageCancelOrderInfoHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(CancelOrderResp bean){
			
			
		}
		
	}
	
}