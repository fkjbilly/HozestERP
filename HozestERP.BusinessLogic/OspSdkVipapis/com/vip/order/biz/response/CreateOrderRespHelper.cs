using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.biz.response{
	
	
	
	public class CreateOrderRespHelper : TBeanSerializer<CreateOrderResp>
	{
		
		public static CreateOrderRespHelper OBJ = new CreateOrderRespHelper();
		
		public static CreateOrderRespHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(CreateOrderResp structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("result".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.order.biz.response.Result value;
						
						value = new com.vip.order.biz.response.Result();
						com.vip.order.biz.response.ResultHelper.getInstance().Read(value, iprot);
						
						structs.SetResult(value);
					}
					
					
					
					
					
					if ("orderIdSnList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.order.biz.vo.CreateOrdersItemVO> value;
						
						value = new List<com.vip.order.biz.vo.CreateOrdersItemVO>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.order.biz.vo.CreateOrdersItemVO elem2;
								
								elem2 = new com.vip.order.biz.vo.CreateOrdersItemVO();
								com.vip.order.biz.vo.CreateOrdersItemVOHelper.getInstance().Read(elem2, iprot);
								
								value.Add(elem2);
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
		
		
		public void Write(CreateOrderResp structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetResult() != null) {
				
				oprot.WriteFieldBegin("result");
				
				com.vip.order.biz.response.ResultHelper.getInstance().Write(structs.GetResult(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderIdSnList() != null) {
				
				oprot.WriteFieldBegin("orderIdSnList");
				
				oprot.WriteListBegin();
				foreach(com.vip.order.biz.vo.CreateOrdersItemVO _item0 in structs.GetOrderIdSnList()){
					
					
					com.vip.order.biz.vo.CreateOrdersItemVOHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(CreateOrderResp bean){
			
			
		}
		
	}
	
}