using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.biz.response{
	
	
	
	public class UpdateOrderPayResultRespHelper : TBeanSerializer<UpdateOrderPayResultResp>
	{
		
		public static UpdateOrderPayResultRespHelper OBJ = new UpdateOrderPayResultRespHelper();
		
		public static UpdateOrderPayResultRespHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(UpdateOrderPayResultResp structs, Protocol iprot){
			
			
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
						List<com.vip.order.common.pojo.order.vo.NotifyResponseOrderVO> value;
						
						value = new List<com.vip.order.common.pojo.order.vo.NotifyResponseOrderVO>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.order.common.pojo.order.vo.NotifyResponseOrderVO elem1;
								
								elem1 = new com.vip.order.common.pojo.order.vo.NotifyResponseOrderVO();
								com.vip.order.common.pojo.order.vo.NotifyResponseOrderVOHelper.getInstance().Read(elem1, iprot);
								
								value.Add(elem1);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetOrderList(value);
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
		
		
		public void Write(UpdateOrderPayResultResp structs, Protocol oprot){
			
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
				foreach(com.vip.order.common.pojo.order.vo.NotifyResponseOrderVO _item0 in structs.GetOrderList()){
					
					
					com.vip.order.common.pojo.order.vo.NotifyResponseOrderVOHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(UpdateOrderPayResultResp bean){
			
			
		}
		
	}
	
}