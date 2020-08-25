using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.vop.vcloud.jit{
	
	
	
	public class GetDeliveryGoodsResponseHelper : TBeanSerializer<GetDeliveryGoodsResponse>
	{
		
		public static GetDeliveryGoodsResponseHelper OBJ = new GetDeliveryGoodsResponseHelper();
		
		public static GetDeliveryGoodsResponseHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(GetDeliveryGoodsResponse structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("deliveryGoodsList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.vop.vcloud.jit.DeliveryDetail> value;
						
						value = new List<com.vip.vop.vcloud.jit.DeliveryDetail>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.vop.vcloud.jit.DeliveryDetail elem0;
								
								elem0 = new com.vip.vop.vcloud.jit.DeliveryDetail();
								com.vip.vop.vcloud.jit.DeliveryDetailHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetDeliveryGoodsList(value);
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
		
		
		public void Write(GetDeliveryGoodsResponse structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetDeliveryGoodsList() != null) {
				
				oprot.WriteFieldBegin("deliveryGoodsList");
				
				oprot.WriteListBegin();
				foreach(com.vip.vop.vcloud.jit.DeliveryDetail _item0 in structs.GetDeliveryGoodsList()){
					
					
					com.vip.vop.vcloud.jit.DeliveryDetailHelper.getInstance().Write(_item0, oprot);
					
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
		
		
		public void Validate(GetDeliveryGoodsResponse bean){
			
			
		}
		
	}
	
}