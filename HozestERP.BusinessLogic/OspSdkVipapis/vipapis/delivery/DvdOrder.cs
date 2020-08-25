using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.delivery{
	
	
	
	
	
	public class DvdOrder {
		
		///<summary>
		/// 订单编号
		///</summary>
		
		private string order_id_;
		
		///<summary>
		/// 订单状态编码
		///</summary>
		
		private string order_status_;
		
		///<summary>
		/// 收货人
		///</summary>
		
		private string buyer_;
		
		///<summary>
		/// 收货地址
		///</summary>
		
		private string address_;
		
		///<summary>
		/// 手机号码
		///</summary>
		
		private string mobile_;
		
		///<summary>
		/// 联系电话
		///</summary>
		
		private string tel_;
		
		///<summary>
		/// 邮政编码
		///</summary>
		
		private string postcode_;
		
		///<summary>
		/// 城市
		///</summary>
		
		private string city_;
		
		///<summary>
		/// 省份
		///</summary>
		
		private string province_;
		
		///<summary>
		/// 国家代码
		///</summary>
		
		private string country_id_;
		
		///<summary>
		/// 发票抬头
		///</summary>
		
		private string invoice_;
		
		///<summary>
		/// 快递金额（计算 整张出库单商品金额总和+快递费用 == 订单金额）
		///</summary>
		
		private string carriage_;
		
		///<summary>
		/// 备注
		///</summary>
		
		private string remark_;
		
		///<summary>
		/// 期望收货时间
		///</summary>
		
		private string transport_day_;
		
		///<summary>
		/// 供应商ID
		///</summary>
		
		private int? vendor_id_;
		
		///<summary>
		/// 供应商名称
		///</summary>
		
		private string vendor_name_;
		
		///<summary>
		/// <s><font color='red'>促销优惠金额(已弃用)</font></s>
		///</summary>
		
		private string promo_discount_amount_;
		
		///<summary>
		/// <s><font color='red'>优惠金额(已弃用)</font></s>
		///</summary>
		
		private string discount_amount_;
		
		///<summary>
		/// 整张出库单所有商品的金额总和(正常单价之和，不计折扣，不包含运费)
		///</summary>
		
		private string product_money_;
		
		///<summary>
		/// 订单下单时间
		///</summary>
		
		private string add_time_;
		
		///<summary>
		/// PO单编号
		///</summary>
		
		private string po_no_;
		
		///<summary>
		/// 区/县
		///</summary>
		
		private string country_;
		
		///<summary>
		/// vis系统订单创建时间格式：2015-01-06 15:53:07
		///</summary>
		
		private string vis_add_time_;
		
		///<summary>
		/// 唯品会订单总金额
		///</summary>
		
		private double? vip_order_total_amount_;
		
		///<summary>
		/// <s><font color='red'>客户实付金额(已弃用)</font></s>
		///</summary>
		
		private double? actual_payment_amount_;
		
		///<summary>
		/// 给客户开票金额
		///</summary>
		
		private double? invoice_amount_;
		
		///<summary>
		/// 唯品卡支付金额
		///</summary>
		
		private double? vip_card_amount_;
		
		///<summary>
		/// 发票类型；发票类型0-不开发票1-纸质个人发票2-纸质公司发票3-电子发票
		///</summary>
		
		private string invoice_type_;
		
		///<summary>
		/// 纳税人识别号
		///</summary>
		
		private string tax_pay_no_;
		
		///<summary>
		/// 分区仓库
		///</summary>
		
		private string area_warehouse_id_;
		
		public string GetOrder_id(){
			return this.order_id_;
		}
		
		public void SetOrder_id(string value){
			this.order_id_ = value;
		}
		public string GetOrder_status(){
			return this.order_status_;
		}
		
		public void SetOrder_status(string value){
			this.order_status_ = value;
		}
		public string GetBuyer(){
			return this.buyer_;
		}
		
		public void SetBuyer(string value){
			this.buyer_ = value;
		}
		public string GetAddress(){
			return this.address_;
		}
		
		public void SetAddress(string value){
			this.address_ = value;
		}
		public string GetMobile(){
			return this.mobile_;
		}
		
		public void SetMobile(string value){
			this.mobile_ = value;
		}
		public string GetTel(){
			return this.tel_;
		}
		
		public void SetTel(string value){
			this.tel_ = value;
		}
		public string GetPostcode(){
			return this.postcode_;
		}
		
		public void SetPostcode(string value){
			this.postcode_ = value;
		}
		public string GetCity(){
			return this.city_;
		}
		
		public void SetCity(string value){
			this.city_ = value;
		}
		public string GetProvince(){
			return this.province_;
		}
		
		public void SetProvince(string value){
			this.province_ = value;
		}
		public string GetCountry_id(){
			return this.country_id_;
		}
		
		public void SetCountry_id(string value){
			this.country_id_ = value;
		}
		public string GetInvoice(){
			return this.invoice_;
		}
		
		public void SetInvoice(string value){
			this.invoice_ = value;
		}
		public string GetCarriage(){
			return this.carriage_;
		}
		
		public void SetCarriage(string value){
			this.carriage_ = value;
		}
		public string GetRemark(){
			return this.remark_;
		}
		
		public void SetRemark(string value){
			this.remark_ = value;
		}
		public string GetTransport_day(){
			return this.transport_day_;
		}
		
		public void SetTransport_day(string value){
			this.transport_day_ = value;
		}
		public int? GetVendor_id(){
			return this.vendor_id_;
		}
		
		public void SetVendor_id(int? value){
			this.vendor_id_ = value;
		}
		public string GetVendor_name(){
			return this.vendor_name_;
		}
		
		public void SetVendor_name(string value){
			this.vendor_name_ = value;
		}
		public string GetPromo_discount_amount(){
			return this.promo_discount_amount_;
		}
		
		public void SetPromo_discount_amount(string value){
			this.promo_discount_amount_ = value;
		}
		public string GetDiscount_amount(){
			return this.discount_amount_;
		}
		
		public void SetDiscount_amount(string value){
			this.discount_amount_ = value;
		}
		public string GetProduct_money(){
			return this.product_money_;
		}
		
		public void SetProduct_money(string value){
			this.product_money_ = value;
		}
		public string GetAdd_time(){
			return this.add_time_;
		}
		
		public void SetAdd_time(string value){
			this.add_time_ = value;
		}
		public string GetPo_no(){
			return this.po_no_;
		}
		
		public void SetPo_no(string value){
			this.po_no_ = value;
		}
		public string GetCountry(){
			return this.country_;
		}
		
		public void SetCountry(string value){
			this.country_ = value;
		}
		public string GetVis_add_time(){
			return this.vis_add_time_;
		}
		
		public void SetVis_add_time(string value){
			this.vis_add_time_ = value;
		}
		public double? GetVip_order_total_amount(){
			return this.vip_order_total_amount_;
		}
		
		public void SetVip_order_total_amount(double? value){
			this.vip_order_total_amount_ = value;
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
		public string GetInvoice_type(){
			return this.invoice_type_;
		}
		
		public void SetInvoice_type(string value){
			this.invoice_type_ = value;
		}
		public string GetTax_pay_no(){
			return this.tax_pay_no_;
		}
		
		public void SetTax_pay_no(string value){
			this.tax_pay_no_ = value;
		}
		public string GetArea_warehouse_id(){
			return this.area_warehouse_id_;
		}
		
		public void SetArea_warehouse_id(string value){
			this.area_warehouse_id_ = value;
		}
		
	}
	
}