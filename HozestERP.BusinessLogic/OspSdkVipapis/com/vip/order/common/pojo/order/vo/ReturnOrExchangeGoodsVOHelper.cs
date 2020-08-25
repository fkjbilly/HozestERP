using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.common.pojo.order.vo{
	
	
	
	public class ReturnOrExchangeGoodsVOHelper : TBeanSerializer<ReturnOrExchangeGoodsVO>
	{
		
		public static ReturnOrExchangeGoodsVOHelper OBJ = new ReturnOrExchangeGoodsVOHelper();
		
		public static ReturnOrExchangeGoodsVOHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(ReturnOrExchangeGoodsVO structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("merchandiseNo".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetMerchandiseNo(value);
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
					
					
					
					
					
					if ("reasonCode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetReasonCode(value);
					}
					
					
					
					
					
					if ("reason".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetReason(value);
					}
					
					
					
					
					
					if ("exchangeGoodsStockList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.order.common.pojo.order.vo.ExchangeGoodsStockVO> value;
						
						value = new List<com.vip.order.common.pojo.order.vo.ExchangeGoodsStockVO>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.order.common.pojo.order.vo.ExchangeGoodsStockVO elem0;
								
								elem0 = new com.vip.order.common.pojo.order.vo.ExchangeGoodsStockVO();
								com.vip.order.common.pojo.order.vo.ExchangeGoodsStockVOHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetExchangeGoodsStockList(value);
					}
					
					
					
					
					
					if ("exActSubtotal".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetExActSubtotal(value);
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
		
		
		public void Write(ReturnOrExchangeGoodsVO structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetMerchandiseNo() != null) {
				
				oprot.WriteFieldBegin("merchandiseNo");
				oprot.WriteI64((long)structs.GetMerchandiseNo()); 
				
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
			
			
			if(structs.GetReasonCode() != null) {
				
				oprot.WriteFieldBegin("reasonCode");
				oprot.WriteString(structs.GetReasonCode());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetReason() != null) {
				
				oprot.WriteFieldBegin("reason");
				oprot.WriteString(structs.GetReason());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetExchangeGoodsStockList() != null) {
				
				oprot.WriteFieldBegin("exchangeGoodsStockList");
				
				oprot.WriteListBegin();
				foreach(com.vip.order.common.pojo.order.vo.ExchangeGoodsStockVO _item0 in structs.GetExchangeGoodsStockList()){
					
					
					com.vip.order.common.pojo.order.vo.ExchangeGoodsStockVOHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetExActSubtotal() != null) {
				
				oprot.WriteFieldBegin("exActSubtotal");
				oprot.WriteString(structs.GetExActSubtotal());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(ReturnOrExchangeGoodsVO bean){
			
			
		}
		
	}
	
}