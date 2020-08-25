using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.biz.response{
	
	
	
	public class OrderDetailItemHelper : TBeanSerializer<OrderDetailItem>
	{
		
		public static OrderDetailItemHelper OBJ = new OrderDetailItemHelper();
		
		public static OrderDetailItemHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(OrderDetailItem structs, Protocol iprot){
			
			
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
					
					
					
					
					
					if ("exOrderSn".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.order.common.pojo.order.vo.OrderCoopVO value;
						
						value = new com.vip.order.common.pojo.order.vo.OrderCoopVO();
						com.vip.order.common.pojo.order.vo.OrderCoopVOHelper.getInstance().Read(value, iprot);
						
						structs.SetExOrderSn(value);
					}
					
					
					
					
					
					if ("orderInvoice".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.order.common.pojo.order.vo.OrderInvoiceVO value;
						
						value = new com.vip.order.common.pojo.order.vo.OrderInvoiceVO();
						com.vip.order.common.pojo.order.vo.OrderInvoiceVOHelper.getInstance().Read(value, iprot);
						
						structs.SetOrderInvoice(value);
					}
					
					
					
					
					
					if ("orderElectronicInvoice".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.order.common.pojo.order.vo.OrderElectronicInvoiceVO value;
						
						value = new com.vip.order.common.pojo.order.vo.OrderElectronicInvoiceVO();
						com.vip.order.common.pojo.order.vo.OrderElectronicInvoiceVOHelper.getInstance().Read(value, iprot);
						
						structs.SetOrderElectronicInvoice(value);
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
					
					
					
					
					
					if ("orderPayDetailList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.order.common.pojo.order.vo.OrderPayDetailVO> value;
						
						value = new List<com.vip.order.common.pojo.order.vo.OrderPayDetailVO>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.order.common.pojo.order.vo.OrderPayDetailVO elem6;
								
								elem6 = new com.vip.order.common.pojo.order.vo.OrderPayDetailVO();
								com.vip.order.common.pojo.order.vo.OrderPayDetailVOHelper.getInstance().Read(elem6, iprot);
								
								value.Add(elem6);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetOrderPayDetailList(value);
					}
					
					
					
					
					
					if ("orderPayInstalmentList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.order.common.pojo.order.vo.OrderPayInstalmentVO> value;
						
						value = new List<com.vip.order.common.pojo.order.vo.OrderPayInstalmentVO>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.order.common.pojo.order.vo.OrderPayInstalmentVO elem8;
								
								elem8 = new com.vip.order.common.pojo.order.vo.OrderPayInstalmentVO();
								com.vip.order.common.pojo.order.vo.OrderPayInstalmentVOHelper.getInstance().Read(elem8, iprot);
								
								value.Add(elem8);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetOrderPayInstalmentList(value);
					}
					
					
					
					
					
					if ("orderGoodsAndDescribeList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.order.common.pojo.order.vo.OrderGoodsAndDescribeVO> value;
						
						value = new List<com.vip.order.common.pojo.order.vo.OrderGoodsAndDescribeVO>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.order.common.pojo.order.vo.OrderGoodsAndDescribeVO elem10;
								
								elem10 = new com.vip.order.common.pojo.order.vo.OrderGoodsAndDescribeVO();
								com.vip.order.common.pojo.order.vo.OrderGoodsAndDescribeVOHelper.getInstance().Read(elem10, iprot);
								
								value.Add(elem10);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetOrderGoodsAndDescribeList(value);
					}
					
					
					
					
					
					if ("orderActiveList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.order.common.pojo.order.vo.OrderActiveVO> value;
						
						value = new List<com.vip.order.common.pojo.order.vo.OrderActiveVO>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.order.common.pojo.order.vo.OrderActiveVO elem12;
								
								elem12 = new com.vip.order.common.pojo.order.vo.OrderActiveVO();
								com.vip.order.common.pojo.order.vo.OrderActiveVOHelper.getInstance().Read(elem12, iprot);
								
								value.Add(elem12);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetOrderActiveList(value);
					}
					
					
					
					
					
					if ("orderLogsList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.order.common.pojo.order.vo.OrderLogsVO> value;
						
						value = new List<com.vip.order.common.pojo.order.vo.OrderLogsVO>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.order.common.pojo.order.vo.OrderLogsVO elem14;
								
								elem14 = new com.vip.order.common.pojo.order.vo.OrderLogsVO();
								com.vip.order.common.pojo.order.vo.OrderLogsVOHelper.getInstance().Read(elem14, iprot);
								
								value.Add(elem14);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetOrderLogsList(value);
					}
					
					
					
					
					
					if ("orderStatusHistoryList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.order.common.pojo.order.vo.OrderStatusHistoryVO> value;
						
						value = new List<com.vip.order.common.pojo.order.vo.OrderStatusHistoryVO>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.order.common.pojo.order.vo.OrderStatusHistoryVO elem16;
								
								elem16 = new com.vip.order.common.pojo.order.vo.OrderStatusHistoryVO();
								com.vip.order.common.pojo.order.vo.OrderStatusHistoryVOHelper.getInstance().Read(elem16, iprot);
								
								value.Add(elem16);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetOrderStatusHistoryList(value);
					}
					
					
					
					
					
					if ("orderTransportDetailsAndPackageList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.order.common.pojo.order.vo.OrderTransportDetailsAndPackageVO> value;
						
						value = new List<com.vip.order.common.pojo.order.vo.OrderTransportDetailsAndPackageVO>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.order.common.pojo.order.vo.OrderTransportDetailsAndPackageVO elem18;
								
								elem18 = new com.vip.order.common.pojo.order.vo.OrderTransportDetailsAndPackageVO();
								com.vip.order.common.pojo.order.vo.OrderTransportDetailsAndPackageVOHelper.getInstance().Read(elem18, iprot);
								
								value.Add(elem18);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetOrderTransportDetailsAndPackageList(value);
					}
					
					
					
					
					
					if ("prepayOrderExtend".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.order.common.pojo.order.vo.PrepayOrderExtendVO value;
						
						value = new com.vip.order.common.pojo.order.vo.PrepayOrderExtendVO();
						com.vip.order.common.pojo.order.vo.PrepayOrderExtendVOHelper.getInstance().Read(value, iprot);
						
						structs.SetPrepayOrderExtend(value);
					}
					
					
					
					
					
					if ("orderReturnApplyList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.order.common.pojo.order.vo.OrderReturnApplyListVO> value;
						
						value = new List<com.vip.order.common.pojo.order.vo.OrderReturnApplyListVO>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.order.common.pojo.order.vo.OrderReturnApplyListVO elem21;
								
								elem21 = new com.vip.order.common.pojo.order.vo.OrderReturnApplyListVO();
								com.vip.order.common.pojo.order.vo.OrderReturnApplyListVOHelper.getInstance().Read(elem21, iprot);
								
								value.Add(elem21);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetOrderReturnApplyList(value);
					}
					
					
					
					
					
					if ("orderExchangeApplyList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.order.common.pojo.order.vo.OrderExchangeApplyListVO> value;
						
						value = new List<com.vip.order.common.pojo.order.vo.OrderExchangeApplyListVO>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.order.common.pojo.order.vo.OrderExchangeApplyListVO elem23;
								
								elem23 = new com.vip.order.common.pojo.order.vo.OrderExchangeApplyListVO();
								com.vip.order.common.pojo.order.vo.OrderExchangeApplyListVOHelper.getInstance().Read(elem23, iprot);
								
								value.Add(elem23);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetOrderExchangeApplyList(value);
					}
					
					
					
					
					
					if ("orderDetailsSuppInfo".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.order.common.pojo.order.vo.OrderDetailsSuppInfoVO value;
						
						value = new com.vip.order.common.pojo.order.vo.OrderDetailsSuppInfoVO();
						com.vip.order.common.pojo.order.vo.OrderDetailsSuppInfoVOHelper.getInstance().Read(value, iprot);
						
						structs.SetOrderDetailsSuppInfo(value);
					}
					
					
					
					
					
					if ("returnAddress".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.order.common.pojo.order.vo.ReturnAddressVO value;
						
						value = new com.vip.order.common.pojo.order.vo.ReturnAddressVO();
						com.vip.order.common.pojo.order.vo.ReturnAddressVOHelper.getInstance().Read(value, iprot);
						
						structs.SetReturnAddress(value);
					}
					
					
					
					
					
					if ("orderCardList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.order.common.pojo.order.vo.OrderCardVO> value;
						
						value = new List<com.vip.order.common.pojo.order.vo.OrderCardVO>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.order.common.pojo.order.vo.OrderCardVO elem27;
								
								elem27 = new com.vip.order.common.pojo.order.vo.OrderCardVO();
								com.vip.order.common.pojo.order.vo.OrderCardVOHelper.getInstance().Read(elem27, iprot);
								
								value.Add(elem27);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetOrderCardList(value);
					}
					
					
					
					
					
					if ("orderCancelData".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.order.common.pojo.order.vo.OrderCancelDataVO value;
						
						value = new com.vip.order.common.pojo.order.vo.OrderCancelDataVO();
						com.vip.order.common.pojo.order.vo.OrderCancelDataVOHelper.getInstance().Read(value, iprot);
						
						structs.SetOrderCancelData(value);
					}
					
					
					
					
					
					if ("orderGoodsBackList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.order.common.pojo.order.vo.OrderGoodsBackVO> value;
						
						value = new List<com.vip.order.common.pojo.order.vo.OrderGoodsBackVO>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.order.common.pojo.order.vo.OrderGoodsBackVO elem30;
								
								elem30 = new com.vip.order.common.pojo.order.vo.OrderGoodsBackVO();
								com.vip.order.common.pojo.order.vo.OrderGoodsBackVOHelper.getInstance().Read(elem30, iprot);
								
								value.Add(elem30);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetOrderGoodsBackList(value);
					}
					
					
					
					
					
					if ("orderBackBankList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.order.common.pojo.order.vo.OrderBackBankVO> value;
						
						value = new List<com.vip.order.common.pojo.order.vo.OrderBackBankVO>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.order.common.pojo.order.vo.OrderBackBankVO elem32;
								
								elem32 = new com.vip.order.common.pojo.order.vo.OrderBackBankVO();
								com.vip.order.common.pojo.order.vo.OrderBackBankVOHelper.getInstance().Read(elem32, iprot);
								
								value.Add(elem32);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetOrderBackBankList(value);
					}
					
					
					
					
					
					if ("ordersPayType".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.order.common.pojo.order.vo.OrdersPayTypeVO value;
						
						value = new com.vip.order.common.pojo.order.vo.OrdersPayTypeVO();
						com.vip.order.common.pojo.order.vo.OrdersPayTypeVOHelper.getInstance().Read(value, iprot);
						
						structs.SetOrdersPayType(value);
					}
					
					
					
					
					
					if ("orderPos".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.order.common.pojo.order.vo.OrderPosVO value;
						
						value = new com.vip.order.common.pojo.order.vo.OrderPosVO();
						com.vip.order.common.pojo.order.vo.OrderPosVOHelper.getInstance().Read(value, iprot);
						
						structs.SetOrderPos(value);
					}
					
					
					
					
					
					if ("couponList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.order.common.pojo.order.vo.OrderCouponVO> value;
						
						value = new List<com.vip.order.common.pojo.order.vo.OrderCouponVO>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.order.common.pojo.order.vo.OrderCouponVO elem36;
								
								elem36 = new com.vip.order.common.pojo.order.vo.OrderCouponVO();
								com.vip.order.common.pojo.order.vo.OrderCouponVOHelper.getInstance().Read(elem36, iprot);
								
								value.Add(elem36);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetCouponList(value);
					}
					
					
					
					
					
					if ("opStatusList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.order.common.pojo.order.vo.OpStatusVO> value;
						
						value = new List<com.vip.order.common.pojo.order.vo.OpStatusVO>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.order.common.pojo.order.vo.OpStatusVO elem38;
								
								elem38 = new com.vip.order.common.pojo.order.vo.OpStatusVO();
								com.vip.order.common.pojo.order.vo.OpStatusVOHelper.getInstance().Read(elem38, iprot);
								
								value.Add(elem38);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetOpStatusList(value);
					}
					
					
					
					
					
					if ("prepayOrderExtendList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.order.common.pojo.order.vo.PrepayOrderExtendVO> value;
						
						value = new List<com.vip.order.common.pojo.order.vo.PrepayOrderExtendVO>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.order.common.pojo.order.vo.PrepayOrderExtendVO elem40;
								
								elem40 = new com.vip.order.common.pojo.order.vo.PrepayOrderExtendVO();
								com.vip.order.common.pojo.order.vo.PrepayOrderExtendVOHelper.getInstance().Read(elem40, iprot);
								
								value.Add(elem40);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetPrepayOrderExtendList(value);
					}
					
					
					
					
					
					if ("orderRefundDetailsList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.order.common.pojo.order.vo.OrderRefundDetailsVO> value;
						
						value = new List<com.vip.order.common.pojo.order.vo.OrderRefundDetailsVO>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.order.common.pojo.order.vo.OrderRefundDetailsVO elem42;
								
								elem42 = new com.vip.order.common.pojo.order.vo.OrderRefundDetailsVO();
								com.vip.order.common.pojo.order.vo.OrderRefundDetailsVOHelper.getInstance().Read(elem42, iprot);
								
								value.Add(elem42);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetOrderRefundDetailsList(value);
					}
					
					
					
					
					
					if ("orderPaySnList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.order.common.pojo.order.vo.OrderPaySnVO> value;
						
						value = new List<com.vip.order.common.pojo.order.vo.OrderPaySnVO>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.order.common.pojo.order.vo.OrderPaySnVO elem44;
								
								elem44 = new com.vip.order.common.pojo.order.vo.OrderPaySnVO();
								com.vip.order.common.pojo.order.vo.OrderPaySnVOHelper.getInstance().Read(elem44, iprot);
								
								value.Add(elem44);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetOrderPaySnList(value);
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
								
								com.vip.order.common.pojo.order.vo.OrderWarehouseVO elem47;
								
								elem47 = new com.vip.order.common.pojo.order.vo.OrderWarehouseVO();
								com.vip.order.common.pojo.order.vo.OrderWarehouseVOHelper.getInstance().Read(elem47, iprot);
								
								value.Add(elem47);
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
		
		
		public void Write(OrderDetailItem structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetOrder() != null) {
				
				oprot.WriteFieldBegin("order");
				
				com.vip.order.common.pojo.order.vo.OrderVOHelper.getInstance().Write(structs.GetOrder(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetExOrderSn() != null) {
				
				oprot.WriteFieldBegin("exOrderSn");
				
				com.vip.order.common.pojo.order.vo.OrderCoopVOHelper.getInstance().Write(structs.GetExOrderSn(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderInvoice() != null) {
				
				oprot.WriteFieldBegin("orderInvoice");
				
				com.vip.order.common.pojo.order.vo.OrderInvoiceVOHelper.getInstance().Write(structs.GetOrderInvoice(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderElectronicInvoice() != null) {
				
				oprot.WriteFieldBegin("orderElectronicInvoice");
				
				com.vip.order.common.pojo.order.vo.OrderElectronicInvoiceVOHelper.getInstance().Write(structs.GetOrderElectronicInvoice(), oprot);
				
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
			
			
			if(structs.GetOrderPayDetailList() != null) {
				
				oprot.WriteFieldBegin("orderPayDetailList");
				
				oprot.WriteListBegin();
				foreach(com.vip.order.common.pojo.order.vo.OrderPayDetailVO _item0 in structs.GetOrderPayDetailList()){
					
					
					com.vip.order.common.pojo.order.vo.OrderPayDetailVOHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderPayInstalmentList() != null) {
				
				oprot.WriteFieldBegin("orderPayInstalmentList");
				
				oprot.WriteListBegin();
				foreach(com.vip.order.common.pojo.order.vo.OrderPayInstalmentVO _item0 in structs.GetOrderPayInstalmentList()){
					
					
					com.vip.order.common.pojo.order.vo.OrderPayInstalmentVOHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderGoodsAndDescribeList() != null) {
				
				oprot.WriteFieldBegin("orderGoodsAndDescribeList");
				
				oprot.WriteListBegin();
				foreach(com.vip.order.common.pojo.order.vo.OrderGoodsAndDescribeVO _item0 in structs.GetOrderGoodsAndDescribeList()){
					
					
					com.vip.order.common.pojo.order.vo.OrderGoodsAndDescribeVOHelper.getInstance().Write(_item0, oprot);
					
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
			
			
			if(structs.GetOrderLogsList() != null) {
				
				oprot.WriteFieldBegin("orderLogsList");
				
				oprot.WriteListBegin();
				foreach(com.vip.order.common.pojo.order.vo.OrderLogsVO _item0 in structs.GetOrderLogsList()){
					
					
					com.vip.order.common.pojo.order.vo.OrderLogsVOHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderStatusHistoryList() != null) {
				
				oprot.WriteFieldBegin("orderStatusHistoryList");
				
				oprot.WriteListBegin();
				foreach(com.vip.order.common.pojo.order.vo.OrderStatusHistoryVO _item0 in structs.GetOrderStatusHistoryList()){
					
					
					com.vip.order.common.pojo.order.vo.OrderStatusHistoryVOHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderTransportDetailsAndPackageList() != null) {
				
				oprot.WriteFieldBegin("orderTransportDetailsAndPackageList");
				
				oprot.WriteListBegin();
				foreach(com.vip.order.common.pojo.order.vo.OrderTransportDetailsAndPackageVO _item0 in structs.GetOrderTransportDetailsAndPackageList()){
					
					
					com.vip.order.common.pojo.order.vo.OrderTransportDetailsAndPackageVOHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPrepayOrderExtend() != null) {
				
				oprot.WriteFieldBegin("prepayOrderExtend");
				
				com.vip.order.common.pojo.order.vo.PrepayOrderExtendVOHelper.getInstance().Write(structs.GetPrepayOrderExtend(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderReturnApplyList() != null) {
				
				oprot.WriteFieldBegin("orderReturnApplyList");
				
				oprot.WriteListBegin();
				foreach(com.vip.order.common.pojo.order.vo.OrderReturnApplyListVO _item0 in structs.GetOrderReturnApplyList()){
					
					
					com.vip.order.common.pojo.order.vo.OrderReturnApplyListVOHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderExchangeApplyList() != null) {
				
				oprot.WriteFieldBegin("orderExchangeApplyList");
				
				oprot.WriteListBegin();
				foreach(com.vip.order.common.pojo.order.vo.OrderExchangeApplyListVO _item0 in structs.GetOrderExchangeApplyList()){
					
					
					com.vip.order.common.pojo.order.vo.OrderExchangeApplyListVOHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderDetailsSuppInfo() != null) {
				
				oprot.WriteFieldBegin("orderDetailsSuppInfo");
				
				com.vip.order.common.pojo.order.vo.OrderDetailsSuppInfoVOHelper.getInstance().Write(structs.GetOrderDetailsSuppInfo(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetReturnAddress() != null) {
				
				oprot.WriteFieldBegin("returnAddress");
				
				com.vip.order.common.pojo.order.vo.ReturnAddressVOHelper.getInstance().Write(structs.GetReturnAddress(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderCardList() != null) {
				
				oprot.WriteFieldBegin("orderCardList");
				
				oprot.WriteListBegin();
				foreach(com.vip.order.common.pojo.order.vo.OrderCardVO _item0 in structs.GetOrderCardList()){
					
					
					com.vip.order.common.pojo.order.vo.OrderCardVOHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderCancelData() != null) {
				
				oprot.WriteFieldBegin("orderCancelData");
				
				com.vip.order.common.pojo.order.vo.OrderCancelDataVOHelper.getInstance().Write(structs.GetOrderCancelData(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderGoodsBackList() != null) {
				
				oprot.WriteFieldBegin("orderGoodsBackList");
				
				oprot.WriteListBegin();
				foreach(com.vip.order.common.pojo.order.vo.OrderGoodsBackVO _item0 in structs.GetOrderGoodsBackList()){
					
					
					com.vip.order.common.pojo.order.vo.OrderGoodsBackVOHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderBackBankList() != null) {
				
				oprot.WriteFieldBegin("orderBackBankList");
				
				oprot.WriteListBegin();
				foreach(com.vip.order.common.pojo.order.vo.OrderBackBankVO _item0 in structs.GetOrderBackBankList()){
					
					
					com.vip.order.common.pojo.order.vo.OrderBackBankVOHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrdersPayType() != null) {
				
				oprot.WriteFieldBegin("ordersPayType");
				
				com.vip.order.common.pojo.order.vo.OrdersPayTypeVOHelper.getInstance().Write(structs.GetOrdersPayType(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderPos() != null) {
				
				oprot.WriteFieldBegin("orderPos");
				
				com.vip.order.common.pojo.order.vo.OrderPosVOHelper.getInstance().Write(structs.GetOrderPos(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCouponList() != null) {
				
				oprot.WriteFieldBegin("couponList");
				
				oprot.WriteListBegin();
				foreach(com.vip.order.common.pojo.order.vo.OrderCouponVO _item0 in structs.GetCouponList()){
					
					
					com.vip.order.common.pojo.order.vo.OrderCouponVOHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
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
			
			
			if(structs.GetPrepayOrderExtendList() != null) {
				
				oprot.WriteFieldBegin("prepayOrderExtendList");
				
				oprot.WriteListBegin();
				foreach(com.vip.order.common.pojo.order.vo.PrepayOrderExtendVO _item0 in structs.GetPrepayOrderExtendList()){
					
					
					com.vip.order.common.pojo.order.vo.PrepayOrderExtendVOHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderRefundDetailsList() != null) {
				
				oprot.WriteFieldBegin("orderRefundDetailsList");
				
				oprot.WriteListBegin();
				foreach(com.vip.order.common.pojo.order.vo.OrderRefundDetailsVO _item0 in structs.GetOrderRefundDetailsList()){
					
					
					com.vip.order.common.pojo.order.vo.OrderRefundDetailsVOHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderPaySnList() != null) {
				
				oprot.WriteFieldBegin("orderPaySnList");
				
				oprot.WriteListBegin();
				foreach(com.vip.order.common.pojo.order.vo.OrderPaySnVO _item0 in structs.GetOrderPaySnList()){
					
					
					com.vip.order.common.pojo.order.vo.OrderPaySnVOHelper.getInstance().Write(_item0, oprot);
					
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
		
		
		public void Validate(OrderDetailItem bean){
			
			
		}
		
	}
	
}