using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.response{
	
	
	
	
	
	public class OrderOpStatus {
		
		///<summary>
		/// 订单id
		///</summary>
		
		private long? orderId_;
		
		///<summary>
		/// 订单sn
		///</summary>
		
		private string orderSn_;
		
		///<summary>
		/// 操作状态列表
		///</summary>
		
		private List<com.vip.order.common.pojo.order.vo.OpStatusVO> opList_;
		
		public long? GetOrderId(){
			return this.orderId_;
		}
		
		public void SetOrderId(long? value){
			this.orderId_ = value;
		}
		public string GetOrderSn(){
			return this.orderSn_;
		}
		
		public void SetOrderSn(string value){
			this.orderSn_ = value;
		}
		public List<com.vip.order.common.pojo.order.vo.OpStatusVO> GetOpList(){
			return this.opList_;
		}
		
		public void SetOpList(List<com.vip.order.common.pojo.order.vo.OpStatusVO> value){
			this.opList_ = value;
		}
		
	}
	
}