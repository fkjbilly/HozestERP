using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.hermes.core.health{
	
	
	
	public class CheckResultHelper : TBeanSerializer<CheckResult>
	{
		
		public static CheckResultHelper OBJ = new CheckResultHelper();
		
		public static CheckResultHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(CheckResult structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("status".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.hermes.core.health.Status value;
						
						value = new com.vip.hermes.core.health.Status();
						com.vip.hermes.core.health.StatusHelper.getInstance().Read(value, iprot);
						
						structs.SetStatus(value);
					}
					
					
					
					
					
					if ("details".Equals(schemeField.Trim())){
						
						needSkip = false;
						Dictionary<string, string> value;
						
						value = new Dictionary<string, string>();
						iprot.ReadMapBegin();
						while(true){
							
							try{
								
								string _key2;
								string _val2;
								_key2 = iprot.ReadString();
								
								_val2 = iprot.ReadString();
								
								value.Add(_key2, _val2);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadMapEnd();
						
						structs.SetDetails(value);
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
		
		
		public void Write(CheckResult structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetStatus() != null) {
				
				oprot.WriteFieldBegin("status");
				
				com.vip.hermes.core.health.StatusHelper.getInstance().Write(structs.GetStatus(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetDetails() != null) {
				
				oprot.WriteFieldBegin("details");
				
				oprot.WriteMapBegin();
				foreach(KeyValuePair< string, string > _ir0 in structs.GetDetails()){
					
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
		
		
		public void Validate(CheckResult bean){
			
			
		}
		
	}
	
}