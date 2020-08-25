using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.price{
	
	
	
	public class PriceApplicationDetailHelper : TBeanSerializer<PriceApplicationDetail>
	{
		
		public static PriceApplicationDetailHelper OBJ = new PriceApplicationDetailHelper();
		
		public static PriceApplicationDetailHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(PriceApplicationDetail structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("application_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetApplication_id(value);
					}
					
					
					
					
					
					if ("barcode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBarcode(value);
					}
					
					
					
					
					
					if ("sale_price".Equals(schemeField.Trim())){
						
						needSkip = false;
						double? value;
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
						string value;
						value = iprot.ReadString();
						
						structs.SetExtra_discount_type(value);
					}
					
					
					
					
					
					if ("original_sale_price".Equals(schemeField.Trim())){
						
						needSkip = false;
						double? value;
						value = iprot.ReadDouble();
						
						structs.SetOriginal_sale_price(value);
					}
					
					
					
					
					
					if ("osn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOsn(value);
					}
					
					
					
					
					
					if ("sn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSn(value);
					}
					
					
					
					
					
					if ("withdraw".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetWithdraw(value);
					}
					
					
					
					
					
					if ("remark".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetRemark(value);
					}
					
					
					
					
					
					if ("is_manual".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetIs_manual(value);
					}
					
					
					
					
					
					if ("exception_status".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetException_status(value);
					}
					
					
					
					
					
					if ("exception_description".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetException_description(value);
					}
					
					
					
					
					
					if ("compareResultList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.price.CompareResult> value;
						
						value = new List<vipapis.price.CompareResult>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.price.CompareResult elem1;
								
								elem1 = new vipapis.price.CompareResult();
								vipapis.price.CompareResultHelper.getInstance().Read(elem1, iprot);
								
								value.Add(elem1);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetCompareResultList(value);
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
		
		
		public void Write(PriceApplicationDetail structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetApplication_id() != null) {
				
				oprot.WriteFieldBegin("application_id");
				oprot.WriteString(structs.GetApplication_id());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBarcode() != null) {
				
				oprot.WriteFieldBegin("barcode");
				oprot.WriteString(structs.GetBarcode());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSale_price() != null) {
				
				oprot.WriteFieldBegin("sale_price");
				oprot.WriteDouble((double)structs.GetSale_price());
				
				oprot.WriteFieldEnd();
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
				oprot.WriteString(structs.GetExtra_discount_type());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOriginal_sale_price() != null) {
				
				oprot.WriteFieldBegin("original_sale_price");
				oprot.WriteDouble((double)structs.GetOriginal_sale_price());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOsn() != null) {
				
				oprot.WriteFieldBegin("osn");
				oprot.WriteString(structs.GetOsn());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSn() != null) {
				
				oprot.WriteFieldBegin("sn");
				oprot.WriteString(structs.GetSn());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetWithdraw() != null) {
				
				oprot.WriteFieldBegin("withdraw");
				oprot.WriteString(structs.GetWithdraw());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetRemark() != null) {
				
				oprot.WriteFieldBegin("remark");
				oprot.WriteString(structs.GetRemark());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetIs_manual() != null) {
				
				oprot.WriteFieldBegin("is_manual");
				oprot.WriteString(structs.GetIs_manual());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetException_status() != null) {
				
				oprot.WriteFieldBegin("exception_status");
				oprot.WriteString(structs.GetException_status());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetException_description() != null) {
				
				oprot.WriteFieldBegin("exception_description");
				oprot.WriteString(structs.GetException_description());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCompareResultList() != null) {
				
				oprot.WriteFieldBegin("compareResultList");
				
				oprot.WriteListBegin();
				foreach(vipapis.price.CompareResult _item0 in structs.GetCompareResultList()){
					
					
					vipapis.price.CompareResultHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(PriceApplicationDetail bean){
			
			
		}
		
	}
	
}