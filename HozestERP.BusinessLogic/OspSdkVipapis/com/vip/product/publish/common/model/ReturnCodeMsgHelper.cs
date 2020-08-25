using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.product.publish.common.model{
	
	
	
	public class ReturnCodeMsgHelper : TBeanSerializer<ReturnCodeMsg>
	{
		
		public static ReturnCodeMsgHelper OBJ = new ReturnCodeMsgHelper();
		
		public static ReturnCodeMsgHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(ReturnCodeMsg structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("returnCode".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetReturnCode(value);
					}
					
					
					
					
					
					if ("errorMsg".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetErrorMsg(value);
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
		
		
		public void Write(ReturnCodeMsg structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetReturnCode() != null) {
				
				oprot.WriteFieldBegin("returnCode");
				oprot.WriteI32((int)structs.GetReturnCode()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetErrorMsg() != null) {
				
				oprot.WriteFieldBegin("errorMsg");
				oprot.WriteString(structs.GetErrorMsg());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(ReturnCodeMsg bean){
			
			
		}
		
	}
	
}