using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.biz.response{
	
	
	
	public class AutoPayRespHelper : TBeanSerializer<AutoPayResp>
	{
		
		public static AutoPayRespHelper OBJ = new AutoPayRespHelper();
		
		public static AutoPayRespHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(AutoPayResp structs, Protocol iprot){
			
			
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
		
		
		public void Write(AutoPayResp structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetResult() != null) {
				
				oprot.WriteFieldBegin("result");
				
				com.vip.order.common.pojo.order.result.ResultHelper.getInstance().Write(structs.GetResult(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(AutoPayResp bean){
			
			
		}
		
	}
	
}