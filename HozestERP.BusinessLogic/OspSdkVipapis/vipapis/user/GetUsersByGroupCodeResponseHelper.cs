using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.user{
	
	
	
	public class GetUsersByGroupCodeResponseHelper : TBeanSerializer<GetUsersByGroupCodeResponse>
	{
		
		public static GetUsersByGroupCodeResponseHelper OBJ = new GetUsersByGroupCodeResponseHelper();
		
		public static GetUsersByGroupCodeResponseHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(GetUsersByGroupCodeResponse structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("users".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<string> value;
						
						value = new List<string>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								string elem0;
								elem0 = iprot.ReadString();
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetUsers(value);
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
		
		
		public void Write(GetUsersByGroupCodeResponse structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetUsers() != null) {
				
				oprot.WriteFieldBegin("users");
				
				oprot.WriteListBegin();
				foreach(string _item0 in structs.GetUsers()){
					
					oprot.WriteString(_item0);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(GetUsersByGroupCodeResponse bean){
			
			
		}
		
	}
	
}