using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.overseas{
	
	
	
	
	
	public class TransferForm {
		
		///<summary>
		/// 数据源(V代表VIS，P代表PSP，E代表ERP)
		///</summary>
		
		private string transfer_source_;
		
		///<summary>
		/// 传输id
		/// @sampleValue transaction_id 一个调拨单需要这么多标识吗？贤林确认
		///</summary>
		
		private string transaction_id_;
		
		///<summary>
		/// 供应商编码
		///</summary>
		
		private string vendor_code_;
		
		///<summary>
		/// ERP预调拨单号
		///</summary>
		
		private string erp_transfer_sn_;
		
		///<summary>
		/// ODS预调拨单号
		///</summary>
		
		private string transfer_sn_;
		
		///<summary>
		/// 调拨类型
		/// @sampleValue transfer_type 残次品调拨是什么？贤林确认
		///</summary>
		
		private string transfer_type_;
		
		///<summary>
		/// 支付方式（0 货到付款；1 现付月结）
		/// @sampleValue pay_type 找贤林确认，调拨单是否需要支付方式
		///</summary>
		
		private string pay_type_;
		
		///<summary>
		/// 预调拨发货仓
		///</summary>
		
		private string from_warehouse_;
		
		///<summary>
		/// 预调拨收货仓
		///</summary>
		
		private string to_warehouse_;
		
		///<summary>
		/// 总行数
		///</summary>
		
		private long? line_count_;
		
		///<summary>
		/// 预调拨通知email地址
		///</summary>
		
		private string to_email_;
		
		///<summary>
		/// 预调拨抄送email地址
		///</summary>
		
		private string cc_email_;
		
		///<summary>
		/// 创建人
		///</summary>
		
		private string erp_creater_;
		
		///<summary>
		/// 创建时间
		/// @sampleValue erp_create_time 2015-09-27 08:41:23
		///</summary>
		
		private string erp_create_time_;
		
		///<summary>
		/// 退供收货人
		///</summary>
		
		private string consignee_;
		
		///<summary>
		/// 国家标识
		///</summary>
		
		private string country_;
		
		///<summary>
		/// 省/州
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
		/// 收货地址
		///</summary>
		
		private string address_;
		
		///<summary>
		/// 邮政编码
		///</summary>
		
		private string postcode_;
		
		///<summary>
		/// 座机
		///</summary>
		
		private string telephone_;
		
		///<summary>
		/// 移动电话
		///</summary>
		
		private string mobile_;
		
		///<summary>
		/// 地址编码
		///</summary>
		
		private string area_id_;
		
		///<summary>
		/// 商品清单
		///</summary>
		
		private List<vipapis.overseas.ProductItem> product_list_;
		
		public string GetTransfer_source(){
			return this.transfer_source_;
		}
		
		public void SetTransfer_source(string value){
			this.transfer_source_ = value;
		}
		public string GetTransaction_id(){
			return this.transaction_id_;
		}
		
		public void SetTransaction_id(string value){
			this.transaction_id_ = value;
		}
		public string GetVendor_code(){
			return this.vendor_code_;
		}
		
		public void SetVendor_code(string value){
			this.vendor_code_ = value;
		}
		public string GetErp_transfer_sn(){
			return this.erp_transfer_sn_;
		}
		
		public void SetErp_transfer_sn(string value){
			this.erp_transfer_sn_ = value;
		}
		public string GetTransfer_sn(){
			return this.transfer_sn_;
		}
		
		public void SetTransfer_sn(string value){
			this.transfer_sn_ = value;
		}
		public string GetTransfer_type(){
			return this.transfer_type_;
		}
		
		public void SetTransfer_type(string value){
			this.transfer_type_ = value;
		}
		public string GetPay_type(){
			return this.pay_type_;
		}
		
		public void SetPay_type(string value){
			this.pay_type_ = value;
		}
		public string GetFrom_warehouse(){
			return this.from_warehouse_;
		}
		
		public void SetFrom_warehouse(string value){
			this.from_warehouse_ = value;
		}
		public string GetTo_warehouse(){
			return this.to_warehouse_;
		}
		
		public void SetTo_warehouse(string value){
			this.to_warehouse_ = value;
		}
		public long? GetLine_count(){
			return this.line_count_;
		}
		
		public void SetLine_count(long? value){
			this.line_count_ = value;
		}
		public string GetTo_email(){
			return this.to_email_;
		}
		
		public void SetTo_email(string value){
			this.to_email_ = value;
		}
		public string GetCc_email(){
			return this.cc_email_;
		}
		
		public void SetCc_email(string value){
			this.cc_email_ = value;
		}
		public string GetErp_creater(){
			return this.erp_creater_;
		}
		
		public void SetErp_creater(string value){
			this.erp_creater_ = value;
		}
		public string GetErp_create_time(){
			return this.erp_create_time_;
		}
		
		public void SetErp_create_time(string value){
			this.erp_create_time_ = value;
		}
		public string GetConsignee(){
			return this.consignee_;
		}
		
		public void SetConsignee(string value){
			this.consignee_ = value;
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
		public string GetTelephone(){
			return this.telephone_;
		}
		
		public void SetTelephone(string value){
			this.telephone_ = value;
		}
		public string GetMobile(){
			return this.mobile_;
		}
		
		public void SetMobile(string value){
			this.mobile_ = value;
		}
		public string GetArea_id(){
			return this.area_id_;
		}
		
		public void SetArea_id(string value){
			this.area_id_ = value;
		}
		public List<vipapis.overseas.ProductItem> GetProduct_list(){
			return this.product_list_;
		}
		
		public void SetProduct_list(List<vipapis.overseas.ProductItem> value){
			this.product_list_ = value;
		}
		
	}
	
}