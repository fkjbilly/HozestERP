using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.delivery{
	
	
	
	public class OrderReturnDetailResponseHelper : TBeanSerializer<OrderReturnDetailResponse>
	{
		
		public static OrderReturnDetailResponseHelper OBJ = new OrderReturnDetailResponseHelper();
		
		public static OrderReturnDetailResponseHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(OrderReturnDetailResponse structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("order_return_detail_list".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.delivery.Return> value;
						
						value = new List<vipapis.delivery.Return>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.delivery.Return elem0;
								
								elem0 = new vipapis.delivery.Return();
								vipapis.delivery.ReturnHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetOrder_return_detail_list(value);
					}
					
					
					
					
					
					if ("total".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
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
		
		
		public void Write(OrderReturnDetailResponse structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetOrder_return_detail_list() != null) {
				
				oprot.WriteFieldBegin("order_return_detail_list");
				
				oprot.WriteListBegin();
				foreach(vipapis.delivery.Return _item0 in structs.GetOrder_return_detail_list()){
					
					
					vipapis.delivery.ReturnHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTotal() != null) {
				
				oprot.WriteFieldBegin("total");
				oprot.WriteI32((int)structs.GetTotal()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("total can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(OrderReturnDetailResponse bean){
			
			
		}
		
	}
	
}