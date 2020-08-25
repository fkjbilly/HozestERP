using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.order{
	
	
	
	
	
	public class OccupiedOrder {
		
		///<summary>
		/// 库存占用订单号
		///</summary>
		
		private string order_id_;
		
		///<summary>
		/// 下单时间
		///</summary>
		
		private string create_time_;
		
		///<summary>
		/// 商品列表
		///</summary>
		
		private List<vipapis.order.OccupiedOrderDetail> barcodes_;
		
		///<summary>
		/// 订单业务类型
		///</summary>
		
		private int? business_type_;
		
		///<summary>
		/// 寻源范围，非OXO订单，此字段为空
		///</summary>
		
		private List<vipapis.order.OrderSource> order_source_;
		
		///<summary>
		/// 省份编码
		///</summary>
		
		private string province_code_;
		
		///<summary>
		/// 省份
		///</summary>
		
		private string province_;
		
		///<summary>
		/// 城市编码
		///</summary>
		
		private string city_code_;
		
		///<summary>
		/// 城市
		///</summary>
		
		private string city_;
		
		///<summary>
		/// 区县编码
		///</summary>
		
		private string district_code_;
		
		///<summary>
		/// 区县
		///</summary>
		
		private string district_;
		
		///<summary>
		/// 发票类型：0：不需要发票，1：纸质个人发票，2：纸质公司发票，3：电子发票，4：电子发票纸质版
		///</summary>
		
		private int? invoice_type_;
		
		public string GetOrder_id(){
			return this.order_id_;
		}
		
		public void SetOrder_id(string value){
			this.order_id_ = value;
		}
		public string GetCreate_time(){
			return this.create_time_;
		}
		
		public void SetCreate_time(string value){
			this.create_time_ = value;
		}
		public List<vipapis.order.OccupiedOrderDetail> GetBarcodes(){
			return this.barcodes_;
		}
		
		public void SetBarcodes(List<vipapis.order.OccupiedOrderDetail> value){
			this.barcodes_ = value;
		}
		public int? GetBusiness_type(){
			return this.business_type_;
		}
		
		public void SetBusiness_type(int? value){
			this.business_type_ = value;
		}
		public List<vipapis.order.OrderSource> GetOrder_source(){
			return this.order_source_;
		}
		
		public void SetOrder_source(List<vipapis.order.OrderSource> value){
			this.order_source_ = value;
		}
		public string GetProvince_code(){
			return this.province_code_;
		}
		
		public void SetProvince_code(string value){
			this.province_code_ = value;
		}
		public string GetProvince(){
			return this.province_;
		}
		
		public void SetProvince(string value){
			this.province_ = value;
		}
		public string GetCity_code(){
			return this.city_code_;
		}
		
		public void SetCity_code(string value){
			this.city_code_ = value;
		}
		public string GetCity(){
			return this.city_;
		}
		
		public void SetCity(string value){
			this.city_ = value;
		}
		public string GetDistrict_code(){
			return this.district_code_;
		}
		
		public void SetDistrict_code(string value){
			this.district_code_ = value;
		}
		public string GetDistrict(){
			return this.district_;
		}
		
		public void SetDistrict(string value){
			this.district_ = value;
		}
		public int? GetInvoice_type(){
			return this.invoice_type_;
		}
		
		public void SetInvoice_type(int? value){
			this.invoice_type_ = value;
		}
		
	}
	
}