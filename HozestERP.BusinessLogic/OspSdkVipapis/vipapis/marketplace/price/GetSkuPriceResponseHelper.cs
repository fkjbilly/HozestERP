using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.marketplace.price{
	
	
	
	public class GetSkuPriceResponseHelper : TBeanSerializer<GetSkuPriceResponse>
	{
		
		public static GetSkuPriceResponseHelper OBJ = new GetSkuPriceResponseHelper();
		
		public static GetSkuPriceResponseHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(GetSkuPriceResponse structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("sku_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSku_id(value);
					}
					
					
					
					
					
					if ("market_price".Equals(schemeField.Trim())){
						
						needSkip = false;
						double value;
						value = iprot.ReadDouble();
						
						structs.SetMarket_price(value);
					}
					
					
					
					
					
					if ("sale_price".Equals(schemeField.Trim())){
						
						needSkip = false;
						double value;
						value = iprot.ReadDouble();
						
						structs.SetSale_price(value);
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
		
		
		public void Write(GetSkuPriceResponse structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetSku_id() != null) {
				
				oprot.WriteFieldBegin("sku_id");
				oprot.WriteString(structs.GetSku_id());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("sku_id can not be null!");
			}
			
			
			if(structs.GetMarket_price() != null) {
				
				oprot.WriteFieldBegin("market_price");
				oprot.WriteDouble((double)structs.GetMarket_price());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("market_price can not be null!");
			}
			
			
			if(structs.GetSale_price() != null) {
				
				oprot.WriteFieldBegin("sale_price");
				oprot.WriteDouble((double)structs.GetSale_price());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("sale_price can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(GetSkuPriceResponse bean){
			
			
		}
		
	}
	
}