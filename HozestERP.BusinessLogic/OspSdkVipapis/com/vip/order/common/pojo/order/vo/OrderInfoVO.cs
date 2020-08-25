using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.common.pojo.order.vo{
	
	
	
	
	
	public class OrderInfoVO {
		
		///<summary>
		/// 订单模式
		///</summary>
		
		private int? orderCategory_;
		
		///<summary>
		/// 订单信息
		///</summary>
		
		private com.vip.order.common.pojo.order.vo.OrderVO order_;
		
		///<summary>
		/// 订单收货地址信息
		///</summary>
		
		private com.vip.order.common.pojo.order.vo.OrderReceiveAddrVO orderReceiveAddr_;
		
		///<summary>
		/// 订单支付及优惠信息
		///</summary>
		
		private com.vip.order.common.pojo.order.vo.OrderPayAndDiscountVO orderPayAndDiscount_;
		
		///<summary>
		/// 订单商品信息
		///</summary>
		
		private List<com.vip.order.common.pojo.order.vo.OrderGoodsVO> orderGoodsList_;
		
		///<summary>
		/// 订单发票信息
		///</summary>
		
		private com.vip.order.common.pojo.order.vo.OrderInvoiceVO orderInvoice_;
		
		///<summary>
		/// 订单活动
		///</summary>
		
		private List<com.vip.order.common.pojo.order.vo.OrderActiveVO> orderActiveList_;
		
		///<summary>
		/// 预付订单额外信息-弃用，请使用prepayOrderExtendList
		///</summary>
		
		private com.vip.order.common.pojo.order.vo.PrepayOrderExtendVO prepayOrderExtend_;
		
		///<summary>
		/// 订单补充信息
		///</summary>
		
		private com.vip.order.common.pojo.order.vo.OrderDetailsSuppInfoVO orderDetailsSuppInfo_;
		
		///<summary>
		/// 订单可操作状态列表
		///</summary>
		
		private List<com.vip.order.common.pojo.order.vo.OpStatusVO> opStatusList_;
		
		///<summary>
		/// 虚拟仓商品货源发货仓映射列表
		///</summary>
		
		private List<com.vip.order.common.pojo.order.vo.OrderGoodsWarehouseDetailVO> orderGoodsWarehouseDetailList_;
		
		///<summary>
		/// 预付子单信息
		///</summary>
		
		private List<com.vip.order.common.pojo.order.vo.PrepayOrderExtendVO> prepayOrderExtendList_;
		
		///<summary>
		/// 赔付记录
		///</summary>
		
		private com.vip.order.common.pojo.order.vo.OrderCompensateVO orderCompensate_;
		
		///<summary>
		/// 寻仓记录
		///</summary>
		
		private List<com.vip.order.common.pojo.order.vo.OrderWarehouseVO> orderWarehouseList_;
		
		///<summary>
		/// 订单业务属性纵表
		///</summary>
		
		private com.vip.order.common.pojo.order.vo.OrderBizExtAttrVO orderBizExtAttr_;
		
		public int? GetOrderCategory(){
			return this.orderCategory_;
		}
		
		public void SetOrderCategory(int? value){
			this.orderCategory_ = value;
		}
		public com.vip.order.common.pojo.order.vo.OrderVO GetOrder(){
			return this.order_;
		}
		
		public void SetOrder(com.vip.order.common.pojo.order.vo.OrderVO value){
			this.order_ = value;
		}
		public com.vip.order.common.pojo.order.vo.OrderReceiveAddrVO GetOrderReceiveAddr(){
			return this.orderReceiveAddr_;
		}
		
		public void SetOrderReceiveAddr(com.vip.order.common.pojo.order.vo.OrderReceiveAddrVO value){
			this.orderReceiveAddr_ = value;
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
		public com.vip.order.common.pojo.order.vo.OrderInvoiceVO GetOrderInvoice(){
			return this.orderInvoice_;
		}
		
		public void SetOrderInvoice(com.vip.order.common.pojo.order.vo.OrderInvoiceVO value){
			this.orderInvoice_ = value;
		}
		public List<com.vip.order.common.pojo.order.vo.OrderActiveVO> GetOrderActiveList(){
			return this.orderActiveList_;
		}
		
		public void SetOrderActiveList(List<com.vip.order.common.pojo.order.vo.OrderActiveVO> value){
			this.orderActiveList_ = value;
		}
		public com.vip.order.common.pojo.order.vo.PrepayOrderExtendVO GetPrepayOrderExtend(){
			return this.prepayOrderExtend_;
		}
		
		public void SetPrepayOrderExtend(com.vip.order.common.pojo.order.vo.PrepayOrderExtendVO value){
			this.prepayOrderExtend_ = value;
		}
		public com.vip.order.common.pojo.order.vo.OrderDetailsSuppInfoVO GetOrderDetailsSuppInfo(){
			return this.orderDetailsSuppInfo_;
		}
		
		public void SetOrderDetailsSuppInfo(com.vip.order.common.pojo.order.vo.OrderDetailsSuppInfoVO value){
			this.orderDetailsSuppInfo_ = value;
		}
		public List<com.vip.order.common.pojo.order.vo.OpStatusVO> GetOpStatusList(){
			return this.opStatusList_;
		}
		
		public void SetOpStatusList(List<com.vip.order.common.pojo.order.vo.OpStatusVO> value){
			this.opStatusList_ = value;
		}
		public List<com.vip.order.common.pojo.order.vo.OrderGoodsWarehouseDetailVO> GetOrderGoodsWarehouseDetailList(){
			return this.orderGoodsWarehouseDetailList_;
		}
		
		public void SetOrderGoodsWarehouseDetailList(List<com.vip.order.common.pojo.order.vo.OrderGoodsWarehouseDetailVO> value){
			this.orderGoodsWarehouseDetailList_ = value;
		}
		public List<com.vip.order.common.pojo.order.vo.PrepayOrderExtendVO> GetPrepayOrderExtendList(){
			return this.prepayOrderExtendList_;
		}
		
		public void SetPrepayOrderExtendList(List<com.vip.order.common.pojo.order.vo.PrepayOrderExtendVO> value){
			this.prepayOrderExtendList_ = value;
		}
		public com.vip.order.common.pojo.order.vo.OrderCompensateVO GetOrderCompensate(){
			return this.orderCompensate_;
		}
		
		public void SetOrderCompensate(com.vip.order.common.pojo.order.vo.OrderCompensateVO value){
			this.orderCompensate_ = value;
		}
		public List<com.vip.order.common.pojo.order.vo.OrderWarehouseVO> GetOrderWarehouseList(){
			return this.orderWarehouseList_;
		}
		
		public void SetOrderWarehouseList(List<com.vip.order.common.pojo.order.vo.OrderWarehouseVO> value){
			this.orderWarehouseList_ = value;
		}
		public com.vip.order.common.pojo.order.vo.OrderBizExtAttrVO GetOrderBizExtAttr(){
			return this.orderBizExtAttr_;
		}
		
		public void SetOrderBizExtAttr(com.vip.order.common.pojo.order.vo.OrderBizExtAttrVO value){
			this.orderBizExtAttr_ = value;
		}
		
	}
	
}