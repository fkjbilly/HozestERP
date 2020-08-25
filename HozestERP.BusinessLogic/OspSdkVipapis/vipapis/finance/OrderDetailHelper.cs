using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.finance{
	
	
	
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
					
					
					
					
					
					if ("brand_name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBrand_name(value);
					}
					
					
					
					
					
					if ("product_name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetProduct_name(value);
					}
					
					
					
					
					
					if ("sales_or_schedule_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSales_or_schedule_id(value);
					}
					
					
					
					
					
					if ("date".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetDate(value);
					}
					
					
					
					
					
					if ("promotions".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.finance.Promotion> value;
						
						value = new List<vipapis.finance.Promotion>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.finance.Promotion elem0;
								
								elem0 = new vipapis.finance.Promotion();
								vipapis.finance.PromotionHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetPromotions(value);
					}
					
					
					
					
					
					if ("errors".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.finance.Error> value;
						
						value = new List<vipapis.finance.Error>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.finance.Error elem2;
								
								elem2 = new vipapis.finance.Error();
								vipapis.finance.ErrorHelper.getInstance().Read(elem2, iprot);
								
								value.Add(elem2);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetErrors(value);
					}
					
					
					
					
					
					if ("carriage".Equals(schemeField.Trim())){
						
						needSkip = false;
						double? value;
						value = iprot.ReadDouble();
						
						structs.SetCarriage(value);
					}
					
					
					
					
					
					if ("expay_sub_total".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetExpay_sub_total(value);
					}
					
					
					
					
					
					if ("exact_sub_total".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetExact_sub_total(value);
					}
					
					
					
					
					
					if ("excoupon_sub_total".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetExcoupon_sub_total(value);
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
			
			
			if(structs.GetBrand_name() != null) {
				
				oprot.WriteFieldBegin("brand_name");
				oprot.WriteString(structs.GetBrand_name());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetProduct_name() != null) {
				
				oprot.WriteFieldBegin("product_name");
				oprot.WriteString(structs.GetProduct_name());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSales_or_schedule_id() != null) {
				
				oprot.WriteFieldBegin("sales_or_schedule_id");
				oprot.WriteString(structs.GetSales_or_schedule_id());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetDate() != null) {
				
				oprot.WriteFieldBegin("date");
				oprot.WriteString(structs.GetDate());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPromotions() != null) {
				
				oprot.WriteFieldBegin("promotions");
				
				oprot.WriteListBegin();
				foreach(vipapis.finance.Promotion _item0 in structs.GetPromotions()){
					
					
					vipapis.finance.PromotionHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetErrors() != null) {
				
				oprot.WriteFieldBegin("errors");
				
				oprot.WriteListBegin();
				foreach(vipapis.finance.Error _item0 in structs.GetErrors()){
					
					
					vipapis.finance.ErrorHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCarriage() != null) {
				
				oprot.WriteFieldBegin("carriage");
				oprot.WriteDouble((double)structs.GetCarriage());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetExpay_sub_total() != null) {
				
				oprot.WriteFieldBegin("expay_sub_total");
				oprot.WriteString(structs.GetExpay_sub_total());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetExact_sub_total() != null) {
				
				oprot.WriteFieldBegin("exact_sub_total");
				oprot.WriteString(structs.GetExact_sub_total());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetExcoupon_sub_total() != null) {
				
				oprot.WriteFieldBegin("excoupon_sub_total");
				oprot.WriteString(structs.GetExcoupon_sub_total());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(OrderDetail bean){
			
			
		}
		
	}
	
}