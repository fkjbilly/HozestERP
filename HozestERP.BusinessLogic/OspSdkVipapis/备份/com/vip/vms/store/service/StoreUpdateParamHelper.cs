using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.vms.store.service{
	
	
	
	public class StoreUpdateParamHelper : BeanSerializer<StoreUpdateParam>
	{
		
		public static StoreUpdateParamHelper OBJ = new StoreUpdateParamHelper();
		
		public static StoreUpdateParamHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(StoreUpdateParam structs, Protocol iprot){
			
			
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
					
					
					
					
					
					if ("storeName".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetStoreName(value);
					}
					
					
					
					
					
					if ("province".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetProvince(value);
					}
					
					
					
					
					
					if ("city".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCity(value);
					}
					
					
					
					
					
					if ("district".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetDistrict(value);
					}
					
					
					
					
					
					if ("street".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetStreet(value);
					}
					
					
					
					
					
					if ("address".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetAddress(value);
					}
					
					
					
					
					
					if ("contact".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetContact(value);
					}
					
					
					
					
					
					if ("tel".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTel(value);
					}
					
					
					
					
					
					if ("country".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCountry(value);
					}
					
					
					
					
					
					if ("zipcode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetZipcode(value);
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
		
		
		public void Write(StoreUpdateParam structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetVendor_id() != null) {
				
				oprot.WriteFieldBegin("vendor_id");
				oprot.WriteString(structs.GetVendor_id());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("vendor_id can not be null!");
			}
			
			
			if(structs.GetStoreName() != null) {
				
				oprot.WriteFieldBegin("storeName");
				oprot.WriteString(structs.GetStoreName());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("storeName can not be null!");
			}
			
			
			if(structs.GetProvince() != null) {
				
				oprot.WriteFieldBegin("province");
				oprot.WriteString(structs.GetProvince());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("province can not be null!");
			}
			
			
			if(structs.GetCity() != null) {
				
				oprot.WriteFieldBegin("city");
				oprot.WriteString(structs.GetCity());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("city can not be null!");
			}
			
			
			if(structs.GetDistrict() != null) {
				
				oprot.WriteFieldBegin("district");
				oprot.WriteString(structs.GetDistrict());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("district can not be null!");
			}
			
			
			if(structs.GetStreet() != null) {
				
				oprot.WriteFieldBegin("street");
				oprot.WriteString(structs.GetStreet());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("street can not be null!");
			}
			
			
			if(structs.GetAddress() != null) {
				
				oprot.WriteFieldBegin("address");
				oprot.WriteString(structs.GetAddress());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("address can not be null!");
			}
			
			
			if(structs.GetContact() != null) {
				
				oprot.WriteFieldBegin("contact");
				oprot.WriteString(structs.GetContact());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("contact can not be null!");
			}
			
			
			if(structs.GetTel() != null) {
				
				oprot.WriteFieldBegin("tel");
				oprot.WriteString(structs.GetTel());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("tel can not be null!");
			}
			
			
			if(structs.GetCountry() != null) {
				
				oprot.WriteFieldBegin("country");
				oprot.WriteString(structs.GetCountry());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetZipcode() != null) {
				
				oprot.WriteFieldBegin("zipcode");
				oprot.WriteString(structs.GetZipcode());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(StoreUpdateParam bean){
			
			
		}
		
	}
	
}