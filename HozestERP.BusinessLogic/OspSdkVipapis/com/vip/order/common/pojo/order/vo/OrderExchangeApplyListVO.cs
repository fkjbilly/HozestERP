using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.common.pojo.order.vo{
	
	
	
	
	
	public class OrderExchangeApplyListVO {
		
		///<summary>
		/// 订单换货申请单
		///</summary>
		
		private com.vip.order.common.pojo.order.vo.OrderExchangeApplyVO orderExchangeApply_;
		
		///<summary>
		/// 订单换货收货地址信息
		///</summary>
		
		private com.vip.order.common.pojo.order.vo.OrderReceiveAddrVO orderExchangeReceiveAddr_;
		
		///<summary>
		/// 订单换货回寄物流信息
		///</summary>
		
		private com.vip.order.common.pojo.order.vo.OrderReturnTransportInfoVO orderExchangeReturnTransportInfo_;
		
		///<summary>
		/// 订单换货商品
		///</summary>
		
		private List<com.vip.order.common.pojo.order.vo.OrderExchangeGoodsVO> orderExchangeGoods_;
		
		///<summary>
		/// 订单换货收包物流信息
		///</summary>
		
		private List<com.vip.order.common.pojo.order.vo.OrderReturnPackageInfoVO> orderExchangeReturnPackageInfo_;
		
		///<summary>
		/// 换货补贴
		///</summary>
		
		private com.vip.order.common.pojo.order.vo.ExchangeBackFeeVO exchangeBackFee_;
		
		public com.vip.order.common.pojo.order.vo.OrderExchangeApplyVO GetOrderExchangeApply(){
			return this.orderExchangeApply_;
		}
		
		public void SetOrderExchangeApply(com.vip.order.common.pojo.order.vo.OrderExchangeApplyVO value){
			this.orderExchangeApply_ = value;
		}
		public com.vip.order.common.pojo.order.vo.OrderReceiveAddrVO GetOrderExchangeReceiveAddr(){
			return this.orderExchangeReceiveAddr_;
		}
		
		public void SetOrderExchangeReceiveAddr(com.vip.order.common.pojo.order.vo.OrderReceiveAddrVO value){
			this.orderExchangeReceiveAddr_ = value;
		}
		public com.vip.order.common.pojo.order.vo.OrderReturnTransportInfoVO GetOrderExchangeReturnTransportInfo(){
			return this.orderExchangeReturnTransportInfo_;
		}
		
		public void SetOrderExchangeReturnTransportInfo(com.vip.order.common.pojo.order.vo.OrderReturnTransportInfoVO value){
			this.orderExchangeReturnTransportInfo_ = value;
		}
		public List<com.vip.order.common.pojo.order.vo.OrderExchangeGoodsVO> GetOrderExchangeGoods(){
			return this.orderExchangeGoods_;
		}
		
		public void SetOrderExchangeGoods(List<com.vip.order.common.pojo.order.vo.OrderExchangeGoodsVO> value){
			this.orderExchangeGoods_ = value;
		}
		public List<com.vip.order.common.pojo.order.vo.OrderReturnPackageInfoVO> GetOrderExchangeReturnPackageInfo(){
			return this.orderExchangeReturnPackageInfo_;
		}
		
		public void SetOrderExchangeReturnPackageInfo(List<com.vip.order.common.pojo.order.vo.OrderReturnPackageInfoVO> value){
			this.orderExchangeReturnPackageInfo_ = value;
		}
		public com.vip.order.common.pojo.order.vo.ExchangeBackFeeVO GetExchangeBackFee(){
			return this.exchangeBackFee_;
		}
		
		public void SetExchangeBackFee(com.vip.order.common.pojo.order.vo.ExchangeBackFeeVO value){
			this.exchangeBackFee_ = value;
		}
		
	}
	
}