using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.common.pojo.order.vo{
	
	
	
	public class OrderExchangeGoodsVOHelper : TBeanSerializer<OrderExchangeGoodsVO>
	{
		
		public static OrderExchangeGoodsVOHelper OBJ = new OrderExchangeGoodsVOHelper();
		
		public static OrderExchangeGoodsVOHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(OrderExchangeGoodsVO structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("orderExchangeGoodsId".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetOrderExchangeGoodsId(value);
					}
					
					
					
					
					
					if ("orderSn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOrderSn(value);
					}
					
					
					
					
					
					if ("applyId".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetApplyId(value);
					}
					
					
					
					
					
					if ("reasonId".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetReasonId(value);
					}
					
					
					
					
					
					if ("orderExchangeTransportId".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetOrderExchangeTransportId(value);
					}
					
					
					
					
					
					if ("merItemNo".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetMerItemNo(value);
					}
					
					
					
					
					
					if ("merchandiseNo".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetMerchandiseNo(value);
					}
					
					
					
					
					
					if ("salesNo".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetSalesNo(value);
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
					
					
					
					
					
					if ("amount".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetAmount(value);
					}
					
					
					
					
					
					if ("newMerItemNo".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetNewMerItemNo(value);
					}
					
					
					
					
					
					if ("newMerchandiseNo".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetNewMerchandiseNo(value);
					}
					
					
					
					
					
					if ("newSalesNo".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetNewSalesNo(value);
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
					
					
					
					
					
					if ("stockSource".Equals(schemeField.Trim())){
						
						needSkip = false;
						byte? value;
						value = iprot.ReadByte(); 
						
						structs.SetStockSource(value);
					}
					
					
					
					
					
					if ("stockState".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetStockState(value);
					}
					
					
					
					
					
					if ("isDeleted".Equals(schemeField.Trim())){
						
						needSkip = false;
						byte? value;
						value = iprot.ReadByte(); 
						
						structs.SetIsDeleted(value);
					}
					
					
					
					
					
					if ("createTime".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetCreateTime(value);
					}
					
					
					
					
					
					if ("updateTime".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetUpdateTime(value);
					}
					
					
					
					
					
					if ("newSizeName".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetNewSizeName(value);
					}
					
					
					
					
					
					if ("remark".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetRemark(value);
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
					
					
					
					
					
					if ("newPriceId".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetNewPriceId(value);
					}
					
					
					
					
					
					if ("newVSkuId".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetNewVSkuId(value);
					}
					
					
					
					
					
					if ("newSn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetNewSn(value);
					}
					
					
					
					
					
					if ("newAmount".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetNewAmount(value);
					}
					
					
					
					
					
					if ("posNo".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPosNo(value);
					}
					
					
					
					
					
					if ("priceTime".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetPriceTime(value);
					}
					
					
					
					
					
					if ("newPriceTime".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetNewPriceTime(value);
					}
					
					
					
					
					
					if ("decorateFlag".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetDecorateFlag(value);
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
		
		
		public void Write(OrderExchangeGoodsVO structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetOrderExchangeGoodsId() != null) {
				
				oprot.WriteFieldBegin("orderExchangeGoodsId");
				oprot.WriteI64((long)structs.GetOrderExchangeGoodsId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderSn() != null) {
				
				oprot.WriteFieldBegin("orderSn");
				oprot.WriteString(structs.GetOrderSn());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetApplyId() != null) {
				
				oprot.WriteFieldBegin("applyId");
				oprot.WriteI64((long)structs.GetApplyId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetReasonId() != null) {
				
				oprot.WriteFieldBegin("reasonId");
				oprot.WriteI32((int)structs.GetReasonId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderExchangeTransportId() != null) {
				
				oprot.WriteFieldBegin("orderExchangeTransportId");
				oprot.WriteI64((long)structs.GetOrderExchangeTransportId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetMerItemNo() != null) {
				
				oprot.WriteFieldBegin("merItemNo");
				oprot.WriteI64((long)structs.GetMerItemNo()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetMerchandiseNo() != null) {
				
				oprot.WriteFieldBegin("merchandiseNo");
				oprot.WriteI64((long)structs.GetMerchandiseNo()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSalesNo() != null) {
				
				oprot.WriteFieldBegin("salesNo");
				oprot.WriteI64((long)structs.GetSalesNo()); 
				
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
			
			
			if(structs.GetAmount() != null) {
				
				oprot.WriteFieldBegin("amount");
				oprot.WriteI32((int)structs.GetAmount()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetNewMerItemNo() != null) {
				
				oprot.WriteFieldBegin("newMerItemNo");
				oprot.WriteI64((long)structs.GetNewMerItemNo()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetNewMerchandiseNo() != null) {
				
				oprot.WriteFieldBegin("newMerchandiseNo");
				oprot.WriteI64((long)structs.GetNewMerchandiseNo()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetNewSalesNo() != null) {
				
				oprot.WriteFieldBegin("newSalesNo");
				oprot.WriteI64((long)structs.GetNewSalesNo()); 
				
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
			
			
			if(structs.GetStockSource() != null) {
				
				oprot.WriteFieldBegin("stockSource");
				oprot.WriteByte((byte)structs.GetStockSource()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetStockState() != null) {
				
				oprot.WriteFieldBegin("stockState");
				oprot.WriteString(structs.GetStockState());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetIsDeleted() != null) {
				
				oprot.WriteFieldBegin("isDeleted");
				oprot.WriteByte((byte)structs.GetIsDeleted()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCreateTime() != null) {
				
				oprot.WriteFieldBegin("createTime");
				oprot.WriteI64((long)structs.GetCreateTime()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetUpdateTime() != null) {
				
				oprot.WriteFieldBegin("updateTime");
				oprot.WriteI64((long)structs.GetUpdateTime()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetNewSizeName() != null) {
				
				oprot.WriteFieldBegin("newSizeName");
				oprot.WriteString(structs.GetNewSizeName());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetRemark() != null) {
				
				oprot.WriteFieldBegin("remark");
				oprot.WriteString(structs.GetRemark());
				
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
			
			
			if(structs.GetNewPriceId() != null) {
				
				oprot.WriteFieldBegin("newPriceId");
				oprot.WriteI64((long)structs.GetNewPriceId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetNewVSkuId() != null) {
				
				oprot.WriteFieldBegin("newVSkuId");
				oprot.WriteI64((long)structs.GetNewVSkuId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetNewSn() != null) {
				
				oprot.WriteFieldBegin("newSn");
				oprot.WriteString(structs.GetNewSn());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetNewAmount() != null) {
				
				oprot.WriteFieldBegin("newAmount");
				oprot.WriteString(structs.GetNewAmount());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPosNo() != null) {
				
				oprot.WriteFieldBegin("posNo");
				oprot.WriteString(structs.GetPosNo());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPriceTime() != null) {
				
				oprot.WriteFieldBegin("priceTime");
				oprot.WriteI64((long)structs.GetPriceTime()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetNewPriceTime() != null) {
				
				oprot.WriteFieldBegin("newPriceTime");
				oprot.WriteI64((long)structs.GetNewPriceTime()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetDecorateFlag() != null) {
				
				oprot.WriteFieldBegin("decorateFlag");
				oprot.WriteI32((int)structs.GetDecorateFlag()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(OrderExchangeGoodsVO bean){
			
			
		}
		
	}
	
}