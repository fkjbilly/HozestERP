using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.biz.response{
	
	
	
	public class BatchGetOrderListRespHelper : TBeanSerializer<BatchGetOrderListResp>
	{
		
		public static BatchGetOrderListRespHelper OBJ = new BatchGetOrderListRespHelper();
		
		public static BatchGetOrderListRespHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(BatchGetOrderListResp structs, Protocol iprot){
			
			
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
					
					
					
					
					
					if ("orderInfoList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.order.common.pojo.order.vo.OrderInfoVO> value;
						
						value = new List<com.vip.order.common.pojo.order.vo.OrderInfoVO>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.order.common.pojo.order.vo.OrderInfoVO elem2;
								
								elem2 = new com.vip.order.common.pojo.order.vo.OrderInfoVO();
								com.vip.order.common.pojo.order.vo.OrderInfoVOHelper.getInstance().Read(elem2, iprot);
								
								value.Add(elem2);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetOrderInfoList(value);
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
		
		
		public void Write(BatchGetOrderListResp structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetResult() != null) {
				
				oprot.WriteFieldBegin("result");
				
				com.vip.order.common.pojo.order.result.ResultHelper.getInstance().Write(structs.GetResult(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderInfoList() != null) {
				
				oprot.WriteFieldBegin("orderInfoList");
				
				oprot.WriteListBegin();
				foreach(com.vip.order.common.pojo.order.vo.OrderInfoVO _item0 in structs.GetOrderInfoList()){
					
					
					com.vip.order.common.pojo.order.vo.OrderInfoVOHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(BatchGetOrderListResp bean){
			
			
		}
		
	}
	
}