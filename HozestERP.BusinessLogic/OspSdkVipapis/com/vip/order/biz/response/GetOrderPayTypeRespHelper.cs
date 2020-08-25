using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.biz.response{
	
	
	
	public class GetOrderPayTypeRespHelper : TBeanSerializer<GetOrderPayTypeResp>
	{
		
		public static GetOrderPayTypeRespHelper OBJ = new GetOrderPayTypeRespHelper();
		
		public static GetOrderPayTypeRespHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(GetOrderPayTypeResp structs, Protocol iprot){
			
			
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
					
					
					
					
					
					if ("ordersPayTypeList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.order.common.pojo.order.vo.OrdersPayTypeVO> value;
						
						value = new List<com.vip.order.common.pojo.order.vo.OrdersPayTypeVO>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.order.common.pojo.order.vo.OrdersPayTypeVO elem2;
								
								elem2 = new com.vip.order.common.pojo.order.vo.OrdersPayTypeVO();
								com.vip.order.common.pojo.order.vo.OrdersPayTypeVOHelper.getInstance().Read(elem2, iprot);
								
								value.Add(elem2);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetOrdersPayTypeList(value);
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
		
		
		public void Write(GetOrderPayTypeResp structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetResult() != null) {
				
				oprot.WriteFieldBegin("result");
				
				com.vip.order.common.pojo.order.result.ResultHelper.getInstance().Write(structs.GetResult(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrdersPayTypeList() != null) {
				
				oprot.WriteFieldBegin("ordersPayTypeList");
				
				oprot.WriteListBegin();
				foreach(com.vip.order.common.pojo.order.vo.OrdersPayTypeVO _item0 in structs.GetOrdersPayTypeList()){
					
					
					com.vip.order.common.pojo.order.vo.OrdersPayTypeVOHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(GetOrderPayTypeResp bean){
			
			
		}
		
	}
	
}