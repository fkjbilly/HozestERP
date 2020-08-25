using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.biz.request{
	
	
	
	public class BatchGetOrderActiveDetailReqHelper : TBeanSerializer<BatchGetOrderActiveDetailReq>
	{
		
		public static BatchGetOrderActiveDetailReqHelper OBJ = new BatchGetOrderActiveDetailReqHelper();
		
		public static BatchGetOrderActiveDetailReqHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(BatchGetOrderActiveDetailReq structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("orderSnAndUserIdList".Equals(schemeField.Trim())){
						
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
						
						structs.SetOrderSnAndUserIdList(value);
					}
					
					
					
					
					
					if ("activeTypeRange".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.order.common.pojo.order.request.RangeParam value;
						
						value = new com.vip.order.common.pojo.order.request.RangeParam();
						com.vip.order.common.pojo.order.request.RangeParamHelper.getInstance().Read(value, iprot);
						
						structs.SetActiveTypeRange(value);
					}
					
					
					
					
					
					if ("activeFieldRange".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.order.common.pojo.order.request.RangeParam value;
						
						value = new com.vip.order.common.pojo.order.request.RangeParam();
						com.vip.order.common.pojo.order.request.RangeParamHelper.getInstance().Read(value, iprot);
						
						structs.SetActiveFieldRange(value);
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
		
		
		public void Write(BatchGetOrderActiveDetailReq structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetOrderSnAndUserIdList() != null) {
				
				oprot.WriteFieldBegin("orderSnAndUserIdList");
				
				oprot.WriteListBegin();
				foreach(com.vip.order.common.pojo.order.vo.OrderSnAndIdVO _item0 in structs.GetOrderSnAndUserIdList()){
					
					
					com.vip.order.common.pojo.order.vo.OrderSnAndIdVOHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetActiveTypeRange() != null) {
				
				oprot.WriteFieldBegin("activeTypeRange");
				
				com.vip.order.common.pojo.order.request.RangeParamHelper.getInstance().Write(structs.GetActiveTypeRange(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetActiveFieldRange() != null) {
				
				oprot.WriteFieldBegin("activeFieldRange");
				
				com.vip.order.common.pojo.order.request.RangeParamHelper.getInstance().Write(structs.GetActiveFieldRange(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(BatchGetOrderActiveDetailReq bean){
			
			
		}
		
	}
	
}