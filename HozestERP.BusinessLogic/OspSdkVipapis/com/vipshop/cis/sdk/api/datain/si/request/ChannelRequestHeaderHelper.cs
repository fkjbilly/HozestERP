using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vipshop.cis.sdk.api.datain.si.request{
	
	
	
	public class ChannelRequestHeaderHelper : TBeanSerializer<ChannelRequestHeader>
	{
		
		public static ChannelRequestHeaderHelper OBJ = new ChannelRequestHeaderHelper();
		
		public static ChannelRequestHeaderHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(ChannelRequestHeader structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("version".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetVersion(value);
					}
					
					
					
					
					
					if ("consumer".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetConsumer(value);
					}
					
					
					
					
					
					if ("token".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetToken(value);
					}
					
					
					
					
					
					if ("extension_area".Equals(schemeField.Trim())){
						
						needSkip = false;
						Dictionary<string, string> value;
						
						value = new Dictionary<string, string>();
						iprot.ReadMapBegin();
						while(true){
							
							try{
								
								string _key0;
								string _val0;
								_key0 = iprot.ReadString();
								
								_val0 = iprot.ReadString();
								
								value.Add(_key0, _val0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadMapEnd();
						
						structs.SetExtension_area(value);
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
		
		
		public void Write(ChannelRequestHeader structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetVersion() != null) {
				
				oprot.WriteFieldBegin("version");
				oprot.WriteString(structs.GetVersion());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("version can not be null!");
			}
			
			
			if(structs.GetConsumer() != null) {
				
				oprot.WriteFieldBegin("consumer");
				oprot.WriteString(structs.GetConsumer());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("consumer can not be null!");
			}
			
			
			if(structs.GetToken() != null) {
				
				oprot.WriteFieldBegin("token");
				oprot.WriteString(structs.GetToken());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("token can not be null!");
			}
			
			
			if(structs.GetExtension_area() != null) {
				
				oprot.WriteFieldBegin("extension_area");
				
				oprot.WriteMapBegin();
				foreach(KeyValuePair< string, string > _ir0 in structs.GetExtension_area()){
					
					string _key0 = _ir0.Key;
					string _value0 = _ir0.Value;
					oprot.WriteString(_key0);
					
					oprot.WriteString(_value0);
					
				}
				
				oprot.WriteMapEnd();
				
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
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(ChannelRequestHeader bean){
			
			
		}
		
	}
	
}