using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.common.pojo.order.vo{
	
	
	
	
	
	public class SplitOrderVO {
		
		///<summary>
		/// 子单订单
		///</summary>
		
		private com.vip.order.common.pojo.order.vo.OrderVO order_;
		
		///<summary>
		/// 子单商品列表
		///</summary>
		
		private List<com.vip.order.common.pojo.order.vo.OrderGoodsVO> orderGoodsList_;
		
		///<summary>
		/// 子单活动列表
		///</summary>
		
		private List<com.vip.order.common.pojo.order.vo.OrderActiveVO> orderActiveList_;
		
		///<summary>
		/// 子单预付金额分摊明细
		///</summary>
		
		private List<com.vip.order.common.pojo.order.vo.PrepayOrderMoneyDetailVO> prepayOrderMoneyDetailList_;
		
		///<summary>
		/// 子单支付信息明细
		///</summary>
		
		private List<com.vip.order.common.pojo.order.vo.OrderPayDetailVO> payDetailList_;
		
		///<summary>
		/// 子单支付信息
		///</summary>
		
		private com.vip.order.common.pojo.order.vo.OrderPayAndDiscountVO orderPayAndDiscount_;
		
		///<summary>
		/// 虚拟仓商品货源发货仓映射
		///</summary>
		
		private List<com.vip.order.common.pojo.order.vo.OrderGoodsWarehouseDetailVO> goodsWarehouseList_;
		
		///<summary>
		/// 发票
		///</summary>
		
		private com.vip.order.common.pojo.order.vo.OrderInvoiceVO orderInvoice_;
		
		///<summary>
		/// 寻仓记录
		///</summary>
		
		private List<com.vip.order.common.pojo.order.vo.OrderWarehouseVO> orderWarehouseList_;
		
		public com.vip.order.common.pojo.order.vo.OrderVO GetOrder(){
			return this.order_;
		}
		
		public void SetOrder(com.vip.order.common.pojo.order.vo.OrderVO value){
			this.order_ = value;
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
		public List<com.vip.order.common.pojo.order.vo.PrepayOrderMoneyDetailVO> GetPrepayOrderMoneyDetailList(){
			return this.prepayOrderMoneyDetailList_;
		}
		
		public void SetPrepayOrderMoneyDetailList(List<com.vip.order.common.pojo.order.vo.PrepayOrderMoneyDetailVO> value){
			this.prepayOrderMoneyDetailList_ = value;
		}
		public List<com.vip.order.common.pojo.order.vo.OrderPayDetailVO> GetPayDetailList(){
			return this.payDetailList_;
		}
		
		public void SetPayDetailList(List<com.vip.order.common.pojo.order.vo.OrderPayDetailVO> value){
			this.payDetailList_ = value;
		}
		public com.vip.order.common.pojo.order.vo.OrderPayAndDiscountVO GetOrderPayAndDiscount(){
			return this.orderPayAndDiscount_;
		}
		
		public void SetOrderPayAndDiscount(com.vip.order.common.pojo.order.vo.OrderPayAndDiscountVO value){
			this.orderPayAndDiscount_ = value;
		}
		public List<com.vip.order.common.pojo.order.vo.OrderGoodsWarehouseDetailVO> GetGoodsWarehouseList(){
			return this.goodsWarehouseList_;
		}
		
		public void SetGoodsWarehouseList(List<com.vip.order.common.pojo.order.vo.OrderGoodsWarehouseDetailVO> value){
			this.goodsWarehouseList_ = value;
		}
		public com.vip.order.common.pojo.order.vo.OrderInvoiceVO GetOrderInvoice(){
			return this.orderInvoice_;
		}
		
		public void SetOrderInvoice(com.vip.order.common.pojo.order.vo.OrderInvoiceVO value){
			this.orderInvoice_ = value;
		}
		public List<com.vip.order.common.pojo.order.vo.OrderWarehouseVO> GetOrderWarehouseList(){
			return this.orderWarehouseList_;
		}
		
		public void SetOrderWarehouseList(List<com.vip.order.common.pojo.order.vo.OrderWarehouseVO> value){
			this.orderWarehouseList_ = value;
		}
		
	}
	
}