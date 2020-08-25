using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.price{
	
	
	
	public class SubmitPriceApplicationDetailHelper : TBeanSerializer<SubmitPriceApplicationDetail>
	{
		
		public static SubmitPriceApplicationDetailHelper OBJ = new SubmitPriceApplicationDetailHelper();
		
		public static SubmitPriceApplicationDetailHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(SubmitPriceApplicationDetail structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("barcode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBarcode(value);
					}
					
					
					
					
					
					if ("sale_price".Equals(schemeField.Trim())){
						
						needSkip = false;
						double value;
						value = iprot.ReadDouble();
						
						structs.SetSale_price(value);
					}
					
					
					
					
					
					if ("market_price".Equals(schemeField.Trim())){
						
						needSkip = false;
						double? value;
						value = iprot.ReadDouble();
						
						structs.SetMarket_price(value);
					}
					
					
					
					
					
					if ("gross_margin".Equals(schemeField.Trim())){
						
						needSkip = false;
						double? value;
						value = iprot.ReadDouble();
						
						structs.SetGross_margin(value);
					}
					
					
					
					
					
					if ("bill_tax_price".Equals(schemeField.Trim())){
						
						needSkip = false;
						double? value;
						value = iprot.ReadDouble();
						
						structs.SetBill_tax_price(value);
					}
					
					
					
					
					
					if ("bill_currency".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBill_currency(value);
					}
					
					
					
					
					
					if ("extra_discount_type".Equals(schemeField.Trim())){
						
						needSkip = false;
						byte? value;
						value = iprot.ReadByte(); 
						
						structs.SetExtra_discount_type(value);
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
		
		
		public void Write(SubmitPriceApplicationDetail structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetBarcode() != null) {
				
				oprot.WriteFieldBegin("barcode");
				oprot.WriteString(structs.GetBarcode());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("barcode can not be null!");
			}
			
			
			if(structs.GetSale_price() != null) {
				
				oprot.WriteFieldBegin("sale_price");
				oprot.WriteDouble((double)structs.GetSale_price());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("sale_price can not be null!");
			}
			
			
			if(structs.GetMarket_price() != null) {
				
				oprot.WriteFieldBegin("market_price");
				oprot.WriteDouble((double)structs.GetMarket_price());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetGross_margin() != null) {
				
				oprot.WriteFieldBegin("gross_margin");
				oprot.WriteDouble((double)structs.GetGross_margin());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBill_tax_price() != null) {
				
				oprot.WriteFieldBegin("bill_tax_price");
				oprot.WriteDouble((double)structs.GetBill_tax_price());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBill_currency() != null) {
				
				oprot.WriteFieldBegin("bill_currency");
				oprot.WriteString(structs.GetBill_currency());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetExtra_discount_type() != null) {
				
				oprot.WriteFieldBegin("extra_discount_type");
				oprot.WriteByte((byte)structs.GetExtra_discount_type()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(SubmitPriceApplicationDetail bean){
			
			
		}
		
	}
	
}