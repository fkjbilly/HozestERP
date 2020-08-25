using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.store{
	
	
	
	
	
	public class StoreQueryRequest {
		
		///<summary>
		/// 供应商ID
		/// @sampleValue vendor_id 550
		///</summary>
		
		private int? vendor_id_;
		
		///<summary>
		/// 门店编码，允许传入多个门店编码支持批量查询（当同时传入门店编码和门店名称时，以门店编码为准，门店名称无效）
		/// @sampleValue store_sn 550MD150820110351009
		///</summary>
		
		private List<string> store_sn_;
		
		///<summary>
		/// 门店名称，允许传入多个门店名称支持批量查询（当同时传入门店编码和门店名称时，以门店编码为准，门店名称无效）
		/// @sampleValue store_names 新桥店
		///</summary>
		
		private List<string> store_names_;
		
		///<summary>
		/// 省份编码
		/// @sampleValue province_code 101103
		///</summary>
		
		private string province_code_;
		
		///<summary>
		/// 城市编码
		/// @sampleValue city_code 101103101
		///</summary>
		
		private string city_code_;
		
		///<summary>
		/// 唯品会仓库编码
		/// @sampleValue warehouse VIP_SH
		///</summary>
		
		private string warehouse_;
		
		///<summary>
		/// 页码参数，默认1
		/// @sampleValue page 1
		///</summary>
		
		private int? page_;
		
		///<summary>
		/// 每页记录条数，默认50，最大200
		/// @sampleValue limit 50
		///</summary>
		
		private int? limit_;
		
		public int? GetVendor_id(){
			return this.vendor_id_;
		}
		
		public void SetVendor_id(int? value){
			this.vendor_id_ = value;
		}
		public List<string> GetStore_sn(){
			return this.store_sn_;
		}
		
		public void SetStore_sn(List<string> value){
			this.store_sn_ = value;
		}
		public List<string> GetStore_names(){
			return this.store_names_;
		}
		
		public void SetStore_names(List<string> value){
			this.store_names_ = value;
		}
		public string GetProvince_code(){
			return this.province_code_;
		}
		
		public void SetProvince_code(string value){
			this.province_code_ = value;
		}
		public string GetCity_code(){
			return this.city_code_;
		}
		
		public void SetCity_code(string value){
			this.city_code_ = value;
		}
		public string GetWarehouse(){
			return this.warehouse_;
		}
		
		public void SetWarehouse(string value){
			this.warehouse_ = value;
		}
		public int? GetPage(){
			return this.page_;
		}
		
		public void SetPage(int? value){
			this.page_ = value;
		}
		public int? GetLimit(){
			return this.limit_;
		}
		
		public void SetLimit(int? value){
			this.limit_ = value;
		}
		
	}
	
}