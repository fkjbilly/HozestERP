using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.vop.vcloud.jit{
	
	
	
	public class GetDeliveryDetailResponseHelper : TBeanSerializer<GetDeliveryDetailResponse>
	{
		
		public static GetDeliveryDetailResponseHelper OBJ = new GetDeliveryDetailResponseHelper();
		
		public static GetDeliveryDetailResponseHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(GetDeliveryDetailResponse structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("delivery".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.vop.vcloud.jit.Delivery value;
						
						value = new com.vip.vop.vcloud.jit.Delivery();
						com.vip.vop.vcloud.jit.DeliveryHelper.getInstance().Read(value, iprot);
						
						structs.SetDelivery(value);
					}
					
					
					
					
					
					if ("deliveryDetail".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.vop.vcloud.jit.DeliveryDetail> value;
						
						value = new List<com.vip.vop.vcloud.jit.DeliveryDetail>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.vop.vcloud.jit.DeliveryDetail elem2;
								
								elem2 = new com.vip.vop.vcloud.jit.DeliveryDetail();
								com.vip.vop.vcloud.jit.DeliveryDetailHelper.getInstance().Read(elem2, iprot);
								
								value.Add(elem2);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetDeliveryDetail(value);
					}
					
					
					
					
					
					if ("deliveryTrace".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.vop.vcloud.jit.DeliveryTrace> value;
						
						value = new List<com.vip.vop.vcloud.jit.DeliveryTrace>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.vop.vcloud.jit.DeliveryTrace elem4;
								
								elem4 = new com.vip.vop.vcloud.jit.DeliveryTrace();
								com.vip.vop.vcloud.jit.DeliveryTraceHelper.getInstance().Read(elem4, iprot);
								
								value.Add(elem4);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetDeliveryTrace(value);
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
		
		
		public void Write(GetDeliveryDetailResponse structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetDelivery() != null) {
				
				oprot.WriteFieldBegin("delivery");
				
				com.vip.vop.vcloud.jit.DeliveryHelper.getInstance().Write(structs.GetDelivery(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetDeliveryDetail() != null) {
				
				oprot.WriteFieldBegin("deliveryDetail");
				
				oprot.WriteListBegin();
				foreach(com.vip.vop.vcloud.jit.DeliveryDetail _item0 in structs.GetDeliveryDetail()){
					
					
					com.vip.vop.vcloud.jit.DeliveryDetailHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetDeliveryTrace() != null) {
				
				oprot.WriteFieldBegin("deliveryTrace");
				
				oprot.WriteListBegin();
				foreach(com.vip.vop.vcloud.jit.DeliveryTrace _item0 in structs.GetDeliveryTrace()){
					
					
					com.vip.vop.vcloud.jit.DeliveryTraceHelper.getInstance().Write(_item0, oprot);
					
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
		
		
		public void Validate(GetDeliveryDetailResponse bean){
			
			
		}
		
	}
	
}