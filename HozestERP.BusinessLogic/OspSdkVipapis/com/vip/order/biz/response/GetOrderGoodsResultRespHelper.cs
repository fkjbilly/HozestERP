using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.biz.response{
	
	
	
	public class GetOrderGoodsResultRespHelper : TBeanSerializer<GetOrderGoodsResultResp>
	{
		
		public static GetOrderGoodsResultRespHelper OBJ = new GetOrderGoodsResultRespHelper();
		
		public static GetOrderGoodsResultRespHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(GetOrderGoodsResultResp structs, Protocol iprot){
			
			
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
					
					
					
					
					
					if ("getOrderGoodsItemList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.order.biz.response.GetOrderGoodsItem> value;
						
						value = new List<com.vip.order.biz.response.GetOrderGoodsItem>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.order.biz.response.GetOrderGoodsItem elem1;
								
								elem1 = new com.vip.order.biz.response.GetOrderGoodsItem();
								com.vip.order.biz.response.GetOrderGoodsItemHelper.getInstance().Read(elem1, iprot);
								
								value.Add(elem1);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetGetOrderGoodsItemList(value);
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
		
		
		public void Write(GetOrderGoodsResultResp structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetResult() != null) {
				
				oprot.WriteFieldBegin("result");
				
				com.vip.order.common.pojo.order.result.ResultHelper.getInstance().Write(structs.GetResult(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetGetOrderGoodsItemList() != null) {
				
				oprot.WriteFieldBegin("getOrderGoodsItemList");
				
				oprot.WriteListBegin();
				foreach(com.vip.order.biz.response.GetOrderGoodsItem _item0 in structs.GetGetOrderGoodsItemList()){
					
					
					com.vip.order.biz.response.GetOrderGoodsItemHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(GetOrderGoodsResultResp bean){
			
			
		}
		
	}
	
}