using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.delivery{
	
	
	
	
	
	public class ConfirmReturnOrderRequest {
		
		///<summary>
		/// 供应商ID
		///</summary>
		
		private int? vendor_id_;
		
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
		/// 运单号
		///</summary>
		
		private string delivery_no_;
		
		///<summary>
		/// 备注信息
		///</summary>
		
		private string note_;
		
		///<summary>
		/// 退货或者拒收商品详情列表
		///</summary>
		
		private List<vipapis.delivery.ReturnGoods> goods_list_;
		
		public int? GetVendor_id(){
			return this.vendor_id_;
		}
		
		public void SetVendor_id(int? value){
			this.vendor_id_ = value;
		}
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
		public string GetDelivery_no(){
			return this.delivery_no_;
		}
		
		public void SetDelivery_no(string value){
			this.delivery_no_ = value;
		}
		public string GetNote(){
			return this.note_;
		}
		
		public void SetNote(string value){
			this.note_ = value;
		}
		public List<vipapis.delivery.ReturnGoods> GetGoods_list(){
			return this.goods_list_;
		}
		
		public void SetGoods_list(List<vipapis.delivery.ReturnGoods> value){
			this.goods_list_ = value;
		}
		
	}
	
}