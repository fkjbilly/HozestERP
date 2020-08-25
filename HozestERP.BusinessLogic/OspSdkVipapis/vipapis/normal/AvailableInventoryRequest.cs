using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.normal{
	
	
	
	
	
	public class AvailableInventoryRequest {
		
		///<summary>
		/// 供应商ID
		/// @sampleValue vendor_id 550
		///</summary>
		
		private int? vendor_id_;
		
		///<summary>
		/// 批次号(<font color='red'>不支持负数,相同供应商ID不允许重复，否则忽略重复请求</font>)
		/// @sampleValue batch_no 123
		///</summary>
		
		private int? batch_no_;
		
		///<summary>
		/// 供应商仓库编码
		///</summary>
		
		private string warehouse_supplier_;
		
		///<summary>
		/// 商品库存变化列表（<font color='red'>最大支持50条</font>）
		///</summary>
		
		private List<vipapis.normal.AvailableInventory> availableInventoryList_;
		
		///<summary>
		/// 常态合作编码
		///</summary>
		
		private int? cooperation_no_;
		
		public int? GetVendor_id(){
			return this.vendor_id_;
		}
		
		public void SetVendor_id(int? value){
			this.vendor_id_ = value;
		}
		public int? GetBatch_no(){
			return this.batch_no_;
		}
		
		public void SetBatch_no(int? value){
			this.batch_no_ = value;
		}
		public string GetWarehouse_supplier(){
			return this.warehouse_supplier_;
		}
		
		public void SetWarehouse_supplier(string value){
			this.warehouse_supplier_ = value;
		}
		public List<vipapis.normal.AvailableInventory> GetAvailableInventoryList(){
			return this.availableInventoryList_;
		}
		
		public void SetAvailableInventoryList(List<vipapis.normal.AvailableInventory> value){
			this.availableInventoryList_ = value;
		}
		public int? GetCooperation_no(){
			return this.cooperation_no_;
		}
		
		public void SetCooperation_no(int? value){
			this.cooperation_no_ = value;
		}
		
	}
	
}