using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.biz.response{
	
	
	
	public class GetPrepayOrderUnpayMsgRespHelper : TBeanSerializer<GetPrepayOrderUnpayMsgResp>
	{
		
		public static GetPrepayOrderUnpayMsgRespHelper OBJ = new GetPrepayOrderUnpayMsgRespHelper();
		
		public static GetPrepayOrderUnpayMsgRespHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(GetPrepayOrderUnpayMsgResp structs, Protocol iprot){
			
			
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
					
					
					
					
					
					if ("msgList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.order.biz.response.PrepayOrderUnpayMsg> value;
						
						value = new List<com.vip.order.biz.response.PrepayOrderUnpayMsg>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.order.biz.response.PrepayOrderUnpayMsg elem1;
								
								elem1 = new com.vip.order.biz.response.PrepayOrderUnpayMsg();
								com.vip.order.biz.response.PrepayOrderUnpayMsgHelper.getInstance().Read(elem1, iprot);
								
								value.Add(elem1);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetMsgList(value);
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
		
		
		public void Write(GetPrepayOrderUnpayMsgResp structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetResult() != null) {
				
				oprot.WriteFieldBegin("result");
				
				com.vip.order.common.pojo.order.result.ResultHelper.getInstance().Write(structs.GetResult(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetMsgList() != null) {
				
				oprot.WriteFieldBegin("msgList");
				
				oprot.WriteListBegin();
				foreach(com.vip.order.biz.response.PrepayOrderUnpayMsg _item0 in structs.GetMsgList()){
					
					
					com.vip.order.biz.response.PrepayOrderUnpayMsgHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(GetPrepayOrderUnpayMsgResp bean){
			
			
		}
		
	}
	
}