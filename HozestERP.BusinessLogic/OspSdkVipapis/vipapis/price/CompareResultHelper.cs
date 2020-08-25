using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.price{
	
	
	
	public class CompareResultHelper : TBeanSerializer<CompareResult>
	{
		
		public static CompareResultHelper OBJ = new CompareResultHelper();
		
		public static CompareResultHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(CompareResult structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("ext_market_price".Equals(schemeField.Trim())){
						
						needSkip = false;
						double? value;
						value = iprot.ReadDouble();
						
						structs.SetExt_market_price(value);
					}
					
					
					
					
					
					if ("ext_sale_price".Equals(schemeField.Trim())){
						
						needSkip = false;
						double? value;
						value = iprot.ReadDouble();
						
						structs.SetExt_sale_price(value);
					}
					
					
					
					
					
					if ("vip_discount_price".Equals(schemeField.Trim())){
						
						needSkip = false;
						double? value;
						value = iprot.ReadDouble();
						
						structs.SetVip_discount_price(value);
					}
					
					
					
					
					
					if ("c_discount_price".Equals(schemeField.Trim())){
						
						needSkip = false;
						double? value;
						value = iprot.ReadDouble();
						
						structs.SetC_discount_price(value);
					}
					
					
					
					
					
					if ("c_url".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetC_url(value);
					}
					
					
					
					
					
					if ("c_product_name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetC_product_name(value);
					}
					
					
					
					
					
					if ("c_mall_name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetC_mall_name(value);
					}
					
					
					
					
					
					if ("c_store_name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetC_store_name(value);
					}
					
					
					
					
					
					if ("vip_lowest_price".Equals(schemeField.Trim())){
						
						needSkip = false;
						double? value;
						value = iprot.ReadDouble();
						
						structs.SetVip_lowest_price(value);
					}
					
					
					
					
					
					if ("same_style_price".Equals(schemeField.Trim())){
						
						needSkip = false;
						double? value;
						value = iprot.ReadDouble();
						
						structs.SetSame_style_price(value);
					}
					
					
					
					
					
					if ("pre_market_price".Equals(schemeField.Trim())){
						
						needSkip = false;
						double? value;
						value = iprot.ReadDouble();
						
						structs.SetPre_market_price(value);
					}
					
					
					
					
					
					if ("pre_sale_price".Equals(schemeField.Trim())){
						
						needSkip = false;
						double? value;
						value = iprot.ReadDouble();
						
						structs.SetPre_sale_price(value);
					}
					
					
					
					
					
					if ("pre_bill_price".Equals(schemeField.Trim())){
						
						needSkip = false;
						double? value;
						value = iprot.ReadDouble();
						
						structs.SetPre_bill_price(value);
					}
					
					
					
					
					
					if ("pre_brand_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPre_brand_id(value);
					}
					
					
					
					
					
					if ("pre_schedule_name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPre_schedule_name(value);
					}
					
					
					
					
					
					if ("pre_schedule_start_time".Equals(schemeField.Trim())){
						
						needSkip = false;
						System.DateTime? value;
						value = Osp.Sdk.Util.TimeUtil.FromUnixTime(iprot.ReadI64()); 
						
						structs.SetPre_schedule_start_time(value);
					}
					
					
					
					
					
					if ("pre_schedule_end_time".Equals(schemeField.Trim())){
						
						needSkip = false;
						System.DateTime? value;
						value = Osp.Sdk.Util.TimeUtil.FromUnixTime(iprot.ReadI64()); 
						
						structs.SetPre_schedule_end_time(value);
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
		
		
		public void Write(CompareResult structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetExt_market_price() != null) {
				
				oprot.WriteFieldBegin("ext_market_price");
				oprot.WriteDouble((double)structs.GetExt_market_price());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetExt_sale_price() != null) {
				
				oprot.WriteFieldBegin("ext_sale_price");
				oprot.WriteDouble((double)structs.GetExt_sale_price());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetVip_discount_price() != null) {
				
				oprot.WriteFieldBegin("vip_discount_price");
				oprot.WriteDouble((double)structs.GetVip_discount_price());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetC_discount_price() != null) {
				
				oprot.WriteFieldBegin("c_discount_price");
				oprot.WriteDouble((double)structs.GetC_discount_price());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetC_url() != null) {
				
				oprot.WriteFieldBegin("c_url");
				oprot.WriteString(structs.GetC_url());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetC_product_name() != null) {
				
				oprot.WriteFieldBegin("c_product_name");
				oprot.WriteString(structs.GetC_product_name());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetC_mall_name() != null) {
				
				oprot.WriteFieldBegin("c_mall_name");
				oprot.WriteString(structs.GetC_mall_name());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetC_store_name() != null) {
				
				oprot.WriteFieldBegin("c_store_name");
				oprot.WriteString(structs.GetC_store_name());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetVip_lowest_price() != null) {
				
				oprot.WriteFieldBegin("vip_lowest_price");
				oprot.WriteDouble((double)structs.GetVip_lowest_price());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSame_style_price() != null) {
				
				oprot.WriteFieldBegin("same_style_price");
				oprot.WriteDouble((double)structs.GetSame_style_price());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPre_market_price() != null) {
				
				oprot.WriteFieldBegin("pre_market_price");
				oprot.WriteDouble((double)structs.GetPre_market_price());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPre_sale_price() != null) {
				
				oprot.WriteFieldBegin("pre_sale_price");
				oprot.WriteDouble((double)structs.GetPre_sale_price());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPre_bill_price() != null) {
				
				oprot.WriteFieldBegin("pre_bill_price");
				oprot.WriteDouble((double)structs.GetPre_bill_price());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPre_brand_id() != null) {
				
				oprot.WriteFieldBegin("pre_brand_id");
				oprot.WriteString(structs.GetPre_brand_id());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPre_schedule_name() != null) {
				
				oprot.WriteFieldBegin("pre_schedule_name");
				oprot.WriteString(structs.GetPre_schedule_name());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPre_schedule_start_time() != null) {
				
				oprot.WriteFieldBegin("pre_schedule_start_time");
				oprot.WriteI64(Osp.Sdk.Util.TimeUtil.ToUnixTime((System.DateTime)structs.GetPre_schedule_start_time())); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPre_schedule_end_time() != null) {
				
				oprot.WriteFieldBegin("pre_schedule_end_time");
				oprot.WriteI64(Osp.Sdk.Util.TimeUtil.ToUnixTime((System.DateTime)structs.GetPre_schedule_end_time())); 
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(CompareResult bean){
			
			
		}
		
	}
	
}