using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.biz.response{
	
	
	
	public class GetOrdersBySizeIdRespHelper : TBeanSerializer<GetOrdersBySizeIdResp>
	{
		
		public static GetOrdersBySizeIdRespHelper OBJ = new GetOrdersBySizeIdRespHelper();
		
		public static GetOrdersBySizeIdRespHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(GetOrdersBySizeIdResp structs, Protocol iprot){
			
			
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
					
					
					
					
					
					if ("infoList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.order.common.pojo.order.vo.GetOrdersBySizeIdInfoVO> value;
						
						value = new List<com.vip.order.common.pojo.order.vo.GetOrdersBySizeIdInfoVO>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.order.common.pojo.order.vo.GetOrdersBySizeIdInfoVO elem1;
								
								elem1 = new com.vip.order.common.pojo.order.vo.GetOrdersBySizeIdInfoVO();
								com.vip.order.common.pojo.order.vo.GetOrdersBySizeIdInfoVOHelper.getInstance().Read(elem1, iprot);
								
								value.Add(elem1);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetInfoList(value);
					}
					
					
					
					
					
					if ("total".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetTotal(value);
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
		
		
		public void Write(GetOrdersBySizeIdResp structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetResult() != null) {
				
				oprot.WriteFieldBegin("result");
				
				com.vip.order.common.pojo.order.result.ResultHelper.getInstance().Write(structs.GetResult(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetInfoList() != null) {
				
				oprot.WriteFieldBegin("infoList");
				
				oprot.WriteListBegin();
				foreach(com.vip.order.common.pojo.order.vo.GetOrdersBySizeIdInfoVO _item0 in structs.GetInfoList()){
					
					
					com.vip.order.common.pojo.order.vo.GetOrdersBySizeIdInfoVOHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTotal() != null) {
				
				oprot.WriteFieldBegin("total");
				oprot.WriteI32((int)structs.GetTotal()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(GetOrdersBySizeIdResp bean){
			
			
		}
		
	}
	
}