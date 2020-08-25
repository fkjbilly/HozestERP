using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.biz.response{
	
	
	
	public class ConfirmOrderGroupBuyRespHelper : TBeanSerializer<ConfirmOrderGroupBuyResp>
	{
		
		public static ConfirmOrderGroupBuyRespHelper OBJ = new ConfirmOrderGroupBuyRespHelper();
		
		public static ConfirmOrderGroupBuyRespHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(ConfirmOrderGroupBuyResp structs, Protocol iprot){
			
			
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
					
					
					
					
					
					if ("statusList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.order.common.pojo.order.vo.ConfirmOrderGroupBuyVO> value;
						
						value = new List<com.vip.order.common.pojo.order.vo.ConfirmOrderGroupBuyVO>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.order.common.pojo.order.vo.ConfirmOrderGroupBuyVO elem1;
								
								elem1 = new com.vip.order.common.pojo.order.vo.ConfirmOrderGroupBuyVO();
								com.vip.order.common.pojo.order.vo.ConfirmOrderGroupBuyVOHelper.getInstance().Read(elem1, iprot);
								
								value.Add(elem1);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetStatusList(value);
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
		
		
		public void Write(ConfirmOrderGroupBuyResp structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetResult() != null) {
				
				oprot.WriteFieldBegin("result");
				
				com.vip.order.common.pojo.order.result.ResultHelper.getInstance().Write(structs.GetResult(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetStatusList() != null) {
				
				oprot.WriteFieldBegin("statusList");
				
				oprot.WriteListBegin();
				foreach(com.vip.order.common.pojo.order.vo.ConfirmOrderGroupBuyVO _item0 in structs.GetStatusList()){
					
					
					com.vip.order.common.pojo.order.vo.ConfirmOrderGroupBuyVOHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(ConfirmOrderGroupBuyResp bean){
			
			
		}
		
	}
	
}