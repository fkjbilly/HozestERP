using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.vms.store.service{
	
	
	
	
	
	public class StoreWarehouseRelUpdateParam {
		
		///<summary>
		/// 供应商Id
		///</summary>
		
		private string vendor_id_;
		
		///<summary>
		/// 名店名称
		///</summary>
		
		private string storeName_;
		
		///<summary>
		/// 唯品会仓库编码
		///</summary>
		
		private string warehouse_;
		
		///<summary>
		/// 优先级
		///</summary>
		
		private int? priority_;
		
		public string GetVendor_id(){
			return this.vendor_id_;
		}
		
		public void SetVendor_id(string value){
			this.vendor_id_ = value;
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
		public int? GetPriority(){
			return this.priority_;
		}
		
		public void SetPriority(int? value){
			this.priority_ = value;
		}
		
	}
	
}