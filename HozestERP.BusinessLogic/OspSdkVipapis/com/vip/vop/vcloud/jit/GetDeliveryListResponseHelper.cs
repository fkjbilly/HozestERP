using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.vop.vcloud.jit{
	
	
	
	public class GetDeliveryListResponseHelper : TBeanSerializer<GetDeliveryListResponse>
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
					
					
					if ("deliveryList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.vop.vcloud.jit.Delivery> value;
						
						value = new List<com.vip.vop.vcloud.jit.Delivery>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.vop.vcloud.jit.Delivery elem1;
								
								elem1 = new com.vip.vop.vcloud.jit.Delivery();
								com.vip.vop.vcloud.jit.DeliveryHelper.getInstance().Read(elem1, iprot);
								
								value.Add(elem1);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetDeliveryList(value);
					}
					
					
					
					
					
					if ("pagination".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.vop.vcloud.common.api.Pagination value;
						
						value = new com.vip.vop.vcloud.common.api.Pagination();
						com.vip.vop.vcloud.common.api.PaginationHelper.getInstance().Read(value, iprot);
						
						structs.SetPagination(value);
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
			
			if(structs.GetDeliveryList() != null) {
				
				oprot.WriteFieldBegin("deliveryList");
				
				oprot.WriteListBegin();
				foreach(com.vip.vop.vcloud.jit.Delivery _item0 in structs.GetDeliveryList()){
					
					
					com.vip.vop.vcloud.jit.DeliveryHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPagination() != null) {
				
				oprot.WriteFieldBegin("pagination");
				
				com.vip.vop.vcloud.common.api.PaginationHelper.getInstance().Write(structs.GetPagination(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(GetDeliveryListResponse bean){
			
			
		}
		
	}
	
}