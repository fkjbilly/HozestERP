using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.biz.request{
	
	
	
	public class OrderGoodsConditionHelper : TBeanSerializer<OrderGoodsCondition>
	{
		
		public static OrderGoodsConditionHelper OBJ = new OrderGoodsConditionHelper();
		
		public static OrderGoodsConditionHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(OrderGoodsCondition structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("orderGoodsIdList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<long?> value;
						
						value = new List<long?>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								long elem0;
								elem0 = iprot.ReadI64(); 
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetOrderGoodsIdList(value);
					}
					
					
					
					
					
					if ("brandId".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetBrandId(value);
					}
					
					
					
					
					
					if ("goodsId".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetGoodsId(value);
					}
					
					
					
					
					
					if ("sizeId".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetSizeId(value);
					}
					
					
					
					
					
					if ("goodsStatus".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetGoodsStatus(value);
					}
					
					
					
					
					
					if ("goodsType".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetGoodsType(value);
					}
					
					
					
					
					
					if ("goodsCount".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetGoodsCount(value);
					}
					
					
					
					
					
					if ("price".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPrice(value);
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
		
		
		public void Write(OrderGoodsCondition structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetOrderGoodsIdList() != null) {
				
				oprot.WriteFieldBegin("orderGoodsIdList");
				
				oprot.WriteListBegin();
				foreach(long _item0 in structs.GetOrderGoodsIdList()){
					
					oprot.WriteI64((long)_item0); 
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBrandId() != null) {
				
				oprot.WriteFieldBegin("brandId");
				oprot.WriteI32((int)structs.GetBrandId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetGoodsId() != null) {
				
				oprot.WriteFieldBegin("goodsId");
				oprot.WriteI64((long)structs.GetGoodsId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSizeId() != null) {
				
				oprot.WriteFieldBegin("sizeId");
				oprot.WriteI32((int)structs.GetSizeId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetGoodsStatus() != null) {
				
				oprot.WriteFieldBegin("goodsStatus");
				oprot.WriteString(structs.GetGoodsStatus());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetGoodsType() != null) {
				
				oprot.WriteFieldBegin("goodsType");
				oprot.WriteString(structs.GetGoodsType());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetGoodsCount() != null) {
				
				oprot.WriteFieldBegin("goodsCount");
				oprot.WriteString(structs.GetGoodsCount());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPrice() != null) {
				
				oprot.WriteFieldBegin("price");
				oprot.WriteString(structs.GetPrice());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(OrderGoodsCondition bean){
			
			
		}
		
	}
	
}