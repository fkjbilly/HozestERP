using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.vms.store.service{
	
	
	
	
	
	public class StoreQueryParam {
		
		///<summary>
		/// 供应商Id
		///</summary>
		
		private string vendor_id_;
		
		///<summary>
		/// 门店编码
		///</summary>
		
		private string storeCode_;
		
		///<summary>
		/// 名店名称
		///</summary>
		
		private string storeName_;
		
		///<summary>
		/// 唯品会仓库编码
		///</summary>
		
		private string warehouse_;
		
		///<summary>
		/// 分页
		///</summary>
		
		private com.vip.vms.common.Pager pager_;
		
		///<summary>
		/// 门店省份的编码（TMS中的code）
		///</summary>
		
		private string provinceCode_;
		
		///<summary>
		/// 门店城市的编码（TMS中的code）
		///</summary>
		
		private string cityCode_;
		
		public string GetVendor_id(){
			return this.vendor_id_;
		}
		
		public void SetVendor_id(string value){
			this.vendor_id_ = value;
		}
		public string GetStoreCode(){
			return this.storeCode_;
		}
		
		public void SetStoreCode(string value){
			this.storeCode_ = value;
		}
		public string GetStoreName(){
			return this.storeName_;
		}
		
		public void SetStoreName(string value){
			this.storeName_ = value;
		}
		public string GetWarehouse(){
			return this.warehouse_;
		}
		
		public void SetWarehouse(string value){
			this.warehouse_ = value;
		}
		public com.vip.vms.common.Pager GetPager(){
			return this.pager_;
		}
		
		public void SetPager(com.vip.vms.common.Pager value){
			this.pager_ = value;
		}
		public string GetProvinceCode(){
			return this.provinceCode_;
		}
		
		public void SetProvinceCode(string value){
			this.provinceCode_ = value;
		}
		public string GetCityCode(){
			return this.cityCode_;
		}
		
		public void SetCityCode(string value){
			this.cityCode_ = value;
		}
		
	}
	
}