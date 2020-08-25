using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.biz.request{
	
	
	
	public class RequestHeaderHelper : TBeanSerializer<RequestHeader>
	{
		
		public static RequestHeaderHelper OBJ = new RequestHeaderHelper();
		
		public static RequestHeaderHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(RequestHeader structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("operation".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOperation(value);
					}
					
					
					
					
					
					if ("sourceSys".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSourceSys(value);
					}
					
					
					
					
					
					if ("transId".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTransId(value);
					}
					
					
					
					
					
					if ("transTimestamp".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetTransTimestamp(value);
					}
					
					
					
					
					
					if ("operator".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOperator(value);
					}
					
					
					
					
					
					if ("operatorName".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOperatorName(value);
					}
					
					
					
					
					
					if ("clientIp".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetClientIp(value);
					}
					
					
					
					
					
					if ("appVersion".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetAppVersion(value);
					}
					
					
					
					
					
					if ("operatorRole".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetOperatorRole(value);
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
		
		
		public void Write(RequestHeader structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetOperation() != null) {
				
				oprot.WriteFieldBegin("operation");
				oprot.WriteString(structs.GetOperation());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSourceSys() != null) {
				
				oprot.WriteFieldBegin("sourceSys");
				oprot.WriteString(structs.GetSourceSys());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTransId() != null) {
				
				oprot.WriteFieldBegin("transId");
				oprot.WriteString(structs.GetTransId());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTransTimestamp() != null) {
				
				oprot.WriteFieldBegin("transTimestamp");
				oprot.WriteI64((long)structs.GetTransTimestamp()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOperator() != null) {
				
				oprot.WriteFieldBegin("operator");
				oprot.WriteString(structs.GetOperator());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOperatorName() != null) {
				
				oprot.WriteFieldBegin("operatorName");
				oprot.WriteString(structs.GetOperatorName());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetClientIp() != null) {
				
				oprot.WriteFieldBegin("clientIp");
				oprot.WriteString(structs.GetClientIp());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetAppVersion() != null) {
				
				oprot.WriteFieldBegin("appVersion");
				oprot.WriteString(structs.GetAppVersion());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOperatorRole() != null) {
				
				oprot.WriteFieldBegin("operatorRole");
				oprot.WriteI32((int)structs.GetOperatorRole()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(RequestHeader bean){
			
			
		}
		
	}
	
}