using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.marketplace.delivery{
	
	
	
	
	
	public class EditedShipInfo {
		
		///<summary>
		/// 订单号
		///</summary>
		
		private string order_id_;
		
		///<summary>
		/// 承运商编号
		///</summary>
		
		private string carrier_code_;
		
		///<summary>
		/// 承运商名称
		///</summary>
		
		private string carrier_name_;
		
		///<summary>
		/// 包裹类型:1 单包裹 ，2多包裹
		///</summary>
		
		private int? package_type_;
		
		///<summary>
		/// 创建人
		///</summary>
		
		private string create_by_;
		
		///<summary>
		/// 包裹列表
		///</summary>
		
		private List<vipapis.marketplace.delivery.EditedPackage> edited_packages_;
		
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
		public string GetCreate_by(){
			return this.create_by_;
		}
		
		public void SetCreate_by(string value){
			this.create_by_ = value;
		}
		public List<vipapis.marketplace.delivery.EditedPackage> GetEdited_packages(){
			return this.edited_packages_;
		}
		
		public void SetEdited_packages(List<vipapis.marketplace.delivery.EditedPackage> value){
			this.edited_packages_ = value;
		}
		
	}
	
}