using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.overseas{
	
	
	
	public class CarrierInfoHelper : TBeanSerializer<CarrierInfo>
	{
		
		public static CarrierInfoHelper OBJ = new CarrierInfoHelper();
		
		public static CarrierInfoHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(CarrierInfo structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("cust_data_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCust_data_id(value);
					}
					
					
					
					
					
					if ("order_sn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOrder_sn(value);
					}
					
					
					
					
					
					if ("transport_no".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTransport_no(value);
					}
					
					
					
					
					
					if ("order_status".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetOrder_status(value);
					}
					
					
					
					
					
					if ("order_status_info".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOrder_status_info(value);
					}
					
					
					
					
					
					if ("current_city".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCurrent_city(value);
					}
					
					
					
					
					
					if ("create_time".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCreate_time(value);
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
		
		
		public void Write(CarrierInfo structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetCust_data_id() != null) {
				
				oprot.WriteFieldBegin("cust_data_id");
				oprot.WriteString(structs.GetCust_data_id());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("cust_data_id can not be null!");
			}
			
			
			if(structs.GetOrder_sn() != null) {
				
				oprot.WriteFieldBegin("order_sn");
				oprot.WriteString(structs.GetOrder_sn());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("order_sn can not be null!");
			}
			
			
			if(structs.GetTransport_no() != null) {
				
				oprot.WriteFieldBegin("transport_no");
				oprot.WriteString(structs.GetTransport_no());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("transport_no can not be null!");
			}
			
			
			if(structs.GetOrder_status() != null) {
				
				oprot.WriteFieldBegin("order_status");
				oprot.WriteI32((int)structs.GetOrder_status()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("order_status can not be null!");
			}
			
			
			if(structs.GetOrder_status_info() != null) {
				
				oprot.WriteFieldBegin("order_status_info");
				oprot.WriteString(structs.GetOrder_status_info());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("order_status_info can not be null!");
			}
			
			
			if(structs.GetCurrent_city() != null) {
				
				oprot.WriteFieldBegin("current_city");
				oprot.WriteString(structs.GetCurrent_city());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("current_city can not be null!");
			}
			
			
			if(structs.GetCreate_time() != null) {
				
				oprot.WriteFieldBegin("create_time");
				oprot.WriteString(structs.GetCreate_time());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("create_time can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(CarrierInfo bean){
			
			
		}
		
	}
	
}