using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.biz.response{
	
	
	
	public class VerifyStockAndGetPayableFlagRespHelper : TBeanSerializer<VerifyStockAndGetPayableFlagResp>
	{
		
		public static VerifyStockAndGetPayableFlagRespHelper OBJ = new VerifyStockAndGetPayableFlagRespHelper();
		
		public static VerifyStockAndGetPayableFlagRespHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(VerifyStockAndGetPayableFlagResp structs, Protocol iprot){
			
			
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
					
					
					
					
					
					if ("verifyStockAndGetPayableFlagVO".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.order.biz.vo.VerifyStockAndGetPayableFlagVO value;
						
						value = new com.vip.order.biz.vo.VerifyStockAndGetPayableFlagVO();
						com.vip.order.biz.vo.VerifyStockAndGetPayableFlagVOHelper.getInstance().Read(value, iprot);
						
						structs.SetVerifyStockAndGetPayableFlagVO(value);
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
		
		
		public void Write(VerifyStockAndGetPayableFlagResp structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetResult() != null) {
				
				oprot.WriteFieldBegin("result");
				
				com.vip.order.common.pojo.order.result.ResultHelper.getInstance().Write(structs.GetResult(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetVerifyStockAndGetPayableFlagVO() != null) {
				
				oprot.WriteFieldBegin("verifyStockAndGetPayableFlagVO");
				
				com.vip.order.biz.vo.VerifyStockAndGetPayableFlagVOHelper.getInstance().Write(structs.GetVerifyStockAndGetPayableFlagVO(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(VerifyStockAndGetPayableFlagResp bean){
			
			
		}
		
	}
	
}