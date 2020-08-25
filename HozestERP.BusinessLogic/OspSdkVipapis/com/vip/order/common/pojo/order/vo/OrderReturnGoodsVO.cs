using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.common.pojo.order.vo{
	
	
	
	
	
	public class OrderReturnGoodsVO {
		
		///<summary>
		/// 退货申请单ID
		///</summary>
		
		private long? applyId_;
		
		///<summary>
		/// 订单售后商品id
		///</summary>
		
		private long? orderReturnGoodsId_;
		
		///<summary>
		/// 售后退回id
		///</summary>
		
		private long? orderReturnTransportId_;
		
		///<summary>
		/// 档期、专场的SKU id(对应m_size_id，订单DB字段名为order_return_goods.goods_id)
		///</summary>
		
		private long? merItemNo_;
		
		///<summary>
		/// 条码
		///</summary>
		
		private string sn_;
		
		///<summary>
		/// 商品名称
		///</summary>
		
		private string goodsName_;
		
		///<summary>
		/// 档期、专场名称(原brand_name)
		///</summary>
		
		private string salesName_;
		
		///<summary>
		/// 尺码名称
		///</summary>
		
		private string sizeName_;
		
		///<summary>
		/// 价格id
		///</summary>
		
		private long? priceId_;
		
		///<summary>
		/// 商品sku
		///</summary>
		
		private long? vSkuId_;
		
		///<summary>
		/// 商品版本
		///</summary>
		
		private int? goodsVersion_;
		
		///<summary>
		/// 商品数量
		///</summary>
		
		private int? amount_;
		
		///<summary>
		/// 单价
		///</summary>
		
		private string sellPrice_;
		
		///<summary>
		/// 商品类型
		///</summary>
		
		private string goodsType_;
		
		///<summary>
		/// 异常退货原因ID
		///</summary>
		
		private int? returnReasonId_;
		
		///<summary>
		/// 我司原因
		///</summary>
		
		private string ourReasonFlag_;
		
		///<summary>
		/// 是否特殊退款
		///</summary>
		
		private string specialRefund_;
		
		///<summary>
		/// 特殊退款原因ID
		///</summary>
		
		private int? specialRefundReason_;
		
		///<summary>
		/// 原因描述
		///</summary>
		
		private string reasonRemark_;
		
		///<summary>
		/// 标志。0：已申请未退回；1：有申请已匹配；2：未申请却退回；3：未申请却退回(非本单商品)
		///</summary>
		
		private string goodsBackFlag_;
		
		///<summary>
		/// backTime
		///</summary>
		
		private long? backTime_;
		
		///<summary>
		/// 退货详细原因
		///</summary>
		
		private string returnReasonDetails_;
		
		///<summary>
		/// 数据是否删除，0：未被删除，1：已删除
		///</summary>
		
		private byte? isDeleted_;
		
		///<summary>
		/// 档期、专场的id(对应原brand_id)
		///</summary>
		
		private string salesNo_;
		
		///<summary>
		/// 档期、专场商品id(对应m_id，订单DB字段名为goods_id)
		///</summary>
		
		private int? merchandiseNo_;
		
		///<summary>
		/// 订单ID
		///</summary>
		
		private long? orderId_;
		
		///<summary>
		/// 活动优惠(单件)
		///</summary>
		
		private string exActSubtotal_;
		
		///<summary>
		/// 支付优惠(单件)
		///</summary>
		
		private string exCouponSubTotal_;
		
		///<summary>
		/// 支付优惠(单件)
		///</summary>
		
		private string exPaySubtotal_;
		
		///<summary>
		/// 优惠总金额（单件）
		///</summary>
		
		private string exAllSubtotal_;
		
		///<summary>
		/// 添加时间
		///</summary>
		
		private long? addTime_;
		
		///<summary>
		/// 操作人名称
		///</summary>
		
		private string operatorName_;
		
		///<summary>
		/// 价格时间(时间戳)
		///</summary>
		
		private long? priceTime_;
		
		public long? GetApplyId(){
			return this.applyId_;
		}
		
		public void SetApplyId(long? value){
			this.applyId_ = value;
		}
		public long? GetOrderReturnGoodsId(){
			return this.orderReturnGoodsId_;
		}
		
		public void SetOrderReturnGoodsId(long? value){
			this.orderReturnGoodsId_ = value;
		}
		public long? GetOrderReturnTransportId(){
			return this.orderReturnTransportId_;
		}
		
		public void SetOrderReturnTransportId(long? value){
			this.orderReturnTransportId_ = value;
		}
		public long? GetMerItemNo(){
			return this.merItemNo_;
		}
		
		public void SetMerItemNo(long? value){
			this.merItemNo_ = value;
		}
		public string GetSn(){
			return this.sn_;
		}
		
		public void SetSn(string value){
			this.sn_ = value;
		}
		public string GetGoodsName(){
			return this.goodsName_;
		}
		
		public void SetGoodsName(string value){
			this.goodsName_ = value;
		}
		public string GetSalesName(){
			return this.salesName_;
		}
		
		public void SetSalesName(string value){
			this.salesName_ = value;
		}
		public string GetSizeName(){
			return this.sizeName_;
		}
		
		public void SetSizeName(string value){
			this.sizeName_ = value;
		}
		public long? GetPriceId(){
			return this.priceId_;
		}
		
		public void SetPriceId(long? value){
			this.priceId_ = value;
		}
		public long? GetVSkuId(){
			return this.vSkuId_;
		}
		
		public void SetVSkuId(long? value){
			this.vSkuId_ = value;
		}
		public int? GetGoodsVersion(){
			return this.goodsVersion_;
		}
		
		public void SetGoodsVersion(int? value){
			this.goodsVersion_ = value;
		}
		public int? GetAmount(){
			return this.amount_;
		}
		
		public void SetAmount(int? value){
			this.amount_ = value;
		}
		public string GetSellPrice(){
			return this.sellPrice_;
		}
		
		public void SetSellPrice(string value){
			this.sellPrice_ = value;
		}
		public string GetGoodsType(){
			return this.goodsType_;
		}
		
		public void SetGoodsType(string value){
			this.goodsType_ = value;
		}
		public int? GetReturnReasonId(){
			return this.returnReasonId_;
		}
		
		public void SetReturnReasonId(int? value){
			this.returnReasonId_ = value;
		}
		public string GetOurReasonFlag(){
			return this.ourReasonFlag_;
		}
		
		public void SetOurReasonFlag(string value){
			this.ourReasonFlag_ = value;
		}
		public string GetSpecialRefund(){
			return this.specialRefund_;
		}
		
		public void SetSpecialRefund(string value){
			this.specialRefund_ = value;
		}
		public int? GetSpecialRefundReason(){
			return this.specialRefundReason_;
		}
		
		public void SetSpecialRefundReason(int? value){
			this.specialRefundReason_ = value;
		}
		public string GetReasonRemark(){
			return this.reasonRemark_;
		}
		
		public void SetReasonRemark(string value){
			this.reasonRemark_ = value;
		}
		public string GetGoodsBackFlag(){
			return this.goodsBackFlag_;
		}
		
		public void SetGoodsBackFlag(string value){
			this.goodsBackFlag_ = value;
		}
		public long? GetBackTime(){
			return this.backTime_;
		}
		
		public void SetBackTime(long? value){
			this.backTime_ = value;
		}
		public string GetReturnReasonDetails(){
			return this.returnReasonDetails_;
		}
		
		public void SetReturnReasonDetails(string value){
			this.returnReasonDetails_ = value;
		}
		public byte? GetIsDeleted(){
			return this.isDeleted_;
		}
		
		public void SetIsDeleted(byte? value){
			this.isDeleted_ = value;
		}
		public string GetSalesNo(){
			return this.salesNo_;
		}
		
		public void SetSalesNo(string value){
			this.salesNo_ = value;
		}
		public int? GetMerchandiseNo(){
			return this.merchandiseNo_;
		}
		
		public void SetMerchandiseNo(int? value){
			this.merchandiseNo_ = value;
		}
		public long? GetOrderId(){
			return this.orderId_;
		}
		
		public void SetOrderId(long? value){
			this.orderId_ = value;
		}
		public string GetExActSubtotal(){
			return this.exActSubtotal_;
		}
		
		public void SetExActSubtotal(string value){
			this.exActSubtotal_ = value;
		}
		public string GetExCouponSubTotal(){
			return this.exCouponSubTotal_;
		}
		
		public void SetExCouponSubTotal(string value){
			this.exCouponSubTotal_ = value;
		}
		public string GetExPaySubtotal(){
			return this.exPaySubtotal_;
		}
		
		public void SetExPaySubtotal(string value){
			this.exPaySubtotal_ = value;
		}
		public string GetExAllSubtotal(){
			return this.exAllSubtotal_;
		}
		
		public void SetExAllSubtotal(string value){
			this.exAllSubtotal_ = value;
		}
		public long? GetAddTime(){
			return this.addTime_;
		}
		
		public void SetAddTime(long? value){
			this.addTime_ = value;
		}
		public string GetOperatorName(){
			return this.operatorName_;
		}
		
		public void SetOperatorName(string value){
			this.operatorName_ = value;
		}
		public long? GetPriceTime(){
			return this.priceTime_;
		}
		
		public void SetPriceTime(long? value){
			this.priceTime_ = value;
		}
		
	}
	
}