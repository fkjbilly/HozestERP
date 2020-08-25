using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.biz.response{
	
	
	
	public class GetMergeOrderRespHelper : TBeanSerializer<GetMergeOrderResp>
	{
		
		public static GetMergeOrderRespHelper OBJ = new GetMergeOrderRespHelper();
		
		public static GetMergeOrderRespHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(GetMergeOrderResp structs, Protocol iprot){
			
			
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
					
					
					
					
					
					if ("mainOrder".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.order.biz.response.MergeOrderItem value;
						
						value = new com.vip.order.biz.response.MergeOrderItem();
						com.vip.order.biz.response.MergeOrderItemHelper.getInstance().Read(value, iprot);
						
						structs.SetMainOrder(value);
					}
					
					
					
					
					
					if ("canMergeOrders".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.order.biz.response.MergeOrderItem> value;
						
						value = new List<com.vip.order.biz.response.MergeOrderItem>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.order.biz.response.MergeOrderItem elem2;
								
								elem2 = new com.vip.order.biz.response.MergeOrderItem();
								com.vip.order.biz.response.MergeOrderItemHelper.getInstance().Read(elem2, iprot);
								
								value.Add(elem2);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetCanMergeOrders(value);
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
		
		
		public void Write(GetMergeOrderResp structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetResult() != null) {
				
				oprot.WriteFieldBegin("result");
				
				com.vip.order.common.pojo.order.result.ResultHelper.getInstance().Write(structs.GetResult(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetMainOrder() != null) {
				
				oprot.WriteFieldBegin("mainOrder");
				
				com.vip.order.biz.response.MergeOrderItemHelper.getInstance().Write(structs.GetMainOrder(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCanMergeOrders() != null) {
				
				oprot.WriteFieldBegin("canMergeOrders");
				
				oprot.WriteListBegin();
				foreach(com.vip.order.biz.response.MergeOrderItem _item0 in structs.GetCanMergeOrders()){
					
					
					com.vip.order.biz.response.MergeOrderItemHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(GetMergeOrderResp bean){
			
			
		}
		
	}
	
}