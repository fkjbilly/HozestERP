using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.domain.inventory{
	
	
	
	
	
	public class PurchaseSalesInventoryResponse {
		
		///<summary>
		/// 总记录条数
		///</summary>
		
		private int? detail_count_;
		
		///<summary>
		/// 进销存商品信息列表
		///</summary>
		
		private List<com.vip.domain.inventory.PurchaseSalesInventoryItemInfo> items_;
		
		public int? GetDetail_count(){
			return this.detail_count_;
		}
		
		public void SetDetail_count(int? value){
			this.detail_count_ = value;
		}
		public List<com.vip.domain.inventory.PurchaseSalesInventoryItemInfo> GetItems(){
			return this.items_;
		}
		
		public void SetItems(List<com.vip.domain.inventory.PurchaseSalesInventoryItemInfo> value){
			this.items_ = value;
		}
		
	}
	
}