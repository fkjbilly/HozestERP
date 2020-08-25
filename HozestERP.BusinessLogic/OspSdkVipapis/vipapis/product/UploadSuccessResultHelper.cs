using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.product{
	
	
	
	public class UploadSuccessResultHelper : TBeanSerializer<UploadSuccessResult>
	{
		
		public static UploadSuccessResultHelper OBJ = new UploadSuccessResultHelper();
		
		public static UploadSuccessResultHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(UploadSuccessResult structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("img_index".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetImg_index(value);
					}
					
					
					
					
					
					if ("url".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetUrl(value);
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
		
		
		public void Write(UploadSuccessResult structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetImg_index() != null) {
				
				oprot.WriteFieldBegin("img_index");
				oprot.WriteI32((int)structs.GetImg_index()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetUrl() != null) {
				
				oprot.WriteFieldBegin("url");
				oprot.WriteString(structs.GetUrl());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(UploadSuccessResult bean){
			
			
		}
		
	}
	
}