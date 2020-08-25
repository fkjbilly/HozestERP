using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.biz.response{
	
	
	
	public class GetOrderOpStatusRespHelper : TBeanSerializer<GetOrderOpStatusResp>
	{
		
		public static GetOrderOpStatusRespHelper OBJ = new GetOrderOpStatusRespHelper();
		
		public static GetOrderOpStatusRespHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(GetOrderOpStatusResp structs, Protocol iprot){
			
			
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
					
					
					
					
					
					if ("orderOpList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.order.biz.response.OrderOpStatus> value;
						
						value = new List<com.vip.order.biz.response.OrderOpStatus>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.order.biz.response.OrderOpStatus elem2;
								
								elem2 = new com.vip.order.biz.response.OrderOpStatus();
								com.vip.order.biz.response.OrderOpStatusHelper.getInstance().Read(elem2, iprot);
								
								value.Add(elem2);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetOrderOpList(value);
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
		
		
		public void Write(GetOrderOpStatusResp structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetResult() != null) {
				
				oprot.WriteFieldBegin("result");
				
				com.vip.order.common.pojo.order.result.ResultHelper.getInstance().Write(structs.GetResult(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderOpList() != null) {
				
				oprot.WriteFieldBegin("orderOpList");
				
				oprot.WriteListBegin();
				foreach(com.vip.order.biz.response.OrderOpStatus _item0 in structs.GetOrderOpList()){
					
					
					com.vip.order.biz.response.OrderOpStatusHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(GetOrderOpStatusResp bean){
			
			
		}
		
	}
	
}