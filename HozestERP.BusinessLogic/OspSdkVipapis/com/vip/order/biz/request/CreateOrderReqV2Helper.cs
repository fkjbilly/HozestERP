using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.biz.request{
	
	
	
	public class CreateOrderReqV2Helper : TBeanSerializer<CreateOrderReqV2>
	{
		
		public static CreateOrderReqV2Helper OBJ = new CreateOrderReqV2Helper();
		
		public static CreateOrderReqV2Helper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(CreateOrderReqV2 structs, Protocol iprot){
			
			
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
								
								com.vip.order.common.pojo.order.vo.OrderPayDetailVO elem7;
								
								elem7 = new com.vip.order.common.pojo.order.vo.OrderPayDetailVO();
								com.vip.order.common.pojo.order.vo.OrderPayDetailVOHelper.getInstance().Read(elem7, iprot);
								
								value.Add(elem7);
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
								
								com.vip.order.common.pojo.order.vo.OrderPayInstalmentVO elem9;
								
								elem9 = new com.vip.order.common.pojo.order.vo.OrderPayInstalmentVO();
								com.vip.order.common.pojo.order.vo.OrderPayInstalmentVOHelper.getInstance().Read(elem9, iprot);
								
								value.Add(elem9);
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
								
								com.vip.order.common.pojo.order.vo.OrderGoodsAndDescribeVO elem11;
								
								elem11 = new com.vip.order.common.pojo.order.vo.OrderGoodsAndDescribeVO();
								com.vip.order.common.pojo.order.vo.OrderGoodsAndDescribeVOHelper.getInstance().Read(elem11, iprot);
								
								value.Add(elem11);
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
								
								com.vip.order.common.pojo.order.vo.OrderActiveVO elem13;
								
								elem13 = new com.vip.order.common.pojo.order.vo.OrderActiveVO();
								com.vip.order.common.pojo.order.vo.OrderActiveVOHelper.getInstance().Read(elem13, iprot);
								
								value.Add(elem13);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetOrderActiveList(value);
					}
					
					
					
					
					
					if ("orderCookie".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.order.common.pojo.order.vo.OrderCookieVO value;
						
						value = new com.vip.order.common.pojo.order.vo.OrderCookieVO();
						com.vip.order.common.pojo.order.vo.OrderCookieVOHelper.getInstance().Read(value, iprot);
						
						structs.SetOrderCookie(value);
					}
					
					
					
					
					
					if ("prepayOrderExtend".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.order.common.pojo.order.vo.PrepayOrderExtendVO value;
						
						value = new com.vip.order.common.pojo.order.vo.PrepayOrderExtendVO();
						com.vip.order.common.pojo.order.vo.PrepayOrderExtendVOHelper.getInstance().Read(value, iprot);
						
						structs.SetPrepayOrderExtend(value);
					}
					
					
					
					
					
					if ("orderPeriodsInfoList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.order.common.pojo.order.vo.PrepayOrderPeriodsInfoVO> value;
						
						value = new List<com.vip.order.common.pojo.order.vo.PrepayOrderPeriodsInfoVO>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.order.common.pojo.order.vo.PrepayOrderPeriodsInfoVO elem17;
								
								elem17 = new com.vip.order.common.pojo.order.vo.PrepayOrderPeriodsInfoVO();
								com.vip.order.common.pojo.order.vo.PrepayOrderPeriodsInfoVOHelper.getInstance().Read(elem17, iprot);
								
								value.Add(elem17);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetOrderPeriodsInfoList(value);
					}
					
					
					
					
					
					if ("uniqueKey".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetUniqueKey(value);
					}
					
					
					
					
					
					if ("indexKey".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetIndexKey(value);
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
		
		
		public void Write(CreateOrderReqV2 structs, Protocol oprot){
			
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
			
			
			if(structs.GetOrderCookie() != null) {
				
				oprot.WriteFieldBegin("orderCookie");
				
				com.vip.order.common.pojo.order.vo.OrderCookieVOHelper.getInstance().Write(structs.GetOrderCookie(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPrepayOrderExtend() != null) {
				
				oprot.WriteFieldBegin("prepayOrderExtend");
				
				com.vip.order.common.pojo.order.vo.PrepayOrderExtendVOHelper.getInstance().Write(structs.GetPrepayOrderExtend(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderPeriodsInfoList() != null) {
				
				oprot.WriteFieldBegin("orderPeriodsInfoList");
				
				oprot.WriteListBegin();
				foreach(com.vip.order.common.pojo.order.vo.PrepayOrderPeriodsInfoVO _item0 in structs.GetOrderPeriodsInfoList()){
					
					
					com.vip.order.common.pojo.order.vo.PrepayOrderPeriodsInfoVOHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetUniqueKey() != null) {
				
				oprot.WriteFieldBegin("uniqueKey");
				oprot.WriteString(structs.GetUniqueKey());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetIndexKey() != null) {
				
				oprot.WriteFieldBegin("indexKey");
				oprot.WriteString(structs.GetIndexKey());
				
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
		
		
		public void Validate(CreateOrderReqV2 bean){
			
			
		}
		
	}
	
}