using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.biz.response{
	
	
	
	public class GetOrderListByUserIdRespHelper : TBeanSerializer<GetOrderListByUserIdResp>
	{
		
		public static GetOrderListByUserIdRespHelper OBJ = new GetOrderListByUserIdRespHelper();
		
		public static GetOrderListByUserIdRespHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(GetOrderListByUserIdResp structs, Protocol iprot){
			
			
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
					
					
					
					
					
					if ("orderList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.order.common.pojo.order.vo.OrderInfoVO> value;
						
						value = new List<com.vip.order.common.pojo.order.vo.OrderInfoVO>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.order.common.pojo.order.vo.OrderInfoVO elem1;
								
								elem1 = new com.vip.order.common.pojo.order.vo.OrderInfoVO();
								com.vip.order.common.pojo.order.vo.OrderInfoVOHelper.getInstance().Read(elem1, iprot);
								
								value.Add(elem1);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetOrderList(value);
					}
					
					
					
					
					
					if ("parentOrderList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.order.common.pojo.order.vo.ParentOrderInfoVO> value;
						
						value = new List<com.vip.order.common.pojo.order.vo.ParentOrderInfoVO>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.order.common.pojo.order.vo.ParentOrderInfoVO elem3;
								
								elem3 = new com.vip.order.common.pojo.order.vo.ParentOrderInfoVO();
								com.vip.order.common.pojo.order.vo.ParentOrderInfoVOHelper.getInstance().Read(elem3, iprot);
								
								value.Add(elem3);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetParentOrderList(value);
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
		
		
		public void Write(GetOrderListByUserIdResp structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetResult() != null) {
				
				oprot.WriteFieldBegin("result");
				
				com.vip.order.common.pojo.order.result.ResultHelper.getInstance().Write(structs.GetResult(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderList() != null) {
				
				oprot.WriteFieldBegin("orderList");
				
				oprot.WriteListBegin();
				foreach(com.vip.order.common.pojo.order.vo.OrderInfoVO _item0 in structs.GetOrderList()){
					
					
					com.vip.order.common.pojo.order.vo.OrderInfoVOHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetParentOrderList() != null) {
				
				oprot.WriteFieldBegin("parentOrderList");
				
				oprot.WriteListBegin();
				foreach(com.vip.order.common.pojo.order.vo.ParentOrderInfoVO _item0 in structs.GetParentOrderList()){
					
					
					com.vip.order.common.pojo.order.vo.ParentOrderInfoVOHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(GetOrderListByUserIdResp bean){
			
			
		}
		
	}
	
}