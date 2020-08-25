using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.dvd{
	
	
	
	
	
	public class AreaWarehouse {
		
		///<summary>
		/// 仓库代码
		///</summary>
		
		private string area_warehouse_id_;
		
		///<summary>
		/// 仓库名称
		///</summary>
		
		private string area_warehouse_name_;
		
		///<summary>
		/// 仓库地址
		///</summary>
		
		private string area_warehouse_address_;
		
		///<summary>
		/// 退货地址
		///</summary>
		
		private string returned_goods_address_;
		
		public string GetArea_warehouse_id(){
			return this.area_warehouse_id_;
		}
		
		public void SetArea_warehouse_id(string value){
			this.area_warehouse_id_ = value;
		}
		public string GetArea_warehouse_name(){
			return this.area_warehouse_name_;
		}
		
		public void SetArea_warehouse_name(string value){
			this.area_warehouse_name_ = value;
		}
		public string GetArea_warehouse_address(){
			return this.area_warehouse_address_;
		}
		
		public void SetArea_warehouse_address(string value){
			this.area_warehouse_address_ = value;
		}
		public string GetReturned_goods_address(){
			return this.returned_goods_address_;
		}
		
		public void SetReturned_goods_address(string value){
			this.returned_goods_address_ = value;
		}
		
	}
	
}