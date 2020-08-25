using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.biz.request{
	
	
	
	public class SignOrderReqHelper : TBeanSerializer<SignOrderReq>
	{
		
		public static SignOrderReqHelper OBJ = new SignOrderReqHelper();
		
		public static SignOrderReqHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(SignOrderReq structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("orderSnAndUserId".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.order.common.pojo.order.vo.OrderSnAndIdVO value;
						
						value = new com.vip.order.common.pojo.order.vo.OrderSnAndIdVO();
						com.vip.order.common.pojo.order.vo.OrderSnAndIdVOHelper.getInstance().Read(value, iprot);
						
						structs.SetOrderSnAndUserId(value);
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
		
		
		public void Write(SignOrderReq structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetOrderSnAndUserId() != null) {
				
				oprot.WriteFieldBegin("orderSnAndUserId");
				
				com.vip.order.common.pojo.order.vo.OrderSnAndIdVOHelper.getInstance().Write(structs.GetOrderSnAndUserId(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(SignOrderReq bean){
			
			
		}
		
	}
	
}