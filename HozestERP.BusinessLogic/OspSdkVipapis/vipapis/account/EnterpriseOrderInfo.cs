using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.account{
	
	
	
	
	
	public class EnterpriseOrderInfo {
		
		///<summary>
		/// 企业标记
		///</summary>
		
		private string enterprise_code_;
		
		///<summary>
		/// 企业员工编号
		///</summary>
		
		private string enterprise_employee_no_;
		
		///<summary>
		/// 订单时间
		///</summary>
		
		private string oder_time_;
		
		///<summary>
		/// 订单实际支付金额
		///</summary>
		
		private double? money_;
		
		///<summary>
		/// 商品品类名称，用逗号隔开
		///</summary>
		
		private string category_;
		
		///<summary>
		/// 新老客类型:1:新客,0:老客
		///</summary>
		
		private int? account_status_;
		
		///<summary>
		/// 订单状态
		///</summary>
		
		private int? order_status_;
		
		///<summary>
		/// 支付类型
		///</summary>
		
		private int? pay_type_;
		
		///<summary>
		/// 订单编号
		///</summary>
		
		private string order_sn_;
		
		///<summary>
		/// 支付编号
		///</summary>
		
		private string pay_sn_;
		
		public string GetEnterprise_code(){
			return this.enterprise_code_;
		}
		
		public void SetEnterprise_code(string value){
			this.enterprise_code_ = value;
		}
		public string GetEnterprise_employee_no(){
			return this.enterprise_employee_no_;
		}
		
		public void SetEnterprise_employee_no(string value){
			this.enterprise_employee_no_ = value;
		}
		public string GetOder_time(){
			return this.oder_time_;
		}
		
		public void SetOder_time(string value){
			this.oder_time_ = value;
		}
		public double? GetMoney(){
			return this.money_;
		}
		
		public void SetMoney(double? value){
			this.money_ = value;
		}
		public string GetCategory(){
			return this.category_;
		}
		
		public void SetCategory(string value){
			this.category_ = value;
		}
		public int? GetAccount_status(){
			return this.account_status_;
		}
		
		public void SetAccount_status(int? value){
			this.account_status_ = value;
		}
		public int? GetOrder_status(){
			return this.order_status_;
		}
		
		public void SetOrder_status(int? value){
			this.order_status_ = value;
		}
		public int? GetPay_type(){
			return this.pay_type_;
		}
		
		public void SetPay_type(int? value){
			this.pay_type_ = value;
		}
		public string GetOrder_sn(){
			return this.order_sn_;
		}
		
		public void SetOrder_sn(string value){
			this.order_sn_ = value;
		}
		public string GetPay_sn(){
			return this.pay_sn_;
		}
		
		public void SetPay_sn(string value){
			this.pay_sn_ = value;
		}
		
	}
	
}