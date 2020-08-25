using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.vop.vcloud.jit{
	
	
	
	public class GetDeliveryListRequestHelper : TBeanSerializer<GetDeliveryListRequest>
	{
		
		public static GetDeliveryListRequestHelper OBJ = new GetDeliveryListRequestHelper();
		
		public static GetDeliveryListRequestHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(GetDeliveryListRequest structs, Protocol iprot){
			
			
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
					
					
					
					
					
					if ("storageNo".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetStorageNo(value);
					}
					
					
					
					
					
					if ("vipWarehouse".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetVipWarehouse(value);
					}
					
					
					
					
					
					if ("outFlag".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetOutFlag(value);
					}
					
					
					
					
					
					if ("outTimeFrom".Equals(schemeField.Trim())){
						
						needSkip = false;
						System.DateTime? value;
						value = Osp.Sdk.Util.TimeUtil.FromUnixTime(iprot.ReadI64()); 
						
						structs.SetOutTimeFrom(value);
					}
					
					
					
					
					
					if ("outTimeTo".Equals(schemeField.Trim())){
						
						needSkip = false;
						System.DateTime? value;
						value = Osp.Sdk.Util.TimeUtil.FromUnixTime(iprot.ReadI64()); 
						
						structs.SetOutTimeTo(value);
					}
					
					
					
					
					
					if ("arrivalTimeFrom".Equals(schemeField.Trim())){
						
						needSkip = false;
						System.DateTime? value;
						value = Osp.Sdk.Util.TimeUtil.FromUnixTime(iprot.ReadI64()); 
						
						structs.SetArrivalTimeFrom(value);
					}
					
					
					
					
					
					if ("arrivalTimeTo".Equals(schemeField.Trim())){
						
						needSkip = false;
						System.DateTime? value;
						value = Osp.Sdk.Util.TimeUtil.FromUnixTime(iprot.ReadI64()); 
						
						structs.SetArrivalTimeTo(value);
					}
					
					
					
					
					
					if ("realArrivalTimeFrom".Equals(schemeField.Trim())){
						
						needSkip = false;
						System.DateTime? value;
						value = Osp.Sdk.Util.TimeUtil.FromUnixTime(iprot.ReadI64()); 
						
						structs.SetRealArrivalTimeFrom(value);
					}
					
					
					
					
					
					if ("realArrivalTimeTo".Equals(schemeField.Trim())){
						
						needSkip = false;
						System.DateTime? value;
						value = Osp.Sdk.Util.TimeUtil.FromUnixTime(iprot.ReadI64()); 
						
						structs.SetRealArrivalTimeTo(value);
					}
					
					
					
					
					
					if ("erpWarehouse".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetErpWarehouse(value);
					}
					
					
					
					
					
					if ("pagination".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.vop.vcloud.common.api.Pagination value;
						
						value = new com.vip.vop.vcloud.common.api.Pagination();
						com.vip.vop.vcloud.common.api.PaginationHelper.getInstance().Read(value, iprot);
						
						structs.SetPagination(value);
					}
					
					
					
					
					
					if ("deliveryTimeFrom".Equals(schemeField.Trim())){
						
						needSkip = false;
						System.DateTime? value;
						value = Osp.Sdk.Util.TimeUtil.FromUnixTime(iprot.ReadI64()); 
						
						structs.SetDeliveryTimeFrom(value);
					}
					
					
					
					
					
					if ("deliveryTimeTo".Equals(schemeField.Trim())){
						
						needSkip = false;
						System.DateTime? value;
						value = Osp.Sdk.Util.TimeUtil.FromUnixTime(iprot.ReadI64()); 
						
						structs.SetDeliveryTimeTo(value);
					}
					
					
					
					
					
					if ("needPush".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetNeedPush(value);
					}
					
					
					
					
					
					if ("userId".Equals(schemeField.Trim())){
						
						needSkip = false;
						long value;
						value = iprot.ReadI64(); 
						
						structs.SetUserId(value);
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
		
		
		public void Write(GetDeliveryListRequest structs, Protocol oprot){
			
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
			
			
			if(structs.GetStorageNo() != null) {
				
				oprot.WriteFieldBegin("storageNo");
				oprot.WriteString(structs.GetStorageNo());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetVipWarehouse() != null) {
				
				oprot.WriteFieldBegin("vipWarehouse");
				oprot.WriteString(structs.GetVipWarehouse());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOutFlag() != null) {
				
				oprot.WriteFieldBegin("outFlag");
				oprot.WriteI32((int)structs.GetOutFlag()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOutTimeFrom() != null) {
				
				oprot.WriteFieldBegin("outTimeFrom");
				oprot.WriteI64(Osp.Sdk.Util.TimeUtil.ToUnixTime((System.DateTime)structs.GetOutTimeFrom())); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOutTimeTo() != null) {
				
				oprot.WriteFieldBegin("outTimeTo");
				oprot.WriteI64(Osp.Sdk.Util.TimeUtil.ToUnixTime((System.DateTime)structs.GetOutTimeTo())); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetArrivalTimeFrom() != null) {
				
				oprot.WriteFieldBegin("arrivalTimeFrom");
				oprot.WriteI64(Osp.Sdk.Util.TimeUtil.ToUnixTime((System.DateTime)structs.GetArrivalTimeFrom())); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetArrivalTimeTo() != null) {
				
				oprot.WriteFieldBegin("arrivalTimeTo");
				oprot.WriteI64(Osp.Sdk.Util.TimeUtil.ToUnixTime((System.DateTime)structs.GetArrivalTimeTo())); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetRealArrivalTimeFrom() != null) {
				
				oprot.WriteFieldBegin("realArrivalTimeFrom");
				oprot.WriteI64(Osp.Sdk.Util.TimeUtil.ToUnixTime((System.DateTime)structs.GetRealArrivalTimeFrom())); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetRealArrivalTimeTo() != null) {
				
				oprot.WriteFieldBegin("realArrivalTimeTo");
				oprot.WriteI64(Osp.Sdk.Util.TimeUtil.ToUnixTime((System.DateTime)structs.GetRealArrivalTimeTo())); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetErpWarehouse() != null) {
				
				oprot.WriteFieldBegin("erpWarehouse");
				oprot.WriteString(structs.GetErpWarehouse());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPagination() != null) {
				
				oprot.WriteFieldBegin("pagination");
				
				com.vip.vop.vcloud.common.api.PaginationHelper.getInstance().Write(structs.GetPagination(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetDeliveryTimeFrom() != null) {
				
				oprot.WriteFieldBegin("deliveryTimeFrom");
				oprot.WriteI64(Osp.Sdk.Util.TimeUtil.ToUnixTime((System.DateTime)structs.GetDeliveryTimeFrom())); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetDeliveryTimeTo() != null) {
				
				oprot.WriteFieldBegin("deliveryTimeTo");
				oprot.WriteI64(Osp.Sdk.Util.TimeUtil.ToUnixTime((System.DateTime)structs.GetDeliveryTimeTo())); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetNeedPush() != null) {
				
				oprot.WriteFieldBegin("needPush");
				oprot.WriteI32((int)structs.GetNeedPush()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetUserId() != null) {
				
				oprot.WriteFieldBegin("userId");
				oprot.WriteI64((long)structs.GetUserId()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("userId can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(GetDeliveryListRequest bean){
			
			
		}
		
	}
	
}