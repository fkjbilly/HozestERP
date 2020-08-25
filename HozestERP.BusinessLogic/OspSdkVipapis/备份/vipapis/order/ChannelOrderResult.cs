using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.order{
	
	
	
	
	
	public class ChannelOrderResult {
		
		///<summary>
		/// 订单号
		/// @sampleValue order_sn 15013055143441
		///</summary>
		
		private long? order_sn_;
		
		///<summary>
		/// 订单状态
		/// @sampleValue order_status 订单已审核
		///</summary>
		
		private string order_status_;
		
		///<summary>
		/// 运费
		/// @sampleValue carriage 10.0
		///</summary>
		
		private double? carriage_;
		
		///<summary>
		/// 订单金额（应支付）
		/// @sampleValue money 58.5
		///</summary>
		
		private double? money_;
		
		///<summary>
		/// 下单时间
		/// @sampleValue add_time 2015-06-06 10:25:38
		///</summary>
		
		private string add_time_;
		
		///<summary>
		/// 订单支付时间
		/// @sampleValue pay_time 2015-06-06 10:25:38
		///</summary>
		
		private string pay_time_;
		
		///<summary>
		/// 订单更新时间
		/// @sampleValue update_time 2015-06-06 10:25:38
		///</summary>
		
		private string update_time_;
		
		public long? GetOrder_sn(){
			return this.order_sn_;
		}
		
		public void SetOrder_sn(long? value){
			this.order_sn_ = value;
		}
		public string GetOrder_status(){
			return this.order_status_;
		}
		
		public void SetOrder_status(string value){
			this.order_status_ = value;
		}
		public double? GetCarriage(){
			return this.carriage_;
		}
		
		public void SetCarriage(double? value){
			this.carriage_ = value;
		}
		public double? GetMoney(){
			return this.money_;
		}
		
		public void SetMoney(double? value){
			this.money_ = value;
		}
		public string GetAdd_time(){
			return this.add_time_;
		}
		
		public void SetAdd_time(string value){
			this.add_time_ = value;
		}
		public string GetPay_time(){
			return this.pay_time_;
		}
		
		public void SetPay_time(string value){
			this.pay_time_ = value;
		}
		public string GetUpdate_time(){
			return this.update_time_;
		}
		
		public void SetUpdate_time(string value){
			this.update_time_ = value;
		}
		
	}
	
}