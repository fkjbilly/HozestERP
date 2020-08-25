using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vipshop.cis.sdk.api.datain.si.response{
	
	
	
	public class ChannelResponseHeaderHelper : TBeanSerializer<ChannelResponseHeader>
	{
		
		public static ChannelResponseHeaderHelper OBJ = new ChannelResponseHeaderHelper();
		
		public static ChannelResponseHeaderHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(ChannelResponseHeader structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("response_code".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetResponse_code(value);
					}
					
					
					
					
					
					if ("result_code".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetResult_code(value);
					}
					
					
					
					
					
					if ("message".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetMessage(value);
					}
					
					
					
					
					
					if ("local_area".Equals(schemeField.Trim())){
						
						needSkip = false;
						Dictionary<string, string> value;
						
						value = new Dictionary<string, string>();
						iprot.ReadMapBegin();
						while(true){
							
							try{
								
								string _key1;
								string _val1;
								_key1 = iprot.ReadString();
								
								_val1 = iprot.ReadString();
								
								value.Add(_key1, _val1);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadMapEnd();
						
						structs.SetLocal_area(value);
					}
					
					
					
					
					
					if ("trace_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTrace_id(value);
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
		
		
		public void Write(ChannelResponseHeader structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetResponse_code() != null) {
				
				oprot.WriteFieldBegin("response_code");
				oprot.WriteI32((int)structs.GetResponse_code()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("response_code can not be null!");
			}
			
			
			if(structs.GetResult_code() != null) {
				
				oprot.WriteFieldBegin("result_code");
				oprot.WriteString(structs.GetResult_code());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetMessage() != null) {
				
				oprot.WriteFieldBegin("message");
				oprot.WriteString(structs.GetMessage());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetLocal_area() != null) {
				
				oprot.WriteFieldBegin("local_area");
				
				oprot.WriteMapBegin();
				foreach(KeyValuePair< string, string > _ir0 in structs.GetLocal_area()){
					
					string _key0 = _ir0.Key;
					string _value0 = _ir0.Value;
					oprot.WriteString(_key0);
					
					oprot.WriteString(_value0);
					
				}
				
				oprot.WriteMapEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTrace_id() != null) {
				
				oprot.WriteFieldBegin("trace_id");
				oprot.WriteString(structs.GetTrace_id());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(ChannelResponseHeader bean){
			
			
		}
		
	}
	
}