using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.biz.response{
	
	
	
	public class CreateOrderRespV2Helper : TBeanSerializer<CreateOrderRespV2>
	{
		
		public static CreateOrderRespV2Helper OBJ = new CreateOrderRespV2Helper();
		
		public static CreateOrderRespV2Helper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(CreateOrderRespV2 structs, Protocol iprot){
			
			
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
					
					
					
					
					
					if ("orderIdSnList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.order.common.pojo.order.vo.CreateOrdersItemVO> value;
						
						value = new List<com.vip.order.common.pojo.order.vo.CreateOrdersItemVO>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.order.common.pojo.order.vo.CreateOrdersItemVO elem1;
								
								elem1 = new com.vip.order.common.pojo.order.vo.CreateOrdersItemVO();
								com.vip.order.common.pojo.order.vo.CreateOrdersItemVOHelper.getInstance().Read(elem1, iprot);
								
								value.Add(elem1);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetOrderIdSnList(value);
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
		
		
		public void Write(CreateOrderRespV2 structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetResult() != null) {
				
				oprot.WriteFieldBegin("result");
				
				com.vip.order.common.pojo.order.result.ResultHelper.getInstance().Write(structs.GetResult(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderIdSnList() != null) {
				
				oprot.WriteFieldBegin("orderIdSnList");
				
				oprot.WriteListBegin();
				foreach(com.vip.order.common.pojo.order.vo.CreateOrdersItemVO _item0 in structs.GetOrderIdSnList()){
					
					
					com.vip.order.common.pojo.order.vo.CreateOrdersItemVOHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(CreateOrderRespV2 bean){
			
			
		}
		
	}
	
}