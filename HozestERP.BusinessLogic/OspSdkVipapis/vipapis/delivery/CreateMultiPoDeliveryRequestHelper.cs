using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.delivery{
	
	
	
	public class CreateMultiPoDeliveryRequestHelper : TBeanSerializer<CreateMultiPoDeliveryRequest>
	{
		
		public static CreateMultiPoDeliveryRequestHelper OBJ = new CreateMultiPoDeliveryRequestHelper();
		
		public static CreateMultiPoDeliveryRequestHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(CreateMultiPoDeliveryRequest structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("vendor_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetVendor_id(value);
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
						vipapis.common.Warehouse? value;
						
						value = vipapis.common.WarehouseUtil.FindByName(iprot.ReadString());
						
						structs.SetWarehouse(value);
					}
					
					
					
					
					
					if ("delivery_time".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetDelivery_time(value);
					}
					
					
					
					
					
					if ("arrival_time".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetArrival_time(value);
					}
					
					
					
					
					
					if ("carrier_code".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCarrier_code(value);
					}
					
					
					
					
					
					if ("delivery_method".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetDelivery_method(value);
					}
					
					
					
					
					
					if ("store_sn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetStore_sn(value);
					}
					
					
					
					
					
					if ("jit_type".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetJit_type(value);
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
		
		
		public void Write(CreateMultiPoDeliveryRequest structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetVendor_id() != null) {
				
				oprot.WriteFieldBegin("vendor_id");
				oprot.WriteI32((int)structs.GetVendor_id()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("vendor_id can not be null!");
			}
			
			
			if(structs.GetPo_no() != null) {
				
				oprot.WriteFieldBegin("po_no");
				oprot.WriteString(structs.GetPo_no());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("po_no can not be null!");
			}
			
			
			if(structs.GetDelivery_no() != null) {
				
				oprot.WriteFieldBegin("delivery_no");
				oprot.WriteString(structs.GetDelivery_no());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("delivery_no can not be null!");
			}
			
			
			if(structs.GetWarehouse() != null) {
				
				oprot.WriteFieldBegin("warehouse");
				oprot.WriteString(structs.GetWarehouse().ToString());  
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("warehouse can not be null!");
			}
			
			
			if(structs.GetDelivery_time() != null) {
				
				oprot.WriteFieldBegin("delivery_time");
				oprot.WriteString(structs.GetDelivery_time());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("delivery_time can not be null!");
			}
			
			
			if(structs.GetArrival_time() != null) {
				
				oprot.WriteFieldBegin("arrival_time");
				oprot.WriteString(structs.GetArrival_time());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("arrival_time can not be null!");
			}
			
			
			if(structs.GetCarrier_code() != null) {
				
				oprot.WriteFieldBegin("carrier_code");
				oprot.WriteString(structs.GetCarrier_code());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("carrier_code can not be null!");
			}
			
			
			if(structs.GetDelivery_method() != null) {
				
				oprot.WriteFieldBegin("delivery_method");
				oprot.WriteString(structs.GetDelivery_method());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("delivery_method can not be null!");
			}
			
			
			if(structs.GetStore_sn() != null) {
				
				oprot.WriteFieldBegin("store_sn");
				oprot.WriteString(structs.GetStore_sn());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetJit_type() != null) {
				
				oprot.WriteFieldBegin("jit_type");
				oprot.WriteI32((int)structs.GetJit_type()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(CreateMultiPoDeliveryRequest bean){
			
			
		}
		
	}
	
}