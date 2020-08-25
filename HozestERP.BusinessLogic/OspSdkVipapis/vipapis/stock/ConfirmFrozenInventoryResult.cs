using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.stock{
	
	
	
	
	
	public class ConfirmFrozenInventoryResult {
		
		///<summary>
		/// 仓库名称
		///</summary>
		
		private string store_name_;
		
		///<summary>
		/// 商品条码
		/// @sampleValue barcode 
		///</summary>
		
		private string barcode_;
		
		///<summary>
		/// 处理消息
		/// @sampleValue message 
		///</summary>
		
		private string message_;
		
		public string GetStore_name(){
			return this.store_name_;
		}
		
		public void SetStore_name(string value){
			this.store_name_ = value;
		}
		public string GetBarcode(){
			return this.barcode_;
		}
		
		public void SetBarcode(string value){
			this.barcode_ = value;
		}
		public string GetMessage(){
			return this.message_;
		}
		
		public void SetMessage(string value){
			this.message_ = value;
		}
		
	}
	
}