using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.domain.order{
	
	
	
	
	
	public class OrderInfo {
		
		///<summary>
		/// 唯一标识
		///</summary>
		
		private string transaction_id_;
		
		///<summary>
		/// 销售平台
		///</summary>
		
		private string sales_platform_;
		
		///<summary>
		/// ERP订单号
		///</summary>
		
		private string erp_order_sn_;
		
		///<summary>
		/// 平台订单号
		///</summary>
		
		private string third_order_sn_;
		
		///<summary>
		/// 原订单号
		///</summary>
		
		private string old_erp_order_sn_;
		
		///<summary>
		/// 发货仓编码
		///</summary>
		
		private com.vip.domain.inventory.WarehouseCode? warehouse_;
		
		///<summary>
		/// 收货人
		///</summary>
		
		private string buyer_;
		
		///<summary>
		/// 国家
		///</summary>
		
		private string country_;
		
		///<summary>
		/// 省份码
		///</summary>
		
		private string state_;
		
		///<summary>
		/// 城市
		///</summary>
		
		private string city_;
		
		///<summary>
		/// 区/县
		///</summary>
		
		private string region_;
		
		///<summary>
		/// 乡镇/街道
		///</summary>
		
		private string town_;
		
		///<summary>
		/// 详细地址
		///</summary>
		
		private string address_;
		
		///<summary>
		/// 邮政编码
		///</summary>
		
		private string postcode_;
		
		///<summary>
		/// 固定电话
		///</summary>
		
		private string tel_;
		
		///<summary>
		/// 手机号码
		///</summary>
		
		private string mobile_;
		
		///<summary>
		/// 支付方式
		///</summary>
		
		private com.vip.domain.order.OrderPayType? pay_type_;
		
		///<summary>
		/// 客户要求
		///</summary>
		
		private com.vip.domain.order.OrderTransportDay? transport_day_;
		
		///<summary>
		/// 备注
		///</summary>
		
		private string remark_;
		
		///<summary>
		/// 合计
		///</summary>
		
		private double? goods_money_;
		
		///<summary>
		/// 现金应收
		///</summary>
		
		private double? money_;
		
		///<summary>
		/// 运费
		///</summary>
		
		private double? carriage_;
		
		///<summary>
		/// 货到付款方式
		///</summary>
		
		private com.vip.domain.order.OrderExtPayType? ext_pay_type_;
		
		///<summary>
		/// 创建订单时间
		/// @sampleValue erp_create_time 2016-07-14 17:18:37
		///</summary>
		
		private string erp_create_time_;
		
		///<summary>
		/// 下单时间
		/// @sampleValue b2c_add_time 2016-07-14 17:18:37
		///</summary>
		
		private string b2c_add_time_;
		
		///<summary>
		/// 发票抬头
		///</summary>
		
		private string invoice_;
		
		///<summary>
		/// 发票金额
		///</summary>
		
		private double? ex_pay_money_;
		
		///<summary>
		/// 折扣比例
		///</summary>
		
		private double? aigo_;
		
		///<summary>
		/// 服务电话
		///</summary>
		
		private string service_phone_;
		
		///<summary>
		/// 清单是否打印价格
		///</summary>
		
		private com.vip.domain.order.OrderIsPrintingPrice? is_printing_price_;
		
		///<summary>
		/// 订单商品明细信息
		///</summary>
		
		private List<com.vip.domain.order.OrderItemInfo> itemList_;
		
		public string GetTransaction_id(){
			return this.transaction_id_;
		}
		
		public void SetTransaction_id(string value){
			this.transaction_id_ = value;
		}
		public string GetSales_platform(){
			return this.sales_platform_;
		}
		
		public void SetSales_platform(string value){
			this.sales_platform_ = value;
		}
		public string GetErp_order_sn(){
			return this.erp_order_sn_;
		}
		
		public void SetErp_order_sn(string value){
			this.erp_order_sn_ = value;
		}
		public string GetThird_order_sn(){
			return this.third_order_sn_;
		}
		
		public void SetThird_order_sn(string value){
			this.third_order_sn_ = value;
		}
		public string GetOld_erp_order_sn(){
			return this.old_erp_order_sn_;
		}
		
		public void SetOld_erp_order_sn(string value){
			this.old_erp_order_sn_ = value;
		}
		public com.vip.domain.inventory.WarehouseCode? GetWarehouse(){
			return this.warehouse_;
		}
		
		public void SetWarehouse(com.vip.domain.inventory.WarehouseCode? value){
			this.warehouse_ = value;
		}
		public string GetBuyer(){
			return this.buyer_;
		}
		
		public void SetBuyer(string value){
			this.buyer_ = value;
		}
		public string GetCountry(){
			return this.country_;
		}
		
		public void SetCountry(string value){
			this.country_ = value;
		}
		public string GetState(){
			return this.state_;
		}
		
		public void SetState(string value){
			this.state_ = value;
		}
		public string GetCity(){
			return this.city_;
		}
		
		public void SetCity(string value){
			this.city_ = value;
		}
		public string GetRegion(){
			return this.region_;
		}
		
		public void SetRegion(string value){
			this.region_ = value;
		}
		public string GetTown(){
			return this.town_;
		}
		
		public void SetTown(string value){
			this.town_ = value;
		}
		public string GetAddress(){
			return this.address_;
		}
		
		public void SetAddress(string value){
			this.address_ = value;
		}
		public string GetPostcode(){
			return this.postcode_;
		}
		
		public void SetPostcode(string value){
			this.postcode_ = value;
		}
		public string GetTel(){
			return this.tel_;
		}
		
		public void SetTel(string value){
			this.tel_ = value;
		}
		public string GetMobile(){
			return this.mobile_;
		}
		
		public void SetMobile(string value){
			this.mobile_ = value;
		}
		public com.vip.domain.order.OrderPayType? GetPay_type(){
			return this.pay_type_;
		}
		
		public void SetPay_type(com.vip.domain.order.OrderPayType? value){
			this.pay_type_ = value;
		}
		public com.vip.domain.order.OrderTransportDay? GetTransport_day(){
			return this.transport_day_;
		}
		
		public void SetTransport_day(com.vip.domain.order.OrderTransportDay? value){
			this.transport_day_ = value;
		}
		public string GetRemark(){
			return this.remark_;
		}
		
		public void SetRemark(string value){
			this.remark_ = value;
		}
		public double? GetGoods_money(){
			return this.goods_money_;
		}
		
		public void SetGoods_money(double? value){
			this.goods_money_ = value;
		}
		public double? GetMoney(){
			return this.money_;
		}
		
		public void SetMoney(double? value){
			this.money_ = value;
		}
		public double? GetCarriage(){
			return this.carriage_;
		}
		
		public void SetCarriage(double? value){
			this.carriage_ = value;
		}
		public com.vip.domain.order.OrderExtPayType? GetExt_pay_type(){
			return this.ext_pay_type_;
		}
		
		public void SetExt_pay_type(com.vip.domain.order.OrderExtPayType? value){
			this.ext_pay_type_ = value;
		}
		public string GetErp_create_time(){
			return this.erp_create_time_;
		}
		
		public void SetErp_create_time(string value){
			this.erp_create_time_ = value;
		}
		public string GetB2c_add_time(){
			return this.b2c_add_time_;
		}
		
		public void SetB2c_add_time(string value){
			this.b2c_add_time_ = value;
		}
		public string GetInvoice(){
			return this.invoice_;
		}
		
		public void SetInvoice(string value){
			this.invoice_ = value;
		}
		public double? GetEx_pay_money(){
			return this.ex_pay_money_;
		}
		
		public void SetEx_pay_money(double? value){
			this.ex_pay_money_ = value;
		}
		public double? GetAigo(){
			return this.aigo_;
		}
		
		public void SetAigo(double? value){
			this.aigo_ = value;
		}
		public string GetService_phone(){
			return this.service_phone_;
		}
		
		public void SetService_phone(string value){
			this.service_phone_ = value;
		}
		public com.vip.domain.order.OrderIsPrintingPrice? GetIs_printing_price(){
			return this.is_printing_price_;
		}
		
		public void SetIs_printing_price(com.vip.domain.order.OrderIsPrintingPrice? value){
			this.is_printing_price_ = value;
		}
		public List<com.vip.domain.order.OrderItemInfo> GetItemList(){
			return this.itemList_;
		}
		
		public void SetItemList(List<com.vip.domain.order.OrderItemInfo> value){
			this.itemList_ = value;
		}
		
	}
	
}