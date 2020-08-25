using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.common.pojo.order.vo{
	
	
	
	
	
	public class OrderReturnApplyListVO {
		
		///<summary>
		/// 订单售后申请单
		///</summary>
		
		private com.vip.order.common.pojo.order.vo.OrderReturnApplyVO orderReturnApply_;
		
		///<summary>
		/// 订单售后取件地址信息
		///</summary>
		
		private com.vip.order.common.pojo.order.vo.OrderReceiveAddrVO orderReturnReceiveAddr_;
		
		///<summary>
		/// 订单售后回寄物流信息
		///</summary>
		
		private com.vip.order.common.pojo.order.vo.OrderReturnTransportInfoVO orderReturnTransportInfo_;
		
		///<summary>
		/// 订单售后商品
		///</summary>
		
		private List<com.vip.order.common.pojo.order.vo.OrderReturnGoodsVO> orderReturnGoods_;
		
		///<summary>
		/// 订单售后收包物流信息
		///</summary>
		
		private List<com.vip.order.common.pojo.order.vo.OrderReturnPackageInfoVO> orderReturnPackageInfo_;
		
		///<summary>
		/// 退货退款信息
		///</summary>
		
		private List<com.vip.order.common.pojo.order.vo.OrderRefundDetailsVO> orderReturnRefundDetailsList_;
		
		public com.vip.order.common.pojo.order.vo.OrderReturnApplyVO GetOrderReturnApply(){
			return this.orderReturnApply_;
		}
		
		public void SetOrderReturnApply(com.vip.order.common.pojo.order.vo.OrderReturnApplyVO value){
			this.orderReturnApply_ = value;
		}
		public com.vip.order.common.pojo.order.vo.OrderReceiveAddrVO GetOrderReturnReceiveAddr(){
			return this.orderReturnReceiveAddr_;
		}
		
		public void SetOrderReturnReceiveAddr(com.vip.order.common.pojo.order.vo.OrderReceiveAddrVO value){
			this.orderReturnReceiveAddr_ = value;
		}
		public com.vip.order.common.pojo.order.vo.OrderReturnTransportInfoVO GetOrderReturnTransportInfo(){
			return this.orderReturnTransportInfo_;
		}
		
		public void SetOrderReturnTransportInfo(com.vip.order.common.pojo.order.vo.OrderReturnTransportInfoVO value){
			this.orderReturnTransportInfo_ = value;
		}
		public List<com.vip.order.common.pojo.order.vo.OrderReturnGoodsVO> GetOrderReturnGoods(){
			return this.orderReturnGoods_;
		}
		
		public void SetOrderReturnGoods(List<com.vip.order.common.pojo.order.vo.OrderReturnGoodsVO> value){
			this.orderReturnGoods_ = value;
		}
		public List<com.vip.order.common.pojo.order.vo.OrderReturnPackageInfoVO> GetOrderReturnPackageInfo(){
			return this.orderReturnPackageInfo_;
		}
		
		public void SetOrderReturnPackageInfo(List<com.vip.order.common.pojo.order.vo.OrderReturnPackageInfoVO> value){
			this.orderReturnPackageInfo_ = value;
		}
		public List<com.vip.order.common.pojo.order.vo.OrderRefundDetailsVO> GetOrderReturnRefundDetailsList(){
			return this.orderReturnRefundDetailsList_;
		}
		
		public void SetOrderReturnRefundDetailsList(List<com.vip.order.common.pojo.order.vo.OrderRefundDetailsVO> value){
			this.orderReturnRefundDetailsList_ = value;
		}
		
	}
	
}