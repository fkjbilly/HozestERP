using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.domain.order{
	
	
	
	public class OrderStatusInfoHelper : TBeanSerializer<OrderStatusInfo>
	{
		
		public static OrderStatusInfoHelper OBJ = new OrderStatusInfoHelper();
		
		public static OrderStatusInfoHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(OrderStatusInfo structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("erp_order_sn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetErp_order_sn(value);
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
					
					
					
					
					
					if ("carriers_code".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCarriers_code(value);
					}
					
					
					
					
					
					if ("carriers_name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCarriers_name(value);
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
					
					
					
					
					
					if ("pay_type".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPay_type(value);
					}
					
					
					
					
					
					if ("ext_pay_type".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetExt_pay_type(value);
					}
					
					
					
					
					
					if ("alipay_cust_no".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetAlipay_cust_no(value);
					}
					
					
					
					
					
					if ("max_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetMax_id(value);
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
		
		
		public void Write(OrderStatusInfo structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetErp_order_sn() != null) {
				
				oprot.WriteFieldBegin("erp_order_sn");
				oprot.WriteString(structs.GetErp_order_sn());
				
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
			
			
			if(structs.GetCarriers_code() != null) {
				
				oprot.WriteFieldBegin("carriers_code");
				oprot.WriteString(structs.GetCarriers_code());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCarriers_name() != null) {
				
				oprot.WriteFieldBegin("carriers_name");
				oprot.WriteString(structs.GetCarriers_name());
				
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
			
			
			if(structs.GetPay_type() != null) {
				
				oprot.WriteFieldBegin("pay_type");
				oprot.WriteString(structs.GetPay_type());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetExt_pay_type() != null) {
				
				oprot.WriteFieldBegin("ext_pay_type");
				oprot.WriteString(structs.GetExt_pay_type());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetAlipay_cust_no() != null) {
				
				oprot.WriteFieldBegin("alipay_cust_no");
				oprot.WriteString(structs.GetAlipay_cust_no());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetMax_id() != null) {
				
				oprot.WriteFieldBegin("max_id");
				oprot.WriteI64((long)structs.GetMax_id()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(OrderStatusInfo bean){
			
			
		}
		
	}
	
}