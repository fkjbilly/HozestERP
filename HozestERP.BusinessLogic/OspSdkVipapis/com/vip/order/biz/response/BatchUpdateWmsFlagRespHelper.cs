using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.biz.response{
	
	
	
	public class BatchUpdateWmsFlagRespHelper : TBeanSerializer<BatchUpdateWmsFlagResp>
	{
		
		public static BatchUpdateWmsFlagRespHelper OBJ = new BatchUpdateWmsFlagRespHelper();
		
		public static BatchUpdateWmsFlagRespHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(BatchUpdateWmsFlagResp structs, Protocol iprot){
			
			
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
					
					
					
					
					
					if ("successList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.order.common.pojo.order.vo.OrderSnAndIdVO> value;
						
						value = new List<com.vip.order.common.pojo.order.vo.OrderSnAndIdVO>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.order.common.pojo.order.vo.OrderSnAndIdVO elem1;
								
								elem1 = new com.vip.order.common.pojo.order.vo.OrderSnAndIdVO();
								com.vip.order.common.pojo.order.vo.OrderSnAndIdVOHelper.getInstance().Read(elem1, iprot);
								
								value.Add(elem1);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetSuccessList(value);
					}
					
					
					
					
					
					if ("failList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.order.common.pojo.order.vo.OrderSnAndIdVO> value;
						
						value = new List<com.vip.order.common.pojo.order.vo.OrderSnAndIdVO>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.order.common.pojo.order.vo.OrderSnAndIdVO elem3;
								
								elem3 = new com.vip.order.common.pojo.order.vo.OrderSnAndIdVO();
								com.vip.order.common.pojo.order.vo.OrderSnAndIdVOHelper.getInstance().Read(elem3, iprot);
								
								value.Add(elem3);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetFailList(value);
					}
					
					
					
					
					
					if ("filterList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.order.common.pojo.order.vo.OrderSnAndIdVO> value;
						
						value = new List<com.vip.order.common.pojo.order.vo.OrderSnAndIdVO>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.order.common.pojo.order.vo.OrderSnAndIdVO elem5;
								
								elem5 = new com.vip.order.common.pojo.order.vo.OrderSnAndIdVO();
								com.vip.order.common.pojo.order.vo.OrderSnAndIdVOHelper.getInstance().Read(elem5, iprot);
								
								value.Add(elem5);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetFilterList(value);
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
		
		
		public void Write(BatchUpdateWmsFlagResp structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetResult() != null) {
				
				oprot.WriteFieldBegin("result");
				
				com.vip.order.common.pojo.order.result.ResultHelper.getInstance().Write(structs.GetResult(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSuccessList() != null) {
				
				oprot.WriteFieldBegin("successList");
				
				oprot.WriteListBegin();
				foreach(com.vip.order.common.pojo.order.vo.OrderSnAndIdVO _item0 in structs.GetSuccessList()){
					
					
					com.vip.order.common.pojo.order.vo.OrderSnAndIdVOHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetFailList() != null) {
				
				oprot.WriteFieldBegin("failList");
				
				oprot.WriteListBegin();
				foreach(com.vip.order.common.pojo.order.vo.OrderSnAndIdVO _item0 in structs.GetFailList()){
					
					
					com.vip.order.common.pojo.order.vo.OrderSnAndIdVOHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetFilterList() != null) {
				
				oprot.WriteFieldBegin("filterList");
				
				oprot.WriteListBegin();
				foreach(com.vip.order.common.pojo.order.vo.OrderSnAndIdVO _item0 in structs.GetFilterList()){
					
					
					com.vip.order.common.pojo.order.vo.OrderSnAndIdVOHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(BatchUpdateWmsFlagResp bean){
			
			
		}
		
	}
	
}