using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.request{
	
	
	
	
	
	public class ConfirmOrderGroupBuyReq {
		
		///<summary>
		/// 订单号与用户ID的VO列表
		///</summary>
		
		private List<com.vip.order.common.pojo.order.vo.OrderSnUserIdVO> orderSnUserIdList_;
		
		public List<com.vip.order.common.pojo.order.vo.OrderSnUserIdVO> GetOrderSnUserIdList(){
			return this.orderSnUserIdList_;
		}
		
		public void SetOrderSnUserIdList(List<com.vip.order.common.pojo.order.vo.OrderSnUserIdVO> value){
			this.orderSnUserIdList_ = value;
		}
		
	}
	
}