using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.request{
	
	
	
	
	
	public class UpdateReservationStateReq {
		
		///<summary>
		/// 用户Id
		///</summary>
		
		private long? userId_;
		
		///<summary>
		/// 订单ID
		///</summary>
		
		private long? orderId_;
		
		///<summary>
		/// 订单ID
		///</summary>
		
		private string orderSn_;
		
		///<summary>
		/// size_id
		///</summary>
		
		private List<long?> merItemNoList_;
		
		///<summary>
		/// 授权状态：1(未授权)、2(已授权)、3(取消)
		///</summary>
		
		private string reservationState_;
		
		public long? GetUserId(){
			return this.userId_;
		}
		
		public void SetUserId(long? value){
			this.userId_ = value;
		}
		public long? GetOrderId(){
			return this.orderId_;
		}
		
		public void SetOrderId(long? value){
			this.orderId_ = value;
		}
		public string GetOrderSn(){
			return this.orderSn_;
		}
		
		public void SetOrderSn(string value){
			this.orderSn_ = value;
		}
		public List<long?> GetMerItemNoList(){
			return this.merItemNoList_;
		}
		
		public void SetMerItemNoList(List<long?> value){
			this.merItemNoList_ = value;
		}
		public string GetReservationState(){
			return this.reservationState_;
		}
		
		public void SetReservationState(string value){
			this.reservationState_ = value;
		}
		
	}
	
}