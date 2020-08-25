using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.stock{
	
	
	
	
	
	public class OxoShopOrderForPopList {
		
		///<summary>
		/// 订单号
		///</summary>
		
		private string order_id_;
		
		///<summary>
		/// 收货人
		///</summary>
		
		private string buyer_;
		
		///<summary>
		/// 详细地址
		///</summary>
		
		private string address_;
		
		///<summary>
		/// 市
		///</summary>
		
		private string city_;
		
		///<summary>
		/// 省/州
		///</summary>
		
		private string province_;
		
		///<summary>
		/// 邮政编码
		///</summary>
		
		private string postcode_;
		
		///<summary>
		/// 国家标识
		///</summary>
		
		private string country_id_;
		
		///<summary>
		/// 座机
		///</summary>
		
		private string tel_;
		
		///<summary>
		/// 移动电话
		///</summary>
		
		private string mobile_;
		
		///<summary>
		/// 客户要求
		///</summary>
		
		private string transport_day_;
		
		///<summary>
		/// 备注
		///</summary>
		
		private string remark_;
		
		///<summary>
		/// 发票抬头
		///</summary>
		
		private string invoice_;
		
		///<summary>
		/// 订单明细结构体
		///</summary>
		
		private List<vipapis.stock.OxoOrderGoodsList> oxo_order_goods_list_;
		
		public string GetOrder_id(){
			return this.order_id_;
		}
		
		public void SetOrder_id(string value){
			this.order_id_ = value;
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
		public string GetPostcode(){
			return this.postcode_;
		}
		
		public void SetPostcode(string value){
			this.postcode_ = value;
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
		public string GetInvoice(){
			return this.invoice_;
		}
		
		public void SetInvoice(string value){
			this.invoice_ = value;
		}
		public List<vipapis.stock.OxoOrderGoodsList> GetOxo_order_goods_list(){
			return this.oxo_order_goods_list_;
		}
		
		public void SetOxo_order_goods_list(List<vipapis.stock.OxoOrderGoodsList> value){
			this.oxo_order_goods_list_ = value;
		}
		
	}
	
}