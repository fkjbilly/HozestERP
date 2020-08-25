using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.puma{
	
	
	
	public class ProductHelper : TBeanSerializer<Product>
	{
		
		public static ProductHelper OBJ = new ProductHelper();
		
		public static ProductHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(Product structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("stock".Equals(schemeField.Trim())){
						
						needSkip = false;
						vipapis.puma.Stock value;
						
						value = new vipapis.puma.Stock();
						vipapis.puma.StockHelper.getInstance().Read(value, iprot);
						
						structs.SetStock(value);
					}
					
					
					
					
					
					if ("cps".Equals(schemeField.Trim())){
						
						needSkip = false;
						vipapis.puma.Cps value;
						
						value = new vipapis.puma.Cps();
						vipapis.puma.CpsHelper.getInstance().Read(value, iprot);
						
						structs.SetCps(value);
					}
					
					
					
					
					
					if ("price".Equals(schemeField.Trim())){
						
						needSkip = false;
						vipapis.puma.Price value;
						
						value = new vipapis.puma.Price();
						vipapis.puma.PriceHelper.getInstance().Read(value, iprot);
						
						structs.SetPrice(value);
					}
					
					
					
					
					
					if ("merchandise".Equals(schemeField.Trim())){
						
						needSkip = false;
						vipapis.puma.Merchandise value;
						
						value = new vipapis.puma.Merchandise();
						vipapis.puma.MerchandiseHelper.getInstance().Read(value, iprot);
						
						structs.SetMerchandise(value);
					}
					
					
					
					
					
					if ("vendor_product".Equals(schemeField.Trim())){
						
						needSkip = false;
						vipapis.puma.VendorProduct value;
						
						value = new vipapis.puma.VendorProduct();
						vipapis.puma.VendorProductHelper.getInstance().Read(value, iprot);
						
						structs.SetVendor_product(value);
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
		
		
		public void Write(Product structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetStock() != null) {
				
				oprot.WriteFieldBegin("stock");
				
				vipapis.puma.StockHelper.getInstance().Write(structs.GetStock(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCps() != null) {
				
				oprot.WriteFieldBegin("cps");
				
				vipapis.puma.CpsHelper.getInstance().Write(structs.GetCps(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPrice() != null) {
				
				oprot.WriteFieldBegin("price");
				
				vipapis.puma.PriceHelper.getInstance().Write(structs.GetPrice(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetMerchandise() != null) {
				
				oprot.WriteFieldBegin("merchandise");
				
				vipapis.puma.MerchandiseHelper.getInstance().Write(structs.GetMerchandise(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetVendor_product() != null) {
				
				oprot.WriteFieldBegin("vendor_product");
				
				vipapis.puma.VendorProductHelper.getInstance().Write(structs.GetVendor_product(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(Product bean){
			
			
		}
		
	}
	
}