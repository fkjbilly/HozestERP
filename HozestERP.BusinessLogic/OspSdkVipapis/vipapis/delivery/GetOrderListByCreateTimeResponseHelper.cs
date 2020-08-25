using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.delivery{
	
	
	
	public class GetOrderListByCreateTimeResponseHelper : TBeanSerializer<GetOrderListByCreateTimeResponse>
	{
		
		public static GetOrderListByCreateTimeResponseHelper OBJ = new GetOrderListByCreateTimeResponseHelper();
		
		public static GetOrderListByCreateTimeResponseHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(GetOrderListByCreateTimeResponse structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("order_list_by_create_time".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.delivery.OrderListByCreateTime> value;
						
						value = new List<vipapis.delivery.OrderListByCreateTime>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.delivery.OrderListByCreateTime elem0;
								
								elem0 = new vipapis.delivery.OrderListByCreateTime();
								vipapis.delivery.OrderListByCreateTimeHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetOrder_list_by_create_time(value);
					}
					
					
					
					
					
					if ("total".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetTotal(value);
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
		
		
		public void Write(GetOrderListByCreateTimeResponse structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetOrder_list_by_create_time() != null) {
				
				oprot.WriteFieldBegin("order_list_by_create_time");
				
				oprot.WriteListBegin();
				foreach(vipapis.delivery.OrderListByCreateTime _item0 in structs.GetOrder_list_by_create_time()){
					
					
					vipapis.delivery.OrderListByCreateTimeHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTotal() != null) {
				
				oprot.WriteFieldBegin("total");
				oprot.WriteI32((int)structs.GetTotal()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(GetOrderListByCreateTimeResponse bean){
			
			
		}
		
	}
	
}