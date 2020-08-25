using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.domain.order{
	
	
	
	public class CustomerBackOrderStatusInfoHelper : TBeanSerializer<CustomerBackOrderStatusInfo>
	{
		
		public static CustomerBackOrderStatusInfoHelper OBJ = new CustomerBackOrderStatusInfoHelper();
		
		public static CustomerBackOrderStatusInfoHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(CustomerBackOrderStatusInfo structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("max_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetMax_id(value);
					}
					
					
					
					
					
					if ("erp_back_sn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetErp_back_sn(value);
					}
					
					
					
					
					
					if ("transport_no".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTransport_no(value);
					}
					
					
					
					
					
					if ("transport_code".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTransport_code(value);
					}
					
					
					
					
					
					if ("transport_detail".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTransport_detail(value);
					}
					
					
					
					
					
					if ("ab_reason".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetAb_reason(value);
					}
					
					
					
					
					
					if ("ab_remark".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetAb_remark(value);
					}
					
					
					
					
					
					if ("carriers_code".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCarriers_code(value);
					}
					
					
					
					
					
					if ("carriers_shortname".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCarriers_shortname(value);
					}
					
					
					
					
					
					if ("carriers_type".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCarriers_type(value);
					}
					
					
					
					
					
					if ("play_type".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPlay_type(value);
					}
					
					
					
					
					
					if ("play_money".Equals(schemeField.Trim())){
						
						needSkip = false;
						double? value;
						value = iprot.ReadDouble();
						
						structs.SetPlay_money(value);
					}
					
					
					
					
					
					if ("warehouse".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetWarehouse(value);
					}
					
					
					
					
					
					if ("action_time".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetAction_time(value);
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
		
		
		public void Write(CustomerBackOrderStatusInfo structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetMax_id() != null) {
				
				oprot.WriteFieldBegin("max_id");
				oprot.WriteI64((long)structs.GetMax_id()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetErp_back_sn() != null) {
				
				oprot.WriteFieldBegin("erp_back_sn");
				oprot.WriteString(structs.GetErp_back_sn());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTransport_no() != null) {
				
				oprot.WriteFieldBegin("transport_no");
				oprot.WriteString(structs.GetTransport_no());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTransport_code() != null) {
				
				oprot.WriteFieldBegin("transport_code");
				oprot.WriteString(structs.GetTransport_code());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTransport_detail() != null) {
				
				oprot.WriteFieldBegin("transport_detail");
				oprot.WriteString(structs.GetTransport_detail());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetAb_reason() != null) {
				
				oprot.WriteFieldBegin("ab_reason");
				oprot.WriteString(structs.GetAb_reason());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetAb_remark() != null) {
				
				oprot.WriteFieldBegin("ab_remark");
				oprot.WriteString(structs.GetAb_remark());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCarriers_code() != null) {
				
				oprot.WriteFieldBegin("carriers_code");
				oprot.WriteString(structs.GetCarriers_code());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCarriers_shortname() != null) {
				
				oprot.WriteFieldBegin("carriers_shortname");
				oprot.WriteString(structs.GetCarriers_shortname());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCarriers_type() != null) {
				
				oprot.WriteFieldBegin("carriers_type");
				oprot.WriteString(structs.GetCarriers_type());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPlay_type() != null) {
				
				oprot.WriteFieldBegin("play_type");
				oprot.WriteString(structs.GetPlay_type());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPlay_money() != null) {
				
				oprot.WriteFieldBegin("play_money");
				oprot.WriteDouble((double)structs.GetPlay_money());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetWarehouse() != null) {
				
				oprot.WriteFieldBegin("warehouse");
				oprot.WriteString(structs.GetWarehouse());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetAction_time() != null) {
				
				oprot.WriteFieldBegin("action_time");
				oprot.WriteString(structs.GetAction_time());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(CustomerBackOrderStatusInfo bean){
			
			
		}
		
	}
	
}