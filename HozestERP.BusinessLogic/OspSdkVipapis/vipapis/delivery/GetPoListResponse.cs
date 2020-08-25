using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.delivery{
	
	
	
	
	
	public class GetPoListResponse {
		
		///<summary>
		/// 商品清单列表
		///</summary>
		
		private List<vipapis.delivery.PurchaseOrder> purchase_order_list_;
		
		///<summary>
		/// 记录总条数
		///</summary>
		
		private int? total_;
		
		public List<vipapis.delivery.PurchaseOrder> GetPurchase_order_list(){
			return this.purchase_order_list_;
		}
		
		public void SetPurchase_order_list(List<vipapis.delivery.PurchaseOrder> value){
			this.purchase_order_list_ = value;
		}
		public int? GetTotal(){
			return this.total_;
		}
		
		public void SetTotal(int? value){
			this.total_ = value;
		}
		
	}
	
}