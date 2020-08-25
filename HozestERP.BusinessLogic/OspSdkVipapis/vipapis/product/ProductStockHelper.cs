using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.product{
	
	
	
	public class ProductStockHelper : TBeanSerializer<ProductStock>
	{
		
		public static ProductStockHelper OBJ = new ProductStockHelper();
		
		public static ProductStockHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(ProductStock structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("product_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetProduct_id(value);
					}
					
					
					
					
					
					if ("product_name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetProduct_name(value);
					}
					
					
					
					
					
					if ("sell_price".Equals(schemeField.Trim())){
						
						needSkip = false;
						double value;
						value = iprot.ReadDouble();
						
						structs.SetSell_price(value);
					}
					
					
					
					
					
					if ("hasStock".Equals(schemeField.Trim())){
						
						needSkip = false;
						bool value;
						value = iprot.ReadBool();
						
						structs.SetHasStock(value);
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
		
		
		public void Write(ProductStock structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetProduct_id() != null) {
				
				oprot.WriteFieldBegin("product_id");
				oprot.WriteI32((int)structs.GetProduct_id()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("product_id can not be null!");
			}
			
			
			if(structs.GetProduct_name() != null) {
				
				oprot.WriteFieldBegin("product_name");
				oprot.WriteString(structs.GetProduct_name());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("product_name can not be null!");
			}
			
			
			if(structs.GetSell_price() != null) {
				
				oprot.WriteFieldBegin("sell_price");
				oprot.WriteDouble((double)structs.GetSell_price());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("sell_price can not be null!");
			}
			
			
			if(structs.GetHasStock() != null) {
				
				oprot.WriteFieldBegin("hasStock");
				oprot.WriteBool((bool)structs.GetHasStock());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("hasStock can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(ProductStock bean){
			
			
		}
		
	}
	
}