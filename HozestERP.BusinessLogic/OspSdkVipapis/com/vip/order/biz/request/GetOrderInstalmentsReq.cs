using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.request{
	
	
	
	
	
	public class GetOrderInstalmentsReq {
		
		///<summary>
		/// 用户ID列表
		///</summary>
		
		private List<long?> userIdList_;
		
		///<summary>
		/// 订单序列号列表
		///</summary>
		
		private List<string> orderSnList_;
		
		///<summary>
		/// 订单支付类型范围
		///</summary>
		
		private com.vip.order.common.pojo.order.request.RangeParam payTypeRange_;
		
		public List<long?> GetUserIdList(){
			return this.userIdList_;
		}
		
		public void SetUserIdList(List<long?> value){
			this.userIdList_ = value;
		}
		public List<string> GetOrderSnList(){
			return this.orderSnList_;
		}
		
		public void SetOrderSnList(List<string> value){
			this.orderSnList_ = value;
		}
		public com.vip.order.common.pojo.order.request.RangeParam GetPayTypeRange(){
			return this.payTypeRange_;
		}
		
		public void SetPayTypeRange(com.vip.order.common.pojo.order.request.RangeParam value){
			this.payTypeRange_ = value;
		}
		
	}
	
}