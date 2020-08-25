using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.request{
	
	
	
	
	
	public class CheckCashOnDeliveryReq {
		
		///<summary>
		/// 订单id
		///</summary>
		
		private long? orderId_;
		
		///<summary>
		/// 订单sn
		///</summary>
		
		private string orderSn_;
		
		///<summary>
		/// 用户id
		///</summary>
		
		private long? userId_;
		
		///<summary>
		/// 订单金额
		///</summary>
		
		private string money_;
		
		///<summary>
		/// 区域代码
		///</summary>
		
		private string areaCode_;
		
		///<summary>
		/// 移动电话
		///</summary>
		
		private string mobile_;
		
		///<summary>
		/// 固定电话
		///</summary>
		
		private string tel_;
		
		///<summary>
		/// 移动电话
		///</summary>
		
		private string vipclub_;
		
		///<summary>
		/// 销售模式
		///</summary>
		
		private string specialType_;
		
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
		public long? GetUserId(){
			return this.userId_;
		}
		
		public void SetUserId(long? value){
			this.userId_ = value;
		}
		public string GetMoney(){
			return this.money_;
		}
		
		public void SetMoney(string value){
			this.money_ = value;
		}
		public string GetAreaCode(){
			return this.areaCode_;
		}
		
		public void SetAreaCode(string value){
			this.areaCode_ = value;
		}
		public string GetMobile(){
			return this.mobile_;
		}
		
		public void SetMobile(string value){
			this.mobile_ = value;
		}
		public string GetTel(){
			return this.tel_;
		}
		
		public void SetTel(string value){
			this.tel_ = value;
		}
		public string GetVipclub(){
			return this.vipclub_;
		}
		
		public void SetVipclub(string value){
			this.vipclub_ = value;
		}
		public string GetSpecialType(){
			return this.specialType_;
		}
		
		public void SetSpecialType(string value){
			this.specialType_ = value;
		}
		
	}
	
}