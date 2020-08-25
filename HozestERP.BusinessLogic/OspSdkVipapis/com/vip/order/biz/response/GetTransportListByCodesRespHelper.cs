using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.biz.response{
	
	
	
	public class GetTransportListByCodesRespHelper : TBeanSerializer<GetTransportListByCodesResp>
	{
		
		public static GetTransportListByCodesRespHelper OBJ = new GetTransportListByCodesRespHelper();
		
		public static GetTransportListByCodesRespHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(GetTransportListByCodesResp structs, Protocol iprot){
			
			
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
					
					
					
					
					
					if ("transportDetailList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.order.common.pojo.order.vo.OrderTransportDetailVO> value;
						
						value = new List<com.vip.order.common.pojo.order.vo.OrderTransportDetailVO>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.order.common.pojo.order.vo.OrderTransportDetailVO elem1;
								
								elem1 = new com.vip.order.common.pojo.order.vo.OrderTransportDetailVO();
								com.vip.order.common.pojo.order.vo.OrderTransportDetailVOHelper.getInstance().Read(elem1, iprot);
								
								value.Add(elem1);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetTransportDetailList(value);
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
		
		
		public void Write(GetTransportListByCodesResp structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetResult() != null) {
				
				oprot.WriteFieldBegin("result");
				
				com.vip.order.common.pojo.order.result.ResultHelper.getInstance().Write(structs.GetResult(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTransportDetailList() != null) {
				
				oprot.WriteFieldBegin("transportDetailList");
				
				oprot.WriteListBegin();
				foreach(com.vip.order.common.pojo.order.vo.OrderTransportDetailVO _item0 in structs.GetTransportDetailList()){
					
					
					com.vip.order.common.pojo.order.vo.OrderTransportDetailVOHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(GetTransportListByCodesResp bean){
			
			
		}
		
	}
	
}