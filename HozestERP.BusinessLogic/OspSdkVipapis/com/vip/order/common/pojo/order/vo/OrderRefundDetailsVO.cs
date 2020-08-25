using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.common.pojo.order.vo{
	
	
	
	
	
	public class OrderRefundDetailsVO {
		
		///<summary>
		/// 订单ID
		///</summary>
		
		private long? orderId_;
		
		///<summary>
		/// 申请单ID,可能是换货，可能是退货，要跟type字段来区分
		///</summary>
		
		private long? applyId_;
		
		///<summary>
		/// 订单操作场景
		///</summary>
		
		private int? orderScenario_;
		
		///<summary>
		/// 支付操作
		///</summary>
		
		private int? payOperation_;
		
		///<summary>
		/// 支付方式
		///</summary>
		
		private int? payType_;
		
		///<summary>
		/// 支付ID
		///</summary>
		
		private int? payId_;
		
		///<summary>
		/// 原支付号
		///</summary>
		
		private string paySn_;
		
		///<summary>
		/// 退款号
		///</summary>
		
		private string refundSn_;
		
		///<summary>
		/// 支付账号
		///</summary>
		
		private string payAccount_;
		
		///<summary>
		/// 退款时间
		///</summary>
		
		private long? refundTime_;
		
		///<summary>
		/// 货币类型
		///</summary>
		
		private string currency_;
		
		///<summary>
		/// 退款金额
		///</summary>
		
		private string refundMoney_;
		
		///<summary>
		/// 退款状态，0：未退款；1：已退款；2：退款中
		///</summary>
		
		private int? refundStatus_;
		
		///<summary>
		/// 支付名称
		///</summary>
		
		private string payTypeName_;
		
		///<summary>
		/// 订单号，查询订单详情时有返回
		///</summary>
		
		private string orderSn_;
		
		///<summary>
		/// 售后类型.1：退货。2：换货
		///</summary>
		
		private int? type_;
		
		///<summary>
		/// 创建时间
		///</summary>
		
		private long? createTime_;
		
		///<summary>
		/// 更新时间
		///</summary>
		
		private long? updateTime_;
		
		///<summary>
		/// 订单售后申请类型
		///</summary>
		
		private int? isDeleted_;
		
		///<summary>
		/// 退款路径
		///</summary>
		
		private int? refundWay_;
		
		///<summary>
		/// 退款请求号前缀;该次退款中,所有资产的退款请求号前缀一致
		///</summary>
		
		private string refundRequestSn_;
		
		///<summary>
		/// 原订单号
		///</summary>
		
		private string originalOrderSn_;
		
		///<summary>
		/// 主键ID
		///</summary>
		
		private long? id_;
		
		///<summary>
		/// 退款请求唯一号
		///</summary>
		
		private string refundRequestDetailSn_;
		
		public long? GetOrderId(){
			return this.orderId_;
		}
		
		public void SetOrderId(long? value){
			this.orderId_ = value;
		}
		public long? GetApplyId(){
			return this.applyId_;
		}
		
		public void SetApplyId(long? value){
			this.applyId_ = value;
		}
		public int? GetOrderScenario(){
			return this.orderScenario_;
		}
		
		public void SetOrderScenario(int? value){
			this.orderScenario_ = value;
		}
		public int? GetPayOperation(){
			return this.payOperation_;
		}
		
		public void SetPayOperation(int? value){
			this.payOperation_ = value;
		}
		public int? GetPayType(){
			return this.payType_;
		}
		
		public void SetPayType(int? value){
			this.payType_ = value;
		}
		public int? GetPayId(){
			return this.payId_;
		}
		
		public void SetPayId(int? value){
			this.payId_ = value;
		}
		public string GetPaySn(){
			return this.paySn_;
		}
		
		public void SetPaySn(string value){
			this.paySn_ = value;
		}
		public string GetRefundSn(){
			return this.refundSn_;
		}
		
		public void SetRefundSn(string value){
			this.refundSn_ = value;
		}
		public string GetPayAccount(){
			return this.payAccount_;
		}
		
		public void SetPayAccount(string value){
			this.payAccount_ = value;
		}
		public long? GetRefundTime(){
			return this.refundTime_;
		}
		
		public void SetRefundTime(long? value){
			this.refundTime_ = value;
		}
		public string GetCurrency(){
			return this.currency_;
		}
		
		public void SetCurrency(string value){
			this.currency_ = value;
		}
		public string GetRefundMoney(){
			return this.refundMoney_;
		}
		
		public void SetRefundMoney(string value){
			this.refundMoney_ = value;
		}
		public int? GetRefundStatus(){
			return this.refundStatus_;
		}
		
		public void SetRefundStatus(int? value){
			this.refundStatus_ = value;
		}
		public string GetPayTypeName(){
			return this.payTypeName_;
		}
		
		public void SetPayTypeName(string value){
			this.payTypeName_ = value;
		}
		public string GetOrderSn(){
			return this.orderSn_;
		}
		
		public void SetOrderSn(string value){
			this.orderSn_ = value;
		}
		public int? GetType(){
			return this.type_;
		}
		
		public void SetType(int? value){
			this.type_ = value;
		}
		public long? GetCreateTime(){
			return this.createTime_;
		}
		
		public void SetCreateTime(long? value){
			this.createTime_ = value;
		}
		public long? GetUpdateTime(){
			return this.updateTime_;
		}
		
		public void SetUpdateTime(long? value){
			this.updateTime_ = value;
		}
		public int? GetIsDeleted(){
			return this.isDeleted_;
		}
		
		public void SetIsDeleted(int? value){
			this.isDeleted_ = value;
		}
		public int? GetRefundWay(){
			return this.refundWay_;
		}
		
		public void SetRefundWay(int? value){
			this.refundWay_ = value;
		}
		public string GetRefundRequestSn(){
			return this.refundRequestSn_;
		}
		
		public void SetRefundRequestSn(string value){
			this.refundRequestSn_ = value;
		}
		public string GetOriginalOrderSn(){
			return this.originalOrderSn_;
		}
		
		public void SetOriginalOrderSn(string value){
			this.originalOrderSn_ = value;
		}
		public long? GetId(){
			return this.id_;
		}
		
		public void SetId(long? value){
			this.id_ = value;
		}
		public string GetRefundRequestDetailSn(){
			return this.refundRequestDetailSn_;
		}
		
		public void SetRefundRequestDetailSn(string value){
			this.refundRequestDetailSn_ = value;
		}
		
	}
	
}