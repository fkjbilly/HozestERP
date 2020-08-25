using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.delivery{
	
	
	
	public class GetDeliveryGoodsResponseHelper : BeanSerializer<GetDeliveryGoodsResponse>
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
					
					
					if ("delivery_goods_list".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.delivery.DeliveryGoodsList> value;
						
						value = new List<vipapis.delivery.DeliveryGoodsList>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.delivery.DeliveryGoodsList elem0;
								
								elem0 = new vipapis.delivery.DeliveryGoodsList();
								vipapis.delivery.DeliveryGoodsListHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetDelivery_goods_list(value);
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
		
		
		public void Write(GetDeliveryGoodsResponse structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetDelivery_goods_list() != null) {
				
				oprot.WriteFieldBegin("delivery_goods_list");
				
				oprot.WriteListBegin();
				foreach(vipapis.delivery.DeliveryGoodsList _item0 in structs.GetDelivery_goods_list()){
					
					
					vipapis.delivery.DeliveryGoodsListHelper.getInstance().Write(_item0, oprot);
					
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
		
		
		public void Validate(GetDeliveryGoodsResponse bean){
			
			
		}
		
	}
	
}