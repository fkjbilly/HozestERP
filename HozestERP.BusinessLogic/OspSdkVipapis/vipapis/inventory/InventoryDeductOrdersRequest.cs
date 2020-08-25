using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.inventory{
	
	
	
	
	
	public class InventoryDeductOrdersRequest {
		
		///<summary>
		/// 供应商id
		///</summary>
		
		private long? vendor_id_;
		
		///<summary>
		/// 1.对于多PO生成的拣货单，需进行多次调用。每次传入拣货单号和多个PO中的一个，遍历此拣货单对应的所有PO，才能得到所有订单 2.补货单只跟一个PO对应 3.如果没有存储拣货单/补货单与PO的关系，可调用JIT接口getPickList获取
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