using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.common.pojo.order.vo{
	
	
	
	
	
	public class OrderInfoForReq {
		
		///<summary>
		/// 订单信息
		///</summary>
		
		private com.vip.order.common.pojo.order.vo.OrderVO order_;
		
		///<summary>
		/// 订单支付及优惠信息
		///</summary>
		
		private com.vip.order.common.pojo.order.vo.OrderPayAndDiscountVO orderPayAndDiscount_;
		
		///<summary>
		/// 订单支付详情
		///</summary>
		
		private com.vip.order.common.pojo.order.vo.OrderPayDetailVO orderPayDetail_;
		
		///<summary>
		/// 订单分期付款信息
		///</summary>
		
		private com.vip.order.common.pojo.order.vo.OrderPayInstalmentVO orderPayInstalment_;
		
		///<summary>
		/// 订单商品信息
		///</summary>
		
		private List<com.vip.order.common.pojo.order.vo.OrderGoodsVO> orderGoodsList_;
		
		///<summary>
		/// 订单活动
		///</summary>
		
		private com.vip.order.common.pojo.order.vo.OrderActiveVO orderActive_;
		
		///<summary>
		/// 订单活动
		///</summary>
		
		private com.vip.order.common.pojo.order.vo.OrderLogsVO orderLog_;
		
		///<summary>
		/// 预付订单信息
		///</summary>
		
		private com.vip.order.common.pojo.order.vo.PrepayOrderExtendVO prepayOrderExtendVO_;
		
		public com.vip.order.common.pojo.order.vo.OrderVO GetOrder(){
			return this.order_;
		}
		
		public void SetOrder(com.vip.order.common.pojo.order.vo.OrderVO value){
			this.order_ = value;
		}
		public com.vip.order.common.pojo.order.vo.OrderPayAndDiscountVO GetOrderPayAndDiscount(){
			return this.orderPayAndDiscount_;
		}
		
		public void SetOrderPayAndDiscount(com.vip.order.common.pojo.order.vo.OrderPayAndDiscountVO value){
			this.orderPayAndDiscount_ = value;
		}
		public com.vip.order.common.pojo.order.vo.OrderPayDetailVO GetOrderPayDetail(){
			return this.orderPayDetail_;
		}
		
		public void SetOrderPayDetail(com.vip.order.common.pojo.order.vo.OrderPayDetailVO value){
			this.orderPayDetail_ = value;
		}
		public com.vip.order.common.pojo.order.vo.OrderPayInstalmentVO GetOrderPayInstalment(){
			return this.orderPayInstalment_;
		}
		
		public void SetOrderPayInstalment(com.vip.order.common.pojo.order.vo.OrderPayInstalmentVO value){
			this.orderPayInstalment_ = value;
		}
		public List<com.vip.order.common.pojo.order.vo.OrderGoodsVO> GetOrderGoodsList(){
			return this.orderGoodsList_;
		}
		
		public void SetOrderGoodsList(List<com.vip.order.common.pojo.order.vo.OrderGoodsVO> value){
			this.orderGoodsList_ = value;
		}
		public com.vip.order.common.pojo.order.vo.OrderActiveVO GetOrderActive(){
			return this.orderActive_;
		}
		
		public void SetOrderActive(com.vip.order.common.pojo.order.vo.OrderActiveVO value){
			this.orderActive_ = value;
		}
		public com.vip.order.common.pojo.order.vo.OrderLogsVO GetOrderLog(){
			return this.orderLog_;
		}
		
		public void SetOrderLog(com.vip.order.common.pojo.order.vo.OrderLogsVO value){
			this.orderLog_ = value;
		}
		public com.vip.order.common.pojo.order.vo.PrepayOrderExtendVO GetPrepayOrderExtendVO(){
			return this.prepayOrderExtendVO_;
		}
		
		public void SetPrepayOrderExtendVO(com.vip.order.common.pojo.order.vo.PrepayOrderExtendVO value){
			this.prepayOrderExtendVO_ = value;
		}
		
	}
	
}