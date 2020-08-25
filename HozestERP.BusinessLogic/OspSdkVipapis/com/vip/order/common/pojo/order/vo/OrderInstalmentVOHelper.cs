using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.common.pojo.order.vo{
	
	
	
	public class OrderInstalmentVOHelper : TBeanSerializer<OrderInstalmentVO>
	{
		
		public static OrderInstalmentVOHelper OBJ = new OrderInstalmentVOHelper();
		
		public static OrderInstalmentVOHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(OrderInstalmentVO structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("order".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.order.common.pojo.order.vo.OrderVO value;
						
						value = new com.vip.order.common.pojo.order.vo.OrderVO();
						com.vip.order.common.pojo.order.vo.OrderVOHelper.getInstance().Read(value, iprot);
						
						structs.SetOrder(value);
					}
					
					
					
					
					
					if ("orderPayInstalment".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.order.common.pojo.order.vo.OrderPayInstalmentVO value;
						
						value = new com.vip.order.common.pojo.order.vo.OrderPayInstalmentVO();
						com.vip.order.common.pojo.order.vo.OrderPayInstalmentVOHelper.getInstance().Read(value, iprot);
						
						structs.SetOrderPayInstalment(value);
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
		
		
		public void Write(OrderInstalmentVO structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetOrder() != null) {
				
				oprot.WriteFieldBegin("order");
				
				com.vip.order.common.pojo.order.vo.OrderVOHelper.getInstance().Write(structs.GetOrder(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderPayInstalment() != null) {
				
				oprot.WriteFieldBegin("orderPayInstalment");
				
				com.vip.order.common.pojo.order.vo.OrderPayInstalmentVOHelper.getInstance().Write(structs.GetOrderPayInstalment(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(OrderInstalmentVO bean){
			
			
		}
		
	}
	
}