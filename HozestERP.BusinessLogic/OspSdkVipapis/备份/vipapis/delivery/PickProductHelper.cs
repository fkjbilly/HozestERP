using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.delivery{
	
	
	
	public class PickProductHelper : BeanSerializer<PickProduct>
	{
		
		public static PickProductHelper OBJ = new PickProductHelper();
		
		public static PickProductHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(PickProduct structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("stock".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetStock(value);
					}
					
					
					
					
					
					if ("barcode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBarcode(value);
					}
					
					
					
					
					
					if ("art_no".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetArt_no(value);
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
					
					
					
					
					
					if ("actual_unit_price".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetActual_unit_price(value);
					}
					
					
					
					
					
					if ("actual_market_price".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetActual_market_price(value);
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
		
		
		public void Write(PickProduct structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetStock() != null) {
				
				oprot.WriteFieldBegin("stock");
				oprot.WriteI32((int)structs.GetStock()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBarcode() != null) {
				
				oprot.WriteFieldBegin("barcode");
				oprot.WriteString(structs.GetBarcode());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetArt_no() != null) {
				
				oprot.WriteFieldBegin("art_no");
				oprot.WriteString(structs.GetArt_no());
				
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
			
			
			if(structs.GetActual_unit_price() != null) {
				
				oprot.WriteFieldBegin("actual_unit_price");
				oprot.WriteString(structs.GetActual_unit_price());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetActual_market_price() != null) {
				
				oprot.WriteFieldBegin("actual_market_price");
				oprot.WriteString(structs.GetActual_market_price());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(PickProduct bean){
			
			
		}
		
	}
	
}