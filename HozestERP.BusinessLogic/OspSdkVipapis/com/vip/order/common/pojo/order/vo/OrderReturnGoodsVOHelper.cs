using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.common.pojo.order.vo{
	
	
	
	public class OrderReturnGoodsVOHelper : TBeanSerializer<OrderReturnGoodsVO>
	{
		
		public static OrderReturnGoodsVOHelper OBJ = new OrderReturnGoodsVOHelper();
		
		public static OrderReturnGoodsVOHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(OrderReturnGoodsVO structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("applyId".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetApplyId(value);
					}
					
					
					
					
					
					if ("orderReturnGoodsId".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetOrderReturnGoodsId(value);
					}
					
					
					
					
					
					if ("orderReturnTransportId".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetOrderReturnTransportId(value);
					}
					
					
					
					
					
					if ("merItemNo".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetMerItemNo(value);
					}
					
					
					
					
					
					if ("sn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSn(value);
					}
					
					
					
					
					
					if ("goodsName".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetGoodsName(value);
					}
					
					
					
					
					
					if ("salesName".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSalesName(value);
					}
					
					
					
					
					
					if ("sizeName".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSizeName(value);
					}
					
					
					
					
					
					if ("priceId".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetPriceId(value);
					}
					
					
					
					
					
					if ("vSkuId".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetVSkuId(value);
					}
					
					
					
					
					
					if ("goodsVersion".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetGoodsVersion(value);
					}
					
					
					
					
					
					if ("amount".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetAmount(value);
					}
					
					
					
					
					
					if ("sellPrice".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSellPrice(value);
					}
					
					
					
					
					
					if ("goodsType".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetGoodsType(value);
					}
					
					
					
					
					
					if ("returnReasonId".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetReturnReasonId(value);
					}
					
					
					
					
					
					if ("ourReasonFlag".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOurReasonFlag(value);
					}
					
					
					
					
					
					if ("specialRefund".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSpecialRefund(value);
					}
					
					
					
					
					
					if ("specialRefundReason".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetSpecialRefundReason(value);
					}
					
					
					
					
					
					if ("reasonRemark".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetReasonRemark(value);
					}
					
					
					
					
					
					if ("goodsBackFlag".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetGoodsBackFlag(value);
					}
					
					
					
					
					
					if ("backTime".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetBackTime(value);
					}
					
					
					
					
					
					if ("returnReasonDetails".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetReturnReasonDetails(value);
					}
					
					
					
					
					
					if ("isDeleted".Equals(schemeField.Trim())){
						
						needSkip = false;
						byte? value;
						value = iprot.ReadByte(); 
						
						structs.SetIsDeleted(value);
					}
					
					
					
					
					
					if ("salesNo".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSalesNo(value);
					}
					
					
					
					
					
					if ("merchandiseNo".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetMerchandiseNo(value);
					}
					
					
					
					
					
					if ("orderId".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetOrderId(value);
					}
					
					
					
					
					
					if ("exActSubtotal".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetExActSubtotal(value);
					}
					
					
					
					
					
					if ("exCouponSubTotal".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetExCouponSubTotal(value);
					}
					
					
					
					
					
					if ("exPaySubtotal".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetExPaySubtotal(value);
					}
					
					
					
					
					
					if ("exAllSubtotal".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetExAllSubtotal(value);
					}
					
					
					
					
					
					if ("addTime".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetAddTime(value);
					}
					
					
					
					
					
					if ("operatorName".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOperatorName(value);
					}
					
					
					
					
					
					if ("priceTime".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetPriceTime(value);
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
		
		
		public void Write(OrderReturnGoodsVO structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetApplyId() != null) {
				
				oprot.WriteFieldBegin("applyId");
				oprot.WriteI64((long)structs.GetApplyId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderReturnGoodsId() != null) {
				
				oprot.WriteFieldBegin("orderReturnGoodsId");
				oprot.WriteI64((long)structs.GetOrderReturnGoodsId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderReturnTransportId() != null) {
				
				oprot.WriteFieldBegin("orderReturnTransportId");
				oprot.WriteI64((long)structs.GetOrderReturnTransportId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetMerItemNo() != null) {
				
				oprot.WriteFieldBegin("merItemNo");
				oprot.WriteI64((long)structs.GetMerItemNo()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSn() != null) {
				
				oprot.WriteFieldBegin("sn");
				oprot.WriteString(structs.GetSn());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetGoodsName() != null) {
				
				oprot.WriteFieldBegin("goodsName");
				oprot.WriteString(structs.GetGoodsName());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSalesName() != null) {
				
				oprot.WriteFieldBegin("salesName");
				oprot.WriteString(structs.GetSalesName());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSizeName() != null) {
				
				oprot.WriteFieldBegin("sizeName");
				oprot.WriteString(structs.GetSizeName());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPriceId() != null) {
				
				oprot.WriteFieldBegin("priceId");
				oprot.WriteI64((long)structs.GetPriceId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetVSkuId() != null) {
				
				oprot.WriteFieldBegin("vSkuId");
				oprot.WriteI64((long)structs.GetVSkuId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetGoodsVersion() != null) {
				
				oprot.WriteFieldBegin("goodsVersion");
				oprot.WriteI32((int)structs.GetGoodsVersion()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetAmount() != null) {
				
				oprot.WriteFieldBegin("amount");
				oprot.WriteI32((int)structs.GetAmount()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSellPrice() != null) {
				
				oprot.WriteFieldBegin("sellPrice");
				oprot.WriteString(structs.GetSellPrice());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetGoodsType() != null) {
				
				oprot.WriteFieldBegin("goodsType");
				oprot.WriteString(structs.GetGoodsType());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetReturnReasonId() != null) {
				
				oprot.WriteFieldBegin("returnReasonId");
				oprot.WriteI32((int)structs.GetReturnReasonId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOurReasonFlag() != null) {
				
				oprot.WriteFieldBegin("ourReasonFlag");
				oprot.WriteString(structs.GetOurReasonFlag());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSpecialRefund() != null) {
				
				oprot.WriteFieldBegin("specialRefund");
				oprot.WriteString(structs.GetSpecialRefund());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSpecialRefundReason() != null) {
				
				oprot.WriteFieldBegin("specialRefundReason");
				oprot.WriteI32((int)structs.GetSpecialRefundReason()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetReasonRemark() != null) {
				
				oprot.WriteFieldBegin("reasonRemark");
				oprot.WriteString(structs.GetReasonRemark());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetGoodsBackFlag() != null) {
				
				oprot.WriteFieldBegin("goodsBackFlag");
				oprot.WriteString(structs.GetGoodsBackFlag());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBackTime() != null) {
				
				oprot.WriteFieldBegin("backTime");
				oprot.WriteI64((long)structs.GetBackTime()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetReturnReasonDetails() != null) {
				
				oprot.WriteFieldBegin("returnReasonDetails");
				oprot.WriteString(structs.GetReturnReasonDetails());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetIsDeleted() != null) {
				
				oprot.WriteFieldBegin("isDeleted");
				oprot.WriteByte((byte)structs.GetIsDeleted()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSalesNo() != null) {
				
				oprot.WriteFieldBegin("salesNo");
				oprot.WriteString(structs.GetSalesNo());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetMerchandiseNo() != null) {
				
				oprot.WriteFieldBegin("merchandiseNo");
				oprot.WriteI32((int)structs.GetMerchandiseNo()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderId() != null) {
				
				oprot.WriteFieldBegin("orderId");
				oprot.WriteI64((long)structs.GetOrderId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetExActSubtotal() != null) {
				
				oprot.WriteFieldBegin("exActSubtotal");
				oprot.WriteString(structs.GetExActSubtotal());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetExCouponSubTotal() != null) {
				
				oprot.WriteFieldBegin("exCouponSubTotal");
				oprot.WriteString(structs.GetExCouponSubTotal());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetExPaySubtotal() != null) {
				
				oprot.WriteFieldBegin("exPaySubtotal");
				oprot.WriteString(structs.GetExPaySubtotal());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetExAllSubtotal() != null) {
				
				oprot.WriteFieldBegin("exAllSubtotal");
				oprot.WriteString(structs.GetExAllSubtotal());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetAddTime() != null) {
				
				oprot.WriteFieldBegin("addTime");
				oprot.WriteI64((long)structs.GetAddTime()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOperatorName() != null) {
				
				oprot.WriteFieldBegin("operatorName");
				oprot.WriteString(structs.GetOperatorName());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPriceTime() != null) {
				
				oprot.WriteFieldBegin("priceTime");
				oprot.WriteI64((long)structs.GetPriceTime()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(OrderReturnGoodsVO bean){
			
			
		}
		
	}
	
}