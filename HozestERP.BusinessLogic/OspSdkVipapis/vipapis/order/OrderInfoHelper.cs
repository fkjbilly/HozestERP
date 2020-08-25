using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.order{
	
	
	
	public class OrderInfoHelper : BeanSerializer<OrderInfo>
	{
		
		public static OrderInfoHelper OBJ = new OrderInfoHelper();
		
		public static OrderInfoHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(OrderInfo structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("order_sn".Equals(schemeField.Trim())){
						
						needSkip = false;
						long value;
						value = iprot.ReadI64(); 
						
						structs.SetOrder_sn(value);
					}
					
					
					
					
					
					if ("order_time".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetOrder_time(value);
					}
					
					
					
					
					
					if ("status".Equals(schemeField.Trim())){
						
						needSkip = false;
						vipapis.common.OrderStatus? value;
						
						value = vipapis.common.OrderStatusUtil.FindByName(iprot.ReadString());
						
						structs.SetStatus(value);
					}
					
					
					
					
					
					if ("goods_list".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.order.OrderGoods> value;
						
						value = new List<vipapis.order.OrderGoods>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.order.OrderGoods elem0;
								
								elem0 = new vipapis.order.OrderGoods();
								vipapis.order.OrderGoodsHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetGoods_list(value);
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
		
		
		public void Write(OrderInfo structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetOrder_sn() != null) {
				
				oprot.WriteFieldBegin("order_sn");
				oprot.WriteI64((long)structs.GetOrder_sn()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("order_sn can not be null!");
			}
			
			
			if(structs.GetOrder_time() != null) {
				
				oprot.WriteFieldBegin("order_time");
				oprot.WriteI32((int)structs.GetOrder_time()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("order_time can not be null!");
			}
			
			
			if(structs.GetStatus() != null) {
				
				oprot.WriteFieldBegin("status");
				oprot.WriteString(structs.GetStatus().ToString());  
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetGoods_list() != null) {
				
				oprot.WriteFieldBegin("goods_list");
				
				oprot.WriteListBegin();
				foreach(vipapis.order.OrderGoods _item0 in structs.GetGoods_list()){
					
					
					vipapis.order.OrderGoodsHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(OrderInfo bean){
			
			
		}
		
	}
	
}