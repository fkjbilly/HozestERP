using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.biz.response{
	
	
	
	public class GetCanAfterSaleOrderListRespHelper : TBeanSerializer<GetCanAfterSaleOrderListResp>
	{
		
		public static GetCanAfterSaleOrderListRespHelper OBJ = new GetCanAfterSaleOrderListRespHelper();
		
		public static GetCanAfterSaleOrderListRespHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(GetCanAfterSaleOrderListResp structs, Protocol iprot){
			
			
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
					
					
					
					
					
					if ("canAfterSaleOrderInfoList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.order.biz.response.CanAfterSaleOrderInfo> value;
						
						value = new List<com.vip.order.biz.response.CanAfterSaleOrderInfo>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.order.biz.response.CanAfterSaleOrderInfo elem1;
								
								elem1 = new com.vip.order.biz.response.CanAfterSaleOrderInfo();
								com.vip.order.biz.response.CanAfterSaleOrderInfoHelper.getInstance().Read(elem1, iprot);
								
								value.Add(elem1);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetCanAfterSaleOrderInfoList(value);
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
		
		
		public void Write(GetCanAfterSaleOrderListResp structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetResult() != null) {
				
				oprot.WriteFieldBegin("result");
				
				com.vip.order.common.pojo.order.result.ResultHelper.getInstance().Write(structs.GetResult(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCanAfterSaleOrderInfoList() != null) {
				
				oprot.WriteFieldBegin("canAfterSaleOrderInfoList");
				
				oprot.WriteListBegin();
				foreach(com.vip.order.biz.response.CanAfterSaleOrderInfo _item0 in structs.GetCanAfterSaleOrderInfoList()){
					
					
					com.vip.order.biz.response.CanAfterSaleOrderInfoHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(GetCanAfterSaleOrderListResp bean){
			
			
		}
		
	}
	
}