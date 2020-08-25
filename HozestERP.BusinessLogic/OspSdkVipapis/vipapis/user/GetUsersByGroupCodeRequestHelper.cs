using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.user{
	
	
	
	public class GetUsersByGroupCodeRequestHelper : TBeanSerializer<GetUsersByGroupCodeRequest>
	{
		
		public static GetUsersByGroupCodeRequestHelper OBJ = new GetUsersByGroupCodeRequestHelper();
		
		public static GetUsersByGroupCodeRequestHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(GetUsersByGroupCodeRequest structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("dsp_code".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetDsp_code(value);
					}
					
					
					
					
					
					if ("group_code".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetGroup_code(value);
					}
					
					
					
					
					
					if ("data_version".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetData_version(value);
					}
					
					
					
					
					
					if ("start".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetStart(value);
					}
					
					
					
					
					
					if ("offset".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetOffset(value);
					}
					
					
					
					
					
					if ("encrypt_type".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetEncrypt_type(value);
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
		
		
		public void Write(GetUsersByGroupCodeRequest structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetDsp_code() != null) {
				
				oprot.WriteFieldBegin("dsp_code");
				oprot.WriteString(structs.GetDsp_code());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("dsp_code can not be null!");
			}
			
			
			if(structs.GetGroup_code() != null) {
				
				oprot.WriteFieldBegin("group_code");
				oprot.WriteString(structs.GetGroup_code());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("group_code can not be null!");
			}
			
			
			if(structs.GetData_version() != null) {
				
				oprot.WriteFieldBegin("data_version");
				oprot.WriteString(structs.GetData_version());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("data_version can not be null!");
			}
			
			
			if(structs.GetStart() != null) {
				
				oprot.WriteFieldBegin("start");
				oprot.WriteI32((int)structs.GetStart()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOffset() != null) {
				
				oprot.WriteFieldBegin("offset");
				oprot.WriteI32((int)structs.GetOffset()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetEncrypt_type() != null) {
				
				oprot.WriteFieldBegin("encrypt_type");
				oprot.WriteI32((int)structs.GetEncrypt_type()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(GetUsersByGroupCodeRequest bean){
			
			
		}
		
	}
	
}