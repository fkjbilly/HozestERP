using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.common.pojo.order.vo{
	
	
	
	public class OrderInfoForReqHelper : TBeanSerializer<OrderInfoForReq>
	{
		
		public static OrderInfoForReqHelper OBJ = new OrderInfoForReqHelper();
		
		public static OrderInfoForReqHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(OrderInfoForReq structs, Protocol iprot){
			
			
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
					
					
					
					
					
					if ("orderPayAndDiscount".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.order.common.pojo.order.vo.OrderPayAndDiscountVO value;
						
						value = new com.vip.order.common.pojo.order.vo.OrderPayAndDiscountVO();
						com.vip.order.common.pojo.order.vo.OrderPayAndDiscountVOHelper.getInstance().Read(value, iprot);
						
						structs.SetOrderPayAndDiscount(value);
					}
					
					
					
					
					
					if ("orderPayDetail".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.order.common.pojo.order.vo.OrderPayDetailVO value;
						
						value = new com.vip.order.common.pojo.order.vo.OrderPayDetailVO();
						com.vip.order.common.pojo.order.vo.OrderPayDetailVOHelper.getInstance().Read(value, iprot);
						
						structs.SetOrderPayDetail(value);
					}
					
					
					
					
					
					if ("orderPayInstalment".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.order.common.pojo.order.vo.OrderPayInstalmentVO value;
						
						value = new com.vip.order.common.pojo.order.vo.OrderPayInstalmentVO();
						com.vip.order.common.pojo.order.vo.OrderPayInstalmentVOHelper.getInstance().Read(value, iprot);
						
						structs.SetOrderPayInstalment(value);
					}
					
					
					
					
					
					if ("orderGoodsList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.order.common.pojo.order.vo.OrderGoodsVO> value;
						
						value = new List<com.vip.order.common.pojo.order.vo.OrderGoodsVO>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.order.common.pojo.order.vo.OrderGoodsVO elem4;
								
								elem4 = new com.vip.order.common.pojo.order.vo.OrderGoodsVO();
								com.vip.order.common.pojo.order.vo.OrderGoodsVOHelper.getInstance().Read(elem4, iprot);
								
								value.Add(elem4);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetOrderGoodsList(value);
					}
					
					
					
					
					
					if ("orderActive".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.order.common.pojo.order.vo.OrderActiveVO value;
						
						value = new com.vip.order.common.pojo.order.vo.OrderActiveVO();
						com.vip.order.common.pojo.order.vo.OrderActiveVOHelper.getInstance().Read(value, iprot);
						
						structs.SetOrderActive(value);
					}
					
					
					
					
					
					if ("orderLog".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.order.common.pojo.order.vo.OrderLogsVO value;
						
						value = new com.vip.order.common.pojo.order.vo.OrderLogsVO();
						com.vip.order.common.pojo.order.vo.OrderLogsVOHelper.getInstance().Read(value, iprot);
						
						structs.SetOrderLog(value);
					}
					
					
					
					
					
					if ("prepayOrderExtendVO".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.order.common.pojo.order.vo.PrepayOrderExtendVO value;
						
						value = new com.vip.order.common.pojo.order.vo.PrepayOrderExtendVO();
						com.vip.order.common.pojo.order.vo.PrepayOrderExtendVOHelper.getInstance().Read(value, iprot);
						
						structs.SetPrepayOrderExtendVO(value);
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
		
		
		public void Write(OrderInfoForReq structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetOrder() != null) {
				
				oprot.WriteFieldBegin("order");
				
				com.vip.order.common.pojo.order.vo.OrderVOHelper.getInstance().Write(structs.GetOrder(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderPayAndDiscount() != null) {
				
				oprot.WriteFieldBegin("orderPayAndDiscount");
				
				com.vip.order.common.pojo.order.vo.OrderPayAndDiscountVOHelper.getInstance().Write(structs.GetOrderPayAndDiscount(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderPayDetail() != null) {
				
				oprot.WriteFieldBegin("orderPayDetail");
				
				com.vip.order.common.pojo.order.vo.OrderPayDetailVOHelper.getInstance().Write(structs.GetOrderPayDetail(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderPayInstalment() != null) {
				
				oprot.WriteFieldBegin("orderPayInstalment");
				
				com.vip.order.common.pojo.order.vo.OrderPayInstalmentVOHelper.getInstance().Write(structs.GetOrderPayInstalment(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderGoodsList() != null) {
				
				oprot.WriteFieldBegin("orderGoodsList");
				
				oprot.WriteListBegin();
				foreach(com.vip.order.common.pojo.order.vo.OrderGoodsVO _item0 in structs.GetOrderGoodsList()){
					
					
					com.vip.order.common.pojo.order.vo.OrderGoodsVOHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderActive() != null) {
				
				oprot.WriteFieldBegin("orderActive");
				
				com.vip.order.common.pojo.order.vo.OrderActiveVOHelper.getInstance().Write(structs.GetOrderActive(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderLog() != null) {
				
				oprot.WriteFieldBegin("orderLog");
				
				com.vip.order.common.pojo.order.vo.OrderLogsVOHelper.getInstance().Write(structs.GetOrderLog(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPrepayOrderExtendVO() != null) {
				
				oprot.WriteFieldBegin("prepayOrderExtendVO");
				
				com.vip.order.common.pojo.order.vo.PrepayOrderExtendVOHelper.getInstance().Write(structs.GetPrepayOrderExtendVO(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(OrderInfoForReq bean){
			
			
		}
		
	}
	
}