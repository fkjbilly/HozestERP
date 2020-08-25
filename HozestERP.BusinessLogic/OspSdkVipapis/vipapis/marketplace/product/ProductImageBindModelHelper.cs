using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.marketplace.product{
	
	
	
	public class ProductImageBindModelHelper : TBeanSerializer<ProductImageBindModel>
	{
		
		public static ProductImageBindModelHelper OBJ = new ProductImageBindModelHelper();
		
		public static ProductImageBindModelHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(ProductImageBindModel structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("spu_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSpu_id(value);
					}
					
					
					
					
					
					if ("images".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.marketplace.product.Image> value;
						
						value = new List<vipapis.marketplace.product.Image>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.marketplace.product.Image elem0;
								
								elem0 = new vipapis.marketplace.product.Image();
								vipapis.marketplace.product.ImageHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetImages(value);
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
		
		
		public void Write(ProductImageBindModel structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetSpu_id() != null) {
				
				oprot.WriteFieldBegin("spu_id");
				oprot.WriteString(structs.GetSpu_id());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("spu_id can not be null!");
			}
			
			
			if(structs.GetImages() != null) {
				
				oprot.WriteFieldBegin("images");
				
				oprot.WriteListBegin();
				foreach(vipapis.marketplace.product.Image _item0 in structs.GetImages()){
					
					
					vipapis.marketplace.product.ImageHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("images can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(ProductImageBindModel bean){
			
			
		}
		
	}
	
}