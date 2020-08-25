using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.delivery{
	
	
	
	public class OrderReturnHelper : TBeanSerializer<OrderReturn>
	{
		
		public static OrderReturnHelper OBJ = new OrderReturnHelper();
		
		public static OrderReturnHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(OrderReturn structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("order_return_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOrder_return_id(value);
					}
					
					
					
					
					
					if ("order_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOrder_id(value);
					}
					
					
					
					
					
					if ("return_type".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetReturn_type(value);
					}
					
					
					
					
					
					if ("vendor_need_audit".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetVendor_need_audit(value);
					}
					
					
					
					
					
					if ("return_reason".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetReturn_reason(value);
					}
					
					
					
					
					
					if ("return_time".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetReturn_time(value);
					}
					
					
					
					
					
					if ("transport_no".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTransport_no(value);
					}
					
					
					
					
					
					if ("carrier".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCarrier(value);
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
		
		
		public void Write(OrderReturn structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetOrder_return_id() != null) {
				
				oprot.WriteFieldBegin("order_return_id");
				oprot.WriteString(structs.GetOrder_return_id());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrder_id() != null) {
				
				oprot.WriteFieldBegin("order_id");
				oprot.WriteString(structs.GetOrder_id());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetReturn_type() != null) {
				
				oprot.WriteFieldBegin("return_type");
				oprot.WriteI32((int)structs.GetReturn_type()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetVendor_need_audit() != null) {
				
				oprot.WriteFieldBegin("vendor_need_audit");
				oprot.WriteI32((int)structs.GetVendor_need_audit()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetReturn_reason() != null) {
				
				oprot.WriteFieldBegin("return_reason");
				oprot.WriteString(structs.GetReturn_reason());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetReturn_time() != null) {
				
				oprot.WriteFieldBegin("return_time");
				oprot.WriteString(structs.GetReturn_time());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTransport_no() != null) {
				
				oprot.WriteFieldBegin("transport_no");
				oprot.WriteString(structs.GetTransport_no());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCarrier() != null) {
				
				oprot.WriteFieldBegin("carrier");
				oprot.WriteString(structs.GetCarrier());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(OrderReturn bean){
			
			
		}
		
	}
	
}