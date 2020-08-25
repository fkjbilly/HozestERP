using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.request{
	
	
	
	
	
	public class AutoTakeInventoryReq {
		
		///<summary>
		/// 用户ID
		///</summary>
		
		private long? userId_;
		
		///<summary>
		/// 订单sn
		///</summary>
		
		private string orderSn_;
		
		///<summary>
		/// 占用库存列表
		///</summary>
		
		private List<com.vip.order.biz.request.Inventory> inventoryList_;
		
		public long? GetUserId(){
			return this.userId_;
		}
		
		public void SetUserId(long? value){
			this.userId_ = value;
		}
		public string GetOrderSn(){
			return this.orderSn_;
		}
		
		public void SetOrderSn(string value){
			this.orderSn_ = value;
		}
		public List<com.vip.order.biz.request.Inventory> GetInventoryList(){
			return this.inventoryList_;
		}
		
		public void SetInventoryList(List<com.vip.order.biz.request.Inventory> value){
			this.inventoryList_ = value;
		}
		
	}
	
}