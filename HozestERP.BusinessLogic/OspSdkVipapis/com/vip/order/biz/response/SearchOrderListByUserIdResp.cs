using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.response{
	
	
	
	
	
	public class SearchOrderListByUserIdResp {
		
		///<summary>
		/// 处理结果
		///</summary>
		
		private com.vip.order.common.pojo.order.result.Result result_;
		
		///<summary>
		/// 历史订单列表
		///</summary>
		
		private List<com.vip.order.common.pojo.order.vo.OrderInfoVO> orderInfoList_;
		
		///<summary>
		/// 父单信息列表
		///</summary>
		
		private List<com.vip.order.common.pojo.order.vo.ParentOrderInfoVO> parentOrderList_;
		
		///<summary>
		/// 匹配关键字订单数量
		///</summary>
		
		private int? totalCount_;
		
		public com.vip.order.common.pojo.order.result.Result GetResult(){
			return this.result_;
		}
		
		public void SetResult(com.vip.order.common.pojo.order.result.Result value){
			this.result_ = value;
		}
		public List<com.vip.order.common.pojo.order.vo.OrderInfoVO> GetOrderInfoList(){
			return this.orderInfoList_;
		}
		
		public void SetOrderInfoList(List<com.vip.order.common.pojo.order.vo.OrderInfoVO> value){
			this.orderInfoList_ = value;
		}
		public List<com.vip.order.common.pojo.order.vo.ParentOrderInfoVO> GetParentOrderList(){
			return this.parentOrderList_;
		}
		
		public void SetParentOrderList(List<com.vip.order.common.pojo.order.vo.ParentOrderInfoVO> value){
			this.parentOrderList_ = value;
		}
		public int? GetTotalCount(){
			return this.totalCount_;
		}
		
		public void SetTotalCount(int? value){
			this.totalCount_ = value;
		}
		
	}
	
}