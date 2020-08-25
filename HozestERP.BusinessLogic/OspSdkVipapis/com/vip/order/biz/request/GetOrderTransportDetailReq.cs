using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.request{
	
	
	
	
	
	public class GetOrderTransportDetailReq {
		
		///<summary>
		/// 会员ID
		///</summary>
		
		private long? userId_;
		
		///<summary>
		/// 订单SN
		///</summary>
		
		private string orderSn_;
		
		///<summary>
		/// 订单分发明细
		///</summary>
		
		private com.vip.order.common.pojo.order.vo.OrderDeliveryVO orderDelivery_;
		
		///<summary>
		/// 订单类型vipClub,pincang:品仓订单（必传）
		///</summary>
		
		private string vipClub_;
		
		public long? GetUserId(){
			return this.userId_;
		}
		
		public void SetUserId(long? value){
			this.userId_ = value;
		}
		public string GetOrderSn(){
			return this.orderSn_;
		}
		
		public void SetOrderSn(string value){
			this.orderSn_ = value;
		}
		public com.vip.order.common.pojo.order.vo.OrderDeliveryVO GetOrderDelivery(){
			return this.orderDelivery_;
		}
		
		public void SetOrderDelivery(com.vip.order.common.pojo.order.vo.OrderDeliveryVO value){
			this.orderDelivery_ = value;
		}
		public string GetVipClub(){
			return this.vipClub_;
		}
		
		public void SetVipClub(string value){
			this.vipClub_ = value;
		}
		
	}
	
}