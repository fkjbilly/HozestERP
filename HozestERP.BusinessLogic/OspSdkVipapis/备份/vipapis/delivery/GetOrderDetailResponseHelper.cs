using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.delivery{
	
	
	
	public class GetOrderDetailResponseHelper : BeanSerializer<GetOrderDetailResponse>
	{
		
		public static GetOrderDetailResponseHelper OBJ = new GetOrderDetailResponseHelper();
		
		public static GetOrderDetailResponseHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(GetOrderDetailResponse structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("orderDetails".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.delivery.DvdOrderDetail> value;
						
						value = new List<vipapis.delivery.DvdOrderDetail>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.delivery.DvdOrderDetail elem0;
								
								elem0 = new vipapis.delivery.DvdOrderDetail();
								vipapis.delivery.DvdOrderDetailHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetOrderDetails(value);
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
		
		
		public void Write(GetOrderDetailResponse structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetOrderDetails() != null) {
				
				oprot.WriteFieldBegin("orderDetails");
				
				oprot.WriteListBegin();
				foreach(vipapis.delivery.DvdOrderDetail _item0 in structs.GetOrderDetails()){
					
					
					vipapis.delivery.DvdOrderDetailHelper.getInstance().Write(_item0, oprot);
					
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
		
		
		public void Validate(GetOrderDetailResponse bean){
			
			
		}
		
	}
	
}