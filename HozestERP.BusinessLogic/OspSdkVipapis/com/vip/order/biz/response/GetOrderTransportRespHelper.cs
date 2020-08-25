using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.biz.response{
	
	
	
	public class GetOrderTransportRespHelper : TBeanSerializer<GetOrderTransportResp>
	{
		
		public static GetOrderTransportRespHelper OBJ = new GetOrderTransportRespHelper();
		
		public static GetOrderTransportRespHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(GetOrderTransportResp structs, Protocol iprot){
			
			
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
					
					
					
					
					
					if ("transportList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.order.common.pojo.order.vo.TransportVO> value;
						
						value = new List<com.vip.order.common.pojo.order.vo.TransportVO>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.order.common.pojo.order.vo.TransportVO elem1;
								
								elem1 = new com.vip.order.common.pojo.order.vo.TransportVO();
								com.vip.order.common.pojo.order.vo.TransportVOHelper.getInstance().Read(elem1, iprot);
								
								value.Add(elem1);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetTransportList(value);
					}
					
					
					
					
					
					if ("transportFlagList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.order.common.pojo.order.vo.FlagVO> value;
						
						value = new List<com.vip.order.common.pojo.order.vo.FlagVO>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.order.common.pojo.order.vo.FlagVO elem3;
								
								elem3 = new com.vip.order.common.pojo.order.vo.FlagVO();
								com.vip.order.common.pojo.order.vo.FlagVOHelper.getInstance().Read(elem3, iprot);
								
								value.Add(elem3);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetTransportFlagList(value);
					}
					
					
					
					
					
					if ("orderReturnMoney".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.order.common.pojo.order.vo.OrderReturnMoneyVO value;
						
						value = new com.vip.order.common.pojo.order.vo.OrderReturnMoneyVO();
						com.vip.order.common.pojo.order.vo.OrderReturnMoneyVOHelper.getInstance().Read(value, iprot);
						
						structs.SetOrderReturnMoney(value);
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
		
		
		public void Write(GetOrderTransportResp structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetResult() != null) {
				
				oprot.WriteFieldBegin("result");
				
				com.vip.order.common.pojo.order.result.ResultHelper.getInstance().Write(structs.GetResult(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTransportList() != null) {
				
				oprot.WriteFieldBegin("transportList");
				
				oprot.WriteListBegin();
				foreach(com.vip.order.common.pojo.order.vo.TransportVO _item0 in structs.GetTransportList()){
					
					
					com.vip.order.common.pojo.order.vo.TransportVOHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTransportFlagList() != null) {
				
				oprot.WriteFieldBegin("transportFlagList");
				
				oprot.WriteListBegin();
				foreach(com.vip.order.common.pojo.order.vo.FlagVO _item0 in structs.GetTransportFlagList()){
					
					
					com.vip.order.common.pojo.order.vo.FlagVOHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderReturnMoney() != null) {
				
				oprot.WriteFieldBegin("orderReturnMoney");
				
				com.vip.order.common.pojo.order.vo.OrderReturnMoneyVOHelper.getInstance().Write(structs.GetOrderReturnMoney(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(GetOrderTransportResp bean){
			
			
		}
		
	}
	
}