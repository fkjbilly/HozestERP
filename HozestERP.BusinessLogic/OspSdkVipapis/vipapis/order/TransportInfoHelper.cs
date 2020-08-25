using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.order{
	
	
	
	public class TransportInfoHelper : BeanSerializer<TransportInfo>
	{
		
		public static TransportInfoHelper OBJ = new TransportInfoHelper();
		
		public static TransportInfoHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(TransportInfo structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("datetime".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetDatetime(value);
					}
					
					
					
					
					
					if ("user".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetUser(value);
					}
					
					
					
					
					
					if ("remark".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetRemark(value);
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
		
		
		public void Write(TransportInfo structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetDatetime() != null) {
				
				oprot.WriteFieldBegin("datetime");
				oprot.WriteI32((int)structs.GetDatetime()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("datetime can not be null!");
			}
			
			
			if(structs.GetUser() != null) {
				
				oprot.WriteFieldBegin("user");
				oprot.WriteString(structs.GetUser());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("user can not be null!");
			}
			
			
			if(structs.GetRemark() != null) {
				
				oprot.WriteFieldBegin("remark");
				oprot.WriteString(structs.GetRemark());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(TransportInfo bean){
			
			
		}
		
	}
	
}