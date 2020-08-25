using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.delivery{
	
	
	
	
	
	public class GetPoSkuListResponse {
		
		///<summary>
		/// PO单SKU信息
		///</summary>
		
		private List<vipapis.delivery.PurchaseOrderSku> purchase_order_sku_list_;
		
		///<summary>
		/// 记录总条数
		///</summary>
		
		private int? total_;
		
		public List<vipapis.delivery.PurchaseOrderSku> GetPurchase_order_sku_list(){
			return this.purchase_order_sku_list_;
		}
		
		public void SetPurchase_order_sku_list(List<vipapis.delivery.PurchaseOrderSku> value){
			this.purchase_order_sku_list_ = value;
		}
		public int? GetTotal(){
			return this.total_;
		}
		
		public void SetTotal(int? value){
			this.total_ = value;
		}
		
	}
	
}