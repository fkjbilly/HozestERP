using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.common.pojo.order.vo{
	
	
	
	
	
	public class GoodsWarehouseVO {
		
		///<summary>
		/// 商品ID
		///</summary>
		
		private string merchandiseNo_;
		
		///<summary>
		/// 订单ID
		///</summary>
		
		private string warehouse_;
		
		///<summary>
		/// 商品所对应档期
		///</summary>
		
		private string salesNo_;
		
		public string GetMerchandiseNo(){
			return this.merchandiseNo_;
		}
		
		public void SetMerchandiseNo(string value){
			this.merchandiseNo_ = value;
		}
		public string GetWarehouse(){
			return this.warehouse_;
		}
		
		public void SetWarehouse(string value){
			this.warehouse_ = value;
		}
		public string GetSalesNo(){
			return this.salesNo_;
		}
		
		public void SetSalesNo(string value){
			this.salesNo_ = value;
		}
		
	}
	
}