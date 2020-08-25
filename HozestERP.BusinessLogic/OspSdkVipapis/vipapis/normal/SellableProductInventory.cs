using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.normal{
	
	
	
	
	
	public class SellableProductInventory {
		
		///<summary>
		/// 商品条码
		///</summary>
		
		private string barcode_;
		
		///<summary>
		/// 库存调整数量（<font color='red'>不能为负数</font>）
		///</summary>
		
		private int? inventory_;
		
		///<summary>
		/// 已拣货库存（<font color='red'>不能为负数</font>）
		///</summary>
		
		private int? pick_num_;
		
		public string GetBarcode(){
			return this.barcode_;
		}
		
		public void SetBarcode(string value){
			this.barcode_ = value;
		}
		public int? GetInventory(){
			return this.inventory_;
		}
		
		public void SetInventory(int? value){
			this.inventory_ = value;
		}
		public int? GetPick_num(){
			return this.pick_num_;
		}
		
		public void SetPick_num(int? value){
			this.pick_num_ = value;
		}
		
	}
	
}