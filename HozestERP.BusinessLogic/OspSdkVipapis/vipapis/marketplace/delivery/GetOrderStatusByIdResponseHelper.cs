using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.marketplace.delivery{
	
	
	
	public class GetOrderStatusByIdResponseHelper : TBeanSerializer<GetOrderStatusByIdResponse>
	{
		
		public static GetOrderStatusByIdResponseHelper OBJ = new GetOrderStatusByIdResponseHelper();
		
		public static GetOrderStatusByIdResponseHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(GetOrderStatusByIdResponse structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("order_status_list".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.marketplace.delivery.OrderStatus> value;
						
						value = new List<vipapis.marketplace.delivery.OrderStatus>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.marketplace.delivery.OrderStatus elem1;
								
								elem1 = new vipapis.marketplace.delivery.OrderStatus();
								vipapis.marketplace.delivery.OrderStatusHelper.getInstance().Read(elem1, iprot);
								
								value.Add(elem1);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetOrder_status_list(value);
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
		
		
		public void Write(GetOrderStatusByIdResponse structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetOrder_status_list() != null) {
				
				oprot.WriteFieldBegin("order_status_list");
				
				oprot.WriteListBegin();
				foreach(vipapis.marketplace.delivery.OrderStatus _item0 in structs.GetOrder_status_list()){
					
					
					vipapis.marketplace.delivery.OrderStatusHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("order_status_list can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(GetOrderStatusByIdResponse bean){
			
			
		}
		
	}
	
}