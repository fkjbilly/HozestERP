using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.stock{
	
	
	
	
	
	public class DelInneWarehouseInfo {
		
		///<summary>
		/// 仓库编号
		///</summary>
		
		private string vendor_warehouse_id_;
		
		///<summary>
		/// 供应商id
		///</summary>
		
		private string msg_;
		
		public string GetVendor_warehouse_id(){
			return this.vendor_warehouse_id_;
		}
		
		public void SetVendor_warehouse_id(string value){
			this.vendor_warehouse_id_ = value;
		}
		public string GetMsg(){
			return this.msg_;
		}
		
		public void SetMsg(string value){
			this.msg_ = value;
		}
		
	}
	
}