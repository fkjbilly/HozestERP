using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.vipcard{
	
	
	
	public class ApplyGroupResponseHelper : TBeanSerializer<ApplyGroupResponse>
	{
		
		public static ApplyGroupResponseHelper OBJ = new ApplyGroupResponseHelper();
		
		public static ApplyGroupResponseHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(ApplyGroupResponse structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("group_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetGroup_id(value);
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
		
		
		public void Write(ApplyGroupResponse structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetGroup_id() != null) {
				
				oprot.WriteFieldBegin("group_id");
				oprot.WriteI32((int)structs.GetGroup_id()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("group_id can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(ApplyGroupResponse bean){
			
			
		}
		
	}
	
}