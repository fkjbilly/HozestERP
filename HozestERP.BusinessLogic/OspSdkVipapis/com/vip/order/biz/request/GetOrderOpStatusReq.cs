using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.request{
	
	
	
	
	
	public class GetOrderOpStatusReq {
		
		///<summary>
		/// 订单可操作状态入参
		///</summary>
		
		private List<com.vip.order.common.pojo.order.vo.OrderOpStatusVO> orderList_;
		
		///<summary>
		/// 操作名列表
		///</summary>
		
		private List<string> opList_;
		
		public List<com.vip.order.common.pojo.order.vo.OrderOpStatusVO> GetOrderList(){
			return this.orderList_;
		}
		
		public void SetOrderList(List<com.vip.order.common.pojo.order.vo.OrderOpStatusVO> value){
			this.orderList_ = value;
		}
		public List<string> GetOpList(){
			return this.opList_;
		}
		
		public void SetOpList(List<string> value){
			this.opList_ = value;
		}
		
	}
	
}