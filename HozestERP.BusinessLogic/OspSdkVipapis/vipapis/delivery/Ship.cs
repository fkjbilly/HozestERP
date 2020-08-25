using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.delivery{
	
	
	
	
	
	public class Ship {
		
		///<summary>
		/// 订单号码
		/// @sampleValue order_id 
		///</summary>
		
		private string order_id_;
		
		///<summary>
		/// 承运商编码
		/// @sampleValue carrier_code 
		///</summary>
		
		private string carrier_code_;
		
		///<summary>
		/// 承运商名称
		/// @sampleValue carrier_name 
		///</summary>
		
		private string carrier_name_;
		
		///<summary>
		/// 包裹类型：1，单包裹；2，多包裹
		/// @sampleValue package_type 
		///</summary>
		
		private string package_type_;
		
		///<summary>
		/// 包裹信息
		/// @sampleValue packages 
		///</summary>
		
		private List<vipapis.delivery.Package> packages_;
		
		///<summary>
		/// 返回发货失败信息
		/// @sampleValue error_msg 
		///</summary>
		
		private string error_msg_;
		
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
		public string GetPackage_type(){
			return this.package_type_;
		}
		
		public void SetPackage_type(string value){
			this.package_type_ = value;
		}
		public List<vipapis.delivery.Package> GetPackages(){
			return this.packages_;
		}
		
		public void SetPackages(List<vipapis.delivery.Package> value){
			this.packages_ = value;
		}
		public string GetError_msg(){
			return this.error_msg_;
		}
		
		public void SetError_msg(string value){
			this.error_msg_ = value;
		}
		
	}
	
}