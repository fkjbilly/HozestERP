using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.biz.request{
	
	
	
	public class AddOrderTransportReqHelper : TBeanSerializer<AddOrderTransportReq>
	{
		
		public static AddOrderTransportReqHelper OBJ = new AddOrderTransportReqHelper();
		
		public static AddOrderTransportReqHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(AddOrderTransportReq structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("userId".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetUserId(value);
					}
					
					
					
					
					
					if ("orderTransportDetailVO".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.order.common.pojo.order.vo.OrderTransportDetailVO value;
						
						value = new com.vip.order.common.pojo.order.vo.OrderTransportDetailVO();
						com.vip.order.common.pojo.order.vo.OrderTransportDetailVOHelper.getInstance().Read(value, iprot);
						
						structs.SetOrderTransportDetailVO(value);
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
		
		
		public void Write(AddOrderTransportReq structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetUserId() != null) {
				
				oprot.WriteFieldBegin("userId");
				oprot.WriteI64((long)structs.GetUserId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderTransportDetailVO() != null) {
				
				oprot.WriteFieldBegin("orderTransportDetailVO");
				
				com.vip.order.common.pojo.order.vo.OrderTransportDetailVOHelper.getInstance().Write(structs.GetOrderTransportDetailVO(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(AddOrderTransportReq bean){
			
			
		}
		
	}
	
}