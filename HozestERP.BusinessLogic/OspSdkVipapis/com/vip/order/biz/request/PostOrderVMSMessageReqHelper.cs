using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.biz.request{
	
	
	
	public class PostOrderVMSMessageReqHelper : TBeanSerializer<PostOrderVMSMessageReq>
	{
		
		public static PostOrderVMSMessageReqHelper OBJ = new PostOrderVMSMessageReqHelper();
		
		public static PostOrderVMSMessageReqHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(PostOrderVMSMessageReq structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("msgScenario".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetMsgScenario(value);
					}
					
					
					
					
					
					if ("msgType".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetMsgType(value);
					}
					
					
					
					
					
					if ("msgContent".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetMsgContent(value);
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
		
		
		public void Write(PostOrderVMSMessageReq structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetMsgScenario() != null) {
				
				oprot.WriteFieldBegin("msgScenario");
				oprot.WriteString(structs.GetMsgScenario());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetMsgType() != null) {
				
				oprot.WriteFieldBegin("msgType");
				oprot.WriteI32((int)structs.GetMsgType()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetMsgContent() != null) {
				
				oprot.WriteFieldBegin("msgContent");
				oprot.WriteString(structs.GetMsgContent());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(PostOrderVMSMessageReq bean){
			
			
		}
		
	}
	
}