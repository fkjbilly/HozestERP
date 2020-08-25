using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.biz.request{
	
	
	
	public class GetUserDeliveryAddressReqHelper : TBeanSerializer<GetUserDeliveryAddressReq>
	{
		
		public static GetUserDeliveryAddressReqHelper OBJ = new GetUserDeliveryAddressReqHelper();
		
		public static GetUserDeliveryAddressReqHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(GetUserDeliveryAddressReq structs, Protocol iprot){
			
			
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
					
					
					
					
					
					if ("statusRange".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.order.common.pojo.order.request.RangeParam value;
						
						value = new com.vip.order.common.pojo.order.request.RangeParam();
						com.vip.order.common.pojo.order.request.RangeParamHelper.getInstance().Read(value, iprot);
						
						structs.SetStatusRange(value);
					}
					
					
					
					
					
					if ("orderDateRange".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.order.common.pojo.order.request.RangeParam value;
						
						value = new com.vip.order.common.pojo.order.request.RangeParam();
						com.vip.order.common.pojo.order.request.RangeParamHelper.getInstance().Read(value, iprot);
						
						structs.SetOrderDateRange(value);
					}
					
					
					
					
					
					if ("orderTimeRange".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.order.common.pojo.order.request.RangeParam value;
						
						value = new com.vip.order.common.pojo.order.request.RangeParam();
						com.vip.order.common.pojo.order.request.RangeParamHelper.getInstance().Read(value, iprot);
						
						structs.SetOrderTimeRange(value);
					}
					
					
					
					
					
					if ("orderLimit".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetOrderLimit(value);
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
		
		
		public void Write(GetUserDeliveryAddressReq structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetUserId() != null) {
				
				oprot.WriteFieldBegin("userId");
				oprot.WriteI64((long)structs.GetUserId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetStatusRange() != null) {
				
				oprot.WriteFieldBegin("statusRange");
				
				com.vip.order.common.pojo.order.request.RangeParamHelper.getInstance().Write(structs.GetStatusRange(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderDateRange() != null) {
				
				oprot.WriteFieldBegin("orderDateRange");
				
				com.vip.order.common.pojo.order.request.RangeParamHelper.getInstance().Write(structs.GetOrderDateRange(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderTimeRange() != null) {
				
				oprot.WriteFieldBegin("orderTimeRange");
				
				com.vip.order.common.pojo.order.request.RangeParamHelper.getInstance().Write(structs.GetOrderTimeRange(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderLimit() != null) {
				
				oprot.WriteFieldBegin("orderLimit");
				oprot.WriteI32((int)structs.GetOrderLimit()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(GetUserDeliveryAddressReq bean){
			
			
		}
		
	}
	
}