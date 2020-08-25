using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.common.pojo.order.vo{
	
	
	
	public class OrderExchangeApplyListVOHelper : TBeanSerializer<OrderExchangeApplyListVO>
	{
		
		public static OrderExchangeApplyListVOHelper OBJ = new OrderExchangeApplyListVOHelper();
		
		public static OrderExchangeApplyListVOHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(OrderExchangeApplyListVO structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("orderExchangeApply".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.order.common.pojo.order.vo.OrderExchangeApplyVO value;
						
						value = new com.vip.order.common.pojo.order.vo.OrderExchangeApplyVO();
						com.vip.order.common.pojo.order.vo.OrderExchangeApplyVOHelper.getInstance().Read(value, iprot);
						
						structs.SetOrderExchangeApply(value);
					}
					
					
					
					
					
					if ("orderExchangeReceiveAddr".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.order.common.pojo.order.vo.OrderReceiveAddrVO value;
						
						value = new com.vip.order.common.pojo.order.vo.OrderReceiveAddrVO();
						com.vip.order.common.pojo.order.vo.OrderReceiveAddrVOHelper.getInstance().Read(value, iprot);
						
						structs.SetOrderExchangeReceiveAddr(value);
					}
					
					
					
					
					
					if ("orderExchangeReturnTransportInfo".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.order.common.pojo.order.vo.OrderReturnTransportInfoVO value;
						
						value = new com.vip.order.common.pojo.order.vo.OrderReturnTransportInfoVO();
						com.vip.order.common.pojo.order.vo.OrderReturnTransportInfoVOHelper.getInstance().Read(value, iprot);
						
						structs.SetOrderExchangeReturnTransportInfo(value);
					}
					
					
					
					
					
					if ("orderExchangeGoods".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.order.common.pojo.order.vo.OrderExchangeGoodsVO> value;
						
						value = new List<com.vip.order.common.pojo.order.vo.OrderExchangeGoodsVO>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.order.common.pojo.order.vo.OrderExchangeGoodsVO elem4;
								
								elem4 = new com.vip.order.common.pojo.order.vo.OrderExchangeGoodsVO();
								com.vip.order.common.pojo.order.vo.OrderExchangeGoodsVOHelper.getInstance().Read(elem4, iprot);
								
								value.Add(elem4);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetOrderExchangeGoods(value);
					}
					
					
					
					
					
					if ("orderExchangeReturnPackageInfo".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.order.common.pojo.order.vo.OrderReturnPackageInfoVO> value;
						
						value = new List<com.vip.order.common.pojo.order.vo.OrderReturnPackageInfoVO>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.order.common.pojo.order.vo.OrderReturnPackageInfoVO elem6;
								
								elem6 = new com.vip.order.common.pojo.order.vo.OrderReturnPackageInfoVO();
								com.vip.order.common.pojo.order.vo.OrderReturnPackageInfoVOHelper.getInstance().Read(elem6, iprot);
								
								value.Add(elem6);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetOrderExchangeReturnPackageInfo(value);
					}
					
					
					
					
					
					if ("exchangeBackFee".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.order.common.pojo.order.vo.ExchangeBackFeeVO value;
						
						value = new com.vip.order.common.pojo.order.vo.ExchangeBackFeeVO();
						com.vip.order.common.pojo.order.vo.ExchangeBackFeeVOHelper.getInstance().Read(value, iprot);
						
						structs.SetExchangeBackFee(value);
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
		
		
		public void Write(OrderExchangeApplyListVO structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetOrderExchangeApply() != null) {
				
				oprot.WriteFieldBegin("orderExchangeApply");
				
				com.vip.order.common.pojo.order.vo.OrderExchangeApplyVOHelper.getInstance().Write(structs.GetOrderExchangeApply(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderExchangeReceiveAddr() != null) {
				
				oprot.WriteFieldBegin("orderExchangeReceiveAddr");
				
				com.vip.order.common.pojo.order.vo.OrderReceiveAddrVOHelper.getInstance().Write(structs.GetOrderExchangeReceiveAddr(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderExchangeReturnTransportInfo() != null) {
				
				oprot.WriteFieldBegin("orderExchangeReturnTransportInfo");
				
				com.vip.order.common.pojo.order.vo.OrderReturnTransportInfoVOHelper.getInstance().Write(structs.GetOrderExchangeReturnTransportInfo(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderExchangeGoods() != null) {
				
				oprot.WriteFieldBegin("orderExchangeGoods");
				
				oprot.WriteListBegin();
				foreach(com.vip.order.common.pojo.order.vo.OrderExchangeGoodsVO _item0 in structs.GetOrderExchangeGoods()){
					
					
					com.vip.order.common.pojo.order.vo.OrderExchangeGoodsVOHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderExchangeReturnPackageInfo() != null) {
				
				oprot.WriteFieldBegin("orderExchangeReturnPackageInfo");
				
				oprot.WriteListBegin();
				foreach(com.vip.order.common.pojo.order.vo.OrderReturnPackageInfoVO _item0 in structs.GetOrderExchangeReturnPackageInfo()){
					
					
					com.vip.order.common.pojo.order.vo.OrderReturnPackageInfoVOHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetExchangeBackFee() != null) {
				
				oprot.WriteFieldBegin("exchangeBackFee");
				
				com.vip.order.common.pojo.order.vo.ExchangeBackFeeVOHelper.getInstance().Write(structs.GetExchangeBackFee(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(OrderExchangeApplyListVO bean){
			
			
		}
		
	}
	
}