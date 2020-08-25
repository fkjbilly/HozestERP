using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.overseas{
	
	
	
	
	
	public class SaleOrderResult {
		
		///<summary>
		/// 商品条形码
		///</summary>
		
		private string sales_id_;
		
		///<summary>
		/// 商品名称
		///</summary>
		
		private string order_no_;
		
		///<summary>
		/// 尺码
		///</summary>
		
		private string order_id_;
		
		///<summary>
		/// 数量
		///</summary>
		
		private string order_type_;
		
		///<summary>
		/// 数量
		///</summary>
		
		private string create_time_;
		
		///<summary>
		/// 数量
		///</summary>
		
		private string warehouse_;
		
		///<summary>
		/// 数量
		///</summary>
		
		private string remark_;
		
		///<summary>
		/// 数量
		///</summary>
		
		private string transport_day_;
		
		///<summary>
		/// 数量
		///</summary>
		
		private string order_status_;
		
		///<summary>
		/// 数量
		///</summary>
		
		private string buyer_;
		
		///<summary>
		/// 数量
		///</summary>
		
		private string address_;
		
		///<summary>
		/// 数量
		///</summary>
		
		private string tel_;
		
		///<summary>
		/// 数量
		///</summary>
		
		private string mobile_;
		
		///<summary>
		/// 数量
		///</summary>
		
		private string user_type_name_;
		
		///<summary>
		/// 数量
		///</summary>
		
		private string user_name_;
		
		///<summary>
		/// 数量
		///</summary>
		
		private string goHTS_money_;
		
		///<summary>
		/// 数量
		///</summary>
		
		private string chinaFreightForwarding_;
		
		///<summary>
		/// 数量
		///</summary>
		
		private string globalFreightForwarding_;
		
		///<summary>
		/// 数量
		///</summary>
		
		private List<vipapis.overseas.OrderDetail> order_detail_list_;
		
		public string GetSales_id(){
			return this.sales_id_;
		}
		
		public void SetSales_id(string value){
			this.sales_id_ = value;
		}
		public string GetOrder_no(){
			return this.order_no_;
		}
		
		public void SetOrder_no(string value){
			this.order_no_ = value;
		}
		public string GetOrder_id(){
			return this.order_id_;
		}
		
		public void SetOrder_id(string value){
			this.order_id_ = value;
		}
		public string GetOrder_type(){
			return this.order_type_;
		}
		
		public void SetOrder_type(string value){
			this.order_type_ = value;
		}
		public string GetCreate_time(){
			return this.create_time_;
		}
		
		public void SetCreate_time(string value){
			this.create_time_ = value;
		}
		public string GetWarehouse(){
			return this.warehouse_;
		}
		
		public void SetWarehouse(string value){
			this.warehouse_ = value;
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
		public string GetUser_type_name(){
			return this.user_type_name_;
		}
		
		public void SetUser_type_name(string value){
			this.user_type_name_ = value;
		}
		public string GetUser_name(){
			return this.user_name_;
		}
		
		public void SetUser_name(string value){
			this.user_name_ = value;
		}
		public string GetGoHTS_money(){
			return this.goHTS_money_;
		}
		
		public void SetGoHTS_money(string value){
			this.goHTS_money_ = value;
		}
		public string GetChinaFreightForwarding(){
			return this.chinaFreightForwarding_;
		}
		
		public void SetChinaFreightForwarding(string value){
			this.chinaFreightForwarding_ = value;
		}
		public string GetGlobalFreightForwarding(){
			return this.globalFreightForwarding_;
		}
		
		public void SetGlobalFreightForwarding(string value){
			this.globalFreightForwarding_ = value;
		}
		public List<vipapis.overseas.OrderDetail> GetOrder_detail_list(){
			return this.order_detail_list_;
		}
		
		public void SetOrder_detail_list(List<vipapis.overseas.OrderDetail> value){
			this.order_detail_list_ = value;
		}
		
	}
	
}