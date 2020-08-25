using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.biz.request{
	
	
	
	public class PrepayOrderInfoForReqHelper : TBeanSerializer<PrepayOrderInfoForReq>
	{
		
		public static PrepayOrderInfoForReqHelper OBJ = new PrepayOrderInfoForReqHelper();
		
		public static PrepayOrderInfoForReqHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(PrepayOrderInfoForReq structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("prepayOrderExtend".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.order.common.pojo.order.vo.PrepayOrderExtendVO value;
						
						value = new com.vip.order.common.pojo.order.vo.PrepayOrderExtendVO();
						com.vip.order.common.pojo.order.vo.PrepayOrderExtendVOHelper.getInstance().Read(value, iprot);
						
						structs.SetPrepayOrderExtend(value);
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
		
		
		public void Write(PrepayOrderInfoForReq structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetPrepayOrderExtend() != null) {
				
				oprot.WriteFieldBegin("prepayOrderExtend");
				
				com.vip.order.common.pojo.order.vo.PrepayOrderExtendVOHelper.getInstance().Write(structs.GetPrepayOrderExtend(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(PrepayOrderInfoForReq bean){
			
			
		}
		
	}
	
}