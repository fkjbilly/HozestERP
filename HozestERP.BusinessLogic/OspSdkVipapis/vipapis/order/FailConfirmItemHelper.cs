using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.order{
	
	
	
	public class FailConfirmItemHelper : TBeanSerializer<FailConfirmItem>
	{
		
		public static FailConfirmItemHelper OBJ = new FailConfirmItemHelper();
		
		public static FailConfirmItemHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(FailConfirmItem structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("order_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOrder_id(value);
					}
					
					
					
					
					
					if ("failure_msg".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetFailure_msg(value);
					}
					
					
					
					
					
					if ("failure_code".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetFailure_code(value);
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
		
		
		public void Write(FailConfirmItem structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetOrder_id() != null) {
				
				oprot.WriteFieldBegin("order_id");
				oprot.WriteString(structs.GetOrder_id());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetFailure_msg() != null) {
				
				oprot.WriteFieldBegin("failure_msg");
				oprot.WriteString(structs.GetFailure_msg());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetFailure_code() != null) {
				
				oprot.WriteFieldBegin("failure_code");
				oprot.WriteString(structs.GetFailure_code());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(FailConfirmItem bean){
			
			
		}
		
	}
	
}