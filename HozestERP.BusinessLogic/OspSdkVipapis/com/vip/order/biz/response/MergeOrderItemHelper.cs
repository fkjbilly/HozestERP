using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.biz.response{
	
	
	
	public class MergeOrderItemHelper : TBeanSerializer<MergeOrderItem>
	{
		
		public static MergeOrderItemHelper OBJ = new MergeOrderItemHelper();
		
		public static MergeOrderItemHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(MergeOrderItem structs, Protocol iprot){
			
			
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
					
					
					
					
					
					if ("orderReceiveAddr".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.order.common.pojo.order.vo.OrderReceiveAddrVO value;
						
						value = new com.vip.order.common.pojo.order.vo.OrderReceiveAddrVO();
						com.vip.order.common.pojo.order.vo.OrderReceiveAddrVOHelper.getInstance().Read(value, iprot);
						
						structs.SetOrderReceiveAddr(value);
					}
					
					
					
					
					
					if ("orderPayAndDiscount".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.order.common.pojo.order.vo.OrderPayAndDiscountVO value;
						
						value = new com.vip.order.common.pojo.order.vo.OrderPayAndDiscountVO();
						com.vip.order.common.pojo.order.vo.OrderPayAndDiscountVOHelper.getInstance().Read(value, iprot);
						
						structs.SetOrderPayAndDiscount(value);
					}
					
					
					
					
					
					if ("areaFlagName".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetAreaFlagName(value);
					}
					
					
					
					
					
					if ("areaFlag".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetAreaFlag(value);
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
		
		
		public void Write(MergeOrderItem structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetOrder() != null) {
				
				oprot.WriteFieldBegin("order");
				
				com.vip.order.common.pojo.order.vo.OrderVOHelper.getInstance().Write(structs.GetOrder(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderReceiveAddr() != null) {
				
				oprot.WriteFieldBegin("orderReceiveAddr");
				
				com.vip.order.common.pojo.order.vo.OrderReceiveAddrVOHelper.getInstance().Write(structs.GetOrderReceiveAddr(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderPayAndDiscount() != null) {
				
				oprot.WriteFieldBegin("orderPayAndDiscount");
				
				com.vip.order.common.pojo.order.vo.OrderPayAndDiscountVOHelper.getInstance().Write(structs.GetOrderPayAndDiscount(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetAreaFlagName() != null) {
				
				oprot.WriteFieldBegin("areaFlagName");
				oprot.WriteString(structs.GetAreaFlagName());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetAreaFlag() != null) {
				
				oprot.WriteFieldBegin("areaFlag");
				oprot.WriteI32((int)structs.GetAreaFlag()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(MergeOrderItem bean){
			
			
		}
		
	}
	
}