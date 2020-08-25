using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.stock{
	
	
	
	
	
	public class ConfirmFrozenInventory {
		
		///<summary>
		/// 仓库名称
		/// @sampleValue store_name 
		///</summary>
		
		private string store_name_;
		
		///<summary>
		/// 商品条码
		/// @sampleValue barcode 
		///</summary>
		
		private string barcode_;
		
		///<summary>
		/// 冻结数量
		/// @sampleValue frozen_qty 
		///</summary>
		
		private int? frozen_qty_;
		
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
		public int? GetFrozen_qty(){
			return this.frozen_qty_;
		}
		
		public void SetFrozen_qty(int? value){
			this.frozen_qty_ = value;
		}
		
	}
	
}