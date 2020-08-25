using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.request{
	
	
	
	
	
	public class PutIntoSplitQueueReq {
		
		///<summary>
		/// 订单信息
		///</summary>
		
		private List<com.vip.order.biz.vo.OrderSplitVO> orderList_;
		
		public List<com.vip.order.biz.vo.OrderSplitVO> GetOrderList(){
			return this.orderList_;
		}
		
		public void SetOrderList(List<com.vip.order.biz.vo.OrderSplitVO> value){
			this.orderList_ = value;
		}
		
	}
	
}