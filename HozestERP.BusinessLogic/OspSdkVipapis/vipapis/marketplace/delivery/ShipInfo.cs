using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.marketplace.delivery{
	
	
	
	
	
	public class ShipInfo {
		
		///<summary>
		/// 订单号
		///</summary>
		
		private string order_id_;
		
		///<summary>
		/// 承运商编码
		///</summary>
		
		private string carrier_code_;
		
		///<summary>
		/// 承运商名称
		///</summary>
		
		private string carrier_name_;
		
		///<summary>
		/// 包裹类型：1，单包裹；2，多包裹
		///</summary>
		
		private int? package_type_;
		
		///<summary>
		/// 包裹信息
		///</summary>
		
		private List<vipapis.marketplace.delivery.ShipPackage> packages_;
		
		public string GetOrder_id(){
			return this.order_id_;
		}
		
		public void SetOrder_id(string value){
			this.order_id_ = value;
		}
		public string GetCarrier_code(){
			return this.carrier_code_;
		}
		
		public void SetCarrier_code(string value){
			this.carrier_code_ = value;
		}
		public string GetCarrier_name(){
			return this.carrier_name_;
		}
		
		public void SetCarrier_name(string value){
			this.carrier_name_ = value;
		}
		public int? GetPackage_type(){
			return this.package_type_;
		}
		
		public void SetPackage_type(int? value){
			this.package_type_ = value;
		}
		public List<vipapis.marketplace.delivery.ShipPackage> GetPackages(){
			return this.packages_;
		}
		
		public void SetPackages(List<vipapis.marketplace.delivery.ShipPackage> value){
			this.packages_ = value;
		}
		
	}
	
}