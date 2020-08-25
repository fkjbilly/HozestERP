using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.stock{
	
	
	
	
	
	public class WarehouseInfoList {
		
		///<summary>
		/// 仓库编号
		///</summary>
		
		private string vendor_warehouse_id_;
		
		///<summary>
		/// 仓库名称
		///</summary>
		
		private string vendor_warehouse_name_;
		
		///<summary>
		/// 仓库省份
		///</summary>
		
		private string vendor_warehouse_province_;
		
		///<summary>
		/// 仓库城市
		///</summary>
		
		private string vendor_warehouse_city_;
		
		///<summary>
		/// 仓库区县
		///</summary>
		
		private string vendor_warehouse_country_;
		
		///<summary>
		/// 仓库街道
		///</summary>
		
		private string vendor_warehouse_street_;
		
		///<summary>
		/// 仓库门牌号
		///</summary>
		
		private string vendor_warehouse_addresses_;
		
		///<summary>
		/// 联系人
		///</summary>
		
		private string name_;
		
		///<summary>
		/// 联系电话
		///</summary>
		
		private string tel_;
		
		///<summary>
		/// 唯品会仓库编码
		///</summary>
		
		private string vip_warehouse_code_;
		
		///<summary>
		/// 优先级
		///</summary>
		
		private string priority_;
		
		public string GetVendor_warehouse_id(){
			return this.vendor_warehouse_id_;
		}
		
		public void SetVendor_warehouse_id(string value){
			this.vendor_warehouse_id_ = value;
		}
		public string GetVendor_warehouse_name(){
			return this.vendor_warehouse_name_;
		}
		
		public void SetVendor_warehouse_name(string value){
			this.vendor_warehouse_name_ = value;
		}
		public string GetVendor_warehouse_province(){
			return this.vendor_warehouse_province_;
		}
		
		public void SetVendor_warehouse_province(string value){
			this.vendor_warehouse_province_ = value;
		}
		public string GetVendor_warehouse_city(){
			return this.vendor_warehouse_city_;
		}
		
		public void SetVendor_warehouse_city(string value){
			this.vendor_warehouse_city_ = value;
		}
		public string GetVendor_warehouse_country(){
			return this.vendor_warehouse_country_;
		}
		
		public void SetVendor_warehouse_country(string value){
			this.vendor_warehouse_country_ = value;
		}
		public string GetVendor_warehouse_street(){
			return this.vendor_warehouse_street_;
		}
		
		public void SetVendor_warehouse_street(string value){
			this.vendor_warehouse_street_ = value;
		}
		public string GetVendor_warehouse_addresses(){
			return this.vendor_warehouse_addresses_;
		}
		
		public void SetVendor_warehouse_addresses(string value){
			this.vendor_warehouse_addresses_ = value;
		}
		public string GetName(){
			return this.name_;
		}
		
		public void SetName(string value){
			this.name_ = value;
		}
		public string GetTel(){
			return this.tel_;
		}
		
		public void SetTel(string value){
			this.tel_ = value;
		}
		public string GetVip_warehouse_code(){
			return this.vip_warehouse_code_;
		}
		
		public void SetVip_warehouse_code(string value){
			this.vip_warehouse_code_ = value;
		}
		public string GetPriority(){
			return this.priority_;
		}
		
		public void SetPriority(string value){
			this.priority_ = value;
		}
		
	}
	
}