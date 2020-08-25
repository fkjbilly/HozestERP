using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.product{
	
	
	
	public class UploadImageResultHelper : TBeanSerializer<UploadImageResult>
	{
		
		public static UploadImageResultHelper OBJ = new UploadImageResultHelper();
		
		public static UploadImageResultHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(UploadImageResult structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("process_status".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetProcess_status(value);
					}
					
					
					
					
					
					if ("failure_info".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetFailure_info(value);
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
		
		
		public void Write(UploadImageResult structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetProcess_status() != null) {
				
				oprot.WriteFieldBegin("process_status");
				oprot.WriteI32((int)structs.GetProcess_status()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("process_status can not be null!");
			}
			
			
			if(structs.GetFailure_info() != null) {
				
				oprot.WriteFieldBegin("failure_info");
				oprot.WriteString(structs.GetFailure_info());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(UploadImageResult bean){
			
			
		}
		
	}
	
}