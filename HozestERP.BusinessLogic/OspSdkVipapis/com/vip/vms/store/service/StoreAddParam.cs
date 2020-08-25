using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.vms.store.service{
	
	
	
	
	
	public class StoreAddParam {
		
		///<summary>
		/// 供应商Id
		///</summary>
		
		private string vendor_id_;
		
		///<summary>
		/// 名店名称
		///</summary>
		
		private string storeName_;
		
		///<summary>
		/// 门店省份
		///</summary>
		
		private string province_;
		
		///<summary>
		/// 门店城市
		///</summary>
		
		private string city_;
		
		///<summary>
		/// 门店区县
		///</summary>
		
		private string district_;
		
		///<summary>
		/// 门店街道
		///</summary>
		
		private string street_;
		
		///<summary>
		/// 门店门牌
		///</summary>
		
		private string address_;
		
		///<summary>
		/// 负责人
		///</summary>
		
		private string contact_;
		
		///<summary>
		/// 联系电话
		///</summary>
		
		private string tel_;
		
		///<summary>
		/// 门店国家名称
		///</summary>
		
		private string country_;
		
		///<summary>
		/// 门店邮政编码
		///</summary>
		
		private string zipcode_;
		
		public string GetVendor_id(){
			return this.vendor_id_;
		}
		
		public void SetVendor_id(string value){
			this.vendor_id_ = value;
		}
		public string GetStoreName(){
			return this.storeName_;
		}
		
		public void SetStoreName(string value){
			this.storeName_ = value;
		}
		public string GetProvince(){
			return this.province_;
		}
		
		public void SetProvince(string value){
			this.province_ = value;
		}
		public string GetCity(){
			return this.city_;
		}
		
		public void SetCity(string value){
			this.city_ = value;
		}
		public string GetDistrict(){
			return this.district_;
		}
		
		public void SetDistrict(string value){
			this.district_ = value;
		}
		public string GetStreet(){
			return this.street_;
		}
		
		public void SetStreet(string value){
			this.street_ = value;
		}
		public string GetAddress(){
			return this.address_;
		}
		
		public void SetAddress(string value){
			this.address_ = value;
		}
		public string GetContact(){
			return this.contact_;
		}
		
		public void SetContact(string value){
			this.contact_ = value;
		}
		public string GetTel(){
			return this.tel_;
		}
		
		public void SetTel(string value){
			this.tel_ = value;
		}
		public string GetCountry(){
			return this.country_;
		}
		
		public void SetCountry(string value){
			this.country_ = value;
		}
		public string GetZipcode(){
			return this.zipcode_;
		}
		
		public void SetZipcode(string value){
			this.zipcode_ = value;
		}
		
	}
	
}