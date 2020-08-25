using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.product{
	
	
	
	public class ImageUploadResultHelper : BeanSerializer<ImageUploadResult>
	{
		
		public static ImageUploadResultHelper OBJ = new ImageUploadResultHelper();
		
		public static ImageUploadResultHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(ImageUploadResult structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("vendor_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetVendor_id(value);
					}
					
					
					
					
					
					if ("brand_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetBrand_id(value);
					}
					
					
					
					
					
					if ("sn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSn(value);
					}
					
					
					
					
					
					if ("upload_result_map".Equals(schemeField.Trim())){
						
						needSkip = false;
						Dictionary<int?, vipapis.product.UploadTaskExecutionResult> value;
						
						value = new Dictionary<int?, vipapis.product.UploadTaskExecutionResult>();
						iprot.ReadMapBegin();
						while(true){
							
							try{
								
								int _key0;
								vipapis.product.UploadTaskExecutionResult _val0;
								_key0 = iprot.ReadI32(); 
								
								
								_val0 = new vipapis.product.UploadTaskExecutionResult();
								vipapis.product.UploadTaskExecutionResultHelper.getInstance().Read(_val0, iprot);
								
								value.Add(_key0, _val0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadMapEnd();
						
						structs.SetUpload_result_map(value);
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
		
		
		public void Write(ImageUploadResult structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetVendor_id() != null) {
				
				oprot.WriteFieldBegin("vendor_id");
				oprot.WriteI32((int)structs.GetVendor_id()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("vendor_id can not be null!");
			}
			
			
			if(structs.GetBrand_id() != null) {
				
				oprot.WriteFieldBegin("brand_id");
				oprot.WriteI32((int)structs.GetBrand_id()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("brand_id can not be null!");
			}
			
			
			if(structs.GetSn() != null) {
				
				oprot.WriteFieldBegin("sn");
				oprot.WriteString(structs.GetSn());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("sn can not be null!");
			}
			
			
			if(structs.GetUpload_result_map() != null) {
				
				oprot.WriteFieldBegin("upload_result_map");
				
				oprot.WriteMapBegin();
				foreach(KeyValuePair< int?, vipapis.product.UploadTaskExecutionResult > _ir0 in structs.GetUpload_result_map()){
					
					int? _key0 = _ir0.Key;
					vipapis.product.UploadTaskExecutionResult _value0 = _ir0.Value;
					oprot.WriteI32((int)_key0); 
					
					
					vipapis.product.UploadTaskExecutionResultHelper.getInstance().Write(_value0, oprot);
					
				}
				
				oprot.WriteMapEnd();
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("upload_result_map can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(ImageUploadResult bean){
			
			
		}
		
	}
	
}