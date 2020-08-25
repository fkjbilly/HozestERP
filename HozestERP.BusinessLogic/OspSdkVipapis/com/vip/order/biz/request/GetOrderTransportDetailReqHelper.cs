using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.biz.request{
	
	
	
	public class GetOrderTransportDetailReqHelper : TBeanSerializer<GetOrderTransportDetailReq>
	{
		
		public static GetOrderTransportDetailReqHelper OBJ = new GetOrderTransportDetailReqHelper();
		
		public static GetOrderTransportDetailReqHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(GetOrderTransportDetailReq structs, Protocol iprot){
			
			
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
					
					
					
					
					
					if ("orderSn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOrderSn(value);
					}
					
					
					
					
					
					if ("orderDelivery".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.order.common.pojo.order.vo.OrderDeliveryVO value;
						
						value = new com.vip.order.common.pojo.order.vo.OrderDeliveryVO();
						com.vip.order.common.pojo.order.vo.OrderDeliveryVOHelper.getInstance().Read(value, iprot);
						
						structs.SetOrderDelivery(value);
					}
					
					
					
					
					
					if ("vipClub".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetVipClub(value);
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
		
		
		public void Write(GetOrderTransportDetailReq structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetUserId() != null) {
				
				oprot.WriteFieldBegin("userId");
				oprot.WriteI64((long)structs.GetUserId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderSn() != null) {
				
				oprot.WriteFieldBegin("orderSn");
				oprot.WriteString(structs.GetOrderSn());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderDelivery() != null) {
				
				oprot.WriteFieldBegin("orderDelivery");
				
				com.vip.order.common.pojo.order.vo.OrderDeliveryVOHelper.getInstance().Write(structs.GetOrderDelivery(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetVipClub() != null) {
				
				oprot.WriteFieldBegin("vipClub");
				oprot.WriteString(structs.GetVipClub());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(GetOrderTransportDetailReq bean){
			
			
		}
		
	}
	
}