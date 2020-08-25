using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.vop.omni.logistics{
	
	
	
	public class TraceInfoHelper : TBeanSerializer<TraceInfo>
	{
		
		public static TraceInfoHelper OBJ = new TraceInfoHelper();
		
		public static TraceInfoHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(TraceInfo structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("transport_code".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTransport_code(value);
					}
					
					
					
					
					
					if ("transport_detail".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTransport_detail(value);
					}
					
					
					
					
					
					if ("transport_time".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTransport_time(value);
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
		
		
		public void Write(TraceInfo structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetTransport_code() != null) {
				
				oprot.WriteFieldBegin("transport_code");
				oprot.WriteString(structs.GetTransport_code());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTransport_detail() != null) {
				
				oprot.WriteFieldBegin("transport_detail");
				oprot.WriteString(structs.GetTransport_detail());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTransport_time() != null) {
				
				oprot.WriteFieldBegin("transport_time");
				oprot.WriteString(structs.GetTransport_time());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(TraceInfo bean){
			
			
		}
		
	}
	
}