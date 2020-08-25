using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.vms.store.service{
	
	
	
	public class StoreQueryParamHelper : TBeanSerializer<StoreQueryParam>
	{
		
		public static StoreQueryParamHelper OBJ = new StoreQueryParamHelper();
		
		public static StoreQueryParamHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(StoreQueryParam structs, Protocol iprot){
			
			
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
					
					
					
					
					
					if ("storeCode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetStoreCode(value);
					}
					
					
					
					
					
					if ("storeName".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetStoreName(value);
					}
					
					
					
					
					
					if ("warehouse".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetWarehouse(value);
					}
					
					
					
					
					
					if ("pager".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.vms.common.Pager value;
						
						value = new com.vip.vms.common.Pager();
						com.vip.vms.common.PagerHelper.getInstance().Read(value, iprot);
						
						structs.SetPager(value);
					}
					
					
					
					
					
					if ("provinceCode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetProvinceCode(value);
					}
					
					
					
					
					
					if ("cityCode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCityCode(value);
					}
					
					
					
					
					
					if ("vendorCode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetVendorCode(value);
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
		
		
		public void Write(StoreQueryParam structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetVendor_id() != null) {
				
				oprot.WriteFieldBegin("vendor_id");
				oprot.WriteString(structs.GetVendor_id());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetStoreCode() != null) {
				
				oprot.WriteFieldBegin("storeCode");
				oprot.WriteString(structs.GetStoreCode());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetStoreName() != null) {
				
				oprot.WriteFieldBegin("storeName");
				oprot.WriteString(structs.GetStoreName());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetWarehouse() != null) {
				
				oprot.WriteFieldBegin("warehouse");
				oprot.WriteString(structs.GetWarehouse());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPager() != null) {
				
				oprot.WriteFieldBegin("pager");
				
				com.vip.vms.common.PagerHelper.getInstance().Write(structs.GetPager(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetProvinceCode() != null) {
				
				oprot.WriteFieldBegin("provinceCode");
				oprot.WriteString(structs.GetProvinceCode());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCityCode() != null) {
				
				oprot.WriteFieldBegin("cityCode");
				oprot.WriteString(structs.GetCityCode());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetVendorCode() != null) {
				
				oprot.WriteFieldBegin("vendorCode");
				oprot.WriteString(structs.GetVendorCode());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(StoreQueryParam bean){
			
			
		}
		
	}
	
}