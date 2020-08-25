using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.pg{
	
	
	
	
	
	public class GetProductInventoryListResponse {
		
		///<summary>
		/// productInventorys
		///</summary>
		
		private List<vipapis.pg.Inventory> goodsStock_;
		
		///<summary>
		/// total
		///</summary>
		
		private int? total_;
		
		public List<vipapis.pg.Inventory> GetGoodsStock(){
			return this.goodsStock_;
		}
		
		public void SetGoodsStock(List<vipapis.pg.Inventory> value){
			this.goodsStock_ = value;
		}
		public int? GetTotal(){
			return this.total_;
		}
		
		public void SetTotal(int? value){
			this.total_ = value;
		}
		
	}
	
}