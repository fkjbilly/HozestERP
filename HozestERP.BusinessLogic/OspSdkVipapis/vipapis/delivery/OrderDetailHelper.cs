using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.delivery{
	
	
	
	public class OrderDetailHelper : TBeanSerializer<OrderDetail>
	{
		
		public static OrderDetailHelper OBJ = new OrderDetailHelper();
		
		public static OrderDetailHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(OrderDetail structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("order_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOrder_id(value);
					}
					
					
					
					
					
					if ("barcode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBarcode(value);
					}
					
					
					
					
					
					if ("amount".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetAmount(value);
					}
					
					
					
					
					
					if ("price".Equals(schemeField.Trim())){
						
						needSkip = false;
						double? value;
						value = iprot.ReadDouble();
						
						structs.SetPrice(value);
					}
					
					
					
					
					
					if ("brand_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBrand_id(value);
					}
					
					
					
					
					
					if ("promotions".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.delivery.PromotionInfo> value;
						
						value = new List<vipapis.delivery.PromotionInfo>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.delivery.PromotionInfo elem1;
								
								elem1 = new vipapis.delivery.PromotionInfo();
								vipapis.delivery.PromotionInfoHelper.getInstance().Read(elem1, iprot);
								
								value.Add(elem1);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetPromotions(value);
					}
					
					
					
					
					
					if ("failed_promotions".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.delivery.FailedPromotionInfo> value;
						
						value = new List<vipapis.delivery.FailedPromotionInfo>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.delivery.FailedPromotionInfo elem3;
								
								elem3 = new vipapis.delivery.FailedPromotionInfo();
								vipapis.delivery.FailedPromotionInfoHelper.getInstance().Read(elem3, iprot);
								
								value.Add(elem3);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetFailed_promotions(value);
					}
					
					
					
					
					
					if ("date".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetDate(value);
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
		
		
		public void Write(OrderDetail structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetOrder_id() != null) {
				
				oprot.WriteFieldBegin("order_id");
				oprot.WriteString(structs.GetOrder_id());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBarcode() != null) {
				
				oprot.WriteFieldBegin("barcode");
				oprot.WriteString(structs.GetBarcode());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetAmount() != null) {
				
				oprot.WriteFieldBegin("amount");
				oprot.WriteI32((int)structs.GetAmount()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPrice() != null) {
				
				oprot.WriteFieldBegin("price");
				oprot.WriteDouble((double)structs.GetPrice());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBrand_id() != null) {
				
				oprot.WriteFieldBegin("brand_id");
				oprot.WriteString(structs.GetBrand_id());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPromotions() != null) {
				
				oprot.WriteFieldBegin("promotions");
				
				oprot.WriteListBegin();
				foreach(vipapis.delivery.PromotionInfo _item0 in structs.GetPromotions()){
					
					
					vipapis.delivery.PromotionInfoHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetFailed_promotions() != null) {
				
				oprot.WriteFieldBegin("failed_promotions");
				
				oprot.WriteListBegin();
				foreach(vipapis.delivery.FailedPromotionInfo _item0 in structs.GetFailed_promotions()){
					
					
					vipapis.delivery.FailedPromotionInfoHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetDate() != null) {
				
				oprot.WriteFieldBegin("date");
				oprot.WriteString(structs.GetDate());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(OrderDetail bean){
			
			
		}
		
	}
	
}