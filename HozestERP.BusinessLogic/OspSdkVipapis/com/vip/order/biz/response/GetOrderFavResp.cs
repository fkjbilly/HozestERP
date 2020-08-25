using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.response{
	
	
	
	
	
	public class GetOrderFavResp {
		
		///<summary>
		/// 处理结果
		///</summary>
		
		private com.vip.order.common.pojo.order.result.Result result_;
		
		///<summary>
		/// 订单优惠列表
		///</summary>
		
		private List<com.vip.order.common.pojo.order.vo.OrderFavVO> orderFavList_;
		
		public com.vip.order.common.pojo.order.result.Result GetResult(){
			return this.result_;
		}
		
		public void SetResult(com.vip.order.common.pojo.order.result.Result value){
			this.result_ = value;
		}
		public List<com.vip.order.common.pojo.order.vo.OrderFavVO> GetOrderFavList(){
			return this.orderFavList_;
		}
		
		public void SetOrderFavList(List<com.vip.order.common.pojo.order.vo.OrderFavVO> value){
			this.orderFavList_ = value;
		}
		
	}
	
}