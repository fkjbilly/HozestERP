using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.vop.vendor{
	
	
	
	public class VendorInfoHelper : TBeanSerializer<VendorInfo>
	{
		
		public static VendorInfoHelper OBJ = new VendorInfoHelper();
		
		public static VendorInfoHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(VendorInfo structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("developerId".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetDeveloperId(value);
					}
					
					
					
					
					
					if ("account".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetAccount(value);
					}
					
					
					
					
					
					if ("name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetName(value);
					}
					
					
					
					
					
					if ("linkName".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetLinkName(value);
					}
					
					
					
					
					
					if ("mobileNo".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetMobileNo(value);
					}
					
					
					
					
					
					if ("email".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetEmail(value);
					}
					
					
					
					
					
					if ("registerDate".Equals(schemeField.Trim())){
						
						needSkip = false;
						System.DateTime? value;
						value = Osp.Sdk.Util.TimeUtil.FromUnixTime(iprot.ReadI64()); 
						
						structs.SetRegisterDate(value);
					}
					
					
					
					
					
					if ("province".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetProvince(value);
					}
					
					
					
					
					
					if ("cityName".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCityName(value);
					}
					
					
					
					
					
					if ("county".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCounty(value);
					}
					
					
					
					
					
					if ("address".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetAddress(value);
					}
					
					
					
					
					
					if ("type".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetType(value);
					}
					
					
					
					
					
					if ("emailStatus".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetEmailStatus(value);
					}
					
					
					
					
					
					if ("cellStatus".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetCellStatus(value);
					}
					
					
					
					
					
					if ("businessLicense".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBusinessLicense(value);
					}
					
					
					
					
					
					if ("licensePicNum".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetLicensePicNum(value);
					}
					
					
					
					
					
					if ("organizationCode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOrganizationCode(value);
					}
					
					
					
					
					
					if ("organizationPicNum".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetOrganizationPicNum(value);
					}
					
					
					
					
					
					if ("taxPicNum".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetTaxPicNum(value);
					}
					
					
					
					
					
					if ("taxNum".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTaxNum(value);
					}
					
					
					
					
					
					if ("accountLicense".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetAccountLicense(value);
					}
					
					
					
					
					
					if ("accountName".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetAccountName(value);
					}
					
					
					
					
					
					if ("accountNum".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetAccountNum(value);
					}
					
					
					
					
					
					if ("vipName".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetVipName(value);
					}
					
					
					
					
					
					if ("accessToken".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetAccessToken(value);
					}
					
					
					
					
					
					if ("status".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetStatus(value);
					}
					
					
					
					
					
					if ("dealStatus".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetDealStatus(value);
					}
					
					
					
					
					
					if ("submitStatus".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetSubmitStatus(value);
					}
					
					
					
					
					
					if ("registEmail".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetRegistEmail(value);
					}
					
					
					
					
					
					if ("registMobileNo".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetRegistMobileNo(value);
					}
					
					
					
					
					
					if ("updateDate".Equals(schemeField.Trim())){
						
						needSkip = false;
						System.DateTime? value;
						value = Osp.Sdk.Util.TimeUtil.FromUnixTime(iprot.ReadI64()); 
						
						structs.SetUpdateDate(value);
					}
					
					
					
					
					
					if ("userId".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetUserId(value);
					}
					
					
					
					
					
					if ("vendorId".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetVendorId(value);
					}
					
					
					
					
					
					if ("vendorPkid".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetVendorPkid(value);
					}
					
					
					
					
					
					if ("vendorLoginName".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetVendorLoginName(value);
					}
					
					
					
					
					
					if ("taxPicNumDev".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetTaxPicNumDev(value);
					}
					
					
					
					
					
					if ("licensePicNumDev".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetLicensePicNumDev(value);
					}
					
					
					
					
					
					if ("organizationPicNumDev".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetOrganizationPicNumDev(value);
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
		
		
		public void Write(VendorInfo structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetDeveloperId() != null) {
				
				oprot.WriteFieldBegin("developerId");
				oprot.WriteI32((int)structs.GetDeveloperId()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("developerId can not be null!");
			}
			
			
			if(structs.GetAccount() != null) {
				
				oprot.WriteFieldBegin("account");
				oprot.WriteString(structs.GetAccount());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("account can not be null!");
			}
			
			
			if(structs.GetName() != null) {
				
				oprot.WriteFieldBegin("name");
				oprot.WriteString(structs.GetName());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetLinkName() != null) {
				
				oprot.WriteFieldBegin("linkName");
				oprot.WriteString(structs.GetLinkName());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetMobileNo() != null) {
				
				oprot.WriteFieldBegin("mobileNo");
				oprot.WriteString(structs.GetMobileNo());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetEmail() != null) {
				
				oprot.WriteFieldBegin("email");
				oprot.WriteString(structs.GetEmail());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetRegisterDate() != null) {
				
				oprot.WriteFieldBegin("registerDate");
				oprot.WriteI64(Osp.Sdk.Util.TimeUtil.ToUnixTime((System.DateTime)structs.GetRegisterDate())); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetProvince() != null) {
				
				oprot.WriteFieldBegin("province");
				oprot.WriteString(structs.GetProvince());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCityName() != null) {
				
				oprot.WriteFieldBegin("cityName");
				oprot.WriteString(structs.GetCityName());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCounty() != null) {
				
				oprot.WriteFieldBegin("county");
				oprot.WriteString(structs.GetCounty());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetAddress() != null) {
				
				oprot.WriteFieldBegin("address");
				oprot.WriteString(structs.GetAddress());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetType() != null) {
				
				oprot.WriteFieldBegin("type");
				oprot.WriteI32((int)structs.GetType()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetEmailStatus() != null) {
				
				oprot.WriteFieldBegin("emailStatus");
				oprot.WriteI32((int)structs.GetEmailStatus()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCellStatus() != null) {
				
				oprot.WriteFieldBegin("cellStatus");
				oprot.WriteI32((int)structs.GetCellStatus()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBusinessLicense() != null) {
				
				oprot.WriteFieldBegin("businessLicense");
				oprot.WriteString(structs.GetBusinessLicense());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetLicensePicNum() != null) {
				
				oprot.WriteFieldBegin("licensePicNum");
				oprot.WriteI32((int)structs.GetLicensePicNum()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrganizationCode() != null) {
				
				oprot.WriteFieldBegin("organizationCode");
				oprot.WriteString(structs.GetOrganizationCode());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrganizationPicNum() != null) {
				
				oprot.WriteFieldBegin("organizationPicNum");
				oprot.WriteI32((int)structs.GetOrganizationPicNum()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTaxPicNum() != null) {
				
				oprot.WriteFieldBegin("taxPicNum");
				oprot.WriteI32((int)structs.GetTaxPicNum()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTaxNum() != null) {
				
				oprot.WriteFieldBegin("taxNum");
				oprot.WriteString(structs.GetTaxNum());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetAccountLicense() != null) {
				
				oprot.WriteFieldBegin("accountLicense");
				oprot.WriteString(structs.GetAccountLicense());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetAccountName() != null) {
				
				oprot.WriteFieldBegin("accountName");
				oprot.WriteString(structs.GetAccountName());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetAccountNum() != null) {
				
				oprot.WriteFieldBegin("accountNum");
				oprot.WriteString(structs.GetAccountNum());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetVipName() != null) {
				
				oprot.WriteFieldBegin("vipName");
				oprot.WriteString(structs.GetVipName());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetAccessToken() != null) {
				
				oprot.WriteFieldBegin("accessToken");
				oprot.WriteString(structs.GetAccessToken());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetStatus() != null) {
				
				oprot.WriteFieldBegin("status");
				oprot.WriteI32((int)structs.GetStatus()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetDealStatus() != null) {
				
				oprot.WriteFieldBegin("dealStatus");
				oprot.WriteI32((int)structs.GetDealStatus()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSubmitStatus() != null) {
				
				oprot.WriteFieldBegin("submitStatus");
				oprot.WriteI32((int)structs.GetSubmitStatus()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetRegistEmail() != null) {
				
				oprot.WriteFieldBegin("registEmail");
				oprot.WriteString(structs.GetRegistEmail());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetRegistMobileNo() != null) {
				
				oprot.WriteFieldBegin("registMobileNo");
				oprot.WriteString(structs.GetRegistMobileNo());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetUpdateDate() != null) {
				
				oprot.WriteFieldBegin("updateDate");
				oprot.WriteI64(Osp.Sdk.Util.TimeUtil.ToUnixTime((System.DateTime)structs.GetUpdateDate())); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetUserId() != null) {
				
				oprot.WriteFieldBegin("userId");
				oprot.WriteString(structs.GetUserId());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetVendorId() != null) {
				
				oprot.WriteFieldBegin("vendorId");
				oprot.WriteI32((int)structs.GetVendorId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetVendorPkid() != null) {
				
				oprot.WriteFieldBegin("vendorPkid");
				oprot.WriteI32((int)structs.GetVendorPkid()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetVendorLoginName() != null) {
				
				oprot.WriteFieldBegin("vendorLoginName");
				oprot.WriteString(structs.GetVendorLoginName());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTaxPicNumDev() != null) {
				
				oprot.WriteFieldBegin("taxPicNumDev");
				oprot.WriteI32((int)structs.GetTaxPicNumDev()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetLicensePicNumDev() != null) {
				
				oprot.WriteFieldBegin("licensePicNumDev");
				oprot.WriteI32((int)structs.GetLicensePicNumDev()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrganizationPicNumDev() != null) {
				
				oprot.WriteFieldBegin("organizationPicNumDev");
				oprot.WriteI32((int)structs.GetOrganizationPicNumDev()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(VendorInfo bean){
			
			
		}
		
	}
	
}