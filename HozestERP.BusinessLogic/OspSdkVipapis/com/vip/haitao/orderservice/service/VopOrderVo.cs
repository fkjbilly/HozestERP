using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.haitao.orderservice.service{
	
	
	
	
	
	public class VopOrderVo {
		
		///<summary>
		/// 订单号
		///</summary>
		
		private string orderSn_;
		
		///<summary>
		/// 交接状态
		///</summary>
		
		private int? status_;
		
		///<summary>
		/// 交接状态
		///</summary>
		
		private string connectTime_;
		
		///<summary>
		/// 描述
		///</summary>
		
		private string message_;
		
		///<summary>
		/// 重量
		///</summary>
		
		private double? weight_;
		
		///<summary>
		/// 体积
		///</summary>
		
		private double? volume_;
		
		public string GetOrderSn(){
			return this.orderSn_;
		}
		
		public void SetOrderSn(string value){
			this.orderSn_ = value;
		}
		public int? GetStatus(){
			return this.status_;
		}
		
		public void SetStatus(int? value){
			this.status_ = value;
		}
		public string GetConnectTime(){
			return this.connectTime_;
		}
		
		public void SetConnectTime(string value){
			this.connectTime_ = value;
		}
		public string GetMessage(){
			return this.message_;
		}
		
		public void SetMessage(string value){
			this.message_ = value;
		}
		public double? GetWeight(){
			return this.weight_;
		}
		
		public void SetWeight(double? value){
			this.weight_ = value;
		}
		public double? GetVolume(){
			return this.volume_;
		}
		
		public void SetVolume(double? value){
			this.volume_ = value;
		}
		
	}
	
}