using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.order{
	
	
	
	public class FailQueryItemHelper : TBeanSerializer<FailQueryItem>
	{
		
		public static FailQueryItemHelper OBJ = new FailQueryItemHelper();
		
		public static FailQueryItemHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(FailQueryItem structs, Protocol iprot){
			
			
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
					
					
					
					
					
					if ("invoice_type".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetInvoice_type(value);
					}
					
					
					
					
					
					if ("failure_msg".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetFailure_msg(value);
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
		
		
		public void Write(FailQueryItem structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetOrder_id() != null) {
				
				oprot.WriteFieldBegin("order_id");
				oprot.WriteString(structs.GetOrder_id());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("order_id can not be null!");
			}
			
			
			if(structs.GetInvoice_type() != null) {
				
				oprot.WriteFieldBegin("invoice_type");
				oprot.WriteI32((int)structs.GetInvoice_type()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetFailure_msg() != null) {
				
				oprot.WriteFieldBegin("failure_msg");
				oprot.WriteString(structs.GetFailure_msg());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("failure_msg can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(FailQueryItem bean){
			
			
		}
		
	}
	
}