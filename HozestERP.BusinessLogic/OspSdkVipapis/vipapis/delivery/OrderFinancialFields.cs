using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.delivery{
	
	
	
	
	
	public class OrderFinancialFields {
		
		///<summary>
		/// 订单id
		/// @sampleValue order_id 13413241234
		///</summary>
		
		private string order_id_;
		
		///<summary>
		/// 唯品会订单总金额<br>供应商应收货款+应收运费
		/// @sampleValue vip_order_total_amount 33444.56
		///</summary>
		
		private double? vip_order_total_amount_;
		
		///<summary>
		/// 运费金额
		/// @sampleValue carriage 33.56
		///</summary>
		
		private double? carriage_;
		
		///<summary>
		/// 供应商订单优惠<br>即：供应商针对订单给出的优惠金额
		/// @sampleValue vendor_discount 22.43
		///</summary>
		
		private double? vendor_discount_;
		
		///<summary>
		/// 唯品会抵现总额<br>优惠总额+唯品币支付-供应商优惠总额
		/// @sampleValue vip_total_deduction 23.43
		///</summary>
		
		private double? vip_total_deduction_;
		
		///<summary>
		/// 客户实付金额=唯品卡+在线支付（收银台支付）+唯品钱包
		/// @sampleValue actual_payment_amount 20.43
		///</summary>
		
		private double? actual_payment_amount_;
		
		///<summary>
		/// 供应商给客户开发票的金额=客户实付金额-唯品卡金额
		/// @sampleValue invoice_amount 234.43
		///</summary>
		
		private double? invoice_amount_;
		
		///<summary>
		/// 唯品卡支付金额<br>会员用唯品卡支付的金额，也属于实付金额的一部分，但需供应商单独开票给唯品会
		/// @sampleValue vip_card_amount 234.43
		///</summary>
		
		private double? vip_card_amount_;
		
		///<summary>
		/// 支付时间,时间戳(秒)，如果货到付款为0
		/// @sampleValue pay_time 1472032742
		///</summary>
		
		private long? pay_time_;
		
		///<summary>
		/// 发票类型0-不开发票1-纸质个人发票2-纸质公司发票3-电子发票
		/// @sampleValue invoice_type 1
		///</summary>
		
		private string invoice_type_;
		
		public string GetOrder_id(){
			return this.order_id_;
		}
		
		public void SetOrder_id(string value){
			this.order_id_ = value;
		}
		public double? GetVip_order_total_amount(){
			return this.vip_order_total_amount_;
		}
		
		public void SetVip_order_total_amount(double? value){
			this.vip_order_total_amount_ = value;
		}
		public double? GetCarriage(){
			return this.carriage_;
		}
		
		public void SetCarriage(double? value){
			this.carriage_ = value;
		}
		public double? GetVendor_discount(){
			return this.vendor_discount_;
		}
		
		public void SetVendor_discount(double? value){
			this.vendor_discount_ = value;
		}
		public double? GetVip_total_deduction(){
			return this.vip_total_deduction_;
		}
		
		public void SetVip_total_deduction(double? value){
			this.vip_total_deduction_ = value;
		}
		public double? GetActual_payment_amount(){
			return this.actual_payment_amount_;
		}
		
		public void SetActual_payment_amount(double? value){
			this.actual_payment_amount_ = value;
		}
		public double? GetInvoice_amount(){
			return this.invoice_amount_;
		}
		
		public void SetInvoice_amount(double? value){
			this.invoice_amount_ = value;
		}
		public double? GetVip_card_amount(){
			return this.vip_card_amount_;
		}
		
		public void SetVip_card_amount(double? value){
			this.vip_card_amount_ = value;
		}
		public long? GetPay_time(){
			return this.pay_time_;
		}
		
		public void SetPay_time(long? value){
			this.pay_time_ = value;
		}
		public string GetInvoice_type(){
			return this.invoice_type_;
		}
		
		public void SetInvoice_type(string value){
			this.invoice_type_ = value;
		}
		
	}
	
}