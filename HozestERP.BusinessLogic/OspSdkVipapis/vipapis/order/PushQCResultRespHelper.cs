using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.order{
	
	
	
	public class PushQCResultRespHelper : TBeanSerializer<PushQCResultResp>
	{
		
		public static PushQCResultRespHelper OBJ = new PushQCResultRespHelper();
		
		public static PushQCResultRespHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(PushQCResultResp structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("is_success".Equals(schemeField.Trim())){
						
						needSkip = false;
						bool value;
						value = iprot.ReadBool();
						
						structs.SetIs_success(value);
					}
					
					
					
					
					
					if ("failure_msg".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetFailure_msg(value);
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
		
		
		public void Write(PushQCResultResp structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetIs_success() != null) {
				
				oprot.WriteFieldBegin("is_success");
				oprot.WriteBool((bool)structs.GetIs_success());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("is_success can not be null!");
			}
			
			
			if(structs.GetFailure_msg() != null) {
				
				oprot.WriteFieldBegin("failure_msg");
				oprot.WriteString(structs.GetFailure_msg());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(PushQCResultResp bean){
			
			
		}
		
	}
	
}