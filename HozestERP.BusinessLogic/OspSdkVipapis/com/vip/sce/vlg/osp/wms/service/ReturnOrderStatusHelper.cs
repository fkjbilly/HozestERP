using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.sce.vlg.osp.wms.service{
	
	
	
	public class ReturnOrderStatusHelper : TBeanSerializer<ReturnOrderStatus>
	{
		
		public static ReturnOrderStatusHelper OBJ = new ReturnOrderStatusHelper();
		
		public static ReturnOrderStatusHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(ReturnOrderStatus structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("id".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetId(value);
					}
					
					
					
					
					
					if ("warehouse".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetWarehouse(value);
					}
					
					
					
					
					
					if ("shipment_no".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetShipment_no(value);
					}
					
					
					
					
					
					if ("erp_order_no".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetErp_order_no(value);
					}
					
					
					
					
					
					if ("reference_no".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetReference_no(value);
					}
					
					
					
					
					
					if ("order_type".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOrder_type(value);
					}
					
					
					
					
					
					if ("status_code".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetStatus_code(value);
					}
					
					
					
					
					
					if ("action_time".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetAction_time(value);
					}
					
					
					
					
					
					if ("return_type".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetReturn_type(value);
					}
					
					
					
					
					
					if ("sub_return_sn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSub_return_sn(value);
					}
					
					
					
					
					
					if ("sub_return_flag".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSub_return_flag(value);
					}
					
					
					
					
					
					if ("memo".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetMemo(value);
					}
					
					
					
					
					
					if ("user".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetUser(value);
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
		
		
		public void Write(ReturnOrderStatus structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetId() != null) {
				
				oprot.WriteFieldBegin("id");
				oprot.WriteString(structs.GetId());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("id can not be null!");
			}
			
			
			if(structs.GetWarehouse() != null) {
				
				oprot.WriteFieldBegin("warehouse");
				oprot.WriteString(structs.GetWarehouse());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("warehouse can not be null!");
			}
			
			
			if(structs.GetShipment_no() != null) {
				
				oprot.WriteFieldBegin("shipment_no");
				oprot.WriteString(structs.GetShipment_no());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("shipment_no can not be null!");
			}
			
			
			if(structs.GetErp_order_no() != null) {
				
				oprot.WriteFieldBegin("erp_order_no");
				oprot.WriteString(structs.GetErp_order_no());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("erp_order_no can not be null!");
			}
			
			
			if(structs.GetReference_no() != null) {
				
				oprot.WriteFieldBegin("reference_no");
				oprot.WriteString(structs.GetReference_no());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("reference_no can not be null!");
			}
			
			
			if(structs.GetOrder_type() != null) {
				
				oprot.WriteFieldBegin("order_type");
				oprot.WriteString(structs.GetOrder_type());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("order_type can not be null!");
			}
			
			
			if(structs.GetStatus_code() != null) {
				
				oprot.WriteFieldBegin("status_code");
				oprot.WriteString(structs.GetStatus_code());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("status_code can not be null!");
			}
			
			
			if(structs.GetAction_time() != null) {
				
				oprot.WriteFieldBegin("action_time");
				oprot.WriteString(structs.GetAction_time());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("action_time can not be null!");
			}
			
			
			if(structs.GetReturn_type() != null) {
				
				oprot.WriteFieldBegin("return_type");
				oprot.WriteString(structs.GetReturn_type());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("return_type can not be null!");
			}
			
			
			if(structs.GetSub_return_sn() != null) {
				
				oprot.WriteFieldBegin("sub_return_sn");
				oprot.WriteString(structs.GetSub_return_sn());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("sub_return_sn can not be null!");
			}
			
			
			if(structs.GetSub_return_flag() != null) {
				
				oprot.WriteFieldBegin("sub_return_flag");
				oprot.WriteString(structs.GetSub_return_flag());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("sub_return_flag can not be null!");
			}
			
			
			if(structs.GetMemo() != null) {
				
				oprot.WriteFieldBegin("memo");
				oprot.WriteString(structs.GetMemo());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("memo can not be null!");
			}
			
			
			if(structs.GetUser() != null) {
				
				oprot.WriteFieldBegin("user");
				oprot.WriteString(structs.GetUser());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("user can not be null!");
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
		
		
		public void Validate(ReturnOrderStatus bean){
			
			
		}
		
	}
	
}