using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.biz.request{
	
	
	
	public class CalculateSplitOrderMoneyReqHelper : TBeanSerializer<CalculateSplitOrderMoneyReq>
	{
		
		public static CalculateSplitOrderMoneyReqHelper OBJ = new CalculateSplitOrderMoneyReqHelper();
		
		public static CalculateSplitOrderMoneyReqHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(CalculateSplitOrderMoneyReq structs, Protocol iprot){
			
			
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
					
					
					
					
					
					if ("orderGoodsList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.order.common.pojo.order.vo.OrderGoodsVO> value;
						
						value = new List<com.vip.order.common.pojo.order.vo.OrderGoodsVO>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.order.common.pojo.order.vo.OrderGoodsVO elem2;
								
								elem2 = new com.vip.order.common.pojo.order.vo.OrderGoodsVO();
								com.vip.order.common.pojo.order.vo.OrderGoodsVOHelper.getInstance().Read(elem2, iprot);
								
								value.Add(elem2);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetOrderGoodsList(value);
					}
					
					
					
					
					
					if ("orderPayDetailList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.order.common.pojo.order.vo.OrderPayDetailVO> value;
						
						value = new List<com.vip.order.common.pojo.order.vo.OrderPayDetailVO>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.order.common.pojo.order.vo.OrderPayDetailVO elem4;
								
								elem4 = new com.vip.order.common.pojo.order.vo.OrderPayDetailVO();
								com.vip.order.common.pojo.order.vo.OrderPayDetailVOHelper.getInstance().Read(elem4, iprot);
								
								value.Add(elem4);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetOrderPayDetailList(value);
					}
					
					
					
					
					
					if ("orderActiveList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.order.common.pojo.order.vo.OrderActiveVO> value;
						
						value = new List<com.vip.order.common.pojo.order.vo.OrderActiveVO>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.order.common.pojo.order.vo.OrderActiveVO elem6;
								
								elem6 = new com.vip.order.common.pojo.order.vo.OrderActiveVO();
								com.vip.order.common.pojo.order.vo.OrderActiveVOHelper.getInstance().Read(elem6, iprot);
								
								value.Add(elem6);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetOrderActiveList(value);
					}
					
					
					
					
					
					if ("prepayOrderExtendList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.order.common.pojo.order.vo.PrepayOrderExtendVO> value;
						
						value = new List<com.vip.order.common.pojo.order.vo.PrepayOrderExtendVO>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.order.common.pojo.order.vo.PrepayOrderExtendVO elem8;
								
								elem8 = new com.vip.order.common.pojo.order.vo.PrepayOrderExtendVO();
								com.vip.order.common.pojo.order.vo.PrepayOrderExtendVOHelper.getInstance().Read(elem8, iprot);
								
								value.Add(elem8);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetPrepayOrderExtendList(value);
					}
					
					
					
					
					
					if ("splitOrderList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.order.common.pojo.order.vo.SplitOrderVO> value;
						
						value = new List<com.vip.order.common.pojo.order.vo.SplitOrderVO>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.order.common.pojo.order.vo.SplitOrderVO elem10;
								
								elem10 = new com.vip.order.common.pojo.order.vo.SplitOrderVO();
								com.vip.order.common.pojo.order.vo.SplitOrderVOHelper.getInstance().Read(elem10, iprot);
								
								value.Add(elem10);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetSplitOrderList(value);
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
		
		
		public void Write(CalculateSplitOrderMoneyReq structs, Protocol oprot){
			
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
			
			
			if(structs.GetOrderGoodsList() != null) {
				
				oprot.WriteFieldBegin("orderGoodsList");
				
				oprot.WriteListBegin();
				foreach(com.vip.order.common.pojo.order.vo.OrderGoodsVO _item0 in structs.GetOrderGoodsList()){
					
					
					com.vip.order.common.pojo.order.vo.OrderGoodsVOHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
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
			
			
			if(structs.GetOrderActiveList() != null) {
				
				oprot.WriteFieldBegin("orderActiveList");
				
				oprot.WriteListBegin();
				foreach(com.vip.order.common.pojo.order.vo.OrderActiveVO _item0 in structs.GetOrderActiveList()){
					
					
					com.vip.order.common.pojo.order.vo.OrderActiveVOHelper.getInstance().Write(_item0, oprot);
					
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
			
			
			if(structs.GetSplitOrderList() != null) {
				
				oprot.WriteFieldBegin("splitOrderList");
				
				oprot.WriteListBegin();
				foreach(com.vip.order.common.pojo.order.vo.SplitOrderVO _item0 in structs.GetSplitOrderList()){
					
					
					com.vip.order.common.pojo.order.vo.SplitOrderVOHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(CalculateSplitOrderMoneyReq bean){
			
			
		}
		
	}
	
}