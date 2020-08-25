using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.request{
	
	
	
	
	
	public class AutoPayReq {
		
		///<summary>
		/// 用户ID
		///</summary>
		
		private long? userId_;
		
		///<summary>
		/// 订单sn列表
		///</summary>
		
		private List<string> orderSnList_;
		
		///<summary>
		/// payId
		///</summary>
		
		private int? payId_;
		
		///<summary>
		/// payType
		///</summary>
		
		private int? payType_;
		
		public long? GetUserId(){
			return this.userId_;
		}
		
		public void SetUserId(long? value){
			this.userId_ = value;
		}
		public List<string> GetOrderSnList(){
			return this.orderSnList_;
		}
		
		public void SetOrderSnList(List<string> value){
			this.orderSnList_ = value;
		}
		public int? GetPayId(){
			return this.payId_;
		}
		
		public void SetPayId(int? value){
			this.payId_ = value;
		}
		public int? GetPayType(){
			return this.payType_;
		}
		
		public void SetPayType(int? value){
			this.payType_ = value;
		}
		
	}
	
}