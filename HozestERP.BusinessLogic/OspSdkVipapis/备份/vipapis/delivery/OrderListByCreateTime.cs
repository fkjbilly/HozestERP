using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.delivery{
	
	
	
	
	
	public class OrderListByCreateTime {
		
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
		/// 收获地址
		///</summary>
		
		private string address_;
		
		///<summary>
		/// 手机号码
		///</summary>
		
		private string mobile_;
		
		///<summary>
		/// 联系方式
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
		/// 国家ID
		///</summary>
		
		private string country_id_;
		
		///<summary>
		/// 发票抬头
		///</summary>
		
		private string invoice_;
		
		///<summary>
		/// 快递金额
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
		
		private string vendor_id_;
		
		///<summary>
		/// 供应商名称
		///</summary>
		
		private string vendor_name_;
		
		///<summary>
		/// 促销优惠金额
		///</summary>
		
		private string ex_fav_money_;
		
		///<summary>
		/// 促销金额
		///</summary>
		
		private string favourable_money_;
		
		///<summary>
		/// 整张出库单商品金额总和(计算发票金额==整张出库单商品金额总和+快递金额-优惠金额-促销优惠金额)
		///</summary>
		
		private string product_money_;
		
		///<summary>
		/// 订单下单时间
		///</summary>
		
		private string add_time_;
		
		///<summary>
		/// 订单进入vis系统时间
		///</summary>
		
		private string create_time_;
		
		///<summary>
		/// PO号
		///</summary>
		
		private string po_no_;
		
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
		public string GetVendor_id(){
			return this.vendor_id_;
		}
		
		public void SetVendor_id(string value){
			this.vendor_id_ = value;
		}
		public string GetVendor_name(){
			return this.vendor_name_;
		}
		
		public void SetVendor_name(string value){
			this.vendor_name_ = value;
		}
		public string GetEx_fav_money(){
			return this.ex_fav_money_;
		}
		
		public void SetEx_fav_money(string value){
			this.ex_fav_money_ = value;
		}
		public string GetFavourable_money(){
			return this.favourable_money_;
		}
		
		public void SetFavourable_money(string value){
			this.favourable_money_ = value;
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
		public string GetCreate_time(){
			return this.create_time_;
		}
		
		public void SetCreate_time(string value){
			this.create_time_ = value;
		}
		public string GetPo_no(){
			return this.po_no_;
		}
		
		public void SetPo_no(string value){
			this.po_no_ = value;
		}
		
	}
	
}