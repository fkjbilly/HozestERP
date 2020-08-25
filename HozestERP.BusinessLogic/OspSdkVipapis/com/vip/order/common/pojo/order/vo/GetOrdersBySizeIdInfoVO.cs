using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.common.pojo.order.vo{
	
	
	
	
	
	public class GetOrdersBySizeIdInfoVO {
		
		///<summary>
		/// 订单id
		///</summary>
		
		private long? id_;
		
		///<summary>
		/// 订单编号
		///</summary>
		
		private string orderSn_;
		
		///<summary>
		/// 登录名
		///</summary>
		
		private string userName_;
		
		///<summary>
		/// 在线支付金额
		///</summary>
		
		private string money_;
		
		///<summary>
		/// 在线支付金额
		///</summary>
		
		private string surplus_;
		
		///<summary>
		/// 唯品卡支付金额
		///</summary>
		
		private string favMoney_;
		
		///<summary>
		/// 订单状态
		///</summary>
		
		private int? orderStatus_;
		
		///<summary>
		/// 购买的当前商品数量
		///</summary>
		
		private int? amount_;
		
		///<summary>
		/// 下单时间
		///</summary>
		
		private long? addTime_;
		
		public long? GetId(){
			return this.id_;
		}
		
		public void SetId(long? value){
			this.id_ = value;
		}
		public string GetOrderSn(){
			return this.orderSn_;
		}
		
		public void SetOrderSn(string value){
			this.orderSn_ = value;
		}
		public string GetUserName(){
			return this.userName_;
		}
		
		public void SetUserName(string value){
			this.userName_ = value;
		}
		public string GetMoney(){
			return this.money_;
		}
		
		public void SetMoney(string value){
			this.money_ = value;
		}
		public string GetSurplus(){
			return this.surplus_;
		}
		
		public void SetSurplus(string value){
			this.surplus_ = value;
		}
		public string GetFavMoney(){
			return this.favMoney_;
		}
		
		public void SetFavMoney(string value){
			this.favMoney_ = value;
		}
		public int? GetOrderStatus(){
			return this.orderStatus_;
		}
		
		public void SetOrderStatus(int? value){
			this.orderStatus_ = value;
		}
		public int? GetAmount(){
			return this.amount_;
		}
		
		public void SetAmount(int? value){
			this.amount_ = value;
		}
		public long? GetAddTime(){
			return this.addTime_;
		}
		
		public void SetAddTime(long? value){
			this.addTime_ = value;
		}
		
	}
	
}