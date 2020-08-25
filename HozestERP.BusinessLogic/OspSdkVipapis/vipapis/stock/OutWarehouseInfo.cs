using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.stock{
	
	
	
	
	
	public class OutWarehouseInfo {
		
		///<summary>
		/// 供应商id
		///</summary>
		
		private string vendor_id_;
		
		///<summary>
		/// 仓库编号
		///</summary>
		
		private string vendor_warehouse_id_;
		
		///<summary>
		/// 错误信息
		///</summary>
		
		private string msg_;
		
		///<summary>
		/// 响应结果
		///</summary>
		
		private string result_;
		
		public string GetVendor_id(){
			return this.vendor_id_;
		}
		
		public void SetVendor_id(string value){
			this.vendor_id_ = value;
		}
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
		public string GetResult(){
			return this.result_;
		}
		
		public void SetResult(string value){
			this.result_ = value;
		}
		
	}
	
}