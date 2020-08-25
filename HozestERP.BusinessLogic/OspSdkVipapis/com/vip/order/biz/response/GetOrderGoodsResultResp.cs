using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.response{
	
	
	
	
	
	public class GetOrderGoodsResultResp {
		
		///<summary>
		/// 通用结果头部
		///</summary>
		
		private com.vip.order.common.pojo.order.result.Result result_;
		
		///<summary>
		/// 订单商品详情信息列表
		///</summary>
		
		private List<com.vip.order.biz.response.GetOrderGoodsItem> getOrderGoodsItemList_;
		
		public com.vip.order.common.pojo.order.result.Result GetResult(){
			return this.result_;
		}
		
		public void SetResult(com.vip.order.common.pojo.order.result.Result value){
			this.result_ = value;
		}
		public List<com.vip.order.biz.response.GetOrderGoodsItem> GetGetOrderGoodsItemList(){
			return this.getOrderGoodsItemList_;
		}
		
		public void SetGetOrderGoodsItemList(List<com.vip.order.biz.response.GetOrderGoodsItem> value){
			this.getOrderGoodsItemList_ = value;
		}
		
	}
	
}