using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.biz.response{
	
	
	
	public class PutIntoSplitQueueRespHelper : TBeanSerializer<PutIntoSplitQueueResp>
	{
		
		public static PutIntoSplitQueueRespHelper OBJ = new PutIntoSplitQueueRespHelper();
		
		public static PutIntoSplitQueueRespHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(PutIntoSplitQueueResp structs, Protocol iprot){
			
			
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
					
					
					
					
					
					if ("orderResultList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.order.biz.response.OrderResult> value;
						
						value = new List<com.vip.order.biz.response.OrderResult>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.order.biz.response.OrderResult elem2;
								
								elem2 = new com.vip.order.biz.response.OrderResult();
								com.vip.order.biz.response.OrderResultHelper.getInstance().Read(elem2, iprot);
								
								value.Add(elem2);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetOrderResultList(value);
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
		
		
		public void Write(PutIntoSplitQueueResp structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetResult() != null) {
				
				oprot.WriteFieldBegin("result");
				
				com.vip.order.common.pojo.order.result.ResultHelper.getInstance().Write(structs.GetResult(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderResultList() != null) {
				
				oprot.WriteFieldBegin("orderResultList");
				
				oprot.WriteListBegin();
				foreach(com.vip.order.biz.response.OrderResult _item0 in structs.GetOrderResultList()){
					
					
					com.vip.order.biz.response.OrderResultHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(PutIntoSplitQueueResp bean){
			
			
		}
		
	}
	
}