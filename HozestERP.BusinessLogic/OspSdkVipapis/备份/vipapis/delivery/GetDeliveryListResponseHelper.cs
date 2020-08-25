using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.delivery{
	
	
	
	public class GetDeliveryListResponseHelper : BeanSerializer<GetDeliveryListResponse>
	{
		
		public static GetDeliveryListResponseHelper OBJ = new GetDeliveryListResponseHelper();
		
		public static GetDeliveryListResponseHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(GetDeliveryListResponse structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("delivery_list".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.delivery.DeliveryList> value;
						
						value = new List<vipapis.delivery.DeliveryList>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.delivery.DeliveryList elem0;
								
								elem0 = new vipapis.delivery.DeliveryList();
								vipapis.delivery.DeliveryListHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetDelivery_list(value);
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
		
		
		public void Write(GetDeliveryListResponse structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetDelivery_list() != null) {
				
				oprot.WriteFieldBegin("delivery_list");
				
				oprot.WriteListBegin();
				foreach(vipapis.delivery.DeliveryList _item0 in structs.GetDelivery_list()){
					
					
					vipapis.delivery.DeliveryListHelper.getInstance().Write(_item0, oprot);
					
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
		
		
		public void Validate(GetDeliveryListResponse bean){
			
			
		}
		
	}
	
}