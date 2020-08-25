using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.stock{
	
	
	
	public class OxoOrderGoodsJitListHelper : TBeanSerializer<OxoOrderGoodsJitList>
	{
		
		public static OxoOrderGoodsJitListHelper OBJ = new OxoOrderGoodsJitListHelper();
		
		public static OxoOrderGoodsJitListHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(OxoOrderGoodsJitList structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("vendor_warehouse_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetVendor_warehouse_id(value);
					}
					
					
					
					
					
					if ("barcode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBarcode(value);
					}
					
					
					
					
					
					if ("product_name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetProduct_name(value);
					}
					
					
					
					
					
					if ("size".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSize(value);
					}
					
					
					
					
					
					if ("market_price".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetMarket_price(value);
					}
					
					
					
					
					
					if ("num".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetNum(value);
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
		
		
		public void Write(OxoOrderGoodsJitList structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetVendor_warehouse_id() != null) {
				
				oprot.WriteFieldBegin("vendor_warehouse_id");
				oprot.WriteString(structs.GetVendor_warehouse_id());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBarcode() != null) {
				
				oprot.WriteFieldBegin("barcode");
				oprot.WriteString(structs.GetBarcode());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetProduct_name() != null) {
				
				oprot.WriteFieldBegin("product_name");
				oprot.WriteString(structs.GetProduct_name());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSize() != null) {
				
				oprot.WriteFieldBegin("size");
				oprot.WriteString(structs.GetSize());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetMarket_price() != null) {
				
				oprot.WriteFieldBegin("market_price");
				oprot.WriteString(structs.GetMarket_price());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetNum() != null) {
				
				oprot.WriteFieldBegin("num");
				oprot.WriteString(structs.GetNum());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(OxoOrderGoodsJitList bean){
			
			
		}
		
	}
	
}