using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.delivery{
	
	
	
	
	
	public class RefuseOrReturnOrder {
		
		///<summary>
		/// 订单编号
		///</summary>
		
		private string order_id_;
		
		///<summary>
		/// 承运商名称
		///</summary>
		
		private string carrier_name_;
		
		///<summary>
		/// 运单号
		///</summary>
		
		private string transport_no_;
		
		///<summary>
		/// 拒收商品列表
		///</summary>
		
		private List<vipapis.delivery.RefuseOrReturnProduct> refuse_or_return_product_list_;
		
		public string GetOrder_id(){
			return this.order_id_;
		}
		
		public void SetOrder_id(string value){
			this.order_id_ = value;
		}
		public string GetCarrier_name(){
			return this.carrier_name_;
		}
		
		public void SetCarrier_name(string value){
			this.carrier_name_ = value;
		}
		public string GetTransport_no(){
			return this.transport_no_;
		}
		
		public void SetTransport_no(string value){
			this.transport_no_ = value;
		}
		public List<vipapis.delivery.RefuseOrReturnProduct> GetRefuse_or_return_product_list(){
			return this.refuse_or_return_product_list_;
		}
		
		public void SetRefuse_or_return_product_list(List<vipapis.delivery.RefuseOrReturnProduct> value){
			this.refuse_or_return_product_list_ = value;
		}
		
	}
	
}