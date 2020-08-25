using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.sce.vlg.osp.wms.service{
	
	
	
	
	
	public class OutWmsReturnOrderHeader {
		
		///<summary>
		/// 传输ID
		///</summary>
		
		private string transaction_id_;
		
		///<summary>
		/// 仓库
		///</summary>
		
		private string warehouse_;
		
		///<summary>
		/// 数据源
		///</summary>
		
		private string return_source_;
		
		///<summary>
		/// 供应商编码
		///</summary>
		
		private string vendor_code_;
		
		///<summary>
		/// ERP退供单号
		///</summary>
		
		private string erp_return_sn_;
		
		///<summary>
		/// 退供单号
		///</summary>
		
		private string return_sn_;
		
		///<summary>
		/// 退供类型
		///</summary>
		
		private string return_type_;
		
		///<summary>
		/// 支付方式
		///</summary>
		
		private string pay_type_;
		
		///<summary>
		/// 采购订单号
		///</summary>
		
		private string po_;
		
		///<summary>
		/// 总行数
		///</summary>
		
		private long? line_count_;
		
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
		/// 地址编码
		///</summary>
		
		private string area_id_;
		
		///<summary>
		/// 座机
		///</summary>
		
		private string telephone_;
		
		///<summary>
		/// 移动电话
		///</summary>
		
		private string mobile_;
		
		///<summary>
		/// 退供通知email地址
		///</summary>
		
		private string to_email_;
		
		///<summary>
		/// 退供抄送email地址
		///</summary>
		
		private string cc_email_;
		
		///<summary>
		/// 创建人
		///</summary>
		
		private string erp_creater_;
		
		///<summary>
		/// 创建时间
		///</summary>
		
		private string erp_create_time_;
		
		///<summary>
		/// 目的仓
		///</summary>
		
		private string ship_to_;
		
		///<summary>
		/// 是否自提(0:否<默认>,1：是)
		///</summary>
		
		private int? self_reference_;
		
		///<summary>
		/// 是否原箱退货(0:否<默认>,1：是)
		///</summary>
		
		private int? is_return_original_box_;
		
		///<summary>
		/// 是否接受整饰服务(0:否<默认>,1：是)
		///</summary>
		
		private int? is_need_tidy_up_;
		
		///<summary>
		/// 订单信息列表
		///</summary>
		
		private List<com.vip.sce.vlg.osp.wms.service.OutWmsReturnOrderDetail> detail_;
		
		public string GetTransaction_id(){
			return this.transaction_id_;
		}
		
		public void SetTransaction_id(string value){
			this.transaction_id_ = value;
		}
		public string GetWarehouse(){
			return this.warehouse_;
		}
		
		public void SetWarehouse(string value){
			this.warehouse_ = value;
		}
		public string GetReturn_source(){
			return this.return_source_;
		}
		
		public void SetReturn_source(string value){
			this.return_source_ = value;
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
		public string GetPo(){
			return this.po_;
		}
		
		public void SetPo(string value){
			this.po_ = value;
		}
		public long? GetLine_count(){
			return this.line_count_;
		}
		
		public void SetLine_count(long? value){
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
		public string GetShip_to(){
			return this.ship_to_;
		}
		
		public void SetShip_to(string value){
			this.ship_to_ = value;
		}
		public int? GetSelf_reference(){
			return this.self_reference_;
		}
		
		public void SetSelf_reference(int? value){
			this.self_reference_ = value;
		}
		public int? GetIs_return_original_box(){
			return this.is_return_original_box_;
		}
		
		public void SetIs_return_original_box(int? value){
			this.is_return_original_box_ = value;
		}
		public int? GetIs_need_tidy_up(){
			return this.is_need_tidy_up_;
		}
		
		public void SetIs_need_tidy_up(int? value){
			this.is_need_tidy_up_ = value;
		}
		public List<com.vip.sce.vlg.osp.wms.service.OutWmsReturnOrderDetail> GetDetail(){
			return this.detail_;
		}
		
		public void SetDetail(List<com.vip.sce.vlg.osp.wms.service.OutWmsReturnOrderDetail> value){
			this.detail_ = value;
		}
		
	}
	
}