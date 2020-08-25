using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.biz.request{
	
	
	
	public class BatchGetOrderTransportListReqHelper : TBeanSerializer<BatchGetOrderTransportListReq>
	{
		
		public static BatchGetOrderTransportListReqHelper OBJ = new BatchGetOrderTransportListReqHelper();
		
		public static BatchGetOrderTransportListReqHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(BatchGetOrderTransportListReq structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("idRange".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.order.common.pojo.order.request.RangeParam value;
						
						value = new com.vip.order.common.pojo.order.request.RangeParam();
						com.vip.order.common.pojo.order.request.RangeParamHelper.getInstance().Read(value, iprot);
						
						structs.SetIdRange(value);
					}
					
					
					
					
					
					if ("transportCodeRange".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.order.common.pojo.order.request.RangeParam value;
						
						value = new com.vip.order.common.pojo.order.request.RangeParam();
						com.vip.order.common.pojo.order.request.RangeParamHelper.getInstance().Read(value, iprot);
						
						structs.SetTransportCodeRange(value);
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
		
		
		public void Write(BatchGetOrderTransportListReq structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetIdRange() != null) {
				
				oprot.WriteFieldBegin("idRange");
				
				com.vip.order.common.pojo.order.request.RangeParamHelper.getInstance().Write(structs.GetIdRange(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTransportCodeRange() != null) {
				
				oprot.WriteFieldBegin("transportCodeRange");
				
				com.vip.order.common.pojo.order.request.RangeParamHelper.getInstance().Write(structs.GetTransportCodeRange(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(BatchGetOrderTransportListReq bean){
			
			
		}
		
	}
	
}