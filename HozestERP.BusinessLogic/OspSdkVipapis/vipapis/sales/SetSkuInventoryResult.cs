using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.sales{
	
	
	
	
	
	public class SetSkuInventoryResult {
		
		///<summary>
		/// 成功的barcode列表
		///</summary>
		
		private List<vipapis.sales.BarcodeInventory> successList_;
		
		///<summary>
		/// 失败的barcode列表及失败原因
		///</summary>
		
		private List<vipapis.sales.BarcodeMessage> failedList_;
		
		public List<vipapis.sales.BarcodeInventory> GetSuccessList(){
			return this.successList_;
		}
		
		public void SetSuccessList(List<vipapis.sales.BarcodeInventory> value){
			this.successList_ = value;
		}
		public List<vipapis.sales.BarcodeMessage> GetFailedList(){
			return this.failedList_;
		}
		
		public void SetFailedList(List<vipapis.sales.BarcodeMessage> value){
			this.failedList_ = value;
		}
		
	}
	
}