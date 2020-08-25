using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.biz.request{
	
	
	
	public class ModifyOrderPayTypeRspHelper : TBeanSerializer<ModifyOrderPayTypeRsp>
	{
		
		public static ModifyOrderPayTypeRspHelper OBJ = new ModifyOrderPayTypeRspHelper();
		
		public static ModifyOrderPayTypeRspHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(ModifyOrderPayTypeRsp structs, Protocol iprot){
			
			
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
					
					
					
					
					
					if ("isSuccess".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetIsSuccess(value);
					}
					
					
					
					
					
					if ("ModifyPayTypeRsp".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.order.biz.request.OrderInfo> value;
						
						value = new List<com.vip.order.biz.request.OrderInfo>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.order.biz.request.OrderInfo elem2;
								
								elem2 = new com.vip.order.biz.request.OrderInfo();
								com.vip.order.biz.request.OrderInfoHelper.getInstance().Read(elem2, iprot);
								
								value.Add(elem2);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetModifyPayTypeRsp(value);
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
		
		
		public void Write(ModifyOrderPayTypeRsp structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetResult() != null) {
				
				oprot.WriteFieldBegin("result");
				
				com.vip.order.common.pojo.order.result.ResultHelper.getInstance().Write(structs.GetResult(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetIsSuccess() != null) {
				
				oprot.WriteFieldBegin("isSuccess");
				oprot.WriteI32((int)structs.GetIsSuccess()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetModifyPayTypeRsp() != null) {
				
				oprot.WriteFieldBegin("ModifyPayTypeRsp");
				
				oprot.WriteListBegin();
				foreach(com.vip.order.biz.request.OrderInfo _item0 in structs.GetModifyPayTypeRsp()){
					
					
					com.vip.order.biz.request.OrderInfoHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(ModifyOrderPayTypeRsp bean){
			
			
		}
		
	}
	
}