using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.delivery{
	
	
	
	public class GetOrderListResponseHelper : TBeanSerializer<GetOrderListResponse>
	{
		
		public static GetOrderListResponseHelper OBJ = new GetOrderListResponseHelper();
		
		public static GetOrderListResponseHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(GetOrderListResponse structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("dvd_order_list".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.delivery.DvdOrder> value;
						
						value = new List<vipapis.delivery.DvdOrder>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.delivery.DvdOrder elem0;
								
								elem0 = new vipapis.delivery.DvdOrder();
								vipapis.delivery.DvdOrderHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetDvd_order_list(value);
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
		
		
		public void Write(GetOrderListResponse structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetDvd_order_list() != null) {
				
				oprot.WriteFieldBegin("dvd_order_list");
				
				oprot.WriteListBegin();
				foreach(vipapis.delivery.DvdOrder _item0 in structs.GetDvd_order_list()){
					
					
					vipapis.delivery.DvdOrderHelper.getInstance().Write(_item0, oprot);
					
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
		
		
		public void Validate(GetOrderListResponse bean){
			
			
		}
		
	}
	
}