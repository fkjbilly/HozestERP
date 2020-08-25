using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.delivery{
	
	
	
	public class PriceInfoHelper : TBeanSerializer<PriceInfo>
	{
		
		public static PriceInfoHelper OBJ = new PriceInfoHelper();
		
		public static PriceInfoHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(PriceInfo structs, Protocol iprot){
			
			
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
					
					
					
					
					
					if ("actual_market_price".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetActual_market_price(value);
					}
					
					
					
					
					
					if ("actual_unit_price".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetActual_unit_price(value);
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
		
		
		public void Write(PriceInfo structs, Protocol oprot){
			
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
			
			
			if(structs.GetActual_market_price() != null) {
				
				oprot.WriteFieldBegin("actual_market_price");
				oprot.WriteString(structs.GetActual_market_price());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetActual_unit_price() != null) {
				
				oprot.WriteFieldBegin("actual_unit_price");
				oprot.WriteString(structs.GetActual_unit_price());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("actual_unit_price can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(PriceInfo bean){
			
			
		}
		
	}
	
}