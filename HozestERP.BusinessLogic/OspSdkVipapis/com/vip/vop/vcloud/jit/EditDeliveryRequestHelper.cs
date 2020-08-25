using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.vop.vcloud.jit{
	
	
	
	public class EditDeliveryRequestHelper : TBeanSerializer<EditDeliveryRequest>
	{
		
		public static EditDeliveryRequestHelper OBJ = new EditDeliveryRequestHelper();
		
		public static EditDeliveryRequestHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(EditDeliveryRequest structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("vendorId".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetVendorId(value);
					}
					
					
					
					
					
					if ("poNo".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPoNo(value);
					}
					
					
					
					
					
					if ("deliveryNo".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetDeliveryNo(value);
					}
					
					
					
					
					
					if ("vipWarehouse".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetVipWarehouse(value);
					}
					
					
					
					
					
					if ("deliveryMethod".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetDeliveryMethod(value);
					}
					
					
					
					
					
					if ("deliveryTime".Equals(schemeField.Trim())){
						
						needSkip = false;
						System.DateTime? value;
						value = Osp.Sdk.Util.TimeUtil.FromUnixTime(iprot.ReadI64()); 
						
						structs.SetDeliveryTime(value);
					}
					
					
					
					
					
					if ("arrivalTime".Equals(schemeField.Trim())){
						
						needSkip = false;
						System.DateTime? value;
						value = Osp.Sdk.Util.TimeUtil.FromUnixTime(iprot.ReadI64()); 
						
						structs.SetArrivalTime(value);
					}
					
					
					
					
					
					if ("carrierCode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCarrierCode(value);
					}
					
					
					
					
					
					if ("carrierName".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCarrierName(value);
					}
					
					
					
					
					
					if ("erpWarehouse".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetErpWarehouse(value);
					}
					
					
					
					
					
					if ("storageNo".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetStorageNo(value);
					}
					
					
					
					
					
					if ("raceTime".Equals(schemeField.Trim())){
						
						needSkip = false;
						System.DateTime? value;
						value = Osp.Sdk.Util.TimeUtil.FromUnixTime(iprot.ReadI64()); 
						
						structs.SetRaceTime(value);
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
		
		
		public void Write(EditDeliveryRequest structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetVendorId() != null) {
				
				oprot.WriteFieldBegin("vendorId");
				oprot.WriteI32((int)structs.GetVendorId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPoNo() != null) {
				
				oprot.WriteFieldBegin("poNo");
				oprot.WriteString(structs.GetPoNo());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetDeliveryNo() != null) {
				
				oprot.WriteFieldBegin("deliveryNo");
				oprot.WriteString(structs.GetDeliveryNo());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetVipWarehouse() != null) {
				
				oprot.WriteFieldBegin("vipWarehouse");
				oprot.WriteString(structs.GetVipWarehouse());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetDeliveryMethod() != null) {
				
				oprot.WriteFieldBegin("deliveryMethod");
				oprot.WriteI32((int)structs.GetDeliveryMethod()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetDeliveryTime() != null) {
				
				oprot.WriteFieldBegin("deliveryTime");
				oprot.WriteI64(Osp.Sdk.Util.TimeUtil.ToUnixTime((System.DateTime)structs.GetDeliveryTime())); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetArrivalTime() != null) {
				
				oprot.WriteFieldBegin("arrivalTime");
				oprot.WriteI64(Osp.Sdk.Util.TimeUtil.ToUnixTime((System.DateTime)structs.GetArrivalTime())); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCarrierCode() != null) {
				
				oprot.WriteFieldBegin("carrierCode");
				oprot.WriteString(structs.GetCarrierCode());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCarrierName() != null) {
				
				oprot.WriteFieldBegin("carrierName");
				oprot.WriteString(structs.GetCarrierName());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetErpWarehouse() != null) {
				
				oprot.WriteFieldBegin("erpWarehouse");
				oprot.WriteString(structs.GetErpWarehouse());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetStorageNo() != null) {
				
				oprot.WriteFieldBegin("storageNo");
				oprot.WriteString(structs.GetStorageNo());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetRaceTime() != null) {
				
				oprot.WriteFieldBegin("raceTime");
				oprot.WriteI64(Osp.Sdk.Util.TimeUtil.ToUnixTime((System.DateTime)structs.GetRaceTime())); 
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(EditDeliveryRequest bean){
			
			
		}
		
	}
	
}