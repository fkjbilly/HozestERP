using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.order{
	
	
	
	
	
	public class OmniOrder {
		
		///<summary>
		/// 订单号
		///</summary>
		
		private string order_id_;
		
		///<summary>
		/// 省份
		///</summary>
		
		private string province_;
		
		///<summary>
		/// 城市
		///</summary>
		
		private string city_;
		
		///<summary>
		/// 区县
		///</summary>
		
		private string district_;
		
		///<summary>
		/// 订单商品
		///</summary>
		
		private List<vipapis.order.OrderSku> order_skus_;
		
		///<summary>
		/// 业务类型(1:门店发货,2:仓中仓发货)
		///</summary>
		
		private byte? business_type_;
		
		///<summary>
		/// 省份编码
		///</summary>
		
		private string province_code_;
		
		///<summary>
		/// 城市编码
		///</summary>
		
		private string city_code_;
		
		///<summary>
		/// 区县编码
		///</summary>
		
		private string district_code_;
		
		public string GetOrder_id(){
			return this.order_id_;
		}
		
		public void SetOrder_id(string value){
			this.order_id_ = value;
		}
		public string GetProvince(){
			return this.province_;
		}
		
		public void SetProvince(string value){
			this.province_ = value;
		}
		public string GetCity(){
			return this.city_;
		}
		
		public void SetCity(string value){
			this.city_ = value;
		}
		public string GetDistrict(){
			return this.district_;
		}
		
		public void SetDistrict(string value){
			this.district_ = value;
		}
		public List<vipapis.order.OrderSku> GetOrder_skus(){
			return this.order_skus_;
		}
		
		public void SetOrder_skus(List<vipapis.order.OrderSku> value){
			this.order_skus_ = value;
		}
		public byte? GetBusiness_type(){
			return this.business_type_;
		}
		
		public void SetBusiness_type(byte? value){
			this.business_type_ = value;
		}
		public string GetProvince_code(){
			return this.province_code_;
		}
		
		public void SetProvince_code(string value){
			this.province_code_ = value;
		}
		public string GetCity_code(){
			return this.city_code_;
		}
		
		public void SetCity_code(string value){
			this.city_code_ = value;
		}
		public string GetDistrict_code(){
			return this.district_code_;
		}
		
		public void SetDistrict_code(string value){
			this.district_code_ = value;
		}
		
	}
	
}