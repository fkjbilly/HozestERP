using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.normal{
	
	
	
	
	
	public class InventoryDeductOrdersRequest {
		
		///<summary>
		/// 供应商id
		///</summary>
		
		private long? vendor_id_;
		
		///<summary>
		/// 拣货单
		///</summary>
		
		private string pick_no_;
		
		///<summary>
		/// po单号
		///</summary>
		
		private string po_no_;
		
		///<summary>
		/// 每页查询记录数 默认50 最大200
		///</summary>
		
		private int? limit_;
		
		///<summary>
		/// 页码 默认为1
		///</summary>
		
		private int? page_;
		
		public long? GetVendor_id(){
			return this.vendor_id_;
		}
		
		public void SetVendor_id(long? value){
			this.vendor_id_ = value;
		}
		public string GetPick_no(){
			return this.pick_no_;
		}
		
		public void SetPick_no(string value){
			this.pick_no_ = value;
		}
		public string GetPo_no(){
			return this.po_no_;
		}
		
		public void SetPo_no(string value){
			this.po_no_ = value;
		}
		public int? GetLimit(){
			return this.limit_;
		}
		
		public void SetLimit(int? value){
			this.limit_ = value;
		}
		public int? GetPage(){
			return this.page_;
		}
		
		public void SetPage(int? value){
			this.page_ = value;
		}
		
	}
	
}