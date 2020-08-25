using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.common.pojo.order.vo{
	
	
	
	public class OrderGoodsAndDescribeVOHelper : TBeanSerializer<OrderGoodsAndDescribeVO>
	{
		
		public static OrderGoodsAndDescribeVOHelper OBJ = new OrderGoodsAndDescribeVOHelper();
		
		public static OrderGoodsAndDescribeVOHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(OrderGoodsAndDescribeVO structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("orderGoodsDescribeList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.order.common.pojo.order.vo.OrderGoodsDescribeVO> value;
						
						value = new List<com.vip.order.common.pojo.order.vo.OrderGoodsDescribeVO>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.order.common.pojo.order.vo.OrderGoodsDescribeVO elem1;
								
								elem1 = new com.vip.order.common.pojo.order.vo.OrderGoodsDescribeVO();
								com.vip.order.common.pojo.order.vo.OrderGoodsDescribeVOHelper.getInstance().Read(elem1, iprot);
								
								value.Add(elem1);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetOrderGoodsDescribeList(value);
					}
					
					
					
					
					
					if ("orderGoods".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.order.common.pojo.order.vo.OrderGoodsVO value;
						
						value = new com.vip.order.common.pojo.order.vo.OrderGoodsVO();
						com.vip.order.common.pojo.order.vo.OrderGoodsVOHelper.getInstance().Read(value, iprot);
						
						structs.SetOrderGoods(value);
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
		
		
		public void Write(OrderGoodsAndDescribeVO structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetOrderGoodsDescribeList() != null) {
				
				oprot.WriteFieldBegin("orderGoodsDescribeList");
				
				oprot.WriteListBegin();
				foreach(com.vip.order.common.pojo.order.vo.OrderGoodsDescribeVO _item0 in structs.GetOrderGoodsDescribeList()){
					
					
					com.vip.order.common.pojo.order.vo.OrderGoodsDescribeVOHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderGoods() != null) {
				
				oprot.WriteFieldBegin("orderGoods");
				
				com.vip.order.common.pojo.order.vo.OrderGoodsVOHelper.getInstance().Write(structs.GetOrderGoods(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(OrderGoodsAndDescribeVO bean){
			
			
		}
		
	}
	
}