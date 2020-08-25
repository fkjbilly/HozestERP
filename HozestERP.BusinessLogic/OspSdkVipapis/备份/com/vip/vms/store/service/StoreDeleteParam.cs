using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.vms.store.service{
	
	
	
	
	
	public class StoreDeleteParam {
		
		///<summary>
		/// 供应商Id
		///</summary>
		
		private string vendor_id_;
		
		///<summary>
		/// 名店名称
		///</summary>
		
		private string storeName_;
		
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
		
	}
	
}