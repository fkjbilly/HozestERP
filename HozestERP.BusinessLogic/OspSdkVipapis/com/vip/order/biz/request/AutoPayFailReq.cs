using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.request{
	
	
	
	
	
	public class AutoPayFailReq {
		
		///<summary>
		/// 用户ID
		///</summary>
		
		private long? userId_;
		
		///<summary>
		/// 订单sn
		///</summary>
		
		private string orderSn_;
		
		///<summary>
		/// 失败错误码
		///</summary>
		
		private int? failCode_;
		
		///<summary>
		/// 失败的原因描述
		///</summary>
		
		private string failMsg_;
		
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
		public int? GetFailCode(){
			return this.failCode_;
		}
		
		public void SetFailCode(int? value){
			this.failCode_ = value;
		}
		public string GetFailMsg(){
			return this.failMsg_;
		}
		
		public void SetFailMsg(string value){
			this.failMsg_ = value;
		}
		
	}
	
}