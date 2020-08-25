using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.delivery{
	
	
	
	public class DeliveryListHelper : BeanSerializer<DeliveryList>
	{
		
		public static DeliveryListHelper OBJ = new DeliveryListHelper();
		
		public static DeliveryListHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(DeliveryList structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("vendor_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetVendor_id(value);
					}
					
					
					
					
					
					if ("vendor_name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetVendor_name(value);
					}
					
					
					
					
					
					if ("po_no".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPo_no(value);
					}
					
					
					
					
					
					if ("delivery_no".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetDelivery_no(value);
					}
					
					
					
					
					
					if ("warehouse".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetWarehouse(value);
					}
					
					
					
					
					
					if ("storage_no".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetStorage_no(value);
					}
					
					
					
					
					
					if ("out_time".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOut_time(value);
					}
					
					
					
					
					
					if ("arrive_time".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetArrive_time(value);
					}
					
					
					
					
					
					if ("real_arrive_time".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetReal_arrive_time(value);
					}
					
					
					
					
					
					if ("race_time".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetRace_time(value);
					}
					
					
					
					
					
					if ("real_race_time".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetReal_race_time(value);
					}
					
					
					
					
					
					if ("out_flag".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOut_flag(value);
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
		
		
		public void Write(DeliveryList structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetVendor_id() != null) {
				
				oprot.WriteFieldBegin("vendor_id");
				oprot.WriteString(structs.GetVendor_id());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetVendor_name() != null) {
				
				oprot.WriteFieldBegin("vendor_name");
				oprot.WriteString(structs.GetVendor_name());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPo_no() != null) {
				
				oprot.WriteFieldBegin("po_no");
				oprot.WriteString(structs.GetPo_no());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetDelivery_no() != null) {
				
				oprot.WriteFieldBegin("delivery_no");
				oprot.WriteString(structs.GetDelivery_no());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetWarehouse() != null) {
				
				oprot.WriteFieldBegin("warehouse");
				oprot.WriteString(structs.GetWarehouse());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetStorage_no() != null) {
				
				oprot.WriteFieldBegin("storage_no");
				oprot.WriteString(structs.GetStorage_no());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOut_time() != null) {
				
				oprot.WriteFieldBegin("out_time");
				oprot.WriteString(structs.GetOut_time());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetArrive_time() != null) {
				
				oprot.WriteFieldBegin("arrive_time");
				oprot.WriteString(structs.GetArrive_time());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetReal_arrive_time() != null) {
				
				oprot.WriteFieldBegin("real_arrive_time");
				oprot.WriteString(structs.GetReal_arrive_time());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetRace_time() != null) {
				
				oprot.WriteFieldBegin("race_time");
				oprot.WriteString(structs.GetRace_time());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetReal_race_time() != null) {
				
				oprot.WriteFieldBegin("real_race_time");
				oprot.WriteString(structs.GetReal_race_time());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOut_flag() != null) {
				
				oprot.WriteFieldBegin("out_flag");
				oprot.WriteString(structs.GetOut_flag());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCreate_time() != null) {
				
				oprot.WriteFieldBegin("create_time");
				oprot.WriteString(structs.GetCreate_time());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(DeliveryList bean){
			
			
		}
		
	}
	
}