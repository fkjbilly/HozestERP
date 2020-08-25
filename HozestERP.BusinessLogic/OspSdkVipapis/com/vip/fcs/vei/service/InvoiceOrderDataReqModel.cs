using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.fcs.vei.service{
	
	
	
	
	
	public class InvoiceOrderDataReqModel {
		
		///<summary>
		/// 订单号
		///</summary>
		
		private string orderSn_;
		
		///<summary>
		/// 订单状态
		///</summary>
		
		private string orderState_;
		
		///<summary>
		/// 订单时间（订单的下单时间）。无法提供时传当前时间
		///</summary>
		
		private long? orderDate_;
		
		///<summary>
		/// 开票金额
		///</summary>
		
		private double? orderAmount_;
		
		///<summary>
		/// 付款人电话
		///</summary>
		
		private string customerTel_;
		
		///<summary>
		/// 发票抬头类型。01企业，02机关、事业单位，03个人，04其他（目前全部为03）
		///</summary>
		
		private string titleType_;
		
		///<summary>
		/// 抬头
		///</summary>
		
		private string title_;
		
		///<summary>
		/// 支付方式
		///</summary>
		
		private string payType_;
		
		///<summary>
		/// 收货省
		///</summary>
		
		private string consigneeProvinces_;
		
		///<summary>
		/// 收货市
		///</summary>
		
		private string consigneeCity_;
		
		///<summary>
		/// 发货仓库
		///</summary>
		
		private string warehouse_;
		
		///<summary>
		/// 支付时间。无法提供时传当前时间
		///</summary>
		
		private long? payDate_;
		
		///<summary>
		/// 邮费
		///</summary>
		
		private double? otherAmount_;
		
		///<summary>
		/// 订单id
		///</summary>
		
		private long? orderid_;
		
		///<summary>
		/// 用户id
		///</summary>
		
		private string userid_;
		
		///<summary>
		/// 发票id（order库order_electornic_invoice表的id字段）
		///</summary>
		
		private string orderElectornicInvoiceId_;
		
		///<summary>
		/// 下单平台默认为0。1为pc，2为wap，3为app
		///</summary>
		
		private int? platform_;
		
		///<summary>
		/// 优惠金额
		///</summary>
		
		private double? discountAmount_;
		
		///<summary>
		/// 钱包支付金额（唯品币等）
		///</summary>
		
		private double? walletAmount_;
		
		///<summary>
		/// 在线支付不可开发票的金额
		///</summary>
		
		private double? invoiceDeductMoney_;
		
		///<summary>
		/// 数据来源系统标识（EBS、客服...）。与sourceRecordId字段组合，发现重复记录时报错
		///</summary>
		
		private string source_;
		
		///<summary>
		/// 来源系统记录唯一id(用于防止同一来源系统的重复记录)。与source字段组合，发现重复记录时报错
		///</summary>
		
		private string sourceRecordId_;
		
		///<summary>
		/// 开票类型（1为蓝票，2为红票（全冲红），3为冲红换开蓝票）
		///</summary>
		
		private int? invoiceType_;
		
		///<summary>
		/// 订单行。全冲红（invoiceType为2）时，本字段可为空
		///</summary>
		
		private List<com.vip.fcs.vei.service.OrderItemsModel> orderItems_;
		
		///<summary>
		/// 订单来源频道
		///</summary>
		
		private string vipClub_;
		
		///<summary>
		/// 业务类型
		///</summary>
		
		private string businessType_;
		
		///<summary>
		/// 业务子类型
		///</summary>
		
		private string businessSubType_;
		
		///<summary>
		/// 纳税人识别号或统一社会信用代码
		///</summary>
		
		private string buyerTaxRegisterNo_;
		
		///<summary>
		/// 备注
		///</summary>
		
		private string remark_;
		
		public string GetOrderSn(){
			return this.orderSn_;
		}
		
		public void SetOrderSn(string value){
			this.orderSn_ = value;
		}
		public string GetOrderState(){
			return this.orderState_;
		}
		
		public void SetOrderState(string value){
			this.orderState_ = value;
		}
		public long? GetOrderDate(){
			return this.orderDate_;
		}
		
		public void SetOrderDate(long? value){
			this.orderDate_ = value;
		}
		public double? GetOrderAmount(){
			return this.orderAmount_;
		}
		
		public void SetOrderAmount(double? value){
			this.orderAmount_ = value;
		}
		public string GetCustomerTel(){
			return this.customerTel_;
		}
		
		public void SetCustomerTel(string value){
			this.customerTel_ = value;
		}
		public string GetTitleType(){
			return this.titleType_;
		}
		
		public void SetTitleType(string value){
			this.titleType_ = value;
		}
		public string GetTitle(){
			return this.title_;
		}
		
		public void SetTitle(string value){
			this.title_ = value;
		}
		public string GetPayType(){
			return this.payType_;
		}
		
		public void SetPayType(string value){
			this.payType_ = value;
		}
		public string GetConsigneeProvinces(){
			return this.consigneeProvinces_;
		}
		
		public void SetConsigneeProvinces(string value){
			this.consigneeProvinces_ = value;
		}
		public string GetConsigneeCity(){
			return this.consigneeCity_;
		}
		
		public void SetConsigneeCity(string value){
			this.consigneeCity_ = value;
		}
		public string GetWarehouse(){
			return this.warehouse_;
		}
		
		public void SetWarehouse(string value){
			this.warehouse_ = value;
		}
		public long? GetPayDate(){
			return this.payDate_;
		}
		
		public void SetPayDate(long? value){
			this.payDate_ = value;
		}
		public double? GetOtherAmount(){
			return this.otherAmount_;
		}
		
		public void SetOtherAmount(double? value){
			this.otherAmount_ = value;
		}
		public long? GetOrderid(){
			return this.orderid_;
		}
		
		public void SetOrderid(long? value){
			this.orderid_ = value;
		}
		public string GetUserid(){
			return this.userid_;
		}
		
		public void SetUserid(string value){
			this.userid_ = value;
		}
		public string GetOrderElectornicInvoiceId(){
			return this.orderElectornicInvoiceId_;
		}
		
		public void SetOrderElectornicInvoiceId(string value){
			this.orderElectornicInvoiceId_ = value;
		}
		public int? GetPlatform(){
			return this.platform_;
		}
		
		public void SetPlatform(int? value){
			this.platform_ = value;
		}
		public double? GetDiscountAmount(){
			return this.discountAmount_;
		}
		
		public void SetDiscountAmount(double? value){
			this.discountAmount_ = value;
		}
		public double? GetWalletAmount(){
			return this.walletAmount_;
		}
		
		public void SetWalletAmount(double? value){
			this.walletAmount_ = value;
		}
		public double? GetInvoiceDeductMoney(){
			return this.invoiceDeductMoney_;
		}
		
		public void SetInvoiceDeductMoney(double? value){
			this.invoiceDeductMoney_ = value;
		}
		public string GetSource(){
			return this.source_;
		}
		
		public void SetSource(string value){
			this.source_ = value;
		}
		public string GetSourceRecordId(){
			return this.sourceRecordId_;
		}
		
		public void SetSourceRecordId(string value){
			this.sourceRecordId_ = value;
		}
		public int? GetInvoiceType(){
			return this.invoiceType_;
		}
		
		public void SetInvoiceType(int? value){
			this.invoiceType_ = value;
		}
		public List<com.vip.fcs.vei.service.OrderItemsModel> GetOrderItems(){
			return this.orderItems_;
		}
		
		public void SetOrderItems(List<com.vip.fcs.vei.service.OrderItemsModel> value){
			this.orderItems_ = value;
		}
		public string GetVipClub(){
			return this.vipClub_;
		}
		
		public void SetVipClub(string value){
			this.vipClub_ = value;
		}
		public string GetBusinessType(){
			return this.businessType_;
		}
		
		public void SetBusinessType(string value){
			this.businessType_ = value;
		}
		public string GetBusinessSubType(){
			return this.businessSubType_;
		}
		
		public void SetBusinessSubType(string value){
			this.businessSubType_ = value;
		}
		public string GetBuyerTaxRegisterNo(){
			return this.buyerTaxRegisterNo_;
		}
		
		public void SetBuyerTaxRegisterNo(string value){
			this.buyerTaxRegisterNo_ = value;
		}
		public string GetRemark(){
			return this.remark_;
		}
		
		public void SetRemark(string value){
			this.remark_ = value;
		}
		
	}
	
}