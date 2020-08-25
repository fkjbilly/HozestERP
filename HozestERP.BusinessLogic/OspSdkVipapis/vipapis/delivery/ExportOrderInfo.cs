using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.delivery{
	
	
	
	
	
	public class ExportOrderInfo {
		
		///<summary>
		/// 订单号码
		/// @sampleValue order_id 
		///</summary>
		
		private string order_id_;
		
		///<summary>
		/// 10:订单已审核（已处理),22:已发货,25:已签收,45:退款处理中,49:已退款,53:退货未审核,54:退货已审核,55:拒收回访,58:退货已返仓,60:已完成,70:用户已拒收,97:订单已取消,117:退货审核中,118:订单申请断货,119：断货申请通过，300：拒收异常
		/// @sampleValue order_status 
		///</summary>
		
		private string order_status_;
		
		///<summary>
		/// 仓库名称
		/// @sampleValue warehouse_name 
		///</summary>
		
		private string warehouse_name_;
		
		///<summary>
		/// EBS分仓代码
		/// @sampleValue ebs_warehouse_code 
		///</summary>
		
		private string ebs_warehouse_code_;
		
		///<summary>
		/// B2C分仓代码
		/// @sampleValue b2c_warehouse 
		///</summary>
		
		private string b2c_warehouse_;
		
		///<summary>
		/// 客户类型
		/// @sampleValue user_type 
		///</summary>
		
		private int? user_type_;
		
		///<summary>
		/// 客户名称
		/// @sampleValue user_name 
		///</summary>
		
		private string user_name_;
		
		///<summary>
		/// 用户下单ID
		/// @sampleValue buyer_id 
		///</summary>
		
		private int? buyer_id_;
		
		///<summary>
		/// 收货地址
		/// @sampleValue address 
		///</summary>
		
		private string address_;
		
		///<summary>
		/// 收货人
		/// @sampleValue buyer 
		///</summary>
		
		private string buyer_;
		
		///<summary>
		/// 区域编码
		/// @sampleValue area_id 
		///</summary>
		
		private string area_id_;
		
		///<summary>
		/// 邮政编码
		/// @sampleValue postcode 
		///</summary>
		
		private string postcode_;
		
		///<summary>
		/// 城市
		/// @sampleValue city 
		///</summary>
		
		private string city_;
		
		///<summary>
		/// 省份
		/// @sampleValue province 
		///</summary>
		
		private string province_;
		
		///<summary>
		/// 国家代码
		/// @sampleValue country_id 
		///</summary>
		
		private string country_id_;
		
		///<summary>
		/// 电话号码
		/// @sampleValue tel 
		///</summary>
		
		private string tel_;
		
		///<summary>
		/// 手机号码
		/// @sampleValue mobile 
		///</summary>
		
		private string mobile_;
		
		///<summary>
		/// 支付类型
		/// @sampleValue pay_type 
		///</summary>
		
		private string pay_type_;
		
		///<summary>
		/// POS机刷卡标识
		/// @sampleValue pos 
		///</summary>
		
		private int? pos_;
		
		///<summary>
		/// 客户要求送货时间
		/// @sampleValue transport_day 
		///</summary>
		
		private string transport_day_;
		
		///<summary>
		/// 备注
		/// @sampleValue remark 
		///</summary>
		
		private string remark_;
		
		///<summary>
		/// 类型说明
		/// @sampleValue order_type 
		///</summary>
		
		private string order_type_;
		
		///<summary>
		/// 订单类型
		/// @sampleValue vipclub 
		///</summary>
		
		private string vipclub_;
		
		///<summary>
		/// 发票抬头
		/// @sampleValue invoice 
		///</summary>
		
		private string invoice_;
		
		///<summary>
		/// 整张出库单商品金额总和
		/// @sampleValue goods_money 
		///</summary>
		
		private string goods_money_;
		
		///<summary>
		/// 应收金额=单据金额x折扣比例
		/// @sampleValue money 
		///</summary>
		
		private string money_;
		
		///<summary>
		/// 折扣
		/// @sampleValue agio 
		///</summary>
		
		private string agio_;
		
		///<summary>
		/// 优惠金额
		/// @sampleValue discount_amount 
		///</summary>
		
		private string discount_amount_;
		
		///<summary>
		/// 促销优惠金额
		/// @sampleValue promo_discount_amount 
		///</summary>
		
		private string promo_discount_amount_;
		
		///<summary>
		/// 电子货币包
		/// @sampleValue surplus 
		///</summary>
		
		private string surplus_;
		
		///<summary>
		/// 运费
		/// @sampleValue carriage 
		///</summary>
		
		private string carriage_;
		
		///<summary>
		/// 运单号码
		/// @sampleValue transport_no 
		///</summary>
		
		private string transport_no_;
		
		///<summary>
		/// 承运商编码
		/// @sampleValue carrier_code 
		///</summary>
		
		private string carrier_code_;
		
		///<summary>
		/// 承运商名称
		/// @sampleValue carrier_name 
		///</summary>
		
		private string carrier_name_;
		
		///<summary>
		/// 配送信息 运单详情
		/// @sampleValue transport_detail 
		///</summary>
		
		private string transport_detail_;
		
		///<summary>
		/// b2c物流状态编码
		/// @sampleValue b2c_transport_code 
		///</summary>
		
		private int? b2c_transport_code_;
		
		///<summary>
		/// 运送方式说明
		/// @sampleValue transport_id 
		///</summary>
		
		private string transport_id_;
		
		///<summary>
		/// 承载物类型
		/// @sampleValue transport_type 
		///</summary>
		
		private string transport_type_;
		
		///<summary>
		/// 供应商代码
		/// @sampleValue vendor_code 
		///</summary>
		
		private string vendor_code_;
		
		///<summary>
		/// 供应商ID
		/// @sampleValue vendor_id 
		///</summary>
		
		private int? vendor_id_;
		
		///<summary>
		/// 供应商名称
		/// @sampleValue vendor_name 
		///</summary>
		
		private string vendor_name_;
		
		///<summary>
		/// 品牌中文名称
		/// @sampleValue brand_name 
		///</summary>
		
		private string brand_name_;
		
		///<summary>
		/// 商品信息
		/// @sampleValue goods_list 
		///</summary>
		
		private List<vipapis.delivery.ExportProduct> goods_list_;
		
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
		public string GetWarehouse_name(){
			return this.warehouse_name_;
		}
		
		public void SetWarehouse_name(string value){
			this.warehouse_name_ = value;
		}
		public string GetEbs_warehouse_code(){
			return this.ebs_warehouse_code_;
		}
		
		public void SetEbs_warehouse_code(string value){
			this.ebs_warehouse_code_ = value;
		}
		public string GetB2c_warehouse(){
			return this.b2c_warehouse_;
		}
		
		public void SetB2c_warehouse(string value){
			this.b2c_warehouse_ = value;
		}
		public int? GetUser_type(){
			return this.user_type_;
		}
		
		public void SetUser_type(int? value){
			this.user_type_ = value;
		}
		public string GetUser_name(){
			return this.user_name_;
		}
		
		public void SetUser_name(string value){
			this.user_name_ = value;
		}
		public int? GetBuyer_id(){
			return this.buyer_id_;
		}
		
		public void SetBuyer_id(int? value){
			this.buyer_id_ = value;
		}
		public string GetAddress(){
			return this.address_;
		}
		
		public void SetAddress(string value){
			this.address_ = value;
		}
		public string GetBuyer(){
			return this.buyer_;
		}
		
		public void SetBuyer(string value){
			this.buyer_ = value;
		}
		public string GetArea_id(){
			return this.area_id_;
		}
		
		public void SetArea_id(string value){
			this.area_id_ = value;
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
		public string GetPay_type(){
			return this.pay_type_;
		}
		
		public void SetPay_type(string value){
			this.pay_type_ = value;
		}
		public int? GetPos(){
			return this.pos_;
		}
		
		public void SetPos(int? value){
			this.pos_ = value;
		}
		public string GetTransport_day(){
			return this.transport_day_;
		}
		
		public void SetTransport_day(string value){
			this.transport_day_ = value;
		}
		public string GetRemark(){
			return this.remark_;
		}
		
		public void SetRemark(string value){
			this.remark_ = value;
		}
		public string GetOrder_type(){
			return this.order_type_;
		}
		
		public void SetOrder_type(string value){
			this.order_type_ = value;
		}
		public string GetVipclub(){
			return this.vipclub_;
		}
		
		public void SetVipclub(string value){
			this.vipclub_ = value;
		}
		public string GetInvoice(){
			return this.invoice_;
		}
		
		public void SetInvoice(string value){
			this.invoice_ = value;
		}
		public string GetGoods_money(){
			return this.goods_money_;
		}
		
		public void SetGoods_money(string value){
			this.goods_money_ = value;
		}
		public string GetMoney(){
			return this.money_;
		}
		
		public void SetMoney(string value){
			this.money_ = value;
		}
		public string GetAgio(){
			return this.agio_;
		}
		
		public void SetAgio(string value){
			this.agio_ = value;
		}
		public string GetDiscount_amount(){
			return this.discount_amount_;
		}
		
		public void SetDiscount_amount(string value){
			this.discount_amount_ = value;
		}
		public string GetPromo_discount_amount(){
			return this.promo_discount_amount_;
		}
		
		public void SetPromo_discount_amount(string value){
			this.promo_discount_amount_ = value;
		}
		public string GetSurplus(){
			return this.surplus_;
		}
		
		public void SetSurplus(string value){
			this.surplus_ = value;
		}
		public string GetCarriage(){
			return this.carriage_;
		}
		
		public void SetCarriage(string value){
			this.carriage_ = value;
		}
		public string GetTransport_no(){
			return this.transport_no_;
		}
		
		public void SetTransport_no(string value){
			this.transport_no_ = value;
		}
		public string GetCarrier_code(){
			return this.carrier_code_;
		}
		
		public void SetCarrier_code(string value){
			this.carrier_code_ = value;
		}
		public string GetCarrier_name(){
			return this.carrier_name_;
		}
		
		public void SetCarrier_name(string value){
			this.carrier_name_ = value;
		}
		public string GetTransport_detail(){
			return this.transport_detail_;
		}
		
		public void SetTransport_detail(string value){
			this.transport_detail_ = value;
		}
		public int? GetB2c_transport_code(){
			return this.b2c_transport_code_;
		}
		
		public void SetB2c_transport_code(int? value){
			this.b2c_transport_code_ = value;
		}
		public string GetTransport_id(){
			return this.transport_id_;
		}
		
		public void SetTransport_id(string value){
			this.transport_id_ = value;
		}
		public string GetTransport_type(){
			return this.transport_type_;
		}
		
		public void SetTransport_type(string value){
			this.transport_type_ = value;
		}
		public string GetVendor_code(){
			return this.vendor_code_;
		}
		
		public void SetVendor_code(string value){
			this.vendor_code_ = value;
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
		public string GetBrand_name(){
			return this.brand_name_;
		}
		
		public void SetBrand_name(string value){
			this.brand_name_ = value;
		}
		public List<vipapis.delivery.ExportProduct> GetGoods_list(){
			return this.goods_list_;
		}
		
		public void SetGoods_list(List<vipapis.delivery.ExportProduct> value){
			this.goods_list_ = value;
		}
		
	}
	
}