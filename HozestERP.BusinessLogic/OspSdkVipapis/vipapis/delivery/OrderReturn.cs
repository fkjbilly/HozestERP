using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.delivery{
	
	
	
	
	
	public class OrderReturn {
		
		///<summary>
		/// 客退申请单号
		///</summary>
		
		private string order_return_id_;
		
		///<summary>
		/// 订单号
		///</summary>
		
		private string order_id_;
		
		///<summary>
		/// 退货类型(0:拒收；1:客退；2:取消客退)
		///</summary>
		
		private int? return_type_;
		
		///<summary>
		/// 是否需供应商审核(0:不需要；1：需要)
		///</summary>
		
		private int? vendor_need_audit_;
		
		///<summary>
		/// 退货原因
		///</summary>
		
		private string return_reason_;
		
		///<summary>
		/// 客退申请时间
		///</summary>
		
		private string return_time_;
		
		///<summary>
		/// 客退运单号
		///</summary>
		
		private string transport_no_;
		
		///<summary>
		/// 退货快递承运商
		///</summary>
		
		private string carrier_;
		
		public string GetOrder_return_id(){
			return this.order_return_id_;
		}
		
		public void SetOrder_return_id(string value){
			this.order_return_id_ = value;
		}
		public string GetOrder_id(){
			return this.order_id_;
		}
		
		public void SetOrder_id(string value){
			this.order_id_ = value;
		}
		public int? GetReturn_type(){
			return this.return_type_;
		}
		
		public void SetReturn_type(int? value){
			this.return_type_ = value;
		}
		public int? GetVendor_need_audit(){
			return this.vendor_need_audit_;
		}
		
		public void SetVendor_need_audit(int? value){
			this.vendor_need_audit_ = value;
		}
		public string GetReturn_reason(){
			return this.return_reason_;
		}
		
		public void SetReturn_reason(string value){
			this.return_reason_ = value;
		}
		public string GetReturn_time(){
			return this.return_time_;
		}
		
		public void SetReturn_time(string value){
			this.return_time_ = value;
		}
		public string GetTransport_no(){
			return this.transport_no_;
		}
		
		public void SetTransport_no(string value){
			this.transport_no_ = value;
		}
		public string GetCarrier(){
			return this.carrier_;
		}
		
		public void SetCarrier(string value){
			this.carrier_ = value;
		}
		
	}
	
}