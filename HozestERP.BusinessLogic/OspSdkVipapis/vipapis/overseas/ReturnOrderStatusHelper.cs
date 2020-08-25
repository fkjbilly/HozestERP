using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.overseas{
	
	
	
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
						long value;
						value = iprot.ReadI64(); 
						
						structs.SetId(value);
					}
					
					
					
					
					
					if ("shipment_no".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetShipment_no(value);
					}
					
					
					
					
					
					if ("erp_order_sn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetErp_order_sn(value);
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
					
					
					
					
					
					if ("create_time".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCreate_time(value);
					}
					
					
					
					
					
					if ("memo".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetMemo(value);
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
				oprot.WriteI64((long)structs.GetId()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("id can not be null!");
			}
			
			
			if(structs.GetShipment_no() != null) {
				
				oprot.WriteFieldBegin("shipment_no");
				oprot.WriteString(structs.GetShipment_no());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("shipment_no can not be null!");
			}
			
			
			if(structs.GetErp_order_sn() != null) {
				
				oprot.WriteFieldBegin("erp_order_sn");
				oprot.WriteString(structs.GetErp_order_sn());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetReference_no() != null) {
				
				oprot.WriteFieldBegin("reference_no");
				oprot.WriteString(structs.GetReference_no());
				
				oprot.WriteFieldEnd();
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
			
			
			if(structs.GetCreate_time() != null) {
				
				oprot.WriteFieldBegin("create_time");
				oprot.WriteString(structs.GetCreate_time());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("create_time can not be null!");
			}
			
			
			if(structs.GetMemo() != null) {
				
				oprot.WriteFieldBegin("memo");
				oprot.WriteString(structs.GetMemo());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(ReturnOrderStatus bean){
			
			
		}
		
	}
	
}