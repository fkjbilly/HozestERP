using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.response{
	
	
	
	
	
	public class OrderActiveDetailResult {
		
		///<summary>
		/// 订单编号
		///</summary>
		
		private string orderSn_;
		
		///<summary>
		/// 查询结果返回码
		///</summary>
		
		private int? resultCode_;
		
		///<summary>
		/// 订单优惠明细列表
		///</summary>
		
		private List<com.vip.order.common.pojo.order.vo.OrderActiveDetailVO> activeDetailList_;
		
		public string GetOrderSn(){
			return this.orderSn_;
		}
		
		public void SetOrderSn(string value){
			this.orderSn_ = value;
		}
		public int? GetResultCode(){
			return this.resultCode_;
		}
		
		public void SetResultCode(int? value){
			this.resultCode_ = value;
		}
		public List<com.vip.order.common.pojo.order.vo.OrderActiveDetailVO> GetActiveDetailList(){
			return this.activeDetailList_;
		}
		
		public void SetActiveDetailList(List<com.vip.order.common.pojo.order.vo.OrderActiveDetailVO> value){
			this.activeDetailList_ = value;
		}
		
	}
	
}