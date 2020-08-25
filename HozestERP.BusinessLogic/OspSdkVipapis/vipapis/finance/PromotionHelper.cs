using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.finance{
	
	
	
	public class PromotionHelper : TBeanSerializer<Promotion>
	{
		
		public static PromotionHelper OBJ = new PromotionHelper();
		
		public static PromotionHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(Promotion structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("promotion_type".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPromotion_type(value);
					}
					
					
					
					
					
					if ("promotion_name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPromotion_name(value);
					}
					
					
					
					
					
					if ("promotion_description".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPromotion_description(value);
					}
					
					
					
					
					
					if ("vendor_ratio".Equals(schemeField.Trim())){
						
						needSkip = false;
						double? value;
						value = iprot.ReadDouble();
						
						structs.SetVendor_ratio(value);
					}
					
					
					
					
					
					if ("discount_total_amount".Equals(schemeField.Trim())){
						
						needSkip = false;
						double? value;
						value = iprot.ReadDouble();
						
						structs.SetDiscount_total_amount(value);
					}
					
					
					
					
					
					if ("discount_vendor_amount".Equals(schemeField.Trim())){
						
						needSkip = false;
						double? value;
						value = iprot.ReadDouble();
						
						structs.SetDiscount_vendor_amount(value);
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
		
		
		public void Write(Promotion structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetPromotion_type() != null) {
				
				oprot.WriteFieldBegin("promotion_type");
				oprot.WriteString(structs.GetPromotion_type());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPromotion_name() != null) {
				
				oprot.WriteFieldBegin("promotion_name");
				oprot.WriteString(structs.GetPromotion_name());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPromotion_description() != null) {
				
				oprot.WriteFieldBegin("promotion_description");
				oprot.WriteString(structs.GetPromotion_description());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetVendor_ratio() != null) {
				
				oprot.WriteFieldBegin("vendor_ratio");
				oprot.WriteDouble((double)structs.GetVendor_ratio());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetDiscount_total_amount() != null) {
				
				oprot.WriteFieldBegin("discount_total_amount");
				oprot.WriteDouble((double)structs.GetDiscount_total_amount());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetDiscount_vendor_amount() != null) {
				
				oprot.WriteFieldBegin("discount_vendor_amount");
				oprot.WriteDouble((double)structs.GetDiscount_vendor_amount());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(Promotion bean){
			
			
		}
		
	}
	
}