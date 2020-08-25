using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.common.pojo.order.vo{
	
	
	
	
	
	public class OrderPayDetailVO {
		
		///<summary>
		/// 支付明细状态，0：未支付；1：已支付；2：支付中
		///</summary>
		
		private int? payStatus_;
		
		///<summary>
		/// 支付方式
		///</summary>
		
		private int? payType_;
		
		///<summary>
		/// 支付时间
		///</summary>
		
		private long? payTime_;
		
		///<summary>
		/// 支付号或退款号
		///</summary>
		
		private string paySn_;
		
		///<summary>
		/// 支付操作
		///</summary>
		
		private int? payOperation_;
		
		///<summary>
		/// 支付金额
		///</summary>
		
		private string payMoney_;
		
		///<summary>
		/// 支付ID
		///</summary>
		
		private int? payId_;
		
		///<summary>
		/// 支付账号
		///</summary>
		
		private string payAccount_;
		
		///<summary>
		/// 订单操作场景
		///</summary>
		
		private int? orderScenario_;
		
		///<summary>
		/// 货币类型
		///</summary>
		
		private string currency_;
		
		///<summary>
		/// 订单号
		///</summary>
		
		private long? orderId_;
		
		///<summary>
		/// 记录Id,对外接口不返回
		///</summary>
		
		private long? payDetailId_;
		
		///<summary>
		/// 原始订单号
		///</summary>
		
		private string originalOrderSn_;
		
		///<summary>
		/// 分期数
		///</summary>
		
		private int? period_;
		
		///<summary>
		/// 原始支付号或退款号
		///</summary>
		
		private string originalPaySn_;
		
		///<summary>
		/// 退款路径
		///</summary>
		
		private int? refundWay_;
		
		///<summary>
		/// 退款请求号
		///</summary>
		
		private string refundRequestSn_;
		
		///<summary>
		/// 创建时间
		///</summary>
		
		private long? createTime_;
		
		///<summary>
		/// 更新时间
		///</summary>
		
		private long? updateTime_;
		
		///<summary>
		/// ID
		///</summary>
		
		private long? id_;
		
		public int? GetPayStatus(){
			return this.payStatus_;
		}
		
		public void SetPayStatus(int? value){
			this.payStatus_ = value;
		}
		public int? GetPayType(){
			return this.payType_;
		}
		
		public void SetPayType(int? value){
			this.payType_ = value;
		}
		public long? GetPayTime(){
			return this.payTime_;
		}
		
		public void SetPayTime(long? value){
			this.payTime_ = value;
		}
		public string GetPaySn(){
			return this.paySn_;
		}
		
		public void SetPaySn(string value){
			this.paySn_ = value;
		}
		public int? GetPayOperation(){
			return this.payOperation_;
		}
		
		public void SetPayOperation(int? value){
			this.payOperation_ = value;
		}
		public string GetPayMoney(){
			return this.payMoney_;
		}
		
		public void SetPayMoney(string value){
			this.payMoney_ = value;
		}
		public int? GetPayId(){
			return this.payId_;
		}
		
		public void SetPayId(int? value){
			this.payId_ = value;
		}
		public string GetPayAccount(){
			return this.payAccount_;
		}
		
		public void SetPayAccount(string value){
			this.payAccount_ = value;
		}
		public int? GetOrderScenario(){
			return this.orderScenario_;
		}
		
		public void SetOrderScenario(int? value){
			this.orderScenario_ = value;
		}
		public string GetCurrency(){
			return this.currency_;
		}
		
		public void SetCurrency(string value){
			this.currency_ = value;
		}
		public long? GetOrderId(){
			return this.orderId_;
		}
		
		public void SetOrderId(long? value){
			this.orderId_ = value;
		}
		public long? GetPayDetailId(){
			return this.payDetailId_;
		}
		
		public void SetPayDetailId(long? value){
			this.payDetailId_ = value;
		}
		public string GetOriginalOrderSn(){
			return this.originalOrderSn_;
		}
		
		public void SetOriginalOrderSn(string value){
			this.originalOrderSn_ = value;
		}
		public int? GetPeriod(){
			return this.period_;
		}
		
		public void SetPeriod(int? value){
			this.period_ = value;
		}
		public string GetOriginalPaySn(){
			return this.originalPaySn_;
		}
		
		public void SetOriginalPaySn(string value){
			this.originalPaySn_ = value;
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
		public long? GetId(){
			return this.id_;
		}
		
		public void SetId(long? value){
			this.id_ = value;
		}
		
	}
	
}