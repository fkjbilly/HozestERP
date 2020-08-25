using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.biz.request{
	
	
	
	public class PutIntoSplitQueueReqHelper : TBeanSerializer<PutIntoSplitQueueReq>
	{
		
		public static PutIntoSplitQueueReqHelper OBJ = new PutIntoSplitQueueReqHelper();
		
		public static PutIntoSplitQueueReqHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(PutIntoSplitQueueReq structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("orderList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.order.biz.vo.OrderSplitVO> value;
						
						value = new List<com.vip.order.biz.vo.OrderSplitVO>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.order.biz.vo.OrderSplitVO elem1;
								
								elem1 = new com.vip.order.biz.vo.OrderSplitVO();
								com.vip.order.biz.vo.OrderSplitVOHelper.getInstance().Read(elem1, iprot);
								
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
		
		
		public void Write(PutIntoSplitQueueReq structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetOrderList() != null) {
				
				oprot.WriteFieldBegin("orderList");
				
				oprot.WriteListBegin();
				foreach(com.vip.order.biz.vo.OrderSplitVO _item0 in structs.GetOrderList()){
					
					
					com.vip.order.biz.vo.OrderSplitVOHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(PutIntoSplitQueueReq bean){
			
			
		}
		
	}
	
}