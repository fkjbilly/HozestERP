using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.delivery{
	
	
	
	
	
	public class RefuseOrReturnProductResultInfo {
		
		///<summary>
		/// 订单编号
		///</summary>
		
		private string order_id_;
		
		///<summary>
		/// 供应商Id
		///</summary>
		
		private string vendor_id_;
		
		///<summary>
		/// 运单号
		///</summary>
		
		private string transport_no_;
		
		///<summary>
		/// 承运商名称
		///</summary>
		
		private string carrier_name_;
		
		///<summary>
		/// 商品列表
		///</summary>
		
		private List<vipapis.delivery.RefuseOrReturnProduct> product_list_;
		
		///<summary>
		/// 错误信息
		///</summary>
		
		private string error_msg_;
		
		public string GetOrder_id(){
			return this.order_id_;
		}
		
		public void SetOrder_id(string value){
			this.order_id_ = value;
		}
		public string GetVendor_id(){
			return this.vendor_id_;
		}
		
		public void SetVendor_id(string value){
			this.vendor_id_ = value;
		}
		public string GetTransport_no(){
			return this.transport_no_;
		}
		
		public void SetTransport_no(string value){
			this.transport_no_ = value;
		}
		public string GetCarrier_name(){
			return this.carrier_name_;
		}
		
		public void SetCarrier_name(string value){
			this.carrier_name_ = value;
		}
		public List<vipapis.delivery.RefuseOrReturnProduct> GetProduct_list(){
			return this.product_list_;
		}
		
		public void SetProduct_list(List<vipapis.delivery.RefuseOrReturnProduct> value){
			this.product_list_ = value;
		}
		public string GetError_msg(){
			return this.error_msg_;
		}
		
		public void SetError_msg(string value){
			this.error_msg_ = value;
		}
		
	}
	
}