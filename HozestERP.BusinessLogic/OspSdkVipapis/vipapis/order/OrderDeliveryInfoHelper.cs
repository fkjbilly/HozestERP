using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.order{
	
	
	
	public class OrderDeliveryInfoHelper : TBeanSerializer<OrderDeliveryInfo>
	{
		
		public static OrderDeliveryInfoHelper OBJ = new OrderDeliveryInfoHelper();
		
		public static OrderDeliveryInfoHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(OrderDeliveryInfo structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("order_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOrder_id(value);
					}
					
					
					
					
					
					if ("delivery_list".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.order.DeliveryInfo> value;
						
						value = new List<vipapis.order.DeliveryInfo>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.order.DeliveryInfo elem0;
								
								elem0 = new vipapis.order.DeliveryInfo();
								vipapis.order.DeliveryInfoHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetDelivery_list(value);
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
		
		
		public void Write(OrderDeliveryInfo structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetOrder_id() != null) {
				
				oprot.WriteFieldBegin("order_id");
				oprot.WriteString(structs.GetOrder_id());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetDelivery_list() != null) {
				
				oprot.WriteFieldBegin("delivery_list");
				
				oprot.WriteListBegin();
				foreach(vipapis.order.DeliveryInfo _item0 in structs.GetDelivery_list()){
					
					
					vipapis.order.DeliveryInfoHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(OrderDeliveryInfo bean){
			
			
		}
		
	}
	
}