using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.overseas{
	
	
	
	
	
	public class OrderStatusItem {
		
		///<summary>
		/// 订单编号
		/// @sampleValue order_id 14090119735437
		///</summary>
		
		private string order_id_;
		
		///<summary>
		/// 订单状态
		/// @sampleValue order_status 004，达到海外仓库；005，拣货中；006，缺货；007，已OQC交接；
		///</summary>
		
		private string order_status_;
		
		///<summary>
		/// 备注,当订单状态为缺货是必填
		///</summary>
		
		private string memo_;
		
		///<summary>
		/// 更新时间
		/// @sampleValue create_time 2015-09-22 11:30:48
		///</summary>
		
		private string create_time_;
		
		///<summary>
		/// 订单ID,长度为15,由仓库标识(4位)+自增主健id(11位,不足位前面补0)联合组成
		/// @sampleValue logistics_id GZZY000000000123
		///</summary>
		
		private string logistics_id_;
		
		public string GetOrder_id(){
			return this.order_id_;
		}
		
		public void SetOrder_id(string value){
			this.order_id_ = value;
		}
		public string GetOrder_status(){
			return this.order_status_;
		}
		
		public void SetOrder_status(string value){
			this.order_status_ = value;
		}
		public string GetMemo(){
			return this.memo_;
		}
		
		public void SetMemo(string value){
			this.memo_ = value;
		}
		public string GetCreate_time(){
			return this.create_time_;
		}
		
		public void SetCreate_time(string value){
			this.create_time_ = value;
		}
		public string GetLogistics_id(){
			return this.logistics_id_;
		}
		
		public void SetLogistics_id(string value){
			this.logistics_id_ = value;
		}
		
	}
	
}