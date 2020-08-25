using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.user{
	
	
	
	public class GroupInfoHelper : TBeanSerializer<GroupInfo>
	{
		
		public static GroupInfoHelper OBJ = new GroupInfoHelper();
		
		public static GroupInfoHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(GroupInfo structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("group_code".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetGroup_code(value);
					}
					
					
					
					
					
					if ("group_name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetGroup_name(value);
					}
					
					
					
					
					
					if ("data_type".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetData_type(value);
					}
					
					
					
					
					
					if ("expire_time".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetExpire_time(value);
					}
					
					
					
					
					
					if ("size".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetSize(value);
					}
					
					
					
					
					
					if ("data_version".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetData_version(value);
					}
					
					
					
					
					
					if ("last_updated_time".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetLast_updated_time(value);
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
		
		
		public void Write(GroupInfo structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetGroup_code() != null) {
				
				oprot.WriteFieldBegin("group_code");
				oprot.WriteString(structs.GetGroup_code());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetGroup_name() != null) {
				
				oprot.WriteFieldBegin("group_name");
				oprot.WriteString(structs.GetGroup_name());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetData_type() != null) {
				
				oprot.WriteFieldBegin("data_type");
				oprot.WriteI32((int)structs.GetData_type()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetExpire_time() != null) {
				
				oprot.WriteFieldBegin("expire_time");
				oprot.WriteI64((long)structs.GetExpire_time()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSize() != null) {
				
				oprot.WriteFieldBegin("size");
				oprot.WriteI32((int)structs.GetSize()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetData_version() != null) {
				
				oprot.WriteFieldBegin("data_version");
				oprot.WriteString(structs.GetData_version());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetLast_updated_time() != null) {
				
				oprot.WriteFieldBegin("last_updated_time");
				oprot.WriteI64((long)structs.GetLast_updated_time()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(GroupInfo bean){
			
			
		}
		
	}
	
}