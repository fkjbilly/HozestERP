using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.response{
	
	
	
	
	
	public class GetLimitedOrderGoodsCountResp {
		
		///<summary>
		/// 处理结果
		///</summary>
		
		private com.vip.order.common.pojo.order.result.Result result_;
		
		///<summary>
		/// 用户购买的商品数量
		///</summary>
		
		private int? goodsAmount_;
		
		public com.vip.order.common.pojo.order.result.Result GetResult(){
			return this.result_;
		}
		
		public void SetResult(com.vip.order.common.pojo.order.result.Result value){
			this.result_ = value;
		}
		public int? GetGoodsAmount(){
			return this.goodsAmount_;
		}
		
		public void SetGoodsAmount(int? value){
			this.goodsAmount_ = value;
		}
		
	}
	
}