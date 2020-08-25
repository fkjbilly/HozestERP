using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.vop.vendor{
	
	
	
	
	
	public class VendorInfo {
		
		///<summary>
		/// VOP开发者信息
		/// @sampleValue developerId 
		///</summary>
		
		private int? developerId_;
		
		///<summary>
		/// 
		/// @sampleValue account 
		///</summary>
		
		private string account_;
		
		///<summary>
		/// 
		/// @sampleValue name 
		///</summary>
		
		private string name_;
		
		///<summary>
		/// 
		/// @sampleValue linkName 
		///</summary>
		
		private string linkName_;
		
		///<summary>
		/// 
		/// @sampleValue mobileNo 
		///</summary>
		
		private string mobileNo_;
		
		///<summary>
		/// 
		/// @sampleValue email 
		///</summary>
		
		private string email_;
		
		///<summary>
		/// 
		/// @sampleValue registerDate 
		///</summary>
		
		private System.DateTime? registerDate_;
		
		///<summary>
		/// 
		/// @sampleValue province 
		///</summary>
		
		private string province_;
		
		///<summary>
		/// 
		/// @sampleValue cityName 
		///</summary>
		
		private string cityName_;
		
		///<summary>
		/// 
		/// @sampleValue county 
		///</summary>
		
		private string county_;
		
		///<summary>
		/// 
		/// @sampleValue address 
		///</summary>
		
		private string address_;
		
		///<summary>
		/// 
		/// @sampleValue type 
		///</summary>
		
		private int? type_;
		
		///<summary>
		/// Email验证状态
		/// @sampleValue emailStatus 1、未验证 2、已验证
		///</summary>
		
		private int? emailStatus_;
		
		///<summary>
		/// 手机验证状态
		/// @sampleValue cellStatus 1、未验证 2、已验证
		///</summary>
		
		private int? cellStatus_;
		
		///<summary>
		/// 
		/// @sampleValue businessLicense 
		///</summary>
		
		private string businessLicense_;
		
		///<summary>
		/// 
		/// @sampleValue licensePicNum 
		///</summary>
		
		private int? licensePicNum_;
		
		///<summary>
		/// 
		/// @sampleValue organizationCode 
		///</summary>
		
		private string organizationCode_;
		
		///<summary>
		/// 
		/// @sampleValue organizationPicNum 
		///</summary>
		
		private int? organizationPicNum_;
		
		///<summary>
		/// 
		/// @sampleValue taxPicNum 
		///</summary>
		
		private int? taxPicNum_;
		
		///<summary>
		/// 
		/// @sampleValue taxNum 
		///</summary>
		
		private string taxNum_;
		
		///<summary>
		/// 
		/// @sampleValue accountLicense 
		///</summary>
		
		private string accountLicense_;
		
		///<summary>
		/// 
		/// @sampleValue accountName 
		///</summary>
		
		private string accountName_;
		
		///<summary>
		/// 
		/// @sampleValue accountNum 
		///</summary>
		
		private string accountNum_;
		
		///<summary>
		/// 
		/// @sampleValue vipName 
		///</summary>
		
		private string vipName_;
		
		///<summary>
		/// 
		/// @sampleValue accessToken 
		///</summary>
		
		private string accessToken_;
		
		///<summary>
		/// 审核状态
		/// @sampleValue status 
		///</summary>
		
		private int? status_;
		
		///<summary>
		/// 管理处理状态
		/// @sampleValue dealStatus 0、未处理 1、处理中 2、认证通过 -1、认证失败
		///</summary>
		
		private int? dealStatus_;
		
		///<summary>
		/// 提交状态
		/// @sampleValue submitStatus 0、首次申请  1、重新申请 2、信息修改
		///</summary>
		
		private int? submitStatus_;
		
		///<summary>
		/// 
		/// @sampleValue registEmail 
		///</summary>
		
		private string registEmail_;
		
		///<summary>
		/// 
		/// @sampleValue registMobileNo 
		///</summary>
		
		private string registMobileNo_;
		
		///<summary>
		/// 
		/// @sampleValue updateDate 
		///</summary>
		
		private System.DateTime? updateDate_;
		
		///<summary>
		/// 
		/// @sampleValue userId 
		///</summary>
		
		private string userId_;
		
		///<summary>
		/// 
		/// @sampleValue vendorId 
		///</summary>
		
		private int? vendorId_;
		
		///<summary>
		/// 
		/// @sampleValue vendorPkid 
		///</summary>
		
		private int? vendorPkid_;
		
		///<summary>
		/// 
		/// @sampleValue vendorLoginName 
		///</summary>
		
		private string vendorLoginName_;
		
		///<summary>
		/// 
		/// @sampleValue taxPicNumDev 
		///</summary>
		
		private int? taxPicNumDev_;
		
		///<summary>
		/// 
		/// @sampleValue licensePicNumDev 
		///</summary>
		
		private int? licensePicNumDev_;
		
		///<summary>
		/// 
		/// @sampleValue organizationPicNumDev 
		///</summary>
		
		private int? organizationPicNumDev_;
		
		public int? GetDeveloperId(){
			return this.developerId_;
		}
		
		public void SetDeveloperId(int? value){
			this.developerId_ = value;
		}
		public string GetAccount(){
			return this.account_;
		}
		
		public void SetAccount(string value){
			this.account_ = value;
		}
		public string GetName(){
			return this.name_;
		}
		
		public void SetName(string value){
			this.name_ = value;
		}
		public string GetLinkName(){
			return this.linkName_;
		}
		
		public void SetLinkName(string value){
			this.linkName_ = value;
		}
		public string GetMobileNo(){
			return this.mobileNo_;
		}
		
		public void SetMobileNo(string value){
			this.mobileNo_ = value;
		}
		public string GetEmail(){
			return this.email_;
		}
		
		public void SetEmail(string value){
			this.email_ = value;
		}
		public System.DateTime? GetRegisterDate(){
			return this.registerDate_;
		}
		
		public void SetRegisterDate(System.DateTime? value){
			this.registerDate_ = value;
		}
		public string GetProvince(){
			return this.province_;
		}
		
		public void SetProvince(string value){
			this.province_ = value;
		}
		public string GetCityName(){
			return this.cityName_;
		}
		
		public void SetCityName(string value){
			this.cityName_ = value;
		}
		public string GetCounty(){
			return this.county_;
		}
		
		public void SetCounty(string value){
			this.county_ = value;
		}
		public string GetAddress(){
			return this.address_;
		}
		
		public void SetAddress(string value){
			this.address_ = value;
		}
		public int? GetType(){
			return this.type_;
		}
		
		public void SetType(int? value){
			this.type_ = value;
		}
		public int? GetEmailStatus(){
			return this.emailStatus_;
		}
		
		public void SetEmailStatus(int? value){
			this.emailStatus_ = value;
		}
		public int? GetCellStatus(){
			return this.cellStatus_;
		}
		
		public void SetCellStatus(int? value){
			this.cellStatus_ = value;
		}
		public string GetBusinessLicense(){
			return this.businessLicense_;
		}
		
		public void SetBusinessLicense(string value){
			this.businessLicense_ = value;
		}
		public int? GetLicensePicNum(){
			return this.licensePicNum_;
		}
		
		public void SetLicensePicNum(int? value){
			this.licensePicNum_ = value;
		}
		public string GetOrganizationCode(){
			return this.organizationCode_;
		}
		
		public void SetOrganizationCode(string value){
			this.organizationCode_ = value;
		}
		public int? GetOrganizationPicNum(){
			return this.organizationPicNum_;
		}
		
		public void SetOrganizationPicNum(int? value){
			this.organizationPicNum_ = value;
		}
		public int? GetTaxPicNum(){
			return this.taxPicNum_;
		}
		
		public void SetTaxPicNum(int? value){
			this.taxPicNum_ = value;
		}
		public string GetTaxNum(){
			return this.taxNum_;
		}
		
		public void SetTaxNum(string value){
			this.taxNum_ = value;
		}
		public string GetAccountLicense(){
			return this.accountLicense_;
		}
		
		public void SetAccountLicense(string value){
			this.accountLicense_ = value;
		}
		public string GetAccountName(){
			return this.accountName_;
		}
		
		public void SetAccountName(string value){
			this.accountName_ = value;
		}
		public string GetAccountNum(){
			return this.accountNum_;
		}
		
		public void SetAccountNum(string value){
			this.accountNum_ = value;
		}
		public string GetVipName(){
			return this.vipName_;
		}
		
		public void SetVipName(string value){
			this.vipName_ = value;
		}
		public string GetAccessToken(){
			return this.accessToken_;
		}
		
		public void SetAccessToken(string value){
			this.accessToken_ = value;
		}
		public int? GetStatus(){
			return this.status_;
		}
		
		public void SetStatus(int? value){
			this.status_ = value;
		}
		public int? GetDealStatus(){
			return this.dealStatus_;
		}
		
		public void SetDealStatus(int? value){
			this.dealStatus_ = value;
		}
		public int? GetSubmitStatus(){
			return this.submitStatus_;
		}
		
		public void SetSubmitStatus(int? value){
			this.submitStatus_ = value;
		}
		public string GetRegistEmail(){
			return this.registEmail_;
		}
		
		public void SetRegistEmail(string value){
			this.registEmail_ = value;
		}
		public string GetRegistMobileNo(){
			return this.registMobileNo_;
		}
		
		public void SetRegistMobileNo(string value){
			this.registMobileNo_ = value;
		}
		public System.DateTime? GetUpdateDate(){
			return this.updateDate_;
		}
		
		public void SetUpdateDate(System.DateTime? value){
			this.updateDate_ = value;
		}
		public string GetUserId(){
			return this.userId_;
		}
		
		public void SetUserId(string value){
			this.userId_ = value;
		}
		public int? GetVendorId(){
			return this.vendorId_;
		}
		
		public void SetVendorId(int? value){
			this.vendorId_ = value;
		}
		public int? GetVendorPkid(){
			return this.vendorPkid_;
		}
		
		public void SetVendorPkid(int? value){
			this.vendorPkid_ = value;
		}
		public string GetVendorLoginName(){
			return this.vendorLoginName_;
		}
		
		public void SetVendorLoginName(string value){
			this.vendorLoginName_ = value;
		}
		public int? GetTaxPicNumDev(){
			return this.taxPicNumDev_;
		}
		
		public void SetTaxPicNumDev(int? value){
			this.taxPicNumDev_ = value;
		}
		public int? GetLicensePicNumDev(){
			return this.licensePicNumDev_;
		}
		
		public void SetLicensePicNumDev(int? value){
			this.licensePicNumDev_ = value;
		}
		public int? GetOrganizationPicNumDev(){
			return this.organizationPicNumDev_;
		}
		
		public void SetOrganizationPicNumDev(int? value){
			this.organizationPicNumDev_ = value;
		}
		
	}
	
}