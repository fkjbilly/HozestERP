using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.common.pojo.order.vo{
	
	
	
	public class OrderInfoVOHelper : TBeanSerializer<OrderInfoVO>
	{
		
		public static OrderInfoVOHelper OBJ = new OrderInfoVOHelper();
		
		public static OrderInfoVOHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(OrderInfoVO structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("orderCategory".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetOrderCategory(value);
					}
					
					
					
					
					
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
					
					
					
					
					
					if ("orderInvoice".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.order.common.pojo.order.vo.OrderInvoiceVO value;
						
						value = new com.vip.order.common.pojo.order.vo.OrderInvoiceVO();
						com.vip.order.common.pojo.order.vo.OrderInvoiceVOHelper.getInstance().Read(value, iprot);
						
						structs.SetOrderInvoice(value);
					}
					
					
					
					
					
					if ("orderActiveList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.order.common.pojo.order.vo.OrderActiveVO> value;
						
						value = new List<com.vip.order.common.pojo.order.vo.OrderActiveVO>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.order.common.pojo.order.vo.OrderActiveVO elem7;
								
								elem7 = new com.vip.order.common.pojo.order.vo.OrderActiveVO();
								com.vip.order.common.pojo.order.vo.OrderActiveVOHelper.getInstance().Read(elem7, iprot);
								
								value.Add(elem7);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetOrderActiveList(value);
					}
					
					
					
					
					
					if ("prepayOrderExtend".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.order.common.pojo.order.vo.PrepayOrderExtendVO value;
						
						value = new com.vip.order.common.pojo.order.vo.PrepayOrderExtendVO();
						com.vip.order.common.pojo.order.vo.PrepayOrderExtendVOHelper.getInstance().Read(value, iprot);
						
						structs.SetPrepayOrderExtend(value);
					}
					
					
					
					
					
					if ("orderDetailsSuppInfo".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.order.common.pojo.order.vo.OrderDetailsSuppInfoVO value;
						
						value = new com.vip.order.common.pojo.order.vo.OrderDetailsSuppInfoVO();
						com.vip.order.common.pojo.order.vo.OrderDetailsSuppInfoVOHelper.getInstance().Read(value, iprot);
						
						structs.SetOrderDetailsSuppInfo(value);
					}
					
					
					
					
					
					if ("opStatusList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.order.common.pojo.order.vo.OpStatusVO> value;
						
						value = new List<com.vip.order.common.pojo.order.vo.OpStatusVO>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.order.common.pojo.order.vo.OpStatusVO elem11;
								
								elem11 = new com.vip.order.common.pojo.order.vo.OpStatusVO();
								com.vip.order.common.pojo.order.vo.OpStatusVOHelper.getInstance().Read(elem11, iprot);
								
								value.Add(elem11);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetOpStatusList(value);
					}
					
					
					
					
					
					if ("orderGoodsWarehouseDetailList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.order.common.pojo.order.vo.OrderGoodsWarehouseDetailVO> value;
						
						value = new List<com.vip.order.common.pojo.order.vo.OrderGoodsWarehouseDetailVO>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.order.common.pojo.order.vo.OrderGoodsWarehouseDetailVO elem13;
								
								elem13 = new com.vip.order.common.pojo.order.vo.OrderGoodsWarehouseDetailVO();
								com.vip.order.common.pojo.order.vo.OrderGoodsWarehouseDetailVOHelper.getInstance().Read(elem13, iprot);
								
								value.Add(elem13);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetOrderGoodsWarehouseDetailList(value);
					}
					
					
					
					
					
					if ("prepayOrderExtendList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.order.common.pojo.order.vo.PrepayOrderExtendVO> value;
						
						value = new List<com.vip.order.common.pojo.order.vo.PrepayOrderExtendVO>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.order.common.pojo.order.vo.PrepayOrderExtendVO elem15;
								
								elem15 = new com.vip.order.common.pojo.order.vo.PrepayOrderExtendVO();
								com.vip.order.common.pojo.order.vo.PrepayOrderExtendVOHelper.getInstance().Read(elem15, iprot);
								
								value.Add(elem15);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetPrepayOrderExtendList(value);
					}
					
					
					
					
					
					if ("orderCompensate".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.order.common.pojo.order.vo.OrderCompensateVO value;
						
						value = new com.vip.order.common.pojo.order.vo.OrderCompensateVO();
						com.vip.order.common.pojo.order.vo.OrderCompensateVOHelper.getInstance().Read(value, iprot);
						
						structs.SetOrderCompensate(value);
					}
					
					
					
					
					
					if ("orderWarehouseList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.order.common.pojo.order.vo.OrderWarehouseVO> value;
						
						value = new List<com.vip.order.common.pojo.order.vo.OrderWarehouseVO>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.order.common.pojo.order.vo.OrderWarehouseVO elem18;
								
								elem18 = new com.vip.order.common.pojo.order.vo.OrderWarehouseVO();
								com.vip.order.common.pojo.order.vo.OrderWarehouseVOHelper.getInstance().Read(elem18, iprot);
								
								value.Add(elem18);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetOrderWarehouseList(value);
					}
					
					
					
					
					
					if ("orderBizExtAttr".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.order.common.pojo.order.vo.OrderBizExtAttrVO value;
						
						value = new com.vip.order.common.pojo.order.vo.OrderBizExtAttrVO();
						com.vip.order.common.pojo.order.vo.OrderBizExtAttrVOHelper.getInstance().Read(value, iprot);
						
						structs.SetOrderBizExtAttr(value);
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
		
		
		public void Write(OrderInfoVO structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetOrderCategory() != null) {
				
				oprot.WriteFieldBegin("orderCategory");
				oprot.WriteI32((int)structs.GetOrderCategory()); 
				
				oprot.WriteFieldEnd();
			}
			
			
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
			
			
			if(structs.GetOrderGoodsList() != null) {
				
				oprot.WriteFieldBegin("orderGoodsList");
				
				oprot.WriteListBegin();
				foreach(com.vip.order.common.pojo.order.vo.OrderGoodsVO _item0 in structs.GetOrderGoodsList()){
					
					
					com.vip.order.common.pojo.order.vo.OrderGoodsVOHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderInvoice() != null) {
				
				oprot.WriteFieldBegin("orderInvoice");
				
				com.vip.order.common.pojo.order.vo.OrderInvoiceVOHelper.getInstance().Write(structs.GetOrderInvoice(), oprot);
				
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
			
			
			if(structs.GetPrepayOrderExtend() != null) {
				
				oprot.WriteFieldBegin("prepayOrderExtend");
				
				com.vip.order.common.pojo.order.vo.PrepayOrderExtendVOHelper.getInstance().Write(structs.GetPrepayOrderExtend(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderDetailsSuppInfo() != null) {
				
				oprot.WriteFieldBegin("orderDetailsSuppInfo");
				
				com.vip.order.common.pojo.order.vo.OrderDetailsSuppInfoVOHelper.getInstance().Write(structs.GetOrderDetailsSuppInfo(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOpStatusList() != null) {
				
				oprot.WriteFieldBegin("opStatusList");
				
				oprot.WriteListBegin();
				foreach(com.vip.order.common.pojo.order.vo.OpStatusVO _item0 in structs.GetOpStatusList()){
					
					
					com.vip.order.common.pojo.order.vo.OpStatusVOHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderGoodsWarehouseDetailList() != null) {
				
				oprot.WriteFieldBegin("orderGoodsWarehouseDetailList");
				
				oprot.WriteListBegin();
				foreach(com.vip.order.common.pojo.order.vo.OrderGoodsWarehouseDetailVO _item0 in structs.GetOrderGoodsWarehouseDetailList()){
					
					
					com.vip.order.common.pojo.order.vo.OrderGoodsWarehouseDetailVOHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPrepayOrderExtendList() != null) {
				
				oprot.WriteFieldBegin("prepayOrderExtendList");
				
				oprot.WriteListBegin();
				foreach(com.vip.order.common.pojo.order.vo.PrepayOrderExtendVO _item0 in structs.GetPrepayOrderExtendList()){
					
					
					com.vip.order.common.pojo.order.vo.PrepayOrderExtendVOHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderCompensate() != null) {
				
				oprot.WriteFieldBegin("orderCompensate");
				
				com.vip.order.common.pojo.order.vo.OrderCompensateVOHelper.getInstance().Write(structs.GetOrderCompensate(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderWarehouseList() != null) {
				
				oprot.WriteFieldBegin("orderWarehouseList");
				
				oprot.WriteListBegin();
				foreach(com.vip.order.common.pojo.order.vo.OrderWarehouseVO _item0 in structs.GetOrderWarehouseList()){
					
					
					com.vip.order.common.pojo.order.vo.OrderWarehouseVOHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderBizExtAttr() != null) {
				
				oprot.WriteFieldBegin("orderBizExtAttr");
				
				com.vip.order.common.pojo.order.vo.OrderBizExtAttrVOHelper.getInstance().Write(structs.GetOrderBizExtAttr(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(OrderInfoVO bean){
			
			
		}
		
	}
	
}