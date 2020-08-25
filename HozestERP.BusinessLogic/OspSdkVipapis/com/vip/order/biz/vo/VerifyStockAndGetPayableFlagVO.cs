using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.vo{
	
	
	
	
	
	public class VerifyStockAndGetPayableFlagVO {
		
		///<summary>
		/// 结果
		///</summary>
		
		private bool? payResult_;
		
		///<summary>
		/// 订单信息
		///</summary>
		
		private com.vip.order.common.pojo.order.vo.OrderInfoVO orderInfoVo_;
		
		///<summary>
		/// 已占用库存的商品信息
		///</summary>
		
		private Dictionary<int?, int?> takeMap_;
		
		///<summary>
		/// 未占用库存的商品信息
		///</summary>
		
		private Dictionary<int?, int?> noTakeMap_;
		
		public bool? GetPayResult(){
			return this.payResult_;
		}
		
		public void SetPayResult(bool? value){
			this.payResult_ = value;
		}
		public com.vip.order.common.pojo.order.vo.OrderInfoVO GetOrderInfoVo(){
			return this.orderInfoVo_;
		}
		
		public void SetOrderInfoVo(com.vip.order.common.pojo.order.vo.OrderInfoVO value){
			this.orderInfoVo_ = value;
		}
		public Dictionary<int?, int?> GetTakeMap(){
			return this.takeMap_;
		}
		
		public void SetTakeMap(Dictionary<int?, int?> value){
			this.takeMap_ = value;
		}
		public Dictionary<int?, int?> GetNoTakeMap(){
			return this.noTakeMap_;
		}
		
		public void SetNoTakeMap(Dictionary<int?, int?> value){
			this.noTakeMap_ = value;
		}
		
	}
	
}