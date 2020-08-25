using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.store{
	
	
	
	
	
	public class StoreInfo {
		
		///<summary>
		/// 供应商ID
		/// @sampleValue vendor_id 550
		///</summary>
		
		private int? vendor_id_;
		
		///<summary>
		/// 门店名称
		/// @sampleValue store_name 新桥店
		///</summary>
		
		private string store_name_;
		
		///<summary>
		/// 门店编码
		/// @sampleValue store_sn 550MD150820110351009
		///</summary>
		
		private string store_sn_;
		
		///<summary>
		/// 国家名称
		/// @sampleValue country 中国
		///</summary>
		
		private string country_;
		
		///<summary>
		/// 省份名称
		/// @sampleValue province 上海市
		///</summary>
		
		private string province_;
		
		///<summary>
		/// 城市名称
		/// @sampleValue city 上海市
		///</summary>
		
		private string city_;
		
		///<summary>
		/// 区县名称
		/// @sampleValue district 松江区
		///</summary>
		
		private string district_;
		
		///<summary>
		/// 街道名称
		/// @sampleValue street 新桥镇
		///</summary>
		
		private string street_;
		
		///<summary>
		/// 详细地址
		/// @sampleValue address 302
		///</summary>
		
		private string address_;
		
		public int? GetVendor_id(){
			return this.vendor_id_;
		}
		
		public void SetVendor_id(int? value){
			this.vendor_id_ = value;
		}
		public string GetStore_name(){
			return this.store_name_;
		}
		
		public void SetStore_name(string value){
			this.store_name_ = value;
		}
		public string GetStore_sn(){
			return this.store_sn_;
		}
		
		public void SetStore_sn(string value){
			this.store_sn_ = value;
		}
		public string GetCountry(){
			return this.country_;
		}
		
		public void SetCountry(string value){
			this.country_ = value;
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
		
	}
	
}