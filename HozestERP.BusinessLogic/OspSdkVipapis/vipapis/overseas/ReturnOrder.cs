using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.overseas{
	
	
	
	
	
	public class ReturnOrder {
		
		///<summary>
		/// 数据源(V代表VIS，P代表PSP，E代表ERP)
		///</summary>
		
		private string return_source_;
		
		///<summary>
		/// 传输id（退供单的唯一标识）
		///</summary>
		
		private string transaction_id_;
		
		///<summary>
		/// 供应商编码
		///</summary>
		
		private string vendor_code_;
		
		///<summary>
		/// ERP退供单号
		///</summary>
		
		private string erp_return_sn_;
		
		///<summary>
		/// ODS退供单号
		///</summary>
		
		private string return_sn_;
		
		///<summary>
		/// 退供类型
		/// @sampleValue return_type 1
		///</summary>
		
		private string return_type_;
		
		///<summary>
		/// 支付方式（0，货到付款；1，现付月结）
		/// @sampleValue pay_type 退供也有支付方式吗？贤林确认
		///</summary>
		
		private string pay_type_;
		
		///<summary>
		/// 是否自提（0，品骏配送；1、供应商自提；2、退供应商；3、增值服务；4、报废）
		/// @sampleValue self_reference 0
		///</summary>
		
		private string self_reference_;
		
		///<summary>
		/// 退供发货仓
		///</summary>
		
		private string from_warehouse_;
		
		///<summary>
		/// 退供目的仓
		///</summary>
		
		private string to_warehouse_;
		
		///<summary>
		/// 总行数
		///</summary>
		
		private string line_count_;
		
		///<summary>
		/// 退供收货人
		/// @sampleValue consignee 张三
		///</summary>
		
		private string consignee_;
		
		///<summary>
		/// 国家标识
		/// @sampleValue country CN
		///</summary>
		
		private string country_;
		
		///<summary>
		/// 省/州
		/// @sampleValue state 广东省
		///</summary>
		
		private string state_;
		
		///<summary>
		/// 城市
		/// @sampleValue city 广州市
		///</summary>
		
		private string city_;
		
		///<summary>
		/// 区/县
		/// @sampleValue region 荔湾区
		///</summary>
		
		private string region_;
		
		///<summary>
		/// 乡镇/街道
		/// @sampleValue town 花地街道
		///</summary>
		
		private string town_;
		
		///<summary>
		/// 收货地址
		/// @sampleValue address 广东省.广州市.荔湾市.花海街道.花海街20号
		///</summary>
		
		private string address_;
		
		///<summary>
		/// 邮政编码
		/// @sampleValue postcode 510000
		///</summary>
		
		private string postcode_;
		
		///<summary>
		/// 地址编码
		///</summary>
		
		private string area_id_;
		
		///<summary>
		/// 座机
		/// @sampleValue telephone 020-88888888
		///</summary>
		
		private string telephone_;
		
		///<summary>
		/// 移动电话
		/// @sampleValue mobile 13800138000
		///</summary>
		
		private string mobile_;
		
		///<summary>
		/// 退供通知email地址
		/// @sampleValue to_email abc@vipshop.com
		///</summary>
		
		private string to_email_;
		
		///<summary>
		/// 退供抄送email地址
		/// @sampleValue cc_email abcd@vipshop.com,abce@vipshop.com
		///</summary>
		
		private string cc_email_;
		
		///<summary>
		/// 创建人
		///</summary>
		
		private string creater_;
		
		///<summary>
		/// 创建时间
		/// @sampleValue creat_time 2014-07-14 20:18:37
		///</summary>
		
		private string creat_time_;
		
		///<summary>
		/// 是否需要整理(0 不需要整理，1 需要整理)
		/// @sampleValue is_need_tidy_up 找贤琳，此字段有何用
		///</summary>
		
		private string is_need_tidy_up_;
		
		///<summary>
		/// 会否原箱退回（0 不需要 ，1 需要）
		/// @sampleValue is_return_original_box 找贤琳，此字段有何用
		///</summary>
		
		private string is_return_original_box_;
		
		///<summary>
		/// 订单详情列表
		///</summary>
		
		private List<vipapis.overseas.ReturnOrderDetail> order_detail_list_;
		
		public string GetReturn_source(){
			return this.return_source_;
		}
		
		public void SetReturn_source(string value){
			this.return_source_ = value;
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
		public string GetErp_return_sn(){
			return this.erp_return_sn_;
		}
		
		public void SetErp_return_sn(string value){
			this.erp_return_sn_ = value;
		}
		public string GetReturn_sn(){
			return this.return_sn_;
		}
		
		public void SetReturn_sn(string value){
			this.return_sn_ = value;
		}
		public string GetReturn_type(){
			return this.return_type_;
		}
		
		public void SetReturn_type(string value){
			this.return_type_ = value;
		}
		public string GetPay_type(){
			return this.pay_type_;
		}
		
		public void SetPay_type(string value){
			this.pay_type_ = value;
		}
		public string GetSelf_reference(){
			return this.self_reference_;
		}
		
		public void SetSelf_reference(string value){
			this.self_reference_ = value;
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
		public string GetLine_count(){
			return this.line_count_;
		}
		
		public void SetLine_count(string value){
			this.line_count_ = value;
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
		public string GetArea_id(){
			return this.area_id_;
		}
		
		public void SetArea_id(string value){
			this.area_id_ = value;
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
		public string GetCreater(){
			return this.creater_;
		}
		
		public void SetCreater(string value){
			this.creater_ = value;
		}
		public string GetCreat_time(){
			return this.creat_time_;
		}
		
		public void SetCreat_time(string value){
			this.creat_time_ = value;
		}
		public string GetIs_need_tidy_up(){
			return this.is_need_tidy_up_;
		}
		
		public void SetIs_need_tidy_up(string value){
			this.is_need_tidy_up_ = value;
		}
		public string GetIs_return_original_box(){
			return this.is_return_original_box_;
		}
		
		public void SetIs_return_original_box(string value){
			this.is_return_original_box_ = value;
		}
		public List<vipapis.overseas.ReturnOrderDetail> GetOrder_detail_list(){
			return this.order_detail_list_;
		}
		
		public void SetOrder_detail_list(List<vipapis.overseas.ReturnOrderDetail> value){
			this.order_detail_list_ = value;
		}
		
	}
	
}