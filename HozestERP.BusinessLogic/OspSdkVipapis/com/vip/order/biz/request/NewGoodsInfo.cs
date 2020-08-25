using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.request{
	
	
	
	
	
	public class NewGoodsInfo {
		
		///<summary>
		/// sizeId
		///</summary>
		
		private long? merItemNo_;
		
		///<summary>
		/// 商品数量
		///</summary>
		
		private int? amount_;
		
		public long? GetMerItemNo(){
			return this.merItemNo_;
		}
		
		public void SetMerItemNo(long? value){
			this.merItemNo_ = value;
		}
		public int? GetAmount(){
			return this.amount_;
		}
		
		public void SetAmount(int? value){
			this.amount_ = value;
		}
		
	}
	
}