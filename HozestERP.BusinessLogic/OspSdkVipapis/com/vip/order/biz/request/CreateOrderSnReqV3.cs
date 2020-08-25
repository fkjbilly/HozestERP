using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.request{
	
	
	
	
	
	public class CreateOrderSnReqV3 {
		
		///<summary>
		/// 生成订单号个数 
		///</summary>
		
		private int? num_;
		
		///<summary>
		/// 用户id
		///</summary>
		
		private long? userId_;
		
		public int? GetNum(){
			return this.num_;
		}
		
		public void SetNum(int? value){
			this.num_ = value;
		}
		public long? GetUserId(){
			return this.userId_;
		}
		
		public void SetUserId(long? value){
			this.userId_ = value;
		}
		
	}
	
}