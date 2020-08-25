using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.common.pojo.order.vo{
	
	
	
	public class SplitOrderVOHelper : TBeanSerializer<SplitOrderVO>
	{
		
		public static SplitOrderVOHelper OBJ = new SplitOrderVOHelper();
		
		public static SplitOrderVOHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(SplitOrderVO structs, Protocol iprot){
			
			
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
					
					
					
					
					
					if ("orderGoodsList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.order.common.pojo.order.vo.OrderGoodsVO> value;
						
						value = new List<com.vip.order.common.pojo.order.vo.OrderGoodsVO>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.order.common.pojo.order.vo.OrderGoodsVO elem1;
								
								elem1 = new com.vip.order.common.pojo.order.vo.OrderGoodsVO();
								com.vip.order.common.pojo.order.vo.OrderGoodsVOHelper.getInstance().Read(elem1, iprot);
								
								value.Add(elem1);
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
								
								com.vip.order.common.pojo.order.vo.OrderActiveVO elem3;
								
								elem3 = new com.vip.order.common.pojo.order.vo.OrderActiveVO();
								com.vip.order.common.pojo.order.vo.OrderActiveVOHelper.getInstance().Read(elem3, iprot);
								
								value.Add(elem3);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetOrderActiveList(value);
					}
					
					
					
					
					
					if ("prepayOrderMoneyDetailList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.order.common.pojo.order.vo.PrepayOrderMoneyDetailVO> value;
						
						value = new List<com.vip.order.common.pojo.order.vo.PrepayOrderMoneyDetailVO>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.order.common.pojo.order.vo.PrepayOrderMoneyDetailVO elem5;
								
								elem5 = new com.vip.order.common.pojo.order.vo.PrepayOrderMoneyDetailVO();
								com.vip.order.common.pojo.order.vo.PrepayOrderMoneyDetailVOHelper.getInstance().Read(elem5, iprot);
								
								value.Add(elem5);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetPrepayOrderMoneyDetailList(value);
					}
					
					
					
					
					
					if ("payDetailList".Equals(schemeField.Trim())){
						
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
						
						structs.SetPayDetailList(value);
					}
					
					
					
					
					
					if ("orderPayAndDiscount".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.order.common.pojo.order.vo.OrderPayAndDiscountVO value;
						
						value = new com.vip.order.common.pojo.order.vo.OrderPayAndDiscountVO();
						com.vip.order.common.pojo.order.vo.OrderPayAndDiscountVOHelper.getInstance().Read(value, iprot);
						
						structs.SetOrderPayAndDiscount(value);
					}
					
					
					
					
					
					if ("goodsWarehouseList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.order.common.pojo.order.vo.OrderGoodsWarehouseDetailVO> value;
						
						value = new List<com.vip.order.common.pojo.order.vo.OrderGoodsWarehouseDetailVO>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.order.common.pojo.order.vo.OrderGoodsWarehouseDetailVO elem10;
								
								elem10 = new com.vip.order.common.pojo.order.vo.OrderGoodsWarehouseDetailVO();
								com.vip.order.common.pojo.order.vo.OrderGoodsWarehouseDetailVOHelper.getInstance().Read(elem10, iprot);
								
								value.Add(elem10);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetGoodsWarehouseList(value);
					}
					
					
					
					
					
					if ("orderInvoice".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.order.common.pojo.order.vo.OrderInvoiceVO value;
						
						value = new com.vip.order.common.pojo.order.vo.OrderInvoiceVO();
						com.vip.order.common.pojo.order.vo.OrderInvoiceVOHelper.getInstance().Read(value, iprot);
						
						structs.SetOrderInvoice(value);
					}
					
					
					
					
					
					if ("orderWarehouseList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.order.common.pojo.order.vo.OrderWarehouseVO> value;
						
						value = new List<com.vip.order.common.pojo.order.vo.OrderWarehouseVO>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.order.common.pojo.order.vo.OrderWarehouseVO elem13;
								
								elem13 = new com.vip.order.common.pojo.order.vo.OrderWarehouseVO();
								com.vip.order.common.pojo.order.vo.OrderWarehouseVOHelper.getInstance().Read(elem13, iprot);
								
								value.Add(elem13);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetOrderWarehouseList(value);
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
		
		
		public void Write(SplitOrderVO structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetOrder() != null) {
				
				oprot.WriteFieldBegin("order");
				
				com.vip.order.common.pojo.order.vo.OrderVOHelper.getInstance().Write(structs.GetOrder(), oprot);
				
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
			
			
			if(structs.GetPrepayOrderMoneyDetailList() != null) {
				
				oprot.WriteFieldBegin("prepayOrderMoneyDetailList");
				
				oprot.WriteListBegin();
				foreach(com.vip.order.common.pojo.order.vo.PrepayOrderMoneyDetailVO _item0 in structs.GetPrepayOrderMoneyDetailList()){
					
					
					com.vip.order.common.pojo.order.vo.PrepayOrderMoneyDetailVOHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPayDetailList() != null) {
				
				oprot.WriteFieldBegin("payDetailList");
				
				oprot.WriteListBegin();
				foreach(com.vip.order.common.pojo.order.vo.OrderPayDetailVO _item0 in structs.GetPayDetailList()){
					
					
					com.vip.order.common.pojo.order.vo.OrderPayDetailVOHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderPayAndDiscount() != null) {
				
				oprot.WriteFieldBegin("orderPayAndDiscount");
				
				com.vip.order.common.pojo.order.vo.OrderPayAndDiscountVOHelper.getInstance().Write(structs.GetOrderPayAndDiscount(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetGoodsWarehouseList() != null) {
				
				oprot.WriteFieldBegin("goodsWarehouseList");
				
				oprot.WriteListBegin();
				foreach(com.vip.order.common.pojo.order.vo.OrderGoodsWarehouseDetailVO _item0 in structs.GetGoodsWarehouseList()){
					
					
					com.vip.order.common.pojo.order.vo.OrderGoodsWarehouseDetailVOHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderInvoice() != null) {
				
				oprot.WriteFieldBegin("orderInvoice");
				
				com.vip.order.common.pojo.order.vo.OrderInvoiceVOHelper.getInstance().Write(structs.GetOrderInvoice(), oprot);
				
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
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(SplitOrderVO bean){
			
			
		}
		
	}
	
}