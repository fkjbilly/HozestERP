using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.haitao.orderservice.service{
	
	
	
	public class HeadHelper : TBeanSerializer<Head>
	{
		
		public static HeadHelper OBJ = new HeadHelper();
		
		public static HeadHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(Head structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("responseTime".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetResponseTime(value);
					}
					
					
					
					
					
					if ("sysResponseCode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSysResponseCode(value);
					}
					
					
					
					
					
					if ("sysResponseMsg".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSysResponseMsg(value);
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
		
		
		public void Write(Head structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetResponseTime() != null) {
				
				oprot.WriteFieldBegin("responseTime");
				oprot.WriteString(structs.GetResponseTime());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSysResponseCode() != null) {
				
				oprot.WriteFieldBegin("sysResponseCode");
				oprot.WriteString(structs.GetSysResponseCode());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSysResponseMsg() != null) {
				
				oprot.WriteFieldBegin("sysResponseMsg");
				oprot.WriteString(structs.GetSysResponseMsg());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(Head bean){
			
			
		}
		
	}
	
}