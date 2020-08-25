using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.svip.osp.service{
	
	
	
	public class SimpleRequestHeaderHelper : TBeanSerializer<SimpleRequestHeader>
	{
		
		public static SimpleRequestHeaderHelper OBJ = new SimpleRequestHeaderHelper();
		
		public static SimpleRequestHeaderHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(SimpleRequestHeader structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("userId".Equals(schemeField.Trim())){
						
						needSkip = false;
						long value;
						value = iprot.ReadI64(); 
						
						structs.SetUserId(value);
					}
					
					
					
					
					
					if ("ip".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetIp(value);
					}
					
					
					
					
					
					if ("marsCid".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetMarsCid(value);
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
		
		
		public void Write(SimpleRequestHeader structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetUserId() != null) {
				
				oprot.WriteFieldBegin("userId");
				oprot.WriteI64((long)structs.GetUserId()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("userId can not be null!");
			}
			
			
			if(structs.GetIp() != null) {
				
				oprot.WriteFieldBegin("ip");
				oprot.WriteString(structs.GetIp());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetMarsCid() != null) {
				
				oprot.WriteFieldBegin("marsCid");
				oprot.WriteString(structs.GetMarsCid());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(SimpleRequestHeader bean){
			
			
		}
		
	}
	
}