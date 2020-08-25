using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.dvd{
	
	
	
	
	
	public class AreaOccupiedOrder {
		
		///<summary>
		/// 订单号
		///</summary>
		
		private string order_id_;
		
		///<summary>
		/// 下单时间
		///</summary>
		
		private string create_time_;
		
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
		/// 分区仓库代码
		///</summary>
		
		private string area_warehouse_id_;
		
		///<summary>
		/// 售卖模式(2-普通直发，9-直发预售)
		///</summary>
		
		private int? sale_type_;
		
		///<summary>
		/// 订单类型
		///</summary>
		
		private int? order_type_;
		
		///<summary>
		/// 商品列表
		///</summary>
		
		private List<vipapis.dvd.AreaOccupiedOrderDetail> order_details_;
		
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
		public string GetArea_warehouse_id(){
			return this.area_warehouse_id_;
		}
		
		public void SetArea_warehouse_id(string value){
			this.area_warehouse_id_ = value;
		}
		public int? GetSale_type(){
			return this.sale_type_;
		}
		
		public void SetSale_type(int? value){
			this.sale_type_ = value;
		}
		public int? GetOrder_type(){
			return this.order_type_;
		}
		
		public void SetOrder_type(int? value){
			this.order_type_ = value;
		}
		public List<vipapis.dvd.AreaOccupiedOrderDetail> GetOrder_details(){
			return this.order_details_;
		}
		
		public void SetOrder_details(List<vipapis.dvd.AreaOccupiedOrderDetail> value){
			this.order_details_ = value;
		}
		
	}
	
}