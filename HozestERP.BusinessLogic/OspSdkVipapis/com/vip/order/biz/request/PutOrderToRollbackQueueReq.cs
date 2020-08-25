using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.request{
	
	
	
	
	
	public class PutOrderToRollbackQueueReq {
		
		///<summary>
		/// 回滚订单号列表 
		///</summary>
		
		private List<com.vip.order.common.pojo.order.vo.OrderSnAndIdVO> orderSnList_;
		
		public List<com.vip.order.common.pojo.order.vo.OrderSnAndIdVO> GetOrderSnList(){
			return this.orderSnList_;
		}
		
		public void SetOrderSnList(List<com.vip.order.common.pojo.order.vo.OrderSnAndIdVO> value){
			this.orderSnList_ = value;
		}
		
	}
	
}