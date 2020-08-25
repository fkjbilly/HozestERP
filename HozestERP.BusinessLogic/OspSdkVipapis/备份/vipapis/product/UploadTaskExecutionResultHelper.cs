using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.product{
	
	
	
	public class UploadTaskExecutionResultHelper : BeanSerializer<UploadTaskExecutionResult>
	{
		
		public static UploadTaskExecutionResultHelper OBJ = new UploadTaskExecutionResultHelper();
		
		public static UploadTaskExecutionResultHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(UploadTaskExecutionResult structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("task_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetTask_id(value);
					}
					
					
					
					
					
					if ("process_status".Equals(schemeField.Trim())){
						
						needSkip = false;
						short? value;
						value = iprot.ReadI16(); 
						
						structs.SetProcess_status(value);
					}
					
					
					
					
					
					if ("failure_code".Equals(schemeField.Trim())){
						
						needSkip = false;
						short? value;
						value = iprot.ReadI16(); 
						
						structs.SetFailure_code(value);
					}
					
					
					
					
					
					if ("failure_reason".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetFailure_reason(value);
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
		
		
		public void Write(UploadTaskExecutionResult structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetTask_id() != null) {
				
				oprot.WriteFieldBegin("task_id");
				oprot.WriteI64((long)structs.GetTask_id()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetProcess_status() != null) {
				
				oprot.WriteFieldBegin("process_status");
				oprot.WriteI16((short)structs.GetProcess_status()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetFailure_code() != null) {
				
				oprot.WriteFieldBegin("failure_code");
				oprot.WriteI16((short)structs.GetFailure_code()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetFailure_reason() != null) {
				
				oprot.WriteFieldBegin("failure_reason");
				oprot.WriteString(structs.GetFailure_reason());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(UploadTaskExecutionResult bean){
			
			
		}
		
	}
	
}