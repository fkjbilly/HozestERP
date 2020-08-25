using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.biz.response{
	
	
	
	public class CalculateSplitOrderMoneyRespHelper : TBeanSerializer<CalculateSplitOrderMoneyResp>
	{
		
		public static CalculateSplitOrderMoneyRespHelper OBJ = new CalculateSplitOrderMoneyRespHelper();
		
		public static CalculateSplitOrderMoneyRespHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(CalculateSplitOrderMoneyResp structs, Protocol iprot){
			
			
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
					
					
					
					
					
					if ("splitOrderList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.order.common.pojo.order.vo.SplitOrderVO> value;
						
						value = new List<com.vip.order.common.pojo.order.vo.SplitOrderVO>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.order.common.pojo.order.vo.SplitOrderVO elem1;
								
								elem1 = new com.vip.order.common.pojo.order.vo.SplitOrderVO();
								com.vip.order.common.pojo.order.vo.SplitOrderVOHelper.getInstance().Read(elem1, iprot);
								
								value.Add(elem1);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetSplitOrderList(value);
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
		
		
		public void Write(CalculateSplitOrderMoneyResp structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetResult() != null) {
				
				oprot.WriteFieldBegin("result");
				
				com.vip.order.common.pojo.order.result.ResultHelper.getInstance().Write(structs.GetResult(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSplitOrderList() != null) {
				
				oprot.WriteFieldBegin("splitOrderList");
				
				oprot.WriteListBegin();
				foreach(com.vip.order.common.pojo.order.vo.SplitOrderVO _item0 in structs.GetSplitOrderList()){
					
					
					com.vip.order.common.pojo.order.vo.SplitOrderVOHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(CalculateSplitOrderMoneyResp bean){
			
			
		}
		
	}
	
}