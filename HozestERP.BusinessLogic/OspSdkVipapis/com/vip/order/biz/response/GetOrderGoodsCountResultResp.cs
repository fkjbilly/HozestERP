using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.response{
	
	
	
	
	
	public class GetOrderGoodsCountResultResp {
		
		///<summary>
		/// 通用结果头部
		///</summary>
		
		private com.vip.order.common.pojo.order.result.Result result_;
		
		///<summary>
		/// 订单商品总数
		///</summary>
		
		private int? orderGoodsCount_;
		
		public com.vip.order.common.pojo.order.result.Result GetResult(){
			return this.result_;
		}
		
		public void SetResult(com.vip.order.common.pojo.order.result.Result value){
			this.result_ = value;
		}
		public int? GetOrderGoodsCount(){
			return this.orderGoodsCount_;
		}
		
		public void SetOrderGoodsCount(int? value){
			this.orderGoodsCount_ = value;
		}
		
	}
	
}