using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.data.compass.service.vop{
	
	
	
	public class CompassDataResponseHelper : TBeanSerializer<CompassDataResponse>
	{
		
		public static CompassDataResponseHelper OBJ = new CompassDataResponseHelper();
		
		public static CompassDataResponseHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(CompassDataResponse structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("code".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCode(value);
					}
					
					
					
					
					
					if ("msg".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetMsg(value);
					}
					
					
					
					
					
					if ("data".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<Dictionary<string, string>> value;
						
						value = new List<Dictionary<string, string>>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								Dictionary<string, string> elem0;
								
								elem0 = new Dictionary<string, string>();
								iprot.ReadMapBegin();
								while(true){
									
									try{
										
										string _key1;
										string _val1;
										_key1 = iprot.ReadString();
										
										_val1 = iprot.ReadString();
										
										elem0.Add(_key1, _val1);
									}
									catch(Exception e){
										
										
										break;
									}
								}
								
								iprot.ReadMapEnd();
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetData(value);
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
		
		
		public void Write(CompassDataResponse structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetCode() != null) {
				
				oprot.WriteFieldBegin("code");
				oprot.WriteString(structs.GetCode());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("code can not be null!");
			}
			
			
			if(structs.GetMsg() != null) {
				
				oprot.WriteFieldBegin("msg");
				oprot.WriteString(structs.GetMsg());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("msg can not be null!");
			}
			
			
			if(structs.GetData() != null) {
				
				oprot.WriteFieldBegin("data");
				
				oprot.WriteListBegin();
				foreach(Dictionary<string, string> _item0 in structs.GetData()){
					
					
					oprot.WriteMapBegin();
					foreach(KeyValuePair< string, string > _ir1 in _item0){
						
						string _key1 = _ir1.Key;
						string _value1 = _ir1.Value;
						oprot.WriteString(_key1);
						
						oprot.WriteString(_value1);
						
					}
					
					oprot.WriteMapEnd();
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("data can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(CompassDataResponse bean){
			
			
		}
		
	}
	
}