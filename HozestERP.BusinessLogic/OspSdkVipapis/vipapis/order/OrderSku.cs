using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.order{
	
	
	
	
	
	public class OrderSku {
		
		///<summary>
		/// 品牌ID
		///</summary>
		
		private long? brand_id_;
		
		///<summary>
		/// 商品条形码
		///</summary>
		
		private string barcode_;
		
		///<summary>
		/// 商品数量
		///</summary>
		
		private int? amount_;
		
		///<summary>
		/// 拣货状态
		///</summary>
		
		private byte? pick_state_;
		
		public long? GetBrand_id(){
			return this.brand_id_;
		}
		
		public void SetBrand_id(long? value){
			this.brand_id_ = value;
		}
		public string GetBarcode(){
			return this.barcode_;
		}
		
		public void SetBarcode(string value){
			this.barcode_ = value;
		}
		public int? GetAmount(){
			return this.amount_;
		}
		
		public void SetAmount(int? value){
			this.amount_ = value;
		}
		public byte? GetPick_state(){
			return this.pick_state_;
		}
		
		public void SetPick_state(byte? value){
			this.pick_state_ = value;
		}
		
	}
	
}