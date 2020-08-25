using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.price{
	
	
	
	public class UpdatePriceApplicationDetailHelper : TBeanSerializer<UpdatePriceApplicationDetail>
	{
		
		public static UpdatePriceApplicationDetailHelper OBJ = new UpdatePriceApplicationDetailHelper();
		
		public static UpdatePriceApplicationDetailHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(UpdatePriceApplicationDetail structs, Protocol iprot){
			
			
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
					
					
					
					
					
					if ("osn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOsn(value);
					}
					
					
					
					
					
					if ("po_no".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPo_no(value);
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
					
					
					
					
					
					if ("bill_tax_price".Equals(schemeField.Trim())){
						
						needSkip = false;
						double? value;
						value = iprot.ReadDouble();
						
						structs.SetBill_tax_price(value);
					}
					
					
					
					
					
					if ("withdraw".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetWithdraw(value);
					}
					
					
					
					
					
					if ("extra_discount_type".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetExtra_discount_type(value);
					}
					
					
					
					
					
					if ("exception_remark".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetException_remark(value);
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
		
		
		public void Write(UpdatePriceApplicationDetail structs, Protocol oprot){
			
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
			
			
			if(structs.GetOsn() != null) {
				
				oprot.WriteFieldBegin("osn");
				oprot.WriteString(structs.GetOsn());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPo_no() != null) {
				
				oprot.WriteFieldBegin("po_no");
				oprot.WriteString(structs.GetPo_no());
				
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
			
			
			if(structs.GetBill_tax_price() != null) {
				
				oprot.WriteFieldBegin("bill_tax_price");
				oprot.WriteDouble((double)structs.GetBill_tax_price());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetWithdraw() != null) {
				
				oprot.WriteFieldBegin("withdraw");
				oprot.WriteString(structs.GetWithdraw());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetExtra_discount_type() != null) {
				
				oprot.WriteFieldBegin("extra_discount_type");
				oprot.WriteString(structs.GetExtra_discount_type());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetException_remark() != null) {
				
				oprot.WriteFieldBegin("exception_remark");
				oprot.WriteString(structs.GetException_remark());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(UpdatePriceApplicationDetail bean){
			
			
		}
		
	}
	
}