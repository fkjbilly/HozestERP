using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.common.pojo.order.vo{
	
	
	
	
	
	public class PrepayOrderExtendVO {
		
		///<summary>
		/// 父订单号
		///</summary>
		
		private string parentSn_;
		
		///<summary>
		/// 预付订单流水号
		///</summary>
		
		private string orderCode_;
		
		///<summary>
		/// 预付款支付期数
		///</summary>
		
		private int? periods_;
		
		///<summary>
		/// 是否首单
		///</summary>
		
		private int? isFirst_;
		
		///<summary>
		/// 是否尾单
		///</summary>
		
		private int? isLast_;
		
		///<summary>
		/// 是否锁住
		///</summary>
		
		private int? isLock_;
		
		///<summary>
		/// 支付ID
		///</summary>
		
		private long? payId_;
		
		///<summary>
		/// 预付订单总应付金额
		///</summary>
		
		private string totalMoney_;
		
		///<summary>
		/// 支付开始时间
		///</summary>
		
		private long? startPayTime_;
		
		///<summary>
		/// 支付结束时间
		///</summary>
		
		private long? endPayTime_;
		
		///<summary>
		/// 订单ID
		///</summary>
		
		private long? orderId_;
		
		///<summary>
		/// 订单子状态标识 0-无异常 1-身份验证未通过
		///</summary>
		
		private long? orderAddTime_;
		
		///<summary>
		/// orders.create_time
		///</summary>
		
		private long? createTime_;
		
		///<summary>
		/// 订单支付金额
		///</summary>
		
		private string moneyPaid_;
		
		///<summary>
		/// 审核时间
		///</summary>
		
		private long? auditTime_;
		
		///<summary>
		/// 代金券ID
		///</summary>
		
		private int? couponId_;
		
		///<summary>
		/// 代金券使用金额
		///</summary>
		
		private string couponMoneyPaid_;
		
		///<summary>
		/// 标识订单的货币种类
		///</summary>
		
		private string currency_;
		
		///<summary>
		/// 下单时间
		///</summary>
		
		private long? orderDate_;
		
		///<summary>
		/// 折扣率
		///</summary>
		
		private string discountRate_;
		
		///<summary>
		/// 下单ip
		///</summary>
		
		private string userIp_;
		
		///<summary>
		/// 保留订单标识
		///</summary>
		
		private int? isHold_;
		
		///<summary>
		/// 订单状态
		///</summary>
		
		private int? isSpecial_;
		
		///<summary>
		/// 订单日志操作状态
		///</summary>
		
		private int? opFlag_;
		
		///<summary>
		/// 操作者
		///</summary>
		
		private string operator_;
		
		///<summary>
		/// 退换货标志
		///</summary>
		
		private string orderFlag_;
		
		///<summary>
		/// 支付状态
		///</summary>
		
		private int? payStatus_;
		
		///<summary>
		/// 支付时间
		///</summary>
		
		private long? payTime_;
		
		///<summary>
		/// 支付方式
		///</summary>
		
		private int? payType_;
		
		///<summary>
		/// 退款方式
		///</summary>
		
		private int? returnType_;
		
		///<summary>
		/// 订单来源
		///</summary>
		
		private string source_;
		
		///<summary>
		/// 订单状态
		///</summary>
		
		private int? orderStatus_;
		
		///<summary>
		/// 账户余额支付金额
		///</summary>
		
		private string walletMoneyPaid_;
		
		///<summary>
		/// 订单类型
		///</summary>
		
		private int? orderType_;
		
		///<summary>
		/// 最后更新时间
		///</summary>
		
		private long? orderUpdateTime_;
		
		///<summary>
		/// 用户id
		///</summary>
		
		private long? userId_;
		
		///<summary>
		/// 用户名
		///</summary>
		
		private string userName_;
		
		///<summary>
		/// 虚拟金额
		///</summary>
		
		private string virtualMoneyPaid_;
		
		///<summary>
		/// WMS抓取状态
		///</summary>
		
		private int? wmsFlag_;
		
		///<summary>
		/// 支付方式中文名
		///</summary>
		
		private string payTypeName_;
		
		///<summary>
		/// 真实的支付方式中文名
		///</summary>
		
		private string realPayTypeName_;
		
		///<summary>
		/// 支付状态中文名
		///</summary>
		
		private string payStatusName_;
		
		///<summary>
		/// 订单类型中文名
		///</summary>
		
		private string orderTypeName_;
		
		///<summary>
		/// 订单状态中文名
		///</summary>
		
		private string orderStatusName_;
		
		///<summary>
		/// 客服端类型
		///</summary>
		
		private int? clientType_;
		
		///<summary>
		/// queue_status
		///</summary>
		
		private int? queueStatus_;
		
		///<summary>
		/// 订单子状态标识
		///</summary>
		
		private int? orderSubStatus_;
		
		public string GetParentSn(){
			return this.parentSn_;
		}
		
		public void SetParentSn(string value){
			this.parentSn_ = value;
		}
		public string GetOrderCode(){
			return this.orderCode_;
		}
		
		public void SetOrderCode(string value){
			this.orderCode_ = value;
		}
		public int? GetPeriods(){
			return this.periods_;
		}
		
		public void SetPeriods(int? value){
			this.periods_ = value;
		}
		public int? GetIsFirst(){
			return this.isFirst_;
		}
		
		public void SetIsFirst(int? value){
			this.isFirst_ = value;
		}
		public int? GetIsLast(){
			return this.isLast_;
		}
		
		public void SetIsLast(int? value){
			this.isLast_ = value;
		}
		public int? GetIsLock(){
			return this.isLock_;
		}
		
		public void SetIsLock(int? value){
			this.isLock_ = value;
		}
		public long? GetPayId(){
			return this.payId_;
		}
		
		public void SetPayId(long? value){
			this.payId_ = value;
		}
		public string GetTotalMoney(){
			return this.totalMoney_;
		}
		
		public void SetTotalMoney(string value){
			this.totalMoney_ = value;
		}
		public long? GetStartPayTime(){
			return this.startPayTime_;
		}
		
		public void SetStartPayTime(long? value){
			this.startPayTime_ = value;
		}
		public long? GetEndPayTime(){
			return this.endPayTime_;
		}
		
		public void SetEndPayTime(long? value){
			this.endPayTime_ = value;
		}
		public long? GetOrderId(){
			return this.orderId_;
		}
		
		public void SetOrderId(long? value){
			this.orderId_ = value;
		}
		public long? GetOrderAddTime(){
			return this.orderAddTime_;
		}
		
		public void SetOrderAddTime(long? value){
			this.orderAddTime_ = value;
		}
		public long? GetCreateTime(){
			return this.createTime_;
		}
		
		public void SetCreateTime(long? value){
			this.createTime_ = value;
		}
		public string GetMoneyPaid(){
			return this.moneyPaid_;
		}
		
		public void SetMoneyPaid(string value){
			this.moneyPaid_ = value;
		}
		public long? GetAuditTime(){
			return this.auditTime_;
		}
		
		public void SetAuditTime(long? value){
			this.auditTime_ = value;
		}
		public int? GetCouponId(){
			return this.couponId_;
		}
		
		public void SetCouponId(int? value){
			this.couponId_ = value;
		}
		public string GetCouponMoneyPaid(){
			return this.couponMoneyPaid_;
		}
		
		public void SetCouponMoneyPaid(string value){
			this.couponMoneyPaid_ = value;
		}
		public string GetCurrency(){
			return this.currency_;
		}
		
		public void SetCurrency(string value){
			this.currency_ = value;
		}
		public long? GetOrderDate(){
			return this.orderDate_;
		}
		
		public void SetOrderDate(long? value){
			this.orderDate_ = value;
		}
		public string GetDiscountRate(){
			return this.discountRate_;
		}
		
		public void SetDiscountRate(string value){
			this.discountRate_ = value;
		}
		public string GetUserIp(){
			return this.userIp_;
		}
		
		public void SetUserIp(string value){
			this.userIp_ = value;
		}
		public int? GetIsHold(){
			return this.isHold_;
		}
		
		public void SetIsHold(int? value){
			this.isHold_ = value;
		}
		public int? GetIsSpecial(){
			return this.isSpecial_;
		}
		
		public void SetIsSpecial(int? value){
			this.isSpecial_ = value;
		}
		public int? GetOpFlag(){
			return this.opFlag_;
		}
		
		public void SetOpFlag(int? value){
			this.opFlag_ = value;
		}
		public string GetOperator(){
			return this.operator_;
		}
		
		public void SetOperator(string value){
			this.operator_ = value;
		}
		public string GetOrderFlag(){
			return this.orderFlag_;
		}
		
		public void SetOrderFlag(string value){
			this.orderFlag_ = value;
		}
		public int? GetPayStatus(){
			return this.payStatus_;
		}
		
		public void SetPayStatus(int? value){
			this.payStatus_ = value;
		}
		public long? GetPayTime(){
			return this.payTime_;
		}
		
		public void SetPayTime(long? value){
			this.payTime_ = value;
		}
		public int? GetPayType(){
			return this.payType_;
		}
		
		public void SetPayType(int? value){
			this.payType_ = value;
		}
		public int? GetReturnType(){
			return this.returnType_;
		}
		
		public void SetReturnType(int? value){
			this.returnType_ = value;
		}
		public string GetSource(){
			return this.source_;
		}
		
		public void SetSource(string value){
			this.source_ = value;
		}
		public int? GetOrderStatus(){
			return this.orderStatus_;
		}
		
		public void SetOrderStatus(int? value){
			this.orderStatus_ = value;
		}
		public string GetWalletMoneyPaid(){
			return this.walletMoneyPaid_;
		}
		
		public void SetWalletMoneyPaid(string value){
			this.walletMoneyPaid_ = value;
		}
		public int? GetOrderType(){
			return this.orderType_;
		}
		
		public void SetOrderType(int? value){
			this.orderType_ = value;
		}
		public long? GetOrderUpdateTime(){
			return this.orderUpdateTime_;
		}
		
		public void SetOrderUpdateTime(long? value){
			this.orderUpdateTime_ = value;
		}
		public long? GetUserId(){
			return this.userId_;
		}
		
		public void SetUserId(long? value){
			this.userId_ = value;
		}
		public string GetUserName(){
			return this.userName_;
		}
		
		public void SetUserName(string value){
			this.userName_ = value;
		}
		public string GetVirtualMoneyPaid(){
			return this.virtualMoneyPaid_;
		}
		
		public void SetVirtualMoneyPaid(string value){
			this.virtualMoneyPaid_ = value;
		}
		public int? GetWmsFlag(){
			return this.wmsFlag_;
		}
		
		public void SetWmsFlag(int? value){
			this.wmsFlag_ = value;
		}
		public string GetPayTypeName(){
			return this.payTypeName_;
		}
		
		public void SetPayTypeName(string value){
			this.payTypeName_ = value;
		}
		public string GetRealPayTypeName(){
			return this.realPayTypeName_;
		}
		
		public void SetRealPayTypeName(string value){
			this.realPayTypeName_ = value;
		}
		public string GetPayStatusName(){
			return this.payStatusName_;
		}
		
		public void SetPayStatusName(string value){
			this.payStatusName_ = value;
		}
		public string GetOrderTypeName(){
			return this.orderTypeName_;
		}
		
		public void SetOrderTypeName(string value){
			this.orderTypeName_ = value;
		}
		public string GetOrderStatusName(){
			return this.orderStatusName_;
		}
		
		public void SetOrderStatusName(string value){
			this.orderStatusName_ = value;
		}
		public int? GetClientType(){
			return this.clientType_;
		}
		
		public void SetClientType(int? value){
			this.clientType_ = value;
		}
		public int? GetQueueStatus(){
			return this.queueStatus_;
		}
		
		public void SetQueueStatus(int? value){
			this.queueStatus_ = value;
		}
		public int? GetOrderSubStatus(){
			return this.orderSubStatus_;
		}
		
		public void SetOrderSubStatus(int? value){
			this.orderSubStatus_ = value;
		}
		
	}
	
}