using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.biz.request{
	
	
	
	public class PutOrderToRollbackQueueReqHelper : TBeanSerializer<PutOrderToRollbackQueueReq>
	{
		
		public static PutOrderToRollbackQueueReqHelper OBJ = new PutOrderToRollbackQueueReqHelper();
		
		public static PutOrderToRollbackQueueReqHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(PutOrderToRollbackQueueReq structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("orderSnList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.order.common.pojo.order.vo.OrderSnAndIdVO> value;
						
						value = new List<com.vip.order.common.pojo.order.vo.OrderSnAndIdVO>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.order.common.pojo.order.vo.OrderSnAndIdVO elem0;
								
								elem0 = new com.vip.order.common.pojo.order.vo.OrderSnAndIdVO();
								com.vip.order.common.pojo.order.vo.OrderSnAndIdVOHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetOrderSnList(value);
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
		
		
		public void Write(PutOrderToRollbackQueueReq structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetOrderSnList() != null) {
				
				oprot.WriteFieldBegin("orderSnList");
				
				oprot.WriteListBegin();
				foreach(com.vip.order.common.pojo.order.vo.OrderSnAndIdVO _item0 in structs.GetOrderSnList()){
					
					
					com.vip.order.common.pojo.order.vo.OrderSnAndIdVOHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(PutOrderToRollbackQueueReq bean){
			
			
		}
		
	}
	
}