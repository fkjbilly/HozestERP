using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.product{
	
	
	
	public class MultiGetProductSkuResponseHelper : TBeanSerializer<MultiGetProductSkuResponse>
	{
		
		public static MultiGetProductSkuResponseHelper OBJ = new MultiGetProductSkuResponseHelper();
		
		public static MultiGetProductSkuResponseHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(MultiGetProductSkuResponse structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("products".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.product.ProductSkuInfo> value;
						
						value = new List<vipapis.product.ProductSkuInfo>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.product.ProductSkuInfo elem0;
								
								elem0 = new vipapis.product.ProductSkuInfo();
								vipapis.product.ProductSkuInfoHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetProducts(value);
					}
					
					
					
					
					
					if ("total".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetTotal(value);
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
		
		
		public void Write(MultiGetProductSkuResponse structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetProducts() != null) {
				
				oprot.WriteFieldBegin("products");
				
				oprot.WriteListBegin();
				foreach(vipapis.product.ProductSkuInfo _item0 in structs.GetProducts()){
					
					
					vipapis.product.ProductSkuInfoHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTotal() != null) {
				
				oprot.WriteFieldBegin("total");
				oprot.WriteI32((int)structs.GetTotal()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("total can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(MultiGetProductSkuResponse bean){
			
			
		}
		
	}
	
}