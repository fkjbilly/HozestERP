using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.vop.vcloud.jit{
	
	
	
	public class DeliveryHelper : TBeanSerializer<Delivery>
	{
		
		public static DeliveryHelper OBJ = new DeliveryHelper();
		
		public static DeliveryHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(Delivery structs, Protocol iprot){
			
			
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
					
					
					
					
					
					if ("vendorName".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetVendorName(value);
					}
					
					
					
					
					
					if ("poNo".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPoNo(value);
					}
					
					
					
					
					
					if ("storageNo".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetStorageNo(value);
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
					
					
					
					
					
					if ("outTime".Equals(schemeField.Trim())){
						
						needSkip = false;
						System.DateTime? value;
						value = Osp.Sdk.Util.TimeUtil.FromUnixTime(iprot.ReadI64()); 
						
						structs.SetOutTime(value);
					}
					
					
					
					
					
					if ("outFlag".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetOutFlag(value);
					}
					
					
					
					
					
					if ("createTime".Equals(schemeField.Trim())){
						
						needSkip = false;
						System.DateTime? value;
						value = Osp.Sdk.Util.TimeUtil.FromUnixTime(iprot.ReadI64()); 
						
						structs.SetCreateTime(value);
					}
					
					
					
					
					
					if ("arrivalTime".Equals(schemeField.Trim())){
						
						needSkip = false;
						System.DateTime? value;
						value = Osp.Sdk.Util.TimeUtil.FromUnixTime(iprot.ReadI64()); 
						
						structs.SetArrivalTime(value);
					}
					
					
					
					
					
					if ("realArrivalTime".Equals(schemeField.Trim())){
						
						needSkip = false;
						System.DateTime? value;
						value = Osp.Sdk.Util.TimeUtil.FromUnixTime(iprot.ReadI64()); 
						
						structs.SetRealArrivalTime(value);
					}
					
					
					
					
					
					if ("raceTime".Equals(schemeField.Trim())){
						
						needSkip = false;
						System.DateTime? value;
						value = Osp.Sdk.Util.TimeUtil.FromUnixTime(iprot.ReadI64()); 
						
						structs.SetRaceTime(value);
					}
					
					
					
					
					
					if ("realRaceTime".Equals(schemeField.Trim())){
						
						needSkip = false;
						System.DateTime? value;
						value = Osp.Sdk.Util.TimeUtil.FromUnixTime(iprot.ReadI64()); 
						
						structs.SetRealRaceTime(value);
					}
					
					
					
					
					
					if ("outFlagDesc".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOutFlagDesc(value);
					}
					
					
					
					
					
					if ("erpWarehouse".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetErpWarehouse(value);
					}
					
					
					
					
					
					if ("brandName".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBrandName(value);
					}
					
					
					
					
					
					if ("totalDeliveryNum".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetTotalDeliveryNum(value);
					}
					
					
					
					
					
					if ("totalBox".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetTotalBox(value);
					}
					
					
					
					
					
					if ("deliveryMethodDesc".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetDeliveryMethodDesc(value);
					}
					
					
					
					
					
					if ("id".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetId(value);
					}
					
					
					
					
					
					if ("isSubmit".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetIsSubmit(value);
					}
					
					
					
					
					
					if ("po".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.vop.vcloud.jit.Po value;
						
						value = new com.vip.vop.vcloud.jit.Po();
						com.vip.vop.vcloud.jit.PoHelper.getInstance().Read(value, iprot);
						
						structs.SetPo(value);
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
		
		
		public void Write(Delivery structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetVendorId() != null) {
				
				oprot.WriteFieldBegin("vendorId");
				oprot.WriteI32((int)structs.GetVendorId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetVendorName() != null) {
				
				oprot.WriteFieldBegin("vendorName");
				oprot.WriteString(structs.GetVendorName());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPoNo() != null) {
				
				oprot.WriteFieldBegin("poNo");
				oprot.WriteString(structs.GetPoNo());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetStorageNo() != null) {
				
				oprot.WriteFieldBegin("storageNo");
				oprot.WriteString(structs.GetStorageNo());
				
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
			
			
			if(structs.GetOutTime() != null) {
				
				oprot.WriteFieldBegin("outTime");
				oprot.WriteI64(Osp.Sdk.Util.TimeUtil.ToUnixTime((System.DateTime)structs.GetOutTime())); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOutFlag() != null) {
				
				oprot.WriteFieldBegin("outFlag");
				oprot.WriteI32((int)structs.GetOutFlag()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCreateTime() != null) {
				
				oprot.WriteFieldBegin("createTime");
				oprot.WriteI64(Osp.Sdk.Util.TimeUtil.ToUnixTime((System.DateTime)structs.GetCreateTime())); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetArrivalTime() != null) {
				
				oprot.WriteFieldBegin("arrivalTime");
				oprot.WriteI64(Osp.Sdk.Util.TimeUtil.ToUnixTime((System.DateTime)structs.GetArrivalTime())); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetRealArrivalTime() != null) {
				
				oprot.WriteFieldBegin("realArrivalTime");
				oprot.WriteI64(Osp.Sdk.Util.TimeUtil.ToUnixTime((System.DateTime)structs.GetRealArrivalTime())); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetRaceTime() != null) {
				
				oprot.WriteFieldBegin("raceTime");
				oprot.WriteI64(Osp.Sdk.Util.TimeUtil.ToUnixTime((System.DateTime)structs.GetRaceTime())); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetRealRaceTime() != null) {
				
				oprot.WriteFieldBegin("realRaceTime");
				oprot.WriteI64(Osp.Sdk.Util.TimeUtil.ToUnixTime((System.DateTime)structs.GetRealRaceTime())); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOutFlagDesc() != null) {
				
				oprot.WriteFieldBegin("outFlagDesc");
				oprot.WriteString(structs.GetOutFlagDesc());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetErpWarehouse() != null) {
				
				oprot.WriteFieldBegin("erpWarehouse");
				oprot.WriteString(structs.GetErpWarehouse());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBrandName() != null) {
				
				oprot.WriteFieldBegin("brandName");
				oprot.WriteString(structs.GetBrandName());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTotalDeliveryNum() != null) {
				
				oprot.WriteFieldBegin("totalDeliveryNum");
				oprot.WriteI32((int)structs.GetTotalDeliveryNum()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTotalBox() != null) {
				
				oprot.WriteFieldBegin("totalBox");
				oprot.WriteI32((int)structs.GetTotalBox()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetDeliveryMethodDesc() != null) {
				
				oprot.WriteFieldBegin("deliveryMethodDesc");
				oprot.WriteString(structs.GetDeliveryMethodDesc());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetId() != null) {
				
				oprot.WriteFieldBegin("id");
				oprot.WriteI64((long)structs.GetId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetIsSubmit() != null) {
				
				oprot.WriteFieldBegin("isSubmit");
				oprot.WriteI64((long)structs.GetIsSubmit()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPo() != null) {
				
				oprot.WriteFieldBegin("po");
				
				com.vip.vop.vcloud.jit.PoHelper.getInstance().Write(structs.GetPo(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(Delivery bean){
			
			
		}
		
	}
	
}