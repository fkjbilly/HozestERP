using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.request{
	
	
	
	
	
	public class GetGoodsDispatchWarehouseReq {
		
		///<summary>
		/// 商品列表
		///</summary>
		
		private List<com.vip.order.biz.request.GoodsDispatchWarehouseModel> goodsList_;
		
		///<summary>
		/// 站点
		///</summary>
		
		private string warehouse_;
		
		public List<com.vip.order.biz.request.GoodsDispatchWarehouseModel> GetGoodsList(){
			return this.goodsList_;
		}
		
		public void SetGoodsList(List<com.vip.order.biz.request.GoodsDispatchWarehouseModel> value){
			this.goodsList_ = value;
		}
		public string GetWarehouse(){
			return this.warehouse_;
		}
		
		public void SetWarehouse(string value){
			this.warehouse_ = value;
		}
		
	}
	
}