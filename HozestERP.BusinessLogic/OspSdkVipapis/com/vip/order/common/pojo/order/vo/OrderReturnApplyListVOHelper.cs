using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.common.pojo.order.vo{
	
	
	
	public class OrderReturnApplyListVOHelper : TBeanSerializer<OrderReturnApplyListVO>
	{
		
		public static OrderReturnApplyListVOHelper OBJ = new OrderReturnApplyListVOHelper();
		
		public static OrderReturnApplyListVOHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(OrderReturnApplyListVO structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("orderReturnApply".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.order.common.pojo.order.vo.OrderReturnApplyVO value;
						
						value = new com.vip.order.common.pojo.order.vo.OrderReturnApplyVO();
						com.vip.order.common.pojo.order.vo.OrderReturnApplyVOHelper.getInstance().Read(value, iprot);
						
						structs.SetOrderReturnApply(value);
					}
					
					
					
					
					
					if ("orderReturnReceiveAddr".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.order.common.pojo.order.vo.OrderReceiveAddrVO value;
						
						value = new com.vip.order.common.pojo.order.vo.OrderReceiveAddrVO();
						com.vip.order.common.pojo.order.vo.OrderReceiveAddrVOHelper.getInstance().Read(value, iprot);
						
						structs.SetOrderReturnReceiveAddr(value);
					}
					
					
					
					
					
					if ("orderReturnTransportInfo".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.order.common.pojo.order.vo.OrderReturnTransportInfoVO value;
						
						value = new com.vip.order.common.pojo.order.vo.OrderReturnTransportInfoVO();
						com.vip.order.common.pojo.order.vo.OrderReturnTransportInfoVOHelper.getInstance().Read(value, iprot);
						
						structs.SetOrderReturnTransportInfo(value);
					}
					
					
					
					
					
					if ("orderReturnGoods".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.order.common.pojo.order.vo.OrderReturnGoodsVO> value;
						
						value = new List<com.vip.order.common.pojo.order.vo.OrderReturnGoodsVO>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.order.common.pojo.order.vo.OrderReturnGoodsVO elem4;
								
								elem4 = new com.vip.order.common.pojo.order.vo.OrderReturnGoodsVO();
								com.vip.order.common.pojo.order.vo.OrderReturnGoodsVOHelper.getInstance().Read(elem4, iprot);
								
								value.Add(elem4);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetOrderReturnGoods(value);
					}
					
					
					
					
					
					if ("orderReturnPackageInfo".Equals(schemeField.Trim())){
						
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
						
						structs.SetOrderReturnPackageInfo(value);
					}
					
					
					
					
					
					if ("orderReturnRefundDetailsList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.order.common.pojo.order.vo.OrderRefundDetailsVO> value;
						
						value = new List<com.vip.order.common.pojo.order.vo.OrderRefundDetailsVO>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.order.common.pojo.order.vo.OrderRefundDetailsVO elem8;
								
								elem8 = new com.vip.order.common.pojo.order.vo.OrderRefundDetailsVO();
								com.vip.order.common.pojo.order.vo.OrderRefundDetailsVOHelper.getInstance().Read(elem8, iprot);
								
								value.Add(elem8);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetOrderReturnRefundDetailsList(value);
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
		
		
		public void Write(OrderReturnApplyListVO structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetOrderReturnApply() != null) {
				
				oprot.WriteFieldBegin("orderReturnApply");
				
				com.vip.order.common.pojo.order.vo.OrderReturnApplyVOHelper.getInstance().Write(structs.GetOrderReturnApply(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderReturnReceiveAddr() != null) {
				
				oprot.WriteFieldBegin("orderReturnReceiveAddr");
				
				com.vip.order.common.pojo.order.vo.OrderReceiveAddrVOHelper.getInstance().Write(structs.GetOrderReturnReceiveAddr(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderReturnTransportInfo() != null) {
				
				oprot.WriteFieldBegin("orderReturnTransportInfo");
				
				com.vip.order.common.pojo.order.vo.OrderReturnTransportInfoVOHelper.getInstance().Write(structs.GetOrderReturnTransportInfo(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderReturnGoods() != null) {
				
				oprot.WriteFieldBegin("orderReturnGoods");
				
				oprot.WriteListBegin();
				foreach(com.vip.order.common.pojo.order.vo.OrderReturnGoodsVO _item0 in structs.GetOrderReturnGoods()){
					
					
					com.vip.order.common.pojo.order.vo.OrderReturnGoodsVOHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderReturnPackageInfo() != null) {
				
				oprot.WriteFieldBegin("orderReturnPackageInfo");
				
				oprot.WriteListBegin();
				foreach(com.vip.order.common.pojo.order.vo.OrderReturnPackageInfoVO _item0 in structs.GetOrderReturnPackageInfo()){
					
					
					com.vip.order.common.pojo.order.vo.OrderReturnPackageInfoVOHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderReturnRefundDetailsList() != null) {
				
				oprot.WriteFieldBegin("orderReturnRefundDetailsList");
				
				oprot.WriteListBegin();
				foreach(com.vip.order.common.pojo.order.vo.OrderRefundDetailsVO _item0 in structs.GetOrderReturnRefundDetailsList()){
					
					
					com.vip.order.common.pojo.order.vo.OrderRefundDetailsVOHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(OrderReturnApplyListVO bean){
			
			
		}
		
	}
	
}