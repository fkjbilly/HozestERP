using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.biz.response{
	
	
	
	public class CanAfterSaleOrderInfoHelper : TBeanSerializer<CanAfterSaleOrderInfo>
	{
		
		public static CanAfterSaleOrderInfoHelper OBJ = new CanAfterSaleOrderInfoHelper();
		
		public static CanAfterSaleOrderInfoHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(CanAfterSaleOrderInfo structs, Protocol iprot){
			
			
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
					
					
					
					
					
					if ("orderDetailsSuppInfo".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.order.common.pojo.order.vo.OrderDetailsSuppInfoVO value;
						
						value = new com.vip.order.common.pojo.order.vo.OrderDetailsSuppInfoVO();
						com.vip.order.common.pojo.order.vo.OrderDetailsSuppInfoVOHelper.getInstance().Read(value, iprot);
						
						structs.SetOrderDetailsSuppInfo(value);
					}
					
					
					
					
					
					if ("orderPayAndDiscount".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.order.common.pojo.order.vo.OrderPayAndDiscountVO value;
						
						value = new com.vip.order.common.pojo.order.vo.OrderPayAndDiscountVO();
						com.vip.order.common.pojo.order.vo.OrderPayAndDiscountVOHelper.getInstance().Read(value, iprot);
						
						structs.SetOrderPayAndDiscount(value);
					}
					
					
					
					
					
					if ("orderGoodsList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.order.common.pojo.order.vo.OrderGoodsVO> value;
						
						value = new List<com.vip.order.common.pojo.order.vo.OrderGoodsVO>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.order.common.pojo.order.vo.OrderGoodsVO elem3;
								
								elem3 = new com.vip.order.common.pojo.order.vo.OrderGoodsVO();
								com.vip.order.common.pojo.order.vo.OrderGoodsVOHelper.getInstance().Read(elem3, iprot);
								
								value.Add(elem3);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetOrderGoodsList(value);
					}
					
					
					
					
					
					if ("orderActiveList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.order.common.pojo.order.vo.OrderActiveVO> value;
						
						value = new List<com.vip.order.common.pojo.order.vo.OrderActiveVO>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.order.common.pojo.order.vo.OrderActiveVO elem5;
								
								elem5 = new com.vip.order.common.pojo.order.vo.OrderActiveVO();
								com.vip.order.common.pojo.order.vo.OrderActiveVOHelper.getInstance().Read(elem5, iprot);
								
								value.Add(elem5);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetOrderActiveList(value);
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
		
		
		public void Write(CanAfterSaleOrderInfo structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetOrder() != null) {
				
				oprot.WriteFieldBegin("order");
				
				com.vip.order.common.pojo.order.vo.OrderVOHelper.getInstance().Write(structs.GetOrder(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderDetailsSuppInfo() != null) {
				
				oprot.WriteFieldBegin("orderDetailsSuppInfo");
				
				com.vip.order.common.pojo.order.vo.OrderDetailsSuppInfoVOHelper.getInstance().Write(structs.GetOrderDetailsSuppInfo(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderPayAndDiscount() != null) {
				
				oprot.WriteFieldBegin("orderPayAndDiscount");
				
				com.vip.order.common.pojo.order.vo.OrderPayAndDiscountVOHelper.getInstance().Write(structs.GetOrderPayAndDiscount(), oprot);
				
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
			
			
			if(structs.GetOrderActiveList() != null) {
				
				oprot.WriteFieldBegin("orderActiveList");
				
				oprot.WriteListBegin();
				foreach(com.vip.order.common.pojo.order.vo.OrderActiveVO _item0 in structs.GetOrderActiveList()){
					
					
					com.vip.order.common.pojo.order.vo.OrderActiveVOHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(CanAfterSaleOrderInfo bean){
			
			
		}
		
	}
	
}