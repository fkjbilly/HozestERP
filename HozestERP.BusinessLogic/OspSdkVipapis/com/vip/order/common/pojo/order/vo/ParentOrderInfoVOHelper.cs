using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.common.pojo.order.vo{
	
	
	
	public class ParentOrderInfoVOHelper : TBeanSerializer<ParentOrderInfoVO>
	{
		
		public static ParentOrderInfoVOHelper OBJ = new ParentOrderInfoVOHelper();
		
		public static ParentOrderInfoVOHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(ParentOrderInfoVO structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("parentOrder".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.order.common.pojo.order.vo.OrderVO value;
						
						value = new com.vip.order.common.pojo.order.vo.OrderVO();
						com.vip.order.common.pojo.order.vo.OrderVOHelper.getInstance().Read(value, iprot);
						
						structs.SetParentOrder(value);
					}
					
					
					
					
					
					if ("parentOrderReceiveAddr".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.order.common.pojo.order.vo.OrderReceiveAddrVO value;
						
						value = new com.vip.order.common.pojo.order.vo.OrderReceiveAddrVO();
						com.vip.order.common.pojo.order.vo.OrderReceiveAddrVOHelper.getInstance().Read(value, iprot);
						
						structs.SetParentOrderReceiveAddr(value);
					}
					
					
					
					
					
					if ("parentOrderPayAndDiscount".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.order.common.pojo.order.vo.OrderPayAndDiscountVO value;
						
						value = new com.vip.order.common.pojo.order.vo.OrderPayAndDiscountVO();
						com.vip.order.common.pojo.order.vo.OrderPayAndDiscountVOHelper.getInstance().Read(value, iprot);
						
						structs.SetParentOrderPayAndDiscount(value);
					}
					
					
					
					
					
					if ("parentOrderDetailsSuppInfo".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.order.common.pojo.order.vo.OrderDetailsSuppInfoVO value;
						
						value = new com.vip.order.common.pojo.order.vo.OrderDetailsSuppInfoVO();
						com.vip.order.common.pojo.order.vo.OrderDetailsSuppInfoVOHelper.getInstance().Read(value, iprot);
						
						structs.SetParentOrderDetailsSuppInfo(value);
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
		
		
		public void Write(ParentOrderInfoVO structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetParentOrder() != null) {
				
				oprot.WriteFieldBegin("parentOrder");
				
				com.vip.order.common.pojo.order.vo.OrderVOHelper.getInstance().Write(structs.GetParentOrder(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetParentOrderReceiveAddr() != null) {
				
				oprot.WriteFieldBegin("parentOrderReceiveAddr");
				
				com.vip.order.common.pojo.order.vo.OrderReceiveAddrVOHelper.getInstance().Write(structs.GetParentOrderReceiveAddr(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetParentOrderPayAndDiscount() != null) {
				
				oprot.WriteFieldBegin("parentOrderPayAndDiscount");
				
				com.vip.order.common.pojo.order.vo.OrderPayAndDiscountVOHelper.getInstance().Write(structs.GetParentOrderPayAndDiscount(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetParentOrderDetailsSuppInfo() != null) {
				
				oprot.WriteFieldBegin("parentOrderDetailsSuppInfo");
				
				com.vip.order.common.pojo.order.vo.OrderDetailsSuppInfoVOHelper.getInstance().Write(structs.GetParentOrderDetailsSuppInfo(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(ParentOrderInfoVO bean){
			
			
		}
		
	}
	
}