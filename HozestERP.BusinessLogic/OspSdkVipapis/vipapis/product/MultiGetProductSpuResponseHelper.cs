using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.product{
	
	
	
	public class MultiGetProductSpuResponseHelper : TBeanSerializer<MultiGetProductSpuResponse>
	{
		
		public static MultiGetProductSpuResponseHelper OBJ = new MultiGetProductSpuResponseHelper();
		
		public static MultiGetProductSpuResponseHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(MultiGetProductSpuResponse structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("products".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.product.ProductSpuInfo> value;
						
						value = new List<vipapis.product.ProductSpuInfo>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.product.ProductSpuInfo elem1;
								
								elem1 = new vipapis.product.ProductSpuInfo();
								vipapis.product.ProductSpuInfoHelper.getInstance().Read(elem1, iprot);
								
								value.Add(elem1);
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
		
		
		public void Write(MultiGetProductSpuResponse structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetProducts() != null) {
				
				oprot.WriteFieldBegin("products");
				
				oprot.WriteListBegin();
				foreach(vipapis.product.ProductSpuInfo _item0 in structs.GetProducts()){
					
					
					vipapis.product.ProductSpuInfoHelper.getInstance().Write(_item0, oprot);
					
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
		
		
		public void Validate(MultiGetProductSpuResponse bean){
			
			
		}
		
	}
	
}