using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.domain.order{
	
	
	
	
	
	public class OrderStatusInfo {
		
		///<summary>
		/// ERP订单号
		///</summary>
		
		private string erp_order_sn_;
		
		///<summary>
		/// 运单号
		///</summary>
		
		private string transport_no_;
		
		///<summary>
		/// 物流状态编码
		///</summary>
		
		private string transport_code_;
		
		///<summary>
		/// 物流状态信息
		///</summary>
		
		private string transport_detail_;
		
		///<summary>
		/// 承运商编码
		///</summary>
		
		private string carriers_code_;
		
		///<summary>
		/// 承运商全称
		///</summary>
		
		private string carriers_name_;
		
		///<summary>
		/// 承运商简称
		///</summary>
		
		private string carriers_shortname_;
		
		///<summary>
		/// 承运商类型
		///</summary>
		
		private string carriers_type_;
		
		///<summary>
		/// 发货仓
		///</summary>
		
		private string warehouse_;
		
		///<summary>
		/// 状态发生时间
		///</summary>
		
		private string action_time_;
		
		///<summary>
		/// 支付方式
		///</summary>
		
		private string pay_type_;
		
		///<summary>
		/// 线下支付方式
		///</summary>
		
		private string ext_pay_type_;
		
		///<summary>
		/// 支付宝账号
		///</summary>
		
		private string alipay_cust_no_;
		
		///<summary>
		/// 当前记录的序号
		///</summary>
		
		private long? max_id_;
		
		public string GetErp_order_sn(){
			return this.erp_order_sn_;
		}
		
		public void SetErp_order_sn(string value){
			this.erp_order_sn_ = value;
		}
		public string GetTransport_no(){
			return this.transport_no_;
		}
		
		public void SetTransport_no(string value){
			this.transport_no_ = value;
		}
		public string GetTransport_code(){
			return this.transport_code_;
		}
		
		public void SetTransport_code(string value){
			this.transport_code_ = value;
		}
		public string GetTransport_detail(){
			return this.transport_detail_;
		}
		
		public void SetTransport_detail(string value){
			this.transport_detail_ = value;
		}
		public string GetCarriers_code(){
			return this.carriers_code_;
		}
		
		public void SetCarriers_code(string value){
			this.carriers_code_ = value;
		}
		public string GetCarriers_name(){
			return this.carriers_name_;
		}
		
		public void SetCarriers_name(string value){
			this.carriers_name_ = value;
		}
		public string GetCarriers_shortname(){
			return this.carriers_shortname_;
		}
		
		public void SetCarriers_shortname(string value){
			this.carriers_shortname_ = value;
		}
		public string GetCarriers_type(){
			return this.carriers_type_;
		}
		
		public void SetCarriers_type(string value){
			this.carriers_type_ = value;
		}
		public string GetWarehouse(){
			return this.warehouse_;
		}
		
		public void SetWarehouse(string value){
			this.warehouse_ = value;
		}
		public string GetAction_time(){
			return this.action_time_;
		}
		
		public void SetAction_time(string value){
			this.action_time_ = value;
		}
		public string GetPay_type(){
			return this.pay_type_;
		}
		
		public void SetPay_type(string value){
			this.pay_type_ = value;
		}
		public string GetExt_pay_type(){
			return this.ext_pay_type_;
		}
		
		public void SetExt_pay_type(string value){
			this.ext_pay_type_ = value;
		}
		public string GetAlipay_cust_no(){
			return this.alipay_cust_no_;
		}
		
		public void SetAlipay_cust_no(string value){
			this.alipay_cust_no_ = value;
		}
		public long? GetMax_id(){
			return this.max_id_;
		}
		
		public void SetMax_id(long? value){
			this.max_id_ = value;
		}
		
	}
	
}