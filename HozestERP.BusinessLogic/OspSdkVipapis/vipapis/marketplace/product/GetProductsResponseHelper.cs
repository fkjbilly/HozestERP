using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.marketplace.product{
	
	
	
	public class GetProductsResponseHelper : TBeanSerializer<GetProductsResponse>
	{
		
		public static GetProductsResponseHelper OBJ = new GetProductsResponseHelper();
		
		public static GetProductsResponseHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(GetProductsResponse structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("products".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.marketplace.product.Product> value;
						
						value = new List<vipapis.marketplace.product.Product>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.marketplace.product.Product elem1;
								
								elem1 = new vipapis.marketplace.product.Product();
								vipapis.marketplace.product.ProductHelper.getInstance().Read(elem1, iprot);
								
								value.Add(elem1);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetProducts(value);
					}
					
					
					
					
					
					if ("has_next".Equals(schemeField.Trim())){
						
						needSkip = false;
						bool? value;
						value = iprot.ReadBool();
						
						structs.SetHas_next(value);
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
		
		
		public void Write(GetProductsResponse structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetProducts() != null) {
				
				oprot.WriteFieldBegin("products");
				
				oprot.WriteListBegin();
				foreach(vipapis.marketplace.product.Product _item0 in structs.GetProducts()){
					
					
					vipapis.marketplace.product.ProductHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetHas_next() != null) {
				
				oprot.WriteFieldBegin("has_next");
				oprot.WriteBool((bool)structs.GetHas_next());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(GetProductsResponse bean){
			
			
		}
		
	}
	
}