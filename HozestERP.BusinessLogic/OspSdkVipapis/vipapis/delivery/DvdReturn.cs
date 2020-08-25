using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.delivery{
	
	
	
	
	
	public class DvdReturn {
		
		///<summary>
		/// 供应商ID
		/// @sampleValue vendor_id 
		///</summary>
		
		private int? vendor_id_;
		
		///<summary>
		/// 订单编号
		/// @sampleValue order_id 
		///</summary>
		
		private string order_id_;
		
		///<summary>
		/// 退货申请单状态
		/// @sampleValue return_status 
		///</summary>
		
		private string return_status_;
		
		///<summary>
		/// 退货原因
		/// @sampleValue return_reason 
		///</summary>
		
		private string return_reason_;
		
		///<summary>
		/// 从b2c拉取客退订单状态时间
		/// @sampleValue create_time 
		///</summary>
		
		private string create_time_;
		
		///<summary>
		/// 客退申请单号
		/// @sampleValue back_sn 
		///</summary>
		
		private string back_sn_;
		
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
		public string GetReturn_status(){
			return this.return_status_;
		}
		
		public void SetReturn_status(string value){
			this.return_status_ = value;
		}
		public string GetReturn_reason(){
			return this.return_reason_;
		}
		
		public void SetReturn_reason(string value){
			this.return_reason_ = value;
		}
		public string GetCreate_time(){
			return this.create_time_;
		}
		
		public void SetCreate_time(string value){
			this.create_time_ = value;
		}
		public string GetBack_sn(){
			return this.back_sn_;
		}
		
		public void SetBack_sn(string value){
			this.back_sn_ = value;
		}
		
	}
	
}