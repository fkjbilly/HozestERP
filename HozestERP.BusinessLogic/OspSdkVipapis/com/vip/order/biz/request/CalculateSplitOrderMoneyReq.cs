using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.request{
	
	
	
	
	
	public class CalculateSplitOrderMoneyReq {
		
		///<summary>
		/// 母单信息
		///</summary>
		
		private com.vip.order.common.pojo.order.vo.OrderVO order_;
		
		///<summary>
		/// 母单支付信息
		///</summary>
		
		private com.vip.order.common.pojo.order.vo.OrderPayAndDiscountVO orderPayAndDiscount_;
		
		///<summary>
		/// 母单商品列表
		///</summary>
		
		private List<com.vip.order.common.pojo.order.vo.OrderGoodsVO> orderGoodsList_;
		
		///<summary>
		/// 母单支付列表
		///</summary>
		
		private List<com.vip.order.common.pojo.order.vo.OrderPayDetailVO> orderPayDetailList_;
		
		///<summary>
		/// 母单活动列表
		///</summary>
		
		private List<com.vip.order.common.pojo.order.vo.OrderActiveVO> orderActiveList_;
		
		///<summary>
		/// 预付订单信息
		///</summary>
		
		private List<com.vip.order.common.pojo.order.vo.PrepayOrderExtendVO> prepayOrderExtendList_;
		
		///<summary>
		/// 拆单子单
		///</summary>
		
		private List<com.vip.order.common.pojo.order.vo.SplitOrderVO> splitOrderList_;
		
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
		public List<com.vip.order.common.pojo.order.vo.OrderGoodsVO> GetOrderGoodsList(){
			return this.orderGoodsList_;
		}
		
		public void SetOrderGoodsList(List<com.vip.order.common.pojo.order.vo.OrderGoodsVO> value){
			this.orderGoodsList_ = value;
		}
		public List<com.vip.order.common.pojo.order.vo.OrderPayDetailVO> GetOrderPayDetailList(){
			return this.orderPayDetailList_;
		}
		
		public void SetOrderPayDetailList(List<com.vip.order.common.pojo.order.vo.OrderPayDetailVO> value){
			this.orderPayDetailList_ = value;
		}
		public List<com.vip.order.common.pojo.order.vo.OrderActiveVO> GetOrderActiveList(){
			return this.orderActiveList_;
		}
		
		public void SetOrderActiveList(List<com.vip.order.common.pojo.order.vo.OrderActiveVO> value){
			this.orderActiveList_ = value;
		}
		public List<com.vip.order.common.pojo.order.vo.PrepayOrderExtendVO> GetPrepayOrderExtendList(){
			return this.prepayOrderExtendList_;
		}
		
		public void SetPrepayOrderExtendList(List<com.vip.order.common.pojo.order.vo.PrepayOrderExtendVO> value){
			this.prepayOrderExtendList_ = value;
		}
		public List<com.vip.order.common.pojo.order.vo.SplitOrderVO> GetSplitOrderList(){
			return this.splitOrderList_;
		}
		
		public void SetSplitOrderList(List<com.vip.order.common.pojo.order.vo.SplitOrderVO> value){
			this.splitOrderList_ = value;
		}
		
	}
	
}