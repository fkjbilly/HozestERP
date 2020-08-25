using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.common.pojo.order.vo{
	
	
	
	public class OrderDeliveryVOHelper : TBeanSerializer<OrderDeliveryVO>
	{
		
		public static OrderDeliveryVOHelper OBJ = new OrderDeliveryVOHelper();
		
		public static OrderDeliveryVOHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(OrderDeliveryVO structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("addressCode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetAddressCode(value);
					}
					
					
					
					
					
					if ("saleTypeList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<int?> value;
						
						value = new List<int?>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								int elem0;
								elem0 = iprot.ReadI32(); 
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetSaleTypeList(value);
					}
					
					
					
					
					
					if ("orderWarehouse".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOrderWarehouse(value);
					}
					
					
					
					
					
					if ("goodsWarehouseList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.order.common.pojo.order.vo.GoodsWarehouseVO> value;
						
						value = new List<com.vip.order.common.pojo.order.vo.GoodsWarehouseVO>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.order.common.pojo.order.vo.GoodsWarehouseVO elem1;
								
								elem1 = new com.vip.order.common.pojo.order.vo.GoodsWarehouseVO();
								com.vip.order.common.pojo.order.vo.GoodsWarehouseVOHelper.getInstance().Read(elem1, iprot);
								
								value.Add(elem1);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetGoodsWarehouseList(value);
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
		
		
		public void Write(OrderDeliveryVO structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetAddressCode() != null) {
				
				oprot.WriteFieldBegin("addressCode");
				oprot.WriteString(structs.GetAddressCode());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSaleTypeList() != null) {
				
				oprot.WriteFieldBegin("saleTypeList");
				
				oprot.WriteListBegin();
				foreach(int _item0 in structs.GetSaleTypeList()){
					
					oprot.WriteI32((int)_item0); 
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderWarehouse() != null) {
				
				oprot.WriteFieldBegin("orderWarehouse");
				oprot.WriteString(structs.GetOrderWarehouse());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetGoodsWarehouseList() != null) {
				
				oprot.WriteFieldBegin("goodsWarehouseList");
				
				oprot.WriteListBegin();
				foreach(com.vip.order.common.pojo.order.vo.GoodsWarehouseVO _item0 in structs.GetGoodsWarehouseList()){
					
					
					com.vip.order.common.pojo.order.vo.GoodsWarehouseVOHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(OrderDeliveryVO bean){
			
			
		}
		
	}
	
}