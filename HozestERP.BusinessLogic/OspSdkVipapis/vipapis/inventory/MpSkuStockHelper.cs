using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.inventory{
	
	
	
	public class MpSkuStockHelper : TBeanSerializer<MpSkuStock>
	{
		
		public static MpSkuStockHelper OBJ = new MpSkuStockHelper();
		
		public static MpSkuStockHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(MpSkuStock structs, Protocol iprot){
			
			
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
					
					
					
					
					
					if ("leaving_stock".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetLeaving_stock(value);
					}
					
					
					
					
					
					if ("cart_hold".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetCart_hold(value);
					}
					
					
					
					
					
					if ("order_hold".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetOrder_hold(value);
					}
					
					
					
					
					
					if ("warehouse".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetWarehouse(value);
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
		
		
		public void Write(MpSkuStock structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetSku_id() != null) {
				
				oprot.WriteFieldBegin("sku_id");
				oprot.WriteString(structs.GetSku_id());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetLeaving_stock() != null) {
				
				oprot.WriteFieldBegin("leaving_stock");
				oprot.WriteI32((int)structs.GetLeaving_stock()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("leaving_stock can not be null!");
			}
			
			
			if(structs.GetCart_hold() != null) {
				
				oprot.WriteFieldBegin("cart_hold");
				oprot.WriteI32((int)structs.GetCart_hold()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("cart_hold can not be null!");
			}
			
			
			if(structs.GetOrder_hold() != null) {
				
				oprot.WriteFieldBegin("order_hold");
				oprot.WriteI32((int)structs.GetOrder_hold()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("order_hold can not be null!");
			}
			
			
			if(structs.GetWarehouse() != null) {
				
				oprot.WriteFieldBegin("warehouse");
				oprot.WriteString(structs.GetWarehouse());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(MpSkuStock bean){
			
			
		}
		
	}
	
}