using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.biz.response{
	
	
	
	public class GetOrderListByPosNoRespHelper : TBeanSerializer<GetOrderListByPosNoResp>
	{
		
		public static GetOrderListByPosNoRespHelper OBJ = new GetOrderListByPosNoRespHelper();
		
		public static GetOrderListByPosNoRespHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(GetOrderListByPosNoResp structs, Protocol iprot){
			
			
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
					
					
					
					
					
					if ("orderPosMap".Equals(schemeField.Trim())){
						
						needSkip = false;
						Dictionary<string, List<com.vip.order.common.pojo.order.vo.OrderByPosVO>> value;
						
						value = new Dictionary<string, List<com.vip.order.common.pojo.order.vo.OrderByPosVO>>();
						iprot.ReadMapBegin();
						while(true){
							
							try{
								
								string _key1;
								List<com.vip.order.common.pojo.order.vo.OrderByPosVO> _val1;
								_key1 = iprot.ReadString();
								
								
								_val1 = new List<com.vip.order.common.pojo.order.vo.OrderByPosVO>();
								iprot.ReadListBegin();
								while(true){
									
									try{
										
										com.vip.order.common.pojo.order.vo.OrderByPosVO elem2;
										
										elem2 = new com.vip.order.common.pojo.order.vo.OrderByPosVO();
										com.vip.order.common.pojo.order.vo.OrderByPosVOHelper.getInstance().Read(elem2, iprot);
										
										_val1.Add(elem2);
									}
									catch(Exception e){
										
										
										break;
									}
								}
								
								iprot.ReadListEnd();
								
								value.Add(_key1, _val1);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadMapEnd();
						
						structs.SetOrderPosMap(value);
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
		
		
		public void Write(GetOrderListByPosNoResp structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetResult() != null) {
				
				oprot.WriteFieldBegin("result");
				
				com.vip.order.common.pojo.order.result.ResultHelper.getInstance().Write(structs.GetResult(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderPosMap() != null) {
				
				oprot.WriteFieldBegin("orderPosMap");
				
				oprot.WriteMapBegin();
				foreach(KeyValuePair< string, List<com.vip.order.common.pojo.order.vo.OrderByPosVO> > _ir0 in structs.GetOrderPosMap()){
					
					string _key0 = _ir0.Key;
					List<com.vip.order.common.pojo.order.vo.OrderByPosVO> _value0 = _ir0.Value;
					oprot.WriteString(_key0);
					
					
					oprot.WriteListBegin();
					foreach(com.vip.order.common.pojo.order.vo.OrderByPosVO _item1 in _value0){
						
						
						com.vip.order.common.pojo.order.vo.OrderByPosVOHelper.getInstance().Write(_item1, oprot);
						
					}
					
					oprot.WriteListEnd();
					
				}
				
				oprot.WriteMapEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(GetOrderListByPosNoResp bean){
			
			
		}
		
	}
	
}