using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.common.pojo.order.vo{
	
	
	
	public class OrderGoodsVOHelper : TBeanSerializer<OrderGoodsVO>
	{
		
		public static OrderGoodsVOHelper OBJ = new OrderGoodsVOHelper();
		
		public static OrderGoodsVOHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(OrderGoodsVO structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("orderGoodsId".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetOrderGoodsId(value);
					}
					
					
					
					
					
					if ("merchandiseNo".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetMerchandiseNo(value);
					}
					
					
					
					
					
					if ("amount".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetAmount(value);
					}
					
					
					
					
					
					if ("priceId".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetPriceId(value);
					}
					
					
					
					
					
					if ("skuId".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetSkuId(value);
					}
					
					
					
					
					
					if ("goodsVersion".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetGoodsVersion(value);
					}
					
					
					
					
					
					if ("salesNo".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetSalesNo(value);
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
					
					
					
					
					
					if ("sellPrice".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSellPrice(value);
					}
					
					
					
					
					
					if ("goodsType".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetGoodsType(value);
					}
					
					
					
					
					
					if ("presentId".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetPresentId(value);
					}
					
					
					
					
					
					if ("presentName".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPresentName(value);
					}
					
					
					
					
					
					if ("remark".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetRemark(value);
					}
					
					
					
					
					
					if ("isDelete".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetIsDelete(value);
					}
					
					
					
					
					
					if ("goodsStatus".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetGoodsStatus(value);
					}
					
					
					
					
					
					if ("totalAomunt".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetTotalAomunt(value);
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
					
					
					
					
					
					if ("subOrderSn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSubOrderSn(value);
					}
					
					
					
					
					
					if ("saleStyle".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetSaleStyle(value);
					}
					
					
					
					
					
					if ("brandWarehouse".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBrandWarehouse(value);
					}
					
					
					
					
					
					if ("bondedWarehouse".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBondedWarehouse(value);
					}
					
					
					
					
					
					if ("orderWarehouse".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOrderWarehouse(value);
					}
					
					
					
					
					
					if ("goodsSubtotal".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetGoodsSubtotal(value);
					}
					
					
					
					
					
					if ("posNo".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPosNo(value);
					}
					
					
					
					
					
					if ("allocateId".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetAllocateId(value);
					}
					
					
					
					
					
					if ("priceTime".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetPriceTime(value);
					}
					
					
					
					
					
					if ("isCjcLarge".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetIsCjcLarge(value);
					}
					
					
					
					
					
					if ("defaultSaleStyle".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetDefaultSaleStyle(value);
					}
					
					
					
					
					
					if ("originMerItemNo".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetOriginMerItemNo(value);
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
		
		
		public void Write(OrderGoodsVO structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetOrderGoodsId() != null) {
				
				oprot.WriteFieldBegin("orderGoodsId");
				oprot.WriteI64((long)structs.GetOrderGoodsId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetMerchandiseNo() != null) {
				
				oprot.WriteFieldBegin("merchandiseNo");
				oprot.WriteI64((long)structs.GetMerchandiseNo()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetAmount() != null) {
				
				oprot.WriteFieldBegin("amount");
				oprot.WriteI32((int)structs.GetAmount()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPriceId() != null) {
				
				oprot.WriteFieldBegin("priceId");
				oprot.WriteI64((long)structs.GetPriceId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSkuId() != null) {
				
				oprot.WriteFieldBegin("skuId");
				oprot.WriteI64((long)structs.GetSkuId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetGoodsVersion() != null) {
				
				oprot.WriteFieldBegin("goodsVersion");
				oprot.WriteI32((int)structs.GetGoodsVersion()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSalesNo() != null) {
				
				oprot.WriteFieldBegin("salesNo");
				oprot.WriteI64((long)structs.GetSalesNo()); 
				
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
			
			
			if(structs.GetSellPrice() != null) {
				
				oprot.WriteFieldBegin("sellPrice");
				oprot.WriteString(structs.GetSellPrice());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetGoodsType() != null) {
				
				oprot.WriteFieldBegin("goodsType");
				oprot.WriteI32((int)structs.GetGoodsType()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPresentId() != null) {
				
				oprot.WriteFieldBegin("presentId");
				oprot.WriteI32((int)structs.GetPresentId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPresentName() != null) {
				
				oprot.WriteFieldBegin("presentName");
				oprot.WriteString(structs.GetPresentName());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetRemark() != null) {
				
				oprot.WriteFieldBegin("remark");
				oprot.WriteString(structs.GetRemark());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetIsDelete() != null) {
				
				oprot.WriteFieldBegin("isDelete");
				oprot.WriteI32((int)structs.GetIsDelete()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetGoodsStatus() != null) {
				
				oprot.WriteFieldBegin("goodsStatus");
				oprot.WriteI32((int)structs.GetGoodsStatus()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTotalAomunt() != null) {
				
				oprot.WriteFieldBegin("totalAomunt");
				oprot.WriteI32((int)structs.GetTotalAomunt()); 
				
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
			
			
			if(structs.GetSubOrderSn() != null) {
				
				oprot.WriteFieldBegin("subOrderSn");
				oprot.WriteString(structs.GetSubOrderSn());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSaleStyle() != null) {
				
				oprot.WriteFieldBegin("saleStyle");
				oprot.WriteI32((int)structs.GetSaleStyle()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBrandWarehouse() != null) {
				
				oprot.WriteFieldBegin("brandWarehouse");
				oprot.WriteString(structs.GetBrandWarehouse());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBondedWarehouse() != null) {
				
				oprot.WriteFieldBegin("bondedWarehouse");
				oprot.WriteString(structs.GetBondedWarehouse());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderWarehouse() != null) {
				
				oprot.WriteFieldBegin("orderWarehouse");
				oprot.WriteString(structs.GetOrderWarehouse());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetGoodsSubtotal() != null) {
				
				oprot.WriteFieldBegin("goodsSubtotal");
				oprot.WriteString(structs.GetGoodsSubtotal());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPosNo() != null) {
				
				oprot.WriteFieldBegin("posNo");
				oprot.WriteString(structs.GetPosNo());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetAllocateId() != null) {
				
				oprot.WriteFieldBegin("allocateId");
				oprot.WriteI64((long)structs.GetAllocateId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPriceTime() != null) {
				
				oprot.WriteFieldBegin("priceTime");
				oprot.WriteI64((long)structs.GetPriceTime()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetIsCjcLarge() != null) {
				
				oprot.WriteFieldBegin("isCjcLarge");
				oprot.WriteI32((int)structs.GetIsCjcLarge()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetDefaultSaleStyle() != null) {
				
				oprot.WriteFieldBegin("defaultSaleStyle");
				oprot.WriteI32((int)structs.GetDefaultSaleStyle()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOriginMerItemNo() != null) {
				
				oprot.WriteFieldBegin("originMerItemNo");
				oprot.WriteI64((long)structs.GetOriginMerItemNo()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(OrderGoodsVO bean){
			
			
		}
		
	}
	
}