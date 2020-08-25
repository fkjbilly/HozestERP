using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.sce.vlg.osp.wms.service{
	
	
	
	
	
	public class CarrierInfo {
		
		///<summary>
		/// 数据的唯一标识
		///</summary>
		
		private string cust_data_id_;
		
		///<summary>
		/// 订单号
		///</summary>
		
		private string order_sn_;
		
		///<summary>
		/// 运单号
		///</summary>
		
		private string transport_no_;
		
		///<summary>
		/// 状态编码
		///</summary>
		
		private int? order_status_;
		
		///<summary>
		/// 跟踪信息描述
		///</summary>
		
		private string order_status_info_;
		
		///<summary>
		/// 当前所在地
		///</summary>
		
		private string current_city_;
		
		///<summary>
		/// 当前状态时间,格式：yyyy-MM-dd HH:mm:ss
		///</summary>
		
		private string create_time_;
		
		public string GetCust_data_id(){
			return this.cust_data_id_;
		}
		
		public void SetCust_data_id(string value){
			this.cust_data_id_ = value;
		}
		public string GetOrder_sn(){
			return this.order_sn_;
		}
		
		public void SetOrder_sn(string value){
			this.order_sn_ = value;
		}
		public string GetTransport_no(){
			return this.transport_no_;
		}
		
		public void SetTransport_no(string value){
			this.transport_no_ = value;
		}
		public int? GetOrder_status(){
			return this.order_status_;
		}
		
		public void SetOrder_status(int? value){
			this.order_status_ = value;
		}
		public string GetOrder_status_info(){
			return this.order_status_info_;
		}
		
		public void SetOrder_status_info(string value){
			this.order_status_info_ = value;
		}
		public string GetCurrent_city(){
			return this.current_city_;
		}
		
		public void SetCurrent_city(string value){
			this.current_city_ = value;
		}
		public string GetCreate_time(){
			return this.create_time_;
		}
		
		public void SetCreate_time(string value){
			this.create_time_ = value;
		}
		
	}
	
}