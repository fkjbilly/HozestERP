using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.product{
	
	
	
	public class ProductImageHelper : BeanSerializer<ProductImage>
	{
		
		public static ProductImageHelper OBJ = new ProductImageHelper();
		
		public static ProductImageHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(ProductImage structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("image_url".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetImage_url(value);
					}
					
					
					
					
					
					if ("image_index".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetImage_index(value);
					}
					
					
					
					
					
					if ("description".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetDescription(value);
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
		
		
		public void Write(ProductImage structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetImage_url() != null) {
				
				oprot.WriteFieldBegin("image_url");
				oprot.WriteString(structs.GetImage_url());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("image_url can not be null!");
			}
			
			
			if(structs.GetImage_index() != null) {
				
				oprot.WriteFieldBegin("image_index");
				oprot.WriteI32((int)structs.GetImage_index()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("image_index can not be null!");
			}
			
			
			if(structs.GetDescription() != null) {
				
				oprot.WriteFieldBegin("description");
				oprot.WriteString(structs.GetDescription());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(ProductImage bean){
			
			
		}
		
	}
	
}