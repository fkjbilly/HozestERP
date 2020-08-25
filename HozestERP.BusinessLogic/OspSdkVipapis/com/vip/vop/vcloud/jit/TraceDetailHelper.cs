using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.vop.vcloud.jit{
	
	
	
	public class TraceDetailHelper : TBeanSerializer<TraceDetail>
	{
		
		public static TraceDetailHelper OBJ = new TraceDetailHelper();
		
		public static TraceDetailHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(TraceDetail structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("transportCode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTransportCode(value);
					}
					
					
					
					
					
					if ("transportDetail".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTransportDetail(value);
					}
					
					
					
					
					
					if ("transportTime".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTransportTime(value);
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
		
		
		public void Write(TraceDetail structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetTransportCode() != null) {
				
				oprot.WriteFieldBegin("transportCode");
				oprot.WriteString(structs.GetTransportCode());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTransportDetail() != null) {
				
				oprot.WriteFieldBegin("transportDetail");
				oprot.WriteString(structs.GetTransportDetail());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTransportTime() != null) {
				
				oprot.WriteFieldBegin("transportTime");
				oprot.WriteString(structs.GetTransportTime());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(TraceDetail bean){
			
			
		}
		
	}
	
}