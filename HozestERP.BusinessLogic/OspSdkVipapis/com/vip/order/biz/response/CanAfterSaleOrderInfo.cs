using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.response{
	
	
	
	
	
	public class CanAfterSaleOrderInfo {
		
		///<summary>
		/// 订单信息
		///</summary>
		
		private com.vip.order.common.pojo.order.vo.OrderVO order_;
		
		///<summary>
		/// 订单补充信息
		///</summary>
		
		private com.vip.order.common.pojo.order.vo.OrderDetailsSuppInfoVO orderDetailsSuppInfo_;
		
		///<summary>
		/// 订单支付及优惠信息
		///</summary>
		
		private com.vip.order.common.pojo.order.vo.OrderPayAndDiscountVO orderPayAndDiscount_;
		
		///<summary>
		/// 订单商品信息
		///</summary>
		
		private List<com.vip.order.common.pojo.order.vo.OrderGoodsVO> orderGoodsList_;
		
		///<summary>
		/// 订单活动
		///</summary>
		
		private List<com.vip.order.common.pojo.order.vo.OrderActiveVO> orderActiveList_;
		
		public com.vip.order.common.pojo.order.vo.OrderVO GetOrder(){
			return this.order_;
		}
		
		public void SetOrder(com.vip.order.common.pojo.order.vo.OrderVO value){
			this.order_ = value;
		}
		public com.vip.order.common.pojo.order.vo.OrderDetailsSuppInfoVO GetOrderDetailsSuppInfo(){
			return this.orderDetailsSuppInfo_;
		}
		
		public void SetOrderDetailsSuppInfo(com.vip.order.common.pojo.order.vo.OrderDetailsSuppInfoVO value){
			this.orderDetailsSuppInfo_ = value;
		}
		public com.vip.order.common.pojo.order.vo.OrderPayAndDiscountVO GetOrderPayAndDiscount(){
			return this.orderPayAndDiscount_;
		}
		
		public void SetOrderPayAndDiscount(com.vip.order.common.pojo.order.vo.OrderPayAndDiscountVO value){
			this.orderPayAndDiscount_ = value;
		}
		public List<com.vip.order.common.pojo.order.vo.OrderGoodsVO> GetOrderGoodsList(){
			return this.orderGoodsList_;
		}
		
		public void SetOrderGoodsList(List<com.vip.order.common.pojo.order.vo.OrderGoodsVO> value){
			this.orderGoodsList_ = value;
		}
		public List<com.vip.order.common.pojo.order.vo.OrderActiveVO> GetOrderActiveList(){
			return this.orderActiveList_;
		}
		
		public void SetOrderActiveList(List<com.vip.order.common.pojo.order.vo.OrderActiveVO> value){
			this.orderActiveList_ = value;
		}
		
	}
	
}